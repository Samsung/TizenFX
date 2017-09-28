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
    /// The Size is a struct that defining height and width as a pair of generic type.
    /// </summary>
    public struct Size : IEquatable<Size>
    {
        /// <summary>
        /// Magnitude along the horizontal axis, in platform-defined units.
        /// </summary>
        public int Width;

        /// <summary>
        /// Magnitude along the vertical axis, in platform-specific units.
        /// </summary>
        public int Height;

        /// <summary>
        /// Initializes a new instance of the Size structure from the specified dimensions.
        /// </summary>
        /// <param name="width">The width to set</param>
        /// <param name="height">The height to set</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// A human-readable representation of the <see cref="T:Tizen.UI.Size" />.
        /// </summary>
        /// <returns>The string is formatted as "{{Width={0} Height={1}}}".</returns>
        public override string ToString()
        {
            return string.Format("{{Width={0} Height={1}}}", Width, Height);
        }

        /// <summary>
        /// Gets hash code.
        /// </summary>
        /// <returns>The hash code.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return Width.GetHashCode() ^ (Height.GetHashCode() * 397);
            }
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Size))
                return false;

            return Equals((Size)obj);
        }

        public bool Equals(Size other)
        {
            return Width.Equals(other.Width) && Height.Equals(other.Height);
        }

        /// <summary>
        /// Whether the two <see cref="T:Tizen.UI.Size" />s are equal.
        /// </summary>
        /// <param name="s1">A <see cref="T:Tizen.UI.Size" /> on the left hand side.</param>
        /// <param name="s2">A <see cref="T:Tizen.UI.Size" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Size" />s have equal values.</returns>
        public static bool operator ==(Size s1, Size s2)
        {
            return s1.Equals(s2);
        }

        /// <summary>
        /// Whether two <see cref="T:Tizen.UI.Size" />s are not equal.
        /// </summary>
        /// <param name="s1">A <see cref="T:Tizen.UI.Size" /> on the left hand side.</param>
        /// <param name="s2">A <see cref="T:Tizen.UI.Size" /> on the right hand side.</param>
        /// <returns>True if the two <see cref="T:Tizen.UI.Size" />s do not have equal values.</returns>
        public static bool operator !=(Size s1, Size s2)
        {
            return !s1.Equals(s2);
        }
    }
}