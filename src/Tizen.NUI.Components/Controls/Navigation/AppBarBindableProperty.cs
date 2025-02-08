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
        public static readonly BindableProperty NavigationContentProperty = null;
        internal static void SetInternalNavigationContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalNavigationContent = newValue as View;
            }
        }
        internal static object GetInternalNavigationContentProperty(BindableObject bindable)
        {
            var instance = (AppBar)bindable;
            return instance.InternalNavigationContent;
        }

        /// <summary>
        /// TitleProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleProperty = null;
        internal static void SetInternalTitleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalTitle = newValue as string;
            }
        }
        internal static object GetInternalTitleProperty(BindableObject bindable)
        {
            var instance = (AppBar)bindable;
            return instance.InternalTitle;
        }

        /// <summary>
        /// TitleContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleContentProperty = null;
        internal static void SetInternalTitleContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalTitleContent = newValue as View;
            }
        }
        internal static object GetInternalTitleContentProperty(BindableObject bindable)
        {
            var instance = (AppBar)bindable;
            return instance.InternalTitleContent;
        }

        /// <summary>
        /// ActionContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ActionContentProperty = null;
        internal static void SetInternalActionContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalActionContent = newValue as View;
            }
        }
        internal static object GetInternalActionContentProperty(BindableObject bindable)
        {
            var instance = (AppBar)bindable;
            return instance.InternalActionContent;
        }

        /// <summary>
        /// AutoNavigationContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoNavigationContentProperty = null;
        internal static void SetInternalAutoNavigationContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (AppBar)bindable;
            if (newValue != null)
            {
                instance.InternalAutoNavigationContent = (bool)newValue;
            }
        }
        internal static object GetInternalAutoNavigationContentProperty(BindableObject bindable)
        {
            var instance = (AppBar)bindable;
            return instance.InternalAutoNavigationContent;
        }
    }
}
