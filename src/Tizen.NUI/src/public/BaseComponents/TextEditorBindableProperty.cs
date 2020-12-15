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
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.TEXT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.TEXT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.TextColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.TextColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.FontFamily, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.FontFamily).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.FontStyle).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PointSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PointSize).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextEditor), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.HorizontalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.HorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }

            return temp.GetValueByDescription<HorizontalAlignment>();
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollThreshold, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollThreshold).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollSpeed, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollSpeed).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PrimaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PrimaryCursorColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SecondaryCursorColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SecondaryCursorColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EnableCursorBlink, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EnableCursorBlink).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CursorBlinkInterval, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CursorBlinkInterval).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CursorBlinkDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CursorBlinkDuration).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int), typeof(TextEditor), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CursorWidth, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CursorWidth).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.GrabHandleImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.GrabHandleImage).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.GrabHandlePressedImage, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.GrabHandlePressedImage).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandlePressedImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandlePressedImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandlePressedImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleMarkerImageLeft).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHandleMarkerImageRight).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHighlightColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SelectionHighlightColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.DecorationBoundingBox, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.DecorationBoundingBox).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EnableMarkup, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EnableMarkup).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputFontFamily, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputFontFamily).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = BindableProperty.Create(nameof(InputFontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputFontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputFontStyle).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputPointSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputPointSize).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.LineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.LineSpacing).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputLineSpacingProperty = BindableProperty.Create(nameof(InputLineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputLineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputLineSpacing).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.UNDERLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputUnderline, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputUnderline).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SHADOW).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputShadow, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputShadow).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EMBOSS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputEmboss, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputEmboss).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.OUTLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.InputOutline, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.InputOutline).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SmoothScroll, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SmoothScroll).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SmoothScrollDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SmoothScrollDuration).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EnableScrollBar, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EnableScrollBar).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollBarShowDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollBarShowDuration).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollBarFadeDuration, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ScrollBarFadeDuration).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PixelSize, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PixelSize).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PlaceholderText, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PlaceholderText).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PlaceholderTextColor, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PlaceholderTextColor).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EnableSelection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EnableSelection).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderProperty = BindableProperty.Create(nameof(Placeholder), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Tizen.NUI.PropertyMap temp = new Tizen.NUI.PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextEditor), LineWrapMode.Word, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.LineWrapMode, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            int temp;
            if (Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.LineWrapMode).Get(out temp) == false)
            {
                NUILog.Error("LineWrapMode get error!");
            }
            return (LineWrapMode)temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableShiftSelectionProperty = BindableProperty.Create(nameof(TextEditor.EnableShiftSelection), typeof(bool), typeof(TextEditor), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.EnableShiftSelection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            //textEditor.mShiftSelectionFlag(true);
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.EnableShiftSelection).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextEditor.MatchSystemLanguageDirection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.MatchSystemLanguageDirection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.MatchSystemLanguageDirection).Get(out temp);
            return (bool)temp;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextEditor), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.MaxLength, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.MaxLength).Get(out temp);
            return temp;
        });
    }
}
