namespace SunamoLang.SunamoXlf;

public class PlatformInteropHelperXlf
{
    #region For easy copy
    public static bool IsSellingApp()
    {
        return RHSunExcXlf.ExistsClass("SellingHelper");
    }
    #endregion
}
