// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
namespace SunamoLang._public;

public class XlfDocumentLang
{
    public IEnumerable<XlfFileLang> Files;

#pragma warning disable
    public void LoadXml(string content)
    {
        ThrowEx.NotImplementedMethod();
    }
#pragma warning enable
}