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
    /// Specifies the flag for a buffer.
    /// <para>
    /// This enumeration has a <see cref="FlagsAttribute"/> attribute that allows a bitwise combination of its member values.
    /// </para>
    /// </summary>
    [Flags]
    public enum MediaPacketBufferFlags
    {
        /// <summary>
        /// The buffer contains codec initialization or codec specific data instead of media data
        /// </summary>
        CodecConfig = 0x1,

        /// <summary>
        /// The buffer indicates the end of stream.
        /// </summary>
        EndOfStream = 0x2,

        /// <summary>
        /// The buffer contains a sync frame.
        /// </summary>
        SyncFrame = 0x4,
    }
}
