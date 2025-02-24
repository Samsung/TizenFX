/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using Tizen.NUI;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Extension
{
    /// <summary>
    /// Markup extensions for View.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class TextLabelExtensions
    {
        /// <summary>
        /// The text can set the SID value.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T TranslatableText<T>(this T view, string text) where T : TextLabel
        {
            view.TranslatableText = text;
            return view;
        }

        /// <summary>
        /// The text to display in the UTF-8 format.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T Text<T>(this T view, string text) where T : TextLabel
        {
            view.Text = text;
            return view;
        }

        /// <summary>
        /// The requested font family to use.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="family">The font family value.</param>
        /// <returns>The view itself.</returns>
        public static T FontFamily<T>(this T view, string family) where T : TextLabel
        {
            view.FontFamily = family;
            return view;
        }

        /// <summary>
        /// Set FontStyle to TextLabel. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The font width value.</param>
        /// <param name="weight">The font weight value.</param>
        /// <param name="slant">The font slant value.</param>
        /// <returns>The view itself.</returns>
        public static T FontStyle<T>(this T view,  FontWidthType width, FontWeightType weight, FontSlantType slant) where T : TextLabel
        {
            view.SetFontStyle(new Text.FontStyle()
            {
                Width = width,
                Weight = weight,
                Slant = slant
            });
            return view;
        }

        /// <summary>
        /// The size of font in pixels.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="size">The size value.</param>
        /// <returns>The view itself.</returns>
        public static T FontSize<T>(this T view, float size) where T : TextLabel
        {
            view.PixelSize = size;
            return view;
        }

        /// <summary>
        /// The line vertical alignment.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="horizontal">The horizontal value.</param>
        /// <param name="vertical">The vertical value.</param>
        /// <returns>The view itself.</returns>
        public static T TextAlignment<T>(this T view, HorizontalAlignment horizontal, VerticalAlignment vertical) where T : TextLabel
        {
            view.HorizontalAlignment = horizontal;
            view.VerticalAlignment = vertical;
            return view;
        }

        /// <summary>
        /// The color of the text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T TextColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextLabel
        {
            view.TextColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color of the text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     new UIColor(0xFF0000, 1f); // Solid red
        ///     new UIColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        /// <returns>The view itself.</returns>
        public static T TextColor<T>(this T view, uint value, float alpha) where T : TextLabel
        {
            view.TextColor = (new UIColor(value, alpha)).ToReferenceType();
            return view;
        }

        /// <summary>
        /// The color of the text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T TextColor<T>(this T view, UIColor color) where T : TextLabel
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.TextColor = color.ToReferenceType();
            return view;
        }

        /// <summary>
        /// Whether the mark-up processing is enabled.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="markup">The blink value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableMarkup<T>(this T view, bool markup) where T : TextLabel
        {
            view.EnableMarkup = markup;
            return view;
        }

        /// <summary>
        /// The EnableAutoScroll property.<br />
        /// Starts or stops auto scrolling.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The auto scroll enabled value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableAutoScroll<T>(this T view, bool enabled) where T : TextLabel
        {
            view.EnableAutoScroll = enabled;
            return view;
        }

        /// <summary>
        /// The AutoScrollSpeed property.<br />
        /// Sets the speed of scrolling in pixels per second.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="speed">The speed value.</param>
        /// <returns>The view itself.</returns>
        public static T AutoScrollSpeed<T>(this T view, int speed) where T : TextLabel
        {
            view.AutoScrollSpeed = speed;
            return view;
        }

        /// <summary>
        /// The AutoScrollLoopCount property.<br />
        /// Number of complete loops when scrolling enabled.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="count">The count value.</param>
        /// <returns>The view itself.</returns>
        public static T AutoScrollLoopCount<T>(this T view, int count) where T : TextLabel
        {
            view.AutoScrollLoopCount = count;
            return view;
        }

        /// <summary>
        /// The AutoScrollGap property.<br />
        /// Gap before scrolling wraps.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="gap">The gap value.</param>
        /// <returns>The view itself.</returns>
        public static T AutoScrollGap<T>(this T view, float gap) where T : TextLabel
        {
            view.AutoScrollGap = gap;
            return view;
        }

        /// <summary>
        /// The AutoScrollLoopCount property.<br />
        /// Number of complete loops when scrolling enabled.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="mode">The AutoScrollStopMode value.</param>
        /// <returns>The view itself.</returns>
        public static T AutoScrollStopMode<T>(this T view, AutoScrollStopMode mode) where T : TextLabel
        {
            view.AutoScrollStopMode = mode;
            return view;
        }

        /// <summary>
        /// The AutoScrollLoopDelay.<br />
        /// The amount of time to delay the starting time of auto scrolling and further loops.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="delay">The delay value.</param>
        /// <returns>The view itself.</returns>
        public static T AutoScrollLoopDelay<T>(this T view, float delay) where T : TextLabel
        {
            view.AutoScrollLoopDelay = delay;
            return view;
        }

        /// <summary>
        /// The MultiLine property.<br />
        /// The single-line or multi-line layout option.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="multiline">The multiline value.</param>
        /// <returns>The view itself.</returns>
        public static T MultiLine<T>(this T view, bool multiline) where T : TextLabel
        {
            view.MultiLine = multiline;
            return view;
        }

        /// <summary>
        /// The LineWrapMode property.<br />
        /// line wrap mode when the text lines over layout width.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="mode">The mode value.</param>
        /// <returns>The view itself.</returns>
        public static T LineWrapMode<T>(this T view, LineWrapMode mode) where T : TextLabel
        {
            view.LineWrapMode = mode;
            return view;
        }

        /// <summary>
        /// The LineSpacing property.<br />
        /// The default extra space between lines in points.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="spacing">The spacing value.</param>
        /// <returns>The view itself.</returns>
        public static T LineSpacing<T>(this T view, float spacing) where T : TextLabel
        {
            view.LineSpacing = spacing;
            return view;
        }

        /// <summary>
        /// The Ellipsis.<br />
        /// Enable or disable the ellipsis.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The ellipsis value.</param>
        /// <returns>The view itself.</returns>
        public static T Ellipsis<T>(this T view, bool enabled) where T : TextLabel
        {
            view.Ellipsis = enabled;
            return view;
        }

        /// <summary>
        /// Specifies which portion of the text should be replaced with an ellipsis when the text size exceeds the layout size.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="position">The position value.</param>
        /// <returns>The view itself.</returns>
        public static T EllipsisPosition<T>(this T view, EllipsisPosition position) where T : TextLabel
        {
            view.EllipsisPosition = position;
            return view;
        }

        /// <summary>
        /// Enable FontSizeScale to TextLabel. <br />
        /// Whether the font size scale is enabled. (The default value is true)
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The font size scale enabled value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableFontSizeScale<T>(this T view, bool enabled) where T : TextLabel
        {
            view.EnableFontSizeScale = enabled;
            return view;
        }

        /* To-Do. We want to hide Color and Size, Vector2 types in the futures,
        so hide the struct set who expose those class types.
        Use SetFunction to use these types.

        /// <summary>
        /// The text alignment to match the direction of the system language.<br />
        /// The default value is true.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="match">The direction match value.</param>
        /// <returns>The view itself.</returns>
        public static T MatchSystemLanguageDirection<T>(this T view, bool match) where T : TextLabel
        {
            view.MatchSystemLanguageDirection = match;
            return view;
        }

        /// <summary>
        /// Set FontSizeScale to TextLabel. <br />
        /// The default value is 1.0. <br />
        /// The given font size scale value is used for multiplying the specified font size before querying fonts. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns>The view itself.</returns>
        public static T FontSizeScale<T>(this T view, float scale) where T : TextLabel
        {
            view.FontSizeScale = scale;
            return view;
        }

        /// <summary>
        /// Whether remove FrontInset to TextLabel. <br />
        /// This property is used when the xBearing of first glyph must not be trimmed.<br />
        /// When set to false, The gap between (0, 0) from the first glyph's leftmost pixel is included in the width of text label.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="remove">The remove value.</param>
        /// <returns>The view itself.</returns>
        public static T RemoveFrontInset<T>(this T view, bool remove) where T : TextLabel
        {
            view.RemoveFrontInset = remove;
            return view;
        }

        /// <summary>
        /// Whether remove BackInset to TextLabel. <br />
        /// This property is used when the advance of last glyph must not be trimmed.<br />
        /// When set to false, The gap between the last glyph's rightmost pixel and X coordinate that next glyph will be placed is included in the width of text label.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="remove">The remove value.</param>
        /// <returns>The view itself.</returns>
        public static T RemoveBackInset<T>(this T view, bool remove) where T : TextLabel
        {
            view.RemoveBackInset = remove;
            return view;
        }

        /// <summary>
        /// Specify the position of the primary cursor (caret) in text control.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="position">The position value.</param>
        /// <returns>The view itself.</returns>
        public static T PrimaryCursorPosition<T>(this T view, int position) where T : TextLabel
        {
            view.PrimaryCursorPosition = position;
            return view;
        }

        /// <summary>
        /// The shadow of the text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="blurRadius">The blur radius value for the shadow. Bigger value, much blurry.</param>
        /// <param name="color">The color value.</param>
        /// <param name="offsetX">The offset X value.</param>
        /// <param name="offsetY">The offset Y value.</param>
        /// <returns>The view itself.</returns>
        public static T TextShadow<T>(this T view, float blurRadius, UIColor color, float offsetX = 0, float offsetY = 0) where T : TextLabel
        {
            view.SetShadow( new Text.Shadow()
            {
                BlurRadius = blurRadius,
                Color = color.ToReferenceType(),
                Offset = new Vector2(offsetX, offsetY),
            });
            return view;
        }

        /// <summary>
        /// The shadow of the text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="shadow">The text shadow.</param>
        /// <returns>The view itself.</returns>
        public static T TextShadow<T>(this T view, Text.Shadow shadow) where T : TextLabel
        {
            view.SetShadow(shadow);
            return view;
        }

        /// <summary>
        /// Set underline to TextLabel. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="underline">The underline value.</param>
        /// <returns>The view itself.</returns>
        public static T Underline<T>(this T view, Text.Underline underline) where T : TextLabel
        {
            view.SetUnderline(underline);
            return view;
        }

        /// <summary>
        /// Set outline to TextLabel. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="outline">The outline value.</param>
        /// <returns>The view itself.</returns>
        public static T Outline<T>(this T view, Text.Outline outline) where T : TextLabel
        {
            view.SetOutline(outline);
            return view;
        }

        /// <summary>
        /// Set strikethrough to TextLabel. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="strikethrough">The strikethrough value.</param>
        /// <returns>The view itself.</returns>
        public static T Strikethrough<T>(this T view, Text.Strikethrough strikethrough) where T : TextLabel
        {
            view.SetStrikethrough(strikethrough);
            return view;
        }
        End of To-DO */

        /* Getters */

        /// <summary>
        /// Gets the color for the text of the View.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The text color value.</returns>
        public static UIColor TextColor(this TextLabel view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return new UIColor(view.TextColor);
        }
    }
}
