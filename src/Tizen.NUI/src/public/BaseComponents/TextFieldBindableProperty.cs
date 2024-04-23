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
            var textField = (TextField)bindable;
            if (newValue != null)
            {
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
            var textField = (TextField)bindable;
            if (newValue != null)
            {
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
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.translatablePlaceholderTextFocused = (string)newValue;
            }
        }
        internal static object GetInternalTranslatablePlaceholderTextFocusedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            return textField.translatablePlaceholderTextFocused;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.isSettingTextInCSharp = true;

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.TEXT, (string)newValue);
                textField.isSettingTextInCSharp = false;
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.TEXT);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = null;
        internal static void SetInternalPlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.PlaceholderText, (string)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.PlaceholderText);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = null;
        internal static void SetInternalPlaceholderTextFocusedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.PlaceholderTextFocused, (string)newValue);
            }
        }
        internal static object GetInternalPlaceholderTextFocusedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.PlaceholderTextFocused);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.FontStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.PointSize, (float)newValue);
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.PointSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = null;
        internal static void SetInternalMaxLengthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.MaxLength, (int)newValue);
            }
        }
        internal static object GetInternalMaxLengthProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyInt(textField.SwigCPtr, TextField.Property.MaxLength);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = null;
        internal static void SetInternalExceedPolicyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.ExceedPolicy, (int)newValue);
            }
        }
        internal static object GetInternalExceedPolicyProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyInt(textField.SwigCPtr, TextField.Property.ExceedPolicy);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.HorizontalAlignment, (int)newValue);
            }
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.HorizontalAlignment);
            return temp.GetValueByDescription<HorizontalAlignment>();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.VerticalAlignment, (int)newValue);
            }
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.VerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignment>();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.TextColor, ((Color)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalTextColor == null)
            {
                textField.internalTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.TextColor, textField.internalTextColor.SwigCPtr);
            return textField.internalTextColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = null;
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.PlaceholderTextColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalPlaceholderTextColor == null)
            {
                textField.internalPlaceholderTextColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.PlaceholderTextColor, textField.internalPlaceholderTextColor.SwigCPtr);
            return textField.internalPlaceholderTextColor;
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = null;
        internal static void SetInternalEnableGrabHandleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableGrabHandle, (bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableGrabHandle);
        }

        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = null;
        internal static void SetInternalEnableGrabHandlePopupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableGrabHandlePopup, (bool)newValue);
            }
        }
        internal static object GetInternalEnableGrabHandlePopupProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableGrabHandlePopup);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = null;
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.PrimaryCursorColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalPrimaryCursorColor == null)
            {
                textField.internalPrimaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.PrimaryCursorColor, textField.internalPrimaryCursorColor.SwigCPtr);
            return textField.internalPrimaryCursorColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = null;
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.SecondaryCursorColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalSecondaryCursorColor == null)
            {
                textField.internalSecondaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.SecondaryCursorColor, textField.internalSecondaryCursorColor.SwigCPtr);
            return textField.internalSecondaryCursorColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = null;
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableCursorBlink, (bool)newValue);
            }
        }
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableCursorBlink);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = null;
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.CursorBlinkInterval, (float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.CursorBlinkInterval);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = null;
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.CursorBlinkDuration, (float)newValue);
            }
        }
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.CursorBlinkDuration);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = null;
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.CursorWidth, (int)newValue);
            }
        }
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyInt(textField.SwigCPtr, TextField.Property.CursorWidth);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = null;
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.GrabHandleImage, (string)newValue);
            }
        }
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.GrabHandleImage);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = null;
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.GrabHandlePressedImage, (string)newValue);
            }
        }
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.GrabHandlePressedImage);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = null;
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.ScrollThreshold, (float)newValue);
            }
        }
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.ScrollThreshold);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = null;
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.ScrollSpeed, (float)newValue);
            }
        }
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.ScrollSpeed);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionPopupStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionPopupStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleImageLeft).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = null;
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleImageRight).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = null;
        internal static void SetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandlePressedImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandlePressedImageLeft).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = null;
        internal static void SetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandlePressedImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandlePressedImageRight).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = null;
        internal static void SetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleMarkerImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleMarkerImageLeft).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = null;
        internal static void SetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleMarkerImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SelectionHandleMarkerImageRight).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = null;
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.SelectionHighlightColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalSelectionHighlightColor == null)
            {
                textField.internalSelectionHighlightColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.SelectionHighlightColor, textField.internalSelectionHighlightColor.SwigCPtr);
            return textField.internalSelectionHighlightColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = null;
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.DecorationBoundingBox, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        }
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.DecorationBoundingBox).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = null;
        internal static void SetInternalInputMethodSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.InputMethodSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalInputMethodSettingsProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.InputMethodSettings).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = null;
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.InputColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalInputColor == null)
            {
                textField.internalInputColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.InputColor, textField.internalInputColor.SwigCPtr);
            return textField.internalInputColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableMarkup, (bool)newValue);
            }
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableMarkup);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = null;
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.InputFontFamily, (string)newValue);
            }
        }
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.InputFontFamily);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = null;
        internal static void SetInternalInputFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.InputFontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalInputFontStyleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.InputFontStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = null;
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.InputPointSize, (float)newValue);
            }
        }
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.InputPointSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.UNDERLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = null;
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.InputUnderline, (string)newValue);
            }
        }
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.InputUnderline);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.SHADOW).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = null;
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.InputShadow, (string)newValue);
            }
        }
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.InputShadow);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.EMBOSS, (string)newValue);
            }
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.EMBOSS);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = null;
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.InputEmboss, (string)newValue);
            }
        }
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.InputEmboss);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.OUTLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = null;
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textField.SwigCPtr, TextField.Property.InputOutline, (string)newValue);
            }
        }
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyString(textField.SwigCPtr, TextField.Property.InputOutline);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HiddenInputSettingsProperty = null;
        internal static void SetInternalHiddenInputSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.HiddenInputSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalHiddenInputSettingsProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.HiddenInputSettings).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.PixelSize, (float)newValue);
            }
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.PixelSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableSelection, (bool)newValue);
            }
        }
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableSelection);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = null;
        internal static void SetInternalPlaceholderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalPlaceholderProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textField.SwigCPtr, TextField.Property.PLACEHOLDER).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.ELLIPSIS, (bool)newValue);
            }
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.ELLIPSIS);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textField.SwigCPtr, TextField.Property.EllipsisPosition, (int)newValue);
            }
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyInt(textField.SwigCPtr, TextField.Property.EllipsisPosition);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = null;
        internal static void SetInternalEnableShiftSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableShiftSelection, (bool)newValue);
            }
        }
        internal static object GetInternalEnableShiftSelectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableShiftSelection);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.MatchSystemLanguageDirection, (bool)newValue);
            }
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.MatchSystemLanguageDirection);
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
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.EnableFontSizeScale, (bool)newValue);
            }
        }
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.EnableFontSizeScale);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = null;
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textField.SwigCPtr, TextField.Property.GrabHandleColor, ((Color)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            if (textField.internalGrabHandleColor == null)
            {
                textField.internalGrabHandleColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textField.SwigCPtr, TextField.Property.GrabHandleColor, textField.internalGrabHandleColor.SwigCPtr);
            return textField.internalGrabHandleColor;
        }

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = null;
        internal static void SetInternalShadowOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            if (newValue != null)
            {
                instance.InternalShadowOffset = (Tizen.NUI.Vector2)newValue;
            }
        }
        internal static object GetInternalShadowOffsetProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            return instance.InternalShadowOffset;
        }

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = null;
        internal static void SetInternalShadowColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            if (newValue != null)
            {
                instance.InternalShadowColor = (Tizen.NUI.Vector4)newValue;
            }
        }
        internal static object GetInternalShadowColorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            return instance.InternalShadowColor;
        }

        /// <summary>
        /// EnableEditingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableEditingProperty = null;
        internal static void SetInternalEnableEditingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            if (newValue != null)
            {
                instance.InternalEnableEditing = (bool)newValue;
            }
        }
        internal static object GetInternalEnableEditingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            return instance.InternalEnableEditing;
        }

        /// <summary>
        /// PrimaryCursorPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorPositionProperty = null;
        internal static void SetInternalPrimaryCursorPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            if (newValue != null)
            {
                instance.InternalPrimaryCursorPosition = (int)newValue;
            }
        }
        internal static object GetInternalPrimaryCursorPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextField)bindable;
            return instance.InternalPrimaryCursorPosition;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textField.SwigCPtr, TextField.Property.CharacterSpacing, (float)newValue);
            }
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textField = (TextField)bindable;

            return Object.InternalGetPropertyFloat(textField.SwigCPtr, TextField.Property.CharacterSpacing);
        }

        /// <summary>
        /// RemoveFrontInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveFrontInsetProperty = BindableProperty.Create(nameof(RemoveFrontInset), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.RemoveFrontInset, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textField = (TextField)bindable;
            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.RemoveFrontInset);
        }));

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = BindableProperty.Create(nameof(RemoveBackInset), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textField.SwigCPtr, TextField.Property.RemoveBackInset, (bool)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textField = (TextField)bindable;
            return Object.InternalGetPropertyBool(textField.SwigCPtr, TextField.Property.RemoveBackInset);
        }));
    }
}
