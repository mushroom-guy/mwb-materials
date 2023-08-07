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
        private ToolTip ToolTip = new ToolTip()
        {
            InitialDelay = 100,
            ReshowDelay = 100,
            ShowAlways = true,
            UseAnimation = false,
            UseFading = false
        };

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
                    bAoMasks = AoCheck.Checked,
                    bOpenGlNormal = OpenGlNormalCheck.Checked,
                    ClampSize = int.Parse(ClampComboBox.Text)
                };

                BatchExporter.BatchProperties bProps = new BatchExporter.BatchProperties()
                {
                    VmtRootPath = VmtDestinationPath.Text,
                    EnvRootPath = EnvMapsDestination.Text,
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

                await BatchExporter.StartBatch(folderDialog.FileName, bProps, (string folder, List<string> files) =>
                {
                    bpForm.SetFolderName(folder);
                    bpForm.SetTextures(files);
                });

                timer.Stop();
                Enabled = true;

                bpForm.Close();
                MessageBox.Show("Generated textures! (" + timer.Elapsed.ToString(@"m\:ss\.fff") + ")", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] compressionFormats = new string[] { VtfCmdInterface.FormatDXT5, VtfCmdInterface.FormatRGBA8888, VtfCmdInterface.FormatDXT1 };

            AlbedoCompression.Items.AddRange(compressionFormats);
            AlbedoCompression.SelectedIndex = 0;

            NormalCompression.Items.AddRange(compressionFormats);
            NormalCompression.SelectedIndex = 1;

            ExponentCompression.Items.AddRange(compressionFormats);
            ExponentCompression.SelectedIndex = 0;

            VmtDestinationPath.Text = Properties.Settings.Default.DestinationFolder;

            ClampComboBox.Items.AddRange(new string[] { "4096", "2048", "1024", "512" });
            ClampComboBox.SelectedIndex = 0;

            EnvMapsDestination.Text = Properties.Settings.Default.EnvMapsFolder;
            ToolTip.SetToolTip(EnvMapsDestination, EnvMapsDestination.Text);

            VmtDestinationPath.Text = Properties.Settings.Default.DestinationFolder;
            ToolTip.SetToolTip(VmtDestinationPath, VmtDestinationPath.Text);

            HelpButtonClicked += Form1_HelpButtonClicked;

            ToolTip.SetToolTip(AlbedoLabel, "basetexture");
            ToolTip.SetToolTip(NormalLabel, "bumpmap");
            ToolTip.SetToolTip(ExponentLabel, "phongexponent");
        }

        private void Form1_HelpButtonClicked(object sender, EventArgs e)
        {
            Process.Start("https://github.com/mushroom-guy/mwb-materials/blob/main/help.md");
        }

        private void EnvMapsDestination_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnvMapsFolder = EnvMapsDestination.Text;
            ToolTip.SetToolTip(EnvMapsDestination, EnvMapsDestination.Text);
            Properties.Settings.Default.Save();
        }

        private void VmtDestinationPath_TextChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.DestinationFolder = VmtDestinationPath.Text;
            ToolTip.SetToolTip(VmtDestinationPath, VmtDestinationPath.Text);
            Properties.Settings.Default.Save();
        }
    }
}
