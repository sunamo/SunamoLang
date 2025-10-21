// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang;

#region For easy copy

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

#endregion