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
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextField
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.TEXT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.TEXT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = BindableProperty.Create(nameof(PlaceholderTextFocused), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT_FOCUSED, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT_FOCUSED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.FONT_FAMILY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.FONT_STYLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.FONT_STYLE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.POINT_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.POINT_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.MAX_LENGTH, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.MAX_LENGTH).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = BindableProperty.Create(nameof(ExceedPolicy), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EXCEED_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EXCEED_POLICY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextField), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }

            switch (temp)
            {
                case "BEGIN": return HorizontalAlignment.Begin;
                case "CENTER": return HorizontalAlignment.Center;
                case "END": return HorizontalAlignment.End;
                default: return HorizontalAlignment.Begin;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(TextField.VerticalAlignment), typeof(VerticalAlignment), typeof(TextField), VerticalAlignment.Bottom, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.VERTICAL_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }

            switch (temp)
            {
                case "TOP": return VerticalAlignment.Top;
                case "CENTER": return VerticalAlignment.Center;
                case "BOTTOM": return VerticalAlignment.Bottom;
                default: return VerticalAlignment.Bottom;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextField.TextColor), typeof(Color), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.TEXT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(TextField.PlaceholderTextColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER_TEXT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = BindableProperty.Create(nameof(TextField.EnableGrabHandle), typeof(bool), typeof(TextField), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_GRAB_HANDLE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_GRAB_HANDLE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = BindableProperty.Create(nameof(TextField.EnableGrabHandlePopup), typeof(bool), typeof(TextField), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_GRAB_HANDLE_POPUP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_GRAB_HANDLE_POPUP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(TextField.PrimaryCursorColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PRIMARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PRIMARY_CURSOR_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(TextField.SecondaryCursorColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SECONDARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SECONDARY_CURSOR_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(TextField.EnableCursorBlink), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_CURSOR_BLINK, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_CURSOR_BLINK).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(TextField.CursorBlinkInterval), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CURSOR_BLINK_INTERVAL, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CURSOR_BLINK_INTERVAL).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(TextField.CursorBlinkDuration), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CURSOR_BLINK_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CURSOR_BLINK_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(TextField.CursorWidth), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CURSOR_WIDTH, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CURSOR_WIDTH).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(TextField.GrabHandleImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.GRAB_HANDLE_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.GRAB_HANDLE_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(TextField.GrabHandlePressedImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.GRAB_HANDLE_PRESSED_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.GRAB_HANDLE_PRESSED_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(TextField.ScrollThreshold), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SCROLL_THRESHOLD, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SCROLL_THRESHOLD).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(TextField.ScrollSpeed), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SCROLL_SPEED, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SCROLL_SPEED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(TextField.SelectionHighlightColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SELECTION_HIGHLIGHT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SELECTION_HIGHLIGHT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(TextField.DecorationBoundingBox), typeof(Rectangle), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.DECORATION_BOUNDING_BOX, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.DECORATION_BOUNDING_BOX).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = BindableProperty.Create(nameof(TextField.InputMethodSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_METHOD_SETTINGS, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_METHOD_SETTINGS).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(TextField.InputColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(TextField.EnableMarkup), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_MARKUP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(TextField.InputFontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_FONT_FAMILY, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_FONT_FAMILY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = BindableProperty.Create(nameof(TextField.InputFontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_FONT_STYLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_FONT_STYLE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(TextField.InputPointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_POINT_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_POINT_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(TextField.Underline), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.UNDERLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create(nameof(TextField.InputUnderline), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_UNDERLINE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_UNDERLINE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create(nameof(TextField.Shadow), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SHADOW).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = BindableProperty.Create(nameof(TextField.InputShadow), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_SHADOW, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_SHADOW).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(TextField.Emboss), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EMBOSS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = BindableProperty.Create(nameof(TextField.InputEmboss), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_EMBOSS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = BindableProperty.Create(nameof(TextField.Outline), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.OUTLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = BindableProperty.Create(nameof(TextField.InputOutline), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.INPUT_OUTLINE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.INPUT_OUTLINE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HiddenInputSettingsProperty = BindableProperty.Create(nameof(TextField.HiddenInputSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.HIDDEN_INPUT_SETTINGS, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.HIDDEN_INPUT_SETTINGS).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(TextField.PixelSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PIXEL_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(TextField.EnableSelection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_SELECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_SELECTION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(TextField.Placeholder), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PLACEHOLDER).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(TextField.Ellipsis), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ELLIPSIS, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ELLIPSIS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = BindableProperty.Create(nameof(TextField.EnableShiftSelection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ENABLE_SHIFT_SELECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ENABLE_SHIFT_SELECTION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextField.MatchSystemLanguageDirection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION).Get(out temp);
            return (bool)temp;
        });
    }
}
