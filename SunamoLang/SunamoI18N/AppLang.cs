// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoI18N;

public class AppLang
{
    /// <summary>
    ///     Je zde výkon na 1. místě, proto tato třída nemá žádnou metodu Parse a žádný bezparametrový konstruktor.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="language"></param>
    public AppLang(byte type, byte language)
    {
        Type = type;
        Language = language;
    }

    public byte Language { get; }

    public byte Type { get; }

    public override string ToString()
    {
        return AppLangHelper.ToString(this);
    }
}