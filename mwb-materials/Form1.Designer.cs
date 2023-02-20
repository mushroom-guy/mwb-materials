
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
            this.HelpButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.VmtName = new System.Windows.Forms.TextBox();
            this.VmtButton = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BatchMoveOutputCheck = new System.Windows.Forms.CheckBox();
            this.BatchIncludeFoldersCheck = new System.Windows.Forms.CheckBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TighterPhongCheck = new System.Windows.Forms.CheckBox();
            this.OpenGlNormalCheck = new System.Windows.Forms.CheckBox();
            this.BrighterPhongCheck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.VmtDestinationButton = new System.Windows.Forms.Button();
            this.AlbedoSrgbCheck = new System.Windows.Forms.CheckBox();
            this.VmtDestinationPath = new System.Windows.Forms.TextBox();
            this.MaxExponent = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.AoCheck = new System.Windows.Forms.CheckBox();
            this.SrgbCheck = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxExponent)).BeginInit();
            this.SuspendLayout();
            // 
            // FolderButton
            // 
            this.FolderButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.FolderButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FolderButton.Location = new System.Drawing.Point(3, 63);
            this.FolderButton.Name = "FolderButton";
            this.FolderButton.Size = new System.Drawing.Size(218, 33);
            this.FolderButton.TabIndex = 0;
            this.FolderButton.Text = "Open Folder(s)";
            this.FolderButton.UseVisualStyleBackColor = true;
            this.FolderButton.Click += new System.EventHandler(this.FolderButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 78);
            this.label2.TabIndex = 2;
            this.label2.Text = "_rgb - albedo\r\n_alpha - metalness\r\n_g - gloss\r\n_r - roughness\r\n_o - ambient occlu" +
    "sion\r\n_n - normal\r\n";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.HelpButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            this.groupBox1.Size = new System.Drawing.Size(224, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texture Layout";
            // 
            // HelpButton
            // 
            this.HelpButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton.Location = new System.Drawing.Point(195, 10);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(23, 23);
            this.HelpButton.TabIndex = 3;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.VmtName);
            this.groupBox2.Controls.Add(this.VmtButton);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(0, 99);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 0, 4);
            this.groupBox2.Size = new System.Drawing.Size(224, 74);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Preset VMT";
            // 
            // VmtName
            // 
            this.VmtName.Dock = System.Windows.Forms.DockStyle.Top;
            this.VmtName.Location = new System.Drawing.Point(2, 15);
            this.VmtName.Name = "VmtName";
            this.VmtName.Size = new System.Drawing.Size(222, 20);
            this.VmtName.TabIndex = 6;
            this.VmtName.Text = "example_vmt";
            // 
            // VmtButton
            // 
            this.VmtButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.VmtButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.VmtButton.Location = new System.Drawing.Point(2, 37);
            this.VmtButton.Margin = new System.Windows.Forms.Padding(0);
            this.VmtButton.Name = "VmtButton";
            this.VmtButton.Size = new System.Drawing.Size(222, 33);
            this.VmtButton.TabIndex = 5;
            this.VmtButton.Text = "Generate VMT";
            this.VmtButton.UseVisualStyleBackColor = true;
            this.VmtButton.Click += new System.EventHandler(this.VmtButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BatchMoveOutputCheck);
            this.groupBox3.Controls.Add(this.BatchIncludeFoldersCheck);
            this.groupBox3.Controls.Add(this.FolderButton);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(0, 414);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(224, 99);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Batch";
            // 
            // BatchMoveOutputCheck
            // 
            this.BatchMoveOutputCheck.AutoSize = true;
            this.BatchMoveOutputCheck.Checked = true;
            this.BatchMoveOutputCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatchMoveOutputCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BatchMoveOutputCheck.Location = new System.Drawing.Point(8, 42);
            this.BatchMoveOutputCheck.Name = "BatchMoveOutputCheck";
            this.BatchMoveOutputCheck.Size = new System.Drawing.Size(148, 17);
            this.BatchMoveOutputCheck.TabIndex = 15;
            this.BatchMoveOutputCheck.Text = "Move output to VMT path";
            this.BatchMoveOutputCheck.UseVisualStyleBackColor = true;
            // 
            // BatchIncludeFoldersCheck
            // 
            this.BatchIncludeFoldersCheck.AutoSize = true;
            this.BatchIncludeFoldersCheck.Checked = true;
            this.BatchIncludeFoldersCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BatchIncludeFoldersCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BatchIncludeFoldersCheck.Location = new System.Drawing.Point(8, 19);
            this.BatchIncludeFoldersCheck.Name = "BatchIncludeFoldersCheck";
            this.BatchIncludeFoldersCheck.Size = new System.Drawing.Size(188, 17);
            this.BatchIncludeFoldersCheck.TabIndex = 14;
            this.BatchIncludeFoldersCheck.Text = "Include folders in generated VMTs";
            this.BatchIncludeFoldersCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TighterPhongCheck);
            this.groupBox4.Controls.Add(this.OpenGlNormalCheck);
            this.groupBox4.Controls.Add(this.BrighterPhongCheck);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.VmtDestinationButton);
            this.groupBox4.Controls.Add(this.AlbedoSrgbCheck);
            this.groupBox4.Controls.Add(this.VmtDestinationPath);
            this.groupBox4.Controls.Add(this.MaxExponent);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.AoCheck);
            this.groupBox4.Controls.Add(this.SrgbCheck);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(0, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 4);
            this.groupBox4.Size = new System.Drawing.Size(224, 242);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // TighterPhongCheck
            // 
            this.TighterPhongCheck.AutoSize = true;
            this.TighterPhongCheck.Checked = true;
            this.TighterPhongCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TighterPhongCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.TighterPhongCheck.Location = new System.Drawing.Point(5, 110);
            this.TighterPhongCheck.Name = "TighterPhongCheck";
            this.TighterPhongCheck.Size = new System.Drawing.Size(164, 17);
            this.TighterPhongCheck.TabIndex = 13;
            this.TighterPhongCheck.Text = "Tighter phong with metalness";
            this.TighterPhongCheck.UseVisualStyleBackColor = true;
            // 
            // OpenGlNormalCheck
            // 
            this.OpenGlNormalCheck.AutoSize = true;
            this.OpenGlNormalCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OpenGlNormalCheck.Location = new System.Drawing.Point(5, 133);
            this.OpenGlNormalCheck.Name = "OpenGlNormalCheck";
            this.OpenGlNormalCheck.Size = new System.Drawing.Size(100, 17);
            this.OpenGlNormalCheck.TabIndex = 12;
            this.OpenGlNormalCheck.Text = "OpenGL normal";
            this.OpenGlNormalCheck.UseVisualStyleBackColor = true;
            // 
            // BrighterPhongCheck
            // 
            this.BrighterPhongCheck.AutoSize = true;
            this.BrighterPhongCheck.Checked = true;
            this.BrighterPhongCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.BrighterPhongCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BrighterPhongCheck.Location = new System.Drawing.Point(5, 87);
            this.BrighterPhongCheck.Name = "BrighterPhongCheck";
            this.BrighterPhongCheck.Size = new System.Drawing.Size(167, 17);
            this.BrighterPhongCheck.TabIndex = 9;
            this.BrighterPhongCheck.Text = "Brighter phong with metalness";
            this.BrighterPhongCheck.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(5, 199);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "VMT textures root path";
            // 
            // VmtDestinationButton
            // 
            this.VmtDestinationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VmtDestinationButton.Location = new System.Drawing.Point(197, 215);
            this.VmtDestinationButton.Name = "VmtDestinationButton";
            this.VmtDestinationButton.Size = new System.Drawing.Size(21, 21);
            this.VmtDestinationButton.TabIndex = 7;
            this.VmtDestinationButton.Text = "...";
            this.VmtDestinationButton.UseVisualStyleBackColor = true;
            this.VmtDestinationButton.Click += new System.EventHandler(this.VmtDestinationButton_Click);
            // 
            // AlbedoSrgbCheck
            // 
            this.AlbedoSrgbCheck.AutoSize = true;
            this.AlbedoSrgbCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AlbedoSrgbCheck.Location = new System.Drawing.Point(5, 41);
            this.AlbedoSrgbCheck.Name = "AlbedoSrgbCheck";
            this.AlbedoSrgbCheck.Size = new System.Drawing.Size(164, 17);
            this.AlbedoSrgbCheck.TabIndex = 6;
            this.AlbedoSrgbCheck.Text = "Convert albedo to linear RGB";
            this.AlbedoSrgbCheck.UseVisualStyleBackColor = true;
            // 
            // VmtDestinationPath
            // 
            this.VmtDestinationPath.Location = new System.Drawing.Point(5, 215);
            this.VmtDestinationPath.Name = "VmtDestinationPath";
            this.VmtDestinationPath.Size = new System.Drawing.Size(186, 20);
            this.VmtDestinationPath.TabIndex = 7;
            // 
            // MaxExponent
            // 
            this.MaxExponent.Location = new System.Drawing.Point(5, 156);
            this.MaxExponent.Maximum = new decimal(new int[] {
            155,
            0,
            0,
            0});
            this.MaxExponent.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxExponent.Name = "MaxExponent";
            this.MaxExponent.Size = new System.Drawing.Size(38, 20);
            this.MaxExponent.TabIndex = 4;
            this.MaxExponent.Value = new decimal(new int[] {
            30,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(49, 158);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max exponent";
            // 
            // AoCheck
            // 
            this.AoCheck.AutoSize = true;
            this.AoCheck.Checked = true;
            this.AoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AoCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AoCheck.Location = new System.Drawing.Point(5, 64);
            this.AoCheck.Name = "AoCheck";
            this.AoCheck.Size = new System.Drawing.Size(161, 17);
            this.AoCheck.TabIndex = 1;
            this.AoCheck.Text = "Apply AO to rough and metal";
            this.AoCheck.UseVisualStyleBackColor = true;
            // 
            // SrgbCheck
            // 
            this.SrgbCheck.AutoSize = true;
            this.SrgbCheck.Checked = true;
            this.SrgbCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.SrgbCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SrgbCheck.Location = new System.Drawing.Point(5, 18);
            this.SrgbCheck.Name = "SrgbCheck";
            this.SrgbCheck.Size = new System.Drawing.Size(162, 17);
            this.SrgbCheck.TabIndex = 0;
            this.SrgbCheck.Text = "Convert masks to linear RGB";
            this.SrgbCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(224, 513);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MWB Mats";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxExponent)).EndInit();
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
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox SrgbCheck;
        private System.Windows.Forms.CheckBox AoCheck;
        private System.Windows.Forms.NumericUpDown MaxExponent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.CheckBox AlbedoSrgbCheck;
        private System.Windows.Forms.Button VmtDestinationButton;
        private System.Windows.Forms.TextBox VmtDestinationPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox BrighterPhongCheck;
        private System.Windows.Forms.CheckBox OpenGlNormalCheck;
        private System.Windows.Forms.CheckBox TighterPhongCheck;
        private System.Windows.Forms.CheckBox BatchMoveOutputCheck;
        private System.Windows.Forms.CheckBox BatchIncludeFoldersCheck;
    }
}

