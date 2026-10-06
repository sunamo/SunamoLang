namespace SunamoLang.SunamoI18N;

// Performance is prioritized, so this class has no Parse method and no parameterless constructor.
public class AppLang
{
    public AppLang(byte type, byte language)
    {
        Type = type;
        Language = language;
    }

    public byte Language { get; }

    public byte Type { get; }

    /// <summary>
    /// Returns a string representation of this AppLang instance.
    /// </summary>
    /// <returns>String representation of the instance.</returns>
    public override string ToString() => AppLangHelper.ToString(this);
}