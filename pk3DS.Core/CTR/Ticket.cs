using System;
using System.Text;

namespace pk3DS.Core.CTR
{
    public class Ticket
    {
        public const int TicketSize = 0x350;

        // Signature (at offset 0, 0x140 bytes for RSA-2048)
        public uint SignatureType = 0x10004; // RSA-2048-SHA256
        public byte[] Signature = new byte[0x100];

        // Ticket Header (at offset 0x140)
        public string Issuer = "Root-CA00000003-XS00000009";
        public byte[] EncryptedTitleKey = new byte[0x10];
        public ulong TicketID;
        public uint DeviceID;
        public ulong TitleID;
        public ushort TicketVersion;
        public byte LicenceType = 0; // Permanent
        public byte KeyId;
        public uint EshopAccId;
        public byte Audit;

        // Content Index (after header)
        // For simplicity, content index segment covering indices 0-1023

        public byte[] Build()
        {
            byte[] data = new byte[TicketSize];
            int sigSize = 0x140;

            // --- Signature area (0x00 - 0x13F) ---
            // Signature Type (BIG ENDIAN)
            WriteBE(data, 0, SignatureType, 4);
            // RSA-2048 Signature at 0x04 (0x100 bytes)
            if (Signature != null && Signature.Length > 0)
                Array.Copy(Signature, 0, data, 0x04, Math.Min(Signature.Length, 0x100));
            // Padding at 0x104-0x13F (zeros by default)

            // --- Ticket Header (0x140 - 0x2A3) ---
            int hdr = sigSize;
            // Issuer (0x40 bytes)
            byte[] issuerBytes = Encoding.ASCII.GetBytes(Issuer ?? "Root");
            Array.Copy(issuerBytes, 0, data, hdr + 0x00, Math.Min(issuerBytes.Length, 0x40));
            // ECC Public Key (0x3C bytes) - zeros for RSA
            // (bytes 0x40-0x7B of header are already zero)
            // Format Version at hdr+0x7C
            data[hdr + 0x7C] = 1;
            // CA CRL Version
            data[hdr + 0x7D] = 0;
            // Signer CRL Version
            data[hdr + 0x7E] = 0;
            // Encrypted Title Key (0x10 bytes) at hdr+0x7F
            Array.Copy(EncryptedTitleKey ?? new byte[0x10], 0, data, hdr + 0x7F, 0x10);
            // Padding at hdr+0x8F
            // Ticket ID (8, BIG ENDIAN) at hdr+0x90
            WriteBE(data, hdr + 0x90, TicketID, 8);
            // Device ID (4, BIG ENDIAN) at hdr+0x98
            WriteBE(data, hdr + 0x98, DeviceID, 4);
            // Title ID (8, BIG ENDIAN) at hdr+0x9C
            WriteBE(data, hdr + 0x9C, TitleID, 8);
            // Padding at hdr+0xA4 (2 bytes)
            // Ticket Version (2, BIG ENDIAN) at hdr+0xA6
            WriteBE(data, hdr + 0xA6, TicketVersion, 2);
            // Padding at hdr+0xA8 (8 bytes)
            // Licence Type at hdr+0xB0
            data[hdr + 0xB0] = LicenceType;
            // Key ID at hdr+0xB1
            data[hdr + 0xB1] = KeyId;
            // Property Mask (2) at hdr+0xB2
            WriteBE(data, hdr + 0xB2, (ushort)0, 2);
            // Custom Data (0x14) at hdr+0xB4
            // already zeros
            // Padding (0x14) at hdr+0xC8
            // E-shop Account ID (4, BIG ENDIAN) at hdr+0xDC
            WriteBE(data, hdr + 0xDC, EshopAccId, 4);
            // Padding at hdr+0xE0
            // Audit at hdr+0xE1
            data[hdr + 0xE1] = Audit;
            // Padding at hdr+0xE2 (0x42 bytes)
            // Limits (0x40) at hdr+0x124

            // --- Content Index (0x2A4 - 0x34F) ---
            int idxOff = hdr + 0x164; // 0x2A4
            // Content Index Header (0x28 bytes)
            WriteBE(data, idxOff + 0x00, 0x00010014u, 4); // unk0
            int totalIdxSize = 0x28 + (1 * 0x84); // hdr + 1 segment
            WriteBE(data, idxOff + 0x04, (uint)totalIdxSize, 4); // totalSize
            WriteBE(data, idxOff + 0x08, 0x00000014u, 4); // unk1
            WriteBE(data, idxOff + 0x0C, 0x00010014u, 4); // unk2
            WriteBE(data, idxOff + 0x10, 0x00000000u, 4); // unk3
            WriteBE(data, idxOff + 0x14, 0x00000028u, 4); // hdrSize = sizeof(idxHdr)
            WriteBE(data, idxOff + 0x18, 1u, 4);          // segNum = 1
            WriteBE(data, idxOff + 0x1C, 0x84u, 4);       // segSize = sizeof(struct)
            WriteBE(data, idxOff + 0x20, 0x84u, 4);       // segTotalSize
            WriteBE(data, idxOff + 0x24, 0x00030000u, 4); // unk4

            // Content Index Data - 1 segment (0x84 bytes) at idxOff + 0x28
            int idxDataOff = idxOff + 0x28;
            WriteBE(data, idxDataOff + 0x00, 0u, 4); // level = 0
            // index bitmap: bit 0 = content index 0 present (LSB)
            data[idxDataOff + 0x04] = 0x01;

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
    }
}
