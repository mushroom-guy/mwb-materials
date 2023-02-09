using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        private static void ConvertImageToRGB(FastBitmap src)
        {
            if (src == null)
            {
                return;
            }

            //Parallel.ForEach(SteppedIntegerList(0, src.Bytes.Length, 4), (cursor) =>
            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                src.WriteColor(cursor, ConvertColorToRGB(src.ReadColor(cursor)));
            }//);
        }

        private static void DumpGrayscaleInChannel(FastBitmap src, FastBitmap grayscale, TextureChannel channel)
        {
            if (src == null || grayscale == null)
            {
                return;
            }

            //Parallel.ForEach(SteppedIntegerList(0, src.Bytes.Length, 4), (cursor) =>
            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                src.Bytes[cursor + (int)channel] = (byte)grayscale.ReadGrayscale(cursor);
            }//);
        }

        private static IEnumerable<int> SteppedIntegerList(int startIndex, int endEndex, int stepSize)
        {
            for (int i = startIndex; i < endEndex; i += stepSize)
            {
                yield return i;
            }
        }

        private static void ApplyAmbientOcclusion(FastBitmap src, FastBitmap ao, int divStrength = 1)
        {
            if (src == null || ao == null)
            {
                return;
            }

            //Parallel.ForEach(SteppedIntegerList(0, src.Bytes.Length, 4), (cursor) =>
            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                int gsValue = 255 - ao.ReadGrayscale(cursor);
                gsValue /= divStrength;

                src.Bytes[cursor] = (byte)Math.Max(src.Bytes[cursor] - gsValue, 0);
                src.Bytes[cursor + 1] = (byte)Math.Max(src.Bytes[cursor + 1] - gsValue, 0);
                src.Bytes[cursor + 2] = (byte)Math.Max(src.Bytes[cursor + 2] - gsValue, 0);
            }//);
        }

        private static FastBitmap CreateSourceAlbedo(FastBitmap albedo, FastBitmap ambientOcclusion, FastBitmap metalness)
        {
            if (albedo == null)
            {
                return null;
            }

            FastBitmap sourceAlbedo = new FastBitmap(new Bitmap(albedo.Source.Width, albedo.Source.Height));
            sourceAlbedo.Start(ImageLockMode.ReadWrite);

            albedo.DumpInto(sourceAlbedo);

            if (ambientOcclusion != null)
            {
                ApplyAmbientOcclusion(sourceAlbedo, ambientOcclusion, 2);
            }

            if (metalness != null)
            {
                DumpGrayscaleInChannel(sourceAlbedo, metalness, TextureChannel.Alpha);
            }

            sourceAlbedo.Stop();
            return sourceAlbedo;
        }

        private static FastBitmap CreateSourceNormal(FastBitmap normal, FastBitmap roughness)
        {
            if (normal == null)
            {
                return null;
            }

            FastBitmap sourceNormal = new FastBitmap(new Bitmap(normal.Source.Width, normal.Source.Height));
            sourceNormal.Start(ImageLockMode.ReadWrite);

            normal.DumpInto(sourceNormal);

            if (roughness != null)
            {
                DumpGrayscaleInChannel(sourceNormal, roughness, TextureChannel.Alpha);
            }

            sourceNormal.Stop();
            return sourceNormal;
        }

        private static FastBitmap CreateSourceExponent(FastBitmap roughness, FastBitmap metalness)
        {
            if (roughness == null && metalness == null)
            {
                return null;
            }

            Bitmap target = (roughness != null) ? roughness.Source : metalness.Source;

            FastBitmap sourceExponent = new FastBitmap(new Bitmap(target.Width, target.Height));
            sourceExponent.Start(ImageLockMode.ReadWrite);

            if (roughness != null)
            {
                DumpGrayscaleInChannel(sourceExponent, roughness, TextureChannel.Red);
            }

            if (metalness != null)
            {
                DumpGrayscaleInChannel(sourceExponent, metalness, TextureChannel.Green);
            }

            sourceExponent.Stop();
            return sourceExponent;
        }

        private static FastBitmap LoadImage(string file)
        {
            Bitmap bitmap;

            try
            {
                bitmap = new Bitmap(Image.FromFile(file));
            }
            catch (OutOfMemoryException)
            {
                throw new IOException("Only .PNG files allowed for now.");
            }

            return new FastBitmap(bitmap);
        }

        public static async Task<SourceTextureSet> GenerateTextures(string[] files)
        {
            FastBitmap albedo = null;
            FastBitmap ambientOcclusion = null;
            FastBitmap roughness = null;
            FastBitmap gloss = null;
            FastBitmap metalness = null;
            FastBitmap normal = null;

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
                }
            }

            //apply ao and rgb conversion to the masks we need to use
            ambientOcclusion?.Start(ImageLockMode.ReadOnly);

            //roughness: srgb -> rgb, ao
            Task roughnessTask = Task.Run(() =>
            {
                roughness?.Start(ImageLockMode.ReadWrite);
                ConvertImageToRGB(roughness);
                ApplyAmbientOcclusion(roughness, ambientOcclusion);
                roughness?.Stop();
            });

            //gloss: srgb -> rgb, ao
            Task glossTask = Task.Run(() =>
            {
                gloss?.Start(ImageLockMode.ReadWrite);
                ConvertImageToRGB(gloss);
                ApplyAmbientOcclusion(gloss, ambientOcclusion);
                gloss?.Stop();
            });

            //metalness: ao
            Task metalnessTask = Task.Run(() =>
            {
                metalness?.Start(ImageLockMode.ReadWrite);
                ApplyAmbientOcclusion(metalness, ambientOcclusion);
                metalness?.Stop();
            });

            await roughnessTask; await glossTask; await metalnessTask;

            ambientOcclusion?.Stop();

            //start edits
            albedo?.Start(ImageLockMode.ReadOnly);
            ambientOcclusion?.Start(ImageLockMode.ReadOnly);
            roughness?.Start(ImageLockMode.ReadOnly);
            gloss?.Start(ImageLockMode.ReadOnly);
            metalness?.Start(ImageLockMode.ReadOnly);
            normal?.Start(ImageLockMode.ReadOnly);

            Task<FastBitmap> albedoTask = Task.Run(() =>
            {
                return CreateSourceAlbedo(albedo, ambientOcclusion, metalness);
            });

            Task<FastBitmap> normalTask = Task.Run(() =>
            {
                return CreateSourceNormal(normal, (roughness != null) ? roughness : gloss);
            });

            Task<FastBitmap> exponentTask = Task.Run(() =>
            {
                return CreateSourceExponent((roughness != null) ? roughness : gloss, metalness);
            });

            FastBitmap sourceAlbedo = await albedoTask;//CreateSourceAlbedo(albedo, ambientOcclusion, metalness);
            FastBitmap sourceNormal = await normalTask;//CreateSourceNormal(normal, (roughness != null) ? roughness : gloss);
            FastBitmap sourceExponent = await exponentTask;//CreateSourceExponent((roughness != null) ? roughness : gloss, metalness);

            //stop edits
            albedo?.StopAndDispose();
            ambientOcclusion?.StopAndDispose();
            roughness?.StopAndDispose();
            gloss?.StopAndDispose();
            metalness?.StopAndDispose();
            normal?.StopAndDispose();

            //collect garbage from fastbitmaps
            System.GC.Collect();
            System.GC.WaitForPendingFinalizers();

            return new SourceTextureSet(sourceAlbedo?.Source, sourceExponent?.Source, sourceNormal?.Source);
        }
    }
}
