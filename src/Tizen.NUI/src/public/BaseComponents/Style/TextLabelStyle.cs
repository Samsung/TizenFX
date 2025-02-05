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
        public static readonly BindableProperty TranslatableTextSelectorProperty = null;
        internal static void SetInternalTranslatableTextSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).translatableTextSelector = ((Selector<string>)newValue)?.Clone();
        }
        internal static object GetInternalTranslatableTextSelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).translatableTextSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextSelectorProperty = null;
        internal static void SetInternalTextSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).textSelector = ((Selector<string>)newValue)?.Clone();
        }
        internal static object GetInternalTextSelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).textSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontFamilySelectorProperty = null;
        internal static void SetInternalFontFamilySelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).fontFamilySelector = ((Selector<string>)newValue)?.Clone();
        }
        internal static object GetInternalFontFamilySelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).fontFamilySelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PointSizeSelectorProperty = null;
        internal static void SetInternalPointSizeSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).pointSizeSelector = ((Selector<float?>)newValue)?.Clone();
        }
        internal static object GetInternalPointSizeSelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).pointSizeSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextColorSelectorProperty = null;
        internal static void SetInternalTextColorSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).textColorSelector = ((Selector<Color>)newValue)?.Clone();
        }
        internal static object GetInternalTextColorSelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).textColorSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MultiLineProperty = null;
        internal static void SetInternalMultiLineProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.multiLine = (bool?)newValue;
        }
        internal static object GetInternalMultiLineProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.multiLine;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty HorizontalAlignmentProperty = null;
        internal static void SetInternalHorizontalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.horizontalAlignment = (HorizontalAlignment?)newValue;
        }
        internal static object GetInternalHorizontalAlignmentProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.horizontalAlignment;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalAlignmentProperty = null;
        internal static void SetInternalVerticalAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.verticalAlignment = (VerticalAlignment?)newValue;
        }
        internal static object GetInternalVerticalAlignmentProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.verticalAlignment;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableMarkupProperty = null;
        internal static void SetInternalEnableMarkupProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.enableMarkup = (bool?)newValue;
        }
        internal static object GetInternalEnableMarkupProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.enableMarkup;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EnableAutoScrollProperty = null;
        internal static void SetInternalEnableAutoScrollProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.enableAutoScroll = (bool?)newValue;
        }
        internal static object GetInternalEnableAutoScrollProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.enableAutoScroll;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollSpeedProperty = null;
        internal static void SetInternalAutoScrollSpeedProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollSpeed = (int?)newValue;
        }
        internal static object GetInternalAutoScrollSpeedProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollSpeed;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopCountProperty = null;
        internal static void SetInternalAutoScrollLoopCountProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollLoopCount = (int?)newValue;
        }
        internal static object GetInternalAutoScrollLoopCountProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollLoopCount;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollGapProperty = null;
        internal static void SetInternalAutoScrollGapProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollGap = (float?)newValue;
        }
        internal static object GetInternalAutoScrollGapProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollGap;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineSpacingProperty = null;
        internal static void SetInternalLineSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.lineSpacing = (float?)newValue;
        }
        internal static object GetInternalLineSpacingProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.lineSpacing;
        }

        /// <summary> The bindable property of RelativeLineHeightProperty. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty RelativeLineHeightProperty = null;
        internal static void SetInternalRelativeLineHeightProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.relativeLineHeight = (float?)newValue;
        }
        internal static object GetInternalRelativeLineHeightProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.relativeLineHeight;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EmbossProperty = null;
        internal static void SetInternalEmbossProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.emboss = (string)newValue;
        }
        internal static object GetInternalEmbossProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.emboss;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty PixelSizeSelectorProperty = null;
        internal static void SetInternalPixelSizeSelectorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).pixelSizeSelector = ((Selector<float?>)newValue)?.Clone();
        }
        internal static object GetInternalPixelSizeSelectorProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).pixelSizeSelector;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisProperty = null;
        internal static void SetInternalEllipsisProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.ellipsis = (bool?)newValue;
        }
        internal static object GetInternalEllipsisProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.ellipsis;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollLoopDelayProperty = null;
        internal static void SetInternalAutoScrollLoopDelayProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollLoopDelay = (float?)newValue;
        }
        internal static object GetInternalAutoScrollLoopDelayProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollLoopDelay;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty AutoScrollStopModeProperty = null;
        internal static void SetInternalAutoScrollStopModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.autoScrollStopMode = (AutoScrollStopMode?)newValue;
        }
        internal static object GetInternalAutoScrollStopModeProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.autoScrollStopMode;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty LineWrapModeProperty = null;
        internal static void SetInternalLineWrapModeProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.lineWrapMode = (LineWrapMode?)newValue;
        }
        internal static object GetInternalLineWrapModeProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.lineWrapMode;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty VerticalLineAlignmentProperty = null;
        internal static void SetInternalVerticalLineAlignmentProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.verticalLineAlignment = (VerticalLineAlignment?)newValue;
        }
        internal static object GetInternalVerticalLineAlignmentProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.verticalLineAlignment;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty EllipsisPositionProperty = null;
        internal static void SetInternalEllipsisPositionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.ellipsisPosition = (EllipsisPosition?)newValue;
        }
        internal static object GetInternalEllipsisPositionProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.ellipsisPosition;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty CharacterSpacingProperty = null;
        internal static void SetInternalCharacterSpacingProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.characterSpacing = (float?)newValue;
        }
        internal static object GetInternalCharacterSpacingProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.characterSpacing;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontSizeScaleProperty = null;
        internal static void SetInternalFontSizeScaleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.fontSizeScale = (float?)newValue;
        }
        internal static object GetInternalFontSizeScaleProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.fontSizeScale;
        }

        public static readonly BindableProperty AnchorColorProperty = null;
        internal static void SetInternalAnchorColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.anchorColor = (Color)newValue;
        }
        internal static object GetInternalAnchorColorProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.anchorColor;
        }

        public static readonly BindableProperty AnchorClickedColorProperty = null;
        internal static void SetInternalAnchorClickedColorProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.anchorClickedColor = (Color)newValue;
        }
        internal static object GetInternalAnchorClickedColorProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.anchorClickedColor;
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty MatchSystemLanguageDirectionProperty = null;
        internal static void SetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.matchSystemLanguageDirection = (bool?)newValue;
        }
        internal static object GetInternalMatchSystemLanguageDirectionProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.matchSystemLanguageDirection;
        }

        /// A BindableProperty for ImageShadow
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty TextShadowProperty = null;
        internal static void SetInternalTextShadowProperty(BindableObject bindable, object oldValue, object newValue)
        {
            ((TextLabelStyle)bindable).textShadow = ((Selector<TextShadow>)newValue)?.Clone();
        }
        internal static object GetInternalTextShadowProperty(BindableObject bindable)
        {
            return ((TextLabelStyle)bindable).textShadow;
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static readonly BindableProperty FontStyleProperty = null;
        internal static void SetInternalFontStyleProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            textLabelStyle.fontStyle = (PropertyMap)newValue;
        }
        internal static object GetInternalFontStyleProperty(BindableObject bindable)
        {
            var textLabelStyle = (TextLabelStyle)bindable;
            return textLabelStyle.fontStyle;
        }

        private bool? multiLine;
        private HorizontalAlignment? horizontalAlignment;
        private VerticalAlignment? verticalAlignment;
        private bool? enableMarkup;
        private bool? enableAutoScroll;
        private int? autoScrollSpeed;
        private int? autoScrollLoopCount;
        private float? autoScrollGap;
        private float? lineSpacing;
        private float? relativeLineHeight;
        private string emboss;
        private Selector<float?> pixelSizeSelector;
        private bool? ellipsis;
        private float? autoScrollLoopDelay;
        private AutoScrollStopMode? autoScrollStopMode;
        private LineWrapMode? lineWrapMode;
        private VerticalLineAlignment? verticalLineAlignment;
        private EllipsisPosition? ellipsisPosition;
        private bool? matchSystemLanguageDirection;
        private Selector<string> translatableTextSelector;
        private Selector<string> fontFamilySelector;
        private Selector<string> textSelector;
        private Selector<Color> textColorSelector;
        private Selector<float?> pointSizeSelector;
        private Selector<TextShadow> textShadow;
        private PropertyMap fontStyle;
        private float? characterSpacing;
        private float? fontSizeScale;
        private Color anchorColor;
        private Color anchorClickedColor;

        static TextLabelStyle()
        {
            if (NUIApplication.IsUsingXaml)
            {
                TranslatableTextSelectorProperty = BindableProperty.Create(nameof(TranslatableText), typeof(Selector<string>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalTranslatableTextSelectorProperty, defaultValueCreator: GetInternalTranslatableTextSelectorProperty);
                TextSelectorProperty = BindableProperty.Create(nameof(Text), typeof(Selector<string>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalTextSelectorProperty, defaultValueCreator: GetInternalTextSelectorProperty);
                FontFamilySelectorProperty = BindableProperty.Create(nameof(FontFamily), typeof(Selector<string>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalFontFamilySelectorProperty, defaultValueCreator: GetInternalFontFamilySelectorProperty);
                PointSizeSelectorProperty = BindableProperty.Create(nameof(PointSize), typeof(Selector<float?>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalPointSizeSelectorProperty, defaultValueCreator: GetInternalPointSizeSelectorProperty);
                TextColorSelectorProperty = BindableProperty.Create(nameof(TextColor), typeof(Selector<Color>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalTextColorSelectorProperty, defaultValueCreator: GetInternalTextColorSelectorProperty);
                MultiLineProperty = BindableProperty.Create(nameof(MultiLine), typeof(bool?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalMultiLineProperty, defaultValueCreator: GetInternalMultiLineProperty);
                HorizontalAlignmentProperty = BindableProperty.Create(nameof(HorizontalAlignment), typeof(HorizontalAlignment?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalHorizontalAlignmentProperty, defaultValueCreator: GetInternalHorizontalAlignmentProperty);
                VerticalAlignmentProperty = BindableProperty.Create(nameof(VerticalAlignment), typeof(VerticalAlignment?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalVerticalAlignmentProperty, defaultValueCreator: GetInternalVerticalAlignmentProperty);
                EnableMarkupProperty = BindableProperty.Create(nameof(EnableMarkup), typeof(bool?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalEnableMarkupProperty, defaultValueCreator: GetInternalEnableMarkupProperty);
                EnableAutoScrollProperty = BindableProperty.Create(nameof(EnableAutoScroll), typeof(bool?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalEnableAutoScrollProperty, defaultValueCreator: GetInternalEnableAutoScrollProperty);
                AutoScrollSpeedProperty = BindableProperty.Create(nameof(AutoScrollSpeed), typeof(int?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAutoScrollSpeedProperty, defaultValueCreator: GetInternalAutoScrollSpeedProperty);
                AutoScrollLoopCountProperty = BindableProperty.Create(nameof(AutoScrollLoopCount), typeof(int?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAutoScrollLoopCountProperty, defaultValueCreator:  GetInternalAutoScrollLoopCountProperty);
                AutoScrollGapProperty = BindableProperty.Create(nameof(AutoScrollGap), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAutoScrollGapProperty, defaultValueCreator: GetInternalAutoScrollGapProperty);
                LineSpacingProperty = BindableProperty.Create(nameof(LineSpacing), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalLineSpacingProperty, defaultValueCreator: GetInternalLineSpacingProperty);
                RelativeLineHeightProperty = BindableProperty.Create(nameof(RelativeLineHeight), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalRelativeLineHeightProperty, defaultValueCreator: GetInternalRelativeLineHeightProperty);
                EmbossProperty = BindableProperty.Create(nameof(Emboss), typeof(string), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalEmbossProperty, defaultValueCreator: GetInternalEmbossProperty);
                PixelSizeSelectorProperty = BindableProperty.Create(nameof(PixelSize), typeof(Selector<float?>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalPixelSizeSelectorProperty, defaultValueCreator: GetInternalPixelSizeSelectorProperty);
                EllipsisProperty = BindableProperty.Create(nameof(Ellipsis), typeof(bool?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalEllipsisProperty, defaultValueCreator: GetInternalEllipsisProperty);
                AutoScrollLoopDelayProperty = BindableProperty.Create(nameof(AutoScrollLoopDelay), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAutoScrollLoopDelayProperty, defaultValueCreator: GetInternalAutoScrollLoopDelayProperty);
                AutoScrollStopModeProperty = BindableProperty.Create(nameof(AutoScrollStopMode), typeof(AutoScrollStopMode?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAutoScrollStopModeProperty, defaultValueCreator: GetInternalAutoScrollStopModeProperty);
                LineWrapModeProperty = BindableProperty.Create(nameof(LineWrapMode), typeof(LineWrapMode?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalLineWrapModeProperty, defaultValueCreator: GetInternalLineWrapModeProperty);
                VerticalLineAlignmentProperty = BindableProperty.Create(nameof(VerticalLineAlignment), typeof(VerticalLineAlignment?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalVerticalLineAlignmentProperty, defaultValueCreator: GetInternalVerticalLineAlignmentProperty);
                EllipsisPositionProperty = BindableProperty.Create(nameof(EllipsisPosition), typeof(EllipsisPosition?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalEllipsisPositionProperty, defaultValueCreator: GetInternalEllipsisPositionProperty);
                CharacterSpacingProperty = BindableProperty.Create(nameof(CharacterSpacing), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalCharacterSpacingProperty, defaultValueCreator: GetInternalCharacterSpacingProperty);
                FontSizeScaleProperty = BindableProperty.Create(nameof(FontSizeScale), typeof(float?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalFontSizeScaleProperty, defaultValueCreator: GetInternalFontSizeScaleProperty);
                AnchorColorProperty = BindableProperty.Create(nameof(AnchorColor), typeof(Color), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAnchorColorProperty, defaultValueCreator: GetInternalAnchorColorProperty);
                AnchorClickedColorProperty = BindableProperty.Create(nameof(AnchorClickedColor), typeof(Color), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalAnchorClickedColorProperty, defaultValueCreator: GetInternalAnchorClickedColorProperty);
                MatchSystemLanguageDirectionProperty = BindableProperty.Create(nameof(MatchSystemLanguageDirection), typeof(bool?), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalMatchSystemLanguageDirectionProperty, defaultValueCreator: GetInternalMatchSystemLanguageDirectionProperty);
                TextShadowProperty = BindableProperty.Create(nameof(TextShadow), typeof(Selector<TextShadow>), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalTextShadowProperty, defaultValueCreator: GetInternalTextShadowProperty);
                FontStyleProperty = BindableProperty.Create(nameof(FontStyle), typeof(PropertyMap), typeof(TextLabelStyle), null,
                    propertyChanged: SetInternalFontStyleProperty, defaultValueCreator: GetInternalFontStyleProperty);
            }
        }

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
                Selector<string> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<string>)GetValue(TranslatableTextSelectorProperty);
                }
                else
                {
                    tmp = (Selector<string>)GetInternalTranslatableTextSelectorProperty(this);
                }
                return (null != tmp) ? tmp : translatableTextSelector = new Selector<string>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TranslatableTextSelectorProperty, value);
                }
                else
                {
                    SetInternalTranslatableTextSelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> FontFamily
        {
            get
            {
                Selector<string> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<string>)GetValue(FontFamilySelectorProperty);
                }
                else
                {
                    tmp = (Selector<string>)GetInternalFontFamilySelectorProperty(this);
                }
                return (null != tmp) ? tmp : fontFamilySelector = new Selector<string>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontFamilySelectorProperty, value);
                }
                else
                {
                    SetInternalFontFamilySelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MultiLine
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(MultiLineProperty);
                }
                else
                {
                    return (bool?)GetInternalMultiLineProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MultiLineProperty, value);
                }
                else
                {
                    SetInternalMultiLineProperty(this, null, value);
                }
            }
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
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalAlignment?)GetValue(VerticalAlignmentProperty);
                }
                else
                {
                    return (VerticalAlignment?)GetInternalVerticalAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalAlignmentProperty, value);
                }
                else
                {
                    SetInternalVerticalAlignmentProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableMarkup
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableMarkupProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableMarkupProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableMarkupProperty, value);
                }
                else
                {
                    SetInternalEnableMarkupProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutoScroll
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EnableAutoScrollProperty);
                }
                else
                {
                    return (bool?)GetInternalEnableAutoScrollProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableAutoScrollProperty, value);
                }
                else
                {
                    SetInternalEnableAutoScrollProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollSpeed
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int?)GetValue(AutoScrollSpeedProperty);
                }
                else

                {
                    return (int?)GetInternalAutoScrollSpeedProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollSpeedProperty, value);
                }
                else
                {
                    SetInternalAutoScrollSpeedProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? AutoScrollLoopCount
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int?)GetValue(AutoScrollLoopCountProperty);
                }
                else
                {
                    return (int?)GetInternalAutoScrollLoopCountProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollLoopCountProperty, value);
                }
                else
                {
                    SetInternalAutoScrollLoopCountProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollGap
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(AutoScrollGapProperty);
                }
                else
                {
                    return (float?)GetInternalAutoScrollGapProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollGapProperty, value);
                }
                else
                {
                    SetInternalAutoScrollGapProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? LineSpacing
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(LineSpacingProperty);
                }
                else
                {
                    return (float?)GetInternalLineSpacingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineSpacingProperty, value);
                }
                else
                {
                    SetInternalLineSpacingProperty(this, null, value);
                }
            }
        }

        /// <summary>
        /// the relative line height to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RelativeLineHeight
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(RelativeLineHeightProperty);
                }
                else
                {
                    return (float?)GetInternalRelativeLineHeightProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(RelativeLineHeightProperty, value);
                }
                else
                {
                    SetInternalRelativeLineHeightProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Emboss
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(EmbossProperty);
                }
                else
                {
                    return (string)GetInternalEmbossProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EmbossProperty, value);
                }
                else
                {
                    SetInternalEmbossProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PixelSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<float?>)GetValue(PixelSizeSelectorProperty) ?? (pixelSizeSelector = new Selector<float?>());
                }
                else
                {
                    return (Selector<float?>)GetInternalPixelSizeSelectorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PixelSizeSelectorProperty, value);
                }
                else
                {
                    SetInternalPixelSizeSelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Ellipsis
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(EllipsisProperty);
                }
                else
                {
                    return (bool?)GetInternalEllipsisProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisProperty, value);
                }
                else
                {
                    SetInternalEllipsisProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? AutoScrollLoopDelay
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(AutoScrollLoopDelayProperty);
                }
                else
                {
                    return (float?)GetInternalAutoScrollLoopDelayProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollLoopDelayProperty, value);
                }
                else
                {
                    SetInternalAutoScrollLoopDelayProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public AutoScrollStopMode? AutoScrollStopMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (AutoScrollStopMode?)GetValue(AutoScrollStopModeProperty);
                }
                else
                {
                    return (AutoScrollStopMode?)GetInternalAutoScrollStopModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AutoScrollStopModeProperty, value);
                }
                else
                {
                    SetInternalAutoScrollStopModeProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public LineWrapMode? LineWrapMode
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (LineWrapMode?)GetValue(LineWrapModeProperty);
                }
                else
                {
                    return (LineWrapMode?)GetInternalLineWrapModeProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LineWrapModeProperty, value);
                }
                else
                {
                    SetInternalLineWrapModeProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public VerticalLineAlignment? VerticalLineAlignment
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (VerticalLineAlignment?)GetValue(VerticalLineAlignmentProperty);
                }
                else
                {
                    return (VerticalLineAlignment?)GetInternalVerticalLineAlignmentProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VerticalLineAlignmentProperty, value);
                }
                else
                {
                    SetInternalVerticalLineAlignmentProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EllipsisPosition? EllipsisPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (EllipsisPosition?)GetValue(EllipsisPositionProperty);
                }
                else
                {
                    return (EllipsisPosition?)GetInternalEllipsisPositionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EllipsisPositionProperty, value);
                }
                else
                {
                    SetInternalEllipsisPositionProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CharacterSpacing
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(CharacterSpacingProperty);
                }
                else
                {
                    return (float?)GetInternalCharacterSpacingProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CharacterSpacingProperty, value);
                }
                else
                {
                    SetInternalCharacterSpacingProperty(this, null, value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float?)GetValue(FontSizeScaleProperty);
                }
                else
                {
                    return (float?)GetInternalFontSizeScaleProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontSizeScaleProperty, value);
                }
                else
                {
                    SetInternalFontSizeScaleProperty(this, null, value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(AnchorColorProperty);
                }
                else
                {
                    return (Color)GetInternalAnchorColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorColorProperty, value);
                }
                else
                {
                    SetInternalAnchorColorProperty(this, null, value);
                }
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorClickedColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(AnchorClickedColorProperty);
                }
                else
                {
                    return (Color)GetInternalAnchorClickedColorProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(AnchorClickedColorProperty, value);
                }
                else
                {
                    SetInternalAnchorClickedColorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? MatchSystemLanguageDirection
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool?)GetValue(MatchSystemLanguageDirectionProperty);
                }
                else
                {
                    return (bool?)GetInternalMatchSystemLanguageDirectionProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MatchSystemLanguageDirectionProperty, value);
                }
                else
                {
                    SetInternalMatchSystemLanguageDirectionProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> Text
        {
            get
            {
                Selector<string> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<string>)GetValue(TextSelectorProperty);
                }
                else
                {
                    tmp = (Selector<string>)GetInternalTextSelectorProperty(this);
                }
                return (null != tmp) ? tmp : textSelector = new Selector<string>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextSelectorProperty, value);
                }
                else
                {
                    SetInternalTextSelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> TextColor
        {
            get
            {
                Selector<Color> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<Color>)GetValue(TextColorSelectorProperty);
                }
                else
                {
                    tmp = (Selector<Color>)GetInternalTextColorSelectorProperty(this);
                }
                return (null != tmp) ? tmp : textColorSelector = new Selector<Color>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextColorSelectorProperty, value);
                }
                else
                {
                    SetInternalTextColorSelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PointSize
        {
            get
            {
                Selector<float?> tmp = null;
                if (NUIApplication.IsUsingXaml)
                {
                    tmp = (Selector<float?>)GetValue(PointSizeSelectorProperty);
                }
                else
                {
                    tmp = (Selector<float?>)GetInternalPointSizeSelectorProperty(this);
                }
                return (null != tmp) ? tmp : pointSizeSelector = new Selector<float?>();
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PointSizeSelectorProperty, value);
                }
                else
                {
                    SetInternalPointSizeSelectorProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<TextShadow> TextShadow
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Selector<TextShadow>)GetValue(TextShadowProperty);
                }
                else
                {
                    return (Selector<TextShadow>)GetInternalTextShadowProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextShadowProperty, value);
                }
                else
                {
                    SetInternalTextShadowProperty(this, null, value);
                }
            }
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PropertyMap FontStyle
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (PropertyMap)GetValue(FontStyleProperty);
                }
                else
                {
                    return (PropertyMap)GetInternalFontStyleProperty(this);
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(FontStyleProperty, value);
                }
                else
                {
                    SetInternalFontStyleProperty(this, null, value);
                }
            }
        }
    }
}
