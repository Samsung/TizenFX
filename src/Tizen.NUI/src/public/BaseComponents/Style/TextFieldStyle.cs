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
        public static readonly BindableProperty TextSelectorProperty = BindableProperty.Create(nameof(Text), typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create("FontFamilySelector", typeof(Selector<string>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PlaceholderTextColorSelectorProperty = BindableProperty.Create("PlaceholderTextColorSelector", typeof(Selector<Vector4>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.placeholderTextColorSelector)
            {
                textFieldStyle.placeholderTextColorSelector = new Selector<Vector4>();
            }
            textFieldStyle.placeholderTextColorSelector.Clone((Selector<Vector4>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.placeholderTextColorSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PrimaryCursorColorSelectorProperty = BindableProperty.Create("PrimaryCursorColorSelector", typeof(Selector<Vector4>), typeof(TextFieldStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            if (null == textFieldStyle.primaryCursorColorSelector)
            {
                textFieldStyle.primaryCursorColorSelector = new Selector<Vector4>();
            }
            textFieldStyle.primaryCursorColorSelector.Clone((Selector<Vector4>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextFieldStyle)bindable;
            return textFieldStyle.primaryCursorColorSelector;
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
        private Selector<string> translatableTextSelector;
        private Selector<string> translatablePlaceholderTextSelector;
        private Selector<string> textSelector;
        private Selector<string> fontFamilySelector;
        private Selector<Color> textColorSelector;
        private Selector<float?> pointSizeSelector;
        private Selector<Vector4> placeholderTextColorSelector;
        private Selector<Vector4> primaryCursorColorSelector;

        static TextFieldStyle() { }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> TranslatableText
        {
            get => (Selector<string>)GetValue(TranslatableTextSelectorProperty);
            set => SetValue(TranslatableTextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> TranslatablePlaceholderText
        {
            get => (Selector<string>)GetValue(TranslatablePlaceholderTextSelectorProperty);
            set => SetValue(TranslatablePlaceholderTextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> Text
        {
            get => (Selector<string>)GetValue(TextSelectorProperty);
            set => SetValue(TextSelectorProperty, value);
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
        public Selector<string> FontFamily
        {
            get => (Selector<string>)GetValue(FontFamilySelectorProperty);
            set => SetValue(FontFamilySelectorProperty, value);
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
        public Selector<Color> TextColor
        {
            get => (Selector<Color>)GetValue(TextColorSelectorProperty);
            set => SetValue(TextColorSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PointSize
        {
            get => (Selector<float?>)GetValue(PointSizeSelectorProperty);
            set => SetValue(PointSizeSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Vector4> PlaceholderTextColor
        {
            get => (Selector<Vector4>)GetValue(PlaceholderTextColorSelectorProperty);
            set => SetValue(PlaceholderTextColorSelectorProperty, value);
        }

        /// <summary>
        /// Gets or sets primary cursor color.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Vector4> PrimaryCursorColor
        {
            get => (Selector<Vector4>)GetValue(PrimaryCursorColorSelectorProperty);
            set => SetValue(PrimaryCursorColorSelectorProperty, value);
        }
    }
}
