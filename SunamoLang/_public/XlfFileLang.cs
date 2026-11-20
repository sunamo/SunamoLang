namespace SunamoLang._public;

/// <summary>
/// Represents the xlf file lang type.
/// </summary>
public class XlfFileLang
{
    /// <summary>
    /// Gets or sets the original.
    /// </summary>
    public string Original { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the trans units.
    /// </summary>
    public IEnumerable<XlfTransUnitLang> TransUnits { get; set; } = Array.Empty<XlfTransUnitLang>();
}
