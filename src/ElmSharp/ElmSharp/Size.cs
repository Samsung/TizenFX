// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;

namespace ElmSharp
{
    /// <summary>
    /// Struct defining height and width as a pair of generic type.
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
        /// Returns a hash value for the <see cref="T:Tizen.UI.Size" />.
        /// </summary>
        /// <returns>A value intended for efficient insertion and lookup in hashtable-based data structures.</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                return Width.GetHashCode() ^ (Height.GetHashCode() * 397);
            }
        }

        /// <summary>
        /// Returns true if the Width and Height values of this are exactly equal to those in the argument.
        /// </summary>
        /// <param name="obj">Another <see cref="T:Tizen.UI.Size" />.</param>
        /// <returns>True if the Width and Height values are equal to those in <paramref name="obj" />. Returns false if <paramref name="obj" /> is not a <see cref="T:Tizen.UI.Size" />.</returns>
        public override bool Equals(object obj)
        {
            if (!(obj is Size))
                return false;

            return Equals((Size)obj);
        }

        /// <summary>
        /// Returns true if the Width and Height values of this are exactly equal to those in the argument.
        /// </summary>
        /// <param name="other">Another <see cref="T:Tizen.UI.Size" />.</param>
        /// <returns>True if the Width and Height values are equal to those in <paramref name="other" />.</returns>
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
