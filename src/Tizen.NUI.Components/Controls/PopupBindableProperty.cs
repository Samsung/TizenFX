using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Popup
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonHeightProperty = null;
        internal static void SetInternalButtonHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.SetInternalButtonHeight((int)newValue);
            }
        }
        internal static object GetInternalButtonHeightProperty(BindableObject bindable)
        {
            var instance = (Popup)bindable;
            return instance.GetInternalButtonHeight();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextPointSizeProperty = null;
        internal static void SetInternalButtonTextPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemPointSize = (float)newValue;
            }
        }
        internal static object GetInternalButtonTextPointSizeProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemPointSize;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonFontFamilyProperty = null;
        internal static void SetInternalButtonFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemFontFamily = (string)newValue;
            }
        }
        internal static object GetInternalButtonFontFamilyProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemFontFamily;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextColorProperty = null;
        internal static void SetInternalButtonTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemTextColor = (Color)newValue;
            }
        }
        internal static object GetInternalButtonTextColorProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemTextColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonOverLayBackgroundColorSelectorProperty = null;
        internal static void SetInternalButtonOverLayBackgroundColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.OverLayBackgroundColorSelector = (Selector<Color>)newValue;
            }
        }
        internal static object GetInternalButtonOverLayBackgroundColorSelectorProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.OverLayBackgroundColorSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextAlignmentProperty = null;
        internal static void SetInternalButtonTextAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemTextAlignment = (HorizontalAlignment)newValue;
            }
        }
        internal static object GetInternalButtonTextAlignmentProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemTextAlignment;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonBackgroundProperty = null;
        internal static void SetInternalButtonBackgroundProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemBackgroundImageUrl = (string)newValue;
            }
        }
        internal static object GetInternalButtonBackgroundProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemBackgroundImageUrl;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonBackgroundBorderProperty = null;
        internal static void SetInternalButtonBackgroundBorderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
                instance.btGroup.ItemBackgroundBorder = (Rectangle)newValue;
            }
        }
        internal static object GetInternalButtonBackgroundBorderProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemBackgroundBorder;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonImageShadowProperty = null;
        internal static void SetInternalButtonImageShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Popup)bindable;
            instance.btGroup.ItemImageShadow = new ImageShadow((ImageShadow)newValue);
        }
        internal static object GetInternalButtonImageShadowProperty(BindableObject bindable)
        {
            return ((Popup)bindable).btGroup.ItemImageShadow;
        }

        /// <summary>
        /// TitleTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextProperty = null;
        internal static void SetInternalTitleTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
            if (newValue != null)
            {
                var instance = (Popup)bindable;
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
