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
        public static readonly BindableProperty TextArrayProperty = BindableProperty.Create(nameof(TextArray), typeof(string[]), typeof(Toast), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextArray = newValue as string[];
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextArray;
        });

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Toast), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalPointSize = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalPointSize;
        });

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Toast), default(string), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalFontFamily = newValue as string;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalFontFamily;
        });

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Toast), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextColor = newValue as Color;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextColor;
        });

        /// <summary>
        /// TextAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(Toast), default(HorizontalAlignment), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextAlignment = (HorizontalAlignment)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextAlignment;
        });

        /// <summary>
        /// TextPaddingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(Toast), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextPadding = newValue as Extents;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextPadding;
        });

        /// <summary>
        /// TextLineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextLineHeightProperty = BindableProperty.Create(nameof(TextLineHeight), typeof(uint), typeof(Toast), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextLineHeight = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextLineHeight;
        });

        /// <summary>
        /// TextLineSpaceProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextLineSpaceProperty = BindableProperty.Create(nameof(TextLineSpace), typeof(uint), typeof(Toast), default(uint), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Toast)bindable;
            if (newValue != null)
            {
                instance.InternalTextLineSpace = (uint)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Toast)bindable;
            return instance.InternalTextLineSpace;
        });

    }
}
