using pk3DS.Core;
using System;
using System.Linq;
using System.Windows.Forms;
using pk3DS.Core.Structures;

namespace pk3DS.WinForms
{
    public partial class MoveEditor7 : Form
    {
        public MoveEditor7(byte[][] infiles)
        {
            files = infiles;
            movelist[0] = "";

            InitializeComponent();
            Setup();
            RandSettings.GetFormSettings(this, groupBox1.Controls);
        }

        private readonly byte[][] files;
        private readonly string[] types = Main.Config.GetText(TextName.Types);
        private readonly string[] moveflavor = Main.Config.GetText(TextName.MoveFlavor);
        private readonly string[] movelist = Main.Config.GetText(TextName.MoveNames);
        private readonly string[] MoveCategories = { "变化", "物理", "特殊", };
        private readonly string[] StatCategories = { "无", "物攻", "物防", "特攻", "特防", "速度", "命中", "闪避", "全部", };

        private static readonly string[] TargetingTypes =
        {
            "单个相邻的同伴/敌人",
            "任何同伴", "任何相邻的同伴", "单个相邻的敌人", "除玩家外的所有人", "所有敌人",
            "所有同伴", "自身", "场上所有宝可梦", "单个相邻的敌人 (2)", "整个场地",
            "对方的场地", "玩家的场地", "自身",
        };

        private static readonly string[] InflictionTypes =
        {
            "无",
            "麻痹", "睡眠", "冰冻", "灼伤", "中毒/剧毒",
            "混乱", "着迷", "束缚", "恶梦", "诅咒",
            "挑衅", "无理取闹", "定身法", "瞌睡", "回复封锁",
            "?", "被识破", "寄生种子", "查封", "灭亡之歌",
            "扎根", "??? 0x16", "??? 0x17", "Mute"
        };

        private static readonly string[] MoveQualities =
        {
            "纯伤害",
            "无伤害 -> 给予异常状态", "无伤害 -> 减益目标/增益玩家", "无伤害 | 治疗玩家", "伤害 | 给予异常状态", "无伤害 | 给予异常状态 | 增益目标",
            "伤害 | 减益目标", "伤害 | 增益玩家", "伤害 | 吸收伤害", "一击必杀", "影响整个场地",
            "影响一半场地", "强制目标交换宝可梦", "独特的效果",
        };

        private static readonly string[] ZMoveEffects =
        {
            "无",
            "+1 物攻",
            "+2 物攻",
            "+3 物攻",
            "+1 物防",
            "+2 物防",
            "+3 物防",
            "+1 特攻",
            "+2 特攻",
            "+3 特攻",
            "+1 特防",
            "+2 特防",
            "+3 特防",
            "+1 速度",
            "+2 速度",
            "+3 速度",
            "+1 命中",
            "+2 命中",
            "+3 命中",
            "+1 闪避",
            "+2 闪避",
            "+3 闪避",
            "+1 全部能力值 (除了命中或闪避)",
            "+2 全部能力值 (除了命中或闪避)",
            "+3 全部能力值 (除了命中或闪避)",
            "击中要害提升2级",
            "重置玩家被降低的能力值",
            "回复玩家全部HP",
            "回复玩家全部上场过的宝可梦 (临别礼物和抛下狠话)",
            "使玩家万众瞩目",
            "诅咒状态下: 幽灵属性宝可梦回复全部HP, 其他属性加1级物攻"
        };

        private void Setup()
        {
            char[] ps = { 'P', 'S' }; // Distinguish Physical/Special Z-Moves
            for (int i = 622; i < 658; i++)
                movelist[i] += $" ({ps[i % 2]})";
            CB_Move.Items.AddRange(movelist);
            CB_Type.Items.AddRange(types);
            CB_Category.Items.AddRange(MoveCategories);
            CB_Stat1.Items.AddRange(StatCategories);
            CB_Stat2.Items.AddRange(StatCategories);
            CB_Stat3.Items.AddRange(StatCategories);
            CB_Targeting.Items.AddRange(TargetingTypes);
            CB_Quality.Items.AddRange(MoveQualities);
            CB_Inflict.Items.AddRange(InflictionTypes);
            CB_ZMove.Items.AddRange(movelist);
            var flagnames = Enum.GetNames(typeof(MoveFlag7)).Skip(1).ToArray();
            CLB_Flags.Items.AddRange(flagnames);
            CB_ZEffect.Items.AddRange(ZMoveEffects);
            CB_Inflict.Items.Add("特殊");
            var refreshtypes = Enum.GetNames(typeof(RefreshType));
            CB_AfflictRefresh.Items.AddRange(refreshtypes);

            CB_Move.Items.RemoveAt(0);
            CB_Move.SelectedIndex = 0;
        }

        private int entry = -1;

        private void ChangeEntry(object sender, EventArgs e)
        {
            SetEntry();
            entry = Array.IndexOf(movelist, CB_Move.Text);
            GetEntry();
        }

        private void GetEntry()
        {
            if (entry < 1) return;
            byte[] data = files[entry];
            {
                RTB.Text = moveflavor[entry].Replace("\\n", Environment.NewLine);

                CB_Type.SelectedIndex = data[0x00];
                CB_Quality.SelectedIndex = data[0x01];
                CB_Category.SelectedIndex = data[0x02];
                NUD_Power.Value = data[0x3];
                NUD_Accuracy.Value = data[0x4];
                NUD_PP.Value = data[0x05];
                NUD_Priority.Value = (sbyte)data[0x06];
                NUD_HitMin.Value = data[0x7] & 0xF;
                NUD_HitMax.Value = data[0x7] >> 4;
                short inflictVal = BitConverter.ToInt16(data, 0x08);
                CB_Inflict.SelectedIndex = inflictVal < 0 ? CB_Inflict.Items.Count - 1 : inflictVal;
                NUD_Inflict.Value = data[0xA];
                NUD_0xB.Value = data[0xB]; // 0xB ~ Something to deal with skipImmunity
                NUD_TurnMin.Value = data[0xC];
                NUD_TurnMax.Value = data[0xD];
                NUD_CritStage.Value = data[0xE];
                NUD_Flinch.Value = data[0xF];
                NUD_Effect.Value = BitConverter.ToUInt16(data, 0x10);
                NUD_Recoil.Value = (sbyte)data[0x12];
                NUD_Heal.Value = data[0x13];

                CB_Targeting.SelectedIndex = data[0x14];
                CB_Stat1.SelectedIndex = data[0x15];
                CB_Stat2.SelectedIndex = data[0x16];
                CB_Stat3.SelectedIndex = data[0x17];
                NUD_Stat1.Value = (sbyte)data[0x18];
                NUD_Stat2.Value = (sbyte)data[0x19];
                NUD_Stat3.Value = (sbyte)data[0x1A];
                NUD_StatP1.Value = data[0x1B];
                NUD_StatP2.Value = data[0x1C];
                NUD_StatP3.Value = data[0x1D];

                var move = new Move7(data);
                CB_ZMove.SelectedIndex = move.ZMove;
                NUD_ZPower.Value = move.ZPower;
                CB_ZEffect.SelectedIndex = move.ZEffect;
                CB_AfflictRefresh.SelectedIndex = (int)move.RefreshAfflictType;
                NUD_RefreshAfflictPercent.Value = move.RefreshAfflictPercent;

                var flags = (uint)move.Flags;
                for (int i = 0; i < CLB_Flags.Items.Count; i++)
                    CLB_Flags.SetItemChecked(i, ((flags >> i) & 1) == 1);
            }
        }

        private void SetEntry()
        {
            if (entry < 1) return;
            byte[] data = files[entry];
            {
                data[0x00] = (byte)CB_Type.SelectedIndex;
                data[0x01] = (byte)CB_Quality.SelectedIndex;
                data[0x02] = (byte)CB_Category.SelectedIndex;
                data[0x03] = (byte)NUD_Power.Value;
                data[0x04] = (byte)NUD_Accuracy.Value;
                data[0x05] = (byte)NUD_PP.Value;
                data[0x06] = (byte)(int)NUD_Priority.Value;
                data[0x07] = (byte)((byte)NUD_HitMin.Value | ((byte)NUD_HitMax.Value << 4));
                int inflictval = CB_Inflict.SelectedIndex; if (inflictval == CB_Inflict.Items.Count) inflictval = -1;
                Array.Copy(BitConverter.GetBytes((short)inflictval), 0, data, 0x08, 2);
                data[0x0A] = (byte)NUD_Inflict.Value;
                data[0x0B] = (byte)NUD_0xB.Value;
                data[0x0C] = (byte)NUD_TurnMin.Value;
                data[0x0D] = (byte)NUD_TurnMax.Value;
                data[0x0E] = (byte)NUD_CritStage.Value;
                data[0x0F] = (byte)NUD_Flinch.Value;
                Array.Copy(BitConverter.GetBytes((ushort)NUD_Effect.Value), 0, data, 0x10, 2);
                data[0x12] = (byte)(int)NUD_Recoil.Value;
                data[0x13] = (byte)NUD_Heal.Value;
                data[0x14] = (byte)CB_Targeting.SelectedIndex;
                data[0x15] = (byte)CB_Stat1.SelectedIndex;
                data[0x16] = (byte)CB_Stat2.SelectedIndex;
                data[0x17] = (byte)CB_Stat3.SelectedIndex;
                data[0x18] = (byte)(int)NUD_Stat1.Value;
                data[0x19] = (byte)(int)NUD_Stat2.Value;
                data[0x1A] = (byte)(int)NUD_Stat3.Value;
                data[0x1B] = (byte)NUD_StatP1.Value;
                data[0x1C] = (byte)NUD_StatP2.Value;
                data[0x1D] = (byte)NUD_StatP3.Value;

                var move = new Move7(data)
                {
                    ZMove = CB_ZMove.SelectedIndex,
                    ZPower = (int) NUD_ZPower.Value,
                    ZEffect = CB_ZEffect.SelectedIndex,
                    RefreshAfflictPercent = (int) NUD_RefreshAfflictPercent.Value,
                    RefreshAfflictType = (RefreshType)CB_AfflictRefresh.SelectedIndex
                };

                uint flagval = 0;
                for (int i = 0; i < CLB_Flags.Items.Count; i++)
                    flagval |= CLB_Flags.GetItemChecked(i) ? 1u << i : 0;
                move.Flags = (MoveFlag7) flagval;
            }
            files[entry] = data;
        }

        private void CloseForm(object sender, FormClosingEventArgs e)
        {
            SetEntry();
            RandSettings.SetFormSettings(this, groupBox1.Controls);
        }

        private void B_Table_Click(object sender, EventArgs e)
        {
            var items = files.Select(z => new Move7(z));
            Clipboard.SetText(TableUtil.GetTable(items, movelist));
            System.Media.SystemSounds.Asterisk.Play();
        }

        private void B_RandAll_Click(object sender, EventArgs e)
        {
            if (!CHK_Category.Checked && !CHK_Type.Checked)
            {
                WinFormsUtil.Alert("无法随机化招式。", "请检查右侧的设置。");
                return;
            }

            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否随机化招式？无法撤销。", "确认前，请先确认右侧的设置。") != DialogResult.Yes) return;
            Random rnd = Util.Rand;
            for (int i = 0; i < CB_Move.Items.Count; i++)
            {
                CB_Move.SelectedIndex = i; // Get new Move
                if (i == 165 || i == 174) continue; // Don't change Struggle or Curse

                // Change Damage Category if Not Status
                if (CB_Category.SelectedIndex > 0 && CHK_Category.Checked) // Not Status
                    CB_Category.SelectedIndex = rnd.Next(1, 3);

                // Change Move Type
                if (CHK_Type.Checked)
                    CB_Type.SelectedIndex = rnd.Next(0, 18);
            }
            WinFormsUtil.Alert("已随机化全部招式！");
        }

        private void B_Metronome_Click(object sender, EventArgs e)
        {
            if (WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否使用挥指模式？", "这将设置其他全部招式的基础pp值为0！") != DialogResult.Yes) return;

            for (int i = 0; i < CB_Move.Items.Count; i++)
            {
                CB_Move.SelectedIndex = i;
                if (CB_Move.SelectedIndex != 117 || CB_Move.SelectedIndex != 32)
                    NUD_PP.Value = 0;
                if (CB_Move.SelectedIndex == 117)
                    NUD_PP.Value = 40;
                if (CB_Move.SelectedIndex == 32)
                    NUD_PP.Value = 1;
            }
            CB_Move.SelectedIndex = 0;
            WinFormsUtil.Alert("已随机化全部招式的基础pp值！");
        }
    }
}
