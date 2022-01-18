using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DialogPage
    {
        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(DialogPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DialogPage)bindable;
            if (newValue != null)
            {
                instance.InternalContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DialogPage)bindable;
            return instance.InternalContent;
        });

        /// <summary>
        /// EnableScrimProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrimProperty = BindableProperty.Create(nameof(EnableScrim), typeof(bool), typeof(DialogPage), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DialogPage)bindable;
            if (newValue != null)
            {
                instance.InternalEnableScrim = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DialogPage)bindable;
            return instance.InternalEnableScrim;
        });

        /// <summary>
        /// EnableDismissOnScrimProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableDismissOnScrimProperty = BindableProperty.Create(nameof(EnableDismissOnScrim), typeof(bool), typeof(DialogPage), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DialogPage)bindable;
            if (newValue != null)
            {
                instance.InternalEnableDismissOnScrim = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DialogPage)bindable;
            return instance.InternalEnableDismissOnScrim;
        });

        /// <summary>
        /// ScrimColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrimColorProperty = BindableProperty.Create(nameof(ScrimColor), typeof(Color), typeof(DialogPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (DialogPage)bindable;
            if (newValue != null)
            {
                instance.InternalScrimColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (DialogPage)bindable;
            return instance.InternalScrimColor;
        });
    }
}
