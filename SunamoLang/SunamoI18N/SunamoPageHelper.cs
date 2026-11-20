namespace SunamoLang.SunamoI18N;

/// <summary>
/// Represents the sunamo page helper type.
/// </summary>
public class SunamoPageHelper
{
    /// <summary>
    /// Localized string string.
    /// </summary>
    /// <param name="lang">The lang.</param>
    /// <param name="key">The key.</param>
    /// <returns>The localized string string result.</returns>
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
                return null!;
        }
    }
}
