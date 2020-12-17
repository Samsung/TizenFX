/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

namespace ElmSharp
{
    /// <summary>
    /// The Rect is a struct that represents the rectangular space.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect : IEquatable<Rect>
    {
        /// <summary>
        /// Creates and initializes a new instance of the Rect class.
        /// </summary>
        /// <param name="x">X-axis value.</param>
        /// <param name="y">Y-axis value.</param>
        /// <param name="w">Width value.</param>
        /// <param name="h">Height value.</param>
        /// <since_tizen> preview </since_tizen>
        public Rect(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        /// <summary>
        /// Gets or sets the position of this rectangle on the X-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the position of this rectangle on the Y-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of this rectangle.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of this rectangle.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Height { get; set; }

        /// <summary>
        /// Gets the position of this rectangle on the X-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Left { get { return X; } }

        /// <summary>
        /// Gets the extent along the X-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Right { get { return X + Width; } }

        /// <summary>
        /// Gets the position of this rectangle on the Y-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Top { get { return Y; } }

        /// <summary>
        /// Gets the extent along the Y-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Bottom { get { return Y + Height; } }

        /// <summary>
        /// Gets the point defined by Rectangle.Left and Rectangle.Top.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Point Location { get { return new Point { X = X, Y = Y }; } }

        /// <summary>
        /// Gets the extent of the rectangle along its X-axis and Y-axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public Size Size { get { return new Size { Width = Width, Height = Height }; } }

        /// <summary>
        /// A human-readable representation of <see cref="Rect"/>.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1} Width={2} Height={3}}}".</returns>
        /// <since_tizen> preview </since_tizen>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1} Width={2} Height={3}}}", X, Y, Width, Height);
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        /// <since_tizen> preview </since_tizen>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Width.GetHashCode();
                hashCode = (hashCode * 397) ^ Height.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Indicates whether this instance and a specified object are equal.
        /// </summary>
        /// <param name="obj">The object to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are of the same type and represent the same value,
        /// otherwise false.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public override bool Equals(object obj)
        {
            if (!(obj is Rect))
                return false;

            return Equals((Rect)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a <see cref="Rect"/> object are equal.
        /// </summary>
        /// <param name="other">The <see cref="Rect"/> to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are of the same type and represent the same value,
        /// otherwise, false
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public bool Equals(Rect other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        /// <summary>
        /// Whether both <see cref="Rect"/>'s are equal.
        /// </summary>
        /// <param name="r1">A <see cref="Rect"/> on the left hand side.</param>
        /// <param name="r2">A <see cref="Rect"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Rect"/>'s have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator ==(Rect r1, Rect r2)
        {
            return r1.Equals(r2);
        }

        /// <summary>
        /// Whether both <see cref="Rect"/>'s are not equal.
        /// </summary>
        /// <param name="r1">A <see cref="Rect"/> on the left hand side.</param>
        /// <param name="r2">A <see cref="Rect"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Rect"/>'s do not have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator !=(Rect r1, Rect r2)
        {
            return !r1.Equals(r2);
        }
    }
}