namespace pk3DS
{
    partial class TMEditor7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMEditor7));
            this.dgvTM = new System.Windows.Forms.DataGridView();
            this.L_TM = new System.Windows.Forms.Label();
            this.B_RTM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTM)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTM
            // 
            this.dgvTM.AllowUserToAddRows = false;
            this.dgvTM.AllowUserToDeleteRows = false;
            this.dgvTM.AllowUserToResizeColumns = false;
            this.dgvTM.AllowUserToResizeRows = false;
            this.dgvTM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTM.Location = new System.Drawing.Point(15, 40);
            this.dgvTM.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTM.Name = "dgvTM";
            this.dgvTM.Size = new System.Drawing.Size(285, 483);
            this.dgvTM.TabIndex = 1;
            // 
            // L_TM
            // 
            this.L_TM.AutoSize = true;
            this.L_TM.Location = new System.Drawing.Point(11, 14);
            this.L_TM.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_TM.Name = "L_TM";
            this.L_TM.Size = new System.Drawing.Size(46, 21);
            this.L_TM.TabIndex = 2;
            this.L_TM.Text = "招式:";
            // 
            // B_RTM
            // 
            this.B_RTM.Location = new System.Drawing.Point(176, 2);
            this.B_RTM.Margin = new System.Windows.Forms.Padding(5);
            this.B_RTM.Name = "B_RTM";
            this.B_RTM.Size = new System.Drawing.Size(125, 37);
            this.B_RTM.TabIndex = 5;
            this.B_RTM.Text = "随机化";
            this.B_RTM.UseVisualStyleBackColor = true;
            this.B_RTM.Click += new System.EventHandler(this.B_RandomTM_Click);
            // 
            // TMEditor7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(314, 536);
            this.Controls.Add(this.B_RTM);
            this.Controls.Add(this.L_TM);
            this.Controls.Add(this.dgvTM);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(856, 1057);
            this.Name = "TMEditor7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "招式编号编辑器（7代）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTM;
        private System.Windows.Forms.Label L_TM;
        private System.Windows.Forms.Button B_RTM;
    }
}