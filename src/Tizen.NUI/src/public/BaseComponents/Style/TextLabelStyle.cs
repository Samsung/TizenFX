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

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// The base class for Children attributes in Components.
    /// </summary>
    /// This will be public opened in tizen_5.5 after ACR done. Before ACR, need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class TextLabelStyle : ViewStyle
    {
        static readonly IStyleProperty TranslatableTextSelectorProperty = new StyleProperty<TextLabel, Selector<string>>((v, o) => TextLabel.SetInternalTranslatableTextProperty(v, null, o));
        static readonly IStyleProperty FontFamilySelectorProperty = new StyleProperty<TextLabel, Selector<string>>((v, o) => TextLabel.SetInternalFontFamilyProperty(v, null, o));
        static readonly IStyleProperty MultiLineProperty = new StyleProperty<TextLabel, bool>((v, o) => v.MultiLine = o);
        static readonly IStyleProperty HorizontalAlignmentProperty = new StyleProperty<TextLabel, HorizontalAlignment>((v, o) => v.HorizontalAlignment = o);
        static readonly IStyleProperty VerticalAlignmentProperty = new StyleProperty<TextLabel, VerticalAlignment>((v, o) => v.VerticalAlignment = o);
        static readonly IStyleProperty EnableMarkupProperty = new StyleProperty<TextLabel, bool>((v, o) => v.EnableMarkup = o);
        static readonly IStyleProperty EnableAutoScrollProperty = new StyleProperty<TextLabel, bool>((v, o) => v.EnableAutoScroll = o);
        static readonly IStyleProperty AutoScrollSpeedProperty = new StyleProperty<TextLabel, int>((v, o) => v.AutoScrollSpeed = o);
        static readonly IStyleProperty AutoScrollLoopCountProperty = new StyleProperty<TextLabel, int>((v, o) => v.AutoScrollLoopCount = o);
        static readonly IStyleProperty AutoScrollGapProperty = new StyleProperty<TextLabel, float>((v, o) => v.AutoScrollGap = o);
        static readonly IStyleProperty LineSpacingProperty = new StyleProperty<TextLabel, float>((v, o) => v.LineSpacing = o);
        static readonly IStyleProperty RelativeLineHeightProperty = new StyleProperty<TextLabel, float>((v, o) => v.RelativeLineHeight = o);
        static readonly IStyleProperty EmbossProperty = new StyleProperty<TextLabel, string>((v, o) => v.Emboss = o);
        static readonly IStyleProperty PixelSizeSelectorProperty = new StyleProperty<TextLabel, Selector<float?>>((v, o) => TextLabel.SetInternalPixelSizeProperty(v, null, o));
        static readonly IStyleProperty EllipsisProperty = new StyleProperty<TextLabel, bool>((v, o) => v.Ellipsis = o);
        static readonly IStyleProperty AutoScrollLoopDelayProperty = new StyleProperty<TextLabel, float>((v, o) => v.AutoScrollLoopDelay = o);
        static readonly IStyleProperty AutoScrollStopModeProperty = new StyleProperty<TextLabel, AutoScrollStopMode>((v, o) => v.AutoScrollStopMode = o);
        static readonly IStyleProperty LineWrapModeProperty = new StyleProperty<TextLabel, LineWrapMode>((v, o) => v.LineWrapMode = o);
        static readonly IStyleProperty VerticalLineAlignmentProperty = new StyleProperty<TextLabel, VerticalLineAlignment>((v, o) => v.VerticalLineAlignment = o);
        static readonly IStyleProperty EllipsisPositionProperty = new StyleProperty<TextLabel, EllipsisPosition>((v, o) => v.EllipsisPosition = o);
        static readonly IStyleProperty CharacterSpacingProperty = new StyleProperty<TextLabel, float>((v, o) => v.CharacterSpacing = o);
        static readonly IStyleProperty FontSizeScaleProperty = new StyleProperty<TextLabel, float>((v, o) => v.FontSizeScale = o);
        static readonly IStyleProperty AnchorColorProperty = new StyleProperty<TextLabel, Color>((v, o) => v.AnchorColor = o);
        static readonly IStyleProperty AnchorClickedColorProperty = new StyleProperty<TextLabel, Color>((v, o) => v.AnchorClickedColor = o);
        static readonly IStyleProperty MatchSystemLanguageDirectionProperty = new StyleProperty<TextLabel, bool>((v, o) => v.MatchSystemLanguageDirection = o);
        static readonly IStyleProperty TextSelectorProperty = new StyleProperty<TextLabel, Selector<string>>((v, o) => TextLabel.SetInternalTextProperty(v, null, o));
        static readonly IStyleProperty TextColorSelectorProperty = new StyleProperty<TextLabel, Selector<Color>>((v, o) => TextLabel.SetInternalTextColorProperty(v, null, o));
        static readonly IStyleProperty PointSizeSelectorProperty = new StyleProperty<TextLabel, Selector<float?>>((v, o) => TextLabel.SetInternalPointSizeProperty(v, null, o));
        static readonly IStyleProperty TextShadowProperty = new StyleProperty<TextLabel, Selector<TextShadow>>((v, o) => TextLabel.SetInternalTextShadowProperty(v, null, o));
        static readonly IStyleProperty FontStyleProperty = new StyleProperty<TextLabel, PropertyMap>((v, o) => v.FontStyle = o);

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
            get => GetOrCreateValue<Selector<string>>(TranslatableTextSelectorProperty);
            set => SetValue(TranslatableTextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<string> FontFamily
        {
            get => GetOrCreateValue<Selector<string>>(FontFamilySelectorProperty);
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

        /// <summary>
        /// the relative line height to be used.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? RelativeLineHeight
        {
            get => (float?)GetValue(RelativeLineHeightProperty);
            set => SetValue(RelativeLineHeightProperty, value);
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
            get => GetOrCreateValue<Selector<float?>>(PixelSizeSelectorProperty);
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

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public EllipsisPosition? EllipsisPosition
        {
            get => (EllipsisPosition?)GetValue(EllipsisPositionProperty);
            set => SetValue(EllipsisPositionProperty, value);
        }

        /// This will be public opened in tizen_6.5 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? CharacterSpacing
        {
            get => (float?)GetValue(CharacterSpacingProperty);
            set => SetValue(CharacterSpacingProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSizeScale
        {
            get => (float?)GetValue(FontSizeScaleProperty);
            set => SetValue(FontSizeScaleProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorColor
        {
            get => (Color)GetValue(AnchorColorProperty);
            set => SetValue(AnchorColorProperty, value);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color AnchorClickedColor
        {
            get => (Color)GetValue(AnchorClickedColorProperty);
            set => SetValue(AnchorClickedColorProperty, value);
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
            get => GetOrCreateValue<Selector<string>>(TextSelectorProperty);
            set => SetValue(TextSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<Color> TextColor
        {
            get => GetOrCreateValue<Selector<Color>>(TextColorSelectorProperty);
            set => SetValue(TextColorSelectorProperty, value);
        }

        /// This will be public opened in tizen_6.0 after ACR done. Before ACR, need to be hidden as inhouse API.
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Selector<float?> PointSize
        {
            get => GetOrCreateValue<Selector<float?>>(PointSizeSelectorProperty);
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
