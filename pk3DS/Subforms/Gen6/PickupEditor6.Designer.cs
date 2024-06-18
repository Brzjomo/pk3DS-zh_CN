namespace pk3DS
{
    partial class PickupEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupEditor6));
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.L_TM = new System.Windows.Forms.Label();
            this.dgvRare = new System.Windows.Forms.DataGridView();
            this.L_HM = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Randomize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRare)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCommon
            // 
            this.dgvCommon.AllowUserToAddRows = false;
            this.dgvCommon.AllowUserToDeleteRows = false;
            this.dgvCommon.AllowUserToResizeColumns = false;
            this.dgvCommon.AllowUserToResizeRows = false;
            this.dgvCommon.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvCommon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommon.Location = new System.Drawing.Point(15, 40);
            this.dgvCommon.Margin = new System.Windows.Forms.Padding(5);
            this.dgvCommon.Name = "dgvCommon";
            this.dgvCommon.Size = new System.Drawing.Size(400, 485);
            this.dgvCommon.TabIndex = 1;
            // 
            // L_TM
            // 
            this.L_TM.AutoSize = true;
            this.L_TM.Location = new System.Drawing.Point(18, 16);
            this.L_TM.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_TM.Name = "L_TM";
            this.L_TM.Size = new System.Drawing.Size(123, 21);
            this.L_TM.TabIndex = 2;
            this.L_TM.Text = "常见 (30%-4%):";
            // 
            // dgvRare
            // 
            this.dgvRare.AllowUserToAddRows = false;
            this.dgvRare.AllowUserToDeleteRows = false;
            this.dgvRare.AllowUserToResizeColumns = false;
            this.dgvRare.AllowUserToResizeRows = false;
            this.dgvRare.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvRare.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRare.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRare.Location = new System.Drawing.Point(427, 40);
            this.dgvRare.Margin = new System.Windows.Forms.Padding(5);
            this.dgvRare.Name = "dgvRare";
            this.dgvRare.Size = new System.Drawing.Size(400, 485);
            this.dgvRare.TabIndex = 3;
            // 
            // L_HM
            // 
            this.L_HM.AutoSize = true;
            this.L_HM.Location = new System.Drawing.Point(430, 16);
            this.L_HM.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_HM.Name = "L_HM";
            this.L_HM.Size = new System.Drawing.Size(84, 21);
            this.L_HM.TabIndex = 4;
            this.L_HM.Text = "稀有 (1%):";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(257, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(155, 21);
            this.label1.TabIndex = 5;
            this.label1.Text = "(level-1)/10, take 9.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(669, 16);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "(level-1)/10, take 2.";
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(702, 536);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(125, 37);
            this.B_Save.TabIndex = 7;
            this.B_Save.Text = "保存";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(567, 536);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(125, 37);
            this.B_Cancel.TabIndex = 8;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Randomize
            // 
            this.B_Randomize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_Randomize.Location = new System.Drawing.Point(15, 536);
            this.B_Randomize.Margin = new System.Windows.Forms.Padding(5);
            this.B_Randomize.Name = "B_Randomize";
            this.B_Randomize.Size = new System.Drawing.Size(125, 37);
            this.B_Randomize.TabIndex = 9;
            this.B_Randomize.Text = "随机化";
            this.B_Randomize.UseVisualStyleBackColor = true;
            this.B_Randomize.Click += new System.EventHandler(this.B_Randomize_Click);
            // 
            // PickupEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 583);
            this.Controls.Add(this.B_Randomize);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.L_HM);
            this.Controls.Add(this.dgvRare);
            this.Controls.Add(this.L_TM);
            this.Controls.Add(this.dgvCommon);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(856, 1057);
            this.MinimumSize = new System.Drawing.Size(856, 622);
            this.Name = "PickupEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "捡拾编辑器";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRare)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.Label L_TM;
        private System.Windows.Forms.DataGridView dgvRare;
        private System.Windows.Forms.Label L_HM;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Randomize;
    }
}