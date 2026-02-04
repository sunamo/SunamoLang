namespace SunamoLang._sunamo.SunamoStringGetLines;

internal class SHGetLines
{
    internal static List<string> GetLines(string text)
    {
        var parts = text.Split(new[] { "\r\n", "\n\r" }, StringSplitOptions.None).ToList();
        SplitByUnixNewline(parts);
        return parts;
    }

    private static void SplitByUnixNewline(List<string> lines)
    {
        SplitBy(lines, "\r");
        SplitBy(lines, "\n");
    }

    private static void SplitBy(List<string> lines, string separator)
    {
        for (var index = lines.Count - 1; index >= 0; index--)
        {
            if (separator == "\r")
            {
                var windowsNewlines = lines[index].Split(new[] { "\r\n" }, StringSplitOptions.None);
                var reverseNewlines = lines[index].Split(new[] { "\n\r" }, StringSplitOptions.None);

                if (windowsNewlines.Length > 1)
                    ThrowEx.Custom("cannot contain any \r\name, pass already split by this pattern");
                else if (reverseNewlines.Length > 1) ThrowEx.Custom("cannot contain any \n\r, pass already split by this pattern");
            }

            var parts = lines[index].Split(new[] { separator }, StringSplitOptions.None);

            if (parts.Length > 1) InsertOnIndex(lines, parts.ToList(), index);
        }
    }

    private static void InsertOnIndex(List<string> lines, List<string> parts, int index)
    {
        parts.Reverse();

        lines.RemoveAt(index);

        foreach (var item in parts) lines.Insert(index, item);
    }
}