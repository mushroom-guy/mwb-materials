using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mwb_materials
{
    class VtfCmdInterface
    {
        public static readonly string FormatDXT1 = "DXT1";
        public static readonly string FormatDXT5 = "DXT5";
        public static readonly string FormatRGBA8888 = "RGBA8888";

        private static void AddProcessArgument(ProcessStartInfo processInfo, string key, string val)
        {
            processInfo.Arguments += "-" + key + " ";
            processInfo.Arguments += "\"" + val + "\" ";
        }

        private static void AddProcessArgument(ProcessStartInfo processInfo, string key)
        {
            processInfo.Arguments += "-" + key + " ";
        }

        public static async Task ExportFile(string file, string outputFolder, string format, bool bNoMips, string moveOutputPath)
        {
            TaskCompletionSource<bool> completion = new TaskCompletionSource<bool>();

            ProcessStartInfo programInfo = new ProcessStartInfo();
            programInfo.WindowStyle = ProcessWindowStyle.Hidden;
            programInfo.CreateNoWindow = true;
            programInfo.UseShellExecute = false;
            programInfo.RedirectStandardOutput = true;
            programInfo.FileName = "vtfcmd\\VTFCmd.exe";

            programInfo.WorkingDirectory = Path.GetDirectoryName(file);
            programInfo.Arguments = string.Empty;
            AddProcessArgument(programInfo, "file", Path.GetFileName(file));
            AddProcessArgument(programInfo, "output", Path.GetDirectoryName(outputFolder));
            AddProcessArgument(programInfo, "format", format);
            AddProcessArgument(programInfo, "alphaformat", format);
            
            if (bNoMips)
            {
                AddProcessArgument(programInfo, "nomipmaps");
            }
            else
            {
                AddProcessArgument(programInfo, "mfilter", "GAUSSIAN");
                AddProcessArgument(programInfo, "msharpen", "SHARPENSOFT");
            }

            Process runProgram = new Process();
            runProgram.StartInfo = programInfo;
            runProgram.EnableRaisingEvents = true;
            runProgram.Exited += (object sender, EventArgs a) =>
            {
                File.Delete(file);

                if (moveOutputPath != string.Empty)
                {
                    string fileSrc = outputFolder + Path.GetFileNameWithoutExtension(file) + ".vtf";
                    string fileDest = moveOutputPath + "\\" + Path.GetFileNameWithoutExtension(file) + ".vtf";

                    Directory.CreateDirectory(moveOutputPath);

                    if (File.Exists(fileDest))
                    {
                        File.Delete(fileDest);
                    }

                    File.Move(fileSrc, fileDest);
                }

                completion.TrySetResult(true);
            };

            runProgram.Start();

            await completion.Task;
        }
    }
}
