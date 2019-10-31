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
extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;
using System.Globalization;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private string textFieldTextSid = null;
        private string textFieldPlaceHolderTextSid = null;
        private bool systemlangTextFlag = false;
        private InputMethodContext inputMethodCotext = null;

        /// <summary>
        /// Creates the TextField control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextField() : this(Interop.TextField.TextField_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TextField with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextField(bool shown) : this(Interop.TextField.TextField_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal TextField(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true) : base(Interop.TextField.TextField_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextField(TextField handle, bool shown = true) : this(Interop.TextField.new_TextField__SWIG_1(TextField.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal enum ExceedPolicyType
        {
            ExceedPolicyOriginal,
            ExceedPolicyClip
        }

        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatableText
        {
            get
            {
                return textFieldTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                textFieldTextSid = value;
                Text = SetTranslatable(textFieldTextSid);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TranslatablePlaceholderText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatablePlaceholderText
        {
            get
            {
                return textFieldPlaceHolderTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                textFieldPlaceHolderTextSid = value;
                PlaceholderText = SetTranslatable(textFieldPlaceHolderTextSid);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Text property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValueAndForceSendChangeSignal(TextProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderText property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderText
        {
            get
            {
                return (string)GetValue(PlaceholderTextProperty);
            }
            set
            {
                SetValue(PlaceholderTextProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderTextFocused property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderTextFocused
        {
            get
            {
                return (string)GetValue(PlaceholderTextFocusedProperty);
            }
            set
            {
                SetValue(PlaceholderTextFocusedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap FontStyle
        {
            get
            {
                return (PropertyMap)GetValue(FontStyleProperty);
            }
            set
            {
                SetValue(FontStyleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PointSize
        {
            get
            {
                return (float)GetValue(PointSizeProperty);
            }
            set
            {
                SetValue(PointSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MaxLength property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ExceedPolicy property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ExceedPolicy
        {
            get
            {
                return (int)GetValue(ExceedPolicyProperty);
            }
            set
            {
                SetValue(ExceedPolicyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
                NotifyPropertyChanged();
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TextColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.TextColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Color TextColor
        {
            get
            {
                Color temp = (Color)GetValue(TextColorProperty);
                return new Color(OnTextColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                SetValue(TextColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PlaceholderTextColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.PlaceholderTextColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PlaceholderTextColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(PlaceholderTextColorProperty);
                return new Vector4(OnPlaceholderTextColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(PlaceholderTextColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowOffset property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// The property cascade chaining set is possible. For example, this (textField.ShadowOffset.X = 0.1f;) is possible.
        /// </remarks>
        [Obsolete("Please do not use this ShadowOffset(Deprecated). Please use Shadow instead.")]
        public Vector2 ShadowOffset
        {
            get
            {
                PropertyMap map = new PropertyMap();
                GetProperty(TextField.Property.SHADOW).Get(map);
                Vector2 shadowOffset = new Vector2();
                map.Find(TextField.Property.SHADOW, "offset")?.Get(shadowOffset);
                return new Vector2(OnShadowOffsetChanged, shadowOffset.X, shadowOffset.Y);
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("offset", new PropertyValue(value));
                SetValue(ShadowProperty, temp);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// The property cascade chaining set is possible. For example, this (textField.ShadowColor.X = 0.1f;) is possible.
        /// </remarks>
        [Obsolete("Please do not use this ShadowColor(Deprecated). Please use Shadow instead.")]
        public Vector4 ShadowColor
        {
            get
            {
                PropertyMap map = new PropertyMap();
                GetProperty(TextField.Property.SHADOW).Get(map);
                Vector4 shadowColor = new Vector4();
                map.Find(TextField.Property.SHADOW, "color")?.Get(shadowColor);
                return new Vector4(OnShadowColorChanged, shadowColor.X, shadowColor.Y, shadowColor.Z, shadowColor.W);
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("color", new PropertyValue(value));
                SetValue(ShadowProperty, temp);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.PrimaryCursorColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PrimaryCursorColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(PrimaryCursorColorProperty);
                return new Vector4(OnPrimaryCursorColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(PrimaryCursorColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.SecondaryCursorColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SecondaryCursorColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(SecondaryCursorColorProperty);
                return new Vector4(OnSecondaryCursorColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(SecondaryCursorColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableCursorBlink
        {
            get
            {
                return (bool)GetValue(EnableCursorBlinkProperty);
            }
            set
            {
                SetValue(EnableCursorBlinkProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkInterval
        {
            get
            {
                return (float)GetValue(CursorBlinkIntervalProperty);
            }
            set
            {
                SetValue(CursorBlinkIntervalProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkDuration
        {
            get
            {
                return (float)GetValue(CursorBlinkDurationProperty);
            }
            set
            {
                SetValue(CursorBlinkDurationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CursorWidth
        {
            get
            {
                return (int)GetValue(CursorWidthProperty);
            }
            set
            {
                SetValue(CursorWidthProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandleImage
        {
            get
            {
                return (string)GetValue(GrabHandleImageProperty);
            }
            set
            {
                SetValue(GrabHandleImageProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandlePressedImage
        {
            get
            {
                return (string)GetValue(GrabHandlePressedImageProperty);
            }
            set
            {
                SetValue(GrabHandlePressedImageProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollThreshold
        {
            get
            {
                return (float)GetValue(ScrollThresholdProperty);
            }
            set
            {
                SetValue(ScrollThresholdProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollSpeed
        {
            get
            {
                return (float)GetValue(ScrollSpeedProperty);
            }
            set
            {
                SetValue(ScrollSpeedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandleImageLeftProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandleImageRightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandlePressedImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandlePressedImageLeftProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandlePressedImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandlePressedImageRightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleMarkerImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandleMarkerImageLeftProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleMarkerImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandleMarkerImageRightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.SelectionHighlightColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SelectionHighlightColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(SelectionHighlightColorProperty);
                return new Vector4(OnSelectionHighlightColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(SelectionHighlightColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.DecorationBoundingBox.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle DecorationBoundingBox
        {
            get
            {
                Rectangle temp = (Rectangle)GetValue(DecorationBoundingBoxProperty);
                return new Rectangle(OnDecorationBoundingBoxChanged, temp.X, temp.Y, temp.Width, temp.Height);
            }
            set
            {
                SetValue(DecorationBoundingBoxProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputMethodSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputMethodSettings
        {
            get
            {
                return (PropertyMap)GetValue(InputMethodSettingsProperty);
            }
            set
            {
                SetValue(InputMethodSettingsProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textField.InputColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 InputColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(InputColorProperty);
                return new Vector4(OnInputColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(InputColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableMarkup property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableMarkup
        {
            get
            {
                return (bool)GetValue(EnableMarkupProperty);
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputFontFamily
        {
            get
            {
                return (string)GetValue(InputFontFamilyProperty);
            }
            set
            {
                SetValue(InputFontFamilyProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputFontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputFontStyle
        {
            get
            {
                return (PropertyMap)GetValue(InputFontStyleProperty);
            }
            set
            {
                SetValue(InputFontStyleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float InputPointSize
        {
            get
            {
                return (float)GetValue(InputPointSizeProperty);
            }
            set
            {
                SetValue(InputPointSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Underline
        {
            get
            {
                return (PropertyMap)GetValue(UnderlineProperty);
            }
            set
            {
                SetValue(UnderlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputUnderline
        {
            get
            {
                return (string)GetValue(InputUnderlineProperty);
            }
            set
            {
                SetValue(InputUnderlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Shadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Shadow
        {
            get
            {
                return (PropertyMap)GetValue(ShadowProperty);
            }
            set
            {
                SetValue(ShadowProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputShadow
        {
            get
            {
                return (string)GetValue(InputShadowProperty);
            }
            set
            {
                SetValue(InputShadowProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Emboss
        {
            get
            {
                return (string)GetValue(EmbossProperty);
            }
            set
            {
                SetValue(EmbossProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputEmboss
        {
            get
            {
                return (string)GetValue(InputEmbossProperty);
            }
            set
            {
                SetValue(InputEmbossProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Outline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Outline
        {
            get
            {
                return (PropertyMap)GetValue(OutlineProperty);
            }
            set
            {
                SetValue(OutlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputOutline
        {
            get
            {
                return (string)GetValue(InputOutlineProperty);
            }
            set
            {
                SetValue(InputOutlineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HiddenInputSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap HiddenInputSettings
        {
            get
            {
                return (PropertyMap)GetValue(HiddenInputSettingsProperty);
            }
            set
            {
                SetValue(HiddenInputSettingsProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PixelSize
        {
            get
            {
                return (float)GetValue(PixelSizeProperty);
            }
            set
            {
                SetValue(PixelSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Enable selection property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableSelection
        {
            get
            {
                return (bool)GetValue(EnableSelectionProperty);
            }
            set
            {
                SetValue(EnableSelectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Enable selection property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableGrabHandle
        {
            get
            {
                return (bool)GetValue(EnableGrabHandleProperty);
            }
            set
            {
                SetValue(EnableGrabHandleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Enable selection property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableGrabHandlePopup
        {
            get
            {
                return (bool)GetValue(EnableGrabHandlePopupProperty);
            }
            set
            {
                SetValue(EnableGrabHandlePopupProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Placeholder property.
        /// Gets or sets the placeholder: text, color, font family, font style, point size, and pixel size.
        /// </summary>
        /// <example>
        /// The following example demonstrates how to set the Placeholder property.
        /// <code>
        /// PropertyMap propertyMap = new PropertyMap();
        /// propertyMap.Add("text", new PropertyValue("Setting Placeholder Text"));
        /// propertyMap.Add("textFocused", new PropertyValue("Setting Placeholder Text Focused"));
        /// propertyMap.Add("color", new PropertyValue(Color.Red));
        /// propertyMap.Add("fontFamily", new PropertyValue("Arial"));
        /// propertyMap.Add("pointSize", new PropertyValue(12.0f));
        ///
        /// PropertyMap fontStyleMap = new PropertyMap();
        /// fontStyleMap.Add("weight", new PropertyValue("bold"));
        /// fontStyleMap.Add("width", new PropertyValue("condensed"));
        /// fontStyleMap.Add("slant", new PropertyValue("italic"));
        /// propertyMap.Add("fontStyle", new PropertyValue(fontStyleMap));
        ///
        /// TextField field = new TextField();
        /// field.Placeholder = propertyMap;
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Tizen.NUI.PropertyMap Placeholder
        {
            get
            {
                return (PropertyMap)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// Placeholder PropertyMap is used to add ellipsis to placeholder text.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Ellipsis
        {
            get
            {
                return (bool)GetValue(EllipsisProperty);
            }
            set
            {
                SetValue(EllipsisProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Enables selection of the text using the Shift key.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableShiftSelection
        {
            get
            {
                return (bool)GetValue(EnableShiftSelectionProperty);
            }
            set
            {
                SetValue(EnableShiftSelectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool MatchSystemLanguageDirection
        {
            get
            {
                return (bool)GetValue(MatchSystemLanguageDirectionProperty);
            }
            set
            {
                SetValue(MatchSystemLanguageDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// Only used by the IL of xaml, will never changed to not hidden.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool IsCreateByXaml
        {
            get
            {
                return base.IsCreateByXaml;
            }
            set
            {
                base.IsCreateByXaml = value;

                if (value == true)
                {
                    this.TextChanged += (obj, e) =>
                    {
                        this.Text = this.Text;
                    };
                }
            }
        }

        /// <summary>
        /// Get the InputMethodContext instance.
        /// </summary>
        /// <returns>The InputMethodContext instance.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext GetInputMethodContext()
        {
            if (inputMethodCotext == null)
            {
                /*Avoid raising InputMethodContext reference count.*/
                inputMethodCotext = new InputMethodContext(Interop.TextField.TextField_GetInputMethodContext(swigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return inputMethodCotext;
        }

        /// <summary>
        /// Select the whole text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be released at Tizen.NET API Level 5.5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SelectWholeText()
        {
            Interop.TextField.TextField_SelectWholeText(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextField obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t InputStyleChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextField_Dali__Toolkit__TextField__InputStyle__MaskF_t(Interop.TextField.TextField_InputStyleChangedSignal(swigCPtr), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                DisposeQueue.Instance.Add(this);
                return;
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.
            if (this.HasBody())
            {
                if (_textFieldMaxLengthReachedCallbackDelegate != null)
                {
                    this.MaxLengthReachedSignal().Disconnect(_textFieldMaxLengthReachedCallbackDelegate);
                }

                if (_textFieldTextChangedCallbackDelegate != null)
                {
                    TextChangedSignal().Disconnect(_textFieldTextChangedCallbackDelegate);
                }
            }

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    // In order to speed up IME hide, temporarily add
                    GetInputMethodContext()?.DestroyContext();
                    Interop.TextField.delete_TextField(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private string SetTranslatable(string textFieldSid)
        {
            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textFieldSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
            if (translatableText != null)
            {
                if (systemlangTextFlag == false)
                {
                    SystemSettings.LocaleLanguageChanged += new WeakEventHandler<LocaleLanguageChangedEventArgs>(SystemSettings_LocaleLanguageChanged).Handler;
                    systemlangTextFlag = true;
                }
                return translatableText;
            }
            else
            {
                translatableText = "";
                return translatableText;
            }
        }

        private void SystemSettings_LocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            if (textFieldTextSid != null)
            {
                Text = NUIApplication.MultilingualResourceManager?.GetString(textFieldTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
            if (textFieldPlaceHolderTextSid != null)
            {
                PlaceholderText = NUIApplication.MultilingualResourceManager?.GetString(textFieldPlaceHolderTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
        }

        internal new class Property
        {
            internal static readonly int RENDERING_BACKEND = Interop.TextField.TextField_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = Interop.TextField.TextField_Property_TEXT_get();
            internal static readonly int PLACEHOLDER_TEXT = Interop.TextField.TextField_Property_PLACEHOLDER_TEXT_get();
            internal static readonly int PLACEHOLDER_TEXT_FOCUSED = Interop.TextField.TextField_Property_PLACEHOLDER_TEXT_FOCUSED_get();
            internal static readonly int FONT_FAMILY = Interop.TextField.TextField_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = Interop.TextField.TextField_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = Interop.TextField.TextField_Property_POINT_SIZE_get();
            internal static readonly int MAX_LENGTH = Interop.TextField.TextField_Property_MAX_LENGTH_get();
            internal static readonly int EXCEED_POLICY = Interop.TextField.TextField_Property_EXCEED_POLICY_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = Interop.TextField.TextField_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int VERTICAL_ALIGNMENT = Interop.TextField.TextField_Property_VERTICAL_ALIGNMENT_get();
            internal static readonly int TEXT_COLOR = Interop.TextField.TextField_Property_TEXT_COLOR_get();
            internal static readonly int PLACEHOLDER_TEXT_COLOR = Interop.TextField.TextField_Property_PLACEHOLDER_TEXT_COLOR_get();
            internal static readonly int PRIMARY_CURSOR_COLOR = Interop.TextField.TextField_Property_PRIMARY_CURSOR_COLOR_get();
            internal static readonly int SECONDARY_CURSOR_COLOR = Interop.TextField.TextField_Property_SECONDARY_CURSOR_COLOR_get();
            internal static readonly int ENABLE_CURSOR_BLINK = Interop.TextField.TextField_Property_ENABLE_CURSOR_BLINK_get();
            internal static readonly int CURSOR_BLINK_INTERVAL = Interop.TextField.TextField_Property_CURSOR_BLINK_INTERVAL_get();
            internal static readonly int CURSOR_BLINK_DURATION = Interop.TextField.TextField_Property_CURSOR_BLINK_DURATION_get();
            internal static readonly int CURSOR_WIDTH = Interop.TextField.TextField_Property_CURSOR_WIDTH_get();
            internal static readonly int GRAB_HANDLE_IMAGE = Interop.TextField.TextField_Property_GRAB_HANDLE_IMAGE_get();
            internal static readonly int GRAB_HANDLE_PRESSED_IMAGE = Interop.TextField.TextField_Property_GRAB_HANDLE_PRESSED_IMAGE_get();
            internal static readonly int SCROLL_THRESHOLD = Interop.TextField.TextField_Property_SCROLL_THRESHOLD_get();
            internal static readonly int SCROLL_SPEED = Interop.TextField.TextField_Property_SCROLL_SPEED_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_LEFT = Interop.TextField.TextField_Property_SELECTION_HANDLE_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_IMAGE_RIGHT = Interop.TextField.TextField_Property_SELECTION_HANDLE_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_LEFT = Interop.TextField.TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_PRESSED_IMAGE_RIGHT = Interop.TextField.TextField_Property_SELECTION_HANDLE_PRESSED_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_LEFT = Interop.TextField.TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_LEFT_get();
            internal static readonly int SELECTION_HANDLE_MARKER_IMAGE_RIGHT = Interop.TextField.TextField_Property_SELECTION_HANDLE_MARKER_IMAGE_RIGHT_get();
            internal static readonly int SELECTION_HIGHLIGHT_COLOR = Interop.TextField.TextField_Property_SELECTION_HIGHLIGHT_COLOR_get();
            internal static readonly int DECORATION_BOUNDING_BOX = Interop.TextField.TextField_Property_DECORATION_BOUNDING_BOX_get();
            internal static readonly int INPUT_METHOD_SETTINGS = Interop.TextField.TextField_Property_INPUT_METHOD_SETTINGS_get();
            internal static readonly int INPUT_COLOR = Interop.TextField.TextField_Property_INPUT_COLOR_get();
            internal static readonly int ENABLE_MARKUP = Interop.TextField.TextField_Property_ENABLE_MARKUP_get();
            internal static readonly int INPUT_FONT_FAMILY = Interop.TextField.TextField_Property_INPUT_FONT_FAMILY_get();
            internal static readonly int INPUT_FONT_STYLE = Interop.TextField.TextField_Property_INPUT_FONT_STYLE_get();
            internal static readonly int INPUT_POINT_SIZE = Interop.TextField.TextField_Property_INPUT_POINT_SIZE_get();
            internal static readonly int UNDERLINE = Interop.TextField.TextField_Property_UNDERLINE_get();
            internal static readonly int INPUT_UNDERLINE = Interop.TextField.TextField_Property_INPUT_UNDERLINE_get();
            internal static readonly int SHADOW = Interop.TextField.TextField_Property_SHADOW_get();
            internal static readonly int INPUT_SHADOW = Interop.TextField.TextField_Property_INPUT_SHADOW_get();
            internal static readonly int EMBOSS = Interop.TextField.TextField_Property_EMBOSS_get();
            internal static readonly int INPUT_EMBOSS = Interop.TextField.TextField_Property_INPUT_EMBOSS_get();
            internal static readonly int OUTLINE = Interop.TextField.TextField_Property_OUTLINE_get();
            internal static readonly int INPUT_OUTLINE = Interop.TextField.TextField_Property_INPUT_OUTLINE_get();
            internal static readonly int HIDDEN_INPUT_SETTINGS = Interop.TextField.TextField_Property_HIDDEN_INPUT_SETTINGS_get();
            internal static readonly int PIXEL_SIZE = Interop.TextField.TextField_Property_PIXEL_SIZE_get();
            internal static readonly int ENABLE_SELECTION = Interop.TextField.TextField_Property_ENABLE_SELECTION_get();
            internal static readonly int PLACEHOLDER = Interop.TextField.TextField_Property_PLACEHOLDER_get();
            internal static readonly int ELLIPSIS = Interop.TextField.TextField_Property_ELLIPSIS_get();
            internal static readonly int ENABLE_SHIFT_SELECTION = Interop.TextField.TextField_Property_ENABLE_SHIFT_SELECTION_get();
            internal static readonly int MATCH_SYSTEM_LANGUAGE_DIRECTION = Interop.TextField.TextField_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get();
            internal static readonly int ENABLE_GRAB_HANDLE = Interop.TextField.TextField_Property_ENABLE_GRAB_HANDLE_get();
            internal static readonly int ENABLE_GRAB_HANDLE_POPUP = Interop.TextField.TextField_Property_ENABLE_GRAB_HANDLE_POPUP_get();
        }

        internal class InputStyle
        {
            internal enum Mask
            {
                None = 0x0000,
                Color = 0x0001,
                FontFamily = 0x0002,
                PointSize = 0x0004,
                FontStyle = 0x0008,
                Underline = 0x0010,
                Shadow = 0x0020,
                Emboss = 0x0040,
                Outline = 0x0080
            }
        }

        private void OnDecorationBoundingBoxChanged(int x, int y, int width, int height)
        {
            DecorationBoundingBox = new Rectangle(x, y, width, height);
        }
        private void OnInputColorChanged(float x, float y, float z, float w)
        {
            InputColor = new Vector4(x, y, z, w);
        }
        private void OnPlaceholderTextColorChanged(float r, float g, float b, float a)
        {
            PlaceholderTextColor = new Vector4(r, g, b, a);
        }
        private void OnPrimaryCursorColorChanged(float x, float y, float z, float w)
        {
            PrimaryCursorColor = new Vector4(x, y, z, w);
        }
        private void OnSecondaryCursorColorChanged(float x, float y, float z, float w)
        {
            SecondaryCursorColor = new Vector4(x, y, z, w);
        }
        private void OnSelectionHighlightColorChanged(float x, float y, float z, float w)
        {
            SelectionHighlightColor = new Vector4(x, y, z, w);
        }
        private void OnShadowColorChanged(float x, float y, float z, float w)
        {
            ShadowColor = new Vector4(x, y, z, w);
        }
        private void OnShadowOffsetChanged(float x, float y)
        {
            ShadowOffset = new Vector2(x, y);
        }
        private void OnTextColorChanged(float r, float g, float b, float a)
        {
            TextColor = new Color(r, g, b, a);
        }
    }
}
