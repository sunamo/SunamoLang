
namespace SunamoLang.SunamoI18N;



/// <summary>
/// Tato třída je zde kvůli interoperibilitě s .web apss
/// má 3. parametr string ale ten se nevyužívá
/// </summary>
public class SunamoPageHelper
{
    public static string LocalizedString_String(string l, string key, string ms)
    {
        switch (l)
        {
            case "cs":
                return RLData.cs[key];
                break;
            case "en":
                return RLData.en[key];
                break;
            default:
                ThrowEx.NotImplementedCase(l);
                break;
        }

        return null;
    }
}
