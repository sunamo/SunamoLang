namespace SunamoLang.SunamoXlf;

/// <summary>
/// Resource localization data storage.
/// Separates RL and RLData to avoid intellisense conflicts.
/// </summary>
public static class RLData
{
    /// <summary>
    /// English translation dictionary.
    /// </summary>
    public static TranslateDictionary En { get; } = new(Langs.en);

    /// <summary>
    /// Czech translation dictionary.
    /// </summary>
    public static TranslateDictionary Cs { get; } = new(Langs.cs);
}