// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoXlf;

/// <summary>
///     Is here dont mix RL and RLData with intellisense
/// </summary>
public static class RLData
{
    private static Type type = typeof(RLData);

    // In case of serious problem I can use TranslateDictionary
    public static TranslateDictionary en = new(Langs.en);
    public static TranslateDictionary cs = new(Langs.cs);
}