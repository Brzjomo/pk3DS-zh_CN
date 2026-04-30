namespace pk3DS.WinForms
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
            CB_Trainer = new System.Windows.Forms.ComboBox();
            CB_Pokemon = new System.Windows.Forms.ComboBox();
            L_Trainer = new System.Windows.Forms.Label();
            L_Pokemon = new System.Windows.Forms.Label();
            GB_Trainer = new System.Windows.Forms.GroupBox();
            L_Class = new System.Windows.Forms.Label();
            B_Remove = new System.Windows.Forms.Button();
            B_Set = new System.Windows.Forms.Button();
            LB_Choices = new System.Windows.Forms.ListBox();
            CB_Class = new System.Windows.Forms.ComboBox();
            GB_Pokemon = new System.Windows.Forms.GroupBox();
            PB_PKM = new System.Windows.Forms.PictureBox();
            CHK_Spe = new System.Windows.Forms.CheckBox();
            CHK_SpD = new System.Windows.Forms.CheckBox();
            CHK_SpA = new System.Windows.Forms.CheckBox();
            CHK_DEF = new System.Windows.Forms.CheckBox();
            CHK_ATK = new System.Windows.Forms.CheckBox();
            CHK_HP = new System.Windows.Forms.CheckBox();
            L_Species = new System.Windows.Forms.Label();
            L_Item = new System.Windows.Forms.Label();
            L_Nature = new System.Windows.Forms.Label();
            L_Moves = new System.Windows.Forms.Label();
            CB_Item = new System.Windows.Forms.ComboBox();
            CB_Nature = new System.Windows.Forms.ComboBox();
            CB_Move4 = new System.Windows.Forms.ComboBox();
            CB_Move2 = new System.Windows.Forms.ComboBox();
            CB_Move3 = new System.Windows.Forms.ComboBox();
            CB_Move1 = new System.Windows.Forms.ComboBox();
            CB_Species = new System.Windows.Forms.ComboBox();
            B_DumpPKs = new System.Windows.Forms.Button();
            DumpTRs = new System.Windows.Forms.Button();
            GB_Randomize = new System.Windows.Forms.GroupBox();
            B_Randomize = new System.Windows.Forms.Button();
            CHK_Form = new System.Windows.Forms.CheckBox();
            CHK_EVs = new System.Windows.Forms.CheckBox();
            CHK_Natures = new System.Windows.Forms.CheckBox();
            CHK_Items = new System.Windows.Forms.CheckBox();
            CHK_Moves = new System.Windows.Forms.CheckBox();
            CHK_Species = new System.Windows.Forms.CheckBox();
            NUD_Legendary = new System.Windows.Forms.NumericUpDown();
            L_Legendary = new System.Windows.Forms.Label();
            CHK_Legendary = new System.Windows.Forms.CheckBox();
            CHK_Smart = new System.Windows.Forms.CheckBox();
            GB_Trainer.SuspendLayout();
            GB_Pokemon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PB_PKM).BeginInit();
            GB_Randomize.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Legendary).BeginInit();
            SuspendLayout();
            // 
            // CB_Trainer
            // 
            CB_Trainer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Trainer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Trainer.FormattingEnabled = true;
            CB_Trainer.Location = new System.Drawing.Point(80, 15);
            CB_Trainer.Margin = new System.Windows.Forms.Padding(5);
            CB_Trainer.Name = "CB_Trainer";
            CB_Trainer.Size = new System.Drawing.Size(200, 29);
            CB_Trainer.TabIndex = 0;
            CB_Trainer.SelectedIndexChanged += ChangeTrainer;
            // 
            // CB_Pokemon
            // 
            CB_Pokemon.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Pokemon.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Pokemon.FormattingEnabled = true;
            CB_Pokemon.Location = new System.Drawing.Point(514, 13);
            CB_Pokemon.Margin = new System.Windows.Forms.Padding(5);
            CB_Pokemon.Name = "CB_Pokemon";
            CB_Pokemon.Size = new System.Drawing.Size(200, 29);
            CB_Pokemon.TabIndex = 1;
            CB_Pokemon.SelectedIndexChanged += ChangePokemon;
            // 
            // L_Trainer
            // 
            L_Trainer.AutoSize = true;
            L_Trainer.Location = new System.Drawing.Point(8, 18);
            L_Trainer.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Trainer.Name = "L_Trainer";
            L_Trainer.Size = new System.Drawing.Size(62, 21);
            L_Trainer.TabIndex = 2;
            L_Trainer.Text = "训练家:";
            // 
            // L_Pokemon
            // 
            L_Pokemon.AutoSize = true;
            L_Pokemon.Location = new System.Drawing.Point(442, 18);
            L_Pokemon.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Pokemon.Name = "L_Pokemon";
            L_Pokemon.Size = new System.Drawing.Size(62, 21);
            L_Pokemon.TabIndex = 3;
            L_Pokemon.Text = "宝可梦:";
            // 
            // GB_Trainer
            // 
            GB_Trainer.Controls.Add(L_Class);
            GB_Trainer.Controls.Add(B_Remove);
            GB_Trainer.Controls.Add(B_Set);
            GB_Trainer.Controls.Add(LB_Choices);
            GB_Trainer.Controls.Add(CB_Class);
            GB_Trainer.Location = new System.Drawing.Point(12, 52);
            GB_Trainer.Margin = new System.Windows.Forms.Padding(5);
            GB_Trainer.Name = "GB_Trainer";
            GB_Trainer.Padding = new System.Windows.Forms.Padding(5);
            GB_Trainer.Size = new System.Drawing.Size(420, 303);
            GB_Trainer.TabIndex = 4;
            GB_Trainer.TabStop = false;
            GB_Trainer.Text = "训练家总览";
            // 
            // L_Class
            // 
            L_Class.AutoSize = true;
            L_Class.Location = new System.Drawing.Point(23, 37);
            L_Class.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Class.Name = "L_Class";
            L_Class.Size = new System.Drawing.Size(46, 21);
            L_Class.TabIndex = 5;
            L_Class.Text = "类型:";
            // 
            // B_Remove
            // 
            B_Remove.Location = new System.Drawing.Point(303, 252);
            B_Remove.Margin = new System.Windows.Forms.Padding(5);
            B_Remove.Name = "B_Remove";
            B_Remove.Size = new System.Drawing.Size(103, 37);
            B_Remove.TabIndex = 4;
            B_Remove.Text = "[X] 删除";
            B_Remove.UseVisualStyleBackColor = true;
            B_Remove.Click += B_Remove_Click;
            // 
            // B_Set
            // 
            B_Set.Location = new System.Drawing.Point(303, 75);
            B_Set.Margin = new System.Windows.Forms.Padding(5);
            B_Set.Name = "B_Set";
            B_Set.Size = new System.Drawing.Size(103, 37);
            B_Set.TabIndex = 2;
            B_Set.Text = "[<] 设置";
            B_Set.UseVisualStyleBackColor = true;
            B_Set.Click += B_Set_Click;
            // 
            // LB_Choices
            // 
            LB_Choices.FormattingEnabled = true;
            LB_Choices.ItemHeight = 21;
            LB_Choices.Location = new System.Drawing.Point(15, 75);
            LB_Choices.Margin = new System.Windows.Forms.Padding(5);
            LB_Choices.Name = "LB_Choices";
            LB_Choices.Size = new System.Drawing.Size(276, 214);
            LB_Choices.TabIndex = 1;
            LB_Choices.SelectedIndexChanged += B_View_Click;
            // 
            // CB_Class
            // 
            CB_Class.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Class.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Class.FormattingEnabled = true;
            CB_Class.Location = new System.Drawing.Point(92, 32);
            CB_Class.Margin = new System.Windows.Forms.Padding(5);
            CB_Class.Name = "CB_Class";
            CB_Class.Size = new System.Drawing.Size(199, 29);
            CB_Class.TabIndex = 0;
            // 
            // GB_Pokemon
            // 
            GB_Pokemon.Controls.Add(PB_PKM);
            GB_Pokemon.Controls.Add(CHK_Spe);
            GB_Pokemon.Controls.Add(CHK_SpD);
            GB_Pokemon.Controls.Add(CHK_SpA);
            GB_Pokemon.Controls.Add(CHK_DEF);
            GB_Pokemon.Controls.Add(CHK_ATK);
            GB_Pokemon.Controls.Add(CHK_HP);
            GB_Pokemon.Controls.Add(L_Species);
            GB_Pokemon.Controls.Add(L_Item);
            GB_Pokemon.Controls.Add(L_Nature);
            GB_Pokemon.Controls.Add(L_Moves);
            GB_Pokemon.Controls.Add(CB_Item);
            GB_Pokemon.Controls.Add(CB_Nature);
            GB_Pokemon.Controls.Add(CB_Move4);
            GB_Pokemon.Controls.Add(CB_Move2);
            GB_Pokemon.Controls.Add(CB_Move3);
            GB_Pokemon.Controls.Add(CB_Move1);
            GB_Pokemon.Controls.Add(CB_Species);
            GB_Pokemon.Location = new System.Drawing.Point(442, 52);
            GB_Pokemon.Margin = new System.Windows.Forms.Padding(5);
            GB_Pokemon.Name = "GB_Pokemon";
            GB_Pokemon.Padding = new System.Windows.Forms.Padding(5);
            GB_Pokemon.Size = new System.Drawing.Size(446, 303);
            GB_Pokemon.TabIndex = 5;
            GB_Pokemon.TabStop = false;
            GB_Pokemon.Text = "宝可梦总览";
            // 
            // PB_PKM
            // 
            PB_PKM.Location = new System.Drawing.Point(296, 17);
            PB_PKM.Margin = new System.Windows.Forms.Padding(5);
            PB_PKM.Name = "PB_PKM";
            PB_PKM.Size = new System.Drawing.Size(75, 65);
            PB_PKM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            PB_PKM.TabIndex = 25;
            PB_PKM.TabStop = false;
            // 
            // CHK_Spe
            // 
            CHK_Spe.AutoSize = true;
            CHK_Spe.Location = new System.Drawing.Point(365, 258);
            CHK_Spe.Margin = new System.Windows.Forms.Padding(5);
            CHK_Spe.Name = "CHK_Spe";
            CHK_Spe.Size = new System.Drawing.Size(61, 25);
            CHK_Spe.TabIndex = 24;
            CHK_Spe.Text = "速度";
            CHK_Spe.UseVisualStyleBackColor = true;
            // 
            // CHK_SpD
            // 
            CHK_SpD.AutoSize = true;
            CHK_SpD.Location = new System.Drawing.Point(365, 231);
            CHK_SpD.Margin = new System.Windows.Forms.Padding(5);
            CHK_SpD.Name = "CHK_SpD";
            CHK_SpD.Size = new System.Drawing.Size(61, 25);
            CHK_SpD.TabIndex = 23;
            CHK_SpD.Text = "特防";
            CHK_SpD.UseVisualStyleBackColor = true;
            // 
            // CHK_SpA
            // 
            CHK_SpA.AutoSize = true;
            CHK_SpA.Location = new System.Drawing.Point(365, 205);
            CHK_SpA.Margin = new System.Windows.Forms.Padding(5);
            CHK_SpA.Name = "CHK_SpA";
            CHK_SpA.Size = new System.Drawing.Size(61, 25);
            CHK_SpA.TabIndex = 22;
            CHK_SpA.Text = "特攻";
            CHK_SpA.UseVisualStyleBackColor = true;
            // 
            // CHK_DEF
            // 
            CHK_DEF.AutoSize = true;
            CHK_DEF.Location = new System.Drawing.Point(287, 258);
            CHK_DEF.Margin = new System.Windows.Forms.Padding(5);
            CHK_DEF.Name = "CHK_DEF";
            CHK_DEF.Size = new System.Drawing.Size(61, 25);
            CHK_DEF.TabIndex = 21;
            CHK_DEF.Text = "物防";
            CHK_DEF.UseVisualStyleBackColor = true;
            // 
            // CHK_ATK
            // 
            CHK_ATK.AutoSize = true;
            CHK_ATK.Location = new System.Drawing.Point(287, 231);
            CHK_ATK.Margin = new System.Windows.Forms.Padding(5);
            CHK_ATK.Name = "CHK_ATK";
            CHK_ATK.Size = new System.Drawing.Size(61, 25);
            CHK_ATK.TabIndex = 20;
            CHK_ATK.Text = "物攻";
            CHK_ATK.UseVisualStyleBackColor = true;
            // 
            // CHK_HP
            // 
            CHK_HP.AutoSize = true;
            CHK_HP.Location = new System.Drawing.Point(287, 205);
            CHK_HP.Margin = new System.Windows.Forms.Padding(5);
            CHK_HP.Name = "CHK_HP";
            CHK_HP.Size = new System.Drawing.Size(51, 25);
            CHK_HP.TabIndex = 19;
            CHK_HP.Text = "HP";
            CHK_HP.UseVisualStyleBackColor = true;
            // 
            // L_Species
            // 
            L_Species.AutoSize = true;
            L_Species.Location = new System.Drawing.Point(22, 37);
            L_Species.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Species.Name = "L_Species";
            L_Species.Size = new System.Drawing.Size(62, 21);
            L_Species.TabIndex = 18;
            L_Species.Text = "宝可梦:";
            // 
            // L_Item
            // 
            L_Item.AutoSize = true;
            L_Item.Location = new System.Drawing.Point(22, 256);
            L_Item.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Item.Name = "L_Item";
            L_Item.Size = new System.Drawing.Size(78, 21);
            L_Item.TabIndex = 17;
            L_Item.Text = "持有物品:";
            // 
            // L_Nature
            // 
            L_Nature.AutoSize = true;
            L_Nature.Location = new System.Drawing.Point(54, 212);
            L_Nature.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Nature.Name = "L_Nature";
            L_Nature.Size = new System.Drawing.Size(46, 21);
            L_Nature.TabIndex = 16;
            L_Nature.Text = "性格:";
            // 
            // L_Moves
            // 
            L_Moves.AutoSize = true;
            L_Moves.Location = new System.Drawing.Point(22, 77);
            L_Moves.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            L_Moves.Name = "L_Moves";
            L_Moves.Size = new System.Drawing.Size(46, 21);
            L_Moves.TabIndex = 15;
            L_Moves.Text = "招式:";
            // 
            // CB_Item
            // 
            CB_Item.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Item.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Item.FormattingEnabled = true;
            CB_Item.Location = new System.Drawing.Point(103, 252);
            CB_Item.Margin = new System.Windows.Forms.Padding(5);
            CB_Item.Name = "CB_Item";
            CB_Item.Size = new System.Drawing.Size(166, 29);
            CB_Item.TabIndex = 14;
            // 
            // CB_Nature
            // 
            CB_Nature.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Nature.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Nature.FormattingEnabled = true;
            CB_Nature.Location = new System.Drawing.Point(103, 208);
            CB_Nature.Margin = new System.Windows.Forms.Padding(5);
            CB_Nature.Name = "CB_Nature";
            CB_Nature.Size = new System.Drawing.Size(166, 29);
            CB_Nature.TabIndex = 13;
            // 
            // CB_Move4
            // 
            CB_Move4.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Move4.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Move4.FormattingEnabled = true;
            CB_Move4.Location = new System.Drawing.Point(233, 147);
            CB_Move4.Margin = new System.Windows.Forms.Padding(5);
            CB_Move4.Name = "CB_Move4";
            CB_Move4.Size = new System.Drawing.Size(199, 29);
            CB_Move4.TabIndex = 12;
            // 
            // CB_Move2
            // 
            CB_Move2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Move2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Move2.FormattingEnabled = true;
            CB_Move2.Location = new System.Drawing.Point(233, 103);
            CB_Move2.Margin = new System.Windows.Forms.Padding(5);
            CB_Move2.Name = "CB_Move2";
            CB_Move2.Size = new System.Drawing.Size(199, 29);
            CB_Move2.TabIndex = 11;
            // 
            // CB_Move3
            // 
            CB_Move3.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Move3.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Move3.FormattingEnabled = true;
            CB_Move3.Location = new System.Drawing.Point(22, 147);
            CB_Move3.Margin = new System.Windows.Forms.Padding(5);
            CB_Move3.Name = "CB_Move3";
            CB_Move3.Size = new System.Drawing.Size(199, 29);
            CB_Move3.TabIndex = 10;
            // 
            // CB_Move1
            // 
            CB_Move1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Move1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Move1.FormattingEnabled = true;
            CB_Move1.Location = new System.Drawing.Point(22, 103);
            CB_Move1.Margin = new System.Windows.Forms.Padding(5);
            CB_Move1.Name = "CB_Move1";
            CB_Move1.Size = new System.Drawing.Size(199, 29);
            CB_Move1.TabIndex = 9;
            // 
            // CB_Species
            // 
            CB_Species.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            CB_Species.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            CB_Species.FormattingEnabled = true;
            CB_Species.Location = new System.Drawing.Point(112, 32);
            CB_Species.Margin = new System.Windows.Forms.Padding(5);
            CB_Species.Name = "CB_Species";
            CB_Species.Size = new System.Drawing.Size(174, 29);
            CB_Species.TabIndex = 8;
            CB_Species.SelectedIndexChanged += ChangeSpecies;
            // 
            // B_DumpPKs
            // 
            B_DumpPKs.Location = new System.Drawing.Point(748, 9);
            B_DumpPKs.Margin = new System.Windows.Forms.Padding(5);
            B_DumpPKs.Name = "B_DumpPKs";
            B_DumpPKs.Size = new System.Drawing.Size(140, 40);
            B_DumpPKs.TabIndex = 6;
            B_DumpPKs.Text = "导出至TXT文件";
            B_DumpPKs.UseVisualStyleBackColor = true;
            B_DumpPKs.Click += B_DumpPKs_Click;
            // 
            // DumpTRs
            // 
            DumpTRs.Location = new System.Drawing.Point(292, 9);
            DumpTRs.Margin = new System.Windows.Forms.Padding(5);
            DumpTRs.Name = "DumpTRs";
            DumpTRs.Size = new System.Drawing.Size(140, 40);
            DumpTRs.TabIndex = 7;
            DumpTRs.Text = "导出至TXT文件";
            DumpTRs.UseVisualStyleBackColor = true;
            DumpTRs.Click += DumpTRs_Click;
            // 
            // GB_Randomize
            // 
            GB_Randomize.Controls.Add(B_Randomize);
            GB_Randomize.Controls.Add(CHK_Form);
            GB_Randomize.Controls.Add(CHK_EVs);
            GB_Randomize.Controls.Add(CHK_Natures);
            GB_Randomize.Controls.Add(CHK_Items);
            GB_Randomize.Controls.Add(CHK_Moves);
            GB_Randomize.Controls.Add(CHK_Species);
            GB_Randomize.Controls.Add(NUD_Legendary);
            GB_Randomize.Controls.Add(L_Legendary);
            GB_Randomize.Controls.Add(CHK_Legendary);
            GB_Randomize.Controls.Add(CHK_Smart);
            GB_Randomize.Location = new System.Drawing.Point(12, 365);
            GB_Randomize.Name = "GB_Randomize";
            GB_Randomize.Size = new System.Drawing.Size(878, 199);
            GB_Randomize.TabIndex = 8;
            GB_Randomize.TabStop = false;
            GB_Randomize.Text = "随机化设置";
            // 
            // B_Randomize
            // 
            B_Randomize.Location = new System.Drawing.Point(350, 116);
            B_Randomize.Name = "B_Randomize";
            B_Randomize.Size = new System.Drawing.Size(180, 60);
            B_Randomize.TabIndex = 10;
            B_Randomize.Text = "随机化";
            B_Randomize.UseVisualStyleBackColor = true;
            B_Randomize.Click += B_Randomize_Click;
            // 
            // CHK_Form
            // 
            CHK_Form.AutoSize = true;
            CHK_Form.Checked = true;
            CHK_Form.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Form.Location = new System.Drawing.Point(597, 30);
            CHK_Form.Name = "CHK_Form";
            CHK_Form.Size = new System.Drawing.Size(93, 25);
            CHK_Form.TabIndex = 5;
            CHK_Form.Text = "随机形态";
            CHK_Form.UseVisualStyleBackColor = true;
            // 
            // CHK_EVs
            // 
            CHK_EVs.AutoSize = true;
            CHK_EVs.Checked = true;
            CHK_EVs.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_EVs.Location = new System.Drawing.Point(471, 30);
            CHK_EVs.Name = "CHK_EVs";
            CHK_EVs.Size = new System.Drawing.Size(109, 25);
            CHK_EVs.TabIndex = 4;
            CHK_EVs.Text = "随机努力值";
            CHK_EVs.UseVisualStyleBackColor = true;
            // 
            // CHK_Natures
            // 
            CHK_Natures.AutoSize = true;
            CHK_Natures.Checked = true;
            CHK_Natures.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Natures.Location = new System.Drawing.Point(361, 30);
            CHK_Natures.Name = "CHK_Natures";
            CHK_Natures.Size = new System.Drawing.Size(93, 25);
            CHK_Natures.TabIndex = 3;
            CHK_Natures.Text = "随机性格";
            CHK_Natures.UseVisualStyleBackColor = true;
            // 
            // CHK_Items
            // 
            CHK_Items.AutoSize = true;
            CHK_Items.Checked = true;
            CHK_Items.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Items.Location = new System.Drawing.Point(251, 30);
            CHK_Items.Name = "CHK_Items";
            CHK_Items.Size = new System.Drawing.Size(93, 25);
            CHK_Items.TabIndex = 2;
            CHK_Items.Text = "随机道具";
            CHK_Items.UseVisualStyleBackColor = true;
            // 
            // CHK_Moves
            // 
            CHK_Moves.AutoSize = true;
            CHK_Moves.Checked = true;
            CHK_Moves.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Moves.Location = new System.Drawing.Point(141, 30);
            CHK_Moves.Name = "CHK_Moves";
            CHK_Moves.Size = new System.Drawing.Size(93, 25);
            CHK_Moves.TabIndex = 1;
            CHK_Moves.Text = "随机招式";
            CHK_Moves.UseVisualStyleBackColor = true;
            // 
            // CHK_Species
            // 
            CHK_Species.AutoSize = true;
            CHK_Species.Checked = true;
            CHK_Species.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Species.Location = new System.Drawing.Point(15, 30);
            CHK_Species.Name = "CHK_Species";
            CHK_Species.Size = new System.Drawing.Size(109, 25);
            CHK_Species.TabIndex = 0;
            CHK_Species.Text = "随机宝可梦";
            CHK_Species.UseVisualStyleBackColor = true;
            // 
            // NUD_Legendary
            // 
            NUD_Legendary.Enabled = false;
            NUD_Legendary.Location = new System.Drawing.Point(372, 68);
            NUD_Legendary.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            NUD_Legendary.Name = "NUD_Legendary";
            NUD_Legendary.Size = new System.Drawing.Size(60, 29);
            NUD_Legendary.TabIndex = 9;
            NUD_Legendary.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            NUD_Legendary.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // L_Legendary
            // 
            L_Legendary.AutoSize = true;
            L_Legendary.Enabled = false;
            L_Legendary.Location = new System.Drawing.Point(291, 72);
            L_Legendary.Name = "L_Legendary";
            L_Legendary.Size = new System.Drawing.Size(78, 21);
            L_Legendary.TabIndex = 8;
            L_Legendary.Text = "出现几率:";
            // 
            // CHK_Legendary
            // 
            CHK_Legendary.AutoSize = true;
            CHK_Legendary.Checked = true;
            CHK_Legendary.CheckState = System.Windows.Forms.CheckState.Checked;
            CHK_Legendary.Enabled = false;
            CHK_Legendary.Location = new System.Drawing.Point(141, 70);
            CHK_Legendary.Name = "CHK_Legendary";
            CHK_Legendary.Size = new System.Drawing.Size(141, 25);
            CHK_Legendary.TabIndex = 7;
            CHK_Legendary.Text = "允许传说宝可梦";
            CHK_Legendary.UseVisualStyleBackColor = true;
            CHK_Legendary.CheckedChanged += CHK_Legendary_CheckedChanged;
            // 
            // CHK_Smart
            // 
            CHK_Smart.AutoSize = true;
            CHK_Smart.Location = new System.Drawing.Point(15, 70);
            CHK_Smart.Name = "CHK_Smart";
            CHK_Smart.Size = new System.Drawing.Size(93, 25);
            CHK_Smart.TabIndex = 6;
            CHK_Smart.Text = "智能增强";
            CHK_Smart.UseVisualStyleBackColor = true;
            CHK_Smart.CheckedChanged += CHK_Smart_CheckedChanged;
            // 
            // MaisonEditor6
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(902, 576);
            Controls.Add(GB_Randomize);
            Controls.Add(DumpTRs);
            Controls.Add(B_DumpPKs);
            Controls.Add(GB_Pokemon);
            Controls.Add(GB_Trainer);
            Controls.Add(L_Pokemon);
            Controls.Add(L_Trainer);
            Controls.Add(CB_Pokemon);
            Controls.Add(CB_Trainer);
            Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 134);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(5);
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(981, 640);
            Name = "MaisonEditor6";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "对战屋编辑器";
            FormClosing += Form_Closing;
            GB_Trainer.ResumeLayout(false);
            GB_Trainer.PerformLayout();
            GB_Pokemon.ResumeLayout(false);
            GB_Pokemon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PB_PKM).EndInit();
            GB_Randomize.ResumeLayout(false);
            GB_Randomize.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)NUD_Legendary).EndInit();
            ResumeLayout(false);
            PerformLayout();

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
        private System.Windows.Forms.GroupBox GB_Randomize;
        private System.Windows.Forms.CheckBox CHK_Species;
        private System.Windows.Forms.CheckBox CHK_Moves;
        private System.Windows.Forms.CheckBox CHK_Items;
        private System.Windows.Forms.CheckBox CHK_Natures;
        private System.Windows.Forms.CheckBox CHK_EVs;
        private System.Windows.Forms.CheckBox CHK_Form;
        private System.Windows.Forms.CheckBox CHK_Smart;
        private System.Windows.Forms.CheckBox CHK_Legendary;
        private System.Windows.Forms.NumericUpDown NUD_Legendary;
        private System.Windows.Forms.Label L_Legendary;
        private System.Windows.Forms.Button B_Randomize;
    }
}