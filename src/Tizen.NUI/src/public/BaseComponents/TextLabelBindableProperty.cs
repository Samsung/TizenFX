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
        public static readonly BindableProperty TranslatableTextProperty = null;
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.translatableText;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            // Do not try to get string if we know that previous text was empty.
            return textLabel.textIsEmpty ? "" : Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.TEXT);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.InternalFontFamily;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
                textLabel.RequestLayout();
            }
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PointSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = null;
        internal static void SetInternalMultiLineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine, (bool)newValue);
                textLabel.RequestLayout();
            }
        }
        internal static object GetInternalMultiLineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment, (int)newValue);
            }
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment);
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
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment, (int)newValue);
            }
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment);
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
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorProperty = null;
        internal static void SetInternalTextColorProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            if (textLabel.internalTextColor == null)
            {
                textLabel.internalTextColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.TextColor, textLabel.internalTextColor.SwigCPtr);
            return textLabel.internalTextColor;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorColorProperty = null;
        internal static void SetInternalAnchorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.AnchorColor, ((Color)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalAnchorColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            if (textLabel.internalAnchorColor == null)
            {
                textLabel.internalAnchorColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.TextColor, textLabel.internalAnchorColor.SwigCPtr);
            return textLabel.internalAnchorColor;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorClickedColorProperty = null;
        internal static void SetInternalAnchorClickedColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.AnchorClickedColor, ((Color)newValue).SwigCPtr);
            }
        }
        internal static object GetInternalAnchorClickedColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            if (textLabel.internalAnchorClickedColor == null)
            {
                textLabel.internalAnchorClickedColor = new Color(0, 0, 0, 0);
            }
            Object.InternalRetrievingPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.TextColor, textLabel.internalAnchorClickedColor.SwigCPtr);
            return textLabel.internalAnchorClickedColor;
        }

        /// <summary>
        /// RemoveFrontInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveFrontInsetProperty = null;
        internal static void SetInternalRemoveFrontInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveFrontInset, (bool)newValue);
            }
        }
        internal static object GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveFrontInset);
        }

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = null;
        internal static void SetInternalRemoveBackInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveBackInset, (bool)newValue);
            }
        }
        internal static object GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveBackInset);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup, (bool)newValue);
            }
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = null;
        internal static void SetInternalEnableAutoScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll, (bool)newValue);
            }
        }
        internal static object GetInternalEnableAutoScrollProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = null;
        internal static void SetInternalAutoScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed, (int)newValue);
            }
        }
        internal static object GetInternalAutoScrollSpeedProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = null;
        internal static void SetInternalAutoScrollLoopCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount, (int)newValue);
            }
        }
        internal static object GetInternalAutoScrollLoopCountProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = null;
        internal static void SetInternalAutoScrollGapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap, (float)newValue);
            }
        }
        internal static object GetInternalAutoScrollGapProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing, (float)newValue);
                textLabel.RequestLayout();
            }
        }
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight, (float)newValue);
            }
        }
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextShadowProperty = null;
        internal static void SetInternalTextShadowProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalTextShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp.Empty() ? null : new TextShadow(temp);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS, (string)newValue);
            }
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, object oldValue, object newValue)
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
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PixelSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS, (bool)newValue);
            }
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition, (int)newValue);
            }
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (EllipsisPosition)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = null;
        internal static void SetInternalAutoScrollLoopDelayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay, (float)newValue);
            }
        }
        internal static object GetInternalAutoScrollLoopDelayProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = null;
        internal static void SetInternalAutoScrollStopModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode, (int)newValue);
            }
        }
        internal static object GetInternalAutoScrollStopModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode);
            return temp.GetValueByDescription<AutoScrollStopMode>();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode, (int)newValue);
            }
        }
        internal static object GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (LineWrapMode)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = null;
        internal static void SetInternalVerticalLineAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment, (int)newValue);
            }
        }
        internal static object GetInternalVerticalLineAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (VerticalLineAlignment)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection, (bool)newValue);
            }
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing, (float)newValue);
            }
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing);
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextFitProperty = null;
        internal static void SetInternalTextFitProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit, new Tizen.NUI.PropertyValue((PropertyMap)newValue));
            }
        }
        internal static object GetInternalTextFitProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit).Get(temp);
            return temp;
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize, (float)newValue);
                textLabel.RequestLayout();
            }
        }
        internal static object GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                textLabel.InternalFontSizeScale = (float)newValue;
            }
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.InternalFontSizeScale;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = null;
        internal static void SetInternalEnableFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale, (bool)newValue);
                textLabel.RequestLayout();
            }
        }
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale);
        }

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = null;
        internal static void SetInternalShadowOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowOffset = (Tizen.NUI.Vector2)newValue;
            }
        }
        internal static object GetInternalShadowOffsetProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowOffset;
        }

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = null;
        internal static void SetInternalShadowColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowColor = (Tizen.NUI.Vector4)newValue;
            }
        }
        internal static object GetInternalShadowColorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowColor;
        }

        /// <summary>
        /// UnderlineEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineEnabledProperty = null;
        internal static void SetInternalUnderlineEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineEnabled = (bool)newValue;
            }
        }
        internal static object GetInternalUnderlineEnabledProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineEnabled;
        }

        /// <summary>
        /// UnderlineColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineColorProperty = null;
        internal static void SetInternalUnderlineColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineColor = (Tizen.NUI.Vector4)newValue;
            }
        }
        internal static object GetInternalUnderlineColorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineColor;
        }

        /// <summary>
        /// UnderlineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineHeightProperty = null;
        internal static void SetInternalUnderlineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineHeight = (float)newValue;
            }
        }
        internal static object GetInternalUnderlineHeightProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineHeight;
        }

        /// <summary>
        /// CutoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CutoutProperty = null;
        internal static void SetInternalCutoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.Cutout, (bool)newValue);
            }
        }
        internal static object GetInternalCutoutProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.Cutout);
        }

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
                textIsEmpty = string.IsNullOrEmpty(value);

                Object.InternalSetPropertyString(SwigCPtr, TextLabel.Property.TEXT, value);
                RequestLayout();
            }
        }

        private void SetFontFamily(string value)
        {
            if (value != null)
            {
                InternalFontFamily = (string)value;
            }
        }

        private void SetTextColor(Color value)
        {
            if (value != null)
            {

                Object.InternalSetPropertyVector4(SwigCPtr, TextLabel.Property.TextColor, value.SwigCPtr);
            }
        }

        private void SetPointSize(float? value)
        {
            if (value != null)
            {

                Object.InternalSetPropertyFloat(SwigCPtr, TextLabel.Property.PointSize, (float)value);
                RequestLayout();
            }
        }

        private void SetPixelSize(float? value)
        {
            if (value != null)
            {

                Object.InternalSetPropertyFloat(SwigCPtr, TextLabel.Property.PixelSize, (float)value);
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
