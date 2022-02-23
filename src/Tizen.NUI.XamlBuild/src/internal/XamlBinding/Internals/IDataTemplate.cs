using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}