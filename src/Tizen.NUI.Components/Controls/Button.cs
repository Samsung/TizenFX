﻿/*
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
    public partial class Button : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IconRelativeOrientationProperty = BindableProperty.Create(nameof(IconRelativeOrientation), typeof(IconOrientation?), typeof(Button), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                if (instance.Style != null && instance.Style.IconRelativeOrientation != (IconOrientation?)newValue)
                {
                    instance.Style.IconRelativeOrientation = (IconOrientation?)newValue;
                    instance.UpdateUIContent();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.Style?.IconRelativeOrientation;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(nameof(IsEnabled), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.isEnabled = (bool)newValue;
                instance.UpdateState();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.isEnabled;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectedProperty = BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.isSelected = (bool)newValue;
                instance.UpdateState();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.isSelected;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty IsSelectableProperty = BindableProperty.Create(nameof(IsSelectable), typeof(bool), typeof(Button), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Button)bindable;
            if (newValue != null)
            {
                instance.Style.IsSelectable = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Button)bindable;
            return instance.Style?.IsSelectable ?? false;
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
        /// <since_tizen> 8 </since_tizen>
        public TextLabel TextLabel
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

        /// <summary>
        /// Icon relative orientation in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
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
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        public override bool OnKey(Key key)
        {
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
        public override bool OnTouch(Touch touch)
        {
            if (!IsEnabled || null == touch)
            {
                return false;
            }

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
                    OverlayImage?.ApplyStyle(buttonStyle.Overlay);
                }

                if (buttonStyle.Text != null)
                {
                    TextLabel?.ApplyStyle(buttonStyle.Text);
                }

                if (buttonStyle.Icon != null)
                {
                    Icon?.ApplyStyle(buttonStyle.Icon);
                }
            }
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
        [Obsolete("Deprecated in API8; Will be removed in API10. Please use View.ControlStateChangedEventArgs")]
        public class StateChangedEventArgs : EventArgs
        {
            /// <summary> previous state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public ControlStates PreviousState;
            /// <summary> current state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public ControlStates CurrentState;
        }

        /// <summary>
        /// Get current text part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invalid.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's text part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel GetCurrentText(ButtonExtension extension)
        {
            return (extension == Extension) ? TextLabel : null;
        }

        /// <summary>
        /// Get current icon part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invalid.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's icon part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView GetCurrentIcon(ButtonExtension extension)
        {
            return (extension == Extension) ? Icon : null;
        }

        /// <summary>
        /// Get current overlay image part to the attached ButtonExtension.
        /// </summary>
        /// <remarks>
        /// It returns null if the passed extension is invalid.
        /// </remarks>
        /// <param name="extension">The extension instance that is currently attached to this Button.</param>
        /// <return>The button's overlay image part.</return>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView GetCurrentOverlayImage(ButtonExtension extension)
        {
            return (extension == Extension) ? OverlayImage : null;
        }
    }
}
