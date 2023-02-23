
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
            System.Windows.Forms.Label label2;
            System.Windows.Forms.Label label3;
            System.Windows.Forms.Label label4;
            System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
            System.Windows.Forms.Label label10;
            System.Windows.Forms.Label label9;
            System.Windows.Forms.Label label8;
            System.Windows.Forms.GroupBox groupBox5;
            System.Windows.Forms.Label label7;
            System.Windows.Forms.Label label6;
            System.Windows.Forms.Label label5;
            System.Windows.Forms.GroupBox groupBox1;
            System.Windows.Forms.GroupBox groupBox3;
            System.Windows.Forms.GroupBox groupBox4;
            System.Windows.Forms.Label label1;
            this.ExponentMipMapsCheck = new System.Windows.Forms.CheckBox();
            this.NormalMipMapsCheck = new System.Windows.Forms.CheckBox();
            this.ExponentCompression = new System.Windows.Forms.ComboBox();
            this.NormalCompression = new System.Windows.Forms.ComboBox();
            this.AlbedoCompression = new System.Windows.Forms.ComboBox();
            this.AlbedoMipMapsCheck = new System.Windows.Forms.CheckBox();
            this.HelpButton = new System.Windows.Forms.Button();
            this.BatchMoveOutputCheck = new System.Windows.Forms.CheckBox();
            this.BatchIncludeFoldersCheck = new System.Windows.Forms.CheckBox();
            this.FolderButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.VmtDestinationButton = new System.Windows.Forms.Button();
            this.VmtDestinationPath = new System.Windows.Forms.TextBox();
            this.GlossyFresnelCheck = new System.Windows.Forms.CheckBox();
            this.PhongAlbedoTintCheck = new System.Windows.Forms.CheckBox();
            this.PhongBoost = new System.Windows.Forms.NumericUpDown();
            this.OpenGlNormalCheck = new System.Windows.Forms.CheckBox();
            this.AlbedoSrgbCheck = new System.Windows.Forms.CheckBox();
            this.MaxExponent = new System.Windows.Forms.NumericUpDown();
            this.AoCheck = new System.Windows.Forms.CheckBox();
            this.SrgbCheck = new System.Windows.Forms.CheckBox();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            label10 = new System.Windows.Forms.Label();
            label9 = new System.Windows.Forms.Label();
            label8 = new System.Windows.Forms.Label();
            groupBox5 = new System.Windows.Forms.GroupBox();
            label7 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            groupBox1 = new System.Windows.Forms.GroupBox();
            groupBox3 = new System.Windows.Forms.GroupBox();
            groupBox4 = new System.Windows.Forms.GroupBox();
            label1 = new System.Windows.Forms.Label();
            tableLayoutPanel1.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBoost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxExponent)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = System.Drawing.SystemColors.ControlText;
            label2.Location = new System.Drawing.Point(5, 15);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(137, 78);
            label2.TabIndex = 2;
            label2.Text = "_rgb - albedo\r\n_alpha, _m - metalness\r\n_g - gloss\r\n_r - roughness\r\n_o, _ao - ambi" +
    "ent occlusion\r\n_n - normal\r\n";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.SystemColors.Control;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label3.Location = new System.Drawing.Point(0, 0);
            label3.Margin = new System.Windows.Forms.Padding(0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(194, 22);
            label3.TabIndex = 8;
            label3.Text = "VMT textures root path";
            label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.SystemColors.Control;
            label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label4.Location = new System.Drawing.Point(122, 137);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(34, 13);
            label4.TabIndex = 14;
            label4.Text = "Boost";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 144F));
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            tableLayoutPanel1.Controls.Add(label10, 0, 2);
            tableLayoutPanel1.Controls.Add(label9, 0, 1);
            tableLayoutPanel1.Controls.Add(label8, 0, 0);
            tableLayoutPanel1.Controls.Add(this.ExponentMipMapsCheck, 2, 2);
            tableLayoutPanel1.Controls.Add(this.NormalMipMapsCheck, 2, 1);
            tableLayoutPanel1.Controls.Add(this.ExponentCompression, 1, 2);
            tableLayoutPanel1.Controls.Add(this.NormalCompression, 1, 1);
            tableLayoutPanel1.Controls.Add(this.AlbedoCompression, 1, 0);
            tableLayoutPanel1.Controls.Add(this.AlbedoMipMapsCheck, 2, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            tableLayoutPanel1.Location = new System.Drawing.Point(3, 36);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 48.3871F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 51.6129F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            tableLayoutPanel1.Size = new System.Drawing.Size(218, 90);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Dock = System.Windows.Forms.DockStyle.Fill;
            label10.ForeColor = System.Drawing.Color.ForestGreen;
            label10.Location = new System.Drawing.Point(3, 60);
            label10.Name = "label10";
            label10.Size = new System.Drawing.Size(35, 30);
            label10.TabIndex = 22;
            label10.Text = "E";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Dock = System.Windows.Forms.DockStyle.Fill;
            label9.ForeColor = System.Drawing.Color.MediumSlateBlue;
            label9.Location = new System.Drawing.Point(3, 29);
            label9.Name = "label9";
            label9.Size = new System.Drawing.Size(35, 31);
            label9.TabIndex = 21;
            label9.Text = "N";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Dock = System.Windows.Forms.DockStyle.Fill;
            label8.ForeColor = System.Drawing.Color.Red;
            label8.Location = new System.Drawing.Point(3, 0);
            label8.Name = "label8";
            label8.Size = new System.Drawing.Size(35, 29);
            label8.TabIndex = 10;
            label8.Text = "RGB";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ExponentMipMapsCheck
            // 
            this.ExponentMipMapsCheck.AutoSize = true;
            this.ExponentMipMapsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ExponentMipMapsCheck.Checked = true;
            this.ExponentMipMapsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ExponentMipMapsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExponentMipMapsCheck.Location = new System.Drawing.Point(188, 63);
            this.ExponentMipMapsCheck.Name = "ExponentMipMapsCheck";
            this.ExponentMipMapsCheck.Size = new System.Drawing.Size(27, 24);
            this.ExponentMipMapsCheck.TabIndex = 20;
            this.ExponentMipMapsCheck.UseVisualStyleBackColor = true;
            // 
            // NormalMipMapsCheck
            // 
            this.NormalMipMapsCheck.AutoSize = true;
            this.NormalMipMapsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NormalMipMapsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalMipMapsCheck.Location = new System.Drawing.Point(188, 32);
            this.NormalMipMapsCheck.Name = "NormalMipMapsCheck";
            this.NormalMipMapsCheck.Size = new System.Drawing.Size(27, 25);
            this.NormalMipMapsCheck.TabIndex = 19;
            this.NormalMipMapsCheck.UseVisualStyleBackColor = true;
            // 
            // ExponentCompression
            // 
            this.ExponentCompression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExponentCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExponentCompression.FormattingEnabled = true;
            this.ExponentCompression.Location = new System.Drawing.Point(44, 63);
            this.ExponentCompression.Name = "ExponentCompression";
            this.ExponentCompression.Size = new System.Drawing.Size(138, 21);
            this.ExponentCompression.TabIndex = 18;
            // 
            // NormalCompression
            // 
            this.NormalCompression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NormalCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.NormalCompression.FormattingEnabled = true;
            this.NormalCompression.Location = new System.Drawing.Point(44, 32);
            this.NormalCompression.Name = "NormalCompression";
            this.NormalCompression.Size = new System.Drawing.Size(138, 21);
            this.NormalCompression.TabIndex = 16;
            // 
            // AlbedoCompression
            // 
            this.AlbedoCompression.DisplayMember = "DXT5";
            this.AlbedoCompression.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbedoCompression.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AlbedoCompression.FormattingEnabled = true;
            this.AlbedoCompression.Location = new System.Drawing.Point(44, 3);
            this.AlbedoCompression.Name = "AlbedoCompression";
            this.AlbedoCompression.Size = new System.Drawing.Size(138, 21);
            this.AlbedoCompression.TabIndex = 0;
            // 
            // AlbedoMipMapsCheck
            // 
            this.AlbedoMipMapsCheck.AutoSize = true;
            this.AlbedoMipMapsCheck.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.AlbedoMipMapsCheck.Checked = true;
            this.AlbedoMipMapsCheck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.AlbedoMipMapsCheck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AlbedoMipMapsCheck.Location = new System.Drawing.Point(188, 3);
            this.AlbedoMipMapsCheck.Name = "AlbedoMipMapsCheck";
            this.AlbedoMipMapsCheck.Size = new System.Drawing.Size(27, 23);
            this.AlbedoMipMapsCheck.TabIndex = 1;
            this.AlbedoMipMapsCheck.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label7);
            groupBox5.Controls.Add(label6);
            groupBox5.Controls.Add(label5);
            groupBox5.Controls.Add(tableLayoutPanel1);
            groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupBox5.ForeColor = System.Drawing.SystemColors.ControlDark;
            groupBox5.Location = new System.Drawing.Point(0, 343);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new System.Drawing.Size(224, 129);
            groupBox5.TabIndex = 7;
            groupBox5.TabStop = false;
            groupBox5.Text = "VTFs";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label7.Location = new System.Drawing.Point(2, 16);
            label7.Name = "label7";
            label7.Size = new System.Drawing.Size(43, 13);
            label7.TabIndex = 9;
            label7.Text = "Texture";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label6.Location = new System.Drawing.Point(189, 16);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(29, 13);
            label6.TabIndex = 8;
            label6.Text = "Mips";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            label5.Location = new System.Drawing.Point(77, 16);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(67, 13);
            label5.TabIndex = 7;
            label5.Text = "Compression";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(this.HelpButton);
            groupBox1.Controls.Add(label2);
            groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox1.Location = new System.Drawing.Point(0, 0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 0, 0);
            groupBox1.Size = new System.Drawing.Size(224, 99);
            groupBox1.TabIndex = 3;
            groupBox1.TabStop = false;
            groupBox1.Text = "Texture Layout";
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
            // groupBox3
            // 
            groupBox3.Controls.Add(this.BatchMoveOutputCheck);
            groupBox3.Controls.Add(this.BatchIncludeFoldersCheck);
            groupBox3.Controls.Add(this.FolderButton);
            groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            groupBox3.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox3.Location = new System.Drawing.Point(0, 472);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new System.Drawing.Size(224, 99);
            groupBox3.TabIndex = 4;
            groupBox3.TabStop = false;
            groupBox3.Text = "Batch";
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
            this.BatchIncludeFoldersCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.BatchIncludeFoldersCheck.Location = new System.Drawing.Point(8, 19);
            this.BatchIncludeFoldersCheck.Name = "BatchIncludeFoldersCheck";
            this.BatchIncludeFoldersCheck.Size = new System.Drawing.Size(188, 17);
            this.BatchIncludeFoldersCheck.TabIndex = 14;
            this.BatchIncludeFoldersCheck.Text = "Include folders in generated VMTs";
            this.BatchIncludeFoldersCheck.UseVisualStyleBackColor = true;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(this.tableLayoutPanel2);
            groupBox4.Controls.Add(this.GlossyFresnelCheck);
            groupBox4.Controls.Add(this.PhongAlbedoTintCheck);
            groupBox4.Controls.Add(label4);
            groupBox4.Controls.Add(this.PhongBoost);
            groupBox4.Controls.Add(this.OpenGlNormalCheck);
            groupBox4.Controls.Add(this.AlbedoSrgbCheck);
            groupBox4.Controls.Add(this.MaxExponent);
            groupBox4.Controls.Add(label1);
            groupBox4.Controls.Add(this.AoCheck);
            groupBox4.Controls.Add(this.SrgbCheck);
            groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            groupBox4.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            groupBox4.Location = new System.Drawing.Point(0, 99);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new System.Windows.Forms.Padding(2, 2, 0, 4);
            groupBox4.Size = new System.Drawing.Size(224, 242);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Settings";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.38739F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.61261F));
            this.tableLayoutPanel2.Controls.Add(this.VmtDestinationButton, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.VmtDestinationPath, 0, 1);
            this.tableLayoutPanel2.Controls.Add(label3, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(2, 184);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.74074F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 59.25926F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(222, 54);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // VmtDestinationButton
            // 
            this.VmtDestinationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.VmtDestinationButton.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.VmtDestinationButton.Location = new System.Drawing.Point(197, 27);
            this.VmtDestinationButton.Name = "VmtDestinationButton";
            this.VmtDestinationButton.Size = new System.Drawing.Size(22, 22);
            this.VmtDestinationButton.TabIndex = 7;
            this.VmtDestinationButton.Text = "...";
            this.VmtDestinationButton.UseVisualStyleBackColor = true;
            this.VmtDestinationButton.Click += new System.EventHandler(this.VmtDestinationButton_Click);
            // 
            // VmtDestinationPath
            // 
            this.VmtDestinationPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.VmtDestinationPath.Location = new System.Drawing.Point(3, 28);
            this.VmtDestinationPath.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.VmtDestinationPath.Name = "VmtDestinationPath";
            this.VmtDestinationPath.Size = new System.Drawing.Size(188, 20);
            this.VmtDestinationPath.TabIndex = 7;
            // 
            // GlossyFresnelCheck
            // 
            this.GlossyFresnelCheck.AutoSize = true;
            this.GlossyFresnelCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.GlossyFresnelCheck.Location = new System.Drawing.Point(5, 161);
            this.GlossyFresnelCheck.Name = "GlossyFresnelCheck";
            this.GlossyFresnelCheck.Size = new System.Drawing.Size(91, 17);
            this.GlossyFresnelCheck.TabIndex = 16;
            this.GlossyFresnelCheck.Text = "Glossy fresnel";
            this.GlossyFresnelCheck.UseVisualStyleBackColor = true;
            // 
            // PhongAlbedoTintCheck
            // 
            this.PhongAlbedoTintCheck.AutoSize = true;
            this.PhongAlbedoTintCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PhongAlbedoTintCheck.Location = new System.Drawing.Point(5, 136);
            this.PhongAlbedoTintCheck.Name = "PhongAlbedoTintCheck";
            this.PhongAlbedoTintCheck.Size = new System.Drawing.Size(62, 17);
            this.PhongAlbedoTintCheck.TabIndex = 15;
            this.PhongAlbedoTintCheck.Text = "Colored";
            this.PhongAlbedoTintCheck.UseVisualStyleBackColor = true;
            this.PhongAlbedoTintCheck.CheckedChanged += new System.EventHandler(this.PhongAlbedoTintCheck_CheckedChanged);
            // 
            // PhongBoost
            // 
            this.PhongBoost.Enabled = false;
            this.PhongBoost.Location = new System.Drawing.Point(80, 135);
            this.PhongBoost.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.PhongBoost.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.PhongBoost.Name = "PhongBoost";
            this.PhongBoost.Size = new System.Drawing.Size(38, 20);
            this.PhongBoost.TabIndex = 13;
            this.PhongBoost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // OpenGlNormalCheck
            // 
            this.OpenGlNormalCheck.AutoSize = true;
            this.OpenGlNormalCheck.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.OpenGlNormalCheck.Location = new System.Drawing.Point(5, 87);
            this.OpenGlNormalCheck.Name = "OpenGlNormalCheck";
            this.OpenGlNormalCheck.Size = new System.Drawing.Size(100, 17);
            this.OpenGlNormalCheck.TabIndex = 12;
            this.OpenGlNormalCheck.Text = "OpenGL normal";
            this.OpenGlNormalCheck.UseVisualStyleBackColor = true;
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
            // MaxExponent
            // 
            this.MaxExponent.Location = new System.Drawing.Point(5, 110);
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
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.SystemColors.Control;
            label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            label1.Location = new System.Drawing.Point(49, 112);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(74, 13);
            label1.TabIndex = 3;
            label1.Text = "Max exponent";
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
            this.ClientSize = new System.Drawing.Size(224, 571);
            this.Controls.Add(groupBox5);
            this.Controls.Add(groupBox4);
            this.Controls.Add(groupBox3);
            this.Controls.Add(groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "MWB Mats";
            this.Load += new System.EventHandler(this.Form1_Load);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PhongBoost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxExponent)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button FolderButton;
        private System.Windows.Forms.CheckBox SrgbCheck;
        private System.Windows.Forms.CheckBox AoCheck;
        private System.Windows.Forms.NumericUpDown MaxExponent;
        private System.Windows.Forms.Button HelpButton;
        private System.Windows.Forms.CheckBox AlbedoSrgbCheck;
        private System.Windows.Forms.Button VmtDestinationButton;
        private System.Windows.Forms.CheckBox OpenGlNormalCheck;
        private System.Windows.Forms.CheckBox BatchMoveOutputCheck;
        private System.Windows.Forms.CheckBox BatchIncludeFoldersCheck;
        private System.Windows.Forms.NumericUpDown PhongBoost;
        private System.Windows.Forms.CheckBox PhongAlbedoTintCheck;
        private System.Windows.Forms.TextBox VmtDestinationPath;
        private System.Windows.Forms.ComboBox AlbedoCompression;
        private System.Windows.Forms.CheckBox AlbedoMipMapsCheck;
        private System.Windows.Forms.CheckBox ExponentMipMapsCheck;
        private System.Windows.Forms.CheckBox NormalMipMapsCheck;
        private System.Windows.Forms.ComboBox ExponentCompression;
        private System.Windows.Forms.ComboBox NormalCompression;
        private System.Windows.Forms.CheckBox GlossyFresnelCheck;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

