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
                return textField?.Text;
            }
            set
            {
                if (null != textField) textField.Text = value;
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
                return textField?.PlaceholderText;
            }
            set
            {
                if (null != textField) textField.PlaceholderText = value;
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
                return textField?.TextColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs?.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.TextColor = value;
                    if (null != textField) textField.TextColor = value;
                }
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
                return textField?.PlaceholderTextColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs?.InputBoxAttributes && null != value)
                {
                    Vector4 color = new Vector4(value.R, value.G, value.B, value.A);
                    inputFieldAttrs.InputBoxAttributes.PlaceholderTextColor = color;
                    if (null != textField) textField.PlaceholderTextColor = color;
                }
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
                return textField?.PrimaryCursorColor;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs?.InputBoxAttributes && null != value)
                {
                    Vector4 color = new Vector4(value.R, value.G, value.B, value.A);
                    inputFieldAttrs.InputBoxAttributes.PrimaryCursorColor = color;
                    if (null != textField) textField.PrimaryCursorColor = color;
                }
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
                return textField?.FontFamily;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs?.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.FontFamily = value;
                    if (null != textField) textField.FontFamily = value;
                }
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
                return textField?.EnableCursorBlink ?? false;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.EnableCursorBlink = value;
                    if (null != textField) textField.EnableCursorBlink = value;
                }
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
                return textField?.EnableSelection ?? false;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs?.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.EnableSelection = value;
                    if (null != textField) textField.EnableSelection = value;
                }
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
                return textField?.CursorWidth ?? 0;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.CursorWidth = value;
                    if (null != textField) textField.CursorWidth = value;
                }
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
                return textField?.Ellipsis ?? false;
            }
            set
            {
                CreateTextFieldAttributes();
                if (null != inputFieldAttrs.InputBoxAttributes)
                {
                    inputFieldAttrs.InputBoxAttributes.Ellipsis = value;
                    if (null != textField) textField.Ellipsis = value;
                }
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
                return inputFieldAttrs?.BackgroundImageAttributes?.ResourceUrl?.All;
            }
            set
            {
                CreateBackgroundAttributes();
                if (null != inputFieldAttrs?.BackgroundImageAttributes)
                {
                    inputFieldAttrs.BackgroundImageAttributes.ResourceUrl = value;
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
                return inputFieldAttrs?.BackgroundImageAttributes?.Border?.All;
            }
            set
            {
                CreateBackgroundAttributes();
                if (null != inputFieldAttrs?.BackgroundImageAttributes)
                {
                    inputFieldAttrs.BackgroundImageAttributes.Border = value;
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
                return inputFieldAttrs?.Space ?? 0;
            }
            set
            {
                if (null != inputFieldAttrs)
                {
                    inputFieldAttrs.Space = value;
                    RelayoutRequest();
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ApplyStyle(ViewStyle viewStyle)
        {
            base.ApplyStyle(viewStyle);

            InputFieldStyle inputFieldStyle = viewStyle as InputFieldStyle;

            if (null != inputFieldStyle.BackgroundImageAttributes)
            {
                if (null == bgImage)
                {
                    bgImage = new ImageView()
                    {
                        WidthResizePolicy = ResizePolicyType.FillToParent,
                        HeightResizePolicy = ResizePolicyType.FillToParent,
                    };

                    this.Add(bgImage);
                }
                bgImage.ApplyStyle(inputFieldStyle.BackgroundImageAttributes);
            }
            if (null != inputFieldStyle.InputBoxAttributes)
            {
                if (null == textField)
                {
                    textField = new TextField()
                    {
                        WidthResizePolicy = ResizePolicyType.Fixed,
                        HeightResizePolicy = ResizePolicyType.Fixed,
                        ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                        PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                        PositionUsesPivotPoint = true,
                    };
                    this.Add(textField);
                    textField.FocusGained += OnTextFieldFocusGained;
                    textField.FocusLost += OnTextFieldFocusLost;
                    textField.TextChanged += OnTextFieldTextChanged;
                    textField.KeyEvent += OnTextFieldKeyEvent;
                }
                textField.ApplyStyle(inputFieldStyle.InputBoxAttributes);
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
            InputFieldStyle tempStyle = StyleManager.Instance.GetViewStyle(style) as InputFieldStyle;
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

            if (null == bgImage)
            {
                bgImage = new ImageView()
                {
                    WidthResizePolicy = ResizePolicyType.FillToParent,
                    HeightResizePolicy = ResizePolicyType.FillToParent,
                };

                this.Add(bgImage);
            }
            if (null == textField)
            {
                textField = new TextField()
                {
                    WidthResizePolicy = ResizePolicyType.Fixed,
                    HeightResizePolicy = ResizePolicyType.Fixed,
                    ParentOrigin = Tizen.NUI.ParentOrigin.CenterLeft,
                    PivotPoint = Tizen.NUI.PivotPoint.CenterLeft,
                    PositionUsesPivotPoint = true,
                };
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
