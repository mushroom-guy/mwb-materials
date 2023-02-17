using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mwb_materials.MwbMats
{
    class BatchExporter
    {
        public struct BatchProperties
        {
            public string VmtRootPath { get; set; }
            public MaterialManipulation.GenerateProperties GenerateProps { get; set; }
        }

        private static async Task GenerateInFolder(string path, BatchProperties props, string startPath, Action<string> folderFunc)
        {
            //before we do files, we have to first look in other folders, we can't run the tool
            //more than once or we are gonna eat a lot of memory
            string[] folders = Directory.GetDirectories(path);

            foreach (string folder in folders)
            {
                if (folder.ToLower().EndsWith("output") || folder.ToLower().EndsWith("temp"))
                {
                    continue;
                }

                await GenerateInFolder(folder, props, startPath, folderFunc);
            }

            //after the recursion is done we can hopefully do images
            string[] files = Directory.GetFiles(path);
            List<string> sanitizedFiles = new List<string>();

            foreach (string file in files)
            {
                try
                {
                    Image.FromFile(file);
                }
                catch (OutOfMemoryException)
                {
                    continue;
                }

                sanitizedFiles.Add(file);
            }

            if (sanitizedFiles.Count <= 0)
            {
                return;
            }

            string folderName = Path.GetFileName(path);
            folderFunc(folderName);

            MaterialManipulation.SourceTextureSet textures = await MaterialManipulation.GenerateTextures(sanitizedFiles, props.GenerateProps);

            string tempPath = path + "\\temp\\";
            string outputPath = path + "\\output\\";

            Directory.CreateDirectory(tempPath);
            Directory.CreateDirectory(outputPath);

            Dictionary<string, object> vmtValues = new Dictionary<string, object>();

            Task albedoTask = Task.CompletedTask;
            Task exponentTask = Task.CompletedTask;
            Task normalTask = Task.CompletedTask;

            string outputName;

            if (textures.Albedo != null)
            {
                outputName = folderName + "_rgb";

                textures.Albedo?.Save(tempPath + outputName + ".png", ImageFormat.Png);
                vmtValues.Add("ALBEDONAME", outputName);

                albedoTask = VtfCmdInterface.ExportFile(tempPath + outputName + ".png", outputPath, VtfCmdInterface.FormatDXT5, false);
            }

            if (textures.Exponent != null)
            {
                outputName = folderName + "_e";

                textures.Exponent.Save(tempPath + outputName + ".png", ImageFormat.Png);
                vmtValues.Add("EXPONENTNAME", outputName);

                exponentTask = VtfCmdInterface.ExportFile(tempPath + outputName + ".png", outputPath, VtfCmdInterface.FormatDXT5, false);
            }

            if (textures.Normal != null)
            {
                outputName = folderName + "_n";

                textures.Normal?.Save(tempPath + outputName + ".png", ImageFormat.Png);
                vmtValues.Add("NORMALNAME", outputName);

                normalTask = VtfCmdInterface.ExportFile(tempPath + outputName + ".png", outputPath, VtfCmdInterface.FormatRGBA8888, true);
            }

            await albedoTask; await exponentTask; await normalTask;

            textures.Dispose();

            string vmtPath = string.Empty;

            if (props.VmtRootPath != string.Empty)
            {
                vmtPath = props.VmtRootPath.Replace("materials", string.Empty);
                vmtPath = vmtPath.Trim(new char[] { '\\' });
            }

            vmtPath += path.Replace(startPath, string.Empty);
            vmtValues.Add("EXPORTPATH", vmtPath);

            VmtGenerator.Generate(outputPath, folderName, vmtValues);
            Directory.Delete(tempPath);
        }

        public static async Task StartBatch(string path, BatchProperties props, Action<string> folderFunc)
        {
            await GenerateInFolder(path, props, path, folderFunc);
        }
    }
}
