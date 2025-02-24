using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultTitleItem
    {
        /// <summary>
        /// IconProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconProperty = null;
        internal static void SetInternalIconProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultTitleItem)bindable;
            if (newValue != null)
            {
                instance.InternalIcon = newValue as View;
            }
        }
        internal static object GetInternalIconProperty(BindableObject bindable)
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalIcon;
        }

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultTitleItem)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var instance = (DefaultTitleItem)bindable;
            return instance.InternalText;
        }
    }
}
