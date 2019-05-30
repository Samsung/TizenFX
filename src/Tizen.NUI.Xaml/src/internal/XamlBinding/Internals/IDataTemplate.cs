using System;

namespace Tizen.NUI.XamlBinding.Internals
{
    internal interface IDataTemplate
    {
        Func<object> LoadTemplate { get; set; }
    }
}