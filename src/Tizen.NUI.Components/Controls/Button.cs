/*
 * Copyright(c) 2019 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Button is one kind of common component, a button clearly describes what action will occur when the user selects it.
    /// Button may contain text or an icon.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Button : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(IconOrientation?), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.privateIconRelativeOrientation = (IconOrientation?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.privateIconRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.privateIsEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.privateIsEnabled;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.privateIsSelected = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.privateIsSelected;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.privateIsSelectable = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.privateIsSelectable;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconPaddingProperty = BindableProperty.Create(nameof(IconPadding), typeof(Extents), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (null != newValue && null != instance.Style?.IconPadding)
            {
                instance.Style.IconPadding.CopyFrom((Extents)newValue);
                instance.UpdateUIContent();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.Style?.IconPadding;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextPaddingProperty = BindableProperty.Create(nameof(TextPadding), typeof(Extents), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (null != newValue && null != instance.Style?.TextPadding)
            {
                instance.Style.TextPadding.CopyFrom((Extents)newValue);
                instance.UpdateUIContent();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.Style?.TextPadding;
        });

        private ImageView overlayImage;

        private TextLabel buttonText;
        private ImageView buttonIcon;

        private EventHandler<StateChangedEventArgs> stateChangeHander;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;

        static Button() { }

        /// <summary>
        /// Creates a new instance of a Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Button() : base()
        {
            Initialize(GetDefaultExtension());
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="style">Create Button by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(string style) : base(style)
        {
            Initialize(GetDefaultExtension());
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="buttonStyle">Create Button by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(ButtonStyle buttonStyle) : base(buttonStyle)
        {
            Initialize(GetDefaultExtension() as ButtonExtension);
        }

        /// <summary>
        /// Creates a new instance of a Button with a custom extension.
        /// </summary>
        /// <param name="extension">A custom extension for the Button.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button(ButtonExtension extension) : base()
        {
            Initialize(extension);
        }

        /// <summary>
        /// Creates a new instance of a Button with style and a custom extension.
        /// </summary>
        /// <param name="buttonStyle">Create Button by style customized by user.</param>
        /// <param name="extension">A custom extension for the Button.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button(ButtonStyle buttonStyle, ButtonExtension extension) : base(buttonStyle)
        {
            Initialize(extension);
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ClickEventArgs> ClickEvent;
        /// <summary>
        /// An event for the button state changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChangedEvent
        {
            add
            {
                stateChangeHander += value;
            }
            remove
            {
                stateChangeHander -= value;
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
        /// Style of the button.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        public new ButtonStyle Style => ViewStyle as ButtonStyle;

        /// <summary>
        /// The text of Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Text
        {
            get
            {
                return Style?.Text?.Text?.GetValue(ControlState);
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.Text = value;
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
                return (bool)GetValue(IsSelectableProperty);
            }
            set
            {
                SetValue(IsSelectableProperty, value);
            }
        }

        private bool privateIsSelectable
        {
            get
            {
                return Style?.IsSelectable ?? false;
            }
            set
            {
                Style.IsSelectable = value;
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
                return Style?.Text?.TranslatableText?.All;
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.TranslatableText = value;
                }
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
                return Style?.Text?.PointSize?.All ?? 0;
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.PointSize = value;
                }
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
                return Style?.Text?.FontFamily.All;
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.FontFamily = value;
                }
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
                return Style?.Text?.TextColor?.All;
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.TextColor = value;
                }
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
                return Style?.Text?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                if (null != Style?.Text)
                {
                    Style.Text.HorizontalAlignment = value;
                }
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
                return Style?.Icon?.ResourceUrl?.All;
            }
            set
            {
                if (null != Style?.Icon)
                {
                    Style.Icon.ResourceUrl = value;
                }
            }
        }

        private StringSelector textSelector = new StringSelector();
        /// <summary>
        /// Text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TextSelector
        {
            get
            {
                return textSelector;
            }
            set
            {
                textSelector.Clone(value);
            }
        }

        private StringSelector translatableTextSelector = new StringSelector();
        /// <summary>
        /// Translateable text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TranslatableTextSelector
        {
            get
            {
                return translatableTextSelector;
            }
            set
            {
                translatableTextSelector.Clone(value);
            }
        }

        private ColorSelector textColorSelector = new ColorSelector();
        /// <summary>
        /// Text color selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ColorSelector TextColorSelector
        {
            get
            {
                return textColorSelector;
            }
            set
            {
                textColorSelector.Clone(value);
            }
        }

        private FloatSelector pointSizeSelector = new FloatSelector();
        /// <summary>
        /// Text font size selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public FloatSelector PointSizeSelector
        {
            get
            {
                return pointSizeSelector;
            }
            set
            {
                pointSizeSelector.Clone(value);
            }
        }

        private StringSelector iconURLSelector = new StringSelector();
        /// <summary>
        /// Icon image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector IconURLSelector
        {
            get
            {
                return iconURLSelector;
            }
            set
            {
                iconURLSelector.Clone(value);
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
                return (bool)GetValue(IsSelectedProperty);
            }
            set
            {
                SetValue(IsSelectedProperty, value);
            }
        }
        private bool privateIsSelected
        {
            get
            {
                return isSelected;
            }
            set
            {
                isSelected = value;
                UpdateState(false);
            }
        }

        internal void UpdateSelectedStateByUI(bool selected, Touch touchInfo = null)
        {
            if (Style.IsSelectable != null && Style.IsSelectable == true)
            {
                isSelected = selected;
            }
            UpdateState(true, touchInfo);
        }

        /// <summary>
        /// Flag to decide enable or disable in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsEnabled
        {
            get
            {
                return (bool)GetValue(IsEnabledProperty);
            }
            set
            {
                SetValue(IsEnabledProperty, value);
            }
        }
        private bool privateIsEnabled
        {
            get
            {
                return isEnabled;
            }
            set
            {
                isEnabled = value;
                UpdateState(false);
            }
        }

        /// <summary>
        /// Icon relative orientation in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IconOrientation? IconRelativeOrientation
        {
            get
            {
                return (IconOrientation?)GetValue(IconRelativeOrientationProperty);
            }
            set
            {
                SetValue(IconRelativeOrientationProperty, value);
            }
        }
        private IconOrientation? privateIconRelativeOrientation
        {
            get
            {
                return Style?.IconRelativeOrientation;
            }
            set
            {
                if(Style != null && Style.IconRelativeOrientation != value)
                {
                    Style.IconRelativeOrientation = value;
                    UpdateUIContent();
                }
            }
        }

        /// <summary>
        /// Icon padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents IconPadding
        {
            get => (Extents)GetValue(IconPaddingProperty);
            set => SetValue(IconPaddingProperty, value);
        }

        /// <summary>
        /// Text padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents TextPadding
        {
            get => (Extents) GetValue(TextPaddingProperty);
            set => SetValue(TextPaddingProperty, value);
        }

        /// <summary>
        /// The ButtonExtension instance.
        /// A custom extension can be set from the constructor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ButtonExtension Extension { get; set; }

        /// <summary>
        /// Get default ButtonExtension for this class.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ButtonExtension GetDefaultExtension()
        {
            return null;
        }

        /// <summary>
        /// Dispose Button and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                Extension?.OnDisconnect(GetExposer());

                if (buttonIcon != null)
                {
                    Utility.Dispose(buttonIcon);
                }
                if (buttonText != null)
                {
                    Utility.Dispose(buttonText);
                }
                if (overlayImage != null)
                {
                    Utility.Dispose(overlayImage);
                }
            }

            base.Dispose(type);
        }
        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool OnKey(Key key)
        {
            if (null == key) return false;
            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Return")
                {
                    isPressed = true;
                    UpdateState(true);
                    if(isEnabled)
                    {
                        ClickEventArgs eventArgs = new ClickEventArgs();
                        OnClick(eventArgs);
                    }
                }
            }
            else if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    isPressed = false;
                    UpdateSelectedStateByUI(!isSelected);
                }
            }
            return base.OnKey(key);
        }

        /// <summary>
        /// Called when the control gain key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is gained.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            base.OnFocusGained();
            UpdateState(false);
        }

        /// <summary>
        /// Called when the control loses key input focus. Should be overridden by derived classes if they need to customize what happens when the focus is lost.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            base.OnFocusLost();
            UpdateState(false);
        }

        /// <summary>
        /// Called after a touch event is received by the owning view.<br />
        /// CustomViewBehaviour.REQUIRES_TOUCH_EVENTS must be enabled during construction. See CustomView(ViewWrapperImpl.CustomViewBehaviour behaviour).<br />
        /// </summary>
        /// <param name="touch">The touch event.</param>
        /// <returns>True if the event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool OnTouch(Touch touch)
        {
            if (null == touch) return false;
            PointStateType state = touch.GetState(0);

            switch(state)
            {
                case PointStateType.Down:
                    isPressed = true;
                    UpdateState(true, touch);
                    return true;
                case PointStateType.Interrupted:
                    isPressed = false;
                    UpdateState(false);
                    return true;
                case PointStateType.Up:
                {
                    bool clicked = isPressed && isEnabled;

                    isPressed = false;

                    UpdateSelectedStateByUI(!isSelected, touch);

                    if (clicked)
                    {
                        ClickEventArgs eventArgs = new ClickEventArgs();
                        OnClick(eventArgs);
                        Extension?.OnClick(GetExposer(), touch);
                    }

                    return true;
                }
                default:
                    break;
            }
            return base.OnTouch(touch);
        }

        /// <summary>
        /// Apply style to button.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        /// <since_tizen> 8 </since_tizen>
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            ButtonStyle buttonStyle = viewStyle as ButtonStyle;

            if (null != buttonStyle)
            {
                overlayImage?.ApplyStyle(buttonStyle.Overlay);
                buttonText?.ApplyStyle(buttonStyle.Text);
                buttonIcon?.ApplyStyle(buttonStyle.Icon);
            }
        }

        /// <summary>
        /// Get Button style.
        /// </summary>
        /// <returns>The default button style.</returns>
        /// <since_tizen> 8 </since_tizen>
        protected override ViewStyle GetViewStyle()
        {
            return new ButtonStyle();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();
            UpdateUIContent();
            Extension?.OnRelayout(GetExposer());
        }

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <param name="byUI">True if the state has changed by user interation. (e.g. touch, key)</param>
        /// <param name="touchInfo">The touch information in case the state has changed by touching.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState(bool byUI, Touch touchInfo = null)
        {
            ControlStates sourceState = ControlState;
            ControlStates targetState;

            if(isEnabled)
            {
                targetState = isPressed ? ControlStates.Pressed : (IsFocused ? (IsSelected ? ControlStates.SelectedFocused : ControlStates.Focused) : (IsSelected ? ControlStates.Selected : ControlStates.Normal));
            }
            else
            {
                targetState = IsSelected ? ControlStates.DisabledSelected : (IsFocused ? ControlStates.DisabledFocused : ControlStates.Disabled);
            }

            if(sourceState != targetState)
            {
                ControlState = targetState;

                OnUpdate();

                StateChangedEventArgs e = new StateChangedEventArgs
                {
                    PreviousState = sourceState,
                    CurrentState = targetState
                };
                stateChangeHander?.Invoke(this, e);

                Extension?.OnControlStateChanged(GetExposer(), sourceState, targetState, byUI, touchInfo);
            }
        }

        /// <summary>
        /// It is hijack by using protected, style copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize(ButtonExtension extension)
        {
            ComposeSubComponents(extension);

            if (null == Style.IconRelativeOrientation) Style.IconRelativeOrientation = IconOrientation.Left;
            UpdateState(false);
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        /// <summary>
        /// Compose sub components in Button
        /// </summary>
        private void ComposeSubComponents(ButtonExtension extension)
        {
            var currentStyle = Style;
            Extension = extension;

            // Create overlayImage
            overlayImage = new ImageView();
            extension?.OnCreateOverlayImage(this, ref overlayImage, currentStyle?.Overlay);
            if (null != overlayImage)
            {
                Add(overlayImage);
                overlayImage.ApplyStyle(currentStyle?.Overlay);
            }

            // Create icon
            buttonIcon = new ImageView();
            extension?.OnCreateIcon(this, ref buttonIcon, currentStyle?.Icon);
            if (null != buttonIcon)
            {
                Add(buttonIcon);
                buttonIcon.ApplyStyle(currentStyle?.Icon);
                buttonIcon.Relayout += OnIconRelayout;
            }

            // Create text
            buttonText = new TextLabel();
            extension?.OnCreateText(this, ref buttonText, currentStyle?.Text);
            if (null != buttonText)
            {
                Add(buttonText);
                buttonText.ApplyStyle(currentStyle?.Text);
            }
        }

        private void OnResourceLoaded(object target, ImageView.ResourceLoadedEventArgs args)
        {
            if (args.Status == ResourceLoadingStatusType.Ready)
            {
                MeasureText();
            }
        }

        /// <summary>
        /// Measure text, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureText()
        {
            if (Style.IconRelativeOrientation == null || buttonIcon == null || buttonText == null)
            {
                return;
            }
            buttonText.WidthResizePolicy = ResizePolicyType.Fixed;
            buttonText.HeightResizePolicy = ResizePolicyType.Fixed;
            int textPaddingStart = Style.TextPadding.Start;
            int textPaddingEnd = Style.TextPadding.End;
            int textPaddingTop = Style.TextPadding.Top;
            int textPaddingBottom = Style.TextPadding.Bottom;

            int iconPaddingStart = Style.IconPadding.Start;
            int iconPaddingEnd = Style.IconPadding.End;
            int iconPaddingTop = Style.IconPadding.Top;
            int iconPaddingBottom = Style.IconPadding.Bottom;

            if (IconRelativeOrientation == IconOrientation.Top || IconRelativeOrientation == IconOrientation.Bottom)
            {
                buttonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd;
                buttonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - buttonIcon.SizeHeight;
            }
            else
            {
                buttonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd - iconPaddingStart - iconPaddingEnd - buttonIcon.SizeWidth;
                buttonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom;
            }
        }
        /// <summary>
        /// Layout child, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            if (Style.IconRelativeOrientation == null || buttonIcon == null || buttonText == null)
            {
                return;
            }

            int textPaddingStart = Style.TextPadding.Start;
            int textPaddingEnd = Style.TextPadding.End;
            int textPaddingTop = Style.TextPadding.Top;
            int textPaddingBottom = Style.TextPadding.Bottom;

            int iconPaddingStart = Style.IconPadding.Start;
            int iconPaddingEnd = Style.IconPadding.End;
            int iconPaddingTop = Style.IconPadding.Top;
            int iconPaddingBottom = Style.IconPadding.Bottom;

            switch (IconRelativeOrientation)
            {
                case IconOrientation.Top:
                    buttonIcon.PositionUsesPivotPoint = true;
                    buttonIcon.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    buttonIcon.PivotPoint = NUI.PivotPoint.TopCenter;
                    buttonIcon.Position2D = new Position2D(0, iconPaddingTop);

                    buttonText.PositionUsesPivotPoint = true;
                    buttonText.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    buttonText.PivotPoint = NUI.PivotPoint.BottomCenter;
                    buttonText.Position2D = new Position2D(0, -textPaddingBottom);
                    break;
                case IconOrientation.Bottom:
                    buttonIcon.PositionUsesPivotPoint = true;
                    buttonIcon.ParentOrigin = NUI.ParentOrigin.BottomCenter;
                    buttonIcon.PivotPoint = NUI.PivotPoint.BottomCenter;
                    buttonIcon.Position2D = new Position2D(0, -iconPaddingBottom);

                    buttonText.PositionUsesPivotPoint = true;
                    buttonText.ParentOrigin = NUI.ParentOrigin.TopCenter;
                    buttonText.PivotPoint = NUI.PivotPoint.TopCenter;
                    buttonText.Position2D = new Position2D(0, textPaddingTop);
                    break;
                case IconOrientation.Left:
                    if (LayoutDirection == ViewLayoutDirectionType.LTR)
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonIcon.Position2D = new Position2D(iconPaddingStart, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingEnd, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingStart, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingEnd, 0);
                    }

                    break;
                case IconOrientation.Right:
                    if (LayoutDirection == ViewLayoutDirectionType.RTL)
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonIcon.Position2D = new Position2D(iconPaddingEnd, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingStart, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingEnd, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingStart, 0);
                    }
                    break;
                default:
                    break;
            }
            if (string.IsNullOrEmpty(buttonText.Text))
            {
                buttonIcon.ParentOrigin = NUI.ParentOrigin.Center;
                buttonIcon.PivotPoint = NUI.PivotPoint.Center;
            }
        }
        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <param name="sender">The sender</param>
        /// <param name="e">The event data</param>
        /// <since_tizen> 8 </since_tizen>
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ButtonStyle buttonStyle = StyleManager.Instance.GetViewStyle(style) as ButtonStyle;
            if (buttonStyle != null)
            {
                Style.CopyFrom(buttonStyle);
                UpdateUIContent();
            }
        }

        private void UpdateUIContent()
        {
            MeasureText();
            LayoutChild();

            Sensitive = isEnabled;
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            MeasureText();
            LayoutChild();
        }

        private void OnClick(ClickEventArgs eventArgs)
        {
            ClickEvent?.Invoke(this, eventArgs);
        }

        private void OnIconRelayout(object sender, EventArgs e)
        {
            MeasureText();
            LayoutChild();
        }

        /// <summary>
        /// ClickEventArgs is a class to record button click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class ClickEventArgs : EventArgs
        {
        }
        /// <summary>
        /// StateChangeEventArgs is a class to record button state change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class StateChangedEventArgs : EventArgs
        {
            /// <summary> previous state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            public ControlStates PreviousState;
            /// <summary> current state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            public ControlStates CurrentState;
        }

        internal virtual ButtonExposer GetExposer()
        {
            return new ButtonExposer(this);
        }

        /// <summary>
        /// ButtonExposer helps ButtonExtension to access inside of a Button.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ButtonExposer
        {
            private Button button;

            internal ButtonExposer(Button button)
            {
                this.button = button;
            }

            /// <summary>
            /// Expose Button instance.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public Button Button => button;

            /// <summary>
            /// Expose Button's text part.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public TextLabel Text => button.buttonText;

            /// <summary>
            /// Expose Button's icon part.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ImageView Icon => button.buttonIcon;

            /// <summary>
            /// Expose Button's overlay image part.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ImageView OverlayImage => button.overlayImage;
        }

        /// <summary>
        /// OverlayAnimationExtension class is a customized ButtonExtension that play blinking animation on Button pressed.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class OverlayAnimationExtension : ButtonExtension
        {
            private Animation pressAnimation;

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override void OnCreateOverlayImage(Button button, ref ImageView overlayImage, ImageViewStyle style)
            {
                overlayImage.Hide();
            }

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override void OnControlStateChanged(ButtonExposer buttonExposer, ControlStates previousState, ControlStates currentState, bool byUI, Touch touchInfo)
            {
                if (currentState != ControlStates.Pressed || null == buttonExposer.OverlayImage)
                {
                    return;
                }

                var button = buttonExposer.Button;
                var overlayImage = buttonExposer.OverlayImage;

                if (null == pressAnimation)
                {
                    var keyFrames = new KeyFrames();
                    keyFrames.Add(0.0f, 0.0f);
                    keyFrames.Add(0.25f, 1.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.Linear));
                    keyFrames.Add(1.0f, 0.0f, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));

                    pressAnimation = new Animation(400);
                    pressAnimation.EndAction = Animation.EndActions.StopFinal;
                    pressAnimation.AnimateBetween(overlayImage, "Opacity", keyFrames);
                    pressAnimation.AnimateTo(overlayImage, "Scale", new Vector3(1, 1, 1), 0, 300, new AlphaFunction(AlphaFunction.BuiltinFunctions.EaseOut));
                }

                if (pressAnimation.State == Animation.States.Playing)
                {
                    pressAnimation.Stop();
                    overlayImage.Hide();
                }

                overlayImage.Opacity = 0.0f;
                overlayImage.CornerRadius = button.CornerRadius;
                overlayImage.Background = button.Background;
                overlayImage.Size = button.Size;
                overlayImage.Scale = new Vector3(0.86f, 0.86f, 1);
                overlayImage.Show();

                pressAnimation.Play();
            }

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override void OnDisconnect(ButtonExposer buttonExposer)
            {
                if (null != pressAnimation)
                {
                    if (pressAnimation.State == Animation.States.Playing)
                    {
                        pressAnimation.Stop();
                    }
                    pressAnimation.Dispose();
                    pressAnimation = null;
                }
            }
        }
    }
}
