using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class ContentPage
    {
        /// <summary>
        /// AppBarProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AppBarProperty = BindableProperty.Create(nameof(AppBar), typeof(AppBar), typeof(ContentPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ContentPage)bindable;
            if (newValue != null)
            {
                instance.InternalAppBar = newValue as AppBar;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ContentPage)bindable;
            return instance.InternalAppBar;
        });

        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = BindableProperty.Create(nameof(Content), typeof(View), typeof(ContentPage), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (ContentPage)bindable;
            if (newValue != null)
            {
                instance.InternalContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (ContentPage)bindable;
            return instance.InternalContent;
        });

    }
}
