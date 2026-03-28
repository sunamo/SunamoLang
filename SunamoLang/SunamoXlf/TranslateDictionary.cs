namespace SunamoLang.SunamoXlf;

/// <summary>
/// Dictionary for translation key-value pairs with automatic reloading capability.
/// </summary>
public class TranslateDictionary : IDictionary<string, string>
{
    /// <summary>
    /// Gets or sets the base path to the solution folder.
    /// </summary>
    public static string? BasePathSolution { get; set; } = null;

    /// <summary>
    /// Gets or sets the function to reload translations when a key is not found.
    /// </summary>
    public static Func<string, LocalizationLanguages, string>? ReloadIfKeyWontBeFound { get; set; }

    /// <summary>
    /// Gets or sets whether to return the XLF key itself instead of the translated value.
    /// </summary>
    public static bool ReturnXlfKey { get; set; } = false;

    /// <summary>
    /// Gets or sets the localization languages configuration.
    /// </summary>
    public static LocalizationLanguages? LocalizationLanguages { get; set; } = null;
    private readonly Dictionary<string, string> dictionary = new();
    private readonly Langs language = Langs.en;

    /// <summary>
    /// Initializes a new instance of the TranslateDictionary class.
    /// </summary>
    /// <param name="language">The language for this dictionary.</param>
    public TranslateDictionary(Langs language)
    {
        this.language = language;
    }

    /// <summary>
    /// Gets or sets the message box display action.
    /// </summary>
    public static Action<string>? ShowMb
    {
        get => throw new Exception("This functionality is deprecated and not properly implemented.");
        set => throw new Exception("This functionality is deprecated and not properly implemented.");
    }

    /// <summary>
    /// Gets or sets the translation for the specified key.
    /// </summary>
    /// <param name="key">The translation key.</param>
    /// <returns>The translated string.</returns>
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
    /// Gets the collection of keys in the dictionary.
    /// </summary>
    public ICollection<string> Keys => dictionary.Keys;

    /// <summary>
    /// Gets the collection of values in the dictionary.
    /// </summary>
    public ICollection<string> Values => dictionary.Values;

    /// <summary>
    /// Gets the number of key-value pairs in the dictionary.
    /// </summary>
    public int Count => dictionary.Count;

    /// <summary>
    /// Gets a value indicating whether the dictionary is read-only.
    /// </summary>
    public bool IsReadOnly => false;

    /// <summary>
    /// Adds a key-value pair to the dictionary.
    /// </summary>
    /// <param name="key">The translation key.</param>
    /// <param name="value">The translated string.</param>
    public void Add(string key, string value)
    {
        dictionary.Add(key, value);
    }

    /// <summary>
    /// Adds a key-value pair to the dictionary.
    /// </summary>
    /// <param name="item">The key-value pair to add.</param>
    public void Add(KeyValuePair<string, string> item)
    {
        dictionary.Add(item.Key, item.Value);
    }

    /// <summary>
    /// Removes all key-value pairs from the dictionary.
    /// </summary>
    public void Clear()
    {
        dictionary.Clear();
    }

    /// <summary>
    /// Determines whether the dictionary contains a specific key-value pair.
    /// </summary>
    /// <param name="item">The key-value pair to locate.</param>
    /// <returns>True if the dictionary contains the key; otherwise, false.</returns>
    public bool Contains(KeyValuePair<string, string> item)
    {
        return dictionary.ContainsKey(item.Key);
    }

    /// <summary>
    /// Determines whether the dictionary contains the specified key.
    /// </summary>
    /// <param name="key">The key to locate in the dictionary.</param>
    /// <returns>True if the dictionary contains the key; otherwise, false.</returns>
    public bool ContainsKey(string key)
    {
        return dictionary.ContainsKey(key);
    }

    /// <summary>
    /// Copies the elements to an array starting at the specified index.
    /// </summary>
    /// <param name="array">The target array.</param>
    /// <param name="arrayIndex">The starting index.</param>
    public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Returns an enumerator that iterates through the dictionary.
    /// </summary>
    /// <returns>An enumerator for the dictionary.</returns>
    public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
    {
        return dictionary.GetEnumerator();
    }

    /// <summary>
    /// Removes the entry with the specified key from the dictionary.
    /// </summary>
    /// <param name="key">The key of the entry to remove.</param>
    /// <returns>True if the entry was removed; otherwise, false.</returns>
    public bool Remove(string key)
    {
        return dictionary.Remove(key);
    }

    /// <summary>
    /// Removes the specified key-value pair from the dictionary.
    /// </summary>
    /// <param name="item">The key-value pair to remove.</param>
    /// <returns>True if the entry was removed; otherwise, false.</returns>
    public bool Remove(KeyValuePair<string, string> item)
    {
        return dictionary.Remove(item.Key);
    }

    /// <summary>
    /// Gets the value associated with the specified key.
    /// </summary>
    /// <param name="key">The key to locate in the dictionary.</param>
    /// <param name="value">When this method returns, contains the value associated with the key, if found; otherwise, null.</param>
    /// <returns>True if the dictionary contains an entry with the specified key; otherwise, false.</returns>
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