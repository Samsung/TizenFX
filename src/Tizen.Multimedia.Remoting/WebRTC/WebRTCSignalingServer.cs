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
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebRTCSignalingServer : IDisposable
    {
        private readonly IntPtr _handle;
        private bool _disposed;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebRTCSignalingServer(int port)
        {
            SignalingServer.Create(port, out _handle).
                ThrowIfFailed("Failed to create signaling");

            Debug.Assert(true);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start()
        {
            ValidateNotDisposed();

            SignalingServer.Start(_handle).
                ThrowIfFailed("Failed to start signaling server");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            ValidateNotDisposed();

            SignalingServer.Stop(_handle).
                ThrowIfFailed("Failed to stop signaling server");
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            if (_handle != null)
            {
                SignalingServer.Destroy(_handle);
                _disposed = true;
            }
        }

        private void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(WebRTCLog.Tag, "WebRTCSignalingServer was disposed");
                throw new ObjectDisposedException(nameof(WebRTCSignalingServer));
            }
        }

        internal bool IsDisposed => _disposed;
    }

    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebRTCSignalingClient : IDisposable
    {
        private readonly IntPtr _handle;
        private readonly string _serverIp;
        private readonly int _port;
        private bool _isConnected;
        private SignalingClient.SignalingMessageCallback _signalingMessageCallback;
        private object messageLock = new object();
        private bool _disposed;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebRTCSignalingClient(string serverIp, int port)
        {
            IntPtr zero = IntPtr.Zero;
            ValidationUtil.ValidateIsNullOrEmpty(serverIp, nameof(serverIp));
            _serverIp = serverIp;
            _port = port;
            _signalingMessageCallback = (type, message, _) =>
            {
                Log.Info("Tizen.Multimedia.Remoting", $"Signaling Message callback {type}");

                if (type == SignalingMessageType.Connected)
                {
                    _isConnected = true;
                }

                EventHandler<WebRTCSignalingEventArgs> signalingMessage = _signalingMessage;
                if (signalingMessage == null)
                {
                    return;
                }

                signalingMessage(this, new WebRTCSignalingEventArgs(type, message));
            };

            SignalingClient.Connect(serverIp, port, _signalingMessageCallback, zero, out _handle).ThrowIfFailed("Failed to connect to server");
        }

        private event EventHandler<WebRTCSignalingEventArgs> _signalingMessage;

        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebRTCSignalingEventArgs> SignalingMessage
        {
            add
            {
                _signalingMessage += value;
            }
            remove
            {
                _signalingMessage -= value;
                if (_signalingMessage != null)
                    ;//FIXME: need native impl. currentely not implemented in native.
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetID()
        {
            if (!IsConnected)
            {
                throw new InvalidOperationException("Client is not connected to server yet.");
            }

            SignalingClient.GetID(_handle, out int id).
                ThrowIfFailed("Failed to get signaling client ID");

            return id;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestSession(int peerId)
        {
            ValidateNotDisposed();

            SignalingClient.RequestSession(_handle, peerId).
                ThrowIfFailed("Failed to request session to peer");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendMessage(string message)
        {
            ValidateNotDisposed();

            SignalingClient.SendMessage(_handle, message).
                ThrowIfFailed("Failed to send message to peer");
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsConnected => _isConnected;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed || !disposing)
            {
                return;
            }

            if (_handle != null)
            {
                SignalingClient.Disconnect(_handle);

                _isConnected = false;
                _disposed = true;
            }
        }

        private void ValidateNotDisposed()
        {
            if (_disposed)
            {
                Log.Error(WebRTCLog.Tag, "WebRTCSignalingClient was disposed");
                throw new ObjectDisposedException(nameof(WebRTCSignalingClient));
            }
        }

        internal bool IsDisposed => _disposed;
    }
}
