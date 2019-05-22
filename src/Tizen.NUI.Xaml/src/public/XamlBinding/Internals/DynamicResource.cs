using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// The class DynamicResource.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class DynamicResource
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DynamicResource(string key)
        {
            Key = key;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Key { get; private set; }
    }
}