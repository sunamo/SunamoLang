namespace SunamoLang.SunamoXlf;

// Usage: ThisApp.Resources = ResourcesHelper.Create("sunamo.Properties.Resources", typeof(ResourcesHelper).Assembly)
// When the joined file changes, the content update is also reflected in the *.resx file.
public class ResourcesHelper
{
    #region For easy copy

    private ResourceManager? resourceManager;

    private ResourcesHelper()
    {
    }

    public static ResourcesHelper Create(string resourceClass, Assembly assembly)
    {
        var resourcesHelper = new ResourcesHelper();
        resourcesHelper.resourceManager = new ResourceManager(resourceClass, assembly);
        return resourcesHelper;
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public string? GetString(string name)
    {
        return resourceManager?.GetString(name);
    }

    public string GetByteArrayAsString(string name)
    {
        var byteArray = resourceManager?.GetObject(name) as byte[];
        return byteArray != null ? Encoding.UTF8.GetString(byteArray) : string.Empty;
    }

    #endregion
}
