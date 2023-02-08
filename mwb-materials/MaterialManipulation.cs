using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
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

        public enum TextureChannel
        {
            Blue,
            Green,
            Red,
            Alpha
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
            }
        }

        private static Color ConvertColorToRGB(Color col)
        {
            double R = (double)col.R / 255.0;
            double G = (double)col.G / 255.0;
            double B = (double)col.B / 255.0;
            double A = (double)col.A / 255.0;

            if (R <= 0.04045)
                R /= 12.92;
            else
                R = Math.Pow((R + 0.055) / 1.055, 2.4);

            if (G <= 0.04045)
                G /= 12.92;
            else
                G = Math.Pow((G + 0.055) / 1.055, 2.4);

            if (B <= 0.04045)
                B /= 12.92;
            else
                B = Math.Pow((B + 0.055) / 1.055, 2.4);

            if (A <= 0.04045)
                A /= 12.92;
            else
                A = Math.Pow((A + 0.055) / 1.055, 2.4);

            return Color.FromArgb(
                (int)(A * 255.0),
                (int)(R * 255.0),
                (int)(G * 255.0),
                (int)(B * 255.0));
        }

        private static void ConvertImageToRGB(Bitmap src)
        {
            if (src == null)
            {
                return;
            }

            FastBitmap fastSrc = new FastBitmap(src);
            fastSrc.Start(ImageLockMode.ReadWrite);

            for (int cursor = 0; cursor < fastSrc.Bytes.Length; cursor += 4)
            {
                fastSrc.WriteColor(cursor, ConvertColorToRGB(fastSrc.ReadColor(cursor)));
            }

            fastSrc.Stop();
        }

        private static void DumpGrayscaleInChannel(Bitmap src, Bitmap grayscale, TextureChannel channel)
        {
            if (src == null || grayscale == null)
            {
                return;
            }

            FastBitmap fastSrc = new FastBitmap(src);
            fastSrc.Start(ImageLockMode.ReadWrite);

            FastBitmap fastGrayscale = new FastBitmap(grayscale);
            fastGrayscale.Start(ImageLockMode.ReadOnly);

            for (int cursor = 0; cursor < fastSrc.Bytes.Length; cursor += 4)
            {
                fastSrc.Bytes[cursor + (int)channel] = (byte)fastGrayscale.ReadGrayscale(cursor);
            }

            fastSrc.Stop();
            fastGrayscale.Stop();
        }

        private static async Task ApplyAmbientOcclusion(Bitmap src, Bitmap ao, int divStrength = 1)
        {
            if (src == null)
            {
                return;
            }

            FastBitmap fastSrc = new FastBitmap(src);
            FastBitmap fastAo = new FastBitmap(new Bitmap(ao));

            await Task.Run(() =>
            {
                fastSrc.Start(ImageLockMode.ReadWrite);
                fastAo.Start(ImageLockMode.ReadOnly);

                for (int cursor = 0; cursor < fastSrc.Bytes.Length; cursor += 4)
                {
                    int gsValue = 255 - fastAo.ReadGrayscale(cursor);
                    gsValue /= divStrength;

                    fastSrc.Bytes[cursor] = (byte)Math.Max(fastSrc.Bytes[cursor] - gsValue, 0);
                    fastSrc.Bytes[cursor + 1] = (byte)Math.Max(fastSrc.Bytes[cursor + 1] - gsValue, 0);
                    fastSrc.Bytes[cursor + 2] = (byte)Math.Max(fastSrc.Bytes[cursor + 2] - gsValue, 0);
                }

                fastSrc.Stop();

                fastAo.Stop();
                fastAo.Dispose();
            });
        }

        private static Bitmap LoadImage(string file)
        {
            return new Bitmap(Image.FromFile(file));
        }

        public static async Task<SourceTextureSet> GenerateTexturesAsync(string[] files, Action<int, string> progressFunc)
        {
            progressFunc(0, "Started");

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

                if (name.EndsWith(AlbedoNomenclature))
                {
                    albedo = LoadImage(file);
                    continue;
                }

                if (name.EndsWith(AmbientOcclusionNomenclature))
                {
                    ambientOcclusion = LoadImage(file);
                    continue;
                }

                if (name.EndsWith(RoughnessNomenclature))
                {
                    roughness = LoadImage(file);
                    continue;
                }

                if (name.EndsWith(GlossNomenclature))
                {   
                    gloss = LoadImage(file);
                    continue;
                }

                if (name.EndsWith(MetalnessNomenclature))
                {
                    metalness = LoadImage(file);
                    continue;
                }

                if (name.EndsWith(NormalNomenclature))
                {
                    normal = LoadImage(file);
                    continue;
                }
            }

            //convert to rgb:
            // roughness / gloss need to be converted from srgb
            // why not metalness as well? who knows
            // same for albedo (although i think we should, but color2 kinda does it already)
            Task roughRgb = Task.Run(() => { ConvertImageToRGB(roughness); });
            Task glossRgb = Task.Run(() => { ConvertImageToRGB(gloss); });

            progressFunc(20, "Converting to RGB...");
            await roughRgb; await glossRgb;

            //apply ao to the ones that need it
            if (ambientOcclusion != null)
            {
                Task albedoAo = ApplyAmbientOcclusion(albedo, ambientOcclusion, 2);
                Task metalnessAo = ApplyAmbientOcclusion(metalness, ambientOcclusion);
                Task roughnessAo = ApplyAmbientOcclusion(roughness, ambientOcclusion);
                Task glossAo = ApplyAmbientOcclusion(gloss, ambientOcclusion);

                progressFunc(50, "Applying ambient occlusion...");
                await albedoAo; await metalnessAo; await roughnessAo; await glossAo;

                ambientOcclusion.Dispose();
            }

            //albedo:
            // put metalness in alpha channel
            Task albedoTask = Task.CompletedTask;
            Task normalTask = Task.CompletedTask;

            if (metalness != null)
            {
                albedoTask = Task.Run(() => { DumpGrayscaleInChannel(albedo, metalness, TextureChannel.Alpha); });
            }

            //normal:
            // put roughness in alpha channel
            if (gloss != null || roughness != null)
            {
                normalTask = Task.Run(() => { DumpGrayscaleInChannel(normal, (gloss != null) ? gloss : roughness, TextureChannel.Alpha); });
            }

            progressFunc(70, "Generating Source textures...");
            await albedoTask; await normalTask;

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

            //dispose unused
            gloss?.Dispose();
            roughness?.Dispose();
            metalness?.Dispose();

            progressFunc(100, "Done!");
            return new SourceTextureSet(albedo, exponent, normal);
        }
    }
}
