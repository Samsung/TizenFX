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
using Tizen.NUI.BaseComponents;
using System.ComponentModel;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// InputField is a editable input compoment
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class InputField : Control
    {
        // the background image
        private ImageView bgImage = null;
        // the textField
        private TextField textField = null;
        // the attributes of the inputField
        private InputFieldStyle inputFieldAttrs = null;
        // the flag indicate should relayout the textField in base class
        private bool relayoutTextField = true;

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField() : base()
        {
            Initialize();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField(string style) : base(style)
        {
            Initialize();
        }

        /// <summary>
        /// Initializes a new instance of the InputField class.
        /// </summary>
        /// <param name="attributes">Create Header by attributes customized by user.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public InputField(InputFieldStyle attributes) : base(attributes)
        {
            Initialize();
        }

        /// <summary>
        /// Gets or sets the property for the enabled state.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StateEnabled
        {
            get
            {
                return Sensitive;
            }
            set
            {
                Sensitive = value;
            }
        }

        /// <summary>
        /// Gets or sets the property for the text content.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text
        {
            get
            {
                return textField.Text;
            }
            set
            {
                textField.Text = value;
            }
        }

        /// <summary>
        /// Gets or sets the property for the hint text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string HintText
        {
            get
            {
                return textField.PlaceholderText;
            }
            set
            {
                textField.PlaceholderText = value;
            }
        }

        /// <summary>
        /// Gets or sets the property for the color of the input text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                return textField.TextColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null == inputFieldAttrs.InputBoxAttributes.TextColor)
                {
                    inputFieldAttrs.InputBoxAttributes.TextColor = new Selector<Color>();
                }
                if (null != inputFieldAttrs.InputBoxAttributes.TextColor)
                {
                    inputFieldAttrs.InputBoxAttributes.TextColor.All = value;
                }
                textField.TextColor = value;
            }
        }

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color HintTextColor
        {
            get
            {
                return textField.PlaceholderTextColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null == inputFieldAttrs.InputBoxAttributes.PlaceholderTextColor)
                {
                    inputFieldAttrs.InputBoxAttributes.PlaceholderTextColor = new Selector<Color>();
                }
                if (null != inputFieldAttrs.InputBoxAttributes.PlaceholderTextColor)
                {
                    inputFieldAttrs.InputBoxAttributes.PlaceholderTextColor.All = value;
                }
                textField.PlaceholderTextColor = value;
            }
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color PrimaryCursorColor
        {
            get
            {
                return textField.PrimaryCursorColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null == inputFieldAttrs.InputBoxAttributes.PrimaryCursorColor)
                {
                    inputFieldAttrs.InputBoxAttributes.PrimaryCursorColor = new Selector<Color>();
                }
                if (null != inputFieldAttrs.InputBoxAttributes.PrimaryCursorColor)
                {
                    inputFieldAttrs.InputBoxAttributes.PrimaryCursorColor.All = value;
                }
                textField.PrimaryCursorColor = value;
            }
        }

        /// <summary>
        /// Gets or sets font family of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get
            {
                return textField.FontFamily;
            }
            set
            {
                CreateTextFieldAttributes();
                inputFieldAttrs.InputBoxAttributes.FontFamily = value;
                textField.FontFamily = value;
            }
        }

        /// <summary>
        /// Gets or sets enable cursor blink.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableCursorBlink
        {
            get
            {
                return textField.EnableCursorBlink;
            }
            set
            {
                CreateTextFieldAttributes();
                inputFieldAttrs.InputBoxAttributes.EnableCursorBlink = value;
                textField.EnableCursorBlink = value;
            }
        }

        /// <summary>
        /// Gets or sets enable selection.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableSelection
        {
            get
            {
                return textField.EnableSelection;
            }
            set
            {
                CreateTextFieldAttributes();
                inputFieldAttrs.InputBoxAttributes.EnableSelection = value;
                textField.EnableSelection = value;
            }
        }

        /// <summary>
        /// Gets or sets cursor width.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int CursorWidth
        {
            get
            {
                return textField.CursorWidth;
            }
            set
            {
                CreateTextFieldAttributes();
                inputFieldAttrs.InputBoxAttributes.CursorWidth = value;
                textField.CursorWidth = value;
            }
        }

        /// <summary>
        /// Gets or sets if enable ellipsis.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableEllipsis
        {
            get
            {
                return textField.Ellipsis;
            }
            set
            {
                CreateTextFieldAttributes();
                inputFieldAttrs.InputBoxAttributes.Ellipsis = value;
                textField.Ellipsis = value;
            }
        }

        /// <summary>
        /// Gets or sets background image's resource url of input field.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string BackgroundImageURL
        {
            get
            {
                return inputFieldAttrs.BackgroundImageAttributes?.ResourceUrl?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (inputFieldAttrs.BackgroundImageAttributes.ResourceUrl == null)
                    {
                        inputFieldAttrs.BackgroundImageAttributes.ResourceUrl = new Selector<string>();
                    }
                    if (inputFieldAttrs.BackgroundImageAttributes.ResourceUrl != null)
                    {
                        inputFieldAttrs.BackgroundImageAttributes.ResourceUrl.All = value;
                    }
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
                return inputFieldAttrs.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                if (value != null)
                {
                    CreateBackgroundAttributes();
                    if (inputFieldAttrs.BackgroundImageAttributes.Border == null)
                    {
                        inputFieldAttrs.BackgroundImageAttributes.Border = new Selector<Rectangle>();
                    }
                    if (inputFieldAttrs.BackgroundImageAttributes.Border != null)
                    {
                        inputFieldAttrs.BackgroundImageAttributes.Border.All = value;
                    }
                    RelayoutRequest();
                }
            }
        }

        /// <summary>
        /// Gets and Sets Space.
        /// </summary>
        public int Space
        {
            get
            {
                return inputFieldAttrs.Space ?? 0;
            }
            set
            {
                inputFieldAttrs.Space = value;
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Get Input Field attribues.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override ViewStyle GetViewStyle()
        {
            return new InputFieldStyle();
        }

        /// <summary>
        /// Dispose Input Field and all children on it.
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
                if (bgImage != null)
                {
                    this.Remove(bgImage);
                    bgImage.Dispose();
                    bgImage = null;
                }
                if (null != textField)
                {
                    textField.FocusGained -= OnTextFieldFocusGained;
                    textField.FocusLost -= OnTextFieldFocusLost;
                    textField.TextChanged -= OnTextFieldTextChanged;
                    textField.KeyEvent -= OnTextFieldKeyEvent;
                    this.Remove(textField);
                    textField.Dispose();
                    textField = null;
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// Update Input Field by attributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnUpdate()
        {
            RelayoutComponent();
            OnLayoutDirectionChanged();
        }

        /// <summary>
        /// Theme change callback when theme is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void OnThemeChangedEvent(object sender, StyleManager.ThemeChangeEventArgs e)
        {
            InputFieldStyle tempStyle = StyleManager.Instance.GetAttributes(style) as InputFieldStyle;
            if (tempStyle != null)
            {
                Style.CopyFrom(tempStyle);
                RelayoutRequest();
            }
        }

        /// <summary>
        /// Theme change callback when text field focus is gained, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldFocusGained(object source, EventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field is lost, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldFocusLost(object source, EventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field's text is changed, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void OnTextFieldTextChanged(object sender, TextField.TextChangedEventArgs e)
        {
        }

        /// <summary>
        /// Theme change callback when text field have a key event, this callback will be trigger.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual bool OnTextFieldKeyEvent(object source, KeyEventArgs e)
        {
            return false;
        }

        /// <summary>
        /// Set the text field 2D size
        /// </summary>
        /// <param name="w">Input Field' width.</param>
        /// <param name="h">Input Field' height.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldSize2D(int w, int h)
        {
            if (textField != null)
            {
                textField.Size2D = new Size2D(w, h);
            }
        }

        /// <summary>
        /// Set the text field X pose
        /// </summary>
        /// <param name="x">Input Field' X.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldPosX(int x)
        {
            if (textField != null)
            {
                textField.PositionX = x;
            }
        }

        /// <summary>
        /// Set the text field  text color
        /// </summary>
        /// <param name="color">Input Field' color.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTextFieldTextColor(Color color)
        {
            if (textField != null)
            {
                textField.TextColor = color;
            }
        }

        /// <summary>
        /// Set the text field relayout flag
        /// </summary>
        /// <param name="value">relayout text field' value.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void RelayoutTextField(bool value)
        {
            relayoutTextField = value;
        }

        private void Initialize()
        {
            inputFieldAttrs = Style as InputFieldStyle;
            if (null == inputFieldAttrs)
            {
                throw new Exception("Fail to get the InputField attributes.");
            }

            bgImage = new ImageView();
            if (null == bgImage)
            {
                throw new Exception("Fail to create background image.");
            }

            textField = new TextField();
            if (null == textField)
            {
                throw new Exception("Fail to create text field.");
            }

            if (null != inputFieldAttrs.BackgroundImageAttributes)
            {
                bgImage.WidthResizePolicy = ResizePolicyType.FillToParent;
                bgImage.HeightResizePolicy = ResizePolicyType.FillToParent;
                bgImage.ParentOrigin = Tizen.NUI.ParentOrigin.Center;
                bgImage.PivotPoint = Tizen.NUI.PivotPoint.Center;
                bgImage.PositionUsesPivotPoint = true;
                this.Add(bgImage);
            }

            if (null != inputFieldAttrs.InputBoxAttributes)
            {
                textField.WidthResizePolicy = ResizePolicyType.Fixed;
                textField.HeightResizePolicy = ResizePolicyType.Fixed;
                textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                textField.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                textField.PositionUsesPivotPoint = true;
                this.Add(textField);

                textField.FocusGained += OnTextFieldFocusGained;
                textField.FocusLost += OnTextFieldFocusLost;
                textField.TextChanged += OnTextFieldTextChanged;
                textField.KeyEvent += OnTextFieldKeyEvent;
            }
        }

        private void OnLayoutDirectionChanged()
        {
            if (inputFieldAttrs == null) return;
            if (textField != null)
            {
                if (LayoutDirection == ViewLayoutDirectionType.LTR)
                {
                    if(inputFieldAttrs.InputBoxAttributes != null)
                    {
                        inputFieldAttrs.InputBoxAttributes.HorizontalAlignment = HorizontalAlignment.Begin;
                        inputFieldAttrs.InputBoxAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                        inputFieldAttrs.InputBoxAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                        inputFieldAttrs.InputBoxAttributes.PositionUsesPivotPoint = true;
                    }
                    textField.HorizontalAlignment = HorizontalAlignment.Begin;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterLeft;
                    textField.PositionUsesPivotPoint = true;
                }
                else //ViewLayoutDirectionType.RTL
                {
                    if (inputFieldAttrs.InputBoxAttributes != null)
                    {
                        inputFieldAttrs.InputBoxAttributes.HorizontalAlignment = HorizontalAlignment.End;
                        inputFieldAttrs.InputBoxAttributes.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                        inputFieldAttrs.InputBoxAttributes.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    }
                    textField.HorizontalAlignment = HorizontalAlignment.End;
                    textField.ParentOrigin = Tizen.NUI.ParentOrigin.CenterRight;
                    textField.PivotPoint = Tizen.NUI.PivotPoint.CenterRight;
                    textField.PositionUsesPivotPoint = true;
                }
            }
        }

        private void RelayoutComponent()
        {
            if (!relayoutTextField)
            {
                return;
            }
            int space = inputFieldAttrs.Space ?? 0;

            if (textField != null)
            {
                textField.Size2D = new Size2D(this.Size2D.Width - space * 2, this.Size2D.Height);
                textField.PositionX = space;
            }
        }

        private void CreateBackgroundAttributes()
        {
            if (null == inputFieldAttrs.BackgroundImageAttributes)
            {
                inputFieldAttrs.BackgroundImageAttributes = new ImageViewStyle();
            }
        }

        private void CreateTextFieldAttributes()
        {
            if (null == inputFieldAttrs.InputBoxAttributes)
            {
                inputFieldAttrs.InputBoxAttributes = new TextFieldStyle();
            }
        }
    }
}
