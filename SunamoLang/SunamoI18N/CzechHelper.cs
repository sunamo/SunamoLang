namespace SunamoLang.SunamoI18N;

/// <summary>
/// Helper class for Czech language text processing and transformations.
/// </summary>
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

    /// <summary>
    /// Replaces characters in HTML content from UTF-8 hex encoding to Czech characters.
    /// </summary>
    /// <param name="input">The input HTML string to process.</param>
    /// <returns>The processed HTML string with Czech characters.</returns>
    public static string ReplaceInHtmlFrom_UTF_8_Hex(string input)
    {
        return ReplaceInHtmlFrom(CzechEncodings.UTF_8, true, input);
    }

    /// <summary>
    /// Replaces characters in HTML content from the specified encoding.
    /// </summary>
    /// <param name="encoding">The Czech encoding to use.</param>
    /// <param name="isHex">Whether the encoding is in hexadecimal format.</param>
    /// <param name="input">The input HTML string to process.</param>
    /// <returns>The processed HTML string.</returns>
    public static string ReplaceInHtmlFrom(CzechEncodings encoding, bool isHex, string input)
    {
        if (encoding == CzechEncodings.UTF_8 && isHex)
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

    /// <summary>
    /// Initializes the encoding conversion tables.
    /// </summary>
    /// <param name="encoding">The Czech encoding to initialize.</param>
    /// <param name="isHex">Whether the encoding is in hexadecimal format.</param>
    public static void Init(CzechEncodings encoding, bool isHex)
    {
        if (encoding == CzechEncodings.UTF_8 && isHex)
        {
            var utf8hexL = SHGetLines.GetLines(utf8hex);
            var czechLettersL = SHGetLines.GetLines(czechLetters);

            ThrowEx.DifferentCountInLists("utf8hexL", utf8hexL, "czechLettersL", czechLettersL);

            CA.Prepend(" ", utf8hexL);

            CA.Replace(utf8hexL, " ", "=");

            for (var i = 0; i < czechLettersL.Count; i++) fromUtf8hex.Add(utf8hexL[i], czechLettersL[i]);
        }
    }

    /// <summary>
    /// Returns the Czech greeting "Dear" in the appropriate gender form.
    /// </summary>
    /// <param name="isFemale">True for female form, false for male form.</param>
    /// <returns>The gendered greeting word.</returns>
    public static string Dear(bool isFemale)
    {
        if (isFemale) return "Mil\u00E1";
        return "Mil\u00FD";
    }

    /// <summary>
    /// Returns the Czech greeting "Esteemed" in the appropriate gender form.
    /// </summary>
    /// <param name="isFemale">True for female form, false for male form.</param>
    /// <returns>The gendered greeting word.</returns>
    public static string Esteemed(bool isFemale)
    {
        if (isFemale) return "Vážená";
        return "Vážený";
    }

    /// <summary>
    /// Creates a formal honorable greeting with name.
    /// </summary>
    /// <param name="isFemale">True for female form, false for male form.</param>
    /// <param name="greetingWord">The greeting word to use (e.g., "Dear", "Esteemed").</param>
    /// <param name="name">The person's name.</param>
    /// <returns>A formatted honorable greeting.</returns>
    public static string Honorable(bool isFemale, string greetingWord, string name)
    {
        string formattedGreeting;

        if (isFemale)
            formattedGreeting = greetingWord + " " + Translate.FromKey(XlfKeys.Madam) + " " + name;
        else
            formattedGreeting = greetingWord + " " + Translate.FromKey(XlfKeys.Sir) + " " + name;

        return char.ToUpper(formattedGreeting[0]) + formattedGreeting.Substring(1);
    }

    /// <summary>
    /// Determines gender from a Czech surname.
    /// </summary>
    /// <param name="surname">The surname to analyze.</param>
    /// <returns>True if the surname indicates female gender, false otherwise.</returns>
    public static bool GetSexFromSurname(string surname)
    {
        if (surname.EndsWith("ova") || surname.EndsWith("á")) return true;
        return false;
    }
}