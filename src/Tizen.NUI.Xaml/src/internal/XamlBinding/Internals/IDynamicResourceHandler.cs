using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDynamicResourceHandler
    {
        void SetDynamicResource(BindableProperty property, string key);
    }
}
