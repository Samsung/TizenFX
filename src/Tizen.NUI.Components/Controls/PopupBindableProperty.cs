using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Popup
    {
        /// <summary>
        /// TitleTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextProperty = null;
        internal static void SetInternalTitleTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleText = newValue as string;
            }
        }
        internal static object GetInternalTitleTextProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleText;
        }

        /// <summary>
        /// TitlePointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitlePointSizeProperty = null;
        internal static void SetInternalTitlePointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitlePointSize = (float)newValue;
            }
        }
        internal static object GetInternalTitlePointSizeProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitlePointSize;
        }

        /// <summary>
        /// TitleTextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextColorProperty = null;
        internal static void SetInternalTitleTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextColor = newValue as Color;
            }
        }
        internal static object GetInternalTitleTextColorProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextColor;
        }

        /// <summary>
        /// TitleTextHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextHorizontalAlignmentProperty = null;
        internal static void SetInternalTitleTextHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextHorizontalAlignment = (HorizontalAlignment)newValue;
            }
        }
        internal static object GetInternalTitleTextHorizontalAlignmentProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextHorizontalAlignment;
        }

        /// <summary>
        /// TitleTextPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextPositionProperty = null;
        internal static void SetInternalTitleTextPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextPosition = newValue as Position;
            }
        }
        internal static object GetInternalTitleTextPositionProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextPosition;
        }

        /// <summary>
        /// TitleHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleHeightProperty = null;
        internal static void SetInternalTitleHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleHeight = (int)newValue;
            }
        }
        internal static object GetInternalTitleHeightProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleHeight;
        }

        /// <summary>
        /// ButtonCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonCountProperty = null;
        internal static void SetInternalButtonCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalButtonCount = (int)newValue;
            }
        }
        internal static object GetInternalButtonCountProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.InternalButtonCount;
        }
    }
}
