namespace pk3DS.WinForms
{
    partial class Patch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patch));
            this.CHKLB_GARCs = new System.Windows.Forms.CheckedListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.B_PatchCIA = new System.Windows.Forms.Button();
            this.CHK_Lang = new System.Windows.Forms.CheckBox();
            this.RTB_GARCs = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.B_CheckAll = new System.Windows.Forms.Button();
            this.B_CheckNone = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CHKLB_GARCs
            // 
            this.CHKLB_GARCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.CHKLB_GARCs.FormattingEnabled = true;
            this.CHKLB_GARCs.Location = new System.Drawing.Point(20, 19);
            this.CHKLB_GARCs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CHKLB_GARCs.Name = "CHKLB_GARCs";
            this.CHKLB_GARCs.Size = new System.Drawing.Size(247, 412);
            this.CHKLB_GARCs.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(280, 46);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(171, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "a/#/* -> a#/*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(280, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "ExeFS 路径覆盖:";
            // 
            // B_PatchCIA
            // 
            this.B_PatchCIA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_PatchCIA.Location = new System.Drawing.Point(280, 450);
            this.B_PatchCIA.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_PatchCIA.Name = "B_PatchCIA";
            this.B_PatchCIA.Size = new System.Drawing.Size(173, 37);
            this.B_PatchCIA.TabIndex = 3;
            this.B_PatchCIA.Text = "重定向[CIA]";
            this.B_PatchCIA.UseVisualStyleBackColor = true;
            this.B_PatchCIA.Click += new System.EventHandler(this.B_PatchCIA_Click);
            // 
            // CHK_Lang
            // 
            this.CHK_Lang.AutoSize = true;
            this.CHK_Lang.Location = new System.Drawing.Point(285, 88);
            this.CHK_Lang.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CHK_Lang.Name = "CHK_Lang";
            this.CHK_Lang.Size = new System.Drawing.Size(159, 25);
            this.CHK_Lang.TabIndex = 4;
            this.CHK_Lang.Text = "修补语言";
            this.CHK_Lang.UseVisualStyleBackColor = true;
            // 
            // RTB_GARCs
            // 
            this.RTB_GARCs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RTB_GARCs.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RTB_GARCs.Location = new System.Drawing.Point(280, 145);
            this.RTB_GARCs.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RTB_GARCs.Name = "RTB_GARCs";
            this.RTB_GARCs.Size = new System.Drawing.Size(122, 289);
            this.RTB_GARCs.TabIndex = 5;
            this.RTB_GARCs.Text = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(275, 119);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "额外GARCs:";
            // 
            // B_CheckAll
            // 
            this.B_CheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_CheckAll.Location = new System.Drawing.Point(20, 450);
            this.B_CheckAll.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_CheckAll.Name = "B_CheckAll";
            this.B_CheckAll.Size = new System.Drawing.Size(125, 37);
            this.B_CheckAll.TabIndex = 7;
            this.B_CheckAll.Text = "检查全部";
            this.B_CheckAll.UseVisualStyleBackColor = true;
            this.B_CheckAll.Click += new System.EventHandler(this.B_CheckAll_Click);
            // 
            // B_CheckNone
            // 
            this.B_CheckNone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_CheckNone.Location = new System.Drawing.Point(145, 450);
            this.B_CheckNone.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_CheckNone.Name = "B_CheckNone";
            this.B_CheckNone.Size = new System.Drawing.Size(125, 37);
            this.B_CheckNone.TabIndex = 8;
            this.B_CheckNone.Text = "不检查";
            this.B_CheckNone.UseVisualStyleBackColor = true;
            this.B_CheckNone.Click += new System.EventHandler(this.B_CheckNone_Click);
            // 
            // Patch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 504);
            this.Controls.Add(this.B_CheckNone);
            this.Controls.Add(this.B_CheckAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.RTB_GARCs);
            this.Controls.Add(this.CHK_Lang);
            this.Controls.Add(this.B_PatchCIA);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.CHKLB_GARCs);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Patch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "补丁管理器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SavePatch);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckedListBox CHKLB_GARCs;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button B_PatchCIA;
        private System.Windows.Forms.CheckBox CHK_Lang;
        private System.Windows.Forms.RichTextBox RTB_GARCs;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button B_CheckAll;
        private System.Windows.Forms.Button B_CheckNone;
    }
}