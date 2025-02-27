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
        static readonly IStyleProperty IsSelectableProperty = new StyleProperty<Button, bool>((v, o) => v.IsSelectable = o);
        static readonly IStyleProperty IsSelectedProperty = new StyleProperty<Button, bool>((v, o) => v.IsSelected = o);
        static readonly IStyleProperty IconRelativeOrientationProperty = new StyleProperty<Button, Button.IconOrientation?>((v, o) => v.IconRelativeOrientation = o);
        static readonly IStyleProperty IconPaddingProperty = new StyleProperty<Button, Extents>((v, o) => v.IconPadding = o);
        static readonly IStyleProperty TextPaddingProperty = new StyleProperty<Button, Extents>((v, o) => v.TextPadding = o);
        static readonly IStyleProperty ItemAlignmentProperty = new StyleProperty<Button, LinearLayout.Alignment>((v, o) => v.ItemAlignment = o);
        static readonly IStyleProperty ItemHorizontalAlignmentProperty = new StyleProperty<Button, HorizontalAlignment>((v, o) => v.ItemHorizontalAlignment = o);
        static readonly IStyleProperty ItemVerticalAlignmentProperty = new StyleProperty<Button, VerticalAlignment>((v, o) => v.ItemVerticalAlignment = o);
        static readonly IStyleProperty ItemSpacingProperty = new StyleProperty<Button, Size2D>((v, o) => v.ItemSpacing = o);

        static ButtonStyle() { }

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
            get => (bool?)GetValue(IsSelectableProperty);
            set => SetValue(IsSelectableProperty, value);
        }

        /// <summary>
        /// Flag to decide selected state in Button.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool? IsSelected
        {
            get => (bool?)GetValue(IsSelectedProperty);
            set => SetValue(IsSelectedProperty, value);
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
            get => (Button.IconOrientation?)GetValue(IconRelativeOrientationProperty);
            set => SetValue(IconRelativeOrientationProperty, value);
        }

        /// <summary>
        /// Icon padding in Button. It is shortcut of Icon.Padding.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents IconPadding
        {
            // TODO Fixme
            // When there are icon and text, the linear layout does not count padding.
            get => GetOrCreateValue<Extents>(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Text padding in Button. It is shortcut of Text.Padding.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public Extents TextPadding
        {
            get => GetOrCreateValue<Extents>(TextPaddingProperty);
            set => SetValue(TextPaddingProperty, value);
        }

        /// <summary>
        /// The item (text or icon or both) alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LinearLayout.Alignment? ItemAlignment
        {
            get => (LinearLayout.Alignment?)GetValue(ItemAlignmentProperty);
            set => SetValue(ItemAlignmentProperty, value);
        }

        /// <summary>
        /// The item (text or icon or both) horizontal alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? ItemHorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(ItemHorizontalAlignmentProperty);
            set => SetValue(ItemHorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// The item (text or icon or both) vertical alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? ItemVerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(ItemVerticalAlignmentProperty);
            set => SetValue(ItemVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// The space between icon and text.
        /// The value is applied when there exist icon and text both.
        /// The width value is used when the items are arranged horizontally. Otherwise, the height value is used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size2D ItemSpacing
        {
            get => (Size2D)GetValue(ItemSpacingProperty);
            set => SetValue(ItemSpacingProperty, value);
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
    }
}
