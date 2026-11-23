namespace SunamoLang.SunamoXlf;

// Usage: ThisApp.Resources = ResourcesHelper.Create("sunamo.Properties.Resources", typeof(ResourcesHelper).Assembly)
// When the joined file changes, the content update is also reflected in the *.resx file.
/// <summary>
/// Represents the resources helper type.
/// </summary>
public class ResourcesHelper
{
    #region For easy copy

    private ResourceManager? resourceManager;

    private ResourcesHelper()
    {
    }

    /// <summary>
    /// Create.
    /// </summary>
    /// <param name="resourceClass">The resource class.</param>
    /// <param name="assembly">The assembly.</param>
    /// <returns>The create result.</returns>
    public static ResourcesHelper Create(string resourceClass, Assembly assembly)
    {
        var resourcesHelper = new ResourcesHelper();
        resourcesHelper.resourceManager = new ResourceManager(resourceClass, assembly);
        return resourcesHelper;
    }

    /// <summary>
    /// Get string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get string result.</returns>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string? GetString(string name)
    {
        return resourceManager?.GetString(name);
    }

    /// <summary>
    /// Get byte array as string.
    /// </summary>
    /// <param name="name">The name.</param>
    /// <returns>The get byte array as string result.</returns>
    public string GetByteArrayAsString(string name)
    {
        var byteArray = resourceManager?.GetObject(name) as byte[];
        return byteArray != null ? Encoding.UTF8.GetString(byteArray) : string.Empty;
    }

    #endregion
}
