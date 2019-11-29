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
        private string grabHandleImage;
        private string grabHandlePressedImage;
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
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create("TranslatableTextSelector", typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.translatableTextSelector)
            {
                textFieldStyle.translatableTextSelector = new Selector<string>();
            }
            textFieldStyle.translatableTextSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.translatableTextSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatablePlaceholderTextSelectorProperty = BindableProperty.Create("TranslatablePlaceholderTextSelector", typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.translatablePlaceholderTextSelector)
            {
                textFieldStyle.translatablePlaceholderTextSelector = new Selector<string>();
            }
            textFieldStyle.translatablePlaceholderTextSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.translatablePlaceholderTextSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = BindableProperty.Create("Text", typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.textSelector)
            {
                textFieldStyle.textSelector = new Selector<string>();
            }
            textFieldStyle.textSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.textSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create("FontFamily", typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.fontFamilySelector)
            {
                textFieldStyle.fontFamilySelector = new Selector<string>();
            }
            textFieldStyle.fontFamilySelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.fontFamilySelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create("PointSizeSelector", typeof(Selector<float?>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.pointSizeSelector)
            {
                textFieldStyle.pointSizeSelector = new Selector<float?>();
            }
            textFieldStyle.pointSizeSelector.Clone((Selector<float?>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.pointSizeSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create("TextColorSelector", typeof(Selector<Color>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.textColorSelector)
            {
                textFieldStyle.textColorSelector = new Selector<Color>();
            }
            textFieldStyle.textColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.textColorSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextColorSelectorProperty = BindableProperty.Create("PlaceholderTextColorSelector", typeof(Selector<Color>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.placeholderTextColorSelector)
            {
                textFieldStyle.placeholderTextColorSelector = new Selector<Color>();
            }
            textFieldStyle.placeholderTextColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextColorSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorSelectorProperty = BindableProperty.Create("PrimaryCursorColorSelector", typeof(Selector<Color>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.primaryCursorColorSelector)
            {
                textFieldStyle.primaryCursorColorSelector = new Selector<Color>();
            }
            textFieldStyle.primaryCursorColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.primaryCursorColorSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PlaceholderTextProperty = BindableProperty.Create("PlaceholderText", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PlaceholderTextFocusedProperty = BindableProperty.Create("PlaceholderTextFocused", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MaxLengthProperty = BindableProperty.Create("MaxLength", typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ExceedPolicyProperty = BindableProperty.Create("ExceedPolicy", typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create("HorizontalAlignment", typeof(HorizontalAlignment?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create("VerticalAlignment", typeof(VerticalAlignment?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SecondaryCursorColorProperty = BindableProperty.Create("SecondaryCursorColor", typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EnableCursorBlinkProperty = BindableProperty.Create("EnableCursorBlink", typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CursorBlinkIntervalProperty = BindableProperty.Create("CursorBlinkInterval", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CursorBlinkDurationProperty = BindableProperty.Create("CursorBlinkDuration", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty CursorWidthProperty = BindableProperty.Create("CursorWidth", typeof(int?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.cursorWidth = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.cursorWidth;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty GrabHandleImageProperty = BindableProperty.Create("GrabHandleImage", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty GrabHandlePressedImageProperty = BindableProperty.Create("GrabHandlePressedImage", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.grabHandlePressedImage = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.grabHandlePressedImage;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ScrollThresholdProperty = BindableProperty.Create("ScrollThreshold", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty ScrollSpeedProperty = BindableProperty.Create("ScrollSpeed", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty SelectionHighlightColorProperty = BindableProperty.Create("SelectionHighlightColor", typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty DecorationBoundingBoxProperty = BindableProperty.Create("DecorationBoundingBox", typeof(Rectangle), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputColorProperty = BindableProperty.Create("InputColor", typeof(Vector4), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create("EnableMarkup", typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputFontFamilyProperty = BindableProperty.Create("InputFontFamily", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputPointSizeProperty = BindableProperty.Create("InputPointSize", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputUnderlineProperty = BindableProperty.Create("InputUnderline", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputShadowProperty = BindableProperty.Create("InputShadow", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create("Emboss", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputEmbossProperty = BindableProperty.Create("InputEmboss", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty InputOutlineProperty = BindableProperty.Create("InputOutline", typeof(string), typeof(TextFieldStyle), String.Empty, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create("PixelSize", typeof(float?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EnableSelectionProperty = BindableProperty.Create("EnableSelection", typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create("Ellipsis", typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create("MatchSystemLanguageDirection", typeof(bool?), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            textFieldStyle.matchSystemLanguageDirection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.matchSystemLanguageDirection;
        });

        private Selector<string> translatableTextSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> TranslatableText
        {
            get
            {
                return (Selector<string>)GetValue(TranslatableTextSelectorProperty);
            }
            set
            {
                SetValue(TranslatableTextSelectorProperty, value);
            }
        }

        private Selector<string> translatablePlaceholderTextSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> TranslatablePlaceholderText
        {
            get
            {
                return (Selector<string>)GetValue(TranslatablePlaceholderTextSelectorProperty);
            }
            set
            {
                SetValue(TranslatablePlaceholderTextSelectorProperty, value);
            }
        }

        private Selector<string> textSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> Text
        {
            get
            {
                return (Selector<string>)GetValue(TextSelectorProperty);
            }
            set
            {
                SetValue(TextSelectorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderText
        {
            get
            {
                string temp = (string)GetValue(PlaceholderTextProperty);
                return temp;
            }
            set
            {
                SetValue(PlaceholderTextProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PlaceholderTextFocused
        {
            get
            {
                string temp = (string)GetValue(PlaceholderTextFocusedProperty);
                return temp;
            }
            set
            {
                SetValue(PlaceholderTextFocusedProperty, value);
            }
        }

        private Selector<string> fontFamilySelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> FontFamily
        {
            get
            {
                return (Selector<string>)GetValue(FontFamilySelectorProperty);
            }
            set
            {
                SetValue(FontFamilySelectorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? MaxLength
        {
            get
            {
                int? temp = (int?)GetValue(MaxLengthProperty);
                return temp;
            }
            set
            {
                SetValue(MaxLengthProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ExceedPolicy
        {
            get
            {
                int? temp = (int?)GetValue(ExceedPolicyProperty);
                return temp;
            }
            set
            {
                SetValue(ExceedPolicyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HorizontalAlignment? HorizontalAlignment
        {
            get
            {
                HorizontalAlignment? temp = (HorizontalAlignment?)GetValue(HorizontalAlignmentProperty);
                return temp;
            }
            set
            {
                SetValue(HorizontalAlignmentProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalAlignment? VerticalAlignment
        {
            get
            {
                VerticalAlignment? temp = (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
                return temp;
            }
            set
            {
                SetValue(VerticalAlignmentProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SecondaryCursorColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(SecondaryCursorColorProperty);
                return temp;
            }
            set
            {
                SetValue(SecondaryCursorColorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableCursorBlink
        {
            get
            {
                bool? temp = (bool?)GetValue(EnableCursorBlinkProperty);
                return temp;
            }
            set
            {
                SetValue(EnableCursorBlinkProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkInterval
        {
            get
            {
                float? temp = (float?)GetValue(CursorBlinkIntervalProperty);
                return temp;
            }
            set
            {
                SetValue(CursorBlinkIntervalProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CursorBlinkDuration
        {
            get
            {
                float? temp = (float?)GetValue(CursorBlinkDurationProperty);
                return temp;
            }
            set
            {
                SetValue(CursorBlinkDurationProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? CursorWidth
        {
            get
            {
                int? temp = (int?)GetValue(CursorWidthProperty);
                return temp;
            }
            set
            {
                SetValue(CursorWidthProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandleImage
        {
            get
            {
                string temp = (string)GetValue(GrabHandleImageProperty);
                return temp;
            }
            set
            {
                SetValue(GrabHandleImageProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GrabHandlePressedImage
        {
            get
            {
                string temp = (string)GetValue(GrabHandlePressedImageProperty);
                return temp;
            }
            set
            {
                SetValue(GrabHandlePressedImageProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollThreshold
        {
            get
            {
                float? temp = (float?)GetValue(ScrollThresholdProperty);
                return temp;
            }
            set
            {
                SetValue(ScrollThresholdProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? ScrollSpeed
        {
            get
            {
                float? temp = (float?)GetValue(ScrollSpeedProperty);
                return temp;
            }
            set
            {
                SetValue(ScrollSpeedProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 SelectionHighlightColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(SelectionHighlightColorProperty);
                return temp;
            }
            set
            {
                SetValue(SelectionHighlightColorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Rectangle DecorationBoundingBox
        {
            get
            {
                Rectangle temp = (Rectangle)GetValue(DecorationBoundingBoxProperty);
                return temp;
            }
            set
            {
                SetValue(DecorationBoundingBoxProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector4 InputColor
        {
            get
            {
                Vector4 temp = (Vector4)GetValue(InputColorProperty);
                return temp;
            }
            set
            {
                SetValue(InputColorProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get
            {
                bool? temp = (bool?)GetValue(EnableMarkupProperty);
                return temp;
            }
            set
            {
                SetValue(EnableMarkupProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputFontFamily
        {
            get
            {
                string temp = (string)GetValue(InputFontFamilyProperty);
                return temp;
            }
            set
            {
                SetValue(InputFontFamilyProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? InputPointSize
        {
            get
            {
                float? temp = (float?)GetValue(InputPointSizeProperty);
                return temp;
            }
            set
            {
                SetValue(InputPointSizeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputUnderline
        {
            get
            {
                string temp = (string)GetValue(InputUnderlineProperty);
                return temp;
            }
            set
            {
                SetValue(InputUnderlineProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputShadow
        {
            get
            {
                string temp = (string)GetValue(InputShadowProperty);
                return temp;
            }
            set
            {
                SetValue(InputShadowProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get
            {
                string temp = (string)GetValue(EmbossProperty);
                return temp;
            }
            set
            {
                SetValue(EmbossProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputEmboss
        {
            get
            {
                string temp = (string)GetValue(InputEmbossProperty);
                return temp;
            }
            set
            {
                SetValue(InputEmbossProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string InputOutline
        {
            get
            {
                string temp = (string)GetValue(InputOutlineProperty);
                return temp;
            }
            set
            {
                SetValue(InputOutlineProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize
        {
            get
            {
                float? temp = (float?)GetValue(PixelSizeProperty);
                return temp;
            }
            set
            {
                SetValue(PixelSizeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableSelection
        {
            get
            {
                bool? temp = (bool?)GetValue(EnableSelectionProperty);
                return temp;
            }
            set
            {
                SetValue(EnableSelectionProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get
            {
                bool? temp = (bool?)GetValue(EllipsisProperty);
                return temp;
            }
            set
            {
                SetValue(EllipsisProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get
            {
                bool? temp = (bool?)GetValue(MatchSystemLanguageDirectionProperty);
                return temp;
            }
            set
            {
                SetValue(MatchSystemLanguageDirectionProperty, value);
            }
        }

        private Selector<Color> textColorSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> TextColor
        {
            get
            {
                return (Selector<Color>)GetValue(TextColorSelectorProperty);
            }
            set
            {
                SetValue(TextColorSelectorProperty, value);
            }
        }

        private Selector<float?> pointSizeSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PointSize
        {
            get
            {
                return (Selector<float?>)GetValue(PointSizeSelectorProperty);
            }
            set
            {
                SetValue(PointSizeSelectorProperty, value);
            }
        }

        private Selector<Color> placeholderTextColorSelector;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> PlaceholderTextColor
        {
            get
            {
                return (Selector<Color>)GetValue(PlaceholderTextColorSelectorProperty);
            }
            set
            {
                SetValue(PlaceholderTextColorSelectorProperty, value);
            }
        }

        private Selector<Color> primaryCursorColorSelector;
        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> PrimaryCursorColor
        {
            get
            {
                return (Selector<Color>)GetValue(PrimaryCursorColorSelectorProperty);
            }
            set
            {
                SetValue(PrimaryCursorColorSelectorProperty, value);
            }
        }
    }
}
