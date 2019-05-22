using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal interface IViewContainer<T> where T : Element
    {
        IList<T> Children { get; }
    }
}