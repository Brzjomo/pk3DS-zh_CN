namespace pk3DS.WinForms
{
    partial class Shuffler
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Shuffler));
            this.CB_a = new System.Windows.Forms.ComboBox();
            this.CB_b = new System.Windows.Forms.ComboBox();
            this.CB_c = new System.Windows.Forms.ComboBox();
            this.L_a = new System.Windows.Forms.Label();
            this.L_File = new System.Windows.Forms.Label();
            this.B_Shuffle = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CB_a
            // 
            this.CB_a.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_a.FormattingEnabled = true;
            this.CB_a.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3"});
            this.CB_a.Location = new System.Drawing.Point(60, 18);
            this.CB_a.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CB_a.Name = "CB_a";
            this.CB_a.Size = new System.Drawing.Size(54, 29);
            this.CB_a.TabIndex = 0;
            this.CB_a.SelectedIndexChanged += new System.EventHandler(this.UpdateLabel);
            // 
            // CB_b
            // 
            this.CB_b.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_b.FormattingEnabled = true;
            this.CB_b.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.CB_b.Location = new System.Drawing.Point(127, 18);
            this.CB_b.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CB_b.Name = "CB_b";
            this.CB_b.Size = new System.Drawing.Size(54, 29);
            this.CB_b.TabIndex = 1;
            this.CB_b.SelectedIndexChanged += new System.EventHandler(this.UpdateLabel);
            // 
            // CB_c
            // 
            this.CB_c.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_c.FormattingEnabled = true;
            this.CB_c.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.CB_c.Location = new System.Drawing.Point(193, 18);
            this.CB_c.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.CB_c.Name = "CB_c";
            this.CB_c.Size = new System.Drawing.Size(54, 29);
            this.CB_c.TabIndex = 2;
            this.CB_c.SelectedIndexChanged += new System.EventHandler(this.UpdateLabel);
            // 
            // L_a
            // 
            this.L_a.Location = new System.Drawing.Point(20, 14);
            this.L_a.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_a.Name = "L_a";
            this.L_a.Size = new System.Drawing.Size(30, 37);
            this.L_a.TabIndex = 3;
            this.L_a.Text = "a";
            this.L_a.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_File
            // 
            this.L_File.Location = new System.Drawing.Point(25, 56);
            this.L_File.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_File.Name = "L_File";
            this.L_File.Size = new System.Drawing.Size(225, 37);
            this.L_File.TabIndex = 4;
            this.L_File.Text = "FILENAME HERE";
            this.L_File.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // B_Shuffle
            // 
            this.B_Shuffle.Location = new System.Drawing.Point(127, 108);
            this.B_Shuffle.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.B_Shuffle.Name = "B_Shuffle";
            this.B_Shuffle.Size = new System.Drawing.Size(125, 37);
            this.B_Shuffle.TabIndex = 5;
            this.B_Shuffle.Text = "Shuffle!";
            this.B_Shuffle.UseVisualStyleBackColor = true;
            this.B_Shuffle.Click += new System.EventHandler(this.B_Shuffle_Click);
            // 
            // Shuffler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 163);
            this.Controls.Add(this.B_Shuffle);
            this.Controls.Add(this.L_File);
            this.Controls.Add(this.L_a);
            this.Controls.Add(this.CB_c);
            this.Controls.Add(this.CB_b);
            this.Controls.Add(this.CB_a);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(289, 202);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(289, 202);
            this.Name = "Shuffler";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Shuffler";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_a;
        private System.Windows.Forms.ComboBox CB_b;
        private System.Windows.Forms.ComboBox CB_c;
        private System.Windows.Forms.Label L_a;
        private System.Windows.Forms.Label L_File;
        private System.Windows.Forms.Button B_Shuffle;
    }
}