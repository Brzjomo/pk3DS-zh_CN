using System;
using System.Collections.Generic;

namespace pk3DS.Core.CTR
{
    public class TMD
    {
        // Signature
        public uint SignatureType = 0x10004; // RSA-2048-SHA256 (big-endian: 0x00010004)
        public byte[] Signature = new byte[0x100];

        // TMD Header
        public string Issuer = "Root-CA00000003-CP0000000b";
        public byte FormatVersion = 1;
        public byte CaCrlVersion;
        public byte SignerCrlVersion;
        public ulong SystemVersion;
        public ulong TitleID;
        public uint TitleType = 0x40; // CTR
        public ushort GroupID;
        public uint SaveDataSize;
        public uint PrivSaveDataSize;
        public byte TwlFlag;
        public uint AccessRights;
        public ushort TitleVersion;
        public ushort BootContent;
        public List<ContentChunkRecord> Contents = new List<ContentChunkRecord>();

        public const int ContentInfoRecordCount = 64;
        public const int ContentInfoRecordSize = 0x24;
        public const int ContentChunkRecordSize = 0x30;
        public const int SignatureOffset = 0x140; // where tmd_hdr starts after RSA-2048 sig

        public byte[] Build()
        {
            int contentCount = Contents.Count;
            int totalSize = SignatureOffset + 0xC4 + (ContentInfoRecordCount * ContentInfoRecordSize)
                          + (contentCount * ContentChunkRecordSize);

            byte[] data = new byte[totalSize];

            // --- Signature area (0x00 - 0x13F) ---
            // RSA-2048: sigType[4] + sigData[0x100] + padding[0x3C] = 0x140
            // Signature Type (BIG ENDIAN)
            WriteBE(data, 0, SignatureType, 4);
            // Signature at 0x04 (0x100 bytes) — fill 0xFF for unsigned
            for (int i = 0; i < 0x100; i++)
                data[0x04 + i] = 0xFF;
            if (Signature != null && Signature.Length > 0 && !IsAllZero(Signature))
                Array.Copy(Signature, 0, data, 0x04, Math.Min(Signature.Length, 0x100));
            // Padding 0x104-0x13F (already zeros)

            // --- TMD Header (0x140 - 0x203) ---
            int hdr = SignatureOffset; // 0x140
            // Issuer (0x40 bytes)
            byte[] issuerBytes = System.Text.Encoding.ASCII.GetBytes(Issuer ?? "Root");
            Array.Copy(issuerBytes, 0, data, hdr + 0x00, Math.Min(issuerBytes.Length, 0x40));
            // FormatVersion (1)
            data[hdr + 0x40] = FormatVersion;
            // CaCrlVersion (1)
            data[hdr + 0x41] = CaCrlVersion;
            // SignerCrlVersion (1)
            data[hdr + 0x42] = SignerCrlVersion;
            // Padding (1) at 0x43 (already 0)
            // SystemVersion (8) at 0x44
            Array.Copy(BitConverter.GetBytes(SystemVersion), 0, data, hdr + 0x44, 8);
            // TitleID (8, BIG ENDIAN) at 0x4C
            WriteBE(data, hdr + 0x4C, TitleID, 8);
            // TitleType (4, BIG ENDIAN) at 0x54
            WriteBE(data, hdr + 0x54, TitleType, 4);
            // GroupID (2) at 0x58
            Array.Copy(BitConverter.GetBytes(GroupID), 0, data, hdr + 0x58, 2);
            // SaveDataSize (4, LE) at 0x5A
            Array.Copy(BitConverter.GetBytes(SaveDataSize), 0, data, hdr + 0x5A, 4);
            // PrivSaveDataSize (4, LE) at 0x5E
            Array.Copy(BitConverter.GetBytes(PrivSaveDataSize), 0, data, hdr + 0x5E, 4);
            // Padding (4) at 0x62 (already 0)
            // TwlFlag (1) at 0x66
            data[hdr + 0x66] = TwlFlag;
            // Padding (0x31) at 0x67-0x97 (already 0)
            // AccessRights (4, BIG ENDIAN) at 0x98
            WriteBE(data, hdr + 0x98, AccessRights, 4);
            // TitleVersion (2, BIG ENDIAN) at 0x9C
            WriteBE(data, hdr + 0x9C, TitleVersion, 2);
            // ContentCount (2, BIG ENDIAN) at 0x9E
            WriteBE(data, hdr + 0x9E, (ushort)contentCount, 2);
            // BootContent (2) at 0xA0
            WriteBE(data, hdr + 0xA0, BootContent, 2);
            // Padding (2) at 0xA2 (already 0)
            // InfoRecordHash (0x20) at 0xA4 — computed below

            // --- Content Info Records (64 records × 0x24 = 0x900 bytes at offset 0x204) ---
            int infoOffset = SignatureOffset + 0xC4; // 0x204

            // Serialize all chunk records first to compute hash for info records
            int chunkOffset = infoOffset + (ContentInfoRecordCount * ContentInfoRecordSize); // 0xB04
            byte[] chunkData = new byte[contentCount * ContentChunkRecordSize];
            for (int i = 0; i < contentCount; i++)
            {
                Contents[i].Serialize(chunkData, i * ContentChunkRecordSize);
            }

            // For 3DS TMD, there are always 64 content info records.
            // Each covers a range of content indices.
            // We fill in only the first and leave rest as zero.
            // Info record 0: covers indices 0-63
            ushort cmdCount = (ushort)contentCount;
            WriteBE(data, infoOffset + 0, 0, 2);      // contentIndexOffset = 0
            WriteBE(data, infoOffset + 2, cmdCount, 2); // contentCommandCount = contentCount

            // Hash of all chunk records
            byte[] infoHash = System.Security.Cryptography.SHA256.HashData(chunkData);
            Array.Copy(infoHash, 0, data, infoOffset + 4, 0x20);

            // Hash of all info records (to fill into TMD header)
            byte[] allInfoRecords = new byte[ContentInfoRecordCount * ContentInfoRecordSize];
            Array.Copy(data, infoOffset, allInfoRecords, 0, ContentInfoRecordCount * ContentInfoRecordSize);
            byte[] hdrHash = System.Security.Cryptography.SHA256.HashData(allInfoRecords);
            Array.Copy(hdrHash, 0, data, hdr + 0xA4, 0x20);

            // --- Content Chunk Records (at 0xB04+) ---
            Array.Copy(chunkData, 0, data, chunkOffset, chunkData.Length);

            // Sign TMD header (0xC4 bytes starting at offset 0x140) with makerom test key
            const int tmdHeaderSize = 0xC4;
            byte[] tmdSig = DebugPKI.SignRsa2048Sha256(data, SignatureOffset, tmdHeaderSize);
            Array.Copy(tmdSig, 0, data, 4, 0x100);

            return data;
        }

        private static void WriteBE(byte[] dest, int offset, ulong value, int bytes)
        {
            for (int i = 0; i < bytes; i++)
                dest[offset + i] = (byte)((value >> ((bytes - 1 - i) * 8)) & 0xFF);
        }

        private static void WriteBE(byte[] dest, int offset, uint value, int bytes)
        {
            WriteBE(dest, offset, (ulong)value, bytes);
        }

        private static void WriteBE(byte[] dest, int offset, ushort value, int bytes)
        {
            WriteBE(dest, offset, (ulong)value, bytes);
        }

        private static bool IsAllZero(byte[] data)
        {
            foreach (byte b in data)
                if (b != 0) return false;
            return true;
        }
    }

    public struct ContentChunkRecord
    {
        public uint ID;
        public ushort Index;
        public ushort Type; // flags: 0x1 = encrypted
        public ulong Size;
        public byte[] Hash; // SHA256 (0x20)

        public void Serialize(byte[] data, int offset)
        {
            // All fields are BIG ENDIAN per TMD spec
            WriteBE(data, offset, ID, 4);
            WriteBE(data, offset + 4, Index, 2);
            WriteBE(data, offset + 6, Type, 2);
            WriteBE(data, offset + 8, Size, 8);
            Array.Copy(Hash ?? new byte[0x20], 0, data, offset + 0x10, 0x20);
        }

        private static void WriteBE(byte[] dest, int offset, ulong value, int bytes)
        {
            for (int i = 0; i < bytes; i++)
                dest[offset + i] = (byte)((value >> ((bytes - 1 - i) * 8)) & 0xFF);
        }

        private static void WriteBE(byte[] dest, int offset, uint value, int bytes)
        {
            WriteBE(dest, offset, (ulong)value, bytes);
        }

        private static void WriteBE(byte[] dest, int offset, ushort value, int bytes)
        {
            WriteBE(dest, offset, (ulong)value, bytes);
        }
    }
}
