namespace SunamoLang.SunamoXlf;

/// <summary>
///     For using in content template etc
/// </summary>
public class TranslatedStrings
{
    public static TranslatedStrings Instance = new();
    private static readonly Type type = typeof(TranslatedStrings);

    public Func<string, string> get = null;

    private TranslatedStrings()
    {
    }

    public string SetAsDefault { get; set; } = string.Empty;

    public string Delete { get; set; } = string.Empty;

    public void FillIfIsEmpty(string k)
    {
        var v = RH.GetValueOfProperty(k, type, Instance, false);

        if (v.ToString() == string.Empty)
        {
            var tr = get(k);
            RH.SetValueOfProperty(k, type, Instance, false, tr);
            //v = RH.GetValueOfProperty(k, type, Instance, false);
        }
    }
}