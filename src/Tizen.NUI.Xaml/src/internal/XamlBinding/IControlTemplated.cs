using System.Collections.Generic;

namespace Tizen.NUI.XamlBinding
{
    internal interface IControlTemplated
    {
        // ControlTemplate ControlTemplate { get; set; }

        IList<Element> InternalChildren { get; }

        void OnControlTemplateChanged(ControlTemplate oldValue, ControlTemplate newValue);
    }
}
