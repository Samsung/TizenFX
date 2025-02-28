﻿/*
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
using System;
using System.ComponentModel;
using System.Diagnostics;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using Tizen.NUI.Accessibility;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// ClickedEventArgs is a class to record button click event arguments which will sent to user.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class ClickedEventArgs : EventArgs
    {
    }

    /// <summary>
    /// SelectedChangedEventArgs is a class to record item selected arguments which will sent to user.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    public class SelectedChangedEventArgs : EventArgs
    {
        /// <summary> Selected state </summary>
        /// <since_tizen> 8 </since_tizen>
        public bool IsSelected { get; set; }
    }

    /// <summary>
    /// Button is one kind of common component, a button clearly describes what action will occur when the user selects it.
    /// Button may contain text or an icon.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public partial class Button : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty = null;
        internal static void SetInternalIconRelativeOrientationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            var newIconOrientation = (IconOrientation?)newValue;
            if (instance.iconRelativeOrientation != newIconOrientation)
            {
                instance.iconRelativeOrientation = newIconOrientation;
                instance.LayoutItems();
            }
        }
        internal static object GetInternalIconRelativeOrientationProperty(BindableObject bindable)
        {
            return ((Button)bindable).iconRelativeOrientation;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = null;
        internal static void SetInternalIsSelectedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                bool newSelected = (bool)newValue;
                if (instance.isSelected != newSelected)
                {
                    instance.isSelected = newSelected;

                    if (instance.isSelectable)
                    {
                        instance.UpdateState();
                    }

                    if (Accessibility.Accessibility.IsEnabled && instance.IsHighlighted)
                    {
                        instance.EmitAccessibilityStateChangedEvent(AccessibilityState.Checked, newSelected);
                    }
                }
            }
        }
        internal static object GetInternalIsSelectedProperty(BindableObject bindable)
        {
            var instance = (Button)bindable;
            return instance.isSelectable && instance.isSelected;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = null;
        internal static void SetInternalIsSelectableProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalIsSelectableProperty(BindableObject bindable)
        {
            return ((Button)bindable).isSelectable;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty = null;
        internal static void SetInternalIconPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (instance.buttonIcon == null)
            {
                return;
            }
            instance.buttonIcon.Padding = (Extents)newValue;
        }
        internal static object GetInternalIconPaddingProperty(BindableObject bindable)
        {
            return ((Button)bindable).buttonIcon?.Padding;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = null;
        internal static void SetInternalTextPaddingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            if (instance.buttonText == null)
            {
                return;
            }
            instance.buttonText.Padding = (Extents)newValue;
        }
        internal static object GetInternalTextPaddingProperty(BindableObject bindable)
        {
            return ((Button)bindable).buttonText?.Padding;
        }

        /// <summary> The bindable property of ItemAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemAlignmentProperty = null;
        internal static void SetInternalItemAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            var newAlignment = (LinearLayout.Alignment)newValue;

            if (instance.itemAlignment != newAlignment)
            {
                instance.itemAlignment = newAlignment;

                switch (newAlignment)
                {
                    case LinearLayout.Alignment.Begin:
                        instance.itemHorizontalAlignment = HorizontalAlignment.Begin;
                        break;
                    case LinearLayout.Alignment.End:
                        instance.itemHorizontalAlignment = HorizontalAlignment.End;
                        break;
                    case LinearLayout.Alignment.CenterHorizontal:
                        instance.itemHorizontalAlignment = HorizontalAlignment.Center;
                        break;
                    case LinearLayout.Alignment.Top:
                        instance.itemVerticalAlignment = VerticalAlignment.Top;
                        break;
                    case LinearLayout.Alignment.Bottom:
                        instance.itemVerticalAlignment = VerticalAlignment.Bottom;
                        break;
                    case LinearLayout.Alignment.CenterVertical:
                        instance.itemVerticalAlignment = VerticalAlignment.Center;
                        break;
                    case LinearLayout.Alignment.Center:
                        instance.itemHorizontalAlignment = HorizontalAlignment.Center;
                        instance.itemVerticalAlignment = VerticalAlignment.Center;
                        break;
                    default:
                        break;
                }

                instance.LayoutItems();
            }
        }
        internal static object GetInternalItemAlignmentProperty(BindableObject bindable)
        {
            return ((Button)bindable).itemAlignment;
        }

        /// <summary> The bindable property of ItemHorizontalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemHorizontalAlignmentProperty = null;
        internal static void SetInternalItemHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            var newHorizontalAlignment = (HorizontalAlignment)newValue;

            if (instance.itemHorizontalAlignment != newHorizontalAlignment)
            {
                instance.itemHorizontalAlignment = newHorizontalAlignment;
                instance.LayoutItems();
            }
        }
        internal static object GetInternalItemHorizontalAlignmentProperty(BindableObject bindable)
        {
            return ((Button)bindable).itemHorizontalAlignment;
        }

        /// <summary> The bindable property of ItemVerticalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemVerticalAlignmentProperty = null;
        internal static void SetInternalItemVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            var newVerticalAlignment = (VerticalAlignment)newValue;

            if (instance.itemVerticalAlignment != newVerticalAlignment)
            {
                instance.itemVerticalAlignment = newVerticalAlignment;
                instance.LayoutItems();
            }
        }
        internal static object GetInternalItemVerticalAlignmentProperty(BindableObject bindable)
        {
            return ((Button)bindable).itemVerticalAlignment;
        }

        /// <summary> The bindable property of ItemSpacing. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ItemSpacingProperty = null;
        internal static void SetInternalItemSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Button)bindable;
            instance.itemSpacing = (Size2D)newValue;
            instance.UpdateSizeAndSpacing();
        }
        internal static object GetInternalItemSpacingProperty(BindableObject bindable)
        {
            return ((Button)bindable).itemSpacing;
        }

        private IconOrientation? iconRelativeOrientation = IconOrientation.Left;
        private bool isSelected = false;
        private bool isSelectable = false;
        private Size2D itemSpacing;
        private LinearLayout.Alignment itemAlignment = LinearLayout.Alignment.Center;
        private HorizontalAlignment itemHorizontalAlignment = HorizontalAlignment.Center;
        private VerticalAlignment itemVerticalAlignment = VerticalAlignment.Center;

        static Button()
        {
            if (NUIApplication.IsUsingXaml)
            {
                IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(IconOrientation?), typeof(Button), null,
                    propertyChanged: SetInternalIconRelativeOrientationProperty, defaultValueCreator: GetInternalIconRelativeOrientationProperty);
                IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Button), false,
                    propertyChanged: SetInternalIsSelectedProperty, defaultValueCreator: GetInternalIsSelectedProperty);
                IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(Button), true,
                    propertyChanged: SetInternalIsSelectableProperty, defaultValueCreator: GetInternalIsSelectableProperty);
                IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(Button), null,
                    propertyChanged: SetInternalIconPaddingProperty, defaultValueCreator: GetInternalIconPaddingProperty);
                TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(Button), null,
                    propertyChanged: SetInternalTextPaddingProperty, defaultValueCreator: GetInternalTextPaddingProperty);
                ItemAlignmentProperty = BindableProperty.Create(nameof(ItemAlignment), typeof(LinearLayout.Alignment), typeof(Button), LinearLayout.Alignment.Center,
                    propertyChanged: SetInternalItemAlignmentProperty, defaultValueCreator: GetInternalItemAlignmentProperty);
                ItemHorizontalAlignmentProperty = BindableProperty.Create(nameof(ItemHorizontalAlignment), typeof(HorizontalAlignment), typeof(Button), HorizontalAlignment.Center,
                    propertyChanged: SetInternalItemHorizontalAlignmentProperty, defaultValueCreator: GetInternalItemHorizontalAlignmentProperty);
                ItemVerticalAlignmentProperty = BindableProperty.Create(nameof(ItemVerticalAlignment), typeof(VerticalAlignment), typeof(Button), VerticalAlignment.Center,
                    propertyChanged: SetInternalItemVerticalAlignmentProperty, defaultValueCreator: GetInternalItemVerticalAlignmentProperty);
                ItemSpacingProperty = BindableProperty.Create(nameof(ItemSpacing), typeof(Size2D), typeof(Button), null,
                    propertyChanged: SetInternalItemSpacingProperty, defaultValueCreator: GetInternalItemSpacingProperty);
                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(Button), default(string),
                    propertyChanged: SetInternalTextProperty, defaultValueCreator: GetInternalTextProperty);
                TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(Button), default(string),
                    propertyChanged: SetInternalTranslatableTextProperty, defaultValueCreator: GetInternalTranslatableTextProperty);
                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(Button), default(float),
                    propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);
                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(Button), default(string),
                    propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);
                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(Button), null,
                    propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);
                TextAlignmentProperty = BindableProperty.Create(nameof(TextAlignment), typeof(HorizontalAlignment), typeof(Button), default(HorizontalAlignment),
                    propertyChanged: SetInternalTextAlignmentProperty, defaultValueCreator: GetInternalTextAlignmentProperty);
                IconURLProperty = BindableProperty.Create(nameof(IconURL), typeof(string), typeof(Button), default(string),
                    propertyChanged: SetInternalIconURLProperty, defaultValueCreator: GetInternalIconURLProperty);
                IconSizeProperty = BindableProperty.Create(nameof(IconSize), typeof(Size), typeof(Button), null,
                    propertyChanged: SetInternalIconSizeProperty, defaultValueCreator: GetInternalIconSizeProperty);
                TextSelectorProperty = BindableProperty.Create(nameof(TextSelector), typeof(StringSelector), typeof(Button), null,
                    propertyChanged: SetInternalTextSelectorProperty, defaultValueCreator: GetInternalTextSelectorProperty);
                TranslatableTextSelectorProperty = BindableProperty.Create(nameof(TranslatableTextSelector), typeof(StringSelector), typeof(Button), null,
                    propertyChanged: SetInternalTranslatableTextSelectorProperty, defaultValueCreator: GetInternalTranslatableTextSelectorProperty);
                TextColorSelectorProperty = BindableProperty.Create(nameof(TextColorSelector), typeof(ColorSelector), typeof(Button), null,
                    propertyChanged: SetInternalTextColorSelectorProperty, defaultValueCreator: GetInternalTextColorSelectorProperty);
                PointSizeSelectorProperty = BindableProperty.Create(nameof(PointSizeSelector), typeof(FloatSelector), typeof(Button), null,
                    propertyChanged: SetInternalPointSizeSelectorProperty, defaultValueCreator: GetInternalPointSizeSelectorProperty);
                IconURLSelectorProperty = BindableProperty.Create(nameof(IconURLSelector), typeof(StringSelector), typeof(Button), null,
                    propertyChanged: SetInternalIconURLSelectorProperty, defaultValueCreator: GetInternalIconURLSelectorProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Button() : base()
        {
            Focusable = true;
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="style">Create Button by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(string style) : base(style)
        {
            Focusable = true;
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="buttonStyle">Create Button by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(ButtonStyle buttonStyle) : base(buttonStyle)
        {
            Focusable = true;
        }

        /// <summary>
        /// Calculates current states for the button<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.Checked] = this.IsSelected;
            states[AccessibilityState.Enabled] = this.IsEnabled;

            return states;
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use Clicked event instead.")]
        public event EventHandler<ClickEventArgs> ClickEvent;

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public event EventHandler<ClickedEventArgs> Clicked;

        /// <summary>
        /// An event for the button state changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use View.ControlStateChangedEvent")]
        public event EventHandler<StateChangedEventArgs> StateChangedEvent
        {
            add
            {
                stateChangeHandler += value;
            }
            remove
            {
                stateChangeHandler -= value;
            }
        }

        /// <summary>
        /// Icon orientation.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public enum IconOrientation
        {
            /// <summary>
            /// Top.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Top,
            /// <summary>
            /// Bottom.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Bottom,
            /// <summary>
            /// Left.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Left,
            /// <summary>
            /// Right.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            Right,
        }

        /// <summary>
        /// Button's icon part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView Icon
        {
            get => buttonIcon;
            internal set
            {
                buttonIcon = value;
            }
        }

        /// <summary>
        /// Button's overlay image part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public ImageView OverlayImage
        {
            get
            {
                if (null == overlayImage)
                {
                    overlayImage = CreateOverlayImage();
                    if (null != Extension)
                    {
                        Extension.ProcessOverlayImage(this, ref overlayImage);
                    }
                    if (null != overlayImage)
                    {
                        overlayImage.ExcludeLayouting = true;
                        Add(overlayImage);
                    }
                }
                return overlayImage;
            }
            internal set
            {
                overlayImage = value;
            }
        }

        /// <summary>
        /// Button's text part.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public TextLabel TextLabel
        {
            get => buttonText;
            internal set
            {
                buttonText = value;
            }
        }

        /// <summary>
        /// The last applied style object copy.
        /// </summary>
        /// <remarks>
        /// Modifying contents in style may cause unexpected behaviour.
        /// </remarks>
        /// <since_tizen> 8 </since_tizen>
        public ButtonStyle Style => (ButtonStyle)(ViewStyle as ButtonStyle)?.Clone();

        /// <summary>
        /// The text of Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Text
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextProperty) as string;
                }
                else
                {
                    return GetInternalTextProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextProperty, value);
                }
                else
                {
                    SetInternalTextProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalText
        {
            get
            {
                return TextLabel.Text;
            }
            set
            {
                TextLabel.Text = value;

                if (Accessibility.Accessibility.IsEnabled && IsHighlighted && String.IsNullOrEmpty(AccessibilityName) && IsAccessibilityNameSignalEmpty())
                {
                    EmitAccessibilityEvent(AccessibilityPropertyChangeEvent.Name);
                }
            }
        }

        /// <summary>
        /// Flag to decide Button can be selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSelectable
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsSelectableProperty);
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
        /// Translate text string in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TranslatableText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TranslatableTextProperty) as string;
                }
                else
                {
                    return GetInternalTranslatableTextProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatableTextProperty, value);
                }
                else
                {
                    SetInternalTranslatableTextProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalTranslatableText
        {
            get
            {
                return TextLabel.TranslatableText;
            }
            set
            {
                TextLabel.TranslatableText = value;
            }
        }

        /// <summary>
        /// Text point size in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float PointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PointSizeProperty);
                }
                else
                {
                    return (float)GetInternalPointSizeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PointSizeProperty, value);
                }
                else
                {
                    SetInternalPointSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalPointSize
        {
            get
            {
                return TextLabel.PointSize;
            }
            set
            {
                TextLabel.PointSize = value;
            }
        }

        /// <summary>
        /// Text font family in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string FontFamily
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(FontFamilyProperty) as string;
                }
                else
                {
                    return GetInternalFontFamilyProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontFamilyProperty, value);
                }
                else
                {
                    SetInternalFontFamilyProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalFontFamily
        {
            get
            {
                return TextLabel.FontFamily;
            }
            set
            {
                TextLabel.FontFamily = value;
            }
        }

        /// <summary>
        /// Text color in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextColorProperty) as Color;
                }
                else
                {
                    return GetInternalTextColorProperty(this) as Color;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorProperty, value);
                }
                else
                {
                    SetInternalTextColorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalTextColor
        {
            get
            {
                return TextLabel.TextColor;
            }
            set
            {
                TextLabel.TextColor = value;
            }
        }

        /// <summary>
        /// Text horizontal alignment in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public HorizontalAlignment TextAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(TextAlignmentProperty);
                }
                else
                {
                    return (HorizontalAlignment)GetInternalTextAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextAlignmentProperty, value);
                }
                else
                {
                    SetInternalTextAlignmentProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private HorizontalAlignment InternalTextAlignment
        {
            get
            {
                return TextLabel.HorizontalAlignment;
            }
            set
            {
                TextLabel.HorizontalAlignment = value;
            }
        }

        /// <summary>
        /// Icon image's resource url in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string IconURL
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(IconURLProperty) as string;
                }
                else
                {
                    return GetInternalIconURLProperty(this) as string;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconURLProperty, value);
                }
                else
                {
                    SetInternalIconURLProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalIconURL
        {
            get
            {
                return Icon.ResourceUrl;
            }
            set
            {
                Icon.ResourceUrl = value;
            }
        }

        /// <summary>
        /// Icon image's size in Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size IconSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(IconSizeProperty) as Size;
                }
                else
                {
                    return GetInternalIconSizeProperty(this) as Size;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconSizeProperty, value);
                }
                else
                {
                    SetInternalIconSizeProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private Size InternalIconSize
        {
            get => Icon.Size;
            set => Icon.Size = value;
        }

        /// <summary>
        /// Text string selector in Button.
        /// Getter returns copied selector value if exist, null otherwise.
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TextSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextSelectorProperty) as StringSelector;
                }
                else
                {
                    return GetInternalTextSelectorProperty(this) as StringSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextSelectorProperty, value);
                }
                else
                {
                    SetInternalTextSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalTextSelector
        {
            get => buttonText?.TextSelector == null ? null : new StringSelector(buttonText.TextSelector);
            set
            {
                if (value == null || buttonText == null)
                {
                    throw new NullReferenceException("Button.TextSelector is null");
                }
                else
                {
                    buttonText.TextSelector = value;
                }
            }
        }

        /// <summary>
        /// Translatable text string selector in Button.
        /// Getter returns copied selector value if exist, null otherwise.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TranslatableTextSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TranslatableTextSelectorProperty) as StringSelector;
                }
                else
                {
                    return GetInternalTranslatableTextSelectorProperty(this) as StringSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatableTextSelectorProperty, value);
                }
                else
                {
                    SetInternalTranslatableTextSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalTranslatableTextSelector
        {
            get => (buttonText?.TranslatableTextSelector == null) ? null : new StringSelector(buttonText.TranslatableTextSelector);
            set
            {
                if (value == null || buttonText == null)
                {
                    throw new NullReferenceException("Button.TranslatableTextSelector is null");
                }
                else
                {
                    buttonText.TranslatableTextSelector = value;
                }
            }
        }

        /// <summary>
        /// Text color selector in Button.
        /// Getter returns copied selector value if exist, null otherwise.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public ColorSelector TextColorSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TextColorSelectorProperty) as ColorSelector;
                }
                else
                {
                    return GetInternalTextColorSelectorProperty(this) as ColorSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorSelectorProperty, value);
                }
                else
                {
                    SetInternalTextColorSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private ColorSelector InternalTextColorSelector
        {
            get => buttonText?.TextColorSelector == null ? null : new ColorSelector(buttonText.TextColorSelector);
            set
            {
                if (value == null || buttonText == null)
                {
                    throw new NullReferenceException("Button.TextColorSelectorProperty is null");
                }
                else
                {
                    buttonText.TextColorSelector = value;
                }
            }
        }

        /// <summary>
        /// Text font size selector in Button.
        /// Getter returns copied selector value if exist, null otherwise.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public FloatSelector PointSizeSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(PointSizeSelectorProperty) as FloatSelector;
                }
                else
                {
                    return GetInternalPointSizeSelectorProperty(this) as FloatSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PointSizeSelectorProperty, value);
                }
                else
                {
                    SetInternalPointSizeSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private FloatSelector InternalPointSizeSelector
        {
            get => buttonText?.PointSizeSelector == null ? null : new FloatSelector(buttonText.PointSizeSelector);
            set
            {
                if (value == null || buttonText == null)
                {
                    throw new NullReferenceException("Button.PointSizeSelector is null");
                }
                else
                {
                    buttonText.PointSizeSelector = value;
                }
            }
        }

        /// <summary>
        /// Icon image's resource url selector in Button.
        /// Getter returns copied selector value if exist, null otherwise.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown when setting null value.</exception>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector IconURLSelector
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(IconURLSelectorProperty) as StringSelector;
                }
                else
                {
                    return GetInternalIconURLSelectorProperty(this) as StringSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(IconURLSelectorProperty, value);
                }
                else
                {
                    SetInternalIconURLSelectorProperty(this, null, value);
                }
                NotifyPropertyChanged();
            }
        }
        private StringSelector InternalIconURLSelector
        {
            get
            {
                Selector<string> resourceUrlSelector = buttonIcon?.ResourceUrlSelector;
                if(resourceUrlSelector == null)
                {
                    return null;
                }
                return new StringSelector(resourceUrlSelector);
            }
            set
            {
                if (value == null || buttonIcon == null)
                {
                    throw new NullReferenceException("Button.IconURLSelector is null");
                }
                else
                {
                    buttonIcon.ResourceUrlSelector = value;
                }
            }
        }

        /// <summary>
        /// Flag to decide selected state in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSelected
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(IsSelectedProperty);
                }
                else
                {
                    return (bool)GetInternalIsSelectedProperty(this);
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
        /// Flag to decide enable or disable in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public new bool IsEnabled
        {
            get => base.IsEnabled;
            set
            {
                base.IsEnabled = value;
            }
        }

        /// <summary>
        /// Icon relative orientation in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public IconOrientation? IconRelativeOrientation
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (IconOrientation?)GetValue(IconRelativeOrientationProperty) ?? IconOrientation.Left;
                }
                else
                {
                    return (IconOrientation?)GetInternalIconRelativeOrientationProperty(this) ?? IconOrientation.Left;
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
        /// <since_tizen> 6 </since_tizen>
        public Extents IconPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(IconPaddingProperty) ?? new Extents();
                }
                else
                {
                    return (Extents)GetInternalIconPaddingProperty(this) ?? new Extents();
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
        /// Text padding in Button. It is shortcut of TextLabel.Padding.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents TextPadding
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Extents)GetValue(TextPaddingProperty) ?? new Extents();
                }
                else
                {
                    return (Extents)GetInternalTextPaddingProperty(this) ?? new Extents();
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
        /// <since_tizen> 9 </since_tizen>
        public LinearLayout.Alignment ItemAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (LinearLayout.Alignment)GetValue(ItemAlignmentProperty);
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
        public HorizontalAlignment ItemHorizontalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(ItemHorizontalAlignmentProperty);
                }
                else
                {
                    return (HorizontalAlignment)GetInternalItemHorizontalAlignmentProperty(this);
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
        public VerticalAlignment ItemVerticalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment)GetValue(ItemVerticalAlignmentProperty);
                }
                else
                {
                    return (VerticalAlignment)GetInternalItemVerticalAlignmentProperty(this);
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
        /// <since_tizen> 9 </since_tizen>
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

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool OnKey(Key key)
        {
            bool clicked = false;

            if (!IsEnabled || null == key)
            {
                return false;
            }

            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Return")
                {
                    isPressed = true;
                    UpdateState();
                }
            }
            else if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    clicked = isPressed && IsEnabled;

                    isPressed = false;

                    if (IsSelectable)
                    {
                        IsSelected = !IsSelected;
                    }
                    else
                    {
                        UpdateState();
                    }

                    if (clicked)
                    {
                        ClickedEventArgs eventArgs = new ClickedEventArgs();
                        OnClickedInternal(eventArgs);
                    }
                }
            }
            return base.OnKey(key) || clicked;
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override void OnFocusGained()
        {
            base.OnFocusGained();
            UpdateState();
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is lost.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public override void OnFocusLost()
        {
            base.OnFocusLost();
            UpdateState();
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 8 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use OnClicked instead.")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        public override bool OnTouch(Touch touch)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        {
            return base.OnTouch(touch);
        }

        /// <summary>
        /// Apply style to button.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            Debug.Assert(buttonIcon != null && buttonText != null);

            base.ApplyStyle(viewStyle);

            if (viewStyle is ButtonStyle buttonStyle)
            {
                styleApplying++;

                if ((Extension = buttonStyle.CreateExtension()) != null)
                {
                    bool needRelayout = false;
                    needRelayout |= Extension.ProcessIcon(this, ref buttonIcon);
                    needRelayout |= Extension.ProcessText(this, ref buttonText);

                    if (needRelayout)
                    {
                        LayoutItems();
                    }
                }

                if (buttonStyle.Overlay != null)
                {
                    OverlayImage?.ApplyStyle(buttonStyle.Overlay);
                }

                if (buttonStyle.Text != null)
                {
                    buttonText.ThemeChangeSensitive = false;
                    buttonText.ApplyStyle(buttonStyle.Text);
                }

                if (buttonStyle.Icon != null)
                {
                    buttonIcon.ApplyStyle(buttonStyle.Icon);
                }

                styleApplying--;
            }

            UpdateState();
        }

        /// <summary>
        /// ClickEventArgs is a class to record button click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use ClickedEventArgs instead.")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ClickEventArgs : EventArgs
        {
        }

        /// <summary>
        /// StateChangeEventArgs is a class to record button state change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use View.ControlStateChangedEventArgs")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class StateChangedEventArgs : EventArgs
        {
            /// <summary> previous state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public ControlStates PreviousState;
            /// <summary> current state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public ControlStates CurrentState;
        }
    }
}
