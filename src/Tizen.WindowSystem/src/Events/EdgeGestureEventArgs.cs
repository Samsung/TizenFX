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
    /// This class contains the data related to edge gesture events (EdgeSwipe and EdgeDrag).
    /// For EdgeSwipe, X/Y represent the start position. For EdgeDrag, X/Y represent the current position.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class EdgeGestureEventArgs : EventArgs
    {
        internal EdgeGestureEventArgs(GestureState state, int fingers, int x, int y, GestureEdge edge)
        {
            State = state;
            Fingers = fingers;
            X = x;
            Y = y;
            Edge = edge;
        }
        /// <summary>
        /// State of the gesture.
        /// </summary>
        public GestureState State { get; internal set; }
        /// <summary>
        /// Number of fingers.
        /// </summary>
        public int Fingers { get; internal set; }
        /// <summary>
        /// X coordinate. Start position for EdgeSwipe, current position for EdgeDrag.
        /// </summary>
        public int X { get; internal set; }
        /// <summary>
        /// Y coordinate. Start position for EdgeSwipe, current position for EdgeDrag.
        /// </summary>
        public int Y { get; internal set; }
        /// <summary>
        /// Edge position.
        /// </summary>
        public GestureEdge Edge { get; internal set; }
    }
}
