/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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


        static TextEditor()
        {
            if (NUIApplication.IsUsingXaml)
            {
                TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalTextProperty, defaultValueCreator: GetInternalTextProperty);

                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);

                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);

                FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalFontStyleProperty, defaultValueCreator: GetInternalFontStyleProperty);

                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);

                HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextEditor), HorizontalAlignment.Begin, propertyChanged: SetInternalHorizontalAlignmentProperty, defaultValueCreator: GetInternalHorizontalAlignmentProperty);

                VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextEditor), VerticalAlignment.Bottom, propertyChanged: SetInternalVerticalAlignmentProperty, defaultValueCreator: GetInternalVerticalAlignmentProperty);

                ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalScrollThresholdProperty, defaultValueCreator: GetInternalScrollThresholdProperty);

                ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalScrollSpeedProperty, defaultValueCreator: GetInternalScrollSpeedProperty);

                PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: SetInternalPrimaryCursorColorProperty, defaultValueCreator: GetInternalPrimaryCursorColorProperty);

                SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: SetInternalSecondaryCursorColorProperty, defaultValueCreator: GetInternalSecondaryCursorColorProperty);

                EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalEnableCursorBlinkProperty, defaultValueCreator: GetInternalEnableCursorBlinkProperty);

                CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalCursorBlinkIntervalProperty, defaultValueCreator: GetInternalCursorBlinkIntervalProperty);

                CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalCursorBlinkDurationProperty, defaultValueCreator: GetInternalCursorBlinkDurationProperty);

                CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int), typeof(TextEditor), default(int), propertyChanged: SetInternalCursorWidthProperty, defaultValueCreator: GetInternalCursorWidthProperty);

                GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalGrabHandleImageProperty, defaultValueCreator: GetInternalGrabHandleImageProperty);

                GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalGrabHandlePressedImageProperty, defaultValueCreator: GetInternalGrabHandlePressedImageProperty);

                SelectionPopupStyleProperty = BindableProperty.Create(nameof(SelectionPopupStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionPopupStyleProperty, defaultValueCreator: GetInternalSelectionPopupStyleProperty);

                SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandleImageLeftProperty, defaultValueCreator: GetInternalSelectionHandleImageLeftProperty);

                SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandleImageRightProperty, defaultValueCreator: GetInternalSelectionHandleImageRightProperty);

                SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandlePressedImageLeftProperty, defaultValueCreator: GetInternalSelectionHandlePressedImageLeftProperty);

                SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandlePressedImageRightProperty, defaultValueCreator: GetInternalSelectionHandlePressedImageRightProperty);

                SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandleMarkerImageLeftProperty, defaultValueCreator: GetInternalSelectionHandleMarkerImageLeftProperty);

                SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHandleMarkerImageRightProperty, defaultValueCreator: GetInternalSelectionHandleMarkerImageRightProperty);

                SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: SetInternalSelectionHighlightColorProperty, defaultValueCreator: GetInternalSelectionHighlightColorProperty);

                DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditor), null, propertyChanged: SetInternalDecorationBoundingBoxProperty, defaultValueCreator: GetInternalDecorationBoundingBoxProperty);

                EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalEnableMarkupProperty, defaultValueCreator: GetInternalEnableMarkupProperty);

                InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: SetInternalInputColorProperty, defaultValueCreator: GetInternalInputColorProperty);

                InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalInputFontFamilyProperty, defaultValueCreator: GetInternalInputFontFamilyProperty);

                InputFontStyleProperty = BindableProperty.Create(nameof(InputFontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalInputFontStyleProperty, defaultValueCreator: GetInternalInputFontStyleProperty);

                InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalInputPointSizeProperty, defaultValueCreator: GetInternalInputPointSizeProperty);

                LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalLineSpacingProperty, defaultValueCreator: GetInternalLineSpacingProperty);

                InputLineSpacingProperty = BindableProperty.Create(nameof(InputLineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalInputLineSpacingProperty, defaultValueCreator: GetInternalInputLineSpacingProperty);

                RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalRelativeLineHeightProperty, defaultValueCreator: GetInternalRelativeLineHeightProperty);

                UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalUnderlineProperty, defaultValueCreator: GetInternalUnderlineProperty);

                InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalInputUnderlineProperty, defaultValueCreator: GetInternalInputUnderlineProperty);

                ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalShadowProperty, defaultValueCreator: GetInternalShadowProperty);

                InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalInputShadowProperty, defaultValueCreator: GetInternalInputShadowProperty);

                EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalEmbossProperty, defaultValueCreator: GetInternalEmbossProperty);

                InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalInputEmbossProperty, defaultValueCreator: GetInternalInputEmbossProperty);

                OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalOutlineProperty, defaultValueCreator: GetInternalOutlineProperty);

                InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalInputOutlineProperty, defaultValueCreator: GetInternalInputOutlineProperty);

                SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalSmoothScrollProperty, defaultValueCreator: GetInternalSmoothScrollProperty);

                SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalSmoothScrollDurationProperty, defaultValueCreator: GetInternalSmoothScrollDurationProperty);

                EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalEnableScrollBarProperty, defaultValueCreator: GetInternalEnableScrollBarProperty);

                ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalScrollBarShowDurationProperty, defaultValueCreator: GetInternalScrollBarShowDurationProperty);

                ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalScrollBarFadeDurationProperty, defaultValueCreator: GetInternalScrollBarFadeDurationProperty);

                PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalPixelSizeProperty, defaultValueCreator: GetInternalPixelSizeProperty);

                PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: SetInternalPlaceholderTextProperty, defaultValueCreator: GetInternalPlaceholderTextProperty);

                PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditor), null, propertyChanged: SetInternalPlaceholderTextColorProperty, defaultValueCreator: GetInternalPlaceholderTextColorProperty);

                EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalEnableSelectionProperty, defaultValueCreator: GetInternalEnableSelectionProperty);

                PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalPlaceholderProperty, defaultValueCreator: GetInternalPlaceholderProperty);

                LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextEditor), LineWrapMode.Word, propertyChanged: SetInternalLineWrapModeProperty, defaultValueCreator: GetInternalLineWrapModeProperty);

                EnableShiftSelectionProperty = BindableProperty.Create(nameof(TextEditor.EnableShiftSelection), typeof(bool), typeof(TextEditor), true, propertyChanged: SetInternalEnableShiftSelectionProperty, defaultValueCreator: GetInternalEnableShiftSelectionProperty);

                MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextEditor.MatchSystemLanguageDirection), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalMatchSystemLanguageDirectionProperty, defaultValueCreator: GetInternalMatchSystemLanguageDirectionProperty);

                MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextEditor), default(int), propertyChanged: SetInternalMaxLengthProperty, defaultValueCreator: GetInternalMaxLengthProperty);

                FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalFontSizeScaleProperty, defaultValueCreator: GetInternalFontSizeScaleProperty);

                EnableFontSizeScaleProperty = BindableProperty.Create(nameof(EnableFontSizeScale), typeof(bool), typeof(TextEditor), default(bool), propertyChanged: SetInternalEnableFontSizeScaleProperty, defaultValueCreator: GetInternalEnableFontSizeScaleProperty);

                GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextEditor), null, propertyChanged: SetInternalGrabHandleColorProperty, defaultValueCreator: GetInternalGrabHandleColorProperty);

                EnableGrabHandleProperty = BindableProperty.Create(nameof(TextEditor.EnableGrabHandle), typeof(bool), typeof(TextEditor), true, propertyChanged: SetInternalEnableGrabHandleProperty, defaultValueCreator: GetInternalEnableGrabHandleProperty);

                EnableGrabHandlePopupProperty = BindableProperty.Create(nameof(TextEditor.EnableGrabHandlePopup), typeof(bool), typeof(TextEditor), true, propertyChanged: SetInternalEnableGrabHandlePopupProperty, defaultValueCreator: GetInternalEnableGrabHandlePopupProperty);

                InputMethodSettingsProperty = BindableProperty.Create(nameof(TextEditor.InputMethodSettings), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: SetInternalInputMethodSettingsProperty, defaultValueCreator: GetInternalInputMethodSettingsProperty);

                EllipsisProperty = BindableProperty.Create(nameof(TextEditor.Ellipsis), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalEllipsisProperty, defaultValueCreator: GetInternalEllipsisProperty);

                EllipsisPositionProperty = BindableProperty.Create(nameof(EllipsisPosition), typeof(EllipsisPosition), typeof(TextEditor), EllipsisPosition.End, propertyChanged: SetInternalEllipsisPositionProperty, defaultValueCreator: GetInternalEllipsisPositionProperty);

                MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalMinLineSizeProperty, defaultValueCreator: GetInternalMinLineSizeProperty);

                TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(Tizen.NUI.BaseComponents.TextEditor), string.Empty, propertyChanged: SetInternalTranslatableTextProperty, defaultValueCreator: GetInternalTranslatableTextProperty);

                TranslatablePlaceholderTextProperty = BindableProperty.Create(nameof(TranslatablePlaceholderText), typeof(string), typeof(Tizen.NUI.BaseComponents.TextEditor), string.Empty, propertyChanged: SetInternalTranslatablePlaceholderTextProperty, defaultValueCreator: GetInternalTranslatablePlaceholderTextProperty);

                EnableEditingProperty = BindableProperty.Create(nameof(EnableEditing), typeof(bool), typeof(Tizen.NUI.BaseComponents.TextEditor), false, propertyChanged: SetInternalEnableEditingProperty, defaultValueCreator: GetInternalEnableEditingProperty);

                HorizontalScrollPositionProperty = BindableProperty.Create(nameof(HorizontalScrollPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: SetInternalHorizontalScrollPositionProperty, defaultValueCreator: GetInternalHorizontalScrollPositionProperty);

                VerticalScrollPositionProperty = BindableProperty.Create(nameof(VerticalScrollPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: SetInternalVerticalScrollPositionProperty, defaultValueCreator: GetInternalVerticalScrollPositionProperty);

                PrimaryCursorPositionProperty = BindableProperty.Create(nameof(PrimaryCursorPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: SetInternalPrimaryCursorPositionProperty, defaultValueCreator: GetInternalPrimaryCursorPositionProperty);

                CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: SetInternalCharacterSpacingProperty, defaultValueCreator: GetInternalCharacterSpacingProperty);

                RemoveFrontInsetProperty = BindableProperty.Create(nameof(RemoveFrontInset), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalRemoveFrontInsetProperty, defaultValueCreator: GetInternalRemoveFrontInsetProperty);

                RemoveBackInsetProperty = BindableProperty.Create(nameof(RemoveBackInset), typeof(bool), typeof(TextEditor), false, propertyChanged: SetInternalRemoveBackInsetProperty, defaultValueCreator: GetInternalRemoveBackInsetProperty);
            }
        }

        static internal new void Preload()
        {
            // Do not call View.Preload(), since we already call it

            Property.Preload();
            // Do nothing. Just call for load static values.
        }

        /// <summary>
        /// Creates the TextEditor control.
        /// This returns a handle to the TextEditor control.
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TranslatableTextProperty) as string;
                }
                else
                {
                    return InternalTranslatableText;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatableTextProperty, value);
                }
                else
                {
                    InternalTranslatableText = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(TranslatablePlaceholderTextProperty) as string;
                }
                else
                {
                    return InternalTranslatablePlaceholderText;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatablePlaceholderTextProperty, value);
                }
                else
                {
                    InternalTranslatablePlaceholderText = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(TextProperty);
                }
                else
                {
                    return GetInternalText();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextProperty, value);
                }
                else
                {
                    SetInternalText(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalText(string text)
        {
            if (text != null)
            {
                isSettingTextInCSharp = true;

                Object.InternalSetPropertyString(SwigCPtr, Property.TEXT, text);
                isSettingTextInCSharp = false;
            }
        }

        private string GetInternalText()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.TEXT);
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
                Vector4 temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Vector4)GetValue(TextColorProperty);
                }
                else
                {
                    temp = GetInternalTextColor();
                }
                return new Vector4(OnTextColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorProperty, value);
                }
                else
                {
                    SetInternalTextColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTextColor(Vector4 color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.TextColor, color.SwigCPtr);
            }
        }

        private Vector4 GetInternalTextColor()
        {
            if (internalTextColor == null)
            {
                internalTextColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.TextColor, internalTextColor.SwigCPtr);
            return internalTextColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(FontFamilyProperty);
                }
                else
                {
                    return InternalFontFamily;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontFamilyProperty, value);
                }
                else
                {
                    InternalFontFamily = value;
                }
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
                        newFontFamily = SystemFontTypeChangedManager.FontType;
                    }
                    catch (Exception e)
                    {
                        Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(FontStyleProperty);
                }
                else
                {
                    return GetInternalFontStyle();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontStyleProperty, value);
                }
                else
                {
                    SetInternalFontStyle(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalFontStyle(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.FontStyle, pv);
            }
        }

        private PropertyMap GetInternalFontStyle()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.FontStyle);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontStyleProperty, fontStyleMap);
                }
                else
                {
                    SetInternalFontStyle(fontStyleMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var fontStyleMap =  (PropertyMap)GetValue(FontStyleProperty);
                fontStyle = TextMapHelper.GetFontStyleStruct(fontStyleMap);
            }
            else
            {
                using var fontStyleMap = GetInternalFontStyle();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PointSizeProperty);
                }
                else
                {
                    return GetInternalPointSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PointSizeProperty, value);
                }
                else
                {
                    SetInternalPointSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPointSize(float pointSize)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.PointSize, (float)pointSize);
        }

        private float GetInternalPointSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PointSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
                }
                else
                {
                    return GetInternalHorizontalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HorizontalAlignmentProperty, value);
                }
                else
                {
                    SetInternalHorizontalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalHorizontalAlignment(HorizontalAlignment alignment)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.HorizontalAlignment, (int)alignment);
        }

        private HorizontalAlignment GetInternalHorizontalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.HorizontalAlignment);
            return temp.GetValueByDescription<HorizontalAlignment>();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
                }
                else
                {
                    return GetInternalVerticalAlignment();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalAlignmentProperty, value);
                }
                else
                {
                    SetInternalVerticalAlignment(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalVerticalAlignment(VerticalAlignment newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.VerticalAlignment, (int)newValue);
        }

        private VerticalAlignment GetInternalVerticalAlignment()
        {
            string temp = Object.InternalGetPropertyString(SwigCPtr, Property.VerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignment>();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScrollThresholdProperty);
                }
                else
                {
                    return GetInternalScrollThreshold();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollThresholdProperty, value);
                }
                else
                {
                    SetInternalScrollThreshold(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollThreshold(float threshold)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScrollThreshold, (float)threshold);
        }

        private float GetInternalScrollThreshold()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScrollThreshold);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScrollSpeedProperty);
                }
                else
                {
                    return GetInternalScrollSpeed();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollSpeedProperty, value);
                }
                else
                {
                    SetInternalScrollSpeed(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollSpeed(float speed)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScrollSpeed, (float)speed);
        }

        private float GetInternalScrollSpeed()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScrollSpeed);
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
                Vector4 temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Vector4)GetValue(PrimaryCursorColorProperty);
                }
                else
                {
                    temp = GetInternalPrimaryCursorColor();
                }
                return new Vector4(OnPrimaryCursorColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PrimaryCursorColorProperty, value);
                }
                else
                {
                    SetInternalPrimaryCursorColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPrimaryCursorColor(Vector4 color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.PrimaryCursorColor, color.SwigCPtr);
            }
        }

        private Vector4 GetInternalPrimaryCursorColor()
        {
            if (internalPrimaryCursorColor == null)
            {
                internalPrimaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.PrimaryCursorColor, internalPrimaryCursorColor.SwigCPtr);
            return internalPrimaryCursorColor;
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
                Vector4 temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Vector4)GetValue(SecondaryCursorColorProperty);
                }
                else
                {
                    temp = GetInternalSecondaryCursorColor();
                }
                return new Vector4(OnSecondaryCursorColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SecondaryCursorColorProperty, value);
                }
                else
                {
                    SetInternalSecondaryCursorColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSecondaryCursorColor(Vector4 color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.SecondaryCursorColor, color.SwigCPtr);
            }
        }

        private Vector4 GetInternalSecondaryCursorColor()
        {
            if (internalSecondaryCursorColor == null)
            {
                internalSecondaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.SecondaryCursorColor, internalSecondaryCursorColor.SwigCPtr);
            return internalSecondaryCursorColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableCursorBlinkProperty);
                }
                else
                {
                    return GetInternalEnableCursorBlink();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableCursorBlinkProperty, value);
                }
                else
                {
                    SetInternalEnableCursorBlink(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableCursorBlink(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableCursorBlink, enabled);
        }

        private bool GetInternalEnableCursorBlink()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableCursorBlink);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(CursorBlinkIntervalProperty);
                }
                else
                {
                    return GetInternalCursorBlinkInterval();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CursorBlinkIntervalProperty, value);
                }
                else
                {
                    SetInternalCursorBlinkInterval(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCursorBlinkInterval(float interval)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.CursorBlinkInterval, interval);
        }

        private float GetInternalCursorBlinkInterval()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.CursorBlinkInterval);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(CursorBlinkDurationProperty);
                }
                else
                {
                    return GetInternalCursorBlinkDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CursorBlinkDurationProperty, value);
                }
                else
                {
                    SetInternalCursorBlinkDuration(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCursorBlinkDuration(float duration)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.CursorBlinkDuration, duration);
        }

        private float GetInternalCursorBlinkDuration()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.CursorBlinkDuration);
        }

        /// <summary>
        /// Gets or sets the width of the cursor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CursorWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(CursorWidthProperty);
                }
                else
                {
                    return GetInternalCursorWidth();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CursorWidthProperty, value);
                }
                else
                {
                    SetInternalCursorWidth(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCursorWidth(int w)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.CursorWidth, w);
        }

        private int GetInternalCursorWidth()
        {
            return Object.InternalGetPropertyInt(SwigCPtr, Property.CursorWidth);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(GrabHandleImageProperty);
                }
                else
                {
                    return GetInternalGrabHandleImage();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(GrabHandleImageProperty, value);
                }
                else
                {
                    SetInternalGrabHandleImage(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalGrabHandleImage(string image)
        {
            if (image != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.GrabHandleImage, image);
            }
        }

        private string GetInternalGrabHandleImage()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.GrabHandleImage);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(GrabHandlePressedImageProperty);
                }
                else
                {
                    return GetInternalGrabHandlePressedImage();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(GrabHandlePressedImageProperty, value);
                }
                else
                {
                    SetInternalGrabHandlePressedImage(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalGrabHandlePressedImage(string image)
        {
            if (image != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.GrabHandlePressedImage, image);
            }
        }

        private string GetInternalGrabHandlePressedImage()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.GrabHandlePressedImage);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionPopupStyleProperty);
                }
                else
                {
                    return GetInternalSelectionPopupStyle();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionPopupStyleProperty, value);
                }
                else
                {
                    SetInternalSelectionPopupStyle(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionPopupStyle(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.SelectionPopupStyle, pv);
            }
        }

        private PropertyMap GetInternalSelectionPopupStyle()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionPopupStyle);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
                }
                else
                {
                    return GetInternalSelectionHandleImageLeft();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandleImageLeftProperty, value);
                }
                else
                {
                    SetInternalSelectionHandleImageLeft(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandleImageLeft(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.SelectionHandleImageLeft, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandleImageLeft()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandleImageLeft);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandleImageRightProperty);

                }
                else
                {
                    return GetInternalSelectionHandleImageRight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandleImageRightProperty, value);

                }
                else
                {
                    SetInternalSelectionHandleImageRight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandleImageRight(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.SelectionHandleImageRight, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandleImageRight()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandleImageRight);
            prop.Get(temp);
            return temp;
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
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandleImageLeftProperty, leftImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandleImageLeft(leftImageMap);
                    }
                }
            }

            if (!String.IsNullOrEmpty(selectionHandleImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandleImage.RightImageUrl))
                {
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandleImageRightProperty, rightImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandleImageRight(rightImageMap);
                    }
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
            if (NUIApplication.IsUsingXaml)
            {
                var leftImageMap = (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
                var rightImageMap = (PropertyMap)GetValue(SelectionHandleImageRightProperty);
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            else
            {
                using var leftImageMap = GetInternalSelectionHandleImageLeft();
                using var rightImageMap = GetInternalSelectionHandleImageRight();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandlePressedImageLeftProperty);
                }
                else
                {
                    return GetInternalSelectionHandlePressedImageLeft();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandlePressedImageLeftProperty, value);
                }
                else
                {
                    SetInternalSelectionHandlePressedImageLeft(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandlePressedImageLeft(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.SelectionHandlePressedImageLeft, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandlePressedImageLeft()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandlePressedImageLeft);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandlePressedImageRightProperty);
                }
                else
                {
                    return GetInternalSelectionHandlePressedImageRight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandlePressedImageRightProperty, value);
                }
                else
                {
                    SetInternalSelectionHandlePressedImageRight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandlePressedImageRight(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.SelectionHandlePressedImageRight, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandlePressedImageRight()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandlePressedImageRight);
            prop.Get(temp);
            return temp;
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
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandlePressedImageLeftProperty, leftImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandlePressedImageLeft(leftImageMap);
                    }
                }
            }

            if (!String.IsNullOrEmpty(selectionHandlePressedImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandlePressedImage.RightImageUrl))
                {
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandlePressedImageRightProperty, rightImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandlePressedImageRight(rightImageMap);
                    }
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
            if (NUIApplication.IsUsingXaml)
            {
                var leftImageMap = (PropertyMap)GetValue(SelectionHandlePressedImageLeftProperty);
                var rightImageMap = (PropertyMap)GetValue(SelectionHandlePressedImageRightProperty);
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            else
            {
                using var leftImageMap = GetInternalSelectionHandlePressedImageLeft();
                using var rightImageMap = GetInternalSelectionHandlePressedImageRight();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandleMarkerImageLeftProperty);
                }
                else
                {
                    return GetInternalSelectionHandleMarkerImageLeft();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandleMarkerImageLeftProperty, value);
                }
                else
                {
                    SetInternalSelectionHandleMarkerImageLeft(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandleMarkerImageLeft(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.SelectionHandleMarkerImageLeft, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandleMarkerImageLeft()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandleMarkerImageLeft);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(SelectionHandleMarkerImageRightProperty);
                }
                else
                {
                    return GetInternalSelectionHandleMarkerImageRight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHandleMarkerImageRightProperty, value);
                }
                else
                {
                    SetInternalSelectionHandleMarkerImageRight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHandleMarkerImageRight(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.SelectionHandleMarkerImageRight, pv);
            }
        }

        private PropertyMap GetInternalSelectionHandleMarkerImageRight()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectionHandleMarkerImageRight);
            prop.Get(temp);
            return temp;
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
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandleMarkerImageLeftProperty, leftImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandleMarkerImageLeft(leftImageMap);
                    }
                }
            }

            if (!String.IsNullOrEmpty(selectionHandleMarkerImage.RightImageUrl))
            {
                using (var rightImageMap = TextMapHelper.GetFileNameMap(selectionHandleMarkerImage.RightImageUrl))
                {
                    if (NUIApplication.IsUsingXaml)
                    {
                        SetValue(SelectionHandleMarkerImageRightProperty, rightImageMap);
                    }
                    else
                    {
                        SetInternalSelectionHandleMarkerImageRight(rightImageMap);
                    }
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
            if (NUIApplication.IsUsingXaml)
            {
                var leftImageMap = (PropertyMap)GetValue(SelectionHandleMarkerImageLeftProperty);
                var rightImageMap = (PropertyMap)GetValue(SelectionHandleMarkerImageRightProperty);
                selectionHandleImage = TextMapHelper.GetSelectionHandleImageStruct(leftImageMap, rightImageMap);
            }
            else
            {
                using var leftImageMap = GetInternalSelectionHandleMarkerImageLeft();
                using var rightImageMap = GetInternalSelectionHandleMarkerImageRight();
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
                Vector4 temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Vector4)GetValue(SelectionHighlightColorProperty);
                }
                else
                {
                    temp = GetInternalSelectionHighlightColor();
                }
                return new Vector4(OnSelectionHighlightColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHighlightColorProperty, value);
                }
                else
                {
                    SetInternalSelectionHighlightColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSelectionHighlightColor(Vector4 color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.SelectionHighlightColor, color.SwigCPtr);
            }
        }

        private Vector4 GetInternalSelectionHighlightColor()
        {
            if (internalSelectionHighlightColor == null)
            {
                internalSelectionHighlightColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.SelectionHighlightColor, internalSelectionHighlightColor.SwigCPtr);
            return internalSelectionHighlightColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    Rectangle temp = (Rectangle)GetValue(DecorationBoundingBoxProperty);
                    return new Rectangle(OnDecorationBoundingBoxChanged, temp.X, temp.Y, temp.Width, temp.Height);
                }
                else
                {
                    using Rectangle temp = GetInternalDecorationBoundingBox();
                    return new Rectangle(OnDecorationBoundingBoxChanged, temp.X, temp.Y, temp.Width, temp.Height);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DecorationBoundingBoxProperty, value);
                }
                else
                {
                    SetInternalDecorationBoundingBox(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalDecorationBoundingBox(Rectangle rect)
        {
            if (rect != null)
            {
                using var pv = new PropertyValue(rect);
                Object.SetProperty(SwigCPtr, Property.DecorationBoundingBox, pv);
            }
        }

        private Rectangle GetInternalDecorationBoundingBox()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            Rectangle temp = new Rectangle(0, 0, 0, 0);
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.DecorationBoundingBox);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableMarkupProperty);
                }
                else
                {
                    return GetInternalEnableMarkup();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableMarkupProperty, value);
                }
                else
                {
                    SetInternalEnableMarkup(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableMarkup(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableMarkup, enabled);
        }

        private bool GetInternalEnableMarkup()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableMarkup);
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
                Vector4 temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Vector4)GetValue(InputColorProperty);
                }
                else
                {
                    temp = GetInternalInputColor();
                }
                return new Vector4(OnInputColorChanged, temp.X, temp.Y, temp.Z, temp.W);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputColorProperty, value);
                }
                else
                {
                    SetInternalInputColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputColor(Vector4 color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.InputColor, color.SwigCPtr);
            }
        }

        private Vector4 GetInternalInputColor()
        {
            if (internalInputColor == null)
            {
                internalInputColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.InputColor, internalInputColor.SwigCPtr);
            return internalInputColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(InputFontFamilyProperty);
                }
                else
                {
                    return GetInternalInputFontFamily();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputFontFamilyProperty, value);
                }
                else
                {
                    SetInternalInputFontFamily(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputFontFamily(string family)
        {
            if (family != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.InputFontFamily, family);
            }
        }

        private string GetInternalInputFontFamily()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.InputFontFamily);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(InputFontStyleProperty);
                }
                else
                {
                    return GetInternalInputFontStyle();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputFontStyleProperty, value);
                }
                else
                {
                    SetInternalInputFontStyle(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputFontStyle(PropertyMap map)
        {
            if (map != null)
            {
                using var pv = new PropertyValue(map);
                Object.SetProperty(SwigCPtr, Property.InputFontStyle, pv);
            }
        }

        private PropertyMap GetInternalInputFontStyle()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.InputFontStyle);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputFontStyleProperty, fontStyleMap);
                }
                else
                {
                    SetInternalInputFontStyle(fontStyleMap);
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(InputPointSizeProperty);
                }
                else
                {
                    return GetInternalInputPointSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputPointSizeProperty, value);
                }
                else
                {
                    SetInternalInputPointSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputPointSize(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.InputPointSize, (float)newValue);
        }

        private float GetInternalInputPointSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.InputPointSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(LineSpacingProperty);
                }
                else
                {
                    return GetInternalLineSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineSpacingProperty, value);
                }
                else
                {
                    SetInternalLineSpacing(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLineSpacing(float space)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.LineSpacing, space);
        }

        private float GetInternalLineSpacing()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.LineSpacing);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(InputLineSpacingProperty);
                }
                else
                {
                    return GetInternalInputLineSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputLineSpacingProperty, value);
                }
                else
                {
                    SetInternalInputLineSpacing(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputLineSpacing(float space)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.InputLineSpacing, space);
        }

        private float GetInternalInputLineSpacing()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.InputLineSpacing);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(RelativeLineHeightProperty);
                }
                else
                {
                    return GetInternalRelativeLineHeight();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RelativeLineHeightProperty, value);
                }
                else
                {
                    SetInternalRelativeLineHeight(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRelativeLineHeight(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.RelativeLineHeight, newValue);
        }

        private float GetInternalRelativeLineHeight()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.RelativeLineHeight);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(UnderlineProperty);
                }
                else
                {
                    return GetInternalUnderline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineProperty, value);
                }
                else
                {
                    SetInternalUnderline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUnderline(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.UNDERLINE, pv);
            }
        }

        private PropertyMap GetInternalUnderline()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.UNDERLINE);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UnderlineProperty, underlineMap);
                }
                else
                {
                    SetInternalUnderline(underlineMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var underlineMap = (PropertyMap)GetValue(UnderlineProperty);
                underline = TextMapHelper.GetUnderlineStruct(underlineMap);
            }
            else
            {
                using var underlineMap = GetInternalUnderline();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(InputUnderlineProperty);
                }
                else
                {
                    return GetInternalInputUnderline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputUnderlineProperty, value);
                }
                else
                {
                    SetInternalInputUnderline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputUnderline(string line)
        {
            if (line != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.InputUnderline, line);
            }
        }

        private string GetInternalInputUnderline()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.InputUnderline);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(ShadowProperty);
                }
                else
                {
                    return GetInternalShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowProperty, value);
                }
                else
                {
                    SetInternalShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalShadow(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.SHADOW, pv);
            }
        }

        private PropertyMap GetInternalShadow()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.SHADOW);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ShadowProperty, shadowMap);
                }
                else
                {
                    SetInternalShadow(shadowMap);
                }
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
        public Text.Shadow GetShadow()
        {
            Text.Shadow shadow;
            if (NUIApplication.IsUsingXaml)
            {
                var shadowMap = (PropertyMap)GetValue(ShadowProperty);
                shadow = TextMapHelper.GetShadowStruct(shadowMap);
            }
            else
            {
                using var shadowMap = GetInternalShadow();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(InputShadowProperty);
                }
                else
                {
                    return GetInternalInputShadow();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputShadowProperty, value);
                }
                else
                {
                    SetInternalInputShadow(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputShadow(string shadow)
        {
            if (shadow != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.InputShadow, shadow);
            }
        }

        private string GetInternalInputShadow()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.InputShadow);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(EmbossProperty);
                }
                else
                {
                    return GetInternalEmboss();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EmbossProperty, value);
                }
                else
                {
                    SetInternalEmboss(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEmboss(string emboss)
        {
            if (emboss != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.EMBOSS, emboss);
            }
        }

        private string GetInternalEmboss()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.EMBOSS);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(InputEmbossProperty);
                }
                else
                {
                    return GetInternalInputEmboss();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputEmbossProperty, value);
                }
                else
                {
                    SetInternalInputEmboss(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputEmboss(string emboss)
        {
            if (emboss != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.InputEmboss, emboss);
            }
        }

        private string GetInternalInputEmboss()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.InputEmboss);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(OutlineProperty);
                }
                else
                {
                    return GetInternalOutline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OutlineProperty, value);
                }
                else
                {
                    SetInternalOutline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalOutline(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.OUTLINE, pv);
            }
        }

        private PropertyMap GetInternalOutline()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.OUTLINE);
            prop.Get(temp);
            return temp;
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(OutlineProperty, outlineMap);
                }
                else
                {
                    SetInternalOutline(outlineMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var outlineMap = (PropertyMap)GetValue(OutlineProperty);
                outline = TextMapHelper.GetOutlineStruct(outlineMap);
            }
            else
            {
                using var outlineMap = GetInternalOutline();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(InputOutlineProperty);
                }
                else
                {
                    return GetInternalInputOutline();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputOutlineProperty, value);
                }
                else
                {
                    SetInternalInputOutline(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputOutline(string newValue)
        {
            if (newValue != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.InputOutline, newValue);
            }
        }

        private string GetInternalInputOutline()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.InputOutline);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(SmoothScrollProperty);
                }
                else
                {
                    return GetInternalSmoothScroll();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SmoothScrollProperty, value);
                }
                else
                {
                    SetInternalSmoothScroll(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSmoothScroll(bool scroll)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.SmoothScroll, scroll);
        }

        private bool GetInternalSmoothScroll()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.SmoothScroll);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(SmoothScrollDurationProperty);
                }
                else
                {
                    return GetInternalSmoothScrollDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SmoothScrollDurationProperty, value);
                }
                else
                {
                    SetInternalSmoothScrollDuration(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalSmoothScrollDuration(float duration)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.SmoothScrollDuration, duration);
        }

        private float GetInternalSmoothScrollDuration()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.SmoothScrollDuration);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableScrollBarProperty);
                }
                else
                {
                    return GetInternalEnableScrollBar();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableScrollBarProperty, value);
                }
                else
                {
                    SetInternalEnableScrollBar(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableScrollBar(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableScrollBar, enabled);
        }

        private bool GetInternalEnableScrollBar()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableScrollBar);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScrollBarShowDurationProperty);
                }
                else
                {
                    return GetInternalScrollBarShowDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollBarShowDurationProperty, value);
                }
                else
                {
                    SetInternalScrollBarShowDuration(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollBarShowDuration(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScrollBarShowDuration, newValue);
        }

        private float GetInternalScrollBarShowDuration()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScrollBarShowDuration);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(ScrollBarFadeDurationProperty);
                }
                else
                {
                    return GetInternalScrollBarFadeDuration();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollBarFadeDurationProperty, value);
                }
                else
                {
                    SetInternalScrollBarFadeDuration(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalScrollBarFadeDuration(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.ScrollBarFadeDuration, newValue);
        }

        private float GetInternalScrollBarFadeDuration()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.ScrollBarFadeDuration);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PixelSizeProperty);
                }
                else
                {
                    return GetInternalPixelSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PixelSizeProperty, value);
                }
                else
                {
                    SetInternalPixelSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPixelSize(float pixelSize)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.PixelSize, pixelSize);
        }

        private float GetInternalPixelSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.PixelSize);
        }

        /// <summary>
        /// Gets the line count of the text.
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(PlaceholderTextProperty);
                }
                else
                {
                    return GetInternalPlaceholderText();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderTextProperty, value);
                }
                else
                {
                    SetInternalPlaceholderText(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPlaceholderText(string text)
        {
            if (text != null)
            {
                Object.InternalSetPropertyString(SwigCPtr, Property.PlaceholderText, text);
            }
        }

        private string GetInternalPlaceholderText()
        {
            return Object.InternalGetPropertyString(SwigCPtr, Property.PlaceholderText);
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
                Color temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Color)GetValue(PlaceholderTextColorProperty);
                }
                else
                {
                    temp = GetInternalPlaceholderTextColor();
                }
                return new Color(OnPlaceholderTextColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderTextColorProperty, value);
                }
                else
                {
                    SetInternalPlaceholderTextColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPlaceholderTextColor(Color color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.PlaceholderTextColor, color.SwigCPtr);
            }
        }

        private Color GetInternalPlaceholderTextColor()
        {
            if (internalPlaceholderTextColor == null)
            {
                internalPlaceholderTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.PlaceholderTextColor, internalPlaceholderTextColor.SwigCPtr);
            return internalPlaceholderTextColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableSelectionProperty);
                }
                else
                {
                    return GetInternalEnableSelection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableSelectionProperty, value);
                }
                else
                {
                    SetInternalEnableSelection(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableSelection(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableSelection, enabled);
        }

        private bool GetInternalEnableSelection()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableSelection);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableEditingProperty);
                }
                else
                {
                    return InternalEnableEditing;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableEditingProperty, value);
                }
                else
                {
                    InternalEnableEditing = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(HorizontalScrollPositionProperty);
                }
                else
                {
                    return InternalHorizontalScrollPosition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(HorizontalScrollPositionProperty, value);
                }
                else
                {
                    InternalHorizontalScrollPosition = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(VerticalScrollPositionProperty);
                }
                else
                {
                    return InternalVerticalScrollPosition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalScrollPositionProperty, value);
                }
                else
                {
                    InternalVerticalScrollPosition = value;
                }
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(PrimaryCursorPositionProperty);
                }
                else
                {
                    return InternalPrimaryCursorPosition;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PrimaryCursorPositionProperty, value);
                }
                else
                {
                    InternalPrimaryCursorPosition = value;
                }
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
                Color temp;
                if (NUIApplication.IsUsingXaml)
                {
                    temp = (Color)GetValue(GrabHandleColorProperty);
                }
                else
                {
                    temp = GetInternalGrabHandleColor();
                }
                return new Color(OnGrabHandleColorChanged, temp.R, temp.G, temp.B, temp.A);
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(GrabHandleColorProperty, value);
                }
                else
                {
                    SetInternalGrabHandleColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalGrabHandleColor(Color color)
        {
            if (color != null)
            {
                Object.InternalSetPropertyVector4(SwigCPtr, Property.GrabHandleColor, color.SwigCPtr);
            }
        }

        private Color GetInternalGrabHandleColor()
        {
            if (internalGrabHandleColor == null)
            {
                internalGrabHandleColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(SwigCPtr, Property.GrabHandleColor, internalGrabHandleColor.SwigCPtr);
            return internalGrabHandleColor;
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(PlaceholderProperty);
                }
                else
                {
                    return GetInternalPlaceholder();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderProperty, value);
                }
                else
                {
                    SetInternalPlaceholder(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPlaceholder(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.PLACEHOLDER, pv);
            }
        }

        private PropertyMap GetInternalPlaceholder()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap map = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.PLACEHOLDER);
            prop.Get(map);

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
                    map.Add("fontStyle", fontStyle);
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
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderProperty, placeholderMap);
                }
                else
                {
                    SetInternalPlaceholder(placeholderMap);
                }
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
            if (NUIApplication.IsUsingXaml)
            {
                var placeholderMap = (PropertyMap)GetValue(PlaceholderProperty);
                placeholder = TextMapHelper.GetPlaceholderStruct(placeholderMap);
            }
            else
            {
                using var placeholderMap = GetInternalPlaceholder();
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EllipsisProperty);
                }
                else
                {
                    return GetInternalEllipsis();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisProperty, value);
                }
                else
                {
                    SetInternalEllipsis(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEllipsis(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.ELLIPSIS, newValue);
        }

        private bool GetInternalEllipsis()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.ELLIPSIS);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (EllipsisPosition)GetValue(EllipsisPositionProperty);
                }
                else
                {
                    return GetInternalEllipsisPosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisPositionProperty, value);
                }
                else
                {
                    SetInternalEllipsisPosition(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEllipsisPosition(EllipsisPosition newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.EllipsisPosition, (int)newValue);
        }

        private EllipsisPosition GetInternalEllipsisPosition()
        {
            return (EllipsisPosition)Object.InternalGetPropertyInt(SwigCPtr, Property.EllipsisPosition);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (LineWrapMode)GetValue(LineWrapModeProperty);
                }
                else
                {
                    return GetInternalLineWrapMode();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineWrapModeProperty, value);
                }
                else
                {
                    SetInternalLineWrapMode(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalLineWrapMode(LineWrapMode newValue)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.LineWrapMode, (int)newValue);
        }

        private LineWrapMode GetInternalLineWrapMode()
        {
            return (LineWrapMode)Object.InternalGetPropertyInt(SwigCPtr, Property.LineWrapMode);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableShiftSelectionProperty);
                }
                else
                {
                    return GetInternalEnableShiftSelection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableShiftSelectionProperty, value);
                }
                else
                {
                    SetInternalEnableShiftSelection(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableShiftSelection(bool newValue)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableShiftSelection, newValue);
        }

        private bool GetInternalEnableShiftSelection()
        {
            //textEditor.mShiftSelectionFlag(true);
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableShiftSelection);
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool MatchSystemLanguageDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(MatchSystemLanguageDirectionProperty);
                }
                else
                {
                    return GetInternalMatchSystemLanguageDirection();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MatchSystemLanguageDirectionProperty, value);
                }
                else
                {
                    SetInternalMatchSystemLanguageDirection(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMatchSystemLanguageDirection(bool matched)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.MatchSystemLanguageDirection, matched);
        }

        private bool GetInternalMatchSystemLanguageDirection()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.MatchSystemLanguageDirection);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(MaxLengthProperty);
                }
                else
                {
                    return GetInternalMaxLength();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MaxLengthProperty, value);
                }
                else
                {
                    SetInternalMaxLength(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMaxLength(int len)
        {
            Object.InternalSetPropertyInt(SwigCPtr, Property.MaxLength, len);
        }

        private int GetInternalMaxLength()
        {
            return Object.InternalGetPropertyInt(SwigCPtr, Property.MaxLength);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(FontSizeScaleProperty);
                }
                else
                {
                    return InternalFontSizeScale;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontSizeScaleProperty, value);
                }
                else
                {
                    InternalFontSizeScale = value;
                }
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
                        systemSettingsFontSize = SystemFontSizeChangedManager.FontSize;
                    }
                    catch (Exception e)
                    {
                        Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableFontSizeScaleProperty);
                }
                else
                {
                    return GetInternalEnableFontSizeScale();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableFontSizeScaleProperty, value);
                }
                else
                {
                    SetInternalEnableFontSizeScale(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableFontSizeScale(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableFontSizeScale, enabled);
        }

        private bool GetInternalEnableFontSizeScale()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableFontSizeScale);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(InputMethodSettingsProperty);
                }
                else
                {
                    return GetInternalInputMethodSettings();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputMethodSettingsProperty, value);
                }
                else
                {
                    SetInternalInputMethodSettings(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalInputMethodSettings(PropertyMap newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.InputMethodSettings, pv);
            }
        }

        private PropertyMap GetInternalInputMethodSettings()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.InputMethodSettings);
            prop.Get(temp);
            return temp;
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
        /// Selects the entire text within the TextEditor control.
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableGrabHandleProperty);
                }
                else
                {
                    return GetInternalEnableGrabHandle();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableGrabHandleProperty, value);
                }
                else
                {
                    SetInternalEnableGrabHandle(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableGrabHandle(bool enabled)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableGrabHandle, enabled);
        }

        private bool GetInternalEnableGrabHandle()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableGrabHandle);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableGrabHandlePopupProperty);
                }
                else
                {
                    return GetInternalEnableGrabHandlePopup();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableGrabHandlePopupProperty, value);
                }
                else
                {
                    SetInternalEnableGrabHandlePopup(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalEnableGrabHandlePopup(bool popup)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.EnableGrabHandlePopup, popup);
        }

        private bool GetInternalEnableGrabHandlePopup()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.EnableGrabHandlePopup);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(MinLineSizeProperty);
                }
                else
                {
                    return GetInternalMinLineSize();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MinLineSizeProperty, value);
                }
                else
                {
                    SetInternalMinLineSize(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMinLineSize(float newValue)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.MinLineSize, (float)newValue);
        }

        private float GetInternalMinLineSize()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.MinLineSize);
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
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(CharacterSpacingProperty);
                }
                else
                {
                    return GetInternalCharacterSpacing();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CharacterSpacingProperty, value);
                }
                else
                {
                    SetInternalCharacterSpacing(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCharacterSpacing(float space)
        {
            Object.InternalSetPropertyFloat(SwigCPtr, Property.CharacterSpacing, (float)space);
        }

        private float GetInternalCharacterSpacing()
        {
            return Object.InternalGetPropertyFloat(SwigCPtr, Property.CharacterSpacing);
        }

        /// <summary>
        /// The RemoveFrontInset property.<br />
        /// This property is used when the xBearing of first glyph must not be trimmed.<br />
        /// When set to false, The gap between (0, 0) from the first glyph's leftmost pixel is included in the width of text label.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveFrontInset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RemoveFrontInsetProperty);
                }
                else
                {
                    return GetInternalRemoveFrontInset();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RemoveFrontInsetProperty, value);
                }
                else
                {
                    SetInternalRemoveFrontInset(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRemoveFrontInset(bool remove)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.RemoveFrontInset, remove);
        }

        private bool GetInternalRemoveFrontInset()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.RemoveFrontInset);
        }

        /// <summary>
        /// The RemoveBackInset property.<br />
        /// This property is used when the advance of last glyph must not be trimmed.<br />
        /// When set to false, The gap between the last glyph's rightmost pixel and X coordinate that next glyph will be placed is included in the width of text label.
        /// </summary>
        /// <remarks>
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveBackInset
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(RemoveBackInsetProperty);
                }
                else
                {
                    return GetInternalRemoveBackInset();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RemoveBackInsetProperty, value);
                }
                else
                {
                    SetInternalRemoveBackInset(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalRemoveBackInset(bool remove)
        {
            Object.InternalSetPropertyBool(SwigCPtr, Property.RemoveBackInset, remove);
        }

        private bool GetInternalRemoveBackInset()
        {
            return Object.InternalGetPropertyBool(SwigCPtr, Property.RemoveBackInset);
        }

        /// <summary>
        /// The FontVariations property.
        /// </summary>
        /// <remarks>
        /// The FontVariations property allows control over different style axes in a variable font, <br />
        /// such as weight(wght), width(wdth), slant(slnt).
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontVariations
        {
            get
            {
                return GetInternalFontVariations();
            }
            set
            {
                SetInternalFontVariations(value);
                NotifyPropertyChanged();
            }
        }

        private PropertyMap GetInternalFontVariations()
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            PropertyMap temp = new PropertyMap();
#pragma warning restore CA2000 // Dispose objects before losing scope
            using var prop = Object.GetProperty(SwigCPtr, Property.FontVariations);
            prop.Get(temp);
            return temp;
        }

        private void SetInternalFontVariations(PropertyMap newValue)
        {
            if (newValue != null)
            {
                Object.SetProperty(SwigCPtr, Property.FontVariations, new PropertyValue(newValue));
            }
        }

        public void SetProperty(int index, float value)
        {
            Object.SetProperty(SwigCPtr, index, new PropertyValue(value));
        }

        /// <summary>
        /// Dispose.
        /// Releases unmanaged and optionally managed resources.
        /// </summary>
        /// <remarks>
        /// When overriding this method, you need to distinguish between explicit and implicit conditions. For explicit conditions, release both managed and unmanaged resources. For implicit conditions, only release unmanaged resources.
        /// </remarks>
        /// <param name="type">Explicit to release both managed and unmanaged resources. Implicit to release only unmanaged resources.</param>
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

            RemoveSystemSettingsLocaleLanguageChanged();
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
            translatableText = NUIApplication.MultilingualResourceManager?.GetString(textEditorSid, new CultureInfo(SystemLocaleLanguageChangedManager.LocaleLanguage.Replace("_", "-")));
            if (translatableText != null)
            {
                AddSystemSettingsLocaleLanguageChanged();
                return translatableText;
            }
            else
            {
                translatableText = "";
                RemoveSystemSettingsLocaleLanguageChanged();
                return translatableText;
            }
        }

        private void SystemSettingsLocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
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

        private void AddSystemSettingsLocaleLanguageChanged()
        {
            if (!hasSystemLanguageChanged)
            {
                try
                {
                    SystemLocaleLanguageChangedManager.Add(SystemSettingsLocaleLanguageChanged);
                    hasSystemLanguageChanged = true;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
                }
            }
        }
        
        private void RemoveSystemSettingsLocaleLanguageChanged()
        {
            if (hasSystemLanguageChanged)
            {
                try
                {
                    SystemLocaleLanguageChangedManager.Remove(SystemSettingsLocaleLanguageChanged);
                    hasSystemLanguageChanged = false;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
                }
            }
        }

        private void SystemSettingsFontSizeChanged(object sender, FontSizeChangedEventArgs e)
        {
            float newFontSizeScale = TextUtils.GetFontSizeScale(e.Value);
            SetInternalFontSizeScale(newFontSizeScale);
        }

        private void AddSystemSettingsFontSizeChanged()
        {
            if (!hasSystemFontSizeChanged)
            {
                try
                {
                    SystemFontSizeChangedManager.Add(SystemSettingsFontSizeChanged);
                    hasSystemFontSizeChanged = true;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
                }
            }
        }

        private void RemoveSystemSettingsFontSizeChanged()
        {
            if (hasSystemFontSizeChanged)
            {
                try
                {
                    SystemFontSizeChangedManager.Remove(SystemSettingsFontSizeChanged);
                    hasSystemFontSizeChanged = false;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
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
                    SystemFontTypeChangedManager.Add(SystemSettingsFontTypeChanged);
                    hasSystemFontTypeChanged = true;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
                }
            }
        }

        private void RemoveSystemSettingsFontTypeChanged()
        {
            if (hasSystemFontTypeChanged)
            {
                try
                {
                    SystemFontTypeChangedManager.Remove(SystemSettingsFontTypeChanged);
                    hasSystemFontTypeChanged = false;
                }
                catch (Exception e)
                {
                    Tizen.Log.Info("NUI", $"{e} Exception caught.\n");
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
            internal static readonly int RemoveFrontInset = Interop.TextEditor.RemoveFrontInsetGet();
            internal static readonly int RemoveBackInset = Interop.TextEditor.RemoveBackInsetGet();
            internal static readonly int FontVariations = Interop.TextEditor.FontVariationsGet();

            internal static void Preload()
            {
                // Do nothing. Just call for load static values.
            }
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

        internal class TextEditorLayout : LayoutItem
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

            /// <inheritdoc/>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public override bool IsPaddingHandledByNative()
            {
                return true;
            }
        }
    }
}
