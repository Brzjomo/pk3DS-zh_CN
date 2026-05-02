namespace pk3DS.WinForms.Text;

/// <summary>
/// Compile-time safe accessors for centralized string resources.
/// Maps to keys in lang/*.json files via StringManager.
/// </summary>
public static class Strings
{
    private static string Get(string key, string fallback = null) =>
        StringManager.Instance.Get(key, fallback);

    // ===== Common =====
    public static string Common_Pokemon   => Get("Common.Pokemon", "宝可梦");
    public static string Common_Randomize => Get("Common.Randomize", "随机化");
    public static string Common_Save      => Get("Common.Save", "保存");
    public static string Common_Cancel    => Get("Common.Cancel", "取消");
    public static string Common_Error     => Get("Common.Error", "错误");
    public static string Common_Warning   => Get("Common.Warning", "警告");
    public static string Common_Prompt    => Get("Common.Prompt", "提示");
    public static string Common_Open      => Get("Common.Open", "打开");
    public static string Common_Close     => Get("Common.Close", "关闭");

    // ===== Main =====
    public static string Main_Title                  => Get("Main.Title", "pk3DS中文版");
    public static string Main_FileMenu               => Get("Main.FileMenu", "文件");
    public static string Main_GameVersion             => Get("Main.GameVersion", "游戏版本: ");
    public static string Main_GameLoaded               => Get("Main.GameLoaded", "游戏已加载: {0}");
    public static string Main_LoadingSubData            => Get("Main.LoadingSubData", "发现数据! 正在为子表单加载持久数据...");
    public static string Main_Success                   => Get("Main.Success", "成功!");
    public static string Main_Failure                   => Get("Main.Failure", "失败!");
    public static string Main_Aborted                   => Get("Main.Aborted", "中止!");
    public static string Main_FileCount                 => Get("Main.FileCount", "文件: ");
    public static string Main_Sample                    => Get("Main.Sample", "示例: ");
    public static string Main_GARC_Get                  => Get("Main.GARC_Get", "GARC 已取得: {0}... ");
    public static string Main_GARC_GetDetail            => Get("Main.GARC_GetDetail", "GARC 已取得: {0} @ {1}... ");
    public static string Main_GARC_Mod                  => Get("Main.GARC_Mod", "GARC 已修改: {0}... ");
    public static string Main_GARC_ModDetail            => Get("Main.GARC_ModDetail", "GARC 已修改: {0} @ {1}... ");
    public static string Main_RunningSMWE               => Get("Main.RunningSMWE", "运行SMWE中... ");
    public static string Main_NoteTitle                 => Get("Main.NoteTitle", "注意");
    public static string Main_OnlyUSUMSupported         => Get("Main.OnlyUSUMSupported", "目前仅支持\"究极日月\"。");
    public static string Main_CRO_RSADetail             => Get("Main.CRO_RSADetail", "If you have made any modifications, it is required that the RSA Verification check be patched on the system in order for the modified CROs to load (ie, no file redirection like NTR's layeredFS).");
    public static string Main_Exit                   => Get("Main.Exit", "退出");
    public static string Main_OpenROMFirst           => Get("Main.OpenROMFirst", "请先打开一个游戏目录！");
    public static string Main_GARCFileCorrupt         => Get("Main.GARCFileCorrupt", "{0} ({1}) 文件损坏，请使用「恢复备份」功能还原。");
    public static string Main_Status_Ready           => Get("Main.Status_Ready", "就绪");
    public static string Main_Status_Saving          => Get("Main.Status_Saving", "正在保存...");
    public static string Main_Status_Loading         => Get("Main.Status_Loading", "正在加载 ROM...");
    public static string Main_Status_Building        => Get("Main.Status_Building", "正在构建 RomFS bin文件. 请等待程序运行结束.");
    public static string Main_Status_Saved           => Get("Main.Status_Saved", "RomFS bin文件已保存.");
    public static string Main_AutoLoadError          => Get("Main.AutoLoadError", "无法自动加载先前打开的ROM转储，位于 -- {0}.");
    public static string Main_ExtractCXI_Title       => Get("Main.ExtractCXI_Title", "选择CXI文件");
    public static string Main_ExtractCXI_Desc        => Get("Main.ExtractCXI_Desc", "提取 CXI 文件需要数 GB 的磁盘空间，并且需要一些时间才能完成。");
    public static string Main_ExtractCXI_Desc2       => Get("Main.ExtractCXI_Desc2", "如果你想继续，请按\"确定\"选择你的CXI文件，然后再选择输出目录。为获得最佳效果，请确保输出目录为空。");
    public static string Main_Extract3DS_Title       => Get("Main.Extract3DS_Title", "选择3DS文件");
    public static string Main_Extract3DS_Desc        => Get("Main.Extract3DS_Desc", "提取 3DS 文件需要数 GB 的磁盘空间，并且需要一些时间才能完成。");
    public static string Main_Extract3DS_Desc2       => Get("Main.Extract3DS_Desc2", "如果你想继续，请按\"确定\"选择你的3DS文件，然后再选择输出目录。为获得最佳效果，请确保输出目录为空。");
    public static string Main_Status_ExeFSNoRomFS    => Get("Main.Status_ExeFSNoRomFS", "ExeFS 已加载 - 无RomFS");
    public static string Main_Status_NoGame          => Get("Main.Status_NoGame", "未加载游戏");

    // ===== Main Dialogs =====
    public static string Main_CopyToClipboard       => Get("Main.CopyToClipboard", "复制到剪切板?");
    public static string Main_CannotOpenPath         => Get("Main.CannotOpenPath", "无法打开 -- {0}");
    public static string Main_ExtractSubfilesCancel  => Get("Main.ExtractSubfilesCancel", "取消: 中止");
    public static string Main_DetectUncompressedCode => Get("Main.DetectUncompressedCode", "检测到未压缩的code.bin文件");
    public static string Main_DetectCompressedCode   => Get("Main.DetectCompressedCode", "检测到压缩的code.bin文件");
    public static string Main_DetectCompressedBin    => Get("Main.DetectCompressedBin", "检测到已压缩的bin文件");
    public static string Main_DecompressAndReplace   => Get("Main.DecompressAndReplace", "是否解压缩? 文件将会被替换.");
    public static string Main_CannotLoadRomFS        => Get("Main.CannotLoadRomFS", "无法从 romfs 加载游戏数据。请仔细检查你的 ROM 转储是否正确。");
    public static string Main_ExtractionComplete     => Get("Main.ExtractionComplete", "提取完成!");
    public static string Main_WaitForOperations      => Get("Main.WaitForOperations", "请先等待所有操作完成.");
    public static string Main_RebuildRomFS           => Get("Main.RebuildRomFS", "是否重建 RomFS?");
    public static string Main_WrittenRomFS           => Get("Main.WrittenRomFS", "已写入 RomFS bin文件:");
    public static string Main_EditSuperBattle        => Get("Main.EditSuperBattle", "编辑【超级对战屋】还是【普通对战屋】？");
    public static string Main_EditSuperBattleDetail  => Get("Main.EditSuperBattleDetail", "是 = 超级对战屋, 否 = 普通对战屋, 取消 = 中止");
    public static string Main_EditRoyalBattle        => Get("Main.EditRoyalBattle", "编辑【皇家对战】还是【对战树】？");
    public static string Main_EditRoyalBattleDetail  => Get("Main.EditRoyalBattleDetail", "是 = 皇家对战, 否 = 对战树, 取消 = 中止");
    public static string Main_ScriptEditorWarning    => Get("Main.ScriptEditorWarning", "不推荐绝大部分玩家使用世界脚本编辑器，它仍然未完成。");
    public static string Main_ContinuePrompt         => Get("Main.ContinuePrompt", "是否继续?");
    public static string Main_RebuildExeFS           => Get("Main.RebuildExeFS", "是否重建 ExeFS?");
    public static string Main_CROWarning             => Get("Main.CROWarning", "如果你的3DS打了RO补丁，重建 CRO/CRR 不是必须的。");
    public static string Main_CROUpdated             => Get("Main.CROUpdated", "CRO's 与 CRR 已更新。");
    public static string Main_FileTooLarge           => Get("Main.FileTooLarge", "文件过大!");
    public static string Main_Bytes                  => Get("Main.Bytes", " 字节.");
    public static string Main_DetectedAction         => Get("Main.DetectedAction", "检测到 {0} 文件，请选择执行的动作。");
    public static string Main_ActionChoices          => Get("Main.ActionChoices", "是 = 解压\n否 = 压缩\n取消 = 中止");
    public static string Main_AttemptDecompress      => Get("Main.AttemptDecompress", "以尝试解压, 可能成功:");
    public static string Main_FileDecompressed       => Get("Main.FileDecompressed", "文件已解压缩!");
    public static string Main_FileCompressed         => Get("Main.FileCompressed", "文件已压缩!");
    public static string Main_CannotGetGARC          => Get("Main.CannotGetGARC", "无法获取 GARC:");
    public static string Main_CannotWriteGARC        => Get("Main.CannotWriteGARC", "无法写入 GARC:");
    public static string Main_ResetRNG               => Get("Main.ResetRNG", "重置 RNG?");
    public static string Main_ResetRNGDetail         => Get("Main.ResetRNGDetail", "如果是, 在点击确定前复制 32位 (非16进制) 整数种子至剪切板");
    public static string Main_RNGSetToSeed           => Get("Main.RNGSetToSeed", "重置 RNG 为种子: {0}");
    public static string Main_CannotSetSeed          => Get("Main.CannotSetSeed", "无法设置种子");
    public static string Main_NewVersionFound        => Get("Main.NewVersionFound", "发现新版本: {0}.{1}");
    public static string Main_CannotCheckUpdate      => Get("Main.CannotCheckUpdate", "无法检查更新，请确认网络连接。");

    // ===== Main Title Formats =====
    public static string Main_Title_BuildOnly        => Get("Main.Title.BuildOnly", "pk3DS中文版_{0}.{1}");
    public static string Main_Title_BuildDesc        => Get("Main.Title.BuildDesc", "pk3DS中文版_{0}.{1}: {2}");
    public static string Main_Title_CheckFailed      => Get("Main.Title.CheckFailed", "pk3DS中文版_{0}.{1}（检查更新失败）");
    public static string Main_Title_CheckFailedDesc  => Get("Main.Title.CheckFailedDesc", "pk3DS中文版_{0}.{1}: {2}（检查更新失败）");
    public static string Main_Title_UpToDate          => Get("Main.Title.UpToDate", "pk3DS中文版_{0}.{1}（已是最新版）");
    public static string Main_Title_UpToDateDesc      => Get("Main.Title.UpToDateDesc", "pk3DS中文版_{0}.{1}: {2}（已是最新版）");
    public static string Main_Title_NewVersion        => Get("Main.Title.NewVersion", "pk3DS中文版_{0}.{1}（有新版本可用: {2}.{3}）");
    public static string Main_Title_NewVersionDesc    => Get("Main.Title.NewVersionDesc", "pk3DS中文版_{0}.{1}: {2}（有新版本可用: {3}.{4}）");

    // ===== Editor =====
    public static string Editor_CancelDiscardChanges => Get("Editor.CancelDiscardChanges", "取消: 丢弃所有更改");

    // ===== Program =====
    public static string Program_UnhandledException  => Get("Program.UnhandledException", "发生未经处理的异常。\n您可以继续运行程序（可能出现副作用），但请报告此错误。");
    public static string Program_FatalError          => Get("Program.FatalError", "发生致命错误，程序必须关闭。");
    public static string Program_FatalWinFormsError  => Get("Program.FatalWinFormsError", "pk3DS.WinForms 发生了致命错误，无法显示详细信息。请向作者报告此错误。");
    public static string Program_FatalNonUIError     => Get("Program.FatalNonUIError", "PKHeX 发生了致命的非 UI 错误，无法显示详细信息。请向作者报告此错误。");

    // ===== ErrorWindow =====
    public static string ErrorWindow_Title           => Get("ErrorWindow.Title", "错误详情");
    public static string ErrorWindow_Continue        => Get("ErrorWindow.Continue", "继续");
    public static string ErrorWindow_Abort           => Get("ErrorWindow.Abort", "中止");
    public static string ErrorWindow_CopyClipboard   => Get("ErrorWindow.CopyClipboard", "复制到剪贴板");
    public static string ErrorWindow_ExceptionDetails => Get("ErrorWindow.ExceptionDetails", "异常详情:");
    public static string ErrorWindow_LoadedAssemblies => Get("ErrorWindow.LoadedAssemblies", "已加载的程序集:");
    public static string ErrorWindow_LoadedAssembliesError => Get("ErrorWindow.LoadedAssembliesError", "列出已加载的程序集时出错:");
    public static string ErrorWindow_UserMessage => Get("ErrorWindow.UserMessage", "用户消息:");

    // ===== TrainerRand =====
    public static string TrainerRand_Title           => Get("TrainerRand.Title", "训练家随机化设置");
    public static string TrainerRand_RandomizeAll    => Get("TrainerRand.RandomizeAll", "是否全部随机化？无法撤销");
    public static string TrainerRand_RandomPKM       => Get("TrainerRand.RandomizePKM", "随机化宝可梦");
    public static string TrainerRand_BSTBalance      => Get("TrainerRand.BSTBalance", "基于BST随机化");

    // ===== Wild Encounter =====
    public static string WildEnhancer_EvoLevel       => Get("WildEnhancer.EvoLevel", "进化链等级调衡");
    public static string WildEnhancer_LegendEnable   => Get("WildEnhancer.LegendEnable", "传说宝可梦管理");
    public static string WildEnhancer_LegendMinLevel => Get("WildEnhancer.LegendMinLevel", "最低等级阈值");

    // ===== Evolution Editor =====
    public static string Evo_RandomAll           => Get("Evo.RandomAll", "是否随机全部宝可梦？");
    public static string Evo_KeepMethod          => Get("Evo.KeepMethod", "进化方式和进化条件将保持不变。");
    public static string Evo_Randomized          => Get("Evo.Randomized", "宝可梦进化已全部随机！");
    public static string Evo_RemoveTrade         => Get("Evo.RemoveTrade", "是否移除全部通讯进化？");
    public static string Evo_TradeReplace        => Get("Evo.TradeReplace", "通讯进化方式将会被替代，以便单人游戏也可进化。");
    public static string Evo_TradeRemoved        => Get("Evo.TradeRemoved", "已移除全部通讯进化！");
    public static string Evo_TradeReplaceDetail  => Get("Evo.TradeReplaceDetail", "通讯进化将在到达指定等级，或持有相关道具并升级时进行。");
    public static string Evo_ConfirmMod          => Get("Evo.ConfirmMod", "是否确认修改？");
    public static string Evo_RandomEvoDetail     => Get("Evo.RandomEvoDetail", "你的宝可梦每次升级都会进化为随机的宝可梦。");
    public static string Evo_ExportAll           => Get("Evo.ExportAll", "是否导出所有进化到TXT文本？");

    // ===== Level Up Editor =====
    public static string LevelUp_RandomConfirm   => Get("LevelUp.RandomConfirm", "是否确认随机化升级招式？");
    public static string LevelUp_CantUndo        => Get("LevelUp.CantUndo", "无法撤销。");
    public static string LevelUp_MetronomeMode   => Get("LevelUp.MetronomeMode", "是否使用挥指模式？");
    public static string LevelUp_MetronomeDetail => Get("LevelUp.MetronomeDetail", "这将导致宝可梦只能学习挥指。");
    public static string LevelUp_AllMetronome    => Get("LevelUp.AllMetronome", "现在所有宝可梦都只会挥指！");
    public static string LevelUp_ExportAll       => Get("LevelUp.ExportAll", "是否导出所有升级招式至TXT文件？");

    // ===== Move Editor =====
    public static string Move_CantRandomize      => Get("Move.CantRandomize", "无法随机化招式。");
    public static string Move_CheckRightSettings => Get("Move.CheckRightSettings", "请检查右侧的设置。");
    public static string Move_RandomConfirm      => Get("Move.RandomConfirm", "是否随机化招式？无法撤销。");
    public static string Move_ConfirmRight       => Get("Move.ConfirmRight", "确认前，请先确认右侧的设置。");
    public static string Move_Randomized         => Get("Move.Randomized", "已随机化全部招式！");
    public static string Move_MetronomeMode      => Get("Move.MetronomeMode", "是否使用挥指模式？");
    public static string Move_MetronomeDetail    => Get("Move.MetronomeDetail", "这将设置其他全部招式的基础pp值为0！");
    public static string Move_PPRandomized       => Get("Move.PPRandomized", "已随机化全部招式的基础pp值！");

    // ===== Egg Move Editor =====
    public static string EggMove_RandomConfirm   => Get("EggMove.RandomConfirm", "是否确认随机化蛋招式？");
    public static string EggMove_CantUndo        => Get("EggMove.CantUndo", "无法撤销！");
    public static string EggMove_ExportAll       => Get("EggMove.ExportAll", "是否导出全部蛋招式至TXT文件？");

    // ===== Gift Editor =====
    public static string Gift_RandomAll          => Get("Gift.RandomAll", "是否全部随机化？无法撤销。");
    public static string Gift_CheckOptions       => Get("Gift.CheckOptions", "请先检查随机化选项页的设置。");
    public static string Gift_Randomized         => Get("Gift.Randomized", "已根据设置随机化全部礼物宝可梦！");
    public static string Gift_ModLevels          => Get("Gift.ModLevels", "是否修改当前所有宝可梦等级？");
    public static string Gift_LevelsModified     => Get("Gift.LevelsModified", "已根据设置修改全部宝可梦等级！");

    public static string Gift_CRONotExists       => Get("Gift.CRONotExists", "CRO文件不存在！关闭中...");
    public static string Gift_StartersModified   => Get("Gift.StartersModified", "Starters 已经被修改。");

    // ===== Personal Editor =====
    public static string Personal_RandomAll      => Get("Personal.RandomAll", "是否全部随机化？无法撤销。");
    public static string Personal_ConfirmOptions => Get("Personal.ConfirmOptions", "请先确认随机化选项。");
    public static string Personal_Randomized     => Get("Personal.Randomized", "已根据设置随机化全部宝可梦个体数据！");
    public static string Personal_ModAll         => Get("Personal.ModAll", "是否全部修改？无法撤销。");
    public static string Personal_ConfirmModOpts => Get("Personal.ConfirmModOpts", "请先确认修改器选项。");
    public static string Personal_Modified       => Get("Personal.Modified", "已根据设置修改全部宝可梦个体数据！");
    public static string Personal_ExportAll      => Get("Personal.ExportAll", "是否导出全部个体数据至TXT文件？");

    // ===== Maison Editor =====
    public static string Maison_ExportTrainers   => Get("Maison.ExportTrainers", "是否确认导出训练家信息至TXT文件？");
    public static string Maison_ExportPKM        => Get("Maison.ExportPKM", "是否确认导出宝可梦信息至TXT文件？");
    public static string Maison_RandomAll        => Get("Maison.RandomAll", "是否确认随机化所有宝可梦？");
    public static string Maison_Randomized       => Get("Maison.Randomized", "随机化完成！");

    // ===== Mart Editor =====
    public static string Mart_RandomItems        => Get("Mart.RandomItems", "是否随机商店物品?");
    public static string Mart_RandomSpecial      => Get("Mart.RandomSpecial", "是否仅随机特殊商店?");
    public static string Mart_KeepEssentials     => Get("Mart.KeepEssentials", "不会修改常规必需品。");
    public static string Mart_Randomized         => Get("Mart.Randomized", "已随机化!");
    public static string Mart_RandomBP           => Get("Mart.RandomBP", "是否随机化对战点数物品?");

    // ===== Pickup Editor =====
    public static string Pickup_Randomize        => Get("Pickup.Randomize", "是否随机化捡拾列表？");
    public static string Pickup_AddRow           => Get("Pickup.AddRow", "是否在末尾新增1行？");
    public static string Pickup_DeleteRow        => Get("Pickup.DeleteRow", "是否删除最后1行？");
    public static string Pickup_TotalMustEqual100 => Get("Pickup.TotalMustEqual100", "{0}列的总列数必须等于100。");
    public static string Pickup_CurrentSum        => Get("Pickup.CurrentSum", "现有{0}。");
    public static string Pickup_CodeNotDecompressed => Get("Pickup.CodeNotDecompressed", ".code.bin未解压，程序已终止");

    // ===== Item Editor =====
    public static string Item_NoExeFS            => Get("Item.NoExeFS", "未加载 exeFS 代码");
    public static string Item_NoCodeBin          => Get("Item.NoCodeBin", "未检测到 .code .bin 文件");

    // ===== Shiny Rate =====
    public static string Shiny_ExternallyModified => Get("Shiny.ExternallyModified", ".code.bin已被外部修改");
    public static string Shiny_WontLoad          => Get("Shiny.WontLoad", "现有数值将不会加载。");
    public static string Shiny_AlreadyModified   => Get("Shiny.AlreadyModified", "已修改过闪光率");
    public static string Shiny_LoadModified      => Get("Shiny.LoadModified", "将加载已修改的数值。");

    // ===== SMTE =====
    public static string SMTE_CantSetEmpty       => Get("SMTE.CantSetEmpty", "无法设置空槽位");
    public static string SMTE_RandomAll          => Get("SMTE.RandomAll", "是否全部随机化？无法撤销。");
    public static string SMTE_Randomized         => Get("SMTE.Randomized", "已根据设置随机化全部训练家！");

    // ===== Static Encounter Editor =====
    public static string Static_Randomized       => Get("Static.Randomized", "已根据选项随机化固定遭遇！");
    public static string Static_ModLevels        => Get("Static.ModLevels", "是否修改全部当前等级？");
    public static string Static_LevelsModified   => Get("Static.LevelsModified", "已根据选项修改全部等级！");
    public static string Static_CheckOptions     => Get("Static.CheckOptions", "继续前，请先检查随机化选项。");
    public static string Static_RandomStarter    => Get("Static.RandomStarter", "是否随机初始宝可梦？ 无法撤销。");
    public static string Static_StarterTextUpdate => Get("Static.StarterTextUpdate", "初始宝可梦已更改，是否更新文本引用?");
    public static string Static_UpdateNote       => Get("Static.UpdateNote", "注意这只更新pk3ds中，当前语言的文本引用。");
    public static string Static_UpdateTip        => Get("Static.UpdateTip", "你也可以稍后在主窗口的选项-语言设置中更改。");
    public static string Static_RandomStatic     => Get("Static.RandomStatic", "是否随机固定遭遇？无法撤销。");
    public static string Static_StarterRandomized => Get("Static.StarterRandomized", "已根据设置随机化初始宝可梦！");

    // ===== Mega Evolution Editor =====
    public static string Mega_ExportAll          => Get("Mega.ExportAll", "是否导出全部Mega进化至TXT文档？");

    // ===== Misc Alerts =====
    public static string Alert_NewVersionAvailable   => Get("Alert.NewVersionAvailable", "有新版本可用，是否打开下载地址？");
    public static string Alert_VersionCheckFailed    => Get("Alert.VersionCheckFailed", "版本获取错误，请手动确认。");
    public static string Alert_BrowserFailed         => Get("Alert.BrowserFailed", "无法打开浏览器: {0}");
    public static string Alert_CannotCopyClipboard   => Get("Alert.CannotCopyClipboard", "无法复制到剪切板");
    public static string Alert_LanguageNotAvailable  => Get("Alert.LanguageNotAvailable", "游戏语言不可用，已设置为日语-片假名。");
    public static string Alert_RomFSNotExtracted     => Get("Alert.RomFSNotExtracted", "RomFS解包未执行。");
    public static string Alert_Extracted             => Get("Alert.Extracted", "已解包!");
    public static string Alert_Compressed            => Get("Alert.Compressed", "已压缩!");
    public static string Alert_Decompressed          => Get("Alert.Decompressed", "已解压!");
    public static string CRO_FileNotFound            => Get("CRO.FileNotFound", "文件未找到!");
    public static string CRO_DllFieldNotFound        => Get("CRO.DllFieldNotFound", "RomFS文件夹中未找到 DllField.cro!");
    public static string CRO_DllBattleNotFound       => Get("CRO.DllBattleNotFound", "RomFS文件夹中未找到 DllBattle.cro!");
    public static string CRO_DllPoke3SelectNotFound  => Get("CRO.DllPoke3SelectNotFound", "RomFS文件夹中未找到 DllPoke3Select.cro!");

    // ===== Misc Editors =====
    public static string Editor_NoEditorAvailable    => Get("Editor.NoEditorAvailable", "无可用编辑器.");
    public static string Editor_FileCountMismatch    => Get("Editor.FileCountMismatch", "文件数与预期的数目不匹配.");
    public static string Editor_MissingAFolder       => Get("Editor.MissingAFolder", "父级目录未包含 'a' 文件夹.");
    public static string Editor_DetectExeFS          => Get("Editor.DetectExeFS", "检测到ExeFS.bin文件");
    public static string Editor_DetectCompressed     => Get("Editor.DetectCompressed", "检测到压缩的bin文件.");
    public static string Editor_DetectDecompressed   => Get("Editor.DetectDecompressed", "检测到已解压的bin文件.");
    public static string Editor_ExtractSubfiles      => Get("Editor.ExtractSubfiles", "是否解包子文件?");
    public static string Editor_Unpack               => Get("Editor.Unpack", "是否解包?");
    public static string Editor_Compress             => Get("Editor.Compress", "是否压缩? 文件将会被替换。");
    public static string Editor_Decompress           => Get("Editor.Decompress", "是否解压? 文件将会被替换。");
    public static string Editor_SaveTextError        => Get("Editor.SaveTextError", "试图保存文本时出错.");
    public static string Editor_SaveAndExport        => Get("Editor.SaveAndExport", "是: 保存更改, 导出错误信息");
    public static string Editor_SaveNoExport         => Get("Editor.SaveNoExport", "否: 保存更改, 不导出错误信息");
    public static string Editor_SavedTxt             => Get("Editor.SavedTxt", "已保存TXT文件至: {0}");
    public static string Editor_RebuildFailed        => Get("Editor.RebuildFailed", "重建失败");
    public static string Editor_RebuildFailedDetail  => Get("Editor.RebuildFailedDetail", "磁盘空间不足，或文件写入出错。请检查磁盘剩余空间后重试。");
    public static string Editor_SkipAlreadyExists    => Get("Editor.SkipAlreadyExists", "跳过 - 文件已存在!");
    public static string Editor_CancelWriteBack      => Get("Editor.CancelWriteBack", "是否取消回写数据至 GARC?");
    public static string Editor_NoGameLoaded         => Get("Editor.NoGameLoaded", "请先打开一个游戏目录！");

    // ===== Backup =====
    public static string Backup_CreateSuccess         => Get("Backup.CreateSuccess", "备份完成！已备份 {0} 个文件到游戏目录下的 backup 文件夹。");
    public static string Backup_CreateFailed          => Get("Backup.CreateFailed", "备份失败：");
    public static string Backup_NotFound              => Get("Backup.NotFound", "未找到备份文件夹。请先使用「创建备份」功能。");
    public static string Backup_ConfirmRestore        => Get("Backup.ConfirmRestore", "确定要恢复备份吗？所有当前修改将被覆盖。");
    public static string Backup_ConfirmRestart        => Get("Backup.ConfirmRestart", "\n\n是否立即重启程序？");
    public static string Backup_RestoreFailed         => Get("Backup.RestoreFailed", "还原失败：");
    public static string Backup_RestoreComplete       => Get("Backup.RestoreComplete", "还原完成！共恢复 {0} 个文件。\nExeFS: {1}，GARC: {2}");

    // ===== Misc =====
    public static string Misc_NotCompleted => Get("Misc.NotCompleted", "未完成！");
    public static string Misc_SaveChanges  => Get("Misc.SaveChanges", "是否保存更改?");

    // ===== GARC Utility =====
    public static string Garc_PackSuccessful           => Get("Garc.PackSuccessful", "打包成功!");
    public static string Garc_PackSuccessfulDetail     => Get("Garc.PackSuccessfulDetail", "{0} 个文件已打包到 GARC!");
    public static string Garc_FolderNotExist           => Get("Garc.FolderNotExist", "文件夹不存在。");
    public static string Garc_PackFailed               => Get("Garc.PackFailed", "打包失败");
    public static string Garc_UnpackSuccessful         => Get("Garc.UnpackSuccessful", "解包成功!");
    public static string Garc_UnpackSuccessfulDetail   => Get("Garc.UnpackSuccessfulDetail", "{0} 个文件已从 GARC 解包!");
    public static string Garc_FileNotExist             => Get("Garc.FileNotExist", "文件不存在");

    // ===== Patch =====
    public static string Patch_SelectGarcs     => Get("Patch.SelectGarcs", "请至少选择一个 GARC 文件。");
    public static string Patch_SelectDir       => Get("Patch.SelectDir", "选择补丁输出目录");
    public static string Patch_ExportFailed    => Get("Patch.ExportFailed", "补丁导出失败：");
    public static string Patch_ExportComplete  => Get("Patch.ExportComplete", "补丁导出完成！共导出 {0} 个文件。\n输出目录:\n{1}");
    public static string Patch_BadVersion      => Get("Patch.BadVersion", "无法识别的游戏版本。");

    // ===== Shuffler =====
    public static string Shuffler_GarcPrevented => Get("Shuffler.GarcPrevented", "GARC 被禁止洗牌。");
    public static string Shuffler_NoFiles       => Get("Shuffler.NoFiles", "没有可洗牌的文件...?");
    public static string Shuffler_Shuffled      => Get("Shuffler.Shuffled", "GARC 已洗牌!");

    // ===== ToolsUI =====
    public static string ToolsUI_UnableToProcessFile    => Get("ToolsUI.UnableToProcessFile", "无法处理文件。");
    public static string ToolsUI_CannotOpenFile         => Get("ToolsUI.CannotOpenFile", "无法打开文件!");
    public static string ToolsUI_UnpackingFailed        => Get("ToolsUI.UnpackingFailed", "解包失败。");
    public static string ToolsUI_NotDarcOrMini          => Get("ToolsUI.NotDarcOrMini", "文件不是 darc 或迷你打包文件:");
    public static string ToolsUI_FileError              => Get("ToolsUI.FileError", "文件错误:");
    public static string ToolsUI_InputPathNotFolder     => Get("ToolsUI.InputPathNotFolder", "输入路径不是文件夹");
    public static string ToolsUI_CannotAutodetect      => Get("ToolsUI.CannotAutodetect", "无法自动检测打包类型。");
    public static string ToolsUI_PackingFailed          => Get("ToolsUI.PackingFailed", "打包失败。");
    public static string ToolsUI_MiniFolderNameNotValid => Get("ToolsUI.MiniFolderNameNotValid", "迷你文件夹名称无效:");
    public static string ToolsUI_RepackingNotImplemented => Get("ToolsUI.RepackingNotImplemented", "重新打包未实现。");
    public static string ToolsUI_FormatSelection        => Get("ToolsUI.FormatSelection", "选择格式:");
    public static string ToolsUI_FormatSelectionDetail  => Get("ToolsUI.FormatSelectionDetail", "是: 太阳/月亮 (版本 6)\n否: XY/ORAS (版本 4)");
    public static string ToolsUI_HeaderSizeNonstandard  => Get("ToolsUI.HeaderSizeNonstandard", "现有文件的头部大小不符合标准。");
    public static string ToolsUI_AdjustHeaderSize       => Get("ToolsUI.AdjustHeaderSize", "是否调整新打包文件的头部大小与旧文件一致？数据指针将相应更新。");

    // ===== TextEditor =====
    public static string TextEditor_Imported             => Get("TextEditor.Imported", "已从输入路径导入文本:");
    public static string TextEditor_CountMismatch         => Get("TextEditor.CountMismatch", "输入文件中文本文件的数量与文本文件所需的数量不匹配。");
    public static string TextEditor_NewlineFormatMismatch => Get("TextEditor.NewlineFormatMismatch", "输入的文本文件没有游戏内换行格式代码 (\\n,\\r,\\c)。");
    public static string TextEditor_ConvertFailed         => Get("TextEditor.ConvertFailed", "输入的文本文件 (#{0}) 转换失败:");
    public static string TextEditor_InvalidLine           => Get("TextEditor.InvalidLine", "无效行 @ {0}，预期 Text File : {1}");
    public static string TextEditor_Randomized            => Get("TextEditor.Randomized", "字符串已随机化!");

    // ===== Shiny =====
    public static string Shiny_CannotFindPID => Get("Shiny.CannotFindPID", "无法找到 PID 生成程序。");
    public static string Shiny_Closing       => Get("Shiny.Closing", "关闭中。");
    public static string Shiny_RerollIncreased => Get("Shiny.RerollIncreased", "指定的重试次数已增加到下一个最高支持值。");

    // ===== Common Errors =====
    public static string Common_CodeBinNotDecompressed => Get("Common.CodeBinNotDecompressed", ".code.bin 未解压，程序已终止。");
    public static string Common_NoCodeBin              => Get("Common.NoCodeBin", "未检测到 code.bin 文件。");

    // ===== OPower =====
    public static string OPower_MoreResearch => Get("OPower.MoreResearch", "游戏中给予 S/MAX 学习力需要更多研究。");

    // ===== Mega Evolution =====
    public static string Mega_RayquazaWarning      => Get("Mega.RayquazaWarning", "烈空坐是特殊的，它使用不同的进化触发方式。如果它学会了画龙点睛，它可以进行超级进化。");
    public static string Mega_RayquazaWarningDetail => Get("Mega.RayquazaWarningDetail", "如果你希望保留此功能，请不要编辑它的进化表。");

    // ===== Mart6 =====
    public static string Mart_RandomizeInventories  => Get("Mart.RandomizeInventories", "是否随机化商店物品?");
    public static string Mart_RandomizeSpecialMarts => Get("Mart.RandomizeSpecialMarts", "是否仅随机特殊商店?");

    // ===== OWSE =====
    public static string OWSE_WriteMapParse   => Get("OWSE.WriteMapParse", "是否写入地图解析输出?");
    public static string OWSE_MapImagesDumped => Get("OWSE.MapImagesDumped", "所有地图图片已导出到 ");

    // ===== Wild Encounters (Gen6) =====
    public static string XYWE_Randomized      => Get("XYWE.Randomized", "已根据设置，随机化全部野外遭遇!");
    public static string XYWE_ExportToView    => Get("XYWE.ExportToView", "按下\"导出表格\"按钮来查看新的野外遭遇信息!");
    public static string XYWE_LevelsModified  => Get("XYWE.LevelsModified", "已根据设置，修改全部等级范围!");
    public static string XYWE_LevelsExportTip => Get("XYWE.LevelsExportTip", "按下\"导出表格\"按钮来查看新的等级范围!");

    // ===== RSTE =====
    public static string RSTE_InsufficientMegaTypes => Get("RSTE.InsufficientMegaTypes", "具有至少一种Mega进化的属性类型不足，无法在保持属性主题的同时保证剧情Mega进化。");
    public static string RSTE_RerandomizeSuggest    => Get("RSTE.RerandomizeSuggest", "重新随机化个体值或不要同时选择。");

    // ===== Tutor6 =====
    public static string Tutor6_SaveNotReflected => Get("Tutor6.SaveNotReflected", "更改不会在游戏中反映。");
    public static string Tutor6_NeedsResearch    => Get("Tutor6.NeedsResearch", "仍需要更多研究。");

    // ===== Icon =====
    public static string Icon_ReplaceSMDH         => Get("Icon.ReplaceSMDH", "是否替换SMDH?");
    public static string Icon_ImportImage         => Get("Icon.ImportImage", "是否导入图片?");
    public static string Icon_InvalidImageFormat  => Get("Icon.InvalidImageFormat", "非法的图片格式！");
    public static string Icon_ImageSizeIncorrect  => Get("Icon.ImageSizeIncorrect", "图片尺寸不正确。");
    public static string Icon_ExpectedDimensions  => Get("Icon.ExpectedDimensions", "预期尺寸（24x24 或 48x48）");

    // ===== MapPerm =====
    public static string MapPerm_CopyToClipboard => Get("MapPerm.CopyToClipboard", "是否复制图片到剪切板?");

    // ===== SMWE =====
    public static string SMWE_NoTableToCopy       => Get("SMWE.NoTableToCopy", "没有要复制的表格");
    public static string SMWE_TableDataCopied     => Get("SMWE.TableDataCopied", "已复制表格数据");
    public static string SMWE_NoTableToPaste      => Get("SMWE.NoTableToPaste", "没有要粘贴的表格");
    public static string SMWE_EncounterRateInvalid => Get("SMWE.EncounterRateInvalid", "遭遇机率加起来必须为 0% 或 100%");
    public static string SMWE_ExportMapConfirm    => Get("SMWE.ExportMapConfirm", "此操作将在pk3DS目录下创建encdata目录，并保存Map数据，是否继续?");
    public static string SMWE_AllTablesExported   => Get("SMWE.AllTablesExported", "已导出全部表格");
    public static string SMWE_RandomAll           => Get("SMWE.RandomAll", "是否全部随机化？无法撤消。");
    public static string SMWE_CheckRandomSettings => Get("SMWE.CheckRandomSettings", "请先核对左下角的随机化设置。");
    public static string SMWE_Randomized          => Get("SMWE.Randomized", "已根据设置，随机化全部野外遭遇！");
    public static string SMWE_ExportToView        => Get("SMWE.ExportToView", "按下“导出表格”按钮来查看新的野外遭遇信息。");
    public static string SMWE_CopyToSOS           => Get("SMWE.CopyToSOS", "是否将常规遭遇的宝可梦，复制到SOS闯入对战?");
    public static string SMWE_CantUndo            => Get("SMWE.CantUndo", "无法撤销");
    public static string SMWE_CopiedToSOS         => Get("SMWE.CopiedToSOS", "已将常规遭遇的宝可梦，复制到SOS闯入对战");
    public static string SMWE_ModAllLevels        => Get("SMWE.ModAllLevels", "是否修改全部遭遇宝可梦的等级");
    public static string SMWE_LevelsModified      => Get("SMWE.LevelsModified", "已根据设置，修改全部遭遇宝可梦的等级");

    // ===== RSWE =====
    public static string RSWE_Randomized   => Get("RSWE.Randomized", "已根据设置，随机化全部野外遭遇!");
    public static string RSWE_ExportToView => Get("RSWE.ExportToView", "按下“导出表格”按钮来查看新的野外遭遇信息。");

    // ===== TM =====
    public static string TM_RandomMoves         => Get("TM.RandomMoves", "是否随机化招式？");
    public static string TM_SameCompatibility   => Get("TM.SameCompatibility", "招式兼容性将与先前一致。");
    public static string TMHM_MayCauseStuck     => Get("TMHM.MayCauseStuck", "随机化秘传机可能会导致游戏卡关！");
    public static string TMHM_ContinuePrompt    => Get("TMHM.ContinuePrompt", "是否继续？");

    // ===== Starter =====
    public static string Starter_RandomClose    => Get("Starter.RandomClose", "随机化后是否直接关闭？");

    // ===== Tutor =====
    public static string Tutor_RandomizeComplete       => Get("Tutor.RandomizeComplete", "随机完成！已修改 {0} 个招式导师的招式和 Price。\n招式范围: 1-{1}\nPrice 范围: 1-8\n\n注意：此功能仍需测试，随机结果可能存在问题，请保存后到游戏中验证。");

    // ===== TitleScreen =====
    public static string TitleScreen_Overwrite         => Get("TitleScreen.Overwrite", "是否覆盖？");
    public static string TitleScreen_SizeMismatch      => Get("TitleScreen.SizeMismatch", "尺寸不匹配！");
    public static string TitleScreen_RecompressWait    => Get("TitleScreen.RecompressWait", "重新压缩可能需要一些时间...");
    public static string TitleScreen_DontPanic         => Get("TitleScreen.DontPanic", "如果进度条不动，不要慌！");
    public static string TitleScreen_CopyToClipboard   => Get("TitleScreen.CopyToClipboard", "是否复制图片到剪贴板？");

    // ===== TypeChart =====
    public static string TypeChart_CroNotExists => Get("TypeChart.CroNotExists", "CRO 不存在！关闭中...");

    // ===== LevelUp =====
    public static string LevelUp_StatsSummary => Get("LevelUp.StatsSummary", "共习得招式: {0}\r\n单个宝可梦最大招式习得数: {1}\r\n同属性增益计数: {2}");

    // ===== EggMove =====
    public static string EggMove_StatsSummary => Get("EggMove.StatsSummary", "共指定蛋招式: {0}\r\n同属性增益计数: {1}");
}
