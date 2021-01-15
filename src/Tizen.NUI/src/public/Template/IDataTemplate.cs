using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    public interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}
