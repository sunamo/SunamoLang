namespace SunamoLang.SunamoXlf;

/// <summary>
/// Represents the xlf resources h type.
/// </summary>
public class XlfResourcesH
{
    /// <summary>
    /// Gets or sets the initialized.
    /// </summary>
    public static bool Initialized { get; set; } = false;

    private static string? previousKey;

    /// <summary>
    /// Path to xlf sunamo.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <param name="basePathXlfFile">The base path xlf file.</param>
    /// <returns>The path to xlf sunamo result.</returns>
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
    /// Save resoures to RL.
    /// </summary>
    /// <param name="basePathToSunamoProject">The base path to sunamo project.</param>
    /// <param name="localizationLanguages">The localization languages.</param>
    /// <returns>The save resoures to RL result.</returns>
    public static string? SaveResouresToRL(string basePathToSunamoProject, LocalizationLanguages localizationLanguages)
    {
        return SaveResouresToRL<string, string>(null, basePathToSunamoProject, localizationLanguages);
    }

    #region Main worker

    /// <summary>
    /// Save resoures to RL storage folder storage file.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="basePath">The base path.</param>
    /// <param name="localizationLanguages">The localization languages.</param>
    /// <returns>The save resoures to RL storage folder storage file result.</returns>
    public static string? SaveResouresToRL<StorageFolder, StorageFile>(string? key, string basePath,
        LocalizationLanguages localizationLanguages)
    {
        _ = basePath;
        if (previousKey == key && previousKey != null) return null;
        previousKey = key;
        ProcessXlfContent(Langs.cs, localizationLanguages.Cs);
        ProcessXlfContent(Langs.en, localizationLanguages.En);

        return key;
    }

    /// <summary>
    /// Get trans units.
    /// </summary>
    /// <param name="document">The document.</param>
    /// <returns>The get trans units result.</returns>
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
