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
    /// Provides data for the <see cref="Camera.StateChanged"/> event.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class CameraStateChangedEventArgs : EventArgs
    {
        internal CameraStateChangedEventArgs(CameraState previous, CameraState current, bool policy)
        {
            Previous = previous;
            Current = current;
            ByPolicy = policy;
        }

        /// <summary>
        /// Gets the previous state of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraState Previous { get; }

        /// <summary>
        /// Gets the current state of the camera.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public CameraState Current { get; }

        /// <summary>
        /// Gets the value indicating whether the state is changed by policy.
        /// </summary>
        /// <value>
        /// true if the state changed by policy, such as resource conflict or security, otherwise false.
        /// </value>
        /// <since_tizen> 3 </since_tizen>
        public bool ByPolicy { get; }
    }
}
