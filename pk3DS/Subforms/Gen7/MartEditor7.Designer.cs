namespace pk3DS.WinForms
{
    partial class MartEditor7
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MartEditor7));
            this.CB_Location = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.dgvIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItem = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.L_Mart = new System.Windows.Forms.Label();
            this.B_Randomize = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CB_LocationBP = new System.Windows.Forms.ComboBox();
            this.B_RandomizeBP = new System.Windows.Forms.Button();
            this.dgvbp = new System.Windows.Forms.DataGridView();
            this.dgvIndexBP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvItemBP = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgvPriceBP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CHK_XItems = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbp)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Location
            // 
            this.CB_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Location.FormattingEnabled = true;
            this.CB_Location.Location = new System.Drawing.Point(76, 10);
            this.CB_Location.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Location.Name = "CB_Location";
            this.CB_Location.Size = new System.Drawing.Size(441, 29);
            this.CB_Location.TabIndex = 0;
            this.CB_Location.SelectedIndexChanged += new System.EventHandler(this.ChangeIndex);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIndex,
            this.dgvItem});
            this.dgv.Location = new System.Drawing.Point(20, 52);
            this.dgv.Margin = new System.Windows.Forms.Padding(5);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(500, 458);
            this.dgv.TabIndex = 1;
            // 
            // dgvIndex
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvIndex.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvIndex.HeaderText = "Index";
            this.dgvIndex.Name = "dgvIndex";
            this.dgvIndex.ReadOnly = true;
            this.dgvIndex.Width = 45;
            // 
            // dgvItem
            // 
            this.dgvItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvItem.HeaderText = "Item";
            this.dgvItem.Name = "dgvItem";
            this.dgvItem.Width = 135;
            // 
            // L_Mart
            // 
            this.L_Mart.AutoSize = true;
            this.L_Mart.Location = new System.Drawing.Point(20, 14);
            this.L_Mart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Mart.Name = "L_Mart";
            this.L_Mart.Size = new System.Drawing.Size(46, 21);
            this.L_Mart.TabIndex = 2;
            this.L_Mart.Text = "地点:";
            // 
            // B_Randomize
            // 
            this.B_Randomize.Location = new System.Drawing.Point(20, 527);
            this.B_Randomize.Margin = new System.Windows.Forms.Padding(5);
            this.B_Randomize.Name = "B_Randomize";
            this.B_Randomize.Size = new System.Drawing.Size(145, 37);
            this.B_Randomize.TabIndex = 3;
            this.B_Randomize.Text = "随机化";
            this.B_Randomize.UseVisualStyleBackColor = true;
            this.B_Randomize.Click += new System.EventHandler(this.B_Randomize_Click);
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(932, 527);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(113, 37);
            this.B_Save.TabIndex = 4;
            this.B_Save.Text = "保存";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(808, 527);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(113, 37);
            this.B_Cancel.TabIndex = 5;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(545, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "地点:";
            // 
            // CB_LocationBP
            // 
            this.CB_LocationBP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_LocationBP.FormattingEnabled = true;
            this.CB_LocationBP.Location = new System.Drawing.Point(601, 10);
            this.CB_LocationBP.Margin = new System.Windows.Forms.Padding(5);
            this.CB_LocationBP.Name = "CB_LocationBP";
            this.CB_LocationBP.Size = new System.Drawing.Size(441, 29);
            this.CB_LocationBP.TabIndex = 6;
            this.CB_LocationBP.SelectedIndexChanged += new System.EventHandler(this.ChangeIndexBP);
            // 
            // B_RandomizeBP
            // 
            this.B_RandomizeBP.Location = new System.Drawing.Point(545, 527);
            this.B_RandomizeBP.Margin = new System.Windows.Forms.Padding(5);
            this.B_RandomizeBP.Name = "B_RandomizeBP";
            this.B_RandomizeBP.Size = new System.Drawing.Size(145, 37);
            this.B_RandomizeBP.TabIndex = 9;
            this.B_RandomizeBP.Text = "随机化";
            this.B_RandomizeBP.UseVisualStyleBackColor = true;
            this.B_RandomizeBP.Click += new System.EventHandler(this.B_RandomizeBP_Click);
            // 
            // dgvbp
            // 
            this.dgvbp.AllowUserToAddRows = false;
            this.dgvbp.AllowUserToDeleteRows = false;
            this.dgvbp.AllowUserToResizeColumns = false;
            this.dgvbp.AllowUserToResizeRows = false;
            this.dgvbp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvbp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgvIndexBP,
            this.dgvItemBP,
            this.dgvPriceBP});
            this.dgvbp.Location = new System.Drawing.Point(545, 52);
            this.dgvbp.Margin = new System.Windows.Forms.Padding(5);
            this.dgvbp.Name = "dgvbp";
            this.dgvbp.Size = new System.Drawing.Size(500, 458);
            this.dgvbp.TabIndex = 10;
            // 
            // dgvIndexBP
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgvIndexBP.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvIndexBP.HeaderText = "Index";
            this.dgvIndexBP.MaxInputLength = 3;
            this.dgvIndexBP.Name = "dgvIndexBP";
            this.dgvIndexBP.ReadOnly = true;
            this.dgvIndexBP.Width = 45;
            // 
            // dgvItemBP
            // 
            this.dgvItemBP.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgvItemBP.HeaderText = "Item";
            this.dgvItemBP.Name = "dgvItemBP";
            this.dgvItemBP.Width = 135;
            // 
            // dgvPriceBP
            // 
            this.dgvPriceBP.HeaderText = "Price";
            this.dgvPriceBP.MaxInputLength = 3;
            this.dgvPriceBP.Name = "dgvPriceBP";
            this.dgvPriceBP.Width = 65;
            // 
            // CHK_XItems
            // 
            this.CHK_XItems.AutoSize = true;
            this.CHK_XItems.Checked = true;
            this.CHK_XItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_XItems.Location = new System.Drawing.Point(177, 534);
            this.CHK_XItems.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_XItems.Name = "CHK_XItems";
            this.CHK_XItems.Size = new System.Drawing.Size(237, 25);
            this.CHK_XItems.TabIndex = 304;
            this.CHK_XItems.Text = "不要随机强化道具（速通用）";
            this.CHK_XItems.UseVisualStyleBackColor = true;
            // 
            // MartEditor7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 583);
            this.Controls.Add(this.CHK_XItems);
            this.Controls.Add(this.dgvbp);
            this.Controls.Add(this.B_RandomizeBP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CB_LocationBP);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.B_Randomize);
            this.Controls.Add(this.L_Mart);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.CB_Location);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(556, 622);
            this.Name = "MartEditor7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "友好商店编辑器";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvbp)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Location;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Label L_Mart;
        private System.Windows.Forms.Button B_Randomize;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CB_LocationBP;
        private System.Windows.Forms.Button B_RandomizeBP;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIndex;
        private System.Windows.Forms.DataGridView dgvbp;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvIndexBP;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgvItemBP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgvPriceBP;
        private System.Windows.Forms.CheckBox CHK_XItems;
    }
}