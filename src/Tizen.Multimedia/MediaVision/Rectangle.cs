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
    /// This class represents location of the object bounded by rectangle defined by
    /// coordinates of top left corner, width and height.
    /// </summary>
    public class Rectangle
    {
        internal Rectangle()
        {
        }

        /// <summary>
        /// The constructor of the Rectangle class
        /// </summary>
        /// <param name="point">Top left corner of rectangle coordinates</param>
        /// <param name="width">Width of the bounding rectangle</param>
        /// <param name="height">Height of the bounding rectangle</param>
        /// <code>
        /// 
        /// </code>
        public Rectangle(Point point, int width, int height)
        {
            Point = point;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Gets top left corner of rectangle coordinates
        /// </summary>
        public Point Point { get; internal set; }

        /// <summary>
        /// Gets width of the bounding rectangle
        /// </summary>
        public int Width { get; internal set; }

        /// <summary>
        /// Gets height of the bounding rectangle
        /// </summary>
        public int Height { get; internal set; }

        internal new string ToString()
        {
            return string.Format("Point : [{0}, {1}], Width : {2}, Height : {3}", Point.ToString(), Width, Height);
        }
    }
}
