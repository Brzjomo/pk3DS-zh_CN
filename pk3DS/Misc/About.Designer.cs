﻿namespace pk3DS.WinForms
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.B_Close = new System.Windows.Forms.Button();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.L_Thanks = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // B_Close
            // 
            this.B_Close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Close.Location = new System.Drawing.Point(687, 550);
            this.B_Close.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_Close.Name = "B_Close";
            this.B_Close.Size = new System.Drawing.Size(125, 37);
            this.B_Close.TabIndex = 0;
            this.B_Close.Text = "关闭";
            this.B_Close.UseVisualStyleBackColor = true;
            this.B_Close.Click += new System.EventHandler(this.B_Close_Click);
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(12, 14);
            this.RTB.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.RTB.Name = "RTB";
            this.RTB.ReadOnly = true;
            this.RTB.Size = new System.Drawing.Size(797, 518);
            this.RTB.TabIndex = 1;
            this.RTB.Text = "";
            this.RTB.WordWrap = false;
            // 
            // L_Thanks
            // 
            this.L_Thanks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.L_Thanks.AutoSize = true;
            this.L_Thanks.Location = new System.Drawing.Point(20, 556);
            this.L_Thanks.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Thanks.Name = "L_Thanks";
            this.L_Thanks.Size = new System.Drawing.Size(233, 21);
            this.L_Thanks.TabIndex = 2;
            this.L_Thanks.Text = "感谢所有研究者！";
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 600);
            this.Controls.Add(this.L_Thanks);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.B_Close);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1506, 1122);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(839, 637);
            this.Name = "About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "关于";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button B_Close;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Label L_Thanks;
    }
}