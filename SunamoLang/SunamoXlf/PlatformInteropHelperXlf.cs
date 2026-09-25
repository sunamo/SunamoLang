namespace SunamoLang.SunamoXlf;

/// <summary>
/// Platform interoperability helper for XLF operations.
/// </summary>
public class PlatformInteropHelperXlf
{
    #region For easy copy

    /// <summary>
    /// Determines whether the application is a selling app by checking for SellingHelper class existence.
    /// </summary>
    /// <returns>True if the app is a selling app, false otherwise.</returns>
    public static bool IsSellingApp()
    {
        return RH.ExistsClass("SellingHelper");
    }

    #endregion
}