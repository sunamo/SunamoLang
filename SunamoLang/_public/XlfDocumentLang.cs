namespace SunamoLang._public;

/// <summary>
/// Represents an XLF (XLIFF) document for language localization.
/// </summary>
public class XlfDocumentLang
{
    /// <summary>
    /// Gets or sets the collection of XLF files in this document.
    /// </summary>
    public IEnumerable<XlfFileLang> Files { get; set; } = Array.Empty<XlfFileLang>();

    /// <summary>
    /// Loads XML content into the document.
    /// </summary>
    /// <param name="content">The XML content to load.</param>
#pragma warning disable
    public void LoadXml(string content)
    {
        ThrowEx.NotImplementedMethod();
    }
#pragma warning enable
}