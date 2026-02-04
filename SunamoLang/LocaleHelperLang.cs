namespace SunamoLang;

/// <summary>
/// Helper class for locale operations, converting between language and country codes.
/// </summary>
public class LocaleHelperLang : ILocaleHelper
{
    #region For easy copy

    /// <summary>
    /// Gets the country code for the specified language.
    /// </summary>
    /// <param name="lang">The language code (e.g., "cs", "en").</param>
    /// <returns>The country code (e.g., "CZ", "GB").</returns>
    public string GetCountryForLang2(string lang)
    {
        // Easy copy = BCL enum parse
        var langEnum = (Langs)Enum.Parse(typeof(Langs), lang);
        switch (langEnum)
        {
            case Langs.cs:
                return "CZ";
            case Langs.en:
            default:
                return "GB";
        }
    }

    /// <summary>
    /// Gets the language code for the specified country.
    /// </summary>
    /// <param name="country">The country code (e.g., "CZ", "GB").</param>
    /// <returns>The language code (e.g., "cs", "en"), or null if not found.</returns>
    public string GetLangForCountry2(string country)
    {
        foreach (var item in CountryLang.LanguageToCountryMap)
            if (item.Value == country)
                return item.Key.ToString();
        return null;
    }

    /// <summary>
    /// Gets the language code for the specified country by querying all available cultures.
    /// </summary>
    /// <param name="country">The country code (e.g., "cz", "gb").</param>
    /// <returns>The language code (e.g., "cs", "en"), or null if not found.</returns>
    public static string GetLangForCountry(string country)
    {
        country = country.ToLower();
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            var cultureParts = item.Name.Split('-').ToList();
            if (cultureParts.Count > 1)
                if (cultureParts[1] == country)
                    if (cultureParts[0].Length == 2)
                        //ComplexInfoString cis = new ComplexInfoString(cultureParts[0]);
                        //if (cis.QuantityLowerChars == 2)
                        //{
                        // Its not good idea because for en return AG
                        return cultureParts[0];
            //}
        }

        return null;
    }

    #endregion
}