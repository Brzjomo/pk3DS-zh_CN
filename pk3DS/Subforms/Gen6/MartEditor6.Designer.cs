﻿namespace pk3DS
{
    partial class MartEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MartEditor6));
            this.CB_Location = new System.Windows.Forms.ComboBox();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.L_Mart = new System.Windows.Forms.Label();
            this.B_Randomize = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.B_Cancel = new System.Windows.Forms.Button();
            this.CHK_XItems = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Location
            // 
            this.CB_Location.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CB_Location.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Location.FormattingEnabled = true;
            this.CB_Location.Location = new System.Drawing.Point(115, 10);
            this.CB_Location.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Location.Name = "CB_Location";
            this.CB_Location.Size = new System.Drawing.Size(402, 29);
            this.CB_Location.TabIndex = 0;
            this.CB_Location.SelectedIndexChanged += new System.EventHandler(this.ChangeIndex);
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AllowUserToResizeColumns = false;
            this.dgv.AllowUserToResizeRows = false;
            this.dgv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(20, 52);
            this.dgv.Margin = new System.Windows.Forms.Padding(5);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(500, 464);
            this.dgv.TabIndex = 1;
            // 
            // L_Mart
            // 
            this.L_Mart.AutoSize = true;
            this.L_Mart.Location = new System.Drawing.Point(20, 14);
            this.L_Mart.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Mart.Name = "L_Mart";
            this.L_Mart.Size = new System.Drawing.Size(79, 21);
            this.L_Mart.TabIndex = 2;
            this.L_Mart.Text = "Location:";
            // 
            // B_Randomize
            // 
            this.B_Randomize.Location = new System.Drawing.Point(20, 532);
            this.B_Randomize.Margin = new System.Windows.Forms.Padding(5);
            this.B_Randomize.Name = "B_Randomize";
            this.B_Randomize.Size = new System.Drawing.Size(145, 37);
            this.B_Randomize.TabIndex = 3;
            this.B_Randomize.Text = "Randomize";
            this.B_Randomize.UseVisualStyleBackColor = true;
            this.B_Randomize.Click += new System.EventHandler(this.B_Randomize_Click);
            // 
            // B_Save
            // 
            this.B_Save.Location = new System.Drawing.Point(407, 532);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(113, 37);
            this.B_Save.TabIndex = 4;
            this.B_Save.Text = "Save";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // B_Cancel
            // 
            this.B_Cancel.Location = new System.Drawing.Point(283, 532);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(113, 37);
            this.B_Cancel.TabIndex = 5;
            this.B_Cancel.Text = "Cancel";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // CHK_XItems
            // 
            this.CHK_XItems.AutoSize = true;
            this.CHK_XItems.Checked = true;
            this.CHK_XItems.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_XItems.Location = new System.Drawing.Point(22, 576);
            this.CHK_XItems.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_XItems.Name = "CHK_XItems";
            this.CHK_XItems.Size = new System.Drawing.Size(311, 25);
            this.CHK_XItems.TabIndex = 304;
            this.CHK_XItems.Text = "Don\'t Randomize X Items (Speedrun)";
            this.CHK_XItems.UseVisualStyleBackColor = true;
            // 
            // MartEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(540, 616);
            this.Controls.Add(this.CHK_XItems);
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
            this.MaximumSize = new System.Drawing.Size(556, 655);
            this.MinimumSize = new System.Drawing.Size(556, 655);
            this.Name = "MartEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mart Editor";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
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
        private System.Windows.Forms.CheckBox CHK_XItems;
    }
}