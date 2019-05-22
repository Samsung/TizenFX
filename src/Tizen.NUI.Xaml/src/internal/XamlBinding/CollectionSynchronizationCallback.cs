using System;
using System.Collections;

namespace Tizen.NUI.Binding
{
    public delegate void CollectionSynchronizationCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess);
}