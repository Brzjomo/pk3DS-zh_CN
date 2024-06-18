﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Media;
using System.Text;
using System.Windows.Forms;

using pk3DS.Core;
using pk3DS.Core.Structures;

namespace pk3DS.WinForms
{
    public partial class MegaEvoEditor7 : Form
    {
        private readonly byte[][] files;
        //private readonly string[] forms = Main.Config.GetText(TextName.Forms);
        //private readonly string[] types = Main.Config.GetText(TextName.Types);
        private readonly string[] specieslist = Main.Config.GetText(TextName.SpeciesNames);
        private readonly string[] itemlist = Main.Config.GetText(TextName.ItemNames);
        private readonly GroupBox[] groupbox_spec;
        private readonly ComboBox[] forme_spec;
        private readonly ComboBox[] item_spec;
        private readonly CheckBox[] checkbox_spec;
        private readonly PictureBox[][] picturebox_spec;
        private bool loaded;
        private readonly string[][] AltForms;
        private int entry = -1;
        private bool dumping;
        private MegaEvolutions me;

        public MegaEvoEditor7(byte[][] infiles) // All the initial settings
        {
            files = infiles;
            InitializeComponent();
            CB_Species.DisplayMember = "Text";
            CB_Species.ValueMember = "Value";
            #region Intializations

            Array.Resize(ref specieslist, Main.Config.MaxSpeciesID + 1);
            specieslist[0] = itemlist[0] = "";
            specieslist[32] += "♂"; specieslist[29] += "♀";

            if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7)
            {
                string[] temp = new string[specieslist.Length];
                temp[0] = specieslist[0];
                Array.Copy(Main.pokemonNameUSSC_Sim, 0, temp, 1, Main.pokemonNameUSSC_Sim.Length);

                AltForms = Main.Config.Personal.GetFormList(temp, Main.Config.MaxSpeciesID);
            }
            else
            {
                AltForms = Main.Config.Personal.GetFormList(specieslist, Main.Config.MaxSpeciesID);
            }

            groupbox_spec = new[] { GB_MEvo1, GB_MEvo2 };
            item_spec = new[] { CB_Item1, CB_Item2 };
            forme_spec = new[] { CB_Forme1, CB_Forme2 };
            checkbox_spec = new[] { CHK_MEvo1, CHK_MEvo2 };
            picturebox_spec = new[] { new[] { PB_S1, PB_S2 }, new[] { PB_M1, PB_M2 } };
            #endregion
            Setup();
            CB_Species.SelectedIndex = 0;
        }

        private void Setup()
        {
            List<string> temp_list = new List<string>(specieslist);
            temp_list.Sort();

            // CB_Species.DataSource = temp_list.ConvertAll(mon => new ComboItem { Text = mon, Value = Array.IndexOf(specieslist, mon) });

            if (Main.ifFixChineseDisplay && Main.Config.USUM && Main.Language > 7)
            {
                List<ComboItem> comboItems = new List<ComboItem>();
                for (int i = 0; i < temp_list.Count; i++)
                {
                    string mon;
                    int value = i;

                    if (i == 0)
                    {
                        mon = temp_list[i];
                    } else
                    {
                        mon = Main.pokemonNameUSSC_Sim[i - 1];
                    }

                    if (i == 0) { 
                        mon = temp_list[i];
                    }

                    ComboItem comboItem = new ComboItem
                    {
                        Text = mon,
                        Value = value
                    };

                    comboItems.Add(comboItem);
                }

                CB_Species.DataSource = comboItems;
            } else
            {
                CB_Species.DataSource = temp_list.ConvertAll(mon => new ComboItem { Text = mon, Value = Array.IndexOf(specieslist, mon) });
            }

            List<string> items = new List<string>(itemlist);
            List<string> sorted_items = new List<string>(itemlist);
            List<ComboItem>[] item_lists = new List<ComboItem>[item_spec.Length];
            for (int i = 0; i < item_lists.Length; i++)
                item_lists[i] = new List<ComboItem>();

            sorted_items.Sort();
            for (int i = 0; i < items.Count; i++)
            {
                int index = items.IndexOf(sorted_items[i]);
                {
                    var ncbi = new ComboItem();
                    if (sorted_items[i] == "???") continue; // Don't allow stubbed items.
                    ncbi.Text = sorted_items[i] + " - " + index.ToString("000");
                    ncbi.Value = index;
                    foreach (List<ComboItem> l in item_lists)
                        l.Add(ncbi);
                }
                items[index] = "";
            }
            for (int i = 0; i < item_spec.Length; i++)
            {
                item_spec[i].ValueMember = "Value";
                item_spec[i].DisplayMember = "Text";
                item_spec[i].DataSource = item_lists[i];
                item_spec[i].SelectedValue = 0;
            }

            loaded = true;
        }

        private void CHK_Changed(object sender, EventArgs e)
        {
            for (int i = 0; i < groupbox_spec.Length; i++)
            {
                groupbox_spec[i].Enabled = checkbox_spec[i].Checked;
                Update_PBs(i);
            }
        }

        private void ChangeIndex(object sender, EventArgs e)
        {
            SetEntry();
            entry = (int)CB_Species.SelectedValue;
            GetEntry();
        }

        private void GetEntry()
        {
            if (!loaded) return;
            if (Main.Config.ORAS && entry == 384 && !dumping) // Current Mon is Rayquaza
                WinFormsUtil.Alert("Rayquaza is special and uses a different activator for its evolution. If it knows Dragon Ascent, it can Mega Evolve", "Don't edit its evolution table if you want to keep this functionality.");

            byte[] data = files[entry];

            foreach (ComboBox CB in forme_spec)
                FormUtil.SetForms(entry, CB, AltForms);

            me = new MegaEvolutions(data);
            for (int i = 0; i < 2; i++)
            {
                checkbox_spec[i].Checked = me.Method[i] == 1;
                item_spec[i].SelectedValue = (int)me.Argument[i];
                forme_spec[i].SelectedIndex = me.Form[i];
            }
        }

        private void SetEntry()
        {
            if (entry < 1 || entry == 384) return; // Don't edit invalid / Rayquaza.
            for (int i = 0; i < 2; i++)
            {
                if (me.Method[i] > 1)
                    return; // Shouldn't hit this.
                me.Method[i] = checkbox_spec[i].Checked ? (byte)1 : (byte)0;
                me.Argument[i] = (ushort)WinFormsUtil.GetIndex(item_spec[i]);
                me.Form[i] = (ushort)forme_spec[i].SelectedIndex;
            }
            files[entry] = me.Write();
        }

        private void Update_PBs(object sender, EventArgs e)
        {
            if (!loaded) return;
            for (int i = 0; i < checkbox_spec.Length; i++)
            {
                CheckBox CB = checkbox_spec[i];
                if (CB.Checked)
                {
                    UpdateImage(picturebox_spec[0][i], entry, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
                    UpdateImage(picturebox_spec[1][i], entry, forme_spec[i].SelectedIndex, WinFormsUtil.GetIndex(item_spec[i]), 0);
                }
                else
                {
                    UpdateImage(picturebox_spec[0][i], 0, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
                    UpdateImage(picturebox_spec[1][i], 0, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
                }
            }
        }

        private void Update_PBs(int i)
        {
            if (!loaded) return;
            CheckBox CB = checkbox_spec[i];
            if (CB.Checked)
            {
                UpdateImage(picturebox_spec[0][i], entry, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
                UpdateImage(picturebox_spec[1][i], entry, forme_spec[i].SelectedIndex, WinFormsUtil.GetIndex(item_spec[i]), 0);
            }
            else
            {
                UpdateImage(picturebox_spec[0][i], 0, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
                UpdateImage(picturebox_spec[1][i], 0, 0, WinFormsUtil.GetIndex(item_spec[i]), 0);
            }
        }

        private static void UpdateImage(PictureBox pb, int species, int form, int item, int gender)
        {
            if (!pb.Enabled)
            {
                pb.Image = null;
                return;
            }
            pb.Image = WinFormsUtil.GetSprite(species, form, gender, item, Main.Config);
        }

        private void Form_Closing(object sender, FormClosingEventArgs e)
        {
            SetEntry();
        }

        private void B_Dump_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes != WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "是否导出全部Mega进化至TXT文档？"))
                return;
            dumping = true;
            string result = "";

            for (int i = 0; i < Main.Config.MaxSpeciesID; i++)
            {
                CB_Species.SelectedValue = i; // Get new Species
                string header = "======" + Environment.NewLine + entry + " " + CB_Species.Text + Environment.NewLine + "======" + Environment.NewLine;
                bool headered = false;
                for (int j = 0; j < 2; j++)
                {
                    if (!checkbox_spec[j].Checked) continue;
                    if (!headered) { result += header; headered = true; }
                    result += string.Format("Can Mega Evolve into {1} if its held item is {0}." + Environment.NewLine, itemlist[(int)item_spec[j].SelectedValue], forme_spec[j].Text);
                }

                if (headered)
                    result += Environment.NewLine;
            }
            SaveFileDialog sfd = new SaveFileDialog {FileName = "Mega Evolutions.txt", Filter = "Text File|*.txt"};

            SystemSounds.Asterisk.Play();
            if (sfd.ShowDialog() == DialogResult.OK)
                File.WriteAllText(sfd.FileName, result, Encoding.Unicode);

            dumping = false;
        }
    }
}