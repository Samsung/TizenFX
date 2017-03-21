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
        /// Gets or sets the size of the rectangle.
        /// </summary>
        public Size Size
        {
            get { return _size; }
            set { _size = value; }
        }

        public override string ToString() => $"{_location.ToString()}, {_size.ToString()}";

        public override int GetHashCode()
        {
            return new { Location, Size }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Rectangle && this == (Rectangle)obj;
        }

        public static bool operator ==(Rectangle lhs, Rectangle rhs)
        {
            return lhs.Location == rhs.Location && lhs.Size == rhs.Size;
        }

        public static bool operator !=(Rectangle lhs, Rectangle rhs)
        {
            return !(lhs == rhs);
        }
    }
}
