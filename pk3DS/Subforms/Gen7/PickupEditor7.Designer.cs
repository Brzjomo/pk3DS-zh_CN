namespace pk3DS
{
    partial class PickupEditor7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PickupEditor7));
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Randomize = new System.Windows.Forms.Button();
            this.dgvCommon = new System.Windows.Forms.DataGridView();
            this.B_AddRow = new System.Windows.Forms.Button();
            this.B_DeleteRow = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(835, 536);
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
            this.B_Cancel.Location = new System.Drawing.Point(700, 536);
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
            // dgvCommon
            // 
            this.dgvCommon.AllowUserToResizeColumns = false;
            this.dgvCommon.AllowUserToResizeRows = false;
            this.dgvCommon.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCommon.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvCommon.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvCommon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCommon.Location = new System.Drawing.Point(20, 19);
            this.dgvCommon.Margin = new System.Windows.Forms.Padding(5);
            this.dgvCommon.Name = "dgvCommon";
            this.dgvCommon.RowHeadersWidth = 30;
            this.dgvCommon.Size = new System.Drawing.Size(933, 485);
            this.dgvCommon.TabIndex = 10;
            // 
            // B_AddRow
            // 
            this.B_AddRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_AddRow.Location = new System.Drawing.Point(150, 536);
            this.B_AddRow.Margin = new System.Windows.Forms.Padding(5);
            this.B_AddRow.Name = "B_AddRow";
            this.B_AddRow.Size = new System.Drawing.Size(125, 37);
            this.B_AddRow.TabIndex = 11;
            this.B_AddRow.Text = "新增行";
            this.B_AddRow.UseVisualStyleBackColor = true;
            this.B_AddRow.Click += new System.EventHandler(this.B_AddRow_Click);
            // 
            // B_DeleteRow
            // 
            this.B_DeleteRow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_DeleteRow.Location = new System.Drawing.Point(285, 536);
            this.B_DeleteRow.Margin = new System.Windows.Forms.Padding(5);
            this.B_DeleteRow.Name = "B_DeleteRow";
            this.B_DeleteRow.Size = new System.Drawing.Size(125, 37);
            this.B_DeleteRow.TabIndex = 12;
            this.B_DeleteRow.Text = "删除行";
            this.B_DeleteRow.UseVisualStyleBackColor = true;
            this.B_DeleteRow.Click += new System.EventHandler(this.B_DeleteRow_Click);
            // 
            // PickupEditor7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 583);
            this.Controls.Add(this.B_DeleteRow);
            this.Controls.Add(this.B_AddRow);
            this.Controls.Add(this.dgvCommon);
            this.Controls.Add(this.B_Randomize);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(989, 622);
            this.Name = "PickupEditor7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "捡拾编辑器";
            ((System.ComponentModel.ISupportInitialize)(this.dgvCommon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Randomize;
        private System.Windows.Forms.DataGridView dgvCommon;
        private System.Windows.Forms.Button B_AddRow;
        private System.Windows.Forms.Button B_DeleteRow;
    }
}