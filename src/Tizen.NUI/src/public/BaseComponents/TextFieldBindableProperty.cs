﻿/*
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
        /// <summary>
        /// StyleNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.translatableText = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.translatableText;
        });
        /// <summary>
        /// StyleNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextProperty = BindableProperty.Create(nameof(TranslatablePlaceholderText), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                textField.translatablePlaceholderText = (string)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.translatablePlaceholderText;
        });
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PlaceholderText, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PlaceholderText).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = BindableProperty.Create(nameof(PlaceholderTextFocused), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PlaceholderTextFocused, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PlaceholderTextFocused).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.FontFamily, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.FontFamily).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.FontStyle).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PointSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PointSize).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.MaxLength, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.MaxLength).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = BindableProperty.Create(nameof(ExceedPolicy), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ExceedPolicy, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ExceedPolicy).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextField), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.HorizontalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.HorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }

            return temp.GetValueByDescription<HorizontalAlignment>();
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(TextField.VerticalAlignment), typeof(VerticalAlignment), typeof(TextField), VerticalAlignment.Bottom, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.VerticalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.VerticalAlignment).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }

            return temp.GetValueByDescription<VerticalAlignment>();
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextField.TextColor), typeof(Color), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.TextColor, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.TextColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(TextField.PlaceholderTextColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PlaceholderTextColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PlaceholderTextColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandleProperty = BindableProperty.Create(nameof(TextField.EnableGrabHandle), typeof(bool), typeof(TextField), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableGrabHandle, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableGrabHandle).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableGrabHandlePopupProperty = BindableProperty.Create(nameof(TextField.EnableGrabHandlePopup), typeof(bool), typeof(TextField), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableGrabHandlePopup, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableGrabHandlePopup).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(TextField.PrimaryCursorColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PrimaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PrimaryCursorColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(TextField.SecondaryCursorColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SecondaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SecondaryCursorColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(TextField.EnableCursorBlink), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableCursorBlink, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableCursorBlink).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(TextField.CursorBlinkInterval), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CursorBlinkInterval, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CursorBlinkInterval).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(TextField.CursorBlinkDuration), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CursorBlinkDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CursorBlinkDuration).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(TextField.CursorWidth), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.CursorWidth, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.CursorWidth).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(TextField.GrabHandleImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.GrabHandleImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.GrabHandleImage).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(TextField.GrabHandlePressedImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.GrabHandlePressedImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.GrabHandlePressedImage).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(TextField.ScrollThreshold), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ScrollThreshold, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ScrollThreshold).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(TextField.ScrollSpeed), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.ScrollSpeed, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.ScrollSpeed).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandleImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandleImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandleImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandleImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandleImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandlePressedImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandlePressedImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandlePressedImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandlePressedImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandleMarkerImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandleMarkerImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHandleMarkerImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHandleMarkerImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(TextField.SelectionHighlightColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.SelectionHighlightColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.SelectionHighlightColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(TextField.DecorationBoundingBox), typeof(Rectangle), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.DecorationBoundingBox, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.DecorationBoundingBox).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputMethodSettingsProperty = BindableProperty.Create(nameof(TextField.InputMethodSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputMethodSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputMethodSettings).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(TextField.InputColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(TextField.EnableMarkup), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableMarkup, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableMarkup).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(TextField.InputFontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputFontFamily, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputFontFamily).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = BindableProperty.Create(nameof(TextField.InputFontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputFontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputFontStyle).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(TextField.InputPointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputPointSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputPointSize).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputUnderline, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputUnderline).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputShadow, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputShadow).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputEmboss, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputEmboss).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.InputOutline, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.InputOutline).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HiddenInputSettingsProperty = BindableProperty.Create(nameof(TextField.HiddenInputSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.HiddenInputSettings, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.HiddenInputSettings).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(TextField.PixelSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.PixelSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.PixelSize).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(TextField.EnableSelection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableSelection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableSelection).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.EnableShiftSelection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.EnableShiftSelection).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextField.MatchSystemLanguageDirection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textField.swigCPtr, TextField.Property.MatchSystemLanguageDirection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textField.swigCPtr, TextField.Property.MatchSystemLanguageDirection).Get(out temp);
            return (bool)temp;
        });

        #region Selectors
        internal static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create("TranslatableTextSelector", typeof(Selector<string>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.TranslatableText.Update(textField, (Selector<string>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.TranslatableText.Get(textField);
        });
        internal static readonly BindableProperty TranslatablePlaceholderTextSelectorProperty = BindableProperty.Create("TranslatablePlaceholderTextSelector", typeof(Selector<string>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.TranslatablePlaceholderText.Update(textField, (Selector<string>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.TranslatablePlaceholderText.Get(textField);
        });
        internal static readonly BindableProperty TextSelectorProperty = BindableProperty.Create("TextSelector", typeof(Selector<string>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.Text.Update(textField, (Selector<string>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.Text.Get(textField);
        });
        internal static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create("FontFamilySelector", typeof(Selector<string>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.FontFamily.Update(textField, (Selector<string>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.FontFamily.Get(textField);
        });
        internal static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create("PointSizeSelector", typeof(Selector<float?>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.PointSize.Update(textField, (Selector<float?>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.PointSize.Get(textField);
        });
        internal static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create("TextColorSelector", typeof(Selector<Color>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.TextColor.Update(textField, (Selector<Color>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.TextColor.Get(textField);
        });
        internal static readonly BindableProperty PlaceholderTextColorSelectorProperty = BindableProperty.Create("PlaceholderTextColorSelector", typeof(Selector<Vector4>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.PlaceholderTextColor.Update(textField, (Selector<Vector4>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.PlaceholderTextColor.Get(textField);
        });
        internal static readonly BindableProperty PrimaryCursorColorSelectorProperty = BindableProperty.Create("PrimaryCursorColorSelector", typeof(Selector<Vector4>), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = (TextField)bindable;
            textField.SelectorData.PrimaryCursorColor.Update(textField, (Selector<Vector4>)newValue, true);
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = (TextField)bindable;
            return textField.SelectorData.PrimaryCursorColor.Get(textField);
        });
        #endregion
    }
}
