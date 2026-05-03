using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using pk3DS.Core.Properties;

namespace pk3DS.Core.CTR
{
    public class Exheader
    {
        public readonly byte[] Data;
        public readonly byte[] AccessDescriptor;
        public readonly ulong TitleID;

        public Exheader(string EXHEADER_PATH)
        {
            Data = File.ReadAllBytes(EXHEADER_PATH);
            AccessDescriptor = Data.Skip(0x400).Take(0x400).ToArray();
            Data = Data.Take(0x400).ToArray();
            TitleID = BitConverter.ToUInt64(Data, 0x200);
        }

        public byte[] GetSuperBlockHash()
        {
            return SHA256.HashData(Data.AsSpan(0, 0x400));
        }

        public string GetSerial()
        {
            const string output = "CTR-P-";

            var RecognizedGames = new Dictionary<ulong, string[]>();
            var existingCodes = new HashSet<string>();
            string[] lines = Resources.ResourceManager.GetString("_3dsgames").Split('\n').ToArray();
            foreach (string l in lines)
            {
                string[] vars = l.Split('\t').ToArray();
                ulong titleid = Convert.ToUInt64(vars[0], 16);
                string code = vars[1];
                existingCodes.Add(code);
                if (RecognizedGames.ContainsKey(titleid))
                {
                    char lc = RecognizedGames[titleid].ToArray()[0][3];
                    char lc2 = vars[1][3];
                    if (lc2 == 'A' || lc2 == 'E' || (lc2 == 'P' && lc == 'J')) //Prefer games in order US, PAL, JP
                    {
                        RecognizedGames[titleid] = vars.Skip(1).Take(2).ToArray();
                    }
                }
                else
                {
                    RecognizedGames.Add(titleid, vars.Skip(1).Take(2).ToArray());
                }
            }
            if (RecognizedGames.TryGetValue(TitleID, out var title))
                return output + title[0];

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string newCode;
            do {
                newCode = string.Create(4, chars, (buf, c) => {
                    for (int i = 0; i < 4; i++)
                        buf[i] = c[Random.Shared.Next(c.Length)];
                });
            } while (existingCodes.Contains(newCode));
            return output + newCode;
        }

        public bool IsSupported()
        {
            return IsORAS() || IsXY() || IsUSUM() || IsSM();
        }

        public bool IsUSUM()
        {
            return (TitleID & 0xFFFFFFFF) >> 8 == 0x1B50 || (TitleID & 0xFFFFFFFF) >> 8 == 0x1B51;
        }

        public bool IsSM()
        {
            return (TitleID & 0xFFFFFFFF) >> 8 == 0x1648 || (TitleID & 0xFFFFFFFF) >> 8 == 0x175E;
        }

        public bool IsORAS()
        {
            return (TitleID & 0xFFFFFFFF) >> 8 == 0x11C5 || (TitleID & 0xFFFFFFFF) >> 8 == 0x11C4;
        }

        public bool IsXY()
        {
            return (TitleID & 0xFFFFFFFF) >> 8 == 0x55D || (TitleID & 0xFFFFFFFF) >> 8 == 0x55E;
        }

        public string GetPokemonSerial()
        {
            if (!IsSupported())
                return "CTR-P-XXXX";
            string name = ((TitleID & 0xFFFFFFFF) >> 8) switch
            {
                0x1B51 => "A2BA", // Ultra Moon
                0x1B50 => "A2AA", // Ultra Sun
                0x175E => "BNEA", // Moon
                0x1648 => "BNDA", // Sun
                0x11C5 => "ECLA", // Alpha Sapphire
                0x11C4 => "ECRA", // Omega Ruby
                0x055D => "EKJA", // X
                0x055E => "EK2A", // Y
                _ => "XXXX"
            };
            return "CTR-P-" + name;
        }

        /// <summary>Generate a random unique Product Code (CTR-P-XXXX) that doesn't conflict with known game codes.</summary>
        public static string GenerateRandomSerial()
        {
            var existingCodes = new HashSet<string>();
            try
            {
                string[] lines = Resources.ResourceManager.GetString("_3dsgames")?.Split('\n') ?? [];
                foreach (string l in lines)
                {
                    string[] vars = l.Split('\t');
                    if (vars.Length > 1)
                        existingCodes.Add(vars[1]);
                }
            }
            catch { }

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            string newCode;
            do
            {
                newCode = string.Create(4, chars, (buf, c) => {
                    for (int i = 0; i < 4; i++)
                        buf[i] = c[Random.Shared.Next(c.Length)];
                });
            } while (existingCodes.Contains(newCode));
            return "CTR-P-" + newCode;
        }

        /// <summary>Returns the expected Title ID for a given Pokemon game version.</summary>
        public static ulong GetTitleIdForVersion(GameVersion version)
        {
            return version switch
            {
                GameVersion.X  => 0x0004000000055D00,
                GameVersion.Y  => 0x0004000000055E00,
                GameVersion.OR => 0x000400000011C400,
                GameVersion.AS => 0x000400000011C500,
                GameVersion.SN => 0x0004000000164800,
                GameVersion.MN => 0x0004000000175E00,
                GameVersion.US => 0x00040000001B5000,
                GameVersion.UM => 0x00040000001B5100,
                _ => 0,
            };
        }

        /// <summary>Returns true if the Title ID matches the expected ID for the given game version.</summary>
        public static bool IsTitleIdMatch(GameVersion version, ulong titleId)
        {
            ulong expected = GetTitleIdForVersion(version);
            return expected != 0 && expected == titleId;
        }
    }
}
