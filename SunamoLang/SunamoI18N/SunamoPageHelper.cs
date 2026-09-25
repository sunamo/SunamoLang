namespace SunamoLang.SunamoI18N;

public class SunamoPageHelper
{
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
