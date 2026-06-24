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

    public override string ToString() => AppLangHelper.ToString(this);
}
