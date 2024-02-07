
namespace SunamoLang._sunamo;
//namespace SunamoI18N._sunamo;
internal class SHGetLines
{
    //internal static Func<string, List<string>> GetLines;
    internal static List<string> GetLines(string s)
    {
        return s.Split(new String[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
