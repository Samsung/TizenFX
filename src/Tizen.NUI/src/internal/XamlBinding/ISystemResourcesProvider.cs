using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal interface ISystemResourcesProvider
    {
        IResourceDictionary GetSystemResources();
    }
}
