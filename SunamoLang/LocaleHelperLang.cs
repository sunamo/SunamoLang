namespace SunamoLang;

public class LocaleHelperLang : ILocaleHelper
{
    #region For easy copy

    public string GetCountryForLang2(string lang)
    {
        // Easy copy = BCL enum parse
        var list = (Langs)Enum.Parse(typeof(Langs), lang);
        switch (list)
        {
            case Langs.cs:
                return "CZ";
            case Langs.en:
            default:
                return "GB";
        }
    }

    public string GetLangForCountry2(string country)
    {
        foreach (var item in CountryLang.d)
            if (item.Value == country)
                return item.Key.ToString();
        return null;
    }

    public static string GetLangForCountry(string country)
    {
        country = country.ToLower();
        foreach (var item in CultureInfo.GetCultures(CultureTypes.AllCultures))
        {
            var parameter = item.Name.Split('-').ToList();
            if (parameter.Count > 1)
                if (parameter[1] == country)
                    if (parameter[0].Length == 2)
                        //ComplexInfoString cis = new ComplexInfoString(parameter[0]);
                        //if (cis.QuantityLowerChars == 2)
                        //{
                        // Its not good idea because for en return AG
                        return parameter[0];
            //}
        }

        return null;
    }

    #endregion
}