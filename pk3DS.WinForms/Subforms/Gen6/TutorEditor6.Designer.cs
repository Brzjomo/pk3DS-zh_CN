namespace pk3DS.WinForms
{
    partial class TutorEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TutorEditor6));
            CB_Location = new System.Windows.Forms.ComboBox();
            dgv = new System.Windows.Forms.DataGridView();
            L_Mart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dgv).BeginInit();
            SuspendLayout();
            // 
            // CB_Location
            // 
            CB_Location.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CB_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            CB_Location.FormattingEnabled = true;
            CB_Location.Location = new System.Drawing.Point(76, 10);
            CB_Location.Margin = new System.Windows.Forms.Padding(5);
            CB_Location.Name = "CB_Location";
            CB_Location.Size = new System.Drawing.Size(441, 29);
            CB_Location.TabIndex = 0;
            CB_Location.SelectedIndexChanged += ChangeIndex;
            // 
            // dgv
            // 
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            dgv.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgv.Location = new System.Drawing.Point(20, 52);
            dgv.Margin = new System.Windows.Forms.Padding(5);
            dgv.Name = "dgv";
            dgv.Size = new System.Drawing.Size(500, 513);
            dgv.TabIndex = 1;
            // 
            // L_Mart
            // 
            L_Mart.AutoSize = true;
            L_Mart.Location = new System.Drawing.Point(20, 14);
            L_Mart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Mart.Name = "L_Mart";
            L_Mart.Size = new System.Drawing.Size(46, 21);
            L_Mart.TabIndex = 2;
            L_Mart.Text = "地点:";
            // 
            // TutorEditor6
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(540, 584);
            Controls.Add(L_Mart);
            Controls.Add(dgv);
            Controls.Add(CB_Location);
            Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(556, 945);
            MinimumSize = new System.Drawing.Size(556, 622);
            Name = "TutorEditor6";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Move Tutor Editor";
            FormClosing += Form_Closing;
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Location;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label L_Mart;
    }
}