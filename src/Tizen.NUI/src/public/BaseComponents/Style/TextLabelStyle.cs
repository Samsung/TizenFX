/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextLabelStyle : ViewStyle
    {
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create(nameof(TranslatableText), typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).translatableTextSelector = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).translatableTextSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = BindableProperty.Create(nameof(Text), typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).textSelector = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).textSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create(nameof(FontFamily), typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).fontFamilySelector = ((Selector<string>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).fontFamilySelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create(nameof(PointSize), typeof(Selector<float?>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).pointSizeSelector = ((Selector<float?>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).pointSizeSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create(nameof(TextColor), typeof(Selector<Color>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).textColorSelector = ((Selector<Color>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).textColorSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.multiLine = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.multiLine;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.horizontalAlignment = (HorizontalAlignment?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.horizontalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.verticalAlignment = (VerticalAlignment?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.verticalAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.enableMarkup = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.enableMarkup;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.enableAutoScroll = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.enableAutoScroll;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollSpeed = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollSpeed;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollLoopCount = (int?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollLoopCount;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollGap = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollGap;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.lineSpacing = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.lineSpacing;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.emboss = (string)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.emboss;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeSelectorProperty = BindableProperty.Create(nameof(PixelSize), typeof(Selector<float?>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).pixelSizeSelector = ((Selector<float?>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).pixelSizeSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.ellipsis = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.ellipsis;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollLoopDelay = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollLoopDelay;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollStopMode = (AutoScrollStopMode?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollStopMode;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.lineWrapMode = (LineWrapMode?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.lineWrapMode;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.verticalLineAlignment = (VerticalLineAlignment?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.verticalLineAlignment;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.matchSystemLanguageDirection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.matchSystemLanguageDirection;
        });
        /// A BindableProperty for ImageShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextShadowProperty = BindableProperty.Create(nameof(TextShadow), typeof(Selector<TextShadow>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            ((TextLabelStyle)bindable).textShadow = ((Selector<TextShadow>)newValue)?.Clone();
        },
        defaultValueCreator: (bindable) =>
        {
            return ((TextLabelStyle)bindable).textShadow;
        });
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.fontStyle = (PropertyMap)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.fontStyle;
        });

        private bool? multiLine;
        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private bool? enableMarkup;
        private bool? enableAutoScroll;
        private int? autoScrollSpeed;
        private int? autoScrollLoopCount;
        private float? autoScrollGap;
        private float? lineSpacing;
        private string emboss;
        private Selector<float?> pixelSizeSelector;
        private bool? ellipsis;
        private float? autoScrollLoopDelay;
        private AutoScrollStopMode? autoScrollStopMode;
        private LineWrapMode? lineWrapMode;
        private VerticalLineAlignment? verticalLineAlignment;
        private bool? matchSystemLanguageDirection;
        private Selector<string> translatableTextSelector;
        private Selector<string> fontFamilySelector;
        private Selector<string> textSelector;
        private Selector<Color> textColorSelector;
        private Selector<float?> pointSizeSelector;
        private Selector<TextShadow> textShadow;
        private PropertyMap fontStyle;

        static TextLabelStyle() { }

        /// <summary>
        /// Create an empty instance.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextLabelStyle() : base()
        {
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> TranslatableText
        {
            get
            {
                Selector<string> tmp = (Selector<string>)GetValue(TranslatableTextSelectorProperty);
                return (null != tmp) ? tmp : translatableTextSelector = new Selector<string>();
            }
            set => SetValue(TranslatableTextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> FontFamily
        {
            get
            {
                Selector<string> tmp = (Selector<string>)GetValue(FontFamilySelectorProperty);
                return (null != tmp) ? tmp : fontFamilySelector = new Selector<string>();
            }
            set => SetValue(FontFamilySelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MultiLine
        {
            get => (bool?)GetValue(MultiLineProperty);
            set => SetValue(MultiLineProperty, value);
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
        public bool? EnableMarkup
        {
            get => (bool?)GetValue(EnableMarkupProperty);
            set => SetValue(EnableMarkupProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutoScroll
        {
            get => (bool?)GetValue(EnableAutoScrollProperty);
            set => SetValue(EnableAutoScrollProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollSpeed
        {
            get => (int?)GetValue(AutoScrollSpeedProperty);
            set => SetValue(AutoScrollSpeedProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollLoopCount
        {
            get => (int?)GetValue(AutoScrollLoopCountProperty);
            set => SetValue(AutoScrollLoopCountProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollGap
        {
            get => (float?)GetValue(AutoScrollGapProperty);
            set => SetValue(AutoScrollGapProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get => (float?)GetValue(LineSpacingProperty);
            set => SetValue(LineSpacingProperty, value);
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
        public Selector<float?> PixelSize
        {
            get => (Selector<float?>)GetValue(PixelSizeSelectorProperty) ?? (pixelSizeSelector = new Selector<float?>());
            set => SetValue(PixelSizeSelectorProperty, value);
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
        public float? AutoScrollLoopDelay
        {
            get => (float?)GetValue(AutoScrollLoopDelayProperty);
            set => SetValue(AutoScrollLoopDelayProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutoScrollStopMode? AutoScrollStopMode
        {
            get => (AutoScrollStopMode?)GetValue(AutoScrollStopModeProperty);
            set => SetValue(AutoScrollStopModeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LineWrapMode? LineWrapMode
        {
            get => (LineWrapMode?)GetValue(LineWrapModeProperty);
            set => SetValue(LineWrapModeProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment? VerticalLineAlignment
        {
            get => (VerticalLineAlignment?)GetValue(VerticalLineAlignmentProperty);
            set => SetValue(VerticalLineAlignmentProperty, value);
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
        public Selector<string> Text
        {
            get
            {
                Selector<string> tmp = (Selector<string>)GetValue(TextSelectorProperty);
                return (null != tmp) ? tmp : textSelector = new Selector<string>();
            }
            set => SetValue(TextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> TextColor
        {
            get
            {
                Selector<Color> tmp = (Selector<Color>)GetValue(TextColorSelectorProperty);
                return (null != tmp) ? tmp : textColorSelector = new Selector<Color>();
            }
            set => SetValue(TextColorSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PointSize
        {
            get
            {
                Selector<float?> tmp = (Selector<float?>)GetValue(PointSizeSelectorProperty);
                return (null != tmp) ? tmp : pointSizeSelector = new Selector<float?>();
            }
            set => SetValue(PointSizeSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<TextShadow> TextShadow
        {
            get => (Selector<TextShadow>)GetValue(TextShadowProperty);
            set => SetValue(TextShadowProperty, value);
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
