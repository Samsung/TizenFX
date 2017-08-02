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
    /// Represents a size in 2D space.
    /// </summary>
    public struct Size
    {
        /// <summary>
        /// Initializes a new instance of the Size with the specified values.
        /// </summary>
        /// <param name="width">Width of the size.</param>
        /// <param name="height">Height of the size.</param>
        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets or sets the width of the Size.
        /// </summary>
        public int Width
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the height of the Size.
        /// </summary>
        public int Height
        {
            get;
            set;
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <value>A string that represents the current object.</value>
        public override string ToString() => $"Width={ Width.ToString() }, Height={ Height.ToString() }";

        /// <summary>
        /// Gets the hash code for this instance of <see cref="Size"/>.
        /// </summary>
        /// <value>The hash code for this instance of <see cref="Size"/>.</value>
        public override int GetHashCode()
        {
            return new { Width, Height }.GetHashCode();
        }

        /// <summary>
        /// Compares an object to an instance of <see cref="Size"/> for equality.
        /// </summary>
        /// <param name="obj">A <see cref="Object"/> to compare.</param>
        /// <returns>true if the two sizes are equal; otherwise, false.</returns>
        public override bool Equals(object obj)
        {
            return obj is Size && this == (Size)obj;
        }

        /// <summary>
        /// Compares two instances of <see cref="Size"/> for equality.
        /// </summary>
        /// <param name="size1">A <see cref="Size"/> to compare.</param>
        /// <param name="size2">A <see cref="Size"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Size"/> are equal; otherwise false.</returns>
        public static bool operator ==(Size size1, Size size2)
        {
            return size1.Width == size2.Width && size1.Height == size2.Height;
        }

        /// <summary>
        /// Compares two instances of <see cref="Size"/> for inequality.
        /// </summary>
        /// <param name="size1">A <see cref="Size"/> to compare.</param>
        /// <param name="size2">A <see cref="Size"/> to compare.</param>
        /// <returns>true if the two instances of <see cref="Size"/> are not equal; otherwise false.</returns>
        public static bool operator !=(Size size1, Size size2)
        {
            return !(size1 == size2);
        }
    }
}
