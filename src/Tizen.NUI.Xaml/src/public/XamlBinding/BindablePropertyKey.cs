using System;
using System.ComponentModel;

namespace Tizen.NUI.XamlBinding
{
    /// <summary>
    /// The secret key to a BindableProperty, used to implement a BindableProperty with restricted write access.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public sealed class BindablePropertyKey
    {
        internal BindablePropertyKey(BindableProperty property)
        {
            if (property == null)
                throw new ArgumentNullException("property");

            BindableProperty = property;
        }

        /// <summary>
        /// Gets the BindableProperty.
        /// </summary>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public BindableProperty BindableProperty { get; private set; }
    }
}