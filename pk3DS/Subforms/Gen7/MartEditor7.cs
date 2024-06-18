﻿using pk3DS.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace pk3DS.WinForms
{
    public partial class MartEditor7 : Form
    {
        private readonly string CROPath = Path.Combine(Main.RomFSPath, "Shop.cro");

        public MartEditor7()
        {
            if (!File.Exists(CROPath))
            {
                WinFormsUtil.Error("CRO does not exist! Closing.", CROPath);
                Close();
            }
            InitializeComponent();

            data = File.ReadAllBytes(CROPath);
            offset = Util.IndexOfBytes(data, Signature, 0x5000, 0) + Signature.Length;
            offsetBP = Util.IndexOfBytes(data, BPSignature, 0x5000, 0) + BPSignature.Length;

            itemlist[0] = "";
            SetupDGV();
            foreach (string s in locations) CB_Location.Items.Add(s);
            foreach (string s in locationsBP) CB_LocationBP.Items.Add(s);
            CB_Location.SelectedIndex = 0;
            CB_LocationBP.SelectedIndex = 0;
        }

        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private readonly byte[] data;

        #region Tables
        private readonly byte[] Signature = // Leadup to the Shop Data, the shop arrays are the 3rd data array in the rodata section.
        {
            0x2D, 0x00, 0x00, 0x00, 0x3B, 0x00, 0x00, 0x00, 0x2F, 0x00, 0x00, 0x00, 0x3D, 0x00, 0x00, 0x00,
            0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0xFF, 0xFF, 0xFF, 0xFF, 0x00, 0x00, 0x00, 0x00,
            0x10, 0x00, 0x00, 0x00, 0x0E, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x01, 0x00,
        };

        private readonly byte[] BPSignature = // 2 arrays after the regular shops, the BP shops start. Skip over the second one to get BP offset.
        {
            0x09, 0x0B, 0x0D, 0x0F, 0x11, 0x13, 0x14, 0x15, 0x09, 0x04, 0x08, 0x0C, 0x05, 0x04, 0x0B, 0x03,
            0x0A, 0x06, 0x0A, 0x06, 0x04, 0x05, 0x07, 0x01
        };

        private readonly byte[] entries =
        {
            9, 11, 13, 15, 17, 19, 20, 21, // Regular Mart
            9, // KoniKoni Incense
            4, // KoniKoni Herb
            8, // Hau'oli Battle
            12, // Route 2
            5, // Heahea
            4, // Royal Avenue
            11, // Route 8
            3, // Paniola
            10, // Malie TMs
            6, // Mount Hokulani
            10, // Seafolk TM
            6, // KoniKoni TM
            4, // KoniKoni Jewelry
            5, // Thrifty 1
            7, // Thrifty 2
            1, // Thrifty 3 (Souvenir)
        };

        private readonly string[] locations =
        {
            "未试练", "1个试练", "2个试练", "3个试练", "4个试练", "5个试练", "6个试练", "7个试练",
            "可霓可市 [薰香]",
            "可霓可市 [草药]",
            "好奥乐市 [强化道具]",
            "2号道路 [杂项]",
            "慷待市 [招式学习器]",
            "皇家大道 [招式学习器]",
            "8号道路 [杂项]",
            "欧哈纳镇 [精灵球]",
            "马利埃静市 [招式学习器]",
            "辉克拉尼山 [增强剂]",
            "海洋居民之村 [招式学习器]",
            "可霓可市 [招式学习器]",
            "可霓可市 [进化石]",
            "超值超市, 左侧 [精灵球]",
            "超值超市, 中间 [杂项]",
            "超值超市, 右侧 [神秘摆设]"
        };

        private readonly int[] entriesBP =
        {
            8, // Royal 1 (Abil Capsule)
            7, // Royal 2
            18, // Royal 3
            12, // Tree 1
            21, // Tree 2
            16, // Tree 3
        };

        private readonly string[] locationsBP =
        {
            "皇家巨蛋 [提升道具]",
            "皇家巨蛋 [努力值道具]",
            "皇家巨蛋 [对战道具]",
            "对战树 [交换进化道具]",
            "对战树 [对战道具]",
            "对战树 [超级进化石]"
        };
        #endregion

        private void B_Save_Click(object sender, EventArgs e)
        {
            if (entry > -1) SetList();
            if (entryBP > -1) SetListBP();
            File.WriteAllBytes(CROPath, data);
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private readonly int offset;
        private int dataoffset;

        private void GetDataOffset(int index)
        {
            dataoffset = offset; // reset
            for (int i = 0; i < index; i++)
                dataoffset += 2 * entries[i];
        }

        private void SetupDGV()
        {
            foreach (string t in itemlist)
                dgvItem.Items.Add(t); // add only the Names
            foreach (string t in itemlist)
                dgvItemBP.Items.Add(t); // add only the Names
        }

        private int entry = -1;

        private void ChangeIndex(object sender, EventArgs e)
        {
            if (entry > -1) SetList();
            entry = CB_Location.SelectedIndex;
            GetList();
        }

        private void GetList()
        {
            dgv.Rows.Clear();
            int count = entries[entry];
            dgv.Rows.Add(count);
            GetDataOffset(entry);
            for (int i = 0; i < count; i++)
            {
                dgv.Rows[i].Cells[0].Value = i.ToString();
                dgv.Rows[i].Cells[1].Value = itemlist[BitConverter.ToUInt16(data, dataoffset + (2 * i))];
            }
        }

        private void SetList()
        {
            int count = dgv.Rows.Count;
            for (int i = 0; i < count; i++)
                Array.Copy(BitConverter.GetBytes((ushort)Array.IndexOf(itemlist, dgv.Rows[i].Cells[1].Value)), 0, data, dataoffset + (2 * i), 2);
        }

        /// <summary>
        /// Just TMs & HMs; don't want these to be changed; if changed, they are not available elsewhere ingame.
        /// </summary>
        internal static readonly HashSet<int> BannedItems = new()
        {
            328, 329, 330, 331, 332, 333, 334, 335, 336, 337, 338, 339, 340, 341, 342, 343, 344, 345, 346, 347, 348,
            349, 350, 351, 352, 353, 354, 355, 356, 357, 358, 359, 360, 361, 362, 363, 364, 365, 366, 367, 368, 369,
            370, 371, 372, 373, 374, 375, 376, 377, 378, 379, 380, 381, 382, 383, 384, 385, 386, 387, 388, 389, 390,
            391, 392, 393, 394, 395, 396, 397, 398, 399, 400, 401, 402, 403, 404, 405, 406, 407, 408, 409, 410, 411,
            412, 413, 414, 415, 416, 417, 418, 419, 420, 421, 422, 423, 424, 425, 426, 427, 618, 619, 620, 690, 691,
            692, 693, 694, 701, 737
        };

        /// <summary>
        /// All X Items usable in Generations 6 and 7. Speedrunners utilize these Items a lot, so make sure they are still available.
        /// </summary>
        internal static readonly HashSet<int> XItems = new()
        {
            055, 056, 057, 058, 059, 060, 061, 062
        };

        private void B_Randomize_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否随机商店物品?"))
                return;

            int[] validItems = Randomizer.GetRandomItemList();

            int ctr = 0;
            Util.Shuffle(validItems);

            bool specialOnly = DialogResult.Yes == WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否仅随机特殊商店?", "不会修改常规必需品。");
            int start = specialOnly ? 8 : 0;
            for (int i = start; i < CB_Location.Items.Count; i++)
            {
                CB_Location.SelectedIndex = i;
                for (int r = 0; r < dgv.Rows.Count; r++)
                {
                    int currentItem = Array.IndexOf(itemlist, dgv.Rows[r].Cells[1].Value);
                    if (CHK_XItems.Checked && XItems.Contains(currentItem))
                        continue;
                    if (BannedItems.Contains(currentItem))
                        continue;
                    dgv.Rows[r].Cells[1].Value = itemlist[validItems[ctr++]];
                    if (ctr <= validItems.Length) continue;
                    Util.Shuffle(validItems); ctr = 0;
                }
            }
            WinFormsUtil.Alert("已随机化!");
        }

        private void GetDataOffsetBP(int index)
        {
            dataoffsetBP = offsetBP; // reset
            for (int i = 0; i < index; i++)
                dataoffsetBP += 4 * entriesBP[i];
        }

        private readonly int offsetBP;
        private int dataoffsetBP;
        private int entryBP = -1;

        private void ChangeIndexBP(object sender, EventArgs e)
        {
            if (entryBP > -1) SetListBP();
            entryBP = CB_LocationBP.SelectedIndex;
            GetListBP();
        }

        private void GetListBP()
        {
            dgvbp.Rows.Clear();
            int count = entriesBP[entryBP];
            dgvbp.Rows.Add(count);
            GetDataOffsetBP(entryBP);
            for (int i = 0; i < count; i++)
            {
                dgvbp.Rows[i].Cells[0].Value = i.ToString();
                dgvbp.Rows[i].Cells[1].Value = itemlist[BitConverter.ToUInt16(data, dataoffsetBP + (4 * i))];
                dgvbp.Rows[i].Cells[2].Value = BitConverter.ToUInt16(data, dataoffsetBP + (4 * i) + 2).ToString();
            }
        }

        private void SetListBP()
        {
            int count = dgvbp.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                int item = Array.IndexOf(itemlist, dgvbp.Rows[i].Cells[1].Value);
                Array.Copy(BitConverter.GetBytes((ushort)item), 0, data, dataoffsetBP + (4 * i), 2);
                string p = dgvbp.Rows[i].Cells[2].Value.ToString();
                if (int.TryParse(p, out var price))
                    Array.Copy(BitConverter.GetBytes((ushort)price), 0, data, dataoffsetBP + (4 * i) + 2, 2);
            }
        }

        private void B_RandomizeBP_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否随机化对战点数物品?"))
                return;

            int[] validItems = Randomizer.GetRandomItemList();

            int ctr = 0;
            Util.Shuffle(validItems);

            for (int i = 0; i < CB_LocationBP.Items.Count; i++)
            {
                CB_LocationBP.SelectedIndex = i;
                for (int r = 0; r < dgvbp.Rows.Count; r++)
                {
                    dgvbp.Rows[r].Cells[1].Value = itemlist[validItems[ctr++]];
                    if (ctr <= validItems.Length) continue;
                    Util.Shuffle(validItems); ctr = 0;
                }
            }
            WinFormsUtil.Alert("已随机化!");
        }
    }
}