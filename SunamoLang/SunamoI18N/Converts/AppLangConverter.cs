namespace SunamoLang.SunamoI18N.Converts;

/// <summary>
/// Represents the app lang converter type.
/// </summary>
public static class AppLangConverter
{
    /// <summary>
    /// Convert to.
    /// </summary>
    /// <param name="text">The text.</param>
    /// <returns>The convert to result.</returns>
    public static AppLang ConvertTo(string text)
    {
        return new AppLang(byte.Parse(text[0].ToString()), byte.Parse(text[1].ToString()));
    }

    /// <summary>
    /// Convert from.
    /// </summary>
    /// <param name="appLang">The app lang.</param>
    /// <returns>The convert from result.</returns>
    public static string ConvertFrom(AppLang appLang)
    {
        return appLang.Type + appLang.Language.ToString();
    }
}
