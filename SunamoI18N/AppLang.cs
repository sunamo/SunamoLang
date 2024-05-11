namespace SunamoLang;

public class AppLang
{
    private byte _language = 0;
    private byte _type = 0;

    public byte Language
    {
        get
        {
            return _language;
        }
    }

    public byte Type
    {
        get
        {
            return _type;
        }
    }


    /// <summary>
    /// Je zde výkon na 1. místě, proto tato třída nemá žádnou metodu Parse a žádný bezparametrový konstruktor.
    /// </summary>
    /// <param name="type"></param>
    /// <param name="language"></param>
    public AppLang(byte type, byte language)
    {
        _type = type;
        _language = language;
    }

    public override string ToString()
    {
        return AppLangHelper.ToString(this);
    }
}
