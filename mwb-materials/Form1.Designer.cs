
namespace mwb_materials
{
    partial class Form1
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
            this.FolderButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VmtName = new System.Windows.Forms.TextBox();
            this.VmtButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // FolderButton
            // 
            this.FolderButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FolderButton.Location = new System.Drawing.Point(6, 19);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(188, 74);
            this.FolderButton.TabIndex = 0;
            this.FolderButton.Text = "Open Folder";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(6, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 78);
            this.label2.TabIndex = 2;
            this.label2.Text = "_rgb - albedo\r\n_alpha - metalness\r\n_g - gloss\r\n_r - roughness\r\n_o - ambient occlu" +
    "sion\r\n_n - normal\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texture Layout";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VmtName);
            this.groupBox2.Controls.Add(this.VmtButton);
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 99);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preset VMT";
            // 
            // VmtName
            // 
            this.VmtName.Location = new System.Drawing.Point(6, 19);
            this.VmtName.Name = "VmtName";
            this.VmtName.Size = new System.Drawing.Size(188, 20);
            this.VmtName.TabIndex = 6;
            this.VmtName.Text = "example_vmt";
            // 
            // VmtButton
            // 
            this.VmtButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.VmtButton.Location = new System.Drawing.Point(6, 45);
            this.VmtButton.Name = "VmtButton";
            this.VmtButton.Size = new System.Drawing.Size(188, 48);
            this.VmtButton.TabIndex = 5;
            this.VmtButton.Text = "Generate VMT";
            this.VmtButton.UseVisualStyleBackColor = true;
            this.VmtButton.Click += new System.EventHandler(this.VmtButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FolderButton);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(12, 222);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 99);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Textures";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 331);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "MWB Mats";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button VmtButton;
        private System.Windows.Forms.TextBox VmtName;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

