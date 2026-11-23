namespace SunamoLang.SunamoXlf;

/// <summary>
/// Represents the platform interop helper xlf type.
/// </summary>
public class PlatformInteropHelperXlf
{
    #region For easy copy

    /// <summary>
    /// Is selling app.
    /// </summary>
    /// <returns>The is selling app result.</returns>
    public static bool IsSellingApp()
    {
        return RH.ExistsClass("SellingHelper");
    }

    #endregion
}
