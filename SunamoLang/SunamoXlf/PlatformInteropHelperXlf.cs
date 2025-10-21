// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoXlf;

public class PlatformInteropHelperXlf
{
    #region For easy copy

    public static bool IsSellingApp()
    {
        return RH.ExistsClass("SellingHelper");
    }

    #endregion
}