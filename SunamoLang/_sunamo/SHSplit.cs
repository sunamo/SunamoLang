namespace SunamoLang._sunamo;

/// <summary>
/// String helper for splitting operations.
/// </summary>
internal class SHSplit
{
    /// <summary>
    /// Splits a string by character delimiters.
    /// </summary>
    /// <param name="text">The text to split.</param>
    /// <param name="delimiters">The character delimiters.</param>
    /// <returns>A list of split strings.</returns>
    internal static List<string> SplitChar(string text, params char[] delimiters)
    {
        return Split(StringSplitOptions.RemoveEmptyEntries, text,
            delimiters.ToList().ConvertAll(delimiter => delimiter.ToString()).ToArray());
    }

    /// <summary>
    /// Splits a string by string delimiters with options.
    /// </summary>
    /// <param name="stringSplitOptions">The split options.</param>
    /// <param name="text">The text to split.</param>
    /// <param name="delimiters">The string delimiters.</param>
    /// <returns>A list of split strings.</returns>
    internal static List<string> Split(StringSplitOptions stringSplitOptions, string text, params string[] delimiters)
    {
        if (delimiters == null || delimiters.Count() == 0) throw new Exception("NoDelimiterDetermined");
        var result = text.Split(delimiters, stringSplitOptions).ToList();
        CA.Trim(result);
        if (stringSplitOptions == StringSplitOptions.RemoveEmptyEntries)
            result = result.Where(delimiter => delimiter.Trim() != string.Empty).ToList();

        return result;
    }
}