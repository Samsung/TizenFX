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

namespace Tizen.Content.MediaContent
{
    /// <summary>
    /// Represents location of the object bounded by rectangle defined by
    /// coordinates of top left corner, width and height.
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// Initializes a new instance of the Rectangle with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The Width of the rectangle.</param>
        /// <param name="height">The Height of the rectangle.</param>
        public Rectangle(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        /// <value>The x-coordinate of the upper-left edge of the rectangle.</value>
        public int X { get; set; }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        /// <value>The y-coordinate of the upper-left edge of the rectangle.</value>
        public int Y { get; set; }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        /// <value>The width of the rectangle.</value>
        public int Width { get; set; }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        /// <value>The height of the rectangle.</value>
        public int Height { get; set; }

        /// <summary>
        /// Gets the x-coordinate of the left edge of the rectangle.
        /// </summary>
        /// <value>The x-coordinate of the left edge of the rectangle.</value>
        public int Left => X;

        /// <summary>
        /// Gets the y-coordinate of the top edge of the rectangle.
        /// </summary>
        /// <value>The y-coordinate of the top edge of the rectangle.</value>
        public int Top => Y;

        /// <summary>
        /// Gets the x-coordinate of the right edge of the rectangle.
        /// </summary>
        /// <value>The x-coordinate of the right edge of the rectangle.</value>
        public int Right => X + Width;

        /// <summary>
        /// Gets the y-coordinate of the bottom edge of the rectangle.
        /// </summary>
        /// <value>The y-coordinate of the bottom edge of the rectangle.</value>
        public int Bottom => Y + Height;

        /// <summary>
        /// Returns a string representation of the rectangle.
        /// </summary>
        /// <returns>A string representation of the current rectangle.</returns>
        public override string ToString() =>
            $"X={X.ToString()}, Y={Y.ToString()}, Width={Width.ToString()}, Height={Height.ToString()}";

        /// <summary>
        /// Returns the hash code for this Rectangle structure.
        /// </summary>
        /// <returns>An integer that represents the hash code for this rectangle.</returns>
        public override int GetHashCode() => new { X, Y, Width, Height }.GetHashCode();

        /// <summary>
        /// Tests whether obj is a Rectangle structure with the same location and size of this Rectangle structure.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>
        /// true if obj is a Rectangle structure and its X, Y, Width and Height properties are
        /// equal to the corresponding properties of this Rectangle structure; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) => obj is Rectangle && this == (Rectangle)obj;

        /// <summary>
        /// Tests whether two Rectangle structures have equal location and size.
        /// </summary>
        /// <param name="rect1">A <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">A <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if the two Rectangle structures have equal X, Y, Width, and Height properties; otherwise, false.</returns>
        public static bool operator ==(Rectangle rect1, Rectangle rect2)
            => rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;

        /// <summary>
        /// Tests whether two Rectangle structures differ in location or size.
        /// </summary>
        /// <param name="rect1">A <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">A <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if any of the X, Y, Width or Height properties of the two Rectangle structures are unequal; otherwise false.</returns>
        public static bool operator !=(Rectangle rect1, Rectangle rect2) => !(rect1 == rect2);
    }
}
