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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextFieldStyle : ViewStyle
    {
        static readonly IStyleProperty PlaceholderTextProperty = new StyleProperty<TextField, string>((v, o) => v.PlaceholderText = o);
        static readonly IStyleProperty PlaceholderTextFocusedProperty = new StyleProperty<TextField, string>((v, o) => v.PlaceholderTextFocused = o);
        static readonly IStyleProperty FontFamilyProperty = new StyleProperty<TextField, string>((v, o) => v.FontFamily = o);
        static readonly IStyleProperty MaxLengthProperty = new StyleProperty<TextField, int>((v, o) => v.MaxLength = o);
        static readonly IStyleProperty ExceedPolicyProperty = new StyleProperty<TextField, int>((v, o) => v.ExceedPolicy = o);
        static readonly IStyleProperty HorizontalAlignmentProperty = new StyleProperty<TextField, HorizontalAlignment>((v, o) => v.HorizontalAlignment = o);
        static readonly IStyleProperty VerticalAlignmentProperty = new StyleProperty<TextField, VerticalAlignment>((v, o) => v.VerticalAlignment = o);
        static readonly IStyleProperty SecondaryCursorColorProperty = new StyleProperty<TextField, Vector4>((v, o) => v.SecondaryCursorColor = o);
        static readonly IStyleProperty EnableCursorBlinkProperty = new StyleProperty<TextField, bool>((v, o) => v.EnableCursorBlink = o);
        static readonly IStyleProperty CursorBlinkIntervalProperty = new StyleProperty<TextField, float>((v, o) => v.CursorBlinkInterval = o);
        static readonly IStyleProperty CursorBlinkDurationProperty = new StyleProperty<TextField, float>((v, o) => v.CursorBlinkDuration = o);
        static readonly IStyleProperty CursorWidthProperty = new StyleProperty<TextField, int>((v, o) => v.CursorWidth = o);
        static readonly IStyleProperty GrabHandleColorProperty = new StyleProperty<TextField, Color>((v, o) => v.GrabHandleColor = o);
        static readonly IStyleProperty GrabHandleImageProperty = new StyleProperty<TextField, string>((v, o) => v.GrabHandleImage = o);
        static readonly IStyleProperty GrabHandlePressedImageProperty = new StyleProperty<TextField, string>((v, o) => v.GrabHandlePressedImage = o);
        static readonly IStyleProperty SelectionHandleImageLeftProperty = new StyleProperty<TextField, PropertyMap>((v, o) => v.SelectionHandleImageLeft = o);
        static readonly IStyleProperty SelectionHandleImageRightProperty = new StyleProperty<TextField, PropertyMap>((v, o) => v.SelectionHandleImageRight = o);
        static readonly IStyleProperty ScrollThresholdProperty = new StyleProperty<TextField, float>((v, o) => v.ScrollThreshold = o);
        static readonly IStyleProperty ScrollSpeedProperty = new StyleProperty<TextField, float>((v, o) => v.ScrollSpeed = o);
        static readonly IStyleProperty SelectionHighlightColorProperty = new StyleProperty<TextField, Vector4>((v, o) => v.SelectionHighlightColor = o);
        static readonly IStyleProperty DecorationBoundingBoxProperty = new StyleProperty<TextField, Rectangle>((v, o) => v.DecorationBoundingBox = o);
        static readonly IStyleProperty InputColorProperty = new StyleProperty<TextField, Vector4>((v, o) => v.InputColor = o);
        static readonly IStyleProperty EnableMarkupProperty = new StyleProperty<TextField, bool>((v, o) => v.EnableMarkup = o);
        static readonly IStyleProperty InputFontFamilyProperty = new StyleProperty<TextField, string>((v, o) => v.InputFontFamily = o);
        static readonly IStyleProperty InputPointSizeProperty = new StyleProperty<TextField, float>((v, o) => v.InputPointSize = o);
        static readonly IStyleProperty InputUnderlineProperty = new StyleProperty<TextField, string>((v, o) => v.InputUnderline = o);
        static readonly IStyleProperty InputShadowProperty = new StyleProperty<TextField, string>((v, o) => v.InputShadow = o);
        static readonly IStyleProperty EmbossProperty = new StyleProperty<TextField, string>((v, o) => v.Emboss = o);
        static readonly IStyleProperty InputEmbossProperty = new StyleProperty<TextField, string>((v, o) => v.InputEmboss = o);
        static readonly IStyleProperty InputOutlineProperty = new StyleProperty<TextField, string>((v, o) => v.InputOutline = o);
        static readonly IStyleProperty PixelSizeProperty = new StyleProperty<TextField, float>((v, o) => v.PixelSize = o);
        static readonly IStyleProperty EnableSelectionProperty = new StyleProperty<TextField, bool>((v, o) => v.EnableSelection = o);
        static readonly IStyleProperty EllipsisProperty = new StyleProperty<TextField, bool>((v, o) => v.Ellipsis = o);
        static readonly IStyleProperty MatchSystemLanguageDirectionProperty = new StyleProperty<TextField, bool>((v, o) => v.MatchSystemLanguageDirection = o);
        static readonly IStyleProperty TextColorProperty = new StyleProperty<TextField, Color>((v, o) => v.TextColor = o);
        static readonly IStyleProperty PointSizeProperty = new StyleProperty<TextField, float>((v, o) => v.PointSize = o);
        static readonly IStyleProperty FontSizeScaleProperty = new StyleProperty<TextField, float>((v, o) => v.FontSizeScale = o);
        static readonly IStyleProperty PlaceholderTextColorProperty = new StyleProperty<TextField, Vector4>((v, o) => v.PlaceholderTextColor = o);
        static readonly IStyleProperty PrimaryCursorColorProperty = new StyleProperty<TextField, Vector4>((v, o) => v.PrimaryCursorColor = o);
        static readonly IStyleProperty FontStyleProperty = new StyleProperty<TextField, PropertyMap>((v, o) => v.FontStyle = o);
        static readonly IStyleProperty SelectionPopupStyleProperty = new StyleProperty<TextField, PropertyMap>((v, o) => v.SelectionPopupStyle = o);

        static TextFieldStyle() { }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldStyle() : base()
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderTextFocused
        {
            get => (string)GetValue(PlaceholderTextFocusedProperty);
            set => SetValue(PlaceholderTextFocusedProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? MaxLength
        {
            get => (int?)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ExceedPolicy
        {
            get => (int?)GetValue(ExceedPolicyProperty);
            set => SetValue(ExceedPolicyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
            set => SetValue(HorizontalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
            set => SetValue(VerticalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get => (Vector4)GetValue(SecondaryCursorColorProperty);
            set => SetValue(SecondaryCursorColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get => (bool?)GetValue(EnableCursorBlinkProperty);
            set => SetValue(EnableCursorBlinkProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get => (float?)GetValue(CursorBlinkIntervalProperty);
            set => SetValue(CursorBlinkIntervalProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get => (float?)GetValue(CursorBlinkDurationProperty);
            set => SetValue(CursorBlinkDurationProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get => (int?)GetValue(CursorWidthProperty);
            set => SetValue(CursorWidthProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get => (Color)GetValue(GrabHandleColorProperty);
            set => SetValue(GrabHandleColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandleImage
        {
            get => (string)GetValue(GrabHandleImageProperty);
            set => SetValue(GrabHandleImageProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandlePressedImage
        {
            get => (string)GetValue(GrabHandlePressedImageProperty);
            set => SetValue(GrabHandlePressedImageProperty, value);
        }
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageLeft
        {
            get => (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            set => SetValue(SelectionHandleImageLeftProperty, value);
        }
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageRight
        {
            get => (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            set => SetValue(SelectionHandleImageRightProperty, value);
        }
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get => (float?)GetValue(ScrollThresholdProperty);
            set => SetValue(ScrollThresholdProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get => (float?)GetValue(ScrollSpeedProperty);
            set => SetValue(ScrollSpeedProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get => (Vector4)GetValue(SelectionHighlightColorProperty);
            set => SetValue(SelectionHighlightColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get => (Rectangle)GetValue(DecorationBoundingBoxProperty);
            set => SetValue(DecorationBoundingBoxProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get => (Vector4)GetValue(InputColorProperty);
            set => SetValue(InputColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get => (bool?)GetValue(EnableMarkupProperty);
            set => SetValue(EnableMarkupProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputFontFamily
        {
            get => (string)GetValue(InputFontFamilyProperty);
            set => SetValue(InputFontFamilyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get => (float?)GetValue(InputPointSizeProperty);
            set => SetValue(InputPointSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputUnderline
        {
            get => (string)GetValue(InputUnderlineProperty);
            set => SetValue(InputUnderlineProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputShadow
        {
            get => (string)GetValue(InputShadowProperty);
            set => SetValue(InputShadowProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get => (string)GetValue(EmbossProperty);
            set => SetValue(EmbossProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputEmboss
        {
            get => (string)GetValue(InputEmbossProperty);
            set => SetValue(InputEmbossProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputOutline
        {
            get => (string)GetValue(InputOutlineProperty);
            set => SetValue(InputOutlineProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get => (float?)GetValue(PixelSizeProperty);
            set => SetValue(PixelSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get => (bool?)GetValue(EnableSelectionProperty);
            set => SetValue(EnableSelectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get => (bool?)GetValue(EllipsisProperty);
            set => SetValue(EllipsisProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get => (bool?)GetValue(MatchSystemLanguageDirectionProperty);
            set => SetValue(MatchSystemLanguageDirectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize
        {
            get => (float?)GetValue(PointSizeProperty);
            set => SetValue(PointSizeProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get => (float?)GetValue(FontSizeScaleProperty);
            set => SetValue(FontSizeScaleProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PlaceholderTextColor
        {
            get => (Vector4)GetValue(PlaceholderTextColorProperty);
            set => SetValue(PlaceholderTextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PrimaryCursorColor
        {
            get => (Vector4)GetValue(PrimaryCursorColorProperty);
            set => SetValue(PrimaryCursorColorProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontStyle
        {
            get => (PropertyMap)GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionPopupStyle
        {
            get => (PropertyMap)GetValue(SelectionPopupStyleProperty);
            set => SetValue(SelectionPopupStyleProperty, value);
        }
    }
}
