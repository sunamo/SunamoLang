namespace SunamoLang.SunamoI18N;

/// <summary>
/// Represents application language settings with type and language identifiers.
/// Performance is prioritized, so this class has no Parse method and no parameterless constructor.
/// </summary>
public class AppLang
{
    /// <summary>
    /// Initializes a new instance of the AppLang class.
    /// </summary>
    /// <param name="type">The type identifier.</param>
    /// <param name="language">The language identifier.</param>
    public AppLang(byte type, byte language)
    {
        Type = type;
        Language = language;
    }

    /// <summary>
    /// Gets the language identifier.
    /// </summary>
    public byte Language { get; }

    /// <summary>
    /// Gets the type identifier.
    /// </summary>
    public byte Type { get; }

    /// <summary>
    /// Returns a string representation of this AppLang instance.
    /// </summary>
    /// <returns>String representation of the instance.</returns>
    public override string ToString()
    {
        return AppLangHelper.ToString(this);
    }
}