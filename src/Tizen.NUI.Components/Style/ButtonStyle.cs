/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System.ComponentModel;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Components.Extension;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ButtonStyle is a class which saves Button's ux data.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class ButtonStyle : ControlStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = null;
        internal static void SetInternalIsSelectableProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.isSelectable = (bool?)newValue;
        }
        internal static object GetInternalIsSelectableProperty(BindableObject bindable)
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.isSelectable;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = null;
        internal static void SetInternalIsSelectedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.isSelected = (bool?)newValue;
        }
        internal static object GetInternalIsSelectedProperty(BindableObject bindable)
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.isSelected;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty = null;
        internal static void SetInternalIconRelativeOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var buttonStyle = (ButtonStyle)bindable;
            buttonStyle.iconRelativeOrientation = (Button.IconOrientation?)newValue;
        }
        internal static object GetInternalIconRelativeOrientationProperty(BindableObject bindable)
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.iconRelativeOrientation;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty = null;
        internal static void SetInternalIconPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).iconPadding = null == newValue ? null : new Extents((Extents)newValue);
        }
        internal static object GetInternalIconPaddingProperty(BindableObject bindable)
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.iconPadding;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = null;
        internal static void SetInternalTextPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).textPadding = null == newValue ? null : new Extents((Extents)newValue);
        }
        internal static object GetInternalTextPaddingProperty(BindableObject bindable)
        {
            var buttonStyle = (ButtonStyle)bindable;
            return buttonStyle.textPadding;
        }

        /// <summary> The bindable property of ItemAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemAlignmentProperty = null;
        internal static void SetInternalItemAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).itemAlignment = (LinearLayout.Alignment?)newValue;

            switch (newValue)
            {
                case LinearLayout.Alignment.Begin:
                    ((ButtonStyle)bindable).itemHorizontalAlignment = HorizontalAlignment.Begin;
                    break;
                case LinearLayout.Alignment.End:
                    ((ButtonStyle)bindable).itemHorizontalAlignment = HorizontalAlignment.End;
                    break;
                case LinearLayout.Alignment.CenterHorizontal:
                    ((ButtonStyle)bindable).itemHorizontalAlignment = HorizontalAlignment.Center;
                    break;
                case LinearLayout.Alignment.Top:
                    ((ButtonStyle)bindable).itemVerticalAlignment = VerticalAlignment.Top;
                    break;
                case LinearLayout.Alignment.Bottom:
                    ((ButtonStyle)bindable).itemVerticalAlignment = VerticalAlignment.Bottom;
                    break;
                case LinearLayout.Alignment.CenterVertical:
                    ((ButtonStyle)bindable).itemVerticalAlignment = VerticalAlignment.Center;
                    break;
                case LinearLayout.Alignment.Center:
                    ((ButtonStyle)bindable).itemHorizontalAlignment = HorizontalAlignment.Center;
                    ((ButtonStyle)bindable).itemVerticalAlignment = VerticalAlignment.Center;
                    break;
                default:
                    break;
            }
        }
        internal static object GetInternalItemAlignmentProperty(BindableObject bindable)
        {
            return ((ButtonStyle)bindable).itemAlignment;
        }

        /// <summary> The bindable property of ItemHorizontalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemHorizontalAlignmentProperty = null;
        internal static void SetInternalItemHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).itemHorizontalAlignment = (HorizontalAlignment?)newValue;
        }
        internal static object GetInternalItemHorizontalAlignmentProperty(BindableObject bindable)
        {
            return ((ButtonStyle)bindable).itemHorizontalAlignment;
        }

        /// <summary> The bindable property of ItemVerticalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemVerticalAlignmentProperty = null;
        internal static void SetInternalItemVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).itemVerticalAlignment = (VerticalAlignment?)newValue;
        }
        internal static object GetInternalItemVerticalAlignmentProperty(BindableObject bindable)
        {
            return ((ButtonStyle)bindable).itemVerticalAlignment;
        }

        /// <summary> The bindable property of ItemSpacing. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemSpacingProperty = null;
        internal static void SetInternalItemSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((ButtonStyle)bindable).itemSpacing = (Size2D)newValue;
        }
        internal static object GetInternalItemSpacingProperty(BindableObject bindable)
        {
            return ((ButtonStyle)bindable).itemSpacing;
        }

        private bool? isSelectable;
        private bool? isSelected;
        private Button.IconOrientation? iconRelativeOrientation;
        private Extents iconPadding;
        private Extents textPadding;
        private Size2D itemSpacing;
        private LinearLayout.Alignment? itemAlignment;
        private HorizontalAlignment? itemHorizontalAlignment;
        private VerticalAlignment? itemVerticalAlignment;

        static ButtonStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalIsSelectableProperty, defaultValueCreator: GetInternalIsSelectableProperty);
                IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalIsSelectedProperty, defaultValueCreator: GetInternalIsSelectedProperty);
                IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(Button.IconOrientation?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalIconRelativeOrientationProperty, defaultValueCreator: GetInternalIconRelativeOrientationProperty);
                IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalIconPaddingProperty, defaultValueCreator: GetInternalIconPaddingProperty);
                TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalTextPaddingProperty, defaultValueCreator: GetInternalTextPaddingProperty);
                ItemAlignmentProperty = BindableProperty.Create(nameof(ItemAlignment), typeof(LinearLayout.Alignment?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalItemAlignmentProperty, defaultValueCreator: GetInternalItemAlignmentProperty);
                ItemHorizontalAlignmentProperty = BindableProperty.Create(nameof(ItemHorizontalAlignment), typeof(HorizontalAlignment?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalItemHorizontalAlignmentProperty, defaultValueCreator: GetInternalItemHorizontalAlignmentProperty);
                ItemVerticalAlignmentProperty = BindableProperty.Create(nameof(ItemVerticalAlignment), typeof(VerticalAlignment?), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalItemVerticalAlignmentProperty, defaultValueCreator: GetInternalItemVerticalAlignmentProperty);
                ItemSpacingProperty = BindableProperty.Create(nameof(ItemSpacing), typeof(Size2D), typeof(ButtonStyle), null,
                    propertyChanged: SetInternalItemSpacingProperty, defaultValueCreator: GetInternalItemSpacingProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a ButtonStyle.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a ButtonStyle with style.
        /// </summary>
        /// <param name="style">Create ButtonStyle by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle(ButtonStyle style) : base(style)
        {
        }

        /// <summary>
        /// Overlay image's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Overlay { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Text's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabelStyle Text { get; set; } = new TextLabelStyle();

        /// <summary>
        /// Icon's Style.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageViewStyle Icon { get; set; } = new ImageViewStyle();

        /// <summary>
        /// Flag to decide Button can be selected or not.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsSelectable
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(IsSelectableProperty);
                }
                else
                {
                    return (bool)GetInternalIsSelectableProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectableProperty, value);
                }
                else
                {
                    SetInternalIsSelectableProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Flag to decide selected state in Button.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsSelected
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(IsSelectedProperty);
                }
                else
                {
                    return (bool?)GetInternalIsSelectedProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IsSelectedProperty, value);
                }
                else
                {
                    SetInternalIsSelectedProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Flag to decide button can be selected or not.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new bool? IsEnabled
        {
            get => (bool?)base.IsEnabled;
            set
            {
                base.IsEnabled = value;
            }
        }

        /// <summary>
        /// Icon relative orientation.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Button.IconOrientation? IconRelativeOrientation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Button.IconOrientation?)GetValue(IconRelativeOrientationProperty);
                }
                else
                {
                    return (Button.IconOrientation?)GetInternalIconRelativeOrientationProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconRelativeOrientationProperty, value);
                }
                else
                {
                    SetInternalIconRelativeOrientationProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Icon padding in Button. It is shortcut of Icon.Padding.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents IconPadding
        {
            // TODO Fixme
            // When there are icon and text, the linear layout does not count padding.
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return ((Extents)GetValue(IconPaddingProperty)) ?? (iconPadding = new Extents());
                }
                else
                {
                    return (Extents)GetInternalIconPaddingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconPaddingProperty, value);
                }
                else
                {
                    SetInternalIconPaddingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// Text padding in Button. It is shortcut of Text.Padding.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TextPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return ((Extents)GetValue(TextPaddingProperty)) ?? (textPadding = new Extents());
                }
                else
                {
                    return ((Extents)GetInternalTextPaddingProperty(this)) ?? (textPadding = new Extents());
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextPaddingProperty, value);
                }
                else
                {
                    SetInternalTextPaddingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The item (text or icon or both) alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LinearLayout.Alignment? ItemAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (LinearLayout.Alignment?)GetValue(ItemAlignmentProperty);
                }
                else
                {
                    return (LinearLayout.Alignment)GetInternalItemAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemAlignmentProperty, value);
                }
                else
                {
                    SetInternalItemAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The item (text or icon or both) horizontal alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? ItemHorizontalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment?)GetValue(ItemHorizontalAlignmentProperty);
                }
                else
                {
                    return (HorizontalAlignment?)GetInternalItemHorizontalAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemHorizontalAlignmentProperty, value);
                }
                else
                {
                    SetInternalItemHorizontalAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The item (text or icon or both) vertical alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? ItemVerticalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment?)GetValue(ItemVerticalAlignmentProperty);
                }
                else
                {
                    return (VerticalAlignment?)GetInternalItemVerticalAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemVerticalAlignmentProperty, value);
                }
                else
                {
                    SetInternalItemVerticalAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The space between icon and text.
        /// The value is applied when there exist icon and text both.
        /// The width value is used when the items are arranged horizontally. Otherwise, the height value is used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ItemSpacing
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Size2D)GetValue(ItemSpacingProperty);
                }
                else
                {
                    return (Size2D)GetInternalItemSpacingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ItemSpacingProperty, value);
                }
                else
                {
                    SetInternalItemSpacingProperty(this, null, value);
                }
            }
        }

        /// <inheritdoc/>
        /// <since_tizen> 8 </since_tizen>
        public override void CopyFrom(BindableObject bindableObject)
        {
            base.CopyFrom(bindableObject);

            if (bindableObject is ButtonStyle buttonStyle)
            {
                Overlay.CopyFrom(buttonStyle.Overlay);
                Text.CopyFrom(buttonStyle.Text);
                Icon.CopyFrom(buttonStyle.Icon);
            }
        }

        /// <summary>
        /// Create corresponding ButtonExtension.
        /// This is to be called by a Button.
        /// You may override this function to customize button's behavior.
        /// </summary>
        /// <return>The new ButtonExtension instance.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ButtonExtension CreateExtension()
        {
            return null;
        }

        /// <summary>
        /// Dispose ButtonStyle and all children on it.
        /// </summary>
        /// <param name="disposing">true in order to free managed objects</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                iconPadding?.Dispose();
                textPadding?.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
