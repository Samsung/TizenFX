using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// The interface IDynamicResourceHandler.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDynamicResourceHandler
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        void SetDynamicResource(BindableProperty property, string key);
    }
}
