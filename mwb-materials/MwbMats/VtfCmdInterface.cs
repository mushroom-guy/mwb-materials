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
        public static string FormatDXT1 = "dxt1";
        public static string FormatDXT5 = "dxt5";
        public static string FormatRGBA8888 = "rgba8888";

        private static void AddProcessArgument(ProcessStartInfo processInfo, string key, string val)
        {
            processInfo.Arguments += "-" + key + " ";
            processInfo.Arguments += val + " ";
        }

        private static void AddProcessArgument(ProcessStartInfo processInfo, string key)
        {
            processInfo.Arguments += "-" + key + " ";
        }

        public static void ExportFile(string file, string outputFolder, string format, bool bNoMips)
        {
            ProcessStartInfo programInfo = new ProcessStartInfo();
            programInfo.WindowStyle = ProcessWindowStyle.Hidden;
            programInfo.CreateNoWindow = true;
            programInfo.UseShellExecute = false;
            programInfo.RedirectStandardOutput = true;
            programInfo.FileName = "vtfcmd\\VTFCmd.exe";

            programInfo.Arguments = string.Empty;
            AddProcessArgument(programInfo, "file", file);
            AddProcessArgument(programInfo, "output", outputFolder);
            AddProcessArgument(programInfo, "format", format);
            AddProcessArgument(programInfo, "alphaformat", format);
            
            if (bNoMips)
            {
                AddProcessArgument(programInfo, "nomipmaps");
            }

            Process runProgram = new Process();
            runProgram.StartInfo = programInfo;
            runProgram.EnableRaisingEvents = true;
            runProgram.Start();
            runProgram.Exited += (object sender, EventArgs a) =>
            {
                File.Delete(file);
            };
        }
    }
}
