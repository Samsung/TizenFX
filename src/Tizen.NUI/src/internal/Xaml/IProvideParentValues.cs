using System.Collections.Generic;

namespace Tizen.NUI.Xaml
{
    internal interface IProvideParentValues : IProvideValueTarget
    {
        IEnumerable<object> ParentObjects { get; }
    }
}
