namespace SunamoLang.SunamoI18N;

/// <summary>
/// Represents the app lang helper type.
/// </summary>
public static class AppLangHelper
{
    private const byte fixedLanguageType = 0;
    private const byte systemLanguageType = 1;
    private const byte dependingOnLanguage = 0;
    /// <summary>
    /// Czech text for "Depending on the OS language" setting.
    /// </summary>
    /// <summary>
    /// English text for "Depending on the OS language" setting.
    /// </summary>
    private const string czechOSLanguageText = "Podle nastaveného jazyka OS";
    private const string englishOSLanguageText = "Depending on the OS language";

    /// <summary>
    /// Gets or sets the current culture.
    /// </summary>
    public static CultureInfo? CurrentCulture { get; set; } = null;

    /// <summary>
    /// Gets or sets the current UI culture.
    /// </summary>
    public static CultureInfo? CurrentUICulture { get; set; } = null;

    // Languages that the user can select manually.
    // Key is the language abbreviation, value is its full name.
    private static readonly Dictionary<string, string> fixedLanguages = new();

    // System language texts.
    // Key is the two-character language name, value contains texts like "Depending on the OS language".
    private static readonly Dictionary<string, List<string>> systemLanguages = new();

    // Language code mappings.
    // Key is the two-character language name, value is the numeric code used in AppLang class.
    private static Dictionary<string, byte> languageCodes = new();

    /// <summary>
    /// Gets or sets the selected in combo box.
    /// </summary>
    public static AppLang? SelectedInComboBox { get; set; }

    static AppLangHelper()
    {
        fixedLanguages.Add("cs", "Čeština");
        fixedLanguages.Add("en", "English");
        var systemLanguageCS = new List<string>();
        systemLanguageCS.Add(czechOSLanguageText);
        var systemLanguageEN = new List<string>();
        systemLanguageEN.Add(englishOSLanguageText);
        systemLanguages.Add("cs", systemLanguageCS);
        systemLanguages.Add("en", systemLanguageEN);
    }

    /// <summary>
    /// Initializes a new instance of the to string class.
    /// </summary>
    /// <param name=""en"">The en.</param>
    /// <param name=""English"">The english.</param>
    public static string ToString(AppLang appLang)
    {
        var result = "";
        if (appLang.Type == fixedLanguageType)
        {
            result = fixedLanguages[((Langs)appLang.Language).ToString()];
        }
        else
        {
            CultureInfo? dependingCulture = null;
            if (appLang.Language == dependingOnLanguage)
                dependingCulture = CurrentUICulture;
            else
                dependingCulture = CurrentCulture;

            if (dependingCulture is null)
            {
                if (appLang.Language == dependingOnLanguage)
                    dependingCulture = CultureInfo.CurrentUICulture;
                else
                    dependingCulture = CultureInfo.CurrentCulture;
            }

            if (dependingCulture.TwoLetterISOLanguageName == "cs")
            {
                if (appLang.Language == 0)
                    result = czechOSLanguageText + "-" +
                         fixedLanguages[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
            else
            {
                if (appLang.Language == 0)
                    result = englishOSLanguageText + "-" +
                         fixedLanguages[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }

        return result;
    }

    /// <summary>
    /// Initializes a new instance of the get lang class.
    /// </summary>
    /// <param name="appLang.Language">The app lang language.</param>
    public static Langs GetLang(string text)
    {
        var result = Langs.cs;
        var appLang = AppLangConverter.ConvertTo(text);
        if (appLang.Type == fixedLanguageType)
        {
            result = (Langs)appLang.Language;
        }
        else
        {
            if (appLang.Language == 0)
                result = GetLangFromCode(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            else if (appLang.Language == 1) result = GetLangFromCode(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

        return result;
    }

    private static Langs GetLangFromCode(string languageCode)
    {
        var result = Langs.cs;
        if (Enum.TryParse(languageCode, out result)) return result;
        return Langs.en;
    }

    /// <summary>
    /// Get lang 3.
    /// </summary>
    /// <param name="languageCode">The language code.</param>
    /// <returns>The get lang 3 result.</returns>
    public static Langs GetLang3(string languageCode)
    {
        if (languageCode.Length == 5 && languageCode[2] == '-') return GetLangFromCode(languageCode.Substring(0, 2));
        return GetLangFromCode(languageCode);
    }

    /// <summary>
    /// Get culture info.
    /// </summary>
    /// <param name="languageCode">The language code.</param>
    /// <returns>The get culture info result.</returns>
    public static CultureInfo GetCultureInfo(Langs lang)
    {
        CultureInfo? cultureInfo = null;
        if (lang == Langs.cs)
            cultureInfo = new CultureInfo("cs");
        else
            cultureInfo = new CultureInfo("en");
        return cultureInfo;
    }

    /// <summary>
    /// Get lang.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <returns>The get lang result.</returns>
    public static Langs GetLang(CultureInfo cultureInfo)
    {
        if (cultureInfo.TwoLetterISOLanguageName == "cs")
            return Langs.cs;
        return Langs.en;
    }

    /// <summary>
    /// Items to add to combo box.
    /// </summary>
    /// <param name="cultureInfo">The culture info.</param>
    /// <returns>The items to add to combo box result.</returns>
    public static List<AppLang> ItemsToAddToComboBox(string settingsAppLang)
    {
        var result = new List<AppLang>();
        SelectedInComboBox = null;
        byte index = 0;
        foreach (var item in fixedLanguages)
        {
            var appLang = new AppLang(fixedLanguageType, index);
            if (SelectedInComboBox is null)
                if (AppLangConverter.ConvertFrom(appLang) == settingsAppLang)
                    SelectedInComboBox = appLang;
            result.Add(appLang);
            index++;
        }

        if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "cs")
        {
            index = 0;
            foreach (var item in systemLanguages["cs"])
            {
                var appLang = new AppLang(systemLanguageType, index);
                if (SelectedInComboBox is null)
                    if (AppLangConverter.ConvertFrom(appLang) == settingsAppLang)
                        SelectedInComboBox = appLang;
                result.Add(appLang);
                index++;
            }
        }
        else
        {
            index = 0;
            foreach (var item in systemLanguages["en"])
            {
                var appLang = new AppLang(systemLanguageType, index);
                if (SelectedInComboBox is null)
                    if (AppLangConverter.ConvertFrom(appLang) == settingsAppLang)
                        SelectedInComboBox = appLang;
                result.Add(appLang);
                index++;
            }
        }

        return result;
    }
}
