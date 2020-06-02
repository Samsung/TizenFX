/*
 * Copyright(c) 2020 Samsung Electronics Co., Ltd.
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
using Tizen.NUI.Components.Extension;

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

        /// <summary>
        /// The last touch information triggering selected state change.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected Touch SelectionChangedByTouch { get; set; }

        /// <summary>
        /// The ButtonExtension instance that is injected by ButtonStyle.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected ButtonExtension Extension { get; set; }

        /// <summary>
        /// Creates Button's text part.
        /// </summary>
        /// <return>The created Button's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual TextLabel CreateText()
        {
            return new TextLabel();
        }

        /// <summary>
        /// Creates Button's icon part.
        /// </summary>
        /// <return>The created Button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateIcon()
        {
            return new ImageView();
        }

        /// <summary>
        /// Creates Button's overlay image part.
        /// </summary>
        /// <return>The created Button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual ImageView CreateOverlayImage()
        {
            return new ImageView();
        }

        /// <summary>
        /// Called when the Button is Clicked by a user
        /// </summary>
        /// <param name="eventArgs">The click information.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnClick(ClickEventArgs eventArgs)
        {
        }

        static Button() { }

        /// <summary>
        /// Creates a new instance of a Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Button() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="style">Create Button by special style defined in UX.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Button with style.
        /// </summary>
        /// <param name="buttonStyle">Create Button by style customized by user.</param>
        /// <since_tizen> 8 </since_tizen>
        public Button(ButtonStyle buttonStyle) : base(buttonStyle)
        {
            Initialize();
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
        /// Button's icon part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView ButtonIcon
        {
            get
            {
                if (null == buttonIcon)
                {
                    buttonIcon = CreateIcon();
                    if (null != Extension)
                    {
                        buttonIcon = Extension.OnCreateIcon(this, buttonIcon);
                    }
                    Add(buttonIcon);
                    buttonIcon.Relayout += OnIconRelayout;
                }
                return buttonIcon;
            }
            internal set
            {
                buttonIcon = value;
            }
        }

        /// <summary>
        /// Button's overlay image part.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView ButtonOverlay
        {
            get
            {
                if (null == overlayImage)
                {
                    overlayImage = CreateOverlayImage();
                    if (null != Extension)
                    {
                        overlayImage = Extension.OnCreateOverlayImage(this, overlayImage);
                    }
                    overlayImage.WidthResizePolicy = ResizePolicyType.FillToParent;
                    overlayImage.HeightResizePolicy = ResizePolicyType.FillToParent;
                    Add(overlayImage);
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel ButtonText
        {
            get
            {
                if (null == buttonText)
                {
                    buttonText = CreateText();
                    if (null != Extension)
                    {
                        buttonText = Extension.OnCreateText(this, buttonText);
                    }
                    buttonText.HorizontalAlignment = HorizontalAlignment.Center;
                    buttonText.VerticalAlignment = VerticalAlignment.Center;
                    Add(buttonText);
                }
                return buttonText;
            }
            internal set
            {
                buttonText = value;
            }
        }

        /// <summary>
        /// Return a copied Style instance of Button
        /// </summary>
        /// <remarks>
        /// It returns copied Style instance and changing it does not effect to the Button.
        /// Style setting is possible by using constructor or the function of ApplyStyle(ViewStyle viewStyle)
        /// </remarks>
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
                if (value == null || textSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Button.TextSelector is null");
                    throw new NullReferenceException("Button.TextSelector is null");
                }
                else
                {
                    textSelector.Clone(value);
                }
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
                if (value == null || translatableTextSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Button.TranslatableTextSelector is null");
                    throw new NullReferenceException("Button.TranslatableTextSelector is null");
                }
                else
                {
                    translatableTextSelector.Clone(value);
                }
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
                if (value == null || textColorSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Button.textColorSelector is null");
                    throw new NullReferenceException("Button.textColorSelector is null");
                }
                else
                {
                    textColorSelector.Clone(value);
                }
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
                if (value == null || pointSizeSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Button.pointSizeSelector is null");
                    throw new NullReferenceException("Button.pointSizeSelector is null");
                }
                else
                {
                    pointSizeSelector.Clone(value);
                }
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
                if (value == null || iconURLSelector == null)
                {
                    Tizen.Log.Fatal("NUI", "[Exception] Button.iconURLSelector is null");
                    throw new NullReferenceException("Button.iconURLSelector is null");
                }
                else
                {
                    iconURLSelector.Clone(value);
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

                UpdateState();
            }
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
                UpdateState();
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
                if (Style != null && Style.IconRelativeOrientation != value)
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
            get => (Extents)GetValue(TextPaddingProperty);
            set => SetValue(TextPaddingProperty, value);
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
                Extension?.OnDispose(this);

                if (ButtonIcon != null)
                {
                    Utility.Dispose(ButtonIcon);
                }
                if (ButtonText != null)
                {
                    Utility.Dispose(ButtonText);
                }
                if (ButtonOverlay != null)
                {
                    Utility.Dispose(ButtonOverlay);
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
                    UpdateState();
                }
            }
            else if (key.State == Key.StateType.Up)
            {
                if (key.KeyPressedName == "Return")
                {
                    bool clicked = isPressed && isEnabled;

                    isPressed = false;

                    if (Style.IsSelectable != null && Style.IsSelectable == true)
                    {
                        IsSelected = !IsSelected;
                    }
                    else
                    {
                        UpdateState();
                    }

                    if (clicked)
                    {
                        ClickEventArgs eventArgs = new ClickEventArgs();
                        OnClickInternal(eventArgs);
                    }
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
            UpdateState();
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
            UpdateState();
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

            switch (state)
            {
                case PointStateType.Down:
                    isPressed = true;
                    Extension?.SetTouchInfo(touch);
                    UpdateState();
                    return true;
                case PointStateType.Interrupted:
                    isPressed = false;
                    UpdateState();
                    return true;
                case PointStateType.Up:
                    {
                        bool clicked = isPressed && isEnabled;

                        isPressed = false;

                        if (Style.IsSelectable != null && Style.IsSelectable == true)
                        {
                            Extension?.SetTouchInfo(touch);
                            IsSelected = !IsSelected;
                        }
                        else
                        {
                            Extension?.SetTouchInfo(touch);
                            UpdateState();
                        }

                        if (clicked)
                        {
                            ClickEventArgs eventArgs = new ClickEventArgs();
                            OnClickInternal(eventArgs);
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
                Extension = buttonStyle.CreateExtension();
                if (buttonStyle.Overlay != null)
                {
                    ButtonOverlay?.ApplyStyle(buttonStyle.Overlay);
                }

                if (buttonStyle.Text != null)
                {
                    ButtonText?.ApplyStyle(buttonStyle.Text);
                }

                if (buttonStyle.Icon != null)
                {
                    ButtonIcon?.ApplyStyle(buttonStyle.Icon);
                }
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

            Extension?.OnRelayout(this);
        }

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <param name="touchInfo">The touch information in case the state has changed by touching.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
        {
            ControlStates sourceState = ControlState;
            ControlStates targetState;

            if (isEnabled)
            {
                if (isPressed)
                {
                    // Pressed
                    targetState = ControlStates.Pressed;
                }
                else
                {
                    // Normal
                    targetState = ControlStates.Normal;

                    // Selected
                    targetState |= (IsSelected ? ControlStates.Selected : 0);

                    // Focused, SelectedFocused
                    targetState |= (IsFocused ? ControlStates.Focused : 0);
                }
            }
            else
            {
                // Disabled
                targetState = ControlStates.Disabled;

                // DisabledSelected, DisabledFocused
                targetState |= (IsSelected ? ControlStates.Selected : (IsFocused ? ControlStates.Focused : 0));
            }

            if (sourceState != targetState)
            {
                ControlState = targetState;

                OnUpdate();

                StateChangedEventArgs e = new StateChangedEventArgs
                {
                    PreviousState = sourceState,
                    CurrentState = targetState
                };
                stateChangeHander?.Invoke(this, e);

                Extension?.OnControlStateChanged(this, new ControlStateChangedEventArgs(sourceState, targetState));
            }
        }

        /// <summary>
        /// It is hijack by using protected, style copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize()
        {
            var style = (ButtonStyle)Style;
            EnableControlStatePropagation = true;
            UpdateState();
            LayoutDirectionChanged += OnLayoutDirectionChanged;
        }

        /// <summary>
        /// Measure text, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void MeasureText()
        {
            if (Style.IconRelativeOrientation == null || ButtonIcon == null || ButtonText == null)
            {
                return;
            }
            ButtonText.WidthResizePolicy = ResizePolicyType.Fixed;
            ButtonText.HeightResizePolicy = ResizePolicyType.Fixed;
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
                ButtonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd;
                ButtonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - ButtonIcon.SizeHeight;
            }
            else
            {
                ButtonText.SizeWidth = SizeWidth - textPaddingStart - textPaddingEnd - iconPaddingStart - iconPaddingEnd - ButtonIcon.SizeWidth;
                ButtonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom;
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
            if (Style.IconRelativeOrientation == null || ButtonIcon == null || ButtonText == null)
            {
                return;
            }

            var buttonIcon = ButtonIcon;
            var buttonText = ButtonText;

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

        private void OnClickInternal(ClickEventArgs eventArgs)
        {
            OnClick(eventArgs);
            Extension?.OnClick(this, eventArgs);
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

        /// <summary>
        /// Get current text part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invaild.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel GetCurrentText(ButtonExtension extension)
        {
            return (extension == Extension) ? ButtonText : null;
        }

        /// <summary>
        /// Get current icon part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invaild.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView GetCurrentIcon(ButtonExtension extension)
        {
            return (extension == Extension) ? ButtonIcon : null;
        }

        /// <summary>
        /// Get current overlay image part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invaild.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView GetCurrentOverlayImage(ButtonExtension extension)
        {
            return (extension == Extension) ? ButtonOverlay : null;
        }
    }
}
