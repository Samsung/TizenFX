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
    /// The Point3D is a struct that defines a 3D point.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public struct Point3D : IEquatable<Point3D>
    {
        /// <summary>
        /// The X-coordinate of a 3D point.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int X;

        /// <summary>
        /// The Y-coordinate of a 3D point.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Y;

        /// <summary>
        /// The Z-coordinate of a 3D point.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Z;

        /// <summary>
        /// A human-readable representation of <see cref="Point3D"/>.
        /// </summary>
        /// <returns>The string is formatted as "{{X={0} Y={1} Z={2}}}".</returns>
        /// <since_tizen> preview </since_tizen>
        public override string ToString()
        {
            return string.Format("{{X={0} Y={1} Z={2}}}", X, Y, Z);
        }

        ///
        /// <since_tizen> preview </since_tizen>
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
            if (!(obj is Point3D))
                return false;

            return Equals((Point3D)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a <see cref="Point3D"/> object are equal.
        /// </summary>
        /// <param name="other">The <see cref="Point3D"/> to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are of the same type and represent the same value.
        /// otherwise, false.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public bool Equals(Point3D other)
        {
            return X.Equals(other.X) && Y.Equals(other.Y) && Z.Equals(other.Z);
        }

        /// <summary>
        /// Whether both <see cref="Point3D"/>s are equal.
        /// </summary>
        /// <param name="p1">A <see cref="Point3D"/> on the left hand side.</param>
        /// <param name="p2">A <see cref="Point3D"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Point3D"/>s have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator ==(Point3D p1, Point3D p2)
        {
            return p1.Equals(p2);
        }

        /// <summary>
        /// Whether both <see cref="Point3D"/>s are not equal.
        /// </summary>
        /// <param name="p1">A <see cref="Point3D"/> on the left hand side.</param>
        /// <param name="p2">A <see cref="Point3D"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Point3D"/>s do not have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator !=(Point3D p1, Point3D p2)
        {
            return !p1.Equals(p2);
        }
    }
}