namespace pk3DS
{
    sealed partial class Icon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Icon));
            this.PB_Large = new System.Windows.Forms.PictureBox();
            this.CB_AppInfo = new System.Windows.Forms.ComboBox();
            this.L_AppInfo = new System.Windows.Forms.Label();
            this.PB_Small = new System.Windows.Forms.PictureBox();
            this.TB_Short = new System.Windows.Forms.TextBox();
            this.TB_Long = new System.Windows.Forms.TextBox();
            this.TB_Publisher = new System.Windows.Forms.TextBox();
            this.B_ExportSMDH = new System.Windows.Forms.Button();
            this.B_ExportSmallIcon = new System.Windows.Forms.Button();
            this.B_ExportLargeIcon = new System.Windows.Forms.Button();
            this.B_ImportLargeIcon = new System.Windows.Forms.Button();
            this.B_ImportSmallIcon = new System.Windows.Forms.Button();
            this.B_ImportSMDH = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Large)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Small)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PB_Large
            // 
            this.PB_Large.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PB_Large.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Large.Location = new System.Drawing.Point(280, 14);
            this.PB_Large.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PB_Large.Name = "PB_Large";
            this.PB_Large.Size = new System.Drawing.Size(82, 79);
            this.PB_Large.TabIndex = 1;
            this.PB_Large.TabStop = false;
            // 
            // CB_AppInfo
            // 
            this.CB_AppInfo.FormattingEnabled = true;
            this.CB_AppInfo.Location = new System.Drawing.Point(25, 61);
            this.CB_AppInfo.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CB_AppInfo.Name = "CB_AppInfo";
            this.CB_AppInfo.Size = new System.Drawing.Size(247, 29);
            this.CB_AppInfo.TabIndex = 8;
            this.CB_AppInfo.SelectedIndexChanged += new System.EventHandler(this.CB_AppInfo_SelectedIndexChanged);
            // 
            // L_AppInfo
            // 
            this.L_AppInfo.AutoSize = true;
            this.L_AppInfo.Location = new System.Drawing.Point(20, 35);
            this.L_AppInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_AppInfo.Name = "L_AppInfo";
            this.L_AppInfo.Size = new System.Drawing.Size(82, 21);
            this.L_AppInfo.TabIndex = 7;
            this.L_AppInfo.Text = "AppInfo#";
            // 
            // PB_Small
            // 
            this.PB_Small.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.PB_Small.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Small.Location = new System.Drawing.Point(227, 14);
            this.PB_Small.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.PB_Small.Name = "PB_Small";
            this.PB_Small.Size = new System.Drawing.Size(42, 40);
            this.PB_Small.TabIndex = 9;
            this.PB_Small.TabStop = false;
            // 
            // TB_Short
            // 
            this.TB_Short.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Short.Location = new System.Drawing.Point(25, 105);
            this.TB_Short.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TB_Short.MaxLength = 64;
            this.TB_Short.Name = "TB_Short";
            this.TB_Short.Size = new System.Drawing.Size(479, 29);
            this.TB_Short.TabIndex = 10;
            // 
            // TB_Long
            // 
            this.TB_Long.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Long.Location = new System.Drawing.Point(25, 147);
            this.TB_Long.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TB_Long.MaxLength = 128;
            this.TB_Long.Name = "TB_Long";
            this.TB_Long.Size = new System.Drawing.Size(479, 29);
            this.TB_Long.TabIndex = 11;
            // 
            // TB_Publisher
            // 
            this.TB_Publisher.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TB_Publisher.Location = new System.Drawing.Point(25, 189);
            this.TB_Publisher.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.TB_Publisher.MaxLength = 64;
            this.TB_Publisher.Name = "TB_Publisher";
            this.TB_Publisher.Size = new System.Drawing.Size(479, 29);
            this.TB_Publisher.TabIndex = 12;
            // 
            // B_ExportSMDH
            // 
            this.B_ExportSMDH.Location = new System.Drawing.Point(10, 77);
            this.B_ExportSMDH.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ExportSMDH.Name = "B_ExportSMDH";
            this.B_ExportSMDH.Size = new System.Drawing.Size(147, 37);
            this.B_ExportSMDH.TabIndex = 15;
            this.B_ExportSMDH.Text = "Export SMDH";
            this.B_ExportSMDH.UseVisualStyleBackColor = true;
            this.B_ExportSMDH.Click += new System.EventHandler(this.B_ExportSMDH_Click);
            // 
            // B_ExportSmallIcon
            // 
            this.B_ExportSmallIcon.Location = new System.Drawing.Point(167, 77);
            this.B_ExportSmallIcon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ExportSmallIcon.Name = "B_ExportSmallIcon";
            this.B_ExportSmallIcon.Size = new System.Drawing.Size(147, 37);
            this.B_ExportSmallIcon.TabIndex = 16;
            this.B_ExportSmallIcon.Text = "Export Small";
            this.B_ExportSmallIcon.UseVisualStyleBackColor = true;
            this.B_ExportSmallIcon.Click += new System.EventHandler(this.B_ExportSmallIcon_Click);
            // 
            // B_ExportLargeIcon
            // 
            this.B_ExportLargeIcon.Location = new System.Drawing.Point(323, 77);
            this.B_ExportLargeIcon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ExportLargeIcon.Name = "B_ExportLargeIcon";
            this.B_ExportLargeIcon.Size = new System.Drawing.Size(147, 37);
            this.B_ExportLargeIcon.TabIndex = 17;
            this.B_ExportLargeIcon.Text = "Export Large";
            this.B_ExportLargeIcon.UseVisualStyleBackColor = true;
            this.B_ExportLargeIcon.Click += new System.EventHandler(this.B_ExportLargeIcon_Click);
            // 
            // B_ImportLargeIcon
            // 
            this.B_ImportLargeIcon.Enabled = false;
            this.B_ImportLargeIcon.Location = new System.Drawing.Point(323, 32);
            this.B_ImportLargeIcon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ImportLargeIcon.Name = "B_ImportLargeIcon";
            this.B_ImportLargeIcon.Size = new System.Drawing.Size(147, 37);
            this.B_ImportLargeIcon.TabIndex = 20;
            this.B_ImportLargeIcon.Text = "Import Large";
            this.B_ImportLargeIcon.UseVisualStyleBackColor = true;
            this.B_ImportLargeIcon.Click += new System.EventHandler(this.B_ImportLargeIcon_Click);
            // 
            // B_ImportSmallIcon
            // 
            this.B_ImportSmallIcon.Enabled = false;
            this.B_ImportSmallIcon.Location = new System.Drawing.Point(167, 32);
            this.B_ImportSmallIcon.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ImportSmallIcon.Name = "B_ImportSmallIcon";
            this.B_ImportSmallIcon.Size = new System.Drawing.Size(147, 37);
            this.B_ImportSmallIcon.TabIndex = 19;
            this.B_ImportSmallIcon.Text = "Import Small";
            this.B_ImportSmallIcon.UseVisualStyleBackColor = true;
            this.B_ImportSmallIcon.Click += new System.EventHandler(this.B_ImportSmallIcon_Click);
            // 
            // B_ImportSMDH
            // 
            this.B_ImportSMDH.Location = new System.Drawing.Point(10, 32);
            this.B_ImportSMDH.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_ImportSMDH.Name = "B_ImportSMDH";
            this.B_ImportSMDH.Size = new System.Drawing.Size(147, 37);
            this.B_ImportSMDH.TabIndex = 18;
            this.B_ImportSMDH.Text = "Import SMDH";
            this.B_ImportSMDH.UseVisualStyleBackColor = true;
            this.B_ImportSMDH.Click += new System.EventHandler(this.B_ImportSMDH_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(397, 383);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(110, 37);
            this.B_Save.TabIndex = 21;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(277, 383);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(110, 37);
            this.B_Cancel.TabIndex = 22;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.B_ImportLargeIcon);
            this.groupBox1.Controls.Add(this.B_ImportSmallIcon);
            this.groupBox1.Controls.Add(this.B_ImportSMDH);
            this.groupBox1.Controls.Add(this.B_ExportLargeIcon);
            this.groupBox1.Controls.Add(this.B_ExportSMDH);
            this.groupBox1.Controls.Add(this.B_ExportSmallIcon);
            this.groupBox1.Location = new System.Drawing.Point(25, 231);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.groupBox1.Size = new System.Drawing.Size(482, 136);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            // 
            // Icon
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(528, 439);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.TB_Publisher);
            this.Controls.Add(this.TB_Long);
            this.Controls.Add(this.TB_Short);
            this.Controls.Add(this.PB_Small);
            this.Controls.Add(this.CB_AppInfo);
            this.Controls.Add(this.L_AppInfo);
            this.Controls.Add(this.PB_Large);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(523, 370);
            this.Name = "Icon";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SMDH Editor";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Large)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Small)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Large;
        private System.Windows.Forms.ComboBox CB_AppInfo;
        private System.Windows.Forms.Label L_AppInfo;
        private System.Windows.Forms.PictureBox PB_Small;
        private System.Windows.Forms.TextBox TB_Short;
        private System.Windows.Forms.TextBox TB_Long;
        private System.Windows.Forms.TextBox TB_Publisher;
        private System.Windows.Forms.Button B_ExportSMDH;
        private System.Windows.Forms.Button B_ExportSmallIcon;
        private System.Windows.Forms.Button B_ExportLargeIcon;
        private System.Windows.Forms.Button B_ImportLargeIcon;
        private System.Windows.Forms.Button B_ImportSmallIcon;
        private System.Windows.Forms.Button B_ImportSMDH;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.GroupBox groupBox1;

    }
}