// Copyright (c) 2021 Samsung Electronics Co., Ltd.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;

namespace Tizen.NUI.Text
{
    /// <summary>
    /// A struct to pass data of InputFilter PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// InputFilter filters input based on regular expressions. <br />
    /// Users can set the Accepted or Rejected regular expression set, or both. <br />
    /// If both are used, Rejected has higher priority. <br />
    /// The character set must follow the regular expression rules. <br />
    /// Behaviour can not be guaranteed for incorrect grammars. <br />
    /// Refer the link below for detailed rules. <br />
    /// The functions in std::regex library use the ECMAScript grammar: <br />
    /// http://cplusplus.com/reference/regex/ECMAScript/ <br />
    /// The InputFilter struct is used as an argument to SetInputFilter and GetInputFilter methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetInputFilter"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetInputFilter"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetInputFilter"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetInputFilter"/>. <br />
    /// </remarks>
    /// <since_tizen> 9 </since_tizen>
    public struct InputFilter : IEquatable<InputFilter>
    {
        /// <summary>
        /// A regular expression in the set of characters to be accepted by the inputFilter.
        /// </summary>
        public string Accepted { get; set; }

        /// <summary>
        /// A regular expression in the set of characters to be rejected by the inputFilter.
        /// </summary>
        public string Rejected { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal InputFilter, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is InputFilter other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The InputFilter to compare with the current InputFilter.</param>
        /// <returns>true if equal InputFilter, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(InputFilter other) => Accepted == other.Accepted && Rejected == other.Rejected;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsInputFilter">InputFilter to compare</param>
        /// <param name="rhsInputFilter">InputFilter to be compared</param>
        /// <returns>true if InputFilters are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(InputFilter lhsInputFilter, InputFilter rhsInputFilter) => lhsInputFilter.Equals(rhsInputFilter);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsInputFilter">InputFilter to compare</param>
        /// <param name="rhsInputFilter">InputFilter to be compared</param>
        /// <returns>true if InputFilters are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(InputFilter lhsInputFilter, InputFilter rhsInputFilter) => !lhsInputFilter.Equals(rhsInputFilter);

        /// <summary>
        /// Gets the hash code of this InputFilter.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Accepted, Rejected).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of Strikethrough PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The Strikethrough struct is used as an argument to SetStrikethrough and GetStrikethrough methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetStrikethrough"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetStrikethrough"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetStrikethrough"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetStrikethrough"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetStrikethrough"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetStrikethrough"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Strikethrough : IEquatable<Strikethrough>
    {
        /// <summary>
        /// Whether the strikethrough is enabled (the default value is false).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Enable { get; set; }

        /// <summary>
        /// The color of the strikethrough (if not provided then the color of the text is used).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The height in pixels of the strikethrough (if null, the default value is 1.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Height { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal Strikethrough, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Strikethrough other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The Strikethrough to compare with the current Strikethrough.</param>
        /// <returns>true if equal Strikethrough, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Strikethrough other) => Enable == other.Enable && Color == other.Color && Height == other.Height;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsStrikethrough">Strikethrough to compare</param>
        /// <param name="rhsStrikethrough">Strikethrough to be compared</param>
        /// <returns>true if Strikethroughs are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Strikethrough lhsStrikethrough, Strikethrough rhsStrikethrough) => lhsStrikethrough.Equals(rhsStrikethrough);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsStrikethrough">Strikethrough to compare</param>
        /// <param name="rhsStrikethrough">Strikethrough to be compared</param>
        /// <returns>true if Strikethroughs are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Strikethrough lhsStrikethrough, Strikethrough rhsStrikethrough) => !lhsStrikethrough.Equals(rhsStrikethrough);

        /// <summary>
        /// Gets the hash code of this Strikethrough.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Enable, Color, Height).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of FontStyle PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The FontStyle struct is used as an argument to SetFontStyle and GetFontStyle methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetFontStyle"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetFontStyle"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetFontStyle"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct FontStyle : IEquatable<FontStyle>
    {
        /// <summary>
        /// The Width defines occupied by each glyph.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontWidthType Width { get; set; }

        /// <summary>
        /// The Weight defines the thickness or darkness of the glyphs.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontWeightType Weight { get; set; }

        /// <summary>
        /// The Slant defines whether to use italics.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSlantType Slant { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal FontStyle, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is FontStyle other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The FontStyle to compare with the current FontStyle.</param>
        /// <returns>true if equal FontStyle, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(FontStyle other) => Width == other.Width && Weight == other.Weight && Slant == other.Slant;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsFontStyle">FontStyle to compare</param>
        /// <param name="rhsFontStyle">FontStyle to be compared</param>
        /// <returns>true if FontStyles are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(FontStyle lhsFontStyle, FontStyle rhsFontStyle) => lhsFontStyle.Equals(rhsFontStyle);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsFontStyle">FontStyle to compare</param>
        /// <param name="rhsFontStyle">FontStyle to be compared</param>
        /// <returns>true if FontStyles are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(FontStyle lhsFontStyle, FontStyle rhsFontStyle) => !lhsFontStyle.Equals(rhsFontStyle);

        /// <summary>
        /// Gets the hash code of this FontStyle.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Width, Weight, Slant).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of Underline PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The Underline struct is used as an argument to SetUnderline and GetUnderline methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetUnderline"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetUnderline"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetUnderline"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Underline : IEquatable<Underline>
    {
        /// <summary>
        /// Whether the underline is enabled (the default value is false).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Enable { get; set; }

        /// <summary>
        /// The type of the underline (the default type is Solid).
        /// </summary>
        public UnderlineType Type { get; set; }

        /// <summary>
        /// The color of the underline (if not provided then the color of the text is used).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The height in pixels of the underline (if null, the default value is 1.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Height { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal Underline, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Underline other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The Underline to compare with the current Underline.</param>
        /// <returns>true if equal Underline, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Underline other) => Enable == other.Enable && Color == other.Color && Height == other.Height;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsUnderline">Underline to compare</param>
        /// <param name="rhsUnderline">Underline to be compared</param>
        /// <returns>true if Underlines are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Underline lhsUnderline, Underline rhsUnderline) => lhsUnderline.Equals(rhsUnderline);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsUnderline">Underline to compare</param>
        /// <param name="rhsUnderline">Underline to be compared</param>
        /// <returns>true if Underlines are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Underline lhsUnderline, Underline rhsUnderline) => !lhsUnderline.Equals(rhsUnderline);

        /// <summary>
        /// Gets the hash code of this Underline.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Enable, Color, Height).GetHashCode();

        /// <summary>
        /// The width of the dashes of the dashed underline (if null, the default value is 2.0f). <br />
        /// Only valid when "UnderlineType.Dashed" type is used.
        /// </summary>
        public float? DashWidth { get; set; }

        /// <summary>
        /// The gap between the dashes of the dashed underline (if null, the default value is 1.0f). <br />
        /// Only valid when "UnderlineType.Dashed" type is used.
        /// </summary>
        public float? DashGap { get; set; }
    }

    /// <summary>
    /// A struct to pass data of Shadow PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The Shadow struct is used as an argument to SetShadow and GetShadow methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetShadow"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetShadow"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetShadow"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Shadow : IEquatable<Shadow>
    {
        /// <summary>
        /// The color of the shadow (the default color is Color.Black).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The offset in pixels of the shadow (if null, the default value is 0, 0). <br />
        /// If not provided then the shadow is not enabled. <br />
        ///
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Vector2 Offset { get; set; }

        /// <summary>
        /// The radius of the Gaussian blur for the soft shadow (if null, the default value is 0.0f). <br />
        /// If not provided then the soft shadow is not enabled. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? BlurRadius { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal Shadow, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Shadow other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The Shadow to compare with the current Shadow.</param>
        /// <returns>true if equal Shadow, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Shadow other) => Color == other.Color && Offset == other.Offset && BlurRadius == other.BlurRadius;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsShadow">Shadow to compare</param>
        /// <param name="rhsShadow">Shadow to be compared</param>
        /// <returns>true if Shadows are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Shadow lhsShadow, Shadow rhsShadow) => lhsShadow.Equals(rhsShadow);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsShadow">Shadow to compare</param>
        /// <param name="rhsShadow">Shadow to be compared</param>
        /// <returns>true if Shadows are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Shadow lhsShadow, Shadow rhsShadow) => !lhsShadow.Equals(rhsShadow);

        /// <summary>
        /// Gets the hash code of this Shadow.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Color, Offset, BlurRadius).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of Outline PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The Outline struct is used as an argument to SetOutline and GetOutline methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextLabel.GetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetOutline"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetOutline"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetOutline"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Outline : IEquatable<Outline>
    {
        /// <summary>
        /// The color of the outline (the default color is Color.White).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The width in pixels of the outline (if null, the default value is 0.0f). <br />
        /// If not provided then the outline is not enabled. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? Width { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal Outline, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Outline other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The Outline to compare with the current Outline.</param>
        /// <returns>true if equal Outline, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Outline other) => Color == other.Color && Width == other.Width;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsOutline">Outline to compare</param>
        /// <param name="rhsOutline">Outline to be compared</param>
        /// <returns>true if Outlines are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Outline lhsOutline, Outline rhsOutline) => lhsOutline.Equals(rhsOutline);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsOutline">Outline to compare</param>
        /// <param name="rhsOutline">Outline to be compared</param>
        /// <returns>true if Outlines are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Outline lhsOutline, Outline rhsOutline) => !lhsOutline.Equals(rhsOutline);

        /// <summary>
        /// Gets the hash code of this Outline.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Color, Width).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of TextFit PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The TextFit struct is used as an argument to SetTextFit and GetTextFit methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextLabel.SetTextFit"/> and <see cref="Tizen.NUI.BaseComponents.TextLabel.GetTextFit"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct TextFit : IEquatable<TextFit>
    {
        /// <summary>
        /// True to enable the text fit or false to disable (the default value is false).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Enable { get; set; }

        /// <summary>
        /// Minimum Size for text fit (if null, the default value is 10.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MinSize { get; set; }

        /// <summary>
        /// Maximum Size for text fit (if null, the default value is 100.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? MaxSize { get; set; }

        /// <summary>
        /// Step Size for font increase (if null, the default value is 1.0f).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? StepSize { get; set; }

        /// <summary>
        /// The size type of font, PointSize or PixelSize (the default value is PointSize).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontSizeType FontSizeType { get; set; }

        /// <summary>
        /// Font Size for text fit
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? FontSize { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal TextFit, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is TextFit other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The TextFit to compare with the current TextFit.</param>
        /// <returns>true if equal TextFit, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(TextFit other) => Enable == other.Enable && MinSize == other.MinSize && MaxSize == other.MaxSize &&
         StepSize == other.StepSize && FontSizeType == other.FontSizeType && FontSize == other.FontSize;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsTextFit">TextFit to compare</param>
        /// <param name="rhsTextFit">TextFit to be compared</param>
        /// <returns>true if TextFits are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(TextFit lhsTextFit, TextFit rhsTextFit) => lhsTextFit.Equals(rhsTextFit);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsTextFit">TextFit to compare</param>
        /// <param name="rhsTextFit">TextFit to be compared</param>
        /// <returns>true if TextFits are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(TextFit lhsTextFit, TextFit rhsTextFit) => !lhsTextFit.Equals(rhsTextFit);

        /// <summary>
        /// Gets the hash code of this TextFit.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Enable, MinSize, MaxSize, StepSize, FontSizeType, FontSize).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of Placeholder PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The Placeholder struct is used as an argument to SetPlaceholder and GetPlaceholder methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetPlaceholder"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetPlaceholder"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetPlaceholder"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.SetPlaceholder"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Placeholder : IEquatable<Placeholder>
    {
        /// <summary>
        /// The text to display when the TextField is empty and inactive.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Text { get; set; }

        /// <summary>
        /// The text to display when the placeholder has focus.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string TextFocused { get; set; }

        /// <summary>
        /// The color of the placeholder text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color Color { get; set; }

        /// <summary>
        /// The FontFamily of the placeholder text.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string FontFamily { get; set; }

        /// <summary>
        /// The FontStyle of the placeholder text (if null, the text control FontStyle is used).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FontStyle? FontStyle { get; set; }

        /// <summary>
        /// The PointSize of the placeholder text. <br />
        /// Not required if PixelSize provided. <br />
        /// If both provided or neither provided then the text control point size is used. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PointSize { get; set; }

        /// <summary>
        /// The PiexSize of the placeholder text.
        /// Not required if PointSize provided. <br />
        /// If both provided or neither provided then the text control point size is used. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float? PixelSize { get; set; }

        /// <summary>
        /// The ellipsis of the placeholder text (the default value is false).
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ellipsis { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal Placeholder, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is Placeholder other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The Placeholder to compare with the current Placeholder.</param>
        /// <returns>true if equal Placeholder, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(Placeholder other) =>
         Text == other.Text && TextFocused == other.TextFocused && Color == other.Color && FontFamily == other.FontFamily &&
          FontStyle == other.FontStyle && PointSize == other.PointSize && PixelSize == other.PixelSize && Ellipsis == other.Ellipsis;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsPlaceholder">Placeholder to compare</param>
        /// <param name="rhsPlaceholder">Placeholder to be compared</param>
        /// <returns>true if Placeholders are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(Placeholder lhsPlaceholder, Placeholder rhsPlaceholder) => lhsPlaceholder.Equals(rhsPlaceholder);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsPlaceholder">Placeholder to compare</param>
        /// <param name="rhsPlaceholder">Placeholder to be compared</param>
        /// <returns>true if Placeholders are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(Placeholder lhsPlaceholder, Placeholder rhsPlaceholder) => !lhsPlaceholder.Equals(rhsPlaceholder);

        /// <summary>
        /// Gets the hash code of this Placeholder.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Text, TextFocused, Color, FontFamily, FontStyle, PointSize, PixelSize, Ellipsis).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of HiddenInputSettings PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The HiddenInput struct is used as an argument to SetHiddenInput and GetHiddenInput methods. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetHiddenInput"/> and <see cref="Tizen.NUI.BaseComponents.TextField.GetHiddenInput"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct HiddenInput : IEquatable<HiddenInput>
    {
        /// <summary>
        /// The mode for input text display. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public HiddenInputModeType Mode { get; set; }

        /// <summary>
        /// All input characters are substituted by this character (if null, the default value is '*'). <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public char? SubstituteCharacter { get; set; }

        /// <summary>
        /// Length of text to show or hide, available when HideCount/ShowCount mode is used (if null, the default value is 0). <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? SubstituteCount { get; set; }

        /// <summary>
        /// Hide last character after this duration, available when ShowLastCharacter mode (if null, the default value is 1000). <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int? ShowLastCharacterDuration { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal HiddenInput, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is HiddenInput other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The HiddenInput to compare with the current HiddenInput.</param>
        /// <returns>true if equal HiddenInput, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(HiddenInput other) => Mode == other.Mode && SubstituteCharacter == other.SubstituteCharacter &&
         SubstituteCount == other.SubstituteCount && ShowLastCharacterDuration == other.ShowLastCharacterDuration;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsHiddenInput">HiddenInput to compare</param>
        /// <param name="rhsHiddenInput">HiddenInput to be compared</param>
        /// <returns>true if HiddenInputs are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(HiddenInput lhsHiddenInput, HiddenInput rhsHiddenInput) => lhsHiddenInput.Equals(rhsHiddenInput);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsHiddenInput">HiddenInput to compare</param>
        /// <param name="rhsHiddenInput">HiddenInput to be compared</param>
        /// <returns>true if HiddenInputs are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(HiddenInput lhsHiddenInput, HiddenInput rhsHiddenInput) => !lhsHiddenInput.Equals(rhsHiddenInput);

        /// <summary>
        /// Gets the hash code of this HiddenInput.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (Mode, SubstituteCharacter, SubstituteCount, ShowLastCharacterDuration).GetHashCode();
    }

    /// <summary>
    /// A struct to pass data of SelectionHandleImageLeft, SelectionHandleImageRight, SelectionHandlePressedImageLeft, SelectionHandlePressedImageRight, SelectionHandleMarkerImageLeft and SelectionHandleMarkerImageRight PropertyMap. <br />
    /// </summary>
    /// <remarks>
    /// The SelectionHandleImage struct is used as an argument to SetSelectionHandleImage, GetSelectionHandleImage methods, SetSelectionHandlePressedImage, GetSelectionHandlePressedImage, SetSelectionHandleMarkerImage and GetSelectionHandleMarkerImage. <br />
    /// See <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.SetSelectionHandleMarkerImage"/>, <see cref="Tizen.NUI.BaseComponents.TextField.GetSelectionHandleMarkerImage"/>, <br />
    /// <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandleImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandlePressedImage"/>, <see cref="Tizen.NUI.BaseComponents.TextEditor.SetSelectionHandleMarkerImage"/> and <see cref="Tizen.NUI.BaseComponents.TextEditor.GetSelectionHandleMarkerImage"/>. <br />
    /// </remarks>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct SelectionHandleImage : IEquatable<SelectionHandleImage>
    {
        /// <summary>
        /// The image path to display for the left selection handle. <br />
        /// It means the handle in the bottom-left. <br />
        /// If the handle needs to be displayed in the top-left, this image will be vertically flipped. <br />
        /// If null or empty string, it doesn't change the property. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string LeftImageUrl { get; set; }

        /// <summary>
        /// The image path to display for the right selection handle. <br />
        /// It means the handle in the bottom-right. <br />
        /// If the handle needs to be displayed in the top-right, this image will be vertically flipped. <br />
        /// If null or empty string, it doesn't change the property. <br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string RightImageUrl { get; set; }

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="obj">The object to compare with the current object.</param>
        /// <returns>true if equal SelectionHandleImage, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj) => obj is SelectionHandleImage other && this.Equals(other);

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <param name="other">The SelectionHandleImage to compare with the current SelectionHandleImage.</param>
        /// <returns>true if equal SelectionHandleImage, else false.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(SelectionHandleImage other) => LeftImageUrl == other.LeftImageUrl && RightImageUrl == other.RightImageUrl;

        /// <summary>
        /// The == operator.
        /// </summary>
        /// <param name="lhsSelectionHandleImage">SelectionHandleImage to compare</param>
        /// <param name="rhsSelectionHandleImage">SelectionHandleImage to be compared</param>
        /// <returns>true if SelectionHandleImages are equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(SelectionHandleImage lhsSelectionHandleImage, SelectionHandleImage rhsSelectionHandleImage)
         => lhsSelectionHandleImage.Equals(rhsSelectionHandleImage);

        /// <summary>
        /// The != operator.
        /// </summary>
        /// <param name="lhsSelectionHandleImage">SelectionHandleImage to compare</param>
        /// <param name="rhsSelectionHandleImage">SelectionHandleImage to be compared</param>
        /// <returns>true if SelectionHandleImages are not equal</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(SelectionHandleImage lhsSelectionHandleImage, SelectionHandleImage rhsSelectionHandleImage)
         => !lhsSelectionHandleImage.Equals(rhsSelectionHandleImage);

        /// <summary>
        /// Gets the hash code of this SelectionHandleImage.
        /// </summary>
        /// <returns>The hash code.</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode() => (LeftImageUrl, RightImageUrl).GetHashCode();
    }
}