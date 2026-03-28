namespace SunamoLang._sunamo.SunamoExceptions;

/// <summary>
/// Provides methods to throw exceptions with detailed context information.
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws a custom exception with the provided message.
    /// </summary>
    /// <param name="message">The exception message.</param>
    /// <param name="shouldThrow">Whether to actually throw the exception or just return true.</param>
    /// <param name="additionalMessage">An additional message to append.</param>
    /// <returns>True if the exception was generated, false otherwise.</returns>
    internal static bool Custom(string message, bool shouldThrow = true, string additionalMessage = "")
    {
        string joinedMessage = string.Join(" ", message, additionalMessage);
        string? exception = Exceptions.Custom(FullNameOfExecutedCode(), joinedMessage);
        return ThrowIsNotNull(exception, shouldThrow);
    }

    /// <summary>
    /// Throws an exception if two collections have different element counts.
    /// </summary>
    /// <typeparam name="T">The type of elements in the collections.</typeparam>
    /// <param name="firstCollectionName">The name of the first collection.</param>
    /// <param name="firstCollection">The first collection.</param>
    /// <param name="secondCollectionName">The name of the second collection.</param>
    /// <param name="secondCollection">The second collection.</param>
    /// <returns>True if the collections have different counts.</returns>
    internal static bool DifferentCountInLists<T>(string firstCollectionName, IList<T> firstCollection, string secondCollectionName, IList<T> secondCollection)
    {
        return ThrowIsNotNull(
            Exceptions.DifferentCountInLists(FullNameOfExecutedCode(), firstCollectionName, firstCollection.Count, secondCollectionName, secondCollection.Count));
    }

    /// <summary>
    /// Throws an exception for a not-implemented case.
    /// </summary>
    /// <param name="notImplementedName">The name or type of the unimplemented case.</param>
    /// <returns>True if the exception was thrown.</returns>
    internal static bool NotImplementedCase(object notImplementedName)
    { return ThrowIsNotNull(Exceptions.NotImplementedCase, notImplementedName); }

    /// <summary>
    /// Throws an exception for a not-implemented method.
    /// </summary>
    /// <returns>True if the exception was thrown.</returns>
    internal static bool NotImplementedMethod() { return ThrowIsNotNull(Exceptions.NotImplementedMethod); }

    #region Other

    /// <summary>
    /// Gets the full name of the currently executed code location.
    /// </summary>
    /// <returns>The fully qualified name of the calling type and method.</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> exceptionPlace = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(exceptionPlace.Item1, exceptionPlace.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of the executed code from type and method information.
    /// </summary>
    /// <param name="type">The type object (can be Type, MethodBase, string, or any object).</param>
    /// <param name="methodName">The method name.</param>
    /// <param name="isFromThrowEx">Whether this call originates from ThrowEx (affects stack depth).</param>
    /// <returns>The fully qualified name of the type and method.</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
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

    /// <summary>
    /// Throws an exception if the provided exception string is not null.
    /// </summary>
    /// <param name="exception">The exception message to evaluate.</param>
    /// <param name="shouldThrow">Whether to actually throw the exception.</param>
    /// <returns>True if the exception message was not null.</returns>
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

    /// <summary>
    /// Throws an exception using a factory function with one argument.
    /// </summary>
    /// <typeparam name="TArgument">The type of the argument.</typeparam>
    /// <param name="exceptionFactory">The factory function that creates the exception message.</param>
    /// <param name="argument">The argument to pass to the factory.</param>
    /// <returns>True if the exception was thrown.</returns>
    internal static bool ThrowIsNotNull<TArgument>(Func<string, TArgument, string?> exceptionFactory, TArgument argument)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode(), argument);
        return ThrowIsNotNull(exception);
    }

    /// <summary>
    /// Throws an exception using a parameterless factory function.
    /// </summary>
    /// <param name="exceptionFactory">The factory function that creates the exception message.</param>
    /// <returns>True if the exception was thrown.</returns>
    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFactory)
    {
        string? exception = exceptionFactory(FullNameOfExecutedCode());
        return ThrowIsNotNull(exception);
    }
    #endregion
    #endregion
}
