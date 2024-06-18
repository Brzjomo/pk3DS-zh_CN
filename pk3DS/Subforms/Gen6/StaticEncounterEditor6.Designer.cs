namespace pk3DS.WinForms
{
    partial class StaticEncounterEditor6
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaticEncounterEditor6));
            this.B_Cancel = new System.Windows.Forms.Button();
            this.B_Save = new System.Windows.Forms.Button();
            this.LB_Encounters = new System.Windows.Forms.ListBox();
            this.B_RandAll = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.L_Gender = new System.Windows.Forms.Label();
            this.CB_Gender = new System.Windows.Forms.ComboBox();
            this.L_Ability = new System.Windows.Forms.Label();
            this.CB_Ability = new System.Windows.Forms.ComboBox();
            this.CHK_IV3 = new System.Windows.Forms.CheckBox();
            this.CHK_ShinyLock = new System.Windows.Forms.CheckBox();
            this.CB_Species = new System.Windows.Forms.ComboBox();
            this.L_Species = new System.Windows.Forms.Label();
            this.L_HeldItem = new System.Windows.Forms.Label();
            this.NUD_Level = new System.Windows.Forms.NumericUpDown();
            this.L_Level = new System.Windows.Forms.Label();
            this.L_Form = new System.Windows.Forms.Label();
            this.CB_HeldItem = new System.Windows.Forms.ComboBox();
            this.NUD_Form = new System.Windows.Forms.NumericUpDown();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.B_ModifyLevel = new System.Windows.Forms.Button();
            this.GB_Tweak = new System.Windows.Forms.GroupBox();
            this.CHK_ReplaceLegend = new System.Windows.Forms.CheckBox();
            this.CHK_AllowMega = new System.Windows.Forms.CheckBox();
            this.CHK_RandomAbility = new System.Windows.Forms.CheckBox();
            this.CHK_RemoveShinyLock = new System.Windows.Forms.CheckBox();
            this.CHK_Item = new System.Windows.Forms.CheckBox();
            this.L_RandOpt = new System.Windows.Forms.Label();
            this.CHK_BST = new System.Windows.Forms.CheckBox();
            this.CHK_E = new System.Windows.Forms.CheckBox();
            this.CHK_L = new System.Windows.Forms.CheckBox();
            this.CHK_G6 = new System.Windows.Forms.CheckBox();
            this.CHK_G5 = new System.Windows.Forms.CheckBox();
            this.CHK_G4 = new System.Windows.Forms.CheckBox();
            this.CHK_G3 = new System.Windows.Forms.CheckBox();
            this.CHK_G2 = new System.Windows.Forms.CheckBox();
            this.CHK_G1 = new System.Windows.Forms.CheckBox();
            this.NUD_ForceFullyEvolved = new System.Windows.Forms.NumericUpDown();
            this.CHK_ForceFullyEvolved = new System.Windows.Forms.CheckBox();
            this.NUD_LevelBoost = new System.Windows.Forms.NumericUpDown();
            this.CHK_Level = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Level)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Form)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.GB_Tweak.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ForceFullyEvolved)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LevelBoost)).BeginInit();
            this.SuspendLayout();
            // 
            // B_Cancel
            // 
            this.B_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Cancel.Location = new System.Drawing.Point(440, 546);
            this.B_Cancel.Margin = new System.Windows.Forms.Padding(5);
            this.B_Cancel.Name = "B_Cancel";
            this.B_Cancel.Size = new System.Drawing.Size(117, 37);
            this.B_Cancel.TabIndex = 467;
            this.B_Cancel.Text = "取消";
            this.B_Cancel.UseVisualStyleBackColor = true;
            this.B_Cancel.Click += new System.EventHandler(this.B_Cancel_Click);
            // 
            // B_Save
            // 
            this.B_Save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_Save.Location = new System.Drawing.Point(558, 546);
            this.B_Save.Margin = new System.Windows.Forms.Padding(5);
            this.B_Save.Name = "B_Save";
            this.B_Save.Size = new System.Drawing.Size(117, 37);
            this.B_Save.TabIndex = 466;
            this.B_Save.Text = "保存";
            this.B_Save.UseVisualStyleBackColor = true;
            this.B_Save.Click += new System.EventHandler(this.B_Save_Click);
            // 
            // LB_Encounters
            // 
            this.LB_Encounters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.LB_Encounters.FormattingEnabled = true;
            this.LB_Encounters.ItemHeight = 21;
            this.LB_Encounters.Location = new System.Drawing.Point(20, 19);
            this.LB_Encounters.Margin = new System.Windows.Forms.Padding(5);
            this.LB_Encounters.Name = "LB_Encounters";
            this.LB_Encounters.Size = new System.Drawing.Size(181, 550);
            this.LB_Encounters.TabIndex = 468;
            this.LB_Encounters.SelectedIndexChanged += new System.EventHandler(this.ChangeIndex);
            // 
            // B_RandAll
            // 
            this.B_RandAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.B_RandAll.Location = new System.Drawing.Point(302, 546);
            this.B_RandAll.Margin = new System.Windows.Forms.Padding(5);
            this.B_RandAll.Name = "B_RandAll";
            this.B_RandAll.Size = new System.Drawing.Size(138, 37);
            this.B_RandAll.TabIndex = 496;
            this.B_RandAll.Text = "全部随机化";
            this.B_RandAll.UseVisualStyleBackColor = true;
            this.B_RandAll.Click += new System.EventHandler(this.B_RandAll_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(213, 19);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(462, 520);
            this.tabControl1.TabIndex = 501;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.L_Gender);
            this.tabPage1.Controls.Add(this.CB_Gender);
            this.tabPage1.Controls.Add(this.L_Ability);
            this.tabPage1.Controls.Add(this.CB_Ability);
            this.tabPage1.Controls.Add(this.CHK_IV3);
            this.tabPage1.Controls.Add(this.CHK_ShinyLock);
            this.tabPage1.Controls.Add(this.CB_Species);
            this.tabPage1.Controls.Add(this.L_Species);
            this.tabPage1.Controls.Add(this.L_HeldItem);
            this.tabPage1.Controls.Add(this.NUD_Level);
            this.tabPage1.Controls.Add(this.L_Level);
            this.tabPage1.Controls.Add(this.L_Form);
            this.tabPage1.Controls.Add(this.CB_HeldItem);
            this.tabPage1.Controls.Add(this.NUD_Form);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage1.Size = new System.Drawing.Size(454, 486);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "编辑器";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // L_Gender
            // 
            this.L_Gender.AutoSize = true;
            this.L_Gender.Location = new System.Drawing.Point(59, 154);
            this.L_Gender.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Gender.Name = "L_Gender";
            this.L_Gender.Size = new System.Drawing.Size(46, 21);
            this.L_Gender.TabIndex = 526;
            this.L_Gender.Text = "性别:";
            this.L_Gender.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Gender
            // 
            this.CB_Gender.FormattingEnabled = true;
            this.CB_Gender.Location = new System.Drawing.Point(108, 150);
            this.CB_Gender.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Gender.Name = "CB_Gender";
            this.CB_Gender.Size = new System.Drawing.Size(224, 29);
            this.CB_Gender.TabIndex = 525;
            // 
            // L_Ability
            // 
            this.L_Ability.AutoSize = true;
            this.L_Ability.Location = new System.Drawing.Point(59, 119);
            this.L_Ability.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Ability.Name = "L_Ability";
            this.L_Ability.Size = new System.Drawing.Size(46, 21);
            this.L_Ability.TabIndex = 524;
            this.L_Ability.Text = "特性:";
            this.L_Ability.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Ability
            // 
            this.CB_Ability.FormattingEnabled = true;
            this.CB_Ability.Location = new System.Drawing.Point(108, 116);
            this.CB_Ability.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Ability.Name = "CB_Ability";
            this.CB_Ability.Size = new System.Drawing.Size(224, 29);
            this.CB_Ability.TabIndex = 523;
            // 
            // CHK_IV3
            // 
            this.CHK_IV3.AutoSize = true;
            this.CHK_IV3.Location = new System.Drawing.Point(108, 247);
            this.CHK_IV3.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_IV3.Name = "CHK_IV3";
            this.CHK_IV3.Size = new System.Drawing.Size(49, 25);
            this.CHK_IV3.TabIndex = 522;
            this.CHK_IV3.Text = "3V";
            this.CHK_IV3.UseVisualStyleBackColor = true;
            // 
            // CHK_ShinyLock
            // 
            this.CHK_ShinyLock.AutoSize = true;
            this.CHK_ShinyLock.Location = new System.Drawing.Point(108, 222);
            this.CHK_ShinyLock.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_ShinyLock.Name = "CHK_ShinyLock";
            this.CHK_ShinyLock.Size = new System.Drawing.Size(61, 25);
            this.CHK_ShinyLock.TabIndex = 519;
            this.CHK_ShinyLock.Text = "锁闪";
            this.CHK_ShinyLock.UseVisualStyleBackColor = true;
            // 
            // CB_Species
            // 
            this.CB_Species.FormattingEnabled = true;
            this.CB_Species.Location = new System.Drawing.Point(108, 10);
            this.CB_Species.Margin = new System.Windows.Forms.Padding(5);
            this.CB_Species.Name = "CB_Species";
            this.CB_Species.Size = new System.Drawing.Size(224, 29);
            this.CB_Species.TabIndex = 506;
            this.CB_Species.SelectedIndexChanged += new System.EventHandler(this.ChangeSpecies);
            // 
            // L_Species
            // 
            this.L_Species.AutoSize = true;
            this.L_Species.Location = new System.Drawing.Point(43, 14);
            this.L_Species.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Species.Name = "L_Species";
            this.L_Species.Size = new System.Drawing.Size(62, 21);
            this.L_Species.TabIndex = 508;
            this.L_Species.Text = "宝可梦:";
            this.L_Species.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_HeldItem
            // 
            this.L_HeldItem.AutoSize = true;
            this.L_HeldItem.Location = new System.Drawing.Point(26, 190);
            this.L_HeldItem.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_HeldItem.Name = "L_HeldItem";
            this.L_HeldItem.Size = new System.Drawing.Size(78, 21);
            this.L_HeldItem.TabIndex = 509;
            this.L_HeldItem.Text = "携带道具:";
            this.L_HeldItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NUD_Level
            // 
            this.NUD_Level.Location = new System.Drawing.Point(108, 47);
            this.NUD_Level.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_Level.Name = "NUD_Level";
            this.NUD_Level.Size = new System.Drawing.Size(68, 29);
            this.NUD_Level.TabIndex = 510;
            this.NUD_Level.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // L_Level
            // 
            this.L_Level.AutoSize = true;
            this.L_Level.Location = new System.Drawing.Point(59, 51);
            this.L_Level.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Level.Name = "L_Level";
            this.L_Level.Size = new System.Drawing.Size(46, 21);
            this.L_Level.TabIndex = 511;
            this.L_Level.Text = "等级:";
            this.L_Level.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // L_Form
            // 
            this.L_Form.AutoSize = true;
            this.L_Form.Location = new System.Drawing.Point(59, 84);
            this.L_Form.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_Form.Name = "L_Form";
            this.L_Form.Size = new System.Drawing.Size(46, 21);
            this.L_Form.TabIndex = 513;
            this.L_Form.Text = "形态:";
            this.L_Form.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_HeldItem
            // 
            this.CB_HeldItem.FormattingEnabled = true;
            this.CB_HeldItem.Location = new System.Drawing.Point(108, 186);
            this.CB_HeldItem.Margin = new System.Windows.Forms.Padding(5);
            this.CB_HeldItem.Name = "CB_HeldItem";
            this.CB_HeldItem.Size = new System.Drawing.Size(224, 29);
            this.CB_HeldItem.TabIndex = 507;
            // 
            // NUD_Form
            // 
            this.NUD_Form.Location = new System.Drawing.Point(108, 80);
            this.NUD_Form.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_Form.Name = "NUD_Form";
            this.NUD_Form.Size = new System.Drawing.Size(68, 29);
            this.NUD_Form.TabIndex = 512;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.B_ModifyLevel);
            this.tabPage2.Controls.Add(this.GB_Tweak);
            this.tabPage2.Controls.Add(this.NUD_LevelBoost);
            this.tabPage2.Controls.Add(this.CHK_Level);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(5);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(5);
            this.tabPage2.Size = new System.Drawing.Size(454, 486);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "随机化选项";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // B_ModifyLevel
            // 
            this.B_ModifyLevel.Location = new System.Drawing.Point(263, 27);
            this.B_ModifyLevel.Margin = new System.Windows.Forms.Padding(5);
            this.B_ModifyLevel.Name = "B_ModifyLevel";
            this.B_ModifyLevel.Size = new System.Drawing.Size(117, 37);
            this.B_ModifyLevel.TabIndex = 502;
            this.B_ModifyLevel.Text = "× 当前值";
            this.B_ModifyLevel.UseVisualStyleBackColor = true;
            this.B_ModifyLevel.Click += new System.EventHandler(this.ModifyLevels);
            // 
            // GB_Tweak
            // 
            this.GB_Tweak.Controls.Add(this.label14);
            this.GB_Tweak.Controls.Add(this.CHK_ReplaceLegend);
            this.GB_Tweak.Controls.Add(this.CHK_AllowMega);
            this.GB_Tweak.Controls.Add(this.CHK_RandomAbility);
            this.GB_Tweak.Controls.Add(this.CHK_RemoveShinyLock);
            this.GB_Tweak.Controls.Add(this.CHK_Item);
            this.GB_Tweak.Controls.Add(this.L_RandOpt);
            this.GB_Tweak.Controls.Add(this.CHK_BST);
            this.GB_Tweak.Controls.Add(this.CHK_E);
            this.GB_Tweak.Controls.Add(this.CHK_L);
            this.GB_Tweak.Controls.Add(this.CHK_G6);
            this.GB_Tweak.Controls.Add(this.CHK_G5);
            this.GB_Tweak.Controls.Add(this.CHK_G4);
            this.GB_Tweak.Controls.Add(this.CHK_G3);
            this.GB_Tweak.Controls.Add(this.CHK_G2);
            this.GB_Tweak.Controls.Add(this.CHK_G1);
            this.GB_Tweak.Controls.Add(this.NUD_ForceFullyEvolved);
            this.GB_Tweak.Controls.Add(this.CHK_ForceFullyEvolved);
            this.GB_Tweak.Location = new System.Drawing.Point(8, 107);
            this.GB_Tweak.Margin = new System.Windows.Forms.Padding(5);
            this.GB_Tweak.Name = "GB_Tweak";
            this.GB_Tweak.Padding = new System.Windows.Forms.Padding(5);
            this.GB_Tweak.Size = new System.Drawing.Size(430, 299);
            this.GB_Tweak.TabIndex = 509;
            this.GB_Tweak.TabStop = false;
            this.GB_Tweak.Text = "额外选项";
            // 
            // CHK_ReplaceLegend
            // 
            this.CHK_ReplaceLegend.AutoSize = true;
            this.CHK_ReplaceLegend.Checked = true;
            this.CHK_ReplaceLegend.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_ReplaceLegend.Location = new System.Drawing.Point(15, 226);
            this.CHK_ReplaceLegend.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_ReplaceLegend.Name = "CHK_ReplaceLegend";
            this.CHK_ReplaceLegend.Size = new System.Drawing.Size(269, 25);
            this.CHK_ReplaceLegend.TabIndex = 304;
            this.CHK_ReplaceLegend.Text = "用其他传说宝可梦替代传说宝可梦";
            this.CHK_ReplaceLegend.UseVisualStyleBackColor = true;
            // 
            // CHK_AllowMega
            // 
            this.CHK_AllowMega.AutoSize = true;
            this.CHK_AllowMega.Location = new System.Drawing.Point(15, 202);
            this.CHK_AllowMega.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_AllowMega.Name = "CHK_AllowMega";
            this.CHK_AllowMega.Size = new System.Drawing.Size(137, 25);
            this.CHK_AllowMega.TabIndex = 296;
            this.CHK_AllowMega.Text = "随机Mega形态";
            this.CHK_AllowMega.UseVisualStyleBackColor = true;
            // 
            // CHK_RandomAbility
            // 
            this.CHK_RandomAbility.AutoSize = true;
            this.CHK_RandomAbility.Location = new System.Drawing.Point(15, 178);
            this.CHK_RandomAbility.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_RandomAbility.Name = "CHK_RandomAbility";
            this.CHK_RandomAbility.Size = new System.Drawing.Size(192, 25);
            this.CHK_RandomAbility.TabIndex = 303;
            this.CHK_RandomAbility.Text = "随机个性 (1, 2, 或隐藏)";
            this.CHK_RandomAbility.UseVisualStyleBackColor = true;
            // 
            // CHK_RemoveShinyLock
            // 
            this.CHK_RemoveShinyLock.AutoSize = true;
            this.CHK_RemoveShinyLock.Location = new System.Drawing.Point(15, 154);
            this.CHK_RemoveShinyLock.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_RemoveShinyLock.Name = "CHK_RemoveShinyLock";
            this.CHK_RemoveShinyLock.Size = new System.Drawing.Size(93, 25);
            this.CHK_RemoveShinyLock.TabIndex = 297;
            this.CHK_RemoveShinyLock.Text = "解锁闪光";
            this.CHK_RemoveShinyLock.UseVisualStyleBackColor = true;
            // 
            // CHK_Item
            // 
            this.CHK_Item.AutoSize = true;
            this.CHK_Item.Checked = true;
            this.CHK_Item.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_Item.Location = new System.Drawing.Point(15, 130);
            this.CHK_Item.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_Item.Name = "CHK_Item";
            this.CHK_Item.Size = new System.Drawing.Size(125, 25);
            this.CHK_Item.TabIndex = 295;
            this.CHK_Item.Text = "随机携带道具";
            this.CHK_Item.UseVisualStyleBackColor = true;
            // 
            // L_RandOpt
            // 
            this.L_RandOpt.AutoSize = true;
            this.L_RandOpt.Location = new System.Drawing.Point(10, 28);
            this.L_RandOpt.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.L_RandOpt.Name = "L_RandOpt";
            this.L_RandOpt.Size = new System.Drawing.Size(94, 21);
            this.L_RandOpt.TabIndex = 294;
            this.L_RandOpt.Text = "随机化选项:";
            // 
            // CHK_BST
            // 
            this.CHK_BST.AutoSize = true;
            this.CHK_BST.Location = new System.Drawing.Point(213, 102);
            this.CHK_BST.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_BST.Name = "CHK_BST";
            this.CHK_BST.Size = new System.Drawing.Size(137, 25);
            this.CHK_BST.TabIndex = 288;
            this.CHK_BST.Text = "通过BST随机化";
            this.CHK_BST.UseVisualStyleBackColor = true;
            // 
            // CHK_E
            // 
            this.CHK_E.AutoSize = true;
            this.CHK_E.Checked = true;
            this.CHK_E.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_E.Location = new System.Drawing.Point(213, 79);
            this.CHK_E.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_E.Name = "CHK_E";
            this.CHK_E.Size = new System.Drawing.Size(139, 25);
            this.CHK_E.TabIndex = 287;
            this.CHK_E.Text = "Event Legends";
            this.CHK_E.UseVisualStyleBackColor = true;
            // 
            // CHK_L
            // 
            this.CHK_L.AutoSize = true;
            this.CHK_L.Checked = true;
            this.CHK_L.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_L.Location = new System.Drawing.Point(213, 56);
            this.CHK_L.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_L.Name = "CHK_L";
            this.CHK_L.Size = new System.Drawing.Size(142, 25);
            this.CHK_L.TabIndex = 286;
            this.CHK_L.Text = "Game Legends";
            this.CHK_L.UseVisualStyleBackColor = true;
            // 
            // CHK_G6
            // 
            this.CHK_G6.AutoSize = true;
            this.CHK_G6.Checked = true;
            this.CHK_G6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G6.Location = new System.Drawing.Point(112, 102);
            this.CHK_G6.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G6.Name = "CHK_G6";
            this.CHK_G6.Size = new System.Drawing.Size(86, 25);
            this.CHK_G6.TabIndex = 285;
            this.CHK_G6.Text = "第6世代";
            this.CHK_G6.UseVisualStyleBackColor = true;
            // 
            // CHK_G5
            // 
            this.CHK_G5.AutoSize = true;
            this.CHK_G5.Checked = true;
            this.CHK_G5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G5.Location = new System.Drawing.Point(112, 79);
            this.CHK_G5.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G5.Name = "CHK_G5";
            this.CHK_G5.Size = new System.Drawing.Size(86, 25);
            this.CHK_G5.TabIndex = 284;
            this.CHK_G5.Text = "第5世代";
            this.CHK_G5.UseVisualStyleBackColor = true;
            // 
            // CHK_G4
            // 
            this.CHK_G4.AutoSize = true;
            this.CHK_G4.Checked = true;
            this.CHK_G4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G4.Location = new System.Drawing.Point(112, 56);
            this.CHK_G4.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G4.Name = "CHK_G4";
            this.CHK_G4.Size = new System.Drawing.Size(86, 25);
            this.CHK_G4.TabIndex = 283;
            this.CHK_G4.Text = "第4世代";
            this.CHK_G4.UseVisualStyleBackColor = true;
            // 
            // CHK_G3
            // 
            this.CHK_G3.AutoSize = true;
            this.CHK_G3.Checked = true;
            this.CHK_G3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G3.Location = new System.Drawing.Point(15, 102);
            this.CHK_G3.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G3.Name = "CHK_G3";
            this.CHK_G3.Size = new System.Drawing.Size(86, 25);
            this.CHK_G3.TabIndex = 282;
            this.CHK_G3.Text = "第3世代";
            this.CHK_G3.UseVisualStyleBackColor = true;
            // 
            // CHK_G2
            // 
            this.CHK_G2.AutoSize = true;
            this.CHK_G2.Checked = true;
            this.CHK_G2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G2.Location = new System.Drawing.Point(15, 79);
            this.CHK_G2.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G2.Name = "CHK_G2";
            this.CHK_G2.Size = new System.Drawing.Size(86, 25);
            this.CHK_G2.TabIndex = 281;
            this.CHK_G2.Text = "第2世代";
            this.CHK_G2.UseVisualStyleBackColor = true;
            // 
            // CHK_G1
            // 
            this.CHK_G1.AutoSize = true;
            this.CHK_G1.Checked = true;
            this.CHK_G1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_G1.Location = new System.Drawing.Point(15, 56);
            this.CHK_G1.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_G1.Name = "CHK_G1";
            this.CHK_G1.Size = new System.Drawing.Size(86, 25);
            this.CHK_G1.TabIndex = 280;
            this.CHK_G1.Text = "第1世代";
            this.CHK_G1.UseVisualStyleBackColor = true;
            // 
            // NUD_ForceFullyEvolved
            // 
            this.NUD_ForceFullyEvolved.Location = new System.Drawing.Point(82, 258);
            this.NUD_ForceFullyEvolved.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_ForceFullyEvolved.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NUD_ForceFullyEvolved.Name = "NUD_ForceFullyEvolved";
            this.NUD_ForceFullyEvolved.Size = new System.Drawing.Size(67, 29);
            this.NUD_ForceFullyEvolved.TabIndex = 516;
            this.NUD_ForceFullyEvolved.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // CHK_ForceFullyEvolved
            // 
            this.CHK_ForceFullyEvolved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CHK_ForceFullyEvolved.AutoSize = true;
            this.CHK_ForceFullyEvolved.Location = new System.Drawing.Point(15, 260);
            this.CHK_ForceFullyEvolved.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_ForceFullyEvolved.Name = "CHK_ForceFullyEvolved";
            this.CHK_ForceFullyEvolved.Size = new System.Drawing.Size(61, 25);
            this.CHK_ForceFullyEvolved.TabIndex = 515;
            this.CHK_ForceFullyEvolved.Text = "等级";
            this.CHK_ForceFullyEvolved.UseVisualStyleBackColor = true;
            // 
            // NUD_LevelBoost
            // 
            this.NUD_LevelBoost.DecimalPlaces = 2;
            this.NUD_LevelBoost.Increment = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.NUD_LevelBoost.Location = new System.Drawing.Point(173, 31);
            this.NUD_LevelBoost.Margin = new System.Windows.Forms.Padding(5);
            this.NUD_LevelBoost.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.NUD_LevelBoost.Name = "NUD_LevelBoost";
            this.NUD_LevelBoost.Size = new System.Drawing.Size(72, 29);
            this.NUD_LevelBoost.TabIndex = 303;
            this.NUD_LevelBoost.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CHK_Level
            // 
            this.CHK_Level.AutoSize = true;
            this.CHK_Level.Checked = true;
            this.CHK_Level.CheckState = System.Windows.Forms.CheckState.Checked;
            this.CHK_Level.Location = new System.Drawing.Point(22, 33);
            this.CHK_Level.Margin = new System.Windows.Forms.Padding(5);
            this.CHK_Level.Name = "CHK_Level";
            this.CHK_Level.Size = new System.Drawing.Size(141, 25);
            this.CHK_Level.TabIndex = 302;
            this.CHK_Level.Text = "宝可梦等级倍增";
            this.CHK_Level.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(160, 262);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 21);
            this.label14.TabIndex = 517;
            this.label14.Text = "时，强制完全进化";
            // 
            // StaticEncounterEditor6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(695, 598);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.B_RandAll);
            this.Controls.Add(this.LB_Encounters);
            this.Controls.Add(this.B_Cancel);
            this.Controls.Add(this.B_Save);
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(623, 575);
            this.Name = "StaticEncounterEditor6";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "固定遭遇编辑器（6代）";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Level)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_Form)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.GB_Tweak.ResumeLayout(false);
            this.GB_Tweak.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_ForceFullyEvolved)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NUD_LevelBoost)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button B_Cancel;
        private System.Windows.Forms.Button B_Save;
        private System.Windows.Forms.ListBox LB_Encounters;
        private System.Windows.Forms.Button B_RandAll;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.NumericUpDown NUD_LevelBoost;
        private System.Windows.Forms.CheckBox CHK_Level;
        private System.Windows.Forms.GroupBox GB_Tweak;
        private System.Windows.Forms.Label L_RandOpt;
        private System.Windows.Forms.CheckBox CHK_BST;
        private System.Windows.Forms.CheckBox CHK_E;
        private System.Windows.Forms.CheckBox CHK_L;
        private System.Windows.Forms.CheckBox CHK_G6;
        private System.Windows.Forms.CheckBox CHK_G5;
        private System.Windows.Forms.CheckBox CHK_G4;
        private System.Windows.Forms.CheckBox CHK_G3;
        private System.Windows.Forms.CheckBox CHK_G2;
        private System.Windows.Forms.CheckBox CHK_G1;
        private System.Windows.Forms.CheckBox CHK_Item;
        private System.Windows.Forms.CheckBox CHK_AllowMega;
        private System.Windows.Forms.CheckBox CHK_RemoveShinyLock;
        private System.Windows.Forms.CheckBox CHK_ShinyLock;
        private System.Windows.Forms.ComboBox CB_Species;
        private System.Windows.Forms.Label L_Species;
        private System.Windows.Forms.Label L_HeldItem;
        private System.Windows.Forms.NumericUpDown NUD_Level;
        private System.Windows.Forms.Label L_Level;
        private System.Windows.Forms.Label L_Form;
        private System.Windows.Forms.ComboBox CB_HeldItem;
        private System.Windows.Forms.NumericUpDown NUD_Form;
        private System.Windows.Forms.Button B_ModifyLevel;
        private System.Windows.Forms.CheckBox CHK_IV3;
        private System.Windows.Forms.Label L_Gender;
        private System.Windows.Forms.ComboBox CB_Gender;
        private System.Windows.Forms.Label L_Ability;
        private System.Windows.Forms.ComboBox CB_Ability;
        private System.Windows.Forms.CheckBox CHK_RandomAbility;
        private System.Windows.Forms.CheckBox CHK_ReplaceLegend;
        private System.Windows.Forms.NumericUpDown NUD_ForceFullyEvolved;
        private System.Windows.Forms.CheckBox CHK_ForceFullyEvolved;
        private System.Windows.Forms.Label label14;
    }
}