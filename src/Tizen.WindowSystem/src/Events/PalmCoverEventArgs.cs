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
    /// This class contains the data related to the PalmCover event.
    /// </summary>
    /// This class is need to be hidden as inhouse API.
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class PalmCoverEventArgs : EventArgs
    {
        internal PalmCoverEventArgs(GestureState mode, int duration, int cx, int cy, int size, double pressure)
        {
            Mode = mode;
            Duration = duration;
            Cx = cx;
            Cy = cy;
            Size = size;
            Pressure = pressure;
        }
        /// <summary>
        /// Mode
        /// </summary>
        public GestureState Mode{ get; internal set; }
        /// <summary>
        /// Duration
        /// </summary>
        public int Duration{ get; internal set;}
        /// <summary>
        /// Cx
        /// </summary>
        public int Cx{ get; internal set;}
        /// <summary>
        /// Cy
        /// </summary>
        public int Cy{ get; internal set;}
        /// <summary>
        /// Size
        /// </summary>
        public double Size{ get; internal set;}
        /// <summary>
        /// Pressure
        /// </summary>
        public double Pressure{ get; internal set;}
    }
}
