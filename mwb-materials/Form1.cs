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
                MaterialManipulation.SourceTextureSet textures = await MaterialManipulation.GenerateTextures(Directory.GetFiles(path));

                textures.Albedo?.Save(path + "\\albedo.png", ImageFormat.Png);
                textures.Exponent?.Save(path + "\\exponent.png", ImageFormat.Png);
                textures.Normal?.Save(path + "\\normal.png", ImageFormat.Png);
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
    }
}
