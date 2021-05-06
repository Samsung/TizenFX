/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="WebRTC.IceCandidate"/> event.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class WebRTCIceCandicateEventArgs : EventArgs
    {
        internal WebRTCIceCandicateEventArgs(string iceCandidate)
        {
            ICECandicate = iceCandidate;
        }

        /// <summary>
        /// Gets the ICE candidate.
        /// </summary>
        /// <value>The ICE candidate.</value>
        /// <since_tizen> 9 </since_tizen>
        public string ICECandicate { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 9 </since_tizen>
        public override string ToString() => $"ICE candidate={ICECandicate}";
    }
}
