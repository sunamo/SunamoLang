namespace SunamoLang.SunamoXlf;

public class XmlLocalisationInterchangeFileFormatXlf
{
    #region Only in *Xlf.cs

    /// <summary>
    ///     A1 can be full path
    /// </summary>
    /// <param name="s"></param>
    public static Langs GetLangFromFilename(string s)
    {
        s = Path.GetFileNameWithoutExtension(s);
        List<string> parts = null;
        if (s.Contains("_"))
            parts = SHSplit.SplitChar(s, '_');
        else
            parts = SHSplit.SplitChar(s, '.', '-');
        var sub = 2;
        if (s.Contains("min")) sub++;
        var beforeLast = parts[parts.Count - sub].ToLower();
        if (beforeLast.StartsWith("cs")) return Langs.cs;
        return Langs.en;
    }

    #endregion
}