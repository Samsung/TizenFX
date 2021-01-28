/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Xml.Serialization;

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// Abstract class for creating a component port class.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public abstract class ComponentPort : IDisposable
    {
        private static string LogTag = "ComponentPort";
        private readonly string _portName;
        private IntPtr _port = IntPtr.Zero;
        private Interop.ComponentPort.ComponentPortRequestCallback _requestEventCallback;
        private Interop.ComponentPort.ComponentPortSyncRequestCallback _syncRequestEventCallback;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
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
        /// Gets the port name.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string PortName
        {
            get
            {
                return _portName;
            }
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
        /// <param name="endpoint">The name of the endpoint</param>
        /// <param name="timeout">The interval of timeout</param>
        /// <param name="request">The serializable data to send</param>
        /// <since_tizen> 9 </since_tizen>
        public void Send(string endpoint, int timeout, object request)
        {
            if (request == null)
            {
                throw new ArgumentException("request is null");
            }

            if (!request.GetType().IsSerializable)
            {
                throw new ArgumentException("request is not serializable");
            }

            Interop.ComponentPort.ErrorCode err;
            using (Parcel reqParcel = ToParcel(request))
            {
                err = Interop.ComponentPort.Send(_port, endpoint, timeout, reqParcel.SafeParcelHandle);
            }
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
        /// <param name="endpoint">The name of the endpoint</param>
        /// <param name="timeout">The interval of timeout</param>
        /// <param name="request">The serializable data to send</param>
        /// <returns>The received serializable data</returns>
        /// /// <since_tizen> 9 </since_tizen>
        public object SendSync(string endpoint, int timeout, object request)
        {
            if (request == null)
            {
                throw new ArgumentException("request is null");
            }

            if (!request.GetType().IsSerializable)
            {
                throw new ArgumentException("request is not serializable");
            }

            SafeParcelHandle resSafeHandle = null;
            Interop.ComponentPort.ErrorCode err;
            using (Parcel reqParcel = ToParcel(request))
            {             
                err = Interop.ComponentPort.SendSync(_port, endpoint, timeout, reqParcel.SafeParcelHandle, out resSafeHandle);
            }
            if (err != Interop.ComponentPort.ErrorCode.None)
            {
                throw ComponentPortErrorFactory.GetException(err, "Failed to send the request.");
            }

            using (Parcel resParcel = new Parcel(resSafeHandle))
            {
                object response = FromParcel(resParcel);
                return response;
            }            
        }

        /// <summary>
        /// Abstract method for receiving a request event.
        /// </summary>
        /// <param name="sender">The name of the sender</param>
        /// <param name="request">The serializable data</param>
        /// <since_tizen> 9 </since_tizen>
        protected abstract void OnRequestEvent(string sender, object request);

        /// <summary>
        /// Abstract method for receiving a synchronous request event.
        /// </summary>
        /// <param name="sender">The name of the sender</param>
        /// <param name="request">The serializable data</param>
        /// <returns>The serializable data</returns>
        /// <since_tizen> 9 </since_tizen>
        protected abstract object OnSyncRequestEvent(string sender, object request);


        private void OnRequestEvent(string sender, IntPtr request, IntPtr data)
        {
            SafeParcelHandle reqSafeHandle = new SafeParcelHandle(request, false);
            using (var reqParcel = new Parcel(reqSafeHandle))
            {
                object req = FromParcel(reqParcel);
                OnRequestEvent(sender, req);
            }
        }

        private void OnSyncRequestEvent(string sender, IntPtr request, IntPtr response, IntPtr data)
        {
            SafeParcelHandle reqSafeHandle = new SafeParcelHandle(request, false);

            object req = null;
            using (Parcel reqParcel = new Parcel(reqSafeHandle))
            {
                req = FromParcel(reqParcel);
            }

            object result = OnSyncRequestEvent(sender, req);
            if (!result.GetType().IsSerializable)
            {
                Log.Error(LogTag, "result is not serializable");
            }
            else
            {
               SafeParcelHandle resSafeHandle = new SafeParcelHandle(response, false);
               using (Parcel resParcel = new Parcel(resSafeHandle))
                {
                    using (Parcel resultParcel = ToParcel(result))
                    {
                        resParcel.UnMarshall(resultParcel.Marshall());
                    }
                }
            }
        }

        private Parcel ToParcel(object envelope)
        {
            if (envelope == null)
                return null;

            BinaryFormatter formatter = new BinaryFormatter
            {
                Binder = new PortBinder(),
                AssemblyFormat = FormatterAssemblyStyle.Full
            };

            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, envelope);
                Parcel parcel = new Parcel();
                parcel.UnMarshall(stream.ToArray());
                return parcel;
            }
        }

        private object FromParcel(Parcel parcel)
        {
            if (parcel == null)
                return null;

            BinaryFormatter formatter = new BinaryFormatter
            {
                Binder = new PortBinder(),
                AssemblyFormat = FormatterAssemblyStyle.Full,
            };

            object envelope = null;
            using (MemoryStream stream = new MemoryStream(parcel.Marshall()))
            {
                try
                {
                    envelope = (object)formatter.Deserialize(stream);
                }
                catch (ArgumentException e)
                {
                    Log.Error(LogTag, "ArgumentException occurs: " + e.Message);
                }
                catch (SerializationException e)
                {
                    Log.Error(LogTag, "SerializationException occurs: " + e.Message);
                }
                catch (SecurityException e)
                {
                    Log.Error(LogTag, "SecurityException occurs: " + e.Message);
                }
            }

            return envelope;
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
                    if (_port != IntPtr.Zero)
                        Interop.ComponentPort.Destroy(_port);
                    _port = IntPtr.Zero;
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

        internal sealed class PortBinder : SerializationBinder
        {
            private static string LogTag = "PortBinder";

            private string GetAssemblyName(string typeName)
            {
                foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies())
                {
                    foreach (Type t in a.GetTypes())
                    {
                        if (t.FullName == typeName)
                        {
                            Log.Warn(LogTag, "Found! AssemblyName: " + a.FullName);
                            return a.FullName;
                        }
                    }
                }

                return string.Empty;
            }

            public override Type BindToType(string assemblyName, string typeName)
            {
                Type returntype = null;
                Log.Warn(LogTag, "AssemblyName: " + assemblyName);
                Log.Warn(LogTag, "TypeName: " + typeName);
                string foundAssemblyName = GetAssemblyName(typeName);
                if (foundAssemblyName.Length != 0)
                {
                    returntype = Type.GetType(String.Format("{0}, {1}", typeName, foundAssemblyName));
                }
                else
                {
                    returntype = Type.GetType(String.Format("{0}, {1}", typeName, assemblyName));
                }
                return returntype;
            }
        }

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
