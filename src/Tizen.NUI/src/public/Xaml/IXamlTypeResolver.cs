
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    using global::System;

    /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IXamlTypeResolver
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type Resolve(string qualifiedTypeName, IServiceProvider serviceProvider = null);

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool TryResolve(string qualifiedTypeName, out Type type);
    }
}