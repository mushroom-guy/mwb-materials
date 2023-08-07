using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace mwb_materials
{
    public partial class BatchProgressForm : Form
    {
        public BatchProgressForm()
        {
            InitializeComponent();
        }

        public void SetFolderName(string folder)
        {
            BatchFolderLabel.Text = "Generating \n" + folder;
        }

        public void SetTextures(List<string> textures)
        {
            TexturesLabel.Text = "";

            foreach (string texture in textures)
            {
                string name = Path.GetFileName(texture);
                TexturesLabel.Text += name.Substring(Math.Max(0, name.Length - 40), Math.Min(name.Length, 40)) + "\n";
            }
        }

        private void BatchProgressForm_Load(object sender, EventArgs e)
        {
            BatchFolderLabel.Text = "Starting...";
        }
    }
}
