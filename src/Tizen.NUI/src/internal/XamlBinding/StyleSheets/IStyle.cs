using System;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleSheets
{
    internal interface IStyle
    {
        global::System.Type TargetType { get; }

        void Apply(BindableObject bindable);
        void UnApply(BindableObject bindable);
    }
}
