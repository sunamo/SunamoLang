
namespace SunamoLang;
//namespace SunamoI18N._sunamo;
internal class SHGetLines
{
    //internal static Func<string, List<string>> GetLines;
    internal static List<string> GetLines(string s)
    {
        return sv.Split(new string[] { v.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
