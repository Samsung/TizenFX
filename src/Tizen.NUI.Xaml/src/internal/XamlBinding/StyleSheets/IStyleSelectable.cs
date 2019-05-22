using System;
using System.Collections.Generic;
using Tizen.NUI.Binding;

namespace Tizen.NUI.StyleSheets
{
    public interface IStyleSelectable
    {
        string[] NameAndBases { get; }
        string Id { get; }
        IStyleSelectable Parent { get; }
        IList<string> Classes { get; }
        IEnumerable<IStyleSelectable> Children { get; }
    }

    public interface IStylable
    {
        BindableProperty GetProperty(string key, bool inheriting);
    }
}