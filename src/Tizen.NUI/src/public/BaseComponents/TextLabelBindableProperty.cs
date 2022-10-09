﻿/*
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
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.TEXT);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TEXT).Get(out temp);
            return temp;
#endif            
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
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.FontFamily);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontFamily).Get(out temp);
            return temp;
#endif            
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
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PointSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.PointSize).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MultiLine, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MultiLine).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment), typeof(TextLabel), HorizontalAlignment.Begin, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
#if NUI_PROPERTY_CHANGE_2
            temp = Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment);
#else
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment).Get(out temp) == false)
            {
                NUILog.Error("HorizontalAlignment get error!");
            }
#endif
            if (System.String.IsNullOrEmpty(temp))
            {
                return HorizontalAlignment.Begin; // Return default value.
            }

            if (temp.Equals("BEGIN"))
            {
                return HorizontalAlignment.Begin;
            }
            else if (temp.Equals("CENTER"))
            {
                return HorizontalAlignment.Center;
            }
            else
            {
                return HorizontalAlignment.End;
            }
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment), typeof(TextLabel), VerticalAlignment.Bottom, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
#if NUI_PROPERTY_CHANGE_2
            temp = Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment);
#else
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment).Get(out temp) == false)
            {
                NUILog.Error("VerticalAlignment get error!");
            }
#endif
            if (System.String.IsNullOrEmpty(temp))
            {
                return VerticalAlignment.Top; // Return default value.
            }

            if (temp.Equals("TOP"))
            {
                return VerticalAlignment.Top;
            }
            else if (temp.Equals("CENTER"))
            {
                return VerticalAlignment.Center;
            }
            else
            {
                return VerticalAlignment.Bottom;
            }
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
#if NUI_PROPERTY_CHANGE_2
            if (textLabel.internalTextColor == null)
            {
                textLabel.internalTextColor = new Color(0, 0, 0, 0);
            }
            Interop.Actor.InternalRetrievingPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.TextColor, textLabel.internalTextColor.SwigCPtr);
            return textLabel.internalTextColor;
#else
            Color temp = new Color(0.0f, 0.0f, 0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextColor).Get(temp);
            return temp;
#endif
        }));

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableMarkup, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableMarkup).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int), typeof(TextLabel), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int), typeof(TextLabel), default(int), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap).Get(out temp);
            return temp;
#endif            
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineSpacing, new Tizen.NUI.PropertyValue((float)newValue));
#endif
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineSpacing).Get(out temp);
            return temp;
#endif
        }));
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight).Get(out temp);
            return temp;
#endif
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
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS, (string)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EMBOSS, new Tizen.NUI.PropertyValue((string)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS);
#else
            string temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EMBOSS).Get(out temp);
            return temp;
#endif
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
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PixelSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.PixelSize).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = BindableProperty.Create(nameof(EllipsisPosition), typeof(EllipsisPosition), typeof(TextLabel), EllipsisPosition.End, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return (EllipsisPosition)Interop.Actor.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition).Get(out temp);
            return (EllipsisPosition)temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode), typeof(TextLabel), AutoScrollStopMode.FinishLoop, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
            string temp;
#if NUI_PROPERTY_CHANGE_2
            temp = Interop.Actor.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode);
#else
            if (Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode).Get(out temp) == false)
            {
                NUILog.Error("AutoScrollStopMode get error!");
            }
#endif
            return temp.GetValueByDescription<AutoScrollStopMode>();
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode), typeof(TextLabel), LineWrapMode.Word, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineWrapMode, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return (LineWrapMode)Interop.Actor.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode);
#else
            int temp;
            if (false == Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.LineWrapMode).Get(out temp))
            {
                NUILog.Error("LineWrapMode get error!");
            }
            return (LineWrapMode)temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment), typeof(TextLabel), VerticalLineAlignment.Bottom, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment, (int)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment, new Tizen.NUI.PropertyValue((int)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return (VerticalLineAlignment)Interop.Actor.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment);
#else
            int temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment).Get(out temp);
            return (VerticalLineAlignment)temp;
#endif
        }));
        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool), typeof(TextLabel), false, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection, (bool)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection, new Tizen.NUI.PropertyValue((bool)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection);
#else
            bool temp = false;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection).Get(out temp);
            return temp;
#endif
        }));
        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing, new Tizen.NUI.PropertyValue((float)newValue));
#endif
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing);
#else
            float temp = 0;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing).Get(out temp);
            return temp;
#endif
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
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize, (float)newValue);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MinLineSize, new Tizen.NUI.PropertyValue((float)newValue));
#endif
                textLabel.RequestLayout();
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize);
#else
            float temp = 0.0f;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.MinLineSize).Get(out temp);
            return temp;
#endif        
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float), typeof(TextLabel), default(float), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.FontSizeScale, (float)newValue);
                textLabel.RequestLayout();
#else
                using (var property = new Tizen.NUI.PropertyValue((float)newValue))
                {
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontSizeScale, property);
                    textLabel.RequestLayout();
                }
#endif                
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.FontSizeScale);
#else
            float temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontSizeScale).Get(out temp);
            return temp;
#endif
        }));

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = BindableProperty.Create(nameof(EnableFontSizeScale), typeof(bool), typeof(TextLabel), default(bool), propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale, (bool)newValue);
                textLabel.RequestLayout();
#else
                using (var property = new Tizen.NUI.PropertyValue((bool)newValue))
                {
                    Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale, property);
                    textLabel.RequestLayout();
                }
#endif                
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var textLabel = (TextLabel)bindable;
#if NUI_PROPERTY_CHANGE_2
            return Interop.Actor.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale);
#else
            bool temp;
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale).Get(out temp);
            return temp;
#endif
        }));

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = BindableProperty.Create(nameof(ShadowOffset), typeof(Tizen.NUI.Vector2), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowOffset = (Tizen.NUI.Vector2)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowOffset;
        });

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = BindableProperty.Create(nameof(ShadowColor), typeof(Tizen.NUI.Vector4), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowColor = (Tizen.NUI.Vector4)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowColor;
        });

        /// <summary>
        /// UnderlineEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineEnabledProperty = BindableProperty.Create(nameof(UnderlineEnabled), typeof(bool), typeof(TextLabel), false, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineEnabled = (bool)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineEnabled;
        });

        /// <summary>
        /// UnderlineColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineColorProperty = BindableProperty.Create(nameof(UnderlineColor), typeof(Tizen.NUI.Vector4), typeof(TextLabel), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineColor = (Tizen.NUI.Vector4)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineColor;
        });

        /// <summary>
        /// UnderlineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineHeightProperty = BindableProperty.Create(nameof(UnderlineHeight), typeof(float), typeof(TextLabel), 0.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineHeight = (float)newValue;
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineHeight;
        });

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
                var selector = selectorData?.TextColor?.Get();
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
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyString(SwigCPtr, TextLabel.Property.TEXT, value);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.TEXT, new Tizen.NUI.PropertyValue(value));
#endif
                RequestLayout();
            }
        }

        private void SetFontFamily(string value)
        {
            if (value != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyString(SwigCPtr, TextLabel.Property.FontFamily, value);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.FontFamily, new Tizen.NUI.PropertyValue(value));
#endif
                RequestLayout();
            }
        }

        private void SetTextColor(Color value)
        {
            if (value != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyVector4(SwigCPtr, TextLabel.Property.TextColor, value.SwigCPtr);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.TextColor, new Tizen.NUI.PropertyValue(value));
#endif
            }
        }

        private void SetPointSize(float? value)
        {
            if (value != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(SwigCPtr, TextLabel.Property.PointSize, (float)value);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.PointSize, new Tizen.NUI.PropertyValue((float)value));
#endif
                RequestLayout();
            }
        }

        private void SetPixelSize(float? value)
        {
            if (value != null)
            {
#if NUI_PROPERTY_CHANGE_2
                Interop.Actor.InternalSetPropertyFloat(SwigCPtr, TextLabel.Property.PixelSize, (float)value);
#else
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, TextLabel.Property.PixelSize, new Tizen.NUI.PropertyValue((float)value));
#endif
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
