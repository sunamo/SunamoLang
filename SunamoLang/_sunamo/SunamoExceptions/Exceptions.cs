namespace SunamoLang._sunamo.SunamoExceptions;

internal sealed partial class Exceptions
{
    #region Other

    internal static string CheckBefore(string prefix) =>
        string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix + ": ";

    internal static Tuple<string, string, string> PlaceOfException(bool isFillingFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var stackTraceText = stackTrace.ToString();
        var lines = stackTraceText.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);
        var index = 0;
        string type = string.Empty;
        string methodName = string.Empty;
        for (; index < lines.Count; index++)
        {
            var line = lines[index];
            if (isFillingFirstTwo)
                if (!line.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(line, out type, out methodName);
                    isFillingFirstTwo = false;
                }
            if (line.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }
        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    internal static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var methodCall = stackTraceLine.Split(new[] { "at " }, StringSplitOptions.None)[1].Trim();
        var fullMethodPath = methodCall.Split(new[] { "(" }, StringSplitOptions.None)[0];
        var nameParts = fullMethodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = nameParts[^1];
        nameParts.RemoveAt(nameParts.Count - 1);
        type = string.Join(".", nameParts);
    }

    internal static string CallingMethod(int frameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameDepth)?.GetMethod();
        if (methodBase is null)
        {
            return "Method name cannot be get";
        }
        return methodBase.Name;
    }
    #endregion

    #region OnlyReturnString

    internal static string? Custom(string prefix, string message) =>
        CheckBefore(prefix) + message;

    internal static string? NotImplementedMethod(string prefix) =>
        CheckBefore(prefix) + "Not implemented method.";
    #endregion

    internal static string? NotImplementedCase(string prefix, object notImplementedName)
    {
        var forSuffix = string.Empty;
        if (notImplementedName != null)
        {
            forSuffix = " for ";
            if (notImplementedName.GetType() == typeof(Type))
                forSuffix += ((Type)notImplementedName).FullName;
            else
                forSuffix += notImplementedName.ToString();
        }
        return CheckBefore(prefix) + "Not implemented case" + forSuffix + " . internal program error. Please contact developer" +
        ".";
    }

    internal static string? DifferentCountInLists(string prefix, string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        if (firstCollectionCount != secondCollectionCount)
            return CheckBefore(prefix) + " different count elements in collection" + " " +
            string.Concat(firstCollectionName + "-" + firstCollectionCount) + " vs. " +
            string.Concat(secondCollectionName + "-" + secondCollectionCount);
        return null;
    }
}
