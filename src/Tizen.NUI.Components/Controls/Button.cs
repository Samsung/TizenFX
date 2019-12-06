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
        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create("IconRelativeOrientation", typeof(IconOrientation?), typeof(Tizen.NUI.Components.Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            if (newValue != null)
            {
                instance.privateIconRelativeOrientation = (IconOrientation?)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            return instance.privateIconRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create("IsEnabled", typeof(bool), typeof(Tizen.NUI.Components.Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            if (newValue != null)
            {
                instance.privateIsEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            return instance.privateIsEnabled;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create("IsSelected", typeof(bool), typeof(Tizen.NUI.Components.Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            if (newValue != null)
            {
                instance.privateIsSelected = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            return instance.privateIsSelected;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create("IsSelectable", typeof(bool), typeof(Tizen.NUI.Components.Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            if (newValue != null)
            {
                instance.privateIsSelectable = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.Components.Button)bindable;
            return instance.privateIsSelectable;
        });

        private ImageView overlayImage;

        private TextLabel buttonText;
        private ImageView buttonIcon;

        private EventHandler<StateChangedEventArgs> stateChangeHander;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;

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
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Button with attributes.
        /// </summary>
        /// <param name="controlStyle">Create Button by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button(ButtonStyle controlStyle) : base(controlStyle)
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new ButtonStyle Style => ViewStyle as ButtonStyle;

        /// <summary>
        /// The text of Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Text
        {
            get
            {
                return Style.Text.Text.GetValue(ControlState);
            }
            set
            {
                Style.Text.Text = value;
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
                if (value != null)
                {
                    if (Style.Text.TranslatableText == null)
                    {
                        Style.Text.TranslatableText = new Selector<string>();
                    }
                    Style.Text.TranslatableText.All = value;
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
                if (Style.Text.PointSize == null)
                {
                    Style.Text.PointSize = new Selector<float?>();
                }
                Style.Text.PointSize.All = value;
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
                Style.Text.FontFamily = value;
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
                if (Style.Text.TextColor == null)
                {
                    Style.Text.TextColor = new Selector<Color>();
                }
                Style.Text.TextColor.All = value;
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
                Style.Text.HorizontalAlignment = value;
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
                if (value != null)
                {
                    if (Style.Icon.ResourceUrl == null)
                    {
                        Style.Icon.ResourceUrl = new Selector<string>();
                    }
                    Style.Icon.ResourceUrl.All = value;
                }
            }
        }
        /// <summary>
        /// Text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TextSelector
        {
            get
            {
                return (StringSelector)Style?.Text?.Text;
            }
            set
            {
                if (value != null)
                {
                    Style.Text.Text = value.Clone() as StringSelector;
                }
            }
        }
        /// <summary>
        /// Translateable text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector TranslatableTextSelector
        {
            get
            {
                return (StringSelector)Style?.Text?.TranslatableText;
            }
            set
            {
                if (value != null)
                {
                    Style.Text.TranslatableText = value.Clone() as StringSelector;
                }
            }
        }

        /// <summary>
        /// Text color selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public ColorSelector TextColorSelector
        {
            get
            {
                return (ColorSelector)Style?.Text?.TextColor;
            }
            set
            {
                if(value != null)
                {
                    Style.Text.TextColor = value.Clone() as ColorSelector;
                }
            }
        }

        /// <summary>
        /// Text font size selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public FloatSelector PointSizeSelector
        {
            get
            {
                return (FloatSelector)Style?.Text?.PointSize;
            }
            set
            {
                if (value != null)
                {
                    Style.Text.PointSize = value.Clone() as FloatSelector;
                }
            }
        }

        /// <summary>
        /// Icon image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public StringSelector IconURLSelector
        {
            get
            {
                return (StringSelector)Style?.Icon?.ResourceUrl;
            }
            set
            {
                if (value != null)
                {
                    Style.Icon.ResourceUrl = value.Clone() as StringSelector;
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
            get
            {
                return Style.Icon.Padding;
            }
            set
            {
                if (null != value)
                {
                    Style.Icon.Padding.CopyFrom(value);
                }
            }
        }

        /// <summary>
        /// Text padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents TextPadding
        {
            get
            {
                return Style.Text.Padding;
            }
            set
            {
                if (null != value)
                {
                    Style.Text.Padding.CopyFrom(value);
                }
            }
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
                if (buttonIcon != null)
                {
                    buttonIcon.Relayout -= OnIconRelayout;
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
            if (key.State == Key.StateType.Down)
            {
                if (key.KeyPressedName == "Return")
                {
                    isPressed = true;
                    UpdateState();
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
                    if (Style.IsSelectable != null && Style.IsSelectable == true)
                    {
                        isSelected = !isSelected;
                    }
                    UpdateState();
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
        /// Tap gesture event callback.
        /// </summary>
        /// <param name="source">Source which recieved touch event.</param>
        /// <param name="e">Tap gesture event argument.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnTapGestureDetected(object source, TapGestureDetector.DetectedEventArgs e)
        {
            if (isEnabled)
            {
                ClickEventArgs eventArgs = new ClickEventArgs();
                OnClick(eventArgs);
                base.OnTapGestureDetected(source, e);
            }
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
            PointStateType state = touch.GetState(0);

            switch(state)
            {
                case PointStateType.Down:
                    isPressed = true;
                    UpdateState();
                    return true;
                case PointStateType.Interrupted:
                    isPressed = false;
                    UpdateState();
                    return true;
                case PointStateType.Up:
                    isPressed = false;
                    if (Style.IsSelectable != null && Style.IsSelectable == true)
                    {
                        isSelected = !isSelected;
                    }
                    UpdateState();
                    return true;
                default:
                    break;
            }
            return base.OnTouch(touch);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            ButtonStyle buttonStyle = viewStyle as ButtonStyle;

            if (null != buttonStyle)
            {
                if (null == overlayImage)
                {
                    overlayImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(overlayImage);
                }

                if (null == buttonText)
                {
                    buttonText = new TextLabel();
                    this.Add(buttonText);
                }

                if (null == buttonIcon)
                {
                    buttonIcon = new ImageView();
                    buttonIcon.Relayout += OnIconRelayout;
                    this.Add(buttonIcon);
                }

                overlayImage.ApplyStyle(buttonStyle.Overlay);
                buttonText.ApplyStyle(buttonStyle.Text);
                buttonIcon.ApplyStyle(buttonStyle.Icon);
            }
        }

        /// <summary>
        /// Get Button attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new ButtonStyle();
        }

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
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
            }
        }

        /// <summary>
        /// It is hijack by using protected, attributes copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize()
        {
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
            if (Style.IconRelativeOrientation == null || buttonIcon == null || buttonText == null)
            {
                return;
            }
            buttonText.WidthResizePolicy = ResizePolicyType.Fixed;
            buttonText.HeightResizePolicy = ResizePolicyType.Fixed;
            int textPaddingStart = Style.Text.Padding.Start;
            int textPaddingEnd = Style.Text.Padding.End;
            int textPaddingTop = Style.Text.Padding.Top;
            int textPaddingBottom = Style.Text.Padding.Bottom;

            int iconPaddingStart = Style.Icon.Padding.Start;
            int iconPaddingEnd = Style.Icon.Padding.End;
            int iconPaddingTop = Style.Icon.Padding.Top;
            int iconPaddingBottom = Style.Icon.Padding.Bottom;

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

            int textPaddingStart = Style.Text.Padding.Start;
            int textPaddingEnd = Style.Text.Padding.End;
            int textPaddingTop = Style.Text.Padding.Top;
            int textPaddingBottom = Style.Text.Padding.Bottom;

            int iconPaddingStart = Style.Icon.Padding.Start;
            int iconPaddingEnd = Style.Icon.Padding.End;
            int iconPaddingTop = Style.Icon.Padding.Top;
            int iconPaddingBottom = Style.Icon.Padding.Bottom;

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
        }
        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            ButtonStyle tempAttributes = StyleManager.Instance.GetViewStyle(style) as ButtonStyle;
            if (tempAttributes != null)
            {
                Style.CopyFrom(tempAttributes);
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

    }
}
