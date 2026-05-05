using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace pk3DS.Core.CTR
{
    public class ExeFS
    {
        public byte[] Data;
        public byte[] SuperBlockHash;

        public ExeFS(string path)
        {
            if (Directory.Exists(path))
            {
                var files = new DirectoryInfo(path).GetFiles().Select(f => f.FullName).ToArray();
                SetData(files);
            }
            else if (File.Exists(path))
            {
                Data = File.ReadAllBytes(path);
            }
            else
            {
                throw new FileNotFoundException("File not found.", path);
            }
            int sbLen = Math.Min(Data.Length, 0x200);
            SuperBlockHash = SHA256.HashData(Data.AsSpan(0, sbLen));
        }

        // Overall R/W files (wrapped)
        public static bool UnpackExeFS(string inFile, string outPath)
        {
            try
            {
                byte[] data = File.ReadAllBytes(inFile);
                if (!Directory.Exists(outPath)) Directory.CreateDirectory(outPath);
                for (int i = 0; i < 10; i++)
                {
                    // Get File Name String; if exists we have a file to extract.
                    string fileName = Encoding.ASCII.GetString(data.Skip(0x10 * i).Take(0x8).ToArray()).TrimEnd((char)0);
                    if (fileName.Length > 0)
                    {
                        int fileOffset = 0x200 + BitConverter.ToInt32(data, 0x8 + (0x10 * i));
                        int fileSize = BitConverter.ToInt32(data, 0xC + (0x10 * i));
                        byte[] fileBytes = data.Skip(fileOffset).Take(fileSize).ToArray();
                        // Index 0 is .code section; BLZ-decompress it (matching 3dstool behavior)
                        if (i == 0)
                        {
                            byte[] decompressed = BLZCoder.Decompress(fileBytes);
                            if (decompressed != null)
                                fileBytes = decompressed;
                        }
                        File.WriteAllBytes(outPath + Path.DirectorySeparatorChar + fileName + ".bin", fileBytes);
                    }
                }
                return true;
            }
            catch { return false; }
        }

        private static bool IsCodeFile(string path)
        {
            string name = Path.GetFileNameWithoutExtension(path);
            return name == ".code" || name == "code";
        }

        public static bool PackExeFS(string[] files, string outFile)
        {
            // Exclude code.bin — matches HackingToolkit v9 behavior (only banner + icon in ExeFS)
            files = files.Where(f => !IsCodeFile(f)).ToArray();
            if (files.Length > 10) { Console.WriteLine("Cannot package more than 10 files to exefs."); return false; }

            try
            {

                byte[][] fileData = new byte[files.Length][];
                for (int i = 0; i < files.Length; i++)
                    fileData[i] = File.ReadAllBytes(files[i]);

                // Build header
                byte[] headerData = new byte[0x200];
                uint offset = 0;
                SHA256 sha = SHA256.Create();

                for (int i = 0; i < files.Length; i++)
                {
                    string fileName = Path.GetFileNameWithoutExtension(files[i]);
                    byte[] nameData = Encoding.ASCII.GetBytes(fileName); Array.Resize(ref nameData, 0x8);
                    Array.Copy(nameData, 0, headerData, i * 0x10, 0x8);

                    uint size = (uint)fileData[i].Length;
                    Array.Copy(BitConverter.GetBytes(offset), 0, headerData, 0x8 + (i * 0x10), 0x4);
                    Array.Copy(BitConverter.GetBytes(size), 0, headerData, 0xC + (i * 0x10), 0x4);
                    offset += 0x200 - (size % 0x200) + size;

                    byte[] hash = sha.ComputeHash(fileData[i]);
                    Array.Copy(hash, 0, headerData, 0x200 - (0x20 * (i + 1)), 0x20);
                }

                using MemoryStream newFile = new MemoryStream();
                new MemoryStream(headerData).CopyTo(newFile);
                for (int i = 0; i < files.Length; i++)
                {
                    newFile.Write(fileData[i], 0, fileData[i].Length);
                    new MemoryStream(new byte[0x200 - (newFile.Length % 0x200)]).CopyTo(newFile);
                }

                File.WriteAllBytes(outFile, newFile.ToArray());
                return true;
            }
            catch { return false; }
        }

        public void SetData(string[] files)
        {
            // Exclude code.bin — matches HackingToolkit v9 behavior (only banner + icon in ExeFS)
            files = files.Where(f => !IsCodeFile(f)).ToArray();

            byte[][] fileData = new byte[files.Length][];
            for (int i = 0; i < files.Length; i++)
                fileData[i] = File.ReadAllBytes(files[i]);

            // Build header
            byte[] headerData = new byte[0x200];
            uint offset = 0;
            SHA256 sha = SHA256.Create();

            for (int i = 0; i < files.Length; i++)
            {
                string fileName = Path.GetFileNameWithoutExtension(files[i]);
                byte[] nameData = Encoding.ASCII.GetBytes(fileName); Array.Resize(ref nameData, 0x8);
                Array.Copy(nameData, 0, headerData, i * 0x10, 0x8);

                uint size = (uint)fileData[i].Length;
                Array.Copy(BitConverter.GetBytes(offset), 0, headerData, 0x8 + (i * 0x10), 0x4);
                Array.Copy(BitConverter.GetBytes(size), 0, headerData, 0xC + (i * 0x10), 0x4);
                offset += 0x200 - (size % 0x200) + size;

                byte[] hash = sha.ComputeHash(fileData[i]);
                Array.Copy(hash, 0, headerData, 0x200 - (0x20 * (i + 1)), 0x20);
            }

            using MemoryStream newFile = new MemoryStream();
            new MemoryStream(headerData).CopyTo(newFile);
            for (int i = 0; i < files.Length; i++)
            {
                newFile.Write(fileData[i], 0, fileData[i].Length);
                new MemoryStream(new byte[0x200 - (newFile.Length % 0x200)]).CopyTo(newFile);
            }

            Data = newFile.ToArray();
        }
    }
}
