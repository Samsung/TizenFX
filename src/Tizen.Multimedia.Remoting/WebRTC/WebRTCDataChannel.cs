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
using System.ComponentModel;
using System.Diagnostics;
using Tizen.Applications;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides the ability to control WebRTC data channel.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebRTCDataChannel : IDisposable
    {
        private readonly IntPtr _handle;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRTCDataChannel"/> class.
        /// </summary>
        /// <param name="webRtc">The owner of this WebRTCDataChannel.</param>
        /// <param name="label">The name of this data channel.</param>
        /// <exception cref="ArgumentNullException">The webRtc or label is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCDataChannel(WebRTC webRtc, string label)
            : this(webRtc, label, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRTCDataChannel"/> class.
        /// </summary>
        /// <remarks>
        /// The bundle is similar format as the RTCDataChannelInit members outlined https://www.w3.org/TR/webrtc/#dom-rtcdatachannelinit.<br/>
        /// The following attributes can be set to options by using <see cref="Bundle"/> API:<br/>
        /// 'ordered' of type bool            : Whether the channel will send data with guaranteed ordering. The default value is true.<br/>
        /// 'max-packet-lifetime' of type int : The time in milliseconds to attempt transmitting unacknowledged data. -1 for unset. The default value is -1.<br/>
        /// 'max-retransmits' of type int     : The number of times data will be attempted to be transmitted without acknowledgement before dropping. The default value is -1.<br/>
        /// 'protocol' of type string         : The subprotocol used by this channel. The default value is NULL.<br/>
        /// 'id' of type int                  : Override the default identifier selection of this channel. The default value is -1.<br/>
        /// 'priority' of type int            : The priority to use for this channel(1:very low, 2:low, 3:medium, 4:high). The default value is 2.<br/>
        /// </remarks>
        /// <param name="webRtc">The owner of this WebRTCDataChannel.</param>
        /// <param name="label">The name of this data channel.</param>
        /// <param name="bundle">The data channel option.</param>
        /// <exception cref="ArgumentNullException">The webRtc or label is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public WebRTCDataChannel(WebRTC webRtc, string label, Bundle bundle)
        {
            if (webRtc == null)
            {
                throw new ArgumentNullException(nameof(webRtc), "WebRTC is not created successfully.");
            }

            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException(nameof(label), "label is null.");
            }

            var bundle_ = bundle?.SafeBundleHandle ?? new SafeBundleHandle();
            NativeDataChannel.Create(webRtc.Handle, label, bundle_, out _handle).
                ThrowIfFailed("Failed to create webrtc data channel");

            Debug.Assert(_handle != null);

            Label = label;
        }

        internal WebRTCDataChannel(IntPtr dataChannelHandle)
        {
            if (dataChannelHandle == IntPtr.Zero)
            {
                throw new ArgumentNullException(nameof(dataChannelHandle),
                    "WebRTC is not created successfully in native");
            }

            _handle = dataChannelHandle;

            NativeDataChannel.GetLabel(_handle, out string label).
                ThrowIfFailed("Failed to get label");

            Label = label;
        }

        private IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle;
            }
        }

        /// <summary>
        /// Gets the label of this data channel.
        /// </summary>
        /// <value>The label.</value>
        /// <since_tizen> 9 </since_tizen>
        public string Label { get; }

        /// <summary>
        /// Gets the amount of buffered data.
        /// </summary>
        /// <value>The buffered amount in bytes.</value>
        /// <since_tizen> 10 </since_tizen>
        public uint BufferedAmount
        {
            get
            {
                ValidateNotDisposed();

                NativeDataChannel.GetBufferedAmount(Handle, out uint amount).
                    ThrowIfFailed("Failed to get buffered amount");

                return amount;
            }
        }

        private uint? _bufferThreshold;
        /// <summary>
        /// Gets or sets the threshold of data channel buffered amount.<br/>
        /// If the amount of buffered data is lower than threshold value, <see cref="BufferUnderflow"/> will be occurred.<br/>
        /// The default value is 0. and if threshold is 0, <see cref="BufferUnderflow"/> is not occurred.
        /// </summary>
        /// <since_tizen> 10 </since_tizen>
        public uint BufferedAmountLowThreshold
        {
            get
            {
                ValidateNotDisposed();

                if (!_bufferThreshold.HasValue)
                {
                    NativeDataChannel.GetBufferedAmountLowThreshold(Handle, out uint threshold).
                        ThrowIfFailed("Failed to get buffer threshold value");

                    _bufferThreshold = threshold;
                }

                return _bufferThreshold.Value;
            }
            set
            {
                ValidateNotDisposed();

                _bufferThreshold = value;

                RegisterDataChannelBufferedAmountLowThresholdCallback();
            }
        }

        /// <summary>
        /// Sends a string data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The string data to send</param>
        /// <exception cref="ObjectDisposedException">The WebRTCDataChannel has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Send(string data)
        {
            ValidateNotDisposed();

            NativeDataChannel.SendString(Handle, data).
                ThrowIfFailed("Failed to send string data");
        }

        /// <summary>
        /// Sends byte data across the data channel to the remote peer.
        /// </summary>
        /// <param name="data">The byte data to send</param>
        /// <exception cref="ObjectDisposedException">The WebRTCDataChannel has already been disposed.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Send(byte[] data)
        {
            ValidateNotDisposed();

            if (data == null)
            {
                throw new ArgumentNullException(nameof(data), "data is null");
            }

            NativeDataChannel.SendBytes(Handle, data, (uint)data.Length).
                ThrowIfFailed("Failed to send bytes data");
        }

        #region Dispose support
        private bool _disposed;

        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="WebRTCDataChannel"/>.
        /// </summary>
        /// <param name="disposing">
        /// true to release both managed and unmanaged resources;
        /// false to release only unmanaged resources.
        /// </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            if (_handle != null)
            {
                NativeDataChannel.Destroy(_handle);
                _disposed = true;
            }
        }

        private void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Warn(WebRTCLog.Tag, "WebRTCDataChannel was disposed");
                throw new ObjectDisposedException(nameof(WebRTCDataChannel));
            }
        }
        #endregion Dispose support
    }
}
