namespace pk3DS
{
    partial class MaisonEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MaisonEditor6));
            this.CB_Trainer = new System.Windows.Forms.ComboBox();
            this.CB_Pokemon = new System.Windows.Forms.ComboBox();
            this.L_Trainer = new System.Windows.Forms.Label();
            this.L_Pokemon = new System.Windows.Forms.Label();
            this.GB_Trainer = new System.Windows.Forms.GroupBox();
            this.L_Class = new System.Windows.Forms.Label();
            this.B_Remove = new System.Windows.Forms.Button();
            this.B_Set = new System.Windows.Forms.Button();
            this.LB_Choices = new System.Windows.Forms.ListBox();
            this.CB_Class = new System.Windows.Forms.ComboBox();
            this.GB_Pokemon = new System.Windows.Forms.GroupBox();
            this.PB_PKM = new System.Windows.Forms.PictureBox();
            this.CHK_Spe = new System.Windows.Forms.CheckBox();
            this.CHK_SpD = new System.Windows.Forms.CheckBox();
            this.CHK_SpA = new System.Windows.Forms.CheckBox();
            this.CHK_DEF = new System.Windows.Forms.CheckBox();
            this.CHK_ATK = new System.Windows.Forms.CheckBox();
            this.CHK_HP = new System.Windows.Forms.CheckBox();
            this.L_Species = new System.Windows.Forms.Label();
            this.L_Item = new System.Windows.Forms.Label();
            this.L_Nature = new System.Windows.Forms.Label();
            this.L_Moves = new System.Windows.Forms.Label();
            this.CB_Item = new System.Windows.Forms.ComboBox();
            this.CB_Nature = new System.Windows.Forms.ComboBox();
            this.CB_Move4 = new System.Windows.Forms.ComboBox();
            this.CB_Move2 = new System.Windows.Forms.ComboBox();
            this.CB_Move3 = new System.Windows.Forms.ComboBox();
            this.CB_Move1 = new System.Windows.Forms.ComboBox();
            this.CB_Species = new System.Windows.Forms.ComboBox();
            this.B_DumpPKs = new System.Windows.Forms.Button();
            this.DumpTRs = new System.Windows.Forms.Button();
            this.GB_Trainer.SuspendLayout();
            this.GB_Pokemon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PKM)).BeginInit();
            this.SuspendLayout();
            // 
            // CB_Trainer
            // 
            this.CB_Trainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Trainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Trainer.FormattingEnabled = true;
            this.CB_Trainer.Location = new System.Drawing.Point(80, 15);
            this.CB_Trainer.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Trainer.Name = "CB_Trainer";
            this.CB_Trainer.Size = new System.Drawing.Size(200, 29);
            this.CB_Trainer.TabIndex = 0;
            this.CB_Trainer.SelectedIndexChanged += new System.EventHandler(this.ChangeTrainer);
            // 
            // CB_Pokemon
            // 
            this.CB_Pokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Pokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Pokemon.FormattingEnabled = true;
            this.CB_Pokemon.Location = new System.Drawing.Point(514, 13);
            this.CB_Pokemon.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Pokemon.Name = "CB_Pokemon";
            this.CB_Pokemon.Size = new System.Drawing.Size(200, 29);
            this.CB_Pokemon.TabIndex = 1;
            this.CB_Pokemon.SelectedIndexChanged += new System.EventHandler(this.ChangePokemon);
            // 
            // L_Trainer
            // 
            this.L_Trainer.AutoSize = true;
            this.L_Trainer.Location = new System.Drawing.Point(8, 18);
            this.L_Trainer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Trainer.Name = "L_Trainer";
            this.L_Trainer.Size = new System.Drawing.Size(62, 21);
            this.L_Trainer.TabIndex = 2;
            this.L_Trainer.Text = "训练家:";
            // 
            // L_Pokemon
            // 
            this.L_Pokemon.AutoSize = true;
            this.L_Pokemon.Location = new System.Drawing.Point(442, 18);
            this.L_Pokemon.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Pokemon.Name = "L_Pokemon";
            this.L_Pokemon.Size = new System.Drawing.Size(62, 21);
            this.L_Pokemon.TabIndex = 3;
            this.L_Pokemon.Text = "宝可梦:";
            // 
            // GB_Trainer
            // 
            this.GB_Trainer.Controls.Add(this.L_Class);
            this.GB_Trainer.Controls.Add(this.B_Remove);
            this.GB_Trainer.Controls.Add(this.B_Set);
            this.GB_Trainer.Controls.Add(this.LB_Choices);
            this.GB_Trainer.Controls.Add(this.CB_Class);
            this.GB_Trainer.Location = new System.Drawing.Point(12, 52);
            this.GB_Trainer.Margin = new System.Windows.Forms.Padding(5);
            this.GB_Trainer.Name = "GB_Trainer";
            this.GB_Trainer.Padding = new System.Windows.Forms.Padding(5);
            this.GB_Trainer.Size = new System.Drawing.Size(420, 303);
            this.GB_Trainer.TabIndex = 4;
            this.GB_Trainer.TabStop = false;
            this.GB_Trainer.Text = "训练家总览";
            // 
            // L_Class
            // 
            this.L_Class.AutoSize = true;
            this.L_Class.Location = new System.Drawing.Point(23, 37);
            this.L_Class.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Class.Name = "L_Class";
            this.L_Class.Size = new System.Drawing.Size(46, 21);
            this.L_Class.TabIndex = 5;
            this.L_Class.Text = "类型:";
            // 
            // B_Remove
            // 
            this.B_Remove.Location = new System.Drawing.Point(303, 252);
            this.B_Remove.Margin = new System.Windows.Forms.Padding(5);
            this.B_Remove.Name = "B_Remove";
            this.B_Remove.Size = new System.Drawing.Size(103, 37);
            this.B_Remove.TabIndex = 4;
            this.B_Remove.Text = "[X] 删除";
            this.B_Remove.UseVisualStyleBackColor = true;
            this.B_Remove.Click += new System.EventHandler(this.B_Remove_Click);
            // 
            // B_Set
            // 
            this.B_Set.Location = new System.Drawing.Point(303, 75);
            this.B_Set.Margin = new System.Windows.Forms.Padding(5);
            this.B_Set.Name = "B_Set";
            this.B_Set.Size = new System.Drawing.Size(103, 37);
            this.B_Set.TabIndex = 2;
            this.B_Set.Text = "[<] 设置";
            this.B_Set.UseVisualStyleBackColor = true;
            this.B_Set.Click += new System.EventHandler(this.B_Set_Click);
            // 
            // LB_Choices
            // 
            this.LB_Choices.FormattingEnabled = true;
            this.LB_Choices.ItemHeight = 21;
            this.LB_Choices.Location = new System.Drawing.Point(15, 75);
            this.LB_Choices.Margin = new System.Windows.Forms.Padding(5);
            this.LB_Choices.Name = "LB_Choices";
            this.LB_Choices.Size = new System.Drawing.Size(276, 214);
            this.LB_Choices.TabIndex = 1;
            this.LB_Choices.SelectedIndexChanged += new System.EventHandler(this.B_View_Click);
            // 
            // CB_Class
            // 
            this.CB_Class.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Class.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Class.FormattingEnabled = true;
            this.CB_Class.Location = new System.Drawing.Point(92, 32);
            this.CB_Class.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Class.Name = "CB_Class";
            this.CB_Class.Size = new System.Drawing.Size(199, 29);
            this.CB_Class.TabIndex = 0;
            // 
            // GB_Pokemon
            // 
            this.GB_Pokemon.Controls.Add(this.PB_PKM);
            this.GB_Pokemon.Controls.Add(this.CHK_Spe);
            this.GB_Pokemon.Controls.Add(this.CHK_SpD);
            this.GB_Pokemon.Controls.Add(this.CHK_SpA);
            this.GB_Pokemon.Controls.Add(this.CHK_DEF);
            this.GB_Pokemon.Controls.Add(this.CHK_ATK);
            this.GB_Pokemon.Controls.Add(this.CHK_HP);
            this.GB_Pokemon.Controls.Add(this.L_Species);
            this.GB_Pokemon.Controls.Add(this.L_Item);
            this.GB_Pokemon.Controls.Add(this.L_Nature);
            this.GB_Pokemon.Controls.Add(this.L_Moves);
            this.GB_Pokemon.Controls.Add(this.CB_Item);
            this.GB_Pokemon.Controls.Add(this.CB_Nature);
            this.GB_Pokemon.Controls.Add(this.CB_Move4);
            this.GB_Pokemon.Controls.Add(this.CB_Move2);
            this.GB_Pokemon.Controls.Add(this.CB_Move3);
            this.GB_Pokemon.Controls.Add(this.CB_Move1);
            this.GB_Pokemon.Controls.Add(this.CB_Species);
            this.GB_Pokemon.Location = new System.Drawing.Point(442, 52);
            this.GB_Pokemon.Margin = new System.Windows.Forms.Padding(5);
            this.GB_Pokemon.Name = "GB_Pokemon";
            this.GB_Pokemon.Padding = new System.Windows.Forms.Padding(5);
            this.GB_Pokemon.Size = new System.Drawing.Size(446, 303);
            this.GB_Pokemon.TabIndex = 5;
            this.GB_Pokemon.TabStop = false;
            this.GB_Pokemon.Text = "宝可梦总览";
            // 
            // PB_PKM
            // 
            this.PB_PKM.Location = new System.Drawing.Point(296, 17);
            this.PB_PKM.Margin = new System.Windows.Forms.Padding(5);
            this.PB_PKM.Name = "PB_PKM";
            this.PB_PKM.Size = new System.Drawing.Size(75, 65);
            this.PB_PKM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.PB_PKM.TabIndex = 25;
            this.PB_PKM.TabStop = false;
            // 
            // CHK_Spe
            // 
            this.CHK_Spe.AutoSize = true;
            this.CHK_Spe.Location = new System.Drawing.Point(365, 258);
            this.CHK_Spe.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_Spe.Name = "CHK_Spe";
            this.CHK_Spe.Size = new System.Drawing.Size(61, 25);
            this.CHK_Spe.TabIndex = 24;
            this.CHK_Spe.Text = "速度";
            this.CHK_Spe.UseVisualStyleBackColor = true;
            // 
            // CHK_SpD
            // 
            this.CHK_SpD.AutoSize = true;
            this.CHK_SpD.Location = new System.Drawing.Point(365, 231);
            this.CHK_SpD.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_SpD.Name = "CHK_SpD";
            this.CHK_SpD.Size = new System.Drawing.Size(61, 25);
            this.CHK_SpD.TabIndex = 23;
            this.CHK_SpD.Text = "特防";
            this.CHK_SpD.UseVisualStyleBackColor = true;
            // 
            // CHK_SpA
            // 
            this.CHK_SpA.AutoSize = true;
            this.CHK_SpA.Location = new System.Drawing.Point(365, 205);
            this.CHK_SpA.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_SpA.Name = "CHK_SpA";
            this.CHK_SpA.Size = new System.Drawing.Size(61, 25);
            this.CHK_SpA.TabIndex = 22;
            this.CHK_SpA.Text = "特攻";
            this.CHK_SpA.UseVisualStyleBackColor = true;
            // 
            // CHK_DEF
            // 
            this.CHK_DEF.AutoSize = true;
            this.CHK_DEF.Location = new System.Drawing.Point(287, 258);
            this.CHK_DEF.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_DEF.Name = "CHK_DEF";
            this.CHK_DEF.Size = new System.Drawing.Size(61, 25);
            this.CHK_DEF.TabIndex = 21;
            this.CHK_DEF.Text = "物防";
            this.CHK_DEF.UseVisualStyleBackColor = true;
            // 
            // CHK_ATK
            // 
            this.CHK_ATK.AutoSize = true;
            this.CHK_ATK.Location = new System.Drawing.Point(287, 231);
            this.CHK_ATK.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_ATK.Name = "CHK_ATK";
            this.CHK_ATK.Size = new System.Drawing.Size(61, 25);
            this.CHK_ATK.TabIndex = 20;
            this.CHK_ATK.Text = "物攻";
            this.CHK_ATK.UseVisualStyleBackColor = true;
            // 
            // CHK_HP
            // 
            this.CHK_HP.AutoSize = true;
            this.CHK_HP.Location = new System.Drawing.Point(287, 205);
            this.CHK_HP.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_HP.Name = "CHK_HP";
            this.CHK_HP.Size = new System.Drawing.Size(51, 25);
            this.CHK_HP.TabIndex = 19;
            this.CHK_HP.Text = "HP";
            this.CHK_HP.UseVisualStyleBackColor = true;
            // 
            // L_Species
            // 
            this.L_Species.AutoSize = true;
            this.L_Species.Location = new System.Drawing.Point(22, 37);
            this.L_Species.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(62, 21);
            this.L_Species.TabIndex = 18;
            this.L_Species.Text = "宝可梦:";
            // 
            // L_Item
            // 
            this.L_Item.AutoSize = true;
            this.L_Item.Location = new System.Drawing.Point(22, 256);
            this.L_Item.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Item.Name = "L_Item";
            this.L_Item.Size = new System.Drawing.Size(78, 21);
            this.L_Item.TabIndex = 17;
            this.L_Item.Text = "持有物品:";
            // 
            // L_Nature
            // 
            this.L_Nature.AutoSize = true;
            this.L_Nature.Location = new System.Drawing.Point(54, 212);
            this.L_Nature.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Nature.Name = "L_Nature";
            this.L_Nature.Size = new System.Drawing.Size(46, 21);
            this.L_Nature.TabIndex = 16;
            this.L_Nature.Text = "性格:";
            // 
            // L_Moves
            // 
            this.L_Moves.AutoSize = true;
            this.L_Moves.Location = new System.Drawing.Point(22, 77);
            this.L_Moves.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Moves.Name = "L_Moves";
            this.L_Moves.Size = new System.Drawing.Size(46, 21);
            this.L_Moves.TabIndex = 15;
            this.L_Moves.Text = "招式:";
            // 
            // CB_Item
            // 
            this.CB_Item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Item.FormattingEnabled = true;
            this.CB_Item.Location = new System.Drawing.Point(103, 252);
            this.CB_Item.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Item.Name = "CB_Item";
            this.CB_Item.Size = new System.Drawing.Size(166, 29);
            this.CB_Item.TabIndex = 14;
            // 
            // CB_Nature
            // 
            this.CB_Nature.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Nature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Nature.FormattingEnabled = true;
            this.CB_Nature.Location = new System.Drawing.Point(103, 208);
            this.CB_Nature.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Nature.Name = "CB_Nature";
            this.CB_Nature.Size = new System.Drawing.Size(166, 29);
            this.CB_Nature.TabIndex = 13;
            // 
            // CB_Move4
            // 
            this.CB_Move4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Move4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move4.FormattingEnabled = true;
            this.CB_Move4.Location = new System.Drawing.Point(233, 147);
            this.CB_Move4.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Move4.Name = "CB_Move4";
            this.CB_Move4.Size = new System.Drawing.Size(199, 29);
            this.CB_Move4.TabIndex = 12;
            // 
            // CB_Move2
            // 
            this.CB_Move2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Move2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move2.FormattingEnabled = true;
            this.CB_Move2.Location = new System.Drawing.Point(233, 103);
            this.CB_Move2.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Move2.Name = "CB_Move2";
            this.CB_Move2.Size = new System.Drawing.Size(199, 29);
            this.CB_Move2.TabIndex = 11;
            // 
            // CB_Move3
            // 
            this.CB_Move3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Move3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move3.FormattingEnabled = true;
            this.CB_Move3.Location = new System.Drawing.Point(22, 147);
            this.CB_Move3.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Move3.Name = "CB_Move3";
            this.CB_Move3.Size = new System.Drawing.Size(199, 29);
            this.CB_Move3.TabIndex = 10;
            // 
            // CB_Move1
            // 
            this.CB_Move1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Move1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Move1.FormattingEnabled = true;
            this.CB_Move1.Location = new System.Drawing.Point(22, 103);
            this.CB_Move1.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Move1.Name = "CB_Move1";
            this.CB_Move1.Size = new System.Drawing.Size(199, 29);
            this.CB_Move1.TabIndex = 9;
            // 
            // CB_Species
            // 
            this.CB_Species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.CB_Species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CB_Species.FormattingEnabled = true;
            this.CB_Species.Location = new System.Drawing.Point(112, 32);
            this.CB_Species.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Species.Name = "CB_Species";
            this.CB_Species.Size = new System.Drawing.Size(174, 29);
            this.CB_Species.TabIndex = 8;
            this.CB_Species.SelectedIndexChanged += new System.EventHandler(this.ChangeSpecies);
            // 
            // B_DumpPKs
            // 
            this.B_DumpPKs.Location = new System.Drawing.Point(748, 9);
            this.B_DumpPKs.Margin = new System.Windows.Forms.Padding(5);
            this.B_DumpPKs.Name = "B_DumpPKs";
            this.B_DumpPKs.Size = new System.Drawing.Size(140, 40);
            this.B_DumpPKs.TabIndex = 6;
            this.B_DumpPKs.Text = "导出至TXT文件";
            this.B_DumpPKs.UseVisualStyleBackColor = true;
            this.B_DumpPKs.Click += new System.EventHandler(this.B_DumpPKs_Click);
            // 
            // DumpTRs
            // 
            this.DumpTRs.Location = new System.Drawing.Point(292, 9);
            this.DumpTRs.Margin = new System.Windows.Forms.Padding(5);
            this.DumpTRs.Name = "DumpTRs";
            this.DumpTRs.Size = new System.Drawing.Size(140, 40);
            this.DumpTRs.TabIndex = 7;
            this.DumpTRs.Text = "导出至TXT文件";
            this.DumpTRs.UseVisualStyleBackColor = true;
            this.DumpTRs.Click += new System.EventHandler(this.DumpTRs_Click);
            // 
            // MaisonEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(902, 366);
            this.Controls.Add(this.DumpTRs);
            this.Controls.Add(this.B_DumpPKs);
            this.Controls.Add(this.GB_Pokemon);
            this.Controls.Add(this.GB_Trainer);
            this.Controls.Add(this.L_Pokemon);
            this.Controls.Add(this.L_Trainer);
            this.Controls.Add(this.CB_Pokemon);
            this.Controls.Add(this.CB_Trainer);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(981, 405);
            this.Name = "MaisonEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "对战屋编辑器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Closing);
            this.GB_Trainer.ResumeLayout(false);
            this.GB_Trainer.PerformLayout();
            this.GB_Pokemon.ResumeLayout(false);
            this.GB_Pokemon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PB_PKM)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CB_Trainer;
        private System.Windows.Forms.ComboBox CB_Pokemon;
        private System.Windows.Forms.Label L_Trainer;
        private System.Windows.Forms.Label L_Pokemon;
        private System.Windows.Forms.GroupBox GB_Trainer;
        private System.Windows.Forms.GroupBox GB_Pokemon;
        private System.Windows.Forms.Button B_DumpPKs;
        private System.Windows.Forms.Button DumpTRs;
        private System.Windows.Forms.Label L_Item;
        private System.Windows.Forms.Label L_Nature;
        private System.Windows.Forms.Label L_Moves;
        private System.Windows.Forms.ComboBox CB_Item;
        private System.Windows.Forms.ComboBox CB_Nature;
        private System.Windows.Forms.ComboBox CB_Move4;
        private System.Windows.Forms.ComboBox CB_Move2;
        private System.Windows.Forms.ComboBox CB_Move3;
        private System.Windows.Forms.ComboBox CB_Move1;
        private System.Windows.Forms.ComboBox CB_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.CheckBox CHK_Spe;
        private System.Windows.Forms.CheckBox CHK_SpD;
        private System.Windows.Forms.CheckBox CHK_SpA;
        private System.Windows.Forms.CheckBox CHK_DEF;
        private System.Windows.Forms.CheckBox CHK_ATK;
        private System.Windows.Forms.CheckBox CHK_HP;
        private System.Windows.Forms.PictureBox PB_PKM;
        private System.Windows.Forms.Label L_Class;
        private System.Windows.Forms.Button B_Remove;
        private System.Windows.Forms.Button B_Set;
        private System.Windows.Forms.ListBox LB_Choices;
        private System.Windows.Forms.ComboBox CB_Class;
    }
}