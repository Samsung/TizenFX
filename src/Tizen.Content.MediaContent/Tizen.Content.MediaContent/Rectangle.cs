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
    /// Represents the location of the object bounded by the rectangle defined by
    /// coordinates of top left corner, width, and height.
    /// </summary>
    public struct Rectangle
    {
        /// <summary>
        /// Initializes a new instance of the rectangle with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The width of the rectangle.</param>
        /// <param name="height">The height of the rectangle.</param>
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
        /// Returns the hash code for this rectangle structure.
        /// </summary>
        /// <returns>An integer that represents the hash code for this rectangle.</returns>
        public override int GetHashCode() => new { X, Y, Width, Height }.GetHashCode();

        /// <summary>
        /// Tests whether object is a rectangle structure with the same location and size of this rectangle structure.
        /// </summary>
        /// <param name="obj">The <see cref="Object"/> to compare.</param>
        /// <returns>
        /// true if object is a rectangle structure and its x, y, width, and height properties are
        /// equal to the corresponding properties of this rectangle structure; otherwise, false.
        /// </returns>
        public override bool Equals(object obj) => obj is Rectangle && this == (Rectangle)obj;

        /// <summary>
        /// Tests whether two rectangle structures have equal location and size.
        /// </summary>
        /// <param name="rect1">The <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">The <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if the two rectangle structures have equal x, y, width, and height properties; otherwise, false.</returns>
        public static bool operator ==(Rectangle rect1, Rectangle rect2)
            => rect1.X == rect2.X && rect1.Y == rect2.Y && rect1.Width == rect2.Width && rect1.Height == rect2.Height;

        /// <summary>
        /// Tests whether two rectangle structures differ in location or size.
        /// </summary>
        /// <param name="rect1">The <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">The <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if any of the x, y, width, or height properties of the two rectangle structures are unequal; otherwise false.</returns>
        public static bool operator !=(Rectangle rect1, Rectangle rect2) => !(rect1 == rect2);
    }
}
