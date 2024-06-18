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
            this.CB_Location = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.L_Mart = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Location
            // 
            this.CB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Location.FormattingEnabled = true;
            this.CB_Location.Location = new System.Drawing.Point(115, 10);
            this.CB_Location.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Location.Name = "CB_Location";
            this.CB_Location.Size = new System.Drawing.Size(402, 29);
            this.CB_Location.TabIndex = 0;
            this.CB_Location.SelectedIndexChanged += new System.EventHandler(this.ChangeIndex);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(20, 52);
            this.dgv.Margin = new System.Windows.Forms.Padding(5);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(500, 513);
            this.dgv.TabIndex = 1;
            // 
            // L_Mart
            // 
            this.L_Mart.AutoSize = true;
            this.L_Mart.Location = new System.Drawing.Point(20, 14);
            this.L_Mart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Mart.Name = "L_Mart";
            this.L_Mart.Size = new System.Drawing.Size(79, 21);
            this.L_Mart.TabIndex = 2;
            this.L_Mart.Text = "Location:";
            // 
            // TutorEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 584);
            this.Controls.Add(this.L_Mart);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.CB_Location);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(556, 945);
            this.MinimumSize = new System.Drawing.Size(556, 622);
            this.Name = "TutorEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Move Tutor Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Location;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label L_Mart;
    }
}