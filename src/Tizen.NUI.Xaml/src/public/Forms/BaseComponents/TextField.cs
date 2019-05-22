/*
 * Copyright(c) 2018 Samsung Electronics Co., Ltd.
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
extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;

using System;
using System.Runtime.InteropServices;
using System.Globalization;
using System.ComponentModel;
using Tizen.NUI.Binding;
using static Tizen.NUI.BaseComponents.TextField;
using Tizen.NUI;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// A control which provides a single line editable text field.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextField : View
    {
        private Tizen.NUI.BaseComponents.TextField _textField;
        internal Tizen.NUI.BaseComponents.TextField textField
        {
            get
            {
                if (null == _textField)
                {
                    _textField = handleInstance as Tizen.NUI.BaseComponents.TextField;
                }

                return _textField;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextField() : this(new Tizen.NUI.BaseComponents.TextField())
        {
        }

        internal TextField(Tizen.NUI.BaseComponents.TextField nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TextProperty = Binding.BindableProperty.Create(nameof(Text), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Text = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Text;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderTextProperty = Binding.BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PlaceholderText = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PlaceholderText;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderTextFocusedProperty = Binding.BindableProperty.Create(nameof(PlaceholderTextFocused), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PlaceholderTextFocused = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PlaceholderTextFocused;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FontFamilyProperty = Binding.BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.FontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.FontFamily;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FontStyleProperty = Binding.BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.FontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.FontStyle;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PointSizeProperty = Binding.BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PointSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PointSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MaxLengthProperty = Binding.BindableProperty.Create(nameof(MaxLength), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.MaxLength = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.MaxLength;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ExceedPolicyProperty = Binding.BindableProperty.Create(nameof(ExceedPolicy), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.ExceedPolicy = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.ExceedPolicy;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HorizontalAlignmentProperty = Binding.BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextField), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.HorizontalAlignment = (HorizontalAlignment)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.HorizontalAlignment;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty VerticalAlignmentProperty = Binding.BindableProperty.Create(nameof(TextField.VerticalAlignment), typeof(VerticalAlignment), typeof(TextField), VerticalAlignment.Bottom, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.VerticalAlignment = (VerticalAlignment)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.VerticalAlignment;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TextColorProperty = Binding.BindableProperty.Create(nameof(TextField.TextColor), typeof(Color), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.TextColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.TextColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderTextColorProperty = Binding.BindableProperty.Create(nameof(TextField.PlaceholderTextColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PlaceholderTextColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PlaceholderTextColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShadowOffsetProperty = Binding.BindableProperty.Create(nameof(TextField.ShadowOffset), typeof(Vector2), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.ShadowOffset = (Vector2)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.ShadowOffset;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShadowColorProperty = Binding.BindableProperty.Create(nameof(TextField.ShadowColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.ShadowColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.ShadowColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PrimaryCursorColorProperty = Binding.BindableProperty.Create("PrimaryCursorColor", typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PrimaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PrimaryCursorColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SecondaryCursorColorProperty = Binding.BindableProperty.Create(nameof(TextField.SecondaryCursorColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SecondaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SecondaryCursorColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableCursorBlinkProperty = Binding.BindableProperty.Create(nameof(TextField.EnableCursorBlink), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.EnableCursorBlink = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.EnableCursorBlink;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorBlinkIntervalProperty = Binding.BindableProperty.Create(nameof(TextField.CursorBlinkInterval), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.CursorBlinkInterval = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.CursorBlinkInterval;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorBlinkDurationProperty = Binding.BindableProperty.Create(nameof(TextField.CursorBlinkDuration), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.CursorBlinkDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.CursorBlinkDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorWidthProperty = Binding.BindableProperty.Create(nameof(TextField.CursorWidth), typeof(int), typeof(TextField), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.CursorWidth = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.CursorWidth;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty GrabHandleImageProperty = Binding.BindableProperty.Create(nameof(TextField.GrabHandleImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.GrabHandleImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.GrabHandleImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty GrabHandlePressedImageProperty = Binding.BindableProperty.Create(nameof(TextField.GrabHandlePressedImage), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.GrabHandlePressedImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.GrabHandlePressedImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollThresholdProperty = Binding.BindableProperty.Create(nameof(TextField.ScrollThreshold), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.ScrollThreshold = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.ScrollThreshold;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollSpeedProperty = Binding.BindableProperty.Create(nameof(TextField.ScrollSpeed), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.ScrollSpeed = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.ScrollSpeed;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleImageLeftProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandleImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandleImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleImageRightProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandleImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandleImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandlePressedImageLeftProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandlePressedImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandlePressedImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandlePressedImageRightProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandlePressedImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandlePressedImageRight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleMarkerImageLeftProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandleMarkerImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandleMarkerImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleMarkerImageRightProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHandleMarkerImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHandleMarkerImageRight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHighlightColorProperty = Binding.BindableProperty.Create(nameof(TextField.SelectionHighlightColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.SelectionHighlightColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.SelectionHighlightColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DecorationBoundingBoxProperty = Binding.BindableProperty.Create(nameof(TextField.DecorationBoundingBox), typeof(Rectangle), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.DecorationBoundingBox = (Rectangle)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.DecorationBoundingBox;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputMethodSettingsProperty = Binding.BindableProperty.Create(nameof(TextField.InputMethodSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputMethodSettings = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputMethodSettings;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputColorProperty = Binding.BindableProperty.Create(nameof(TextField.InputColor), typeof(Vector4), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableMarkupProperty = Binding.BindableProperty.Create(nameof(TextField.EnableMarkup), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.EnableMarkup = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.EnableMarkup;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputFontFamilyProperty = Binding.BindableProperty.Create(nameof(TextField.InputFontFamily), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputFontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputFontFamily;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputFontStyleProperty = Binding.BindableProperty.Create(nameof(TextField.InputFontStyle), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputFontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputFontStyle;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputPointSizeProperty = Binding.BindableProperty.Create(nameof(TextField.InputPointSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputPointSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputPointSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty UnderlineProperty = Binding.BindableProperty.Create(nameof(TextField.Underline), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Underline = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Underline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputUnderlineProperty = Binding.BindableProperty.Create(nameof(TextField.InputUnderline), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputUnderline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputUnderline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShadowProperty = Binding.BindableProperty.Create(nameof(TextField.Shadow), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Shadow = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Shadow;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputShadowProperty = Binding.BindableProperty.Create(nameof(TextField.InputShadow), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputShadow = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputShadow;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EmbossProperty = Binding.BindableProperty.Create(nameof(TextField.Emboss), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Emboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Emboss;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputEmbossProperty = Binding.BindableProperty.Create(nameof(TextField.InputEmboss), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputEmboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputEmboss;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OutlineProperty = Binding.BindableProperty.Create(nameof(TextField.Outline), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Outline = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Outline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputOutlineProperty = Binding.BindableProperty.Create(nameof(TextField.InputOutline), typeof(string), typeof(TextField), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.InputOutline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.InputOutline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HiddenInputSettingsProperty = Binding.BindableProperty.Create(nameof(TextField.HiddenInputSettings), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.HiddenInputSettings = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.HiddenInputSettings;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PixelSizeProperty = Binding.BindableProperty.Create(nameof(TextField.PixelSize), typeof(float), typeof(TextField), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.PixelSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.PixelSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableSelectionProperty = Binding.BindableProperty.Create(nameof(TextField.EnableSelection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.EnableSelection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.EnableSelection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderProperty = Binding.BindableProperty.Create(nameof(TextField.Placeholder), typeof(PropertyMap), typeof(TextField), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Placeholder = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Placeholder;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EllipsisProperty = Binding.BindableProperty.Create(nameof(TextField.Ellipsis), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.Ellipsis = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.Ellipsis;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableShiftSelectionProperty = Binding.BindableProperty.Create(nameof(TextField.EnableShiftSelection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.EnableShiftSelection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.EnableShiftSelection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MatchSystemLanguageDirectionProperty = Binding.BindableProperty.Create(nameof(TextField.MatchSystemLanguageDirection), typeof(bool), typeof(TextField), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textField = ((TextField)bindable).textField;
            textField.MatchSystemLanguageDirection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textField = ((TextField)bindable).textField;
            return textField.MatchSystemLanguageDirection;
        });

        /// <summary>
        /// The TextChanged event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                textField.TextChanged += value;
            }
            remove
            {
                textField.TextChanged -= value;
            }
        }

        /// <summary>
        /// The MaxLengthReached event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<MaxLengthReachedEventArgs> MaxLengthReached
        {
            add
            {
                textField.MaxLengthReached += value;
            }
            remove
            {
                textField.MaxLengthReached -= value;
            }
        }

        /// <summary>
        /// Get the InputMethodContext instance.
        /// </summary>
        /// <returns>The InputMethodContext instance.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext GetInputMethodContext()
        {
            return textField.GetInputMethodContext();
        }

        /// <summary>
        /// The TranslatableText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatableText
        {
            get
            {
                return textField.TranslatableText;
            }
            set
            {
                textField.TranslatableText = value;
            }
        }
        /// <summary>
        /// The TranslatablePlaceholderText property.<br />
        /// The text can set the SID value.<br />
        /// </summary>
        /// <exception cref='ArgumentNullException'>
        /// ResourceManager about multilingual is null.
        /// </exception>
        /// <since_tizen> 4 </since_tizen>
        public string TranslatablePlaceholderText
        {
            get
            {
                return textField.TranslatablePlaceholderText;
            }
            set
            {
                textField.TranslatablePlaceholderText = value;
            }
        }
 
        /// <summary>
        /// The Text property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(TextProperty, value);
            }
        }

        /// <summary>
        /// The PlaceholderText property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderText
        {
            get
            {
                return (string)GetValue(PlaceholderTextProperty);
            }
            set
            {
                SetValue(PlaceholderTextProperty, value);
            }
        }

        /// <summary>
        /// The PlaceholderTextFocused property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string PlaceholderTextFocused
        {
            get
            {
                return (string)GetValue(PlaceholderTextFocusedProperty);
            }
            set
            {
                SetValue(PlaceholderTextFocusedProperty, value);
            }
        }

        /// <summary>
        /// The FontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string FontFamily
        {
            get
            {
                return (string)GetValue(FontFamilyProperty);
            }
            set
            {
                SetValue(FontFamilyProperty, value);
            }
        }

        /// <summary>
        /// The FontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap FontStyle
        {
            get
            {
                return (PropertyMap)GetValue(FontStyleProperty);
            }
            set
            {
                SetValue(FontStyleProperty, value);
            }
        }

        /// <summary>
        /// The PointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PointSize
        {
            get
            {
                return (float)GetValue(PointSizeProperty);
            }
            set
            {
                SetValue(PointSizeProperty, value);
            }
        }

        /// <summary>
        /// The MaxLength property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int MaxLength
        {
            get
            {
                return (int)GetValue(MaxLengthProperty);
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        /// <summary>
        /// The ExceedPolicy property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int ExceedPolicy
        {
            get
            {
                return (int)GetValue(ExceedPolicyProperty);
            }
            set
            {
                SetValue(ExceedPolicyProperty, value);
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return (HorizontalAlignment)GetValue(HorizontalAlignmentProperty);
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
            }
        }

        /// <summary>
        /// The VerticalAlignment property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return (VerticalAlignment)GetValue(VerticalAlignmentProperty);
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
            }
        }

        /// <summary>
        /// The TextColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
            }
        }

        /// <summary>
        /// The PlaceholderTextColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PlaceholderTextColor
        {
            get
            {
                return (Vector4)GetValue(PlaceholderTextColorProperty);
            }
            set
            {
                SetValue(PlaceholderTextColorProperty, value);
            }
        }

        /// <summary>
        /// The ShadowOffset property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector2 ShadowOffset
        {
            get
            {
                return (Vector2)GetValue(ShadowOffsetProperty);
            }
            set
            {
                SetValue(ShadowOffsetProperty, value);
            }
        }

        /// <summary>
        /// The ShadowColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 ShadowColor
        {
            get
            {
                return (Vector4)GetValue(ShadowColorProperty);
            }
            set
            {
                SetValue(ShadowColorProperty, value);
            }
        }

        /// <summary>
        /// The PrimaryCursorColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 PrimaryCursorColor
        {
            get
            {
                return (Vector4)GetValue(PrimaryCursorColorProperty);
            }
            set
            {
                SetValue(PrimaryCursorColorProperty, value);
            }
        }

        /// <summary>
        /// The SecondaryCursorColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SecondaryCursorColor
        {
            get
            {
                return (Vector4)GetValue(SecondaryCursorColorProperty);
            }
            set
            {
                SetValue(SecondaryCursorColorProperty, value);
            }
        }

        /// <summary>
        /// The EnableCursorBlink property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableCursorBlink
        {
            get
            {
                return (bool)GetValue(EnableCursorBlinkProperty);
            }
            set
            {
                SetValue(EnableCursorBlinkProperty, value);
            }
        }

        /// <summary>
        /// The CursorBlinkInterval property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkInterval
        {
            get
            {
                return (float)GetValue(CursorBlinkIntervalProperty);
            }
            set
            {
                SetValue(CursorBlinkIntervalProperty, value);
            }
        }

        /// <summary>
        /// The CursorBlinkDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float CursorBlinkDuration
        {
            get
            {
                return (float)GetValue(CursorBlinkDurationProperty);
            }
            set
            {
                SetValue(CursorBlinkDurationProperty, value);
            }
        }

        /// <summary>
        /// The CursorWidth property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int CursorWidth
        {
            get
            {
                return (int)GetValue(CursorWidthProperty);
            }
            set
            {
                SetValue(CursorWidthProperty, value);
            }
        }

        /// <summary>
        /// The GrabHandleImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandleImage
        {
            get
            {
                return (string)GetValue(GrabHandleImageProperty);
            }
            set
            {
                SetValue(GrabHandleImageProperty, value);
            }
        }

        /// <summary>
        /// The GrabHandlePressedImage property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string GrabHandlePressedImage
        {
            get
            {
                return (string)GetValue(GrabHandlePressedImageProperty);
            }
            set
            {
                SetValue(GrabHandlePressedImageProperty, value);
            }
        }

        /// <summary>
        /// The ScrollThreshold property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollThreshold
        {
            get
            {
                return (float)GetValue(ScrollThresholdProperty);
            }
            set
            {
                SetValue(ScrollThresholdProperty, value);
            }
        }

        /// <summary>
        /// The ScrollSpeed property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollSpeed
        {
            get
            {
                return (float)GetValue(ScrollSpeedProperty);
            }
            set
            {
                SetValue(ScrollSpeedProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandleImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandleImageLeftProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandleImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandleImageRightProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandlePressedImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandlePressedImageLeftProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandlePressedImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandlePressedImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandlePressedImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandlePressedImageRightProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageLeft property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageLeft
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleMarkerImageLeftProperty);
            }
            set
            {
                SetValue(SelectionHandleMarkerImageLeftProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHandleMarkerImageRight property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap SelectionHandleMarkerImageRight
        {
            get
            {
                return (PropertyMap)GetValue(SelectionHandleMarkerImageRightProperty);
            }
            set
            {
                SetValue(SelectionHandleMarkerImageRightProperty, value);
            }
        }

        /// <summary>
        /// The SelectionHighlightColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 SelectionHighlightColor
        {
            get
            {
                return (Vector4)GetValue(SelectionHighlightColorProperty);
            }
            set
            {
                SetValue(SelectionHighlightColorProperty, value);
            }
        }

        /// <summary>
        /// The DecorationBoundingBox property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Rectangle DecorationBoundingBox
        {
            get
            {
                return (Rectangle)GetValue(DecorationBoundingBoxProperty);
            }
            set
            {
                SetValue(DecorationBoundingBoxProperty, value);
            }
        }

        /// <summary>
        /// The InputMethodSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputMethodSettings
        {
            get
            {
                return (PropertyMap)GetValue(InputMethodSettingsProperty);
            }
            set
            {
                SetValue(InputMethodSettingsProperty, value);
            }
        }

        /// <summary>
        /// The InputColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 InputColor
        {
            get
            {
                return (Vector4)GetValue(InputColorProperty);
            }
            set
            {
                SetValue(InputColorProperty, value);
            }
        }

        /// <summary>
        /// The EnableMarkup property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableMarkup
        {
            get
            {
                return (bool)GetValue(EnableMarkupProperty);
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
            }
        }

        /// <summary>
        /// The InputFontFamily property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputFontFamily
        {
            get
            {
                return (string)GetValue(InputFontFamilyProperty);
            }
            set
            {
                SetValue(InputFontFamilyProperty, value);
            }
        }

        /// <summary>
        /// The InputFontStyle property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap InputFontStyle
        {
            get
            {
                return (PropertyMap)GetValue(InputFontStyleProperty);
            }
            set
            {
                SetValue(InputFontStyleProperty, value);
            }
        }

        /// <summary>
        /// The InputPointSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float InputPointSize
        {
            get
            {
                return (float)GetValue(InputPointSizeProperty);
            }
            set
            {
                SetValue(InputPointSizeProperty, value);
            }
        }

        /// <summary>
        /// The Underline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Underline
        {
            get
            {
                return (PropertyMap)GetValue(UnderlineProperty);
            }
            set
            {
                SetValue(UnderlineProperty, value);
            }
        }

        /// <summary>
        /// The InputUnderline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputUnderline
        {
            get
            {
                return (string)GetValue(InputUnderlineProperty);
            }
            set
            {
                SetValue(InputUnderlineProperty, value);
            }
        }

        /// <summary>
        /// The Shadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Shadow
        {
            get
            {
                return (PropertyMap)GetValue(ShadowProperty);
            }
            set
            {
                SetValue(ShadowProperty, value);
            }
        }

        /// <summary>
        /// The InputShadow property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputShadow
        {
            get
            {
                return (string)GetValue(InputShadowProperty);
            }
            set
            {
                SetValue(InputShadowProperty, value);
            }
        }

        /// <summary>
        /// The Emboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string Emboss
        {
            get
            {
                return (string)GetValue(EmbossProperty);
            }
            set
            {
                SetValue(EmbossProperty, value);
            }
        }

        /// <summary>
        /// The InputEmboss property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputEmboss
        {
            get
            {
                return (string)GetValue(InputEmbossProperty);
            }
            set
            {
                SetValue(InputEmbossProperty, value);
            }
        }

        /// <summary>
        /// The Outline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Outline
        {
            get
            {
                return (PropertyMap)GetValue(OutlineProperty);
            }
            set
            {
                SetValue(OutlineProperty, value);
            }
        }

        /// <summary>
        /// The InputOutline property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public string InputOutline
        {
            get
            {
                return (string)GetValue(InputOutlineProperty);
            }
            set
            {
                SetValue(InputOutlineProperty, value);
            }
        }

        /// <summary>
        /// The HiddenInputSettings property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap HiddenInputSettings
        {
            get
            {
                return (PropertyMap)GetValue(HiddenInputSettingsProperty);
            }
            set
            {
                SetValue(HiddenInputSettingsProperty, value);
            }
        }

        /// <summary>
        /// The PixelSize property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float PixelSize
        {
            get
            {
                return (float)GetValue(PixelSizeProperty);
            }
            set
            {
                SetValue(PixelSizeProperty, value);
            }
        }

        /// <summary>
        /// The Enable selection property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableSelection
        {
            get
            {
                return (bool)GetValue(EnableSelectionProperty);
            }
            set
            {
                SetValue(EnableSelectionProperty, value);
            }
        }

        /// <summary>
        /// The Placeholder property.
        /// Gets or sets the placeholder: text, color, font family, font style, point size, and pixel size.
        /// </summary>
        /// <example>
        /// The following example demonstrates how to set the Placeholder property.
        /// <code>
        /// PropertyMap propertyMap = new PropertyMap();
        /// propertyMap.Add("text", new PropertyValue("Setting Placeholder Text"));
        /// propertyMap.Add("textFocused", new PropertyValue("Setting Placeholder Text Focused"));
        /// propertyMap.Add("color", new PropertyValue(Color.Red));
        /// propertyMap.Add("fontFamily", new PropertyValue("Arial"));
        /// propertyMap.Add("pointSize", new PropertyValue(12.0f));
        ///
        /// PropertyMap fontStyleMap = new PropertyMap();
        /// fontStyleMap.Add("weight", new PropertyValue("bold"));
        /// fontStyleMap.Add("width", new PropertyValue("condensed"));
        /// fontStyleMap.Add("slant", new PropertyValue("italic"));
        /// propertyMap.Add("fontStyle", new PropertyValue(fontStyleMap));
        ///
        /// TextField field = new TextField();
        /// field.Placeholder = propertyMap;
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public PropertyMap Placeholder
        {
            get
            {
                return (PropertyMap)GetValue(PlaceholderProperty);
            }
            set
            {
                SetValue(PlaceholderProperty, value);
            }
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// Placeholder PropertyMap is used to add ellipsis to placeholder text.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Ellipsis
        {
            get
            {
                return (bool)GetValue(EllipsisProperty);
            }
            set
            {
                SetValue(EllipsisProperty, value);
            }
        }

        /// <summary>
        /// Enables selection of the text using the Shift key.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableShiftSelection
        {
            get
            {
                return (bool)GetValue(EnableShiftSelectionProperty);
            }
            set
            {
                SetValue(EnableShiftSelectionProperty, value);
            }
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MatchSystemLanguageDirection
        {
            get
            {
                return (bool)GetValue(MatchSystemLanguageDirectionProperty);
            }
            set
            {
                SetValue(MatchSystemLanguageDirectionProperty, value);
            }
        }
    }
}
