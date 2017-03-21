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

        public override string ToString() => $"Width={ Width.ToString() }, Height={ Height.ToString() }";

        public override int GetHashCode()
        {
            return new { Width, Height }.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            return obj is Size && this == (Size)obj;
        }

        public static bool operator ==(Size lhs, Size rhs)
        {
            return lhs.Width == rhs.Width && lhs.Height == rhs.Height;
        }

        public static bool operator !=(Size lhs, Size rhs)
        {
            return !(lhs == rhs);
        }
    }
}
