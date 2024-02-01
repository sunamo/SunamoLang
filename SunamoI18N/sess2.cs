
namespace SunamoLang.SunamoI18N;
using SunamoLang.SunamoXlf;


public static class sess
{
    static Type type = typeof(sess);

    public static string i18n(string key, Langs l = Langs.en)
    {
        // if (Exc.aspnet)
        // {
        //     //ThrowEx.IsNotAllowed("sess.i18n in asp.net due to use global ThisApp.l");
        // }

        switch (l)
        {
            case Langs.cs:
                return RLData.cs[key];
            case Langs.en:
                return RLData.en[key];
            default:
                ThrowEx.NotImplementedCase(l);
                break;
        }
        return null;
    }
}
