using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Binding.Internals
{
    internal interface IDynamicResourceHandler
    {
        void SetDynamicResource(BindableProperty property, string key);
    }
}
