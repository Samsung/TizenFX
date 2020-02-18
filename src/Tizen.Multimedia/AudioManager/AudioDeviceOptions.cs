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
    /// Specifies the flags for the audio device options.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    [Flags]
    internal enum AudioDeviceOptions
    {
        /// <summary>
        /// Input devices.
        /// </summary>
        Input = 0x0001,

        /// <summary>
        /// Output devices.
        /// </summary>
        Output = 0x0002,

        /// <summary>
        /// Input and output devices (both directions are available).
        /// </summary>
        InputAndOutput = 0x0004,

        /// <summary>
        /// Built-in devices.
        /// </summary>
        Internal = 0x00010,

        /// <summary>
        /// External devices.
        /// </summary>
        External = 0x0020,

        /// <summary>
        /// All devices.
        /// </summary>
        All = 0xFFFF
    }
}
