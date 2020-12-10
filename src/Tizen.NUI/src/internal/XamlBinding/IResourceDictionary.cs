using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface IResourceDictionary : IEnumerable<KeyValuePair<string, object>>
    {
        bool TryGetValue(string key, out object value);

        event EventHandler<ResourcesChangedEventArgs> ValuesChanged;
    }
}
