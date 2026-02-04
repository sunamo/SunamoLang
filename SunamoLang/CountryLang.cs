namespace SunamoLang;

/// <summary>
/// Provides mapping between languages and their corresponding country codes.
/// </summary>
public class CountryLang
{
    /// <summary>
    /// Gets the dictionary mapping languages to country codes.
    /// </summary>
    public static Dictionary<Langs, string> LanguageToCountryMap { get; } = new();

    static CountryLang()
    {
        Init();
    }

    /// <summary>
    /// Initializes the language-to-country mapping.
    /// </summary>
    public static void Init()
    {
        LanguageToCountryMap.Add(Langs.en, "GB");
        LanguageToCountryMap.Add(Langs.cs, "CZ");
    }
}
