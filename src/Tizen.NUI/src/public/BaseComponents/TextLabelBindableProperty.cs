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
                textLabel.SetInternalTranslatableText((string)newValue);
            }
        }
        internal static object GetInternalTranslatableTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalTranslatableText();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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
                textLabel.SetInternalText((string)newValue);
            }
        }
        internal static object GetInternalTextProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalText();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalFontStyle((PropertyMap)newValue);
            }
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalFontStyle();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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
                textLabel.SetInternalPointSize((float)newValue);
            }
        }
        internal static object GetInternalPointSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalPointSize();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = null;
        internal static void SetInternalMultiLineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalMultiLine((bool)newValue);
            }
        }
        internal static object GetInternalMultiLineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalMultiLine();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalHorizontalAlignment((HorizontalAlignment)newValue);
            }
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalHorizontalAlignment();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalVerticalAlignment((VerticalAlignment)newValue);
            }
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalVerticalAlignment();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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
                textLabel.SetInternalTextColor((Color)newValue);
            }
        }
        internal static object GetInternalTextColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalTextColor();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorColorProperty = null;
        internal static void SetInternalAnchorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAnchorColor((Color)newValue);
            }
        }
        internal static object GetInternalAnchorColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAnchorColor();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AnchorClickedColorProperty = null;
        internal static void SetInternalAnchorClickedColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAnchorClickedColor((Color)newValue);
            }
        }
        internal static object GetInternalAnchorClickedColorProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAnchorClickedColor();
        }

        /// <summary>
        /// RemoveFrontInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveFrontInsetProperty = null;
        internal static void SetInternalRemoveFrontInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalRemoveFrontInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveFrontInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalRemoveFrontInset();
        }

        /// <summary>
        /// RemoveBackInsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RemoveBackInsetProperty = null;
        internal static void SetInternalRemoveBackInsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalRemoveBackInset((bool)newValue);
            }
        }
        internal static object GetInternalRemoveBackInsetProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalRemoveBackInset();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEnableMarkup((bool)newValue);
            }
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEnableMarkup();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = null;
        internal static void SetInternalEnableAutoScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEnableAutoScroll((bool)newValue);
            }
        }
        internal static object GetInternalEnableAutoScrollProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEnableAutoScroll();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = null;
        internal static void SetInternalAutoScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAutoScrollSpeed((int)newValue);
            }
        }
        internal static object GetInternalAutoScrollSpeedProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAutoScrollSpeed();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = null;
        internal static void SetInternalAutoScrollLoopCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAutoScrollLoopCount((int)newValue);
            }
        }
        internal static object GetInternalAutoScrollLoopCountProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAutoScrollLoopCount();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = null;
        internal static void SetInternalAutoScrollGapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAutoScrollGap((float)newValue);
            }
        }
        internal static object GetInternalAutoScrollGapProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAutoScrollGap();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalLineSpacing((float)newValue);
            }
        }
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalLineSpacing();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalRelativeLineHeight((float)newValue);
            }
        }
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalRelativeLineHeight();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineProperty = null;
        internal static void SetInternalUnderlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalUnderline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalUnderlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalUnderline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowProperty = null;
        internal static void SetInternalShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalShadow((PropertyMap)newValue);
            }
        }
        internal static object GetInternalShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalShadow();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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
                textLabel.SetInternalTextShadow((TextShadow)newValue);
            }
        }
        internal static object GetInternalTextShadowProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalTextShadow();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEmboss((PropertyMap)newValue);
            }
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEmboss();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty OutlineProperty = null;
        internal static void SetInternalOutlineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalOutline((PropertyMap)newValue);
            }
        }
        internal static object GetInternalOutlineProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalOutline();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
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
                textLabel.SetInternalPixelSize((float)newValue);
            }
        }
        internal static object GetInternalPixelSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalPixelSize();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEllipsis((bool)newValue);
            }
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEllipsis();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEllipsisPosition((EllipsisPosition)newValue);
            }
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEllipsisPosition();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = null;
        internal static void SetInternalAutoScrollLoopDelayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAutoScrollLoopDelay((float)newValue);
            }
        }
        internal static object GetInternalAutoScrollLoopDelayProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAutoScrollLoopDelay();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = null;
        internal static void SetInternalAutoScrollStopModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalAutoScrollStopMode((AutoScrollStopMode)newValue);
            }
        }
        internal static object GetInternalAutoScrollStopModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalAutoScrollStopMode();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalLineWrapMode((LineWrapMode)newValue);
            }
        }
        internal static object GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalLineWrapMode();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = null;
        internal static void SetInternalVerticalLineAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalVerticalLineAlignment((VerticalLineAlignment)newValue);
            }
        }
        internal static object GetInternalVerticalLineAlignmentProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalVerticalLineAlignment();
        }

        /// This will be public opened after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalMatchSystemLanguageDirection((bool)newValue);
            }
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalMatchSystemLanguageDirection();
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalCharacterSpacing((float)newValue);
            }
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalCharacterSpacing();
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextFitProperty = null;
        internal static void SetInternalTextFitProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalTextFit((PropertyMap)newValue);
            }
        }
        internal static object GetInternalTextFitProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalTextFit();
        }

        /// Only for XAML. No need of public API. Make hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MinLineSizeProperty = null;
        internal static void SetInternalMinLineSizeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalMinLineSize((float)newValue);
            }
        }
        internal static object GetInternalMinLineSizeProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalMinLineSize();
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
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
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalEnableFontSizeScale((bool)newValue);
            }
        }
        internal static object GetInternalEnableFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalEnableFontSizeScale();
        }

        /// <summary>
        /// ShadowOffsetProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowOffsetProperty = null;
        internal static void SetInternalShadowOffsetProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextLabel)bindable;
                instance.InternalShadowOffset = (Vector2)newValue;
            }
        }
        internal static object GetInternalShadowOffsetProperty(BindableObject bindable)
        {
            var instance = (TextLabel)bindable;
            return instance.InternalShadowOffset;
        }

        /// <summary>
        /// ShadowColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty ShadowColorProperty = null;
        internal static void SetInternalShadowColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextLabel)bindable;
                instance.InternalShadowColor = (Vector4)newValue;
            }
        }
        internal static object GetInternalShadowColorProperty(BindableObject bindable)
        {
            var instance = (TextLabel)bindable;
            return instance.InternalShadowColor;
        }

        /// <summary>
        /// UnderlineEnabledProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineEnabledProperty = null;
        internal static void SetInternalUnderlineEnabledProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextLabel)bindable;
                instance.InternalUnderlineEnabled = (bool)newValue;
            }
        }
        internal static object GetInternalUnderlineEnabledProperty(BindableObject bindable)
        {
            var instance = (TextLabel)bindable;
            return instance.InternalUnderlineEnabled;
        }

        /// <summary>
        /// UnderlineColorProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineColorProperty = null;
        internal static void SetInternalUnderlineColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextLabel)bindable;
                instance.InternalUnderlineColor = (Vector4)newValue;
            }
        }
        internal static object GetInternalUnderlineColorProperty(BindableObject bindable)
        {
            var instance = (TextLabel)bindable;
            return instance.InternalUnderlineColor;
        }

        /// <summary>
        /// UnderlineHeightProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty UnderlineHeightProperty = null;
        internal static void SetInternalUnderlineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var instance = (TextLabel)bindable;
                instance.InternalUnderlineHeight = (float)newValue;
            }
        }
        internal static object GetInternalUnderlineHeightProperty(BindableObject bindable)
        {
            var instance = (TextLabel)bindable;
            return instance.InternalUnderlineHeight;
        }

        /// <summary>
        /// CutoutProperty
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CutoutProperty = null;
        internal static void SetInternalCutoutProperty(BindableObject bindable, object oldValue, object newValue)
        {
            if (newValue != null)
            {
                var textLabel = (TextLabel)bindable;
                textLabel.SetInternalCutout((bool)newValue);
            }
        }
        internal static object GetInternalCutoutProperty(BindableObject bindable)
        {
            var textLabel = (TextLabel)bindable;
            return textLabel.GetInternalCutout();
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
                using var prop = GetProperty(TextLabel.Property.TextColor);
                if (!prop.Get(color))
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
                InternalFontFamily = value;
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
                using var pv = TextShadow.ToPropertyValue(value);
                Object.SetProperty((System.Runtime.InteropServices.HandleRef)SwigCPtr, Property.SHADOW, pv);
            }
        }
    }
}
