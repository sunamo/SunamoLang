namespace SunamoLang.SunamoXlf;

/// <summary>
/// Helper class for XLF (XLIFF) resource loading and processing.
/// In sunamo, XliffParser and fmdev.ResX are not available as they require .NET Framework due to CodeDom.
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
    public static string? SaveResouresToRL(string basePathToSunamoProject, LocalizationLanguages localizationLanguages)
    {
        return SaveResouresToRL<string, string>(null, basePathToSunamoProject, localizationLanguages);
    }

    #region Main worker

    /// <summary>
    /// Saves localization resources to the resource loader with generic type parameters.
    /// </summary>
    /// <typeparam name="StorageFolder">The storage folder type (unused, for compatibility).</typeparam>
    /// <typeparam name="StorageFile">The storage file type (unused, for compatibility).</typeparam>
    /// <param name="key">The resource key to process.</param>
    /// <param name="basePath">The base path to the project.</param>
    /// <param name="localizationLanguages">The localization languages containing Czech and English content.</param>
    /// <returns>The resource key that was processed, or null if already processed.</returns>
    public static string? SaveResouresToRL<StorageFolder, StorageFile>(string? key, string basePath,
        LocalizationLanguages localizationLanguages)
    {
        if (previousKey == key && previousKey != null) return null;
        previousKey = key;
        ProcessXlfContent(Langs.cs, localizationLanguages.Cs);
        ProcessXlfContent(Langs.en, localizationLanguages.En);

        return key;
    }

    /// <summary>
    /// Extracts all translation units from an XLF document into a dictionary.
    /// </summary>
    /// <param name="document">The XLF document to process.</param>
    /// <returns>A dictionary mapping translation IDs to their target values.</returns>
    public static Dictionary<string, string> GetTransUnits(XlfDocumentLang document)
    {
        var result = new Dictionary<string, string>();
        var xlfFiles = document.Files;
        if (xlfFiles.Count() != 0)
            foreach (var item in xlfFiles)
            {
                if (item.Original.EndsWith("/RESOURCES.RESX"))
                    if (item.TransUnits.Count() > 0)
                        Debugger.Break();
                foreach (var translationUnit in item.TransUnits)
                    if (!result.ContainsKey(translationUnit.Id))
                        result.Add(translationUnit.Id, translationUnit.Target);
            }

        return result;
    }

    private static void ProcessXlfContent(Langs language, string content)
    {
        var isCzech = language == Langs.cs;
        var isEnglish = language == Langs.en;
        var document = new XlfDocumentLang();
        document.LoadXml(content);
        var languageCode = language.ToString().ToLower();
        var xlfFiles = document.Files.Where(file => file.Original.ToLower().Contains(languageCode));
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
        }
    }

    private static string GetResourceFilename(Langs language)
    {
        string? filename = null;
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

        return filename!;
    }

    #endregion
}
