namespace SunamoLang._sunamo;

internal class CA
{
    internal static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();
        return list;
    }

    internal static List<string> Prepend(string prefix, List<string> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].StartsWith(prefix))
            {
                list[i] = prefix + list[i];
            }
        }
        return list;
    }

    /// <summary>
    /// Replaces all occurrences of a substring in a string.
    /// </summary>
    /// <param name="text">The text to search.</param>
    /// <param name="oldValue">The substring to replace.</param>
    /// <param name="newValue">The replacement substring.</param>
    /// <returns>The modified string.</returns>
    internal static string Replace(string text, string oldValue, string newValue) =>
        text.Replace(oldValue, newValue);

    internal static void Replace(List<string> list, string oldValue, string newValue)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = Replace(list[i], oldValue, newValue);
        }
    }
}
