using System.Xml.Linq;

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
    public void LoadXml(string content)
    {
        if (string.IsNullOrWhiteSpace(content))
        {
            Files = Array.Empty<XlfFileLang>();
            return;
        }

        var doc = XDocument.Parse(content);
        XNamespace ns = "urn:oasis:names:tc:xliff:document:1.2";

        var files = new List<XlfFileLang>();
        foreach (var fileEl in doc.Descendants(ns + "file"))
        {
            var original = (string?)fileEl.Attribute("original") ?? string.Empty;
            var units = new List<XlfTransUnitLang>();
            foreach (var tu in fileEl.Descendants(ns + "trans-unit"))
            {
                var id = (string?)tu.Attribute("id") ?? string.Empty;
                var target = (string?)tu.Element(ns + "target") ?? string.Empty;
                if (!string.IsNullOrEmpty(id))
                    units.Add(new XlfTransUnitLang { Id = id, Target = target });
            }
            files.Add(new XlfFileLang { Original = original, TransUnits = units });
        }
        Files = files;
    }
}
