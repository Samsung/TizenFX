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
        public static readonly BindableProperty TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(Popup), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleText;
        });

        /// <summary>
        /// TitlePointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitlePointSizeProperty = BindableProperty.Create(nameof(TitlePointSize), typeof(float), typeof(Popup), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitlePointSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitlePointSize;
        });

        /// <summary>
        /// TitleTextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextColorProperty = BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextColor;
        });

        /// <summary>
        /// TitleTextHorizontalAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextHorizontalAlignmentProperty = BindableProperty.Create(nameof(TitleTextHorizontalAlignment), typeof(HorizontalAlignment), typeof(Popup), default(HorizontalAlignment), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextHorizontalAlignment = (HorizontalAlignment)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextHorizontalAlignment;
        });

        /// <summary>
        /// TitleTextPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleTextPositionProperty = BindableProperty.Create(nameof(TitleTextPosition), typeof(Position), typeof(Popup), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleTextPosition = newValue as Position;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleTextPosition;
        });

        /// <summary>
        /// TitleHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TitleHeightProperty = BindableProperty.Create(nameof(TitleHeight), typeof(int), typeof(Popup), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalTitleHeight = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalTitleHeight;
        });

        /// <summary>
        /// ButtonCountProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonCountProperty = BindableProperty.Create(nameof(ButtonCount), typeof(int), typeof(Popup), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                instance.InternalButtonCount = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.InternalButtonCount;
        });
    }
}
