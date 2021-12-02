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
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalText;
        });

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatableText = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTranslatableText;
        });

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalPointSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalPointSize;
        });

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalFontFamily = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalFontFamily;
        });

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTextColor;
        });

        /// <summary>
        /// TextAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(Button), default(HorizontalAlignment), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalTextAlignment = (HorizontalAlignment)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTextAlignment;
        });

        /// <summary>
        /// IconURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLProperty = BindableProperty.Create(nameof(IconURL), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalIconURL = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalIconURL;
        });

        /// <summary>
        /// IconSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(Size), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.InternalIconSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalIconSize;
        });

        /// <summary>
        /// TextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = BindableProperty.Create(nameof(TextSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            instance.InternalTextSelector = newValue as StringSelector;
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTextSelector;
        });

        /// <summary>
        /// TranslatableTextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create(nameof(TranslatableTextSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            instance.InternalTranslatableTextSelector = newValue as StringSelector;
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTranslatableTextSelector;
        });

        /// <summary>
        /// TextColorSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create(nameof(TextColorSelector), typeof(ColorSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            instance.InternalTextColorSelector = newValue as ColorSelector;
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalTextColorSelector;
        });

        /// <summary>
        /// PointSizeSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create(nameof(PointSizeSelector), typeof(FloatSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            instance.InternalPointSizeSelector = newValue as FloatSelector;
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalPointSizeSelector;
        });

        /// <summary>
        /// IconURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLSelectorProperty = BindableProperty.Create(nameof(IconURLSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            instance.InternalIconURLSelector = newValue as StringSelector;
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.InternalIconURLSelector;
        });
    }
}
