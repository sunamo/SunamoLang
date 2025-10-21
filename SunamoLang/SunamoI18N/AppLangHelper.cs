// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoI18N;

public static class AppLangHelper
{
    /// <summary>
    ///     Číslo 0
    /// </summary>
    private const byte fixedC = 0;

    /// <summary>
    ///     Číslo 1
    /// </summary>
    private const byte systemC = 1;

    private const byte dependingOnLanguage = 0;

    //const byte dependingOnCountry = 1;
    /// <summary>
    ///     Text Podle nastaveného jazyka OS
    ///     Ačkoliv má v názvu 0, používá se když typ jazyku není 0
    /// </summary>
    private const string cs0 = "Podle nastaven\u00E9ho jazyka OS";

    //const string cs1 = "Podle nastaveného regionu";
    /// <summary>
    ///     Text Depending on the OS language
    ///     Ačkoliv má v názvu 0, používá se když typ jazyku není 0
    /// </summary>
    private const string en0 = "Depending on the OS language";

    public static CultureInfo currentCulture = null;
    public static CultureInfo currentUICulture = null;

    /// <summary>
    ///     Jazyky které si může zvolit sám uživatel
    ///     V klíči je zkratka jazyku, v hodnotě pak její plný název
    /// </summary>
    private static readonly Dictionary<string, string> s_fixedLanguages = new();

    /// <summary>
    ///     Texty, které jazyky
    ///     V klíči je dvou znakový název jazyku, v hodnotě pak texty "Podle nastaveného jazyka OS" a "Depending on the OS
    ///     language"
    /// </summary>
    private static readonly Dictionary<string, List<string>> s_systemLanguages = new();

    /// <summary>
    ///     V klíči je dvouznakový název jazyku, v hodnotě číslo tohoto jazyku, které je v třídě AppLang
    /// </summary>
    private static Dictionary<string, byte> s_languageCodes = new();

    //const string en1 = "Depending on the country";
    public static AppLang selectedInCB;

    static AppLangHelper()
    {
        s_fixedLanguages.Add("cs", "\u010Ce\u0161tina");
        s_fixedLanguages.Add("en", Translate.FromKey(XlfKeys.English));
        var systemLanguageCS = new List<string>();
        systemLanguageCS.Add(cs0);
        var systemLanguageEN = new List<string>();
        systemLanguageEN.Add(en0);
        s_systemLanguages.Add("cs", systemLanguageCS);
        s_systemLanguages.Add("en", systemLanguageEN);
    }

    /// <summary>
    ///     Vrátí název jazyku například do ComboBoxu na změnu jazyka
    ///     Vrací pokud A1.TYpe není 0 správný text podle jazyka OS
    /// </summary>
    /// <param name="actual"></param>
    /// <param name="displayed"></param>
    public static string ToString(AppLang actual)
    {
        var vr = "";
        //Langs l = Langs.cs;
        if (actual.Type == fixedC)
        {
            //l = (Langs)actual.Language;
            vr = s_fixedLanguages[((Langs)actual.Language).ToString()];
        }
        else
        {
            CultureInfo depending = null;
            if (actual.Language == dependingOnLanguage)
                depending = currentUICulture;
            else
                depending = currentCulture;
            //depending = CultureInfo.CurrentCulture;
            if (depending == null)
            {
                if (actual.Language == dependingOnLanguage)
                    depending = CultureInfo.CurrentUICulture;
                else
                    depending = CultureInfo.CurrentCulture;
            }

            if (depending.TwoLetterISOLanguageName == "cs")
            {
                if (actual.Language == 0)
                    vr = cs0 + "-" +
                         s_fixedLanguages[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
            else //if (depending.TwoLetterISOLanguageName == "en")
            {
                if (actual.Language == 0)
                    vr = en0 + "-" +
                         s_fixedLanguages[CultureInfo.CurrentUICulture.TwoLetterISOLanguageName];
            }
        }

        return vr;
    }

    /// <summary>
    ///     Metoda která mi vrátí jazyk ve kterém se má obsah zobrazit
    ///     GetLang2 return from two letters lang
    ///     GetLang3 return from two or five (en-us) letters
    /// </summary>
    /// <param name="b"></param>
    public static Langs GetLang(string b)
    {
        var vr = Langs.cs;
        var actual = AppLangConverter.ConvertTo(b);
        if (actual.Type == fixedC)
        {
            vr = (Langs)actual.Language;
        }
        else
        {
            if (actual.Language == 0)
                vr = GetLang2(CultureInfo.CurrentUICulture.TwoLetterISOLanguageName);
            else if (actual.Language == 1) vr = GetLang2(CultureInfo.CurrentCulture.TwoLetterISOLanguageName);
        }

        return vr;
    }

    /// <summary>
    ///     Používá se když chci vrátit jazyk ve výčtu Langs - A1 musí být obsah výčtu Langs, tedy cs nebo en
    ///     2 má v názvu proto že stejná metoda již existuje, ale ta mi vráti jazyk i podle OS
    /// </summary>
    /// <param name="p"></param>
    private static Langs GetLang2(string p)
    {
        var vr = Langs.cs;
        if (Enum.TryParse(p, out vr)) return vr;
        return Langs.en;
    }

    public static Langs GetLang3(string d)
    {
        if (d.Length == 5 && d[2] == '-') return GetLang2(d.Substring(0, 2));
        return GetLang2(d);
    }

    /// <summary>
    ///     Vrátí CultureInfo dané země bez specifikace jazyka pro jazyk A1
    /// </summary>
    /// <param name="p"></param>
    public static CultureInfo GetCi(Langs p)
    {
        CultureInfo ci = null;
        if (p == Langs.cs)
            ci = new CultureInfo("cs");
        else
            ci = new CultureInfo("en");
        return ci;
    }

    /// <summary>
    ///     Vrátí mi vyčet Langs, tedy jazyk na základě A1
    /// </summary>
    /// <param name="cultureInfo"></param>
    public static Langs GetLang(CultureInfo cultureInfo)
    {
        if (cultureInfo.TwoLetterISOLanguageName == "cs")
            return Langs.cs;
        return Langs.en;
    }

    public static List<AppLang> ItemsToAddToComboBox(string settingsAl)
    {
        var vr = new List<AppLang>();
        selectedInCB = null;
        byte i = 0;
        foreach (var item in s_fixedLanguages)
        {
            var al = new AppLang(fixedC, i);
            if (selectedInCB == null)
                if (AppLangConverter.ConvertFrom(al) == settingsAl)
                    selectedInCB = al;
            vr.Add(al);
            i++;
        }

        if (CultureInfo.CurrentUICulture.TwoLetterISOLanguageName == "cs")
        {
            i = 0;
            foreach (var item in s_systemLanguages["cs"])
            {
                var al = new AppLang(systemC, i);
                if (selectedInCB == null)
                    if (AppLangConverter.ConvertFrom(al) == settingsAl)
                        selectedInCB = al;
                vr.Add(al);
                i++;
            }
        }
        else
        {
            i = 0;
            foreach (var item in s_systemLanguages["en"])
            {
                var al = new AppLang(systemC, i);
                if (selectedInCB == null)
                    if (AppLangConverter.ConvertFrom(al) == settingsAl)
                        selectedInCB = al;
                vr.Add(al);
                i++;
            }
        }

        return vr;
    }
}