namespace SunamoLang.SunamoXlf;

// Singleton for translated strings used in content templates and similar scenarios.
/// <summary>
/// Represents the translated strings type.
/// </summary>
public class TranslatedStrings
{
    /// <summary>
    /// Gets the instance.
    /// </summary>
    public static TranslatedStrings Instance { get; } = new();
    /// <summary>
    /// Gets or sets the get.
    /// </summary>
    public Func<string, string>? Get { get; set; } = null;

    private TranslatedStrings()
    {
    }

    /// <summary>
    /// Gets or sets the set as default.
    /// </summary>
    public string SetAsDefault { get; set; } = string.Empty;
    /// <summary>
    /// Gets or sets the delete.
    /// </summary>
    public string Delete { get; set; } = string.Empty;

    /// <summary>
    /// Fill if is empty.
    /// </summary>
    /// <param name="propertyName">The property name.</param>
    public void FillIfIsEmpty(string propertyName)
    {
        var propertyType = typeof(TranslatedStrings);
        var value = RH.GetValueOfProperty(propertyName, propertyType, Instance, false);

        if (value?.ToString() == string.Empty)
        {
            var translation = Get!(propertyName);
            RH.SetValueOfProperty(propertyName, propertyType, Instance, false, translation);
        }
    }
}
