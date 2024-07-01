using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using pk3DS.Core.Structures.PersonalInfo;
using pk3DS.Core;
using pk3DS.Core.Randomizers;
using System.Data.SQLite;
using System.Diagnostics;

namespace pk3DS.WinForms
{
    public partial class PersonalEditor7 : Form
    {
        public PersonalEditor7(byte[][] infiles)
        {
            InitializeComponent();
            helditem_boxes = new[] { CB_HeldItem1, CB_HeldItem2, CB_HeldItem3 };
            ability_boxes = new[] { CB_Ability1, CB_Ability2, CB_Ability3 };
            typing_boxes = new[] { CB_Type1, CB_Type2 };
            eggGroup_boxes = new[] { CB_EggGroup1, CB_EggGroup2 };
            byte_boxes = new[] { TB_BaseHP, TB_BaseATK, TB_BaseDEF, TB_BaseSPA, TB_BaseSPD, TB_BaseSPE, TB_Gender, TB_HatchCycles, TB_Friendship, TB_CatchRate, TB_CallRate };
            ev_boxes = new[] { TB_HPEVs, TB_ATKEVs, TB_DEFEVs, TB_SPEEVs, TB_SPAEVs, TB_SPDEVs };
            rstat_boxes = new[] { CHK_rHP, CHK_rATK, CHK_rDEF, CHK_rSPA, CHK_rSPD, CHK_rSPE };
            files = infiles;

            species[0] = "---";
            abilities[0] = items[0] = moves[0] = "";
            var altForms = Main.Config.Personal.GetFormList(species, Main.Config.MaxSpeciesID);
            entryNames = Main.Config.Personal.GetPersonalEntryList(altForms, species, Main.Config.MaxSpeciesID, out baseForms, out formVal);
            TMs = TMEditor7.GetTMHMList();

            Setup();
            CB_Species.SelectedIndex = 1;
            RandSettings.GetFormSettings(this, TP_Randomizer.Controls);

            NUD_EXP.Enabled = CHK_EXP.Checked;
            NUD_CatchRateMod.Enabled = CHK_CatchRateMod.Checked;
            NUD_CallRate.Enabled = CHK_CallRate.Checked;

            ReadDataFromDB(Main.DBPokeTable, Main.pokeList);
            ReadDataFromDB(Main.DBMegaTable, Main.megaPokeList);

            NUD_TargetBST.Value = 520;
            new ToolTip().SetToolTip(LB_TargetBST, "仅对非Mega形态、非传说宝可梦的最终形态宝可梦生效");
        }
        #region Global Variables
        private readonly byte[][] files;

        private readonly string[] items = Main.Config.GetText(TextName.ItemNames);
        private readonly string[] moves = Main.Config.GetText(TextName.MoveNames);
        private readonly string[] species = Main.Config.GetText(TextName.SpeciesNames);
        private readonly string[] abilities = Main.Config.GetText(TextName.AbilityNames);
        //private readonly string[] forms = Main.Config.GetText(TextName.Forms);
        private readonly string[] types = Main.Config.GetText(TextName.Types);

        private readonly string[] entryNames;

        private readonly ComboBox[] helditem_boxes;
        private readonly ComboBox[] ability_boxes;
        private readonly ComboBox[] typing_boxes;
        private readonly ComboBox[] eggGroup_boxes;

        private readonly MaskedTextBox[] byte_boxes;
        private readonly MaskedTextBox[] ev_boxes;
        private readonly CheckBox[] rstat_boxes;

        private readonly string[] eggGroups = { "---", "Monster", "Water 1", "Bug", "Flying", "Field", "Fairy", "Grass", "Human-Like", "Water 3", "Mineral", "Amorphous", "Water 2", "Ditto", "Dragon", "Undiscovered" };
        private readonly string[] EXPGroups = { "Medium-Fast", "Erratic", "Fluctuating", "Medium-Slow", "Fast", "Slow" };
        private readonly string[] colors = { "Red", "Blue", "Yellow", "Green", "Black", "Brown", "Purple", "Gray", "White", "Pink" };
        private readonly ushort[] tutormoves = { 520, 519, 518, 338, 307, 308, 434, 620 };

        internal static readonly int[] Tutors_USUM =
        {
            450, 343, 162, 530, 324, 442, 402, 529, 340, 067, 441, 253, 009, 007, 008,
            277, 335, 414, 492, 356, 393, 334, 387, 276, 527, 196, 401,      428, 406, 304, 231,
            020, 173, 282, 235, 257, 272, 215, 366, 143, 220, 202, 409,      264, 351, 352,
            380, 388, 180, 495, 270, 271, 478, 472, 283, 200, 278, 289, 446,      285,

            477, 502, 432, 710, 707, 675, 673
        };

        private readonly int[] baseForms, formVal;
        private readonly ushort[] TMs;
        private int entry = -1;

        #endregion
        private void Setup()
        {
            CLB_TM.Items.Clear();

            if (TMs.Length == 0) // No ExeFS to grab TMs from.
            {
                for (int i = 1; i <= 100; i++)
                    CLB_TM.Items.Add($"TM{i:00}");
            }
            else // Use TM moves.
            {
                for (int i = 1; i <= 100; i++)
                    CLB_TM.Items.Add($"TM{i:00} {moves[TMs[i - 1]]}");
            }
            foreach (ushort m in tutormoves)
                CLB_MoveTutors.Items.Add(moves[m]);

            for (int i = 0; i < entryNames.Length; i++)
            {
                if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7 && i != 0)
                {
                    CB_Species.Items.Add(Main.pokemonNameUSSC[i - 1]);
                }
                else
                {
                    CB_Species.Items.Add($"{entryNames[i]} - {i:000}");
                }
            }


            foreach (ComboBox cb in helditem_boxes)
            {
                foreach (string it in items)
                    cb.Items.Add(it);
            }

            foreach (string it in items)
                CB_ZItem.Items.Add(it);
            foreach (string m in moves)
                CB_ZBaseMove.Items.Add(m);
            foreach (string m in moves)
                CB_ZMove.Items.Add(m);

            foreach (ComboBox cb in ability_boxes)
            {
                foreach (string ab in abilities)
                    cb.Items.Add(ab);
            }

            foreach (ComboBox cb in typing_boxes)
            {
                foreach (string ty in types)
                    cb.Items.Add(ty);
            }

            foreach (ComboBox cb in eggGroup_boxes)
            {
                foreach (string eg in eggGroups)
                {
                    switch (eg)
                    {
                        case "Monster":
                            cb.Items.Add("怪兽");
                            break;
                        case "Water 1":
                            cb.Items.Add("水 1");
                            break;
                        case "Bug":
                            cb.Items.Add("虫");
                            break;
                        case "Flying":
                            cb.Items.Add("飞行");
                            break;
                        case "Field":
                            cb.Items.Add("陆上");
                            break;
                        case "Fairy":
                            cb.Items.Add("妖精");
                            break;
                        case "Grass":
                            cb.Items.Add("植物");
                            break;
                        case "Human-Like":
                            cb.Items.Add("人型");
                            break;
                        case "Water 3":
                            cb.Items.Add("水 3");
                            break;
                        case "Mineral":
                            cb.Items.Add("矿物");
                            break;
                        case "Amorphous":
                            cb.Items.Add("不定形");
                            break;
                        case "Water 2":
                            cb.Items.Add("水 2");
                            break;
                        case "Ditto":
                            cb.Items.Add("百变怪");
                            break;
                        case "Dragon":
                            cb.Items.Add("龙");
                            break;
                        case "Undiscovered":
                            cb.Items.Add("未发现");
                            break;
                        default:
                            cb.Items.Add(eg);
                            break;
                    }
                }
            }

            foreach (string co in colors)
            {
                CB_Color.Items.Add(co);
            }

            foreach (string eg in EXPGroups)
            {
                switch (eg)
                {
                    case "Medium-Fast":
                        CB_EXPGroup.Items.Add("较快");
                        break;
                    case "Erratic":
                        CB_EXPGroup.Items.Add("最快");
                        break;
                    case "Fluctuating":
                        CB_EXPGroup.Items.Add("最慢");
                        break;
                    case "Medium-Slow":
                        CB_EXPGroup.Items.Add("较慢");
                        break;
                    case "Fast":
                        CB_EXPGroup.Items.Add("快");
                        break;
                    case "Slow":
                        CB_EXPGroup.Items.Add("慢");
                        break;
                    default:
                        CB_EXPGroup.Items.Add(eg);
                        break;
                }
            }

            if (Main.Config.USUM)
            {
                foreach (var tutor in Tutors_USUM)
                    CLB_BeachTutors.Items.Add(moves[tutor]);
            }

            // toggle usum content
            CHK_BeachTutors.Checked = CHK_BeachTutors.Visible =
                CLB_BeachTutors.Visible = CLB_BeachTutors.Enabled = L_BeachTutors.Visible = Main.Config.USUM;
        }

        private void CB_Species_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (entry > -1 && !dumping) SaveEntry();
            entry = CB_Species.SelectedIndex;
            ReadEntry();
        }

        private void ByteLimiter(object sender, EventArgs e)
        {
            if (sender is not MaskedTextBox mtb)
                return;
            int.TryParse(mtb.Text, out int val);
            if (Array.IndexOf(byte_boxes, mtb) > -1 && val > 255)
                mtb.Text = "255";
            else if (Array.IndexOf(ev_boxes, mtb) > -1 && val > 3)
                mtb.Text = "3";
        }

        private PersonalInfo pkm;

        private void ReadInfo()
        {
            pkm = Main.SpeciesStat[entry];

            TB_BaseHP.Text = pkm.HP.ToString("0");
            TB_BaseATK.Text = pkm.ATK.ToString("0");
            TB_BaseDEF.Text = pkm.DEF.ToString("0");
            TB_BaseSPE.Text = pkm.SPE.ToString("0");
            TB_BaseSPA.Text = pkm.SPA.ToString("0");
            TB_BaseSPD.Text = pkm.SPD.ToString("0");
            TB_HPEVs.Text = pkm.EV_HP.ToString("0");
            TB_ATKEVs.Text = pkm.EV_ATK.ToString("0");
            TB_DEFEVs.Text = pkm.EV_DEF.ToString("0");
            TB_SPEEVs.Text = pkm.EV_SPE.ToString("0");
            TB_SPAEVs.Text = pkm.EV_SPA.ToString("0");
            TB_SPDEVs.Text = pkm.EV_SPD.ToString("0");

            CB_Type1.SelectedIndex = pkm.Types[0];
            CB_Type2.SelectedIndex = pkm.Types[1];

            TB_CatchRate.Text = pkm.CatchRate.ToString("000");
            TB_Stage.Text = pkm.EvoStage.ToString("0");

            CB_HeldItem1.SelectedIndex = pkm.Items[0];
            CB_HeldItem2.SelectedIndex = pkm.Items[1];
            CB_HeldItem3.SelectedIndex = pkm.Items[2];

            TB_Gender.Text = pkm.Gender.ToString("000");
            TB_HatchCycles.Text = pkm.HatchCycles.ToString("0");
            TB_Friendship.Text = pkm.BaseFriendship.ToString("0");

            CB_EXPGroup.SelectedIndex = pkm.EXPGrowth;

            CB_EggGroup1.SelectedIndex = pkm.EggGroups[0];
            CB_EggGroup2.SelectedIndex = pkm.EggGroups[1];

            CB_Ability1.SelectedIndex = pkm.Abilities[0];
            CB_Ability2.SelectedIndex = pkm.Abilities[1];
            CB_Ability3.SelectedIndex = pkm.Abilities[2];

            TB_FormeCount.Text = pkm.FormeCount.ToString("000");
            TB_FormeSprite.Text = pkm.FormeSprite.ToString("000");

            TB_RawColor.Text = pkm.Color.ToString("000");
            CB_Color.SelectedIndex = pkm.Color & 0xF;

            switch (CB_Color.SelectedIndex)
            {
                case 0:
                    TB_RawColor.BackColor = Color.Red;
                    break;
                case 1:
                    TB_RawColor.BackColor = Color.Blue;
                    break;
                case 2:
                    TB_RawColor.BackColor = Color.Yellow;
                    break;
                case 3:
                    TB_RawColor.BackColor = Color.Green;
                    break;
                case 4:
                    TB_RawColor.BackColor = Color.Black;
                    break;
                case 5:
                    TB_RawColor.BackColor = Color.Brown;
                    break;
                case 6:
                    TB_RawColor.BackColor = Color.Purple;
                    break;
                case 7:
                    TB_RawColor.BackColor = Color.Gray;
                    break;
                case 8:
                    TB_RawColor.BackColor = Color.White;
                    break;
                case 9:
                    TB_RawColor.BackColor = Color.Pink;
                    break;
                default:
                    TB_RawColor.BackColor = Color.White;
                    break;
            }

            TB_BaseExp.Text = pkm.BaseEXP.ToString("000");
            TB_BST.Text = pkm.BST.ToString("000");

            TB_Height.Text = ((decimal)pkm.Height / 100).ToString("00.00");
            TB_Weight.Text = ((decimal)pkm.Weight / 10).ToString("000.0");

            for (int i = 0; i < CLB_TM.Items.Count; i++)
                CLB_TM.SetItemChecked(i, pkm.TMHM[i]); // Bitflags for TM

            for (int i = 0; i < CLB_MoveTutors.Items.Count; i++)
                CLB_MoveTutors.SetItemChecked(i, pkm.TypeTutors[i]); // Bitflags for Tutors

            if (Main.Config.SM || Main.Config.USUM)
            {
                PersonalInfoSM sm = (PersonalInfoSM)pkm;
                TB_CallRate.Text = sm.EscapeRate.ToString("000");
                if (sm.SpecialZ_Item < 65535)
                {
                    CB_ZItem.SelectedIndex = sm.SpecialZ_Item;
                }
                if (sm.SpecialZ_BaseMove < 65535)
                {
                    CB_ZBaseMove.SelectedIndex = sm.SpecialZ_BaseMove;
                }
                if (sm.SpecialZ_ZMove < 65535)
                {
                    CB_ZMove.SelectedIndex = sm.SpecialZ_ZMove;
                }
                CHK_Variant.Checked = sm.LocalVariant;
            }
            var special = pkm.SpecialTutors;
            if (special.Length > 0)
            {
                for (int b = 0; b < CLB_BeachTutors.Items.Count; b++)
                    CLB_BeachTutors.SetItemChecked(b, special[0][b]);
            }
        }

        private void ReadEntry()
        {
            ReadInfo();

            if (dumping) return;
            int s = baseForms[entry];
            int f = formVal[entry];
            if (entry <= Main.Config.MaxSpeciesID)
                s = entry;
            Bitmap rawImg = WinFormsUtil.GetSprite(s, f, 0, 0, Main.Config);
            Bitmap bigImg = new Bitmap(rawImg.Width * 2, rawImg.Height * 2);
            for (int x = 0; x < rawImg.Width; x++)
            {
                for (int y = 0; y < rawImg.Height; y++)
                {
                    Color c = rawImg.GetPixel(x, y);
                    bigImg.SetPixel(2 * x, 2 * y, c);
                    bigImg.SetPixel((2 * x) + 1, 2 * y, c);
                    bigImg.SetPixel(2 * x, (2 * y) + 1, c);
                    bigImg.SetPixel((2 * x) + 1, (2 * y) + 1, c);
                }
            }
            PB_MonSprite.Image = bigImg;
        }

        private void SavePersonal()
        {
            pkm.HP = Convert.ToByte(TB_BaseHP.Text);
            pkm.ATK = Convert.ToByte(TB_BaseATK.Text);
            pkm.DEF = Convert.ToByte(TB_BaseDEF.Text);
            pkm.SPE = Convert.ToByte(TB_BaseSPE.Text);
            pkm.SPA = Convert.ToByte(TB_BaseSPA.Text);
            pkm.SPD = Convert.ToByte(TB_BaseSPD.Text);

            pkm.EV_HP = Convert.ToByte(TB_HPEVs.Text);
            pkm.EV_ATK = Convert.ToByte(TB_ATKEVs.Text);
            pkm.EV_DEF = Convert.ToByte(TB_DEFEVs.Text);
            pkm.EV_SPE = Convert.ToByte(TB_SPEEVs.Text);
            pkm.EV_SPA = Convert.ToByte(TB_SPAEVs.Text);
            pkm.EV_SPD = Convert.ToByte(TB_SPDEVs.Text);

            pkm.CatchRate = Convert.ToByte(TB_CatchRate.Text);
            pkm.EvoStage = Convert.ToByte(TB_Stage.Text);

            pkm.Types = new[] { CB_Type1.SelectedIndex, CB_Type2.SelectedIndex };
            pkm.Items = new[] { CB_HeldItem1.SelectedIndex, CB_HeldItem2.SelectedIndex, CB_HeldItem3.SelectedIndex };

            pkm.Gender = Convert.ToByte(TB_Gender.Text);
            pkm.HatchCycles = Convert.ToByte(TB_HatchCycles.Text);
            pkm.BaseFriendship = Convert.ToByte(TB_Friendship.Text);
            pkm.EXPGrowth = (byte)CB_EXPGroup.SelectedIndex;
            pkm.EggGroups = new[] { CB_EggGroup1.SelectedIndex, CB_EggGroup2.SelectedIndex };
            pkm.Abilities = new[] { CB_Ability1.SelectedIndex, CB_Ability2.SelectedIndex, CB_Ability3.SelectedIndex };

            pkm.FormeSprite = Convert.ToUInt16(TB_FormeSprite.Text);
            pkm.FormeCount = Convert.ToByte(TB_FormeCount.Text);
            pkm.Color = (byte)(Convert.ToByte(CB_Color.SelectedIndex) | (Convert.ToByte(TB_RawColor.Text) & 0xF0));
            pkm.BaseEXP = Convert.ToUInt16(TB_BaseExp.Text);

            decimal.TryParse(TB_Height.Text, out var h);
            decimal.TryParse(TB_Weight.Text, out var w);
            pkm.Height = (int)(h * 100);
            pkm.Weight = (int)(w * 10);

            for (int i = 0; i < CLB_TM.Items.Count; i++)
                pkm.TMHM[i] = CLB_TM.GetItemChecked(i);

            for (int t = 0; t < CLB_MoveTutors.Items.Count; t++)
                pkm.TypeTutors[t] = CLB_MoveTutors.GetItemChecked(t);

            if (Main.Config.SM || Main.Config.USUM)
            {
                pkm.EscapeRate = Convert.ToByte(TB_CallRate.Text);
                PersonalInfoSM sm = (PersonalInfoSM)pkm;
                sm.SpecialZ_Item = CB_ZItem.SelectedIndex;
                sm.SpecialZ_BaseMove = CB_ZBaseMove.SelectedIndex;
                sm.SpecialZ_ZMove = CB_ZMove.SelectedIndex;
                sm.LocalVariant = CHK_Variant.Checked;
            }
            var special = pkm.SpecialTutors;
            if (special.Length > 0)
            {
                for (int b = 0; b < CLB_BeachTutors.Items.Count; b++)
                    special[0][b] = CLB_BeachTutors.GetItemChecked(b);
                pkm.SpecialTutors = special;
            }
        }

        private void SaveEntry()
        {
            SavePersonal();
            byte[] edits = pkm.Write();
            files[entry] = edits;
        }

        private void B_Randomize_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否全部随机化？无法撤销。", "请先确认随机化选项。") != DialogResult.Yes)
                return;
            SaveEntry();

            // 获取名称列表
            List<string> speciesList = [];
            var _species = CB_Species.Items;
            foreach (var item in _species)
            {
                speciesList.Add(item.ToString());
            }
            Clipboard.SetText(string.Join("\n", speciesList));

            // 适用条件
            var ifSuitable = Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7;

            // 根据情况创建随机器
            if (ifSuitable && CB_BalanceBST.Checked)
            {
                // 先随机其他项
                var rnd = new BalancedPersonalRandomizer(Main.SpeciesStat, Main.Config)
                {
                    TypeCount = CB_Type1.Items.Count,
                    ModifyCatchRate = CHK_CatchRate.Checked,
                    ModifyEggGroup = CHK_EggGroup.Checked,
                    ModifyStats = CHK_Stats.Checked,
                    ShuffleStats = CHK_Shuffle.Checked,
                    StatsToRandomize = rstat_boxes.Select(g => g.Checked).ToArray(),
                    ModifyAbilities = CHK_Ability.Checked,
                    ModifyLearnsetTM = CHK_TM.Checked,
                    ModifyLearnsetHM = false, // no HMs in Gen 7
                    ModifyLearnsetTypeTutors = CHK_Tutors.Checked,
                    ModifyLearnsetMoveTutors = Main.Config.USUM && CHK_BeachTutors.Checked,
                    ModifyTypes = CHK_Type.Checked,
                    ModifyHeldItems = CHK_Item.Checked,
                    SameTypeChance = NUD_TypePercent.Value,
                    SameEggGroupChance = NUD_Egg.Value,
                    StatDeviation = NUD_StatDev.Value,
                    AllowWonderGuard = CHK_WGuard.Checked
                };

                rnd.Execute();

                // 再逐个随机种族值
                var targetBST = (int)NUD_TargetBST.Value;
                var includeNonFinalStage = CB_IncludeNonFinalStage.Checked;
                var includeMegaForm = CB_IncludeMegaForm.Checked;
                var includeLegendary = CB_IncludeLegendary.Checked;

                for (var i = 0; i < speciesList.Count; i++)
                {
                    if (i == 0)
                    {
                        continue;
                    }

                    var ifFinalStage = false;
                    var ifMegaForm = false;
                    var ifLegendary = false;

                    var temp_1 = speciesList[i].Split('-')[0].Trim();
                    var temp_2 = temp_1.Split(' ');
                    var name = temp_2[0];
                    var form = string.Empty;
                    if (temp_2.Length > 1)
                    {
                        form = temp_2[1];
                    }
                    if (form == "1")
                    {
                        // 可能是mega，查询DB进行验证
                        var _name = "超级" + name;
                        foreach (var item in Main.megaPokeList)
                        {
                            if (item.name[7] == _name)
                            {
                                ifMegaForm = true;
                                ifFinalStage = item.ifFinalStage;
                                ifLegendary = item.ifLegendary;
                            }
                        }
                    }

                    // 不是mega
                    if (!ifMegaForm)
                    {
                        foreach (var item in Main.pokeList)
                        {
                            if (item.name[7] == name)
                            {
                                ifFinalStage = item.ifFinalStage;
                                ifLegendary = item.ifLegendary;
                            }
                        }
                    }

                    // 根据设置随机
                    if (includeMegaForm)
                    {
                        if (includeLegendary)
                        {
                            if (includeNonFinalStage)
                            {
                                RandPokeStats(ifFinalStage, ifMegaForm, ifLegendary, Main.SpeciesStat[i], targetBST);
                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (includeNonFinalStage)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                    else
                    {
                        if (includeLegendary)
                        {
                            if (includeNonFinalStage)
                            {

                            }
                            else
                            {

                            }
                        }
                        else
                        {
                            if (includeNonFinalStage)
                            {

                            }
                            else
                            {

                            }
                        }
                    }
                }
            } else
            {
                var rnd = new PersonalRandomizer(Main.SpeciesStat, Main.Config)
                {
                    TypeCount = CB_Type1.Items.Count,
                    ModifyCatchRate = CHK_CatchRate.Checked,
                    ModifyEggGroup = CHK_EggGroup.Checked,
                    ModifyStats = CHK_Stats.Checked,
                    ShuffleStats = CHK_Shuffle.Checked,
                    StatsToRandomize = rstat_boxes.Select(g => g.Checked).ToArray(),
                    ModifyAbilities = CHK_Ability.Checked,
                    ModifyLearnsetTM = CHK_TM.Checked,
                    ModifyLearnsetHM = false, // no HMs in Gen 7
                    ModifyLearnsetTypeTutors = CHK_Tutors.Checked,
                    ModifyLearnsetMoveTutors = Main.Config.USUM && CHK_BeachTutors.Checked,
                    ModifyTypes = CHK_Type.Checked,
                    ModifyHeldItems = CHK_Item.Checked,
                    SameTypeChance = NUD_TypePercent.Value,
                    SameEggGroupChance = NUD_Egg.Value,
                    StatDeviation = NUD_StatDev.Value,
                    AllowWonderGuard = CHK_WGuard.Checked
                };

                rnd.Execute();
            }

            Main.SpeciesStat.Select(z => z.Write()).ToArray().CopyTo(files, 0);

            ReadEntry();
            WinFormsUtil.Alert("已根据设置随机化全部宝可梦个体数据！");
        }

        private void RandPokeStats(bool ifFinalStage, bool ifMegaForm, bool ifLegendary, PersonalInfo info, int targetBST)
        {
            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);

            var maxValue = (int)NUD_TargetBST.Maximum;
            var newBST = targetBST;

            if (ifLegendary && ifMegaForm)
            {
                newBST = Math.Min(maxValue, targetBST + random.Next(200, 260));
            } else if (ifLegendary) 
            {
                newBST = Math.Min(maxValue, targetBST + random.Next(100, 200));
            } else if (ifMegaForm)
            {
                newBST = Math.Min(maxValue, targetBST + random.Next(80, 150));
            } else if (ifFinalStage) 
            {
                newBST = targetBST;
            } else
            {
                var StatDeviation = NUD_StatDev.Value;
                var low = (int)(info.BST * (1 - (StatDeviation / 100)));
                var high = (int)(info.BST * (1 + (StatDeviation / 100)));
                newBST = Math.Min(maxValue, random.Next(low, high + 1));
            }

            // 随机
            var r1 = (int)(newBST * 0.25);
            var r2 = (int)(newBST * 0.2);
            var r3 = (int)(newBST * 0.17);
            var r4 = (int)(newBST * 0.17);
            var r5 = (int)(newBST * 0.1);

            var v1 = getRandomValue(r1, 0.15);
            var v2 = getRandomValue(r2, 0.17);
            var v3 = getRandomValue(r3, 0.18);
            var v4 = getRandomValue(r4, 0.18);
            var v5 = getRandomValue(r5, 0.22);
            var BSTLeft = Math.Max(10, newBST - v1 - v2 - v3 - v4 - v5);
            var v6 = getRandomValue(BSTLeft, 0.15);
            Debug.WriteLine($"V: {v1}, {v2}, {v3}, {v4}, {v5}, {v6}");

            int[] newStats = [v1, v2, v3, v4, v5, v6];
            var d = random.NextDouble();
            if (d < 0.25)
            {
                newStats = [v2, v1, v3, v4, v5, v6];
                int[] exclude = [1];
                newStats = ShuffleArrayExceptIndex(newStats, exclude);
            } else if (d < 0.5)
            {
                newStats = [v2, v4, v3, v5, v1, v6];
                int[] exclude = [4];
                newStats = ShuffleArrayExceptIndex(newStats, exclude);
            } else if (d < 0.75)
            {
                if (random.NextDouble() < 0.5)
                {
                    newStats = [v6, v4, v1, v5, v3, v2];
                    int[] exclude = [2, 5];
                    newStats = ShuffleArrayExceptIndex(newStats, exclude);
                } else
                {
                    newStats = [v6, v4, v2, v5, v3, v1];
                    int[] exclude = [2, 5];
                    newStats = ShuffleArrayExceptIndex(newStats, exclude);
                }
            } else
            {
                if (random.NextDouble() < 0.5)
                {
                    newStats = [v6, v2, v4, v1, v3, v5];
                    int[] exclude = [1, 3];
                    newStats = ShuffleArrayExceptIndex(newStats, exclude);
                }
                else
                {
                    newStats = [v6, v3, v4, v1, v2, v5];
                    int[] exclude = [3, 4];
                    newStats = ShuffleArrayExceptIndex(newStats, exclude);
                }
            }

            // 保存
            info.Stats = newStats;
        }

        private static int getRandomValue(int value, double rate)
        {
            var low = (int)(value * (1 - rate));
            var high = (int)(value * (1 + rate));

            byte[] buffer = Guid.NewGuid().ToByteArray();
            int iSeed = BitConverter.ToInt32(buffer, 0);
            Random random = new Random(iSeed);

            return random.Next(low, high);
        }

        private static int[] ShuffleArray(int[] array)
        {
            Random random = new Random();
            for (int i = array.Length - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                int temp = array[i];
                array[i] = array[j];
                array[j] = temp;
            }
            return array;
        }

        private static int[] ShuffleArrayExceptIndex(int[] array, int[] indexToExclude)
        {
            Random random = new Random();
            int[] newArray = (int[])array.Clone();

            for (int i = newArray.Length - 1; i > 0; i--)
            {
                foreach (var line in indexToExclude)
                {
                    if (i != line)
                    {
                        int j = random.Next(i + 1);
                        if (j != line)
                        {
                            int temp = newArray[i];
                            newArray[i] = newArray[j];
                            newArray[j] = temp;
                        }
                    }
                }
            }

            return newArray;
        }

        private void B_ModifyAll(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否全部修改？无法撤销。", "请先确认修改器选项。") != DialogResult.Yes) return;

            for (int i = 1; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species

                if (CHK_NoEV.Checked)
                {
                    for (int z = 0; z < 6; z++)
                        ev_boxes[z].Text = 0.ToString();
                }

                if (CHK_Growth.Checked)
                    CB_EXPGroup.SelectedIndex = 5;
                if (CHK_EXP.Checked)
                    TB_BaseExp.Text = ((float)NUD_EXP.Value * (Convert.ToUInt16(TB_BaseExp.Text) / 100f)).ToString("000");

                if (CHK_NoTutor.Checked)
                {
                    foreach (int tm in CLB_TM.CheckedIndices)
                        CLB_TM.SetItemCheckState(tm, CheckState.Unchecked);
                    foreach (int mt in CLB_MoveTutors.CheckedIndices)
                        CLB_MoveTutors.SetItemCheckState(mt, CheckState.Unchecked);
                    foreach (int ao in CLB_BeachTutors.CheckedIndices)
                        CLB_BeachTutors.SetItemCheckState(ao, CheckState.Unchecked);
                }

                if (CHK_FullTMCompatibility.Checked)
                {
                    for (int t = 0; t < CLB_TM.Items.Count; t++)
                        CLB_TM.SetItemCheckState(t, CheckState.Checked);
                }

                if (CHK_FullMoveTutorCompatibility.Checked)
                {
                    for (int m = 0; m < CLB_MoveTutors.Items.Count; m++)
                        CLB_MoveTutors.SetItemCheckState(m, CheckState.Checked);
                }

                if (CHK_FullBeachTutorCompatibility.Checked)
                {
                    for (int m = 0; m < CLB_BeachTutors.Items.Count; m++)
                        CLB_BeachTutors.SetItemCheckState(m, CheckState.Checked);
                }

                if (CHK_QuickHatch.Checked)
                    TB_HatchCycles.Text = 1.ToString();
                if (CHK_CallRate.Checked)
                    TB_CallRate.Text = ((int)NUD_CallRate.Value).ToString();
                if (CHK_CatchRateMod.Checked)
                    TB_CatchRate.Text = ((int)NUD_CatchRateMod.Value).ToString();
            }
            CB_Species.SelectedIndex = 1;
            WinFormsUtil.Alert("已根据设置修改全部宝可梦个体数据！");
        }

        private bool dumping;

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否导出全部个体数据至TXT文件？"))
                return;
            SaveFileDialog sfd = new SaveFileDialog { FileName = "宝可梦个体数据.txt", Filter = "Text File|*.txt" };
            SystemSounds.Asterisk.Play();
            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            dumping = true;
            List<string> lines = new List<string>();
            bool dumpPokemonNameOnly = false;
            for (int i = 1; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species
                if (!dumpPokemonNameOnly)
                {
                    lines.Add("--------------------------------------------");
                    lines.Add($"{entry}");

                    string[] temp = CB_Species.Text.Split('-');
                    string pokemonName = temp[0].Trim();
                    lines.Add($"{pokemonName}");
                    lines.Add($"进化阶段: {TB_Stage.Text}");
                    lines.Add($"捕获率: {pkm.CatchRate}");
                    lines.Add($"总种族值: {pkm.BST}");
                    lines.Add($"种族值: {TB_BaseHP.Text}.{TB_BaseATK.Text}.{TB_BaseDEF.Text}.{TB_BaseSPA.Text}.{TB_BaseSPD.Text}.{TB_BaseSPE.Text}");
                    lines.Add($"取得基础点数: {TB_HPEVs.Text}.{TB_ATKEVs.Text}.{TB_DEFEVs.Text}.{TB_SPAEVs.Text}.{TB_SPDEVs.Text}.{TB_SPEEVs.Text}");
                    lines.Add(string.Format(CB_Type1.SelectedIndex != CB_Type2.SelectedIndex
                        ? "属性: {0} / {1}"
                        : "属性: {0}", CB_Type1.Text, CB_Type2.Text));
                    lines.Add($"特性: {CB_Ability1.Text} (1) | {CB_Ability2.Text} (2) | {CB_Ability3.Text} (H)");

                    lines.Add(string.Format(CB_EggGroup1.SelectedIndex != CB_EggGroup2.SelectedIndex
                        ? "蛋群: {0} / {1}"
                        : "蛋群: {0}", CB_EggGroup1.Text, CB_EggGroup2.Text));
                    lines.Add($"孵蛋周期: {TB_HatchCycles.Text}");
                    lines.Add($"身高: {TB_Height.Text} m");
                    lines.Add($"体重: {TB_Weight.Text} kg");
                    lines.Add($"颜色: {CB_Color.Text}");

                    lines.Add($"初始亲密度: {TB_Friendship.Text}");
                    lines.Add($"经验值累积速度: {CB_EXPGroup.Text}");

                    lines.Add($"物品1 (50%): {CB_HeldItem1.Text}");
                    lines.Add($"物品2 (5%): {CB_HeldItem2.Text}");
                    lines.Add($"物品3 (1%): {CB_HeldItem3.Text}");

                    if (CB_ZBaseMove.SelectedIndex > 0)
                        lines.Add($"{CB_ZBaseMove.Text} + {CB_ZItem.Text} => {CB_ZMove.Text}");
                    lines.Add("");
                }
                else
                {
                    string[] temp = CB_Species.Text.Split('-');
                    string pokemonName = temp[0].Trim();
                    //string pokemonName = CB_Species.Text;
                    lines.Add($"{pokemonName}");
                }
            }
            string path = sfd.FileName;
            File.WriteAllLines(path, lines, Encoding.Unicode);
            dumping = false;
        }

        private void CHK_Stats_CheckedChanged(object sender, EventArgs e)
        {
            L_StatDev.Enabled = NUD_StatDev.Enabled = CHK_Stats.Checked;
            CHK_rHP.Enabled = CHK_rATK.Enabled = CHK_rDEF.Enabled = CHK_rSPA.Enabled = CHK_rSPD.Enabled = CHK_rSPE.Enabled = CHK_Stats.Checked;
        }

        private void CHK_Ability_CheckedChanged(object sender, EventArgs e)
        {
            CHK_WGuard.Enabled = CHK_Ability.Checked;
            if (!CHK_WGuard.Enabled)
                CHK_WGuard.Checked = false;
        }

        private void CB_Color_SelectedIndexChanged(object sender, EventArgs e)
        {
            pkm.Color = (byte)(Convert.ToByte(CB_Color.SelectedIndex));
            TB_RawColor.Text = pkm.Color.ToString("000");
            switch (CB_Color.SelectedIndex)
            {
                case 0:
                    TB_RawColor.BackColor = Color.Red;
                    break;
                case 1:
                    TB_RawColor.BackColor = Color.Blue;
                    break;
                case 2:
                    TB_RawColor.BackColor = Color.Yellow;
                    break;
                case 3:
                    TB_RawColor.BackColor = Color.Green;
                    break;
                case 4:
                    TB_RawColor.BackColor = Color.Black;
                    break;
                case 5:
                    TB_RawColor.BackColor = Color.Brown;
                    break;
                case 6:
                    TB_RawColor.BackColor = Color.Purple;
                    break;
                case 7:
                    TB_RawColor.BackColor = Color.Gray;
                    break;
                case 8:
                    TB_RawColor.BackColor = Color.White;
                    break;
                case 9:
                    TB_RawColor.BackColor = Color.Pink;
                    break;
                default:
                    TB_RawColor.BackColor = Color.White;
                    break;
            }
        }

        private void CHK_Type_CheckedChanged(object sender, EventArgs e)
        {
            NUD_TypePercent.Enabled = CHK_Type.Checked;
        }

        private void CHK_EggGroup_CheckedChanged(object sender, EventArgs e)
        {
            NUD_Egg.Enabled = CHK_EggGroup.Checked;
        }

        private void CHK_EXP_CheckedChanged(object sender, EventArgs e)
        {
            NUD_EXP.Enabled = CHK_EXP.Checked;
        }

        private void CHK_CatchRateMod_CheckedChanged(object sender, EventArgs e)
        {
            NUD_CatchRateMod.Enabled = CHK_CatchRateMod.Checked;
        }

        private void CHK_CallRate_CheckedChanged(object sender, EventArgs e)
        {
            NUD_CallRate.Enabled = CHK_CallRate.Checked;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            if (entry > -1) SaveEntry();
            RandSettings.SetFormSettings(this, TP_Randomizer.Controls);
        }

        private void CB_BalanceBST_CheckedChanged(object sender, EventArgs e)
        {
            if (CB_BalanceBST.Checked == true)
            {
                NUD_TargetBST.Enabled = true;
                CB_IncludeNonFinalStage.Enabled = true;
                CB_IncludeMegaForm.Enabled = true;
                CB_IncludeLegendary.Enabled = true;
            }
            else
            {
                NUD_TargetBST.Enabled = false;
                CB_IncludeNonFinalStage.Enabled = false;
                CB_IncludeMegaForm.Enabled = false;
                CB_IncludeLegendary.Enabled = false;
            }
        }

        // Sqlite
        private SQLiteConnection CreateSQLiteConnection()
        {
            string connectionString = $"Data Source={Main.pokeDBPath};Version=3;";
            return new SQLiteConnection(connectionString);
        }

        private void ReadDataFromDB(string table, List<PokeData> list)
        {
            list.Clear();

            var connection = CreateSQLiteConnection();
            connection.Open();

            string query = $"SELECT nationalNumber, name, type, abilities, BST, evolutionaryStage, ifFinalStage, ifMegaForm, ifLegendary FROM {table}";
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var _nationalNumber = int.Parse(reader["nationalNumber"].ToString());

                        if (_nationalNumber > 807)
                        {
                            continue;
                        }

                        var _name = reader["name"].ToString().Split(',').ToList();
                        var _type = reader["type"].ToString().Split(',').ToList();
                        var _abilities = reader["abilities"].ToString().Split(',').ToList();
                        var _BST = reader["BST"].ToString().Split(',').Select(int.Parse).ToArray();
                        var _evolutionaryStage = int.Parse(reader["evolutionaryStage"].ToString());
                        var _ifFinalStage = bool.Parse(reader["ifFinalStage"].ToString());
                        var _ifMegaForm = bool.Parse(reader["ifMegaForm"].ToString());
                        var _ifLegendary = bool.Parse(reader["ifLegendary"].ToString());

                        var poke = new PokeData(_nationalNumber, _name, _type, _abilities, _BST, _evolutionaryStage, _ifFinalStage, _ifMegaForm, _ifLegendary);
                        list.Add(poke);
                    }
                }
            }

            connection.Close();
        }
    }
}