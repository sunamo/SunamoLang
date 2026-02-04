namespace SunamoLang._public;

/// <summary>
/// Represents a translation unit in an XLF file.
/// </summary>
public class XlfTransUnitLang
{
    /// <summary>
    /// Gets the unique identifier for this translation unit.
    /// </summary>
    internal string Id { get; init; } = string.Empty;

    /// <summary>
    /// Gets or sets the target translation text.
    /// </summary>
    internal string Target { get; set; } = string.Empty;
}