using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class DefaultLinearItem
    {
        /// <summary>
        /// IconProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconProperty = null;
        internal static void SetInternalIconProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalIcon = newValue as View;
            }
        }
        internal static object GetInternalIconProperty(BindableObject bindable)
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalIcon;
        }

        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalText;
        }

        /// <summary>
        /// SubTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SubTextProperty = null;
        internal static void SetInternalSubTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalSubText = newValue as string;
            }
        }
        internal static object GetInternalSubTextProperty(BindableObject bindable)
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalSubText;
        }

        /// <summary>
        /// ExtraProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExtraProperty = null;
        internal static void SetInternalExtraProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (DefaultLinearItem)bindable;
            if (newValue != null)
            {
                instance.InternalExtra = newValue as View;
            }
        }
        internal static object GetInternalExtraProperty(BindableObject bindable)
        {
            var instance = (DefaultLinearItem)bindable;
            return instance.InternalExtra;
        }
    }
}
