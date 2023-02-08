using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

            ProgressLabel.Text = string.Empty;
            ProgressBar.Value = 0;
        }

        private async void FolderButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog folderDialog = new CommonOpenFileDialog();
            folderDialog.IsFolderPicker = true;
            CommonFileDialogResult result = folderDialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {   
                Enabled = false;

                string path = folderDialog.FileName;
                MaterialManipulation.SourceTextureSet textures = await MaterialManipulation.GenerateTexturesAsync(Directory.GetFiles(path), 
                    (int progress, string operation) => { 
                        ProgressBar.Value = progress; 
                        ProgressLabel.Text = operation; 
                    });

                textures.Albedo?.Save(path + "\\albedo.png", ImageFormat.Png);
                textures.Exponent?.Save(path + "\\exponent.png", ImageFormat.Png);
                textures.Normal?.Save(path + "\\normal.png", ImageFormat.Png);
                textures.Dispose();

                Enabled = true;
                MessageBox.Show("Generated textures!", "MWB Mats", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
