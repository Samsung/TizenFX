using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding.Internals
{
    internal interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}
