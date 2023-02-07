using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials
{
    /*
    normal map alpha - mask for phong intensity (this will be the roughness converted to RGB)
    basetexture alpha - metalness of course :))
    exponent - red channel roughness converted to RGB. green channel metalness, blue channel 100% white (or black, or even a bentley image if you feel so devious)
    */

    class MaterialManipulation
    {
        private static string NOMEN_ALBEDO = "_rgb";
        private static string NOMEN_AO = "_o";
        private static string NOMEN_ROUGHNESS = "_r";
        private static string NOMEN_GLOSS = "_g";
        private static string NOMEN_METALNESS = "_alpha";
        private static string NOMEN_NORMAL = "_n";

        public enum TextureChannel
        {
            Alpha,
            Red,
            Green,
            Blue
        }

        public struct SourceTextureSet : IDisposable
        {
            public SourceTextureSet(Bitmap albedo, Bitmap exponent, Bitmap normal)
            {
                Albedo = albedo;
                Exponent = exponent;
                Normal = normal;
            }

            public Bitmap Albedo { get; }
            public Bitmap Exponent { get; }
            public Bitmap Normal { get; }

            public void Dispose()
            {
                Albedo?.Dispose();
                Exponent?.Dispose();
                Normal?.Dispose();

                GC.SuppressFinalize(this);
            }
        }

        private static Color ConvertColorToRGB(Color col)
        {
            float R = (float)col.R / 255.0f;
            float G = (float)col.G / 255.0f;
            float B = (float)col.B / 255.0f;
            float A = (float)col.A / 255.0f;

            if (R <= 0.04045f)
                R /= 12.92f;
            else
                R = (float)Math.Pow((R + 0.055f) / 1.055f, 2.4f);

            if (G <= 0.04045f)
                G /= 12.92f;
            else
                G = (float)Math.Pow((G + 0.055f) / 1.055f, 2.4f);

            if (B <= 0.04045f)
                B /= 12.92f;
            else
                B = (float)Math.Pow((B + 0.055f) / 1.055f, 2.4f);

            if (A <= 0.04045f)
                A /= 12.92f;
            else
                A = (float)Math.Pow((A + 0.055f) / 1.055f, 2.4f);

            return Color.FromArgb(
                (int)(A * 255.0f),
                (int)(R * 255.0f),
                (int)(G * 255.0f),
                (int)(B * 255.0f));
        }

        private static void ConvertImageToRGB(Bitmap src)
        {
            if (src == null)
            {
                return;
            }

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    src.SetPixel(x, y, ConvertColorToRGB(src.GetPixel(x, y)));
                }
            }
        }

        private static void DumpGrayscaleInChannel(Bitmap src, Bitmap grayscale, TextureChannel channel)
        {
            if (src == null || grayscale == null)
            {
                return;
            }

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color pixel = grayscale.GetPixel(x, y);
                    int grayscaleVal = (pixel.R + pixel.G + pixel.B) / 3;

                    pixel = src.GetPixel(x, y);

                    byte[] colors = new byte[] { pixel.A, pixel.R, pixel.G, pixel.B };
                    colors[(int)channel] = (byte)grayscaleVal;

                    src.SetPixel(x, y, Color.FromArgb(colors[0], colors[1], colors[2], colors[3]));
                }
            }
        }

        private static void ApplyAmbientOcclusion(Bitmap src, Bitmap ao, int divStrength = 1)
        {
            if (src == null || ao == null)
            {
                return;
            }

            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color aoColor = ao.GetPixel(x, y);
                    int aoTotal = 255 - ((aoColor.R + aoColor.G + aoColor.B) / 3);
                    aoTotal /= divStrength;

                    Color rgb = src.GetPixel(x, y);
                    src.SetPixel(x, y, Color.FromArgb(
                        rgb.A,
                        Math.Max(rgb.R - aoTotal, 0),
                        Math.Max(rgb.G - aoTotal, 0),
                        Math.Max(rgb.B - aoTotal, 0)));
                }
            }
        }

        public static SourceTextureSet GenerateTextures(string[] files)
        {
            Bitmap albedo = null;
            Bitmap ambientOcclusion = null;
            Bitmap roughness = null;
            Bitmap gloss = null;
            Bitmap metalness = null;
            Bitmap normal = null;

            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                name = name.ToLower();

                albedo = name.EndsWith(NOMEN_ALBEDO) ? new Bitmap(Image.FromFile(file)) : albedo;
                ambientOcclusion = name.EndsWith(NOMEN_AO) ? new Bitmap(Image.FromFile(file)) : ambientOcclusion;
                roughness = name.EndsWith(NOMEN_ROUGHNESS) ? new Bitmap(Image.FromFile(file)) : roughness;
                gloss = name.EndsWith(NOMEN_GLOSS) ? new Bitmap(Image.FromFile(file)) : gloss;
                metalness = name.EndsWith(NOMEN_METALNESS) ? new Bitmap(Image.FromFile(file)) : metalness;
                normal = name.EndsWith(NOMEN_NORMAL) ? new Bitmap(Image.FromFile(file)) : normal;
            }

            //apply ao to the ones that need it
            ApplyAmbientOcclusion(albedo, ambientOcclusion, 2);
            ApplyAmbientOcclusion(metalness, ambientOcclusion);
            ApplyAmbientOcclusion(roughness, ambientOcclusion);
            ApplyAmbientOcclusion(gloss, ambientOcclusion);

            //convert to rgb:
            // roughness / gloss need to be converted from srgb
            // why not metalness as well? who knows
            // same for albedo (although i think we should, but color2 kinda does it already)
            ConvertImageToRGB(roughness);
            ConvertImageToRGB(gloss);

            //albedo:
            // put metalness in alpha channel
            DumpGrayscaleInChannel(albedo, metalness, TextureChannel.Alpha);

            //exponent:
            // put roughness in red channel
            // put metalness in green channel
            Bitmap exponent = null;

            if (gloss != null || roughness != null)
            {
                Bitmap target = (gloss != null) ? gloss : roughness;

                exponent = new Bitmap(target.Width, target.Height);
                DumpGrayscaleInChannel(exponent, target, TextureChannel.Red);
            }
            
            if (metalness != null)
            {
                if (exponent == null)
                {
                    exponent = new Bitmap(metalness.Width, metalness.Height);
                }

                DumpGrayscaleInChannel(exponent, metalness, TextureChannel.Green);
            }

            //normal
            // put roughness in alpha channel
            DumpGrayscaleInChannel(normal, (gloss != null) ? gloss : roughness, TextureChannel.Alpha);

            //dispose unused
            ambientOcclusion?.Dispose();
            gloss?.Dispose();
            roughness?.Dispose();
            metalness?.Dispose();

            return new SourceTextureSet(albedo, exponent, normal);
        }
    }
}
