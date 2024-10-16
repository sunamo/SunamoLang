namespace SunamoLang._sunamo;
/// <summary>
///
/// </summary>
internal class TF
{
    #region For easy copy
    internal static List<byte> bomUtf8 = new List<byte> { 239, 187, 191 };

    internal static
#if ASYNC
    async Task
#else
void
#endif
RemoveDoubleBomUtf8(string path)
    {
        var b = (
#if ASYNC
    await
#endif
File.ReadAllBytesAsync(path)).ToList();
        var to = b.Count > 5 ? 6 : b.Count;

        for (int i = 3; i < to; i++)
        {
            if (bomUtf8[i - 3] != b[i])
            {
                break;
            }
        }

        b = b.Skip(3).ToList();
        WriteAllBytes(path, b);
    }


    #endregion

    #region Only in *Xlf.cs
    internal static void WriteAllBytes(string file, List<byte> b)
    {
        File.WriteAllBytes(file, b.ToArray());
    }
    #endregion
}