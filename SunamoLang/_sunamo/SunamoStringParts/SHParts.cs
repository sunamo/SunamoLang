namespace SunamoLang._sunamo.SunamoStringParts;

/// <summary>
/// String helper for partial string operations (keep/remove parts).
/// </summary>
internal class SHParts
{
    /// <summary>
    /// Function to keep text after first occurrence of a substring.
    /// </summary>
    internal static Func<string, string, bool, string>? KeepAfterFirst = null;

    /// <summary>
    /// Function to remove text after first occurrence of a substring.
    /// </summary>
    internal static Func<string, string, string>? RemoveAfterFirst = null;
}