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
    public static class TextEditorExtensions
    {
        /// <summary>
        /// The text can set the SID value.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T TranslatableText<T>(this T view, string text) where T : TextEditor
        {
            view.TranslatableText = text;
            return view;
        }

        /// <summary>
        /// The text can set the SID value.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T TranslatablePlaceholderText<T>(this T view, string text) where T : TextEditor
        {
            view.TranslatablePlaceholderText = text;
            return view;
        }

        /// <summary>
        /// The text to display in the UTF-8 format.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T Text<T>(this T view, string text) where T : TextEditor
        {
            view.Text = text;
            return view;
        }

        /// <summary>
        /// The text to display when the TextEditor is empty and inactive. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="text">The text value.</param>
        /// <returns>The view itself.</returns>
        public static T PlaceholderText<T>(this T view, string text) where T : TextEditor
        {
            view.PlaceholderText = text;
            return view;
        }

        /// <summary>
        /// The requested font family to use.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="family">The font family value.</param>
        /// <returns>The view itself.</returns>
        public static T FontFamily<T>(this T view, string family) where T : TextEditor
        {
            view.FontFamily = family;
            return view;
        }

        /// <summary>
        /// Set FontStyle to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The font width value.</param>
        /// <param name="weight">The font weight value.</param>
        /// <param name="slant">The font slant value.</param>
        /// <returns>The view itself.</returns>
        public static T FontStyle<T>(this T view,  FontWidthType width, FontWeightType weight, FontSlantType slant) where T : TextEditor
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
        public static T FontSize<T>(this T view, float size) where T : TextEditor
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
        public static T TextAlignment<T>(this T view, HorizontalAlignment horizontal, VerticalAlignment vertical) where T : TextEditor
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
        public static T TextColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
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
        public static T TextColor<T>(this T view, uint value, float alpha) where T : TextEditor
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
        public static T TextColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.TextColor = color.ToReferenceType();
            return view;
        }

        /// <summary>
        /// The color of the placeholder text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T PlaceholderTextColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.PlaceholderTextColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color of the placeholder text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     TextEditor.PlaceholderTextColor(0xFF0000, 1f); // Solid red
        ///     TextEditor.PlaceholderTextColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        /// <returns>The view itself.</returns>
        public static T PlaceholderTextColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.PlaceholderTextColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color of the placeholder text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T PlaceholderTextColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.PlaceholderTextColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color to apply to the primary cursor.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T PrimaryCursorColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.PrimaryCursorColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color to apply to the primary cursor.<br />
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
        public static T PrimaryCursorColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.PrimaryCursorColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color to apply to the primary cursor.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T PrimaryCursorColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.PrimaryCursorColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color to apply to the secondary cursor.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T SecondaryCursorColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.SecondaryCursorColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color to apply to the secondary cursor.<br />
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
        public static T SecondaryCursorColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.SecondaryCursorColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color to apply to the secondary cursor.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T SecondaryCursorColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.SecondaryCursorColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }


        /// <summary>
        /// The color of the selection highlight.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T SelectionHighlightColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.SelectionHighlightColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color of the selection highlight.<br />
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
        public static T SelectionHighlightColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.SelectionHighlightColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color of the selection highlight.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T SelectionHighlightColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.SelectionHighlightColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color of the new input text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T InputColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.InputColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color of the new input text.<br />
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
        public static T InputColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.InputColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color of the new input text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T InputColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.InputColor = new Vector4(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// Whether the mark-up processing is enabled.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="markup">The blink value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableMarkup<T>(this T view, bool markup) where T : TextEditor
        {
            view.EnableMarkup = markup;
            return view;
        }

        /// <summary>
        /// The font's family of the new input text.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="family">The font family value.</param>
        /// <returns>The view itself.</returns>
        public static T InputFontFamily<T>(this T view, string family) where T : TextEditor
        {
            view.InputFontFamily = family;
            return view;
        }

        /// <summary>
        /// Set InputFontStyle to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The font width value.</param>
        /// <param name="weight">The font weight value.</param>
        /// <param name="slant">The font slant value.</param>
        /// <returns>The view itself.</returns>
        public static T InputFontStyle<T>(this T view,  FontWidthType width, FontWeightType weight, FontSlantType slant) where T : TextEditor
        {
            view.SetInputFontStyle(new Text.FontStyle()
            {
                Width = width,
                Weight = weight,
                Slant = slant
            });
            return view;
        }

        /// <summary>
        /// Enables Text selection, such as the cursor, handle, clipboard, and highlight color.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The selection value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableSelection<T>(this T view, bool enabled) where T : TextEditor
        {
            view.EnableSelection = enabled;
            return view;
        }

        /// <summary>
        /// Enable editing in text control.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The editing value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableEditing<T>(this T view, bool enabled) where T : TextEditor
        {
            view.EnableEditing = enabled;
            return view;
        }

        /// <summary>
        /// The Ellipsis.<br />
        /// Enable or disable the ellipsis.<br />
        /// Placeholder PropertyMap is used to add ellipsis to placeholder text.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The ellipsis value.</param>
        /// <returns>The view itself.</returns>
        public static T Ellipsis<T>(this T view, bool enabled) where T : TextEditor
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
        public static T EllipsisPosition<T>(this T view, EllipsisPosition position) where T : TextEditor
        {
            view.EllipsisPosition = position;
            return view;
        }

        /// <summary>
        /// Enable FontSizeScale to TextEditor. <br />
        /// Whether the font size scale is enabled. (The default value is true)
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="enabled">The font size scale enabled value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableFontSizeScale<T>(this T view, bool enabled) where T : TextEditor
        {
            view.EnableFontSizeScale = enabled;
            return view;
        }

        /// <summary>
        /// Set FontSizeScale to TextEditor. <br />
        /// The default value is 1.0. <br />
        /// The given font size scale value is used for multiplying the specified font size before querying fonts. <br />
        /// If FontSizeScale.UseSystemSetting, will use the SystemSettings.FontSize internally. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="scale">The scale value.</param>
        /// <returns>The view itself.</returns>
        public static T FontSizeScale<T>(this T view, float scale) where T : TextEditor
        {
            view.FontSizeScale = scale;
            return view;
        }

        /// <summary>
        /// The color of grab handle.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        /// <returns>The view itself.</returns>
        public static T GrabHandleColor<T>(this T view, float r, float g, float b, float a = 1f) where T : TextEditor
        {
            view.GrabHandleColor = new (r, g, b, a);
            return view;
        }

        /// <summary>
        /// The color of grab handle.<br />
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
        public static T GrabHandleColor<T>(this T view, uint value, float alpha) where T : TextEditor
        {
            var color = new UIColor(value, alpha);
            //FIXME: we need to set UI value type directly without converting reference value.
            view.GrabHandleColor = new Color(color.R, color.G, color.B, color.A);
            return view;
        }

        /// <summary>
        /// The color of grab handle.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="color">The color value.</param>
        /// <returns>The view itself.</returns>
        public static T GrabHandleColor<T>(this T view, UIColor color) where T : TextEditor
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            view.GrabHandleColor = new Color(color.R, color.G, color.B, color.A);
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
        public static T MatchSystemLanguageDirection<T>(this T view, bool match) where T : TextEditor
        {
            view.MatchSystemLanguageDirection = match;
            return view;
        }

        /// <summary>
        /// The maximum number of characters that can be inserted.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="length">The length value.</param>
        /// <returns>The view itself.</returns>
        public static T MaxLength<T>(this T view, int length) where T : TextEditor
        {
            view.MaxLength = length;
            return view;
        }

        /// <summary>
        /// Whether the cursor should blink or not.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="blink">The blink value.</param>
        /// <returns>The view itself.</returns>
        public static T EnableCursorBlink<T>(this T view, bool blink) where T : TextEditor
        {
            view.EnableCursorBlink = blink;
            return view;
        }

        /// <summary>
        /// The cursor will stop blinking after this number of seconds (if non-zero).<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="duration">The duration value.</param>
        /// <returns>The view itself.</returns>
        public static T CursorBlinkDuration<T>(this T view, float duration) where T : TextEditor
        {
            view.CursorBlinkDuration = duration;
            return view;
        }

        /// <summary>
        /// Gets or sets the width of the cursor.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="width">The width value.</param>
        /// <returns>The view itself.</returns>
        public static T CursorWidth<T>(this T view, int width) where T : TextEditor
        {
            view.CursorWidth = width;
            return view;
        }

        /// <summary>
        /// Horizontal scrolling will occur if the cursor is this close to the control border.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="threshold">The threshold value.</param>
        /// <returns>The view itself.</returns>
        public static T ScrollThreshold<T>(this T view, float threshold) where T : TextEditor
        {
            view.ScrollThreshold = threshold;
            return view;
        }

        /// <summary>
        /// The scroll speed in pixels per second.<br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="speed">The speed value.</param>
        /// <returns>The view itself.</returns>
        public static T ScrollSpeed<T>(this T view, float speed) where T : TextEditor
        {
            view.ScrollSpeed = speed;
            return view;
        }

        /// <summary>
        /// Whether remove FrontInset to TextEditor. <br />
        /// This property is used when the xBearing of first glyph must not be trimmed.<br />
        /// When set to false, The gap between (0, 0) from the first glyph's leftmost pixel is included in the width of text label.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="remove">The remove value.</param>
        /// <returns>The view itself.</returns>
        public static T RemoveFrontInset<T>(this T view, bool remove) where T : TextEditor
        {
            view.RemoveFrontInset = remove;
            return view;
        }

        /// <summary>
        /// Whether remove BackInset to TextEditor. <br />
        /// This property is used when the advance of last glyph must not be trimmed.<br />
        /// When set to false, The gap between the last glyph's rightmost pixel and X coordinate that next glyph will be placed is included in the width of text label.
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="remove">The remove value.</param>
        /// <returns>The view itself.</returns>
        public static T RemoveBackInset<T>(this T view, bool remove) where T : TextEditor
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
        public static T PrimaryCursorPosition<T>(this T view, int position) where T : TextEditor
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
        public static T TextShadow<T>(this T view, float blurRadius, UIColor color, float offsetX = 0, float offsetY = 0) where T : TextEditor
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
        public static T TextShadow<T>(this T view, Text.Shadow shadow) where T : TextEditor
        {
            view.SetShadow(shadow);
            return view;
        }

        /// <summary>
        /// Set underline to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="underline">The underline value.</param>
        /// <returns>The view itself.</returns>
        public static T Underline<T>(this T view, Text.Underline underline) where T : TextEditor
        {
            view.SetUnderline(underline);
            return view;
        }

        /// <summary>
        /// Set outline to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="outline">The outline value.</param>
        /// <returns>The view itself.</returns>
        public static T Outline<T>(this T view, Text.Outline outline) where T : TextEditor
        {
            view.SetOutline(outline);
            return view;
        }

        /// <summary>
        /// Set hidden input to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="input">The hidden input value.</param>
        /// <returns>The view itself.</returns>
        public static T HiddenInput<T>(this T view, Text.HiddenInput input) where T : TextEditor
        {
            view.SetHiddenInput(input);
            return view;
        }

        /// <summary>
        /// Set inputFilter to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="inputFilter">The inputFilter value.</param>
        /// <returns>The view itself.</returns>
        public static T InputFilter<T>(this T view, Text.InputFilter inputFilter) where T : TextEditor
        {
            view.SetInputFilter(inputFilter);
            return view;
        }

        /// <summary>
        /// Set strikethrough to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="strikethrough">The strikethrough value.</param>
        /// <returns>The view itself.</returns>
        public static T Strikethrough<T>(this T view, Text.Strikethrough strikethrough) where T : TextEditor
        {
            view.SetStrikethrough(strikethrough);
            return view;
        }

        /// <summary>
        /// Set placeholder to TextEditor. <br />
        /// </summary>
        /// <typeparam name="T">The type of the view.</typeparam>
        /// <param name="view">The extension target.</param>
        /// <param name="placeholder">The placeholder value.</param>
        /// <returns>The view itself.</returns>
        public static T Placeholder<T>(this T view, Text.Placeholder placeholder) where T : TextEditor
        {
            view.SetPlaceholder(placeholder);
            return view;
        }
        End of To-DO */

        /* Getters */

        /// <summary>
        /// Gets the color for the text of the View.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The text color value.</returns>
        public static UIColor TextColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.TextColor);
        }

        /// <summary>
        /// Gets the color for the placeholder text of the View.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The placeholder text color value.</returns>
        public static UIColor PlaceholderTextColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.PlaceholderTextColor);
        }

        /// <summary>
        /// Gets the color for the primary cursor.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The primary cursor color value.</returns>
        public static UIColor PrimaryCursorColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.PrimaryCursorColor);
        }

        /// <summary>
        /// Gets the color for the secondary cursor.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The secondary cursor color value.</returns>
        public static UIColor SecondaryCursorColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.SecondaryCursorColor);
        }

        /// <summary>
        /// Gets the color for the selection highlight.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The selection highlight color value.</returns>
        public static UIColor SelectionHighlightColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.SelectionHighlightColor);
        }

        /// <summary>
        /// Gets the color for the input.
        /// </summary>
        /// <param name="view">The extension target.</param>
        /// <returns>The input color value.</returns>
        public static UIColor InputColor(this TextEditor view)
        {
            //FIXME: we need to set UI value type directly without converting reference value.
            return UIColor.From(view.InputColor);
        }
    }
}
