/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */
using System;
using System.ComponentModel;

namespace Tizen.NUI.WindowSystem
{
    /// <summary>
    /// This class contains the data related to the EdgeSwipe event.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EdgeSwipeEventArgs : EventArgs
    {
        internal EdgeSwipeEventArgs(int mode, int fingers, int sx, int sy, int edge)
        {
            Mode = mode;
            Fingers = fingers;
            Sx = sx;
            Sy = sy;
            Edge = edge;
        }
        /// <summary>
        /// Mode
        /// </summary>
        public int Mode{ get; internal set; }
        /// <summary>
        /// Fingers
        /// </summary>
        public int Fingers{ get; internal set;}
        /// <summary>
        /// Sx
        /// </summary>
        public int Sx{ get; internal set;}
        /// <summary>
        /// Sy
        /// </summary>
        public int Sy{ get; internal set;}
        /// <summary>
        /// Edge
        /// </summary>
        public int Edge{ get; internal set;}
    }
}
