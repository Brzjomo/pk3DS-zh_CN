namespace pk3DS.WinForms
{
    partial class MartEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MartEditor6));
            CB_Location = new System.Windows.Forms.ComboBox();
            dgv = new System.Windows.Forms.DataGridView();
            L_Mart = new System.Windows.Forms.Label();
            B_Randomize = new System.Windows.Forms.Button();
            B_Save = new System.Windows.Forms.Button();
            B_Cancel = new System.Windows.Forms.Button();
            CHK_XItems = new System.Windows.Forms.CheckBox();
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
            dgv.Size = new System.Drawing.Size(500, 464);
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
            // B_Randomize
            // 
            B_Randomize.Location = new System.Drawing.Point(20, 532);
            B_Randomize.Margin = new System.Windows.Forms.Padding(5);
            B_Randomize.Name = "B_Randomize";
            B_Randomize.Size = new System.Drawing.Size(145, 37);
            B_Randomize.TabIndex = 3;
            B_Randomize.Text = "随机化";
            B_Randomize.UseVisualStyleBackColor = true;
            B_Randomize.Click += B_Randomize_Click;
            // 
            // B_Save
            // 
            B_Save.Location = new System.Drawing.Point(407, 532);
            B_Save.Margin = new System.Windows.Forms.Padding(5);
            B_Save.Name = "B_Save";
            B_Save.Size = new System.Drawing.Size(113, 37);
            B_Save.TabIndex = 4;
            B_Save.Text = "保存";
            B_Save.UseVisualStyleBackColor = true;
            B_Save.Click += B_Save_Click;
            // 
            // B_Cancel
            // 
            B_Cancel.Location = new System.Drawing.Point(283, 532);
            B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(113, 37);
            B_Cancel.TabIndex = 5;
            B_Cancel.Text = "取消";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // CHK_XItems
            // 
            CHK_XItems.AutoSize = true;
            CHK_XItems.Checked = true;
            CHK_XItems.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_XItems.Location = new System.Drawing.Point(22, 576);
            CHK_XItems.Margin = new System.Windows.Forms.Padding(5);
            CHK_XItems.Name = "CHK_XItems";
            CHK_XItems.Size = new System.Drawing.Size(237, 25);
            CHK_XItems.TabIndex = 304;
            CHK_XItems.Text = "不要随机强化道具（速通用）";
            CHK_XItems.UseVisualStyleBackColor = true;
            // 
            // MartEditor6
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(540, 616);
            Controls.Add(CHK_XItems);
            Controls.Add(B_Cancel);
            Controls.Add(B_Save);
            Controls.Add(B_Randomize);
            Controls.Add(L_Mart);
            Controls.Add(dgv);
            Controls.Add(CB_Location);
            Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(556, 655);
            MinimumSize = new System.Drawing.Size(556, 655);
            Name = "MartEditor6";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Mart Editor";
            ((System.ComponentModel.ISupportInitialize)dgv).EndInit();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Location;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label L_Mart;
        private System.Windows.Forms.Button B_Randomize;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.CheckBox CHK_XItems;
    }
}