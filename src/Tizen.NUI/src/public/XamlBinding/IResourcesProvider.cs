using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IResourcesProvider
    {
        /// <summary>
        /// Check if resources created.
        /// </summary>
        bool IsResourcesCreated { get; }

        /// <summary>
        /// Saved xaml resources.
        /// </summary>
        ResourceDictionary XamlResources { get; set; }
    }
}
