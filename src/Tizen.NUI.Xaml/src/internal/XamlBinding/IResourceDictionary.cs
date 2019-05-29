using System;
using System.Collections.Generic;

namespace Tizen.NUI.XamlBinding
{
    internal interface IResourceDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        bool TryGetValue(string key, out object value);

        event EventHandler<ResourcesChangedEventArgs> ValuesChanged;
    }
}