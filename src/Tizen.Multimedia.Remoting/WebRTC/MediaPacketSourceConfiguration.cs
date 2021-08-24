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
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides means to configure properties and handle events for <see cref="MediaPacketSource"/>.
    /// </summary>
    /// <seealso cref="MediaPacketSource"/>
    /// <since_tizen> 9 </since_tizen>
    public class MediaPacketSourceConfiguration
    {
        private readonly MediaPacketSource _owner;
        NativeWebRTC.MediaPacketBufferStatusCallback _mediaPacketBufferStatusChangedCallback;

        internal MediaPacketSourceConfiguration(MediaPacketSource owner)
        {
            _owner = owner;
        }

        /// <summary>
        /// Occurs when the buffer underruns or overflows.
        /// </summary>
        /// <remarks>The event handler will be executed on an internal thread.</remarks>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<MediaPacketBufferStatusChangedEventArgs> BufferStatusChanged;

        private IntPtr Handle => _owner.WebRtc.Handle;

        private uint SourceId => _owner.SourceId.Value;

        internal void OnWebRTCSet()
        {
            if (_mediaPacketBufferStatusChangedCallback == null)
            {
                RegisterBufferStatusChangedCallback();
            }
        }

        internal void OnWebRTCUnset()
        {
            if (_mediaPacketBufferStatusChangedCallback != null)
            {
                UnregisterBufferStatusChangedCallback();
            }
        }

        private void RegisterBufferStatusChangedCallback()
        {
            _mediaPacketBufferStatusChangedCallback = (sourceId_, state, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"sourceId:{sourceId_}, state:{state}");

                BufferStatusChanged?.Invoke(this, new MediaPacketBufferStatusChangedEventArgs(sourceId_, state));
            };

            NativeWebRTC.SetBufferStateChangedCb(Handle, SourceId, _mediaPacketBufferStatusChangedCallback, IntPtr.Zero).
                ThrowIfFailed("Failed to set buffer status changed callback.");
        }

        private void UnregisterBufferStatusChangedCallback()
        {
            NativeWebRTC.UnsetBufferStateChangedCb(Handle, SourceId).
                ThrowIfFailed("Failed to unset buffer status changed callback.");
        }
    }
}