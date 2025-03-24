using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// The BindingProperty class represents a binding property for a view.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class BindingProperty<TView, TValue>
    {
        /// <summary>
        /// Gets or sets the setter action for the binding property.
        /// </summary>
        public Action<TView, TValue> Setter { get; set; }
    }
}
