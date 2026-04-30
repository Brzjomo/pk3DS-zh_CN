using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;

using pk3DS.Core;
using pk3DS.Core.Structures;

namespace pk3DS.WinForms
{
    public partial class MaisonEditor6 : Form
    {
        public MaisonEditor6(byte[][] trd, byte[][] trp, bool super)
        {
            trFiles = trd;
            pkFiles = trp;
            Array.Resize(ref specieslist, Main.Config.MaxSpeciesID + 1);
            movelist[0] = specieslist[0] = itemlist[0] = "";

            trNames = Main.Config.GetText(super ? TextName.SuperTrainerNames : TextName.MaisonTrainerNames); Array.Resize(ref trNames, trFiles.Length);

            InitializeComponent();
            Setup();
        }

        private readonly byte[][] trFiles;
        private readonly string[] trNames;
        private readonly byte[][] pkFiles;
        private readonly string[] natures = Main.Config.GetText(TextName.Natures);
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private readonly string[] specieslist = Main.Config.GetText(TextName.SpeciesNames);
        private readonly string[] trClass = Main.Config.GetText(TextName.TrainerClasses);
        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private int trEntry = -1;
        private int pkEntry = -1;
        private bool dumping;
        private List<int> fullLegendary;
        private List<int> megaList;
        private HashSet<int> finalEvoSet;

        private static readonly Dictionary<int, int[]> MegaStoneDictionary = new()
        {
            // XY
            {003, new[] {659}}, {006, new[] {660, 678}}, {009, new[] {661}},
            {065, new[] {679}}, {094, new[] {656}}, {115, new[] {675}},
            {127, new[] {671}}, {130, new[] {676}}, {142, new[] {672}},
            {150, new[] {662, 663}}, {181, new[] {658}}, {212, new[] {670}},
            {214, new[] {680}}, {229, new[] {666}}, {248, new[] {669}},
            {257, new[] {664}}, {282, new[] {657}}, {303, new[] {681}},
            {306, new[] {667}}, {308, new[] {665}}, {310, new[] {682}},
            {354, new[] {668}}, {359, new[] {677}}, {380, new[] {684}},
            {381, new[] {685}}, {445, new[] {683}}, {448, new[] {673}},
            {460, new[] {674}},
            // ORAS
            {015, new[] {770}}, {018, new[] {762}}, {080, new[] {760}},
            {208, new[] {761}}, {254, new[] {753}}, {260, new[] {752}},
            {302, new[] {754}}, {319, new[] {759}}, {323, new[] {767}},
            {334, new[] {755}}, {362, new[] {763}}, {373, new[] {769}},
            {376, new[] {758}}, {428, new[] {768}}, {475, new[] {756}},
            {531, new[] {757}}, {719, new[] {764}},
        };

        private static readonly ushort[] BattleItems = {
            149, 155, 156, 157, 158, 159, // Sitrus & 50% HP recovery berries
            234, 235, 236, 237, 238, 239, 240, // Leftovers, Choice Band/Specs/Scarf, Toxic/Flame Orb, Life Orb
            242, 243, 244, 248, // Focus Sash, Focus Band, Bright Powder, Quick Claw
            270, 271, 272, 273, 276, 277, 278, // Rocky Helmet, Air Balloon, Red Card, Eject Button, Eviolite, Assault Vest, Safety Goggles
            298, // Expert Belt
        };

        private void Setup()
        {
            foreach (string s in trClass) CB_Class.Items.Add(s);
            foreach (string s in specieslist) CB_Species.Items.Add(s);
            foreach (string s in movelist) CB_Move1.Items.Add(s);
            foreach (string s in movelist) CB_Move2.Items.Add(s);
            foreach (string s in movelist) CB_Move3.Items.Add(s);
            foreach (string s in movelist) CB_Move4.Items.Add(s);
            foreach (string s in natures) CB_Nature.Items.Add(s);
            foreach (string s in itemlist) CB_Item.Items.Add(s);
            foreach (string s in trNames) CB_Trainer.Items.Add(s ?? "-- 未知 --");
            for (int i = 0; i < pkFiles.Length; i++) CB_Pokemon.Items.Add(i.ToString());

            CB_Trainer.SelectedIndex = 1;

            // Initialize legendary and mega lists
            var legendaryList = PokeData.getLegendaryList();
            var legalLegendary = Main.Config.USUM ? Legal.Legendary_USUM
                : Main.Config.SM ? Legal.Legendary_SM
                : Legal.Legendary_6;
            fullLegendary = legendaryList.Concat(legalLegendary).Distinct().ToList();
            megaList = PokeData.getMegaList();
            finalEvoSet = new HashSet<int>(Legal.FinalEvolutions_6);
        }

        private void ChangeTrainer(object sender, EventArgs e)
        {
            SetTrainer();
            trEntry = CB_Trainer.SelectedIndex;
            GetTrainer();
            if (GB_Trainer.Enabled)
                LB_Choices.SelectedIndex = 0;
        }

        private void ChangePokemon(object sender, EventArgs e)
        {
            SetPokemon();
            pkEntry = CB_Pokemon.SelectedIndex;
            GetPokemon();
        }

        private void GetTrainer()
        {
            if (trEntry < 0) return;

            // Get
            LB_Choices.Items.Clear();
            Maison6.Trainer tr = new Maison6.Trainer(trFiles[trEntry]);

            CB_Class.SelectedIndex = tr.Class;
            GB_Trainer.Enabled = tr.Count > 0;

            foreach (ushort Entry in tr.Choices)
                LB_Choices.Items.Add(Entry.ToString());
        }

        private void SetTrainer()
        {
            if (trEntry < 0 || !GB_Trainer.Enabled || dumping) return;
            // Gather
            Maison6.Trainer tr = new Maison6.Trainer
            {
                Class = (ushort) CB_Class.SelectedIndex,
                Count = (ushort) LB_Choices.Items.Count
            };
            tr.Choices = new ushort[tr.Count];
            for (int i = 0; i < tr.Count; i++)
                tr.Choices[i] = Convert.ToUInt16(LB_Choices.Items[i].ToString());
            Array.Sort(tr.Choices);
            trFiles[trEntry] = tr.Write();
        }

        private void GetPokemon()
        {
            if (pkEntry < 0 || dumping) return;
            Maison6.Pokemon pkm = new Maison6.Pokemon(pkFiles[pkEntry]);

            // Get
            CB_Move1.SelectedIndex = pkm.Moves[0];
            CB_Move2.SelectedIndex = pkm.Moves[1];
            CB_Move3.SelectedIndex = pkm.Moves[2];
            CB_Move4.SelectedIndex = pkm.Moves[3];
            CHK_HP.Checked = pkm.HP;
            CHK_ATK.Checked = pkm.ATK;
            CHK_DEF.Checked = pkm.DEF;
            CHK_Spe.Checked = pkm.SPE;
            CHK_SpA.Checked = pkm.SPA;
            CHK_SpD.Checked = pkm.SPD;
            CB_Nature.SelectedIndex = pkm.Nature;
            CB_Item.SelectedIndex = pkm.Item;

            CB_Species.SelectedIndex = pkm.Species; // Loaded last in order to refresh the sprite with all info.
            // Last 2 Bytes are unused.
        }

        private void SetPokemon()
        {
            if (pkEntry < 0 || dumping) return;

            // Each File is 16 Bytes.
            Maison6.Pokemon pkm = new Maison6.Pokemon(pkFiles[pkEntry])
            {
                Species = (ushort) CB_Species.SelectedIndex,
                HP = CHK_HP.Checked,
                ATK = CHK_ATK.Checked,
                DEF = CHK_DEF.Checked,
                SPE = CHK_Spe.Checked,
                SPA = CHK_SpA.Checked,
                SPD = CHK_SpD.Checked,
                Nature = (byte) CB_Nature.SelectedIndex,
                Item = (ushort) CB_Item.SelectedIndex,
                Moves =
                {
                    [0] = (ushort) CB_Move1.SelectedIndex,
                    [1] = (ushort) CB_Move2.SelectedIndex,
                    [2] = (ushort) CB_Move3.SelectedIndex,
                    [3] = (ushort) CB_Move4.SelectedIndex
                }
            };

            byte[] data = pkm.Write();
            pkFiles[pkEntry] = data;
        }

        private void ChangeSpecies(object sender, EventArgs e)
        {
            Bitmap rawImg = WinFormsUtil.GetSprite(CB_Species.SelectedIndex, 0, 0, CB_Item.SelectedIndex, Main.Config);
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
            PB_PKM.Image = bigImg;
        }

        private void B_Remove_Click(object sender, EventArgs e)
        {
            if (LB_Choices.SelectedIndex > -1 && GB_Trainer.Enabled)
                LB_Choices.Items.RemoveAt(LB_Choices.SelectedIndex);
        }

        private void B_Set_Click(object sender, EventArgs e)
        {
            if (LB_Choices.SelectedIndex <= -1 || !GB_Trainer.Enabled) return;

            int toAdd = CB_Pokemon.SelectedIndex;
            int count = LB_Choices.Items.Count;
            List<ushort> choices = new List<ushort>();
            for (int i = 0; i < count; i++)
                choices.Add(Convert.ToUInt16(LB_Choices.Items[i].ToString()));

            if (Array.IndexOf(choices.ToArray(), toAdd) > 0) return; // Abort if already in the list
            choices.Add((ushort)toAdd); // Add it to the list.

            // Get new list, and sort it.
            ushort[] choiceList = choices.ToArray(); Array.Sort(choiceList);

            // Set new list.
            LB_Choices.Items.Clear();
            foreach (ushort t in choiceList)
                LB_Choices.Items.Add(t.ToString());

            // Set current index to the one just added.
            LB_Choices.SelectedIndex = Array.IndexOf(choiceList, toAdd);
        }

        private void B_View_Click(object sender, EventArgs e)
        {
            if (LB_Choices.SelectedIndex > -1 && GB_Trainer.Enabled)
                CB_Pokemon.SelectedIndex = Convert.ToUInt16(LB_Choices.Items[LB_Choices.SelectedIndex].ToString());
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SetTrainer();
            SetPokemon();
        }

        private void DumpTRs_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认导出训练家信息至TXT文件？") != DialogResult.Yes) return;

            dumping = true;
            string result = "";
            for (int i = 0; i < CB_Trainer.Items.Count; i++)
            {
                CB_Trainer.SelectedIndex = i;
                int count = LB_Choices.Items.Count;
                if (count > 0)
                {
                    result += "======" + Environment.NewLine + i + " - (" + CB_Class.Text + ") " + CB_Trainer.Text + Environment.NewLine + "======" + Environment.NewLine;
                    result += "Choices: ";
                    for (int c = 0; c < count; c++)
                        result += LB_Choices.Items[c] + ", ";

                    result += Environment.NewLine; result += Environment.NewLine;
                }
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Maison Trainers.txt", Filter = "Text File|*.txt"};

            SystemSounds.Asterisk.Play();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string path = sfd.FileName;
                File.WriteAllText(path, result, Encoding.Unicode);
            }
            dumping = false;
            CB_Trainer.SelectedIndex = 0;
        }

        private void B_DumpPKs_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认导出宝可梦信息至TXT文件？") != DialogResult.Yes) return;

            string[] stats = {"HP", "ATK", "DEF", "Spe", "SpA", "SpD"};
            string result = "";
            for (int i = 0; i < pkFiles.Length; i++)
            {
                var pk = new Maison6.Pokemon(pkFiles[i]);
                if (pk.Species == 0)
                    continue;

                result += "======" + Environment.NewLine;
                result += $"{i} - {specieslist[pk.Species]}" + Environment.NewLine;
                result += "======" + Environment.NewLine;
                result += $"持有物品: {itemlist[pk.Item]}" + Environment.NewLine;
                result += $"特性: {natures[pk.Nature]}" + Environment.NewLine;
                result += $"招式 1: {movelist[pk.Move1]}" + Environment.NewLine;
                result += $"招式 2: {movelist[pk.Move2]}" + Environment.NewLine;
                result += $"招式 3: {movelist[pk.Move3]}" + Environment.NewLine;
                result += $"招式 4: {movelist[pk.Move4]}" + Environment.NewLine;

                var EVstr = string.Join(",", pk.EVs.Select((iv, x) => iv ? stats[x] : string.Empty).Where(x => !string.IsNullOrWhiteSpace(x)));
                result += $"EV'd in: {(pk.EVs.Length > 0 ? EVstr : "None")}" + Environment.NewLine;

                result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Maison Pokemon.txt", Filter = "Text File|*.txt"};

            if (sfd.ShowDialog() != DialogResult.OK)
                return;

            File.WriteAllText(sfd.FileName, result, Encoding.Unicode);
        }

        private void CHK_Smart_CheckedChanged(object sender, EventArgs e)
        {
            bool smart = CHK_Smart.Checked;
            CHK_Legendary.Enabled = smart;
            L_Legendary.Enabled = smart && CHK_Legendary.Checked;
            NUD_Legendary.Enabled = smart && CHK_Legendary.Checked;
        }

        private void CHK_Legendary_CheckedChanged(object sender, EventArgs e)
        {
            bool smart = CHK_Smart.Checked;
            L_Legendary.Enabled = smart && CHK_Legendary.Checked;
            NUD_Legendary.Enabled = smart && CHK_Legendary.Checked;
        }

        private void B_Randomize_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认随机化所有宝可梦？") != DialogResult.Yes)
                return;

            bool smart = CHK_Smart.Checked;
            bool allowLegendary = CHK_Legendary.Checked;
            int legendaryChance = (int)NUD_Legendary.Value;
            var rand = Random.Shared;
            int maxMove = Main.Config.Moves.Length - 1;
            int maxItem = itemlist.Length - 1;
            int maxSpecies = Main.Config.MaxSpeciesID;

            // Randomize all Pokemon entries
            for (int i = 0; i < pkFiles.Length; i++)
            {
                var pkm = new Maison6.Pokemon(pkFiles[i]);

                if (CHK_Species.Checked)
                {
                    ushort species;
                    if (smart)
                        species = GetSmartSpecies(allowLegendary, legendaryChance, rand, maxSpecies);
                    else
                        species = (ushort)rand.Next(1, maxSpecies + 1);
                    pkm.Species = species;
                }

                if (CHK_Moves.Checked)
                {
                    if (smart)
                    {
                        var moves = GetSmartMoves(pkm.Species, rand, maxMove);
                        for (int m = 0; m < 4; m++) pkm.Moves[m] = moves[m];
                    }
                    else
                    {
                        var movePool = new List<ushort>();
                        for (ushort m = 1; m <= maxMove; m++) movePool.Add(m);
                        for (int m = 0; m < 4 && movePool.Count > 0; m++)
                        {
                            int idx = rand.Next(movePool.Count);
                            pkm.Moves[m] = movePool[idx];
                            movePool.RemoveAt(idx);
                        }
                    }
                }

                if (CHK_Items.Checked)
                {
                    if (smart)
                        pkm.Item = GetSmartItem(pkm.Species, rand);
                    else
                        pkm.Item = (ushort)rand.Next(0, maxItem + 1);
                }

                if (CHK_Natures.Checked)
                {
                    if (smart)
                        pkm.Nature = GetSmartNature(pkm.Species, rand);
                    else
                        pkm.Nature = (byte)rand.Next(0, 25);
                }

                if (CHK_EVs.Checked)
                {
                    if (smart)
                        SetSmartEVs(pkm, rand);
                    else
                    {
                        for (int ev = 0; ev < 6; ev++)
                            pkm.EVs[ev] = rand.Next(2) == 0;
                    }
                }

                if (CHK_Form.Checked)
                    pkm.Form = 0; // No Mega forms, always base form

                pkFiles[i] = pkm.Write();
            }

            // Deduplicate: ensure no two entries are completely identical (species, moves, item, nature)
            bool canDeduplicate = CHK_Species.Checked || CHK_Moves.Checked || CHK_Items.Checked || CHK_Natures.Checked;
            if (canDeduplicate)
            {
                var seenKeys = new HashSet<(ushort, ushort, ushort, ushort, ushort, ushort, byte)>();
                for (int i = 0; i < pkFiles.Length; i++)
                {
                    var pkm = new Maison6.Pokemon(pkFiles[i]);
                    var key = (pkm.Species, pkm.Moves[0], pkm.Moves[1], pkm.Moves[2], pkm.Moves[3], pkm.Item, pkm.Nature);

                    for (int attempt = 0; attempt < 50 && !seenKeys.Add(key); attempt++)
                    {
                        if (CHK_Species.Checked)
                        {
                            ushort species;
                            if (smart)
                                species = GetSmartSpecies(allowLegendary, legendaryChance, rand, maxSpecies);
                            else
                                species = (ushort)rand.Next(1, maxSpecies + 1);
                            pkm.Species = species;
                        }
                        if (CHK_Moves.Checked)
                        {
                            if (smart)
                            {
                                var moves = GetSmartMoves(pkm.Species, rand, maxMove);
                                for (int m = 0; m < 4; m++) pkm.Moves[m] = moves[m];
                            }
                            else for (int m = 0; m < 4; m++)
                                pkm.Moves[m] = (ushort)rand.Next(1, maxMove + 1);
                        }
                        if (CHK_Items.Checked)
                        {
                            if (smart) pkm.Item = GetSmartItem(pkm.Species, rand);
                            else pkm.Item = (ushort)rand.Next(0, maxItem + 1);
                        }
                        if (CHK_Natures.Checked)
                        {
                            if (smart) pkm.Nature = GetSmartNature(pkm.Species, rand);
                            else pkm.Nature = (byte)rand.Next(0, 25);
                        }
                        key = (pkm.Species, pkm.Moves[0], pkm.Moves[1], pkm.Moves[2], pkm.Moves[3], pkm.Item, pkm.Nature);
                    }
                    pkFiles[i] = pkm.Write();
                }
            }

            // Randomize trainer choices if species were randomized
            if (CHK_Species.Checked)
            {
                // Build list of mega-capable Pokémon indices for smart mode
                List<int> megaPkIndices = null;
                if (smart)
                {
                    megaPkIndices = new List<int>();
                    for (int i = 0; i < pkFiles.Length; i++)
                    {
                        var pkm = new Maison6.Pokemon(pkFiles[i]);
                        if (megaList.Contains(pkm.Species))
                            megaPkIndices.Add(i);
                    }
                }

                for (int t = 0; t < trFiles.Length; t++)
                {
                    var tr = new Maison6.Trainer(trFiles[t]);
                    if (tr.Count > 0)
                    {
                        if (smart && megaPkIndices.Count > 0)
                        {
                            int megaCount = Math.Max(1, tr.Count / 10);
                            megaCount = Math.Min(megaCount, megaPkIndices.Count);
                            var choices = new List<ushort>();
                            for (int c = 0; c < megaCount; c++)
                                choices.Add((ushort)megaPkIndices[rand.Next(megaPkIndices.Count)]);
                            for (int c = megaCount; c < tr.Count; c++)
                                choices.Add((ushort)rand.Next(pkFiles.Length));
                            tr.Choices = choices.ToArray();
                        }
                        else
                        {
                            for (int c = 0; c < tr.Count; c++)
                                tr.Choices[c] = (ushort)rand.Next(pkFiles.Length);
                        }
                        Array.Sort(tr.Choices);
                        trFiles[t] = tr.Write();
                    }
                }
            }

            // Refresh UI
            if (pkEntry >= 0) GetPokemon();
            if (trEntry >= 0) GetTrainer();

            WinFormsUtil.Alert("随机化完成！");
        }

        #region Smart Randomization Helpers

        private ushort GetSmartSpecies(bool allowLegendary, int legendaryChance, Random rand, int maxSpecies)
        {
            var candidates = new List<(int species, int bst)>();

            for (int i = 1; i <= maxSpecies; i++)
            {
                if (!finalEvoSet.Contains(i)) continue;

                bool isLegendary = fullLegendary.Contains(i);
                if (!allowLegendary && isLegendary) continue;

                int bst = Main.Config.Personal.Table[i].BST;
                candidates.Add((i, bst));
            }

            if (candidates.Count == 0)
                return 1;

            if (allowLegendary)
            {
                var normal = candidates.Where(c => !fullLegendary.Contains(c.species)).ToList();
                var legendary = candidates.Where(c => fullLegendary.Contains(c.species)).ToList();

                List<(int species, int bst)> pool;
                if (legendary.Count > 0 && rand.Next(100) < legendaryChance)
                    pool = legendary;
                else
                    pool = normal;

                if (pool.Count == 0)
                    pool = normal.Count > 0 ? normal : candidates;

                return WeightedRandom(pool, rand);
            }

            return WeightedRandom(candidates, rand);
        }

        private static ushort WeightedRandom(List<(int species, int bst)> candidates, Random rand)
        {
            int[] weights = candidates.Select(c => c.bst * c.bst).ToArray();
            int totalWeight = weights.Sum();
            if (totalWeight <= 0)
                return (ushort)candidates[0].species;

            int roll = rand.Next(totalWeight);
            int cumulative = 0;
            for (int i = 0; i < candidates.Count; i++)
            {
                cumulative += weights[i];
                if (roll < cumulative)
                    return (ushort)candidates[i].species;
            }
            return (ushort)candidates[^1].species;
        }

        private static ushort[] GetSmartMoves(int species, Random rand, int maxMove)
        {
            var pi = Main.Config.Personal.Table[species];
            var types = pi.Types;
            int maxMoveId = Math.Min(maxMove, Main.Config.Moves.Length - 1);

            // Categorize moves by type match and physical/special category
            var typePhys = new List<ushort>();
            var typeSpec = new List<ushort>();
            var typeStatus = new List<ushort>();
            var anyPhys = new List<ushort>();
            var anySpec = new List<ushort>();
            var anyMoves = new List<ushort>();

            for (ushort m = 1; m <= maxMoveId; m++)
            {
                var move = Main.Config.Moves[m];
                if (move == null) continue;

                anyMoves.Add(m);
                if (move.Category == 1) anyPhys.Add(m);
                else if (move.Category == 2) anySpec.Add(m);

                if (types.Contains(move.Type))
                {
                    if (move.Category == 1) typePhys.Add(m);
                    else if (move.Category == 2) typeSpec.Add(m);
                    else typeStatus.Add(m);
                }
            }

            // Determine physical vs special preference from base stats
            bool preferPhys = pi.ATK > pi.SPA;
            bool preferSpec = pi.SPA > pi.ATK;

            var result = new ushort[4];
            int attackCount = 0;

            for (int i = 0; i < 4; i++)
            {
                ushort selected = 0;
                bool needAttack = attackCount < 2;

                // Priority 1: Pick attacking move, preferring type-matched + BST-favored category
                if (needAttack)
                {
                    if (preferPhys)
                    {
                        if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                        else if (anyPhys.Count > 0) selected = PickRandomRemove(anyPhys, rand);
                        else if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                        else if (anySpec.Count > 0) selected = PickRandomRemove(anySpec, rand);
                    }
                    else if (preferSpec)
                    {
                        if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                        else if (anySpec.Count > 0) selected = PickRandomRemove(anySpec, rand);
                        else if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                        else if (anyPhys.Count > 0) selected = PickRandomRemove(anyPhys, rand);
                    }
                    else
                    {
                        if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                        else if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                        else if (anyPhys.Count > 0) selected = PickRandomRemove(anyPhys, rand);
                        else if (anySpec.Count > 0) selected = PickRandomRemove(anySpec, rand);
                    }
                }

                // Priority 2: Type-matched move (70% chance), with BST preference
                if (selected == 0 && rand.Next(100) < 70)
                {
                    if (preferPhys)
                    {
                        if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                        else if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                    }
                    else if (preferSpec)
                    {
                        if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                        else if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                    }
                    else
                    {
                        if (typePhys.Count > 0) selected = PickRandomRemove(typePhys, rand);
                        else if (typeSpec.Count > 0) selected = PickRandomRemove(typeSpec, rand);
                    }

                    if (selected == 0 && typeStatus.Count > 0)
                        selected = PickRandomRemove(typeStatus, rand);
                }

                // Priority 3: Any remaining move
                if (selected == 0 && anyMoves.Count > 0)
                    selected = PickRandomRemove(anyMoves, rand);

                if (selected == 0) break;

                // Remove from all tracking lists
                anyMoves.Remove(selected);
                anyPhys.Remove(selected);
                anySpec.Remove(selected);
                typePhys.Remove(selected);
                typeSpec.Remove(selected);
                typeStatus.Remove(selected);

                result[i] = selected;
                if (Main.Config.Moves[selected].Category != 0)
                    attackCount++;
            }

            return result;
        }

        private static ushort PickRandomRemove(List<ushort> list, Random rand)
        {
            int idx = rand.Next(list.Count);
            ushort val = list[idx];
            list.RemoveAt(idx);
            return val;
        }

        private static ushort GetSmartItem(int species, Random rand)
        {
            if (MegaStoneDictionary.TryGetValue(species, out var stones) && rand.Next(100) < 90)
                return (ushort)stones[rand.Next(stones.Length)];

            return BattleItems[rand.Next(BattleItems.Length)];
        }

        private static byte GetSmartNature(int species, Random rand)
        {
            var pi = Main.Config.Personal.Table[species];
            int[] baseStats = { pi.ATK, pi.DEF, pi.SPE, pi.SPA, pi.SPD };

            int bestIdx = 0, worstIdx = 0;
            for (int i = 1; i < baseStats.Length; i++)
            {
                if (baseStats[i] > baseStats[bestIdx]) bestIdx = i;
                if (baseStats[i] < baseStats[worstIdx]) worstIdx = i;
            }

            if (bestIdx == worstIdx)
                return (byte)rand.Next(0, 25);

            int nature = 5 * bestIdx + worstIdx;
            return (byte)nature;
        }

        private static void SetSmartEVs(Maison6.Pokemon pkm, Random rand)
        {
            var pi = Main.Config.Personal.Table[pkm.Species];
            int[] stats = { pi.HP, pi.ATK, pi.DEF, pi.SPE, pi.SPA, pi.SPD };

            var ranked = stats.Select((v, i) => (value: v, index: i))
                .OrderByDescending(x => x.value)
                .ToList();

            pkm.EVs[ranked[0].index] = true;
            pkm.EVs[ranked[1].index] = rand.NextDouble() < 0.8;
            pkm.EVs[ranked[2].index] = rand.NextDouble() < 0.5;
            pkm.EVs[ranked[3].index] = rand.NextDouble() < 0.15;
            pkm.EVs[ranked[4].index] = rand.NextDouble() < 0.15;
            pkm.EVs[ranked[5].index] = rand.NextDouble() < 0.15;
        }

        #endregion
    }
}