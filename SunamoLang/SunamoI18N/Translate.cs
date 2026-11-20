namespace SunamoLang.SunamoI18N;

public class Translate
{
    public static string FromKey(string key)
    {
        switch (key)
        {
            case "Is not in windows path format":
                return "is not in Windows Path format";
            case "Not implemented case public program error please contact developer":
                return "Not implemented case. public program error. Please contact developer";
            case "Different count elements in collection":
                return "Different count elements in collection";
            default:
                ThrowEx.NotImplementedCase(key);
                return null!;
        }
    }
}
