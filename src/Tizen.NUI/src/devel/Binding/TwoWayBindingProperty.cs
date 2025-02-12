using System;
using System.ComponentModel;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// This class represents a two-way binding property between a view and its value.
    /// </summary>
    /// <typeparam name="TView">The type of the view.</typeparam>
    /// <typeparam name="TValue">The type of the value.</typeparam>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TwoWayBindingProperty<TView, TValue> : BindingProperty<TView, TValue>
    {
        /// <summary>
        /// Gets or sets the function that retrieves the value from the view.
        /// </summary>
        public Func<TView, TValue> Getter { get; set; }

        /// <summary>
        /// Gets or sets the action that adds an observer to the view.
        /// </summary>
        public Action<TView, Action> AddObserver { get; set; }

        /// <summary>
        /// Gets or sets the action that removes an observer from the view.
        /// </summary>
        public Action<TView, Action> RemoveObserver { get; set; }
    }
}
