using System.Collections.Generic;

namespace Tizen.NUI.XamlBinding
{
    internal interface ILayoutController
    {
        IReadOnlyList<Element> Children { get; }
    }
}