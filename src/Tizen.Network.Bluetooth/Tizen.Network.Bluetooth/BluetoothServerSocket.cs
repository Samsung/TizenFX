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

namespace Tizen.Network.Bluetooth
{
    /// <summary>
    /// The BluetoothSocket provides functions for managing connections to other devices and exchanging data.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class BluetoothServerSocket : IDisposable
    {
        private event EventHandler<AcceptStateChangedEventArgs> _acceptStateChanged;
        private event EventHandler<SocketConnectionRequestedEventArgs> _connectionRequested;
        private Interop.Bluetooth.SocketConnectionStateChangedCallback _connectionStateChangedCallback;
        internal int socketFd;
        private bool disposed = false;

        /// <summary>
        /// The AcceptStateChanged event is raised when the socket connection state is changed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the register accpet state changed callback fails.</exception>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<AcceptStateChangedEventArgs> AcceptStateChanged
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

        private void RegisterAcceptStateChangedEvent()
        {
            _connectionStateChangedCallback = (int result, BluetoothSocketState connectionState, ref SocketConnectionStruct socketConnection, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "AcceptStateChanged cb is called");
                if (_acceptStateChanged != null)
                {
                    BluetoothSocket socket = new BluetoothSocket();
                    socket.connectedSocket = socketConnection.SocketFd;
                    GCHandle handle2 = (GCHandle) userData;
                    _acceptStateChanged(handle2.Target as BluetoothServerSocket, new AcceptStateChangedEventArgs((BluetoothError)result, connectionState, BluetoothUtils.ConvertStructToSocketConnection(socketConnection), socket));
                }
            };
            GCHandle handle1 = GCHandle.Alloc(this);
            IntPtr data = (IntPtr) handle1;
            int ret = Interop.Bluetooth.SetConnectionStateChangedCallback(_connectionStateChangedCallback, data);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set accept state changed callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void UnregisterAcceptStateChangedEvent()
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
        /// Registers a callback function that will be invoked when the SCO(Synchronous Connection Oriented link) state is changed
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<SocketConnectionRequestedEventArgs> ConnectionRequested
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

        private void RegisterConnectionRequestedEvent()
        {
            Interop.Bluetooth.SocketConnectionRequestedCallback _connectionRequestedCallback = (int socket_fd, string remoteAddress, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "SocketConnectionRequestedCallback is called");
                BluetoothSocket socket = new BluetoothSocket();
                socket.connectedSocket = socket_fd;
                GCHandle handle2 = (GCHandle)userData;
                _connectionRequested?.Invoke(handle2.Target as IBluetoothServerSocket, new SocketConnectionRequestedEventArgs(remoteAddress, socket));
            };
            GCHandle handle1 = GCHandle.Alloc(this);
            IntPtr data = (IntPtr)handle1;
            int ret = Interop.Bluetooth.SetSocketConnectionRequestedCallback(_connectionRequestedCallback, data);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection requested callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void UnregisterConnectionRequestedEvent()
        {
            int ret = Interop.Bluetooth.UnsetSocketConnectionRequestedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection requested callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// BluetoothServerSocket distructor.
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

            if (disposing)
            {
                // Free managed objects.
            }
            //Free unmanaged objects
            RemoveRegisteredEvents();
            disposed = true;
        }

        private void RemoveRegisteredEvents()
        {
            //unregister all remaining events when this object is released.
            if (_acceptStateChanged != null)
            {
                UnregisterAcceptStateChangedEvent();
            }
        }
    }
}
