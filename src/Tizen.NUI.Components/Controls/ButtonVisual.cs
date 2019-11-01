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
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class ButtonVisual : Control
    {
        //private ImageView backgroundImage;
        //private ImageView shadowImage;
        //private ImageView overlayImage;
        //private TextLabel buttonText;
        //private ImageView buttonIcon;

        private NPatchVisual backgroundImageVisual;
        private NPatchVisual shadowImageVisual;
        private NPatchVisual overlayImageVisual;
        private TextVisual buttonTextVisual;
        private ImageVisual buttonIconVisual;

        private bool backgroundImageVisualAdded = false;
        private bool shadowImageVisualAdded = false;
        private bool overlayImageVisualAdded = false;
        private bool buttonTextVisualAdded = false;
        private bool buttonIconVisualAdded = false;

        private ButtonVisualAttributes buttonAttributes;
        private EventHandler<StateChangeEventArgs> stateChangeHander;

        private bool isSelected = false;
        private bool isEnabled = true;
        private bool isPressed = false;

        /// <summary>
        /// Creates a new instance of a Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ButtonVisual() : base()
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
        public ButtonVisual(string style) : base(style)
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
        public ButtonVisual(ButtonVisualAttributes attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<ClickEventArgs> ClickEvent;

        /// <summary>
        /// An event for the button state changed signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<StateChangeEventArgs> StateChangedEvent
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum IconOrientation
        {
            /// <summary>
            /// Top.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Top,
            /// <summary>
            /// Bottom.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Bottom,
            /// <summary>
            /// Left.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Left,
            /// <summary>
            /// Right.
            /// </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            Right,
        }

        /// <summary>
        /// Flag to decide Button can be selected or not.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    backgroundImageVisual.URL = value;
                    //RelayoutRequest();
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
                    backgroundImageVisual.Border = value;
                    //RelayoutRequest();
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
                    shadowImageVisual.URL = value;
                    //RelayoutRequest();
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
                    shadowImageVisual.Border = value;
                    //RelayoutRequest();
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
                    overlayImageVisual.URL = value;
                    //RelayoutRequest();
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
                    overlayImageVisual.Border = value;
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text string in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    buttonTextVisual.Text = value;
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Translate text string in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public string TranslatableText
        //{
        //    get
        //    {
        //        return buttonAttributes?.TextAttributes?.TranslatableText?.All;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            CreateTextAttributes();
        //            if (buttonAttributes.TextAttributes.TranslatableText == null)
        //            {
        //                buttonAttributes.TextAttributes.TranslatableText = new StringSelector();
        //            }
        //            buttonAttributes.TextAttributes.TranslatableText.All = value;

        //            RelayoutRequest();
        //        }
        //    }
        //}

        /// <summary>
        /// Text point size in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                buttonTextVisual.PointSize = value;
                //RelayoutRequest();
            }
        }

        /// <summary>
        /// Text font family in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                buttonTextVisual.FontFamily = value;
                //RelayoutRequest();
            }
        }

        /// <summary>
        /// Text color in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                buttonTextVisual.TextColor = value;
                //RelayoutRequest();
            }
        }

        /// <summary>
        /// Text horizontal alignment in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                buttonTextVisual.HorizontalAlignment = value;
                //RelayoutRequest();
            }
        }

        /// <summary>
        /// Icon image's resource url in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    buttonIconVisual.URL = value;
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    buttonTextVisual.Text = value.GetValue(State);
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Translateable text string selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //public StringSelector TranslatableTextSelector
        //{
        //    get
        //    {
        //        return buttonAttributes?.TextAttributes?.TranslatableText;
        //    }
        //    set
        //    {
        //        if (value != null)
        //        {
        //            CreateTextAttributes();
        //            buttonAttributes.TextAttributes.TranslatableText = value.Clone() as StringSelector;
        //            RelayoutRequest();
        //        }
        //    }
        //}

        /// <summary>
        /// Text color selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    buttonTextVisual.TextColor = value.GetValue(State);
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Text font size selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    //RelayoutRequest();
                    buttonTextVisual.PointSize = (float)value.GetValue(State);
                }
            }
        }

        /// <summary>
        /// Icon image's resource url selector in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    buttonIconVisual.URL = value.GetValue(State);
                    //RelayoutRequest();
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
                    backgroundImageVisual.URL = value.GetValue(State);
                    //RelayoutRequest();
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
                    backgroundImageVisual.Border = value.GetValue(State);
                    //RelayoutRequest();
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
                    shadowImageVisual.URL = value.GetValue(State);
                    //RelayoutRequest();
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
                    shadowImageVisual.Border = value.GetValue(State);
                    //RelayoutRequest();
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
                    overlayImageVisual.URL = value.GetValue(State);
                    //RelayoutRequest();
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
                    overlayImageVisual.Border = value.GetValue(State);
                    //RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Flag to decide selected state in Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    //RelayoutRequest();
                    //MeasureText();
                    LayoutChild();
                }
            }
        }

        /// <summary>
        /// Icon left padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IconPaddingLeft
        {
            get
            {
                return buttonAttributes?.IconAttributes?.PaddingLeft ?? 0;
            }
            set
            {
                CreateIconAttributes();
                buttonAttributes.IconAttributes.PaddingLeft = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Icon right padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IconPaddingRight
        {
            get
            {
                return buttonAttributes?.IconAttributes?.PaddingRight ?? 0;
            }
            set
            {
                CreateIconAttributes();
                buttonAttributes.IconAttributes.PaddingRight = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Icon top padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IconPaddingTop
        {
            get
            {
                return buttonAttributes?.IconAttributes?.PaddingTop ?? 0;
            }
            set
            {
                CreateIconAttributes();
                buttonAttributes.IconAttributes.PaddingTop = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Icon bottom padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int IconPaddingBottom
        {
            get
            {
                return buttonAttributes?.IconAttributes?.PaddingBottom ?? 0;
            }
            set
            {
                CreateIconAttributes();
                buttonAttributes.IconAttributes.PaddingBottom = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Text left padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingLeft
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PaddingLeft ?? 0;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.PaddingLeft = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Text right padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingRight
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PaddingRight ?? 0;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.PaddingRight = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Text top padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingTop
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PaddingTop ?? 0;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.PaddingTop = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }

        /// <summary>
        /// Text bottom padding in Button, work only when show icon and text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int TextPaddingBottom
        {
            get
            {
                return buttonAttributes?.TextAttributes?.PaddingBottom ?? 0;
            }
            set
            {
                CreateTextAttributes();
                buttonAttributes.TextAttributes.PaddingBottom = value;
                //RelayoutRequest();
                //MeasureText();
                LayoutChild();
            }
        }
        
        public new Size Size
        {
            get
            {
                return this.Size;
            }
            set
            {
                buttonAttributes.Size = value;
                base.Size = value;
                LayoutChild();
            }
        }

        /// <summary>
        /// Dispose Button and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //if (buttonIcon != null)
                //{
                //    buttonIcon.Relayout -= OnIconRelayout;
                //    Utility.Dispose(buttonIcon);
                //}
                //if (buttonText != null)
                //{
                //    Utility.Dispose(buttonText);
                //}
                //if (overlayImage != null)
                //{
                //    Utility.Dispose(overlayImage);
                //}
                //if (backgroundImage != null)
                //{
                //    Utility.Dispose(backgroundImage);
                //}
                //if (shadowImage != null)
                //{
                //    Utility.Dispose(shadowImage);
                //}
            }
            this.RemoveAll();

            base.Dispose(type);
        }

        /// <summary>
        /// Called after a key event is received by the view that has had its focus set.
        /// </summary>
        /// <param name="key">The key event.</param>
        /// <returns>True if the key event should be consumed.</returns>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            return new ButtonVisualAttributes();
        }

        /// <summary>
        /// Update Button by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            Console.WriteLine($"Button Visual On Update");
            //MeasureText();
            //LayoutChild();

            if (buttonAttributes.ShadowImageAttributes != null)
            {
                //ApplyAttributes(shadowImageVisual, buttonAttributes.ShadowImageAttributes);
                //this.AddVisual("shadowImageVisual", shadowImageVisual);
            }
            if (buttonAttributes.BackgroundImageAttributes != null)
            {
                //this.AddVisual("backgroundImageVisual", backgroundImageVisual);
                //global::System.Console.WriteLine($"Add visual button background image visual");
                //ApplyAttributes(backgroundImageVisual, buttonAttributes.BackgroundImageAttributes);
                //Console.WriteLine($"Apply button background image attributes");
            }
            if (buttonAttributes.OverlayImageAttributes != null)
            {
                //ApplyAttributes(overlayImageVisual, buttonAttributes.OverlayImageAttributes);
                //this.AddVisual("overlayImageVisual", overlayImageVisual);
            }
            if (buttonAttributes.TextAttributes != null)
            {
                //ApplyAttributes(buttonTextVisual, buttonAttributes.TextAttributes);
                //Console.WriteLine($"Apply button text visual attributes");
                //this.AddVisual("buttonTextVisual", buttonTextVisual);
                //global::System.Console.WriteLine($"Add visual button text visual");
            }
            if (buttonAttributes.IconAttributes != null)
            {
                //ApplyAttributes(buttonIconVisual, buttonAttributes.IconAttributes);
                //buttonIconVisual.Relayout += OnIconRelayout;
                //this.AddVisual("buttonIconVisual", buttonIconVisual);
            }

            AddVisual();

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

                //OnUpdate();
                UpdateVisual();

                StateChangeEventArgs e = new StateChangeEventArgs
                {
                    PreviousState = sourceState,
                    CurrentState = targetState
                };
                stateChangeHander?.Invoke(this, e);
            }
        }

        private void AddVisual()
        {
            if (!backgroundImageVisualAdded && buttonAttributes.BackgroundImageAttributes?.ResourceURL?.GetValue(State) != null)
            {
                this.AddVisual("backgroundImageVisual", backgroundImageVisual);
                global::System.Console.WriteLine($"Add visual button background image visual");
                backgroundImageVisualAdded = true;
            }
            if (!buttonTextVisualAdded && buttonAttributes.TextAttributes?.Text != null && buttonAttributes.TextAttributes?.PointSize != null)
            {
                this.AddVisual("buttonTextVisual", buttonTextVisual);
                global::System.Console.WriteLine($"Add visual button text visual");
                buttonTextVisualAdded = true;
            }
            if (!shadowImageVisualAdded && buttonAttributes.ShadowImageAttributes?.ResourceURL?.GetValue(State) != null)
            {
                this.AddVisual("shadowImageVisual", shadowImageVisual);
                global::System.Console.WriteLine($"Add visual button shadow image visual");
                shadowImageVisualAdded = true;
            }
            if (!overlayImageVisualAdded && buttonAttributes.OverlayImageAttributes?.ResourceURL?.GetValue(State) != null)
            {
                this.AddVisual("overlayImageVisual", overlayImageVisual);
                global::System.Console.WriteLine($"Add visual button overlay image visual");
                overlayImageVisualAdded = true;
            }
            else if (overlayImageVisualAdded && buttonAttributes.OverlayImageAttributes?.ResourceURL?.GetValue(State) == null)
            {
                this.RemoveVisual("overlayImageVisual");
                overlayImageVisualAdded = false;
            }
            if (!buttonIconVisualAdded && buttonAttributes.IconAttributes?.ResourceURL?.GetValue(State) != null)
            {
                this.AddVisual("buttonIconVisual", buttonIconVisual);
                global::System.Console.WriteLine($"Add visual button icon visual");
                buttonIconVisualAdded = true;
            }
        }

        /// <summary>
        /// It is hijack by using protected, attributes copy problem when class inherited from Button.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        private void Initialize()
        {
            buttonAttributes = attributes as ButtonVisualAttributes;
            if (buttonAttributes == null)
            {
                throw new Exception("Button attribute parse error.");
            }

            ApplyAttributes(this, buttonAttributes);
            LayoutDirectionChanged += OnLayoutDirectionChanged;

            backgroundImageVisual = new NPatchVisual()
            {
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                RelativePosition = new RelativeVector2(0, 0),
                RelativeSize = new RelativeVector2(1.0f, 1.0f),
                DepthIndex = 2,
            };
            shadowImageVisual = new NPatchVisual()
            {
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                RelativePosition = new RelativeVector2(0, 0),
                RelativeSize = new RelativeVector2(1.0f, 1.0f),
                DepthIndex = 1,
            };
            overlayImageVisual = new NPatchVisual()
            {
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                RelativePosition = new RelativeVector2(0, 0),
                RelativeSize = new RelativeVector2(1.0f, 1.0f),
                DepthIndex = 3,
            };
            buttonTextVisual = new TextVisual()
            {
                PointSize = 10,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center,
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                Position = new Vector2(0, 0),
                Size = new Size2D(280, 60),
                DepthIndex = 5,
            };
            buttonIconVisual = new ImageVisual()
            {
                Origin = Visual.AlignType.Center,
                AnchorPoint = Visual.AlignType.Center,
                Position = new Vector2(0, 0),
                Size = new Size2D(50, 50),
                DepthIndex = 5,
            };

            ApplyAttributes(shadowImageVisual, buttonAttributes.ShadowImageAttributes);
            ApplyAttributes(backgroundImageVisual, buttonAttributes.BackgroundImageAttributes);
            ApplyAttributes(overlayImageVisual, buttonAttributes.OverlayImageAttributes);
            ApplyAttributes(buttonTextVisual, buttonAttributes.TextAttributes);
            ApplyAttributes(buttonIconVisual, buttonAttributes.IconAttributes);
        }

        protected virtual void UpdateVisual()
        {
            if (buttonAttributes.ShadowImageAttributes?.ResourceURL is StringSelector)
            {
                if (buttonAttributes.ShadowImageAttributes.ResourceURL.GetValue(State) != null)
                {
                    shadowImageVisual.URL = buttonAttributes.ShadowImageAttributes.ResourceURL.GetValue(State);
                }
            }
            if (buttonAttributes.BackgroundImageAttributes?.ResourceURL is StringSelector)
            {
                if (buttonAttributes.BackgroundImageAttributes.ResourceURL.GetValue(State) != null)
                {
                    backgroundImageVisual.URL = buttonAttributes.BackgroundImageAttributes.ResourceURL.GetValue(State);
                }
            }
            if (buttonAttributes.OverlayImageAttributes?.ResourceURL is StringSelector)
            {
                if (buttonAttributes.OverlayImageAttributes.ResourceURL.GetValue(State) != null)
                {
                    overlayImageVisual.URL = buttonAttributes.OverlayImageAttributes.ResourceURL.GetValue(State);
                }
            }
            if (buttonAttributes.TextAttributes?.Text is StringSelector)
            {
                if (buttonAttributes.TextAttributes.Text.GetValue(State) != null)
                {
                    buttonTextVisual.Text = buttonAttributes.TextAttributes.Text.GetValue(State);
                }
            }
            if (buttonAttributes.TextAttributes?.TextColor is ColorSelector)
            {
                if (buttonAttributes.TextAttributes.TextColor.GetValue(State) != null)
                {
                    buttonTextVisual.TextColor = buttonAttributes.TextAttributes.TextColor.GetValue(State);
                }
            }
            if (buttonAttributes.IconAttributes?.ResourceURL is StringSelector)
            {
                if (buttonAttributes.IconAttributes.ResourceURL.GetValue(State) != null)
                {
                    buttonIconVisual.URL = buttonAttributes.IconAttributes.ResourceURL.GetValue(State);
                }
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
            if ( buttonAttributes.IconRelativeOrientation == null ||
                 buttonIconVisual == null ||
                 buttonTextVisual == null)
            {
                return;
            }
            if (buttonAttributes.IconAttributes?.PaddingLeft == null ||
                             buttonAttributes.IconAttributes?.PaddingRight == null ||
                             buttonAttributes.IconAttributes?.PaddingTop == null ||
                             buttonAttributes.IconAttributes?.PaddingBottom == null)
            {
                return;
            }
            if (buttonAttributes.TextAttributes?.PaddingLeft == null ||
                 buttonAttributes.TextAttributes?.PaddingRight == null ||
                 buttonAttributes.TextAttributes?.PaddingTop == null ||
                 buttonAttributes.TextAttributes?.PaddingBottom == null)
            {
                return;
            }
            if(buttonAttributes.Size == null)
            {
                return;
            }

            //buttonText.WidthResizePolicy = ResizePolicyType.Fixed;
            //buttonText.HeightResizePolicy = ResizePolicyType.Fixed;
            int textPaddingLeft = buttonAttributes.TextAttributes.PaddingLeft ?? 0;
            int textPaddingRight = buttonAttributes.TextAttributes.PaddingRight ?? 0;
            int textPaddingTop = buttonAttributes.TextAttributes.PaddingTop ?? 0;
            int textPaddingBottom = buttonAttributes.TextAttributes.PaddingBottom ?? 0;

            int iconPaddingLeft = buttonAttributes.IconAttributes.PaddingLeft ?? 0;
            int iconPaddingRight = buttonAttributes.IconAttributes.PaddingRight ?? 0;
            int iconPaddingTop = buttonAttributes.IconAttributes.PaddingTop ?? 0;
            int iconPaddingBottom = buttonAttributes.IconAttributes.PaddingBottom ?? 0;
            int sizeWidth;
            int sizeHeight;

            if (IconRelativeOrientation == IconOrientation.Top || IconRelativeOrientation == IconOrientation.Bottom)
            {
                sizeWidth = (int)(SizeWidth - textPaddingLeft - textPaddingRight);
                sizeHeight = (int)(SizeHeight - textPaddingTop - textPaddingBottom - iconPaddingTop - iconPaddingBottom - buttonIconVisual.Size.Height);
                buttonTextVisual.Size = new Size2D(sizeWidth, sizeHeight);
            }
            else
            {
                sizeWidth = (int)(SizeWidth - textPaddingLeft - textPaddingRight - iconPaddingLeft - iconPaddingRight - buttonIconVisual.Size.Width);
                sizeHeight = (int)(SizeHeight - textPaddingTop - textPaddingBottom);
                buttonTextVisual.Size = new Size2D(sizeWidth, sizeHeight);
            }

            //LayoutChild();
        }

        /// <summary>
        /// Layout child, it can be override.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void LayoutChild()
        {
            MeasureText();
            if ( buttonAttributes.IconRelativeOrientation == null ||
                buttonIconVisual == null ||
                buttonTextVisual == null)
            {
                return;
            }
            if ( buttonAttributes.IconAttributes?.PaddingLeft == null ||
                 buttonAttributes.IconAttributes?.PaddingRight == null || 
                 buttonAttributes.IconAttributes?.PaddingTop == null ||
                 buttonAttributes.IconAttributes?.PaddingBottom == null)
            {
                return;
            }
            if ( buttonAttributes.TextAttributes?.PaddingLeft == null ||
                 buttonAttributes.TextAttributes?.PaddingRight == null ||
                 buttonAttributes.TextAttributes?.PaddingTop == null ||
                 buttonAttributes.TextAttributes?.PaddingBottom == null)
            {
                return;
            }

            int textPaddingLeft = buttonAttributes.TextAttributes.PaddingLeft ?? 0;
            int textPaddingRight = buttonAttributes.TextAttributes.PaddingRight?? 0 ;
            int textPaddingTop = buttonAttributes.TextAttributes.PaddingTop ?? 0;
            int textPaddingBottom = buttonAttributes.TextAttributes.PaddingBottom ?? 0;

            int iconPaddingLeft = buttonAttributes.IconAttributes.PaddingLeft ?? 0;
            int iconPaddingRight = buttonAttributes.IconAttributes.PaddingRight ?? 0;
            int iconPaddingTop = buttonAttributes.IconAttributes.PaddingTop ?? 0;
            int iconPaddingBottom = buttonAttributes.IconAttributes.PaddingBottom ?? 0;

            switch (IconRelativeOrientation)
            {
                case IconOrientation.Top:
                    //buttonIconVisual.PositionUsesPivotPoint = true;
                    buttonIconVisual.Origin = Visual.AlignType.TopCenter;
                    buttonIconVisual.AnchorPoint = Visual.AlignType.TopCenter;
                    buttonIconVisual.Position = new Position2D(0, iconPaddingTop);

                    //buttonTextVisual.PositionUsesPivotPoint = true;
                    buttonTextVisual.Origin = Visual.AlignType.BottomCenter;
                    buttonTextVisual.AnchorPoint = Visual.AlignType.BottomCenter;
                    buttonTextVisual.Position = new Position2D(0, -textPaddingBottom);
                    break;
                case IconOrientation.Bottom:
                    //buttonIconVisual.PositionUsesPivotPoint = true;
                    buttonIconVisual.Origin = Visual.AlignType.BottomCenter;
                    buttonIconVisual.AnchorPoint = Visual.AlignType.BottomCenter;
                    buttonIconVisual.Position = new Position2D(0, -iconPaddingBottom);

                    //buttonTextVisual.PositionUsesPivotPoint = true;
                    buttonTextVisual.Origin = Visual.AlignType.TopCenter;
                    buttonTextVisual.AnchorPoint = Visual.AlignType.TopCenter;
                    buttonTextVisual.Position = new Position2D(0, textPaddingTop);
                    break;
                case IconOrientation.Left:
                    if (LayoutDirection == ViewLayoutDirectionType.LTR)
                    {
                        //buttonIconVisual.PositionUsesPivotPoint = true;
                        buttonIconVisual.Origin = Visual.AlignType.CenterBegin;
                        buttonIconVisual.AnchorPoint = Visual.AlignType.CenterBegin;
                        buttonIconVisual.Position = new Position2D(iconPaddingLeft, 0);

                        //buttonTextVisual.PositionUsesPivotPoint = true;
                        buttonTextVisual.Origin = Visual.AlignType.CenterEnd;
                        buttonTextVisual.AnchorPoint = Visual.AlignType.CenterEnd;
                        buttonTextVisual.Position = new Position2D(-textPaddingRight, 0);
                    }
                    else
                    {
                        //buttonIconVisual.PositionUsesPivotPoint = true;
                        buttonIconVisual.Origin = Visual.AlignType.CenterEnd;
                        buttonIconVisual.AnchorPoint = Visual.AlignType.CenterEnd;
                        buttonIconVisual.Position = new Position2D(-iconPaddingLeft, 0);

                        //buttonTextVisual.PositionUsesPivotPoint = true;
                        buttonTextVisual.Origin = Visual.AlignType.CenterBegin;
                        buttonTextVisual.AnchorPoint = Visual.AlignType.CenterBegin;
                        buttonTextVisual.Position = new Position2D(textPaddingRight, 0);
                    }

                    break;
                case IconOrientation.Right:
                    if (LayoutDirection == ViewLayoutDirectionType.RTL)
                    {
                        //buttonIconVisual.PositionUsesPivotPoint = true;
                        buttonIconVisual.Origin = Visual.AlignType.CenterBegin;
                        buttonIconVisual.AnchorPoint = Visual.AlignType.CenterBegin;
                        buttonIconVisual.Position = new Position2D(iconPaddingRight, 0);

                        //buttonTextVisual.PositionUsesPivotPoint = true;
                        buttonTextVisual.Origin = Visual.AlignType.CenterEnd;
                        buttonTextVisual.AnchorPoint = Visual.AlignType.CenterEnd;
                        buttonTextVisual.Position = new Position2D(-textPaddingLeft, 0);
                    }
                    else
                    {
                        //buttonIconVisual.PositionUsesPivotPoint = true;
                        buttonIconVisual.Origin = Visual.AlignType.CenterEnd;
                        buttonIconVisual.AnchorPoint = Visual.AlignType.CenterEnd;
                        buttonIconVisual.Position = new Position2D(-iconPaddingRight, 0);

                        //buttonTextVisual.PositionUsesPivotPoint = true;
                        buttonTextVisual.Origin = Visual.AlignType.CenterBegin;
                        buttonTextVisual.AnchorPoint = Visual.AlignType.CenterBegin;
                        buttonTextVisual.Position = new Position2D(textPaddingLeft, 0);
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
            ButtonVisualAttributes tempAttributes = StyleManager.Instance.GetAttributes(style) as ButtonVisualAttributes;
            if(tempAttributes != null)
            {
                attributes = buttonAttributes = tempAttributes;
                UpdateVisual();
                //RelayoutRequest();
            }
        }

        private void OnLayoutDirectionChanged(object sender, LayoutDirectionChangedEventArgs e)
        {
            //MeasureText();
            UpdateVisual();
            LayoutChild();
        }

        private void OnClick(ClickEventArgs eventArgs)
        {
            ClickEvent?.Invoke(this, eventArgs);
        }

        private void OnIconRelayout(object sender, EventArgs e)
        {
            //MeasureText();
            LayoutChild();
        }

        private void CreateBackgroundAttributes()
        {
            if (buttonAttributes.BackgroundImageAttributes == null)
            {
                buttonAttributes.BackgroundImageAttributes = new NPatchVisualAttributes()
                {
                    //PositionUsesPivotPoint = true,
                    //ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    //PivotPoint = Tizen.NUI.PivotPoint.Center,
                    //WidthResizePolicy = ResizePolicyType.FillToParent,
                    //HeightResizePolicy = ResizePolicyType.FillToParent
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                };
            }
        }

        private void CreateShadowAttributes()
        {
            if (buttonAttributes.ShadowImageAttributes == null)
            {
                buttonAttributes.ShadowImageAttributes = new NPatchVisualAttributes()
                {
                    //PositionUsesPivotPoint = true,
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                    //WidthResizePolicy = ResizePolicyType.FillToParent,
                    //HeightResizePolicy = ResizePolicyType.FillToParent
                };
            }
        }

        private void CreateOverlayAttributes()
        {
            if (buttonAttributes.OverlayImageAttributes == null)
            {
                buttonAttributes.OverlayImageAttributes = new NPatchVisualAttributes()
                {
                    //PositionUsesPivotPoint = true,
                    //ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    //PivotPoint = Tizen.NUI.PivotPoint.Center,
                    //WidthResizePolicy = ResizePolicyType.FillToParent,
                    //HeightResizePolicy = ResizePolicyType.FillToParent
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                };
            }
        }

        private void CreateTextAttributes()
        {
            if (buttonAttributes.TextAttributes == null)
            {
                buttonAttributes.TextAttributes = new TextVisualAttributes()
                {
                    //PositionUsesPivotPoint = true,
                    //ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    //PivotPoint = Tizen.NUI.PivotPoint.Center,
                    //WidthResizePolicy = ResizePolicyType.FillToParent,
                    //HeightResizePolicy = ResizePolicyType.FillToParent,
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    PositionPolicy = VisualTransformPolicyType.Absolute,

                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center
                };
            }
        }

        private void CreateIconAttributes()
        {
            if (buttonAttributes.IconAttributes == null)
            {
                buttonAttributes.IconAttributes = new ImageVisualAttributes()
                {
                    //PositionUsesPivotPoint = true,
                    //ParentOrigin = Tizen.NUI.ParentOrigin.Center,
                    //PivotPoint = Tizen.NUI.PivotPoint.Center,
                    //WidthResizePolicy = ResizePolicyType.UseNaturalSize,
                    //HeightResizePolicy = ResizePolicyType.UseNaturalSize,
                    Origin = Visual.AlignType.Center,
                    AnchorPoint = Visual.AlignType.Center,
                    SizePolicy = VisualTransformPolicyType.Absolute,
                    PositionPolicy = VisualTransformPolicyType.Absolute,
                };
            }
        }

        /// <summary>
        /// ClickEventArgs is a class to record button click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class ClickEventArgs : EventArgs
        {
        }

        /// <summary>
        /// StateChangeEventArgs is a class to record button state change event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class StateChangeEventArgs : EventArgs
        {
            /// <summary> previous state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlStates PreviousState;
            /// <summary> current state of Button </summary>
            /// <since_tizen> 6 </since_tizen>
            /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
            [EditorBrowsable(EditorBrowsableState.Never)]
            public ControlStates CurrentState;
        }
    }
}
