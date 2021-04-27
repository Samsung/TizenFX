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
using System;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextFieldStyle : ViewStyle
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.fontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontFamily;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.pointSize = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.pointSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.textColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.textColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorProperty = BindableProperty.Create(nameof(PlaceholderTextColor), typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderTextColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorProperty = BindableProperty.Create(nameof(PrimaryCursorColor), typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.primaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.primaryCursorColor;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create(nameof(PlaceholderText), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderText = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderText;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextFocusedProperty = BindableProperty.Create(nameof(PlaceholderTextFocused), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.placeholderTextFocused = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextFocused;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create(nameof(MaxLength), typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.maxLength = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.maxLength;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ExceedPolicyProperty = BindableProperty.Create(nameof(ExceedPolicy), typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.exceedPolicy = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.exceedPolicy;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.horizontalAlignment = (HorizontalAlignment?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.horizontalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.verticalAlignment = (VerticalAlignment?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.verticalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create(nameof(SecondaryCursorColor), typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.secondaryCursorColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.secondaryCursorColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create(nameof(EnableCursorBlink), typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableCursorBlink = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableCursorBlink;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create(nameof(CursorBlinkInterval), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorBlinkInterval = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorBlinkInterval;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create(nameof(CursorBlinkDuration), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorBlinkDuration = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorBlinkDuration;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create(nameof(CursorWidth), typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorWidth = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorWidth;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleColorProperty = BindableProperty.Create(nameof(GrabHandleColor), typeof(Color), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandleColor = (Color)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandleColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create(nameof(GrabHandleImage), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandleImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandleImage;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create(nameof(GrabHandlePressedImage), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandlePressedImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandlePressedImage;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageLeftProperty = BindableProperty.Create(nameof(SelectionHandleImageLeft), typeof(PropertyMap), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHandleImageLeft = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHandleImageLeft;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHandleImageRightProperty = BindableProperty.Create(nameof(SelectionHandleImageRight), typeof(PropertyMap), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHandleImageRight = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHandleImageRight;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create(nameof(ScrollThreshold), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.scrollThreshold = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.scrollThreshold;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create(nameof(ScrollSpeed), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.scrollSpeed = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.scrollSpeed;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create(nameof(SelectionHighlightColor), typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.selectionHighlightColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.selectionHighlightColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create(nameof(DecorationBoundingBox), typeof(Rectangle), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.decorationBoundingBox = (Rectangle)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.decorationBoundingBox;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create(nameof(InputColor), typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputColor = (Vector4)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputColor;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableMarkup = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableMarkup;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create(nameof(InputFontFamily), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputFontFamily = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputFontFamily;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create(nameof(InputPointSize), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputPointSize = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputPointSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create(nameof(InputUnderline), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputUnderline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputUnderline;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputShadowProperty = BindableProperty.Create(nameof(InputShadow), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputShadow = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputShadow;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.emboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.emboss;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputEmbossProperty = BindableProperty.Create(nameof(InputEmboss), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputEmboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputEmboss;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty InputOutlineProperty = BindableProperty.Create(nameof(InputOutline), typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.inputOutline = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.inputOutline;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.pixelSize = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.pixelSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create(nameof(EnableSelection), typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.enableSelection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.enableSelection;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.ellipsis = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.ellipsis;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.matchSystemLanguageDirection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.matchSystemLanguageDirection;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.fontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontStyle;
        });

        private string placeholderText;
        private string placeholderTextFocused;
        private int? maxLength;
        private int? exceedPolicy;
        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private Vector4 secondaryCursorColor;
        private bool? enableCursorBlink;
        private float? cursorBlinkInterval;
        private float? cursorBlinkDuration;
        private int? cursorWidth;
        private Color grabHandleColor;
        private string grabHandleImage;
        private string grabHandlePressedImage;
        private PropertyMap selectionHandleImageLeft;
        private PropertyMap selectionHandleImageRight;
        private float? scrollThreshold;
        private float? scrollSpeed;
        private Vector4 selectionHighlightColor;
        private Rectangle decorationBoundingBox;
        private Vector4 inputColor;
        private bool? enableMarkup;
        private string inputFontFamily;
        private float? inputPointSize;
        private string inputUnderline;
        private string inputShadow;
        private string emboss;
        private string inputEmboss;
        private string inputOutline;
        private float? pixelSize;
        private bool? enableSelection;
        private bool? ellipsis;
        private bool? matchSystemLanguageDirection;
        private string fontFamily;
        private Color textColor;
        private float? pointSize;
        private Vector4 placeholderTextColor;
        private Vector4 primaryCursorColor;
        private PropertyMap fontStyle;

        static TextFieldStyle() { }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextFieldStyle() : base()
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderText
        {
            get => (string)GetValue(PlaceholderTextProperty);
            set => SetValue(PlaceholderTextProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderTextFocused
        {
            get => (string)GetValue(PlaceholderTextFocusedProperty);
            set => SetValue(PlaceholderTextFocusedProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily
        {
            get => (string)GetValue(FontFamilyProperty);
            set => SetValue(FontFamilyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? MaxLength
        {
            get => (int?)GetValue(MaxLengthProperty);
            set => SetValue(MaxLengthProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ExceedPolicy
        {
            get => (int?)GetValue(ExceedPolicyProperty);
            set => SetValue(ExceedPolicyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get => (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
            set => SetValue(HorizontalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get => (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
            set => SetValue(VerticalAlignmentProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get => (Vector4)GetValue(SecondaryCursorColorProperty);
            set => SetValue(SecondaryCursorColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get => (bool?)GetValue(EnableCursorBlinkProperty);
            set => SetValue(EnableCursorBlinkProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get => (float?)GetValue(CursorBlinkIntervalProperty);
            set => SetValue(CursorBlinkIntervalProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get => (float?)GetValue(CursorBlinkDurationProperty);
            set => SetValue(CursorBlinkDurationProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get => (int?)GetValue(CursorWidthProperty);
            set => SetValue(CursorWidthProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color GrabHandleColor
        {
            get => (Color)GetValue(GrabHandleColorProperty);
            set => SetValue(GrabHandleColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandleImage
        {
            get => (string)GetValue(GrabHandleImageProperty);
            set => SetValue(GrabHandleImageProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandlePressedImage
        {
            get => (string)GetValue(GrabHandlePressedImageProperty);
            set => SetValue(GrabHandlePressedImageProperty, value);
        }
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageLeft
        {
            get => (PropertyMap)GetValue(SelectionHandleImageLeftProperty);
            set => SetValue(SelectionHandleImageLeftProperty, value);
        }
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap SelectionHandleImageRight
        {
            get => (PropertyMap)GetValue(SelectionHandleImageRightProperty);
            set => SetValue(SelectionHandleImageRightProperty, value);
        }
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get => (float?)GetValue(ScrollThresholdProperty);
            set => SetValue(ScrollThresholdProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get => (float?)GetValue(ScrollSpeedProperty);
            set => SetValue(ScrollSpeedProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get => (Vector4)GetValue(SelectionHighlightColorProperty);
            set => SetValue(SelectionHighlightColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get => (Rectangle)GetValue(DecorationBoundingBoxProperty);
            set => SetValue(DecorationBoundingBoxProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get => (Vector4)GetValue(InputColorProperty);
            set => SetValue(InputColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get => (bool?)GetValue(EnableMarkupProperty);
            set => SetValue(EnableMarkupProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputFontFamily
        {
            get => (string)GetValue(InputFontFamilyProperty);
            set => SetValue(InputFontFamilyProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get => (float?)GetValue(InputPointSizeProperty);
            set => SetValue(InputPointSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputUnderline
        {
            get => (string)GetValue(InputUnderlineProperty);
            set => SetValue(InputUnderlineProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputShadow
        {
            get => (string)GetValue(InputShadowProperty);
            set => SetValue(InputShadowProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get => (string)GetValue(EmbossProperty);
            set => SetValue(EmbossProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputEmboss
        {
            get => (string)GetValue(InputEmbossProperty);
            set => SetValue(InputEmbossProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputOutline
        {
            get => (string)GetValue(InputOutlineProperty);
            set => SetValue(InputOutlineProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get => (float?)GetValue(PixelSizeProperty);
            set => SetValue(PixelSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get => (bool?)GetValue(EnableSelectionProperty);
            set => SetValue(EnableSelectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get => (bool?)GetValue(EllipsisProperty);
            set => SetValue(EllipsisProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get => (bool?)GetValue(MatchSystemLanguageDirectionProperty);
            set => SetValue(MatchSystemLanguageDirectionProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color TextColor
        {
            get => (Color)GetValue(TextColorProperty);
            set => SetValue(TextColorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize
        {
            get => (float?)GetValue(PointSizeProperty);
            set => SetValue(PointSizeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PlaceholderTextColor
        {
            get => (Vector4)GetValue(PlaceholderTextColorProperty);
            set => SetValue(PlaceholderTextColorProperty, value);
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 PrimaryCursorColor
        {
            get => (Vector4)GetValue(PrimaryCursorColorProperty);
            set => SetValue(PrimaryCursorColorProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontStyle
        {
            get => (PropertyMap)GetValue(FontStyleProperty);
            set => SetValue(FontStyleProperty, value);
        }
    }
}
