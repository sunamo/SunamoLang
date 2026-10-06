namespace SunamoLang.SunamoXlf;

// Singleton for translated strings used in content templates and similar scenarios.
public class TranslatedStrings
{
    public static TranslatedStrings Instance { get; } = new();
    public Func<string, string>? Get { get; set; } = null;

    private TranslatedStrings()
    {
    }

    public string SetAsDefault { get; set; } = string.Empty;
    public string Delete { get; set; } = string.Empty;

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
