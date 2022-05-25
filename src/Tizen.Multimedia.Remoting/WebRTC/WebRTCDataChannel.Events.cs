using System.ComponentModel;
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
    /// Provides the ability to control WebRTC data channel.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebRTCDataChannel
    {
        private NativeDataChannel.OpenedCallback _webRtcDataChannelOpenedCallback;
        private NativeDataChannel.ClosedCallback _webRtcDataChannelClosedCallback;
        private NativeDataChannel.MessageReceivedCallback _webRtcDataChannelMsgRecvCallback;
        private NativeDataChannel.ErrorOccurredCallback _webRtcDataChannelErrorOccurredCallback;
        private NativeDataChannel.BufferedAmountLowThresholdCallback _webRtcDataChannelBufferedAmountLowThresholdCallback;

        private event EventHandler<EventArgs> _opened;
        private event EventHandler<EventArgs> _closed;
        private event EventHandler<WebRTCDataChannelMessageReceivedEventArgs> _messageReceived;
        private event EventHandler<WebRTCDataChannelErrorOccurredEventArgs> _errorOccurred;
        private event EventHandler<EventArgs> _bufferedAmountLowThresholdOccurred;

        /// <summary>
        /// Occurs when the data channel's underlying data transport is established.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<EventArgs> Opened
        {
            add
            {
                if (_opened == null)
                {
                    RegisterDataChannelOpenedCallback();
                }
                _opened += value;
            }
            remove
            {
                _opened -= value;
                if (_opened == null)
                {
                    UnregisterDataChannelOpenedCallback();
                }
            }
        }

        /// <summary>
        /// Occurs when the data channel has closed down.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<EventArgs> Closed
        {
            add
            {
                if (_closed == null)
                {
                    RegisterDataChannelClosedCallback();
                }
                _closed += value;
            }
            remove
            {
                _closed -= value;
                if (_closed == null)
                {
                    UnregisterDataChannelClosedCallback();
                }
            }
        }

        /// <summary>
        /// Occurs when a message is received from the remote peer.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCDataChannelMessageReceivedEventArgs> MessageReceived
        {
            add
            {
                if (_messageReceived == null)
                {
                    RegisterDataChannelMessageReceivedCallback();
                }
                _messageReceived += value;
            }
            remove
            {
                _messageReceived -= value;
                if (_messageReceived == null)
                {
                    UnregisterDataChannelMessageReceivedCallback();
                }
            }
        }

        /// <summary>
        /// Occurs when an error occurs on the data channel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebRTCDataChannelErrorOccurredEventArgs> ErrorOccurred
        {
            add
            {
                if (_errorOccurred == null)
                {
                    RegisterDataChannelErrorOccurredCallback();
                }
                _errorOccurred += value;
            }
            remove
            {
                _errorOccurred -= value;
                if (_errorOccurred == null)
                {
                    UnregisterDataChannelErrorOccurredCallback();
                }
            }
        }

        /// <summary>
        /// Occurs when the buffered data amount is lower than <see cref="BufferedAmountLowThreshold"/>.<br/>
        /// If <see cref="BufferedAmountLowThreshold"/> is not set, this event will not be raised.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public event EventHandler<EventArgs> BufferedAmountLow
        {
            add
            {
                if (_bufferedAmountLowThresholdOccurred == null)
                {
                    RegisterDataChannelBufferedAmountLowThresholdCallback();
                }
                _bufferedAmountLowThresholdOccurred += value;
            }
            remove
            {
                _bufferedAmountLowThresholdOccurred -= value;
                if (_bufferedAmountLowThresholdOccurred == null)
                {
                    UnregisterDataChannelBufferedAmountLowThresholdCallback();
                }
            }
        }

        private void RegisterDataChannelOpenedCallback()
        {
            _webRtcDataChannelOpenedCallback = (dataChannelHandle, _) =>
            {
                _opened?.Invoke(this, new EventArgs());
            };

            NativeDataChannel.SetOpenedCb(_handle, _webRtcDataChannelOpenedCallback).
                ThrowIfFailed("Failed to set data channel opened callback.");
        }

        private void UnregisterDataChannelOpenedCallback()
        {
            NativeDataChannel.UnsetOpenedCb(_handle).
                ThrowIfFailed("Failed to unset data channel opened callback.");
        }

        private void RegisterDataChannelClosedCallback()
        {
            _webRtcDataChannelClosedCallback = (dataChannelHandle, _) =>
            {
                _closed?.Invoke(this, new EventArgs());
            };

            NativeDataChannel.SetClosedCb(_handle, _webRtcDataChannelClosedCallback).
                ThrowIfFailed("Failed to set data channel closed callback.");
        }

        private void UnregisterDataChannelClosedCallback()
        {
            NativeDataChannel.UnsetClosedCb(_handle).
                ThrowIfFailed("Failed to unset data channel closed callback.");
        }

        private void RegisterDataChannelMessageReceivedCallback()
        {
            _webRtcDataChannelMsgRecvCallback = (dataChannelHandle, type, message, _) =>
            {
                _messageReceived?.Invoke(this, new WebRTCDataChannelMessageReceivedEventArgs(type, message));
            };

            NativeDataChannel.SetMessageReceivedCb(_handle, _webRtcDataChannelMsgRecvCallback).
                ThrowIfFailed("Failed to set data channel message received callback.");
        }

        private void UnregisterDataChannelMessageReceivedCallback()
        {
            NativeDataChannel.UnsetMessageReceivedCb(_handle).
                ThrowIfFailed("Failed to unset data channel message received callback.");
        }

        private void RegisterDataChannelErrorOccurredCallback()
        {
            _webRtcDataChannelErrorOccurredCallback = (dataChannelHandle, error, _) =>
            {
                _errorOccurred?.Invoke(this, new WebRTCDataChannelErrorOccurredEventArgs((WebRTCError)error));
            };

            NativeDataChannel.SetErrorOccurredCb(_handle, _webRtcDataChannelErrorOccurredCallback).
                ThrowIfFailed("Failed to set data channel error callback.");
        }

        private void UnregisterDataChannelErrorOccurredCallback()
        {
            NativeDataChannel.UnsetErrorOccurredCb(_handle).
                ThrowIfFailed("Failed to unset data channel error callback.");
        }

        private void RegisterDataChannelBufferedAmountLowThresholdCallback()
        {
            if (_webRtcDataChannelBufferedAmountLowThresholdCallback == null)
            {
                _webRtcDataChannelBufferedAmountLowThresholdCallback = (dataChannelHanel, _) =>
                {
                    _bufferedAmountLowThresholdOccurred?.Invoke(this, new EventArgs());
                };
            }

            NativeDataChannel.SetBufferedAmountLowThresholdCb(_handle, _bufferThreshold.Value,
                _webRtcDataChannelBufferedAmountLowThresholdCallback).
                ThrowIfFailed("Failed to set buffered amount low threshold callback.");
        }

        private void UnregisterDataChannelBufferedAmountLowThresholdCallback()
        {
            NativeDataChannel.UnsetBufferedAmountLowThresholdCb(_handle).
                ThrowIfFailed("Failed to unset buffered amount low threshold callback.");
        }
    }
}