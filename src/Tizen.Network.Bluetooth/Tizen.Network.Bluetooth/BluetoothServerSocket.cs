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
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// The BluetoothSocket provides functions for managing connections to other devices and exchanging data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothServerSocket : IDisposable
    {
        private static event EventHandler<AcceptStateChangedEventArgs> _acceptStateChanged;
        private static event EventHandler<SocketConnectionRequestedEventArgs> _connectionRequested;
        private static Interop.Bluetooth.SocketConnectionStateChangedCallback _connectionStateChangedCallback;
        private static Interop.Bluetooth.SocketConnectionRequestedCallback _connectionRequestedCallback;
        private TaskCompletionSource<SocketConnection> _taskForAccept;
        internal int socketFd;
        private bool disposed = false;

        internal BluetoothServerSocket()
        {
            StaticAcceptStateChanged += OnAcceptStateChanged;
            StaticConnectionRequested += OnConnectionRequested;
        }

        private void OnConnectionRequested(Object s, SocketConnectionRequestedEventArgs e)
        {
            if (e.SocketFd == socketFd)
            {
                ConnectionRequested?.Invoke(this, e);
            }
        }

        private void OnAcceptStateChanged(Object s, AcceptStateChangedEventArgs e)
        {
            if (e.Connection.ServerFd == socketFd)
            {
                if (_taskForAccept != null && !_taskForAccept.Task.IsCompleted)
                {
                    if (e.State == BluetoothSocketState.Connected)
                    {
                        _taskForAccept.SetResult(e.Connection);
                    }
                    else
                    {
                        _taskForAccept.SetException(BluetoothErrorFactory.CreateBluetoothException((int)e.Result));
                    }
                    _taskForAccept = null;
                }

                AcceptStateChanged?.Invoke(this, e);
            }
        }

        /// <summary>
        /// The AcceptStateChanged event is raised when the socket connection state is changed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the register accpet state changed callback fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AcceptStateChangedEventArgs> AcceptStateChanged;

        private static event EventHandler<AcceptStateChangedEventArgs> StaticAcceptStateChanged
        {
            add
            {
                if (_acceptStateChanged == null)
                {
                    RegisterAcceptStateChangedEvent();
                }
                _acceptStateChanged += value;
            }
            remove
            {
                _acceptStateChanged -= value;
                if (_acceptStateChanged == null)
                {
                    UnregisterAcceptStateChangedEvent();
                }
            }
        }

        private static void RegisterAcceptStateChangedEvent()
        {
            _connectionStateChangedCallback = (int result, BluetoothSocketState connectionState, ref SocketConnectionStruct socketConnection, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "AcceptStateChanged cb is called");
                BluetoothSocket socket = new BluetoothSocket();
                socket.connectedSocket = socketConnection.SocketFd;
                socket.remoteAddress = socketConnection.Address;
                socket.serviceUuid = socketConnection.ServiceUuid;
                _acceptStateChanged?.Invoke(null, new AcceptStateChangedEventArgs((BluetoothError)result, connectionState, BluetoothUtils.ConvertStructToSocketConnection(socketConnection), socket));
            };

            int ret = Interop.Bluetooth.SetConnectionStateChangedCallback(_connectionStateChangedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set accept state changed callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private static void UnregisterAcceptStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetSocketConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset accept state changed callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        internal BluetoothServerSocket(int socketFd)
        {
            Log.Info (Globals.LogTag, "Constructing server socket");

            StaticAcceptStateChanged += OnAcceptStateChanged;
            StaticConnectionRequested += OnConnectionRequested;

            this.socketFd = socketFd;
        }

        /// <summary>
        /// Starts listening on the passed RFCOMM socket and accepts connection requests.
        /// </summary>
        /// <remarks>
        /// The socket must be created with CreateServerSocket(). This API invokes the ConnectionStateChanged event.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the listen on socket procedure fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public void Listen()
        {
            int ret = Interop.Bluetooth.Listen(socketFd, 1);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to accept connection, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Starts listening on the passed RFCOMM socket without accepting connection requests.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ListenWithoutAccept()
        {
            int ret = Interop.Bluetooth.ListenWithoutAccept(socketFd, 1);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to ListenWithoutAccept, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Accepts a connection request asynchronously.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <returns> A task indicating whether the method is done or not.</returns>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Task<SocketConnection> AcceptAsync()
        {
            if (_taskForAccept != null && !_taskForAccept.Task.IsCompleted)
            {
                BluetoothErrorFactory.ThrowBluetoothException((int)BluetoothError.NowInProgress);
            }
            _taskForAccept = new TaskCompletionSource<SocketConnection>();

            int ret = Interop.Bluetooth.Accept(socketFd);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to accept connection, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return _taskForAccept.Task;
        }

        /// <summary>
        /// Rejects a connection request.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        /// <privilege>http://tizen.org/privilege/bluetooth.admin</privilege>
        /// <exception cref="NotSupportedException">Thrown when the Bluetooth is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the method is failed with message.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reject()
        {
            int ret = Interop.Bluetooth.Reject(socketFd);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to reject connection, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Registers a callback function that will be invoked when a RFCOMM connection is requested.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <feature>http://tizen.org/feature/network.bluetooth</feature>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<SocketConnectionRequestedEventArgs> ConnectionRequested;

        private static event EventHandler<SocketConnectionRequestedEventArgs> StaticConnectionRequested
        {
            add
            {
                if (_connectionRequested == null)
                {
                    RegisterConnectionRequestedEvent();
                }
                _connectionRequested += value;
            }
            remove
            {
                _connectionRequested -= value;
                if (_connectionRequested == null)
                {
                    UnregisterConnectionRequestedEvent();
                }
            }
        }

        private static void RegisterConnectionRequestedEvent()
        {
            _connectionRequestedCallback = (int socketFd, string remoteAddress, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "SocketConnectionRequestedCallback is called");
                _connectionRequested?.Invoke(null, new SocketConnectionRequestedEventArgs(socketFd, remoteAddress));
            };

            int ret = Interop.Bluetooth.SetSocketConnectionRequestedCallback(_connectionRequestedCallback, IntPtr.Zero);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection requested callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private static void UnregisterConnectionRequestedEvent()
        {
            int ret = Interop.Bluetooth.UnsetSocketConnectionRequestedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection requested callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// BluetoothServerSocket destructor.
        /// </summary>
        ~BluetoothServerSocket()
        {
            Dispose(false);
        }

        /// <summary>
        /// Dispose
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
                return;

            int ret = Interop.Bluetooth.DestroyServerSocket(socketFd);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to destroy socket, Error - " + (BluetoothError)ret);
            }
            StaticAcceptStateChanged -= OnAcceptStateChanged;
            StaticConnectionRequested -= OnConnectionRequested;
            disposed = true;
        }
    }
}
