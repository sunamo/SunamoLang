namespace SunamoLang.SunamoI18N.Converts;

/// <summary>
/// Provides conversion between AppLang and string representations.
/// </summary>
public static class AppLangConverter
{
    /// <summary>
    /// Converts a two-character string to an AppLang instance.
    /// </summary>
    /// <param name="text">A two-character string where each character represents a byte value.</param>
    /// <returns>An AppLang instance constructed from the string.</returns>
    public static AppLang ConvertTo(string text)
    {
        return new AppLang(byte.Parse(text[0].ToString()), byte.Parse(text[1].ToString()));
    }

    /// <summary>
    /// Converts an AppLang instance to its string representation.
    /// </summary>
    /// <param name="appLang">The AppLang instance to convert.</param>
    /// <returns>A string representation of the AppLang.</returns>
    public static string ConvertFrom(AppLang appLang)
    {
        return appLang.Type + appLang.Language.ToString();
    }
}