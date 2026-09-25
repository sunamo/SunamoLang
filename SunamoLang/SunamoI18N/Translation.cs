namespace SunamoLang.SunamoI18N;

/// <summary>
/// Data class containing Czech text and its corresponding English translation.
/// </summary>
public class Translation
{
    /// <summary>
    /// Gets or sets the Czech text.
    /// </summary>
    public string Cs { get; set; }

    /// <summary>
    /// Gets or sets the English text.
    /// </summary>
    public string En { get; set; }

    /// <summary>
    /// Initializes a new instance of the Translation class.
    /// </summary>
    /// <param name="en">The English text.</param>
    /// <param name="cs">The Czech text.</param>
    public Translation(string en, string cs)
    {
        En = en;
        Cs = cs;
    }
}