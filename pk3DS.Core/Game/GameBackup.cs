using System;
using System.IO;
using System.Linq;

namespace pk3DS.Core
{
    public static class GameBackup
    {
        private static string GetBackupPath(GameConfig config)
        {
            var gamePath = new DirectoryInfo(config.RomFS).Parent;
            return Path.Combine(gamePath.FullName, "backup");
        }

        public static bool BackupExists(GameConfig config)
        {
            return Directory.Exists(GetBackupPath(config));
        }

        public static int CreateBackup(GameConfig config)
        {
            string backupPath = GetBackupPath(config);
            string bakExeFS = Path.Combine(backupPath, "exefs");
            string bakGARC = Path.Combine(backupPath, "a");

            Directory.CreateDirectory(bakExeFS);
            Directory.CreateDirectory(bakGARC);

            int count = 0;

            // Backup ExeFS files
            if (config.ExeFS != null && Directory.Exists(config.ExeFS))
            {
                foreach (var file in Directory.GetFiles(config.ExeFS))
                {
                    string dest = Path.Combine(bakExeFS, Path.GetFileName(file));
                    File.Copy(file, dest, overwrite: true);
                    count++;
                }
            }

            // Backup GARC files
            if (config.RomFS != null)
            {
                foreach (var f in config.Files.Select(file => file.Name))
                {
                    string garcPath = config.GetGARCFileName(f);
                    string src = Path.Combine(config.RomFS, garcPath);
                    string name = f + $" ({garcPath.Replace(Path.DirectorySeparatorChar.ToString(), "")})";
                    string dest = Path.Combine(bakGARC, name);
                    File.Copy(src, dest, overwrite: true);
                    count++;
                }
            }

            // Write info file
            File.WriteAllText(
                Path.Combine(backupPath, "bakinfo.txt"),
                "Backup created from: " + new DirectoryInfo(config.RomFS).Parent.FullName +
                Environment.NewLine + "Creation time: " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") +
                Environment.NewLine + "Files: " + count);

            return count;
        }

        public static bool RestoreBackup(GameConfig config, out int total, out int exeFS, out int garc)
        {
            total = exeFS = garc = 0;
            string backupPath = GetBackupPath(config);
            if (!Directory.Exists(backupPath))
                return false;

            string bakExeFS = Path.Combine(backupPath, "exefs");
            string bakGARC = Path.Combine(backupPath, "a");

            // Restore ExeFS
            if (Directory.Exists(bakExeFS) && config.ExeFS != null && Directory.Exists(config.ExeFS))
            {
                foreach (var file in Directory.GetFiles(config.ExeFS))
                {
                    string src = Path.Combine(bakExeFS, Path.GetFileName(file));
                    if (File.Exists(src))
                    { File.Copy(src, file, overwrite: true); exeFS++; }
                }
            }

            // Restore GARC
            if (Directory.Exists(bakGARC) && config.RomFS != null)
            {
                foreach (var f in config.Files.Select(file => file.Name))
                {
                    string garcPath = config.GetGARCFileName(f);
                    string name = f + $" ({garcPath.Replace(Path.DirectorySeparatorChar.ToString(), "")})";
                    string src = Path.Combine(bakGARC, name);
                    string dest = Path.Combine(config.RomFS, garcPath);
                    if (File.Exists(src))
                    { File.Copy(src, dest, overwrite: true); garc++; }
                }
            }

            total = exeFS + garc;
            return true;
        }
    }
}
