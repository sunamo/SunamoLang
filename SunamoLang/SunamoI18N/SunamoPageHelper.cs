namespace SunamoLang.SunamoI18N;

/// <summary>
/// Helper class for web application interoperability.
/// Provides localized string retrieval functionality.
/// </summary>
public class SunamoPageHelper
{
    /// <summary>
    /// Gets a localized string for the specified language and key.
    /// </summary>
    /// <param name="lang">The language code (e.g., "cs", "en").</param>
    /// <param name="key">The localization key.</param>
    /// <returns>The localized string value.</returns>
    public static string LocalizedString_String(string lang, string key)
    {
        switch (lang)
        {
            case "cs":
                return RLData.Cs[key];
            case "en":
                return RLData.En[key];
            default:
                ThrowEx.NotImplementedCase(lang);
                return null;
        }
    }
}