using System.Collections.Generic;

namespace Tizen.NUI.XamlBinding
{
    internal interface IViewContainer<T> where T : Element
    {
        IList<T> Children { get; }
    }
}