namespace SunamoLang;

public class LocaleHelperLang : ILocaleHelper
{
    #region For easy copy

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

    public string? GetLangForCountry2(string country)
    {
        foreach (var item in CountryLang.LanguageToCountryMap)
            if (item.Value == country)
                return item.Key.ToString();
        return null;
    }

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
