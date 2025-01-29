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
{}
    #endregion

    #region Only in *Xlf.cs
    #endregion
}