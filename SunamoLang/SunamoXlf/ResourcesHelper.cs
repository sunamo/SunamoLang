namespace SunamoLang.SunamoXlf;

/// <summary>
/// Helper class for loading from *.resources and *.resx files.
/// Usage: ThisApp.Resources = ResourcesHelper.Create("sunamo.Properties.Resources", typeof(ResourcesHelper).Assembly)
/// When the joined file changes, the content update is also reflected in the *.resx file.
/// </summary>
public class ResourcesHelper
{
    #region For easy copy

    private ResourceManager? _resourceManager;

    private ResourcesHelper()
    {
    }

    /// <summary>
    /// Creates a ResourcesHelper instance for the specified resource class.
    /// </summary>
    /// <param name="resourceClass">The resource class name without extension and language specifier (e.g., MyApp.MyResource for MyApp.MyResource.en-US.resx).</param>
    /// <param name="assembly">The assembly containing the resources.</param>
    /// <returns>A new ResourcesHelper instance.</returns>
    public static ResourcesHelper Create(string resourceClass, Assembly assembly)
    {
        var resourcesHelper = new ResourcesHelper();
        resourcesHelper._resourceManager = new ResourceManager(resourceClass, assembly);
        return resourcesHelper;
    }

    /// <summary>
    /// Gets a string resource by name.
    /// </summary>
    /// <param name="name">The resource name.</param>
    /// <returns>The string value of the resource.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string? GetString(string name)
    {
        return _resourceManager?.GetString(name);
    }

    /// <summary>
    /// Gets a byte array resource as a UTF-8 string.
    /// </summary>
    /// <param name="name">The resource name.</param>
    /// <returns>The byte array resource converted to a UTF-8 string.</returns>
    public string GetByteArrayAsString(string name)
    {
        var byteArray = _resourceManager?.GetObject(name) as byte[];
        return byteArray != null ? Encoding.UTF8.GetString(byteArray) : string.Empty;
    }

    #endregion
}