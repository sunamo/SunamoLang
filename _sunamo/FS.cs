namespace SunamoLang._sunamo;

//namespace SunamoLang._sunamo.SunamoExceptions._AddedToAllCsproj;
internal class FS
{
    #region For easy shared
    public static string GetFullPath(string vr)
    {
        var result = Path.GetFullPath(vr);
        return result;
    }

    public static void FileToDirectory(ref string dir)
    {
        if (!dir.EndsWith(AllStrings.bs))
        {
            dir = Path.GetDirectoryName(dir);
        }
    }

    #endregion

    internal static void CreateUpfoldersPsysicallyUnlessThere(string nad)
    {
        CreateFoldersPsysicallyUnlessThere(Path.GetDirectoryName(nad));
    }
    internal static void CreateFoldersPsysicallyUnlessThere(string nad)
    {
        ThrowEx.IsNullOrEmpty("nad", nad);
        //ThrowEx.IsNotWindowsPathFormat("nad", nad);
        if (Directory.Exists(nad))
        {
            return;
        }
        List<string> slozkyKVytvoreni = new List<string>
{
nad
};
        while (true)
        {
            nad = Path.GetDirectoryName(nad);

            if (Directory.Exists(nad))
            {
                break;
            }
            string kopia = nad;
            slozkyKVytvoreni.Add(kopia);
        }
        slozkyKVytvoreni.Reverse();
        foreach (string item in slozkyKVytvoreni)
        {
            string folder = item;
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }
    }
}