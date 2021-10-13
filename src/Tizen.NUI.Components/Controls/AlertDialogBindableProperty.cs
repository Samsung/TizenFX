using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class AlertDialog
    {
        /// <summary>
        /// TitleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AlertDialog), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalTitle = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitle;
        });

        /// <summary>
        /// TitleContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleContentProperty = BindableProperty.Create(nameof(TitleContent), typeof(View), typeof(AlertDialog), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalTitleContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalTitleContent;
        });

        /// <summary>
        /// MessageProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MessageProperty = BindableProperty.Create(nameof(Message), typeof(string), typeof(AlertDialog), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalMessage = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalMessage;
        });

        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(AlertDialog), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalContent;
        });

        /// <summary>
        /// ActionContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionContentProperty = BindableProperty.Create(nameof(ActionContent), typeof(View), typeof(AlertDialog), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AlertDialog)bindable;
            if (newValue != null)
            {
                instance.InternalActionContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AlertDialog)bindable;
            return instance.InternalActionContent;
        });
    }
}
