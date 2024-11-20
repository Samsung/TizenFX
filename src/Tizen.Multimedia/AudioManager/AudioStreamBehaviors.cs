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
    /// Defines the flags that specify the behaviors of audio streams.
    /// This enumeration allows for a bitwise combination of its member values,
    /// enabling flexible configurations for audio playback and management.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    [Flags]
    public enum AudioStreamBehaviors
    {
        /// <summary>
        /// Indicates that the audio stream should not resume automatically
        /// after being paused or stopped. This flag can be used when
        /// explicit control over playback is desired, requiring the application
        /// to manually manage the resumption of audio playback.
        /// </summary>
        NoResume = 0x0001,

        /// <summary>
        /// Indicates that the audio stream should apply a fading effect
        /// during transitions. This behavior is useful for creating smoother
        /// audio experiences, such as gradually lowering the volume before
        /// stopping or increasing the volume when starting playback.
        /// </summary>
        Fading = 0x0002
    }

}
