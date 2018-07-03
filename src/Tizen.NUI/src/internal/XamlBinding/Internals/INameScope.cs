using System;
using System.ComponentModel;
using System.Xml;

namespace Tizen.NUI.Binding.Internals
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface INameScope
    {
        object FindByName(string name);
        void RegisterName(string name, object scopedElement);
        void UnregisterName(string name);
        [Obsolete]void RegisterName(string name, object scopedElement, IXmlLineInfo xmlLineInfo);
    }
}
