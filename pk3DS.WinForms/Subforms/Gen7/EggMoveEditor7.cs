using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using pk3DS.WinForms.Properties;
using pk3DS.Core.Structures;
using pk3DS.Core;
using pk3DS.Core.Randomizers;

namespace pk3DS.WinForms
{
    public partial class EggMoveEditor7 : Form
    {
        public EggMoveEditor7(byte[][] infiles)
        {
            InitializeComponent();
            files = infiles;
            string[] species = Main.Config.GetText(TextName.SpeciesNames);
            string[][] AltForms = Main.Config.Personal.GetFormList(species, Main.Config.MaxSpeciesID);

            // Alt Forms
            if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7)
            {
                string[] temp = new string[species.Length];
                temp[0] = species[0];
                Array.Copy(Main.pokemonNameUSSC_Sim, 0, temp, 1, Main.pokemonNameUSSC_Sim.Length);

                AltForms = Main.Config.Personal.GetFormList(temp, Main.Config.MaxSpeciesID);
            }

            string[] specieslist = Main.Config.Personal.GetPersonalEntryList(AltForms, species, Main.Config.MaxSpeciesID, out _, out _);
            specieslist[0] = movelist[0] = "";

            SetupDGV();
            entries = infiles.Select(z => new EggMoves7(z)).ToArray();
            string[] names = new string[entries.Length];

            // Species
            for (int i = 0; i < species.Length; i++)
            {
                if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7 && i != 0)
                {
                    string[] temp = new string[species.Length];
                    temp[0] = species[0];
                    Array.Copy(Main.pokemonNameUSSC_Sim, 0, temp, 1, Main.pokemonNameUSSC_Sim.Length);

                    names[i] = temp[i];
                    int formoff = entries[i].FormTableIndex;
                    int count = Main.Config.Personal[i].FormeCount;
                    for (int j = 1; j < count; j++)
                    {
                        names[formoff + j - 1] ??= $"{temp[i]} [{AltForms[i][j].Replace(temp[i] + " ", "")}]";
                    }
                }
                else
                {
                    names[i] = species[i];
                    int formoff = entries[i].FormTableIndex;
                    int count = Main.Config.Personal[i].FormeCount;
                    for (int j = 1; j < count; j++)
                    {
                        names[formoff + j - 1] ??= $"{species[i]} [{AltForms[i][j].Replace(species[i] + " ", "")}]";
                    }
                }
            }

            var newlist = names.Select((_, i) => new ComboItem{Text = (names[i] ?? "Extra") + $" ({i})", Value = i});
            newlist = newlist.GroupBy(z => z.Text.StartsWith("Extra"))
                .Select(z => z.OrderBy(item => item.Text))
                .SelectMany(z => z).ToList();
            NUD_FormTable.Maximum = files.Length;

            CB_Species.DisplayMember = "Text";
            CB_Species.ValueMember = "Value";
            CB_Species.DataSource = newlist;

            CB_Species.SelectedIndex = 0;
            RandSettings.GetFormSettings(this, groupBox1.Controls);
        }

        private readonly EggMoves7[] entries;

        private readonly byte[][] files;
        private int entry = -1;
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private bool dumping;
        //private readonly int[] baseForms, formVal;

        private void SetupDGV()
        {
            string[] sortedmoves = (string[])movelist.Clone();
            Array.Sort(sortedmoves);
            DataGridViewComboBoxColumn dgvMove = new DataGridViewComboBoxColumn();
            {
                dgvMove.HeaderText = "招式";
                dgvMove.DisplayIndex = 0;
                for (int i = 0; i < movelist.Length; i++)
                    dgvMove.Items.Add(sortedmoves[i]); // add only the Names

                dgvMove.Width = 230;
                dgvMove.FlatStyle = FlatStyle.Flat;
            }
            dgv.Columns.Add(dgvMove);
        }

        private EggMoves pkm = new EggMoves7(Array.Empty<byte>());

        private void GetList()
        {
            entry = WinFormsUtil.GetIndex(CB_Species);
            int s = 0, f = 0;
            if (entry <= Main.Config.MaxSpeciesID)
            {
                s = entry;
            }
            int[] specForm = { s, f };
            //string filename = "_" + specForm[0] + (entry > Main.Config.MaxSpeciesID ? "_" + (specForm[1] + 1) : "");

            //DialogResult dialogResult = MessageBox.Show(filename + "");
            Bitmap rawImg = (Bitmap)Resources.ResourceManager.GetObject("_" + specForm[0]);
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

            dgv.Rows.Clear();
            pkm = entries[entry];

            //判断是否指定范围
            if (CHK_Expand.Checked)
            {
                pkm.Count = (int)NUD_Moves.Value;
            }

            NUD_FormTable.Value = pkm.FormTableIndex;
            if (pkm.Count < 1) { files[entry] = Array.Empty<byte>(); return; }
            dgv.Rows.Add(pkm.Count);

            // Fill Entries
            for (int i = 0; i < pkm.Count; i++)
                dgv.Rows[i].Cells[0].Value = movelist[pkm.Moves[i]];

            dgv.CancelEdit();
        }

        private void SetList()
        {
            if (entry < 1 || dumping) return;
            List<int> moves = new List<int>();
            for (int i = 0; i < dgv.Rows.Count - 1; i++)
            {
                int move = Array.IndexOf(movelist, dgv.Rows[i].Cells[0].Value);
                if (move > 0 && !moves.Contains((ushort)move)) moves.Add(move);
            }
            pkm.Moves = moves.ToArray();
            pkm.FormTableIndex = (int)NUD_FormTable.Value;

            entries[entry] = (EggMoves7)pkm;
        }

        private void ChangeEntry(object sender, EventArgs e)
        {
            CHK_Expand.Checked = false;
            SetList();
            GetList();
        }

        private void B_RandAll_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认随机化蛋招式？", "无法撤销！") != DialogResult.Yes) return;
            var sets = entries;
            var rand = new EggMoveRandomizer(Main.Config, sets)
            {
                Expand = CHK_Expand.Checked,
                ExpandTo = (int)NUD_Moves.Value,
                STAB = CHK_STAB.Checked,
                STABPercent = NUD_STAB.Value,
                BannedMoves = new[] { 165, 621, 464 }.Concat(Legal.Z_Moves).ToArray(), // Struggle, Hyperspace Fury, Dark Void
            };
            rand.Execute();
            sets.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();
            //CalcStats();
            //WinFormsUtil.Alert("全部宝可梦蛋招式已被随机化！");
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否导出全部蛋招式至TXT文件？"))
                return;

            dumping = true;
            string result = "";
            for (int i = 0; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species
                result += "======" + Environment.NewLine + entry + " " + CB_Species.Text + Environment.NewLine + "======" + Environment.NewLine;
                for (int j = 0; j < dgv.Rows.Count - 1; j++)
                    result += dgv.Rows[j].Cells[0].Value + Environment.NewLine;

                result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Egg Moves.txt", Filter = "Text File|*.txt"};

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
            entries.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            RandSettings.SetFormSettings(this, groupBox1.Controls);
        }

        private void B_Goto_Click(object sender, EventArgs e)
        {
            CB_Species.SelectedValue = (int)NUD_FormTable.Value;
        }

        public void CalcStats()
        {
            Move[] MoveData = Main.Config.Moves;
            int movectr = 0;
            int max = 0;
            int spec = 0;
            int stab = 0;
            for (int i = 0; i < Main.Config.MaxSpeciesID; i++)
            {
                byte[] movedata = files[i];
                int movecount = BitConverter.ToUInt16(movedata, 2);
                if (movecount == 65535)
                    continue;
                movectr += movecount; // Average Moves
                if (max < movecount) { max = movecount; spec = i; } // Max Moves (and species)
                for (int m = 0; m < movecount; m++)
                {
                    int move = BitConverter.ToUInt16(movedata, (m * 2) + 4);
                    if (Main.SpeciesStat[i].Types.Contains(MoveData[move].Type))
                        stab++;
                }
            }
            WinFormsUtil.Alert($"共指定蛋招式: {movectr}\r\n同属性增益计数: {stab}");
        }
    }
}