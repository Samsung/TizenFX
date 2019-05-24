using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    /// <summary>
    /// The interface IDynamicResourceHandler.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDynamicResourceHandler
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        void SetDynamicResource(BindableProperty property, string key);
    }
}
