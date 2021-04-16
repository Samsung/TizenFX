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

extern alias TizenSystemSettings;
using System.ComponentModel;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// A control which renders a short text string.<br />
    /// Text labels are lightweight, non-editable, and do not respond to the user input.<br />
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public partial class TextLabel
    {
        /// <summary>
        /// StyleNameProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TranslatableTextProperty = BindableProperty.Create(nameof(TranslatableText), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<string> selector)
            {
                textLabel.TranslatableTextSelector = selector;
            }
            else
            {
                textLabel.selectorData?.TranslatableText?.Reset(textLabel);
                textLabel.SetTranslatableText((string)newValue);
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.translatableText;
        });
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<string> selector)
            {
                textLabel.TextSelector = selector;
            }
            else
            {
                textLabel.selectorData?.Text?.Reset(textLabel);
                textLabel.SetText((string)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TEXT).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<string> selector)
            {
                textLabel.FontFamilySelector = selector;
            }
            else
            {
                textLabel.selectorData?.FontFamily?.Reset(textLabel);
                textLabel.SetFontFamily((string)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontFamily).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = BindableProperty.Create(nameof(PointSize), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<float?> selector)
            {
                textLabel.PointSizeSelector = selector;
            }
            else
            {
                textLabel.selectorData?.PointSize?.Reset(textLabel);
                textLabel.SetPointSize((float?)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.PointSize).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MultiLine, new Tizen.NUI.PropertyValue((bool)newValue));
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MultiLine).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextLabel), HorizontalAlignment.Begin, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((HorizontalAlignment)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }
            return temp.GetValueByDescription<HorizontalAlignment>();
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextLabel), VerticalAlignment.Bottom, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            string valueToString = "";
            if (newValue != null)
            {
                valueToString = ((VerticalAlignment)newValue).GetDescription();
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment, new Tizen.NUI.PropertyValue(valueToString));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }

            return temp.GetValueByDescription<VerticalAlignment>();
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<Color> selector)
            {
                textLabel.TextColorSelector = selector;
            }
            else
            {
                textLabel.selectorData?.TextColor?.Reset(textLabel);
                textLabel.SetTextColor((Color)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextColor).Get(temp);
            return temp;
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableMarkup, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableMarkup).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int), typeof(TextLabel), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int), typeof(TextLabel), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineSpacing).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = BindableProperty.Create(nameof(Underline), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = BindableProperty.Create(nameof(Shadow), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextShadowProperty = BindableProperty.Create(nameof(TextShadow), typeof(TextShadow), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<TextShadow> selector)
            {
                textLabel.TextShadowSelector = selector;
            }
            else
            {
                textLabel.selectorData?.TextShadow?.Reset(textLabel);
                textLabel.SetTextShadow((TextShadow)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp.Empty() ? null : new TextShadow(temp);
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextLabel), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EMBOSS).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = BindableProperty.Create(nameof(Outline), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE).Get(temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = BindableProperty.Create(nameof(PixelSize), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;

            if (newValue is Selector<float?> selector)
            {
                textLabel.PixelSizeSelector = selector;
            }
            else
            {
                textLabel.selectorData?.PixelSize?.Reset(textLabel);
                textLabel.SetPixelSize((float?)newValue);
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.PixelSize).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay, new Tizen.NUI.PropertyValue((float)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay).Get(out temp);
            return temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode), typeof(TextLabel), AutoScrollStopMode.FinishLoop, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode).Get(out temp) == false)
            {
                NUILog.Error("AutoScrollStopMode get error!");
            }
            return temp.GetValueByDescription<AutoScrollStopMode>();
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextLabel), LineWrapMode.Word, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineWrapMode, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp;
            if (false == Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineWrapMode).Get(out temp))
            {
                NUILog.Error("LineWrapMode get error!");
            }
            return (LineWrapMode)temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment), typeof(TextLabel), VerticalLineAlignment.Bottom, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment).Get(out temp);
            return (VerticalLineAlignment)temp;
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection).Get(out temp);
            return temp;
        }));

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextFitProperty = BindableProperty.Create(nameof(TextFit), typeof(PropertyMap), typeof(TextLabel), null, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit).Get(temp);
            return temp;
        }));

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = BindableProperty.Create(nameof(MinLineSize), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MinLineSize, new Tizen.NUI.PropertyValue((float)newValue));
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MinLineSize).Get(out temp);
            return temp;
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                using (var property = new Tizen.NUI.PropertyValue((float)newValue))
                {
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontSizeScale, property);
                    textLabel.RequestLayout();
                }
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            float temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontSizeScale).Get(out temp);
            return temp;
        }));

        internal Selector<string> TranslatableTextSelector
        {
            get => GetSelector<string>(selectorData?.TranslatableText, TextLabel.TranslatableTextProperty);
            set
            {
                selectorData?.TranslatableText?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetTranslatableText(value.All);
                else EnsureSelectorData().TranslatableText = new TriggerableSelector<string>(this, value, SetTranslatableText, true);
            }
        }

        internal Selector<string> TextSelector
        {
            get => GetSelector<string>(selectorData?.Text, TextLabel.TextProperty);
            set
            {
                selectorData?.Text?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetText(value.All);
                else EnsureSelectorData().Text = new TriggerableSelector<string>(this, value, SetText, true);
            }
        }

        internal Selector<string> FontFamilySelector
        {
            get => GetSelector<string>(selectorData?.FontFamily, TextLabel.FontFamilyProperty);
            set
            {
                selectorData?.FontFamily?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetFontFamily(value.All);
                else EnsureSelectorData().FontFamily = new TriggerableSelector<string>(this, value, SetFontFamily, true);
            }
        }

        internal Selector<float?> PointSizeSelector
        {
            get => GetSelector<float?>(selectorData?.PointSize, TextLabel.PointSizeProperty);
            set
            {
                selectorData?.PointSize?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetPointSize(value.All);
                else EnsureSelectorData().PointSize = new TriggerableSelector<float?>(this, value, SetPointSize, true);
            }
        }

        internal Selector<Color> TextColorSelector
        {
            get
            {
                var selector =  selectorData?.TextColor?.Get();
                if (selector != null)
                {
                    return selector;
                }

                Color color = new Color();
                if (!GetProperty(TextLabel.Property.TextColor).Get(color))
                {
                    return null;
                }
                return new Selector<Color>(color);
            }
            set
            {
                selectorData?.TextColor?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetTextColor(value.All);
                else EnsureSelectorData().TextColor = new TriggerableSelector<Color>(this, value, SetTextColor, true);
            }
        }

        internal Selector<float?> PixelSizeSelector
        {
            get => GetSelector<float?>(selectorData?.PixelSize, TextLabel.PixelSizeProperty);
            set
            {
                selectorData?.PixelSize?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetPixelSize(value.All);
                else EnsureSelectorData().PixelSize = new TriggerableSelector<float?>(this, value, SetPixelSize, true);
            }
        }

        internal Selector<TextShadow> TextShadowSelector
        {
            get => GetSelector<TextShadow>(selectorData?.TextShadow, TextLabel.TextShadowProperty);
            set
            {
                selectorData?.TextShadow?.Reset(this);
                if (value == null) return;

                if (value.HasAll()) SetTextShadow(value.All);
                else EnsureSelectorData().TextShadow = new TriggerableSelector<TextShadow>(this, value, SetTextShadow);
            }
        }

        private void SetTranslatableText(string value)
        {
            if (value != null)
            {
                translatableText = value;
            }
        }

        private void SetText(string value)
        {
            if (value != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.TEXT, new Tizen.NUI.PropertyValue(value));
                RequestLayout();
            }
        }

        private void SetFontFamily(string value)
        {
            if (value != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.FontFamily, new Tizen.NUI.PropertyValue(value));
                RequestLayout();
            }
        }

        private void SetTextColor(Color value)
        {
            if (value != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.TextColor, new Tizen.NUI.PropertyValue(value));
            }
        }

        private void SetPointSize(float? value)
        {
            if (value != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.PointSize, new Tizen.NUI.PropertyValue((float)value));
                RequestLayout();
            }
        }

        private void SetPixelSize(float? value)
        {
            if (value != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.PixelSize, new Tizen.NUI.PropertyValue((float)value));
                RequestLayout();
            }
        }

        private void SetTextShadow(TextShadow value)
        {
            if (value != null)
            {
                Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, Property.SHADOW, TextShadow.ToPropertyValue(value));
            }
        }
    }
}
