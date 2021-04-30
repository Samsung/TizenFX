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
    public partial class WebRTCDataChannel
    {
        private NativeDataChannel.OpenedCallback _webRtcDataChannelOpenedCallback;
        private NativeDataChannel.ClosedCallback _webRtcDataChannelClosedCallback;
        private NativeDataChannel.MessageReceivedCallback _webRtcDataChannelMsgRecvCallback;
        private NativeDataChannel.ErrorCallback _webRtcDataChannelErrorCallback;

        public event EventHandler<EventArgs> Opened;

        public event EventHandler<EventArgs> Closed;

        public event EventHandler<WebRTCDataChannelMessageReceivedEventArgs> MessageReceived;

        public event EventHandler<WebRTCDataChannelErrorOccurredEventArgs> ErrorOccurred;

        private void RegisterEvents()
        {
            RegisterDataChannelOpenedCallback();
            RegisterDataChannelClosedCallback();
            RegisterDataChannelMsgRecvCallback();
            RegisterDataChannelErrorOccurredCallback();
        }

        private void RegisterDataChannelOpenedCallback()
        {
            _webRtcDataChannelOpenedCallback = (dataChannelHandle, _) =>
            {
                Opened?.Invoke(this, new EventArgs());
            };

            NativeDataChannel.SetOpenedCb(_handle, _webRtcDataChannelOpenedCallback).
                ThrowIfFailed("Failed to set data channel opened callback.");
        }

        private void RegisterDataChannelMsgRecvCallback()
        {
            _webRtcDataChannelMsgRecvCallback = (dataChannelHandle, type, message, _) =>
            {
                MessageReceived?.Invoke(this, new WebRTCDataChannelMessageReceivedEventArgs(type, message));
            };

            NativeDataChannel.SetMessageReceivedCb(_handle, _webRtcDataChannelMsgRecvCallback).
                ThrowIfFailed("Failed to set data channel message received callback.");
        }

        private void RegisterDataChannelErrorOccurredCallback()
        {
            _webRtcDataChannelErrorCallback = (dataChannelHandle, error, _) =>
            {
                ErrorOccurred?.Invoke(this, new WebRTCDataChannelErrorOccurredEventArgs((WebRTCError)error));
            };

            NativeDataChannel.SetErrorCb(_handle, _webRtcDataChannelErrorCallback).
                ThrowIfFailed("Failed to set data channel error callback.");
        }

        private void RegisterDataChannelClosedCallback()
        {
            _webRtcDataChannelClosedCallback = (dataChannelHandle, _) =>
            {
                Closed?.Invoke(this, new EventArgs());
            };

            NativeDataChannel.SetClosedCb(_handle, _webRtcDataChannelClosedCallback).
                ThrowIfFailed("Failed to set data channel closed callback.");
        }
    }
}