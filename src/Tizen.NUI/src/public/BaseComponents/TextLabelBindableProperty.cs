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
        internal static void SetInternalTranslatableTextProperty(BindableObject bindable, string oldValue, string newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<string> selector)
            //{
            //    textLabel.TranslatableTextSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.TranslatableText?.Reset(textLabel);
                textLabel.SetTranslatableText((string)newValue);
            }
        }
        internal static string GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.translatableText;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextProperty = null;
        internal static void SetInternalTextProperty(BindableObject bindable, string oldValue, string newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<string> selector)
            //{
            //    textLabel.TextSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.Text?.Reset(textLabel);
                textLabel.SetText((string)newValue);
            }
        }
        internal static string GetInternalTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            // Do not try to get string if we know that previous text was empty.
            return textLabel.textIsEmpty ? "" : Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.TEXT);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilyProperty = null;
        internal static void SetInternalFontFamilyProperty(BindableObject bindable, string oldValue, string newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<string> selector)
            //{
            //    textLabel.FontFamilySelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.FontFamily?.Reset(textLabel);
                textLabel.SetFontFamily((string)newValue);
            }
        }
        internal static string GetInternalFontFamilyProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.InternalFontFamily;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, PropertyMap oldValue, PropertyMap newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle, new Tizen.NUI.PropertyValue(newValue));
                textLabel.RequestLayout();
            }
        }
        internal static PropertyMap GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.FontStyle).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeProperty = null;
        internal static void SetInternalPointSizeProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<float?> selector)
            //{
            //    textLabel.PointSizeSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.PointSize?.Reset(textLabel);
                textLabel.SetPointSize((float?)newValue);
            }
        }
        internal static float GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PointSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = null;
        internal static void SetInternalMultiLineProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine, (bool)newValue);
            textLabel.RequestLayout();
        }
        internal static bool GetInternalMultiLineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MultiLine);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, HorizontalAlignment oldValue, HorizontalAlignment newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.HorizontalAlignment, (int)newValue);
        }
        internal static HorizontalAlignment GetInternalHorizontalAlignmentProperty(BindableObject bindable)
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
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, VerticalAlignment oldValue, VerticalAlignment newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalAlignment, (int)newValue);
        }
        internal static VerticalAlignment GetInternalVerticalAlignmentProperty(BindableObject bindable)
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
        internal static void SetInternalTextColorProperty(BindableObject bindable, Color oldValue, Color newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<Color> selector)
            //{
            //    textLabel.TextColorSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.TextColor?.Reset(textLabel);
                textLabel.SetTextColor((Color)newValue);
            }
        }
        internal static Color GetInternalTextColorProperty(BindableObject bindable)
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
        internal static void SetInternalAnchorColorProperty(BindableObject bindable, Color oldValue, Color newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.AnchorColor, (newValue).SwigCPtr);
            }
        }
        internal static Color GetInternalAnchorColorProperty(BindableObject bindable)
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
        internal static void SetInternalAnchorClickedColorProperty(BindableObject bindable, Color oldValue, Color newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Object.InternalSetPropertyVector4(textLabel.SwigCPtr, TextLabel.Property.AnchorClickedColor, (newValue).SwigCPtr);
            }
        }
        internal static Color GetInternalAnchorClickedColorProperty(BindableObject bindable)
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
        internal static void SetInternalRemoveFrontInsetProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveFrontInset, newValue);
        }
        internal static bool GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveFrontInset);
        }

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = null;
        internal static void SetInternalRemoveBackInsetProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveBackInset, newValue);
        }
        internal static bool GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.RemoveBackInset);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;

            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup, newValue);
        }
        internal static bool GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableMarkup);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = null;
        internal static void SetInternalEnableAutoScrollProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;

            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll, newValue);
        }
        internal static bool GetInternalEnableAutoScrollProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableAutoScroll);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = null;
        internal static void SetInternalAutoScrollSpeedProperty(BindableObject bindable, int oldValue, int newValue)
        {
            var textLabel = (TextLabel)bindable;

            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed, newValue);
        }
        internal static int GetInternalAutoScrollSpeedProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollSpeed);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = null;
        internal static void SetInternalAutoScrollLoopCountProperty(BindableObject bindable, int oldValue, int newValue)
        {
            var textLabel = (TextLabel)bindable;

            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount, newValue);
        }
        internal static int GetInternalAutoScrollLoopCountProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopCount);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = null;
        internal static void SetInternalAutoScrollGapProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap, newValue);
        }
        internal static float GetInternalAutoScrollGapProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollGap);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing, newValue);
            textLabel.RequestLayout();
        }
        internal static float GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.LineSpacing);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight, newValue);
            }
        }
        internal static float GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.RelativeLineHeight);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        internal static void SetInternalUnderlineProperty(BindableObject bindable, PropertyMap oldValue, PropertyMap newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE, new Tizen.NUI.PropertyValue(newValue));
            }
        }
        internal static PropertyMap GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.UNDERLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        internal static void SetInternalShadowProperty(BindableObject bindable, PropertyMap oldValue, PropertyMap newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW, new Tizen.NUI.PropertyValue(newValue));
            }
        }
        internal static PropertyMap GetInternalShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextShadowProperty = null;
        internal static void SetInternalTextShadowProperty(BindableObject bindable, TextShadow oldValue, TextShadow newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<TextShadow> selector)
            //{
            //    textLabel.TextShadowSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.TextShadow?.Reset(textLabel);
                textLabel.SetTextShadow(newValue);
            }
        }
        internal static TextShadow GetInternalTextShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.SHADOW).Get(temp);
            return temp.Empty() ? null : new TextShadow(temp);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, string oldValue, string newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS, newValue);
            }
        }
        internal static string GetInternalEmbossProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.EMBOSS);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        internal static void SetInternalOutlineProperty(BindableObject bindable, PropertyMap oldValue, PropertyMap newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE, new Tizen.NUI.PropertyValue(newValue));
            }
        }
        internal static PropertyMap GetInternalOutlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.OUTLINE).Get(temp);
            return temp;
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeProperty = null;
        internal static void SetInternalPixelSizeProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;

            //if (newValue is Selector<float?> selector)
            //{
            //    textLabel.PixelSizeSelector = selector;
            //}
            //else
            {
                textLabel.selectorData?.PixelSize?.Reset(textLabel);
                textLabel.SetPixelSize((float?)newValue);
            }
        }
        internal static float GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.PixelSize);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;

            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS, newValue);
        }
        internal static bool GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.ELLIPSIS);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, EllipsisPosition oldValue, EllipsisPosition newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition, (int)newValue);
        }
        internal static EllipsisPosition GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (EllipsisPosition)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.EllipsisPosition);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = null;
        internal static void SetInternalAutoScrollLoopDelayProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay, (float)newValue);
        }
        internal static float GetInternalAutoScrollLoopDelayProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.AutoScrollLoopDelay);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = null;
        internal static void SetInternalAutoScrollStopModeProperty(BindableObject bindable, AutoScrollStopMode oldValue, AutoScrollStopMode newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode, (int)newValue);
        }
        internal static AutoScrollStopMode GetInternalAutoScrollStopModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            string temp;

            temp = Object.InternalGetPropertyString(textLabel.SwigCPtr, TextLabel.Property.AutoScrollStopMode);
            return temp.GetValueByDescription<AutoScrollStopMode>();
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, LineWrapMode oldValue, LineWrapMode newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode, (int)newValue);
        }
        internal static LineWrapMode GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (LineWrapMode)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.LineWrapMode);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = null;
        internal static void SetInternalVerticalLineAlignmentProperty(BindableObject bindable, VerticalLineAlignment oldValue, VerticalLineAlignment newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment, (int)newValue);
        }
        internal static VerticalLineAlignment GetInternalVerticalLineAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return (VerticalLineAlignment)Object.InternalGetPropertyInt(textLabel.SwigCPtr, TextLabel.Property.VerticalLineAlignment);
        }

        /// This will be public opened in tizen_5.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {

                Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection, newValue);
            }
        }
        internal static bool GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.MatchSystemLanguageDirection);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing, (float)newValue);
        }
        internal static float GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.CharacterSpacing);
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextFitProperty = null;
        internal static void SetInternalTextFitProperty(BindableObject bindable, PropertyMap oldValue, PropertyMap newValue)
        {
            var textLabel = (TextLabel)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit, new Tizen.NUI.PropertyValue(newValue));
            }
        }
        internal static PropertyMap GetInternalTextFitProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            PropertyMap temp = new PropertyMap();
            Tizen.NUI.Object.GetProperty((System.Runtime.InteropServices.HandleRef)textLabel.SwigCPtr, TextLabel.Property.TextFit).Get(temp);
            return temp;
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize, (float)newValue);
            textLabel.RequestLayout();
        }
        internal static float GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyFloat(textLabel.SwigCPtr, TextLabel.Property.MinLineSize);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var textLabel = (TextLabel)bindable;
            textLabel.InternalFontSizeScale = newValue;
        }
        internal static float GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.InternalFontSizeScale;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableFontSizeScaleProperty = null;
        internal static void SetInternalEnableFontSizeScaleProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale, (bool)newValue);
            textLabel.RequestLayout();
        }
        internal static bool GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;

            return Object.InternalGetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.EnableFontSizeScale);
        }

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = null;
        internal static void SetInternalShadowOffsetProperty(BindableObject bindable, Vector2 oldValue, Vector2 newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowOffset = (Tizen.NUI.Vector2)newValue;
            }
        }
        internal static Vector2 GetInternalShadowOffsetProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowOffset;
        }

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = null;
        internal static void SetInternalShadowColorProperty(BindableObject bindable, Vector4 oldValue, Vector4 newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalShadowColor = (Tizen.NUI.Vector4)newValue;
            }
        }
        internal static Vector4 GetInternalShadowColorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalShadowColor;
        }

        /// <summary>
        /// UnderlineEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineEnabledProperty = null;
        internal static void SetInternalUnderlineEnabledProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            instance.InternalUnderlineEnabled = (bool)newValue;
        }
        internal static bool GetInternalUnderlineEnabledProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineEnabled;
        }

        /// <summary>
        /// UnderlineColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineColorProperty = null;
        internal static void SetInternalUnderlineColorProperty(BindableObject bindable, Vector4 oldValue, Vector4 newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            if (newValue != null)
            {
                instance.InternalUnderlineColor = (Tizen.NUI.Vector4)newValue;
            }
        }
        internal static Vector4 GetInternalUnderlineColorProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineColor;
        }

        /// <summary>
        /// UnderlineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineHeightProperty = null;
        internal static void SetInternalUnderlineHeightProperty(BindableObject bindable, float oldValue, float newValue)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            instance.InternalUnderlineHeight = (float)newValue;
        }
        internal static float GetInternalUnderlineHeightProperty(BindableObject bindable)
        {
            var instance = (Tizen.NUI.BaseComponents.TextLabel)bindable;
            return instance.InternalUnderlineHeight;
        }

        /// <summary>
        /// CutoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CutoutProperty = null;
        internal static void SetInternalCutoutProperty(BindableObject bindable, bool oldValue, bool newValue)
        {
            var textLabel = (TextLabel)bindable;
            Object.InternalSetPropertyBool(textLabel.SwigCPtr, TextLabel.Property.Cutout, (bool)newValue);
        }
        internal static bool GetInternalCutoutProperty(BindableObject bindable)
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
