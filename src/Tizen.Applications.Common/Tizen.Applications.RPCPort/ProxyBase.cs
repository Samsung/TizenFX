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
using System.ComponentModel;

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// Base class for creating a proxy class for remote procedure calls.
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
#pragma warning disable CA1721
        protected Port Port { get; private set; }
#pragma warning restore CA1721

        /// <summary>
        /// Gets Port object for asynchronous events.
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected Port CallbackPort { get; private set; }

        /// <summary>
        /// Creates a new instance of the ProxyBase class.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal I/O error occurs during initialization.</exception>
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
        /// Sets the communication domain as INET for the rpc port proxy.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetDomainInet()
        {
            var err = Interop.LibRPCPort.Proxy.SetDomainInet(_proxy);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Connects to the target stub using TCP/IP protocol asynchronously.
        /// </summary>
        /// <param name="ip">The IP address of the target stub.</param>
        /// <param name="appId">The application ID of the target stub.</param>
        /// <param name="port">The name of rpc port.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when permission is denied.</exception>
        /// <exception cref="InvalidIDException">Thrown when an invalid parameter is passed.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void TcpConnect(string ip, string appId, string port)
        {
            var err = Interop.LibRPCPort.Proxy.TcpConnect(_proxy, ip, appId, port);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.PermissionDenied:
                    throw new PermissionDeniedException();
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Connects to the target stub using TCP/IP protocol synchronously.
        /// </summary>
        /// <param name="ip">The IP address of the target stub.</param>
        /// <param name="appId">The application ID of the target stub.</param>
        /// <param name="port">The name of rpc port.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when permission is denied.</exception>
        /// <exception cref="InvalidIDException">Thrown when an invalid parameter is passed.</exception>
        /// <privilege>http://tizen.org/privilege/appmanager.launch</privilege>
        /// <privilege>http://tizen.org/privilege/datasharing</privilege>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void TcpConnectSync(string ip, string appId, string port)
        {
            var err = Interop.LibRPCPort.Proxy.TcpConnectSync(_proxy, ip, appId, port);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.PermissionDenied:
                    throw new PermissionDeniedException();
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Sets the client TLS certificate and key for authentication.
        /// </summary>
        /// <param name="certPath">Path to the client certificate file (PEM format).</param>
        /// <param name="keyPath">Path to the client private key file (PEM format).</param>
        /// <exception cref="InvalidIDException">Thrown when an invalid parameter is passed.</exception>
        /// <since_tizen> 13 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTlsClientCertificate(string certPath, string keyPath)
        {
            var err = Interop.LibRPCPort.Proxy.SetTlsClientCertificate(_proxy, certPath, keyPath);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Sets the CA certificate for server verification.
        /// </summary>
        /// <param name="caPath">Path to the CA certificate file (PEM format).</param>
        /// <exception cref="InvalidIDException">Thrown when an invalid parameter is passed.</exception>
        /// <since_tizen> 13 </since_tizen>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        protected void SetTlsCaCertificate(string caPath)
        {
            var err = Interop.LibRPCPort.Proxy.SetTlsCaCertificate(_proxy, caPath);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                    throw new InvalidIDException();
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Establishes a connection to the specified application through the named remote procedure call (RPC) port.
        /// </summary>
        /// <remarks>
        /// By calling this method, you can establish a connection between two applications using the specified RPC port. It requires the target application ID and the name of the desired RPC port.
        /// If the connection cannot be established due to invalid arguments or insufficient privileges, appropriate exceptions are thrown accordingly.
        /// </remarks>
        /// <param name="appid">The ID of the target application to connect to.</param>
        /// <param name="port">The name of the RPC port to use for the connection.</param>
        /// <exception cref="InvalidIDException">Thrown if the specified application ID does not exist.</exception>
        /// <exception cref="InvalidIOException">Thrown in case of an internal input/output error during the connection process.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when the required privileges are missing or access is otherwise restricted.</exception>
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
        /// Establishes a connection to the specified application synchronously through the named remote procedure call (RPC) port.
        /// </summary>
        /// <param name="appid">The ID of the target application to connect to.</param>
        /// <param name="port">The name of the RPC port to use for the connection.</param>
        /// <exception cref="InvalidIDException">Thrown if the specified application ID does not exist.</exception>
        /// <exception cref="InvalidIOException">Thrown in case of an internal input/output error during the connection process.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when the required privileges are missing or access is otherwise restricted.</exception>
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
        /// Retrieves a port based on its type.
        /// </summary>
        /// <param name="t">The specific type of port to retrieve.</param>
        /// <returns>An object representing the requested port.</returns>
        /// <exception cref="InvalidIOException">Thrown if an internal I/O error occurs while retrieving the port.</exception>
        /// <example>
        /// To get a main port:
        /// <code>
        /// Port mainPort = GetPort(Port.Type.Main);
        /// </code>
        /// </example>
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
        /// <param name="endPoint">The target stub application ID.</param>
        /// <param name="portName">The name of the Remote Procedure Call (RPC) port.</param>
        /// <param name="port">Port object for reading and writing.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnConnectedEvent(string endPoint, string portName, Port port);

        /// <summary>
        /// Abstract method for receiving disconnected event.
        /// </summary>
        /// <param name="endPoint">The target stub application ID..</param>
        /// <param name="portName">The name of the Remote Procedure Call (RPC) port.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnDisconnectedEvent(string endPoint, string portName);

        /// <summary>
        /// Abstract method called when the proxy receives data from stub.
        /// </summary>
        /// <param name="endPoint">The target stub application ID..</param>
        /// <param name="portName">The name of the Remote Procedure Call (RPC) port.</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnReceivedEvent(string endPoint, string portName);

        /// <summary>
        /// Abstract method for receiving rejected event.
        /// </summary>
        /// <param name="endPoint">The target stub application ID..</param>
        /// <param name="portName">The name of the Remote Procedure Call (RPC) port.</param>
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
