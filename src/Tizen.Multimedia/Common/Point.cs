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
    /// Represents a point in the 2D space.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public struct Point
    {

        /// <summary>
        /// Initializes a new instance of the Point with the specified coordinates.
        /// </summary>
        /// <param name="x">X-axis coordinate of the point in the 2D space.</param>
        /// <param name="y">Y-axis coordinate of the point in the 2D space.</param>
        /// <since_tizen> 3 </since_tizen>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets the X-axis coordinate of the point in the 2D space.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the Y-axis coordinate of the point in the 2D space.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public int Y
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override string ToString() => $"X={X.ToString()}, Y={Y.ToString()}";

        /// <summary>
        /// Gets the hash code for this instance of <see cref="Point"/>.
        /// </summary>
        /// <returns>The hash code for this instance of <see cref="Point"/>.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="Point"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the points are equal; otherwise, false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public override bool Equals(object obj)
        {
            return obj is Point && this == (Point)obj;
        }

        /// <summary>
        /// Compares two instances of <see cref="Point"/> for equality.
        /// </summary>
        /// <param name="point1">A <see cref="Point"/> to compare.</param>
        /// <param name="point2">A <see cref="Point"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Point"/> are equal; otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator ==(Point point1, Point point2)
        {
            return point1.X == point2.X && point1.Y == point2.Y;
        }

        /// <summary>
        /// Compares two instances of <see cref="Point"/> for inequality.
        /// </summary>
        /// <param name="point1">A <see cref="Point"/> to compare.</param>
        /// <param name="point2">A <see cref="Point"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Point"/> are not equal; otherwise false.</returns>
        /// <since_tizen> 3 </since_tizen>
        public static bool operator !=(Point point1, Point point2)
        {
            return !(point1 == point2);
        }
    }
}
