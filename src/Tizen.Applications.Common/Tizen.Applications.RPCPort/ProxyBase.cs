/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// Abstract class for creating a proxy class for RPC.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class ProxyBase : IDisposable
    {
        private Interop.LibRPCPort.Proxy.ConnectedEventCallback _connectedEventCallback;
        private Interop.LibRPCPort.Proxy.DisconnectedEventCallback _disconnectedEventCallback;
        private Interop.LibRPCPort.Proxy.RejectedEventCallback _rejectedEventCallback;
        private Interop.LibRPCPort.Proxy.ReceivedEventCallback _receivedEventCallback;
        private IntPtr _proxy;

        /// <summary>
        /// Gets Port object.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected Port Port { get; private set; }

        /// <summary>
        /// Gets Port object for asynchronous events.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected Port CallbackPort { get; private set; }

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when internal IO error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public ProxyBase()
        {
            if (Interop.LibRPCPort.Proxy.Create(out _proxy) != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
            _connectedEventCallback = new Interop.LibRPCPort.Proxy.ConnectedEventCallback(OnConnectedEvent);
            _disconnectedEventCallback = new Interop.LibRPCPort.Proxy.DisconnectedEventCallback(OnDisconnectedEvent);
            _rejectedEventCallback = new Interop.LibRPCPort.Proxy.RejectedEventCallback(OnRejectedEvent);
            _receivedEventCallback = new Interop.LibRPCPort.Proxy.ReceivedEventCallback(OnReceivedEvent);
            Interop.LibRPCPort.Proxy.AddConnectedEventCb(_proxy, _connectedEventCallback, IntPtr.Zero);
            Interop.LibRPCPort.Proxy.AddDisconnectedEventCb(_proxy, _disconnectedEventCallback, IntPtr.Zero);
            Interop.LibRPCPort.Proxy.AddRejectedEventCb(_proxy, _rejectedEventCallback, IntPtr.Zero);
            Interop.LibRPCPort.Proxy.AddReceivedEventCb(_proxy, _receivedEventCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Connects to port.
        /// </summary>
        /// <param name="appid">The target stub app ID.</param>
        /// <param name="port">The name of the RPC port.</param>
        /// <exception cref="InvalidIDException">Thrown when not available app ID is used.</exception>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 5 </since_tizen>
        protected void Connect(string appid, string port)
        {
            var err = Interop.LibRPCPort.Proxy.Connect(_proxy, appid, port);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.PermissionDenied:
                    throw new PermissionDeniedException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Connects to port synchronously.
        /// </summary>
        /// <param name="appid">The target stub app ID.</param>
        /// <param name="port">The name of the RPC port.</param>
        /// <exception cref="InvalidIDException">Thrown when not available app ID is used.</exception>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when the permission is denied.</exception>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <since_tizen> 8 </since_tizen>
        protected void ConnectSync(string appid, string port)
        {
            var err = Interop.LibRPCPort.Proxy.ConnectSync(_proxy, appid, port);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.PermissionDenied:
                    throw new PermissionDeniedException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Gets a port.
        /// </summary>
        /// <param name="t">The type of port.</param>
        /// <returns>Port object.</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        protected Port GetPort(Port.Type t)
        {
            var err = Interop.LibRPCPort.Proxy.GetPort(_proxy,
                (Interop.LibRPCPort.PortType)t, out IntPtr port);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }

            return new Port() { Handle = port };
        }

        /// <summary>
        /// Abstract method for receiving connected event.
        /// </summary>
        /// <param name="endPoint">The target stub app ID.</param>
        /// <param name="portName">The name of the RPC port.</param>
        /// <param name="port">Port object for reading and writing.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnConnectedEvent(string endPoint, string portName, Port port);

        /// <summary>
        /// Abstract method for receiving disconnected event.
        /// </summary>
        /// <param name="endPoint">The target stub app ID.</param>
        /// <param name="portName">The name of the port.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnDisconnectedEvent(string endPoint, string portName);

        /// <summary>
        /// Abstract method called when the proxy receives data from stub.
        /// </summary>
        /// <param name="endPoint">The target stub app ID.</param>
        /// <param name="portName">The name of the RPC port.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnReceivedEvent(string endPoint, string portName);

        /// <summary>
        /// Abstract method for receiving rejected event.
        /// </summary>
        /// <param name="endPoint">The target stub app ID.</param>
        /// <param name="portName">The name of the RPC port.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnRejectedEvent(string endPoint, string portName);

        private void OnConnectedEvent(string endPoint, string portName, IntPtr port, IntPtr data)
        {
            Port = new Port() { Handle = port };
            CallbackPort = GetPort(Port.Type.Callback);
            OnConnectedEvent(endPoint, portName, Port);
        }

        private void OnDisconnectedEvent(string endPoint, string portName, IntPtr data)
        {
            Port = null;
            CallbackPort = null;
            OnDisconnectedEvent(endPoint, portName);
        }

        private void OnReceivedEvent(string endPoint, string portName, IntPtr data)
        {
            OnReceivedEvent(endPoint, portName);
        }

        private void OnRejectedEvent(string endPoint, string portName, IntPtr data)
        {
            OnRejectedEvent(endPoint, portName);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object and disposes any other disposable objects.
        /// </summary>
        /// <param name="disposing">true to disposes any disposable objects, or false not to dispose disposable objects.</param>
        /// <since_tizen> 6 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }
                if (_proxy != IntPtr.Zero)
                    Interop.LibRPCPort.Proxy.Destroy(_proxy);
                _proxy = IntPtr.Zero;

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class ProxyBase.
        /// </summary>
        ~ProxyBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release all resources used by the class ProxyBase.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
