namespace SunamoLang.SunamoXlf;

/// <summary>
/// Helper class for XML Localization Interchange File Format (XLIFF) operations.
/// </summary>
public class XmlLocalisationInterchangeFileFormatXlf
{
    #region Only in *Xlf.cs

    /// <summary>
    /// Extracts the language from an XLF filename.
    /// </summary>
    /// <param name="filename">The filename or full path to the XLF file.</param>
    /// <returns>The language identifier extracted from the filename.</returns>
    public static Langs GetLangFromFilename(string filename)
    {
        filename = Path.GetFileNameWithoutExtension(filename);
        List<string> parts = null;
        if (filename.Contains("_"))
            parts = SHSplit.SplitChar(filename, '_');
        else
            parts = SHSplit.SplitChar(filename, '.', '-');
        var subtractCount = 2;
        if (filename.Contains("min")) subtractCount++;
        var beforeLast = parts[parts.Count - subtractCount].ToLower();
        if (beforeLast.StartsWith("cs")) return Langs.cs;
        return Langs.en;
    }

    #endregion
}