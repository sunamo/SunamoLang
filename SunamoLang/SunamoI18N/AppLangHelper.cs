namespace SunamoLang.SunamoI18N;

public static class AppLangHelper
{
    private const byte fixedLanguageType = 0;
    private const byte systemLanguageType = 1;
    private const byte dependingOnLanguage = 0;
    private const string czechOSLanguageText = "Podle nastaveného jazyka OS";
    private const string englishOSLanguageText = "Depending on the OS language";

    public static CultureInfo? CurrentCulture { get; set; } = null;

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

    public static AppLang? SelectedInComboBox { get; set; }

    static AppLangHelper()
    {
        fixedLanguages.Add("cs", "Čeština");
        fixedLanguages.Add("en", Translate.FromKey(XlfKeys.English));
        var systemLanguageCS = new List<string>();
        systemLanguageCS.Add(czechOSLanguageText);
        var systemLanguageEN = new List<string>();
        systemLanguageEN.Add(englishOSLanguageText);
        systemLanguages.Add("cs", systemLanguageCS);
        systemLanguages.Add("en", systemLanguageEN);
    }

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

    public static Langs GetLang3(string languageCode)
    {
        if (languageCode.Length == 5 && languageCode[2] == '-') return GetLangFromCode(languageCode.Substring(0, 2));
        return GetLangFromCode(languageCode);
    }

    public static CultureInfo GetCultureInfo(Langs lang)
    {
        CultureInfo? cultureInfo = null;
        if (lang == Langs.cs)
            cultureInfo = new CultureInfo("cs");
        else
            cultureInfo = new CultureInfo("en");
        return cultureInfo;
    }

    public static Langs GetLang(CultureInfo cultureInfo)
    {
        if (cultureInfo.TwoLetterISOLanguageName == "cs")
            return Langs.cs;
        return Langs.en;
    }

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
