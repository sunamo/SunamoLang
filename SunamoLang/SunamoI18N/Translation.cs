// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang.SunamoI18N;

/// <summary>
///     Datová třída, obsahující pouze český text a jeho odpovídající anglický překlad
/// </summary>
public class Translation
{
    public string Cs;
    public string En;

    public Translation(string en, string cs)
    {
        En = en;
        Cs = cs;
    }
}