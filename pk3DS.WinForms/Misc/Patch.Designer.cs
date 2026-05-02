namespace pk3DS.WinForms
{
    partial class Patch
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Patch));
            CHKLB_GARCs = new System.Windows.Forms.CheckedListBox();
            B_PatchCIA = new System.Windows.Forms.Button();
            B_CheckAll = new System.Windows.Forms.Button();
            B_CheckNone = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // CHKLB_GARCs
            // 
            CHKLB_GARCs.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            CHKLB_GARCs.FormattingEnabled = true;
            CHKLB_GARCs.Location = new System.Drawing.Point(20, 19);
            CHKLB_GARCs.Margin = new System.Windows.Forms.Padding(5);
            CHKLB_GARCs.Name = "CHKLB_GARCs";
            CHKLB_GARCs.Size = new System.Drawing.Size(433, 340);
            CHKLB_GARCs.TabIndex = 0;
            // 
            // B_PatchCIA
            // 
            B_PatchCIA.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            B_PatchCIA.Location = new System.Drawing.Point(280, 380);
            B_PatchCIA.Margin = new System.Windows.Forms.Padding(5);
            B_PatchCIA.Name = "B_PatchCIA";
            B_PatchCIA.Size = new System.Drawing.Size(173, 37);
            B_PatchCIA.TabIndex = 3;
            B_PatchCIA.Text = "导出补丁";
            B_PatchCIA.UseVisualStyleBackColor = true;
            B_PatchCIA.Click += B_PatchCIA_Click;
            // 
            // B_CheckAll
            // 
            B_CheckAll.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_CheckAll.Location = new System.Drawing.Point(20, 380);
            B_CheckAll.Margin = new System.Windows.Forms.Padding(5);
            B_CheckAll.Name = "B_CheckAll";
            B_CheckAll.Size = new System.Drawing.Size(125, 37);
            B_CheckAll.TabIndex = 7;
            B_CheckAll.Text = "全部选中";
            B_CheckAll.UseVisualStyleBackColor = true;
            B_CheckAll.Click += B_CheckAll_Click;
            // 
            // B_CheckNone
            // 
            B_CheckNone.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            B_CheckNone.Location = new System.Drawing.Point(146, 380);
            B_CheckNone.Margin = new System.Windows.Forms.Padding(5);
            B_CheckNone.Name = "B_CheckNone";
            B_CheckNone.Size = new System.Drawing.Size(125, 37);
            B_CheckNone.TabIndex = 8;
            B_CheckNone.Text = "全部不选中";
            B_CheckNone.UseVisualStyleBackColor = true;
            B_CheckNone.Click += B_CheckNone_Click;
            // 
            // Patch
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(473, 440);
            Controls.Add(B_CheckNone);
            Controls.Add(B_CheckAll);
            Controls.Add(B_PatchCIA);
            Controls.Add(CHKLB_GARCs);
            Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Patch";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "补丁导出";
            ResumeLayout(false);
        }

        private System.Windows.Forms.CheckedListBox CHKLB_GARCs;
        private System.Windows.Forms.Button B_PatchCIA;
        private System.Windows.Forms.Button B_CheckAll;
        private System.Windows.Forms.Button B_CheckNone;
    }
}
