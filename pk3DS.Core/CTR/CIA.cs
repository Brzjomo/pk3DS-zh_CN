using System;
using System.IO;
using System.Security.Cryptography;

namespace pk3DS.Core.CTR
{
    public class CIA
    {
        public const uint DefaultHeaderSize = 0x2020;

        public uint HeaderSize = DefaultHeaderSize;
        public ushort Type;
        public ushort Version;
        public byte[] CertificateChain;
        public Ticket Ticket;
        public TMD Tmd;
        public byte[] ContentData; // encrypted NCCH
        public byte[] Meta; // optional

        public byte[] Data; // serialized CIA output

        /// <summary>
        /// Builds the full CIA file into <see cref="Data"/>.
        /// Uses makerom-style 64-byte alignment for all sections.
        /// </summary>
        public void Build()
        {
            byte[] certChain = CertificateChain ?? BuildDefaultCertChain();
            byte[] ticketData = Ticket?.Build() ?? new Ticket().Build();
            byte[] tmdData = Tmd?.Build() ?? new TMD().Build();
            byte[] metaData = Meta ?? Array.Empty<byte>();

            // Pre-compute 64-byte aligned section offsets (makerom-style)
            long Align64(long v) => (v + 0x3F) & ~0x3F;
            long headerSize = DefaultHeaderSize;
            long certOff = Align64(headerSize);
            long tikOff = Align64(certOff + certChain.Length);
            long tmdOff = Align64(tikOff + ticketData.Length);

            // Pad content to 64-byte alignment
            long rawContentSize = ContentData?.Length ?? 0;
            long alignedContentSize = (rawContentSize + 0x3F) & ~0x3F;
            long contentOff = Align64(tmdOff + tmdData.Length);
            long metaOff = Align64(contentOff + alignedContentSize);

            long totalSize = metaOff + metaData.Length;
            Data = new byte[totalSize];

            // Write CIA header at offset 0
            WriteHeader(Data, 0, certChain.Length, ticketData.Length, tmdData.Length,
                        metaData.Length, (ulong)alignedContentSize);

            // Content Index bitmask — MSB-first: bit 0 = MSB = 0x80 for content index 0
            Data[0x20] = 0x80;

            // Certificate chain at aligned offset
            certChain.CopyTo(Data, certOff);
            // Ticket at aligned offset
            ticketData.CopyTo(Data, tikOff);
            // TMD at aligned offset
            tmdData.CopyTo(Data, tmdOff);
            // Content at aligned offset (already 64-byte padded)
            if (rawContentSize > 0)
                Array.Copy(ContentData, 0, Data, contentOff, rawContentSize);
            // Meta at aligned offset (if any)
            if (metaData.Length > 0)
                metaData.CopyTo(Data, metaOff);
        }

        private void WriteHeader(byte[] dest, int offset,
            int certSize, int ticketSize, int tmdSize, int metaSize, ulong contentSize)
        {
            Array.Copy(BitConverter.GetBytes(HeaderSize), 0, dest, offset, 4);
            Array.Copy(BitConverter.GetBytes(Type), 0, dest, offset + 4, 2);
            Array.Copy(BitConverter.GetBytes(Version), 0, dest, offset + 6, 2);
            Array.Copy(BitConverter.GetBytes(certSize), 0, dest, offset + 8, 4);
            Array.Copy(BitConverter.GetBytes(ticketSize), 0, dest, offset + 0xC, 4);
            Array.Copy(BitConverter.GetBytes(tmdSize), 0, dest, offset + 0x10, 4);
            Array.Copy(BitConverter.GetBytes(metaSize), 0, dest, offset + 0x14, 4);
            Array.Copy(BitConverter.GetBytes(contentSize), 0, dest, offset + 0x18, 8);
        }

        /// <summary>
        /// Returns makerom-compatible debug certificate chain (3DS test PKI).
        /// CA=RSA-4096 sig + RSA-2048 key (0x400), XS=RSA-2048 (0x300), CP=RSA-2048 (0x300).
        /// Total = 0xA00. Copied from makerom pki/test.h — these are the fixed debug
        /// certs that CFW expects, with real RSA signatures and proper moduli.
        /// </summary>
        internal const int CACertSize = 0x400;
        internal const int ChildCertSize = 0x300;

        internal static byte[] BuildDefaultCertChain()
        {
            byte[] chain = new byte[CACertSize + 2 * ChildCertSize]; // 0xA00
            Array.Copy(DebugPKI.CaCert, 0, chain, 0, CACertSize);
            Array.Copy(DebugPKI.XsCert, 0, chain, CACertSize, ChildCertSize);
            Array.Copy(DebugPKI.CpCert, 0, chain, CACertSize + ChildCertSize, ChildCertSize);
            return chain;
        }

        /// <summary>
        /// Convenience: builds a CIA directly from NCCH data with title ID.
        /// </summary>
        public static byte[] BuildFromNCCH(byte[] ncchData, ulong titleId)
        {
            byte[] contentHash = SHA256.HashData(ncchData);

            var tmd = new TMD
            {
                TitleID = titleId,
                Contents =
                {
                    new ContentChunkRecord
                    {
                        ID = 0,
                        Index = 0,
                        Type = 1, // Encrypted
                        Size = (ulong)ncchData.Length,
                        Hash = contentHash,
                    }
                }
            };

            var ticket = new Ticket
            {
                TitleID = titleId,
            };

            var cia = new CIA
            {
                ContentData = ncchData,
                Ticket = ticket,
                Tmd = tmd,
            };

            cia.Build();
            return cia.Data;
        }
    }
}
