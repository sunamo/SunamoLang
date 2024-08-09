namespace SunamoLang.SunamoI18N;

public class CzechHelper
{
    private const string utf8hex = @"C3 81
C3 84
C4 8C
C4 8E
C3 89
C4 9A
C3 8D
C4 B9
C4 BD
C5 87
C3 93
C3 94
C3 96
C5 94
C5 98
C5 A0
C5 A4
C3 9A
C5 AE
C3 9C
C3 9D
C5 BD
C3 A1
C3 A4
C4 8D
C4 8F
C3 A9
C4 9B
C3 AD
C4 BA
C4 BE
C5 88
C3 B3
C3 B4
C3 B6
C5 95
C5 99
C5 A1
C5 A5
C3 BA
C5 AF
C3 BC
C3 BD
C5 BE";

    private const string czechLetters = @"Á
Ä
Č
Ď
É
Ě
Í
Ĺ
Ľ
Ň
Ó
Ô
Ö
Ŕ
Ř
Š
Ť
Ú
Ů
Ü
Ý
Ž
á
ä
č
ď
é
ě
í
ĺ
ľ
ň
ó
ô
ö
ŕ
ř
š
ť
ú
ů
ü
ý
ž";

    private static readonly Dictionary<string, string> fromUtf8hex = new();

    private static Type type = typeof(CzechHelper);

    public static string ReplaceInHtmlFrom_UTF_8_Hex(string input)
    {
        return ReplaceInHtmlFrom(CzechEncodings.UTF_8, true, input);
    }

    public static string ReplaceInHtmlFrom(CzechEncodings s, bool hex, string input)
    {
        if (s == CzechEncodings.UTF_8 && hex)
        {
            if (fromUtf8hex.Count == 0) Init(CzechEncodings.UTF_8, true);

            foreach (var item in fromUtf8hex) input = input.Replace(item.Key, item.Value);
        }

        input = SHParts.KeepAfterFirst(input, "<!DOCTYPE html>", true);
        input = SHParts.RemoveAfterFirst(input, "</html");

        input = input.Replace("3D\"", "=\"");

        //input = input.Replace("=3D", "=");
        input = input.Replace("\n", "");
        input = input.Replace("\r", "");
        input = input.Replace("\n", "");
        input = input.Replace("</= ", "</");
        input = input.Replace("</ ", "</");
        input = input.Replace("data=-", "data=");
        input = input.Replace(":=", ":");
        input = input.Replace("==", "=");

        // tohle můžu až na konci
        input = input.Replace("=", ";3D");
        input = input.Replace("=", "");
        input = input.Replace(";3D", "=");

        input = input.Replace("=\"", ";\"");
        input = input.Replace("=", "");
        // zde je chyba. nahrazuje to správně ale =\" se mi vloží i na konce hodnoty atributů.
        input = input.Replace(";\"", "=\"");

        return input;
    }


    public static void Init(CzechEncodings s, bool hex)
    {
        if (s == CzechEncodings.UTF_8 && hex)
        {
            var utf8hexL = SHGetLines.GetLines(utf8hex);
            var czechLettersL = SHGetLines.GetLines(czechLetters);

            ThrowEx.DifferentCountInLists("utf8hexL", utf8hexL, "czechLettersL", czechLettersL);

            CA.Prepend(" ", utf8hexL);

            CA.Replace(utf8hexL, " ", "=");

            for (var i = 0; i < czechLettersL.Count; i++) fromUtf8hex.Add(utf8hexL[i], czechLettersL[i]);
        }
    }

    public static string Dear(bool sex)
    {
        if (sex) return "Mil\u00E1";
        return "Mil\u00FD";
    }

    //
    public static string Esteemed(bool sex)
    {
        if (sex) return "Vážená";
        return "Vážený";
    }

    public static string Honorable(bool sex, string dear, string name)
    {
        string f = null;

        #region MyRegion

        //if (ThisApp.l == Langs.en)
        //{
        //    f = sess.i18n(XlfKeys.Dear);
        //}
        //else if(ThisApp.l == Langs.cs)
        //{
        //    f =
        //}
        //else
        //{
        //    ThrowEx.NotImplementedCase(ThisApp.l);
        //}

        //f += AllStrings.space;

        #endregion

        if (sex)
            // its auto with dear
            f = dear + AllStrings.space + sess.i18n(XlfKeys.madam) + " " + name;
        else
            f = dear + AllStrings.space + sess.i18n(XlfKeys.sir) + " " + name;

        return char.ToUpper(f[0]) + f.Substring(1);
    }

    public static bool GetSexFromSurname(string name)
    {
        // ová = á
        if (name.EndsWith("ova") || name.EndsWith("á")) return true;
        return false;
    }
}