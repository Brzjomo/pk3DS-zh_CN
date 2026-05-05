using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using pk3DS.Core.Properties;

namespace pk3DS.Core.CTR
{
    public static class CTRUtil
    {
        internal const uint MEDIA_UNIT_SIZE = 0x200;

        // Main wrapper that assembles the ROM based on the following specifications:
        public static bool BuildROM(bool Card2, string LOGO_NAME,
            string EXEFS_PATH, string ROMFS_PATH, string EXHEADER_PATH,
            string SERIAL_TEXT, string SAVE_PATH,
            bool trimmed = false, ProgressBar PB_Show = null, RichTextBox TB_Progress = null)
        {
            PB_Show ??= new ProgressBar();
            TB_Progress ??= new RichTextBox();

            // Sanity check the input files.
            if (!
                ((File.Exists(EXEFS_PATH) || Directory.Exists(EXEFS_PATH))
                && (File.Exists(ROMFS_PATH) || Directory.Exists(ROMFS_PATH))
                && File.Exists(EXHEADER_PATH)))
            {
                return false;
            }

            // If ExeFS and RomFS are not built, build.
            if (!File.Exists(EXEFS_PATH) && Directory.Exists(EXEFS_PATH))
                ExeFS.PackExeFS(Directory.GetFiles(EXEFS_PATH), EXEFS_PATH = "exefs.bin");
            if (!File.Exists(ROMFS_PATH) && Directory.Exists(ROMFS_PATH))
                RomFS.BuildRomFS(ROMFS_PATH, ROMFS_PATH = "romfs.bin", TB_Progress, PB_Show);

            NCCH NCCH = SetNCCH(EXEFS_PATH, ROMFS_PATH, EXHEADER_PATH, SERIAL_TEXT, LOGO_NAME, TB_Progress);
            NCSD NCSD = SetNCSD(NCCH, Card2, TB_Progress);
            try
            {
                return WriteROM(NCSD, SAVE_PATH, trimmed, PB_Show, TB_Progress);
            }
            catch (IOException ex)
            {
                UpdateTB(TB_Progress, "错误: " + ex.Message);
                return false;
            }
        }

        // Sub methods that drive the operation
        internal static NCCH SetNCCH(string EXEFS_PATH, string ROMFS_PATH, string EXHEADER_PATH, string TB_Serial, string LOGO_NAME, RichTextBox TB_Progress = null)
        {
            TB_Progress ??= new RichTextBox();

            UpdateTB(TB_Progress, "Creating NCCH...");
            UpdateTB(TB_Progress, "Adding Exheader...");
            NCCH NCCH = new NCCH
            {
                Exheader = new Exheader(EXHEADER_PATH),
                plainregion = Array.Empty<byte>()
            };
            if (NCCH.Exheader.IsSupported())
            {
                UpdateTB(TB_Progress, "Detected Pokemon Game. Adding Plain Region...");
                if (NCCH.Exheader.IsXY())
                    NCCH.plainregion = Resources.XY;
                else if (NCCH.Exheader.IsORAS())
                    NCCH.plainregion = Resources.ORAS;
                else if (NCCH.Exheader.IsSM())
                    NCCH.plainregion = Resources.SuMo;
                else if (NCCH.Exheader.IsUSUM())
                    NCCH.plainregion = Resources.USUM;
            }
            UpdateTB(TB_Progress, "Adding ExeFS...");
            NCCH.ExeFS = new ExeFS(EXEFS_PATH);
            UpdateTB(TB_Progress, "Adding RomFS...");
            NCCH.RomFS = new RomFS(ROMFS_PATH);

            UpdateTB(TB_Progress, "Adding Logo...");
            NCCH.logo = (byte[])Resources.ResourceManager.GetObject(LOGO_NAME);
            UpdateTB(TB_Progress, "Assembling NCCH Header...");
            ulong Len = 0x200; //NCCH Signature + NCCH Header
            NCCH.Header = new NCCH.NCCHHeader { Signature = Enumerable.Repeat((byte)0xFF, 0x100).ToArray(), Magic = 0x4843434E };
            NCCH.Header.TitleId = NCCH.Header.ProgramId = NCCH.Exheader.TitleID;
            NCCH.Header.MakerCode = 0x3130; //01
            NCCH.Header.FormatVersion = 0x2; //Default
            NCCH.Header.LogoHash = SHA256.HashData(NCCH.logo);
            NCCH.Header.ProductCode = Encoding.ASCII.GetBytes(TB_Serial);
            Array.Resize(ref NCCH.Header.ProductCode, 0x10);
            NCCH.Header.ExheaderHash = NCCH.Exheader.GetSuperBlockHash();
            NCCH.Header.ExheaderSize = (uint)(NCCH.Exheader.Data.Length + NCCH.Exheader.AccessDescriptor.Length) / MEDIA_UNIT_SIZE;
            Len += NCCH.Header.ExheaderSize * MEDIA_UNIT_SIZE;
            NCCH.Header.Flags = new byte[0x8];
            //FLAGS
            NCCH.Header.Flags[3] = 0; // Crypto: 0 = <7.x, 1=7.x;
            NCCH.Header.Flags[4] = 1; // Content Platform: 1 = CTR;
            NCCH.Header.Flags[5] = 0x3; // Content Type Bitflags: 1=Data, 2=Executable, 4=SysUpdate, 8=Manual, 0x10=Trial;
            NCCH.Header.Flags[6] = 0; // MEDIA_UNIT_SIZE = 0x200*Math.Pow(2, Content.header.Flags[6]);
            NCCH.Header.Flags[7] = 4; // NoCrypto only (NOT FixedCrypto=1). FixedCrypto content rejected by real 3DS AM.
            NCCH.Header.LogoOffset = (uint)(Len / MEDIA_UNIT_SIZE);
            NCCH.Header.LogoSize = (uint)(NCCH.logo.Length / MEDIA_UNIT_SIZE);
            Len += (uint)NCCH.logo.Length;
            NCCH.Header.PlainRegionOffset = (uint)(NCCH.plainregion.Length > 0 ? Len / MEDIA_UNIT_SIZE : 0);
            NCCH.Header.PlainRegionSize = (uint)NCCH.plainregion.Length / MEDIA_UNIT_SIZE;
            Len += (uint)NCCH.plainregion.Length;
            NCCH.Header.ExefsOffset = (uint)(Len / MEDIA_UNIT_SIZE);
            NCCH.Header.ExefsSize = (uint)(NCCH.ExeFS.Data.Length / MEDIA_UNIT_SIZE);
            NCCH.Header.ExefsSuperBlockSize = 0x200 / MEDIA_UNIT_SIZE; //Static 0x200 for exefs superblock
            Len += (uint)NCCH.ExeFS.Data.Length;
            Len = (uint)Align(Len, 0x1000); //Romfs Start is aligned to 0x1000
            NCCH.Header.RomfsOffset = (uint)(Len / MEDIA_UNIT_SIZE);
            NCCH.Header.RomfsSize = (uint)(new FileInfo(NCCH.RomFS.FileName).Length / MEDIA_UNIT_SIZE);
            NCCH.Header.RomfsSuperBlockSize = NCCH.RomFS.SuperBlockLen / MEDIA_UNIT_SIZE;
            Len += NCCH.Header.RomfsSize * MEDIA_UNIT_SIZE;
            NCCH.Header.ExefsHash = NCCH.ExeFS.SuperBlockHash;
            NCCH.Header.RomfsHash = NCCH.RomFS.SuperBlockHash;
            NCCH.Header.Size = (uint)(Len / MEDIA_UNIT_SIZE);
            //Build the Header byte[].
            UpdateTB(TB_Progress, "Building NCCH Header...");
            NCCH.Header.BuildHeader();

            return NCCH;
        }

        internal static NCSD SetNCSD(NCCH NCCH, bool Card2, RichTextBox TB_Progress = null)
        {
            TB_Progress ??= new RichTextBox();
            UpdateTB(TB_Progress, "Building NCSD Header...");
            NCSD NCSD = new NCSD
            {
                NCCH_Array = new List<NCCH> {NCCH},
                Card2 = Card2,
                Header = new NCSD.NCSDHeader {Signature = new byte[0x100], Magic = 0x4453434E}
            };
            ulong Length = 0x80 * 0x100000; // 128 MB
            while (Length <= (NCCH.Header.Size * MEDIA_UNIT_SIZE) + 0x400000) //Extra 4 MB for potential save data
            {
                Length *= 2;
            }
            NCSD.Header.MediaSize = (uint)(Length / MEDIA_UNIT_SIZE);
            NCSD.Header.TitleId = NCCH.Exheader.TitleID;
            NCSD.Header.OffsetSizeTable = new NCSD.NCCH_Meta[8];
            ulong OSOfs = 0x4000;
            for (int i = 0; i < NCSD.Header.OffsetSizeTable.Length; i++)
            {
                NCSD.NCCH_Meta ncchm = new NCSD.NCCH_Meta();
                if (i < NCSD.NCCH_Array.Count)
                {
                    ncchm.Offset = (uint)(OSOfs / MEDIA_UNIT_SIZE);
                    ncchm.Size = NCSD.NCCH_Array[i].Header.Size;
                }
                else
                {
                    ncchm.Offset = 0;
                    ncchm.Size = 0;
                }
                NCSD.Header.OffsetSizeTable[i] = ncchm;
                OSOfs += ncchm.Size * MEDIA_UNIT_SIZE;
            }
            NCSD.Header.flags = new byte[0x8];
            NCSD.Header.flags[0] = 0; // 0-255 seconds of waiting for save writing.
            NCSD.Header.flags[3] = NCSD.Card2 ? (byte)2 : (byte)1; // Media Card Device: 1 = NOR Flash, 2 = None, 3 = BT
            NCSD.Header.flags[4] = 1; // Media Platform Index: 1 = CTR
            NCSD.Header.flags[5] = NCSD.Card2 ? (byte)2 : (byte)1; // Media Type Index: 0 = Inner Device, 1 = Card1, 2 = Card2, 3 = Extended Device
            NCSD.Header.flags[6] = 0; // Media Unit Size. Same as NCCH.
            NCSD.Header.flags[7] = 0; // Old Media Card Device.
            NCSD.Header.NCCHIdTable = new ulong[8];
            for (int i = 0; i < NCSD.NCCH_Array.Count; i++)
            {
                NCSD.Header.NCCHIdTable[i] = NCSD.NCCH_Array[i].Header.TitleId;
            }
            NCSD.cardinfoheader = new NCSD.CardInfoHeader
            {
                WritableAddress = (uint)NCSD.GetWritableAddress(),
                CardInfoBitmask = 0,
                CIN = new NCSD.CardInfoHeader.CardInfoNotes
                {
                    Reserved0 = new byte[0xF8],
                    MediaSizeUsed = OSOfs,
                    Reserved1 = 0,
                    Unknown = 0,
                    Reserved2 = new byte[0xC],
                    CVerTitleId = 0,
                    CVerTitleVersion = 0,
                    Reserved3 = new byte[0xCD6]
                },
                NCCH0TitleId = NCSD.NCCH_Array[0].Header.TitleId,
                Reserved0 = 0,
                InitialData = new byte[0x30]
            };
            byte[] randbuffer = new byte[0x2C];
            Random.Shared.NextBytes(randbuffer);
            Array.Copy(randbuffer, NCSD.cardinfoheader.InitialData, randbuffer.Length);
            NCSD.cardinfoheader.Reserved1 = new byte[0xC0];
            NCSD.cardinfoheader.NCCH0Header = new byte[0x100];
            Array.Copy(NCSD.NCCH_Array[0].Header.Data, 0x100, NCSD.cardinfoheader.NCCH0Header, 0, 0x100);

            NCSD.BuildHeader();

            //NCSD is Initialized
            return NCSD;
        }

        internal static bool WriteROM(NCSD NCSD, string SAVE_PATH, bool trimmed = false,
            ProgressBar PB_Show = null, RichTextBox TB_Progress = null)
        {
            PB_Show ??= new ProgressBar();
            TB_Progress ??= new RichTextBox();
            using (FileStream OutFileStream = new FileStream(SAVE_PATH, FileMode.Create))
            {
                UpdateTB(TB_Progress, "Writing NCSD Header...");
                OutFileStream.Write(NCSD.Data, 0, NCSD.Data.Length);
                UpdateTB(TB_Progress, "Writing NCCH...");
                OutFileStream.Write(NCSD.NCCH_Array[0].Header.Data, 0, NCSD.NCCH_Array[0].Header.Data.Length); //Write NCCH header
                //AES time.
                byte[] key = new byte[0x10]; //Fixed-Crypto key is all zero.
                for (int i = 0; i < 3; i++)
                {
                    AesCtr aesctr = new AesCtr(key, NCSD.NCCH_Array[0].Header.ProgramId, (ulong)(i + 1) << 56); //CTR is ProgramID, section id<<88
                    switch (i)
                    {
                        case 0: //Exheader + AccessDesc
                            UpdateTB(TB_Progress, "Writing Exheader...");
                            byte[] inEncExheader = new byte[NCSD.NCCH_Array[0].Exheader.Data.Length + NCSD.NCCH_Array[0].Exheader.AccessDescriptor.Length];
                            byte[] outEncExheader = new byte[NCSD.NCCH_Array[0].Exheader.Data.Length + NCSD.NCCH_Array[0].Exheader.AccessDescriptor.Length];
                            Array.Copy(NCSD.NCCH_Array[0].Exheader.Data, inEncExheader, NCSD.NCCH_Array[0].Exheader.Data.Length);
                            Array.Copy(NCSD.NCCH_Array[0].Exheader.AccessDescriptor, 0, inEncExheader, NCSD.NCCH_Array[0].Exheader.Data.Length, NCSD.NCCH_Array[0].Exheader.AccessDescriptor.Length);
                            aesctr.TransformBlock(inEncExheader, 0, inEncExheader.Length, outEncExheader, 0);
                            OutFileStream.Write(outEncExheader, 0, outEncExheader.Length); // Write Exheader
                            break;
                        case 1: //Exefs
                            UpdateTB(TB_Progress, "Writing Exefs...");
                            OutFileStream.Seek(0x4000 + (NCSD.NCCH_Array[0].Header.ExefsOffset * MEDIA_UNIT_SIZE), SeekOrigin.Begin);
                            byte[] OutExefs = new byte[NCSD.NCCH_Array[0].ExeFS.Data.Length];
                            aesctr.TransformBlock(NCSD.NCCH_Array[0].ExeFS.Data, 0, NCSD.NCCH_Array[0].ExeFS.Data.Length, OutExefs, 0);
                            OutFileStream.Write(OutExefs, 0, OutExefs.Length);
                            break;
                        case 2: //Romfs
                            UpdateTB(TB_Progress, "Writing Romfs...");
                            OutFileStream.Seek(0x4000 + (NCSD.NCCH_Array[0].Header.RomfsOffset * MEDIA_UNIT_SIZE), SeekOrigin.Begin);
                            using (FileStream InFileStream = new FileStream(NCSD.NCCH_Array[0].RomFS.FileName, FileMode.Open, FileAccess.Read))
                            {
                                uint BUFFER_SIZE;
                                ulong RomfsLen = NCSD.NCCH_Array[0].Header.RomfsSize * MEDIA_UNIT_SIZE;
                                PB_Show.Invoke((Action)(() =>
                                {
                                    PB_Show.Minimum = 0;
                                    PB_Show.Maximum = (int)(RomfsLen / 0x400000);
                                    PB_Show.Value = 0;
                                    PB_Show.Step = 1;
                                }));
                                for (ulong j = 0; j < RomfsLen; j += BUFFER_SIZE)
                                {
                                    BUFFER_SIZE = RomfsLen - j > 0x400000 ? 0x400000 : (uint)(RomfsLen - j);
                                    byte[] buf = new byte[BUFFER_SIZE];
                                    byte[] outbuf = new byte[BUFFER_SIZE];
                                    InFileStream.Read(buf, 0, (int)BUFFER_SIZE);
                                    aesctr.TransformBlock(buf, 0, (int)BUFFER_SIZE, outbuf, 0);
                                    OutFileStream.Write(outbuf, 0, (int)BUFFER_SIZE);
                                    PB_Show.Invoke((Action)PB_Show.PerformStep);
                                }
                            }
                            break;
                    }
                }
                UpdateTB(TB_Progress, "Writing Logo...");
                OutFileStream.Seek(0x4000 + (NCSD.NCCH_Array[0].Header.LogoOffset * MEDIA_UNIT_SIZE), SeekOrigin.Begin);
                OutFileStream.Write(NCSD.NCCH_Array[0].logo, 0, NCSD.NCCH_Array[0].logo.Length);
                if (NCSD.NCCH_Array[0].plainregion.Length > 0)
                {
                    UpdateTB(TB_Progress, "Writing Plain Region...");
                    OutFileStream.Seek(0x4000 + (NCSD.NCCH_Array[0].Header.PlainRegionOffset * MEDIA_UNIT_SIZE), SeekOrigin.Begin);
                    OutFileStream.Write(NCSD.NCCH_Array[0].plainregion, 0, NCSD.NCCH_Array[0].plainregion.Length);
                }

                //NCSD Padding
                if (!trimmed)
                {
                    OutFileStream.Seek((NCSD.Header.OffsetSizeTable[NCSD.NCCH_Array.Count - 1].Offset * MEDIA_UNIT_SIZE) + (NCSD.Header.OffsetSizeTable[NCSD.NCCH_Array.Count - 1].Size * MEDIA_UNIT_SIZE), SeekOrigin.Begin);
                    ulong TotalLen = NCSD.Header.MediaSize * MEDIA_UNIT_SIZE;
                    byte[] Buffer = Enumerable.Repeat((byte)0xFF, 0x400000).ToArray();
                    UpdateTB(TB_Progress, "Writing NCSD Padding...");
                    while ((ulong)OutFileStream.Position < TotalLen)
                    {
                        int BUFFER_LEN = TotalLen - (ulong)OutFileStream.Position < 0x400000 ? (int)(TotalLen - (ulong)OutFileStream.Position) : 0x400000;
                        OutFileStream.Write(Buffer, 0, BUFFER_LEN);
                    }
                }
            }

            //Delete Temporary Romfs File
            if (NCSD.NCCH_Array[0].RomFS.isTempFile)
                File.Delete(NCSD.NCCH_Array[0].RomFS.FileName);

            UpdateTB(TB_Progress, "Done!");
            return true;
        }

        /// <summary>
        /// Builds a CFA (Content Archive) binary for the manual/download-play partition.
        /// Creates a RomFS from the directory and wraps it in a minimal NCCH header.
        /// </summary>
        public static byte[] BuildCFA(string romfsDir, ulong titleId, byte contentType, RichTextBox TB_Progress = null)
        {
            string tempRomFS = Path.GetTempFileName();
            try
            {
                RomFS.BuildRomFS(romfsDir, tempRomFS, TB_Progress);
                byte[] romfsData = File.ReadAllBytes(tempRomFS);
                uint romfsSize = (uint)(romfsData.Length / MEDIA_UNIT_SIZE);

                // Build CFA NCCH header matching HackingToolkit v9 layout (RomFS at 0x8 MU)
                const uint RomFSOffset = 0x8; // matches HackingToolkit/manual CFA layout
                byte[] ncchHeader = new byte[0x200];
                // Signature (0x100 bytes of 0xFF)
                for (int i = 0; i < 0x100; i++)
                    ncchHeader[i] = 0xFF;
                // Magic "NCCH" in big-endian
                Array.Copy(new byte[] { 0x4E, 0x43, 0x43, 0x48 }, 0, ncchHeader, 0x100, 4);
                // Size in media units (header 0x200 + gap + RomFS)
                uint totalSize = RomFSOffset + romfsSize;
                Array.Copy(BitConverter.GetBytes(totalSize), 0, ncchHeader, 0x104, 4);
                // TitleId
                Array.Copy(BitConverter.GetBytes(titleId), 0, ncchHeader, 0x108, 8);
                // MakerCode = "01"
                ncchHeader[0x112] = 0x30; ncchHeader[0x113] = 0x31;
                // FormatVersion = 2
                ncchHeader[0x114] = 2;
                // Flags[5] = contentType (0x01=Data, 0x09=Data|Manual, 0x01=DLP child)
                ncchHeader[0x18D] = contentType;
                // Flags[7] = NoCrypto
                ncchHeader[0x18F] = 4;
                // RomFS offset = 0x8 MU (matches HackingToolkit manual CFA layout)
                Array.Copy(BitConverter.GetBytes(RomFSOffset), 0, ncchHeader, 0x1B0, 4);
                // RomFS size in media units
                Array.Copy(BitConverter.GetBytes(romfsSize), 0, ncchHeader, 0x1B4, 4);
                // RomFS SuperBlockHash
                int sbLen = (int)Math.Min(romfsData.Length, 0x200);
                byte[] sbHash = System.Security.Cryptography.SHA256.HashData(romfsData.AsSpan(0, sbLen));
                Array.Copy(sbHash, 0, ncchHeader, 0x1C0, 0x20);

                // Sign CFA NCCH header (0x100 bytes at offset 0x100) with makerom test key
                byte[] cfaSig = DebugPKI.SignRsa2048Sha256(ncchHeader, 0x100, 0x100);
                Array.Copy(cfaSig, 0, ncchHeader, 0, 0x100);

                // 0xE00 zero-fill between header and RomFS (RomFSOffset=8 means 7 MU gap)
                byte[] cfa = new byte[RomFSOffset * MEDIA_UNIT_SIZE + romfsData.Length];
                Array.Copy(ncchHeader, 0, cfa, 0, 0x200);
                // bytes 0x200..0x1000 remain zero (new byte[] default)
                Array.Copy(romfsData, 0, cfa, RomFSOffset * MEDIA_UNIT_SIZE, romfsData.Length);
                return cfa;
            }
            finally
            {
                if (File.Exists(tempRomFS))
                    File.Delete(tempRomFS);
            }
        }

        public static bool BuildCIA(string LOGO_NAME,
            string EXEFS_PATH, string ROMFS_PATH, string EXHEADER_PATH,
            string SERIAL_TEXT, string SAVE_PATH,
            ProgressBar PB_Show = null, RichTextBox TB_Progress = null,
            bool decrypted = false, ulong? titleIdOverride = null,
            byte[][] additionalContents = null)
        {
            PB_Show ??= new ProgressBar();
            TB_Progress ??= new RichTextBox();

            if (!((File.Exists(EXEFS_PATH) || Directory.Exists(EXEFS_PATH))
                && (File.Exists(ROMFS_PATH) || Directory.Exists(ROMFS_PATH))
                && File.Exists(EXHEADER_PATH)))
            {
                UpdateTB(TB_Progress, "错误: 缺少 ExeFS、RomFS 或 Exheader 文件。");
                return false;
            }

            // Extract SMDH from ExeFS directory for CIA meta section (before packing)
            byte[] smdhData = null;
            if (Directory.Exists(EXEFS_PATH))
            {
                string iconPath = Path.Combine(EXEFS_PATH, "icon.bin");
                if (File.Exists(iconPath))
                    smdhData = File.ReadAllBytes(iconPath);
            }

            if (!File.Exists(EXEFS_PATH) && Directory.Exists(EXEFS_PATH))
                ExeFS.PackExeFS(Directory.GetFiles(EXEFS_PATH), EXEFS_PATH = "exefs.bin");
            if (!File.Exists(ROMFS_PATH) && Directory.Exists(ROMFS_PATH))
                RomFS.BuildRomFS(ROMFS_PATH, ROMFS_PATH = "romfs.bin", TB_Progress, PB_Show);

            // Build the NCCH (same as 3DS build)
            NCCH NCCH = SetNCCH(EXEFS_PATH, ROMFS_PATH, EXHEADER_PATH, SERIAL_TEXT, LOGO_NAME, TB_Progress);

            // Apply Title ID override if requested (modifies Exheader, NCCH header, and later TMD/Ticket)
            ulong effectiveTitleId = NCCH.Exheader.TitleID;
            if (titleIdOverride.HasValue && titleIdOverride.Value != NCCH.Exheader.TitleID)
            {
                effectiveTitleId = titleIdOverride.Value;

                // 1. Update Exheader in-memory data at offset 0x200
                byte[] tidBytes = BitConverter.GetBytes(effectiveTitleId);
                Array.Copy(tidBytes, 0, NCCH.Exheader.Data, 0x200, 8);

                // 2. Also update jump_id in SystemControlInfo at Data[0x1C8]
                if (NCCH.Exheader.Data.Length >= 0x1D0)
                    Array.Copy(tidBytes, 0, NCCH.Exheader.Data, 0x1C8, 8);

                // 3. Also update programId in AccessDescriptor at offset 0x200
                if (NCCH.Exheader.AccessDescriptor.Length >= 0x208)
                    Array.Copy(tidBytes, 0, NCCH.Exheader.AccessDescriptor, 0x200, 8);

                // 4. Recompute Exheader hash
                NCCH.Header.ExheaderHash = NCCH.Exheader.GetSuperBlockHash();

                // 5. Update NCCH header TitleId and ProgramId
                NCCH.Header.TitleId = effectiveTitleId;
                NCCH.Header.ProgramId = effectiveTitleId;

                UpdateTB(TB_Progress, $"Title ID 已覆盖: 0x{effectiveTitleId:X016}");
            }

            // CIA always uses NoCrypto NCCH (Flags[7]=4, matching HackingToolkit/3dstool behavior).
            // FixedCrypto (Flags[7]=1) DOES NOT WORK on real 3DS — AM rejects it with RS_NOTFOUND.
            // The 'decrypted' flag controls TMD content Type (0=no title key encryption).

            // Rebuild NCCH header after all modifications
            NCCH.Header.BuildHeader();

            string tempNcch = Path.GetTempFileName();
            try
            {
                // Build the raw NCCH binary to a temp file (avoids MemoryStream 2 GB limit)
                byte[] key = new byte[0x10];
                long ncchSize = (long)NCCH.Header.Size * MEDIA_UNIT_SIZE;

                // Build NCCH sequentially (no seeks) while computing SHA256
                UpdateTB(TB_Progress, "计算内容哈希...");
                byte[] contentHash;
                using (var fs = new FileStream(tempNcch, FileMode.Create, FileAccess.Write))
                using (var sha = SHA256.Create())
                {
                    // Helper: zero-fill from current position to target, hashing as we go
                    void FillGap(long targetPos)
                    {
                        long gap = targetPos - fs.Position;
                        if (gap <= 0) return;
                        byte[] zeros = new byte[Math.Min(gap, 0x100000)];
                        while (gap > 0)
                        {
                            int write = (int)Math.Min(gap, zeros.Length);
                            fs.Write(zeros, 0, write);
                            sha.TransformBlock(zeros, 0, write, zeros, 0);
                            gap -= write;
                        }
                    }

                    // 1. NCCH Header
                    byte[] ncchHdr = NCCH.Header.Data;
                    fs.Write(ncchHdr, 0, ncchHdr.Length);
                    sha.TransformBlock(ncchHdr, 0, ncchHdr.Length, ncchHdr, 0);

                    // 2. Exheader (encrypted)
                    UpdateTB(TB_Progress, "写入 Exheader...");
                    FillGap(0x200);
                    byte[] exhRaw = new byte[NCCH.Exheader.Data.Length + NCCH.Exheader.AccessDescriptor.Length];
                    Array.Copy(NCCH.Exheader.Data, exhRaw, NCCH.Exheader.Data.Length);
                    Array.Copy(NCCH.Exheader.AccessDescriptor, 0, exhRaw, NCCH.Exheader.Data.Length, NCCH.Exheader.AccessDescriptor.Length);
                    // NoCrypto: write plaintext (HackingToolkit-compatible, real 3DS AM requires this)
                    byte[] exhOut = exhRaw;
                    fs.Write(exhOut, 0, exhOut.Length);
                    sha.TransformBlock(exhOut, 0, exhOut.Length, exhOut, 0);

                    // 3. Logo (plain)
                    FillGap((long)NCCH.Header.LogoOffset * MEDIA_UNIT_SIZE);
                    fs.Write(NCCH.logo, 0, NCCH.logo.Length);
                    sha.TransformBlock(NCCH.logo, 0, NCCH.logo.Length, NCCH.logo, 0);

                    // 4. Plain Region (plain)
                    if (NCCH.plainregion.Length > 0)
                    {
                        FillGap((long)NCCH.Header.PlainRegionOffset * MEDIA_UNIT_SIZE);
                        fs.Write(NCCH.plainregion, 0, NCCH.plainregion.Length);
                        sha.TransformBlock(NCCH.plainregion, 0, NCCH.plainregion.Length, NCCH.plainregion, 0);
                    }

                    // 5. ExeFS (plaintext for NoCrypto)
                    UpdateTB(TB_Progress, "写入 ExeFS...");
                    FillGap((long)NCCH.Header.ExefsOffset * MEDIA_UNIT_SIZE);
                    byte[] exefsOut = NCCH.ExeFS.Data;
                    fs.Write(exefsOut, 0, exefsOut.Length);
                    sha.TransformBlock(exefsOut, 0, exefsOut.Length, exefsOut, 0);

                    // 6. RomFS (plaintext for NoCrypto)
                    UpdateTB(TB_Progress, "写入 RomFS...");
                    FillGap((long)NCCH.Header.RomfsOffset * MEDIA_UNIT_SIZE);
                    using (FileStream romfsIn = new FileStream(NCCH.RomFS.FileName, FileMode.Open, FileAccess.Read))
                    {
                        ulong romfsLen = (ulong)NCCH.Header.RomfsSize * MEDIA_UNIT_SIZE;
                        for (ulong j = 0; j < romfsLen;)
                        {
                            uint bufSize = (uint)Math.Min(romfsLen - j, 0x400000);
                            byte[] buf = new byte[bufSize];
                            romfsIn.Read(buf, 0, (int)bufSize);
                            fs.Write(buf, 0, (int)bufSize);
                            sha.TransformBlock(buf, 0, (int)bufSize, buf, 0);
                            j += bufSize;
                        }
                    }

                    // 7. Trailing zero-fill to full NCCH size
                    if (ncchSize > fs.Position)
                    {
                        long remaining = ncchSize - fs.Position;
                        byte[] zeros = new byte[Math.Min(remaining, 0x100000)];
                        while (remaining > 0)
                        {
                            int write = (int)Math.Min(remaining, zeros.Length);
                            fs.Write(zeros, 0, write);
                            sha.TransformBlock(zeros, 0, write, zeros, 0);
                            remaining -= write;
                        }
                    }
                    fs.SetLength(ncchSize);

                    sha.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
                    contentHash = sha.Hash;
                }

                // Read TMD metadata from Exheader
                uint saveDataSize = 0;
                if (NCCH.Exheader.Data.Length >= 0x1C8)
                    saveDataSize = (uint)BitConverter.ToUInt64(NCCH.Exheader.Data, 0x1C0);
                ushort remasterVersion = 0;
                if (NCCH.Exheader.Data.Length >= 0x3C)
                    remasterVersion = BitConverter.ToUInt16(NCCH.Exheader.Data, 0x03A);
                ushort titleVersion = (ushort)((remasterVersion << 10) & 0xFC00);

                // Build CIA metadata in memory
                var tmd = new TMD
                {
                    TitleID = effectiveTitleId,
                    SaveDataSize = saveDataSize,
                    TitleVersion = titleVersion,
                    Contents =
                    {
                        new ContentChunkRecord
                        {
                            ID = 0,
                            Index = 0,
                            Type = decrypted ? (ushort)0 : (ushort)1, // 0 = not CIA-level encrypted
                            Size = (ulong)ncchSize,
                            Hash = contentHash,
                        }
                    }
                };

                // Add additional contents (manual CFA, download play, etc.)
                byte[][] addContentHashes = null;
                if (additionalContents != null && additionalContents.Length > 0)
                {
                    addContentHashes = new byte[additionalContents.Length][];
                    for (int i = 0; i < additionalContents.Length; i++)
                    {
                        byte[] addData = additionalContents[i];
                        byte[] addHash = System.Security.Cryptography.SHA256.HashData(addData);
                        addContentHashes[i] = addHash;
                        tmd.Contents.Add(new ContentChunkRecord
                        {
                            ID = (uint)(i + 1),
                            Index = (ushort)(i + 1),
                            Type = (ushort)(decrypted ? 0 : 1),
                            Size = (ulong)addData.Length,
                            Hash = addHash,
                        });
                    }
                }

                var ticket = new Ticket
                {
                    TitleID = effectiveTitleId,
                    TicketVersion = titleVersion,
                    KeyId = 0,
                };
                // Generate random TicketID matching makerom format: 0x00040000XXXXXXXX
                byte[] ticketIdBytes = new byte[4];
                System.Security.Cryptography.RandomNumberGenerator.Fill(ticketIdBytes);
                ticket.TicketID = 0x0004000000000000UL | BitConverter.ToUInt32(ticketIdBytes, 0);
                // For non-encrypted CIA, generate random encrypted title key (makerom compatibility)
                System.Security.Cryptography.RandomNumberGenerator.Fill(ticket.EncryptedTitleKey);

                byte[] certChain = CIA.BuildDefaultCertChain(); // CA+XS+CP, 64-byte aligned
                byte[] ticketData = ticket.Build();             // 0x350
                byte[] tmdData = tmd.Build();                   // variable

                // Calculate total content size (NCCH + additional contents, each 64-byte aligned)
                long contentSize = ncchSize;
                if (additionalContents != null)
                {
                    foreach (var addData in additionalContents)
                        contentSize = ((contentSize + 0x3F) & ~0x3FL) + addData.Length;
                }

                // Pre-compute 64-byte aligned section offsets (makerom-style)
                long headerSize = CIA.DefaultHeaderSize; // 0x2020
                long Align64(long v) => (v + 0x3F) & ~0x3F;

                long certOff = Align64(headerSize);
                long tikOff = Align64(certOff + certChain.Length);
                long tmdOff = Align64(tikOff + ticketData.Length);
                long contentOff = Align64(tmdOff + tmdData.Length);
                long metaOff = Align64(contentOff + contentSize);

                // Build CIA directly to output file
                UpdateTB(TB_Progress, "打包 CIA...");
                using (var outFs = new FileStream(SAVE_PATH, FileMode.Create, FileAccess.Write))
                {
                    // 1. CIA Header (0x2020 bytes including content index)
                    var hdr = new byte[0x20];
                    Array.Copy(BitConverter.GetBytes(CIA.DefaultHeaderSize), 0, hdr, 0, 4);
                    Array.Copy(BitConverter.GetBytes((ushort)0), 0, hdr, 4, 2); // type
                    Array.Copy(BitConverter.GetBytes((ushort)0), 0, hdr, 6, 2); // version
                    Array.Copy(BitConverter.GetBytes(certChain.Length), 0, hdr, 8, 4);
                    Array.Copy(BitConverter.GetBytes(ticketData.Length), 0, hdr, 0xC, 4);
                    Array.Copy(BitConverter.GetBytes(tmdData.Length), 0, hdr, 0x10, 4);
                    int metaSize = smdhData != null ? 0x400 + smdhData.Length : 0;
                    Array.Copy(BitConverter.GetBytes(metaSize), 0, hdr, 0x14, 4); // meta size (makerom: header + SMDH)
                    Array.Copy(BitConverter.GetBytes((ulong)contentSize), 0, hdr, 0x18, 8);
                    outFs.Write(hdr, 0, hdr.Length);

                    // Content Index bitmask (0x2000 bytes): MSB-first, bit 7 = content index 0
                    byte[] contentIndex = new byte[0x2000];
                    contentIndex[0] = 0x80; // content index 0
                    if (additionalContents != null)
                    {
                        for (int i = 0; i < additionalContents.Length; i++)
                            contentIndex[0] |= (byte)(0x80 >> (i + 1)); // content index 1, 2, ...
                    }
                    outFs.Write(contentIndex, 0, contentIndex.Length);

                    // 2. Certificate chain at aligned offset
                    outFs.Seek(certOff, SeekOrigin.Begin);
                    outFs.Write(certChain, 0, certChain.Length);

                    // 3. Ticket at aligned offset
                    outFs.Seek(tikOff, SeekOrigin.Begin);
                    outFs.Write(ticketData, 0, ticketData.Length);

                    // 4. TMD at aligned offset
                    outFs.Seek(tmdOff, SeekOrigin.Begin);
                    outFs.Write(tmdData, 0, tmdData.Length);

                    // 5. Content at aligned offset
                    outFs.Seek(contentOff, SeekOrigin.Begin);

                    // 5a. Main NCCH content (streamed from temp file)
                    using (var ncchFs = new FileStream(tempNcch, FileMode.Open, FileAccess.Read))
                    {
                        byte[] buf = new byte[0x400000];
                        int read;
                        while ((read = ncchFs.Read(buf, 0, buf.Length)) > 0)
                            outFs.Write(buf, 0, read);
                    }

                    // 5b. Additional contents (manual CFA, download play, etc.), each 64-byte aligned
                    if (additionalContents != null)
                    {
                        foreach (var addData in additionalContents)
                        {
                            // 64-byte align before each additional content
                            long padTo = (outFs.Position + 0x3F) & ~0x3FL;
                            outFs.Seek(padTo, SeekOrigin.Begin);
                            outFs.Write(addData, 0, addData.Length);
                        }
                    }

                    // 6. Write Meta section (makerom-style: 0x400 header + SMDH) if available
                    if (smdhData != null)
                    {
                        byte[] metaHeader = new byte[0x400];
                        outFs.Seek(metaOff, SeekOrigin.Begin);
                        outFs.Write(metaHeader, 0, metaHeader.Length);
                        outFs.Write(smdhData, 0, smdhData.Length);
                        outFs.SetLength(metaOff + metaSize);
                    }
                    else
                    {
                        outFs.SetLength(metaOff);
                    }
                }

                // Verify content hash by reading back from the built CIA
                UpdateTB(TB_Progress, "验证内容哈希...");
                using (var verifyFs = new FileStream(SAVE_PATH, FileMode.Open, FileAccess.Read))
                using (var verifySha = System.Security.Cryptography.SHA256.Create())
                {
                    verifyFs.Seek(contentOff, SeekOrigin.Begin);
                    long remaining = ncchSize;
                    byte[] buf = new byte[0x400000]; // 4 MB chunks
                    while (remaining > 0)
                    {
                        int read = verifyFs.Read(buf, 0, (int)Math.Min((long)buf.Length, remaining));
                        if (read == 0) break;
                        verifySha.TransformBlock(buf, 0, read, buf, 0);
                        remaining -= read;
                    }
                    verifySha.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
                    byte[] verifyHash = verifySha.Hash;
                    long totalRead = ncchSize - remaining;
                    bool hashOk = verifyHash.AsSpan().SequenceEqual(contentHash);
                    UpdateTB(TB_Progress, hashOk
                        ? $"内容哈希验证通过 ({totalRead} 字节)"
                        : $"内容哈希不匹配! 期望: {BitConverter.ToString(contentHash).Replace("-", "").Substring(0, 16)}... 实际: {BitConverter.ToString(verifyHash).Replace("-", "").Substring(0, 16)}...");
                }

                // Clean up temp files
                if (NCCH.RomFS.isTempFile)
                    File.Delete(NCCH.RomFS.FileName);

                UpdateTB(TB_Progress, "CIA 构建完成!");
                return true;
            }
            catch (Exception ex)
            {
                UpdateTB(TB_Progress, $"错误: {ex.Message}\n堆栈: {ex.StackTrace}");
                return false;
            }
            finally
            {
                if (File.Exists(tempNcch))
                    File.Delete(tempNcch);
            }
        }

        // Utility
        internal static bool IsValid(string exeFS, string romFS, string exeheader, string path, string serial, bool Card2)
        {
            bool isSerialValid = true;
            if (serial.Length == 10)
            {
                string[] subs = serial.Split('-');
                if (subs.Length != 3)
                {
                    isSerialValid = false;
                }
                else
                {
                    if (subs[0].Length != 3 || subs[1].Length != 1 || subs[2].Length != 4)
                    {
                        isSerialValid = false;
                    }
                    else if (subs[0] != "CTR" && subs[0] != "KTR")
                    {
                        isSerialValid = false;
                    }
                    else if (subs[1] != "P" && subs[1] != "N" && subs[2] != "U")
                    {
                        isSerialValid = false;
                    }
                    else
                    {
                        if (subs[2].Any(c => !char.IsLetterOrDigit(c)))
                            isSerialValid = false;
                    }
                }
            }
            else
            {
                isSerialValid = false;
            }
            if (string.IsNullOrEmpty(exeFS)
                || string.IsNullOrEmpty(romFS)
                || string.IsNullOrEmpty(exeheader)
                || string.IsNullOrEmpty(path)
                || !isSerialValid)
            {
                return false;
            }

            Exheader exh = new Exheader(exeheader);
            return !exh.IsSupported() || Card2;
        }

        internal static void UpdateTB(RichTextBox RTB, string progress)
        {
            try
            {
                if (RTB.InvokeRequired)
                {
                    RTB.Invoke((MethodInvoker)delegate
                   {
                       RTB.AppendText(Environment.NewLine + progress);
                       RTB.SelectionStart = RTB.Text.Length;
                       RTB.ScrollToCaret();
                   });
                }
                else
                {
                    RTB.SelectionStart = RTB.Text.Length;
                    RTB.ScrollToCaret();
                    RTB.AppendText(progress + Environment.NewLine);
                }
            }
            catch { }
        }

        internal static ulong Align(ulong input, ulong alignsize)
        {
            ulong output = input;
            if (output % alignsize != 0)
            {
                output += alignsize - (output % alignsize);
            }
            return output;
        }
    }
}
