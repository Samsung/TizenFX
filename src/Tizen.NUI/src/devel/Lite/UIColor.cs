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

namespace Tizen.NUI
{
    /// <summary>
    /// Defines a value type of color.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct UIColor
    {
        /// <summary>
        /// The default color. (This is to distinguish from zero corners)
        /// </summary>
        public static readonly UIColor Default = new (-1, -1, -1, -1);

        /// <summary>
        /// The transparent color.
        /// </summary>
        public static readonly UIColor Transparent = new (0, 0, 0, 0);

        /// <summary>
        /// The transparent color.
        /// </summary>
        public static readonly UIColor Black = new (0, 0, 0, 1);

        /// <summary>
        /// The white color.
        /// </summary>
        public static readonly UIColor White = new (1, 1, 1, 1);

        /// <summary>
        /// The red color.
        /// </summary>
        public static readonly UIColor Red = new (1, 0, 0, 1);

        /// <summary>
        /// The green color.
        /// </summary>
        public static readonly UIColor Green = new (0, 1, 0, 1);

        /// <summary>
        /// The blue color.
        /// </summary>
        public static readonly UIColor Blue = new (0, 0, 1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="UIColor"/> struct.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public UIColor(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
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
            R = ((value >> 16) & 0xff) / 255.0f;
            G = ((value >> 8) & 0xff) / 255.0f;
            B = (value & 0xff) / 255.0f;
            A = alpha;
        }

        internal UIColor(NUI.Vector4 vector4) : this(vector4.X, vector4.Y, vector4.Z, vector4.W)
        {
        }

        /// <summary>
        /// Gets a value indicating whether this is default.
        /// </summary>
        public readonly bool IsDefault => R == -1 && G == -1 && B == -1 && A == -1;

        /// <summary>
        /// Gets a value indicating whether this is zero.
        /// </summary>
        public readonly bool IsZero => R == 0 && G == 0 && B == 0 && A == 0;

        /// <summary>
        /// Gets the red component of the color.
        /// </summary>
        public float R
        {
            get;
        }

        /// <summary>
        /// Gets the green component of the color.
        /// </summary>
        public float G
        {
            get;
        }

        /// <summary>
        /// Gets the blue component of the color.
        /// </summary>
        public float B
        {
            get;
        }

        /// <summary>
        /// Gets the alpha component of the color.
        /// </summary>
        public float A
        {
            get;
        }

        /// <summary>
        /// Multiplies the alpha component of the color by the specified value.
        /// </summary>
        /// <param name="alpha">The value to multiply the alpha component by.</param>
        /// <returns>The new color.</returns>
        public readonly UIColor MultiplyAlpha(float alpha) => new UIColor(R, G, B, A * alpha);

        /// <inheritdoc/>
        public override string ToString() => $"R:{R}, G:{G}, B:{B}, A:{A}";

        /// <summary>
        /// Returns a new color object with the specified alpha value.
        /// </summary>
        /// <param name="alpha">The new alpha value.</param>
        /// <returns>A new color object with the specified alpha value.</returns>
        public readonly UIColor WithAlpha(float alpha) => new (R, G, B, alpha);

        internal readonly NUI.Color ToReferenceType() => new NUI.Color(R, G, B, A);
    }
}
