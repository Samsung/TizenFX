namespace Tizen.NUI.XamlBinding
{
    internal interface IAttachedObject
    {
        void AttachTo(BindableObject bindable);
        void DetachFrom(BindableObject bindable);
    }
}