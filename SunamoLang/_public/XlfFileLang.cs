namespace SunamoLang._public;

public class XlfFileLang
{
    public string Original { get; set; } = string.Empty;

    public IEnumerable<XlfTransUnitLang> TransUnits { get; set; } = Array.Empty<XlfTransUnitLang>();
}
