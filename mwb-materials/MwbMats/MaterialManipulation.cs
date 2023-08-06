using mwb_materials.MwbMats;
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
        private static readonly string AlbedoNomenclature = "_rgb";
        private static readonly string AmbientOcclusionNomenclature = "_o";
        private static readonly string AmbientOcclusionAltNomenclature = "_ao";
        private static readonly string RoughnessNomenclature = "_r";
        private static readonly string GlossNomenclature = "_g";
        private static readonly string MetalnessNomenclature = "_alpha";
        private static readonly string MetalnessAltNomenclature = "_m";
        private static readonly string NormalNomenclature = "_n";

        public enum TextureChannel
        {
            Blue,
            Green,
            Red,
            Alpha
        }

        public enum TextureOperation
        {
            Replace,
            Add,
            Subtract,
            Multiply,
            Divide
        }

        public struct SourceTextureSet : IDisposable
        {
            public SourceTextureSet(Bitmap albedo, Bitmap exponent, Bitmap normal, Color metallicColor, double averageRoughness)
            {
                Albedo = albedo;
                Exponent = exponent;
                Normal = normal;
                AverageMetallicColor = metallicColor;
                AverageRoughness = averageRoughness;
            }

            public Bitmap Albedo { get; }
            public Bitmap Exponent { get; }
            public Bitmap Normal { get; }
            public Color AverageMetallicColor { get; }
            public double AverageRoughness { get; }

            public void Dispose()
            {
                Albedo?.Dispose();
                Exponent?.Dispose();
                Normal?.Dispose();
            }
        }

        private static void DumpGrayscaleInChannel(FastBitmap src, FastBitmap grayscale, TextureChannel channel, TextureOperation operation = TextureOperation.Replace)
        {
            if (src == null || grayscale == null)
            {
                return;
            }

            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                switch (operation)
                {
                    case TextureOperation.Replace:
                        src.Bytes[cursor + (int)channel] = (byte)grayscale.ReadGrayscale(cursor);
                        break;
                    case TextureOperation.Add:
                        src.Bytes[cursor + (int)channel] = (byte)Math.Min(src.Bytes[cursor + (int)channel] + (byte)grayscale.ReadGrayscale(cursor), 255);
                        break;
                    case TextureOperation.Subtract:
                        src.Bytes[cursor + (int)channel] = (byte)Math.Max(src.Bytes[cursor + (int)channel] - (byte)grayscale.ReadGrayscale(cursor), 0);
                        break;
                    case TextureOperation.Multiply:
                        float mul = grayscale.ReadGrayscale(cursor) / 255.0f;
                        float mulValue = src.Bytes[cursor + (int)channel] * mul;
                        src.Bytes[cursor + (int)channel] = (byte)Math.Min(mulValue, 255.0f);
                        break;
                    case TextureOperation.Divide:
                        float div = grayscale.ReadGrayscale(cursor) / 255.0f;
                        float divValue = src.Bytes[cursor + (int)channel] * (1.0f - div);
                        src.Bytes[cursor + (int)channel] = (byte)Math.Min(divValue, 255.0f);
                        break;
                }
            }
        }

        private static void DumpColorInChannel(FastBitmap src, byte color, TextureChannel channel)
        {
            if (src == null)
            {
                return;
            }

            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                src.Bytes[cursor + (int)channel] = color;
            }
        }

        private static void Invert(FastBitmap src)
        {
            if (src == null)
            {
                return;
            }

            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                src.Bytes[cursor] = (byte)(255 - src.Bytes[cursor]);
                src.Bytes[cursor + 1] = (byte)(255 - src.Bytes[cursor + 1]);
                src.Bytes[cursor + 2] = (byte)(255 - src.Bytes[cursor + 2]);
                src.Bytes[cursor + 3] = (byte)(255 - src.Bytes[cursor + 3]);
            }
        }

        private static void Invert(FastBitmap src, TextureChannel channel)
        {
            if (src == null)
            {
                return;
            }

            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                src.Bytes[cursor + (int)channel] = (byte)(255 - src.Bytes[cursor]);
            }
        }

        private static void ApplyAmbientOcclusion(FastBitmap src, FastBitmap ao)
        {
            if (src == null || ao == null)
            {
                return;
            }

            for (int cursor = 0; cursor < src.Bytes.Length; cursor += 4)
            {
                float gsValue = ao.ReadGrayscale(cursor);
                gsValue /= 255.0f;

                src.Bytes[cursor] = (byte)Math.Min(src.Bytes[cursor] * gsValue, 255.0f);
                src.Bytes[cursor + 1] = (byte)Math.Min(src.Bytes[cursor + 1] * gsValue, 255.0f);
                src.Bytes[cursor + 2] = (byte)Math.Min(src.Bytes[cursor + 2] * gsValue, 255.0f);
            }
        }

        private static FastBitmap CreateSourceAlbedo(FastBitmap albedo, FastBitmap ambientOcclusion, FastBitmap metalness, FastBitmap roughness, ref GenerateProperties props)
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
                ApplyAmbientOcclusion(sourceAlbedo, ambientOcclusion);
            }

            if (metalness != null)
            {
                //color2
                for (int cursor = 0; cursor < sourceAlbedo.Bytes.Length; cursor += 4)
                {
                    float metal = metalness.ReadGrayscale(cursor);
                    metal /= 255.0f;

                    float metallic = 255f;
                    float nonMetallic = 0f;

                    float result = nonMetallic.Lerp(metallic, metal);
                    sourceAlbedo.Bytes[cursor + (int)TextureChannel.Alpha] = (byte)result;
                }
            }
            else
            {
                DumpColorInChannel(sourceAlbedo, 0, TextureChannel.Alpha);
            }

            sourceAlbedo.Stop();
            return sourceAlbedo;
        }

        private static FastBitmap CreateSourceNormal(FastBitmap normal, FastBitmap albedo, FastBitmap roughness, FastBitmap metalness, FastBitmap ambientOcclusion, ref GenerateProperties props)
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
                //phong
                DumpGrayscaleInChannel(sourceNormal, roughness, TextureChannel.Alpha);

                for (int cursor = 0; cursor < sourceNormal.Bytes.Length; cursor += 4)
                {
                    double delta = sourceNormal.Bytes[cursor + (int)TextureChannel.Alpha] / 255.0;
                    delta = Math.Pow(delta, 2.5);
                    sourceNormal.Bytes[cursor + (int)TextureChannel.Alpha] = (byte)Math.Min((delta * 255.0) + 1.0, 255.0);
                }

                if (props.bAoMasks)
                {
                    DumpGrayscaleInChannel(sourceNormal, ambientOcclusion, TextureChannel.Alpha, TextureOperation.Multiply);
                }
            }

            sourceNormal.Stop();
            return sourceNormal;
        }

        private static FastBitmap CreateSourceExponent(FastBitmap roughness, FastBitmap metalness, FastBitmap ambientOcclusion, ref GenerateProperties props)
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
                //phong exponent
                DumpGrayscaleInChannel(sourceExponent, roughness, TextureChannel.Red);

                for (int cursor = 0; cursor < sourceExponent.Bytes.Length; cursor += 4)
                {
                    double delta = sourceExponent.Bytes[cursor + (int)TextureChannel.Red] / 255.0;
                    delta = Math.Pow(delta, 4.0);

                    if (metalness != null)
                    {
                        delta *= 1.0f.Lerp(0.5f, metalness.ReadGrayscale(cursor) / 255.0f);
                    }

                    sourceExponent.Bytes[cursor + (int)TextureChannel.Red] = (byte)Math.Min((delta * 255.0) + 1.0, 255.0);
                }

                //rimlight
                DumpGrayscaleInChannel(sourceExponent, roughness, TextureChannel.Alpha);

                if (props.bAoMasks)
                {
                    DumpGrayscaleInChannel(sourceExponent, ambientOcclusion, TextureChannel.Alpha, TextureOperation.Multiply);
                }
            }

            if (metalness != null)
            {
                //phong albedo tint
                DumpGrayscaleInChannel(sourceExponent, metalness, TextureChannel.Green); 
            }

            sourceExponent.Stop();
            return sourceExponent;
        }

        private static FastBitmap LoadImage(string file)
        {
            return new FastBitmap(new Bitmap(Image.FromFile(file)));
        }

        public struct GenerateProperties
        {
            public bool bAoMasks { get; internal set; }
            public bool bOpenGlNormal { get; internal set; }
            public int ClampSize { get; internal set; }
        }

        private static void SetBiggestWidthAndHeight(ref int width, ref int height, FastBitmap bmp)
        {
            width = bmp.Source.Width > width ? bmp.Source.Width : width;
            height = bmp.Source.Height > height ? bmp.Source.Height : height;
        }

        private static void ResizeIfSmaller(FastBitmap bmp, int width, int height)
        {
            if (bmp == null)
            {
                return;
            }

            //technically shouldn't be bigger :D :(
            if (bmp.Source.Width >= width && bmp.Source.Height >= height)
            {
                return;
            }

            bmp.Resize(width, height);
        }

        private static void ResizeToClampSize(int clampSize, FastBitmap[] bitmaps)
        {
            foreach (FastBitmap bmp in bitmaps)
            {
                if (bmp == null)
                {
                    continue;
                }

                double ratioWidth = (double)clampSize / (double)bmp.Source.Width;
                double ratioHeight = (double)clampSize / (double)bmp.Source.Height;
                double ratio = ratioWidth < ratioHeight ? ratioWidth : ratioHeight;

                if (ratio != 1.0)
                {
                    bmp.Resize((int)(bmp.Source.Width * ratio), (int)(bmp.Source.Height * ratio));
                }
            }
        }

        private static Color GetAverageMetallicColor(FastBitmap albedo, FastBitmap metalness)
        {
            if (metalness == null || albedo == null)
            {
                return Color.FromArgb(25, 25, 25);
            }

            double red = 0.0;
            double green = 0.0;
            double blue = 0.0;

            for (int cursor = 0; cursor < albedo.Bytes.Length; cursor += 4)
            {
                double metal = metalness.ReadGrayscale(cursor) / 255.0;

                if (metal > 0.1)
                {
                    red += albedo.Bytes[cursor + (int)TextureChannel.Red] * metal;
                    green += albedo.Bytes[cursor + (int)TextureChannel.Green] * metal;
                    blue += albedo.Bytes[cursor + (int)TextureChannel.Blue] * metal;
                }
                else
                {
                    red += 25.0;
                    green += 25.0;
                    blue += 25.0;
                }
            }

            red /= (albedo.Source.Width * albedo.Source.Height);
            green /= (albedo.Source.Width * albedo.Source.Height);
            blue /= (albedo.Source.Width * albedo.Source.Height);

            return Color.FromArgb((int)red, (int)green, (int)blue);
        }

        private static double GetAverageRoughness(FastBitmap roughness)
        {
            if (roughness == null)
            {
                return 0.5;
            }

            double avgRoughness = 0.0;

            for (int cursor = 0; cursor < roughness.Bytes.Length; cursor += 4)
            {
                avgRoughness += Math.Max(roughness.ReadGrayscale(cursor) / 255.0, 0.5);
            }

            avgRoughness /= (roughness.Source.Width * roughness.Source.Height);
            return avgRoughness;
        }

        public static async Task<SourceTextureSet> GenerateTextures(List<string> files, GenerateProperties props)
        {
            FastBitmap albedo = null;
            FastBitmap ambientOcclusion = null;
            FastBitmap roughness = null;
            FastBitmap gloss = null;
            FastBitmap metalness = null;
            FastBitmap normal = null;

            int biggestWidth = 0;
            int biggestHeight = 0;

            foreach (string file in files)
            {
                string name = Path.GetFileNameWithoutExtension(file);
                name = name.ToLower();

                if (name.EndsWith(AlbedoNomenclature))
                {
                    albedo = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, albedo);
                    continue;
                }

                if (name.EndsWith(AmbientOcclusionNomenclature) || name.EndsWith(AmbientOcclusionAltNomenclature))
                {
                    ambientOcclusion = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, ambientOcclusion);
                    continue;
                }

                if (name.EndsWith(RoughnessNomenclature))
                {
                    roughness = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, roughness);
                    continue;
                }

                if (name.EndsWith(GlossNomenclature))
                {
                    gloss = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, gloss);
                    continue;
                }

                if (name.EndsWith(MetalnessNomenclature) || name.EndsWith(MetalnessAltNomenclature))
                {
                    metalness = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, metalness);
                    continue;
                }

                if (name.EndsWith(NormalNomenclature))
                {
                    normal = LoadImage(file);
                    SetBiggestWidthAndHeight(ref biggestWidth, ref biggestHeight, normal);
                }
            }

            //resize textures
            biggestWidth = Math.Min(props.ClampSize, biggestWidth);
            biggestHeight = Math.Min(props.ClampSize, biggestHeight);

            ResizeIfSmaller(albedo, biggestWidth, biggestHeight);
            ResizeIfSmaller(ambientOcclusion, biggestWidth, biggestHeight);
            ResizeIfSmaller(roughness, biggestWidth, biggestHeight);
            ResizeIfSmaller(gloss, biggestWidth, biggestHeight);
            ResizeIfSmaller(metalness, biggestWidth, biggestHeight);
            ResizeIfSmaller(normal, biggestWidth, biggestHeight);

            ResizeToClampSize(props.ClampSize, new FastBitmap[] { albedo, ambientOcclusion, roughness, gloss, metalness, normal });

            //invert roughness
            Task roughnessTask = Task.Run(() =>
            {
                roughness?.Start(ImageLockMode.ReadWrite);
                Invert(roughness);
                roughness?.Stop();
            });

            Task normalOpenGlTask = Task.CompletedTask;

            if (props.bOpenGlNormal)
            {
                //invert green channel
                normalOpenGlTask = Task.Run(() =>
                {
                    normal?.Start(ImageLockMode.ReadWrite);
                    Invert(normal, TextureChannel.Green);
                    normal?.Stop();
                });  
            }

            await normalOpenGlTask; await roughnessTask;

            //start edits
            albedo?.Start(ImageLockMode.ReadOnly);
            ambientOcclusion?.Start(ImageLockMode.ReadOnly);
            roughness?.Start(ImageLockMode.ReadOnly);
            gloss?.Start(ImageLockMode.ReadOnly);
            metalness?.Start(ImageLockMode.ReadOnly);
            normal?.Start(ImageLockMode.ReadOnly);

            Task<FastBitmap> albedoTask = Task.Run(() =>
            {
                return CreateSourceAlbedo(albedo, ambientOcclusion, metalness, (gloss != null) ? gloss : roughness, ref props);
            });

            Task<FastBitmap> normalTask = Task.Run(() =>
            {
                return CreateSourceNormal(normal, albedo, (gloss != null) ? gloss : roughness, metalness, ambientOcclusion, ref props);
            });

            Task<FastBitmap> exponentTask = Task.Run(() =>
            {
                return CreateSourceExponent((gloss != null) ? gloss : roughness, metalness, ambientOcclusion, ref props);
            });

            Task<Color> getMetallicColor = Task.Run(() =>
            {
                return GetAverageMetallicColor(albedo, metalness);
            });

            Task<double> getAverageRoughness = Task.Run(() =>
            {
                return GetAverageRoughness((gloss != null) ? gloss : roughness);
            });

            FastBitmap sourceAlbedo = await albedoTask;
            FastBitmap sourceNormal = await normalTask;
            FastBitmap sourceExponent = await exponentTask;
            Color averageMetallicColor = await getMetallicColor;
            double averageRoughness = await getAverageRoughness;

            //stop edits
            albedo?.StopAndDispose();
            ambientOcclusion?.StopAndDispose();
            roughness?.StopAndDispose();
            gloss?.StopAndDispose();
            metalness?.StopAndDispose();
            normal?.StopAndDispose();

            return new SourceTextureSet(sourceAlbedo?.Source, sourceExponent?.Source, sourceNormal?.Source, averageMetallicColor, averageRoughness);
        }
    }
}