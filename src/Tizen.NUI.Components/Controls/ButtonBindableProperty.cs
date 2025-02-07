using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    public partial class Button
    {
        /// <summary>
        /// TextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty;

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty;

        /// <summary>
        /// PointSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty;

        /// <summary>
        /// FontFamilyProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty;

        /// <summary>
        /// TextColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty;

        /// <summary>
        /// TextAlignmentProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextAlignmentProperty;

        /// <summary>
        /// IconURLProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLProperty;

        /// <summary>
        /// IconSizeProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconSizeProperty;

        /// <summary>
        /// TextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty;

        /// <summary>
        /// TranslatableTextSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty;

        /// <summary>
        /// TextColorSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty;

        /// <summary>
        /// PointSizeSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty;

        /// <summary>
        /// IconURLSelectorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconURLSelectorProperty;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty;

        /// <summary> The bindable property of ItemAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemAlignmentProperty;

        /// <summary> The bindable property of ItemHorizontalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemHorizontalAlignmentProperty;

        /// <summary> The bindable property of ItemVerticalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemVerticalAlignmentProperty;

        /// <summary> The bindable property of ItemSpacing. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemSpacingProperty;

        static Button()
        {
            if (NUIApplication.IsUsingXaml)
            {
                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
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

                TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
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

                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Button), default(float), propertyChanged: (bindable, oldValue, newValue) =>
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

                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
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

                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
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

                TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(Button), default(HorizontalAlignment), propertyChanged: (bindable, oldValue, newValue) =>
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

                IconURLProperty = BindableProperty.Create(nameof(IconURL), typeof(string), typeof(Button), default(string), propertyChanged: (bindable, oldValue, newValue) =>
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

                IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(Size), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
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

                TextSelectorProperty = BindableProperty.Create(nameof(TextSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.InternalTextSelector = newValue as StringSelector;
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalTextSelector;
                });

                TranslatableTextSelectorProperty = BindableProperty.Create(nameof(TranslatableTextSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.InternalTranslatableTextSelector = newValue as StringSelector;
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalTranslatableTextSelector;
                });

                TextColorSelectorProperty = BindableProperty.Create(nameof(TextColorSelector), typeof(ColorSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.InternalTextColorSelector = newValue as ColorSelector;
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalTextColorSelector;
                });

                PointSizeSelectorProperty = BindableProperty.Create(nameof(PointSizeSelector), typeof(FloatSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.InternalPointSizeSelector = newValue as FloatSelector;
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalPointSizeSelector;
                });

                IconURLSelectorProperty = BindableProperty.Create(nameof(IconURLSelector), typeof(StringSelector), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.InternalIconURLSelector = newValue as StringSelector;
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalIconURLSelector;
                });

                IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(IconOrientation?), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    var newIconOrientation = (IconOrientation?)newValue;
                    if (instance.iconRelativeOrientation != newIconOrientation)
                    {
                        instance.iconRelativeOrientation = newIconOrientation;
                        instance.LayoutItems();
                    }
                },
                defaultValueCreator: (bindable) => ((Button)bindable).iconRelativeOrientation
                );

                IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Button), false, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    if (newValue != null)
                    {
                        instance.InternalIsSelected = (bool)newValue;
                    }
                },
                defaultValueCreator: (bindable) =>
                {
                    var instance = (Button)bindable;
                    return instance.InternalIsSelected;
                });

                IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    if (newValue != null)
                    {
                        bool newSelectable = (bool)newValue;
                        if (instance.isSelectable != newSelectable)
                        {
                            instance.isSelectable = newSelectable;
                            instance.UpdateState();
                        }
                    }
                },
                defaultValueCreator: (bindable) => ((Button)bindable).isSelectable);

                IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    if (instance.buttonIcon == null)
                    {
                        return;
                    }
                    instance.buttonIcon.Padding = (Extents)newValue;
                },
                defaultValueCreator: (bindable) => ((Button)bindable).buttonIcon?.Padding);

                TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    if (instance.buttonText == null)
                    {
                        return;
                    }
                    instance.buttonText.Padding = (Extents)newValue;
                },
                defaultValueCreator: (bindable) => ((Button)bindable).buttonText?.Padding);

                ItemAlignmentProperty = BindableProperty.Create(nameof(ItemAlignment), typeof(LinearLayout.Alignment), typeof(Button), LinearLayout.Alignment.Center, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    var newAlignment = (LinearLayout.Alignment)newValue;
                    instance.InternalItemAlignment = newAlignment;
                },
                defaultValueCreator: (bindable) => ((Button)bindable).itemAlignment);

                ItemHorizontalAlignmentProperty = BindableProperty.Create(nameof(ItemHorizontalAlignment), typeof(HorizontalAlignment), typeof(Button), HorizontalAlignment.Center, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    var newHorizontalAlignment = (HorizontalAlignment)newValue;

                    if (instance.itemHorizontalAlignment != newHorizontalAlignment)
                    {
                        instance.itemHorizontalAlignment = newHorizontalAlignment;
                        instance.LayoutItems();
                    }
                },
                defaultValueCreator: (bindable) => ((Button)bindable).itemHorizontalAlignment);

                ItemVerticalAlignmentProperty = BindableProperty.Create(nameof(ItemVerticalAlignment), typeof(VerticalAlignment), typeof(Button), VerticalAlignment.Center, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    var newVerticalAlignment = (VerticalAlignment)newValue;

                    if (instance.itemVerticalAlignment != newVerticalAlignment)
                    {
                        instance.itemVerticalAlignment = newVerticalAlignment;
                        instance.LayoutItems();
                    }
                },
                defaultValueCreator: (bindable) => ((Button)bindable).itemVerticalAlignment);

                ItemSpacingProperty = BindableProperty.Create(nameof(ItemSpacing), typeof(Size2D), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
                {
                    var instance = (Button)bindable;
                    instance.itemSpacing = (Size2D)newValue;
                    instance.UpdateSizeAndSpacing();
                },
                defaultValueCreator: (bindable) => ((Button)bindable).itemSpacing);
            }
        }
    }
}
