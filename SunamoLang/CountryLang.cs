namespace SunamoLang;

public class CountryLang
{
    public static Dictionary<Langs, string> LanguageToCountryMap { get; } = new();

    static CountryLang()
    {
        Init();
    }

    public static void Init()
    {
        LanguageToCountryMap.Add(Langs.en, "GB");
        LanguageToCountryMap.Add(Langs.cs, "CZ");
    }
}
