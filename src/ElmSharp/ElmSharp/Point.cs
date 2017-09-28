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

namespace ElmSharp
{
    /// <summary>
    /// The Point is a struct that defines a 2-D point as a pair of generic type.
    /// </summary>
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Location along the horizontal axis.
        /// </summary>
        public int X;

        /// <summary>
        /// Location along the vertical axis.
        /// </summary>
        public int Y;

        /// <summary>
        /// A human-readable representation of the <see cref="T:Tizen.UI.Point" />.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1}}}".</returns>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1}}}", X, Y);
        }

        /// <summary>
        /// Gets hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return X.GetHashCode() ^ (Y.GetHashCode() * 397);
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        public bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        /// Whether the two <see cref="T:Tizen.UI.Point" />s are equal.
        /// </summary>
        /// <param name="p1">A <see cref="T:Tizen.UI.Point" /> on the left hand side.</param>
        /// <param name="p2">A <see cref="T:Tizen.UI.Point" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Point" />s have equal values.</returns>
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Whether two <see cref="T:Tizen.UI.Point" />s are not equal.
        /// </summary>
        /// <param name="p1">A <see cref="T:Tizen.UI.Point" /> on the left hand side.</param>
        /// <param name="p2">A <see cref="T:Tizen.UI.Point" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Point" />s do not have equal values.</returns>
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
    }
}