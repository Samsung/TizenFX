using System;
using System.ComponentModel;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IXamlTypeResolver.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public interface IXamlTypeResolver
    {
        /// <summary>
        /// Resolve xaml.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        Type Resolve(string qualifiedTypeName, IServiceProvider serviceProvider = null);

        /// <summary>
        /// Resolve xaml and out put the type.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        bool TryResolve(string qualifiedTypeName, out Type type);
    }
}