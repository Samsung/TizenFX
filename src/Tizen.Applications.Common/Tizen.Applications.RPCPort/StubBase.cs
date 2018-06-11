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
    /// Abstract class for making a stub class for RPC
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public abstract class StubBase : IDisposable
    {
        private Interop.LibRPCPort.Stub.ConnectedEventCallback _connectedEventCallback;
        private Interop.LibRPCPort.Stub.DisconnectedEventCallback _disconnectedEventCallback;
        private Interop.LibRPCPort.Stub.ReceivedEventCallback _receivedEventCallback;
        private IntPtr _stub;

        /// <summary>
        /// Gets port name
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public string PortName { get; private set; }

        /// <summary>
        /// Constructor for this class
        /// </summary>
        /// <param name="portName">The name of the port which want to listen</param>
        /// <exception cref="InvalidIOException">Thrown when internal IO error happens</exception>
        /// <since_tizen> 5 </since_tizen>
        public StubBase(string portName)
        {
            if (Interop.LibRPCPort.Stub.Create(out _stub, portName) != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
            PortName = portName;
            _connectedEventCallback = new Interop.LibRPCPort.Stub.ConnectedEventCallback(OnConnectedEvent);
            _disconnectedEventCallback = new Interop.LibRPCPort.Stub.DisconnectedEventCallback(OnDisconnectedEvent);
            _receivedEventCallback = new Interop.LibRPCPort.Stub.ReceivedEventCallback(OnReceivedEvent);
            Interop.LibRPCPort.Stub.AddReceivedEventCb(_stub, _receivedEventCallback, IntPtr.Zero);
            Interop.LibRPCPort.Stub.AddConnectedEventCb(_stub, _connectedEventCallback, IntPtr.Zero);
            Interop.LibRPCPort.Stub.AddDisconnectedEventCb(_stub, _disconnectedEventCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Listens to the requests for connections
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when internal IO error happens</exception>
        /// <since_tizen> 5 </since_tizen>
        protected void Listen()
        {
            var err = Interop.LibRPCPort.Stub.Listen(_stub);
            switch (err)
            {
                case Interop.LibRPCPort.ErrorCode.InvalidParameter:
                case Interop.LibRPCPort.ErrorCode.IoError:
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Adds a privilege to the stub
        /// </summary>
        /// <param name="privilege">The privilege to access this stub</param>
        /// <exception cref="ArgumentNullException">Thrown when the privilege is null</exception>
        /// <since_tizen> 5 </since_tizen>
        protected void AddPrivilege(string privilege)
        {
            if (privilege == null)
                throw new ArgumentNullException();
            Interop.LibRPCPort.Stub.AddPrivilege(_stub, privilege);
        }

        /// <summary>
        /// Sets trusted to the stub
        /// </summary>
        /// <param name="trusted">Whether stub allows only trusted proxy or not</param>
        /// <since_tizen> 5 </since_tizen>
        protected void SetTrusted(bool trusted)
        {
            Interop.LibRPCPort.Stub.SetTrusted(_stub, trusted);
        }

        /// <summary>
        /// Abstract method for receiving connected event
        /// </summary>
        /// <param name="sender">The target proxy app ID</param>
        /// <param name="instance">The information of the request</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnConnectedEvent(string sender, string instance);

        /// <summary>
        /// Abstract method for receiving disconnected event
        /// </summary>
        /// <param name="sender">The target proxy app ID</param>
        /// <param name="instance">The information of the request</param>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnDisconnectedEvent(string sender, string instance);

        /// <summary>
        /// Abstract method called when the stub received data from proxy
        /// </summary>
        /// <param name="sender">The target proxy app ID</param>
        /// <param name="instance">The information of the request</param>
        /// <param name="port">Port object for reading and writing</param>
        /// <returns></returns>
        /// <since_tizen> 5 </since_tizen>
        protected abstract bool OnReceivedEvent(string sender, string instance, Port port);

        /// <summary>
        /// Abstract method called right before disposing object
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        protected abstract void OnTerminatedEvent();

        private void OnConnectedEvent(string sender, string instance, IntPtr data)
        {
            OnConnectedEvent(sender, instance);
        }

        private void OnDisconnectedEvent(string sender, string instance, IntPtr data)
        {
            OnDisconnectedEvent(sender, instance);
        }

        private int OnReceivedEvent(string sender, string instance, IntPtr port, IntPtr data)
        {
            bool b = OnReceivedEvent(sender, instance, new Port() { Handle = port });
            if (b)
                return 0;
            return -1;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                OnTerminatedEvent();

                if (_stub != IntPtr.Zero)
                    Interop.LibRPCPort.Proxy.Destroy(_stub);
                _stub = IntPtr.Zero;

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class StubBase
        /// </summary>
        ~StubBase()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release all resources used by the class StubBase
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
