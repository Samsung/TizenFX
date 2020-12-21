/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// Abstract class for creating a component port class.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class ComponentPort : IDisposable
    {
        private readonly string _portName;
        private readonly SafePortHandle _port;
        private Interop.ComponentPort.ComponentPortRequestCallback _requestEventCallback;
        private Interop.ComponentPort.ComponentPortSyncRequestCallback _syncRequestEventCallback;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the arugment is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="portName">The name of the port.</param>
        /// <since_tizen> 9 </since_tizen>
        public ComponentPort(string portName)
        {
            var ret = Interop.ComponentPort.Create(portName, out _port);
            if (ret != Interop.ComponentPort.ErrorCode.None)
                throw ComponentPortErrorFactory.GetException(ret, "ComponentPort(" + portName + ").");

            _portName = portName;
            _requestEventCallback = new Interop.ComponentPort.ComponentPortRequestCallback(OnRequestEvent);
            _syncRequestEventCallback = new Interop.ComponentPort.ComponentPortSyncRequestCallback(OnSyncRequestEvent);
            Interop.ComponentPort.SetRequestCb(_port, _requestEventCallback, IntPtr.Zero);
            Interop.ComponentPort.SetSyncRequestCb(_port, _syncRequestEventCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Adds a privilege to the port object.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <param name="privilege">privilege data</param>
        /// <since_tizen> 9 </since_tizen>
        public void AddPrivilege(string privilege)
        {
            Interop.ComponentPort.AddPrivilege(_port, privilege);
        }

        /// <summary>
        /// Waits for events.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void WaitForEvent()
        {
            Interop.ComponentPort.WaitForEvent(_port);
        }

        /// <summary>
        /// Cancels waiting for events.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public void Cancel()
        {
            Interop.ComponentPort.Cancel(_port);
        }

        /// <summary>
        /// Sends the request data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when because of permission denied.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="portName">The name of the port</param>
        /// <param name="timeout">The interval of timeout</param>
        /// <param name="request">The parcel data to send</param>
        /// <since_tizen> 9 </since_tizen>
        public void Send(string portName, int timeout, Parcel request)
        {
            if (request == null)
            {
                throw new ArgumentException("request is null");
            }

            Interop.ComponentPort.ErrorCode err;
            err = Interop.ComponentPort.Send(_port, portName, timeout, request.SafeParcelHandle);
            if (err != Interop.ComponentPort.ErrorCode.None)
            {
                throw ComponentPortErrorFactory.GetException(err, "Failed to send the request.");
            }
        }

        /// <summary>
        /// Sends the request data synchronously.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when because of permission denied.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="portName">The name of the port</param>
        /// <param name="timeout">The interval of timeout</param>
        /// <param name="request">The parcel data to send</param>
        /// <returns>The received parcel data</returns>
        /// /// <since_tizen> 9 </since_tizen>
        public Parcel SendSync(string portName, int timeout, Parcel request)
        {
            if (request == null)
            {
                throw new ArgumentException("request is null");
            }

            Interop.ComponentPort.ErrorCode err;
            err = Interop.ComponentPort.SendSync(_port, portName, timeout, request.SafeParcelHandle, out SafeParcelHandle res);
            if (err != Interop.ComponentPort.ErrorCode.None)
            {
                throw ComponentPortErrorFactory.GetException(err, "Failed to send the request.");
            }

            var response = new Parcel(res);  
            res.Dispose();
            return response;
        }

        /// <summary>
        /// Abstrace method for receiving a request event.
        /// </summary>
        /// <param name="sender">The name of the sender</param>
        /// <param name="request">The parcel data</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnRequestEvent(string sender, Parcel request);

        /// <summary>
        /// Abstrace method for receiving a synchronous request event.
        /// </summary>
        /// <param name="sender">The name of the sender</param>
        /// <param name="request">The parcel data</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract Parcel OnSyncRequestEvent(string sender, Parcel request);


        private void OnRequestEvent(string sender, IntPtr request, IntPtr data)
        {
            SafeParcelHandle safeHandle = new SafeParcelHandle(request, false);
            var req = new Parcel(safeHandle);
            OnRequestEvent(sender, req);
            req.Dispose();
            safeHandle.Dispose();
        }

        private void OnSyncRequestEvent(string sender, IntPtr request, IntPtr response, IntPtr data)
        {
            SafeParcelHandle reqSafeHandle = new SafeParcelHandle(request, false);
            Parcel req = new Parcel(reqSafeHandle);
            Parcel ret = OnSyncRequestEvent(sender, req);
            SafeParcelHandle safeHandle = new SafeParcelHandle(response, false);
            Parcel res = new Parcel(safeHandle);
            res.Write(ret.Marshall());
            res.Dispose();
            safeHandle.Dispose();
            req.Dispose();
            req.Dispose();
            reqSafeHandle.Dispose();            
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects, or false not to dispose disposable objects.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_port != null && !_port.IsInvalid)
                        _port.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class ComponentPort.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        ~ComponentPort()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Releases all the resources used by the class ComponentPort.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        internal static class ComponentPortErrorFactory
        {
            internal static Exception GetException(Interop.ComponentPort.ErrorCode err, string message)
            {
                string errMessage = string.Format("{0} err = {1}", message, err);
                switch (err)
                {
                    case Interop.ComponentPort.ErrorCode.InvalidParameter:
                        return new ArgumentException(errMessage);
                    case Interop.ComponentPort.ErrorCode.PermissionDenied:
                        return new UnauthorizedAccessException(errMessage);
                    case Interop.ComponentPort.ErrorCode.OutOfMemory:
                        return new OutOfMemoryException(errMessage);
                    default:
                        return new global::System.IO.IOException(errMessage);
                }
            }
        }
    }
}
