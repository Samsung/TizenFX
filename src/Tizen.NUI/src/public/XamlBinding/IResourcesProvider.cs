using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IResourcesProvider
    {
        bool IsResourcesCreated { get; }
        ResourceDictionary Resources { get; set; }
    }
}
