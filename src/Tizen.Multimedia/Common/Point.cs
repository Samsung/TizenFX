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
    /// Represents a point in 2D space.
    /// </summary>
    public struct Point
    {

        /// <summary>
        /// Initializes a new instance of the Point with the specified coordinates.
        /// </summary>
        /// <param name="x">X-axis coordinate of the point in 2D space.</param>
        /// <param name="y">Y-axis coordinate of the point in 2D space.</param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets or sets X-axis coordinate of the point in 2D space.
        /// </summary>
        public int X
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets Y-axis coordinate of the point in 2D space.
        /// </summary>
        public int Y
        {
            get;
            set;
        }

        public override string ToString() => $"X={X}, Y={Y}";

        public override int GetHashCode()
        {
            return new { X, Y }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            if ((obj is Point) == false)
            {
                return false;
            }

            Point rhs = (Point)obj;
            return X == rhs.X && Y == rhs.Y;
        }

        public static bool operator ==(Point lhs, Point rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(Point lhs, Point rhs)
        {
            return !lhs.Equals(rhs);
        }
    }
}
