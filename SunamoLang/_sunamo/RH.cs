namespace SunamoLang._sunamo;

/// <summary>
/// Reflection helper class for getting and setting property values.
/// </summary>
internal class RH
{
    #region For easy copy
    internal static object GetValueOfProperty(string name, Type type, object instance, bool ignoreCase)
    {
        PropertyInfo[] pis = type.GetProperties();
        return GetValue(name, type, instance, pis, ignoreCase, null);
    }

    internal static object SetValueOfProperty(string name, Type type, object instance, bool ignoreCase, object value)
    {
        PropertyInfo[] properties = type.GetProperties();
        return SetValue(name, type, instance, properties, ignoreCase, value);
    }

    private static object SetValue(object instance, MemberInfo[] property, object value)
    {
        var memberInfo = property[0];
        if (memberInfo is PropertyInfo)
        {
            var propertyInfo = (PropertyInfo)memberInfo;
            propertyInfo.SetValue(instance, value);
        }
        else if (memberInfo is FieldInfo)
        {
            var fieldInfo = (FieldInfo)memberInfo;
            fieldInfo.SetValue(instance, value);
        }
        return null;
    }

    private static object GetValue(object instance, MemberInfo[] property, object value)
    {
        var memberInfo = property[0];
        if (memberInfo is PropertyInfo)
        {
            var propertyInfo = (PropertyInfo)memberInfo;
            return propertyInfo.GetValue(instance);
        }
        else if (memberInfo is FieldInfo)
        {
            var fieldInfo = (FieldInfo)memberInfo;
            return fieldInfo.GetValue(instance);
        }
        return null;
    }

    internal static object GetValue(string name, Type type, object instance, IList properties, bool ignoreCase, object value)
    {
        return GetOrSetValue(name, type, instance, properties, ignoreCase, GetValue, value);
    }

    internal static object SetValue(string name, Type type, object instance, IList properties, bool ignoreCase, object value)
    {
        return GetOrSetValue(name, type, instance, properties, ignoreCase, SetValue, value);
    }

    internal static object GetOrSetValue(string name, Type type, object instance, IList properties, bool ignoreCase, Func<object, MemberInfo[], object, object> getOrSet, object value)
    {
        if (ignoreCase)
        {
            name = name.ToLower();
            foreach (MemberInfo item in properties)
            {
                if (item.Name.ToLower() == name)
                {
                    var property = type.GetMember(name);
                    if (property != null)
                    {
                        return getOrSet(instance, property, value);
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
                    var property = type.GetMember(name);
                    if (property != null)
                    {
                        return getOrSet(instance, property, value);
                    }
                }
            }
        }
        return null;
    }

    internal static bool ExistsClass(string className)
    {
        var type2 = (from assembly in AppDomain.CurrentDomain.GetAssemblies()
                     from type in assembly.GetTypes()
                     where type.Name == className
                     select type).FirstOrDefault();

        return type2 != null;
    }
    #endregion
}