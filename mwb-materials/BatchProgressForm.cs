using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        private void BatchProgressForm_Load(object sender, EventArgs e)
        {
            BatchFolderLabel.Text = "Starting...";
        }
    }
}
