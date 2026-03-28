namespace SunamoLang.SunamoI18N;

/// <summary>
/// Helper class for application language settings and culture management.
/// </summary>
public static class AppLangHelper
{
    /// <summary>
    /// Fixed language type constant (value: 0).
    /// </summary>
    private const byte fixedLanguageType = 0;

    /// <summary>
    /// System language type constant (value: 1).
    /// </summary>
    private const byte systemLanguageType = 1;

    /// <summary>
    /// Language-dependent constant (value: 0).
    /// </summary>
    private const byte dependingOnLanguage = 0;

    /// <summary>
    /// Czech text for "Depending on the OS language" setting.
    /// </summary>
    private const string czechOSLanguageText = "Podle nastaven\u00E9ho jazyka OS";

    /// <summary>
    /// English text for "Depending on the OS language" setting.
    /// </summary>
    private const string englishOSLanguageText = "Depending on the OS language";

    /// <summary>
    /// Gets or sets the current culture information.
    /// </summary>
    public static CultureInfo? CurrentCulture { get; set; } = null;

    /// <summary>
    /// Gets or sets the current UI culture information.
    /// </summary>
    public static CultureInfo? CurrentUICulture { get; set; } = null;

    /// <summary>
    /// Languages that the user can select manually.
    /// Key is the language abbreviation, value is its full name.
    /// </summary>
    private static readonly Dictionary<string, string> fixedLanguages = new();

    /// <summary>
    /// System language texts.
    /// Key is the two-character language name, value contains texts like "Depending on the OS language".
    /// </summary>
    private static readonly Dictionary<string, List<string>> systemLanguages = new();

    /// <summary>
    /// Language code mappings.
    /// Key is the two-character language name, value is the numeric code used in AppLang class.
    /// </summary>
    private static Dictionary<string, byte> languageCodes = new();

    /// <summary>
    /// Gets or sets the currently selected language in the combo box.
    /// </summary>
    public static AppLang? SelectedInComboBox { get; set; }

    static AppLangHelper()
    {
        fixedLanguages.Add("cs", "\u010Ce\u0161tina");
        fixedLanguages.Add("en", Translate.FromKey(XlfKeys.English));
        var systemLanguageCS = new List<string>();
        systemLanguageCS.Add(czechOSLanguageText);
        var systemLanguageEN = new List<string>();
        systemLanguageEN.Add(englishOSLanguageText);
        systemLanguages.Add("cs", systemLanguageCS);
        systemLanguages.Add("en", systemLanguageEN);
    }

    /// <summary>
    /// Returns the language name for display (e.g., in a ComboBox for language selection).
    /// If the language type is not fixed, returns the appropriate text based on OS language.
    /// </summary>
    /// <param name="appLang">The current AppLang instance.</param>
    /// <returns>The display name for the language.</returns>
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

            if (dependingCulture == null)
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
    /// Returns the language in which content should be displayed.
    /// Supports both two-letter and five-letter (e.g., en-US) language codes.
    /// </summary>
    /// <param name="text">The language code string.</param>
    /// <returns>The corresponding Langs enum value.</returns>
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

    /// <summary>
    /// Returns the language enum value from a two-letter language code (e.g., "cs" or "en").
    /// </summary>
    /// <param name="languageCode">The two-letter language code.</param>
    /// <returns>The corresponding Langs enum value.</returns>
    private static Langs GetLangFromCode(string languageCode)
    {
        var result = Langs.cs;
        if (Enum.TryParse(languageCode, out result)) return result;
        return Langs.en;
    }

    /// <summary>
    /// Returns the language enum value from either a two-letter or five-letter language code.
    /// </summary>
    /// <param name="languageCode">The language code (e.g., "en" or "en-US").</param>
    /// <returns>The corresponding Langs enum value.</returns>
    public static Langs GetLang3(string languageCode)
    {
        if (languageCode.Length == 5 && languageCode[2] == '-') return GetLangFromCode(languageCode.Substring(0, 2));
        return GetLangFromCode(languageCode);
    }

    /// <summary>
    /// Returns the CultureInfo for the specified language.
    /// </summary>
    /// <param name="lang">The language enum value.</param>
    /// <returns>The corresponding CultureInfo instance.</returns>
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
    /// Returns the Langs enum value based on the provided CultureInfo.
    /// </summary>
    /// <param name="cultureInfo">The CultureInfo to extract language from.</param>
    /// <returns>The corresponding Langs enum value.</returns>
    public static Langs GetLang(CultureInfo cultureInfo)
    {
        if (cultureInfo.TwoLetterISOLanguageName == "cs")
            return Langs.cs;
        return Langs.en;
    }

    /// <summary>
    /// Returns a list of AppLang items to populate a language selection ComboBox.
    /// </summary>
    /// <param name="settingsAppLang">The current language settings string.</param>
    /// <returns>A list of AppLang items for the ComboBox.</returns>
    public static List<AppLang> ItemsToAddToComboBox(string settingsAppLang)
    {
        var result = new List<AppLang>();
        SelectedInComboBox = null;
        byte index = 0;
        foreach (var item in fixedLanguages)
        {
            var appLang = new AppLang(fixedLanguageType, index);
            if (SelectedInComboBox == null)
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
                if (SelectedInComboBox == null)
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
                if (SelectedInComboBox == null)
                    if (AppLangConverter.ConvertFrom(appLang) == settingsAppLang)
                        SelectedInComboBox = appLang;
                result.Add(appLang);
                index++;
            }
        }

        return result;
    }
}
