
namespace SunamoLang;
//namespace SunamoI18N;
public class SHGetLines
{
    //public static Func<string, List<string>> GetLines;
    public static List<string> GetLines(string v)
    {
        return v.Split(new string[] { v.Contains("\r\n") ? "\r\n" : "\n" }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
}
