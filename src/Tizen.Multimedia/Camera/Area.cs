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
    /// The class containing area of the display.
    /// </summary>
    public class Area
    {
        /// <summary>
        /// Constructor for area class.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">Y coordinate</param>
        /// <param name="width">Width of area</param>
        /// <param name="height">Height of area</param>
        public Area(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        /// <summary>
        /// X coordinate of the area.
        /// </summary>
        public int X
        {
            get;
        }

        /// <summary>
        /// Y coordinate of the area.
        /// </summary>
        public int Y
        {
            get;
        }

        /// <summary>
        /// Width of area.
        /// </summary>
        public int Width
        {
            get;
        }

        /// <summary>
        /// Height of area.
        /// </summary>
        public int Height
        {
            get;
        }
    }
}

