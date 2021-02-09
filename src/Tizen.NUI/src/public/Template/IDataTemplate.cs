using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}
