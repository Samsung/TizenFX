using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// The secret key to a BindableProperty, used to implement a BindableProperty with restricted write access.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    internal sealed class BindablePropertyKey
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
        public BindableProperty BindableProperty { get; private set; }
    }
}