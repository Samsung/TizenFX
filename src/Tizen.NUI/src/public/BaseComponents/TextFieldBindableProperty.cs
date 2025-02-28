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

using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField
    {
        /// <summary>
        /// StyleNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = null;
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.translatableText = (string)newValue;
            }
        }
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.translatableText;
        }

        /// <summary>
        /// StyleNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextProperty = null;
        internal static void SetInternalTranslatablePlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.translatablePlaceholderText = (string)newValue;
            }
        }
        internal static object GetInternalTranslatablePlaceholderTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.translatablePlaceholderText;
        }

        /// <summary>
        /// TranslatablePlaceholderTextFocused property
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextFocusedProperty = null;
        internal static void SetInternalTranslatablePlaceholderTextFocusedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.translatablePlaceholderTextFocused = (string)newValue;
            }
        }
        internal static object GetInternalTranslatablePlaceholderTextFocusedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.translatablePlaceholderTextFocused;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalText((string)newValue);
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalText();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = null;
        internal static void SetInternalPlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPlaceholderText((string)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPlaceholderText();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = null;
        internal static void SetInternalPlaceholderTextFocusedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPlaceholderTextFocused((string)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextFocusedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPlaceholderTextFocused();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.InternalFontFamily = (string)newValue;
            }
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.InternalFontFamily;
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalFontStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalFontStyle();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPointSize((float)newValue);
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPointSize();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = null;
        internal static void SetInternalMaxLengthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalMaxLength((int)newValue);
            }
        }
        internal static object GetInternalMaxLengthProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalMaxLength();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = null;
        internal static void SetInternalExceedPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalExceedPolicy((int)newValue);
            }
        }
        internal static object GetInternalExceedPolicyProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalExceedPolicy();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalHorizontalAlignment((HorizontalAlignment)newValue);
            }
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalHorizontalAlignment();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalVerticalAlignment((VerticalAlignment)newValue);
            }
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalVerticalAlignment();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalTextColor((Color)newValue);
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalTextColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = null;
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPlaceholderTextColor((Vector4)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPlaceholderTextColor();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = null;
        internal static void SetInternalEnableGrabHandleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableGrabHandle((bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableGrabHandle();
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = null;
        internal static void SetInternalEnableGrabHandlePopupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableGrabHandlePopup((bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandlePopupProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableGrabHandlePopup();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = null;
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPrimaryCursorColor((Vector4)newValue);
            }
        }
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPrimaryCursorColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = null;
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSecondaryCursorColor((Vector4)newValue);
            }
        }
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSecondaryCursorColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = null;
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableCursorBlink((bool)newValue);
            }
        }
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableCursorBlink();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = null;
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalCursorBlinkInterval((float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalCursorBlinkInterval();
        }
        
        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = null;
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalCursorBlinkDuration((float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalCursorBlinkDuration();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = null;
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalCursorWidth((int)newValue);
            }
        }
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalCursorWidth();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = null;
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalGrabHandleImage((string)newValue);
            }
        }
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalGrabHandleImage();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = null;
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalGrabHandlePressedImage((string)newValue);
            }
        }
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalGrabHandlePressedImage();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = null;
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalScrollThreshold((float)newValue);
            }
        }
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalScrollThreshold();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = null;
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalScrollSpeed((float)newValue);
            }
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalScrollSpeed();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionPopupStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionPopupStyle();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandleImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandleImageLeft();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = null;
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandleImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandleImageRight();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = null;
        internal static void SetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandlePressedImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandlePressedImageLeft();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = null;
        internal static void SetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandlePressedImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandlePressedImageRight();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = null;
        internal static void SetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandleMarkerImageLeft((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandleMarkerImageLeft();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = null;
        internal static void SetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHandleMarkerImageRight((PropertyMap)newValue);
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHandleMarkerImageRight();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = null;
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalSelectionHighlightColor((Vector4)newValue);
            }
        }
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalSelectionHighlightColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = null;
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalDecorationBoundingBox((Rectangle)newValue);
            }
        }
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalDecorationBoundingBox();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = null;
        internal static void SetInternalInputMethodSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputMethodSettings((PropertyMap)newValue);
            }
        }
        internal static object GetInternalInputMethodSettingsProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputMethodSettings();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = null;
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputColor((Vector4)newValue);
            }
        }
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputColor();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableMarkup((bool)newValue);
            }
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableMarkup();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = null;
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputFontFamily((string)newValue);
            }
        }
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputFontFamily();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = null;
        internal static void SetInternalInputFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputFontStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalInputFontStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputFontStyle();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = null;
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputPointSize((float)newValue);
            }
        }
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputPointSize();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalUnderline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalUnderline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = null;
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputUnderline((string)newValue);
            }
        }
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputUnderline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalShadow((PropertyMap)newValue);
            }
        }
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalShadow();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = null;
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputShadow((string)newValue);
            }
        }
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputShadow();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEmboss((string)newValue);
            }
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEmboss();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = null;
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputEmboss((string)newValue);
            }
        }
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputEmboss();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalOutline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalOutline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = null;
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalInputOutline((string)newValue);
            }
        }
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalInputOutline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HiddenInputSettingsProperty = null;
        internal static void SetInternalHiddenInputSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalHiddenInputSettings((PropertyMap)newValue);
            }
        }
        internal static object GetInternalHiddenInputSettingsProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalHiddenInputSettings();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPixelSize((float)newValue);
            }
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPixelSize();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableSelection((bool)newValue);
            }
        }
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableSelection();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = null;
        internal static void SetInternalPlaceholderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalPlaceholder((PropertyMap)newValue);
            }
        }
        internal static object GetInternalPlaceholderProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalPlaceholder();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEllipsis((bool)newValue);
            }
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEllipsis();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEllipsisPosition((EllipsisPosition)newValue);
            }
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEllipsisPosition();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = null;
        internal static void SetInternalEnableShiftSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableShiftSelection((bool)newValue);
            }
        }
        internal static object GetInternalEnableShiftSelectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableShiftSelection();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalMatchSystemLanguageDirection((bool)newValue);
            }
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalMatchSystemLanguageDirection();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.InternalFontSizeScale = (float)newValue;
            }
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.InternalFontSizeScale;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = null;
        internal static void SetInternalEnableFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalEnableFontSizeScale((bool)newValue);
            }
        }
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalEnableFontSizeScale();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = null;
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalGrabHandleColor((Color)newValue);
            }
        }
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalGrabHandleColor();
        }

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = null;
        internal static void SetInternalShadowOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (TextField)bindable;
            if (newValue != null)
            {
                instance.InternalShadowOffset = (Vector2)newValue;
            }
        }
        internal static object GetInternalShadowOffsetProperty(BindableObject bindable)
        {
            var instance = (TextField)bindable;
            return instance.InternalShadowOffset;
        }

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = null;
        internal static void SetInternalShadowColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (TextField)bindable;
            if (newValue != null)
            {
                instance.InternalShadowColor = (Vector4)newValue;
            }
        }
        internal static object GetInternalShadowColorProperty(BindableObject bindable)
        {
            var instance = (TextField)bindable;
            return instance.InternalShadowColor;
        }

        /// <summary>
        /// EnableEditingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableEditingProperty = null;
        internal static void SetInternalEnableEditingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (TextField)bindable;
            if (newValue != null)
            {
                instance.InternalEnableEditing = (bool)newValue;
            }
        }
        internal static object GetInternalEnableEditingProperty(BindableObject bindable)
        {
            var instance = (TextField)bindable;
            return instance.InternalEnableEditing;
        }

        /// <summary>
        /// PrimaryCursorPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorPositionProperty = null;
        internal static void SetInternalPrimaryCursorPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (TextField)bindable;
            if (newValue != null)
            {
                instance.InternalPrimaryCursorPosition = (int)newValue;
            }
        }
        internal static object GetInternalPrimaryCursorPositionProperty(BindableObject bindable)
        {
            var instance = (TextField)bindable;
            return instance.InternalPrimaryCursorPosition;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textField = (TextField)bindable;
                textField.SetInternalCharacterSpacing((float)newValue);
            }
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalCharacterSpacing();
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
                var textField = (TextField)bindable;
                textField.SetInternalRemoveFrontInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalRemoveFrontInset();
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
                var textField = (TextField)bindable;
                textField.SetInternalRemoveBackInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.GetInternalRemoveBackInset();
        }
    }
}
