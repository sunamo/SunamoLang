namespace SunamoLang.Interfaces;

/// <summary>
/// Represents the i locale helper type.
/// </summary>
public interface ILocaleHelper
{
    /// <summary>
    /// Get country for lang 2.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <returns>The get country for lang 2 result.</returns>
    string GetCountryForLang2(string lang);

    /// <summary>
    /// Get lang for country 2.
    /// </summary>
    /// <param name="country">The country.</param>
    /// <returns>The get lang for country 2 result.</returns>
    string? GetLangForCountry2(string country);
}
