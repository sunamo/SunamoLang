namespace SunamoLang._sunamo;

internal class SHSplit
{
    internal static List<string> SplitChar(string text, params char[] delimiters) =>
        Split(StringSplitOptions.RemoveEmptyEntries, text,
            delimiters.ToList().ConvertAll(delimiter => delimiter.ToString()).ToArray());

    internal static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] delimiters)
    {
        if (delimiters == null || delimiters.Count() == 0) throw new Exception("NoDelimiterDetermined");
        var result = text.Split(delimiters, stringSplitOptions).ToList();
        CA.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
            result = result.Where(entry => entry.Trim() != string.Empty).ToList();

        return result;
    }
}
