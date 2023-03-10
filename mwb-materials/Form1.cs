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
                MaterialManipulation.GenerateProperties props = new MaterialManipulation.GenerateProperties()
                {
                    bSrgb = SrgbCheck.Checked,
                    bAlbedoSrgb = AlbedoSrgbCheck.Checked,
                    bAoMasks = AoCheck.Checked,
                    MaxExponent = Math.Max((int)MaxExponent.Value, 1),
                    bOpenGlNormal = OpenGlNormalCheck.Checked,
                    PhongBoost = Math.Max((int)PhongBoost.Value, 1),
                    bPhongAlbedoTint = PhongAlbedoTintCheck.Checked,
                    bGlossyFresnel = GlossyFresnelCheck.Checked
                };

                BatchExporter.BatchProperties bProps = new BatchExporter.BatchProperties()
                {
                    VmtRootPath = VmtDestinationPath.Text,
                    bMoveOutput = BatchMoveOutputCheck.Checked,
                    bIncludeFolders = BatchIncludeFoldersCheck.Checked,
                    AlbedoCompression = AlbedoCompression.Text,
                    NormalCompression = NormalCompression.Text,
                    ExponentCompression = ExponentCompression.Text,
                    bAlbedoMipMaps = AlbedoMipMapsCheck.Checked,
                    bNormalMipMaps = NormalMipMapsCheck.Checked,
                    bExponentMipMaps = ExponentMipMapsCheck.Checked,
                    GenerateProps = props
                };

                timer.Start();
                Enabled = false;

                BatchProgressForm bpForm = new BatchProgressForm();
                bpForm.Show();
                bpForm.Enabled = false;

                await BatchExporter.StartBatch(folderDialog.FileName, bProps, (string folder) =>
                {
                    bpForm.SetFolderName(folder);
                });

                timer.Stop();
                Enabled = true;

                bpForm.Close();
                MessageBox.Show("Generated textures! (" + timer.Elapsed.ToString(@"m\:ss\.fff") + ")", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                /*else
                {
                    VmtDestinationPath.Text = VmtDestinationPath.Text.Substring(VmtDestinationPath.Text.IndexOf("materials"));
                }*/
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Create the ToolTip and associate with the Form container.
            ToolTip toolTip1 = new ToolTip();

            // Set up the delays for the ToolTip.
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 0;
            toolTip1.ReshowDelay = 500;

            // Force the ToolTip text to be displayed whether or not the form is active.
            toolTip1.ShowAlways = true;

            toolTip1.SetToolTip(SrgbCheck, "Most PBR workflows use sRGB colorspace for their masks. Tick this off if your textures don't.");
            toolTip1.SetToolTip(AlbedoSrgbCheck, "Some assets may use sRGB colorspace for albedo. Tick this off if your texture doesn't.");
            toolTip1.SetToolTip(AoCheck, "Apply ambient occlusion to masks.");
            toolTip1.SetToolTip(MaxExponent, "Tool won't generate a higher exponent value than this.");
            toolTip1.SetToolTip(OpenGlNormalCheck, "Inverts green channel.");
            toolTip1.SetToolTip(VmtDestinationPath, "Sets the textures' path in the VMT.");
            toolTip1.SetToolTip(PhongBoost, "Sets phongboost value. Note that this changes the final output of the normal texture.\nIf your materials are fully metallic, keep this at 1.\nMake sure to experiment with what looks right, but 3 is usually good enough.");
            toolTip1.SetToolTip(PhongAlbedoTintCheck, "Enable this if your metals are colored (enables phong albedo tint).");
            toolTip1.SetToolTip(GlossyFresnelCheck, "Enable this to have bright silhouettes (good for glossy and round objects).");
            toolTip1.SetToolTip(BatchMoveOutputCheck, "Move the output folder contents to VMT texture path.");
            toolTip1.SetToolTip(BatchIncludeFoldersCheck, "Add folder hierarchy to VMT texture paths (when doing more than one folder).");

            string[] compressionFormats = new string[] { VtfCmdInterface.FormatDXT5, VtfCmdInterface.FormatRGBA8888, VtfCmdInterface.FormatDXT1 };

            AlbedoCompression.Items.AddRange(compressionFormats);
            AlbedoCompression.SelectedIndex = 0;

            NormalCompression.Items.AddRange(compressionFormats);
            NormalCompression.SelectedIndex = 1;

            ExponentCompression.Items.AddRange(compressionFormats);
            ExponentCompression.SelectedIndex = 0;
        }

        private void PhongAlbedoTintCheck_CheckedChanged(object sender, EventArgs e)
        {
            PhongBoost.Enabled = PhongAlbedoTintCheck.Checked;
        }

    }
}
