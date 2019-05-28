using System;
using System.Collections.Generic;

namespace Tizen.NUI.Binding
{
    internal interface IResourceDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        bool TryGetValue(string key, out object value);

        event EventHandler<ResourcesChangedEventArgs> ValuesChanged;
    }
}