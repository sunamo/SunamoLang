namespace SunamoLang.SunamoXlf;

// Separates RL and RLData to avoid intellisense conflicts.
/// <summary>
/// Represents the RL data type.
/// </summary>
public static class RLData
{
    /// <summary>
    /// Gets the en.
    /// </summary>
    public static TranslateDictionary En { get; } = new(Langs.en);
    /// <summary>
    /// Gets the cs.
    /// </summary>
    public static TranslateDictionary Cs { get; } = new(Langs.cs);
}
