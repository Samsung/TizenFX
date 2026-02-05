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

namespace Tizen.WindowSystem
{
    /// <summary>
    /// This class contains the data related to the EdgeDrag event.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EdgeDragEventArgs : EventArgs
    {
        internal EdgeDragEventArgs(GestureState mode, int fingers, int cx, int cy, GestureEdge edge)
        {
            Mode = mode;
            Fingers = fingers;
            Cx = cx;
            Cy = cy;
            Edge = edge;
        }
        /// <summary>
        /// Mode
        /// </summary>
        public GestureState Mode{ get; internal set; }
        /// <summary>
        /// Fingers
        /// </summary>
        public int Fingers{ get; internal set;}
        /// <summary>
        /// Cx
        /// </summary>
        public int Cx{ get; internal set;}
        /// <summary>
        /// Cy
        /// </summary>
        public int Cy{ get; internal set;}
        /// <summary>
        /// Edge
        /// </summary>
        public GestureEdge Edge{ get; internal set;}
    }
}
