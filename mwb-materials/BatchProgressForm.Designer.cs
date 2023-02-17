
namespace mwb_materials
{
    partial class BatchProgressForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BatchFolderLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BatchFolderLabel
            // 
            this.BatchFolderLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BatchFolderLabel.Location = new System.Drawing.Point(0, 0);
            this.BatchFolderLabel.Name = "BatchFolderLabel";
            this.BatchFolderLabel.Size = new System.Drawing.Size(215, 61);
            this.BatchFolderLabel.TabIndex = 1;
            this.BatchFolderLabel.Text = "Generating bitches";
            this.BatchFolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BatchProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 61);
            this.Controls.Add(this.BatchFolderLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BatchProgressForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MWB Mats";
            this.Load += new System.EventHandler(this.BatchProgressForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label BatchFolderLabel;
    }
}