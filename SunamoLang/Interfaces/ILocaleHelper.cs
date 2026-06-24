namespace SunamoLang.Interfaces;

public interface ILocaleHelper
{
    string GetCountryForLang2(string lang);

    string? GetLangForCountry2(string country);
}
