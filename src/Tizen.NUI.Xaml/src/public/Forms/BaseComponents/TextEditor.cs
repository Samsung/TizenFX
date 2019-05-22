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
using static Tizen.NUI.BaseComponents.TextEditor;
using Tizen.NUI;

namespace Tizen.NUI.Xaml.Forms.BaseComponents
{
    /// <summary>
    /// A control which provides a multi-line editable text editor.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextEditor : View
    {
        private Tizen.NUI.BaseComponents.TextEditor _textEditor;
        internal Tizen.NUI.BaseComponents.TextEditor textEditor
        {
            get
            {
                if (null == _textEditor)
                {
                    _textEditor = handleInstance as Tizen.NUI.BaseComponents.TextEditor;
                }

                return _textEditor;
            }
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextEditor() : this(new Tizen.NUI.BaseComponents.TextEditor())
        {
        }

        internal TextEditor(Tizen.NUI.BaseComponents.TextEditor nuiInstance) : base(nuiInstance)
        {
            SetNUIInstance(nuiInstance);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TextProperty = Binding.BindableProperty.Create(nameof(Text), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Text = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Text;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty TextColorProperty = Binding.BindableProperty.Create(nameof(TextColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.TextColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.TextColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FontFamilyProperty = Binding.BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.FontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.FontFamily;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty FontStyleProperty = Binding.BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.FontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.FontStyle;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PointSizeProperty = Binding.BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.PointSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.PointSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty HorizontalAlignmentProperty = Binding.BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextEditor), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.HorizontalAlignment = (HorizontalAlignment)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.HorizontalAlignment;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollThresholdProperty = Binding.BindableProperty.Create(nameof(ScrollThreshold), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.ScrollThreshold = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.ScrollThreshold;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollSpeedProperty = Binding.BindableProperty.Create(nameof(ScrollSpeed), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.ScrollSpeed = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.ScrollSpeed;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PrimaryCursorColorProperty = Binding.BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.PrimaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.PrimaryCursorColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SecondaryCursorColorProperty = Binding.BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SecondaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SecondaryCursorColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableCursorBlinkProperty = Binding.BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.EnableCursorBlink = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.EnableCursorBlink;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorBlinkIntervalProperty = Binding.BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.CursorBlinkInterval = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.CursorBlinkInterval;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorBlinkDurationProperty = Binding.BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.CursorBlinkDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.CursorBlinkDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty CursorWidthProperty = Binding.BindableProperty.Create(nameof(CursorWidth), typeof(int), typeof(TextEditor), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.CursorWidth = (int)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.CursorWidth;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty GrabHandleImageProperty = Binding.BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.GrabHandleImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.GrabHandleImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty GrabHandlePressedImageProperty = Binding.BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.GrabHandlePressedImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.GrabHandlePressedImage;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleImageLeftProperty = Binding.BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandleImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandleImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleImageRightProperty = Binding.BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandleImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandleImageRight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandlePressedImageLeftProperty = Binding.BindableProperty.Create(nameof(SelectionHandlePressedImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandlePressedImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandlePressedImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandlePressedImageRightProperty = Binding.BindableProperty.Create(nameof(SelectionHandlePressedImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandlePressedImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandlePressedImageRight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleMarkerImageLeftProperty = Binding.BindableProperty.Create(nameof(SelectionHandleMarkerImageLeft), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandleMarkerImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandleMarkerImageLeft;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHandleMarkerImageRightProperty = Binding.BindableProperty.Create(nameof(SelectionHandleMarkerImageRight), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHandleMarkerImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHandleMarkerImageRight;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SelectionHighlightColorProperty = Binding.BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SelectionHighlightColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SelectionHighlightColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty DecorationBoundingBoxProperty = Binding.BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.DecorationBoundingBox = (Rectangle)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.DecorationBoundingBox;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableMarkupProperty = Binding.BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.EnableMarkup = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.EnableMarkup;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputColorProperty = Binding.BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputFontFamilyProperty = Binding.BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputFontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputFontFamily;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputFontStyleProperty = Binding.BindableProperty.Create(nameof(InputFontStyle), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputFontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputFontStyle;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputPointSizeProperty = Binding.BindableProperty.Create(nameof(InputPointSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputPointSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputPointSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LineSpacingProperty = Binding.BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.LineSpacing = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.LineSpacing;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputLineSpacingProperty = Binding.BindableProperty.Create(nameof(InputLineSpacing), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputLineSpacing = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputLineSpacing;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty UnderlineProperty = Binding.BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Underline = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Underline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputUnderlineProperty = Binding.BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputUnderline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputUnderline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ShadowProperty = Binding.BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Shadow = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Shadow;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputShadowProperty = Binding.BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputShadow = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputShadow;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EmbossProperty = Binding.BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Emboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Emboss;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputEmbossProperty = Binding.BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputEmboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputEmboss;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty OutlineProperty = Binding.BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Outline = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Outline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty InputOutlineProperty = Binding.BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.InputOutline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.InputOutline;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SmoothScrollProperty = Binding.BindableProperty.Create(nameof(SmoothScroll), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SmoothScroll = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SmoothScroll;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty SmoothScrollDurationProperty = Binding.BindableProperty.Create(nameof(SmoothScrollDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.SmoothScrollDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.SmoothScrollDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableScrollBarProperty = Binding.BindableProperty.Create(nameof(EnableScrollBar), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.EnableScrollBar = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.EnableScrollBar;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollBarShowDurationProperty = Binding.BindableProperty.Create(nameof(ScrollBarShowDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.ScrollBarShowDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.ScrollBarShowDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty ScrollBarFadeDurationProperty = Binding.BindableProperty.Create(nameof(ScrollBarFadeDuration), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.ScrollBarFadeDuration = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.ScrollBarFadeDuration;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PixelSizeProperty = Binding.BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextEditor), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.PixelSize = (float)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.PixelSize;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderTextProperty = Binding.BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextEditor), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.PlaceholderText = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.PlaceholderText;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderTextColorProperty = Binding.BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Color), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.PlaceholderTextColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.PlaceholderTextColor;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableSelectionProperty = Binding.BindableProperty.Create(nameof(EnableSelection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.EnableSelection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.EnableSelection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty PlaceholderProperty = Binding.BindableProperty.Create(nameof(Placeholder), typeof(PropertyMap), typeof(TextEditor), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.Placeholder = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.Placeholder;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty LineWrapModeProperty = Binding.BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextEditor), LineWrapMode.Word, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.LineWrapMode = (LineWrapMode)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.LineWrapMode;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty EnableShiftSelectionProperty = Binding.BindableProperty.Create(nameof(TextEditor.EnableShiftSelection), typeof(bool), typeof(TextEditor), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.EnableShiftSelection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.EnableShiftSelection;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly Binding.BindableProperty MatchSystemLanguageDirectionProperty = Binding.BindableProperty.Create(nameof(TextEditor.MatchSystemLanguageDirection), typeof(bool), typeof(TextEditor), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            textEditor.MatchSystemLanguageDirection = (bool)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textEditor = ((TextEditor)bindable).textEditor;
            return textEditor.MatchSystemLanguageDirection;
        });

        /// <summary>
        /// An event for the TextChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The TextChanged signal is emitted when the text changes.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<TextChangedEventArgs> TextChanged
        {
            add
            {
                textEditor.TextChanged += value;
            }
            remove
            {
                textEditor.TextChanged -= value;
            }
        }

        /// <summary>
        /// Event for the ScrollStateChanged signal which can be used to subscribe or unsubscribe the event handler
        /// provided by the user. The ScrollStateChanged signal is emitted when the scroll state changes.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ScrollStateChangedEventArgs> ScrollStateChanged
        {
            add
            {
                textEditor.ScrollStateChanged += value;
            }
            remove
            {
                textEditor.ScrollStateChanged -= value;
            }
        }

        /// <summary>
        /// Get the InputMethodContext instance.
        /// </summary>
        /// <returns>The InputMethodContext instance.</returns>
        /// <since_tizen> 5 </since_tizen>
        public InputMethodContext GetInputMethodContext()
        {
            return textEditor.GetInputMethodContext();
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
                return textEditor.TranslatableText;
            }
            set
            {
                textEditor.TranslatableText = value;
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
                return textEditor.TranslatablePlaceholderText;
            }
            set
            {
                textEditor.TranslatablePlaceholderText = value;
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
        /// The TextColor property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Vector4 TextColor
        {
            get
            {
                return (Vector4)GetValue(TextColorProperty);
            }
            set
            {
                SetValue(TextColorProperty, value);
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
        /// The LineSpacing property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float LineSpacing
        {
            get
            {
                return (float)GetValue(LineSpacingProperty);
            }
            set
            {
                SetValue(LineSpacingProperty, value);
            }
        }

        /// <summary>
        /// The InputLineSpacing property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float InputLineSpacing
        {
            get
            {
                return (float)GetValue(InputLineSpacingProperty);
            }
            set
            {
                SetValue(InputLineSpacingProperty, value);
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
        /// The SmoothScroll property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool SmoothScroll
        {
            get
            {
                return (bool)GetValue(SmoothScrollProperty);
            }
            set
            {
                SetValue(SmoothScrollProperty, value);
            }
        }

        /// <summary>
        /// The SmoothScrollDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float SmoothScrollDuration
        {
            get
            {
                return (float)GetValue(SmoothScrollDurationProperty);
            }
            set
            {
                SetValue(SmoothScrollDurationProperty, value);
            }
        }

        /// <summary>
        /// The EnableScrollBar property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableScrollBar
        {
            get
            {
                return (bool)GetValue(EnableScrollBarProperty);
            }
            set
            {
                SetValue(EnableScrollBarProperty, value);
            }
        }

        /// <summary>
        /// The ScrollBarShowDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollBarShowDuration
        {
            get
            {
                return (float)GetValue(ScrollBarShowDurationProperty);
            }
            set
            {
                SetValue(ScrollBarShowDurationProperty, value);
            }
        }

        /// <summary>
        /// The ScrollBarFadeDuration property.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float ScrollBarFadeDuration
        {
            get
            {
                return (float)GetValue(ScrollBarFadeDurationProperty);
            }
            set
            {
                SetValue(ScrollBarFadeDurationProperty, value);
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
        /// The line count of the text.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int LineCount
        {
            get
            {
                return textEditor.LineCount;
            }
        }

        /// <summary>
        /// The text to display when the TextEditor is empty and inactive.
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
        /// The Placeholder text color.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public Color PlaceholderTextColor
        {
            get
            {
                return (Color)GetValue(PlaceholderTextColorProperty);
            }
            set
            {
                SetValue(PlaceholderTextColorProperty, value);
            }
        }

        /// <summary>
        /// The EnableSelection property.
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
        /// The following example demonstrates how to set the placeholder property.
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
        /// TextEditor editor = new TextEditor();
        /// editor.Placeholder = propertyMap;
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
        /// The LineWrapMode property.<br />
        /// The line wrap mode when the text lines over the layout width.<br />
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public LineWrapMode LineWrapMode
        {
            get
            {
                return (LineWrapMode)GetValue(LineWrapModeProperty);
            }
            set
            {
                SetValue(LineWrapModeProperty, value);
            }
        }

        /// <summary>
        /// Enables Text selection using Shift key.
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
