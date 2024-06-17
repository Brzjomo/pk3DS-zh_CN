namespace pk3DS
{
    partial class TextEditor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextEditor));
            this.CB_Entry = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.B_AddLine = new System.Windows.Forms.Button();
            this.B_RemoveLine = new System.Windows.Forms.Button();
            this.B_Export = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.B_Import = new System.Windows.Forms.Button();
            this.B_Randomize = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Entry
            // 
            this.CB_Entry.FormattingEnabled = true;
            this.CB_Entry.Location = new System.Drawing.Point(108, 13);
            this.CB_Entry.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Entry.Name = "CB_Entry";
            this.CB_Entry.Size = new System.Drawing.Size(139, 29);
            this.CB_Entry.TabIndex = 5;
            this.CB_Entry.SelectedIndexChanged += new System.EventHandler(this.ChangeEntry);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(20, 52);
            this.dgv.Margin = new System.Windows.Forms.Padding(5);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersVisible = false;
            this.dgv.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgv.ShowEditingIcon = false;
            this.dgv.Size = new System.Drawing.Size(1017, 513);
            this.dgv.TabIndex = 0;
            // 
            // B_AddLine
            // 
            this.B_AddLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_AddLine.Location = new System.Drawing.Point(728, 10);
            this.B_AddLine.Margin = new System.Windows.Forms.Padding(5);
            this.B_AddLine.Name = "B_AddLine";
            this.B_AddLine.Size = new System.Drawing.Size(150, 37);
            this.B_AddLine.TabIndex = 6;
            this.B_AddLine.Text = "末尾加行";
            this.B_AddLine.UseVisualStyleBackColor = true;
            this.B_AddLine.Click += new System.EventHandler(this.B_AddLine_Click);
            // 
            // B_RemoveLine
            // 
            this.B_RemoveLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.B_RemoveLine.Location = new System.Drawing.Point(888, 10);
            this.B_RemoveLine.Margin = new System.Windows.Forms.Padding(5);
            this.B_RemoveLine.Name = "B_RemoveLine";
            this.B_RemoveLine.Size = new System.Drawing.Size(150, 37);
            this.B_RemoveLine.TabIndex = 7;
            this.B_RemoveLine.Text = "移除行";
            this.B_RemoveLine.UseVisualStyleBackColor = true;
            this.B_RemoveLine.Click += new System.EventHandler(this.B_RemoveLine_Click);
            // 
            // B_Export
            // 
            this.B_Export.Location = new System.Drawing.Point(257, 10);
            this.B_Export.Margin = new System.Windows.Forms.Padding(5);
            this.B_Export.Name = "B_Export";
            this.B_Export.Size = new System.Drawing.Size(150, 37);
            this.B_Export.TabIndex = 8;
            this.B_Export.Text = "全部导出 (.txt)";
            this.B_Export.UseVisualStyleBackColor = true;
            this.B_Export.Click += new System.EventHandler(this.B_Export_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 16);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 21);
            this.label1.TabIndex = 9;
            this.label1.Text = "文本文件:";
            // 
            // B_Import
            // 
            this.B_Import.Location = new System.Drawing.Point(417, 10);
            this.B_Import.Margin = new System.Windows.Forms.Padding(5);
            this.B_Import.Name = "B_Import";
            this.B_Import.Size = new System.Drawing.Size(150, 37);
            this.B_Import.TabIndex = 10;
            this.B_Import.Text = "全部导入 (.txt)";
            this.B_Import.UseVisualStyleBackColor = true;
            this.B_Import.Click += new System.EventHandler(this.B_Import_Click);
            // 
            // B_Randomize
            // 
            this.B_Randomize.Location = new System.Drawing.Point(577, 10);
            this.B_Randomize.Margin = new System.Windows.Forms.Padding(5);
            this.B_Randomize.Name = "B_Randomize";
            this.B_Randomize.Size = new System.Drawing.Size(117, 37);
            this.B_Randomize.TabIndex = 11;
            this.B_Randomize.Text = "随机化";
            this.B_Randomize.UseVisualStyleBackColor = true;
            this.B_Randomize.Click += new System.EventHandler(this.B_Randomize_Click);
            // 
            // TextEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1057, 584);
            this.Controls.Add(this.B_Randomize);
            this.Controls.Add(this.B_Import);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.B_Export);
            this.Controls.Add(this.B_RemoveLine);
            this.Controls.Add(this.B_AddLine);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.CB_Entry);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(656, 461);
            this.Name = "TextEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "文本编辑器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TextEditor_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Entry;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button B_AddLine;
        private System.Windows.Forms.Button B_RemoveLine;
        private System.Windows.Forms.Button B_Export;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_Import;
        private System.Windows.Forms.Button B_Randomize;
    }
}
