namespace SunamoLang._sunamo.SunamoExceptions;

internal partial class ThrowEx
{
    internal static bool Custom(string message, bool shouldThrow = true, string additionalMessage = "")
    {
        string joinedMessage = string.Join(" ", message, additionalMessage);
        string? exception = Exceptions.Custom(FullNameOfExecutedCode(), joinedMessage);
        return ThrowIsNotNull(exception, shouldThrow);
    }

    internal static bool DifferentCountInLists<T>(string firstCollectionName, IList<T> firstCollection, string secondCollectionName, IList<T> secondCollection)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollection.Count, secondCollectionName, secondCollection.Count));
    }

    internal static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }

    internal static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }

    #region Other

    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> exceptionPlace = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(exceptionPlace.Item1, exceptionPlace.Item2, true);
        return fullName;
    }

    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName is null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }
        string typeFullName;
        if (type is Type typeCast)
        {
            typeFullName = typeCast.FullName ?? "Type cannot be get via type is Type typeCast";
        }
        else if (type is MethodBase methodBase)
        {
            typeFullName = methodBase.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase methodBase";
            methodName = methodBase.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type objectType = type.GetType();
            typeFullName = objectType.FullName ?? "Type cannot be get via type.GetType()";
        }
        return string.Concat(typeFullName, ".", methodName);
    }

    internal static bool ThrowIsNotNull(string? exception, bool shouldThrow = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (shouldThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode

    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionFactory, TArgument argument)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exception);
    }

    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exception);
    }
    #endregion
    #endregion
}
