using System;

namespace Tizen.NUI.Xaml
{
    /// <summary>
    /// The interface IXamlTypeResolver.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public interface IXamlTypeResolver
    {
        /// <summary>
        /// Resolve xaml.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        Type Resolve(string qualifiedTypeName, IServiceProvider serviceProvider = null);

        /// <summary>
        /// Resolve xaml and out put the type.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        bool TryResolve(string qualifiedTypeName, out Type type);
    }
}