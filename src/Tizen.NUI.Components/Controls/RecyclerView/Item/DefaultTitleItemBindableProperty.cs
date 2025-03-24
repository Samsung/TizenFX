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
            if (newValue != null)
            {
                var instance = (DefaultTitleItem)bindable;
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
            if (newValue != null)
            {
                var instance = (DefaultTitleItem)bindable;
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
