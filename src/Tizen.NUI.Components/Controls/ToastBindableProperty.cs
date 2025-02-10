using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Toast
    {
        /// <summary>
        /// TextArrayProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextArrayProperty = null;
        internal static void SetInternalTextArrayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextArray = newValue as string[];
            }
        }
        internal static object GetInternalTextArrayProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextArray;
        }

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalPointSize = (float)newValue;
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalPointSize;
        }

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalFontFamily = newValue as string;
            }
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalFontFamily;
        }

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = newValue as Color;
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextColor;
        }

        /// <summary>
        /// TextAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextAlignmentProperty = null;
        internal static void SetInternalTextAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextAlignment = (HorizontalAlignment)newValue;
            }
        }
        internal static object GetInternalTextAlignmentProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextAlignment;
        }

        /// <summary>
        /// TextPaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = null;
        internal static void SetInternalTextPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextPadding = newValue as Extents;
            }
        }
        internal static object GetInternalTextPaddingProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextPadding;
        }

        /// <summary>
        /// TextLineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextLineHeightProperty = null;
        internal static void SetInternalTextLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextLineHeight = (uint)newValue;
            }
        }
        internal static object GetInternalTextLineHeightProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextLineHeight;
        }

        /// <summary>
        /// TextLineSpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextLineSpaceProperty = null;
        internal static void SetInternalTextLineSpaceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextLineSpace = (uint)newValue;
            }
        }
        internal static object GetInternalTextLineSpaceProperty(BindableObject bindable)
        {
            var instance = (Toast)bindable;
            return instance.InternalTextLineSpace;
        }
    }
}
