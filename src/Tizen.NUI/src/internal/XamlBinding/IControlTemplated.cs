using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal interface IControlTemplated
    {
        // ControlTemplate ControlTemplate { get; set; }

        IList<Element> InternalChildren { get; }

        void OnControlTemplateChanged(ControlTemplate oldValue, ControlTemplate newValue);
    }
}
