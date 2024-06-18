namespace pk3DS
{
    partial class OWSE7
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OWSE7));
            this.L_Location = new System.Windows.Forms.Label();
            this.CB_LocationID = new System.Windows.Forms.ComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tab_7_ZS = new System.Windows.Forms.TabPage();
            this.L_7_Info = new System.Windows.Forms.Label();
            this.RTB_7_Parse = new System.Windows.Forms.RichTextBox();
            this.NUD_7_Count = new System.Windows.Forms.NumericUpDown();
            this.L_7_Count = new System.Windows.Forms.Label();
            this.RTB_7_Script = new System.Windows.Forms.RichTextBox();
            this.RTB_7_Raw = new System.Windows.Forms.RichTextBox();
            this.tab_8_ZI = new System.Windows.Forms.TabPage();
            this.L_8_Info = new System.Windows.Forms.Label();
            this.RTB_8_Parse = new System.Windows.Forms.RichTextBox();
            this.NUD_8_Count = new System.Windows.Forms.NumericUpDown();
            this.L_8_Count = new System.Windows.Forms.Label();
            this.RTB_8_Script = new System.Windows.Forms.RichTextBox();
            this.RTB_8_Raw = new System.Windows.Forms.RichTextBox();
            this.tabControl1.SuspendLayout();
            this.tab_7_ZS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_7_Count)).BeginInit();
            this.tab_8_ZI.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_8_Count)).BeginInit();
            this.SuspendLayout();
            // 
            // L_Location
            // 
            this.L_Location.AutoSize = true;
            this.L_Location.Location = new System.Drawing.Point(20, 14);
            this.L_Location.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Location.Name = "L_Location";
            this.L_Location.Size = new System.Drawing.Size(40, 21);
            this.L_Location.TabIndex = 433;
            this.L_Location.Text = "Loc:";
            // 
            // CB_LocationID
            // 
            this.CB_LocationID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_LocationID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_LocationID.FormattingEnabled = true;
            this.CB_LocationID.Location = new System.Drawing.Point(77, 10);
            this.CB_LocationID.Margin = new System.Windows.Forms.Padding(5);
            this.CB_LocationID.Name = "CB_LocationID";
            this.CB_LocationID.Size = new System.Drawing.Size(271, 29);
            this.CB_LocationID.TabIndex = 432;
            this.CB_LocationID.SelectedIndexChanged += new System.EventHandler(this.CB_LocationID_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tab_7_ZS);
            this.tabControl1.Controls.Add(this.tab_8_ZI);
            this.tabControl1.Location = new System.Drawing.Point(25, 52);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(767, 752);
            this.tabControl1.TabIndex = 434;
            // 
            // tab_7_ZS
            // 
            this.tab_7_ZS.Controls.Add(this.L_7_Info);
            this.tab_7_ZS.Controls.Add(this.RTB_7_Parse);
            this.tab_7_ZS.Controls.Add(this.NUD_7_Count);
            this.tab_7_ZS.Controls.Add(this.L_7_Count);
            this.tab_7_ZS.Controls.Add(this.RTB_7_Script);
            this.tab_7_ZS.Controls.Add(this.RTB_7_Raw);
            this.tab_7_ZS.Location = new System.Drawing.Point(4, 30);
            this.tab_7_ZS.Margin = new System.Windows.Forms.Padding(5);
            this.tab_7_ZS.Name = "tab_7_ZS";
            this.tab_7_ZS.Padding = new System.Windows.Forms.Padding(5);
            this.tab_7_ZS.Size = new System.Drawing.Size(759, 718);
            this.tab_7_ZS.TabIndex = 0;
            this.tab_7_ZS.Text = "7.ZS";
            this.tab_7_ZS.UseVisualStyleBackColor = true;
            // 
            // L_7_Info
            // 
            this.L_7_Info.AutoSize = true;
            this.L_7_Info.Location = new System.Drawing.Point(228, 397);
            this.L_7_Info.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_7_Info.Name = "L_7_Info";
            this.L_7_Info.Size = new System.Drawing.Size(66, 21);
            this.L_7_Info.TabIndex = 438;
            this.L_7_Info.Text = "Count7";
            // 
            // RTB_7_Parse
            // 
            this.RTB_7_Parse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_7_Parse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_7_Parse.Location = new System.Drawing.Point(347, 334);
            this.RTB_7_Parse.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_7_Parse.Name = "RTB_7_Parse";
            this.RTB_7_Parse.ReadOnly = true;
            this.RTB_7_Parse.Size = new System.Drawing.Size(394, 353);
            this.RTB_7_Parse.TabIndex = 437;
            this.RTB_7_Parse.Text = "Script CMDs";
            // 
            // NUD_7_Count
            // 
            this.NUD_7_Count.Location = new System.Drawing.Point(233, 360);
            this.NUD_7_Count.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_7_Count.Name = "NUD_7_Count";
            this.NUD_7_Count.Size = new System.Drawing.Size(103, 29);
            this.NUD_7_Count.TabIndex = 436;
            this.NUD_7_Count.ValueChanged += new System.EventHandler(this.NUD_7_Count_ValueChanged);
            // 
            // L_7_Count
            // 
            this.L_7_Count.AutoSize = true;
            this.L_7_Count.Location = new System.Drawing.Point(228, 334);
            this.L_7_Count.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_7_Count.Name = "L_7_Count";
            this.L_7_Count.Size = new System.Drawing.Size(66, 21);
            this.L_7_Count.TabIndex = 435;
            this.L_7_Count.Text = "Count7";
            // 
            // RTB_7_Script
            // 
            this.RTB_7_Script.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RTB_7_Script.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_7_Script.Location = new System.Drawing.Point(10, 334);
            this.RTB_7_Script.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_7_Script.Name = "RTB_7_Script";
            this.RTB_7_Script.ReadOnly = true;
            this.RTB_7_Script.Size = new System.Drawing.Size(206, 353);
            this.RTB_7_Script.TabIndex = 431;
            this.RTB_7_Script.Text = "Script CMDs";
            // 
            // RTB_7_Raw
            // 
            this.RTB_7_Raw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_7_Raw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_7_Raw.Location = new System.Drawing.Point(10, 10);
            this.RTB_7_Raw.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_7_Raw.Name = "RTB_7_Raw";
            this.RTB_7_Raw.ReadOnly = true;
            this.RTB_7_Raw.Size = new System.Drawing.Size(731, 312);
            this.RTB_7_Raw.TabIndex = 430;
            this.RTB_7_Raw.Text = "Raw Data";
            // 
            // tab_8_ZI
            // 
            this.tab_8_ZI.Controls.Add(this.L_8_Info);
            this.tab_8_ZI.Controls.Add(this.RTB_8_Parse);
            this.tab_8_ZI.Controls.Add(this.NUD_8_Count);
            this.tab_8_ZI.Controls.Add(this.L_8_Count);
            this.tab_8_ZI.Controls.Add(this.RTB_8_Script);
            this.tab_8_ZI.Controls.Add(this.RTB_8_Raw);
            this.tab_8_ZI.Location = new System.Drawing.Point(4, 30);
            this.tab_8_ZI.Margin = new System.Windows.Forms.Padding(5);
            this.tab_8_ZI.Name = "tab_8_ZI";
            this.tab_8_ZI.Padding = new System.Windows.Forms.Padding(5);
            this.tab_8_ZI.Size = new System.Drawing.Size(759, 718);
            this.tab_8_ZI.TabIndex = 1;
            this.tab_8_ZI.Text = "8.ZI";
            this.tab_8_ZI.UseVisualStyleBackColor = true;
            // 
            // L_8_Info
            // 
            this.L_8_Info.AutoSize = true;
            this.L_8_Info.Location = new System.Drawing.Point(228, 397);
            this.L_8_Info.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_8_Info.Name = "L_8_Info";
            this.L_8_Info.Size = new System.Drawing.Size(66, 21);
            this.L_8_Info.TabIndex = 439;
            this.L_8_Info.Text = "Count8";
            // 
            // RTB_8_Parse
            // 
            this.RTB_8_Parse.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_8_Parse.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_8_Parse.Location = new System.Drawing.Point(347, 334);
            this.RTB_8_Parse.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_8_Parse.Name = "RTB_8_Parse";
            this.RTB_8_Parse.ReadOnly = true;
            this.RTB_8_Parse.Size = new System.Drawing.Size(394, 353);
            this.RTB_8_Parse.TabIndex = 438;
            this.RTB_8_Parse.Text = "Script CMDs";
            // 
            // NUD_8_Count
            // 
            this.NUD_8_Count.Location = new System.Drawing.Point(233, 360);
            this.NUD_8_Count.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_8_Count.Name = "NUD_8_Count";
            this.NUD_8_Count.Size = new System.Drawing.Size(103, 29);
            this.NUD_8_Count.TabIndex = 435;
            this.NUD_8_Count.ValueChanged += new System.EventHandler(this.NUD_8_Count_ValueChanged);
            // 
            // L_8_Count
            // 
            this.L_8_Count.AutoSize = true;
            this.L_8_Count.Location = new System.Drawing.Point(228, 334);
            this.L_8_Count.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_8_Count.Name = "L_8_Count";
            this.L_8_Count.Size = new System.Drawing.Size(66, 21);
            this.L_8_Count.TabIndex = 434;
            this.L_8_Count.Text = "Count8";
            // 
            // RTB_8_Script
            // 
            this.RTB_8_Script.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.RTB_8_Script.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_8_Script.Location = new System.Drawing.Point(10, 334);
            this.RTB_8_Script.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_8_Script.Name = "RTB_8_Script";
            this.RTB_8_Script.ReadOnly = true;
            this.RTB_8_Script.Size = new System.Drawing.Size(206, 353);
            this.RTB_8_Script.TabIndex = 433;
            this.RTB_8_Script.Text = "Script CMDs";
            // 
            // RTB_8_Raw
            // 
            this.RTB_8_Raw.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.RTB_8_Raw.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RTB_8_Raw.Location = new System.Drawing.Point(10, 10);
            this.RTB_8_Raw.Margin = new System.Windows.Forms.Padding(5);
            this.RTB_8_Raw.Name = "RTB_8_Raw";
            this.RTB_8_Raw.ReadOnly = true;
            this.RTB_8_Raw.Size = new System.Drawing.Size(731, 312);
            this.RTB_8_Raw.TabIndex = 432;
            this.RTB_8_Raw.Text = "Raw Data";
            // 
            // OWSE7
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 826);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.L_Location);
            this.Controls.Add(this.CB_LocationID);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "OWSE7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "OWSE7";
            this.tabControl1.ResumeLayout(false);
            this.tab_7_ZS.ResumeLayout(false);
            this.tab_7_ZS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_7_Count)).EndInit();
            this.tab_8_ZI.ResumeLayout(false);
            this.tab_8_ZI.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_8_Count)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label L_Location;
        private System.Windows.Forms.ComboBox CB_LocationID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tab_7_ZS;
        private System.Windows.Forms.TabPage tab_8_ZI;
        private System.Windows.Forms.RichTextBox RTB_7_Script;
        private System.Windows.Forms.RichTextBox RTB_7_Raw;
        private System.Windows.Forms.RichTextBox RTB_8_Script;
        private System.Windows.Forms.RichTextBox RTB_8_Raw;
        private System.Windows.Forms.Label L_8_Count;
        private System.Windows.Forms.Label L_7_Count;
        private System.Windows.Forms.NumericUpDown NUD_8_Count;
        private System.Windows.Forms.NumericUpDown NUD_7_Count;
        private System.Windows.Forms.RichTextBox RTB_7_Parse;
        private System.Windows.Forms.RichTextBox RTB_8_Parse;
        private System.Windows.Forms.Label L_7_Info;
        private System.Windows.Forms.Label L_8_Info;
    }
}