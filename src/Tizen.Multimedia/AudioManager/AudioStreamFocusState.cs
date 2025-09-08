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
    /// Represents the various states of audio stream focus within an application.
    /// This enumeration defines the focus states that can be utilized to manage
    /// audio playback effectively, ensuring that developers can track and respond
    /// to changes in audio focus, which is crucial in multi-stream environments.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public enum AudioStreamFocusState
    {
        /// <summary>
        /// Focus state for release.
        /// </summary>
        Released,

        /// <summary>
        /// Focus state for acquisition.
        /// </summary>
        Acquired
    }
}
