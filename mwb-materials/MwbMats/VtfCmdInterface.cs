using mwb_materials.MwbMats;
using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;

namespace mwb_materials
{
    class VtfCmdInterface
    {
        public const string FormatDXT1 = "DXT1";
        public const string FormatDXT5 = "DXT5";
        public const string FormatRGBA8888 = "RGBA8888";

        public static Task ExportFile(string file, string outputFolder, string format, bool bNoMips, string moveOutputPath)
        {
            if (VtfLib.vlImageLoad(file, false))
            {
                if (bNoMips)
                {
                    VtfLib.vlImageSetFlag(VTFImageFlag.TEXTUREFLAGS_NOMIP, true);
                }
                else
                {
                    VtfLib.vlImageGenerateAllMipmaps(VTFMipmapFilter.MIPMAP_FILTER_GAUSSIAN, VTFSharpenFilter.SHARPEN_FILTER_SHARPENSOFT);
                }

                VTFImageFormat f = VTFImageFormat.IMAGE_FORMAT_NONE;

                switch (format)
                {
                    case FormatDXT1: f = VTFImageFormat.IMAGE_FORMAT_DXT1; break;
                    case FormatDXT5: f = VTFImageFormat.IMAGE_FORMAT_DXT1; break;
                    case FormatRGBA8888: f = VTFImageFormat.IMAGE_FORMAT_DXT1; break;

                }

                //VtfLib.vlImageCreate(VtfLib.vlImageGetWidth(), VtfLib.vlImageGetHeight(), 
                //    VtfLib.vlImageGetFrameCount(), VtfLib.vlImageGetFaceCount(), 
                //    VtfLib.vlImageGetDepth(), f, true, true, true);
                //
                //bool s = VtfLib.vlImageConvertFromRGBA8888(VtfLib.vlImageGetData(0, 0, 0, 0), );

                if (VtfLib.vlImageSave(outputFolder))
                {
                    File.Delete(file);

                    if (moveOutputPath != string.Empty)
                    {
                        string fileSrc = outputFolder + Path.GetFileNameWithoutExtension(file) + ".vtf";
                        string fileDest = moveOutputPath + "\\" + Path.GetFileNameWithoutExtension(file) + ".vtf";

                        Directory.CreateDirectory(moveOutputPath);

                        if (File.Exists(fileDest)) File.Delete(fileDest);
                        File.Move(fileSrc, fileDest);
                    }
                };
            }

            return Task.CompletedTask;
        }
    }
}
