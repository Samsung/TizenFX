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
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextFieldStyle : ViewStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.fontFamily = (string)newValue;
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontFamily;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.pointSize = (float?)newValue;
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.pointSize;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.fontSizeScale = (float?)newValue;
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontSizeScale;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.textColor = (Color)newValue;
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.textColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = null;
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderTextColor = (Vector4)newValue;
        }
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = null;
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.primaryCursorColor = (Vector4)newValue;
        }
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.primaryCursorColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = null;
        internal static void SetInternalPlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderText = (string)newValue;
        }
        internal static object GetInternalPlaceholderTextProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderText;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = null;
        internal static void SetInternalPlaceholderTextFocusedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderTextFocused = (string)newValue;
        }
        internal static object GetInternalPlaceholderTextFocusedProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextFocused;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = null;
        internal static void SetInternalMaxLengthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.maxLength = (int?)newValue;
        }
        internal static object GetInternalMaxLengthProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.maxLength;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = null;
        internal static void SetInternalExceedPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.exceedPolicy = (int?)newValue;
        }
        internal static object GetInternalExceedPolicyProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.exceedPolicy;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.horizontalAlignment = (HorizontalAlignment?)newValue;
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.horizontalAlignment;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.verticalAlignment = (VerticalAlignment?)newValue;
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.verticalAlignment;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = null;
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.secondaryCursorColor = (Vector4)newValue;
        }
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.secondaryCursorColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = null;
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableCursorBlink = (bool?)newValue;
        }
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableCursorBlink;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = null;
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorBlinkInterval = (float?)newValue;
        }
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorBlinkInterval;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = null;
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorBlinkDuration = (float?)newValue;
        }
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorBlinkDuration;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = null;
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorWidth = (int?)newValue;
        }
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorWidth;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = null;
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandleColor = (Color)newValue;
        }
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandleColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = null;
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandleImage = (string)newValue;
        }
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandleImage;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = null;
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandlePressedImage = (string)newValue;
        }
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandlePressedImage;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHandleImageLeft = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHandleImageLeft;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = null;
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHandleImageRight = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHandleImageRight;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = null;
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.scrollThreshold = (float?)newValue;
        }
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.scrollThreshold;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = null;
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.scrollSpeed = (float?)newValue;
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.scrollSpeed;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = null;
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHighlightColor = (Vector4)newValue;
        }
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHighlightColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = null;
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.decorationBoundingBox = (Rectangle)newValue;
        }
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.decorationBoundingBox;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = null;
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputColor = (Vector4)newValue;
        }
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableMarkup = (bool?)newValue;
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableMarkup;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = null;
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputFontFamily = (string)newValue;
        }
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputFontFamily;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = null;
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputPointSize = (float?)newValue;
        }
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputPointSize;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = null;
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputUnderline = (string)newValue;
        }
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputUnderline;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = null;
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputShadow = (string)newValue;
        }
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputShadow;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.emboss = (string)newValue;
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.emboss;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = null;
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputEmboss = (string)newValue;
        }
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputEmboss;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = null;
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputOutline = (string)newValue;
        }
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputOutline;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.pixelSize = (float?)newValue;
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.pixelSize;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableSelection = (bool?)newValue;
        }
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableSelection;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.ellipsis = (bool?)newValue;
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.ellipsis;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.matchSystemLanguageDirection = (bool?)newValue;
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.matchSystemLanguageDirection;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.fontStyle = (PropertyMap)newValue;
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontStyle;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionPopupStyle = (PropertyMap)newValue;
        }
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionPopupStyle;
        }

        private string placeholderText;
        private string placeholderTextFocused;
        private int? maxLength;
        private int? exceedPolicy;
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
        private bool? enableMarkup;
        private string inputFontFamily;
        private float? inputPointSize;
        private string inputUnderline;
        private string inputShadow;
        private string emboss;
        private string inputEmboss;
        private string inputOutline;
        private float? pixelSize;
        private bool? enableSelection;
        private bool? ellipsis;
        private bool? matchSystemLanguageDirection;
        private string fontFamily;
        private Color textColor;
        private float? pointSize;
        private float? fontSizeScale;
        private Vector4 placeholderTextColor;
        private Vector4 primaryCursorColor;
        private PropertyMap fontStyle;
        private PropertyMap selectionPopupStyle;

        static TextFieldStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalFontFamilyProperty, defaultValueCreator: GetInternalFontFamilyProperty);
                PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalPointSizeProperty, defaultValueCreator: GetInternalPointSizeProperty);
                FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalFontSizeScaleProperty, defaultValueCreator: GetInternalFontSizeScaleProperty);
                TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalTextColorProperty, defaultValueCreator: GetInternalTextColorProperty);
                PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Vector4), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalPlaceholderTextColorProperty, defaultValueCreator: GetInternalPlaceholderTextColorProperty);
                PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalPrimaryCursorColorProperty, defaultValueCreator: GetInternalPrimaryCursorColorProperty);
                PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalPlaceholderTextProperty, defaultValueCreator: GetInternalPlaceholderTextProperty);
                PlaceholderTextFocusedProperty = BindableProperty.Create(nameof(PlaceholderTextFocused), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalPlaceholderTextFocusedProperty, defaultValueCreator: GetInternalPlaceholderTextFocusedProperty);
                MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalMaxLengthProperty, defaultValueCreator: GetInternalMaxLengthProperty);
                ExceedPolicyProperty = BindableProperty.Create(nameof(ExceedPolicy), typeof(int?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalExceedPolicyProperty, defaultValueCreator: GetInternalExceedPolicyProperty);
                HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalHorizontalAlignmentProperty, defaultValueCreator: GetInternalHorizontalAlignmentProperty);
                VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalVerticalAlignmentProperty, defaultValueCreator: GetInternalVerticalAlignmentProperty);
                SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalSecondaryCursorColorProperty, defaultValueCreator: GetInternalSecondaryCursorColorProperty);
                EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalEnableCursorBlinkProperty, defaultValueCreator: GetInternalEnableCursorBlinkProperty);
                CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalCursorBlinkIntervalProperty, defaultValueCreator: GetInternalCursorBlinkIntervalProperty);
                CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalCursorBlinkDurationProperty, defaultValueCreator: GetInternalCursorBlinkDurationProperty);
                CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalCursorWidthProperty, defaultValueCreator: GetInternalCursorWidthProperty);
                GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalGrabHandleColorProperty, defaultValueCreator: GetInternalGrabHandleColorProperty);
                GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalGrabHandleImageProperty, defaultValueCreator: GetInternalGrabHandleImageProperty);
                GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalGrabHandlePressedImageProperty, defaultValueCreator: GetInternalGrabHandlePressedImageProperty);
                SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalSelectionHandleImageLeftProperty, defaultValueCreator: GetInternalSelectionHandleImageLeftProperty);
                SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalSelectionHandleImageRightProperty, defaultValueCreator: GetInternalSelectionHandleImageRightProperty);
                ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalScrollThresholdProperty, defaultValueCreator: GetInternalScrollThresholdProperty);
                ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalScrollSpeedProperty, defaultValueCreator: GetInternalScrollSpeedProperty);
                SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalSelectionHighlightColorProperty, defaultValueCreator: GetInternalSelectionHighlightColorProperty);
                DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalDecorationBoundingBoxProperty, defaultValueCreator: GetInternalDecorationBoundingBoxProperty);
                InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalInputColorProperty, defaultValueCreator: GetInternalInputColorProperty);
                EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalEnableMarkupProperty, defaultValueCreator: GetInternalEnableMarkupProperty);
                InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalInputFontFamilyProperty, defaultValueCreator: GetInternalInputFontFamilyProperty);
                InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalInputPointSizeProperty, defaultValueCreator: GetInternalInputPointSizeProperty);
                InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalInputUnderlineProperty, defaultValueCreator: GetInternalInputUnderlineProperty);
                InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalInputShadowProperty, defaultValueCreator: GetInternalInputShadowProperty);
                EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalEmbossProperty, defaultValueCreator: GetInternalEmbossProperty);
                InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalInputEmbossProperty, defaultValueCreator: GetInternalInputEmbossProperty);
                InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextFieldStyle), String.Empty,
                    propertyChanged: SetInternalInputOutlineProperty, defaultValueCreator: GetInternalInputOutlineProperty);
                PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalPixelSizeProperty, defaultValueCreator: GetInternalPixelSizeProperty);
                EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalEnableSelectionProperty, defaultValueCreator: GetInternalEnableSelectionProperty);
                EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalEllipsisProperty, defaultValueCreator: GetInternalEllipsisProperty);
                MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalMatchSystemLanguageDirectionProperty, defaultValueCreator: GetInternalMatchSystemLanguageDirectionProperty);
                FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalFontStyleProperty, defaultValueCreator: GetInternalFontStyleProperty);
                SelectionPopupStyleProperty = BindableProperty.Create(nameof(SelectionPopupStyle), typeof(PropertyMap), typeof(TextFieldStyle), null,
                    propertyChanged: SetInternalSelectionPopupStyleProperty, defaultValueCreator: GetInternalSelectionPopupStyleProperty);
            }
        }

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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(PlaceholderTextProperty);
                }
                else
                {
                    return (string)GetInternalPlaceholderTextProperty(this);
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
                    SetInternalPlaceholderTextProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderTextFocused
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(PlaceholderTextFocusedProperty);
                }
                else
                {
                    return (string)GetInternalPlaceholderTextFocusedProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PlaceholderTextFocusedProperty, value);
                }
                else
                {
                    SetInternalPlaceholderTextFocusedProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? MaxLength
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int?)GetValue(MaxLengthProperty);
                }
                else
                {
                    return (int?)GetInternalMaxLengthProperty(this);
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
                    SetInternalMaxLengthProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ExceedPolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int?)GetValue(ExceedPolicyProperty);
                }
                else
                {
                    return (int?)GetInternalExceedPolicyProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ExceedPolicyProperty, value);
                }
                else
                {
                    SetInternalExceedPolicyProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalSecondaryCursorColorProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalEnableCursorBlinkProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalCursorBlinkIntervalProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalCursorBlinkDurationProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalCursorWidthProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalGrabHandleColorProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalGrabHandleImageProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalGrabHandlePressedImageProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalSelectionHandleImageLeftProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
                    SetInternalSelectionHandleImageRightProperty(this,null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableMarkupProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableMarkupProperty(this);
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
                    SetInternalEnableMarkupProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(TextColorProperty);
                }
                else
                {
                    return (Color)GetInternalTextColorProperty(this);
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PlaceholderTextColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Vector4)GetValue(PlaceholderTextColorProperty);
                }
                else
                {
                    return (Vector4)GetInternalPlaceholderTextColorProperty(this);
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
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
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
