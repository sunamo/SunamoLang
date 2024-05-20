
namespace SunamoLang;
//namespace SunamoI18N;
internal class SHGetLines
{
    //internal static Func<string, List<string>> GetLines;
    internal static List<string> GetLines(string v)
    {
        return v.Split(new string[] { v.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
