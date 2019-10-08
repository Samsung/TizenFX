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

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Button is one kind of common component, a button clearly describes what action will occur when the user selects it.
    /// Button may contain text or an icon.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Button : Control
    {
        private ImageView backgroundImage;
        private ImageView shadowImage;
        private ImageView overlayImage;

        private TextLabel buttonText;
        private ImageView buttonIcon;

        private ButtonAttributes buttonAttributes;
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
        /// <param name="attributes">Create Button by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button(ButtonAttributes attributes) : base(attributes)
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
        /// Flag to decide Button can be selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsSelectable
        {
            get
            {
                return buttonAttributes?.IsSelectable ?? false;
            }
            set
            {
                buttonAttributes.IsSelectable = value;
            }
        }
        /// <summary>
        /// Background image's resource url in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImageURL
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (buttonAttributes.BackgroundImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.BackgroundImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.BackgroundImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Background image's border in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle BackgroundImageBorder
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (buttonAttributes.BackgroundImageAttributes.Border == null)
                    {
                        buttonAttributes.BackgroundImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.BackgroundImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Shadow image's resource url in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ShadowImageURL
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (buttonAttributes.ShadowImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.ShadowImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.ShadowImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Shadow image's border in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ShadowImageBorder
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    if (buttonAttributes.ShadowImageAttributes.Border == null)
                    {
                        buttonAttributes.ShadowImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.ShadowImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Overlay image's resource url in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string OverlayImageURL
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    if (buttonAttributes.OverlayImageAttributes.ResourceURL == null)
                    {
                        buttonAttributes.OverlayImageAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.OverlayImageAttributes.ResourceURL.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Overlay image's border in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle OverlayImageBorder
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    if (buttonAttributes.OverlayImageAttributes.Border == null)
                    {
                        buttonAttributes.OverlayImageAttributes.Border = new RectangleSelector();
                    }
                    buttonAttributes.OverlayImageAttributes.Border.All = value;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Text string in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Text
        {
            get
            {
                return buttonAttributes?.TextAttributes?.Text?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if(buttonAttributes.TextAttributes.Text == null)
                    {
                        buttonAttributes.TextAttributes.Text = new StringSelector();
                    }
                    buttonAttributes.TextAttributes.Text.All = value;

                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.TranslatableText?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    if (buttonAttributes.TextAttributes.TranslatableText == null)
                    {
                        buttonAttributes.TextAttributes.TranslatableText = new StringSelector();
                    }
                    buttonAttributes.TextAttributes.TranslatableText.All = value;

                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.PointSize?.All ?? 0;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.PointSize == null)
                {
                    buttonAttributes.TextAttributes.PointSize = new FloatSelector();
                }
                buttonAttributes.TextAttributes.PointSize.All = value;
                RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.FontFamily;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.FontFamily = value;
                RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.TextColor?.All;
            }
            set
            {
                CreateTextAttributes();
                if (buttonAttributes.TextAttributes.TextColor == null)
                {
                    buttonAttributes.TextAttributes.TextColor = new ColorSelector();
                }
                buttonAttributes.TextAttributes.TextColor.All = value;
                RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.HorizontalAlignment = value;
                RelayoutRequest();
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
                return buttonAttributes?.IconAttributes?.ResourceURL?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateIconAttributes();
                    if (buttonAttributes.IconAttributes.ResourceURL == null)
                    {
                        buttonAttributes.IconAttributes.ResourceURL = new StringSelector();
                    }
                    buttonAttributes.IconAttributes.ResourceURL.All = value;
                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.Text;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.Text = value.Clone() as StringSelector;
                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.TranslatableText;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.TranslatableText = value.Clone() as StringSelector;
                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.TextColor;
            }
            set
            {
                if(value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.TextColor = value.Clone() as ColorSelector;
                    RelayoutRequest();
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
                return buttonAttributes?.TextAttributes?.PointSize;
            }
            set
            {
                if (value != null)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.PointSize = value.Clone() as FloatSelector;
                    RelayoutRequest();
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
                return buttonAttributes?.IconAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateIconAttributes();
                    buttonAttributes.IconAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Background image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector BackgroundImageURLSelector
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    buttonAttributes.BackgroundImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Background image's border selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RectangleSelector BackgroundImageBorderSelector
        {
            get
            {
                return buttonAttributes?.BackgroundImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    buttonAttributes.BackgroundImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Shadow image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector ShadowImageURLSelector
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    buttonAttributes.ShadowImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Shadow image's border selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RectangleSelector ShadowImageBorderSelector
        {
            get
            {
                return buttonAttributes?.ShadowImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateShadowAttributes();
                    buttonAttributes.ShadowImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Overlay image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector OverlayImageURLSelector
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.ResourceURL;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    buttonAttributes.OverlayImageAttributes.ResourceURL = value.Clone() as StringSelector;
                    RelayoutRequest();
                }
            }
        }
        /// <summary>
        /// Overlay image's border selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public RectangleSelector OverlayImageBorderSelector
        {
            get
            {
                return buttonAttributes?.OverlayImageAttributes?.Border;
            }
            set
            {
                if (value != null)
                {
                    CreateOverlayAttributes();
                    buttonAttributes.OverlayImageAttributes.Border = value.Clone() as RectangleSelector;
                    RelayoutRequest();
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
                return buttonAttributes?.IconRelativeOrientation;
            }
            set
            {
                if(buttonAttributes != null && buttonAttributes.IconRelativeOrientation != value)
                {
                    buttonAttributes.IconRelativeOrientation = value;
                    RelayoutRequest();
                }
            }
        }

        // <summary>
        /// Icon padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents IconPadding
        {
            get
            {
                if (null == buttonAttributes || null == buttonAttributes.IconAttributes)
                {
                    return null;
                }
                else
                {
                    return new Extents((ushort)buttonAttributes.IconAttributes.PaddingLeft, (ushort)buttonAttributes.IconAttributes.PaddingRight, (ushort)buttonAttributes.IconAttributes.PaddingTop, (ushort)buttonAttributes.IconAttributes.PaddingBottom);
                }
            }
            set
            {
                if (null != value)
                {
                    CreateIconAttributes();
                    buttonAttributes.IconAttributes.PaddingLeft = value.Start;
                    buttonAttributes.IconAttributes.PaddingRight = value.End;
                    buttonAttributes.IconAttributes.PaddingTop = value.Top;
                    buttonAttributes.IconAttributes.PaddingBottom = value.Bottom;
                    RelayoutRequest();
                }
            }
        }

        // <summary>
        /// Text padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Extents TextPadding
        {
            get
            {
                if (null == buttonAttributes || null == buttonAttributes.TextAttributes)
                {
                    return null;
                }
                else
                {
                    return new Extents((ushort)buttonAttributes.TextAttributes.PaddingLeft, (ushort)buttonAttributes.TextAttributes.PaddingRight, (ushort)buttonAttributes.TextAttributes.PaddingTop, (ushort)buttonAttributes.TextAttributes.PaddingBottom);
                }
            }
            set
            {
                if (null != value)
                {
                    CreateTextAttributes();
                    buttonAttributes.TextAttributes.PaddingLeft = value.Start;
                    buttonAttributes.TextAttributes.PaddingRight = value.End;
                    buttonAttributes.TextAttributes.PaddingTop = value.Top;
                    buttonAttributes.TextAttributes.PaddingBottom = value.Bottom;
                    RelayoutRequest();
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
                if (backgroundImage != null)
                {
                    Utility.Dispose(backgroundImage);
                }
                if (shadowImage != null)
                {
                    Utility.Dispose(shadowImage);
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
                    if (buttonAttributes.IsSelectable != null && buttonAttributes.IsSelectable == true)
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
                    if (buttonAttributes.IsSelectable != null && buttonAttributes.IsSelectable == true)
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
        /// <summary>
        /// Get Button attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override Attributes GetAttributes()
        {
            return new ButtonAttributes();
        }
        /// <summary>
        /// Update Button by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            if (buttonAttributes.ShadowImageAttributes != null)
            {
                if(shadowImage == null)
                {
                    shadowImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(shadowImage);
                }
                ApplyAttributes(shadowImage, buttonAttributes.ShadowImageAttributes);
            }

            if (buttonAttributes.BackgroundImageAttributes != null)
            {
                if(backgroundImage == null)
                {
                    backgroundImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(backgroundImage);
                }
                ApplyAttributes(backgroundImage, buttonAttributes.BackgroundImageAttributes);
            }

            if (buttonAttributes.OverlayImageAttributes != null)
            {
                if(overlayImage == null)
                {
                    overlayImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent
                    };
                    this.Add(overlayImage);
                }
                ApplyAttributes(overlayImage, buttonAttributes.OverlayImageAttributes);
            }

            if (buttonAttributes.TextAttributes != null)
            {
                if(buttonText == null)
                {
                    buttonText = new TextLabel();
                    this.Add(buttonText);
                }
                ApplyAttributes(buttonText, buttonAttributes.TextAttributes);
            }

            if (buttonAttributes.IconAttributes != null)
            {
                if(buttonIcon == null)
                {
                    buttonIcon = new ImageView();
                    buttonIcon.Relayout += OnIconRelayout;
                    this.Add(buttonIcon);
                }
                ApplyAttributes(buttonIcon, buttonAttributes.IconAttributes);
            }

            MeasureText();
            LayoutChild();

            Sensitive = isEnabled ? true : false;
        }

        /// <summary>
        /// Update Button State.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void UpdateState()
        {
            ControlStates sourceState = State;
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
                State = targetState;

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
            buttonAttributes = attributes as ButtonAttributes;
            if (buttonAttributes == null)
            {
                throw new Exception("Button attribute parse error.");
            }

            ApplyAttributes(this, buttonAttributes);
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
            if (buttonAttributes.IconRelativeOrientation == null || buttonIcon == null || buttonText == null)
            {
                return;
            }
            buttonText.WidthResizePolicy = ResizePolicyType.Fixed;
            buttonText.HeightResizePolicy = ResizePolicyType.Fixed;
            int textPaddingLeft = buttonAttributes.TextAttributes.PaddingLeft;
            int textPaddingRight = buttonAttributes.TextAttributes.PaddingRight;
            int textPaddingTop = buttonAttributes.TextAttributes.PaddingTop;
            int textPaddingBottom = buttonAttributes.TextAttributes.PaddingBottom;

            int iconPaddingLeft = buttonAttributes.IconAttributes.PaddingLeft;
            int iconPaddingRight = buttonAttributes.IconAttributes.PaddingRight;
            int iconPaddingTop = buttonAttributes.IconAttributes.PaddingTop;
            int iconPaddingBottom = buttonAttributes.IconAttributes.PaddingBottom;

            if (IconRelativeOrientation == IconOrientation.Top || IconRelativeOrientation == IconOrientation.Bottom)
            {
                buttonText.SizeWidth = SizeWidth - textPaddingLeft - textPaddingRight;
                buttonText.SizeHeight = SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - buttonIcon.SizeHeight;
            }
            else
            {
                buttonText.SizeWidth = SizeWidth - textPaddingLeft - textPaddingRight - iconPaddingLeft - iconPaddingRight - buttonIcon.SizeWidth;
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
            if (buttonAttributes.IconRelativeOrientation == null || buttonIcon == null || buttonText == null)
            {
                return;
            }

            int textPaddingLeft = buttonAttributes.TextAttributes.PaddingLeft;
            int textPaddingRight = buttonAttributes.TextAttributes.PaddingRight;
            int textPaddingTop = buttonAttributes.TextAttributes.PaddingTop;
            int textPaddingBottom = buttonAttributes.TextAttributes.PaddingBottom;

            int iconPaddingLeft = buttonAttributes.IconAttributes.PaddingLeft;
            int iconPaddingRight = buttonAttributes.IconAttributes.PaddingRight;
            int iconPaddingTop = buttonAttributes.IconAttributes.PaddingTop;
            int iconPaddingBottom = buttonAttributes.IconAttributes.PaddingBottom;

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
                        buttonIcon.Position2D = new Position2D(iconPaddingLeft, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingRight, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingLeft, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingRight, 0);
                    }

                    break;
                case IconOrientation.Right:
                    if (LayoutDirection == ViewLayoutDirectionType.RTL)
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonIcon.Position2D = new Position2D(iconPaddingRight, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonText.Position2D = new Position2D(-textPaddingLeft, 0);
                    }
                    else
                    {
                        buttonIcon.PositionUsesPivotPoint = true;
                        buttonIcon.ParentOrigin = NUI.ParentOrigin.CenterRight;
                        buttonIcon.PivotPoint = NUI.PivotPoint.CenterRight;
                        buttonIcon.Position2D = new Position2D(-iconPaddingRight, 0);

                        buttonText.PositionUsesPivotPoint = true;
                        buttonText.ParentOrigin = NUI.ParentOrigin.CenterLeft;
                        buttonText.PivotPoint = NUI.PivotPoint.CenterLeft;
                        buttonText.Position2D = new Position2D(textPaddingLeft, 0);
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
            ButtonAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ButtonAttributes;
            if(tempAttributes != null)
            {
                attributes = buttonAttributes = tempAttributes;
                RelayoutRequest();
            }
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

        private void CreateBackgroundAttributes()
        {
            if (buttonAttributes.BackgroundImageAttributes == null)
            {
                buttonAttributes.BackgroundImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateShadowAttributes()
        {
            if (buttonAttributes.ShadowImageAttributes == null)
            {
                buttonAttributes.ShadowImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateOverlayAttributes()
        {
            if (buttonAttributes.OverlayImageAttributes == null)
            {
                buttonAttributes.OverlayImageAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (buttonAttributes.TextAttributes == null)
            {
                buttonAttributes.TextAttributes = new TextAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            }
        }

        private void CreateIconAttributes()
        {
            if (buttonAttributes.IconAttributes == null)
            {
                buttonAttributes.IconAttributes = new ImageAttributes()
                {
                    PositionUsesPivotPoint = true,
                    ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    PivotPoint = Tizen.NUI.PivotPoint.Center,
                    WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                };
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
