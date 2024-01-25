/*
 * Copyright (c) 2023 Samsung Electronics Co., Ltd All Rights Reserved
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

using System.ComponentModel;

namespace Tizen.Applications
{
    /// <summary>
    /// Represents the window position of the application.
    /// </summary>
    /// <since_tizen> 11 </since_tizen>
    public class WindowPosition
    {
        /// <summary>
        /// Initializes the instance of the WindowPosition class.
        /// </summary>
        /// <param name="x">The X position.</param>
        /// <param name="y">The Y position.</param>
        /// <param name="w">The width.</param>
        /// <param name="h">The height.</param>
        /// <since_tizen> 11 </since_tizen>
        public WindowPosition(int x, int y, int w, int h)
        {
            PositionX = x;
            PositionY = y;
            Width = w;
            Height = h;
        }

        /// <summary>
        /// The X position.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int PositionX
        {
            set;
            get;
        }
        
        /// <summary>
        /// The Y position.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int PositionY
        {
            set;
            get;
        }

        /// <summary>
        /// The width.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int Width
        {
            set;
            get;
        }

        /// <summary>
        /// The height.
        /// </summary>
        /// <since_tizen> 11 </since_tizen>
        public int Height
        {
            set;
            get;
        }
    }
}
