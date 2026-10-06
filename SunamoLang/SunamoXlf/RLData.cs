namespace SunamoLang.SunamoXlf;

// Separates RL and RLData to avoid intellisense conflicts.
public static class RLData
{
    public static TranslateDictionary En { get; } = new(Langs.en);
    public static TranslateDictionary Cs { get; } = new(Langs.cs);
}
