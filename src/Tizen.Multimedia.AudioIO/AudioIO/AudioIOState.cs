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
    /// Specifies the states for the <see cref="AudioPlayback"/>, <see cref="AudioCapture"/>, and <see cref="AsyncAudioCapture"/>.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioIOState
    {
        /// <summary>
        /// Not prepared.
        /// </summary>
        Idle = 0,

        /// <summary>
        /// The stream is running.
        /// </summary>
        Running = 1,

        /// <summary>
        /// The stream is paused.
        /// </summary>
        Paused = 2
    }
}
