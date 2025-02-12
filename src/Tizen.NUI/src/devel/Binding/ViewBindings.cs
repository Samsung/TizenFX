using System;
using System.ComponentModel;
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Binding
{
    /// <summary>
    /// Provides a set of static properties that represent the binding properties of the <see cref="View"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ViewBindings
    {
        /// <summary>
        /// Gets the binding property for the width of a <see cref="View"/>.
        /// </summary>
        public static BindingProperty<View, float> WidthProperty { get; } = new BindingProperty<View, float>
        {
            Setter = (v, value) => v.SizeWidth = value,
        };

        /// <summary>
        /// Gets the binding property for the height of a <see cref="View"/>.
        /// </summary>
        public static BindingProperty<View, float> HeightProperty { get; } = new BindingProperty<View, float>
        {
            Setter = (v, value) => v.SizeHeight = value,
        };

        /// <summary>
        /// Gets the binding property for the background color of a <see cref="View"/>.
        /// </summary>
        public static BindingProperty<View, UIColor> BackgroundColorProperty { get; } = new BindingProperty<View, UIColor>
        {
            Setter = (v, value) => v.SetBackgroundColor(value),
        };
    }

    /// <summary>
    /// Provides a set of static properties that represent the data-binding capabilities of the <see cref="TextLabel"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextLabelBindings
    {
        /// <summary>
        /// Gets the binding property for the <see cref="TextLabel.Text"/> property.
        /// </summary>
        public static BindingProperty<TextLabel, string> TextProperty { get; } = new BindingProperty<TextLabel, string>
        {
            Setter = (v, value) =>
            {
                v.Text = value;
            }
        };

        /// <summary>
        /// Gets the binding property for the <see cref="TextLabel.TextColor"/> property.
        /// </summary>
        public static BindingProperty<TextLabel, UIColor> TextColorProperty { get; } = new BindingProperty<TextLabel, UIColor>
        {
            Setter = (v, value) => v.TextColor = value.ToReferenceType(),
        };

        /// <summary>
        /// Gets the binding property for the <see cref="TextLabel.PointSize"/> property.
        /// </summary>
        public static BindingProperty<TextLabel, float> FontSizeProperty { get; } = new BindingProperty<TextLabel, float>
        {
            Setter = (v, value) => v.PointSize = value,
        };
    }

    /// <summary>
    /// This class provides a set of static properties for binding with <see cref="TextField"/> control.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextFieldBindings
    {
        /// <summary>
        /// The TextColorProperty is a bindable property that indicates the color of the text in the <see cref="TextField"/> control.
        /// </summary>
        public static BindingProperty<TextField, UIColor> TextColorProperty { get; } = new BindingProperty<TextField, UIColor>
        {
            Setter = (v, value) => v.TextColor = value.ToReferenceType(),
        };

        /// <summary>
        /// The FontSizeProperty is a bindable property that indicates the size of the font used to display the text in the <see cref="TextField"/> control.
        /// </summary>
        public static BindingProperty<TextField, float> FontSizeProperty { get; } = new BindingProperty<TextField, float>
        {
            Setter = (v, value) => v.PointSize = value,
        };

        /// <summary>
        /// The TextProperty is a two-way bindable property that indicates the text displayed in the <see cref="TextField"/> control.
        /// </summary>
        public static TwoWayBindingProperty<TextField, string> TextProperty { get; } = new TwoWayBindingProperty<TextField, string>
        {
            Setter = (v, value) => v.Text = value,
            Getter = v => v.Text,
            AddObserver = (v, action) => v.TextChanged += EventHandlerHelper.Set<EventHandler<TextField.TextChangedEventArgs>>((s, e) => { action.Invoke(); }, action),
            RemoveObserver = (v, action) => v.TextChanged -= EventHandlerHelper.Get<EventHandler<TextField.TextChangedEventArgs>>(action),
        };
    }

    /// <summary>
    /// Provides a set of static properties for binding TextEditor controls.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextEditorBindings
    {
        /// <summary>
        /// The TextColorProperty is a bindable property that indicates the color of the text in the TextEditor control.
        /// </summary>
        public static BindingProperty<TextEditor, UIColor> TextColorProperty { get; } = new BindingProperty<TextEditor, UIColor>
        {
            Setter = (v, value) => v.TextColor = value.ToReferenceType(),
        };

        /// <summary>
        /// The FontSizeProperty is a bindable property that indicates the size of the font used to display the text in the TextEditor control.
        /// </summary>
        public static BindingProperty<TextEditor, float> FontSizeProperty { get; } = new BindingProperty<TextEditor, float>
        {
            Setter = (v, value) => v.PointSize = value,
        };

        /// <summary>
        /// The TextProperty is a two-way bindable property that indicates the text displayed in the TextEditor control.
        /// </summary>
        public static TwoWayBindingProperty<TextEditor, string> TextProperty { get; } = new TwoWayBindingProperty<TextEditor, string>
        {
            Setter = (v, value) => v.Text = value,
            Getter = v => v.Text,
            AddObserver = (v, action) => v.TextChanged += EventHandlerHelper.Set<EventHandler<TextEditor.TextChangedEventArgs>>((s, e) => { action.Invoke(); }, action),
            RemoveObserver = (v, action) => v.TextChanged -= EventHandlerHelper.Get<EventHandler<TextEditor.TextChangedEventArgs>>(action),
        };
    }

    /// <summary>
    /// Provides a set of static properties that represent the bindable properties of the <see cref="ImageView"/> class.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ImageViewBindings
    {
        /// <summary>
        /// Represents the bindable property for the <see cref="ImageView.ResourceUrl"/> property.
        /// </summary>
        public static BindingProperty<ImageView, string> ResourceUrlProperty { get; } = new BindingProperty<ImageView, string>
        {
            Setter = (v, value) => v.ResourceUrl = value,
        };
    }

    /// <summary>
    /// EventHandlerHelper class provides a helper method to set and get event handlers using actions.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class EventHandlerHelper
    {
        private static Dictionary<Action, Delegate> s_actionHandlerMap = new Dictionary<Action, Delegate>();

        /// <summary>
        /// Sets the event handler for the given action.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of the event handler.</typeparam>
        /// <param name="handler">The event handler to set.</param>
        /// <param name="action">The action to associate with the event handler.</param>
        /// <returns>The event handler that was set.</returns>
        public static TEventHandler Set<TEventHandler>(TEventHandler handler, Action action) where TEventHandler : Delegate
        {
            s_actionHandlerMap[action] = handler;
            return handler;
        }

        /// <summary>
        /// Gets the event handler associated with the given action and removes the association.
        /// </summary>
        /// <typeparam name="TEventHandler">The type of the event handler.</typeparam>
        /// <param name="action">The action to get the event handler for.</param>
        /// <returns>The event handler associated with the given action, or null if no association exists.</returns>
        public static TEventHandler Get<TEventHandler>(Action action) where TEventHandler : Delegate
        {
            if (!s_actionHandlerMap.ContainsKey(action))
                return null;

            var handler = (TEventHandler)s_actionHandlerMap[action];
            s_actionHandlerMap.Remove(action);
            return handler;
        }
    }
}
