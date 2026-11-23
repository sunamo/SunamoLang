namespace SunamoLang.SunamoI18N;

/// <summary>
/// Represents the translation type.
/// </summary>
public class Translation
{
    /// <summary>
    /// Gets or sets the cs.
    /// </summary>
    public string Cs { get; set; }

    /// <summary>
    /// Gets or sets the en.
    /// </summary>
    public string En { get; set; }

    /// <summary>
    /// Translation.
    /// </summary>
    /// <param name="en">The en.</param>
    /// <param name="cs">The cs.</param>
    /// <returns>The translation result.</returns>
    public Translation(string en, string cs)
    {
        En = en;
        Cs = cs;
    }
}
