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
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextEditor
    {
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalText((string)newValue);
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalText();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalTextColor((Vector4)newValue);
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalTextColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.InternalFontFamily = (string)newValue;
            }
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.InternalFontFamily;
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalFontStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalFontStyle();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalPointSize((float)newValue);
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPointSize();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalHorizontalAlignment((HorizontalAlignment)newValue);
            }
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalHorizontalAlignment();
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalVerticalAlignment((VerticalAlignment)newValue);
            }
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalVerticalAlignment();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = null;
        
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalScrollThreshold((float)newValue);
            }
        }
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalScrollThreshold();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = null;
        
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalScrollSpeed((float)newValue);
            }
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalScrollSpeed();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = null;
        
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalPrimaryCursorColor((Vector4)newValue);
            }
        }
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPrimaryCursorColor();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = null;
        
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSecondaryCursorColor((Vector4)newValue);
            }
        }
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSecondaryCursorColor();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = null;
        
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableCursorBlink((bool)newValue);
            }
        }
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableCursorBlink();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = null;
        
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalCursorBlinkInterval((float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalCursorBlinkInterval();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = null;
        
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalCursorBlinkDuration((float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalCursorBlinkDuration();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = null;
        
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalCursorWidth((int)newValue);
            }
        }
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalCursorWidth();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = null;
        
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalGrabHandleImage((string)newValue);
            }
        }
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalGrabHandleImage();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = null;
        
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalGrabHandlePressedImage((string)newValue);
            }
        }
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalGrabHandlePressedImage();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionPopupStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionPopupStyle();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandleImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandleImageLeft();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = null;
        
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandleImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandleImageRight();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandlePressedImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandlePressedImageLeft();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = null;
        
        internal static void SetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandlePressedImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandlePressedImageRight();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandleMarkerImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandleMarkerImageLeft();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = null;
        
        internal static void SetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHandleMarkerImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHandleMarkerImageRight();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = null;
        
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSelectionHighlightColor((Vector4)newValue);
            }
        }
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSelectionHighlightColor();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = null;
        
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalDecorationBoundingBox((Rectangle)newValue);
            }
        }
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalDecorationBoundingBox();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableMarkup((bool)newValue);
            }
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableMarkup();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = null;
        
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputColor((Vector4)newValue);
            }
        }
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputColor();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = null;
        
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputFontFamily((string)newValue);
            }
        }
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputFontFamily();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = null;
        
        internal static void SetInternalInputFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputFontStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalInputFontStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputFontStyle();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = null;
        
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputPointSize((float)newValue);
            }
        }
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputPointSize();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalLineSpacing((float)newValue);
            }
        }
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalLineSpacing();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputLineSpacingProperty = null;
        
        internal static void SetInternalInputLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.SetInternalInputLineSpacing((float)newValue);
            }
        }
        internal static object GetInternalInputLineSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputLineSpacing();
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalRelativeLineHeight((float)newValue);
            }
        }
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalRelativeLineHeight();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalUnderline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalUnderline();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = null;
        
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputUnderline((string)newValue);
            }
        }
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputUnderline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalShadow((PropertyMap)newValue);
            }
        }
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalShadow();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = null;
        
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputShadow((string)newValue);
            }
        }
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputShadow();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEmboss((string)newValue);
            }
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEmboss();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = null;
        
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputEmboss((string)newValue);
            }
        }
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputEmboss();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalOutline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalOutline();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = null;
        
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputOutline((string)newValue);
            }
        }
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputOutline();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollProperty = null;
        
        internal static void SetInternalSmoothScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSmoothScroll((bool)newValue);
            }
        }
        internal static object GetInternalSmoothScrollProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSmoothScroll();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollDurationProperty = null;
        
        internal static void SetInternalSmoothScrollDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalSmoothScrollDuration((float)newValue);
            }
        }
        internal static object GetInternalSmoothScrollDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalSmoothScrollDuration();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrollBarProperty = null;
        
        internal static void SetInternalEnableScrollBarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableScrollBar((bool)newValue);
            }
        }
        internal static object GetInternalEnableScrollBarProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableScrollBar();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarShowDurationProperty = null;
        
        internal static void SetInternalScrollBarShowDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.SetInternalScrollBarShowDuration((float)newValue);
            }
        }
        internal static object GetInternalScrollBarShowDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalScrollBarShowDuration();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarFadeDurationProperty = null;
        
        internal static void SetInternalScrollBarFadeDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalScrollBarFadeDuration((float)newValue);
            }
        }
        internal static object GetInternalScrollBarFadeDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalScrollBarFadeDuration();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalPixelSize((float)newValue);
            }
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPixelSize();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = null;
        
        internal static void SetInternalPlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.SetInternalPlaceholderText((string)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPlaceholderText();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = null;
        
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalPlaceholderTextColor((Color)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPlaceholderTextColor();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableSelection((bool)newValue);
            }
        }
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableSelection();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = null;
        
        internal static void SetInternalPlaceholderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalPlaceholder((PropertyMap)newValue);
            }
        }
        internal static object GetInternalPlaceholderProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalPlaceholder();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalLineWrapMode((LineWrapMode)newValue);
            }
        }
        internal static object GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalLineWrapMode();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = null;
        
        internal static void SetInternalEnableShiftSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableShiftSelection((bool)newValue);
            }
        }
        internal static object GetInternalEnableShiftSelectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableShiftSelection();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalMatchSystemLanguageDirection((bool)newValue);
            }
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalMatchSystemLanguageDirection();
        }
        
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = null;
        
        internal static void SetInternalMaxLengthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalMaxLength((int)newValue);
            }
        }
        internal static object GetInternalMaxLengthProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalMaxLength();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.InternalFontSizeScale = (float)newValue;
            }
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.InternalFontSizeScale;
        }
        

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = null;
        
        internal static void SetInternalEnableFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableFontSizeScale((bool)newValue);
            }
        }
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableFontSizeScale();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = null;
        
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalGrabHandleColor((Color)newValue);
            }
        }
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalGrabHandleColor();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = null;
        
        internal static void SetInternalEnableGrabHandleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableGrabHandle((bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableGrabHandle();
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = null;
        
        internal static void SetInternalEnableGrabHandlePopupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEnableGrabHandlePopup((bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandlePopupProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEnableGrabHandlePopup();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = null;
        
        internal static void SetInternalInputMethodSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalInputMethodSettings((PropertyMap)newValue);
            }
        }
        internal static object GetInternalInputMethodSettingsProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalInputMethodSettings();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEllipsis((bool)newValue);
            }
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEllipsis();
        }
        
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalEllipsisPosition((EllipsisPosition)newValue);
            }
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalEllipsisPosition();
        }

        /// currently need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalMinLineSize((float)newValue);
            }
        }
        internal static object GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalMinLineSize();
        }

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = null;
        
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalTranslatableText = (string)newValue;
            }
        }
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalTranslatableText;
        }

        /// <summary>
        /// TranslatablePlaceholderTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextProperty = null;
        
        internal static void SetInternalTranslatablePlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalTranslatablePlaceholderText = (string)newValue;
            }
        }
        internal static object GetInternalTranslatablePlaceholderTextProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalTranslatablePlaceholderText;
        }

        /// <summary>
        /// EnableEditingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableEditingProperty = null;
        
        internal static void SetInternalEnableEditingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalEnableEditing = (bool)newValue;
            }
        }
        internal static object GetInternalEnableEditingProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalEnableEditing;
        }

        /// <summary>
        /// HorizontalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalScrollPositionProperty = null;
        
        internal static void SetInternalHorizontalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalHorizontalScrollPosition = (int)newValue;
            }
        }
        internal static object GetInternalHorizontalScrollPositionProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalHorizontalScrollPosition;
        }

        /// <summary>
        /// VerticalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalScrollPositionProperty = null;
        
        internal static void SetInternalVerticalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalVerticalScrollPosition = (int)newValue;
            }
        }
        internal static object GetInternalVerticalScrollPositionProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalVerticalScrollPosition;
        }

        /// <summary>
        /// PrimaryCursorPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorPositionProperty = null;
        
        internal static void SetInternalPrimaryCursorPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextEditor)bindable;
                instance.InternalPrimaryCursorPosition = (int)newValue;
            }
        }
        internal static object GetInternalPrimaryCursorPositionProperty(BindableObject bindable)
        {
            var instance = (TextEditor)bindable;
            return instance.InternalPrimaryCursorPosition;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalCharacterSpacing((float)newValue);
            }
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalCharacterSpacing();
        }

        /// <summary>
        /// RemoveFrontInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveFrontInsetProperty = null;
        internal static void SetInternalRemoveFrontInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalRemoveFrontInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalRemoveFrontInset();
        }

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = null;
        internal static void SetInternalRemoveBackInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textEditor = (TextEditor)bindable;
                textEditor.SetInternalRemoveBackInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.GetInternalRemoveBackInset();
        }

        /// <summary>
        /// FontVariationsProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontVariationsProperty = null;
        internal static void SetInternalFontVariationsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontVariations, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalFontVariationsProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            PropertyMap temp = new PropertyMap();
            return Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontVariations).Get(temp);
        }
    }
}
