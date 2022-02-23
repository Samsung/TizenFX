using System.Collections.Generic;
using System.ComponentModel;
using Tizen.NUI.Binding.Internals;

namespace Tizen.NUI.Binding
{
    /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal static class NameScopeExtensions
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

        private static Stack<Element> elementStack = new Stack<Element>();

        internal static void PushElement(object element)
        {
            elementStack.Push((Element)element);
        }

        internal static void PopElement()
        {
            elementStack.Pop();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static T FindByNameInCurrentNameScope<T>(string name)
        {
            return FindByName<T>(elementStack.Peek(), name);
        }
    }
}