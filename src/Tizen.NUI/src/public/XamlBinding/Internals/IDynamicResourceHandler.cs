using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDynamicResourceHandler
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        void SetDynamicResource(BindableProperty targetProperty, string key);
    }
}
