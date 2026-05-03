using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using pk3DS.Core.CTR;
using pk3DS.WinForms.Text;

namespace pk3DS.WinForms
{
    public partial class CiaSettingsForm : Form
    {
        public bool ModifyTitleId => CB_ModifyTitleId.Checked;
        public ulong RomTitleId { get; }
        public string ProductCode => TB_ProductCode.Text.Trim();
        public string OriginalProductCode { get; }

        public CiaSettingsForm(ulong romTitleId, ulong expectedTitleId, string originalProductCode)
        {
            RomTitleId = romTitleId;
            OriginalProductCode = originalProductCode;
            InitializeComponent();
            L_RomTitleId.Text = $"{Strings.CiaSettings_RomTitleId}: 0x{romTitleId:X016}";
            TB_Manual.Text = romTitleId.ToString("X16");
            TB_ProductCode.Text = originalProductCode;

            // Auto-detect if Title ID has been modified from the expected game version
            bool mismatch = expectedTitleId != 0 && romTitleId != expectedTitleId;
            if (mismatch)
            {
                // Toggle CB first, then overwrite with ROM values (CheckedChanged generates random)
                CB_ModifyTitleId.Checked = true;
                RB_Manual.Checked = true;
                TB_Manual.Text = romTitleId.ToString("X16");
                TB_ProductCode.Text = originalProductCode;
                L_MismatchNotice.Visible = true;
            }

            UpdateControls();
        }

        public ulong GetTargetTitleId()
        {
            return ManualTitleId ?? RomTitleId;
        }

        private ulong? ManualTitleId => ulong.TryParse(TB_Manual.Text.Trim(), System.Globalization.NumberStyles.HexNumber, null, out var val) ? val : null;

        private static ulong GenerateTitleId(ulong romTitleId)
        {
            byte[] buf = new byte[4];
            System.Security.Cryptography.RandomNumberGenerator.Fill(buf);
            uint lower = BitConverter.ToUInt32(buf, 0) & 0xFFFFFF00; // low byte = 0x00 (base title)
            ulong upper = romTitleId & 0xFFFFFFFF00000000;
            ulong result = upper | lower;
            if (result == romTitleId)
                result ^= 0x100;
            return result;
        }

        private void CB_ModifyTitleId_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
            if (CB_ModifyTitleId.Checked)
            {
                if (TB_ProductCode.Text == OriginalProductCode)
                    TB_ProductCode.Text = Exheader.GenerateRandomSerial();
                if (RB_AutoGen.Checked)
                    GenerateAndFill();
            }
            else
            {
                TB_ProductCode.Text = OriginalProductCode;
                TB_Manual.Text = RomTitleId.ToString("X16");
            }
        }

        private void GenerateAndFill()
        {
            ulong newId = GenerateTitleId(RomTitleId);
            TB_Manual.Text = newId.ToString("X16");
            TB_ProductCode.Text = Exheader.GenerateRandomSerial();
        }

        private void UpdateControls()
        {
            bool enabled = CB_ModifyTitleId.Checked;
            RB_AutoGen.Enabled = enabled;
            RB_Manual.Enabled = enabled;
            TB_Manual.Enabled = enabled && RB_Manual.Checked;
            TB_ProductCode.Enabled = enabled && RB_Manual.Checked;
        }

        private void RB_Manual_CheckedChanged(object sender, EventArgs e) => UpdateControls();

        private void RB_AutoGen_CheckedChanged(object sender, EventArgs e)
        {
            UpdateControls();
            if (RB_AutoGen.Checked && CB_ModifyTitleId.Checked)
                GenerateAndFill();
        }

        private static readonly Regex ProductCodeRegex = new(@"^CTR-[PNU]-[A-Z0-9]{4}$");

        private void B_Accept_Click(object sender, EventArgs e)
        {
            if (!CB_ModifyTitleId.Checked)
            {
                DialogResult = DialogResult.OK;
                Close();
                return;
            }

            // Validate Title ID for manual entry
            if (RB_Manual.Checked && !ManualTitleId.HasValue)
            {
                WinFormsUtil.Alert(Strings.CiaSettings_InvalidTitleId);
                return;
            }

            // Validate Product Code format
            string productCode = TB_ProductCode.Text.Trim().ToUpperInvariant();
            TB_ProductCode.Text = productCode;
            if (!ProductCodeRegex.IsMatch(productCode))
            {
                WinFormsUtil.Alert(Strings.CiaSettings_InvalidProductCode);
                return;
            }

            // If values match ROM original, no effective change — skip modification
            if (GetTargetTitleId() == RomTitleId && productCode == OriginalProductCode)
                CB_ModifyTitleId.Checked = false;

            DialogResult = DialogResult.OK;
            Close();
        }

        private void B_Cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
