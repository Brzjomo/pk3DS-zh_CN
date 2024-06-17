namespace pk3DS
{
    sealed partial class TitleScreenEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TitleScreenEditor6));
            this.PB_Image = new System.Windows.Forms.PictureBox();
            this.CB_DARC = new System.Windows.Forms.ComboBox();
            this.CB_File = new System.Windows.Forms.ComboBox();
            this.L_DARCSelect = new System.Windows.Forms.Label();
            this.L_Dimensions = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Image
            // 
            this.PB_Image.BackColor = System.Drawing.Color.Transparent;
            this.PB_Image.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Image.Location = new System.Drawing.Point(20, 107);
            this.PB_Image.Margin = new System.Windows.Forms.Padding(5);
            this.PB_Image.Name = "PB_Image";
            this.PB_Image.Size = new System.Drawing.Size(402, 240);
            this.PB_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.PB_Image.TabIndex = 0;
            this.PB_Image.TabStop = false;
            this.PB_Image.Click += new System.EventHandler(this.PB_Image_Click);
            // 
            // CB_DARC
            // 
            this.CB_DARC.FormattingEnabled = true;
            this.CB_DARC.Location = new System.Drawing.Point(81, 12);
            this.CB_DARC.Margin = new System.Windows.Forms.Padding(5);
            this.CB_DARC.Name = "CB_DARC";
            this.CB_DARC.Size = new System.Drawing.Size(164, 29);
            this.CB_DARC.TabIndex = 1;
            this.CB_DARC.SelectedIndexChanged += new System.EventHandler(this.ChangeDARC);
            // 
            // CB_File
            // 
            this.CB_File.FormattingEnabled = true;
            this.CB_File.Location = new System.Drawing.Point(20, 56);
            this.CB_File.Margin = new System.Windows.Forms.Padding(5);
            this.CB_File.Name = "CB_File";
            this.CB_File.Size = new System.Drawing.Size(402, 29);
            this.CB_File.TabIndex = 2;
            this.CB_File.SelectedIndexChanged += new System.EventHandler(this.ChangeFile);
            // 
            // L_DARCSelect
            // 
            this.L_DARCSelect.AutoSize = true;
            this.L_DARCSelect.Location = new System.Drawing.Point(20, 16);
            this.L_DARCSelect.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_DARCSelect.Name = "L_DARCSelect";
            this.L_DARCSelect.Size = new System.Drawing.Size(58, 21);
            this.L_DARCSelect.TabIndex = 3;
            this.L_DARCSelect.Text = "DARC:";
            // 
            // L_Dimensions
            // 
            this.L_Dimensions.AutoSize = true;
            this.L_Dimensions.Location = new System.Drawing.Point(254, 16);
            this.L_Dimensions.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Dimensions.Name = "L_Dimensions";
            this.L_Dimensions.Size = new System.Drawing.Size(42, 21);
            this.L_Dimensions.TabIndex = 4;
            this.L_Dimensions.Text = "尺寸";
            // 
            // TitleScreenEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 368);
            this.Controls.Add(this.L_Dimensions);
            this.Controls.Add(this.L_DARCSelect);
            this.Controls.Add(this.CB_File);
            this.Controls.Add(this.CB_DARC);
            this.Controls.Add(this.PB_Image);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "TitleScreenEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "标题界面修改器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.PB_Image)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Image;
        private System.Windows.Forms.ComboBox CB_DARC;
        private System.Windows.Forms.ComboBox CB_File;
        private System.Windows.Forms.Label L_DARCSelect;
        private System.Windows.Forms.Label L_Dimensions;

    }
}