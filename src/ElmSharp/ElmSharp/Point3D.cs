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
    /// Struct defining a 3-D point.
    /// </summary>
    public struct Point3D : IEquatable<Point3D>
    {
        /// <summary>
        /// The X coordinate of a 3D point.
        /// </summary>
        public int X;

        /// <summary>
        /// The Y coordinate of a 3D point.
        /// </summary>
        public int Y;

        /// <summary>
        /// The Z coordinate of a 3D point.
        /// </summary>
        public int Z;

        /// <summary>
        /// A human-readable representation of the <see cref="T:Tizen.UI.Point3D" />.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1} Z={2}}}".</returns>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1} Z={2}}}", X, Y, Z);
        }

        /// <summary>
        /// Returns a hash value for the <see cref="T:Tizen.UI.Point3D" />.
        /// </summary>
        /// <returns>A value intended for efficient insertion and lookup in hashtable-based data structures.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int hashCode = X.GetHashCode();
                hashCode = (hashCode * 397) ^ Y.GetHashCode();
                hashCode = (hashCode * 397) ^ Z.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// Returns true if the X, Y and Z values of this are exactly equal to those in the argument.
        /// </summary>
        /// <param name="obj">Another <see cref="T:Tizen.UI.Point3D" />.</param>
        /// <returns>True if the X, Y and Z values are equal to those in <paramref name="obj" />. Returns false if <paramref name="obj" /> is not a <see cref="T:Tizen.UI.Point" />.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Point3D))
                return false;

            return Equals((Point3D)obj);
        }

        /// <summary>
        /// Returns true if the X, Y and Z values of this are exactly equal to those in the argument.
        /// </summary>
        /// <param name="other">Another <see cref="T:Tizen.UI.Point3D" />.</param>
        /// <returns>True if the X, Y and Z values are equal to those in <paramref name="other" />.</returns>
        public bool Equals(Point3D other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        /// <summary>
        /// Whether the two <see cref="T:Tizen.UI.Point3D" />s are equal.
        /// </summary>
        /// <param name="p1">A <see cref="T:Tizen.UI.Point3D" /> on the left hand side.</param>
        /// <param name="p2">A <see cref="T:Tizen.UI.Point3D" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Point3D" />s have equal values.</returns>
        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Whether two <see cref="T:Tizen.UI.Point3D" />s are not equal.
        /// </summary>
        /// <param name="p1">A <see cref="T:Tizen.UI.Point3D" /> on the left hand side.</param>
        /// <param name="p2">A <see cref="T:Tizen.UI.Point3D" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Point3D" />s do not have equal values.</returns>
        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !p1.Equals(p2);
        }
    }
}
