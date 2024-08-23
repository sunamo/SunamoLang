
namespace SunamoLang.SunamoXlf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public partial class DefaultPaths
{
    public const string eVs2 = @"E:\vs2\";
    public const string eVs = @"E:\vs\";
    private static readonly Dictionary<string, bool> exists = new();
    public static string actualPlatform => eVs;

    //public static Platforms platform = Platforms.Mb;

    /// <summary>
    ///     Ended with backslash
    /// </summary>
    public static string sczRootPath = Path.Combine(eVs, @"Projects\sunamo.cz\");

    public const string bpBb = @"D:\Documents\BitBucket\";

    /// <summary>
    ///     For all is here sczRootPath
    ///     edn with bs
    /// </summary>
    public static string sczPath =
        Path.Combine(eVs, @"Projects\sunamo.cz\sunamo.cz\");

    public static string sczOldPath =
        Path.Combine(eVs, @"Projects\sunamo.cz\sunamo.cz-old\");

    public static string sczNsnPath =
        Path.Combine(eVs, @"Projects\sunamo.cz\sunamo.cz-nsn\");


    public static string vsDocuments = Path.Combine(eDocuments, @"vs\");


    //public static string vs17 = @"E:\vs17\";


    //public static string vs17Documents = Path.Combine(eDocuments, @"vs17\");

    public static string NormalizePathToFolder = Path.Combine(eVs, @"Projects\");

    public static string Test_MoveClassElementIntoSharedFileUC =
        "D:\\_Test\\AllProjectsSearch\\AllProjectsSearch\\MoveClassElementIntoSharedFileUC\\";

    public const string SyncArchived = @"E:\SyncArchived\";
    public const string SyncArchivedText = @"E:\SyncArchived\Text\";
    public const string SyncArchivedDrive = @"E:\SyncArchived\Drive\";

    public static List<string> All = new() { Documents, Docs, Downloads, Music2 };
    public static string XnConvert = @"D:\Pictures\XnConvert\";
    public const string PhotosScz = @"D:\Pictures\photos.sunamo.cz\";

    [Obsolete("Vůbec nechápu k čemu to má být")]
    public static List<string> AllPathsToProjects;

    /// <summary>
    ///     Solution, not project
    /// </summary>
    //public static string sunamo;

    [Obsolete("There is none sunamo\\sunamo")]
    /// <summary>
    ///     Cant be used also VpsHelperSunamo.SunamoProject()
    /// </summary>
    public static string sunamoProject;

    /// <summary>
    ///     E:\Documents\vs\Projects\
    /// </summary>
    public static string eVsProjects = @"E:\vs\Projects\";

    public const string eVsProjectsPinp = @"E:\vs\Projects\PlatformIndependentNuGetPackages\";

    /// <summary>
    ///     E:\Documents\vs\Projects\
    /// </summary>
    //public static string vs;

    //public static string KeysXlf;
    //public static string DllSunamo;
    //public static string VisualStudio2017;
    //public static string VisualStudio2017WoSlash;

    public const string BackupSunamosAppData = @"E:\Sync\Develop of Future\Backups\";
    public const string pathPa = @"D:\pa\";
    public const string pathPaSync = @"D:\paSync\";

    //public const string capturedUris =
    //    @"C:\Users\Administrator\AppData\Roaming\sunamo\SunamoCzAdmin\Data\SubsSignalR\CapturedUris.txt";

    //public const string capturedUris_backup =
    //    @"C:\Users\Administrator\AppData\Roaming\sunamo\SunamoCzAdmin\Data\SubsSignalR\CapturedUris_backup.txt";

    //public const string rootVideos0Kb = @"D:\Documents\Videos0kb\";
    public static string Documents = @"D:\Documents\";
    public static string eDocuments = @"E:\Documents\";
    public static string Docs = @"D:\Docs\";
    public static string Downloads = @"D:\Downloads\";
    public static string Music2 = @"D:\Music2\";
    public static string Backup = @"D:\Documents\Backup\";
    public static string Streamline = @"D:\Pictures\Streamline_All_Icons_PNG\PNG Icons\";
}