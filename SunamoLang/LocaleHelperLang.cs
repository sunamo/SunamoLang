namespace SunamoLang;

/// <summary>
/// Represents the locale helper lang type.
/// </summary>
public class LocaleHelperLang : ILocaleHelper
{
    #region For easy copy

    /// <summary>
    /// Get country for lang 2.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <returns>The get country for lang 2 result.</returns>
    public string GetCountryForLang2(string lang)
    {
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
    /// Get lang for country 2.
    /// </summary>
    /// <param name="country">The country.</param>
    /// <returns>The get lang for country 2 result.</returns>
    public string? GetLangForCountry2(string country)
    {
        foreach (var item in CountryLang.LanguageToCountryMap)
            if (item.Value == country)
                return item.Key.ToString();
        return null;
    }

    /// <summary>
    /// Get lang for country.
    /// </summary>
    /// <param name="country">The country.</param>
    /// <returns>The get lang for country result.</returns>
    public static string? GetLangForCountry(string country)
    {
        country = country.ToLower();
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            var cultureParts = item.Name.Split('-').ToList();
            if (cultureParts.Count > 1)
                if (cultureParts[1] == country)
                    if (cultureParts[0].Length == 2)
                        return cultureParts[0];
        }

        return null;
    }

    #endregion
}
