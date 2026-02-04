namespace SunamoLang.SunamoXlf;

/// <summary>
///     Must be in shared
///     In sunamo is not XliffParser and fmdev.ResX - these projects requires .net fw due to CodeDom
/// </summary>
public class XlfResourcesH
{
    /// <summary>
    /// Gets or sets whether the XLF resources have been initialized.
    /// </summary>
    public static bool Initialized { get; set; } = false;

    private static string? previousKey;

    /// <summary>
    /// Constructs the full path to a Sunamo XLF file based on language and base path.
    /// </summary>
    /// <param name="lang">The language identifier.</param>
    /// <param name="basePathXlfFile">The base path to the XLF file without language suffix.</param>
    /// <returns>The full path to the XLF file including language suffix and extension.</returns>
    public static string PathToXlfSunamo(Langs lang, string basePathXlfFile)
    {
        //var basePathXlfFile = @"E:\vs\Projects\PlatformIndependentNuGetPackages\sunamo\MultilingualResources\sunamo.";
        switch (lang)
        {
            case Langs.cs:
                basePathXlfFile += "cs-CZ";
                break;
            case Langs.en:
                basePathXlfFile += "en-US";
                break;
            default:
                ThrowEx.NotImplementedCase(lang);
                break;
        }

        return basePathXlfFile + ".xlf";
    }

    /// <summary>
    /// Saves localization resources to the resource loader.
    /// </summary>
    /// <param name="basePathToSunamoProject">The base path to the Sunamo project.</param>
    /// <param name="localizationLanguages">The localization languages containing Czech and English content.</param>
    /// <returns>The resource key that was processed.</returns>
    public static string SaveResouresToRL(string basePathToSunamoProject, LocalizationLanguages localizationLanguages)
    {
        return SaveResouresToRL<string, string>(null, basePathToSunamoProject, localizationLanguages);
    }

    #region Main worker

    #region Less sophisficated - Loading always from file

    ///// <summary>
    ///// 2. loading from xlf files
    ///// </summary>
    ///// <typeparam name="StorageFolder"></typeparam>
    ///// <typeparam name="StorageFile"></typeparam>
    ///// <param name="basePath"></param>
    ///// <param name="existsDirectory"></param>
    ///// <param name="appData"></param>
    //public static string SaveResouresToRL<StorageFolder, StorageFile>(string key, string basePath, ExistsDirectory existsDirectory)
    //{
    //    if (previousKey == key && previousKey != null)
    //    {
    //        return null;
    //    }
    //    previousKey = key;
    //    // cant be inicialized - after cs is set initialized to true and skip english
    //    //initialized = true;
    //    var path = Path.Combine(basePath, "MultilingualResources");
    //    var files = Directory.GetFiles(path, "*.xlf", SearchOption.TopDirectoryOnly);
    //    foreach (var file3 in files)
    //    {
    //        var lang = XmlLocalisationInterchangeFileFormatXlf.GetLangFromFilename(file3);
    //        ProcessXlfFile(path, lang.ToString(), file3);
    //    }
    //    return key;
    //}

    #endregion

    #region More sophisficated - If is not my computer, reading from resources

    /// <summary>
    /// Saves localization resources to the resource loader with generic type parameters.
    /// </summary>
    /// <typeparam name="StorageFolder">The storage folder type (unused, for compatibility).</typeparam>
    /// <typeparam name="StorageFile">The storage file type (unused, for compatibility).</typeparam>
    /// <param name="key">The resource key to process.</param>
    /// <param name="basePath">The base path to the project.</param>
    /// <param name="localizationLanguages">The localization languages containing Czech and English content.</param>
    /// <returns>The resource key that was processed, or null if already processed.</returns>
    public static string SaveResouresToRL<StorageFolder, StorageFile>(string key, string basePath,
        LocalizationLanguages localizationLanguages)
    {
        if (previousKey == key && previousKey != null) return null;
        previousKey = key;
        // cant be inicialized - after cs is set initialized to true and skip english
        //initialized = true;
        var path = Path.Combine(basePath, "MultilingualResources");
        //throw new System.Exception("jinak");
        //Type type = typeof(Resources.ResourcesDuo);
        // ResourcesHelper rm = ResourcesHelper.Create("Resources.ResourcesDuo", type.Assembly);
        // #region 1) Loading direct from resources
        //var xlfContentCs =  rm.GetByteArray(Fn(Langs.cs));
        //var xlfContentEn = rm.GetByteArray(Fn(Langs.en));
        ProcessXlfContent(Langs.cs, localizationLanguages.Cs);
        ProcessXlfContent(Langs.en, localizationLanguages.En);
        // #endregion

        #region 2) Loading from files - obsolete

        //var exists = false;
        //exists = MyPc.Instance.IsMyComputerOrVps();
        //if (appData == null)
        //{
        //    // Is web app
        //    exists = true;
        //}
        ////exists = false;
        //// Pokud je můj PC nebo appData existují, neukládám na disk abych z něho mohl číst. v opačném případě ukládám
        //// This is totally important
        //// Otherwise is loading in non UWP apps from resx
        //if (!exists)
        //{
        //    var fn = "sunamo_cs_CZ";
        //    // Always true, in all apps I use _min. NEVER CHANGE IT!!!
        //    if (true) // PlatformInteropHelperXlf.IsSellingApp())
        //    {
        //        fn += "_min";
        //    }
        //    var file = appData.GetFileCommonSettings(fn + ".xlf");
        //    // Cant use StorageFile.ToString - get only name of method
        //    //pathFile = file.ToString();
        //    var enc = Encoding.GetEncoding(65001);
        //    string xlfContentCs = rm.GetByteArrayAsString(fn);
        //    FS.CreateUpfoldersPsysicallyUnlessThere(file);
        //    //xlfContent = xlfContent.Skip(3);
        //    File.WriteAllText(file, xlfContentCs, enc);
        //    TFXlf.RemoveDoubleBomUtf8(file);
        //    fn = "sunamo_en_US";
        //    // Always true, in all apps I use _min. NEVER CHANGE IT!!!
        //    if (true) //PlatformInteropHelperXlf.IsSellingApp())
        //    {
        //        fn += "_min";
        //    }
        //    var file2 = appData.GetFileCommonSettings(fn + ".xlf");
        //    string xlfContentEn = rm.GetByteArrayAsString(fn);
        //    File.WriteAllText(file2, xlfContentEn, enc);
        //    TFXlf.RemoveDoubleBomUtf8(file2);
        //    path = Path.Combine(appData.RootFolderCommon(true), "Settings");
        //}
        //ProcessXlfFiles(path); 

        #endregion

        return key;
    }

    /// <summary>
    /// Extracts all translation units from an XLF document into a dictionary.
    /// </summary>
    /// <param name="doc">The XLF document to process.</param>
    /// <returns>A dictionary mapping translation IDs to their target values.</returns>
    public static Dictionary<string, string> GetTransUnits(XlfDocumentLang doc)
    {
        var result = new Dictionary<string, string>();
        var xlfFiles = doc.Files;
        if (xlfFiles.Count() != 0)
            // Win every xlf will be t least two WPF.TESTS/PROPERTIES/RESOURCES.RESX and WPF.TESTS/RESOURCES/EN-US.RESX
            foreach (var item in xlfFiles)
            {
                // like WPF.TESTS/PROPERTIES/
                if (item.Original.EndsWith("/RESOURCES.RESX"))
                    if (item.TransUnits.Count() > 0)
                        Debugger.Break();
                foreach (var tu in item.TransUnits)
                    if (!result.ContainsKey(tu.Id))
                        result.Add(tu.Id, tu.Target);
            }

        return result;
    }

    private static void ProcessXlfContent(Langs language, string content)
    {
        var isCzech = language == Langs.cs;
        var isEnglish = language == Langs.en;
        var doc = new XlfDocumentLang();
        doc.LoadXml(content);
        var lang = language.ToString().ToLower();
        var xlfFiles = doc.Files.Where(d => d.Original.ToLower().Contains(lang));
        if (xlfFiles.Count() != 0)
        {
            var xlfFile = xlfFiles.First();
            foreach (var translationUnit in xlfFile.TransUnits)
                if (isCzech)
                {
                    if (!RLData.Cs.ContainsKey(translationUnit.Id)) RLData.Cs.Add(translationUnit.Id, translationUnit.Target);
                }
                else if (isEnglish)
                {
                    if (!RLData.En.ContainsKey(translationUnit.Id)) RLData.En.Add(translationUnit.Id, translationUnit.Target);
                }
            //throw new Exception("Invalid file " + file + ", please delete it");
        }
    }

    private static string Fn(Langs language)
    {
        string filename = null;
        switch (language)
        {
            case Langs.cs:
                filename = "sunamo_cs_CZ_min";
                break;
            case Langs.en:
                filename = "sunamo_en_US_min";
                break;
            default:
                ThrowEx.NotImplementedCase(language);
                break;
        }

        return filename;
    }

    #region Obsolete - loading from files

    //private static void ProcessXlfFiles(string path)
    //{
    //    var files = Directory.GetFiles(path, "*.xlf", SearchOption.TopDirectoryOnly);
    //    files.RemoveAll(d => d.EndsWith(".min.xlf"));
    //    foreach (var file3 in files)
    //    {
    //        var lang = XmlLocalisationInterchangeFileFormatXlf.GetLangFromFilename(file3);
    //        ProcessXlfFile(path, lang, file3);
    //    }
    //}
    //private static void ProcessXlfFile(string basePath, Langs lang, string file)
    //{
    //}
    //public static Dictionary<string, string> LoadXlfDocument(string file)
    //{
    //    var doc = new XlfDocument(file);
    //    return GetTransUnits(doc);
    //} 

    #endregion

    #endregion

    #endregion
}