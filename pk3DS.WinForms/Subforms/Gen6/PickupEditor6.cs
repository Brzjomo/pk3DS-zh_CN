﻿using pk3DS.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace pk3DS.WinForms
{
    public partial class PickupEditor6 : Form
    {
        public PickupEditor6()
        {
            InitializeComponent();
            if (Main.ExeFSPath == null) { WinFormsUtil.Alert("未加载exeFS代码"); Close(); }
            string[] files = Directory.GetFiles(Main.ExeFSPath);
            if (!File.Exists(files[0]) || !Path.GetFileNameWithoutExtension(files[0]).Contains("code")) { WinFormsUtil.Alert("No .code.bin detected."); Close(); }
            data = File.ReadAllBytes(files[0]);
            if (data.Length % 0x200 != 0) { WinFormsUtil.Alert(".code.bin未解压，程序已终止"); Close(); }
            offset = Util.IndexOfBytes(data, new byte[] { 0x1E, 0x28, 0x32, 0x3C, 0x46, 0x50, 0x5A, 0x5E, 0x62, 0x05, 0x0A, 0x0F, 0x14, 0x19, 0x1E, 0x23, 0x28, 0x2D, 0x32 }, 0x400000, 0) - 0x3A;
            codebin = files[0];
            itemlist[0] = "";
            SetupDGV();
            GetList();
        }

        private readonly string codebin;
        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private readonly int offset = Main.Config.ORAS ? 0x004872FC : 0x004455A8;
        private readonly byte[] data;
        private int dataoffset;

        private void GetDataOffset()
        {
            dataoffset = offset; // reset
        }

        private void SetupDGV()
        {
            dgvCommon.Columns.Clear(); dgvRare.Columns.Clear();
            DataGridViewColumn dgvIndex = new DataGridViewTextBoxColumn();
            {
                dgvIndex.HeaderText = "序号";
                dgvIndex.DisplayIndex = 0;
                dgvIndex.Width = 50;
                dgvIndex.ReadOnly = true;
                dgvIndex.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            DataGridViewComboBoxColumn dgvMove = new DataGridViewComboBoxColumn();
            {
                dgvMove.HeaderText = "物品";
                dgvMove.DisplayIndex = 1;
                foreach (string t in itemlist)
                    dgvMove.Items.Add(t); // add only the Names

                dgvMove.Width = 285;
                dgvMove.FlatStyle = FlatStyle.Flat;
            }
            dgvCommon.Columns.Add(dgvIndex);
            dgvCommon.Columns.Add(dgvMove);
            dgvRare.Columns.Add((DataGridViewColumn)dgvIndex.Clone());
            dgvRare.Columns.Add((DataGridViewColumn)dgvMove.Clone());
        }

        private List<ushort> common = new();
        private List<ushort> rare = new();

        private void GetList()
        {
            common = new List<ushort>();
            rare = new List<ushort>();
            dgvCommon.Rows.Clear();

            GetDataOffset();
            for (int i = 0; i < 0x12; i++) // 0x12 Common
                common.Add(BitConverter.ToUInt16(data, dataoffset + (2 * i)));
            for (int i = 0x12; i < 0x12 + 0xB; i++) // 0xB Rare
                rare.Add(BitConverter.ToUInt16(data, dataoffset + (2 * i)));

            ushort[] clist = common.ToArray();
            ushort[] rlist = rare.ToArray();
            for (int i = 0; i < clist.Length; i++)
            { dgvCommon.Rows.Add(); dgvCommon.Rows[i].Cells[0].Value = i.ToString(); dgvCommon.Rows[i].Cells[1].Value = itemlist[clist[i]]; }
            for (int i = 0; i < rlist.Length; i++)
            { dgvRare.Rows.Add(); dgvRare.Rows[i].Cells[0].Value = i.ToString(); dgvRare.Rows[i].Cells[1].Value = itemlist[rlist[i]]; }
        }

        private void SetList()
        {
            common = new List<ushort>();
            rare = new List<ushort>();
            for (int i = 0; i < 0x12; i++) // 0x12 Common
                common.Add((ushort)Array.IndexOf(itemlist, dgvCommon.Rows[i].Cells[1].Value));

            for (int i = 0x12; i < 0x12 + 0xB; i++) // 0xB Rare
                rare.Add((ushort)Array.IndexOf(itemlist, dgvRare.Rows[i - 0x12].Cells[1].Value));

            ushort[] clist = common.ToArray();
            ushort[] rlist = rare.ToArray();

            for (int i = 0; i < 0x12; i++)
                Array.Copy(BitConverter.GetBytes(clist[i]), 0, data, offset + (2 * i), 2);
            for (int i = 0x12; i < 0x12 + 0xB; i++)
                Array.Copy(BitConverter.GetBytes(rlist[i - 0x12]), 0, data, offset + (2 * i), 2);
        }

        private void B_Save_Click(object sender, EventArgs e)
        {
            SetList();
            File.WriteAllBytes(codebin, data);
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void B_Randomize_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否随机化捡拾列表？"))
                return;

            int[] validItems = Randomizer.GetRandomItemList();

            int ctr = 0;
            Util.Shuffle(validItems);
            for (int r = 0; r < dgvCommon.Rows.Count; r++)
            {
                dgvCommon.Rows[r].Cells[1].Value = itemlist[validItems[ctr++]];
                if (ctr <= validItems.Length) continue;
                Util.Shuffle(validItems); ctr = 0;
            }
            for (int r = 0; r < dgvRare.Rows.Count; r++)
            {
                dgvRare.Rows[r].Cells[1].Value = itemlist[validItems[ctr++]];
                if (ctr <= validItems.Length) continue;
                Util.Shuffle(validItems); ctr = 0;
            }
            //WinFormsUtil.Alert("已随机！");
        }
    }
}