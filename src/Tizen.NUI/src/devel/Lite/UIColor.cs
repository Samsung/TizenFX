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
using System;
using System.ComponentModel;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI
{
    /// <summary>
    /// Defines a value type of color.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial struct UIColor : IEquatable<UIColor>, IToken<UIColor>
    {
        private float _r; // multiply alpha for token
        private float _g; // fixed alpha for token
        private float _b;
        private float _a;
        private string _tokenId;

        /// <summary>
        /// Initializes a new instance of the <see cref="UIColor"/> struct.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public UIColor(float r, float g, float b, float a)
        {
            _r = r;
            _g = g;
            _b = b;
            _a = a;
            _tokenId = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIColor"/> struct.
        /// </summary>
        /// <param name="value">The value of 0xRRGGBB format.</param>
        /// <param name="alpha">The alpha value between 0.0 and 1.0.</param>
        /// <example>
        /// <code>
        ///     new UIColor(0xFF0000, 1f); // Solid red
        ///     new UIColor(0x00FF00, 0.5f) // Half transparent green
        /// </code>
        /// </example>
        public UIColor(uint value, float alpha)
        {
            _r = ((value >> 16) & 0xff) / 255.0f;
            _g = ((value >> 8) & 0xff) / 255.0f;
            _b = (value & 0xff) / 255.0f;
            _a = alpha;
            _tokenId = string.Empty;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="UIColor"/> struct.
        /// </summary>
        /// <param name="tokenId">The unique identifier of the token.</param>
        /// <param name="multiplyAlpha">The alpha value to multiply by.</param>
        /// <param name="fixedAlpha">The fixed alpha value.</param>
        private UIColor(string tokenId, float multiplyAlpha, float fixedAlpha = -1f)
        {
            if (string.IsNullOrEmpty(tokenId))
            {
                throw new ArgumentException("tokenId should not be null or empty");
            }

            _r = multiplyAlpha; // multiply alpha
            _g = fixedAlpha; // fixed alpha (-1 indicates no fixed)
            _b = 0f;
            _a = 0f;
            _tokenId = tokenId;
        }

        /// <summary>
        /// Gets a value indicating whether this is default.
        /// </summary>
        public readonly bool IsDefault => _r == -1 && _g == -1 && _b == -1 && _a == -1;

        /// <summary>
        /// Gets a value indicating whether this is zero.
        /// </summary>
        public readonly bool IsZero => _r == 0 && _g == 0 && _b == 0 && _a == 0;

        /// <summary>
        /// Gets the red component of the color.
        /// </summary>
        public readonly float R
        {
            get
            {
                if (IsToken)
                {
                    return GetTokenValue().R;
                }
                return _r;
            }
        }

        /// <summary>
        /// Gets the green component of the color.
        /// </summary>
        public readonly float G
        {
            get
            {
                if (IsToken)
                {
                    return GetTokenValue().G;
                }
                return _g;
            }
        }

        /// <summary>
        /// Gets the blue component of the color.
        /// </summary>
        public readonly float B
        {
            get
            {
                if (IsToken)
                {
                    return GetTokenValue().B;
                }
                return _b;
            }
        }

        /// <summary>
        /// Gets the alpha component of the color.
        /// </summary>
        public readonly float A
        {
            get
            {
                if (IsToken)
                {
                    return CalculateTokenAlpha(GetTokenValue().A);
                }
                return _a;
            }
        }

        /// <summary>
        /// Gets the unique identifier of the token.
        /// </summary>
        public readonly string Id
        {
            get => _tokenId;
        }

        /// <summary>
        /// Whether this is token.
        /// </summary>
        public readonly bool IsToken => !string.IsNullOrEmpty(_tokenId);

        /// <inheritdoc/>
        readonly UIColor IToken<UIColor>.Value
        {
            get
            {
                if (IsToken)
                {
                    var color = GetTokenValue();
                    return new (color._r, color._g, color._b, CalculateTokenAlpha(color._a));
                }

                return this;
            }
        }

        /// <summary>
        /// Creates a new color from the token table.
        /// </summary>
        /// <param name="id">The unique identifier of the token.</param>
        public static UIColor Token(string id) => new (id, 1f);

        internal static UIColor From(NUI.Vector4 vector4) => new UIColor(vector4.X, vector4.Y, vector4.Z, vector4.W);

        /// <summary>
        /// Compares two UIColor for equality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are equal, otherwise false.</returns>
        public static bool operator ==(UIColor operand1, UIColor operand2)
        {
            return operand1.Equals(operand2);
        }

        /// <summary>
        /// Compares two UIColor for inequality.
        /// </summary>
        /// <param name="operand1">The first operand object.</param>
        /// <param name="operand2">The second operand object.</param>
        /// <returns>True if both are not equal, otherwise false.</returns>
        public static bool operator !=(UIColor operand1, UIColor operand2)
        {
            return !operand1.Equals(operand2);
        }

        /// <summary>
        /// Whether this is equivalent to other.
        /// </summary>
        public bool Equals(UIColor other)
        {
            if (IsToken && other.IsToken)
            {
                return _tokenId == other._tokenId && GetTokenFixedAlpha() == other.GetTokenFixedAlpha() && GetTokenMultiplyAlpha() == other.GetTokenMultiplyAlpha();
            }

            return R == other.R && G == other.G && B == other.B && A == other.A;
        }

        ///  <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is UIColor other)
            {
                return Equals(other);
            }
            return base.Equals(obj);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashcode = _r.GetHashCode();
                hashcode = hashcode * 397 ^ _g.GetHashCode();
                hashcode = hashcode * 397 ^ _b.GetHashCode();
                hashcode = hashcode * 397 ^ _a.GetHashCode();
                hashcode = hashcode * 397 ^ _tokenId.GetHashCode();
                return hashcode;
            }
        }

        /// <summary>
        /// Multiplies the alpha component of the color by the specified value.
        /// </summary>
        /// <param name="alpha">The value to multiply the alpha component by.</param>
        /// <returns>The new color.</returns>
        public readonly UIColor MultiplyAlpha(float alpha)
        {
            if (IsToken)
            {
                return new (_tokenId, GetTokenMultiplyAlpha() * alpha);
            }
            else
            {
                return new (_r, _g, _b, _a * alpha);
            }
        }

        /// <summary>
        /// Returns a new color object with the specified alpha value.
        /// </summary>
        /// <param name="alpha">The new alpha value.</param>
        /// <returns>A new color object with the specified alpha value.</returns>
        public readonly UIColor WithAlpha(float alpha)
        {
            if (IsToken)
            {
                return new (_tokenId, 1f, alpha);
            }
            else
            {
                return new (_r, _g, _b, alpha);
            }
        }

        /// <inheritdoc/>
        public override string ToString() => $"R:{R}, G:{G}, B:{B}, A:{A}";

        /// <summary>
        /// Provides an implicit conversion between <see cref="UIColor"/> and <see cref="Color"/>.
        /// </summary>
        /// <param name="uiColor">The <see cref="UIColor"/> to convert.</param>
        /// <returns>The converted <see cref="Color"/>.</returns>
        public static implicit operator Color(UIColor uiColor) => uiColor.ToReferenceType();

        internal readonly Color ToReferenceType() => new Color(R, G, B, A);

        private readonly UIColor GetTokenValue()
        {
            if (!TokenManager.ColorTable.TryGetValue(_tokenId, out var color))
            {
                Log.Info("NUI", $"Color name '{_tokenId}' is not found in the color table.");
                return Default;
            }
            return color;
        }

        private readonly float GetTokenMultiplyAlpha() => _r;

        private readonly bool HasTokenFixedAlpha() => _g != -1f;

        private readonly float GetTokenFixedAlpha() => _g;

        private readonly float CalculateTokenAlpha(float alpha) => HasTokenFixedAlpha() ? GetTokenFixedAlpha() : alpha * GetTokenMultiplyAlpha();
    }
}
