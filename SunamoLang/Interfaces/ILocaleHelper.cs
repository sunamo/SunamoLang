namespace SunamoLang.Interfaces;

/// <summary>
/// Provides locale conversion operations between language and country codes.
/// </summary>
public interface ILocaleHelper
{
    /// <summary>
    /// Gets the country code for the specified language.
    /// </summary>
    /// <param name="lang">The language code.</param>
    /// <returns>The country code corresponding to the language.</returns>
    string GetCountryForLang2(string lang);

    /// <summary>
    /// Gets the language code for the specified country.
    /// </summary>
    /// <param name="country">The country code.</param>
    /// <returns>The language code corresponding to the country.</returns>
    string GetLangForCountry2(string country);
}