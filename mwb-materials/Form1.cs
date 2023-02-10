using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mwb_materials
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void FolderButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            CommonFileDialogResult result = folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                Stopwatch timer = new Stopwatch();
                timer.Start();

                Enabled = false;

                string path = folderDialog.FileName;
                string[] files = Directory.GetFiles(path);
                List<string> sanitizedFiles = new List<string>();

                foreach (string file in files)
                {
                    if (Path.GetExtension(file).ToLower() == ".png")
                    {
                        sanitizedFiles.Add(file);
                    }
                }

                MaterialManipulation.GenerateProperties props = new MaterialManipulation.GenerateProperties() { bSrgb = SrgbCheck.Checked, bAo = AoCheck.Checked, MaxExponent = (int)MaxExponent.Value };
                MaterialManipulation.SourceTextureSet textures = await MaterialManipulation.GenerateTextures(sanitizedFiles, props);

                Directory.CreateDirectory(path + "\\temp");
                Directory.CreateDirectory(path + "\\output");

                string folderName = Path.GetFileName(path);
                string outputName;

                if (textures.Albedo != null)
                {
                    outputName = folderName + "_rgb.png";

                    textures.Albedo?.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\", VtfCmdInterface.FormatDXT5, false);
                }

                if (textures.Exponent != null)
                {
                    outputName = folderName + "_e.png";

                    textures.Exponent.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\",VtfCmdInterface.FormatDXT1, false);
                }

                if (textures.Normal != null)
                {
                    outputName = folderName + "_n.png";

                    textures.Normal?.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\", VtfCmdInterface.FormatRGBA8888, true);
                }

                textures.Dispose();

                Enabled = true;

                timer.Stop();
                MessageBox.Show("Generated textures! (" + timer.Elapsed.ToString(@"m\:ss\.fff") + ")", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void VmtButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            CommonFileDialogResult result = folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                string name = VmtName.Text
                    .Trim()
                    .Replace(".vmt", string.Empty);

                using (StreamWriter sw = File.CreateText(folderDialog.FileName + "\\" + name + ".vmt"))
                {
                    byte[] bytes = Properties.Resources.default_vmt;
                    sw.BaseStream.Write(bytes, 0, bytes.Length);
                }

                MessageBox.Show("Saved VMT file: " + name, "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void HelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Make a folder and dump your PNGs in there. The VTFs will be exported into this folder under the \"output\" folder (they will also take the folder's name) \n" +
                "\n" +
                "This system uses GLOSS primarily, which means if it finds a roughness texture it will invert it. \n" +
                "\n" +
                "Metalness needs to be a grayscale image, so not a specular (it should have no color). \n" +
                "\n" +
                "Tool will use any textures it finds, doesn't require any to be present.", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void SettingsHelpButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By default we assume your metalness and roughness masks are sRGB, you can override this with the setting. \n" +
                "\n" +
                "If your metal/gloss/rough textures already have AO applied you can skip this step with the setting. \n" +
                "\n" +
                "\"Max non-metals exponent\" is for any part of the texture that isn't touched by metalness texture (metallic parts get up to 155, Source's default). " +
                "Usually the default is fine, unless you see some parts of the model not behaving correctly (plastic-looking).", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
