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
using Tizen.NUI.Text;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextEditor : View
    {
        static private string defaultStyleName = "Tizen.NUI.BaseComponents.TextEditor";
        static private string defaultFontFamily = "TizenSans";
        private string textEditorTextSid = null;
        private string textEditorPlaceHolderTextSid = null;
        private InputMethodContext inputMethodContext = null;
        private string fontFamily = defaultFontFamily;
        private float fontSizeScale = 1.0f;
        private bool hasSystemLanguageChanged = false;
        private bool hasSystemFontSizeChanged = false;
        private bool hasSystemFontTypeChanged = false;
        private bool isSettingTextInCSharp = false;

        private Color internalPlaceholderTextColor = null;
        private Vector4 internalPrimaryCursorColor = null;
        private Vector4 internalSecondaryCursorColor = null;
        private Vector4 internalSelectionHighlightColor = null;
        private Vector4 internalInputColor = null;
        private Vector4 internalTextColor = null;
        private Color internalGrabHandleColor = null;


        static TextEditor() { }

        /// <summary>
        /// Creates the TextEditor control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextEditor() : this(Interop.TextEditor.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TextEditor with specified style.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditor(TextEditorStyle style) : this(Interop.TextEditor.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true, style: style)
        {
        }

        /// <summary>
        /// Creates the TextEditor with setting the status of shown or hidden.
        /// </summary>
        /// <param name="shown">false : Not displayed (hidden), true : displayed (shown)</param>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditor(bool shown) : this(Interop.TextEditor.New(ThemeManager.GetStyle(defaultStyleName) == null ? false : true), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            SetVisible(shown);
        }

        internal TextEditor(TextEditor handle, bool shown = true) : this(Interop.TextEditor.NewTextEditor(TextEditor.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TextEditor(global::System.IntPtr cPtr, bool cMemoryOwn, bool shown = true, TextEditorStyle style = null) : base(cPtr, cMemoryOwn, style)
        {
            if (!shown)
            {
                SetVisible(false);
            }
            Focusable = true;
            TextChanged += TextEditorTextChanged;
        }

        private bool HasStyle()
        {
            return ThemeManager.GetStyle(this.GetType()) == null ? false : true;
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
                return GetValue(TranslatableTextProperty) as string;
            }
            set
            {
                SetValue(TranslatableTextProperty, value);
            }
        }

        private string InternalTranslatableText
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
                return GetValue(TranslatablePlaceholderTextProperty) as string;
            }
            set
            {
                SetValue(TranslatablePlaceholderTextProperty, value);
            }
        }

        private string InternalTranslatablePlaceholderText
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
        /// The Text property.<br />
        /// The text to display in the UTF-8 format.<br />
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
                SetValue(TextProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TextColor property.<br />
        /// The color of the text.<br />
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
        /// The FontFamily property.<br />
        /// The requested font family to use.<br />
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

        private string InternalFontFamily
        {
            get
            {
                if (HasStyle())
                    return fontFamily;
                else
                    return Object.InternalGetPropertyString(this.SwigCPtr, TextEditor.Property.FontFamily);
            }
            set
            {
                string newFontFamily;

                if (string.Equals(fontFamily, value)) return;

                fontFamily = value;
                if (fontFamily == Tizen.NUI.FontFamily.UseSystemSetting)
                {
                    try
                    {
                        newFontFamily = SystemSettings.FontType;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("{0} Exception caught.", e);
                        newFontFamily = defaultFontFamily;
                    }
                    AddSystemSettingsFontTypeChanged();
                }
                else
                {
                    newFontFamily = fontFamily;
                    RemoveSystemSettingsFontTypeChanged();
                }

                SetInternalFontFamily(newFontFamily);
            }
        }

        private void SetInternalFontFamily(string fontFamily)
        {
            Object.InternalSetPropertyString(this.SwigCPtr, TextEditor.Property.FontFamily, (string)fontFamily);
        }

        /// <summary>
        /// The FontStyle property.<br />
        /// The requested font style to use.<br />
        /// The fontStyle map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>width (string)</term><description>The width key defines occupied by each glyph. (values: ultraCondensed, extraCondensed, condensed, semiCondensed, normal, semiExpanded, expanded, extraExpanded, ultraExpanded)</description></item>
        /// <item><term>weight (string)</term><description>The weight key defines the thickness or darkness of the glyphs. (values: thin, ultraLight, extraLight, light, demiLight, semiLight, book, normal, regular, medium, demiBold, semiBold, bold, ultraBold, extraBold, black, heavy, extraBlack)</description></item>
        /// <item><term>slant (string)</term><description>The slant key defines whether to use italics. (values: normal, roman, italic, oblique)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set FontStyle to TextEditor. <br />
        /// </summary>
        /// <param name="fontStyle">The FontStyle</param>
        /// <remarks>
        /// SetFontStyle specifies the requested font style through <see cref="Tizen.NUI.Text.FontStyle"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetFontStyle method.
        /// <code>
        /// var fontStyle = new Tizen.NUI.Text.FontStyle();
        /// fontStyle.Width = FontWidthType.Expanded;
        /// fontStyle.Weight = FontWeightType.Bold;
        /// fontStyle.Slant = FontSlantType.Italic;
        /// editor.SetFontStyle(fontStyle);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetFontStyle(FontStyle fontStyle)
        {
            using (var fontStyleMap = TextMapHelper.GetFontStyleMap(fontStyle))
            {
                SetValue(FontStyleProperty, fontStyleMap);
            }
        }

        /// <summary>
        /// Get FontStyle from TextEditor. <br />
        /// </summary>
        /// <returns>The FontStyle</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.FontStyle"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontStyle GetFontStyle()
        {
            FontStyle fontStyle;
            using (var fontStyleMap = (PropertyMap)GetValue(FontStyleProperty))
            {
                fontStyle = TextMapHelper.GetFontStyleStruct(fontStyleMap);
            }
            return fontStyle;
        }

        /// <summary>
        /// The PointSize property.<br />
        /// The size of font in points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Binding.TypeConverter(typeof(PointSizeTypeConverter))]
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
        /// The HorizontalAlignment property.<br />
        /// The line horizontal alignment.<br />
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
        /// The VerticalAlignment property.<br />
        /// The line vertical alignment.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
            }
        }

        /// <summary>
        /// The ScrollThreshold property.<br />
        /// Horizontal scrolling will occur if the cursor is this close to the control border.<br />
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
        /// The ScrollSpeed property.<br />
        /// The scroll speed in pixels per second.<br />
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
        /// The PrimaryCursorColor property.<br />
        /// The color to apply to the primary cursor.<br />
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
        /// The SecondaryCursorColor property.<br />
        /// The color to apply to the secondary cursor.<br />
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
        /// The EnableCursorBlink property.<br />
        /// Whether the cursor should blink or not.<br />
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
        /// The CursorBlinkInterval property.<br />
        /// The time interval in seconds between cursor on/off states.<br />
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
        /// The CursorBlinkDuration property.<br />
        /// The cursor will stop blinking after this number of seconds (if non-zero).<br />
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
        /// The GrabHandleImage property.<br />
        /// The image to display for the grab handle.<br />
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
        /// The GrabHandlePressedImage property.<br />
        /// The image to display when the grab handle is pressed.<br />
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
        /// The SelectionPopupStyle property.<br />
        /// The style of the text selection popup can be set through SelectionPopupStyle property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionPopupStyle
        {
            get
            {
                return (PropertyMap)GetValue(SelectionPopupStyleProperty);
            }
            set
            {
                SetValue(SelectionPopupStyleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.<br />
        /// The image to display for the left selection handle.<br />
        /// The selectionHandleImageLeft map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// The SelectionHandleImageRight property.<br />
        /// The image to display for the right selection handle.<br />
        /// The selectionHandleImageRight map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// Set SelectionHandleImage to TextEditor. <br />
        /// </summary>
        /// <param name="selectionHandleImage">The SelectionHandleImage</param>
        /// <remarks>
        /// SetSelectionHandleImage specifies the display image used for the selection handle through <see cref="Tizen.NUI.Text.SelectionHandleImage"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetSelectionHandleImage method.
        /// <code>
        /// var selectionHandleImage = new Tizen.NUI.Text.SelectionHandleImage();
        /// selectionHandleImage.LeftImageUrl = "handle_downleft.png";
        /// selectionHandleImage.RightImageUrl = "handle_downright.png";
        /// editor.SetSelectionHandleImage(selectionHandleImage);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSelectionHandleImage(SelectionHandleImage selectionHandleImage)
        {
            if (!String.IsNullOrEmpty(selectionHandleImage.LeftImageUrl))
            {
                using (var leftImageMap = TextMapHelper.GetFileNameMap(selectionHandleImage.LeftImageUrl))
                {
                    SetValue(SelectionHandleImageLeftProperty, leftImageMap);
                }
            }

            if (!String.IsNullOrEmpty(selectionHandleImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandleImage.RightImageUrl))
                {
                    SetValue(SelectionHandleImageRightProperty, rightImageMap);
                }
            }
        }

        /// <summary>
        /// Get SelectionHandleImage from TextEditor. <br />
        /// </summary>
        /// <returns>The SelectionHandleImage</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.SelectionHandleImage"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectionHandleImage GetSelectionHandleImage()
        {
            SelectionHandleImage selectionHandleImage;
            using (var leftImageMap = (PropertyMap)GetValue(SelectionHandleImageLeftProperty))
            using (var rightImageMap = (PropertyMap)GetValue(SelectionHandleImageRightProperty))
            {
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            return selectionHandleImage;
        }

        /// <summary>
        /// The SelectionHandlePressedImageLeft property.<br />
        /// The image to display when the left selection handle is pressed.<br />
        /// The selectionHandlePressedImageLeft map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// The SelectionHandlePressedImageRight property.<br />
        /// The image to display when the right selection handle is pressed.<br />
        /// The selectionHandlePressedImageRight map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// Set SelectionHandlePressedImage to TextEditor. <br />
        /// </summary>
        /// <param name="selectionHandlePressedImage">The SelectionHandleImage</param>
        /// <remarks>
        /// SetSelectionHandlePressedImage specifies the display image used for the selection handle through <see cref="Tizen.NUI.Text.SelectionHandleImage"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetSelectionHandlePressedImage method.
        /// <code>
        /// var selectionHandlePressedImage = new Tizen.NUI.Text.SelectionHandleImage();
        /// selectionHandlePressedImage.LeftImageUrl = "handle_pressed_downleft.png";
        /// selectionHandlePressedImage.RightImageUrl = "handle_pressed_downright.png";
        /// editor.SetSelectionHandlePressedImage(selectionHandlePressedImage);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSelectionHandlePressedImage(SelectionHandleImage selectionHandlePressedImage)
        {
            if (!String.IsNullOrEmpty(selectionHandlePressedImage.LeftImageUrl))
            {
                using (var leftImageMap = TextMapHelper.GetFileNameMap(selectionHandlePressedImage.LeftImageUrl))
                {
                    SetValue(SelectionHandlePressedImageLeftProperty, leftImageMap);
                }
            }

            if (!String.IsNullOrEmpty(selectionHandlePressedImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandlePressedImage.RightImageUrl))
                {
                    SetValue(SelectionHandlePressedImageRightProperty, rightImageMap);
                }
            }
        }

        /// <summary>
        /// Get SelectionHandlePressedImage from TextEditor. <br />
        /// </summary>
        /// <returns>The SelectionHandlePressedImage</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.SelectionHandleImage"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectionHandleImage GetSelectionHandlePressedImage()
        {
            SelectionHandleImage selectionHandleImage;
            using (var leftImageMap = (PropertyMap)GetValue(SelectionHandlePressedImageLeftProperty))
            using (var rightImageMap = (PropertyMap)GetValue(SelectionHandlePressedImageRightProperty))
            {
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            return selectionHandleImage;
        }

        /// <summary>
        /// The SelectionHandleMarkerImageLeft property.<br />
        /// The image to display for the left selection handle marker.<br />
        /// The selectionHandleMarkerImageLeft map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// The SelectionHandleMarkerImageRight property.<br />
        /// The image to display for the right selection handle marker.<br />
        /// The selectionHandleMarkerImageRight map contains the following key :<br />
        /// <list type="table">
        /// <item><term>filename (string)</term><description>The path of image file</description></item>
        /// </list>
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
        /// Set SelectionHandleMarkerImage to TextEditor. <br />
        /// </summary>
        /// <param name="selectionHandleMarkerImage">The SelectionHandleImage</param>
        /// <remarks>
        /// SetSelectionHandleMarkerImage specifies the display image used for the selection handle through <see cref="Tizen.NUI.Text.SelectionHandleImage"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetSelectionHandleMarkerImage method.
        /// <code>
        /// var selectionHandleMarkerImage = new Tizen.NUI.Text.SelectionHandleImage();
        /// selectionHandleMarkerImage.LeftImageUrl = "handle_pressed_downleft.png";
        /// selectionHandleMarkerImage.RightImageUrl = "handle_pressed_downright.png";
        /// editor.SetSelectionHandleMarkerImage(selectionHandleMarkerImage);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetSelectionHandleMarkerImage(SelectionHandleImage selectionHandleMarkerImage)
        {
            if (!String.IsNullOrEmpty(selectionHandleMarkerImage.LeftImageUrl))
            {
                using (var leftImageMap = TextMapHelper.GetFileNameMap(selectionHandleMarkerImage.LeftImageUrl))
                {
                    SetValue(SelectionHandleMarkerImageLeftProperty, leftImageMap);
                }
            }

            if (!String.IsNullOrEmpty(selectionHandleMarkerImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandleMarkerImage.RightImageUrl))
                {
                    SetValue(SelectionHandleMarkerImageRightProperty, rightImageMap);
                }
            }
        }

        /// <summary>
        /// Get SelectionHandleMarkerImage from TextEditor. <br />
        /// </summary>
        /// <returns>The SelectionHandleMarkerImage</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.SelectionHandleImage"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public SelectionHandleImage GetSelectionHandleMarkerImage()
        {
            SelectionHandleImage selectionHandleImage;
            using (var leftImageMap = (PropertyMap)GetValue(SelectionHandleMarkerImageLeftProperty))
            using (var rightImageMap = (PropertyMap)GetValue(SelectionHandleMarkerImageRightProperty))
            {
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            return selectionHandleImage;
        }

        /// <summary>
        /// The SelectionHighlightColor property.<br />
        /// The color of the selection highlight.<br />
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
        /// The DecorationBoundingBox property.<br />
        /// The decorations (handles etc) will positioned within this area on-screen.<br />
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
        /// The EnableMarkup property.<br />
        /// Whether the mark-up processing is enabled.<br />
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
        /// The InputColor property.<br />
        /// The color of the new input text.<br />
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
        /// The InputFontFamily property.<br />
        /// The font's family of the new input text.<br />
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
        /// The InputFontStyle property.<br />
        /// The font's style of the new input text.<br />
        /// The inputFontStyle map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>width (string)</term><description>The width key defines occupied by each glyph. (values: ultraCondensed, extraCondensed, condensed, semiCondensed, normal, semiExpanded, expanded, extraExpanded, ultraExpanded)</description></item>
        /// <item><term>weight (string)</term><description>The weight key defines the thickness or darkness of the glyphs. (values: thin, ultraLight, extraLight, light, demiLight, semiLight, book, normal, regular, medium, demiBold, semiBold, bold, ultraBold, extraBold, black, heavy, extraBlack)</description></item>
        /// <item><term>slant (string)</term><description>The slant key defines whether to use italics. (values: normal, roman, italic, oblique)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set InputFontStyle to TextEditor. <br />
        /// </summary>
        /// <param name="fontStyle">The FontStyle</param>
        /// <remarks>
        /// SetInputFontStyle specifies the requested font style for new input text through <see cref="Tizen.NUI.Text.FontStyle"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetInputFontStyle method.
        /// <code>
        /// var fontStyle = new Tizen.NUI.Text.FontStyle();
        /// fontStyle.Width = FontWidthType.Expanded;
        /// fontStyle.Weight = FontWeightType.Bold;
        /// fontStyle.Slant = FontSlantType.Italic;
        /// editor.SetInputFontStyle(fontStyle);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInputFontStyle(FontStyle fontStyle)
        {
            using (var fontStyleMap = TextMapHelper.GetFontStyleMap(fontStyle))
            {
                SetValue(InputFontStyleProperty, fontStyleMap);
            }
        }

        /// <summary>
        /// Get InputFontStyle from TextEditor. <br />
        /// </summary>
        /// <returns>The FontStyle</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.FontStyle"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontStyle GetInputFontStyle()
        {
            FontStyle fontStyle;
            using (var fontStyleMap = (PropertyMap)GetValue(InputFontStyleProperty))
            {
                fontStyle = TextMapHelper.GetFontStyleStruct(fontStyleMap);
            }
            return fontStyle;
        }

        /// <summary>
        /// The InputPointSize property.<br />
        /// The font's size of the new input text in points.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Binding.TypeConverter(typeof(PointSizeTypeConverter))]
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
        /// The LineSpacing property.<br />
        /// The default extra space between lines in points.<br />
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
        /// The InputLineSpacing property.<br />
        /// The extra space between lines in points.<br />
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
        /// The relative height of the line (a factor that will be multiplied by text height). <br />
        /// If the value is less than 1, the lines could to be overlapped.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float RelativeLineHeight
        {
            get
            {
                return (float)GetValue(RelativeLineHeightProperty);
            }
            set
            {
                SetValue(RelativeLineHeightProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.<br />
        /// The default underline parameters.<br />
        /// The underline map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>enable (bool)</term><description>Whether the underline is enabled (the default value is false)</description></item>
        /// <item><term>color (Color)</term><description>The color of the underline (If not provided then the color of the text is used)</description></item>
        /// <item><term>height (float)</term><description>The height in pixels of the underline (the default value is 1.f)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Underline to TextEditor. <br />
        /// </summary>
        /// <param name="underline">The Underline</param>
        /// <remarks>
        /// SetUnderline specifies the underline of the text through <see cref="Tizen.NUI.Text.Underline"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetUnderline method.
        /// <code>
        /// var underline = new Tizen.NUI.Text.Underline();
        /// underline.Enable = true;
        /// underline.Color = new Color("#3498DB");
        /// underline.Height = 2.0f;
        /// editor.SetUnderline(underline);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetUnderline(Underline underline)
        {
            using (var underlineMap = TextMapHelper.GetUnderlineMap(underline))
            {
                SetValue(UnderlineProperty, underlineMap);
            }
        }

        /// <summary>
        /// Get Underline from TextEditor. <br />
        /// </summary>
        /// <returns>The Underline</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Underline"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Underline GetUnderline()
        {
            Underline underline;
            using (var underlineMap = (PropertyMap)GetValue(UnderlineProperty))
            {
                underline = TextMapHelper.GetUnderlineStruct(underlineMap);
            }
            return underline;
        }

        /// <summary>
        /// The InputUnderline property.<br />
        /// The underline parameters of the new input text.<br />
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
        /// The Shadow property.<br />
        /// The default shadow parameters.<br />
        /// The shadow map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>color (Color)</term><description>The color of the shadow (the default color is Color.Black)</description></item>
        /// <item><term>offset (Vector2)</term><description>The offset in pixels of the shadow (If not provided then the shadow is not enabled)</description></item>
        /// <item><term>blurRadius (float)</term><description>The radius of the Gaussian blur for the soft shadow (If not provided then the soft shadow is not enabled)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Shadow to TextEditor. <br />
        /// </summary>
        /// <param name="shadow">The Shadow</param>
        /// <remarks>
        /// SetShadow specifies the shadow of the text through <see cref="Tizen.NUI.Text.Shadow"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetShadow method.
        /// <code>
        /// var shadow = new Tizen.NUI.Text.Shadow();
        /// shadow.Offset = new Vector2(3, 3);
        /// shadow.Color = new Color("#F1C40F");
        /// editor.SetShadow(shadow);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetShadow(Tizen.NUI.Text.Shadow shadow)
        {
            using (var shadowMap = TextMapHelper.GetShadowMap(shadow))
            {
                SetValue(ShadowProperty, shadowMap);
            }
        }

        /// <summary>
        /// Get Shadow from TextEditor. <br />
        /// </summary>
        /// <returns>The Shadow</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Shadow"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Tizen.NUI.Text.Shadow GetShadow()
        {
            Tizen.NUI.Text.Shadow shadow;
            using (var shadowMap = (PropertyMap)GetValue(ShadowProperty))
            {
                shadow = TextMapHelper.GetShadowStruct(shadowMap);
            }
            return shadow;
        }

        /// <summary>
        /// The InputShadow property.<br />
        /// The shadow parameters of the new input text.<br />
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
        /// The Emboss property.<br />
        /// The default emboss parameters.<br />
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
        /// The InputEmboss property.<br />
        /// The emboss parameters of the new input text.<br />
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
        /// The Outline property.<br />
        /// The default outline parameters.<br />
        /// The outline map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>color (Color)</term><description>The color of the outline (the default color is Color.White)</description></item>
        /// <item><term>width (float)</term><description>The width in pixels of the outline (If not provided then the outline is not enabled)</description></item>
        /// </list>
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
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
        /// Set Outline to TextEditor. <br />
        /// </summary>
        /// <param name="outline">The Outline</param>
        /// <remarks>
        /// SetOutline specifies the outline of the text through <see cref="Tizen.NUI.Text.Outline"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetOutline method.
        /// <code>
        /// var outline = new Tizen.NUI.Text.Outline();
        /// outline.Width = 2.0f;
        /// outline.Color = new Color("#45B39D");
        /// editor.SetOutline(outline);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetOutline(Outline outline)
        {
            using (var outlineMap = TextMapHelper.GetOutlineMap(outline))
            {
                SetValue(OutlineProperty, outlineMap);
            }
        }

        /// <summary>
        /// Get Outline from TextEditor. <br />
        /// </summary>
        /// <returns>The Outline</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Outline"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Outline GetOutline()
        {
            Outline outline;
            using (var outlineMap = (PropertyMap)GetValue(OutlineProperty))
            {
                outline = TextMapHelper.GetOutlineStruct(outlineMap);
            }
            return outline;
        }

        /// <summary>
        /// The InputOutline property.<br />
        /// The outline parameters of the new input text.<br />
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
        /// The SmoothScroll property.<br />
        /// Enable or disable the smooth scroll animation.<br />
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
        /// The SmoothScrollDuration property.<br />
        /// Sets the duration of smooth scroll animation.<br />
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
        /// The EnableScrollBar property.<br />
        /// Enable or disable the scroll bar.<br />
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
        /// The ScrollBarShowDuration property.<br />
        /// Sets the duration of scroll bar to show.<br />
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
        /// The ScrollBarFadeDuration property.<br />
        /// Sets the duration of scroll bar to fade out.<br />
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
        /// The PixelSize property.<br />
        /// The size of font in pixels.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        [Binding.TypeConverter(typeof(FloatGraphicsTypeConverter))]
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
                int lineCount = 0;
                using (var propertyValue = GetProperty(TextEditor.Property.LineCount))
                {
                    propertyValue.Get(out lineCount);
                }
                return lineCount;
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
        /// The portion of the text that has been selected by the user.
        /// </summary>
        /// <remarks>
        /// Empty string when nothing is selected.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public string SelectedText
        {
            get
            {
                string selectedText;
                using (var propertyValue = GetProperty(TextEditor.Property.SelectedText))
                {
                    propertyValue.Get(out selectedText);
                }
                return selectedText;
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
        /// The Enable selection property.<br />
        /// Enables Text selection, such as the cursor, handle, clipboard, and highlight color.<br />
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
        /// <remarks>
        /// When there is no selection, the index is current cursor position.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public int SelectedTextStart
        {
            get
            {
                int selectedTextStart;
                using (var propertyValue = GetProperty(TextEditor.Property.SelectedTextStart))
                {
                    propertyValue.Get(out selectedTextStart);
                }
                return selectedTextStart;
            }
        }

        /// <summary>
        /// The end index for selection.
        /// </summary>
        /// <remarks>
        /// When there is no selection, the index is current cursor position.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public int SelectedTextEnd
        {
            get
            {
                int selectedTextEnd;
                using (var propertyValue = GetProperty(TextEditor.Property.SelectedTextEnd))
                {
                    propertyValue.Get(out selectedTextEnd);
                }
                return selectedTextEnd;
            }
        }

        /// <summary>
        /// Enable editing in text control.
        /// </summary>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableEditing
        {
            get
            {
                return (bool)GetValue(EnableEditingProperty);
            }
            set
            {
                SetValue(EnableEditingProperty, value);
            }
        }

        private bool InternalEnableEditing
        {
            get
            {
                bool enableEditing;
                using (var propertyValue = GetProperty(TextEditor.Property.EnableEditing))
                {
                    propertyValue.Get(out enableEditing);
                }
                return enableEditing;
            }
            set
            {
                using (var propertyValue = new PropertyValue(value))
                {
                    SetProperty(TextEditor.Property.EnableEditing, propertyValue);
                    NotifyPropertyChanged();
                }
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
                return (int)GetValue(HorizontalScrollPositionProperty);
            }
            set
            {
                SetValue(HorizontalScrollPositionProperty, value);
            }
        }

        private int InternalHorizontalScrollPosition
        {
            get
            {
                int horizontalScrollPosition;
                using (var propertyValue = GetProperty(TextEditor.Property.HorizontalScrollPosition))
                {
                    propertyValue.Get(out horizontalScrollPosition);
                }
                return horizontalScrollPosition;
            }
            set
            {
                using (var propertyValue = new PropertyValue(value))
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
                return (int)GetValue(VerticalScrollPositionProperty);
            }
            set
            {
                SetValue(VerticalScrollPositionProperty, value);
            }
        }

        private int InternalVerticalScrollPosition
        {
            get
            {
                int verticalScrollPosition;
                using (var propertyValue = GetProperty(TextEditor.Property.VerticalScrollPosition))
                {
                    propertyValue.Get(out verticalScrollPosition);
                }
                return verticalScrollPosition;
            }
            set
            {
                using (var propertyValue = new PropertyValue(value))
                {
                    SetProperty(TextEditor.Property.VerticalScrollPosition, propertyValue);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// PrimaryCursorPosition property.<br />
        /// Specify the position of the primary cursor (caret) in text control.
        /// </summary>
        /// <remarks>
        /// If the value set is out of range (negative or greater than or equal the number of characters in Text) then the PrimaryCursorPosition is moved to the end of Text (the number of characters in Text).
        /// </remarks>
        /// <since_tizen> 10 </since_tizen>
        public int PrimaryCursorPosition
        {
            get
            {
                return (int)GetValue(PrimaryCursorPositionProperty);
            }
            set
            {
                SetValue(PrimaryCursorPositionProperty, value);
            }
        }

        private int InternalPrimaryCursorPosition
        {
            get
            {
                int primaryCursorPosition;
                using (var propertyValue = GetProperty(TextEditor.Property.PrimaryCursorPosition))
                {
                    propertyValue.Get(out primaryCursorPosition);
                }
                return primaryCursorPosition;
            }
            set
            {
                using (var propertyValue = new PropertyValue(value))
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
        /// Set InputFilter to TextEditor.
        /// </summary>
        /// <param name="inputFilter">The InputFilter</param>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.InputFilter"/> filters input based on regular expressions. <br />
        /// InputFiltered signal is emitted when the input is filtered by InputFilter <br />
        /// See <see cref="InputFiltered"/>, <see cref="InputFilterType"/> and <see cref="InputFilteredEventArgs"/> for a detailed description.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetInputFilter method.
        /// <code>
        /// var inputFilter = new Tizen.NUI.Text.InputFilter();
        /// inputFilter.Accepted = @"[\d]"; // accept whole digits
        /// inputFilter.Rejected = "[0-3]"; // reject 0, 1, 2, 3
        /// editor.SetInputFilter(inputFilter); // acceptable inputs are 4, 5, 6, 7, 8, 9
        /// </code>
        /// </example>
        /// <since_tizen> 9 </since_tizen>
        public void SetInputFilter(InputFilter inputFilter)
        {
            using (var map = TextMapHelper.GetInputFilterMap(inputFilter))
            using (var propertyValue = new PropertyValue(map))
            {
                SetProperty(TextEditor.Property.InputFilter, propertyValue);
            }
        }

        /// <summary>
        /// Get InputFilter from TextEditor. <br />
        /// </summary>
        /// <returns>The InputFilter</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.InputFilter"/>
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public InputFilter GetInputFilter()
        {
            InputFilter inputFilter;
            using (var propertyValue = GetProperty(TextEditor.Property.InputFilter))
            using (var map = new PropertyMap())
            {
                propertyValue.Get(map);
                inputFilter = TextMapHelper.GetInputFilterStruct(map);
            }
            return inputFilter;
        }

        /// <summary>
        /// Set Strikethrough to TextEditor. <br />
        /// </summary>
        /// <param name="strikethrough">The Strikethrough</param>
        /// <remarks>
        /// SetStrikethrough specifies the strikethrough of the text through <see cref="Tizen.NUI.Text.Strikethrough"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetStrikethrough method.
        /// <code>
        /// var strikethrough = new Tizen.NUI.Text.Strikethrough();
        /// strikethrough.Enable = true;
        /// strikethrough.Color = new Color("#3498DB");
        /// strikethrough.Height = 2.0f;
        /// editor.SetStrikethrough(strikethrough);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetStrikethrough(Strikethrough strikethrough)
        {
            using (var map = TextMapHelper.GetStrikethroughMap(strikethrough))
            using (var propertyValue = new PropertyValue(map))
            {
                SetProperty(TextEditor.Property.Strikethrough, propertyValue);
            }
        }

        /// <summary>
        /// Get Strikethrough from TextEditor. <br />
        /// </summary>
        /// <returns>The Strikethrough</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Strikethrough"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Strikethrough GetStrikethrough()
        {
            Strikethrough strikethrough;
            using (var propertyValue = GetProperty(TextEditor.Property.Strikethrough))
            using (var map = new PropertyMap())
            {
                propertyValue.Get(map);
                strikethrough = TextMapHelper.GetStrikethroughStruct(map);
            }
            return strikethrough;
        }

        /// <summary>
        /// The Placeholder property.
        /// The placeholder map contains the following keys :<br />
        /// <list type="table">
        /// <item><term>text (string)</term><description>The text to display when the TextEditor is empty and inactive</description></item>
        /// <item><term>textFocused (string)</term><description>The text to display when the placeholder has focus</description></item>
        /// <item><term>color (Color)</term><description>The color of the placeholder text</description></item>
        /// <item><term>fontFamily (string)</term><description>The fontFamily of the placeholder text</description></item>
        /// <item><term>fontStyle (PropertyMap)</term><description>The fontStyle of the placeholder text</description></item>
        /// <item><term>pointSize (float)</term><description>The pointSize of the placeholder text</description></item>
        /// <item><term>pixelSize (float)</term><description>The pixelSize of the placeholder text</description></item>
        /// <item><term>ellipsis (bool)</term><description>The ellipsis of the placeholder text</description></item>
        /// </list>
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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1721: Property names should not match get methods")]
        public Tizen.NUI.PropertyMap Placeholder
        {
            get
            {
                PropertyMap map = (PropertyMap)GetValue(PlaceholderProperty);
                string defalutText = "";

                if (TextMapHelper.IsValue(map, 0))
                    map.Add("text", TextMapHelper.GetStringFromMap(map, 0, defalutText));

                if (TextMapHelper.IsValue(map, 1))
                    map.Add("textFocused", TextMapHelper.GetStringFromMap(map, 1, defalutText));

                if (TextMapHelper.IsValue(map, 2))
                {
                    using (var color = TextMapHelper.GetColorFromMap(map, 2))
                    {
                        map.Add("color", color);
                    }
                }

                if (TextMapHelper.IsValue(map, 3))
                    map.Add("fontFamily", TextMapHelper.GetStringFromMap(map, 3, defalutText));

                if (TextMapHelper.IsValue(map, 4))
                {
                    using (var properyValue = map.Find(4))
                    using (var fontStyle = new PropertyMap())
                    {
                        properyValue.Get(fontStyle);
                        using (var fontStyleValue = new PropertyValue(fontStyle))
                        {
                            map.Add("fontStyle", fontStyleValue);
                        }
                    }
                }

                if (TextMapHelper.IsValue(map, 5))
                    map.Add("pointSize", TextMapHelper.GetNullableFloatFromMap(map, 5));

                if (TextMapHelper.IsValue(map, 6))
                    map.Add("pixelSize", TextMapHelper.GetNullableFloatFromMap(map, 6));

                if (TextMapHelper.IsValue(map, 7))
                    map.Add("ellipsis", TextMapHelper.GetBoolFromMap(map, 7, false));

                return map;
            }
            set
            {
                SetValue(PlaceholderProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Set Placeholder to TextEditor. <br />
        /// </summary>
        /// <param name="placeholder">The Placeholder</param>
        /// <remarks>
        /// SetPlaceholder specifies the attributes of the placeholder property through <see cref="Tizen.NUI.Text.Placeholder"/>. <br />
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to use the SetPlaceholder method.
        /// <code>
        /// var placeholder = new Tizen.NUI.Text.Placeholder();
        /// placeholder.Text = "placeholder text";
        /// placeholder.TextFocused = "placeholder textFocused";
        /// placeholder.Color = new Color("#45B39D");
        /// placeholder.FontFamily = "BreezeSans";
        /// placeholder.FontStyle = new Tizen.NUI.Text.FontStyle()
        /// {
        ///     Width = FontWidthType.Expanded,
        ///     Weight = FontWeightType.ExtraLight,
        ///     Slant = FontSlantType.Italic,
        /// };
        /// placeholder.PointSize = 25.0f;
        /// //placeholder.PixelSize = 50.0f;
        /// placeholder.Ellipsis = true;
        /// editor.SetPlaceholder(placeholder);
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPlaceholder(Placeholder placeholder)
        {
            using (var placeholderMap = TextMapHelper.GetPlaceholderMap(placeholder))
            {
                SetValue(PlaceholderProperty, placeholderMap);
            }
        }

        /// <summary>
        /// Get Placeholder from TextEditor. <br />
        /// </summary>
        /// <returns>The Placeholder</returns>
        /// <remarks>
        /// <see cref="Tizen.NUI.Text.Placeholder"/>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Placeholder GetPlaceholder()
        {
            Placeholder placeholder;
            using (var placeholderMap = (PropertyMap)GetValue(PlaceholderProperty))
            {
                placeholder = TextMapHelper.GetPlaceholderStruct(placeholderMap);
            }
            return placeholder;
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
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
        /// The ellipsis position of the text.
        /// Specifies which portion of the text should be replaced with an ellipsis when the text size exceeds the layout size.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public EllipsisPosition EllipsisPosition
        {
            get
            {
                return (EllipsisPosition)GetValue(EllipsisPositionProperty);
            }
            set
            {
                SetValue(EllipsisPositionProperty, value);
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
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
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
        /// The MaxLength property.<br />
        /// The maximum number of characters that can be inserted.<br />
        /// </summary>
        /// This will be public opened in next release of tizen after ACR done. Before ACR, it is used as HiddenAPI (InhouseAPI).
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

        /// <summary>
        /// The FontSizeScale property. <br />
        /// The default value is 1.0. <br />
        /// The given font size scale value is used for multiplying the specified font size before querying fonts. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float FontSizeScale
        {
            get
            {
                return (float)GetValue(FontSizeScaleProperty);
            }
            set
            {
                SetValue(FontSizeScaleProperty, value);
                NotifyPropertyChanged();
            }
        }

        private float InternalFontSizeScale
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
                    AddSystemSettingsFontSizeChanged();
                }
                else
                {
                    newFontSizeScale = fontSizeScale;
                    RemoveSystemSettingsFontSizeChanged();
                }

                SetInternalFontSizeScale(newFontSizeScale);
            }
        }

        private void SetInternalFontSizeScale(float fontSizeScale)
        {

            Object.InternalSetPropertyFloat(this.SwigCPtr, TextEditor.Property.FontSizeScale, (float)fontSizeScale);
        }

        /// <summary>
        /// The EnableFontSizeScale property.<br />
        /// Whether the font size scale is enabled. (The default value is true)
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableFontSizeScale
        {
            get
            {
                return (bool)GetValue(EnableFontSizeScaleProperty);
            }
            set
            {
                SetValue(EnableFontSizeScaleProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The InputMethodSettings property.<br />
        /// The settings to relating to the System's Input Method, Key and Value.<br />
        /// </summary>
        /// <remarks>
        /// <see cref="InputMethod"/> is a class encapsulating the input method map. Use the <see cref="InputMethod"/> class for this property.
        /// </remarks>
        /// <example>
        /// The following example demonstrates how to set the InputMethodSettings property.
        /// <code>
        /// InputMethod method = new InputMethod();
        /// method.PanelLayout = InputMethod.PanelLayoutType.Normal;
        /// method.ActionButton = InputMethod.ActionButtonTitleType.Default;
        /// method.AutoCapital = InputMethod.AutoCapitalType.Word;
        /// method.Variation = 1;
        /// textEditor.InputMethodSettings = method.OutputMap;
        /// </code>
        /// </example>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        /// <since_tizen> 9 </since_tizen>
        public void SelectWholeText()
        {
            Interop.TextEditor.SelectWholeText(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Select text from start to end index. <br />
        /// The index is valid when 0 or positive.
        /// </summary>
        /// <param name="start">The start index for selection.</param>
        /// <param name="end">The end index for selection.</param>
        /// <remarks>
        /// If the end index exceeds the maximum value, it is set to the length of the text.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public void SelectText(int start, int end)
        {
            if (start < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(start), "Value is less than zero");
            if (end < 0)
                throw new global::System.ArgumentOutOfRangeException(nameof(end), "Value is less than zero");

            Interop.TextEditor.SelectText(SwigCPtr, (uint)start, (uint)end);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clear selection of the text. <br />
        /// Valid when selection is activate.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void SelectNone()
        {
            _ = Interop.TextEditor.SelectNone(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The Enable grab handle property.<br />
        /// Enables the grab handles for text selection.<br />
        /// The default value is true, which means the grab handles are enabled by default.<br />
        /// </summary>
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
        /// The Enable grab handle popup property.<br />
        /// Enables the grab handle popup for text selection.<br />
        /// The default value is true, which means the grab handle popup is enabled by default.<br />
        /// </summary>
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
        /// Minimum line size to be used.<br />
        /// The height of the line in points. <br />
        /// If the font size is larger than the line size, it works with the font size. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float MinLineSize
        {
            get
            {
                return (float)GetValue(MinLineSizeProperty);
            }
            set
            {
                SetValue(MinLineSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

        internal SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t InputStyleChangedSignal()
        {
            SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t ret = new SWIGTYPE_p_Dali__SignalT_void_fDali__Toolkit__TextEditor_Dali__Toolkit__TextEditor__InputStyle__MaskF_t(Interop.TextEditor.InputStyleChangedSignal(SwigCPtr));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// The spaces between characters in Pixels.
        /// <remarks>
        /// A positive value will make the characters far apart (expanded) and a negative value will bring them closer (condensed).<br />
        /// The default value is 0.f which does nothing.
        ///</remarks>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float CharacterSpacing
        {
            get
            {
                return (float)GetValue(CharacterSpacingProperty);
            }
            set
            {
                SetValue(CharacterSpacingProperty, value);
                NotifyPropertyChanged();
            }
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

            internalPlaceholderTextColor?.Dispose();
            internalPrimaryCursorColor?.Dispose();
            internalSecondaryCursorColor?.Dispose();
            internalSelectionHighlightColor?.Dispose();
            internalInputColor?.Dispose();
            internalTextColor?.Dispose();
            internalGrabHandleColor?.Dispose();

            if (hasSystemLanguageChanged)
            {
                SystemSettings.LocaleLanguageChanged -= SystemSettings_LocaleLanguageChanged;
            }

            RemoveSystemSettingsFontTypeChanged();
            RemoveSystemSettingsFontSizeChanged();

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

                if (textEditorSelectionStartedCallbackDelegate != null)
                {
                    this.SelectionStartedSignal().Disconnect(textEditorSelectionStartedCallbackDelegate);
                }

                if (textEditorSelectionClearedCallbackDelegate != null)
                {
                    this.SelectionClearedSignal().Disconnect(textEditorSelectionClearedCallbackDelegate);
                }

                if (textEditorCursorPositionChangedCallbackDelegate != null)
                {
                    this.CursorPositionChangedSignal().Disconnect(textEditorCursorPositionChangedCallbackDelegate);
                }

                if (textEditorSelectionChangedCallbackDelegate != null)
                {
                    this.SelectionChangedSignal().Disconnect(textEditorSelectionChangedCallbackDelegate);
                }
            }

            TextChanged -= TextEditorTextChanged;
            GetInputMethodContext()?.DestroyContext();

            base.Dispose(type);
        }

        /// This will not be public opened.
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.TextEditor.DeleteTextEditor(swigCPtr);
        }

        internal override LayoutItem CreateDefaultLayout()
        {
            return new TextEditorLayout();
        }

        internal void SetTextWithoutTextChanged(string text)
        {
            invokeTextChanged = false;
            Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextEditor.Property.TEXT, new Tizen.NUI.PropertyValue(text));
            invokeTextChanged = true;
        }

        private string SetTranslatable(string textEditorSid)
        {
            string translatableText = null;
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textEditorSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
            if (translatableText != null)
            {
                if (hasSystemLanguageChanged == false)
                {
                    SystemSettings.LocaleLanguageChanged += SystemSettings_LocaleLanguageChanged;
                    hasSystemLanguageChanged = true;
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
            SetInternalFontSizeScale(newFontSizeScale);
        }

        private void AddSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged != true)
            {
                try
                {
                    SystemSettings.FontSizeChanged += SystemSettingsFontSizeChanged;
                    hasSystemFontSizeChanged = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontSizeChanged = false;
                }
            }
        }

        private void RemoveSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged == true)
            {
                try
                {
                    SystemSettings.FontSizeChanged -= SystemSettingsFontSizeChanged;
                    hasSystemFontSizeChanged = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontSizeChanged = true;
                }
            }
        }

        private void SystemSettingsFontTypeChanged(object sender, FontTypeChangedEventArgs e)
        {
            SetInternalFontFamily(e.Value);
        }

        private void AddSystemSettingsFontTypeChanged()
        {
            if (HasStyle() && !hasSystemFontTypeChanged)
            {
                try
                {
                    SystemSettings.FontTypeChanged += SystemSettingsFontTypeChanged;
                    hasSystemFontTypeChanged = true;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontTypeChanged = false;
                }
            }
        }
        
        private void RemoveSystemSettingsFontTypeChanged()
        {
            if (hasSystemFontTypeChanged)
            {
                try
                {
                    SystemSettings.FontTypeChanged -= SystemSettingsFontTypeChanged;
                    hasSystemFontTypeChanged = false;
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0} Exception caught.", e);
                    hasSystemFontTypeChanged = true;
                }
            }
        }

        private void TextEditorTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!isSettingTextInCSharp)
            {
                EnforceNotifyBindedInstance(TextProperty);
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
            internal static readonly int VerticalAlignment = Interop.TextEditor.VerticalAlignmentGet();
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
            internal static readonly int SelectionPopupStyle = Interop.TextEditor.SelectionPopupStyleGet();
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
            internal static readonly int RelativeLineHeight = Interop.TextEditor.RelativeLineHeightGet();
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
            internal static readonly int EnableFontSizeScale = Interop.TextEditor.EnableFontSizeScaleGet();
            internal static readonly int GrabHandleColor = Interop.TextEditor.GrabHandleColorGet();
            internal static readonly int EnableGrabHandle = Interop.TextEditor.EnableGrabHandleGet();
            internal static readonly int EnableGrabHandlePopup = Interop.TextEditor.EnableGrabHandlePopupGet();
            internal static readonly int InputMethodSettings = Interop.TextEditor.InputMethodSettingsGet();
            internal static readonly int ELLIPSIS = Interop.TextEditor.EllipsisGet();
            internal static readonly int EllipsisPosition = Interop.TextEditor.EllipsisPositionGet();
            internal static readonly int MinLineSize = Interop.TextEditor.MinLineSizeGet();
            internal static readonly int InputFilter = Interop.TextEditor.InputFilterGet();
            internal static readonly int Strikethrough = Interop.TextEditor.StrikethroughGet();
            internal static readonly int CharacterSpacing = Interop.TextEditor.CharacterSpacingGet();
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

        private class TextEditorLayout : LayoutItem
        {
            protected override void OnMeasure(MeasureSpecification widthMeasureSpec, MeasureSpecification heightMeasureSpec)
            {
                // Padding will be automatically applied by DALi TextEditor.
                var totalWidth = widthMeasureSpec.Size.AsDecimal();
                var totalHeight = heightMeasureSpec.Size.AsDecimal();
                var minSize = Owner.MinimumSize;
                var maxSize = Owner.MaximumSize;
                var naturalSize = Owner.GetNaturalSize();

                if (((TextEditor)Owner).Text.Length == 0)
                {
                    // Calculate height of TextEditor by setting Text with " ".
                    // By calling SetTextWithoutTextChanged, TextChanged callback is not called for this.
                    ((TextEditor)Owner).SetTextWithoutTextChanged(" ");

                    // Store original WidthSpecification to restore it after setting ResizePolicy.
                    var widthSpecification = Owner.WidthSpecification;

                    // In DALi's Size logic, if Width or Height is set to be 0, then
                    // ResizePolicy is not changed to Fixed.
                    // This causes Size changes after NUI Layout's OnMeasure is finished.
                    // e.g. TextEditor's Width fills to its parent although Text is null and
                    //      WidthSpecification is WrapContent.
                    // To prevent the Size changes, WidthResizePolicy is set to be Fixed
                    // in advance if Text is null.
                    Owner.WidthResizePolicy = ResizePolicyType.Fixed;

                    // Restore WidthSpecification because ResizePolicy changes WidthSpecification.
                    Owner.WidthSpecification = widthSpecification;

                    naturalSize = Owner.GetNaturalSize();

                    // Restore TextEditor's Text after calculating height of TextEditor.
                    // By calling SetTextWithoutTextChanged, TextChanged callback is not called for this.
                    ((TextEditor)Owner).SetTextWithoutTextChanged("");
                }

                if (widthMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                {
                    float width = naturalSize != null ? naturalSize.Width : 0;
                    totalWidth = Math.Min(Math.Max(width, minSize.Width), maxSize.Width);
                }

                if (heightMeasureSpec.Mode != MeasureSpecification.ModeType.Exactly)
                {
                    float height = naturalSize != null ? naturalSize.Height : 0;
                    totalHeight = Math.Min(Math.Max(height, minSize.Height), maxSize.Height);
                }

                widthMeasureSpec = new MeasureSpecification(new LayoutLength(totalWidth), MeasureSpecification.ModeType.Exactly);
                heightMeasureSpec = new MeasureSpecification(new LayoutLength(totalHeight), MeasureSpecification.ModeType.Exactly);

                MeasuredSize.StateType childWidthState = MeasuredSize.StateType.MeasuredSizeOK;
                MeasuredSize.StateType childHeightState = MeasuredSize.StateType.MeasuredSizeOK;

                SetMeasuredDimensions(ResolveSizeAndState(new LayoutLength(totalWidth), widthMeasureSpec, childWidthState),
                                      ResolveSizeAndState(new LayoutLength(totalHeight), heightMeasureSpec, childHeightState));
            }
        }
    }
}
