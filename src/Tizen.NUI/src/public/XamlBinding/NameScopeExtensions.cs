using System.ComponentModel;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class NameScopeExtensions
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T FindByName<T>(this Element element, string name)
        {
            return ((INameScope)element).FindByName<T>(name);
        }

        internal static T FindByName<T>(this INameScope namescope, string name)
        {
            return (T)namescope.FindByName(name);
        }
    }
}