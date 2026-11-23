namespace SunamoLang;

/// <summary>
/// Represents the country lang type.
/// </summary>
public class CountryLang
{
    /// <summary>
    /// Gets the language to country map.
    /// </summary>
    public static Dictionary<Langs, string> LanguageToCountryMap { get; } = new();

    static CountryLang()
    {
        Init();
    }

    /// <summary>
    /// Initializes a new instance of the init class.
    /// </summary>
    public static void Init()
    {
        LanguageToCountryMap.Add(Langs.en, "GB");
        LanguageToCountryMap.Add(Langs.cs, "CZ");
    }
}
