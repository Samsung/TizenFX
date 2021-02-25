namespace Tizen.NUI.Binding
{
    internal interface IAttachedObject
    {
        void AttachTo(BindableObject bindable);
        void DetachFrom(BindableObject bindable);
    }
}
