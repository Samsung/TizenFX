using System;

namespace Tizen.NUI.Binding.Internals
{
    internal interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}