namespace pk3DS
{
    partial class ErrorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorWindow));
            this.B_Continue = new System.Windows.Forms.Button();
            this.B_Abort = new System.Windows.Forms.Button();
            this.B_CopyToClipboard = new System.Windows.Forms.Button();
            this.L_ProvideInfo = new System.Windows.Forms.Label();
            this.L_Message = new System.Windows.Forms.Label();
            this.T_ExceptionDetails = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // B_Continue
            // 
            this.B_Continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Continue.Location = new System.Drawing.Point(553, 327);
            this.B_Continue.Margin = new System.Windows.Forms.Padding(5);
            this.B_Continue.Name = "B_Continue";
            this.B_Continue.Size = new System.Drawing.Size(125, 37);
            this.B_Continue.TabIndex = 11;
            this.B_Continue.Text = "继续";
            this.B_Continue.UseVisualStyleBackColor = true;
            this.B_Continue.Click += new System.EventHandler(this.B_Continue_Click);
            // 
            // B_Abort
            // 
            this.B_Abort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Abort.Location = new System.Drawing.Point(688, 327);
            this.B_Abort.Margin = new System.Windows.Forms.Padding(5);
            this.B_Abort.Name = "B_Abort";
            this.B_Abort.Size = new System.Drawing.Size(125, 37);
            this.B_Abort.TabIndex = 10;
            this.B_Abort.Text = "终止";
            this.B_Abort.UseVisualStyleBackColor = true;
            this.B_Abort.Click += new System.EventHandler(this.B_Abort_Click);
            // 
            // B_CopyToClipboard
            // 
            this.B_CopyToClipboard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.B_CopyToClipboard.Location = new System.Drawing.Point(22, 327);
            this.B_CopyToClipboard.Margin = new System.Windows.Forms.Padding(5);
            this.B_CopyToClipboard.Name = "B_CopyToClipboard";
            this.B_CopyToClipboard.Size = new System.Drawing.Size(273, 37);
            this.B_CopyToClipboard.TabIndex = 9;
            this.B_CopyToClipboard.Text = "复制到剪贴板";
            this.B_CopyToClipboard.UseVisualStyleBackColor = true;
            this.B_CopyToClipboard.Click += new System.EventHandler(this.B_CopyToClipboard_Click);
            // 
            // L_ProvideInfo
            // 
            this.L_ProvideInfo.AutoSize = true;
            this.L_ProvideInfo.Location = new System.Drawing.Point(17, 61);
            this.L_ProvideInfo.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_ProvideInfo.Name = "L_ProvideInfo";
            this.L_ProvideInfo.Size = new System.Drawing.Size(222, 21);
            this.L_ProvideInfo.TabIndex = 8;
            this.L_ProvideInfo.Text = "报告此错误时请提供以下信息:";
            // 
            // L_Message
            // 
            this.L_Message.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.L_Message.Location = new System.Drawing.Point(17, 18);
            this.L_Message.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Message.Name = "L_Message";
            this.L_Message.Size = new System.Drawing.Size(797, 44);
            this.L_Message.TabIndex = 7;
            this.L_Message.Text = "未知错误";
            // 
            // T_ExceptionDetails
            // 
            this.T_ExceptionDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.T_ExceptionDetails.Location = new System.Drawing.Point(22, 88);
            this.T_ExceptionDetails.Margin = new System.Windows.Forms.Padding(5);
            this.T_ExceptionDetails.Multiline = true;
            this.T_ExceptionDetails.Name = "T_ExceptionDetails";
            this.T_ExceptionDetails.ReadOnly = true;
            this.T_ExceptionDetails.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.T_ExceptionDetails.Size = new System.Drawing.Size(789, 228);
            this.T_ExceptionDetails.TabIndex = 6;
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 382);
            this.Controls.Add(this.B_Continue);
            this.Controls.Add(this.B_Abort);
            this.Controls.Add(this.B_CopyToClipboard);
            this.Controls.Add(this.L_ProvideInfo);
            this.Controls.Add(this.L_Message);
            this.Controls.Add(this.T_ExceptionDetails);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(848, 421);
            this.Name = "ErrorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "错误";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Continue;
        private System.Windows.Forms.Button B_Abort;
        private System.Windows.Forms.Button B_CopyToClipboard;
        private System.Windows.Forms.Label L_ProvideInfo;
        private System.Windows.Forms.Label L_Message;
        private System.Windows.Forms.TextBox T_ExceptionDetails;
    }
}