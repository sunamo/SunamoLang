namespace SunamoLang._public;

/// <summary>
/// Represents a single file entry in an XLF document.
/// </summary>
public class XlfFileLang
{
    /// <summary>
    /// Gets or sets the original file path.
    /// </summary>
    public string Original { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of translation units.
    /// </summary>
    public IEnumerable<XlfTransUnitLang> TransUnits { get; set; } = Array.Empty<XlfTransUnitLang>();
}