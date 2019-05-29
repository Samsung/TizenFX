using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using Tizen.NUI.XamlBinding;
using Tizen.NUI.Xaml;

namespace Tizen.NUI.XamlBinding.Internals
{
    /// <summary>
    /// The class NameScope.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class NameScope : INameScope
    {
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NameScopeProperty = BindableProperty.CreateAttached("NameScope", typeof(INameScope), typeof(NameScope), default(INameScope));

        readonly Dictionary<string, object> _names = new Dictionary<string, object>();

        object INameScope.FindByName(string name)
        {
            if (_names.ContainsKey(name))
                return _names[name];
            return null;
        }

        void INameScope.RegisterName(string name, object scopedElement)
        {
            if (_names.ContainsKey(name))
                throw new ArgumentException("An element with the same key already exists in NameScope", "name");

            _names[name] = scopedElement;
        }

        [Obsolete]
        void INameScope.RegisterName(string name, object scopedElement, IXmlLineInfo xmlLineInfo)
        {
            try
            {
                ((INameScope)this).RegisterName(name, scopedElement);
            }
            catch (ArgumentException)
            {
                throw new XamlParseException(string.Format("An element with the name \"{0}\" already exists in this NameScope", name), xmlLineInfo);
            }
        }

        void INameScope.UnregisterName(string name)
        {
            _names.Remove(name);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static INameScope GetNameScope(BindableObject bindable)
        {
            return (INameScope)bindable.GetValue(NameScopeProperty);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static void SetNameScope(BindableObject bindable, INameScope value)
        {
            bindable.SetValue(NameScopeProperty, value);
        }
    }
}
