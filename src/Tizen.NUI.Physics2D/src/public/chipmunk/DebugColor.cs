/*
 * Copyright (c) 2023 Codefoco (codefoco@codefoco.com)
 *
 * Permission is hereby granted, free of charge, to any person obtaining a copy
 * of this software and associated documentation files (the "Software"), to deal
 * in the Software without restriction, including without limitation the rights
 * to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
 * copies of the Software, and to permit persons to whom the Software is
 * furnished to do so, subject to the following conditions:
 *
 * The above copyright notice and this permission notice shall be included in all
 * copies or substantial portions of the Software.
 *
 * THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
 * IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
 * FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
 * AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
 * LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
 * OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
 * SOFTWARE.
 */

using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI.Physics2D.Chipmunk
{
    /// <summary>
    /// RGBA channels as floats used to represent the color for debug drawing.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [StructLayout(LayoutKind.Sequential)]
    public struct DebugColor : IEquatable<DebugColor>
    {
#pragma warning disable IDE0032
        private readonly float red;
        private readonly float green;
        private readonly float blue;
        private readonly float alpha;
#pragma warning restore IDE0032

        /// <summary>
        /// Red component in the RGBA color space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Red => red;

        /// <summary>
        /// Green component in the RGBA color space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Green => green;

        /// <summary>
        /// Blue component in the RGBA color space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Blue => blue;

        /// <summary>
        /// Alpha component in the RGBA color space.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float Alpha => alpha;

        /// <summary>
        /// Create a <see cref="DebugColor"/> with the given color channel values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DebugColor(float red, float green, float blue)
            : this(red, green, blue, 1.0f)
        {
        }

        /// <summary>
        /// Create a <see cref="DebugColor"/> with the given color channel values.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DebugColor(float red, float green, float blue, float alpha)
        {
            this.red = red;
            this.green = green;
            this.blue = blue;
            this.alpha = alpha;
        }

        /// <summary>
        /// Check if a <see cref="DebugColor"/> is equal to another object.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override bool Equals(object obj)
        {
            var other = obj as DebugColor?;

            if (other == null)
                return false;

            return Equals(other.Value);
        }

        /// <summary>
        /// Check if a <see cref="DebugColor"/> is reference-equal to the other.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Equals(DebugColor color)
        {
            return this == color;
        }

        /// <summary>
        /// Get the hash code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = -1813971818;

                hashCode = hashCode * -1521134295 + red.GetHashCode();
                hashCode = hashCode * -1521134295 + green.GetHashCode();
                hashCode = hashCode * -1521134295 + blue.GetHashCode();
                hashCode = hashCode * -1521134295 + alpha.GetHashCode();

                return hashCode;
            }
        }

        /// <summary>
        /// Return a string formatted as "(R, G, B, A)".
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public override string ToString()
        {
            return $"({red},{green},{blue},{alpha})";
        }

        /// <summary>
        /// Return true if two <see cref="DebugColor"/> are reference-equal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator ==(DebugColor a, DebugColor b)
        {
#pragma warning disable RECS0018 // Comparison of floating point numbers with equality operator
            return a.red == b.red &&
                a.green == b.green &&
                a.blue == b.blue &&
                a.alpha == b.alpha;
#pragma warning restore RECS0018 // Comparison of floating point numbers with equality operator
        }


        /// <summary>
        /// Return true if two <see cref="DebugColor"/> are not reference-equal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public static bool operator !=(DebugColor a, DebugColor b)
        {
            return !(a == b);
        }
    }
}
