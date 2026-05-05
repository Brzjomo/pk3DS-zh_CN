using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace pk3DS.Core.CTR;

public static class CiaValidator
{
    public static void DumpCiaStructure(string ciaPath, string outputPath)
    {
        using var fs = new FileStream(ciaPath, FileMode.Open, FileAccess.Read);
        using var sw = new StreamWriter(outputPath, false, Encoding.UTF8);

        long fileLen = fs.Length;
        sw.WriteLine($"=== CIA Structure Dump ===");
        sw.WriteLine($"File size: 0x{fileLen:X} ({fileLen} bytes)\n");

        // Read CIA header
        byte[] hdr = new byte[0x20];
        fs.Read(hdr, 0, 0x20);
        uint hdrSize = BitConverter.ToUInt32(hdr, 0);
        ushort type = BitConverter.ToUInt16(hdr, 4);
        ushort fmtVer = BitConverter.ToUInt16(hdr, 6);
        uint certSize = BitConverter.ToUInt32(hdr, 8);
        uint tikSize = BitConverter.ToUInt32(hdr, 0xC);
        uint tmdSize = BitConverter.ToUInt32(hdr, 0x10);
        uint metaSize = BitConverter.ToUInt32(hdr, 0x14);
        ulong contentSize = BitConverter.ToUInt64(hdr, 0x18);

        sw.WriteLine("--- CIA Header ---");
        sw.WriteLine($"Header Size:      0x{hdrSize:X} (expected 0x2020)");
        sw.WriteLine($"Type:             0x{type:X4} (expected 0x0000)");
        sw.WriteLine($"Format Version:   0x{fmtVer:X4} (expected 0x0000)");
        sw.WriteLine($"Cert Chain Size:  0x{certSize:X}");
        sw.WriteLine($"Ticket Size:      0x{tikSize:X} (expected 0x350)");
        sw.WriteLine($"TMD Size:         0x{tmdSize:X}");
        sw.WriteLine($"Meta/Footer Size: 0x{metaSize:X}");
        sw.WriteLine($"Content Size:     0x{contentSize:X}");

        if (hdrSize != 0x2020)
            sw.WriteLine("[WARN] Unexpected header size!");
        if (type != 0)
            sw.WriteLine("[WARN] Unexpected CIA type!");
        if (fmtVer != 0)
            sw.WriteLine("[WARN] Unexpected format version!");
        if (tikSize != 0x350)
            sw.WriteLine($"[WARN] Unexpected ticket size (got 0x{tikSize:X}, expected 0x350)");

        // Content index bitmap
        byte[] contentIdx = new byte[0x2000];
        fs.Seek(0x20, SeekOrigin.Begin);
        fs.Read(contentIdx, 0, 0x2000);
        sw.WriteLine($"\n--- Content Index Bitmap ---");
        sw.WriteLine($"Byte 0: 0x{contentIdx[0]:X2} (expected 0x80 for index 0)");

        // Calculate section offsets (64-byte alignment)
        long Align64(long v) => (v + 0x3F) & ~0x3F;
        long certOff = Align64(hdrSize);
        long tikOff = Align64(certOff + certSize);
        long tmdOff = Align64(tikOff + tikSize);
        long contentOff = Align64(tmdOff + tmdSize);
        long metaOff = Align64(contentOff + (long)contentSize);

        sw.WriteLine($"\n--- Section Offsets (64-byte aligned) ---");
        sw.WriteLine($"Cert chain:  0x{certOff:X} (expected at 0x2040)");
        sw.WriteLine($"Ticket:      0x{tikOff:X}");
        sw.WriteLine($"TMD:         0x{tmdOff:X}");
        sw.WriteLine($"Content:     0x{contentOff:X}");
        sw.WriteLine($"Meta/Footer: 0x{metaOff:X}");
        sw.WriteLine($"File end:    0x{metaOff + metaSize:X}");

        // Read Ticket
        fs.Seek(tikOff, SeekOrigin.Begin);
        byte[] tik = new byte[tikSize];
        fs.Read(tik, 0, (int)tikSize);
        ulong tikTitleId = ReadBE64(tik, 0x140 + 0x9C);
        ushort tikVer = ReadBE16(tik, 0x140 + 0xA6);
        byte[] encKey = new byte[0x10];
        Array.Copy(tik, 0x140 + 0x7F, encKey, 0, 0x10);

        sw.WriteLine($"\n--- Ticket ---");
        sw.WriteLine($"Issuer:        {ReadAscii(tik, 0x140, 0x40)}");
        sw.WriteLine($"Title ID:      0x{tikTitleId:X016}");
        sw.WriteLine($"Ticket Ver:    0x{tikVer:X4}");
        sw.WriteLine($"Enc Title Key: {BitConverter.ToString(encKey).Replace("-", "")}");
        sw.WriteLine($"Licence Type:  0x{tik[0x140 + 0xB0]:X2}");

        // Read TMD
        fs.Seek(tmdOff, SeekOrigin.Begin);
        byte[] tmd = new byte[tmdSize];
        fs.Read(tmd, 0, (int)tmdSize);
        ulong tmdTitleId = ReadBE64(tmd, 0x140 + 0x4C);
        uint tmdTitleType = ReadBE32(tmd, 0x140 + 0x54);
        uint tmdSaveDataSize = BitConverter.ToUInt32(tmd, 0x140 + 0x5A);
        uint tmdAccessRights = ReadBE32(tmd, 0x140 + 0x98);
        ushort tmdTitleVer = ReadBE16(tmd, 0x140 + 0x9C);
        ushort tmdContentCount = ReadBE16(tmd, 0x140 + 0x9E);

        sw.WriteLine($"\n--- TMD ---");
        sw.WriteLine($"Issuer:        {ReadAscii(tmd, 0x140, 0x40)}");
        sw.WriteLine($"Title ID:      0x{tmdTitleId:X016}");
        sw.WriteLine($"Title Type:    0x{tmdTitleType:X8}");
        sw.WriteLine($"SaveDataSize:  0x{tmdSaveDataSize:X}");
        sw.WriteLine($"AccessRights:  0x{tmdAccessRights:X8}");
        sw.WriteLine($"Title Ver:     0x{tmdTitleVer:X4}");
        sw.WriteLine($"Content Count: {tmdContentCount}");

        // Read Content Info Records
        int infoOffset = 0x140 + 0xC4;
        for (int i = 0; i < 64; i++)
        {
            ushort idxOff = ReadBE16(tmd, infoOffset + i * 0x24);
            ushort cmdCnt = ReadBE16(tmd, infoOffset + i * 0x24 + 2);
            if (idxOff != 0 || cmdCnt != 0)
            {
                sw.WriteLine($"\n  Content Info [{i}]: idxOffset={idxOff}, cmdCount={cmdCnt}");
                byte[] infoHash = new byte[0x20];
                Array.Copy(tmd, infoOffset + i * 0x24 + 4, infoHash, 0, 0x20);
                sw.WriteLine($"  Info Hash: {BitConverter.ToString(infoHash).Replace("-", "")}");
            }
        }

        // Read Content Chunk Records
        int chunkOffset = infoOffset + 64 * 0x24;
        for (int i = 0; i < tmdContentCount; i++)
        {
            uint cid = ReadBE32(tmd, chunkOffset + i * 0x30);
            ushort cidx = ReadBE16(tmd, chunkOffset + i * 0x30 + 4);
            ushort ctype = ReadBE16(tmd, chunkOffset + i * 0x30 + 6);
            ulong csize = ReadBE64(tmd, chunkOffset + i * 0x30 + 8);
            byte[] chash = new byte[0x20];
            Array.Copy(tmd, chunkOffset + i * 0x30 + 0x10, chash, 0, 0x20);

            sw.WriteLine($"\n--- Content Chunk [{i}] ---");
            sw.WriteLine($"ID:          0x{cid:X8}");
            sw.WriteLine($"Index:       {cidx}");
            sw.WriteLine($"Type:        0x{ctype:X4}");
            sw.WriteLine($"Size:        0x{csize:X}");
            sw.WriteLine($"Hash:        {BitConverter.ToString(chash).Replace("-", "")}");

            // Verify content hash
            fs.Seek(contentOff, SeekOrigin.Begin);
            byte[] contentData = new byte[csize];
            fs.Read(contentData, 0, (int)csize);
            byte[] computedHash = SHA256.HashData(contentData);
            bool hashMatch = CompareBytes(chash, computedHash);
            sw.WriteLine($"Hash Match:   {hashMatch}");
            if (!hashMatch)
                sw.WriteLine($"[ERROR] Content hash mismatch!");
            else
                sw.WriteLine($"[OK] Content hash verified.");

            // Read NCCH header from content
            if (contentData.Length >= 0x200)
            {
                DumpNcchHeader(contentData, sw);
            }
        }

        sw.WriteLine("\n=== End of Dump ===");
        sw.Flush();
        Console.WriteLine($"Dump written to {outputPath}");
    }

    private static void DumpNcchHeader(byte[] ncch, StreamWriter sw)
    {
        uint magic = BitConverter.ToUInt32(ncch, 0x100);
        uint ncchSize = BitConverter.ToUInt32(ncch, 0x104);
        ulong titleId = BitConverter.ToUInt64(ncch, 0x108);
        ushort makerCode = BitConverter.ToUInt16(ncch, 0x110);
        ushort fmtVersion = BitConverter.ToUInt16(ncch, 0x112);
        ulong programId = BitConverter.ToUInt64(ncch, 0x118);
        uint exhSize = BitConverter.ToUInt32(ncch, 0x180);

        byte[] flags = new byte[8];
        Array.Copy(ncch, 0x188, flags, 0, 8);

        uint logoOfs = BitConverter.ToUInt32(ncch, 0x198);
        uint logoSize = BitConverter.ToUInt32(ncch, 0x19C);
        uint plainOfs = BitConverter.ToUInt32(ncch, 0x190);
        uint plainSize = BitConverter.ToUInt32(ncch, 0x194);
        uint exefsOfs = BitConverter.ToUInt32(ncch, 0x1A0);
        uint exefsSize = BitConverter.ToUInt32(ncch, 0x1A4);
        uint romfsOfs = BitConverter.ToUInt32(ncch, 0x1B0);
        uint romfsSize = BitConverter.ToUInt32(ncch, 0x1B4);

        byte[] exhHash = new byte[0x20];
        Array.Copy(ncch, 0x160, exhHash, 0, 0x20);
        byte[] exefsHash = new byte[0x20];
        Array.Copy(ncch, 0x1C0, exefsHash, 0, 0x20);
        byte[] romfsHash = new byte[0x20];
        Array.Copy(ncch, 0x1E0, romfsHash, 0, 0x20);

        byte[] productCode = new byte[0x10];
        Array.Copy(ncch, 0x150, productCode, 0, 0x10);

        sw.WriteLine($"\n--- NCCH Header ---");
        sw.WriteLine($"Magic:        0x{magic:X8} (expected 0x4843434E = 'NCCH')");
        sw.WriteLine($"Size:         0x{ncchSize:X} media units = 0x{(long)ncchSize * 0x200:X} bytes");
        sw.WriteLine($"Title ID:     0x{titleId:X016}");
        sw.WriteLine($"Maker Code:   0x{makerCode:X4}");
        sw.WriteLine($"Format Ver:   0x{fmtVersion:X4}");
        sw.WriteLine($"Program ID:   0x{programId:X016}");
        sw.WriteLine($"Product Code: {Encoding.ASCII.GetString(productCode).TrimEnd('\0')}");
        sw.WriteLine($"ExH Size:     0x{exhSize:X} media units = 0x{exhSize * 0x200:X} bytes");
        sw.WriteLine($"Flags[3]:     0x{flags[3]:X2} (Crypto: 0=<7.x)");
        sw.WriteLine($"Flags[4]:     0x{flags[4]:X2} (Platform: 1=CTR)");
        sw.WriteLine($"Flags[5]:     0x{flags[5]:X2} (Type: 3=Data|Exec)");
        sw.WriteLine($"Flags[6]:     0x{flags[6]:X2} (MediaUnit = 0x200)");
        sw.WriteLine($"Flags[7]:     0x{flags[7]:X2} (Enc: 1=FixedCrypto, 4=NoCrypto, 5=both)");

        sw.WriteLine($"Logo:         0x{logoOfs:X} + 0x{logoSize:X}");
        sw.WriteLine($"Plain Region: 0x{plainOfs:X} + 0x{plainSize:X}");
        sw.WriteLine($"ExeFS:        0x{exefsOfs:X} + 0x{exefsSize:X}");
        sw.WriteLine($"RomFS:        0x{romfsOfs:X} + 0x{romfsSize:X}");

        // Verify ExheaderHash
        long exhDataSize = exhSize * 0x200L;
        if (ncch.Length >= 0x200 + exhDataSize)
        {
            byte[] exheaderData = new byte[exhDataSize];
            Array.Copy(ncch, 0x200, exheaderData, 0, exhDataSize);
            byte[] computedExhHash = SHA256.HashData(exheaderData);
            bool exhHashOk = CompareBytes(exhHash, computedExhHash);
            sw.WriteLine($"ExH Hash OK:  {exhHashOk}");
            if (!exhHashOk)
            {
                sw.WriteLine($"  Stored: {BitConverter.ToString(exhHash).Replace("-", "")}");
                sw.WriteLine($"  Actual: {BitConverter.ToString(computedExhHash).Replace("-", "")}");
            }
            else
                sw.WriteLine($"[OK] ExheaderHash verified ({exhDataSize} bytes)");
        }

        // Check Title ID consistency
        sw.WriteLine($"\n--- Title ID Consistency ---");
        sw.WriteLine($"NCCH TitleId:  0x{titleId:X016}");
        sw.WriteLine($"NCCH ProgramId: 0x{programId:X016}");
        if (titleId != programId)
            sw.WriteLine($"[WARN] NCCH TitleId != ProgramId");
    }

    private static ulong ReadBE64(byte[] data, int offset)
    {
        return ((ulong)data[offset] << 56) | ((ulong)data[offset + 1] << 48) |
               ((ulong)data[offset + 2] << 40) | ((ulong)data[offset + 3] << 32) |
               ((ulong)data[offset + 4] << 24) | ((ulong)data[offset + 5] << 16) |
               ((ulong)data[offset + 6] << 8) | data[offset + 7];
    }

    private static uint ReadBE32(byte[] data, int offset)
    {
        return ((uint)data[offset] << 24) | ((uint)data[offset + 1] << 16) |
               ((uint)data[offset + 2] << 8) | data[offset + 3];
    }

    private static ushort ReadBE16(byte[] data, int offset)
    {
        return (ushort)((data[offset] << 8) | data[offset + 1]);
    }

    private static string ReadAscii(byte[] data, int offset, int maxLen)
    {
        int end = offset;
        while (end < offset + maxLen && end < data.Length && data[end] != 0) end++;
        return Encoding.ASCII.GetString(data, offset, end - offset);
    }

    private static bool CompareBytes(byte[] a, byte[] b)
    {
        if (a.Length != b.Length) return false;
        for (int i = 0; i < a.Length; i++)
            if (a[i] != b[i]) return false;
        return true;
    }
}
