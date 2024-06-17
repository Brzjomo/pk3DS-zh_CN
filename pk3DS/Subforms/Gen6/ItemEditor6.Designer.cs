namespace pk3DS
{
    partial class ItemEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemEditor6));
            this.Grid = new System.Windows.Forms.PropertyGrid();
            this.L_Index = new System.Windows.Forms.Label();
            this.RTB = new System.Windows.Forms.RichTextBox();
            this.L_Item = new System.Windows.Forms.Label();
            this.CB_Item = new System.Windows.Forms.ComboBox();
            this.B_Table = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Grid
            // 
            this.Grid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Grid.LineColor = System.Drawing.SystemColors.ControlDark;
            this.Grid.Location = new System.Drawing.Point(20, 173);
            this.Grid.Margin = new System.Windows.Forms.Padding(5);
            this.Grid.Name = "Grid";
            this.Grid.Size = new System.Drawing.Size(527, 452);
            this.Grid.TabIndex = 52;
            // 
            // L_Index
            // 
            this.L_Index.AutoSize = true;
            this.L_Index.Location = new System.Drawing.Point(370, 21);
            this.L_Index.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Index.Name = "L_Index";
            this.L_Index.Size = new System.Drawing.Size(51, 21);
            this.L_Index.TabIndex = 51;
            this.L_Index.Text = "序号: ";
            // 
            // RTB
            // 
            this.RTB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB.Location = new System.Drawing.Point(20, 56);
            this.RTB.Margin = new System.Windows.Forms.Padding(5);
            this.RTB.Name = "RTB";
            this.RTB.ReadOnly = true;
            this.RTB.Size = new System.Drawing.Size(527, 107);
            this.RTB.TabIndex = 50;
            this.RTB.Text = "";
            // 
            // L_Item
            // 
            this.L_Item.Location = new System.Drawing.Point(24, 19);
            this.L_Item.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Item.Name = "L_Item";
            this.L_Item.Size = new System.Drawing.Size(50, 24);
            this.L_Item.TabIndex = 49;
            this.L_Item.Text = "物品:";
            this.L_Item.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Item
            // 
            this.CB_Item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CB_Item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Item.DropDownWidth = 120;
            this.CB_Item.FormattingEnabled = true;
            this.CB_Item.Location = new System.Drawing.Point(77, 17);
            this.CB_Item.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Item.Name = "CB_Item";
            this.CB_Item.Size = new System.Drawing.Size(280, 29);
            this.CB_Item.TabIndex = 48;
            this.CB_Item.SelectedIndexChanged += new System.EventHandler(this.ChangeEntry);
            // 
            // B_Table
            // 
            this.B_Table.Location = new System.Drawing.Point(417, 162);
            this.B_Table.Margin = new System.Windows.Forms.Padding(5);
            this.B_Table.Name = "B_Table";
            this.B_Table.Size = new System.Drawing.Size(125, 37);
            this.B_Table.TabIndex = 53;
            this.B_Table.Text = "导出";
            this.B_Table.UseVisualStyleBackColor = true;
            this.B_Table.Click += new System.EventHandler(this.B_Table_Click);
            // 
            // ItemEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 637);
            this.Controls.Add(this.B_Table);
            this.Controls.Add(this.Grid);
            this.Controls.Add(this.L_Index);
            this.Controls.Add(this.RTB);
            this.Controls.Add(this.L_Item);
            this.Controls.Add(this.CB_Item);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(581, 1591);
            this.MinimumSize = new System.Drawing.Size(581, 655);
            this.Name = "ItemEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Item Editor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.IsFormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PropertyGrid Grid;
        private System.Windows.Forms.Label L_Index;
        private System.Windows.Forms.RichTextBox RTB;
        private System.Windows.Forms.Label L_Item;
        private System.Windows.Forms.ComboBox CB_Item;
        private System.Windows.Forms.Button B_Table;
    }
}