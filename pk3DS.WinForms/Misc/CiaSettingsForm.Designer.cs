namespace pk3DS.WinForms
{
    partial class CiaSettingsForm
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
            CB_ModifyTitleId = new System.Windows.Forms.CheckBox();
            L_RomTitleId = new System.Windows.Forms.Label();
            RB_AutoGen = new System.Windows.Forms.RadioButton();
            RB_Manual = new System.Windows.Forms.RadioButton();
            TB_Manual = new System.Windows.Forms.TextBox();
            L_ProductCode = new System.Windows.Forms.Label();
            TB_ProductCode = new System.Windows.Forms.TextBox();
            B_Accept = new System.Windows.Forms.Button();
            B_Cancel = new System.Windows.Forms.Button();
            L_MismatchNotice = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // CB_ModifyTitleId
            // 
            CB_ModifyTitleId.AutoSize = true;
            CB_ModifyTitleId.Font = new System.Drawing.Font("微软雅黑", 9F);
            CB_ModifyTitleId.Location = new System.Drawing.Point(16, 48);
            CB_ModifyTitleId.Name = "CB_ModifyTitleId";
            CB_ModifyTitleId.Size = new System.Drawing.Size(96, 21);
            CB_ModifyTitleId.TabIndex = 0;
            CB_ModifyTitleId.Text = "修改 Title ID";
            CB_ModifyTitleId.UseVisualStyleBackColor = true;
            CB_ModifyTitleId.CheckedChanged += CB_ModifyTitleId_CheckedChanged;
            // 
            // L_RomTitleId
            // 
            L_RomTitleId.AutoSize = true;
            L_RomTitleId.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold);
            L_RomTitleId.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            L_RomTitleId.Location = new System.Drawing.Point(14, 15);
            L_RomTitleId.Name = "L_RomTitleId";
            L_RomTitleId.Size = new System.Drawing.Size(221, 17);
            L_RomTitleId.TabIndex = 1;
            L_RomTitleId.Text = "ROM Title ID: 0x0000000000000000";
            // 
            // RB_AutoGen
            // 
            RB_AutoGen.AutoSize = true;
            RB_AutoGen.Checked = true;
            RB_AutoGen.Font = new System.Drawing.Font("微软雅黑", 9F);
            RB_AutoGen.Location = new System.Drawing.Point(36, 80);
            RB_AutoGen.Name = "RB_AutoGen";
            RB_AutoGen.Size = new System.Drawing.Size(151, 21);
            RB_AutoGen.TabIndex = 2;
            RB_AutoGen.TabStop = true;
            RB_AutoGen.Text = "自动生成唯一 ID (推荐)";
            RB_AutoGen.UseVisualStyleBackColor = true;
            RB_AutoGen.CheckedChanged += RB_AutoGen_CheckedChanged;
            // 
            // RB_Manual
            // 
            RB_Manual.AutoSize = true;
            RB_Manual.Font = new System.Drawing.Font("微软雅黑", 9F);
            RB_Manual.Location = new System.Drawing.Point(36, 112);
            RB_Manual.Name = "RB_Manual";
            RB_Manual.Size = new System.Drawing.Size(167, 21);
            RB_Manual.TabIndex = 3;
            RB_Manual.Text = "手动指定 (16 位十六进制):";
            RB_Manual.UseVisualStyleBackColor = true;
            RB_Manual.CheckedChanged += RB_Manual_CheckedChanged;
            //
            // TB_Manual
            //
            TB_Manual.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            TB_Manual.Font = new System.Drawing.Font("Consolas", 10F);
            TB_Manual.Location = new System.Drawing.Point(206, 111);
            TB_Manual.MaxLength = 16;
            TB_Manual.Name = "TB_Manual";
            TB_Manual.Size = new System.Drawing.Size(149, 23);
            TB_Manual.TabIndex = 4;
            // 
            // L_ProductCode
            // 
            L_ProductCode.AutoSize = true;
            L_ProductCode.Font = new System.Drawing.Font("微软雅黑", 9F);
            L_ProductCode.Location = new System.Drawing.Point(110, 145);
            L_ProductCode.Name = "L_ProductCode";
            L_ProductCode.Size = new System.Drawing.Size(91, 17);
            L_ProductCode.TabIndex = 9;
            L_ProductCode.Text = "Product Code:";
            //
            // TB_ProductCode
            //
            TB_ProductCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            TB_ProductCode.Font = new System.Drawing.Font("Consolas", 10F);
            TB_ProductCode.Location = new System.Drawing.Point(206, 142);
            TB_ProductCode.MaxLength = 10;
            TB_ProductCode.Name = "TB_ProductCode";
            TB_ProductCode.Size = new System.Drawing.Size(149, 23);
            TB_ProductCode.TabIndex = 10;
            // 
            // B_Accept
            // 
            B_Accept.Font = new System.Drawing.Font("微软雅黑", 9F);
            B_Accept.Location = new System.Drawing.Point(188, 204);
            B_Accept.Name = "B_Accept";
            B_Accept.Size = new System.Drawing.Size(84, 32);
            B_Accept.TabIndex = 6;
            B_Accept.Text = "确认";
            B_Accept.UseVisualStyleBackColor = true;
            B_Accept.Click += B_Accept_Click;
            // 
            // B_Cancel
            // 
            B_Cancel.Font = new System.Drawing.Font("微软雅黑", 9F);
            B_Cancel.Location = new System.Drawing.Point(280, 204);
            B_Cancel.Name = "B_Cancel";
            B_Cancel.Size = new System.Drawing.Size(84, 32);
            B_Cancel.TabIndex = 7;
            B_Cancel.Text = "取消";
            B_Cancel.UseVisualStyleBackColor = true;
            B_Cancel.Click += B_Cancel_Click;
            // 
            // L_MismatchNotice
            // 
            L_MismatchNotice.AutoSize = true;
            L_MismatchNotice.Font = new System.Drawing.Font("微软雅黑", 8F);
            L_MismatchNotice.ForeColor = System.Drawing.Color.DarkOrange;
            L_MismatchNotice.Location = new System.Drawing.Point(38, 178);
            L_MismatchNotice.Name = "L_MismatchNotice";
            L_MismatchNotice.Size = new System.Drawing.Size(264, 16);
            L_MismatchNotice.TabIndex = 8;
            L_MismatchNotice.Text = "检测到 Title ID 已修改，当前 ID 已填入上方的输入框";
            L_MismatchNotice.Visible = false;
            // 
            // CiaSettingsForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(380, 247);
            Controls.Add(TB_ProductCode);
            Controls.Add(L_ProductCode);
            Controls.Add(L_MismatchNotice);
            Controls.Add(B_Cancel);
            Controls.Add(B_Accept);
            Controls.Add(TB_Manual);
            Controls.Add(RB_Manual);
            Controls.Add(RB_AutoGen);
            Controls.Add(L_RomTitleId);
            Controls.Add(CB_ModifyTitleId);
            Font = new System.Drawing.Font("微软雅黑", 9F);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CiaSettingsForm";
            ShowInTaskbar = false;
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "CIA 构建设置";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.CheckBox CB_ModifyTitleId;
        private System.Windows.Forms.Label L_RomTitleId;
        private System.Windows.Forms.RadioButton RB_AutoGen;
        private System.Windows.Forms.RadioButton RB_Manual;
        private System.Windows.Forms.TextBox TB_Manual;
        private System.Windows.Forms.Label L_ProductCode;
        private System.Windows.Forms.TextBox TB_ProductCode;
        private System.Windows.Forms.Button B_Accept;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Label L_MismatchNotice;
    }
}
