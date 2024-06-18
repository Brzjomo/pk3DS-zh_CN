namespace pk3DS.WinForms
{
    partial class TypeChart7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TypeChart7));
            this.PB_Chart = new System.Windows.Forms.PictureBox();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.L_Hover = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PB_Chart)).BeginInit();
            this.SuspendLayout();
            // 
            // PB_Chart
            // 
            this.PB_Chart.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PB_Chart.Location = new System.Drawing.Point(14, 14);
            this.PB_Chart.Margin = new System.Windows.Forms.Padding(5);
            this.PB_Chart.Name = "PB_Chart";
            this.PB_Chart.Size = new System.Drawing.Size(580, 580);
            this.PB_Chart.TabIndex = 0;
            this.PB_Chart.TabStop = false;
            this.PB_Chart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ClickMouse);
            this.PB_Chart.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MoveMouse);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(334, 630);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(125, 37);
            this.B_Cancel.TabIndex = 467;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(469, 630);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(125, 37);
            this.B_Save.TabIndex = 466;
            this.B_Save.Text = "保存";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // L_Hover
            // 
            this.L_Hover.AutoSize = true;
            this.L_Hover.Location = new System.Drawing.Point(14, 599);
            this.L_Hover.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Hover.Name = "L_Hover";
            this.L_Hover.Size = new System.Drawing.Size(185, 21);
            this.L_Hover.TabIndex = 468;
            this.L_Hover.Text = "效果总览";
            // 
            // TypeChart7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 681);
            this.Controls.Add(this.L_Hover);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Controls.Add(this.PB_Chart);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(581, 331);
            this.Name = "TypeChart7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "属性克制编辑器";
            ((System.ComponentModel.ISupportInitialize)(this.PB_Chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox PB_Chart;
        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.Label L_Hover;

    }
}