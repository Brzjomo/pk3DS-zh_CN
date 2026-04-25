using System;
using System.Linq;
using System.Security.Cryptography;

namespace pk3DS.Core.CTR
{
    public class AesCtr
    {
        private readonly Aes Aes = Aes.Create();
        private readonly ICryptoTransform Encryptor;
        private readonly AesCounter Counter;

        public AesCtr(byte[] key, byte[] iv)
        {
            Aes.Key = key;
            Aes.Mode = CipherMode.ECB;
            Aes.Padding = PaddingMode.None;
            Counter = new AesCounter(iv);
            Encryptor = Aes.CreateEncryptor();
        }

        public AesCtr(byte[] key, ulong PartitionID, ulong InitialCount)
        {
            Aes.Key = key;
            Aes.Mode = CipherMode.ECB;
            Aes.Padding = PaddingMode.None;
            Counter = new AesCounter(PartitionID, InitialCount);
            Encryptor = Aes.CreateEncryptor();
        }

        public int TransformBlock(byte[] inputBuffer, int inputOffset, int inputCount, byte[] outputBuffer, int outputOffset)
        {
            int BlockLength;
            for (int i = 0; i < inputCount; i += BlockLength)
            {
                BlockLength = inputCount - i > AesCounter.BufferSize ? AesCounter.BufferSize : inputCount - i;
                // Encrypt the counter buffer into outputBuffer at offset
                Encryptor.TransformBlock(Counter.ManageBufferCounters(BlockLength), 0, BlockLength, outputBuffer, outputOffset + i);
                for (int BlockWalker = i; BlockWalker < i + BlockLength; BlockWalker += 8)
                {
                    // XOR 8-byte chunks (long) between encrypted counter (in outputBuffer) and inputBuffer, write back to outputBuffer
                    long left = BitConverter.ToInt64(outputBuffer, outputOffset + BlockWalker);
                    long right = BitConverter.ToInt64(inputBuffer, inputOffset + BlockWalker);
                    byte[] xorBytes = BitConverter.GetBytes(left ^ right);
                    Array.Copy(xorBytes, 0, outputBuffer, outputOffset + BlockWalker, 8);
                }
            }
            return inputCount;
        }
    }

    public class AesCounter
    {
        public const int BufferSize = 0x400000; //4 MB Buffer
        private readonly byte[] Counter = new byte[0x10];
        private readonly byte[] Buffer = new byte[BufferSize];

        public AesCounter(ulong high, ulong low)
        {
            // Avoid using Enumerable.Reverse() or Array.Reverse() to prevent ambiguity with void-returning APIs.
            var highBytes = BitConverter.GetBytes(high);
            var lowBytes = BitConverter.GetBytes(low);
            var highRev = new byte[8];
            var lowRev = new byte[8];
            for (int i = 0; i < 8; i++)
            {
                highRev[i] = highBytes[7 - i];
                lowRev[i] = lowBytes[7 - i];
            }
            Array.Copy(highRev, 0, Counter, 0x0, 0x8);
            Array.Copy(lowRev, 0, Counter, 0x8, 0x8);
        }

        public AesCounter(byte[] iv)
        {
            if (iv == null) throw new ArgumentNullException(nameof(iv));
            if (iv.Length != 16)
                throw new ArgumentException("IV must be 16 bytes.", nameof(iv));

            // Avoid calling methods that might resolve to void-returning APIs (e.g. Array.Reverse)
            // Create a reversed copy explicitly
            var rev = new byte[16];
            for (int i = 0; i < 16; i++)
                rev[i] = iv[15 - i];

            Array.Copy(rev, 0, Counter, 0, 0x10);
        }

        public void Increment()
        {
            for (int i = Counter.Length - 1; i >= 0; i--)
            {
                if (++Counter[i] != 0)
                    return;
            }
        }

        public byte[] ManageBufferCounters(int size)
        {
            for (int i = 0; i < size; i += 0x10)
            {
                Array.Copy(Counter, 0, Buffer, i, 0x10);
                Increment();
            }
            return Buffer;
        }

        public static ulong SwapBytes(ulong value)
        {
            ulong uvalue = value;
            return   (0x00000000000000FF & (uvalue >> 56))
                   | (0x000000000000FF00 & (uvalue >> 40))
                   | (0x0000000000FF0000 & (uvalue >> 24))
                   | (0x00000000FF000000 & (uvalue >> 8))
                   | (0x000000FF00000000 & (uvalue << 8))
                   | (0x0000FF0000000000 & (uvalue << 24))
                   | (0x00FF000000000000 & (uvalue << 40))
                   | (0xFF00000000000000 & (uvalue << 56));
        }
    }
}
