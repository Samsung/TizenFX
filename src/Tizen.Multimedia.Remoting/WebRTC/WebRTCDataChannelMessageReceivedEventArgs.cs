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
using System.Runtime.InteropServices;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides data for the <see cref="WebRTCDataChannel.MessageReceived"/> event.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class WebRTCDataChannelMessageReceivedEventArgs : EventArgs
    {
        internal WebRTCDataChannelMessageReceivedEventArgs(DataChannelType type, IntPtr message)
        {
            Type = type;

            if (type == DataChannelType.Strings)
            {
                Message = Marshal.PtrToStringAnsi(message);
            }
            else
            {
                NativeDataChannel.GetData(message, out IntPtr data, out uint size).
                    ThrowIfFailed("Failed to get data");

                Data = new byte[(int)size];
                Marshal.Copy(data, Data, 0, (int)size);
            }
        }

        /// <summary>
        /// Gets the data channel type.
        /// </summary>
        /// <value>The data channel type.</value>
        /// <since_tizen> 9 </since_tizen>
        public DataChannelType Type { get; }

        /// <summary>
        /// Gets the string message from remote peer.
        /// </summary>
        /// <remarks>
        /// If <see cref="WebRTCDataChannelMessageReceivedEventArgs.Type"/> is <see cref="DataChannelType.Bytes"/>, this property is null.
        /// </remarks>
        /// <value>The message.</value>
        /// <since_tizen> 9 </since_tizen>
        public string Message { get; }

        /// <summary>
        /// Gets the byte data from remote peer.
        /// </summary>
        /// <remarks>
        /// If <see cref="WebRTCDataChannelMessageReceivedEventArgs.Type"/> is <see cref="DataChannelType.Strings"/>, this property is null.
        /// </remarks>
        /// <value>The message.</value>
        /// <since_tizen> 9 </since_tizen>
        public byte[] Data { get; }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>A string that represents the current object.</returns>
        /// <since_tizen> 9 </since_tizen>
        public override string ToString() => $"Channel type={Type}, Message={Message}";
    }
}
