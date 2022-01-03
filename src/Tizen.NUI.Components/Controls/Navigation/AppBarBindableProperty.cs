using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class AppBar
    {
        /// <summary>
        /// NavigationContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty NavigationContentProperty = BindableProperty.Create(nameof(NavigationContent), typeof(View), typeof(AppBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalNavigationContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AppBar)bindable;
            return instance.InternalNavigationContent;
        });

        /// <summary>
        /// TitleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(AppBar), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalTitle = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AppBar)bindable;
            return instance.InternalTitle;
        });

        /// <summary>
        /// TitleContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleContentProperty = BindableProperty.Create(nameof(TitleContent), typeof(View), typeof(AppBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalTitleContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AppBar)bindable;
            return instance.InternalTitleContent;
        });

        /// <summary>
        /// ActionContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionContentProperty = BindableProperty.Create(nameof(ActionContent), typeof(View), typeof(AppBar), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalActionContent = newValue as View;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AppBar)bindable;
            return instance.InternalActionContent;
        });

        /// <summary>
        /// AutoNavigationContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoNavigationContentProperty = BindableProperty.Create(nameof(AutoNavigationContent), typeof(bool), typeof(AppBar), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalAutoNavigationContent = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (AppBar)bindable;
            return instance.InternalAutoNavigationContent;
        });
    }
}
