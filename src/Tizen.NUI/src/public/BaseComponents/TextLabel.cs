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

extern alias TizenSystemSettings;
using TizenSystemSettings.Tizen.System;
using System;
using System.Globalization;
using System.ComponentModel;
using Tizen.NUI.Bindable;

namespace Tizen.NUI.BaseComponents
{

    /// <summary>
    /// A control which renders a short text string.<br />
    /// Text labels are lightweight, non-editable, and do not respond to the user input.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class TextLabel : View
    {
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.TEXT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.TEXT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.FONT_FAMILY, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.FONT_FAMILY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.FONT_STYLE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.FONT_STYLE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextLabel), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.POINT_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.POINT_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.MULTI_LINE, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.MULTI_LINE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextLabel), HorizontalAlignment.Begin, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((HorizontalAlignment)newValue)
                {
                    case HorizontalAlignment.Begin: { valueToString = "BEGIN"; break; }
                    case HorizontalAlignment.Center: { valueToString = "CENTER"; break; }
                    case HorizontalAlignment.End: { valueToString = "END"; break; }
                    default: { valueToString = "BEGIN"; break; }
                }
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.HORIZONTAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.HORIZONTAL_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }
            switch (temp)
            {
                case "BEGIN": return HorizontalAlignment.Begin;
                case "CENTER": return HorizontalAlignment.Center;
                case "END": return HorizontalAlignment.End;
                default: return HorizontalAlignment.Begin;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextLabel), VerticalAlignment.Bottom, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                switch ((VerticalAlignment)newValue)
                {
                    case VerticalAlignment.Top: { valueToString = "TOP"; break; }
                    case VerticalAlignment.Center: { valueToString = "CENTER"; break; }
                    case VerticalAlignment.Bottom: { valueToString = "BOTTOM"; break; }
                    default: { valueToString = "BOTTOM"; break; }
                }
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.VERTICAL_ALIGNMENT, new Tizen.NUI.PropertyValue(valueToString));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.VERTICAL_ALIGNMENT).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }

            switch (temp)
            {
                case "TOP": return VerticalAlignment.Top;
                case "CENTER": return VerticalAlignment.Center;
                case "BOTTOM": return VerticalAlignment.Bottom;
                default: return VerticalAlignment.Bottom;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.TEXT_COLOR, new Tizen.NUI.PropertyValue((Color)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.TEXT_COLOR).Get(temp);
            return temp;
        });

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.ENABLE_MARKUP, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.ENABLE_MARKUP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.ENABLE_AUTO_SCROLL, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.ENABLE_AUTO_SCROLL).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int), typeof(TextLabel), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_SPEED, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_SPEED).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int), typeof(TextLabel), default(int), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_LOOP_COUNT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_LOOP_COUNT).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float), typeof(TextLabel), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_GAP, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_GAP).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextLabel), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.LINE_SPACING, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.LINE_SPACING).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.UNDERLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.EMBOSS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.OUTLINE).Get(temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextLabel), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.PIXEL_SIZE, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.PIXEL_SIZE).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.ELLIPSIS, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.ELLIPSIS).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float), typeof(TextLabel), default(float), propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_LOOP_DELAY, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_LOOP_DELAY).Get(out temp);
            return temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode), typeof(TextLabel), AutoScrollStopMode.FinishLoop, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_STOP_MODE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.AUTO_SCROLL_STOP_MODE).Get(out temp) == false)
            {
                NUILog.Error("AutoScrollStopMode get error!");
            }
            switch (temp)
            {
                case "FINISH_LOOP": return AutoScrollStopMode.FinishLoop;
                case "IMMEDIATE": return AutoScrollStopMode.Immediate;
                default: return AutoScrollStopMode.FinishLoop;
            }
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextLabel), LineWrapMode.Word, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.LINE_WRAP_MODE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp;
            if (false == Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.LINE_WRAP_MODE).Get(out temp))
            {
                NUILog.Error("LineWrapMode get error!");
            }
            return (LineWrapMode)temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment), typeof(TextLabel), VerticalLineAlignment.Bottom, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.VERTICAL_LINE_ALIGNMENT, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.VERTICAL_LINE_ALIGNMENT).Get(out temp);
            return (VerticalLineAlignment)temp;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(textLabel.swigCPtr, TextLabel.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty(textLabel.swigCPtr, TextLabel.Property.MATCH_SYSTEM_LANGUAGE_DIRECTION).Get(out temp);
            return temp;
        });

        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        private string textLabelSid = null;
        private bool systemlangTextFlag = false;

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel() : this(Interop.TextLabel.TextLabel_New__SWIG_0(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates the TextLabel control.
        /// </summary>
        /// <param name="text">The text to display</param>
        /// <since_tizen> 3 </since_tizen>
        public TextLabel(string text) : this(Interop.TextLabel.TextLabel_New__SWIG_1(text), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TextLabel(TextLabel handle) : this(Interop.TextLabel.new_TextLabel__SWIG_1(TextLabel.getCPtr(handle)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal TextLabel(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.TextLabel.TextLabel_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);
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
                return textLabelSid;
            }
            set
            {
                if (NUIApplication.MultilingualResourceManager == null)
                {
                    throw new ArgumentNullException("ResourceManager about multilingual is null");
                }
                string translatableText = null;
                textLabelSid = value;
                translatableText = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(SystemSettings.LocaleLanguage.Replace("_", "-")));
                if (translatableText != null)
                {
                    Text = translatableText;
                    if (systemlangTextFlag == false)
                    {
                        SystemSettings.LocaleLanguageChanged += new WeakEventHandler<LocaleLanguageChangedEventArgs>(SystemSettings_LocaleLanguageChanged).Handler;
                        systemlangTextFlag = true;
                    }
                }
                else
                {
                    Text = "";
                }
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Text property.<br />
        /// The text to display in the UTF-8 format.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontFamily property.<br />
        /// The requested font family to use.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The FontStyle property.<br />
        /// The requested font style to use.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PointSize property.<br />
        /// The size of font in points.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The MultiLine property.<br />
        /// The single-line or multi-line layout option.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool MultiLine
        {
            get
            {
                return (bool)GetValue(MultiLineProperty);
            }
            set
            {
                SetValue(MultiLineProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The HorizontalAlignment property.<br />
        /// The line horizontal alignment.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The VerticalAlignment property.<br />
        /// The line vertical alignment.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The TextColor property.<br />
        /// The color of the text.<br />
        /// Animation framework can be used to change the color of the text when not using mark up.<br />
        /// Cannot animate the color when text is auto scrolling.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowOffset property.<br />
        /// The drop shadow offset 0 indicates no shadow.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// </remarks>
        [Obsolete("Please do not use this ShadowOffset(Deprecated). Please use Shadow instead.")]
        public Vector2 ShadowOffset
        {
            get
            {
                Vector2 shadowOffset = new Vector2();
                Shadow.Find(TextLabel.Property.SHADOW, "offset")?.Get(shadowOffset);
                return shadowOffset;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("offset", new PropertyValue(value));

                PropertyMap shadowMap = Shadow;
                shadowMap.Merge(temp);

                SetValue(ShadowProperty, shadowMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The ShadowColor property.<br />
        /// The color of a drop shadow.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Shadow instead.
        /// </remarks>
        [Obsolete("Please do not use this ShadowColor(Deprecated). Please use Shadow instead.")]
        public Vector4 ShadowColor
        {
            get
            {
                Vector4 shadowColor = new Vector4();
                Shadow.Find(TextLabel.Property.SHADOW, "color")?.Get(shadowColor);
                return shadowColor;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("color", new PropertyValue(value));

                PropertyMap shadowMap = Shadow;
                shadowMap.Merge(temp);

                SetValue(ShadowProperty, shadowMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The UnderlineEnabled property.<br />
        /// The underline enabled flag.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineEnabled(Deprecated). Please use Underline instead.")]
        public bool UnderlineEnabled
        {
            get
            {
                bool underlineEnabled = false;
                Underline.Find(TextLabel.Property.UNDERLINE, "enable")?.Get(out underlineEnabled);
                return underlineEnabled;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Add("enable", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();

            }
        }

        /// <summary>
        /// The UnderlineColor property.<br />
        /// Overrides the underline height from font metrics.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineColor(Deprecated). Please use Underline instead.")]
        public Vector4 UnderlineColor
        {
            get
            {
                Vector4 underlineColor = new Vector4();
                Underline.Find(TextLabel.Property.UNDERLINE, "color")?.Get(underlineColor);
                return underlineColor;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("color", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The UnderlineHeight property.<br />
        /// Overrides the underline height from font metrics.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// Deprecated.(API Level 6) Use Underline instead.
        /// </remarks>
        [Obsolete("Please do not use this UnderlineHeight(Deprecated). Please use Underline instead.")]
        public float UnderlineHeight
        {
            get
            {
                float underlineHeight = 0.0f;
                Underline.Find(TextLabel.Property.UNDERLINE, "height")?.Get(out underlineHeight);
                return underlineHeight;
            }
            set
            {
                PropertyMap temp = new PropertyMap();
                temp.Insert("height", new PropertyValue(value));

                PropertyMap undelineMap = Underline;
                undelineMap.Merge(temp);

                SetValue(UnderlineProperty, undelineMap);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableMarkup property.<br />
        /// Whether the mark-up processing is enabled.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The EnableAutoScroll property.<br />
        /// Starts or stops auto scrolling.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool EnableAutoScroll
        {
            get
            {
                return (bool)GetValue(EnableAutoScrollProperty);
            }
            set
            {
                SetValue(EnableAutoScrollProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollSpeed property.<br />
        /// Sets the speed of scrolling in pixels per second.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoScrollSpeed
        {
            get
            {
                return (int)GetValue(AutoScrollSpeedProperty);
            }
            set
            {
                SetValue(AutoScrollSpeedProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollLoopCount property.<br />
        /// Number of complete loops when scrolling enabled.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int AutoScrollLoopCount
        {
            get
            {
                return (int)GetValue(AutoScrollLoopCountProperty);
            }
            set
            {
                SetValue(AutoScrollLoopCountProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollGap property.<br />
        /// Gap before scrolling wraps.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AutoScrollGap
        {
            get
            {
                return (float)GetValue(AutoScrollGapProperty);
            }
            set
            {
                SetValue(AutoScrollGapProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The LineSpacing property.<br />
        /// The default extra space between lines in points.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Underline property.<br />
        /// The default underline parameters.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Shadow property.<br />
        /// The default shadow parameters.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Emboss property.<br />
        /// The default emboss parameters.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Outline property.<br />
        /// The default outline parameters.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The PixelSize property.<br />
        /// The size of font in pixels.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The Ellipsis property.<br />
        /// Enable or disable the ellipsis.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public bool Ellipsis
        {
            get
            {
                return (bool)GetValue(EllipsisProperty);
            }
            set
            {
                SetValue(EllipsisProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollLoopDelay property.<br />
        /// Do something.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public float AutoScrollLoopDelay
        {
            get
            {
                return (float)GetValue(AutoScrollLoopDelayProperty);
            }
            set
            {
                SetValue(AutoScrollLoopDelayProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The AutoScrollStopMode property.<br />
        /// Do something.<br />
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public AutoScrollStopMode AutoScrollStopMode
        {
            get
            {
                return (AutoScrollStopMode)GetValue(AutoScrollStopModeProperty);
            }
            set
            {
                SetValue(AutoScrollStopModeProperty, value);
                NotifyPropertyChanged();
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
                int temp = 0;
                GetProperty(TextLabel.Property.LINE_COUNT).Get(out temp);
                return temp;
            }
        }

        /// <summary>
        /// The LineWrapMode property.<br />
        /// line wrap mode when the text lines over layout width.<br />
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
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The direction of the text such as left to right or right to left.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public TextDirection TextDirection
        {
            get
            {
                int temp = 0;
                GetProperty(TextLabel.Property.TEXT_DIRECTION).Get(out temp);
                return (TextDirection)temp;
            }
        }

        /// <summary>
        /// The vertical line alignment of the text.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        /// This will be released at Tizen.NET API Level 5, so currently this would be used as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment VerticalLineAlignment
        {
            get
            {
                return (VerticalLineAlignment)GetValue(VerticalLineAlignmentProperty);
            }
            set
            {
                SetValue(VerticalLineAlignmentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The text alignment to match the direction of the system language.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool MatchSystemLanguageDirection
        {
            get
            {
                return (bool)GetValue(MatchSystemLanguageDirectionProperty);
            }
            set
            {
                SetValue(MatchSystemLanguageDirectionProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Downcasts a handle to textLabel handle
        /// </summary>
        /// <param name="handle"></param>
        /// <returns></returns>
        /// <since_tizen> 3 </since_tizen>
        /// Please do not use! this will be deprecated!
        /// Instead please use as keyword.
        [Obsolete("Please do not use! This will be deprecated! Please use as keyword instead! " +
            "Like: " +
            "BaseHandle handle = new TextLabel(\"Hello World!\"); " +
            "TextLabel label = handle as TextLabel")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static TextLabel DownCast(BaseHandle handle)
        {
            TextLabel ret = Registry.GetManagedBaseHandleFromNativePtr(handle) as TextLabel;

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(TextLabel obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        /// <summary>
        /// Dispose.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.TextLabel.delete_TextLabel(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

<<<<<<< HEAD
        /// <summary>
        /// Invoked whenever the binding context of the textlabel changes. Implement this method to add class handling for this event.
        /// </summary>
        /// Deprecated. Do not use.
        protected void OnBindingContextChanged()
        {

        }

=======
>>>>>>> 879c90160b45de49b52f1b8c1359572feadd8a6b
        private void SystemSettings_LocaleLanguageChanged(object sender, LocaleLanguageChangedEventArgs e)
        {
            Text = NUIApplication.MultilingualResourceManager?.GetString(textLabelSid, new CultureInfo(e.Value.Replace("_", "-")));
        }

        internal new class Property
        {
            internal static readonly int RENDERING_BACKEND = Interop.TextLabel.TextLabel_Property_RENDERING_BACKEND_get();
            internal static readonly int TEXT = Interop.TextLabel.TextLabel_Property_TEXT_get();
            internal static readonly int FONT_FAMILY = Interop.TextLabel.TextLabel_Property_FONT_FAMILY_get();
            internal static readonly int FONT_STYLE = Interop.TextLabel.TextLabel_Property_FONT_STYLE_get();
            internal static readonly int POINT_SIZE = Interop.TextLabel.TextLabel_Property_POINT_SIZE_get();
            internal static readonly int MULTI_LINE = Interop.TextLabel.TextLabel_Property_MULTI_LINE_get();
            internal static readonly int HORIZONTAL_ALIGNMENT = Interop.TextLabel.TextLabel_Property_HORIZONTAL_ALIGNMENT_get();
            internal static readonly int VERTICAL_ALIGNMENT = Interop.TextLabel.TextLabel_Property_VERTICAL_ALIGNMENT_get();
            internal static readonly int TEXT_COLOR = Interop.TextLabel.TextLabel_Property_TEXT_COLOR_get();
            internal static readonly int ENABLE_MARKUP = Interop.TextLabel.TextLabel_Property_ENABLE_MARKUP_get();
            internal static readonly int ENABLE_AUTO_SCROLL = Interop.TextLabel.TextLabel_Property_ENABLE_AUTO_SCROLL_get();
            internal static readonly int AUTO_SCROLL_SPEED = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_SPEED_get();
            internal static readonly int AUTO_SCROLL_LOOP_COUNT = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_LOOP_COUNT_get();
            internal static readonly int AUTO_SCROLL_GAP = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_GAP_get();
            internal static readonly int LINE_SPACING = Interop.TextLabel.TextLabel_Property_LINE_SPACING_get();
            internal static readonly int UNDERLINE = Interop.TextLabel.TextLabel_Property_UNDERLINE_get();
            internal static readonly int SHADOW = Interop.TextLabel.TextLabel_Property_SHADOW_get();
            internal static readonly int EMBOSS = Interop.TextLabel.TextLabel_Property_EMBOSS_get();
            internal static readonly int OUTLINE = Interop.TextLabel.TextLabel_Property_OUTLINE_get();
            internal static readonly int PIXEL_SIZE = Interop.TextLabel.TextLabel_Property_PIXEL_SIZE_get();
            internal static readonly int ELLIPSIS = Interop.TextLabel.TextLabel_Property_ELLIPSIS_get();
            internal static readonly int AUTO_SCROLL_STOP_MODE = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_STOP_MODE_get();
            internal static readonly int AUTO_SCROLL_LOOP_DELAY = Interop.TextLabel.TextLabel_Property_AUTO_SCROLL_LOOP_DELAY_get();
            internal static readonly int LINE_COUNT = Interop.TextLabel.TextLabel_Property_LINE_COUNT_get();
            internal static readonly int LINE_WRAP_MODE = Interop.TextLabel.TextLabel_Property_LINE_WRAP_MODE_get();
            internal static readonly int TEXT_DIRECTION = Interop.TextLabel.TextLabel_Property_TEXT_DIRECTION_get();
            internal static readonly int VERTICAL_LINE_ALIGNMENT = Interop.TextLabel.TextLabel_Property_VERTICAL_LINE_ALIGNMENT_get();
            internal static readonly int MATCH_SYSTEM_LANGUAGE_DIRECTION = Interop.TextLabel.TextLabel_Property_MATCH_SYSTEM_LANGUAGE_DIRECTION_get();
        }
    }
}
