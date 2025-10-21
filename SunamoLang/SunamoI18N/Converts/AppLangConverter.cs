// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoI18N.Converts;

/// <summary>
///     AppLang/string
/// </summary>
public static class AppLangConverter //: ISimpleConverter<AppLang, string>
{
    /// <summary>
    ///     A1 - two chars number
    /// </summary>
    /// <param name="b"></param>
    public static AppLang ConvertTo(string b)
    {
        return new AppLang(byte.Parse(b[0].ToString()), byte.Parse(b[1].ToString()));
    }

    public static string ConvertFrom(AppLang t)
    {
        return t.Type + t.Language.ToString();
    }
}