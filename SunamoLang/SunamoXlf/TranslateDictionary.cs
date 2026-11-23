namespace SunamoLang.SunamoXlf;

/// <summary>
/// Represents the translate dictionary type.
/// </summary>
public class TranslateDictionary : IDictionary<string, string>
{
    /// <summary>
    /// Gets or sets the base path solution.
    /// </summary>
    public static string? BasePathSolution { get; set; } = null;
    /// <summary>
    /// Gets or sets the reload if key wont be found.
    /// </summary>
    public static Func<string, LocalizationLanguages, string>? ReloadIfKeyWontBeFound { get; set; }
    /// <summary>
    /// Gets or sets the return xlf key.
    /// </summary>
    public static bool ReturnXlfKey { get; set; } = false;
    /// <summary>
    /// Gets or sets the localization languages.
    /// </summary>
    public static LocalizationLanguages? LocalizationLanguages { get; set; } = null;
    private readonly Dictionary<string, string> dictionary = new();
    private readonly Langs language = Langs.en;

    /// <summary>
    /// Translate dictionary.
    /// </summary>
    /// <returns>The translate dictionary result.</returns>
    public TranslateDictionary(Langs language)
    {
        this.language = language;
    }

    /// <summary>
    /// The show mb.
    /// </summary>
    public static Action<string>? ShowMb
    {
        get => throw new Exception("This functionality is deprecated and not properly implemented.");
        set => throw new Exception("This functionality is deprecated and not properly implemented.");
    }

    /// <summary>
    /// The this string.
    /// </summary>
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

    /// <summary>
    /// Gets the keys.
    /// </summary>
    public ICollection<string> Keys => dictionary.Keys;
    /// <summary>
    /// Gets the values.
    /// </summary>
    public ICollection<string> Values => dictionary.Values;
    /// <summary>
    /// Gets the count.
    /// </summary>
    public int Count => dictionary.Count;
    /// <summary>
    /// Gets the is read only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="ReloadIfKeyWontBeFound">The reload if key wont be found.</param>
    /// <returns>The add result.</returns>
    public void Add(string key, string value)
    {
        dictionary.Add(key, value);
    }

    /// <summary>
    /// Add.
    /// </summary>
    /// <param name="item">The item.</param>
    public void Add(KeyValuePair<string, string> item)
    {
        dictionary.Add(item.Key, item.Value);
    }

    /// <summary>
    /// Clear.
    /// </summary>
    public void Clear()
    {
        dictionary.Clear();
    }

    /// <summary>
    /// Contains.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The contains result.</returns>
    public bool Contains(KeyValuePair<string, string> item)
    {
        return dictionary.ContainsKey(item.Key);
    }

    /// <summary>
    /// Contains key.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The contains key result.</returns>
    public bool ContainsKey(string key)
    {
        return dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Copy to.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    /// <returns>The copy to result.</returns>
    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Get enumerator.
    /// </summary>
    /// <param name="key">The key.</param>
    /// <param name="value">The value.</param>
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    /// <summary>
    /// Remove.
    /// </summary>
    /// <param name="item">The item.</param>
    public bool Remove(string key)
    {
        return dictionary.Remove(key);
    }

    /// <summary>
    /// Remove.
    /// </summary>
    public bool Remove(KeyValuePair<string, string> item)
    {
        return dictionary.Remove(item.Key);
    }

    /// <summary>
    /// Try get value.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <returns>The try get value result.</returns>
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
