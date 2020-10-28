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
    /// The Point is a struct that defines the 2D point as a pair of generic type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// Location along the horizontal axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int X;

        /// <summary>
        /// Location along the vertical axis.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Y;

        /// <summary>
        /// A human readable representation of <see cref="Point"/>.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1}}}".</returns>
        /// <since_tizen> preview </since_tizen>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1}}}", X, Y);
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
                return X.GetHashCode() ^ (Y.GetHashCode() * 397);
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
            if (!(obj is Point))
                return false;

            return Equals((Point)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a <see cref="Point"/> object are equal.
        /// </summary>
        /// <param name="other">The <see cref="Point"/> to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are the same type and represent the same value,
        /// otherwise false.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public bool Equals(Point other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y);
        }

        /// <summary>
        /// Whether both <see cref="Point"/>s are equal.
        /// </summary>
        /// <param name="p1">A <see cref="Point"/> on the left hand side.</param>
        /// <param name="p2">A <see cref="Point"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Point"/>s have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator ==(Point p1, Point p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Whether both <see cref="Point"/>s are not equal.
        /// </summary>
        /// <param name="p1">A <see cref="Point"/> on the left hand side.</param>
        /// <param name="p2">A <see cref="Point"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Point"/>s do not have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator !=(Point p1, Point p2)
        {
            return !p1.Equals(p2);
        }
    }
}