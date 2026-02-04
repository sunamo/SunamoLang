namespace SunamoLang.SunamoXlf;

/// <summary>
/// Collection array helper for XLF (XLIFF localization files) operations.
/// </summary>
public class CAXlf
{
    #region Only in *Xlf.cs

    /// <summary>
    /// Converts an array of items to a List.
    /// </summary>
    /// <typeparam name="T">The type of items in the array.</typeparam>
    /// <param name="items">The array of items to convert.</param>
    /// <returns>A List containing the items from the array.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return new List<T>(items);
    }

    #endregion
}