using Tizen.NUI.Internals;

namespace Tizen.NUI.Binding
{
    internal static class NameScopeExtensions
    {
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