namespace SunamoLang.SunamoI18N;

// Performance is prioritized, so this class has no Parse method and no parameterless constructor.
/// <summary>
/// Represents the app lang type.
/// </summary>
public class AppLang
{
    /// <summary>
    /// Initializes a new instance of the app lang class.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="language">The language.</param>
    public AppLang(byte type, byte language)
    {
        Type = type;
        Language = language;
    }

    /// <summary>
    /// Gets the language.
    /// </summary>
    public byte Language { get; }

    /// <summary>
    /// Gets the type.
    /// </summary>
    public byte Type { get; }

    /// <summary>
    /// Returns a string representation of this AppLang instance.
    /// </summary>
    /// <returns>String representation of the instance.</returns>
    public override string ToString() => AppLangHelper.ToString(this);
}