namespace Tizen.NUI.XamlBinding
{
    internal interface IMenuItemController
    {
        bool IsEnabled { get; set; }
        string IsEnabledPropertyName { get; }

        void Activate();
    }
}
