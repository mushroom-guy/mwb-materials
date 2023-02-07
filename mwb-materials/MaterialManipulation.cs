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
        private static string AlbedoNomenclature = "_rgb";
        private static string AmbientOcclusionNomenclature = "_o";
        private static string RoughnessNomenclature = "_r";
        private static string GlossNomenclature = "_g";
        private static string MetalnessNomenclature = "_alpha";
        private static string NormalNomenclature = "_n";
        private static Bitmap InvalidBitmap = new Bitmap(1, 1);

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

        private static async Task ConvertImageToRGB(Bitmap src)
        {
            if (src == InvalidBitmap)
            {
                return;
            }

            await Task.Run(() =>
            {
                for (int y = 0; y < src.Height; y++)
                {
                    for (int x = 0; x < src.Width; x++)
                    {
                        src.SetPixel(x, y, ConvertColorToRGB(src.GetPixel(x, y)));
                    }
                }
            });
        }

        private static async Task DumpGrayscaleInChannel(Bitmap src, Bitmap grayscale, TextureChannel channel)
        {
            if (src == InvalidBitmap || grayscale == InvalidBitmap)
            {
                return;
            }

            Bitmap grayscaleCopy = new Bitmap(grayscale);

            await Task.Run(() =>
            {
                for (int y = 0; y < src.Height; y++)
                {
                    for (int x = 0; x < src.Width; x++)
                    {
                        Color pixel = grayscaleCopy.GetPixel(x, y);
                        int grayscaleVal = (pixel.R + pixel.G + pixel.B) / 3;

                        pixel = src.GetPixel(x, y);

                        byte[] colors = new byte[] { pixel.A, pixel.R, pixel.G, pixel.B };
                        colors[(int)channel] = (byte)grayscaleVal;

                        src.SetPixel(x, y, Color.FromArgb(colors[0], colors[1], colors[2], colors[3]));
                    }
                }

                grayscaleCopy.Dispose();
            });
        }

        private static async Task ApplyAmbientOcclusion(Bitmap src, Bitmap ao, int divStrength = 1)
        {
            if (src == InvalidBitmap || ao == InvalidBitmap)
            {
                return;
            }

            Bitmap aoCopy = new Bitmap(ao);

            await Task.Run(() =>
            {
                for (int y = 0; y < src.Height; y++)
                {
                    for (int x = 0; x < src.Width; x++)
                    {
                        Color aoColor = aoCopy.GetPixel(x, y);
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

                aoCopy.Dispose();
            });
        }

        private static async Task<Bitmap> LoadImage(string file)
        {
            Bitmap image = await Task.Run<Bitmap>(() => { return new Bitmap(Image.FromFile(file)); });
            return image;
        }

        private static async Task<Bitmap> EmptyImage()
        {
            Bitmap image = await Task.Run<Bitmap>(() => { return InvalidBitmap; });
            return image;
        }

        public static async Task<SourceTextureSet> GenerateTexturesAsync(string[] files)
        {
            Task<Bitmap> albedoTask = EmptyImage();
            Task<Bitmap> ambientOcclusionTask = EmptyImage();
            Task<Bitmap> roughnessTask = EmptyImage();
            Task<Bitmap> glossTask = EmptyImage();
            Task<Bitmap> metalnessTask = EmptyImage();
            Task<Bitmap> normalTask = EmptyImage();

            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                name = name.ToLower();

                if (name.EndsWith(AlbedoNomenclature))
                    albedoTask = LoadImage(file);

                if (name.EndsWith(AmbientOcclusionNomenclature))
                    ambientOcclusionTask = LoadImage(file);

                if (name.EndsWith(RoughnessNomenclature))
                    roughnessTask = LoadImage(file);

                if (name.EndsWith(GlossNomenclature))
                    glossTask = LoadImage(file);

                if (name.EndsWith(MetalnessNomenclature))
                    metalnessTask = LoadImage(file);

                if (name.EndsWith(NormalNomenclature))
                    normalTask = LoadImage(file);
            }

            Bitmap albedo = await albedoTask;
            Bitmap ambientOcclusion = await ambientOcclusionTask;
            Bitmap roughness = await roughnessTask;
            Bitmap gloss = await glossTask;
            Bitmap metalness = await metalnessTask;
            Bitmap normal = await normalTask;

            //convert to rgb:
            // roughness / gloss need to be converted from srgb
            // why not metalness as well? who knows
            // same for albedo (although i think we should, but color2 kinda does it already)
            Task roughnessRgbTask = ConvertImageToRGB(roughness);
            Task glossRgbTask = ConvertImageToRGB(gloss);

            await roughnessRgbTask;
            await glossRgbTask;

            //apply ao to the ones that need it
            Task albedoAoTask = ApplyAmbientOcclusion(albedo, ambientOcclusion, 2);
            Task metalnessAoTask = ApplyAmbientOcclusion(metalness, ambientOcclusion);
            Task roughnessAoTask = ApplyAmbientOcclusion(roughness, ambientOcclusion);
            Task glossAoTask = ApplyAmbientOcclusion(gloss, ambientOcclusion);

            await albedoAoTask;
            await metalnessAoTask;
            await roughnessAoTask;
            await glossAoTask;

            //albedo:
            // put metalness in alpha channel
            Task albedoGrayscaleTask = DumpGrayscaleInChannel(albedo, metalness, TextureChannel.Alpha);

            //normal:
            // put roughness in alpha channel
            Task normalGrayscaleTask = DumpGrayscaleInChannel(normal, (gloss != InvalidBitmap) ? gloss : roughness, TextureChannel.Alpha);

            //exponent:
            // put roughness in red channel
            // put metalness in green channel
            Bitmap exponent = null;

            if (gloss != InvalidBitmap || roughness != InvalidBitmap)
            {
                Bitmap target = (gloss != InvalidBitmap) ? gloss : roughness;

                exponent = new Bitmap(target.Width, target.Height);
                await DumpGrayscaleInChannel(exponent, target, TextureChannel.Red);
            }
            
            if (metalness != InvalidBitmap)
            {
                if (exponent == null)
                {
                    exponent = new Bitmap(metalness.Width, metalness.Height);
                }

                await DumpGrayscaleInChannel (exponent, metalness, TextureChannel.Green);
            }

            await albedoGrayscaleTask;
            await normalGrayscaleTask;

            //dispose unused
            ambientOcclusion?.Dispose();
            gloss?.Dispose();
            roughness?.Dispose();
            metalness?.Dispose();

            return new SourceTextureSet(albedo, exponent, normal);
        }
    }
}
