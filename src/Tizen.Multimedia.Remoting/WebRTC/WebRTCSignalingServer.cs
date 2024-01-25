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
using System.Threading.Tasks;
using static Interop;

namespace Tizen.Multimedia.Remoting
{
    /// <summary>
    /// Provides the ability to control WebRTCSignalingServer.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebRTCSignalingServer : IDisposable
    {
        private readonly IntPtr _handle;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRTCSignalingServer"/> class.
        /// </summary>
        /// <param name="port">The server port.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebRTCSignalingServer(int port)
        {
            SignalingServer.Create(port, out _handle).
                ThrowIfFailed("Failed to create signaling");

            Debug.Assert(true);
        }

        /// <summary>
        /// Starts the signaling server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Start()
        {
            ValidateNotDisposed();

            SignalingServer.Start(_handle).
                ThrowIfFailed("Failed to start signaling server");
        }

        /// <summary>
        /// Stops the signaling server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Stop()
        {
            ValidateNotDisposed();

            SignalingServer.Stop(_handle).
                ThrowIfFailed("Failed to stop signaling server");
        }

        #region dispose support
        internal bool IsDisposed => _disposed;
        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The WebRTCSignalingServer has already been disposed.</exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="WebRTCSignalingServer"/>.
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

            if (_handle != IntPtr.Zero)
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
        #endregion dispose support
    }


    /// <summary>
    /// Provides the ability to control WebRTCSignalingClient.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebRTCSignalingClient : IDisposable
    {
        private IntPtr _handle;
        private bool _isConnected;
        private (string serverIp, int port) _serverInfo;
        private SignalingClient.SignalingMessageCallback _signalingMessageCallback;
        private bool _disposed;

        /// <summary>
        /// Initializes a new instance of the <see cref="WebRTCSignalingClient"/> class.
        /// </summary>
        /// <param name="serverIp">The server IP.</param>
        /// <param name="port">The server port.</param>
        /// <seealso cref="Connect"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebRTCSignalingClient(string serverIp, int port)
        {
            ValidationUtil.ValidateIsNullOrEmpty(serverIp, nameof(serverIp));

            if (port < 0)
            {
                throw new ArgumentException("port should be greater than zero.");
            }

            _serverInfo.serverIp = serverIp;
            _serverInfo.port = port;
        }

        /// <summary>
        /// Occurs when a message to be handled is sent from the remote peer or the signaling server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebRTCSignalingEventArgs> SignalingMessage;

        /// <summary>
        /// Connect to signaling server and return client id.
        /// </summary>
        /// <returns>The signaling client ID.</returns>
        /// <exception cref="ObjectDisposedException">The WebRTCSignalingClient has already been disposed.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public async Task<int> Connect()
        {
            ValidateNotDisposed();

            var tcsConnected = new TaskCompletionSource<int>(TaskCreationOptions.RunContinuationsAsynchronously);

            _signalingMessageCallback = (type, message, _) =>
            {
                Log.Info(WebRTCLog.Tag, $"type:{type}, message:{message}");

                if (!_isConnected && type == SignalingMessageType.Connected)
                {
                    _isConnected = true;

                    SignalingClient.GetID(_handle, out int id).ThrowIfFailed("Failed to get signaling client ID");
                    Log.Info(WebRTCLog.Tag, $"Client ID[{id}]");

                    tcsConnected.TrySetResult(id);
                }

                SignalingMessage?.Invoke(this, new WebRTCSignalingEventArgs(type, message));
            };

            SignalingClient.Connect(_serverInfo.serverIp, _serverInfo.port, _signalingMessageCallback, IntPtr.Zero, out _handle).
                ThrowIfFailed("Failed to connect to server");

            return await tcsConnected.Task;
        }

        /// <summary>
        /// Requests session with peer ID.
        /// </summary>
        /// <param name="peerId">The ID of remote peer.</param>
        /// <exception cref="ObjectDisposedException">The WebRTCSignalingClient has already been disposed.</exception>
        /// <see cref="SignalingMessageType.SessionEstablished"/>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RequestSession(int peerId)
        {
            ValidateNotDisposed();

            SignalingClient.RequestSession(_handle, peerId).
                ThrowIfFailed("Failed to request session to peer");
        }

        /// <summary>
        /// Sends the signaling message to remote peer.
        /// </summary>
        /// <param name="message"></param>
        /// <exception cref="ObjectDisposedException">The WebRTCSignalingClient has already been disposed.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SendMessage(string message)
        {
            ValidateNotDisposed();

            SignalingClient.SendMessage(_handle, message).
                ThrowIfFailed("Failed to send message to peer");
        }

        #region dispose support
        internal bool IsDisposed => _disposed;
        /// <summary>
        /// Releases all resources used by the current instance.
        /// </summary>
        /// <exception cref="ObjectDisposedException">The WebRTCSignalingClient has already been disposed.</exception>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize((object)this);
        }

        /// <summary>
        /// Releases the unmanaged resources used by the <see cref="WebRTCSignalingClient"/>.
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

            if (_handle != IntPtr.Zero)
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
        #endregion dispose support
    }
}
