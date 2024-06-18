namespace pk3DS
{
    partial class EggMoveEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EggMoveEditor6));
            this.dgv = new System.Windows.Forms.DataGridView();
            this.CB_Species = new System.Windows.Forms.ComboBox();
            this.L_Species = new System.Windows.Forms.Label();
            this.B_RandAll = new System.Windows.Forms.Button();
            this.B_Dump = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.L_Moves = new System.Windows.Forms.Label();
            this.NUD_Moves = new System.Windows.Forms.NumericUpDown();
            this.CHK_Expand = new System.Windows.Forms.CheckBox();
            this.L_STAB = new System.Windows.Forms.Label();
            this.NUD_STAB = new System.Windows.Forms.NumericUpDown();
            this.CHK_STAB = new System.Windows.Forms.CheckBox();
            this.CHK_HMs = new System.Windows.Forms.CheckBox();
            this.PB_MonSprite = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Moves)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_STAB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MonSprite)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(14, 66);
            this.dgv.Margin = new System.Windows.Forms.Padding(5);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(290, 412);
            this.dgv.TabIndex = 0;
            // 
            // CB_Species
            // 
            this.CB_Species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Species.FormattingEnabled = true;
            this.CB_Species.Location = new System.Drawing.Point(87, 19);
            this.CB_Species.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Species.Name = "CB_Species";
            this.CB_Species.Size = new System.Drawing.Size(217, 29);
            this.CB_Species.TabIndex = 1;
            this.CB_Species.SelectedIndexChanged += new System.EventHandler(this.ChangeEntry);
            // 
            // L_Species
            // 
            this.L_Species.AutoSize = true;
            this.L_Species.Location = new System.Drawing.Point(15, 23);
            this.L_Species.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(62, 21);
            this.L_Species.TabIndex = 2;
            this.L_Species.Text = "宝可梦:";
            // 
            // B_RandAll
            // 
            this.B_RandAll.Location = new System.Drawing.Point(313, 375);
            this.B_RandAll.Margin = new System.Windows.Forms.Padding(5);
            this.B_RandAll.Name = "B_RandAll";
            this.B_RandAll.Size = new System.Drawing.Size(159, 104);
            this.B_RandAll.TabIndex = 4;
            this.B_RandAll.Text = "随机化";
            this.B_RandAll.UseVisualStyleBackColor = true;
            this.B_RandAll.Click += new System.EventHandler(this.B_RandAll_Click);
            // 
            // B_Dump
            // 
            this.B_Dump.Location = new System.Drawing.Point(314, 76);
            this.B_Dump.Margin = new System.Windows.Forms.Padding(5);
            this.B_Dump.Name = "B_Dump";
            this.B_Dump.Size = new System.Drawing.Size(158, 67);
            this.B_Dump.TabIndex = 5;
            this.B_Dump.Text = "导出至TXT文件";
            this.B_Dump.UseVisualStyleBackColor = true;
            this.B_Dump.Click += new System.EventHandler(this.B_Dump_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.L_Moves);
            this.groupBox1.Controls.Add(this.NUD_Moves);
            this.groupBox1.Controls.Add(this.CHK_Expand);
            this.groupBox1.Controls.Add(this.L_STAB);
            this.groupBox1.Controls.Add(this.NUD_STAB);
            this.groupBox1.Controls.Add(this.CHK_STAB);
            this.groupBox1.Controls.Add(this.CHK_HMs);
            this.groupBox1.Location = new System.Drawing.Point(314, 153);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(158, 212);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选项";
            // 
            // L_Moves
            // 
            this.L_Moves.AutoSize = true;
            this.L_Moves.Location = new System.Drawing.Point(39, 174);
            this.L_Moves.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Moves.Name = "L_Moves";
            this.L_Moves.Size = new System.Drawing.Size(46, 21);
            this.L_Moves.TabIndex = 10;
            this.L_Moves.Text = "招式:";
            // 
            // NUD_Moves
            // 
            this.NUD_Moves.Location = new System.Drawing.Point(88, 170);
            this.NUD_Moves.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_Moves.Maximum = new decimal(new int[] {
            30,
            0,
            0,
            0});
            this.NUD_Moves.Name = "NUD_Moves";
            this.NUD_Moves.Size = new System.Drawing.Size(60, 29);
            this.NUD_Moves.TabIndex = 9;
            this.NUD_Moves.Value = new decimal(new int[] {
            18,
            0,
            0,
            0});
            // 
            // CHK_Expand
            // 
            this.CHK_Expand.AutoSize = true;
            this.CHK_Expand.Location = new System.Drawing.Point(8, 142);
            this.CHK_Expand.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_Expand.Name = "CHK_Expand";
            this.CHK_Expand.Size = new System.Drawing.Size(93, 25);
            this.CHK_Expand.TabIndex = 8;
            this.CHK_Expand.Text = "指定数目";
            this.CHK_Expand.UseVisualStyleBackColor = true;
            // 
            // L_STAB
            // 
            this.L_STAB.AutoSize = true;
            this.L_STAB.Location = new System.Drawing.Point(17, 101);
            this.L_STAB.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_STAB.Name = "L_STAB";
            this.L_STAB.Size = new System.Drawing.Size(68, 21);
            this.L_STAB.TabIndex = 3;
            this.L_STAB.Text = "% STAB";
            // 
            // NUD_STAB
            // 
            this.NUD_STAB.Location = new System.Drawing.Point(88, 97);
            this.NUD_STAB.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_STAB.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.NUD_STAB.Name = "NUD_STAB";
            this.NUD_STAB.Size = new System.Drawing.Size(60, 29);
            this.NUD_STAB.TabIndex = 2;
            this.NUD_STAB.Value = new decimal(new int[] {
            32,
            0,
            0,
            0});
            // 
            // CHK_STAB
            // 
            this.CHK_STAB.AutoSize = true;
            this.CHK_STAB.Location = new System.Drawing.Point(8, 69);
            this.CHK_STAB.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_STAB.Name = "CHK_STAB";
            this.CHK_STAB.Size = new System.Drawing.Size(93, 25);
            this.CHK_STAB.TabIndex = 1;
            this.CHK_STAB.Text = "类型偏差";
            this.CHK_STAB.UseVisualStyleBackColor = true;
            // 
            // CHK_HMs
            // 
            this.CHK_HMs.AutoSize = true;
            this.CHK_HMs.Location = new System.Drawing.Point(8, 30);
            this.CHK_HMs.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_HMs.Name = "CHK_HMs";
            this.CHK_HMs.Size = new System.Drawing.Size(109, 25);
            this.CHK_HMs.TabIndex = 0;
            this.CHK_HMs.Text = "允许秘传技";
            this.CHK_HMs.UseVisualStyleBackColor = true;
            // 
            // PB_MonSprite
            // 
            this.PB_MonSprite.Location = new System.Drawing.Point(312, 8);
            this.PB_MonSprite.Margin = new System.Windows.Forms.Padding(5);
            this.PB_MonSprite.Name = "PB_MonSprite";
            this.PB_MonSprite.Size = new System.Drawing.Size(75, 58);
            this.PB_MonSprite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_MonSprite.TabIndex = 91;
            this.PB_MonSprite.TabStop = false;
            // 
            // EggMoveEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(483, 490);
            this.Controls.Add(this.PB_MonSprite);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.B_Dump);
            this.Controls.Add(this.B_RandAll);
            this.Controls.Add(this.L_Species);
            this.Controls.Add(this.CB_Species);
            this.Controls.Add(this.dgv);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "EggMoveEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "蛋招式编辑器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Moves)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_STAB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PB_MonSprite)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox CB_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.Button B_RandAll;
        private System.Windows.Forms.Button B_Dump;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label L_Moves;
        private System.Windows.Forms.NumericUpDown NUD_Moves;
        private System.Windows.Forms.CheckBox CHK_Expand;
        private System.Windows.Forms.Label L_STAB;
        private System.Windows.Forms.NumericUpDown NUD_STAB;
        private System.Windows.Forms.CheckBox CHK_STAB;
        private System.Windows.Forms.CheckBox CHK_HMs;
        private System.Windows.Forms.PictureBox PB_MonSprite;
    }
}