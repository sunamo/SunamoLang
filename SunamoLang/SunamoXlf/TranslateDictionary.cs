namespace SunamoLang.SunamoXlf;

public class TranslateDictionary : IDictionary<string, string>
{
    public static string? BasePathSolution { get; set; } = null;
    public static Func<string, LocalizationLanguages, string>? ReloadIfKeyWontBeFound { get; set; }
    public static bool ReturnXlfKey { get; set; } = false;
    public static LocalizationLanguages? LocalizationLanguages { get; set; } = null;
    private readonly Dictionary<string, string> dictionary = new();
    private readonly Langs language = Langs.en;

    public TranslateDictionary(Langs language)
    {
        this.language = language;
    }

    public static Action<string>? ShowMb
    {
        get => throw new Exception("This functionality is deprecated and not properly implemented.");
        set => throw new Exception("This functionality is deprecated and not properly implemented.");
    }

    public string this[string key]
    {
        get
        {
            if (ReturnXlfKey) return key;

            if (!dictionary.ContainsKey(key))
            {
                if (ReloadIfKeyWontBeFound == null) return ThrowNotFoundError(key, "ReloadIfKeyWontBeFound is null.");
                ReloadIfKeyWontBeFound(key, LocalizationLanguages!);
                if (!dictionary.ContainsKey(key))
                    return ThrowNotFoundError(key, string.Empty);
            }

            var value = dictionary[key];
            return value;
        }
        set => dictionary[key] = value;
    }

    public ICollection<string> Keys => dictionary.Keys;
    public ICollection<string> Values => dictionary.Values;
    public int Count => dictionary.Count;
    public bool IsReadOnly => false;

    public void Add(string key, string value)
    {
        dictionary.Add(key, value);
    }

    public void Add(KeyValuePair<string, string> item)
    {
        dictionary.Add(item.Key, item.Value);
    }

    public void Clear()
    {
        dictionary.Clear();
    }

    public bool Contains(KeyValuePair<string, string> item)
    {
        return dictionary.ContainsKey(item.Key);
    }

    public bool ContainsKey(string key)
    {
        return dictionary.ContainsKey(key);
    }

    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    public bool Remove(string key)
    {
        return dictionary.Remove(key);
    }

    public bool Remove(KeyValuePair<string, string> item)
    {
        return dictionary.Remove(item.Key);
    }

    public bool TryGetValue(string key, out string value)
    {
        return dictionary.TryGetValue(key, out value!);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    private string ThrowNotFoundError(string key, string customError)
    {
        throw new Exception(customError + ". " + key + " is not in " + language + " dictionary");
    }
}
