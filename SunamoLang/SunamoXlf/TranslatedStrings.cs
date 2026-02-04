namespace SunamoLang.SunamoXlf;

/// <summary>
/// Singleton for translated strings used in content templates and similar scenarios.
/// </summary>
public class TranslatedStrings
{
    /// <summary>
    /// Gets the singleton instance of TranslatedStrings.
    /// </summary>
    public static TranslatedStrings Instance { get; } = new();

    /// <summary>
    /// Gets or sets the function to retrieve a translated string by property name.
    /// </summary>
    public Func<string, string>? Get { get; set; } = null;

    private TranslatedStrings()
    {
    }

    /// <summary>
    /// Gets or sets the translated "Set as Default" string.
    /// </summary>
    public string SetAsDefault { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the translated "Delete" string.
    /// </summary>
    public string Delete { get; set; } = string.Empty;

    /// <summary>
    /// Fills the property if it is empty.
    /// </summary>
    /// <param name="propertyName">The property name to fill.</param>
    public void FillIfIsEmpty(string propertyName)
    {
        var propertyType = typeof(TranslatedStrings);
        var value = RH.GetValueOfProperty(propertyName, propertyType, Instance, false);

        if (value.ToString() == string.Empty)
        {
            var translation = Get(propertyName);
            RH.SetValueOfProperty(propertyName, propertyType, Instance, false, translation);
        }
    }
}