/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    [Obsolete("Deprecated in API8; Will be removed in API10")]
    public partial class Popup : Control
    {
        private TextLabel titleText;
        private ButtonGroup btGroup = null;
        private Window window = null;
        private Layer container = new Layer();
        private ButtonStyle buttonStyle = new ButtonStyle();

        static Popup()
        {
            if (NUIApplication.IsUsingXaml)
            {
                ButtonHeightProperty = BindableProperty.Create(nameof(ButtonHeight), typeof(int), typeof(Popup), default(int),
                    propertyChanged: SetInternalButtonHeightProperty, defaultValueCreator: GetInternalButtonHeightProperty);
                ButtonTextPointSizeProperty = BindableProperty.Create(nameof(ButtonTextPointSize), typeof(float), typeof(Popup), default(float),
                    propertyChanged: SetInternalButtonTextPointSizeProperty, defaultValueCreator: GetInternalButtonTextPointSizeProperty);
                ButtonFontFamilyProperty = BindableProperty.Create(nameof(ButtonFontFamily), typeof(string), typeof(Popup), string.Empty,
                    propertyChanged: SetInternalButtonFontFamilyProperty, defaultValueCreator: GetInternalButtonFontFamilyProperty);
                ButtonTextColorProperty = BindableProperty.Create(nameof(ButtonTextColor), typeof(Color), typeof(Popup), Color.Transparent,
                    propertyChanged: SetInternalButtonTextColorProperty, defaultValueCreator: GetInternalButtonTextColorProperty);
                ButtonOverLayBackgroundColorSelectorProperty = BindableProperty.Create(nameof(ButtonOverLayBackgroundColorSelector), typeof(Selector<Color>), typeof(Popup), new Selector<Color>(),
                    propertyChanged: SetInternalButtonOverLayBackgroundColorSelectorProperty, defaultValueCreator: GetInternalButtonOverLayBackgroundColorSelectorProperty);
                ButtonTextAlignmentProperty = BindableProperty.Create(nameof(ButtonTextAlignment), typeof(HorizontalAlignment), typeof(Popup), new HorizontalAlignment(),
                    propertyChanged: SetInternalButtonTextAlignmentProperty, defaultValueCreator: GetInternalButtonTextAlignmentProperty);
                ButtonBackgroundProperty = BindableProperty.Create(nameof(ButtonBackground), typeof(string), typeof(Popup), string.Empty,
                    propertyChanged: SetInternalButtonBackgroundProperty, defaultValueCreator: GetInternalButtonBackgroundProperty);
                ButtonBackgroundBorderProperty = BindableProperty.Create(nameof(ButtonBackgroundBorder), typeof(Rectangle), typeof(Popup), new Rectangle(0, 0, 0, 0),
                    propertyChanged: SetInternalButtonBackgroundBorderProperty, defaultValueCreator: GetInternalButtonBackgroundBorderProperty);
                ButtonImageShadowProperty = BindableProperty.Create(nameof(ButtonImageShadow), typeof(ImageShadow), typeof(Popup), null,
                    propertyChanged: SetInternalButtonImageShadowProperty, defaultValueCreator: GetInternalButtonImageShadowProperty);
                TitleTextProperty = BindableProperty.Create(nameof(TitleText), typeof(string), typeof(Popup), default(string),
                    propertyChanged: SetInternalTitleTextProperty, defaultValueCreator: GetInternalTitleTextProperty);
                TitlePointSizeProperty = BindableProperty.Create(nameof(TitlePointSize), typeof(float), typeof(Popup), default(float),
                    propertyChanged: SetInternalTitlePointSizeProperty, defaultValueCreator: GetInternalTitlePointSizeProperty);
                TitleTextColorProperty = BindableProperty.Create(nameof(TitleTextColor), typeof(Color), typeof(Popup), null,
                    propertyChanged: SetInternalTitleTextColorProperty, defaultValueCreator: GetInternalTitleTextColorProperty);
                TitleTextHorizontalAlignmentProperty = BindableProperty.Create(nameof(TitleTextHorizontalAlignment), typeof(HorizontalAlignment), typeof(Popup), default(HorizontalAlignment),
                    propertyChanged: SetInternalTitleTextHorizontalAlignmentProperty, defaultValueCreator: GetInternalTitleTextHorizontalAlignmentProperty);
                TitleTextPositionProperty = BindableProperty.Create(nameof(TitleTextPosition), typeof(Position), typeof(Popup), null,
                    propertyChanged: SetInternalTitleTextPositionProperty, defaultValueCreator: GetInternalTitleTextPositionProperty);
                TitleHeightProperty = BindableProperty.Create(nameof(TitleHeight), typeof(int), typeof(Popup), default(int),
                    propertyChanged: SetInternalTitleHeightProperty, defaultValueCreator: GetInternalTitleHeightProperty);
                ButtonCountProperty = BindableProperty.Create(nameof(ButtonCount), typeof(int), typeof(Popup), default(int),
                    propertyChanged: SetInternalButtonCountProperty, defaultValueCreator: GetInternalButtonCountProperty);
            }
        }

        /// <summary>
        /// Creates a new instance of a Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Popup() : base()
        {
        }

        /// <summary>
        /// Creates a new instance of a Popup with style.
        /// </summary>
        /// <param name="style">Create Popup by special style defined in UX.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup(string style) : base(style)
        {
        }

        /// <summary>
        /// Creates a new instance of a Popup with style.
        /// </summary>
        /// <param name="popupStyle">Create Popup by style customized by user.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Popup(PopupStyle popupStyle) : base(popupStyle)
        {
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Post(Window targetWindow)
        {
            if (targetWindow == null)
            {
                return;
            }

            window = targetWindow;
            window.AddLayer(container);
            container.RaiseToTop();
        }

        /// <summary>
        /// Dismiss the dialog
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual void Dismiss()
        {
            if (window == null)
            {
                return;
            }

            window.RemoveLayer(container);
            window = null;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddButton(string buttonText)
        {
            Button btn = new Button(buttonStyle);
            btn.Text = buttonText;
            btn.ClickEvent += ButtonClickEvent;
            btGroup.AddItem(btn);
            UpdateView();
        }

        /// <summary>
        /// Add button by style's name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddButton(string buttonText, string style)
        {
            AddButton(buttonText);
        }

        /// <summary>
        /// Add button by style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddButton(string buttonText, ButtonStyle style)
        {
            Button btn = new Button(style);
            btn.Text = buttonText;
            btn.ClickEvent += ButtonClickEvent;
            btGroup.AddItem(btn);
            UpdateView();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Button GetButton(int index)
        {
            return btGroup.GetItem(index);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RemoveButton(int index)
        {
            btGroup.RemoveItem(index);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddContentText(View childView)
        {
            if (null != ContentView)
            {
                ContentView.Add(childView);
            }
            UpdateView();
        }

        /// <summary>
        /// An event for the button clicked signal which can be used to subscribe or unsubscribe the event handler provided by the user.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public event EventHandler<ButtonClickEventArgs> PopupButtonClickEvent;

        /// <summary>
        /// Popup Title.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabel Title
        {
            get
            {
                if (null == titleText)
                {
                    titleText = new TextLabel
                    {
                        PositionUsesPivotPoint = true,
                        ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                        HorizontalAlignment = HorizontalAlignment.Begin,
                        VerticalAlignment = VerticalAlignment.Bottom,
                        Text = "Title"
                    };
                    Add(titleText);
                }
                return titleText;
            }
            internal set
            {
                titleText = value;
            }
        }

        /// <summary>
        /// Title text string in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string TitleText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TitleTextProperty) as string;
                }
                else
                {
                    return InternalTitleText;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitleTextProperty, value);
                }
                else
                {
                    InternalTitleText = value;
                }
                NotifyPropertyChanged();
            }
        }
        private string InternalTitleText
        {
            get => Title.Text;
            set => Title.Text = value;
        }

        /// <summary>
        /// Title text point size in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public float TitlePointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(TitlePointSizeProperty);
                }
                else
                {
                    return InternalTitlePointSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitlePointSizeProperty, value);
                }
                else
                {
                    InternalTitlePointSize = value;
                }
                NotifyPropertyChanged();
            }
        }
        private float InternalTitlePointSize
        {
            get => Title.PointSize;
            set => Title.PointSize = value;
        }

        /// <summary>
        /// Title text color in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color TitleTextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TitleTextColorProperty) as Color;
                }
                else
                {
                    return InternalTitleTextColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitleTextColorProperty, value);
                }
                else
                {
                    InternalTitleTextColor = value;
                }
                NotifyPropertyChanged();
            }
        }
        private Color InternalTitleTextColor
        {
            get => Title.TextColor;
            set => Title.TextColor = value;
        }

        /// <summary>
        /// Title text horizontal alignment in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public HorizontalAlignment TitleTextHorizontalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(TitleTextHorizontalAlignmentProperty);
                }
                else
                {
                    return InternalTitleTextHorizontalAlignment;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitleTextHorizontalAlignmentProperty, value);
                }
                else
                {
                    InternalTitleTextHorizontalAlignment = value;
                }
                NotifyPropertyChanged();
            }
        }
        private HorizontalAlignment InternalTitleTextHorizontalAlignment
        {
            get => Title.HorizontalAlignment;
            set => Title.HorizontalAlignment = value;
        }

        /// <summary>
        /// Title text's position in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Position TitleTextPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TitleTextPositionProperty) as Position;
                }
                else
                {
                    return InternalTitleTextPosition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitleTextPositionProperty, value);
                }
                else
                {
                    InternalTitleTextPosition =  value;
                }
                NotifyPropertyChanged();
            }
        }
        private Position InternalTitleTextPosition
        {
            get => Title.Position;
            set => Title.Position = value;
        }

        /// <summary>
        /// Title text's height in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int TitleHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(TitleHeightProperty);
                }
                else
                {
                    return InternalTitleHeight;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TitleHeightProperty, value);
                }
                else
                {
                    InternalTitleHeight = value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalTitleHeight
        {
            get => (int)Title.SizeHeight;
            set => Title.SizeHeight = (int)value;
        }

        /// <summary>
        /// Content view in Popup, only can be gotten.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public View ContentView
        {
            get;
            private set;
        }

        /// <summary>
        /// Button count in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int ButtonCount
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(ButtonCountProperty);
                }
                else
                {
                    return InternalButtonCount;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonCountProperty, value);
                }
                else
                {
                    InternalButtonCount = value;
                }
                NotifyPropertyChanged();
            }
        }
        private int InternalButtonCount
        {
            get;
            set;
        }

        /// <summary>
        /// Button height in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public int ButtonHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(ButtonHeightProperty);
                }
                else
                {
                    return GetInternalButtonHeight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonHeightProperty, value);
                }
                else
                {
                    SetInternalButtonHeight(value);
                }
            }
        }

        private void SetInternalButtonHeight(int newValue)
        {
            btGroup.Itemheight = newValue;
            UpdateView();
        }

        private int GetInternalButtonHeight()
        {
            return (int)btGroup.Itemheight;
        }

        /// <summary>
        /// Button text point size in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public float ButtonTextPointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ButtonTextPointSizeProperty);
                }
                else
                {
                    return btGroup.ItemPointSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonTextPointSizeProperty, value);
                }
                else
                {
                    btGroup.ItemPointSize = value;
                }
            }
        }

        /// <summary>
        /// Button text font family in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public string ButtonFontFamily
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ButtonFontFamilyProperty);
                }
                else
                {
                    return btGroup.ItemFontFamily;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonFontFamilyProperty, value);
                }
                else
                {
                    btGroup.ItemFontFamily =  value;
                }
            }
        }

        /// <summary>
        /// Button text color in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public Color ButtonTextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(ButtonTextColorProperty);
                }
                else
                {
                    return btGroup.ItemTextColor;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonTextColorProperty, value);
                }
                else
                {
                    btGroup.ItemTextColor = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<Color>)GetValue(ButtonOverLayBackgroundColorSelectorProperty);
                }
                else
                {
                    return btGroup.OverLayBackgroundColorSelector;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonOverLayBackgroundColorSelectorProperty, value);
                }
                else
                {
                    btGroup.OverLayBackgroundColorSelector = value;
                }
            }
        }

        /// <summary>
        /// Button text horizontal alignment in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public HorizontalAlignment ButtonTextAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(ButtonTextAlignmentProperty);
                }
                else
                {
                    return btGroup.ItemTextAlignment;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonTextAlignmentProperty, value);
                }
                else
                {
                    btGroup.ItemTextAlignment = value;
                }
            }
        }

        /// <summary>
        /// Button background image's resource url in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ButtonBackground
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(ButtonBackgroundProperty);
                }
                else
                {
                    return btGroup.ItemBackgroundImageUrl;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonBackgroundProperty, value);
                }
                else
                {
                    btGroup.ItemBackgroundImageUrl = value;
                }
            }
        }

        /// <summary>
        /// Button background image's border in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle ButtonBackgroundBorder
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rectangle)GetValue(ButtonBackgroundBorderProperty);
                }
                else
                {
                    return btGroup.ItemBackgroundBorder;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonBackgroundBorderProperty, value);
                }
                else
                {
                    btGroup.ItemBackgroundBorder = value;
                }
            }
        }

        /// <summary>
        /// Button's image shadow in Popup.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageShadow ButtonImageShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (ImageShadow)GetValue(ButtonImageShadowProperty);
                }
                else
                {
                    return btGroup.ItemImageShadow;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ButtonImageShadowProperty, value);
                }
                else
                {
                    btGroup.ItemImageShadow = new ImageShadow(value);
                }
            }
        }


        /// <summary>
        /// Set button text by index.
        /// </summary>
        /// <param name="index">Button index.</param>
        /// <param name="text">Button text string.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        public void SetButtonText(int index, string text)
        {
            AddButton(text);
        }

        /// <summary>
        /// Dispose Popup and all children on it.
        /// </summary>
        /// <param name="type">Dispose type.</param>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
        protected override void Dispose(DisposeTypes type)
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member, It will be removed in API10
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

                if (btGroup != null)
                {
                    btGroup.Dispose();
                    btGroup = null;
                }

                buttonStyle?.Dispose();
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

        /// <summary>
        /// Apply style to popup.
        /// </summary>
        /// <param name="viewStyle">The style to apply.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            if (viewStyle is PopupStyle ppStyle)
            {
                if (ppStyle.Buttons?.SizeHeight != null)
                {
                    ButtonHeight = (int)ppStyle.Buttons.SizeHeight;
                }

                if (ppStyle.Buttons?.Clone() is ButtonStyle newButtonStyle)
                {
                    buttonStyle = newButtonStyle;

                    if (buttonStyle.PositionUsesPivotPoint == null) buttonStyle.PositionUsesPivotPoint = true;
                    if (buttonStyle.ParentOrigin == null) buttonStyle.ParentOrigin = Tizen.NUI.ParentOrigin.BottomLeft;
                    if (buttonStyle.PivotPoint == null) buttonStyle.PivotPoint = Tizen.NUI.PivotPoint.BottomLeft;

                    if (btGroup != null)
                    {
                        for (int i = 0; i < btGroup.Count; i++)
                        {
                            var button = GetButton(i);
                            button.ApplyStyle(buttonStyle);
                        }
                    }
                }

                Title.ApplyStyle(ppStyle.Title);
                Title.RaiseToTop();
            }
        }

        /// <summary>
        /// Get Popup style.
        /// </summary>
        /// <returns>The default popup style.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle CreateViewStyle()
        {
            return new PopupStyle();
        }

        /// <inheritdoc/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            base.OnUpdate();
            UpdateView();
        }

        /// <summary>
        /// Initialize AT-SPI object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void OnInitialize()
        {
            base.OnInitialize();
            AccessibilityRole = Role.Dialog;

            container.Add(this);
            container.SetTouchConsumed(true);
            container.SetHoverConsumed(true);

            LeaveRequired = true;
            PropertyChanged += PopupStylePropertyChanged;

            // ContentView
            ContentView = new View()
            {
                ParentOrigin = Tizen.NUI.ParentOrigin.TopLeft,
                PivotPoint = Tizen.NUI.PivotPoint.TopLeft,
                PositionUsesPivotPoint = true
            };
            Add(ContentView);
            ContentView.RaiseToTop();

            // Button
            btGroup = new ButtonGroup(this);
        }

        /// <summary>
        /// Informs AT-SPI bridge about the set of AT-SPI states associated with this object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override AccessibilityStates AccessibilityCalculateStates()
        {
            var states = base.AccessibilityCalculateStates();

            states[AccessibilityState.Modal] = true;

            return states;
        }

        private void UpdateView()
        {
            btGroup.UpdateButton(buttonStyle);
            UpdateContentView();
            UpdateTitle();
        }

        private void ButtonClickEvent(object sender, Button.ClickEventArgs e)
        {
            if (PopupButtonClickEvent != null && btGroup.Count > 0)
            {
                Button button = sender as Button;
                for (int i = 0; i < btGroup.Count; i++)
                {
                    if (button == GetButton(i))
                    {
                        ButtonClickEventArgs args = new ButtonClickEventArgs();
                        args.ButtonIndex = i;
                        PopupButtonClickEvent(this, args);
                    }
                }
            }
        }

        private void PopupStylePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName is var propName && propName != null && propName.Equals("LayoutDirection"))
            {
                btGroup.UpdateButton(buttonStyle);
            }
        }

        private void UpdateContentView()
        {
            int titleX = 0;
            int titleY = 0;
            int titleH = 0;
            int buttonH = 0;
            string strText = Title.Text;
            if (!string.IsNullOrEmpty(strText) && Title.Size != null)
            {
                titleH = (int)titleText.Size.Height;
            }

            if (!string.IsNullOrEmpty(strText) && Title.Position != null)
            {
                titleX = (int)Title.Position.X;
                titleY = (int)Title.Position.Y;
            }

            if (btGroup.Count != 0)
            {
                buttonH = ButtonHeight;
            }
            ContentView.Size = new Size(Size.Width - titleX * 2, Size.Height - titleY - titleH - buttonH);
            ContentView.Position = new Position(titleX, titleY + titleH);
            ContentView.RaiseToTop();
        }

        private void UpdateTitle()
        {
            if (titleText != null && string.IsNullOrEmpty(Title.Text) && Title.Size != null)
            {
                titleText.RaiseToTop();
            }
        }
        /// <summary>
        /// ButtonClickEventArgs is a class to record button click event arguments which will sent to user.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API8; Will be removed in API10")]
        [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1034:NestedTypesShouldNotBeVisible")]
        public class ButtonClickEventArgs : EventArgs
        {
            /// <summary> Button index which is clicked in Popup </summary>
            /// <since_tizen> 6 </since_tizen>
            /// It will be removed in API10
            [global::System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1051:Do not declare visible instance fields")]
            [Obsolete("Deprecated in API8; Will be removed in API10")]
            public int ButtonIndex;
        }
    }
}
