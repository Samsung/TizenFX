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
    /// Defines the flags for configuring audio stream focus options.
    /// This enumeration allows developers to specify different behaviors
    /// regarding how audio focus should be managed within an application
    /// or among multiple audio streams.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Flags]
    public enum AudioStreamFocusOptions
    {
        /// <summary>
        /// Playback focus.
        /// </summary>
        Playback = 0x0001,

        /// <summary>
        /// Recording focus.
        /// </summary>
        Recording = 0x0002
    }

}
