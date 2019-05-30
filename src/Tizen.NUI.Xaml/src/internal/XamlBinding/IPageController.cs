using System.Collections.ObjectModel;
using Tizen.NUI;

namespace Tizen.NUI.XamlBinding
{
    internal interface IPageController
    {
        Rectangle ContainerArea { get; set; }

        bool IgnoresContainerArea { get; set; }

        ObservableCollection<Element> InternalChildren { get; }

        void SendAppearing();

        void SendDisappearing();
    }
}