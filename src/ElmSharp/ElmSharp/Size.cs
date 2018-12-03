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
    /// The Size is a struct defining the height and width as a pair of generic type.
    /// </summary>
    /// <since_tizen> preview </since_tizen>
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        /// Magnitude along the horizontal axis, in platform-defined units.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Width;

        /// <summary>
        /// Magnitude along the vertical axis, in platform-specific units.
        /// </summary>
        /// <since_tizen> preview </since_tizen>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the size structure from specified dimensions.
        /// </summary>
        /// <param name="width">The width to set.</param>
        /// <param name="height">The height to set.</param>
        /// <since_tizen> preview </since_tizen>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// A human-readable representation of <see cref="Size"/>.
        /// </summary>
        /// <returns>The string is formatted as "{{Width={0} Height={1}}}".</returns>
        /// <since_tizen> preview </since_tizen>
        public override string ToString()
        {
            return string.Format("{{Width={0} Height={1}}}", Width, Height);
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
                return Width.GetHashCode() ^ (Height.GetHashCode() * 397);
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
            if (!(obj is Size))
                return false;

            return Equals((Size)obj);
        }

        /// <summary>
        /// Indicates whether this instance and a <see cref="Size"/> object are equal.
        /// </summary>
        /// <param name="other">The <see cref="Size"/> to compare with the current instance.</param>
        /// <returns>
        /// true if the object and this instance are of the same type and represent the same value,
        /// otherwise false.
        /// </returns>
        /// <since_tizen> preview </since_tizen>
        public bool Equals(Size other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        /// <summary>
        /// Whether both <see cref="Size"/>s are equal.
        /// </summary>
        /// <param name="s1">A <see cref="Size"/> on the left hand side.</param>
        /// <param name="s2">A <see cref="Size"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Size"/>s have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator ==(Size s1, Size s2)
        {
            return s1.Equals(s2);
        }

        /// <summary>
        /// Whether both <see cref="Size"/>s are not equal.
        /// </summary>
        /// <param name="s1">A <see cref="Size"/> on the left hand side.</param>
        /// <param name="s2">A <see cref="Size"/> on the right hand side.</param>
        /// <returns>True if both <see cref="Size"/>s do not have equal values.</returns>
        /// <since_tizen> preview </since_tizen>
        public static bool operator !=(Size s1, Size s2)
        {
            return !s1.Equals(s2);
        }
    }
}