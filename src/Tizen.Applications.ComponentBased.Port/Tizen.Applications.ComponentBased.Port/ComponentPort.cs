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
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security;
using System.Threading;
using System.Threading.Tasks;

namespace Tizen.Applications.ComponentBased
{
    /// <summary>
    /// The component port API provides functions to send and receive requests between components of component-based-application.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ComponentPort : IDisposable
    {
        private static string LogTag = "ComponentPort";
        private IntPtr _port = IntPtr.Zero;
        private Interop.ComponentPort.ComponentPortRequestCallback _requestEventCallback;
        private Interop.ComponentPort.ComponentPortSyncRequestCallback _syncRequestEventCallback;
        private static Dictionary<int, uint> _watcherIdMap = new Dictionary<int, uint>();
        private static Dictionary<int, Interop.ComponentPort.ComponentPortAppearedCallback> _appearedNativeCallbackMap = new Dictionary<int, Interop.ComponentPort.ComponentPortAppearedCallback>();
        private static Dictionary<int, Interop.ComponentPort.ComponentPortVanishedCallback> _vanishedNativeCallbackMap = new Dictionary<int, Interop.ComponentPort.ComponentPortVanishedCallback>();
        private static int _requestId = 0;

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

            PortName = portName;
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
            get;
            private set;
        }

        /// <summary>
        /// Adds a privilege to the port object.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <param name="privilege">privilege data</param>
        /// <since_tizen> 9 </since_tizen>
        public void AddPrivilege(string privilege)
        {
            if (string.IsNullOrEmpty(privilege))
            {
                throw new ArgumentException("Invalid argument");
            }

            Interop.ComponentPort.AddPrivilege(_port, privilege);
        }

        private static Task<bool> WaitForPortCore(string endpoint)
        {
            Interop.ComponentPort.IsRunning(endpoint, out bool isRunning);
            if (isRunning)
            {
                return Task.FromResult(true);
            }

            var task = new TaskCompletionSource<bool>();
            int requestId;
            lock (_appearedNativeCallbackMap)
            {
                requestId = _requestId++;
                _appearedNativeCallbackMap[requestId] = (string portName, int owner, IntPtr userData) =>
                {
                    int id = (int)userData;
                    Log.Info(LogTag, portName + " is appeared");
                    task.SetResult(true);
                    lock (_watcherIdMap)
                    {
                        Interop.ComponentPort.Unwatch(_watcherIdMap[id]);
                        _watcherIdMap.Remove(id);
                    }

                    lock (_vanishedNativeCallbackMap)
                    {
                        _vanishedNativeCallbackMap.Remove(id);
                    }

                    lock (_appearedNativeCallbackMap)
                    {
                        _appearedNativeCallbackMap.Remove(id);
                    }
                };
            }

            lock (_vanishedNativeCallbackMap)
            {
                _vanishedNativeCallbackMap[requestId] = (string portName, IntPtr userData) =>
                {
                    Log.Info(LogTag, portName + " is vanished");
                };
            }

            lock (_watcherIdMap)
            {
                Interop.ComponentPort.Watch(endpoint, _appearedNativeCallbackMap[requestId], _vanishedNativeCallbackMap[requestId], (IntPtr)requestId, out uint watcherId);
                _watcherIdMap[requestId] = watcherId;
            }

            return task.Task;
        }

        /// <summary>
        /// Waits until the port is ready.
        /// </summary>
        /// <param name="endpoint">The name of the port</param>
        /// <returns>A task.</returns>
        public static Task WaitForPort(string endpoint)
        {
            return WaitForPortCore(endpoint);
        }

        /// <summary>
        /// Waits for events.
        /// </summary>
        /// <remarks>
        /// This method runs a main loop until Cancel() is called.
        /// The code in the next line will not run until Cancel() is called.
        /// To avoid blocking the main thread, it's recommended to use the ComponentTask class.
        /// </remarks>
        /// <example>
        /// <code>
        /// ComponentTask task = new ComponentTask(new ComponentPort("Comm"));
        /// task.Start();
        /// </code>
        /// </example>
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
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="endpoint">The name of the endpoint</param>
        /// <param name="timeout">The timeout in milliseconds, -1 to use the default timeout</param>
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
        /// Sends the request data and receives the reply data.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="endpoint">The name of the endpoint</param>
        /// <param name="timeout">The timeout in milliseconds, -1 to use the default timeout</param>
        /// <param name="request">The serializable data to send</param>
        /// <returns>The received serializable data</returns>
        /// <since_tizen> 9 </since_tizen>
        public object SendAndReceive(string endpoint, int timeout, object request)
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
        /// Sends the request data and receives the reply data asynchronously.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the argument is invalid.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when permission is denied.</exception>
        /// <exception cref="global::System.IO.IOException">Thrown when because of I/O error.</exception>
        /// <param name="endpoint">The name of the endpoint</param>
        /// <param name="timeout">The timeout in milliseconds, -1 to use the default timeout</param>
        /// <param name="request">The serializable data to send</param>
        /// <returns>The received serializable data</returns>
        /// /// <since_tizen> 9 </since_tizen>
        public Task<object> SendAndReceiveAsync(string endpoint, int timeout, object request)
        {
            try
            {
                return Task.Run(() => SendAndReceive(endpoint, timeout, request));
            }
            catch
            {
                throw;
            }
        }

        /// <summary>
        /// Occurs whenever the request is received.
        /// </summary>
        /// <remarks>
        /// If the reply is requested, RequestEventArgs.Request should be set.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<RequestEventArgs> RequestReceived;

        private void OnRequestEvent(string sender, IntPtr request, IntPtr data)
        {
            SafeParcelHandle reqSafeHandle = new SafeParcelHandle(request, false);
            using (var reqParcel = new Parcel(reqSafeHandle))
            {
                object req = FromParcel(reqParcel);
                RequestReceived?.Invoke(this, new RequestEventArgs(sender, req, false));
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

            var args = new RequestEventArgs(sender, req, true);
            RequestReceived?.Invoke(this, args);

            var result = args.Reply;
            if (result == null)
            {
                Log.Error(LogTag, "result is null");
            }
            else if (!result.GetType().IsSerializable)
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
                        if (resultParcel != null)
                        {
                            resParcel.UnMarshall(resultParcel.Marshall());
                        }
                        else
                        {
                            Log.Error(LogTag, "Result parcel is null");
                        }
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
