using pk3DS.Core;
using pk3DS.WinForms.Text;
using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace pk3DS.WinForms
{
    public partial class Patch : Form
    {
        public Patch()
        {
            InitializeComponent();
            CHKLB_GARCs.Items.Clear();
            foreach (string s in Main.Config.Files.Select(file => file.Name))
                CHKLB_GARCs.Items.Add(s);
        }

        private void B_PatchCIA_Click(object sender, EventArgs e)
        {
            if (CHKLB_GARCs.CheckedIndices.Count == 0)
            { WinFormsUtil.Alert(Strings.Patch_SelectGarcs); return; }

            using var fbd = new FolderBrowserDialog();
            fbd.Description = Strings.Patch_SelectDir;
            if (fbd.ShowDialog() != DialogResult.OK)
                return;

            string baseDir = fbd.SelectedPath;
            string titleId = GetTitleID();
            if (titleId == null)
            { WinFormsUtil.Error(Strings.Patch_BadVersion); return; }

            string targetDir = Path.Combine(baseDir, "luma", "titles", titleId, "romfs");
            int count = 0;

            try
            {
                foreach (int index in CHKLB_GARCs.CheckedIndices)
                {
                    string name = CHKLB_GARCs.Items[index].ToString();

                    // Gametext/storytext have language variants — export all 8
                    if (name == "gametext" || name == "storytext")
                    {
                        for (int l = 0; l < 8; l++)
                            count += ExportGARC(name, l, targetDir);
                    }
                    else
                    {
                        count += ExportGARC(name, Main.Language, targetDir);
                    }
                }

                WinFormsUtil.Alert(string.Format(Strings.Patch_ExportComplete, count, targetDir));
            }
            catch (Exception ex)
            {
                WinFormsUtil.Error(Strings.Patch_ExportFailed + ex.Message);
            }
        }

        private int ExportGARC(string name, int lang, string targetDir)
        {
            string relPath = Main.GetGARCFileName(name, lang);
            string src = Path.Combine(Main.RomFSPath, relPath);
            string dest = Path.Combine(targetDir, relPath);

            if (!File.Exists(src))
                return 0;

            Directory.CreateDirectory(Path.GetDirectoryName(dest));
            File.Copy(src, dest, overwrite: true);
            return 1;
        }

        private static string GetTitleID()
        {
            var ver = Main.Config.Version;

            // Gen6
            if (ver == GameVersion.XY)
                return "0004000000055D00";
            if (ver == GameVersion.ORAS || ver == GameVersion.ORASDEMO)
                return "000400000011C400";

            // Gen7
            if (ver == GameVersion.SM || ver == GameVersion.SMDEMO)
                return "0004000000164800";
            if (ver == GameVersion.USUM)
                return "00040000001B5000";

            return null;
        }

        private void B_CheckAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CHKLB_GARCs.Items.Count; i++)
                CHKLB_GARCs.SetItemChecked(i, true);
        }

        private void B_CheckNone_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < CHKLB_GARCs.Items.Count; i++)
                CHKLB_GARCs.SetItemChecked(i, false);
        }
    }
}
