namespace SunamoLang._sunamo.SunamoExceptions;

/// <summary>
/// Provides exception message generation utilities.
/// </summary>
internal sealed partial class Exceptions
{
    #region Other

    /// <summary>
    /// Checks and formats a prefix for exception messages.
    /// </summary>
    /// <param name="prefix">The prefix text to prepend to exception messages.</param>
    /// <returns>Empty string if prefix is null or whitespace, otherwise prefix followed by colon and space.</returns>
    internal static string CheckBefore(string prefix)
    {
        return string.IsNullOrWhiteSpace(prefix) ? string.Empty : prefix + ": ";
    }

    /// <summary>
    /// Determines the location of an exception in the call stack.
    /// </summary>
    /// <param name="isFillingFirstTwo">Whether to also fill the type and method name from the first non-ThrowEx frame.</param>
    /// <returns>A tuple containing type name, method name, and the full stack trace text.</returns>
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

    /// <summary>
    /// Extracts the type and method name from a stack trace line.
    /// </summary>
    /// <param name="stackTraceLine">A single line from a stack trace.</param>
    /// <param name="type">Output: the fully qualified type name.</param>
    /// <param name="methodName">Output: the method name.</param>
    internal static void TypeAndMethodName(string stackTraceLine, out string type, out string methodName)
    {
        var methodCall = stackTraceLine.Split("at ")[1].Trim();
        var fullMethodPath = methodCall.Split("(")[0];
        var nameParts = fullMethodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = nameParts[^1];
        nameParts.RemoveAt(nameParts.Count - 1);
        type = string.Join(".", nameParts);
    }

    /// <summary>
    /// Gets the name of the calling method at the specified frame depth.
    /// </summary>
    /// <param name="frameDepth">The depth in the call stack to retrieve the method name from.</param>
    /// <returns>The name of the calling method.</returns>
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

    /// <summary>
    /// Creates a custom exception message with an optional prefix.
    /// </summary>
    /// <param name="prefix">The prefix text to prepend.</param>
    /// <param name="message">The exception message.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? Custom(string prefix, string message)
    {
        return CheckBefore(prefix) + message;
    }

    /// <summary>
    /// Creates a "not implemented method" exception message.
    /// </summary>
    /// <param name="prefix">The prefix text to prepend.</param>
    /// <returns>The formatted exception message.</returns>
    internal static string? NotImplementedMethod(string prefix)
    {
        return CheckBefore(prefix) + "Not implemented method.";
    }
    #endregion

    /// <summary>
    /// Creates a "not implemented case" exception message.
    /// </summary>
    /// <param name="prefix">The prefix text to prepend.</param>
    /// <param name="notImplementedName">The name or type of the unimplemented case.</param>
    /// <returns>The formatted exception message.</returns>
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

    /// <summary>
    /// Creates an exception message for collections with different element counts.
    /// </summary>
    /// <param name="prefix">The prefix text to prepend.</param>
    /// <param name="firstCollectionName">The name of the first collection.</param>
    /// <param name="firstCollectionCount">The count of elements in the first collection.</param>
    /// <param name="secondCollectionName">The name of the second collection.</param>
    /// <param name="secondCollectionCount">The count of elements in the second collection.</param>
    /// <returns>The formatted exception message if counts differ, otherwise null.</returns>
    internal static string? DifferentCountInLists(string prefix, string firstCollectionName, int firstCollectionCount, string secondCollectionName, int secondCollectionCount)
    {
        if (firstCollectionCount != secondCollectionCount)
            return CheckBefore(prefix) + " different count elements in collection" + " " +
            string.Concat(firstCollectionName + "-" + firstCollectionCount) + " vs. " +
            string.Concat(secondCollectionName + "-" + secondCollectionCount);
        return null;
    }
}
