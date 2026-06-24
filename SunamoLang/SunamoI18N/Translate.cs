namespace SunamoLang.SunamoI18N;

public class Translate
{
    public static string FromKey(string key)
    {
        switch (key)
        {
            case XlfKeys.IsNotInWindowsPathFormat:
                return "is not in Windows Path format";
            case XlfKeys.NotImplementedCasePublicProgramErrorPleaseContactDeveloper:
                return "Not implemented case. public program error. Please contact developer";
            case XlfKeys.DifferentCountElementsInCollection:
                return "Different count elements in collection";
            default:
                ThrowEx.NotImplementedCase(key);
                return null!;
        }
    }
}
