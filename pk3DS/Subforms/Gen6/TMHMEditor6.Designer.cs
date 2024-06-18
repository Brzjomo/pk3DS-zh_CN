namespace pk3DS.WinForms
{
    partial class TMHMEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TMHMEditor6));
            this.dgvTM = new System.Windows.Forms.DataGridView();
            this.L_TM = new System.Windows.Forms.Label();
            this.dgvHM = new System.Windows.Forms.DataGridView();
            this.L_HM = new System.Windows.Forms.Label();
            this.B_RTM = new System.Windows.Forms.Button();
            this.CHK_RandomizeHM = new System.Windows.Forms.CheckBox();
            this.CHK_RandomizeField = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTM
            // 
            this.dgvTM.AllowUserToAddRows = false;
            this.dgvTM.AllowUserToDeleteRows = false;
            this.dgvTM.AllowUserToResizeColumns = false;
            this.dgvTM.AllowUserToResizeRows = false;
            this.dgvTM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvTM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTM.Location = new System.Drawing.Point(15, 40);
            this.dgvTM.Margin = new System.Windows.Forms.Padding(5);
            this.dgvTM.Name = "dgvTM";
            this.dgvTM.Size = new System.Drawing.Size(285, 485);
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
            // dgvHM
            // 
            this.dgvHM.AllowUserToAddRows = false;
            this.dgvHM.AllowUserToDeleteRows = false;
            this.dgvHM.AllowUserToResizeColumns = false;
            this.dgvHM.AllowUserToResizeRows = false;
            this.dgvHM.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvHM.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHM.Location = new System.Drawing.Point(310, 40);
            this.dgvHM.Margin = new System.Windows.Forms.Padding(5);
            this.dgvHM.Name = "dgvHM";
            this.dgvHM.Size = new System.Drawing.Size(265, 373);
            this.dgvHM.TabIndex = 3;
            // 
            // L_HM
            // 
            this.L_HM.AutoSize = true;
            this.L_HM.Location = new System.Drawing.Point(305, 14);
            this.L_HM.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_HM.Name = "L_HM";
            this.L_HM.Size = new System.Drawing.Size(62, 21);
            this.L_HM.TabIndex = 4;
            this.L_HM.Text = "秘传技:";
            // 
            // B_RTM
            // 
            this.B_RTM.Location = new System.Drawing.Point(488, 435);
            this.B_RTM.Margin = new System.Windows.Forms.Padding(5);
            this.B_RTM.Name = "B_RTM";
            this.B_RTM.Size = new System.Drawing.Size(87, 91);
            this.B_RTM.TabIndex = 5;
            this.B_RTM.Text = "随机化";
            this.B_RTM.UseVisualStyleBackColor = true;
            this.B_RTM.Click += new System.EventHandler(this.B_RandomTM_Click);
            // 
            // CHK_RandomizeHM
            // 
            this.CHK_RandomizeHM.AutoSize = true;
            this.CHK_RandomizeHM.Location = new System.Drawing.Point(22, 32);
            this.CHK_RandomizeHM.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_RandomizeHM.Name = "CHK_RandomizeHM";
            this.CHK_RandomizeHM.Size = new System.Drawing.Size(125, 25);
            this.CHK_RandomizeHM.TabIndex = 280;
            this.CHK_RandomizeHM.Text = "随机化秘传技";
            this.CHK_RandomizeHM.UseVisualStyleBackColor = true;
            // 
            // CHK_RandomizeField
            // 
            this.CHK_RandomizeField.AutoSize = true;
            this.CHK_RandomizeField.Location = new System.Drawing.Point(22, 58);
            this.CHK_RandomizeField.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_RandomizeField.Name = "CHK_RandomizeField";
            this.CHK_RandomizeField.Size = new System.Drawing.Size(141, 25);
            this.CHK_RandomizeField.TabIndex = 281;
            this.CHK_RandomizeField.Text = "随机化场地招式";
            this.CHK_RandomizeField.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.CHK_RandomizeHM);
            this.groupBox1.Controls.Add(this.CHK_RandomizeField);
            this.groupBox1.Location = new System.Drawing.Point(310, 424);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(168, 102);
            this.groupBox1.TabIndex = 282;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "随机化设置";
            // 
            // TMHMEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 536);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_RTM);
            this.Controls.Add(this.L_HM);
            this.Controls.Add(this.dgvHM);
            this.Controls.Add(this.L_TM);
            this.Controls.Add(this.dgvTM);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(856, 1057);
            this.Name = "TMHMEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "招式编号编辑器（6代）";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTM;
        private System.Windows.Forms.Label L_TM;
        private System.Windows.Forms.DataGridView dgvHM;
        private System.Windows.Forms.Label L_HM;
        private System.Windows.Forms.Button B_RTM;
        private System.Windows.Forms.CheckBox CHK_RandomizeHM;
        private System.Windows.Forms.CheckBox CHK_RandomizeField;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}