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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The style class for TextEditor.
    /// This can decorate a TextEditor instance.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextEditorStyle : ViewStyle
    {
        static readonly IStyleProperty FontFamilyProperty = new StyleProperty<TextEditor, string>((v, o) => v.FontFamily = o);
        static readonly IStyleProperty HorizontalAlignmentProperty = new StyleProperty<TextEditor, HorizontalAlignment>((v, o) => v.HorizontalAlignment = o);
        static readonly IStyleProperty VerticalAlignmentProperty = new StyleProperty<TextEditor, VerticalAlignment>((v, o) => v.VerticalAlignment = o);
        static readonly IStyleProperty SecondaryCursorColorProperty = new StyleProperty<TextEditor, Vector4>((v, o) => v.SecondaryCursorColor = o);
        static readonly IStyleProperty EnableCursorBlinkProperty = new StyleProperty<TextEditor, bool>((v, o) => v.EnableCursorBlink = o);
        static readonly IStyleProperty CursorBlinkIntervalProperty = new StyleProperty<TextEditor, float>((v, o) => v.CursorBlinkInterval = o);
        static readonly IStyleProperty CursorBlinkDurationProperty = new StyleProperty<TextEditor, float>((v, o) => v.CursorBlinkDuration = o);
        static readonly IStyleProperty CursorWidthProperty = new StyleProperty<TextEditor, int>((v, o) => v.CursorWidth = o);
        static readonly IStyleProperty GrabHandleColorProperty = new StyleProperty<TextEditor, Color>((v, o) => v.GrabHandleColor = o);
        static readonly IStyleProperty GrabHandleImageProperty = new StyleProperty<TextEditor, string>((v, o) => v.GrabHandleImage = o);
        static readonly IStyleProperty GrabHandlePressedImageProperty = new StyleProperty<TextEditor, string>((v, o) => v.GrabHandlePressedImage = o);
        static readonly IStyleProperty SelectionHandleImageLeftProperty = new StyleProperty<TextEditor, PropertyMap>((v, o) => v.SelectionHandleImageLeft = o);
        static readonly IStyleProperty SelectionHandleImageRightProperty = new StyleProperty<TextEditor, PropertyMap>((v, o) => v.SelectionHandleImageRight = o);
        static readonly IStyleProperty ScrollThresholdProperty = new StyleProperty<TextEditor, float>((v, o) => v.ScrollThreshold = o);
        static readonly IStyleProperty ScrollSpeedProperty = new StyleProperty<TextEditor, float>((v, o) => v.ScrollSpeed = o);
        static readonly IStyleProperty SelectionHighlightColorProperty = new StyleProperty<TextEditor, Vector4>((v, o) => v.SelectionHighlightColor = o);
        static readonly IStyleProperty DecorationBoundingBoxProperty = new StyleProperty<TextEditor, Rectangle>((v, o) => v.DecorationBoundingBox = o);
        static readonly IStyleProperty InputColorProperty = new StyleProperty<TextEditor, Vector4>((v, o) => v.InputColor = o);
        static readonly IStyleProperty InputFontFamilyProperty = new StyleProperty<TextEditor, string>((v, o) => v.InputFontFamily = o);
        static readonly IStyleProperty InputPointSizeProperty = new StyleProperty<TextEditor, float>((v, o) => v.InputPointSize = o);
        static readonly IStyleProperty InputUnderlineProperty = new StyleProperty<TextEditor, string>((v, o) => v.InputUnderline = o);
        static readonly IStyleProperty InputShadowProperty = new StyleProperty<TextEditor, string>((v, o) => v.InputShadow = o);
        static readonly IStyleProperty EmbossProperty = new StyleProperty<TextEditor, string>((v, o) => v.Emboss = o);
        static readonly IStyleProperty InputEmbossProperty = new StyleProperty<TextEditor, string>((v, o) => v.InputEmboss = o);
        static readonly IStyleProperty InputOutlineProperty = new StyleProperty<TextEditor, string>((v, o) => v.InputOutline = o);
        static readonly IStyleProperty SmoothScrollProperty = new StyleProperty<TextEditor, bool>((v, o) => v.SmoothScroll = o);
        static readonly IStyleProperty SmoothScrollDurationProperty = new StyleProperty<TextEditor, float>((v, o) => v.SmoothScrollDuration = o);
        static readonly IStyleProperty EnableScrollBarProperty = new StyleProperty<TextEditor, bool>((v, o) => v.EnableScrollBar = o);
        static readonly IStyleProperty ScrollBarShowDurationProperty = new StyleProperty<TextEditor, float>((v, o) => v.ScrollBarShowDuration = o);
        static readonly IStyleProperty ScrollBarFadeDurationProperty = new StyleProperty<TextEditor, float>((v, o) => v.ScrollBarFadeDuration = o);
        static readonly IStyleProperty PixelSizeProperty = new StyleProperty<TextEditor, float>((v, o) => v.PixelSize = o);
        static readonly IStyleProperty EnableSelectionProperty = new StyleProperty<TextEditor, bool>((v, o) => v.EnableSelection = o);
        static readonly IStyleProperty MatchSystemLanguageDirectionProperty = new StyleProperty<TextEditor, bool>((v, o) => v.MatchSystemLanguageDirection = o);
        static readonly IStyleProperty TextColorProperty = new StyleProperty<TextEditor, Vector4>((v, o) => v.TextColor = o);
        static readonly IStyleProperty PointSizeProperty = new StyleProperty<TextEditor, float>((v, o) => v.PointSize = o);
        static readonly IStyleProperty PlaceholderTextColorProperty = new StyleProperty<TextEditor, Color>((v, o) => v.PlaceholderTextColor = o);
        static readonly IStyleProperty PrimaryCursorColorProperty = new StyleProperty<TextEditor, Vector4>((v, o) => v.PrimaryCursorColor = o);
        static readonly IStyleProperty FontStyleProperty = new StyleProperty<TextEditor, PropertyMap>((v, o) => v.FontStyle = o);
        static readonly IStyleProperty EllipsisProperty = new StyleProperty<TextEditor, bool>((v, o) => v.Ellipsis = o);
        static readonly IStyleProperty LineSpacingProperty = new StyleProperty<TextEditor, float>((v, o) => v.LineSpacing = o);
        static readonly IStyleProperty MinLineSizeProperty = new StyleProperty<TextEditor, float>((v, o) => v.MinLineSize = o);
        static readonly IStyleProperty RelativeLineHeightProperty = new StyleProperty<TextEditor, float>((v, o) => v.RelativeLineHeight = o);
        static readonly IStyleProperty FontSizeScaleProperty = new StyleProperty<TextEditor, float>((v, o) => v.FontSizeScale = o);
        static readonly IStyleProperty SelectionPopupStyleProperty = new StyleProperty<TextEditor, PropertyMap>((v, o) => v.SelectionPopupStyle = o);

        static TextEditorStyle() { }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextEditorStyle() : base()
        {
        }

        /// <summary>
        /// The FontFamily property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
            set => SetValue(HorizontalAlignmentProperty, value);
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
            set => SetValue(VerticalAlignmentProperty, value);
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get => (Vector4)GetValue(SecondaryCursorColorProperty);
            set => SetValue(SecondaryCursorColorProperty, value);
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get => (bool?)GetValue(EnableCursorBlinkProperty);
            set => SetValue(EnableCursorBlinkProperty, value);
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get => (float?)GetValue(CursorBlinkIntervalProperty);
            set => SetValue(CursorBlinkIntervalProperty, value);
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get => (float?)GetValue(CursorBlinkDurationProperty);
            set => SetValue(CursorBlinkDurationProperty, value);
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get => (int?)GetValue(CursorWidthProperty);
            set => SetValue(CursorWidthProperty, value);
        }

        /// <summary>
        /// The GrabHandleColor property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get => (Color)GetValue(GrabHandleColorProperty);
            set => SetValue(GrabHandleColorProperty, value);
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandleImage
        {
            get => (string)GetValue(GrabHandleImageProperty);
            set => SetValue(GrabHandleImageProperty, value);
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandlePressedImage
        {
            get => (string)GetValue(GrabHandlePressedImageProperty);
            set => SetValue(GrabHandlePressedImageProperty, value);
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageLeft
        {
            get => (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            set => SetValue(SelectionHandleImageLeftProperty, value);
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageRight
        {
            get => (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            set => SetValue(SelectionHandleImageRightProperty, value);
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get => (float?)GetValue(ScrollThresholdProperty);
            set => SetValue(ScrollThresholdProperty, value);
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get => (float?)GetValue(ScrollSpeedProperty);
            set => SetValue(ScrollSpeedProperty, value);
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get => (Vector4)GetValue(SelectionHighlightColorProperty);
            set => SetValue(SelectionHighlightColorProperty, value);
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get => (Rectangle)GetValue(DecorationBoundingBoxProperty);
            set => SetValue(DecorationBoundingBoxProperty, value);
        }

        /// <summary>
        /// The InputColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get => (Vector4)GetValue(InputColorProperty);
            set => SetValue(InputColorProperty, value);
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputFontFamily
        {
            get => (string)GetValue(InputFontFamilyProperty);
            set => SetValue(InputFontFamilyProperty, value);
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get => (float?)GetValue(InputPointSizeProperty);
            set => SetValue(InputPointSizeProperty, value);
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputUnderline
        {
            get => (string)GetValue(InputUnderlineProperty);
            set => SetValue(InputUnderlineProperty, value);
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputShadow
        {
            get => (string)GetValue(InputShadowProperty);
            set => SetValue(InputShadowProperty, value);
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get => (string)GetValue(EmbossProperty);
            set => SetValue(EmbossProperty, value);
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputEmboss
        {
            get => (string)GetValue(InputEmbossProperty);
            set => SetValue(InputEmbossProperty, value);
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputOutline
        {
            get => (string)GetValue(InputOutlineProperty);
            set => SetValue(InputOutlineProperty, value);
        }

        /// <summary>
        /// The SmoothScroll property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SmoothScroll
        {
            get => (bool?)GetValue(SmoothScrollProperty);
            set => SetValue(SmoothScrollProperty, value);
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SmoothScrollDuration
        {
            get => (float?)GetValue(SmoothScrollDurationProperty);
            set => SetValue(SmoothScrollDurationProperty, value);
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableScrollBar
        {
            get => (bool?)GetValue(EnableScrollBarProperty);
            set => SetValue(EnableScrollBarProperty, value);
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarShowDuration
        {
            get => (float?)GetValue(ScrollBarShowDurationProperty);
            set => SetValue(ScrollBarShowDurationProperty, value);
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarFadeDuration
        {
            get => (float?)GetValue(ScrollBarFadeDurationProperty);
            set => SetValue(ScrollBarFadeDurationProperty, value);
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get => (float?)GetValue(PixelSizeProperty);
            set => SetValue(PixelSizeProperty, value);
        }

        /// <summary>
        /// The EnableSelection property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get => (bool?)GetValue(EnableSelectionProperty);
            set => SetValue(EnableSelectionProperty, value);
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get => (bool?)GetValue(MatchSystemLanguageDirectionProperty);
            set => SetValue(MatchSystemLanguageDirectionProperty, value);
        }

        /// <summary>
        /// The TextColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 TextColor
        {
            get => (Vector4)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize
        {
            get => (float?)GetValue(PointSizeProperty);
            set => SetValue(PointSizeProperty, value);
        }

        /// <summary>
        /// The Placeholder text color.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color PlaceholderTextColor
        {
            get => (Color)GetValue(PlaceholderTextColorProperty);
            set => SetValue(PlaceholderTextColorProperty, value);
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PrimaryCursorColor
        {
            get => (Vector4)GetValue(PrimaryCursorColorProperty);
            set => SetValue(PrimaryCursorColorProperty, value);
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontStyle
        {
            get => (PropertyMap)GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get => (bool?)GetValue(EllipsisProperty);
            set => SetValue(EllipsisProperty, value);
        }

        /// <summary>
        /// the line spacing to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get => (float?)GetValue(LineSpacingProperty);
            set => SetValue(LineSpacingProperty, value);
        }

        /// <summary>
        /// the minimum line size to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MinLineSize
        {
            get => (float?)GetValue(MinLineSizeProperty);
            set => SetValue(MinLineSizeProperty, value);
        }

        /// <summary>
        /// the relative line height to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RelativeLineHeight
        {
            get => (float?)GetValue(RelativeLineHeightProperty);
            set => SetValue(RelativeLineHeightProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get => (float?)GetValue(FontSizeScaleProperty);
            set => SetValue(FontSizeScaleProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionPopupStyle
        {
            get => (PropertyMap)GetValue(SelectionPopupStyleProperty);
            set => SetValue(SelectionPopupStyleProperty, value);
        }
    }
}
