namespace SunamoLang.SunamoI18N;

/// <summary>
/// Provides translation functionality for localized keys.
/// </summary>
public class Translate
{
    /// <summary>
    /// Translates a localization key to its corresponding text.
    /// </summary>
    /// <param name="key">The localization key to translate.</param>
    /// <returns>The translated text corresponding to the key.</returns>
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
                return null;
        }
    }
}