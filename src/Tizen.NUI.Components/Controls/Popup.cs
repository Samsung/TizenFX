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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// Popup is one kind of common component, it can be used as popup window.
    /// User can handle Popup button count, head title and content area.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class Popup : Control
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonCountProperty = BindableProperty.Create("ButtonCount", typeof(int), typeof(Popup), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if ((int)newValue != instance.buttonCount)
            {
                instance.buttonCount = (int)newValue;
                instance.UpdateButton();
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.buttonCount;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create("ShadowOffset", typeof(Vector4), typeof(Popup), new Vector4(0, 0, 0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style)
                {
                    instance.Style.ShadowOffset = (Vector4)newValue;
                    instance.UpdateShadow();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.ShadowOffset;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonHeightProperty = BindableProperty.Create("ButtonHeight", typeof(int), typeof(Popup), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Size)
                {
                    instance.Style.Buttons.Size.Height = (int)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return (int)(instance.Style?.Buttons?.Size?.Height ?? 0);
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextPointSizeProperty = BindableProperty.Create("ButtonTextPointSize", typeof(float), typeof(Popup), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Text)
                {
                    instance.Style.Buttons.Text.PointSize = (float)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.Text?.PointSize?.All ?? 0;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonFontFamilyProperty = BindableProperty.Create("ButtonFontFamily", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Text)
                {
                    instance.Style.Buttons.Text.FontFamily = (string)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style?.Buttons?.Text?.FontFamily.All;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextColorProperty = BindableProperty.Create("ButtonTextColor", typeof(Color), typeof(Popup), Color.Transparent, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Text)
                {
                    instance.Style.Buttons.Text.TextColor = (Color)newValue;
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.Text?.TextColor?.All;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonOverLayBackgroundColorSelectorProperty = BindableProperty.Create("ButtonOverLayBackgroundColorSelector", typeof(Selector<Color>), typeof(Popup), new Selector<Color>(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Overlay)
                {
                    Selector<Color> color = (Selector<Color>)newValue;
                    if (null == instance.Style.Buttons.Overlay.BackgroundColor)
                    {
                        instance.Style.Buttons.Overlay.BackgroundColor = new Selector<Color>();
                    }
                    instance.Style.Buttons.Overlay.BackgroundColor.Clone(color);
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.Overlay?.BackgroundColor;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonTextAlignmentProperty = BindableProperty.Create("ButtonTextAlignment", typeof(HorizontalAlignment), typeof(Popup), new HorizontalAlignment(), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.Text)
                {
                    instance.Style.Buttons.Text.HorizontalAlignment = (HorizontalAlignment)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.Text?.HorizontalAlignment ?? HorizontalAlignment.Center;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonBackgroundProperty = BindableProperty.Create("ButtonBackground", typeof(string), typeof(Popup), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.BackgroundImage)
                {
                    instance.Style.Buttons.BackgroundImage = (string)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.BackgroundImage?.All;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ButtonBackgroundBorderProperty = BindableProperty.Create("ButtonBackgroundBorder", typeof(Rectangle), typeof(Popup), new Rectangle(0, 0, 0, 0), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Popup)bindable;
            if (newValue != null)
            {
                if (null != instance.Style?.Buttons?.BackgroundImageBorder)
                {
                    instance.Style.Buttons.BackgroundImageBorder = (Rectangle)newValue;
                    instance.UpdateButton();
                }
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Popup)bindable;
            return instance.Style.Buttons?.BackgroundImageBorder?.All;
        });

        private TextLabel titleText;
        private List<Button> buttonList;
        private List<string> buttonTextList = new List<string>();

        private int buttonCount = 0;

        /// <summary>
        /// Creates a new instance of a Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Popup() : base()
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Popup with style.
        /// </summary>
        /// <param name="style">Create Popup by special style defined in UX.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Creates a new instance of a Popup with attributes.
        /// </summary>
        /// <param name="attributes">Create Popup by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup(PopupStyle attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ButtonClickEventArgs> PopupButtonClickEvent;

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new PopupStyle Style => ViewStyle as PopupStyle;

        /// <summary>
        /// Title text string in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string TitleText
        {
            get
            {
                return Style?.Title?.Text?.All;
            }
            set
            {
                if (null != Style?.Title)
                {
                    Style.Title.Text = value;
                }
            }
        }

        /// <summary>
        /// Title text point size in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float TitlePointSize
        {
            get
            {
                return Style?.Title?.PointSize?.All ?? 0;
            }
            set
            {
                if (null != Style?.Title)
                {
                    Style.Title.PointSize = value;
                }
            }
        }

        /// <summary>
        /// Title text color in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color TitleTextColor
        {
            get
            {
                return Style?.Title?.TextColor?.All;
            }
            set
            {
                if (null != Style?.Title)
                {
                    Style.Title.TextColor = value;
                }
            }
        }

        /// <summary>
        /// Title text horizontal alignment in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public HorizontalAlignment TitleTextHorizontalAlignment
        {
            get
            {
                return Style?.Title?.HorizontalAlignment ?? HorizontalAlignment.Center;
            }
            set
            {
                Style.Title.HorizontalAlignment = value;
            }
        }

        /// <summary>
        /// Title text's position in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Position TitleTextPosition
        {
            get
            {
                return Style?.Title?.Position ?? new Position(0, 0, 0);
            }
            set
            {
                Style.Title.Position = value;
            }
        }

        /// <summary>
        /// Title text's height in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int TitleHeight
        {
            get
            {
                return (int)(Style?.Title?.Size?.Height ?? 0);
            }
            set
            {
                Style.Title.Size.Height = value;
            }
        }

        /// <summary>
        /// Content view in Popup, only can be gotten.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public View ContentView
        {
            get;
            private set;
        }

        /// <summary>
        /// Button count in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int ButtonCount
        {
            get
            {
                return (int)GetValue(ButtonCountProperty);
            }
            set
            {
                SetValue(ButtonCountProperty, value);
            }
        }

        /// <summary>
        /// Shadow offset in Popup, including left, right, up and bottom offset.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 ShadowOffset
        {
            get
            {
                return (Vector4)GetValue(ShadowOffsetProperty);
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        /// <summary>
        /// Button height in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int ButtonHeight
        {
            get
            {
                return (int)GetValue(ButtonHeightProperty);
            }
            set
            {
                SetValue(ButtonHeightProperty, value);
            }
        }

        /// <summary>
        /// Button text point size in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float ButtonTextPointSize
        {
            get
            {
                return (float)GetValue(ButtonTextPointSizeProperty);
            }
            set
            {
                SetValue(ButtonTextPointSizeProperty, value);
            }
        }

        /// <summary>
        /// Button text font family in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string ButtonFontFamily
        {
            get
            {           
                return (string)GetValue(ButtonFontFamilyProperty);
            }
            set
            {
                SetValue(ButtonFontFamilyProperty, value);
            }
        }

        /// <summary>
        /// Button text color in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Color ButtonTextColor
        {
            get
            {
                return (Color)GetValue(ButtonTextColorProperty);
            }
            set
            {
                SetValue(ButtonTextColorProperty, value);
            }
        }

        /// <summary>
        /// Button overlay background color selector in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> ButtonOverLayBackgroundColorSelector
        {
            get
            {
                return (Selector<Color>)GetValue(ButtonOverLayBackgroundColorSelectorProperty);
            }
            set
            {
                SetValue(ButtonOverLayBackgroundColorSelectorProperty, value);
            }
        }

        /// <summary>
        /// Button text horizontal alignment in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public HorizontalAlignment ButtonTextAlignment
        {
            get
            {   
                return (HorizontalAlignment)GetValue(ButtonTextAlignmentProperty);
            }
            set
            {
                SetValue(ButtonTextAlignmentProperty, value);
            }
        }

        /// <summary>
        /// Button background image's resource url in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ButtonBackgroundImageURL
        {
            get
            {     
                return (string)GetValue(ButtonBackgroundProperty);
            }
            set
            {
                SetValue(ButtonBackgroundProperty, value);
            }
        }

        /// <summary>
        /// Button background image's border in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ButtonBackgroundImageBorder
        {
            get
            {
                
                return (Rectangle)GetValue(ButtonBackgroundBorderProperty);
            }
            set
            {
                SetValue(ButtonBackgroundBorderProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new Size2D Size2D
        {
            get
            {
                return base.Size2D;
            }
            set
            {
                base.Size2D = value;
                UpdateShadow();
            }
        }

        /// <summary>
        /// Set button text by index.
        /// </summary>
        /// <param name="index">Button index.</param>
        /// <param name="text">Button text string.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetButtonText(int index, string text)
        {
            if(index < 0 && index >= buttonCount)
            {
                return;
            }
            if(buttonTextList.Count < index + 1)
            {
                for (int i = buttonTextList.Count; i < index + 1; i++)
                {
                    buttonTextList.Add("");
                }
            }
            buttonTextList[index] = text;
            UpdateButton();
        }

        /// <summary>
        /// Dispose Popup and all children on it.
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
                if (titleText != null)
                {
                    Remove(titleText);
                    titleText.Dispose();
                    titleText = null;
                }
                if (ContentView != null)
                {
                    Remove(ContentView);
                    ContentView.Dispose();
                    ContentView = null;
                }
                if (buttonList != null)
                {
                    foreach(Button btn in buttonList)
                    {
                        Remove(btn);
                        btn.Dispose();
                    }
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Focus gained callback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusGained()
        {
            base.OnFocusGained();
        }

        /// <summary>
        /// Focus lost callback.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnFocusLost()
        {
            base.OnFocusLost();
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            PopupStyle popupStyle = viewStyle as PopupStyle;

            if (null != popupStyle)
            {
                if (null == titleText)
                {
                    titleText = new TextLabel();
                    Add(titleText);
                }

                titleText.ApplyStyle(Style.Title);
            }
        }

        /// <summary>
        /// Get Popup attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new PopupStyle();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            PopupStyle tempAttributes = StyleManager.Instance.GetAttributes(style) as PopupStyle;
            if (tempAttributes != null)
            {
                Style.CopyFrom(tempAttributes);
                RelayoutRequest();
            }
        }

        private void Initialize()
        {
            LeaveRequired = true;

            // ContentView
            ContentView = new View()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true
            };
            Add(ContentView);
            ContentView.RaiseToTop();

            // Title
            if (null == titleText)
            {
                titleText = new TextLabel();
                Add(titleText);
            }

            buttonList = new List<Button>();
        }

        private void UpdateButton()
        {
            if (buttonCount <= 0) return;
            if (null == buttonTextList || buttonTextList.Count != buttonCount) return;

            if (null != buttonList)
            {
                foreach (Button btn in buttonList)
                {
                    if (null != btn)
                    {
                        btn.ClickEvent -= ButtonClickEvent;
                        this.Remove(btn);
                        btn.Dispose();
                    }
                }
                buttonList.Clear();
            }

            int sizeWidth = Size2D?.Width ?? 0;
            int buttonWidth = sizeWidth / buttonCount;
            int buttonHeight = (int)(Style?.Buttons?.Size?.Height ?? 0);
            for (int i = 0; i < buttonCount; i++)
            {             
                Button btn = new Button(Style?.Buttons);
                btn.Size2D = new Size2D(buttonWidth, buttonHeight);
                btn.Style.Text.Text = buttonTextList[i];
                btn.ClickEvent += ButtonClickEvent;

                this.Add(btn);
                buttonList.Add(btn);
            }

            int pos = 0;
            if (null != buttonList && buttonList.Count > 0)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    for (int i = buttonList.Count - 1; i >= 0; i--)
                    {
                        buttonList[i].PositionX = pos;
                        pos += buttonList[i].Size2D.Width;
                    }
                }
                else
                {
                    for (int i = 0; i < buttonList.Count; i++)
                    {
                        buttonList[i].PositionX = pos;
                        pos += buttonList[i].Size2D.Width;
                    }
                }
            }

            UpdateContentView();
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            if (PopupButtonClickEvent != null && buttonList != null)
            {
                Button button = sender as Button;
                for (int i = 0; i < buttonList.Count; i++)
                {
                    if(button == buttonList[i])
                    {
                        ButtonClickEventArgs args = new ButtonClickEventArgs();
                        args.ButtonIndex = i;
                        PopupButtonClickEvent(this, args);
                    }
                }
            }
        }
        private void UpdateShadow()
        {
            if (Style.ShadowOffset == null) return;
            int w = 0;
            int h = 0;
            if (Style.Shadow != null)
            {
                w = (int)(Size2D.Width + Style.ShadowOffset.W + Style.ShadowOffset.X);
                h = (int)(Size2D.Height + Style.ShadowOffset.Y + Style.ShadowOffset.Z);

                shadowImage.Size2D = new Size2D(w, h);
            }
        }

        private void UpdateTitle()
        {
            int w = 0;
            int h = 0;
            int titleX = 0;
            int titleY = 0;
            int titleH = 0;
            int buttonH = 0;

            if (Style.Title != null)
            {
                if (titleText.Text != null && titleText.Text != "")
                {
                    Style.Title.Text = new Selector<string> { All = titleText.Text };
                    w = (int)(Size2D.Width - titleText.PositionX * 2);

                    if (Style.Title.Size != null)
                    {
                        titleH = (int)titleText.Size.Height;
                    }
                    titleText.Size2D = new Size2D(w, titleH);                 
                }
                else
                {
                    titleText.Size2D = new Size2D(0, 0);
                }
            }

            if (titleText != null)
            {
                if (LayoutDirection == ViewLayoutDirectionType.RTL)
                {
                    if (Style.Title != null)
                    {
                        Style.Title.HorizontalAlignment = HorizontalAlignment.End;
                    }
                    titleText.HorizontalAlignment = HorizontalAlignment.End;
                }
                else if (LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    if (Style.Title != null)
                    {
                        Style.Title.HorizontalAlignment = HorizontalAlignment.Begin;
                    }
                    titleText.HorizontalAlignment = HorizontalAlignment.Begin;
                }
            }

            UpdateContentView();
        }

        private void UpdateContentView()
        {
            int titleX = 0;
            int titleY = 0;
            int titleH = 0;
            if (Style.Title.Size != null)
            {
                titleH = (int)titleText.Size.Height;
            }
            if (Style.Title.Position != null)
            {
                titleX = (int)Style.Title.Position.X;
                titleY = (int)Style.Title.Position.Y;
            }
            int buttonH = (int)Style.Buttons.Size.Height;

            ContentView.Size2D = new Size2D(Size2D.Width - titleX * 2, Size2D.Height - titleY - titleH - buttonH);
            ContentView.Position2D = new Position2D(titleX, titleY + titleH);
            ContentView.RaiseToTop();
        }

        /// <summary>
        /// ButtonClickEventArgs is a class to record button click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public class ButtonClickEventArgs : EventArgs
        {
            /// <summary> Button index which is clicked in Popup </summary>
            /// <since_tizen> 6 </since_tizen>
            public int ButtonIndex;
        }
    }
}
