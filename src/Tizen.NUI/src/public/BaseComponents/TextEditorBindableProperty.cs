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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.TEXT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.FONT_FAMILY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.FONT_STYLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.FONT_STYLE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.POINT_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.POINT_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextEditor), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_THRESHOLD, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_THRESHOLD).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_SPEED, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_SPEED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PRIMARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PRIMARY_CURSOR_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SECONDARY_CURSOR_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SECONDARY_CURSOR_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_CURSOR_BLINK, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_CURSOR_BLINK).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_BLINK_INTERVAL, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_BLINK_INTERVAL).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_BLINK_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_BLINK_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int), typeof(TextEditor), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_WIDTH, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.CURSOR_WIDTH).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.GRAB_HANDLE_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.GRAB_HANDLE_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.GRAB_HANDLE_PRESSED_IMAGE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.GRAB_HANDLE_PRESSED_IMAGE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageLeftProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandlePressedImageRightProperty = BindableProperty.Create(nameof(SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_PRESSED_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_LEFT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleMarkerImageRightProperty = BindableProperty.Create(nameof(SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HANDLE_MARKER_IMAGE_RIGHT).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HIGHLIGHT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SELECTION_HIGHLIGHT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.DECORATION_BOUNDING_BOX, new Tizen.NUI.PropertyValue((Rectangle)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Rectangle temp = new Rectangle(0, 0, 0, 0);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.DECORATION_BOUNDING_BOX).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_MARKUP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_COLOR, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Vector4 temp = new Vector4(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_FONT_FAMILY, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_FONT_FAMILY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontStyleProperty = BindableProperty.Create(nameof(InputFontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_FONT_STYLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_FONT_STYLE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_POINT_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_POINT_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.LINE_SPACING, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.LINE_SPACING).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputLineSpacingProperty = BindableProperty.Create(nameof(InputLineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_LINE_SPACING, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_LINE_SPACING).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_UNDERLINE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_UNDERLINE).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_SHADOW, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_SHADOW).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_EMBOSS).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_OUTLINE, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.INPUT_OUTLINE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollProperty = BindableProperty.Create(nameof(SmoothScroll), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SMOOTH_SCROLL, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SMOOTH_SCROLL).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SmoothScrollDurationProperty = BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SMOOTH_SCROLL_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SMOOTH_SCROLL_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableScrollBarProperty = BindableProperty.Create(nameof(EnableScrollBar), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SCROLL_BAR, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SCROLL_BAR).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarShowDurationProperty = BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_BAR_SHOW_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_BAR_SHOW_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollBarFadeDurationProperty = BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_BAR_FADE_DURATION, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.SCROLL_BAR_FADE_DURATION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PIXEL_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER_TEXT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER_TEXT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER_TEXT_COLOR, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.PLACEHOLDER_TEXT_COLOR).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SELECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SELECTION).Get(out temp);
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.LINE_WRAP_MODE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            int temp;
            if (Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.LINE_WRAP_MODE).Get(out temp) == false)
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
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SHIFT_SELECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            //textEditor.mShiftSelectionFlag(true);
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.ENABLE_SHIFT_SELECTION).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(TextEditor.MatchSystemLanguageDirection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = (TextEditor)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textEditor.swigCPtr, TextEditor.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = (TextEditor)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textEditor.swigCPtr, TextEditor.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION).Get(out temp);
            return (bool)temp;
        });
    }
}
