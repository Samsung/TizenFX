using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IResourcesProvider
    {
        bool IsResourcesCreated { get; }
        ResourceDictionary Resources { get; set; }
    }
}
