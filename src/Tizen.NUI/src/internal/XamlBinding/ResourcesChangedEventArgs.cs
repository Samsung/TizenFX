using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal class ResourcesChangedEventArgs : EventArgs
    {
        public static readonly ResourcesChangedEventArgs StyleSheets = new ResourcesChangedEventArgs(null);

        public ResourcesChangedEventArgs(IEnumerable<KeyValuePair<string, object>> values)
        {
            Values = values;
        }

        public IEnumerable<KeyValuePair<string, object>> Values { get; private set; }
    }
}
