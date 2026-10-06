namespace SunamoLang._sunamo;

internal class RH
{
    #region For easy copy

    internal static object? GetValueOfProperty(string name, Type type, object instance, bool isIgnoringCase)
    {
        PropertyInfo[] properties = type.GetProperties();
        return GetValue(name, type, instance, properties, isIgnoringCase, null);
    }

    internal static object? SetValueOfProperty(string name, Type type, object instance, bool isIgnoringCase, object value)
    {
        PropertyInfo[] properties = type.GetProperties();
        return SetValue(name, type, instance, properties, isIgnoringCase, value);
    }

    private static object? SetValue(object instance, MemberInfo[] members, object? value)
    {
        var memberInfo = members[0];
        if (memberInfo is PropertyInfo propertyInfo)
        {
            propertyInfo.SetValue(instance, value);
        }
        else if (memberInfo is FieldInfo fieldInfo)
        {
            fieldInfo.SetValue(instance, value);
        }
        return null;
    }

    private static object? GetValue(object instance, MemberInfo[] members, object? value)
    {
        var memberInfo = members[0];
        if (memberInfo is PropertyInfo propertyInfo)
        {
            return propertyInfo.GetValue(instance);
        }
        else if (memberInfo is FieldInfo fieldInfo)
        {
            return fieldInfo.GetValue(instance);
        }
        return null;
    }

    /// <summary>
    /// Gets a value by member name with case sensitivity control.
    /// </summary>
    /// <param name="name">The member name to find.</param>
    /// <param name="type">The type containing the member.</param>
    /// <param name="instance">The object instance to read from.</param>
    /// <param name="properties">The list of members to search.</param>
    /// <param name="isIgnoringCase">Whether to perform case-insensitive name matching.</param>
    /// <param name="value">Unused parameter (reserved for symmetry with SetValue).</param>
    /// <returns>The member value, or null if not found.</returns>
    internal static object? GetValue(string name, Type type, object instance, IList properties, bool isIgnoringCase, object? value) =>
        GetOrSetValue(name, type, instance, properties, isIgnoringCase, GetValue, value);

    /// <summary>
    /// Sets a value by member name with case sensitivity control.
    /// </summary>
    /// <param name="name">The member name to find.</param>
    /// <param name="type">The type containing the member.</param>
    /// <param name="instance">The object instance to modify.</param>
    /// <param name="properties">The list of members to search.</param>
    /// <param name="isIgnoringCase">Whether to perform case-insensitive name matching.</param>
    /// <param name="value">The value to set.</param>
    /// <returns>Null after successful operation.</returns>
    internal static object? SetValue(string name, Type type, object instance, IList properties, bool isIgnoringCase, object value) =>
        GetOrSetValue(name, type, instance, properties, isIgnoringCase, SetValue, value);

    internal static object? GetOrSetValue(string name, Type type, object instance, IList properties, bool isIgnoringCase, Func<object, MemberInfo[], object?, object?> getOrSetAction, object? value)
    {
        if (isIgnoringCase)
        {
            name = name.ToLower();
            foreach (MemberInfo item in properties)
            {
                if (item.Name.ToLower() == name)
                {
                    var members = type.GetMember(name);
                    if (members != null)
                    {
                        return getOrSetAction(instance, members, value);
                    }
                }
            }
        }
        else
        {
            foreach (MemberInfo item in properties)
            {
                if (item.Name == name)
                {
                    var members = type.GetMember(name);
                    if (members != null)
                    {
                        return getOrSetAction(instance, members, value);
                    }
                }
            }
        }
        return null;
    }

    internal static bool ExistsClass(string className)
    {
        var foundType = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from type in assembly.GetTypes()
                     where type.Name == className
                     select type).FirstOrDefault();

        return foundType != null;
    }
    #endregion
}
