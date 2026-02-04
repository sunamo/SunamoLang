namespace SunamoLang._sunamo;

/// <summary>
/// Collection array helper methods for string list operations.
/// </summary>
internal class CA
{
    /// <summary>
    /// Trims whitespace from all strings in the list.
    /// </summary>
    /// <param name="list">The list of strings to trim.</param>
    /// <returns>The trimmed list.</returns>
    internal static List<string> Trim(List<string> list)
    {
        for (var i = 0; i < list.Count; i++) list[i] = list[i].Trim();
        return list;
    }

    /// <summary>
    /// Prepends a string to each element in the list if not already present.
    /// </summary>
    /// <param name="prefix">The prefix to prepend.</param>
    /// <param name="list">The list to modify.</param>
    /// <returns>The modified list.</returns>
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
    internal static string Replace(string text, string oldValue, string newValue)
    {
        return text.Replace(oldValue, newValue);
    }

    /// <summary>
    /// Replaces all occurrences of a substring in all strings in a list.
    /// </summary>
    /// <param name="list">The list of strings to modify.</param>
    /// <param name="oldValue">The substring to replace.</param>
    /// <param name="newValue">The replacement substring.</param>
    internal static void Replace(List<string> list, string oldValue, string newValue)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i] = Replace(list[i], oldValue, newValue);
        }
    }
}