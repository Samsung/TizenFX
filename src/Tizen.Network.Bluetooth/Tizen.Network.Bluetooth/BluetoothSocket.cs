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
    /// The IBluetoothServerSocket interface handles the server socket operations.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public interface IBluetoothServerSocket
    {
        /// <summary>
        /// Event handler to receive data over bluetooth socket.
        /// This event occurs when the socket server receives data from the client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        event EventHandler<SocketDataReceivedEventArgs> DataReceived;

        /// <summary>
        /// Event handler method to receive bluetooth socket connection state changed events.
        /// This event occurs when the connection state between two devices is changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        event EventHandler<SocketConnectionStateChangedEventArgs> ConnectionStateChanged;

        /// <summary>
        /// Method to send data over bluetooth socket
        /// </summary>
        /// <returns>The number of bytes written (zero indicates nothing was written).</returns>
        /// <remarks>
        /// The connection must be established.
        /// </remarks>
        /// <param name="data">The data to be sent.</param>
        /// <returns></returns>
        /// <since_tizen> 3 </since_tizen>
        int SendData(string data);
    }

    /// <summary>
    /// The IBluetoothClientSocket interface handles the client socket operations.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public interface IBluetoothClientSocket : IBluetoothServerSocket
    {
        /// <summary>
        /// Connect client socket to server socket on remote device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        void Connect();

        /// <summary>
        /// Disconnect client socket from server socket.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        void Disconnect();
    }

    internal class BluetoothSocket : IBluetoothClientSocket, IDisposable
    {
        private event EventHandler<SocketDataReceivedEventArgs> _dataReceived;
        private event EventHandler<SocketConnectionStateChangedEventArgs> _connectionStateChanged;
        private Interop.Bluetooth.DataReceivedCallback _dataReceivedCallback;
        private Interop.Bluetooth.SocketConnectionStateChangedCallback _connectionStateChangedCallback;
        private bool disposed = false;
        internal int connectedSocket;
        internal string remoteAddress;
        internal string serviceUuid;

        /// <summary>
        /// This event occurs when the socket server receives data from the client.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the register data received callback fails.</exception>
        public event EventHandler<SocketDataReceivedEventArgs> DataReceived
        {
            add
            {
                if (_dataReceived == null)
                {
                    RegisterDataReceivedEvent();
                }
                _dataReceived += value;
            }
            remove
            {
                _dataReceived -= value;
                if (_dataReceived == null)
                {
                    UnregisterDataReceivedEvent();
                }
            }
        }

        /// <summary>
        /// This event occurs when the connection state between two devices is changed.
        /// </summary>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the register connection changed callback fails.</exception>
        public event EventHandler<SocketConnectionStateChangedEventArgs> ConnectionStateChanged
        {
            add
            {
                if (_connectionStateChanged == null)
                {
                    RegisterConnectionStateChangedEvent();
                }
                _connectionStateChanged += value;
            }
            remove
            {
                _connectionStateChanged -= value;
                if (_connectionStateChanged == null)
                {
                    UnregisterConnectionStateChangedEvent();
                }
            }
        }

        private void RegisterDataReceivedEvent()
        {
            _dataReceivedCallback = (ref SocketDataStruct socketData, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "DataReceivedCallback is called");
                if (_dataReceived != null)
                {
                    GCHandle handle2 = (GCHandle) userData;
                    _dataReceived(handle2.Target as IBluetoothServerSocket, new SocketDataReceivedEventArgs(BluetoothUtils.ConvertStructToSocketData(socketData)));
                }
            };
            GCHandle handle1 = GCHandle.Alloc (this);
            IntPtr uData = (IntPtr) handle1;
            int ret = Interop.Bluetooth.SetDataReceivedCallback(_dataReceivedCallback, uData);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set data received callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void UnregisterDataReceivedEvent()
        {
            int ret = Interop.Bluetooth.UnsetDataReceivedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset data received callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void RegisterConnectionStateChangedEvent()
        {
            _connectionStateChangedCallback = (int result, BluetoothSocketState connectionState, ref SocketConnectionStruct socketConnection, IntPtr userData) =>
            {
                Log.Info(Globals.LogTag, "ConnectionStateChangedCallback is called");
                if (_connectionStateChanged != null)
                {
                    connectedSocket = socketConnection.SocketFd;
                    GCHandle handle2 = (GCHandle) userData;
                    _connectionStateChanged(handle2.Target as IBluetoothServerSocket, new SocketConnectionStateChangedEventArgs((BluetoothError)result, connectionState, BluetoothUtils.ConvertStructToSocketConnection(socketConnection)));
                }
            };
            GCHandle handle1 = GCHandle.Alloc(this);
            IntPtr data = (IntPtr) handle1;
            int ret = Interop.Bluetooth.SetConnectionStateChangedCallback(_connectionStateChangedCallback, data);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to set connection state changed callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        private void UnregisterConnectionStateChangedEvent()
        {
            int ret = Interop.Bluetooth.UnsetSocketConnectionStateChangedCallback();
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to unset connection state changed callback, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Connects to a specific RFCOMM based service on a remote Bluetooth device UUID.
        /// </summary>
        /// <remarks>
        /// The bluetooth must be enabled, discoverable with StartDiscovery(), and bonded with the remote device using CreateBond(). The ConnectionStateChanged event is raised once this API is called.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the connect socket attempt to remote device fails, or when the service UUID is not supported by the remote device.</exception>
        void IBluetoothClientSocket.Connect()
        {
            int ret = Interop.Bluetooth.ConnectSocket(remoteAddress, serviceUuid);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to connect to socket, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Disconnects the RFCOMM connection with the given file descriptor of the conneted socket.
        /// </summary>
        /// <remarks>
        /// The connection must be established.
        /// </remarks>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the socket disconnect to remote device fails.</exception>
        void IBluetoothClientSocket.Disconnect()
        {
            int ret = Interop.Bluetooth.DisconnectSocket(connectedSocket);
            if (ret != (int)BluetoothError.None)
            {
                Log.Error(Globals.LogTag, "Failed to disconnect socket, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
        }

        /// <summary>
        /// Sends data to the connected device.
        /// </summary>
        /// <returns>The number of bytes written (zero indicates nothing was written).</returns>
        /// <remarks>
        /// The connection must be established.
        /// </remarks>
        /// <param name="data">The data to be sent.</param>
        /// <exception cref="InvalidOperationException">Thrown when the Bluetooth is not enabled
        /// or when the remote device is not connected, or the send data procedure fails.</exception>
        public int SendData(string data)
        {
            int ret = Interop.Bluetooth.SendData(connectedSocket, data, data.Length);
            if (ret < 0)
            {
                Log.Error(Globals.LogTag, "Failed to send data, Error - " + (BluetoothError)ret);
                BluetoothErrorFactory.ThrowBluetoothException(ret);
            }
            return ret;
        }

        ~BluetoothSocket()
        {
            Dispose(false);
        }

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
            if (_dataReceived != null)
            {
                UnregisterDataReceivedEvent();
            }
            if (_connectionStateChanged != null)
            {
                UnregisterConnectionStateChangedEvent();
            }
        }
    }
}
