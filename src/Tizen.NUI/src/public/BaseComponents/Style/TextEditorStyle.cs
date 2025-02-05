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
        /// <summary> The bindable property of FontFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).fontFamily = (string)newValue;
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).fontFamily;
        }

        /// <summary> The bindable property of PointSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).pointSize = (float?)newValue;
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).pointSize;
        }

        /// <summary> The bindable property of PixelSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).pixelSize = (float?)newValue;
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).pixelSize;
        }

        /// <summary> The bindable property of TextColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).textColor = (Vector4)newValue;
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).textColor;
        }

        /// <summary> The bindable property of PlaceholderTextColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PlaceholderTextColorProperty = null;
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).placeholderTextColor = (Color)newValue;
        }
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).placeholderTextColor;
        }

        /// <summary> The bindable property of PrimaryCursorColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty PrimaryCursorColorProperty = null;
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).primaryCursorColor = (Vector4)newValue;
        }
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).primaryCursorColor;
        }

        /// <summary> The bindable property of HorizontalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).horizontalAlignment = (HorizontalAlignment?)newValue;
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).horizontalAlignment;
        }

        /// <summary> The bindable property of VerticalAlignment. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).verticalAlignment = (VerticalAlignment?)newValue;
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).verticalAlignment;
        }

        /// <summary> The bindable property of SecondaryCursorColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SecondaryCursorColorProperty = null;
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).secondaryCursorColor = (Vector4)newValue;
        }
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).secondaryCursorColor;
        }

        /// <summary> The bindable property of EnableCursorBlink. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EnableCursorBlinkProperty = null;
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).enableCursorBlink = (bool?)newValue;
        }
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).enableCursorBlink;
        }

        /// <summary> The bindable property of CursorBlinkInterval. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty CursorBlinkIntervalProperty = null;
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).cursorBlinkInterval = (float?)newValue;
        }
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).cursorBlinkInterval;
        }

        /// <summary> The bindable property of CursorBlinkDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty CursorBlinkDurationProperty = null;
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).cursorBlinkDuration = (float?)newValue;
        }
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).cursorBlinkDuration;
        }

        /// <summary> The bindable property of CursorWidth. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty CursorWidthProperty = null;
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).cursorWidth = (int?)newValue;
        }
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).cursorWidth;
        }

        /// <summary> The bindable property of GrabHandleColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandleColorProperty = null;
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).grabHandleColor = (Color)newValue;
        }
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).grabHandleColor;
        }

        /// <summary> The bindable property of GrabHandleImage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandleImageProperty = null;
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).grabHandleImage = (string)newValue;
        }
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).grabHandleImage;
        }

        /// <summary> The bindable property of GrabHandlePressedImage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty GrabHandlePressedImageProperty = null;
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).grabHandlePressedImage = (string)newValue;
        }
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).grabHandlePressedImage;
        }

        /// <summary> The bindable property of SelectionHandleImageLeft. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).selectionHandleImageLeft = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).selectionHandleImageLeft;
        }

        /// <summary> The bindable property of SelectionHandleImageRight. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SelectionHandleImageRightProperty = null;
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).selectionHandleImageRight = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).selectionHandleImageRight;
        }

        /// <summary> The bindable property of ScrollThreshold. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollThresholdProperty = null;
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).scrollThreshold = (float?)newValue;
        }
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).scrollThreshold;
        }

        /// <summary> The bindable property of ScrollSpeed. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollSpeedProperty = null;
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).scrollSpeed = (float?)newValue;
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).scrollSpeed;
        }

        /// <summary> The bindable property of SelectionHighlightColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SelectionHighlightColorProperty = null;
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).selectionHighlightColor = (Vector4)newValue;
        }
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).selectionHighlightColor;
        }

        /// <summary> The bindable property of DecorationBoundingBox. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty DecorationBoundingBoxProperty = null;
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).decorationBoundingBox = (Rectangle)newValue;
        }
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).decorationBoundingBox;
        }

        /// <summary> The bindable property of InputColor. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputColorProperty = null;
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputColor = (Vector4)newValue;
        }
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputColor;
        }

        /// <summary> The bindable property of InputFontFamily. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputFontFamilyProperty = null;
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputFontFamily = (string)newValue;
        }
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputFontFamily;
        }

        /// <summary> The bindable property of InputPointSize. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputPointSizeProperty = null;
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputPointSize = (float?)newValue;
        }
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputPointSize;
        }

        /// <summary> The bindable property of InputUnderline. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputUnderlineProperty = null;
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputUnderline = (string)newValue;
        }
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputUnderline;
        }

        /// <summary> The bindable property of InputShadow. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputShadowProperty = null;
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputShadow = (string)newValue;
        }
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputShadow;
        }

        /// <summary> The bindable property of Emboss. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).emboss = (string)newValue;
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).emboss;
        }

        /// <summary> The bindable property of InputEmboss. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputEmbossProperty = null;
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputEmboss = (string)newValue;
        }
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputEmboss;
        }

        /// <summary> The bindable property of InputOutline. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty InputOutlineProperty = null;
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).inputOutline = (string)newValue;
        }
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).inputOutline;
        }

        /// <summary> The bindable property of SmoothScroll. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SmoothScrollProperty = null;
        internal static void SetInternalSmoothScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).smoothScroll = (bool?)newValue;
        }
        internal static object GetInternalSmoothScrollProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).smoothScroll;
        }

        /// <summary> The bindable property of SmoothScrollDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty SmoothScrollDurationProperty = null;
        internal static void SetInternalSmoothScrollDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).smoothScrollDuration = (float?)newValue;
        }
        internal static object GetInternalSmoothScrollDurationProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).smoothScrollDuration;
        }

        /// <summary> The bindable property of EnableScrollBar. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty EnableScrollBarProperty = null;
        internal static void SetInternalEnableScrollBarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).enableScrollBar = (bool?)newValue;
        }
        internal static object GetInternalEnableScrollBarProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).enableScrollBar;
        }

        /// <summary> The bindable property of ScrollBarShowDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollBarShowDurationProperty = null;
        internal static void SetInternalScrollBarShowDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).scrollBarShowDuration = (float?)newValue;
        }
        internal static object GetInternalScrollBarShowDurationProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).scrollBarShowDuration;
        }

        /// <summary> The bindable property of ScrollBarFadeDuration. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty ScrollBarFadeDurationProperty = null;
        internal static void SetInternalScrollBarFadeDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).scrollBarFadeDuration = (float?)newValue;
        }
        internal static object GetInternalScrollBarFadeDurationProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).scrollBarFadeDuration;
        }

        /// <summary> The bindable property of EnableSelection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).enableSelection = (bool?)newValue;
        }
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).enableSelection;
        }

        /// <summary> The bindable property of MatchSystemLanguageDirection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        internal static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).matchSystemLanguageDirection = (bool?)newValue;
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).matchSystemLanguageDirection;
        }

        /// <summary> The bindable property of FontStyleProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextEditorStyle)bindable).fontStyle = (PropertyMap)newValue;
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            return ((TextEditorStyle)bindable).fontStyle;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.ellipsis = (bool?)newValue;
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.ellipsis;
        }

        /// <summary> The bindable property of LineSpacingProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.lineSpacing = (float?)newValue;
        }
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.lineSpacing;
        }

        /// <summary> The bindable property of MinLineSizeProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.minLineSize = (float?)newValue;
        }
        internal static object GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.minLineSize;
        }

        /// <summary> The bindable property of RelativeLineHeightProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.relativeLineHeight = (float?)newValue;
        }
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.relativeLineHeight;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.fontSizeScale = (float?)newValue;
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.fontSizeScale;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            textEditorStyle.selectionPopupStyle = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textEditorStyle = (TextEditorStyle)bindable;
            return textEditorStyle.selectionPopupStyle;
        }

        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private Vector4 secondaryCursorColor;
        private bool? enableCursorBlink;
        private float? cursorBlinkInterval;
        private float? cursorBlinkDuration;
        private int? cursorWidth;
        private Color grabHandleColor;
        private string grabHandleImage;
        private string grabHandlePressedImage;
        private PropertyMap selectionHandleImageLeft;
        private PropertyMap selectionHandleImageRight;
        private float? scrollThreshold;
        private float? scrollSpeed;
        private Vector4 selectionHighlightColor;
        private Rectangle decorationBoundingBox;
        private Vector4 inputColor;
        private string inputFontFamily;
        private float? inputPointSize;
        private string inputUnderline;
        private string inputShadow;
        private string emboss;
        private string inputEmboss;
        private string inputOutline;
        private bool? smoothScroll;
        private float? smoothScrollDuration;
        private bool? enableScrollBar;
        private float? scrollBarShowDuration;
        private float? scrollBarFadeDuration;
        private float? pixelSize;
        private bool? enableSelection;
        private bool? matchSystemLanguageDirection;
        private string fontFamily;
        private Vector4 textColor;
        private float? pointSize;
        private Color placeholderTextColor;
        private Vector4 primaryCursorColor;
        private PropertyMap fontStyle;
        private PropertyMap selectionPopupStyle;
        private bool? ellipsis;
        private float? lineSpacing;
        private float? minLineSize;
        private float? relativeLineHeight;
        private float? fontSizeScale;

        static TextEditorStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);
                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);
                PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalPixelSizeProperty, defaultValueCreator: GetInternalPixelSizeProperty);
                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);
                PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalPlaceholderTextColorProperty, defaultValueCreator: GetInternalPlaceholderTextColorProperty);
                PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalPrimaryCursorColorProperty, defaultValueCreator: GetInternalPrimaryCursorColorProperty);
                HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalHorizontalAlignmentProperty, defaultValueCreator: GetInternalHorizontalAlignmentProperty);
                VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalVerticalAlignmentProperty, defaultValueCreator: GetInternalVerticalAlignmentProperty);
                SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSecondaryCursorColorProperty,defaultValueCreator: GetInternalSecondaryCursorColorProperty);
                EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalEnableCursorBlinkProperty, defaultValueCreator: GetInternalEnableCursorBlinkProperty);
                CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalCursorBlinkIntervalProperty, defaultValueCreator: GetInternalCursorBlinkIntervalProperty);
                CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalCursorBlinkDurationProperty, defaultValueCreator: GetInternalCursorBlinkDurationProperty);
                CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalCursorWidthProperty, defaultValueCreator: GetInternalCursorWidthProperty);
                GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalGrabHandleColorProperty, defaultValueCreator: GetInternalGrabHandleColorProperty);
                GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalGrabHandleImageProperty, defaultValueCreator: GetInternalGrabHandleImageProperty);
                GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalGrabHandlePressedImageProperty, defaultValueCreator: GetInternalGrabHandlePressedImageProperty);
                SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSelectionHandleImageLeftProperty, defaultValueCreator: GetInternalSelectionHandleImageLeftProperty);
                SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSelectionHandleImageRightProperty, defaultValueCreator: GetInternalSelectionHandleImageRightProperty);
                ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalScrollThresholdProperty, defaultValueCreator: GetInternalScrollThresholdProperty);
                ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalScrollSpeedProperty, defaultValueCreator: GetInternalScrollSpeedProperty);
                SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSelectionHighlightColorProperty, defaultValueCreator: GetInternalSelectionHighlightColorProperty);
                DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalDecorationBoundingBoxProperty, defaultValueCreator: GetInternalDecorationBoundingBoxProperty);
                InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalInputColorProperty, defaultValueCreator: GetInternalInputColorProperty);
                InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalInputFontFamilyProperty, defaultValueCreator: GetInternalInputFontFamilyProperty);
                InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalInputPointSizeProperty, defaultValueCreator: GetInternalInputPointSizeProperty);
                InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalInputUnderlineProperty, defaultValueCreator: GetInternalInputUnderlineProperty);
                InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalInputShadowProperty, defaultValueCreator: GetInternalInputShadowProperty);
                EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalEmbossProperty, defaultValueCreator: GetInternalEmbossProperty);
                InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalInputEmbossProperty, defaultValueCreator: GetInternalInputEmbossProperty);
                InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditorStyle), String.Empty,
                    propertyChanged: SetInternalInputOutlineProperty, defaultValueCreator: GetInternalInputOutlineProperty);
                SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSmoothScrollProperty, defaultValueCreator: GetInternalSmoothScrollProperty);
                SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSmoothScrollDurationProperty, defaultValueCreator: GetInternalSmoothScrollDurationProperty);
                EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalEnableScrollBarProperty, defaultValueCreator: GetInternalEnableScrollBarProperty);
                ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalScrollBarShowDurationProperty, defaultValueCreator: GetInternalScrollBarShowDurationProperty);
                ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalScrollBarFadeDurationProperty, defaultValueCreator: GetInternalScrollBarFadeDurationProperty);
                EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalEnableSelectionProperty, defaultValueCreator: GetInternalEnableSelectionProperty);
                MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalMatchSystemLanguageDirectionProperty, defaultValueCreator: GetInternalMatchSystemLanguageDirectionProperty);
                FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalFontStyleProperty, defaultValueCreator: GetInternalFontStyleProperty);
                EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalEllipsisProperty, defaultValueCreator: GetInternalEllipsisProperty);
                LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalLineSpacingProperty, defaultValueCreator: GetInternalLineSpacingProperty);
                MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalMinLineSizeProperty, defaultValueCreator: GetInternalMinLineSizeProperty);
                RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalRelativeLineHeightProperty, defaultValueCreator: GetInternalRelativeLineHeightProperty);
                FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float?), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalFontSizeScaleProperty, defaultValueCreator: GetInternalFontSizeScaleProperty);
                SelectionPopupStyleProperty = BindableProperty.Create(nameof(SelectionPopupStyle), typeof(PropertyMap), typeof(TextEditorStyle), null,
                    propertyChanged: SetInternalSelectionPopupStyleProperty, defaultValueCreator: GetInternalSelectionPopupStyleProperty);
            }
        }

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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(FontFamilyProperty);
                }
                else
                {
                    return (string)GetInternalFontFamilyProperty(this);
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
                    SetInternalFontFamilyProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
                }
                else
                {
                    return (HorizontalAlignment?)GetInternalHorizontalAlignmentProperty(this);
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
                    SetInternalHorizontalAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
                }
                else
                {
                    return (VerticalAlignment?)GetInternalVerticalAlignmentProperty(this);
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
                    SetInternalVerticalAlignmentProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(SecondaryCursorColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalSecondaryCursorColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SecondaryCursorColorProperty, value);
                }
                else
                {
                    SetInternalSecondaryCursorColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableCursorBlinkProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableCursorBlinkProperty(this);
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
                    SetInternalEnableCursorBlinkProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(CursorBlinkIntervalProperty);
                }
                else
                {
                    return (float?)GetInternalCursorBlinkIntervalProperty(this);
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
                    SetInternalCursorBlinkIntervalProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(CursorBlinkDurationProperty);
                }
                else
                {
                    return (float?)GetInternalCursorBlinkDurationProperty(this);
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
                    SetInternalCursorBlinkDurationProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int?)GetValue(CursorWidthProperty);
                }
                else
                {
                    return (int?)GetInternalCursorWidthProperty(this);
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
                    SetInternalCursorWidthProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The GrabHandleColor property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(GrabHandleColorProperty);
                }
                else
                {
                    return (Color)GetInternalGrabHandleColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(GrabHandleColorProperty, value);
                }
                else
                {
                    SetInternalGrabHandleColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalGrabHandleImageProperty(this);
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
                    SetInternalGrabHandleImageProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalGrabHandlePressedImageProperty(this);
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
                    SetInternalGrabHandlePressedImageProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (PropertyMap)GetInternalSelectionHandleImageLeftProperty(this);
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
                    SetInternalSelectionHandleImageLeftProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (PropertyMap)GetInternalSelectionHandleImageRightProperty(this);
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
                    SetInternalSelectionHandleImageRightProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(ScrollThresholdProperty);
                }
                else
                {
                    return (float?)GetInternalScrollThresholdProperty(this);
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
                    SetInternalScrollThresholdProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(ScrollSpeedProperty);
                }
                else
                {
                    return (float?)GetInternalScrollSpeedProperty(this);
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
                    SetInternalScrollSpeedProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(SelectionHighlightColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalSelectionHighlightColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(SelectionHighlightColorProperty, value);
                }
                else
                {
                    SetInternalSelectionHighlightColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Rectangle)GetValue(DecorationBoundingBoxProperty);
                }
                else
                {
                    return (Rectangle)GetInternalDecorationBoundingBoxProperty(this);
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
                    SetInternalDecorationBoundingBoxProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(InputColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalInputColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(InputColorProperty, value);
                }
                else
                {
                    SetInternalInputColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalInputFontFamilyProperty(this);
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
                    SetInternalInputFontFamilyProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(InputPointSizeProperty);
                }
                else
                {
                    return (float?)GetInternalInputPointSizeProperty(this);
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
                    SetInternalInputPointSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalInputUnderlineProperty(this);
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
                    SetInternalInputUnderlineProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalInputShadowProperty(this);
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
                    SetInternalInputShadowProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalEmbossProperty(this);
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
                    SetInternalEmbossProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalInputEmbossProperty(this);
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
                    SetInternalInputEmbossProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (string)GetInternalInputOutlineProperty(this);
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
                    SetInternalInputOutlineProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SmoothScroll property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? SmoothScroll
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(SmoothScrollProperty);
                }
                else
                {
                    return (bool?)GetInternalSmoothScrollProperty(this);
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
                    SetInternalSmoothScrollProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? SmoothScrollDuration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(SmoothScrollDurationProperty);
                }
                else
                {
                    return (float?)GetInternalSmoothScrollDurationProperty(this);
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
                    SetInternalSmoothScrollDurationProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableScrollBar
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableScrollBarProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableScrollBarProperty(this);
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
                    SetInternalEnableScrollBarProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarShowDuration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(ScrollBarShowDurationProperty);
                }
                else
                {
                    return (float?)GetInternalScrollBarShowDurationProperty(this);
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
                    SetInternalScrollBarShowDurationProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollBarFadeDuration
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(ScrollBarFadeDurationProperty);
                }
                else
                {
                    return (float?)GetInternalScrollBarFadeDurationProperty(this);
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
                    SetInternalScrollBarFadeDurationProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(PixelSizeProperty);
                }
                else
                {
                    return (float?)GetInternalPixelSizeProperty(this);
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
                    SetInternalPixelSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The EnableSelection property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableSelectionProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableSelectionProperty(this);
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
                    SetInternalEnableSelectionProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(MatchSystemLanguageDirectionProperty);
                }
                else
                {
                    return (bool?)GetInternalMatchSystemLanguageDirectionProperty(this);
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
                    SetInternalMatchSystemLanguageDirectionProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The TextColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 TextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(TextColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalTextColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorProperty, value);
                }
                else
                {
                    SetInternalTextColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(PointSizeProperty);
                }
                else
                {
                    return (float?)GetInternalPointSizeProperty(this);
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
                    SetInternalPointSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The Placeholder text color.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color PlaceholderTextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(PlaceholderTextColorProperty);
                }
                else
                {
                    return (Color)GetInternalPlaceholderTextColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderTextColorProperty, value);
                }
                else
                {
                    SetInternalPlaceholderTextColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// Note that the cascade chaining set is impossible. Please set a whole value.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PrimaryCursorColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(PrimaryCursorColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalPrimaryCursorColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PrimaryCursorColorProperty, value);
                }
                else
                {
                    SetInternalPrimaryCursorColorProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                    return (PropertyMap)GetInternalFontStyleProperty(this);
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
                    SetInternalFontStyleProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EllipsisProperty);
                }
                else
                {
                    return (bool?)GetInternalEllipsisProperty(this);
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
                    SetInternalEllipsisProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// the line spacing to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(LineSpacingProperty);
                }
                else
                {
                    return (float?)GetInternalLineSpacingProperty(this);
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
                    SetInternalLineSpacingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// the minimum line size to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MinLineSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(MinLineSizeProperty);
                }
                else
                {
                    return (float?)GetInternalMinLineSizeProperty(this);
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
                    SetInternalMinLineSizeProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// the relative line height to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RelativeLineHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(RelativeLineHeightProperty);
                }
                else
                {
                    return (float?)GetInternalRelativeLineHeightProperty(this);
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
                    SetInternalRelativeLineHeightProperty(this, null, value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(FontSizeScaleProperty);
                }
                else
                {
                    return (float?)GetInternalFontSizeScaleProperty(this);
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
                    SetInternalFontSizeScaleProperty(this, null, value);
                }
            }
        }

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
                    return (PropertyMap)GetInternalSelectionPopupStyleProperty(this);
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
                    SetInternalSelectionPopupStyleProperty(this, null, value);
                }
            }
        }
    }
}
