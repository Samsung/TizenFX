namespace Tizen.NUI.Binding
{
    internal interface IMenuItemController
    {
        bool IsEnabled { get; set; }
        string IsEnabledPropertyName { get; }

        void Activate();
    }
}
