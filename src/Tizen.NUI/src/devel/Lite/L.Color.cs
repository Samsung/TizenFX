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

namespace Tizen.NUI.L
{
    /// <summary>
    /// Defines a value type of color.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public struct Color
    {
        public static readonly Color Transparent = new Color(0, 0, 0, 0);
        public static readonly Color Black = new Color(0, 0, 0, 1);
        public static readonly Color White = new Color(1, 1, 1, 1);
        public static readonly Color Red = new Color(1, 0, 0, 1);
        public static readonly Color Green = new Color(0, 1, 0, 1);
        public static readonly Color Blue = new Color(0, 0, 1, 1);

        /// <summary>
        /// Initializes a new instance of the <see cref="Color"/> struct.
        /// </summary>
        /// <param name="r">The red component.</param>
        /// <param name="g">The green component.</param>
        /// <param name="b">The blue component.</param>
        /// <param name="a">The alpha component.</param>
        public Color(float r, float g, float b, float a)
        {
            R = r;
            G = g;
            B = b;
            A = a;
        }

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
        public readonly Color MultiplyAlpha(float alpha) => new Color(R, G, B, A * alpha);

        /// <summary>
        /// Returns a new color object with the specified alpha value.
        /// </summary>
        /// <param name="alpha">The new alpha value.</param>
        /// <returns>A new color object with the specified alpha value.</returns>
        public readonly Color WithAlpha(float alpha) => new Color(R, G, B, alpha);

        internal readonly NUI.Color ToReferenceType() => new NUI.Color(R, G, B, A);
    }
}
