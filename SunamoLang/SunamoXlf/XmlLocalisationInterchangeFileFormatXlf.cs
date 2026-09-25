namespace SunamoLang.SunamoXlf;

public class XmlLocalisationInterchangeFileFormatXlf
{
    #region Only in *Xlf.cs

    public static Langs GetLangFromFilename(string filename)
    {
        filename = Path.GetFileNameWithoutExtension(filename);
        List<string>? parts = null;
        if (filename.Contains("_"))
            parts = SHSplit.SplitChar(filename, '_');
        else
            parts = SHSplit.SplitChar(filename, '.', '-');
        var subtractCount = 2;
        if (filename.Contains("min")) subtractCount++;
        var languageCodePart = parts[parts.Count - subtractCount].ToLower();
        if (languageCodePart.StartsWith("cs")) return Langs.cs;
        return Langs.en;
    }

    #endregion
}
