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
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.isSettingTextInCSharp = true;

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.TEXT, (string)newValue);
                textEditor.isSettingTextInCSharp = false;
            }
        }
        
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.TEXT);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.TextColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalTextColor == null)
            {
                textEditor.internalTextColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.TextColor, textEditor.internalTextColor.SwigCPtr);
            return textEditor.internalTextColor;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.InternalFontFamily = (string)newValue;
            }
        }
        
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return textEditor.InternalFontFamily;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontStyle).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PointSize, (float)newValue);
            }
        }
        
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PointSize);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment, (int)newValue);
            }
        }
        
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment);
            return temp.GetValueByDescription<HorizontalAlignment>();
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment, (int)newValue);
            }
        }
        
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment);
            return temp.GetValueByDescription<VerticalAlignment>();
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = null;
        
        internal static void SetInternalScrollThresholdProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold, (float)newValue);
            }
        }
        
        internal static object GetInternalScrollThresholdProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = null;
        
        internal static void SetInternalScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed, (float)newValue);
            }
        }
        
        internal static object GetInternalScrollSpeedProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = null;
        
        internal static void SetInternalPrimaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalPrimaryCursorColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalPrimaryCursorColor == null)
            {
                textEditor.internalPrimaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor, textEditor.internalPrimaryCursorColor.SwigCPtr);
            return textEditor.internalPrimaryCursorColor;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = null;
        
        internal static void SetInternalSecondaryCursorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalSecondaryCursorColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalSecondaryCursorColor == null)
            {
                textEditor.internalSecondaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor, textEditor.internalSecondaryCursorColor.SwigCPtr);
            return textEditor.internalSecondaryCursorColor;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = null;
        
        internal static void SetInternalEnableCursorBlinkProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableCursorBlinkProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = null;
        
        internal static void SetInternalCursorBlinkIntervalProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval, (float)newValue);
            }
        }
        
        internal static object GetInternalCursorBlinkIntervalProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = null;
        
        internal static void SetInternalCursorBlinkDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration, (float)newValue);
            }
        }
        
        internal static object GetInternalCursorBlinkDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = null;
        
        internal static void SetInternalCursorWidthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.CursorWidth, (int)newValue);
            }
        }
        
        internal static object GetInternalCursorWidthProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.CursorWidth);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = null;
        
        internal static void SetInternalGrabHandleImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage, (string)newValue);
            }
        }
        
        internal static object GetInternalGrabHandleImageProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = null;
        
        internal static void SetInternalGrabHandlePressedImageProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage, (string)newValue);
            }
        }
        
        internal static object GetInternalGrabHandlePressedImageProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = null;
        
        internal static void SetInternalSelectionPopupStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionPopupStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionPopupStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionPopupStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandleImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandleImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageLeft).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = null;
        
        internal static void SetInternalSelectionHandleImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandleImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageRight).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandlePressedImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = null;
        
        internal static void SetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandlePressedImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageRight).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = null;
        
        internal static void SetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandleMarkerImageLeftProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = null;
        
        internal static void SetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalSelectionHandleMarkerImageRightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = null;
        
        internal static void SetInternalSelectionHighlightColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalSelectionHighlightColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalSelectionHighlightColor == null)
            {
                textEditor.internalSelectionHighlightColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor, textEditor.internalSelectionHighlightColor.SwigCPtr);
            return textEditor.internalSelectionHighlightColor;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = null;
        
        internal static void SetInternalDecorationBoundingBoxProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.DecorationBoundingBox, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        }
        
        internal static object GetInternalDecorationBoundingBoxProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.DecorationBoundingBox).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableMarkup, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableMarkup);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = null;
        
        internal static void SetInternalInputColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.InputColor, ((Vector4)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalInputColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalInputColor == null)
            {
                textEditor.internalInputColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.InputColor, textEditor.internalInputColor.SwigCPtr);
            return textEditor.internalInputColor;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = null;
        
        internal static void SetInternalInputFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputFontFamily, (string)newValue);
            }
        }
        
        internal static object GetInternalInputFontFamilyProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputFontFamily);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = null;
        
        internal static void SetInternalInputFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalInputFontStyleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontStyle).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = null;
        
        internal static void SetInternalInputPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputPointSize, (float)newValue);
            }
        }
        
        internal static object GetInternalInputPointSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputPointSize);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.LineSpacing, (float)newValue);
            }
        }
        
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.LineSpacing);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputLineSpacingProperty = null;
        
        internal static void SetInternalInputLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing, (float)newValue);
            }
        }
        
        internal static object GetInternalInputLineSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing);
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight, (float)newValue);
            }
        }
        
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.UNDERLINE).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = null;
        
        internal static void SetInternalInputUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputUnderline, (string)newValue);
            }
        }
        
        internal static object GetInternalInputUnderlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputUnderline);
        }
        

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SHADOW).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = null;
        
        internal static void SetInternalInputShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputShadow, (string)newValue);
            }
        }
        
        internal static object GetInternalInputShadowProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputShadow);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.EMBOSS, (string)newValue);
            }
        }
        
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.EMBOSS);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = null;
        
        internal static void SetInternalInputEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputEmboss, (string)newValue);
            }
        }
        
        internal static object GetInternalInputEmbossProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputEmboss);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.OUTLINE).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = null;
        
        internal static void SetInternalInputOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputOutline, (string)newValue);
            }
        }
        
        internal static object GetInternalInputOutlineProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputOutline);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollProperty = null;
        
        internal static void SetInternalSmoothScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.SmoothScroll, (bool)newValue);
            }
        }
        
        internal static object GetInternalSmoothScrollProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.SmoothScroll);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollDurationProperty = null;
        
        internal static void SetInternalSmoothScrollDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration, (float)newValue);
            }
        }
        
        internal static object GetInternalSmoothScrollDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrollBarProperty = null;
        
        internal static void SetInternalEnableScrollBarProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableScrollBarProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarShowDurationProperty = null;
        
        internal static void SetInternalScrollBarShowDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration, (float)newValue);
            }
        }
        
        internal static object GetInternalScrollBarShowDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarFadeDurationProperty = null;
        
        internal static void SetInternalScrollBarFadeDurationProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration, (float)newValue);
            }
        }
        
        internal static object GetInternalScrollBarFadeDurationProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PixelSize, (float)newValue);
            }
        }
        
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PixelSize);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = null;
        
        internal static void SetInternalPlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.PlaceholderText, (string)newValue);
            }
        }
        
        internal static object GetInternalPlaceholderTextProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.PlaceholderText);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = null;
        
        internal static void SetInternalPlaceholderTextColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor, ((Color)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalPlaceholderTextColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalPlaceholderTextColor == null)
            {
                textEditor.internalPlaceholderTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor, textEditor.internalPlaceholderTextColor.SwigCPtr);
            return textEditor.internalPlaceholderTextColor;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = null;
        
        internal static void SetInternalEnableSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableSelection, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableSelectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableSelection);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = null;
        
        internal static void SetInternalPlaceholderProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalPlaceholderProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PLACEHOLDER).Get(temp);
            return temp;
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.LineWrapMode, (int)newValue);
            }
        }
        
        internal static object GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.LineWrapMode);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = null;
        
        internal static void SetInternalEnableShiftSelectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableShiftSelectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            //textEditor.mShiftSelectionFlag(true);

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection);
        }
        
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection, (bool)newValue);
            }
        }
        
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection);
        }
        
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = null;
        
        internal static void SetInternalMaxLengthProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.MaxLength, (int)newValue);
            }
        }
        
        internal static object GetInternalMaxLengthProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.MaxLength);
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
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = null;
        
        internal static void SetInternalGrabHandleColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor, ((Color)newValue).SwigCPtr);
            }
        }
        
        internal static object GetInternalGrabHandleColorProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            if (textEditor.internalGrabHandleColor == null)
            {
                textEditor.internalGrabHandleColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor, textEditor.internalGrabHandleColor.SwigCPtr);
            return textEditor.internalGrabHandleColor;
        }
        

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = null;
        
        internal static void SetInternalEnableGrabHandleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableGrabHandleProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle);
        }
        
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = null;
        
        internal static void SetInternalEnableGrabHandlePopupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup, (bool)newValue);
            }
        }
        
        internal static object GetInternalEnableGrabHandlePopupProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = null;
        
        internal static void SetInternalInputMethodSettingsProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputMethodSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        
        internal static object GetInternalInputMethodSettingsProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputMethodSettings).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS, (bool)newValue);
            }
        }
        
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS);
        }
        
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition, (int)newValue);
            }
        }
        
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition);
        }

        /// currently need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.MinLineSize, (float)newValue);
            }
        }
        
        internal static object GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.MinLineSize);
        }

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = null;
        
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatableText = (string)newValue;
            }
        }
        
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalTranslatableText;
        }

        /// <summary>
        /// TranslatablePlaceholderTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextProperty = null;
        
        internal static void SetInternalTranslatablePlaceholderTextProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatablePlaceholderText = (string)newValue;
            }
        }
        
        internal static object GetInternalTranslatablePlaceholderTextProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalTranslatablePlaceholderText;
        }

        /// <summary>
        /// EnableEditingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableEditingProperty = null;
        
        internal static void SetInternalEnableEditingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalEnableEditing = (bool)newValue;
            }
        }
        
        internal static object GetInternalEnableEditingProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalEnableEditing;
        }

        /// <summary>
        /// HorizontalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalScrollPositionProperty = null;
        
        internal static void SetInternalHorizontalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalHorizontalScrollPosition = (int)newValue;
            }
        }
        
        internal static object GetInternalHorizontalScrollPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalHorizontalScrollPosition;
        }

        /// <summary>
        /// VerticalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalScrollPositionProperty = null;
        
        internal static void SetInternalVerticalScrollPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalVerticalScrollPosition = (int)newValue;
            }
        }
        
        internal static object GetInternalVerticalScrollPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalVerticalScrollPosition;
        }

        /// <summary>
        /// PrimaryCursorPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorPositionProperty = null;
        
        internal static void SetInternalPrimaryCursorPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalPrimaryCursorPosition = (int)newValue;
            }
        }
        
        internal static object GetInternalPrimaryCursorPositionProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalPrimaryCursorPosition;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing, (float)newValue);
            }
        }
        
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;

            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing);
        }

        /// <summary>
        /// RemoveFrontInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveFrontInsetProperty = null;
        internal static void SetInternalRemoveFrontInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.RemoveFrontInset, (bool)newValue);
            }
        }
        internal static object GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.RemoveFrontInset);
        }

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = null;
        internal static void SetInternalRemoveBackInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.RemoveBackInset, (bool)newValue);
            }
        }
        internal static object GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textEditor = (TextEditor)bindable;
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.RemoveBackInset);
        }
    }
}
