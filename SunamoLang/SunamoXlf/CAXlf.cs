namespace SunamoLang.SunamoXlf;

/// <summary>
/// Represents the CA xlf type.
/// </summary>
public class CAXlf
{
    #region Only in *Xlf.cs

    /// <summary>
    /// To list t.
    /// </summary>
    /// <typeparam name="T">The type T.</typeparam>
    /// <param name="items">The items.</param>
    /// <returns>The to list t result.</returns>
    public static List<T> ToList<T>(params T[] items)
    {
        return new List<T>(items);
    }

    #endregion
}
