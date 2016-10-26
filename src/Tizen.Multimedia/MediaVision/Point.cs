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
    /// This class represents a point in 2D space.
    /// </summary>
    public class Point
    {
        internal Point()
        {
        }

        /// <summary>
        /// The constructor of Point class
        /// </summary>
        /// <param name="x">X-axis coordinate of the point in 2D space</param>
        /// <param name="y">Y-axis coordinate of the point in 2D space</param>
        /// <code>
        /// 
        /// </code>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Gets X-axis coordinate of the point in 2D space
        /// </summary>
        public int X
        {
            get;
            internal set;
        }

        /// <summary>
        /// Gets Y-axis coordinate of the point in 2D space
        /// </summary>
        public int Y
        {
            get;
            internal set;
        }

        internal new string ToString()
        {
            return string.Format("({0}, {1})", X, Y);
        }
    }
}
