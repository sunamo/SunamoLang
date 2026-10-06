namespace SunamoLang.SunamoI18N.Converts;

public static class AppLangConverter
{
    public static AppLang ConvertTo(string text)
    {
        return new AppLang(byte.Parse(text[0].ToString()), byte.Parse(text[1].ToString()));
    }

    public static string ConvertFrom(AppLang appLang)
    {
        return appLang.Type + appLang.Language.ToString();
    }
}
