
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
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.SettingsHelpButton = new System.Windows.Forms.Button();
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
            this.groupBox1.Controls.Add(this.HelpButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 99);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Texture Layout";
            // 
            // HelpButton
            // 
            this.HelpButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HelpButton.Location = new System.Drawing.Point(171, 11);
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
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox2.Location = new System.Drawing.Point(12, 117);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 74);
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
            this.VmtButton.Size = new System.Drawing.Size(188, 23);
            this.VmtButton.TabIndex = 5;
            this.VmtButton.Text = "Generate VMT";
            this.VmtButton.UseVisualStyleBackColor = true;
            this.VmtButton.Click += new System.EventHandler(this.VmtButton_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.FolderButton);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox3.Location = new System.Drawing.Point(12, 296);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 99);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Textures";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.SettingsHelpButton);
            this.groupBox4.Controls.Add(this.MaxExponent);
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.AoCheck);
            this.groupBox4.Controls.Add(this.SrgbCheck);
            this.groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.groupBox4.Location = new System.Drawing.Point(12, 197);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(200, 93);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Settings";
            // 
            // SettingsHelpButton
            // 
            this.SettingsHelpButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.SettingsHelpButton.Location = new System.Drawing.Point(171, 13);
            this.SettingsHelpButton.Name = "SettingsHelpButton";
            this.SettingsHelpButton.Size = new System.Drawing.Size(23, 23);
            this.SettingsHelpButton.TabIndex = 4;
            this.SettingsHelpButton.Text = "?";
            this.SettingsHelpButton.UseVisualStyleBackColor = true;
            this.SettingsHelpButton.Click += new System.EventHandler(this.SettingsHelpButton_Click);
            // 
            // MaxExponent
            // 
            this.MaxExponent.Location = new System.Drawing.Point(6, 65);
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
            this.label1.Location = new System.Drawing.Point(50, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Max non-metals exponent";
            // 
            // AoCheck
            // 
            this.AoCheck.AutoSize = true;
            this.AoCheck.Checked = true;
            this.AoCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AoCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.AoCheck.Location = new System.Drawing.Point(6, 42);
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
            this.SrgbCheck.Location = new System.Drawing.Point(6, 19);
            this.SrgbCheck.Name = "SrgbCheck";
            this.SrgbCheck.Size = new System.Drawing.Size(129, 17);
            this.SrgbCheck.TabIndex = 0;
            this.SrgbCheck.Text = "Convert to linear RGB";
            this.SrgbCheck.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 407);
            this.Controls.Add(this.groupBox4);
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
        private System.Windows.Forms.Button SettingsHelpButton;
    }
}

