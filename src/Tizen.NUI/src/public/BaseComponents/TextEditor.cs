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

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;
using System.Globalization;
using System.ComponentModel;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextEditor : View
    {
        private string textEditorTextSid = null;
        private string textEditorPlaceHolderTextSid = null;
        private bool systemlangTextFlag = false;
        private InputMethodContext inputMethodContext = null;
        private float fontSizeScale = 1.0f;
        private bool hasFontSizeChangedCallback = false;

        static TextEditor() { }

        /// <summary>
        /// Creates the TextEditor control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextEditor() : this(Interop.TextEditor.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TextEditor with specified style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditor(TextEditorStyle style) : this(Interop.TextLabel.New(), true, style: style)
        {
        }

        /// <summary>
        /// Creates the TextEditor with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditor(bool shown) : this(Interop.TextEditor.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal TextEditor(TextEditor handle, bool shown = true) : this(Interop.TextEditor.NewTextEditor(TextEditor.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

            if (!shown)
            {
                SetVisible(false);
            }
        }

        internal TextEditor(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true, TextEditorStyle style = null) : base(cPtr, cMemoryOwn, style)
        {
            if (!shown)
            {
                SetVisible(false);
            }
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
                return textEditorTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException(null, "ResourceManager about multilingual is null");
                }
                textEditorTextSid = value;
                Text = SetTranslatable(textEditorTextSid);
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
                return textEditorPlaceHolderTextSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException(null, "ResourceManager about multilingual is null");
                }
                textEditorPlaceHolderTextSid = value;
                PlaceholderText = SetTranslatable(textEditorPlaceHolderTextSid);
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
        /// The TextColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textEditor.TextColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 TextColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(TextColorProperty);
                return new Vector4(OnTextColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                SetValue(TextColorProperty, value);
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
        /// The PrimaryCursorColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textEditor.PrimaryCursorColor.X = 0.1f;) is possible.
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
        /// The property cascade chaining set is possible. For example, this (textEditor.SecondaryCursorColor.X = 0.1f;) is possible.
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
        /// The property cascade chaining set is possible. For example, this (textEditor.SelectionHighlightColor.X = 0.1f;) is possible.
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
        /// The property cascade chaining set is possible. For example, this (textEditor.DecorationBoundingBox.X = 1;) is possible.
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
        /// The InputColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textEditor.InputColor.X = 0.1f;) is possible.
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
        /// The LineSpacing property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float LineSpacing
        {
            get
            {
                return (float)GetValue(LineSpacingProperty);
            }
            set
            {
                SetValue(LineSpacingProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputLineSpacing property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float InputLineSpacing
        {
            get
            {
                return (float)GetValue(InputLineSpacingProperty);
            }
            set
            {
                SetValue(InputLineSpacingProperty, value);
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
        /// The SmoothScroll property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool SmoothScroll
        {
            get
            {
                return (bool)GetValue(SmoothScrollProperty);
            }
            set
            {
                SetValue(SmoothScrollProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SmoothScrollDuration
        {
            get
            {
                return (float)GetValue(SmoothScrollDurationProperty);
            }
            set
            {
                SetValue(SmoothScrollDurationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableScrollBar
        {
            get
            {
                return (bool)GetValue(EnableScrollBarProperty);
            }
            set
            {
                SetValue(EnableScrollBarProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollBarShowDuration
        {
            get
            {
                return (float)GetValue(ScrollBarShowDurationProperty);
            }
            set
            {
                SetValue(ScrollBarShowDurationProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollBarFadeDuration
        {
            get
            {
                return (float)GetValue(ScrollBarFadeDurationProperty);
            }
            set
            {
                SetValue(ScrollBarFadeDurationProperty, value);
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
        /// The line count of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LineCount
        {
            get
            {
                int temp = 0;
                GetProperty(TextEditor.Property.LineCount).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// The text to display when the TextEditor is empty and inactive.
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
        /// The Selected Text property (read-only).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectedText
        {
            get
            {
                string temp;
                GetProperty(TextEditor.Property.SelectedText).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// The Placeholder text color.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textEditor.PlaceholderTextColor.X = 0.1f;) is possible.
        /// </remarks>
        /// <since_tizen> 3 </since_tizen>
        public Color PlaceholderTextColor
        {
            get
            {
                Color temp = (Color)GetValue(PlaceholderTextColorProperty);
                return new Color(OnPlaceholderTextColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                SetValue(PlaceholderTextColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableSelection property.
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
        /// The start index for selection.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done, Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedTextStart
        {
            get
            {
                int temp;
                GetProperty(TextEditor.Property.SelectedTextStart).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SelectedTextStart, new PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The end index for selection.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done, Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int SelectedTextEnd
        {
            get
            {
                int temp;
                GetProperty(TextEditor.Property.SelectedTextEnd).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.SelectedTextEnd, new PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Enable editing in text control.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// This will be public opened in tizen_6.0 after ACR done, Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableEditing
        {
            get
            {
                bool temp;
                GetProperty(TextEditor.Property.EnableEditing).Get(out temp);
                return temp;
            }
            set
            {
                SetProperty(TextEditor.Property.EnableEditing, new PropertyValue(value));
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Specify horizontal scroll position in text control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int HorizontalScrollPosition
        {
            get
            {
                int temp;
                using (PropertyValue propertyValue = GetProperty(TextEditor.Property.HorizontalScrollPosition))
                {
                    propertyValue.Get(out temp);
                }
                return temp;
            }
            set
            {
                using (PropertyValue propertyValue = new PropertyValue(value))
                {
                    SetProperty(TextEditor.Property.HorizontalScrollPosition, propertyValue);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Specify vertical scroll position in text control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int VerticalScrollPosition
        {
            get
            {
                int temp;
                using (PropertyValue propertyValue = GetProperty(TextEditor.Property.VerticalScrollPosition))
                {
                    propertyValue.Get(out temp);
                }
                return temp;
            }
            set
            {
                using (PropertyValue propertyValue = new PropertyValue(value))
                {
                    SetProperty(TextEditor.Property.VerticalScrollPosition, propertyValue);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// Specify primary cursor (caret) position in text control.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int PrimaryCursorPosition
        {
            get
            {
                int temp;
                using (PropertyValue propertyValue = GetProperty(TextEditor.Property.PrimaryCursorPosition))
                {
                    propertyValue.Get(out temp);
                }
                return temp;
            }
            set
            {
                using (PropertyValue propertyValue = new PropertyValue(value))
                {
                    SetProperty(TextEditor.Property.PrimaryCursorPosition, propertyValue);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The GrabHandleColor property.
        /// </summary>
        /// <remarks>
        /// The property cascade chaining set is possible. For example, this (textEditor.GrabHandleColor.X = 0.1f;) is possible.
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get
            {
                Color temp = (Color)GetValue(GrabHandleColorProperty);
                return new Color(OnGrabHandleColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                SetValue(GrabHandleColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Placeholder property.
        /// Gets or sets the placeholder: text, color, font family, font style, point size, and pixel size.
        /// </summary>
        /// <example>
        /// The following example demonstrates how to set the placeholder property.
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
        /// TextEditor editor = new TextEditor();
        /// editor.Placeholder = propertyMap;
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
        /// The LineWrapMode property.<br />
        /// The line wrap mode when the text lines over the layout width.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public LineWrapMode LineWrapMode
        {
            get
            {
                return (LineWrapMode)GetValue(LineWrapModeProperty);
            }
            set
            {
                SetValue(LineWrapModeProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Enables Text selection using Shift key.
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

        /// <summary>
        /// The MaxLength property.
        /// </summary>
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                        this.Text = e.TextEditor.Text;
                    };
                }
            }
        }

        /// <summary>
        /// The FontSizeScale property. <br />
        /// The default value is 1.0. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float FontSizeScale
        {
            get
            {
                return fontSizeScale;
            }
            set
            {
                float newFontSizeScale;

                if (fontSizeScale == value) return;

                fontSizeScale = value;
                if (fontSizeScale == Tizen.NUI.FontSizeScale.UseSystemSetting)
                {
                    SystemSettingsFontSize systemSettingsFontSize;

                    try
                    {
                        systemSettingsFontSize = SystemSettings.FontSize;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        systemSettingsFontSize = SystemSettingsFontSize.Normal;
                    }
                    newFontSizeScale = TextUtils.GetFontSizeScale(systemSettingsFontSize);
                    addFontSizeChangedCallback();
                }
                else
                {
                    newFontSizeScale = fontSizeScale;
                    removeFontSizeChangedCallback();
                }

                SetValue(FontSizeScaleProperty, newFontSizeScale);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Scroll the text control by specific amount..
        /// </summary>
        /// <param name="scroll">The amount (in pixels) of scrolling in horizontal &amp; vertical directions.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollBy(Vector2 scroll)
        {
            Interop.TextEditor.ScrollBy(SwigCPtr, Vector2.getCPtr(scroll));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get the InputMethodContext instance.
        /// </summary>
        /// <returns>The InputMethodContext instance.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext GetInputMethodContext()
        {
            if (inputMethodContext == null)
            {
                /*Avoid raising InputMethodContext reference count.*/
                inputMethodContext = new InputMethodContext(Interop.TextEditor.GetInputMethodContext(SwigCPtr), true);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
            return inputMethodContext;
        }

        /// <summary>
        /// Select the whole text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SelectWholeText()
        {
            Interop.TextEditor.SelectWholeText(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clear selection of the text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SelectNone()
        {
            _ = Interop.TextEditor.SelectNone(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextEditor obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t InputStyleChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t(Interop.TextEditor.InputStyleChangedSignal(SwigCPtr));
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
                return;
            }

            if (systemlangTextFlag)
            {
                SystemSettings.LocaleLanguageChanged -= SystemSettings_LocaleLanguageChanged;
            }

            removeFontSizeChangedCallback();

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (this.HasBody())
            {
                if (textEditorTextChangedCallbackDelegate != null)
                {
                    TextChangedSignal().Disconnect(textEditorTextChangedCallbackDelegate);
                }

                if (textEditorMaxLengthReachedCallbackDelegate != null)
                {
                    this.MaxLengthReachedSignal().Disconnect(textEditorMaxLengthReachedCallbackDelegate);
                }
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            // In order to speed up IME hide, temporarily add
            GetInputMethodContext()?.DestroyContext();
            Interop.TextEditor.DeleteTextEditor(swigCPtr);
        }

        private string SetTranslatable(string textEditorSid)
        {
            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textEditorSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
            if (translatableText != null)
            {
                if (systemlangTextFlag == false)
                {
                    SystemSettings.LocaleLanguageChanged += SystemSettings_LocaleLanguageChanged;
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
            if (textEditorTextSid != null)
            {
                Text = NUIApplication.MultilingualResourceManager?.GetString(textEditorTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
            if (textEditorPlaceHolderTextSid != null)
            {
                PlaceholderText = NUIApplication.MultilingualResourceManager?.GetString(textEditorPlaceHolderTextSid, new CultureInfo(e.Value.Replace("_", "-")));
            }
        }

        private void SystemSettingsFontSizeChanged(object sender, FontSizeChangedEventArgs e)
        {
            float newFontSizeScale = TextUtils.GetFontSizeScale(e.Value);
            SetValue(FontSizeScaleProperty, newFontSizeScale);
            NotifyPropertyChanged();
        }

        private void addFontSizeChangedCallback()
        {
            if (hasFontSizeChangedCallback != true)
            {
                try
                {
                    SystemSettings.FontSizeChanged += SystemSettingsFontSizeChanged;
                    hasFontSizeChangedCallback = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasFontSizeChangedCallback = false;
                }
            }
        }

        private void removeFontSizeChangedCallback()
        {
            if (hasFontSizeChangedCallback == true)
            {
                try
                {
                    SystemSettings.FontSizeChanged -= SystemSettingsFontSizeChanged;
                    hasFontSizeChangedCallback = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasFontSizeChangedCallback = true;
                }
            }
        }

        internal new class Property
        {
            internal static readonly int TEXT = Interop.TextEditor.TextGet();
            internal static readonly int TextColor = Interop.TextEditor.TextColorGet();
            internal static readonly int FontFamily = Interop.TextEditor.FontFamilyGet();
            internal static readonly int FontStyle = Interop.TextEditor.FontStyleGet();
            internal static readonly int PointSize = Interop.TextEditor.PointSizeGet();
            internal static readonly int HorizontalAlignment = Interop.TextEditor.HorizontalAlignmentGet();
            internal static readonly int ScrollThreshold = Interop.TextEditor.ScrollThresholdGet();
            internal static readonly int ScrollSpeed = Interop.TextEditor.ScrollSpeedGet();
            internal static readonly int PrimaryCursorColor = Interop.TextEditor.PrimaryCursorColorGet();
            internal static readonly int SecondaryCursorColor = Interop.TextEditor.SecondaryCursorColorGet();
            internal static readonly int EnableCursorBlink = Interop.TextEditor.EnableCursorBlinkGet();
            internal static readonly int CursorBlinkInterval = Interop.TextEditor.CursorBlinkIntervalGet();
            internal static readonly int CursorBlinkDuration = Interop.TextEditor.CursorBlinkDurationGet();
            internal static readonly int CursorWidth = Interop.TextEditor.CursorWidthGet();
            internal static readonly int GrabHandleImage = Interop.TextEditor.GrabHandleImageGet();
            internal static readonly int GrabHandlePressedImage = Interop.TextEditor.GrabHandlePressedImageGet();
            internal static readonly int SelectionHandleImageLeft = Interop.TextEditor.SelectionHandleImageLeftGet();
            internal static readonly int SelectionHandleImageRight = Interop.TextEditor.SelectionHandleImageRightGet();
            internal static readonly int SelectionHandlePressedImageLeft = Interop.TextEditor.SelectionHandlePressedImageLeftGet();
            internal static readonly int SelectionHandlePressedImageRight = Interop.TextEditor.SelectionHandlePressedImageRightGet();
            internal static readonly int SelectionHandleMarkerImageLeft = Interop.TextEditor.SelectionHandleMarkerImageLeftGet();
            internal static readonly int SelectionHandleMarkerImageRight = Interop.TextEditor.SelectionHandleMarkerImageRightGet();
            internal static readonly int SelectionHighlightColor = Interop.TextEditor.SelectionHighlightColorGet();
            internal static readonly int DecorationBoundingBox = Interop.TextEditor.DecorationBoundingBoxGet();
            internal static readonly int EnableMarkup = Interop.TextEditor.EnableMarkupGet();
            internal static readonly int InputColor = Interop.TextEditor.InputColorGet();
            internal static readonly int InputFontFamily = Interop.TextEditor.InputFontFamilyGet();
            internal static readonly int InputFontStyle = Interop.TextEditor.InputFontStyleGet();
            internal static readonly int InputPointSize = Interop.TextEditor.InputPointSizeGet();
            internal static readonly int LineSpacing = Interop.TextEditor.LineSpacingGet();
            internal static readonly int InputLineSpacing = Interop.TextEditor.InputLineSpacingGet();
            internal static readonly int UNDERLINE = Interop.TextEditor.UnderlineGet();
            internal static readonly int InputUnderline = Interop.TextEditor.InputUnderlineGet();
            internal static readonly int SHADOW = Interop.TextEditor.ShadowGet();
            internal static readonly int InputShadow = Interop.TextEditor.InputShadowGet();
            internal static readonly int EMBOSS = Interop.TextEditor.EmbossGet();
            internal static readonly int InputEmboss = Interop.TextEditor.InputEmbossGet();
            internal static readonly int OUTLINE = Interop.TextEditor.OutlineGet();
            internal static readonly int InputOutline = Interop.TextEditor.InputOutlineGet();
            internal static readonly int SmoothScroll = Interop.TextEditor.SmoothScrollGet();
            internal static readonly int SmoothScrollDuration = Interop.TextEditor.SmoothScrollDurationGet();
            internal static readonly int EnableScrollBar = Interop.TextEditor.EnableScrollBarGet();
            internal static readonly int ScrollBarShowDuration = Interop.TextEditor.ScrollBarShowDurationGet();
            internal static readonly int ScrollBarFadeDuration = Interop.TextEditor.ScrollBarFadeDurationGet();
            internal static readonly int PixelSize = Interop.TextEditor.PixelSizeGet();
            internal static readonly int LineCount = Interop.TextEditor.LineCountGet();
            internal static readonly int EnableSelection = Interop.TextEditor.EnableSelectionGet();
            internal static readonly int PLACEHOLDER = Interop.TextEditor.PlaceholderGet();
            internal static readonly int LineWrapMode = Interop.TextEditor.LineWrapModeGet();
            internal static readonly int PlaceholderText = Interop.TextEditor.PlaceholderTextGet();
            internal static readonly int PlaceholderTextColor = Interop.TextEditor.PlaceholderTextColorGet();
            internal static readonly int EnableShiftSelection = Interop.TextEditor.EnableShiftSelectionGet();
            internal static readonly int MatchSystemLanguageDirection = Interop.TextEditor.MatchSystemLanguageDirectionGet();
            internal static readonly int MaxLength = Interop.TextEditor.MaxLengthGet();
            internal static readonly int SelectedTextStart = Interop.TextEditor.SelectedTextStartGet();
            internal static readonly int SelectedTextEnd = Interop.TextEditor.SelectedTextEndGet();
            internal static readonly int EnableEditing = Interop.TextEditor.EnableEditingGet();
            internal static readonly int SelectedText = Interop.TextEditor.SelectedTextGet();
            internal static readonly int HorizontalScrollPosition = Interop.TextEditor.HorizontalScrollPositionGet();
            internal static readonly int VerticalScrollPosition = Interop.TextEditor.VerticalScrollPositionGet();
            internal static readonly int PrimaryCursorPosition = Interop.TextEditor.PrimaryCursorPositionGet();
            internal static readonly int FontSizeScale = Interop.TextEditor.FontSizeScaleGet();
            internal static readonly int GrabHandleColor = Interop.TextEditor.GrabHandleColorGet();
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
                LineSpacing = 0x0010,
                Underline = 0x0020,
                Shadow = 0x0040,
                Emboss = 0x0080,
                Outline = 0x0100
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
            PlaceholderTextColor = new Color(r, g, b, a);
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
        private void OnTextColorChanged(float x, float y, float z, float w)
        {
            TextColor = new Vector4(x, y, z, w);
        }
        private void OnGrabHandleColorChanged(float r, float g, float b, float a)
        {
            GrabHandleColor = new Color(r, g, b, a);
        }
    }
}
