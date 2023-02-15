using Microsoft.WindowsAPICodePack.Dialogs;
using mwb_materials.MwbMats;
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

                MaterialManipulation.GenerateProperties props = new MaterialManipulation.GenerateProperties() {
                    bSrgb = SrgbCheck.Checked,
                    bAlbedoSrgb = AlbedoSrgbCheck.Checked,
                    bAo = AoCheck.Checked,
                    MaxExponent = Math.Max((int)MaxExponent.Value, 1),
                    bTintGloss = TintGlossCheck.Checked,
                    bMetalnessIgnoreGloss = NoRoughMetalCheck.Checked,
                    bDesaturateAlbedo = DesaturateAlbedoCheck.Checked
                };

                MaterialManipulation.SourceTextureSet textures = await MaterialManipulation.GenerateTextures(sanitizedFiles, props);

                Directory.CreateDirectory(path + "\\temp");
                Directory.CreateDirectory(path + "\\output");

                string folderName = Path.GetFileName(path);
                Dictionary<string, object> vmtValues = new Dictionary<string, object>();
                string outputName;

                Task albedoTask = Task.CompletedTask;
                Task exponentTask = Task.CompletedTask;
                Task normalTask = Task.CompletedTask;

                if (textures.Albedo != null)
                {
                    outputName = folderName + "_rgb.png";

                    textures.Albedo?.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    vmtValues.Add("ALBEDONAME", outputName.Replace(".png", string.Empty));

                    albedoTask = VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\", VtfCmdInterface.FormatDXT5, false);
                }

                if (textures.Exponent != null)
                {
                    outputName = folderName + "_e.png";

                    textures.Exponent.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    vmtValues.Add("EXPONENTNAME", outputName.Replace(".png", string.Empty));

                    exponentTask = VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\", VtfCmdInterface.FormatDXT5, false);
                }

                if (textures.Normal != null)
                {
                    outputName = folderName + "_n.png";

                    textures.Normal?.Save(path + "\\temp\\" + outputName, ImageFormat.Png);
                    vmtValues.Add("NORMALNAME", outputName.Replace(".png", string.Empty));

                    normalTask = VtfCmdInterface.ExportFile(path + "\\temp\\" + outputName, path + "\\output\\", VtfCmdInterface.FormatRGBA8888, true);
                }

                await albedoTask; await exponentTask; await normalTask;

                textures.Dispose();

                if (VmtDestinationPath.Text != string.Empty)
                {
                    string p = VmtDestinationPath.Text.Replace("materials", string.Empty);
                    p = p.Trim(new char[] { '\\' });
                    vmtValues.Add("EXPORTPATH", p);
                }
                else
                {
                    vmtValues.Add("EXPORTPATH", "");
                }

                VmtGenerator.Generate(path + "\\output\\", folderName, vmtValues);

                Directory.Delete(path + "\\temp");
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
                VmtGenerator.Generate(folderDialog.FileName, VmtName.Text);
                MessageBox.Show("Saved VMT file: " + VmtName.Text, "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void VmtDestinationButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            CommonFileDialogResult result = folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                VmtDestinationPath.Text = folderDialog.FileName;
                VmtDestinationPath.Text.Trim(new char[] { '\\' });

                if (!VmtDestinationPath.Text.Contains("materials"))
                {
                    VmtDestinationPath.Text = string.Empty;
                    MessageBox.Show("Not a valid Source material path");
                }
                else
                {
                    VmtDestinationPath.Text = VmtDestinationPath.Text.Substring(VmtDestinationPath.Text.IndexOf("materials"));
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 1000;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(SrgbCheck, "Most PBR workflows use sRGB colorspace for their masks. Tick this off if your textures don't.");
            toolTip1.SetToolTip(AlbedoSrgbCheck, "Some assets may use sRGB colorspace for albedo. Tick this off if your texture doesn't.");
            toolTip1.SetToolTip(AoCheck, "Apply ambient occlusion to masks.");
            toolTip1.SetToolTip(MaxExponent, "Tool won't generate a higher exponent value than this.");
            toolTip1.SetToolTip(TintGlossCheck, "Generate a stronger phong and tighter exponent using metalness. Ideal for conductive materials.");
            toolTip1.SetToolTip(NoRoughMetalCheck, "Generate env mapping wherever metalness is, regardless of gloss.");
            toolTip1.SetToolTip(DesaturateAlbedoCheck, "With conductive materials, albedo gets desaturated. \n" +
                "Turning this off will allow reflections without albedo color loss. \n" +
                "If your material isn't conductive (eyes, skin, etc...) turn this off.");
            toolTip1.SetToolTip(OpenGlNormalCheck, "Inverts green channel.");
            toolTip1.SetToolTip(VmtDestinationPath, "Sets the textures' path in the VMT (does not move the textures there - they'll still be in /output");
        }
    }
}
