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
using System.Runtime.InteropServices;

namespace Tizen.Multimedia
{
    /// <summary>
    /// An extended EventArgs class containing details of muxed stream(Audio + Video).
    /// </summary>
    public class MuxedStreamDeliveredEventArgs : EventArgs
    {
        internal MuxedStreamDeliveredEventArgs(IntPtr stream, int streamLength, ulong offset)
        {
            Stream = new byte[streamLength];
            Marshal.Copy(stream, Stream, 0, streamLength);
            StreamLength = streamLength;
            Offset = offset;
        }

        /// <summary>
        /// The muexed stream data.
        /// </summary>
        public byte[] Stream { get; }

        /// <summary>
        /// The length of muxed stream data.
        /// </summary>
        public int StreamLength { get; }

        /// <summary>
        /// The offset of the stream data.
        /// </summary>
        public ulong Offset { get; }
    }
}
