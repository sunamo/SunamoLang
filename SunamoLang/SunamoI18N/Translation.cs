namespace SunamoLang.SunamoI18N;

public class Translation
{
    public string Cs { get; set; }

    public string En { get; set; }

    public Translation(string en, string cs)
    {
        En = en;
        Cs = cs;
    }
}
