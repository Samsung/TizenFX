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
using System.Runtime.InteropServices;
using Tizen.Applications;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    public partial class WebRTCDataChannel : IDisposable
    {
        private readonly WebRTC _webRtc;
        private readonly IntPtr _handle;
        private bool _disposed;

        public WebRTCDataChannel(WebRTC webRtc, Bundle bundle, string label)
        {
            if (webRtc == null)
            {
                throw new ArgumentNullException(nameof(webRtc), "WebRTC is not created successfully.");
            }

            if (string.IsNullOrEmpty(label))
            {
                throw new ArgumentNullException(nameof(label), "label is null.");
            }

            if (bundle == null)
            {
                NativeDataChannel.CreateWithoutBundle(webRtc.Handle, label, IntPtr.Zero, out _handle).
                    ThrowIfFailed("Failed to create webrtc data channel");
            }
            else
            {
                NativeDataChannel.Create(webRtc.Handle, label, bundle.SafeBundleHandle, out _handle).
                    ThrowIfFailed("Failed to create webrtc data channel");
            }

            Debug.Assert(_handle != null);

            _webRtc = webRtc;
            Label = label;

            Log.Info(WebRTCLog.Tag, "Register event");
            RegisterEvents();
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

            Log.Info(WebRTCLog.Tag, "Register event");
            RegisterEvents();
        }

        private IntPtr Handle
        {
            get
            {
                ValidateNotDisposed();
                return _handle;
            }
        }

        public string Label { get; }

        public void Send(string data)
        {
            ValidateNotDisposed();

            NativeDataChannel.SendString(Handle, data).
                ThrowIfFailed("Failed to send string data");
        }

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

        public byte[] GetData()
        {
            ValidateNotDisposed();

            NativeDataChannel.GetData(Handle, out IntPtr data, out uint size).
                ThrowIfFailed("Failed to get data");

            byte[] destination = new byte[(int)size];
            Marshal.Copy(data, destination, 0, (int)size);

            return destination;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            if (true)
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

        internal bool IsDisposed => _disposed;
    }
}
