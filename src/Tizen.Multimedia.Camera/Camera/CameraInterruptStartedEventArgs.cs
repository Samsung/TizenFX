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
    /// Provides data for the <see cref="Camera.InterruptStarted"/> event.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CameraInterruptStartedEventArgs : EventArgs
    {
        internal CameraInterruptStartedEventArgs(CameraPolicy policy, CameraState state)
        {
            Policy = policy;
            State = state;
        }

        /// <summary>
        /// Gets the current state of the camera.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraState State { get; }

        /// <summary>
        /// Gets the policy that interrupted the camera.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public CameraPolicy Policy { get; }
    }
}
