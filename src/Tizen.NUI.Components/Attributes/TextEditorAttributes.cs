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
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Components
{
    /// <summary>
    /// TextEditorAttributes is a class which saves TextField's ux data.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextEditorAttributes : ViewAttributes
    {
        /// <summary>
        /// Creates a new instance of a TextEditorAttributes.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditorAttributes() : base() { }

        /// <summary>
        /// Construct with specified attribute.
        /// </summary>
        /// <param name="attributes">The specified TextEditorAttributes.</param>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditorAttributes(TextEditorAttributes attributes) : base(attributes)
        {
            if(null == attributes)
            {
                return;
            }
            if (null != attributes.Text)
            {
                Text = attributes.Text.Clone() as StringSelector;
            }
            if (null != attributes.PlaceholderText)
            {
                PlaceholderText = attributes.PlaceholderText.Clone() as StringSelector;
            }
            if (null != attributes.TranslatablePlaceholderText)
            {
                TranslatablePlaceholderText = attributes.TranslatablePlaceholderText.Clone() as StringSelector;
            }
            if (null != attributes.HorizontalAlignment)
            {
                HorizontalAlignment = attributes.HorizontalAlignment;
            }
            if (null != attributes.EnableMarkup)
            {
                EnableMarkup = attributes.EnableMarkup;
            }
            if (null != attributes.TextColor)
            {
                TextColor = attributes.TextColor.Clone() as ColorSelector;
            }
            if (null != attributes.PlaceholderTextColor)
            {
                PlaceholderTextColor = attributes.PlaceholderTextColor.Clone() as ColorSelector;
            }
            if (null != attributes.PrimaryCursorColor)
            {
                PrimaryCursorColor = attributes.PrimaryCursorColor.Clone() as ColorSelector;
            }
            if (null != attributes.SecondaryCursorColor)
            {
                SecondaryCursorColor = attributes.SecondaryCursorColor.Clone() as ColorSelector;
            }
            if (null != attributes.FontFamily)
            {
                FontFamily = attributes.FontFamily;
            }
            if (null != attributes.PointSize)
            {
                PointSize = attributes.PointSize.Clone() as FloatSelector;
            }
            if (null != attributes.EnableCursorBlink)
            {
                EnableCursorBlink = attributes.EnableCursorBlink;
            }
            if (null != attributes.EnableSelection)
            {
                EnableSelection = attributes.EnableSelection;
            }
            if (null != attributes.CursorWidth)
            {
                CursorWidth = attributes.CursorWidth;
            }
            if (null != attributes.TranslatableText)
            {
                TranslatableText = attributes.TranslatableText;
            }
            if (null != attributes.ScrollThreshold)
            {
                ScrollThreshold = attributes.ScrollThreshold;
            }
            if (null != attributes.ScrollSpeed)
            {
                ScrollSpeed = attributes.ScrollSpeed;
            }
            if (null != attributes.CursorBlinkInterval)
            {
                CursorBlinkInterval = attributes.CursorBlinkInterval;
            }
            if (null != attributes.CursorBlinkDuration)
            {
                CursorBlinkDuration = attributes.CursorBlinkDuration;
            }
            if (null != attributes.GrabHandleImage)
            {
                GrabHandleImage = attributes.GrabHandleImage;
            }
            if (null != attributes.GrabHandlePressedImage)
            {
                GrabHandlePressedImage = attributes.GrabHandlePressedImage;
            }
            if (null != attributes.SelectionHighlightColor)
            {
                SelectionHighlightColor = attributes.SelectionHighlightColor;
            }
            if (null != attributes.DecorationBoundingBox)
            {
                DecorationBoundingBox = attributes.DecorationBoundingBox;
            }
            if (null != attributes.InputColor)
            {
                InputColor = attributes.InputColor;
            }
            if (null != attributes.InputFontFamily)
            {
                InputFontFamily = attributes.InputFontFamily;
            }
            if (null != attributes.InputPointSize)
            {
                InputPointSize = attributes.InputPointSize;
            }
            if (null != attributes.LineSpacing)
            {
                LineSpacing = attributes.LineSpacing;
            }
            if (null != attributes.InputLineSpacing)
            {
                InputLineSpacing = attributes.InputLineSpacing;
            }
            if (null != attributes.InputUnderline)
            {
                InputUnderline = attributes.InputUnderline;
            }
            if (null != attributes.InputShadow)
            {
                InputShadow = attributes.InputShadow;
            }
            if (null != attributes.Emboss)
            {
                Emboss = attributes.Emboss;
            }
            if (null != attributes.InputEmboss)
            {
                InputEmboss = attributes.InputEmboss;
            }
            if (null != attributes.InputOutline)
            {
                InputOutline = attributes.InputOutline;
            }
            if (null != attributes.SmoothScroll)
            {
                SmoothScroll = attributes.SmoothScroll;
            }
            if (null != attributes.SmoothScrollDuration)
            {
                SmoothScrollDuration = attributes.SmoothScrollDuration;
            }
            if (null != attributes.EnableScrollBar)
            {
                EnableScrollBar = attributes.EnableScrollBar;
            }
            if (null != attributes.ScrollBarShowDuration)
            {
                ScrollBarShowDuration = attributes.ScrollBarShowDuration;
            }
            if (null != attributes.ScrollBarFadeDuration)
            {
                ScrollBarFadeDuration = attributes.ScrollBarFadeDuration;
            }
            if (null != attributes.PixelSize)
            {
                PixelSize = attributes.PixelSize;
            }
            if (null != attributes.LineWrapMode)
            {
                LineWrapMode = attributes.LineWrapMode;
            }
            if (null != attributes.EnableShiftSelection)
            {
                EnableShiftSelection = attributes.EnableShiftSelection;
            }
            if (null != attributes.MatchSystemLanguageDirection)
            {
                MatchSystemLanguageDirection = attributes.MatchSystemLanguageDirection;
            }
        }

        /// <summary>
        /// Gets or sets text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector Text
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets place holder text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector PlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets translatable place holder text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public StringSelector TranslatablePlaceholderText
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets horizontal alignment of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable mark up.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets text color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector TextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets place holder text color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PlaceholderTextColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector PrimaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets secondary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ColorSelector SecondaryCursorColor
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets font family of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets point size of text.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FloatSelector PointSize
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable cursor blink.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets enable selection.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets cursor width.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get;
            set;
        }

        //-----------------Start-----------------
        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 6 </since_tizen>
        public string TranslatableText
        {
            get;
            set;
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? ScrollThreshold
        {
            get;
            set;
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? ScrollSpeed
        {
            get;
            set;
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? CursorBlinkInterval
        {
            get;
            set;
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? CursorBlinkDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string GrabHandleImage
        {
            get;
            set;
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string GrabHandlePressedImage
        {
            get;
            set;
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Vector4 SelectionHighlightColor
        {
            get;
            set;
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Rectangle DecorationBoundingBox
        {
            get;
            set;
        }

        /// <summary>
        /// The InputColor property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public Vector4 InputColor
        {
            get;
            set;
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InputFontFamily
        {
            get;
            set;
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? InputPointSize
        {
            get;
            set;
        }

        /// <summary>
        /// The LineSpacing property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? LineSpacing
        {
            get;
            set;
        }

        /// <summary>
        /// The InputLineSpacing property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? InputLineSpacing
        {
            get;
            set;
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InputUnderline
        {
            get;
            set;
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InputShadow
        {
            get;
            set;
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Emboss
        {
            get;
            set;
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InputEmboss
        {
            get;
            set;
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string InputOutline
        {
            get;
            set;
        }

        /// <summary>
        /// The SmoothScroll property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool? SmoothScroll
        {
            get;
            set;
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? SmoothScrollDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool? EnableScrollBar
        {
            get;
            set;
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? ScrollBarShowDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? ScrollBarFadeDuration
        {
            get;
            set;
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public float? PixelSize
        {
            get;
            set;
        }

        /// <summary>
        /// The LineWrapMode property.<br />
        /// The line wrap mode when the text lines over the layout width.<br />
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public LineWrapMode? LineWrapMode
        {
            get;
            set;
        }

        /// <summary>
        /// Enables Text selection using Shift key.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableShiftSelection
        {
            get;
            set;
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool? MatchSystemLanguageDirection
        {
            get;
            set;
        }
        //-----------------End-----------------

        /// <summary>
        /// Attributes's clone function.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override Attributes Clone()
        {
            return new TextEditorAttributes(this);
        }

        /// <summary>
        /// Apply ViewAttributes to TextField.
        /// </summary>
        public override void ApplyToView(View view, ControlStates state)
        {
            base.ApplyToView(view, state);

            TextEditor textField = view as TextEditor;
            TextEditorAttributes textFieldAttrs = this;
            if (textField != null && textFieldAttrs != null)
            {
                if (textFieldAttrs.Text?.GetValue(state) != null)
                {
                    textField.Text = textFieldAttrs.Text.GetValue(state);
                }
                if (textFieldAttrs.PlaceholderText?.GetValue(state) != null)
                {
                    textField.PlaceholderText = textFieldAttrs.PlaceholderText.GetValue(state);
                }
                if (textFieldAttrs.TranslatablePlaceholderText?.GetValue(state) != null)
                {
                    textField.TranslatablePlaceholderText = textFieldAttrs.TranslatablePlaceholderText.GetValue(state);
                }
                if (textFieldAttrs.TextColor?.GetValue(state) != null)
                {
                    textField.TextColor = textFieldAttrs.TextColor.GetValue(state);
                }
                if (textFieldAttrs.PlaceholderTextColor?.GetValue(state) != null)
                {
                    textField.PlaceholderTextColor = textFieldAttrs.PlaceholderTextColor.GetValue(state);
                }
                if (textFieldAttrs.PrimaryCursorColor?.GetValue(state) != null)
                {
                    textField.PrimaryCursorColor = textFieldAttrs.PrimaryCursorColor.GetValue(state);
                }
                if (textFieldAttrs.SecondaryCursorColor?.GetValue(state) != null)
                {
                    textField.SecondaryCursorColor = textFieldAttrs.SecondaryCursorColor.GetValue(state);
                }
                if (textFieldAttrs.PointSize?.GetValue(state) != null)
                {
                    textField.PointSize = textFieldAttrs.PointSize.GetValue(state).Value;
                }
                if (textFieldAttrs.HorizontalAlignment != null)
                {
                    textField.HorizontalAlignment = textFieldAttrs.HorizontalAlignment.Value;
                }
                if (textFieldAttrs.EnableMarkup != null)
                {
                    textField.EnableMarkup = textFieldAttrs.EnableMarkup.Value;
                }
                if (textFieldAttrs.FontFamily != null)
                {
                    textField.FontFamily = textFieldAttrs.FontFamily;
                }
                if (textFieldAttrs.EnableCursorBlink != null)
                {
                    textField.EnableCursorBlink = textFieldAttrs.EnableCursorBlink.Value;
                }
                if (textFieldAttrs.EnableSelection != null)
                {
                    textField.EnableSelection = textFieldAttrs.EnableSelection.Value;
                }
                if (textFieldAttrs.CursorWidth != null)
                {
                    textField.CursorWidth = textFieldAttrs.CursorWidth.Value;
                }
                if (textFieldAttrs.TranslatableText != null)
                {
                    textField.TranslatableText = textFieldAttrs.TranslatableText;
                }
                if (textFieldAttrs.ScrollThreshold != null)
                {
                    textField.ScrollThreshold = textFieldAttrs.ScrollThreshold.Value;
                }
                if (textFieldAttrs.ScrollSpeed != null)
                {
                    textField.ScrollSpeed = textFieldAttrs.ScrollSpeed.Value;
                }
                if (textFieldAttrs.CursorBlinkInterval != null)
                {
                    textField.CursorBlinkInterval = textFieldAttrs.CursorBlinkInterval.Value;
                }
                if (textFieldAttrs.CursorBlinkDuration != null)
                {
                    textField.CursorBlinkDuration = textFieldAttrs.CursorBlinkDuration.Value;
                }
                if (textFieldAttrs.GrabHandleImage != null)
                {
                    textField.GrabHandleImage = textFieldAttrs.GrabHandleImage;
                }
                if (textFieldAttrs.GrabHandlePressedImage != null)
                {
                    textField.GrabHandlePressedImage = textFieldAttrs.GrabHandlePressedImage;
                }
                if (textFieldAttrs.SelectionHighlightColor != null)
                {
                    textField.SelectionHighlightColor = textFieldAttrs.SelectionHighlightColor;
                }
                if (textFieldAttrs.DecorationBoundingBox != null)
                {
                    textField.DecorationBoundingBox = textFieldAttrs.DecorationBoundingBox;
                }
                if (textFieldAttrs.InputColor != null)
                {
                    textField.InputColor = textFieldAttrs.InputColor;
                }
                if (textFieldAttrs.InputFontFamily != null)
                {
                    textField.InputFontFamily = textFieldAttrs.InputFontFamily;
                }
                if (textFieldAttrs.InputPointSize != null)
                {
                    textField.InputPointSize = textFieldAttrs.InputPointSize.Value;
                }
                if (textFieldAttrs.LineSpacing != null)
                {
                    textField.LineSpacing = textFieldAttrs.LineSpacing.Value;
                }
                if (textFieldAttrs.InputLineSpacing != null)
                {
                    textField.InputLineSpacing = textFieldAttrs.InputLineSpacing.Value;
                }
                if (textFieldAttrs.InputUnderline != null)
                {
                    textField.InputUnderline = textFieldAttrs.InputUnderline;
                }
                if (textFieldAttrs.InputShadow != null)
                {
                    textField.InputShadow = textFieldAttrs.InputShadow;
                }
                if (textFieldAttrs.Emboss != null)
                {
                    textField.Emboss = textFieldAttrs.Emboss;
                }
                if (textFieldAttrs.InputEmboss != null)
                {
                    textField.InputEmboss = textFieldAttrs.InputEmboss;
                }
                if (textFieldAttrs.InputOutline != null)
                {
                    textField.InputOutline = textFieldAttrs.InputOutline;
                }
                if (textFieldAttrs.SmoothScroll != null)
                {
                    textField.SmoothScroll = textFieldAttrs.SmoothScroll.Value;
                }
                if (textFieldAttrs.SmoothScrollDuration != null)
                {
                    textField.SmoothScrollDuration = textFieldAttrs.SmoothScrollDuration.Value;
                }
                if (textFieldAttrs.EnableScrollBar != null)
                {
                    textField.EnableScrollBar = textFieldAttrs.EnableScrollBar.Value;
                }
                if (textFieldAttrs.ScrollBarShowDuration != null)
                {
                    textField.ScrollBarShowDuration = textFieldAttrs.ScrollBarShowDuration.Value;
                }
                if (textFieldAttrs.ScrollBarFadeDuration != null)
                {
                    textField.ScrollBarFadeDuration = textFieldAttrs.ScrollBarFadeDuration.Value;
                }
                if (textFieldAttrs.PixelSize != null)
                {
                    textField.PixelSize = textFieldAttrs.PixelSize.Value;
                }
                if (textFieldAttrs.LineWrapMode != null)
                {
                    textField.LineWrapMode = textFieldAttrs.LineWrapMode.Value;
                }
                if (textFieldAttrs.EnableShiftSelection != null)
                {
                    textField.EnableShiftSelection = textFieldAttrs.EnableShiftSelection.Value;
                }
                if (textFieldAttrs.MatchSystemLanguageDirection != null)
                {
                    textField.MatchSystemLanguageDirection = textFieldAttrs.MatchSystemLanguageDirection.Value;
                }
            }
        }
    }
}
