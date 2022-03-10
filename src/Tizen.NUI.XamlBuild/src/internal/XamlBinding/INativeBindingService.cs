namespace Tizen.NUI.Binding
{

    internal interface INativeBindingService
    {
        bool TrySetBinding(object target, string propertyName, BindingBase binding);
        bool TrySetBinding(object target, BindableProperty property, BindingBase binding);
        bool TrySetValue(object target, BindableProperty property, object value);
    }
}