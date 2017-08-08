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

namespace Tizen.Multimedia
{
    /// <summary>
    /// This class represents location of the object bounded by rectangle defined by
    /// coordinates of top left corner, width and height.
    /// </summary>
    public struct Rectangle
    {
        private Point _location;
        private Size _size;

        /// <summary>
        /// Initializes a new instance of the Rectangle with the specified values.
        /// </summary>
        /// <param name="x">The x-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="y">The y-coordinate of the upper-left corner of the rectangle.</param>
        /// <param name="width">The Width of the rectangle.</param>
        /// <param name="height">The Height of the rectangle.</param>
        public Rectangle(int x, int y, int width, int height) : this(new Point(x, y),
            new Size(width, height))
        {
        }

        /// <summary>
        /// Initializes a new instance of the Rectangle with the specified values.
        /// </summary>
        /// <param name="location">A <see cref="Location"/> that represents the upper-left corner of the rectangular region.</param>
        /// <param name="size">A <see cref="Size"/> that represents the width and height of the rectangular region.</param>
        public Rectangle(Point location, Size size)
        {
            _location = location;
            _size = size;
        }

        /// <summary>
        /// Gets or sets the coordinates of the upper-left corner of the rectangle.
        /// </summary>
        public Point Location
        {
            get { return _location; }
            set { _location = value; }
        }

        /// <summary>
        /// Gets or sets the x-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }

        /// <summary>
        /// Gets or sets the y-coordinate of the upper-left corner of the rectangle.
        /// </summary>
        public int Y
        {
            get { return _location.Y; }
            set { _location.Y = value; }
        }

        /// <summary>
        /// Gets or sets the width of the rectangle.
        /// </summary>
        public int Width
        {
            get { return _size.Width; }
            set { _size.Width = value; }
        }

        /// <summary>
        /// Gets or sets the height of the rectangle.
        /// </summary>
        public int Height
        {
            get { return _size.Height; }
            set { _size.Height = value; }
        }

        /// <summary>
        /// Gets the x-coordinate of the left edge of the rectangle.
        /// </summary>
        public int Left => X;

        /// <summary>
        /// Gets the y-coordinate of the top edge of the rectangle.
        /// </summary>
        public int Top => Y;

        /// <summary>
        /// Gets the x-coordinate of the right edge of the rectangle.
        /// </summary>
        public int Right => X + Width;

        /// <summary>
        /// Gets the y-coordinate of the bottom edge of the rectangle.
        /// </summary>
        public int Bottom => Y + Height;

        /// <summary>
        /// Gets or sets the size of the rectangle.
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        public override string ToString() => $"{_location.ToString()}, {_size.ToString()}";

        /// <summary>
        /// Gets the hash code for this instance of <see cref="Rectangle"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="Rectangle"/>.</returns>
        public override int GetHashCode()
        {
            return new { Location, Size }.GetHashCode();
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="Rectangle"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the rectangles are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Rectangle && this == (Rectangle)obj;
        }

        /// <summary>
        /// Compares two instances of <see cref="Rectangle"/> for equality.
        /// </summary>
        /// <param name="rect1">A <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">A <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Rectangle"/> are equal; otherwise false.</returns>
        public static bool operator ==(Rectangle rect1, Rectangle rect2)
        {
            return rect1.Location == rect2.Location && rect1.Size == rect2.Size;
        }

        /// <summary>
        /// Compares two instances of <see cref="Rectangle"/> for inequality.
        /// </summary>
        /// <param name="rect1">A <see cref="Rectangle"/> to compare.</param>
        /// <param name="rect2">A <see cref="Rectangle"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Rectangle"/> are not equal; otherwise false.</returns>
        public static bool operator !=(Rectangle rect1, Rectangle rect2)
        {
            return !(rect1 == rect2);
        }
    }
}
