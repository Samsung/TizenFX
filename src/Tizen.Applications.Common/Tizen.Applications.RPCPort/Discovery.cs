/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// A class for discovering RPC services.
    /// </summary>
    /// <since_tizen> 13 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class Discovery : IDisposable
    {
        private IntPtr _handle;
        private Interop.LibRPCPort.Discovery.DiscoveryCallback _discoveryCallback;
        private bool _disposed = false;

        /// <summary>
        /// Event arguments for the ServiceFound event.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public class ServiceFoundEventArgs : EventArgs
        {
            /// <summary>
            /// Gets the name of the discovered service.
            /// </summary>
            /// <since_tizen> 13 </since_tizen>
            public string ServiceName { get; }

            /// <summary>
            /// Gets the TIDL port name.
            /// </summary>
            /// <since_tizen> 13 </since_tizen>
            public string TidlPort { get; }

            /// <summary>
            /// Gets the application ID.
            /// </summary>
            /// <since_tizen> 13 </since_tizen>
            public string AppId { get; }

            /// <summary>
            /// Gets the IP address of the service.
            /// </summary>
            /// <since_tizen> 1311 </since_tizen>
            public string Ip { get; }

            internal ServiceFoundEventArgs(string serviceName, string tidlPort, string appId, string ip)
            {
                ServiceName = serviceName;
                TidlPort = tidlPort;
                AppId = appId;
                Ip = ip;
            }
        }

        /// <summary>
        /// Event raised when a service is found.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public event EventHandler<ServiceFoundEventArgs> ServiceFound;

        /// <summary>
        /// Creates a new instance of the Discovery class.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 13 </since_tizen>
        public Discovery()
        {
            var err = Interop.LibRPCPort.Discovery.Create(out _handle);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();

            _discoveryCallback = OnDiscoveryEvent;
        }

        /// <summary>
        /// Starts finding services.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void StartFinding()
        {

            var err = Interop.LibRPCPort.Discovery.StartFinding(_handle, _discoveryCallback, IntPtr.Zero);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Stops finding services.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void StopFinding()
        {
            var err = Interop.LibRPCPort.Discovery.StopFinding(_handle);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Registers a service for discovery.
        /// </summary>
        /// <param name="serviceName">The name of the service to register.</param>
        /// <param name="tidlPort">The TIDL port name.</param>
        /// <param name="appId">The application ID.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="ArgumentNullException">Thrown when any of the parameters is null.</exception>
        /// <since_tizen> 13 </since_tizen>
        public void RegisterService(string serviceName, string tidlPort, string appId)
        {
            if (serviceName == null)
                throw new ArgumentNullException(nameof(serviceName));
            if (tidlPort == null)
                throw new ArgumentNullException(nameof(tidlPort));
            if (appId == null)
                throw new ArgumentNullException(nameof(appId));

            var err = Interop.LibRPCPort.Discovery.RegisterService(_handle, serviceName, tidlPort, appId);
            if (err != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        private void OnDiscoveryEvent(string serviceName, string tidlPort, string appId, string ip, IntPtr userData)
        {
            ServiceFound?.Invoke(this, new ServiceFoundEventArgs(serviceName, tidlPort, appId, ip));
        }

        #region IDisposable Support
        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <param name="disposing">true to dispose managed resources as well.</param>
        /// <since_tizen> 13 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // Dispose managed resources here
                }

                if (_handle != IntPtr.Zero)
                {
                    Interop.LibRPCPort.Discovery.StopFinding(_handle);
                    Interop.LibRPCPort.Discovery.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Finalizer for the Discovery class.
        /// </summary>
        ~Discovery()
        {
            Dispose(false);
        }

        /// <summary>
        /// Releases all resources used by the Discovery class.
        /// </summary>
        /// <since_tizen> 13 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}