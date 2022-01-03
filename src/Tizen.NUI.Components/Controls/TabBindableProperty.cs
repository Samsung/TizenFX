using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Tab
    {
        /// <summary>
        /// SelectedItemIndexProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectedItemIndexProperty = BindableProperty.Create(nameof(SelectedItemIndex), typeof(int), typeof(Tab), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalSelectedItemIndex = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalSelectedItemIndex;
        });

        /// <summary>
        /// UseTextNaturalSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UseTextNaturalSizeProperty = BindableProperty.Create(nameof(UseTextNaturalSize), typeof(bool), typeof(Tab), default(bool), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalUseTextNaturalSize = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalUseTextNaturalSize;
        });

        /// <summary>
        /// ItemSpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemSpaceProperty = BindableProperty.Create(nameof(ItemSpace), typeof(int), typeof(Tab), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalItemSpace = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalItemSpace;
        });

        /// <summary>
        /// SpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SpaceProperty = BindableProperty.Create(nameof(Space), typeof(Extents), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalSpace = newValue as Extents;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalSpace;
        });

        /// <summary>
        /// ItemPaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ItemPaddingProperty = BindableProperty.Create(nameof(ItemPadding), typeof(Extents), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalItemPadding = newValue as Extents;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalItemPadding;
        });

        /// <summary>
        /// UnderLineSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderLineSizeProperty = BindableProperty.Create(nameof(UnderLineSize), typeof(Size), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalUnderLineSize = newValue as Size;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalUnderLineSize;
        });

        /// <summary>
        /// UnderLineBackgroundColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderLineBackgroundColorProperty = BindableProperty.Create(nameof(UnderLineBackgroundColor), typeof(Color), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalUnderLineBackgroundColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalUnderLineBackgroundColor;
        });

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Tab), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalPointSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalPointSize;
        });

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Tab), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalFontFamily = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalFontFamily;
        });

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalTextColor;
        });

        /// <summary>
        /// TextColorSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create(nameof(TextColorSelector), typeof(ColorSelector), typeof(Tab), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tab)bindable;
            if (newValue != null)
            {
                instance.InternalTextColorSelector = newValue as ColorSelector;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tab)bindable;
            return instance.InternalTextColorSelector;
        });

    }
}
