using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

using pk3DS.Properties;

using pk3DS.Core.Structures;
using pk3DS.Core;
using pk3DS.Core.Randomizers;

namespace pk3DS
{
    public partial class LevelUpEditor7 : Form
    {
        public LevelUpEditor7(byte[][] infiles)
        {
            InitializeComponent();
            files = infiles;
            string[] species = Main.Config.GetText(TextName.SpeciesNames);
            string[][] AltForms = Main.Config.Personal.GetFormList(species, Main.Config.MaxSpeciesID);
            string[] specieslist = Main.Config.Personal.GetPersonalEntryList(AltForms, species, Main.Config.MaxSpeciesID, out baseForms, out formVal);
            specieslist[0] = movelist[0] = "";

            string[] sortedspecies = (string[])specieslist.Clone();
            Array.Resize(ref sortedspecies, Main.Config.MaxSpeciesID + 1); Array.Sort(sortedspecies);
            SetupDGV();

            var newlist = new List<ComboItem>();
            // add all species
            for (int i = 1; i <= Main.Config.MaxSpeciesID; i++)
            {
                if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7 && i != 0)
                {
                    newlist.Add(new ComboItem {
                        Text = Main.pokemonNameUSSC[i - 1],
                        Value = i
                    });
                }
                else
                {
                    newlist.Add(new ComboItem { Text = sortedspecies[i], Value = Array.IndexOf(specieslist, sortedspecies[i]) });
                }
            }
            // add all forms
            for (int i = Main.Config.MaxSpeciesID + 1; i < specieslist.Length; i++)
            {
                if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7 && i != 0)
                {
                    newlist.Add(new ComboItem
                    {
                        Text = Main.pokemonNameUSSC[i - 1],
                        Value = i
                    });
                }
                else
                {
                    newlist.Add(new ComboItem { Text = specieslist[i], Value = i });
                }
            }
                

            CB_Species.DisplayMember = "Text";
            CB_Species.ValueMember = "Value";
            CB_Species.DataSource = newlist;
            CB_Species.SelectedIndex = 0;
            RandSettings.GetFormSettings(this, groupBox1.Controls);

            new ToolTip().SetToolTip(L_STAB, "同属性招式几率");
        }

        private readonly byte[][] files;
        private int entry = -1;
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private bool dumping;
        private readonly int[] baseForms, formVal;

        private void SetupDGV()
        {
            string[] sortedmoves = (string[])movelist.Clone();
            Array.Sort(sortedmoves);
            DataGridViewColumn dgvLevel = new DataGridViewTextBoxColumn();
            {
                dgvLevel.HeaderText = "等级";
                dgvLevel.DisplayIndex = 0;
                dgvLevel.Width = 70;
                dgvLevel.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            DataGridViewComboBoxColumn dgvMove = new DataGridViewComboBoxColumn();
            {
                dgvMove.HeaderText = "招式";
                dgvMove.DisplayIndex = 1;
                for (int i = 0; i < movelist.Length; i++)
                    dgvMove.Items.Add(sortedmoves[i]); // add only the Names

                dgvMove.Width = 230;
                dgvMove.FlatStyle = FlatStyle.Flat;
            }
            dgv.Columns.Add(dgvLevel);
            dgv.Columns.Add(dgvMove);
        }

        private Learnset pkm;

        private void GetList()
        {
            entry = WinFormsUtil.GetIndex(CB_Species);
            int s = baseForms[entry];
            int f = formVal[entry];
            if (entry <= Main.Config.MaxSpeciesID)
                s = entry;
            int[] specForm = { s, f };
            string filename = "_" + specForm[0] + (entry > Main.Config.MaxSpeciesID ? "_" + (specForm[1] + 1) : "");

            Bitmap rawImg = (Bitmap)Resources.ResourceManager.GetObject(filename);
            if (rawImg != null)
            {
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
            } else
            {
                PB_MonSprite.Image = (Bitmap)Resources.ResourceManager.GetObject(filename);
            }

            dgv.Rows.Clear();
            byte[] input = files[entry];
            if (input.Length <= 4) { files[entry] = BitConverter.GetBytes(-1); return; }
            pkm = new Learnset6(input);

            //判断是否指定范围
            if (CHK_Expand.Checked)
            {
                //最大值为25，超过该值，进游戏黑屏
                pkm.Count = (int)NUD_Moves.Value;
            }

            dgv.Rows.Add(pkm.Count);

            // Fill Entries
            for (int i = 0; i < pkm.Count; i++)
            {
                dgv.Rows[i].Cells[0].Value = pkm.Levels[i];
                dgv.Rows[i].Cells[1].Value = movelist[pkm.Moves[i]];
            }

            dgv.CancelEdit();
        }

        private void SetList()
        {
            if (entry < 1 || dumping) return;
            List<int> moves = new List<int>();
            List<int> levels = new List<int>();
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                int move = Array.IndexOf(movelist, dgv.Rows[i].Cells[1].Value);
                if (move < 1) continue;

                moves.Add((short)move);
                string level = (dgv.Rows[i].Cells[0].Value ?? 0).ToString();
                short.TryParse(level, out var lv);
                if (lv > 100) lv = 100;
                levels.Add(lv);
            }
            pkm.Moves = moves.ToArray();
            pkm.Levels = levels.ToArray();
            files[entry] = pkm.Write();
        }

        private void ChangeEntry(object sender, EventArgs e)
        {
            if (CHK_Expand.Checked)
            {
                CHK_Expand.Checked = false;
            }
            SetList();
            GetList();
        }

        private void B_RandAll_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认随机化升级招式？", "无法撤销。") != DialogResult.Yes) return;

            SetList();
            var sets = files.Select(z => new Learnset6(z)).ToArray();
            var banned = new List<int>(new[] {165, 621, 464}.Concat(Legal.Z_Moves)); // Struggle, Hyperspace Fury, Dark Void
            if (CHK_NoFixedDamage.Checked)
                banned.AddRange(MoveRandomizer.FixedDamageMoves);

            var rand = new LearnsetRandomizer(Main.Config, sets)
            {
                Expand = CHK_Expand.Checked,
                ExpandTo = (int) NUD_Moves.Value,
                Spread = CHK_Spread.Checked,
                SpreadTo = (int) NUD_Level.Value,
                STAB = CHK_STAB.Checked,
                STABPercent = NUD_STAB.Value,
                STABFirst = CHK_STAB.Checked,
                BannedMoves = banned,
                Learn4Level1 = CHK_4MovesLvl1.Checked,
            };
            rand.Execute();
            sets.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();
            //WinFormsUtil.Alert("已随机化全部宝可梦的升级招式！");
            CalcStats();
        }

        private void B_Metronome_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否使用挥指模式？", "这将导致宝可梦只能学习挥指。") != DialogResult.Yes) return;

            CHK_Expand.Checked = false;

            // clear all data, then only assign Metronome at Lv1
            for (int i = 0; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i;
                dgv.Rows.Clear();
                dgv.Rows.Add();
                dgv.Rows[0].Cells[0].Value = 1;
                dgv.Rows[0].Cells[1].Value = movelist[118];
            }
            CB_Species.SelectedIndex = 0;
            WinFormsUtil.Alert("现在所有宝可梦都只会挥指！");
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否导出所有升级招式至TXT文件？"))
                return;

            dumping = true;
            string result = "";
            for (int i = 0; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species
                result += "======" + Environment.NewLine + entry + " " + CB_Species.Text + Environment.NewLine + "======" + Environment.NewLine;
                for (int j = 0; j < dgv.Rows.Count - 1; j++)
                    result += $"{dgv.Rows[j].Cells[0].Value} - {dgv.Rows[j].Cells[1].Value + Environment.NewLine}";

                result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Level Up Moves.txt", Filter = "Text File|*.txt"};

            SystemSounds.Asterisk.Play();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                File.WriteAllText(path, result, Encoding.Unicode);
            }
            dumping = false;
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SetList();
            RandSettings.SetFormSettings(this, groupBox1.Controls);
        }

        private void CHK_TypeBias_CheckedChanged(object sender, EventArgs e)
        {
            NUD_STAB.Enabled = CHK_STAB.Checked;
            NUD_STAB.Value = CHK_STAB.Checked ? 52 : NUD_STAB.Minimum;
        }

        public void CalcStats() // Debug Function
        {
            Move[] MoveData = Main.Config.Moves;
            int movectr = 0;
            int max = 0;
            int spec = 0;
            int stab = 0;
            for (int i = 0; i < Main.Config.MaxSpeciesID; i++)
            {
                byte[] movedata = files[i];
                int movecount = (movedata.Length - 4) / 4;
                if (movecount == 65535)
                    continue;
                movectr += movecount; // Average Moves
                if (max < movecount) { max = movecount; spec = i; } // Max Moves (and species)
                for (int m = 0; m < movedata.Length / 4; m++)
                {
                    int move = BitConverter.ToUInt16(movedata, m*4);
                    if (move == 65535)
                    {
                        movectr--;
                        continue;
                    }
                    if (Main.SpeciesStat[i].Types.Contains(MoveData[move].Type))
                        stab++;
                }
            }
            WinFormsUtil.Alert($"共习得招式: {movectr}\r\n单个宝可梦最大招式习得数: {max}\r\n同属性增益计数: {stab}");
        }
    }
}
