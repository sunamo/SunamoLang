namespace SunamoLang._sunamo.SunamoExceptions;

// © www.sunamo.cz. All Rights Reserved.
internal sealed partial class Exceptions
{
    #region Other
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }


    internal static Tuple<string, string, string> PlaceOfException(
bool fillAlsoFirstTwo = true)
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
            var item = lines[index];
            if (fillAlsoFirstTwo)
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    fillAlsoFirstTwo = false;
                }
            if (item.StartsWith("at System."))
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
        var methodCall = stackTraceLine.Split("at ")[1].Trim();
        var fullMethodPath = methodCall.Split("(")[0];
        var nameParts = fullMethodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = nameParts[^1];
        nameParts.RemoveAt(nameParts.Count - 1);
        type = string.Join(".", nameParts);
    }
    internal static string CallingMethod(int frameDepth = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(frameDepth)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }
    #endregion

    #region OnlyReturnString 
    internal static string? Custom(string before, string message)
    {
        return CheckBefore(before) + message;
    }
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }
    #endregion
    internal static string? NotImplementedCase(string before, object notImplementedName)
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
        return CheckBefore(before) + "Not implemented case" + forSuffix + " . internal program error. Please contact developer" +
        ".";
    }

    internal static string? DifferentCountInLists(string before, string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        if (firstCollectionCount != secondCollectionCount)
            return CheckBefore(before) + " different count elements in collection" + " " +
            string.Concat(firstCollectionName + "-" + firstCollectionCount) + " vs. " +
            string.Concat(secondCollectionName + "-" + secondCollectionCount);
        return null;
    }
}