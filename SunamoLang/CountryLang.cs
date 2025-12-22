namespace SunamoLang;

public class CountryLang
{
    public static Dictionary<Langs, string> d = new();

    static CountryLang()
    {
        Init();
    }

    public static void Init()
    {
        d.Add(Langs.en, "GB");
        d.Add(Langs.cs, "CZ");
    }
}
