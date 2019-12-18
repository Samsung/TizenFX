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
    public class TextLabelStyle : ViewStyle
    {
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
        private float? pixelSize;
        private bool? ellipsis;
        private float? autoScrollLoopDelay;
        private AutoScrollStopMode? autoScrollStopMode;
        private LineWrapMode? lineWrapMode;
        private VerticalLineAlignment? verticalLineAlignment;
        private bool? matchSystemLanguageDirection;
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextSelectorProperty = BindableProperty.Create("TranslatableTextSelector", typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            textFieldStyle.TranslatableTextSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            return textFieldStyle.TranslatableTextSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = BindableProperty.Create("TextSelector", typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            textFieldStyle.TextSelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            return textFieldStyle.TextSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilySelectorProperty = BindableProperty.Create("FontFamilySelector", typeof(Selector<string>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            textFieldStyle.FontFamilySelector.Clone((Selector<string>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            return textFieldStyle.FontFamilySelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = BindableProperty.Create("PointSizeSelector", typeof(Selector<float?>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            textFieldStyle.PointSizeSelector.Clone((Selector<float?>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            return textFieldStyle.PointSizeSelector;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = BindableProperty.Create("TextColorSelector", typeof(Selector<Color>), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            textFieldStyle.TextColorSelector.Clone((Selector<Color>)newValue);
        },
        defaultValueCreator: (bindable) =>
        {
            var textFieldStyle = (TextLabelStyle)bindable;
            return textFieldStyle.TextColorSelector;
        });

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create("MultiLine", typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create("HorizontalAlignment", typeof(HorizontalAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create("VerticalAlignment", typeof(VerticalAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create("EnableMarkup", typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create("EnableAutoScroll", typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create("AutoScrollSpeed", typeof(int?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create("AutoScrollLoopCount", typeof(int?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create("AutoScrollGap", typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create("LineSpacing", typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create("Emboss", typeof(string), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create("PixelSize", typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.pixelSize = (float?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.pixelSize;
        });
        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create("Ellipsis", typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create("AutoScrollLoopDelay", typeof(float?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create("AutoScrollStopMode", typeof(AutoScrollStopMode?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create("LineWrapMode", typeof(LineWrapMode?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty VerticalLineAlignmentProperty = BindableProperty.Create("VerticalLineAlignment", typeof(VerticalLineAlignment?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
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
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create("MatchSystemLanguageDirection", typeof(bool?), typeof(TextLabelStyle), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.matchSystemLanguageDirection = (bool?)newValue;
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.matchSystemLanguageDirection;
        });

        private Selector<string> translatableTextSelector;
        private Selector<string> TranslatableTextSelector
        {
            get
            {
                if (null == translatableTextSelector)
                {
                    translatableTextSelector = new Selector<string>();
                }
                return translatableTextSelector;
            }
        }
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

        private Selector<string> fontFamilySelector;
        private Selector<string> FontFamilySelector
        {
            get
            {
                if (null == fontFamilySelector)
                {
                    fontFamilySelector = new Selector<string>();
                }
                return fontFamilySelector;
            }
        }
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
        public bool? MultiLine
        {
            get
            {
                bool? temp = (bool?)GetValue(MultiLineProperty);
                return temp;
            }
            set
            {
                SetValue(MultiLineProperty, value);
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
        public bool? EnableAutoScroll
        {
            get
            {
                bool? temp = (bool?)GetValue(EnableAutoScrollProperty);
                return temp;
            }
            set
            {
                SetValue(EnableAutoScrollProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollSpeed
        {
            get
            {
                int? temp = (int?)GetValue(AutoScrollSpeedProperty);
                return temp;
            }
            set
            {
                SetValue(AutoScrollSpeedProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollLoopCount
        {
            get
            {
                int? temp = (int?)GetValue(AutoScrollLoopCountProperty);
                return temp;
            }
            set
            {
                SetValue(AutoScrollLoopCountProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollGap
        {
            get
            {
                float? temp = (float?)GetValue(AutoScrollGapProperty);
                return temp;
            }
            set
            {
                SetValue(AutoScrollGapProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get
            {
                float? temp = (float?)GetValue(LineSpacingProperty);
                return temp;
            }
            set
            {
                SetValue(LineSpacingProperty, value);
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
        public float? AutoScrollLoopDelay
        {
            get
            {
                float? temp = (float?)GetValue(AutoScrollLoopDelayProperty);
                return temp;
            }
            set
            {
                SetValue(AutoScrollLoopDelayProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutoScrollStopMode? AutoScrollStopMode
        {
            get
            {
                AutoScrollStopMode? temp = (AutoScrollStopMode?)GetValue(AutoScrollStopModeProperty);
                return temp;
            }
            set
            {
                SetValue(AutoScrollStopModeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LineWrapMode? LineWrapMode
        {
            get
            {
                LineWrapMode? temp = (LineWrapMode?)GetValue(LineWrapModeProperty);
                return temp;
            }
            set
            {
                SetValue(LineWrapModeProperty, value);
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment? VerticalLineAlignment
        {
            get
            {
                VerticalLineAlignment? temp = (VerticalLineAlignment?)GetValue(VerticalLineAlignmentProperty);
                return temp;
            }
            set
            {
                SetValue(VerticalLineAlignmentProperty, value);
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

        private Selector<string> textSelector;
        private Selector<string> TextSelector
        {
            get
            {
                if (null == textSelector)
                {
                    textSelector = new Selector<string>();
                }
                return textSelector;
            }
        }
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

        private Selector<Color> textColorSelector;
        private Selector<Color> TextColorSelector
        {
            get
            {
                if (null == textColorSelector)
                {
                    textColorSelector = new Selector<Color>();
                }
                return textColorSelector;
            }
        }
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
        private Selector<float?> PointSizeSelector
        {
            get
            {
                if (null == pointSizeSelector)
                {
                    pointSizeSelector = new Selector<float?>();
                }
                return pointSizeSelector;
            }
        }
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
    }
}
