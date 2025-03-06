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
        public static readonly BindableProperty AppBarProperty = null;
        internal static void SetInternalAppBarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ContentPage)bindable;
                instance.InternalAppBar = newValue as AppBar;
            }
        }
        internal static object GetInternalAppBarProperty(BindableObject bindable)
        {
            var instance = (ContentPage)bindable;
            return instance.InternalAppBar;
        }

        /// <summary>
        /// ContentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ContentProperty = null;
        internal static void SetInternalContentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (ContentPage)bindable;
                instance.InternalContent = newValue as View;
            }
        }
        internal static object GetInternalContentProperty(BindableObject bindable)
        {
            var instance = (ContentPage)bindable;
            return instance.InternalContent;
        }
    }
}
