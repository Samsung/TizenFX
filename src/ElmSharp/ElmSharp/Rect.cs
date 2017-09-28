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
    /// The Rect is a struct that represent rectangluar space.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Rect : IEquatable<Rect>
    {
        /// <summary>
        /// Creates and initializes a new instance of the Rect class.
        /// </summary>
        /// <param name="x">X axis value.</param>
        /// <param name="y">Y axis value.</param>
        /// <param name="w">Width value.</param>
        /// <param name="h">Height value.</param>
        public Rect(int x, int y, int w, int h)
        {
            X = x;
            Y = y;
            Width = w;
            Height = h;
        }

        /// <summary>
        /// Gets or sets the position of this Rectangle on the X axis.
        /// </summary>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the position of this Rectangle on the Y axis.
        /// </summary>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of this Rectangle.
        /// </summary>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of this Rectangle.
        /// </summary>
        public int Height { get; set; }

        /// <summary>
        /// Gets the position of this Rectangle on the X axis.
        /// </summary>
        public int Left { get { return X; } }

        /// <summary>
        /// Gets the extent along the X axis.
        /// </summary>
        public int Right { get { return X + Width; } }

        /// <summary>
        /// Gets the position of this Rectangle on the Y axis.
        /// </summary>
        public int Top { get { return Y; } }

        /// <summary>
        /// Gets the extent along the Y axis.
        /// </summary>
        public int Bottom { get { return Y + Height; } }

        /// <summary>
        /// Gets the Point defined by Rectangle.Left and Rectangle.Top.
        /// </summary>
        public Point Location { get { return new Point { X = X, Y = Y }; } }

        /// <summary>
        /// Gets the extent of the Rectangle along its X and Y axis.
        /// </summary>
        public Size Size { get { return new Size { Width = Width, Height = Height }; } }

        /// <summary>
        /// A human-readable representation of the <see cref="T:Tizen.UI.Rect" />.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1} Width={2} Height={3}}}".</returns>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1} Width={2} Height={3}}}", X, Y, Width, Height);
        }

        /// <summary>
        /// Gets the hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
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

        public override bool Equals(object obj)
        {
            if (!(obj is Rect))
                return false;

            return Equals((Rect)obj);
        }

        public bool Equals(Rect other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        /// <summary>
        /// Whether the two <see cref="T:Tizen.UI.Rectangle" />s are equal.
        /// </summary>
        /// <param name="r1">A <see cref="T:Tizen.UI.Rectangle" /> on the left hand side.</param>
        /// <param name="r2">A <see cref="T:Tizen.UI.Rectangle" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Rectangle" />s have equal values.</returns>
        public static bool operator ==(Rect r1, Rect r2)
        {
            return r1.Equals(r2);
        }

        /// <summary>
        /// Whether two <see cref="T:Tizen.UI.Rectangle" />s are not equal.
        /// </summary>
        /// <param name="r1">A <see cref="T:Tizen.UI.Rectangle" /> on the left hand side.</param>
        /// <param name="r2">A <see cref="T:Tizen.UI.Rectangle" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Rectangle" />s do not have equal values.</returns>
        public static bool operator !=(Rect r1, Rect r2)
        {
            return !r1.Equals(r2);
        }
    }
}