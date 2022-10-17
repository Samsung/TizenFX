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
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                textEditor.isSettingTextInCSharp = true;
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.TEXT, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.TEXT, new Tizen.NUI.PropertyValue((string)newValue));
#endif
                textEditor.isSettingTextInCSharp = false;
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.TEXT);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.TEXT).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.TextColor, ((Vector4)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.TextColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalTextColor == null)
            {
                textEditor.internalTextColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.TextColor, textEditor.internalTextColor.SwigCPtr);
            return textEditor.internalTextColor;
#else

            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.TextColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.FontFamily, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontFamily, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.FontFamily);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontFamily).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontStyle).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PointSize, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PointSize, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PointSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PointSize).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextEditor), HorizontalAlignment.Begin, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
#if NUI_PROPERTY_CHANGE_2
            temp = Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment);
#else
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.HorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }
#endif
            return temp.GetValueByDescription<HorizontalAlignment>();
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextEditor), VerticalAlignment.Bottom, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
#if NUI_PROPERTY_CHANGE_2
            temp = Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment);
#else
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.VerticalAlignment).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }
#endif
            return temp.GetValueByDescription<VerticalAlignment>();
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollThreshold).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollSpeed).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor, ((Vector4)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalPrimaryCursorColor == null)
            {
                textEditor.internalPrimaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor, textEditor.internalPrimaryCursorColor.SwigCPtr);
            return textEditor.internalPrimaryCursorColor;
#else
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PrimaryCursorColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor, ((Vector4)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
#endif            
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalSecondaryCursorColor == null)
            {
                textEditor.internalSecondaryCursorColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor, textEditor.internalSecondaryCursorColor.SwigCPtr);
            return textEditor.internalSecondaryCursorColor;
#else
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SecondaryCursorColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableCursorBlink).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorBlinkInterval).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorBlinkDuration).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int), typeof(TextEditor), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.CursorWidth, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorWidth, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.CursorWidth);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CursorWidth).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandleImage).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandlePressedImage).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionPopupStyleProperty = BindableProperty.Create(nameof(SelectionPopupStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionPopupStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionPopupStyle).Get(temp);
            return temp;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageLeft).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleImageRight).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandlePressedImageRight).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor, ((Vector4)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalSelectionHighlightColor == null)
            {
                textEditor.internalSelectionHighlightColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor, textEditor.internalSelectionHighlightColor.SwigCPtr);
            return textEditor.internalSelectionHighlightColor;
#else
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SelectionHighlightColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.DecorationBoundingBox, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.DecorationBoundingBox).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableMarkup, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableMarkup, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableMarkup);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableMarkup).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.InputColor, ((Vector4)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalInputColor == null)
            {
                textEditor.internalInputColor = new Vector4(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.InputColor, textEditor.internalInputColor.SwigCPtr);
            return textEditor.internalInputColor;
#else
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputFontFamily, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontFamily, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputFontFamily);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontFamily).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = BindableProperty.Create(nameof(InputFontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputFontStyle).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputPointSize, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputPointSize, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputPointSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputPointSize).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.LineSpacing, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.LineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.LineSpacing);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.LineSpacing).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputLineSpacingProperty = BindableProperty.Create(nameof(InputLineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputLineSpacing).Get(out temp);
            return temp;
#endif
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.RelativeLineHeight).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.UNDERLINE).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputUnderline, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputUnderline, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputUnderline);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputUnderline).Get(out temp);
            return temp;
#endif
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SHADOW).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputShadow, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputShadow, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputShadow);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputShadow).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.EMBOSS, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.EMBOSS);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EMBOSS).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputEmboss, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputEmboss, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputEmboss);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputEmboss).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.OUTLINE).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputOutline, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputOutline, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.InputOutline);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputOutline).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.SmoothScroll, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SmoothScroll, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.SmoothScroll);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SmoothScroll).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.SmoothScrollDuration).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableScrollBar).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollBarShowDuration).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ScrollBarFadeDuration).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PixelSize, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PixelSize, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.PixelSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PixelSize).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyString(textEditor.SwigCPtr, TextEditor.Property.PlaceholderText, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PlaceholderText, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyString(textEditor.SwigCPtr, TextEditor.Property.PlaceholderText);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PlaceholderText).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor, ((Color)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor, new Tizen.NUI.PropertyValue((Color)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalPlaceholderTextColor == null)
            {
                textEditor.internalPlaceholderTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor, textEditor.internalPlaceholderTextColor.SwigCPtr);
            return textEditor.internalPlaceholderTextColor;
#else
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PlaceholderTextColor).Get(temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableSelection, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableSelection, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableSelection);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableSelection).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.PLACEHOLDER).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextEditor), LineWrapMode.Word, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.LineWrapMode, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.LineWrapMode, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.LineWrapMode);
#else
            int temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.LineWrapMode).Get(out temp) == false)
            {
                NUILog.Error("LineWrapMode get error!");
            }
            return (LineWrapMode)temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = BindableProperty.Create(nameof(TextEditor.EnableShiftSelection), typeof(bool), typeof(TextEditor), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            //textEditor.mShiftSelectionFlag(true);
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableShiftSelection).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextEditor.MatchSystemLanguageDirection), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MatchSystemLanguageDirection).Get(out temp);
            return (bool)temp;
#endif
        }));
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextEditor), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.MaxLength, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MaxLength, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.MaxLength);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MaxLength).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.FontSizeScale, (float)newValue);
#else
                using (var property = new Tizen.NUI.PropertyValue((float)newValue))
                {
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontSizeScale, property);
                }
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.FontSizeScale);
#else
            float temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.FontSizeScale).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = BindableProperty.Create(nameof(EnableFontSizeScale), typeof(bool), typeof(TextEditor), default(bool), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale, (bool)newValue);
#else
                using (var property = new Tizen.NUI.PropertyValue((bool)newValue))
                {
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale, property);
                }
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale);
#else
            bool temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableFontSizeScale).Get(out temp);
            return temp;
#endif
        }));

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor, ((Color)newValue).SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor, new Tizen.NUI.PropertyValue((Color)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            if (textEditor.internalGrabHandleColor == null)
            {
                textEditor.internalGrabHandleColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor, textEditor.internalGrabHandleColor.SwigCPtr);
            return textEditor.internalGrabHandleColor;
#else
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.GrabHandleColor).Get(temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = BindableProperty.Create(nameof(TextEditor.EnableGrabHandle), typeof(bool), typeof(TextEditor), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandle).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = BindableProperty.Create(nameof(TextEditor.EnableGrabHandlePopup), typeof(bool), typeof(TextEditor), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EnableGrabHandlePopup).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = BindableProperty.Create(nameof(TextEditor.InputMethodSettings), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputMethodSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.InputMethodSettings).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(TextEditor.Ellipsis), typeof(bool), typeof(TextEditor), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyBool(textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.ELLIPSIS).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = BindableProperty.Create(nameof(EllipsisPosition), typeof(EllipsisPosition), typeof(TextEditor), EllipsisPosition.End, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyInt(textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.EllipsisPosition).Get(out temp);
            return (EllipsisPosition)temp;
#endif
        }));

        /// currently need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.MinLineSize, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MinLineSize, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.MinLineSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.MinLineSize).Get(out temp);
            return temp;
#endif
        }));

        /// <summary>
        /// TranslatableTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(Tizen.NUI.BaseComponents.TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatableText = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalTranslatableText;
        });

        /// <summary>
        /// TranslatablePlaceholderTextProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextProperty = BindableProperty.Create(nameof(TranslatablePlaceholderText), typeof(string), typeof(Tizen.NUI.BaseComponents.TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalTranslatablePlaceholderText = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalTranslatablePlaceholderText;
        });

        /// <summary>
        /// EnableEditingProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableEditingProperty = BindableProperty.Create(nameof(EnableEditing), typeof(bool), typeof(Tizen.NUI.BaseComponents.TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalEnableEditing = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalEnableEditing;
        });

        /// <summary>
        /// HorizontalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalScrollPositionProperty = BindableProperty.Create(nameof(HorizontalScrollPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalHorizontalScrollPosition = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalHorizontalScrollPosition;
        });

        /// <summary>
        /// VerticalScrollPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalScrollPositionProperty = BindableProperty.Create(nameof(VerticalScrollPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalVerticalScrollPosition = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalVerticalScrollPosition;
        });

        /// <summary>
        /// PrimaryCursorPositionProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorPositionProperty = BindableProperty.Create(nameof(PrimaryCursorPosition), typeof(int), typeof(Tizen.NUI.BaseComponents.TextEditor), 0, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            if (newValue != null)
            {
                instance.InternalPrimaryCursorPosition = (int)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextEditor)bindable;
            return instance.InternalPrimaryCursorPosition;
        });

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Object.InternalSetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textEditor = (TextEditor)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Object.InternalGetPropertyFloat(textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing);
#else
            float temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textEditor.SwigCPtr, TextEditor.Property.CharacterSpacing).Get(out temp);
            return temp;
#endif
        }));
    }
}
