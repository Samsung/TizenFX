using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Button
    {
        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalText;
        }

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = null;
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatableText = newValue as string;
            }
        }
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTranslatableText;
        }

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalPointSize = (float)newValue;
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalPointSize;
        }

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalFontFamily = newValue as string;
            }
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalFontFamily;
        }

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = newValue as Color;
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTextColor;
        }

        /// <summary>
        /// TextAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextAlignmentProperty = null;
        internal static void SetInternalTextAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTextAlignment = (HorizontalAlignment)newValue;
            }
        }
        internal static object GetInternalTextAlignmentProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTextAlignment;
        }

        /// <summary>
        /// IconURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLProperty = null;
        internal static void SetInternalIconURLProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalIconURL = newValue as string;
            }
        }
        internal static object GetInternalIconURLProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalIconURL;
        }

        /// <summary>
        /// IconSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconSizeProperty = null;
        internal static void SetInternalIconSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalIconSize = newValue as Size;
            }
        }
        internal static object GetInternalIconSizeProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalIconSize;
        }

        /// <summary>
        /// TextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = null;
        internal static void SetInternalTextSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.InternalTextSelector = newValue as StringSelector;
        }
        internal static object GetInternalTextSelectorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTextSelector;
        }

        /// <summary>
        /// TranslatableTextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty = null;
        internal static void SetInternalTranslatableTextSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.InternalTranslatableTextSelector = newValue as StringSelector;
        }
        internal static object GetInternalTranslatableTextSelectorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTranslatableTextSelector;
        }

        /// <summary>
        /// TextColorSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = null;
        internal static void SetInternalTextColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.InternalTextColorSelector = newValue as ColorSelector;
        }
        internal static object GetInternalTextColorSelectorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalTextColorSelector;
        }

        /// <summary>
        /// PointSizeSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = null;
        internal static void SetInternalPointSizeSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.InternalPointSizeSelector = newValue as FloatSelector;
        }
        internal static object GetInternalPointSizeSelectorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalPointSizeSelector;
        }

        /// <summary>
        /// IconURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLSelectorProperty = null;
        internal static void SetInternalIconURLSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.InternalIconURLSelector = newValue as StringSelector;
        }
        internal static object GetInternalIconURLSelectorProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.InternalIconURLSelector;
        }
    }
}
