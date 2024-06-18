using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using System.Windows.Forms;
using pk3DS.WinForms.Properties;
using pk3DS.Core;
using pk3DS.Core.Randomizers;
using pk3DS.Core.Structures;

namespace pk3DS.WinForms
{
    public partial class EvolutionEditor6 : Form
    {
        public EvolutionEditor6(byte[][] infiles)
        {
            files = infiles;
            InitializeComponent();

            specieslist[0] = movelist[0] = itemlist[0] = "";
            Array.Resize(ref specieslist, Main.Config.MaxSpeciesID + 1);

            string[] evolutionMethods =
            {
                "",
                "友好度进化",
                "白天友好度进化",
                "夜晚友好度进化",
                "升级",
                "通讯进化",
                "持有物品时通讯进化",
                $"互换通讯进化 {specieslist[588]}/{specieslist[616]}", // Shelmet&Karrablast
                "使用物品",
                "升级 (攻击 > 防御)",
                "升级 (攻击 = 防御)",
                "升级 (攻击 < 防御)",
                "升级 (任意能力值 < 5)",
                "升级 (任意能力值 > 5)",
                $"升级 ({specieslist[291]})", // Ninjask
                $"升级 ({specieslist[292]})", // Shedinja
                "升级 (美丽度)",
                "使用物品 (雄性)", // Kirlia->Gallade
                "使用物品 (雌性)", // Snorunt->Froslass
                "持有物品时升级 (白天)",
                "持有物品时升级 (夜晚)",
                "习得招式时升级",
                "队伍中存在指定宝可梦时升级",
                "雄性升级",
                "雌性升级",
                "电气场地升级",
                "森林中升级",
                "寒冷地带升级",
                "翻盖3DS时升级",
                "满50友好度并学会指定属性招式",
                $"队伍中存在 {typelist[16]} 属性",
                "下雨天",
                "白天升级",
                "夜晚升级",
                "雌性升级 (SetForm 1)",
            };

            mb = new[] { CB_M1, CB_M2, CB_M3, CB_M4, CB_M5, CB_M6, CB_M7, CB_M8 };
            pb = new[] { CB_P1, CB_P2, CB_P3, CB_P4, CB_P5, CB_P6, CB_P7, CB_P8 };
            rb = new[] { CB_I1, CB_I2, CB_I3, CB_I4, CB_I5, CB_I6, CB_I7, CB_I8 };
            pic = new[] { PB_1, PB_2, PB_3, PB_4, PB_5, PB_6, PB_7, PB_8 };

            foreach (ComboBox cb in mb) { foreach (string s in evolutionMethods) cb.Items.Add(s); }
            foreach (ComboBox cb in rb) { foreach (string s in specieslist) cb.Items.Add(s); }

            CB_Species.Items.Clear();
            foreach (string s in specieslist) CB_Species.Items.Add(s);

            CB_Species.SelectedIndex = 1;
            RandSettings.GetFormSettings(this, GB_Randomizer.Controls);
        }

        private readonly byte[][] files;
        private readonly ComboBox[] pb;
        private readonly ComboBox[] rb;
        private readonly ComboBox[] mb;
        private readonly PictureBox[] pic;
        private int entry = -1;
        private readonly string[] specieslist = Main.Config.GetText(TextName.SpeciesNames);
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private readonly string[] typelist = Main.Config.GetText(TextName.Types);
        private bool dumping;
        private EvolutionSet evo = new EvolutionSet6(new byte[EvolutionSet6.SIZE]);

        private void GetList()
        {
            entry = Array.IndexOf(specieslist, CB_Species.Text);
            byte[] input = files[entry];
            if (input.Length != EvolutionSet6.SIZE) return; // error
            evo = new EvolutionSet6(input);

            for (int i = 0; i < evo.PossibleEvolutions.Length; i++)
            {
                if (evo.PossibleEvolutions[i].Method > 34) return; // Invalid!

                mb[i].SelectedIndex = evo.PossibleEvolutions[i].Method; // Which will trigger the params cb to reload the valid params list
                pb[i].SelectedIndex = evo.PossibleEvolutions[i].Argument;
                rb[i].SelectedIndex = evo.PossibleEvolutions[i].Species;
            }
        }

        private void SetList()
        {
            if (entry < 1 || dumping) return;

            for (int i = 0; i < 8; i++)
            {
                evo.PossibleEvolutions[i].Method = mb[i].SelectedIndex;
                evo.PossibleEvolutions[i].Argument = pb[i].SelectedIndex;
                evo.PossibleEvolutions[i].Species = rb[i].SelectedIndex;
            }
            files[entry] = evo.Write();
        }

        private void ChangeEntry(object sender, EventArgs e)
        {
            SetList();
            GetList();
        }

        private void B_RandAll_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否随机全部宝可梦？", "进化方式和进化条件将保持不变。"))
                return;

            SetList();
            // Set up advanced randomization options
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.rBST = CHK_BST.Checked;
            evoRand.Randomizer.rEXP = CHK_Exp.Checked;
            evoRand.Randomizer.rType = CHK_Type.Checked;
            evoRand.Randomizer.L = CHK_L.Checked;
            evoRand.Randomizer.E = CHK_E.Checked;
            evoRand.Randomizer.Initialize();
            evoRand.Execute();
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();

            WinFormsUtil.Alert("宝可梦进化已全部随机！");
        }

        private void B_Trade_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否移除全部通讯进化？", "通讯进化方式将会被替代，以便单人游戏也可进化。"))
                return;

            SetList();
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.Initialize();
            evoRand.ExecuteTrade();
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();

            WinFormsUtil.Alert("已移除全部通讯进化！", "通讯进化将在到达指定等级，或持有相关道具并升级时进行。");
        }

        private void B_EveryLevel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否确认修改？", "你的宝可梦每次升级都会进化为随机的宝可梦。"))
                return;

            SetList();
            var evos = files.Select(z => new EvolutionSet6(z)).ToArray();
            var evoRand = new EvolutionRandomizer(Main.Config, evos);
            evoRand.Randomizer.rBST = CHK_BST.Checked;
            evoRand.Randomizer.rEXP = CHK_Exp.Checked;
            evoRand.Randomizer.rType = CHK_Type.Checked;
            evoRand.Randomizer.L = CHK_L.Checked;
            evoRand.Randomizer.E = CHK_E.Checked;
            evoRand.Randomizer.Initialize();
            evoRand.ExecuteEvolveEveryLevel();
            evoRand.Execute(); // randomize right after
            evos.Select(z => z.Write()).ToArray().CopyTo(files, 0);
            GetList();
            SystemSounds.Asterisk.Play();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否导出所有进化到TXT文本？"))
                return;

            dumping = true;
            string result = "";
            for (int i = 0; i < CB_Species.Items.Count; i++)
            {
                CB_Species.SelectedIndex = i; // Get new Species
                result += "======" + Environment.NewLine + entry + " " + CB_Species.Text + Environment.NewLine + "======" + Environment.NewLine;
                for (int j = 0; j < 8; j++)
                {
                    int methodval = mb[j].SelectedIndex;
                    // int param = pb[j].SelectedIndex;
                    int poke = rb[j].SelectedIndex;
                    if (poke > 0 && methodval > 0)
                        result += mb[j].Text + (pb[j].Visible ? " [" + pb[j].Text + "]" : "") + " 进化 " + rb[j].Text + Environment.NewLine;
                }

                result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Evolutions.txt", Filter = "Text File|*.txt"};

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
            RandSettings.SetFormSettings(this, GB_Randomizer.Controls);
        }

        private void ChangeMethod(object sender, EventArgs e)
        {
            int op = Array.IndexOf(mb, sender as ComboBox);
            ushort[] methodCase =
            {
                0,0,0,0,1,0,2,0,2,1,1,1,1,1,1,1,5,2,2,2,2,3,4,1,1,0,0,0, // 27, Past Methods
                // New Methods
                1, // 28 - Dark Type Party
                6, // 29 - Affection + MoveType
                1, // 30 - UpsideDown 3DS
                1, // 31 - Overworld Rain
                1, // 32 - Level @ Day
                1, // 33 - Level @ Night
                1, // 34 - Gender Branch
            };

            pb[op].Visible = pic[op].Visible = rb[op].Visible = mb[op].SelectedIndex > 0;

            pb[op].Items.Clear();
            int cv = methodCase[mb[op].SelectedIndex];
            switch (cv)
            {
                case 0: // No Parameter Required
                    { pb[op].Visible = false; pb[op].Items.Add(""); break; }
                case 1: // Level
                    { for (int i = 0; i <= 100; i++) pb[op].Items.Add(i.ToString()); break; }
                case 2: // Items
                    {  foreach (string t in itemlist) pb[op].Items.Add(t); break; }
                case 3: // Moves
                    { foreach (string t in movelist) pb[op].Items.Add(t); break; }
                case 4: // Species
                    { foreach (string t in specieslist) pb[op].Items.Add(t); break; }
                case 5: // 0-255 (Beauty)
                    { for (int i = 0; i <= 255; i++) pb[op].Items.Add(i.ToString()); break; }
                case 6:
                    { foreach (string t in typelist) pb[op].Items.Add(t); break; }
            }
            pb[op].SelectedIndex = 0;
        }

        private void ChangeInto(object sender, EventArgs e)
        {
            if (sender is not ComboBox cb)
                return;

            Bitmap rawImg = (Bitmap)Resources.ResourceManager.GetObject("_" + Array.IndexOf(specieslist, cb.Text));
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
            pic[Array.IndexOf(rb, cb)].Image = bigImg;
        }

        private void ImgChangeInto(object sender, EventArgs e)
        {
            SetList();
            GetList();

            Bitmap rawImg = (Bitmap)Resources.ResourceManager.GetObject("_" + Array.IndexOf(specieslist, CB_Species.Text));
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
            PB_TOP.Image = bigImg;
        }
    }
}
