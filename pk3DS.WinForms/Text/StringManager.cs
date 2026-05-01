using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace pk3DS.WinForms.Text;

public sealed class StringManager : IDisposable
{
    public static StringManager Instance { get; } = new();

    private Dictionary<string, string> _strings = new();
    private FileSystemWatcher _watcher;
    private string _langDir;
    private string _currentLanguage = "zh-CN";
    private readonly Timer _debounceTimer;

    public event Action<string> LanguageChanged;

    private StringManager()
    {
        _debounceTimer = new Timer { Interval = 300 };
        _debounceTimer.Tick += (_, _) =>
        {
            _debounceTimer.Stop();
            Reload();
        };
    }

    public void Initialize(string languageCode = "zh-CN")
    {
        _currentLanguage = languageCode;

        var baseDir = Path.GetDirectoryName(Application.ExecutablePath) ?? ".";
        _langDir = Path.Combine(baseDir, "lang");

        // Fallback: look next to the assembly if the exe directory doesn't have lang/
        if (!Directory.Exists(_langDir))
        {
            var assemblyDir = Path.GetDirectoryName(typeof(StringManager).Assembly.Location);
            if (assemblyDir != null)
            {
                var alt = Path.Combine(assemblyDir, "lang");
                if (Directory.Exists(alt))
                    _langDir = alt;
            }
        }

        LoadLanguage(_currentLanguage);
        StartFileWatcher();
    }

    public string Get(string key, string defaultValue = null)
    {
        if (_strings.TryGetValue(key, out var value))
            return value;
        return defaultValue ?? key;
    }

    private void LoadLanguage(string languageCode)
    {
        var path = GetLangFilePath(languageCode);
        if (!File.Exists(path))
        {
            _strings = new Dictionary<string, string>();
            return;
        }

        try
        {
            var json = File.ReadAllText(path);
            var dict = JsonSerializer.Deserialize<Dictionary<string, string>>(json);
            _strings = dict ?? new Dictionary<string, string>();
        }
        catch
        {
            _strings = new Dictionary<string, string>();
        }
    }

    private void Reload()
    {
        LoadLanguage(_currentLanguage);
        LanguageChanged?.Invoke(_currentLanguage);
    }

    private void StartFileWatcher()
    {
        if (!Directory.Exists(_langDir))
            return;

        _watcher?.Dispose();
        _watcher = new FileSystemWatcher(_langDir, "*.json")
        {
            NotifyFilter = NotifyFilters.LastWrite | NotifyFilters.FileName,
            EnableRaisingEvents = true,
        };

        _watcher.Changed += OnLangFileChanged;
        _watcher.Created += OnLangFileChanged;
    }

    private void OnLangFileChanged(object sender, FileSystemEventArgs e)
    {
        _debounceTimer.Stop();
        _debounceTimer.Start();
    }

    private string GetLangFilePath(string languageCode) =>
        Path.Combine(_langDir, $"{languageCode}.json");

    public void Dispose()
    {
        _watcher?.Dispose();
        _debounceTimer?.Dispose();
    }
}
