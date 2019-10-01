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
using System.Collections.Concurrent;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents a remote resource.
    /// It provides APIs to manage remote resource.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class RemoteResource : IDisposable
    {
        internal const int TimeOutMax = 3600;
        internal IntPtr _remoteResourceHandle = IntPtr.Zero;

        private bool _disposed = false;
        private bool _cacheEnabled = false;
        private ResourceOptions _options;

        private static int _responseCompletionId = 1;
        private static IDictionary<IntPtr, TaskCompletionSource<RemoteResponse>> _taskCompletionMap = new ConcurrentDictionary<IntPtr, TaskCompletionSource<RemoteResponse>>();

        private static Interop.IoTConnectivity.Client.RemoteResource.ResponseCallback _getResultCallback = NativeGetResultCallbackHandler;
        private static Interop.IoTConnectivity.Client.RemoteResource.ResponseCallback _putResultCallback = NativePutResultCallbackHandler;
        private static Interop.IoTConnectivity.Client.RemoteResource.ResponseCallback _postResultCallback = NativePostResultCallbackHandler;
        private static Interop.IoTConnectivity.Client.RemoteResource.ResponseCallback _deleteResultCallback = NativeDeleteResultCallbackHandler;

        private Interop.IoTConnectivity.Client.RemoteResource.CachedRepresentationChangedCallback _cacheUpdatedCallback;
        private Interop.IoTConnectivity.Client.RemoteResource.StateChangedCallback _stateChangedCallback;
        private Interop.IoTConnectivity.Client.RemoteResource.ObserveCallback _observeCallback;

        private EventHandler<StateChangedEventArgs> _stateChangedEventHandler;

        /// <summary>
        /// Creates a remote resource instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>To use this API, you should provide all the details required to correctly contact and
        /// observe the object.</para>
        /// <para>If not, you should discover the resource object manually.</para>
        /// <para>The <paramref name="policy" /> can contain multiple policies like <c>ResourcePolicy.Discoverable | ResourcePolicy.Observable</c>.</para>
        /// </remarks>
        /// <param name="hostAddress">The host address of the resource.</param>
        /// <param name="uriPath">The URI path of the resource.</param>
        /// <param name="policy">The policies of the resource.</param>
        /// <param name="resourceTypes">The resource types of the resource.</param>
        /// <param name="resourceInterfaces">The resource interfaces of the resource.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        public RemoteResource(string hostAddress, string uriPath, ResourcePolicy policy, ResourceTypes resourceTypes, ResourceInterfaces resourceInterfaces)
        {
            if (hostAddress == null || uriPath == null || resourceTypes == null || resourceInterfaces == null)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid parameters");
                throw new ArgumentException("Invalid parameter");
            }

            HostAddress = hostAddress;
            UriPath = uriPath;
            Policy = policy;
            Types = new List<string>(resourceTypes);
            Interfaces = new List<string>(resourceInterfaces);
            DeviceId = null;

            CreateRemoteResource(resourceTypes._resourceTypeHandle, resourceInterfaces.ResourceInterfacesHandle);
        }

        internal RemoteResource(IntPtr handleToClone)
        {
            int ret = Interop.IoTConnectivity.Client.RemoteResource.Clone(handleToClone, out _remoteResourceHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Faled to clone");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            SetRemoteResource();
        }

        /// <summary>
        /// Destructor of the RemoteResource class.
        /// </summary>
        ~RemoteResource()
        {
            Dispose(false);
        }

        /// <summary>
        /// The event is invoked with cached resource attributes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<CacheUpdatedEventArgs> CacheUpdated;

        /// <summary>
        /// Observe an event on the resource sent by the server.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<ObserverNotifiedEventArgs> ObserverNotified;

        /// <summary>
        /// The event is called when remote resource's state are changed.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public event EventHandler<StateChangedEventArgs> StateChanged
        {
            add
            {
                if (_stateChangedEventHandler == null)
                {
                    RegisterStateChangedEvent();
                }
                _stateChangedEventHandler += value;
            }
            remove
            {
                _stateChangedEventHandler -= value;
                if (_stateChangedEventHandler == null)
                {
                    UnregisterStateChangedEvent();
                }
            }
        }

        /// <summary>
        /// The host address of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The host address of the resource.</value>
        public string HostAddress { get; private set; }

        /// <summary>
        /// The URI path of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The URI path of the resource.</value>
        public string UriPath { get; private set; }

        /// <summary>
        /// The resource types of the remote resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The resource types of the remote resource.</value>
        public IEnumerable<string> Types { get; private set; }

        /// <summary>
        /// The interfaces of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The interfaces of the resource.</value>
        public IEnumerable<string> Interfaces { get; private set; }

        /// <summary>
        /// The policy of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The policy of the resource.</value>
        public ResourcePolicy Policy { get; private set; }

        /// <summary>
        /// The header options of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The header options of the resource.</value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        public ResourceOptions Options
        {
            get
            {
                return _options;
            }
            set
            {
                _options = value;
                if (value != null)
                {
                    int ret = Interop.IoTConnectivity.Client.RemoteResource.SetOptions(_remoteResourceHandle, value._resourceOptionsHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set options");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }

        /// <summary>
        /// Indicates the CacheEnabled status of the remote resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Client can start caching only when this is set true. Set it to false to stop caching the resource attributes.
        /// </value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        public bool CacheEnabled
        {
            get
            {
                return _cacheEnabled;
            }
            set
            {
                if (_cacheEnabled != value)
                {
                    _cacheEnabled = value;
                    HandleCachePolicyChanged();
                }
            }
        }

        /// <summary>
        /// Time interval of monitoring and caching API.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// Default time interval is 10 seconds.
        /// Seconds for time interval (must be in range from 1 to 3600).
        /// </value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        public int TimeInterval
        {
            get
            {
                int interval;
                int ret = Interop.IoTConnectivity.Client.RemoteResource.GetTimeInterval(_remoteResourceHandle, out interval);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Warn(IoTConnectivityErrorFactory.LogTag, "Failed to get time interval");
                    return 0;
                }
                return interval;
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value <= TimeOutMax && value > 0)
                {
                    ret = Interop.IoTConnectivity.Client.RemoteResource.SetTimeInterval(_remoteResourceHandle, value);
                }
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set time interval");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// The device ID of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The device ID of the resource.</value>
        public string DeviceId { get; private set; }

        /// <summary>
        /// Gets cached representation from the remote resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>cached representation from the remote resource.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public Representation CachedRepresentation()
        {
            IntPtr handle;
            int ret = Interop.IoTConnectivity.Client.RemoteResource.GetCachedRepresentation(_remoteResourceHandle, out handle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Warn(IoTConnectivityErrorFactory.LogTag, "Failed to get CachedRepresentation");
                return null;
            }

            Representation representation = new Representation(handle);
            return representation;
        }

        /// <summary>
        /// Starts observing on the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// When server sends notification message, <see cref="ObserverNotified"/> will be called.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="policy">The type to specify how client wants to observe.</param>
        /// <param name="query">The query to send to server.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        public void StartObserving(ObservePolicy policy, ResourceQuery query = null)
        {
            _observeCallback = (IntPtr resource, int err, int sequenceNumber, IntPtr response, IntPtr userData) =>
            {
                int result;
                IntPtr representationHandle;
                int ret = Interop.IoTConnectivity.Server.Response.GetResult(response, out result);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get result");
                    return;
                }

                ret = Interop.IoTConnectivity.Server.Response.GetRepresentation(response, out representationHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get representation");
                    return;
                }

                Representation repr = null;
                try
                {
                    repr = new Representation(representationHandle);
                }
                catch (Exception exp)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new representation: " + exp.Message);
                    return;
                }

                ObserverNotifiedEventArgs e = new ObserverNotifiedEventArgs()
                {
                    Representation = repr,
                    Result = (ResponseCode)result
                };
                ObserverNotified?.Invoke(this, e);
            };

            IntPtr queryHandle = IntPtr.Zero;
            if (query != null)
            {
                queryHandle = query._resourceQueryHandle;
            }

            int errCode = Interop.IoTConnectivity.Client.RemoteResource.RegisterObserve(_remoteResourceHandle, (int)policy, queryHandle, _observeCallback, IntPtr.Zero);
            if (errCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to register observe callbacks");
                throw IoTConnectivityErrorFactory.GetException(errCode);
            }
        }

        /// <summary>
        /// Stops observing on the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        public void StopObserving()
        {
            int ret = Interop.IoTConnectivity.Client.RemoteResource.DeregisterObserve(_remoteResourceHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to deregister observe callbacks");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Gets the attributes of a resource asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="query">The ResourceQuery to send to server.</param>
        /// <returns>Remote response with result and representation.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public async Task<RemoteResponse> GetAsync(ResourceQuery query = null)
        {
            TaskCompletionSource<RemoteResponse> tcsRemoteResponse = new TaskCompletionSource<RemoteResponse>();

            IntPtr id = IntPtr.Zero;
            lock (_taskCompletionMap)
            {
                id = (IntPtr)_responseCompletionId++;
            }

            _taskCompletionMap[id] = tcsRemoteResponse;

            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errCode = Interop.IoTConnectivity.Client.RemoteResource.Get(_remoteResourceHandle, queryHandle, _getResultCallback, id);
            if (errCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get resource attributes");
                tcsRemoteResponse.TrySetException(IoTConnectivityErrorFactory.GetException(errCode));
            }
            return await tcsRemoteResponse.Task;
        }

        private static void NativeGetResultCallbackHandler(IntPtr resource, int err, int requestType, IntPtr responseHandle, IntPtr userData)
        {
            IntPtr responseCompletionId = userData;
            TaskCompletionSource<RemoteResponse> responseCompletionSource = _taskCompletionMap[responseCompletionId];
            _taskCompletionMap.Remove(responseCompletionId);

            if (responseHandle != IntPtr.Zero)
            {
                try
                {
                    responseCompletionSource.TrySetResult(GetRemoteResponse(responseHandle));
                }
                catch(Exception exp)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get RemoteResponse: ", exp.Message);
                    responseCompletionSource.TrySetException(exp);
                }
            }
            else
            {
                responseCompletionSource.TrySetException(IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.System));
            }
        }

        /// <summary>
        /// Puts the representation of a resource asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="representation">Resource representation to put.</param>
        /// <param name="query">The ResourceQuery to send to server.</param>
        /// <returns>Remote response with result and representation.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public async Task<RemoteResponse> PutAsync(Representation representation, ResourceQuery query = null)
        {
            TaskCompletionSource<RemoteResponse> tcsRemoteResponse = new TaskCompletionSource<RemoteResponse>();

            IntPtr id = IntPtr.Zero;
            lock (_taskCompletionMap)
            {
                id = (IntPtr)_responseCompletionId++;
            }

            _taskCompletionMap[id] = tcsRemoteResponse;

            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errCode = Interop.IoTConnectivity.Client.RemoteResource.Put(_remoteResourceHandle, representation._representationHandle, queryHandle, _putResultCallback, id);
            if (errCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to put resource representation");
                tcsRemoteResponse.TrySetException(IoTConnectivityErrorFactory.GetException(errCode));
            }
            return await tcsRemoteResponse.Task;
        }

        private static void NativePutResultCallbackHandler(IntPtr resource, int err, int requestType, IntPtr responseHandle, IntPtr userData)
        {
            IntPtr responseCompletionId = userData;
            TaskCompletionSource<RemoteResponse> responseCompletionSource = _taskCompletionMap[responseCompletionId];
            _taskCompletionMap.Remove(responseCompletionId);

            if (err == (int)(IoTConnectivityError.Iotivity))
            {
                RemoteResponse response = new RemoteResponse();
                response.Result = ResponseCode.Forbidden;
                response.Representation = null;
                responseCompletionSource.TrySetResult(response);
            }
            else if (responseHandle != IntPtr.Zero)
            {
                try
                {
                    responseCompletionSource.TrySetResult(GetRemoteResponse(responseHandle));
                }
                catch (Exception exp)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get RemoteResponse: ", exp.Message);
                    responseCompletionSource.TrySetException(exp);
                }
            }
            else
            {
                responseCompletionSource.TrySetException(IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.System));
            }
        }

        /// <summary>
        /// Posts request on a resource asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="representation">Resource representation of request.</param>
        /// <param name="query">The ResourceQuery to send to server.</param>
        /// <returns>Remote response with result and representation.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public async Task<RemoteResponse> PostAsync(Representation representation, ResourceQuery query = null)
        {
            TaskCompletionSource<RemoteResponse> tcsRemoteResponse = new TaskCompletionSource<RemoteResponse>();

            IntPtr id = IntPtr.Zero;
            lock (_taskCompletionMap)
            {
                id = (IntPtr)_responseCompletionId++;
            }

            _taskCompletionMap[id] = tcsRemoteResponse;

            IntPtr queryHandle = (query == null) ? IntPtr.Zero : query._resourceQueryHandle;
            int errCode = Interop.IoTConnectivity.Client.RemoteResource.Post(_remoteResourceHandle, representation._representationHandle, queryHandle, _postResultCallback, id);
            if (errCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to post request");
                tcsRemoteResponse.TrySetException(IoTConnectivityErrorFactory.GetException(errCode));
            }
            return await tcsRemoteResponse.Task;
        }

        private static void NativePostResultCallbackHandler(IntPtr resource, int err, int requestType, IntPtr responseHandle, IntPtr userData)
        {
            IntPtr responseCompletionId = userData;
            TaskCompletionSource<RemoteResponse> responseCompletionSource = _taskCompletionMap[responseCompletionId];
            _taskCompletionMap.Remove(responseCompletionId);

            if (responseHandle != IntPtr.Zero)
            {
                try
                {
                    responseCompletionSource.TrySetResult(GetRemoteResponse(responseHandle));
                }
                catch (Exception exp)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get RemoteResponse: ", exp.Message);
                    responseCompletionSource.TrySetException(exp);
                }
            }
            else
            {
                responseCompletionSource.TrySetException(IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.System));
            }
        }

        /// <summary>
        /// Deletes the resource asynchronously.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <returns>Remote response with result and representation.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public async Task<RemoteResponse> DeleteAsync()
        {
            TaskCompletionSource<RemoteResponse> tcsRemoteResponse = new TaskCompletionSource<RemoteResponse>();

            IntPtr id = IntPtr.Zero;
            lock (_taskCompletionMap)
            {
                id = (IntPtr)_responseCompletionId++;
            }

            _taskCompletionMap[id] = tcsRemoteResponse;

            int errCode = Interop.IoTConnectivity.Client.RemoteResource.Delete(_remoteResourceHandle, _deleteResultCallback, id);
            if (errCode != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to delete");
                tcsRemoteResponse.TrySetException(IoTConnectivityErrorFactory.GetException(errCode));
            }
            return await tcsRemoteResponse.Task;
        }

        private static void NativeDeleteResultCallbackHandler(IntPtr resource, int err, int requestType, IntPtr responseHandle, IntPtr userData)
        {
            IntPtr responseCompletionId = userData;
            TaskCompletionSource<RemoteResponse> responseCompletionSource = _taskCompletionMap[responseCompletionId];
            _taskCompletionMap.Remove(responseCompletionId);

            if (err == (int)(IoTConnectivityError.Iotivity))
            {
                RemoteResponse response = new RemoteResponse();
                response.Result = ResponseCode.Forbidden;
                response.Representation = null;
                responseCompletionSource.TrySetResult(response);
            }
            else if (responseHandle != IntPtr.Zero)
            {
                try
                {
                    responseCompletionSource.TrySetResult(GetRemoteResponse(responseHandle));
                }
                catch (Exception exp)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get RemoteResponse: ", exp.Message);
                    responseCompletionSource.TrySetException(exp);
                }
            }
            else
            {
                responseCompletionSource.TrySetException(IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.System));
            }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal static Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType GetConnectivityType(string hostAddress)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType type = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None;

            Log.Info(IoTConnectivityErrorFactory.LogTag, hostAddress);

            if (hostAddress == IoTConnectivityClientManager.MulticastAddress)
            {
                type = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ipv4;
            }
            else
            {
                IPAddress address;
                string hostName = hostAddress;
                if (hostAddress.Contains(":"))
                {
                    string[] hostParts = hostAddress.Split(':');
                    if (hostParts.Length == 2)
                    {
                        hostName = hostParts[0];
                    }
                }
                if (hostAddress.Contains("%"))
                {
                    string[] hostParts = hostAddress.Split('%');
                    if (hostParts.Length == 2)
                    {
                        hostName = hostParts[0];
                    }
                }
                if (hostName.Contains("["))
                {
                    string[] hostParts = hostName.Split('[');
                    if (hostParts.Length == 2)
                    {
                        hostName = hostParts[1];
                    }
                }
                Log.Info(IoTConnectivityErrorFactory.LogTag, hostName);
                if (IPAddress.TryParse(hostName, out address))
                {
                    switch (address.AddressFamily)
                    {
                        case System.Net.Sockets.AddressFamily.InterNetwork:
                            type = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ipv4;
                            break;
                        case System.Net.Sockets.AddressFamily.InterNetworkV6:
                            type = Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.Ipv6;
                            break;
                        default:
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to parse for Ipv4 or Ipv6");
                            break;
                    }
                }
                else
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to parse hostname " + hostName);
                }
            }
            return type;
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.IoTConnectivity.Client.RemoteResource.Destroy(_remoteResourceHandle);
            _disposed = true;
        }

        private void HandleCachePolicyChanged()
        {
            if (_cacheEnabled)
            {
                _cacheUpdatedCallback = (IntPtr resource, IntPtr representation, IntPtr userData) =>
                {
                    if (CacheEnabled)
                    {
                        Representation repr = null;
                        try
                        {
                            repr = new Representation(representation);
                        }
                        catch (Exception exp)
                        {
                            Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new Representation: " + exp.Message);
                            return;
                        }

                        CacheUpdatedEventArgs e = new CacheUpdatedEventArgs()
                        {
                            Representation = repr
                        };
                        CacheUpdated?.Invoke(this, e);
                    }
                };

                int ret = Interop.IoTConnectivity.Client.RemoteResource.StartCaching(_remoteResourceHandle, _cacheUpdatedCallback, IntPtr.Zero);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add cache updated event handler");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else
            {
                int ret = Interop.IoTConnectivity.Client.RemoteResource.StopCaching(_remoteResourceHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove cache updated event handler");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        private void RegisterStateChangedEvent()
        {
            _stateChangedCallback = (IntPtr resource, int state, IntPtr userData) =>
            {
                StateChangedEventArgs e = new StateChangedEventArgs()
                {
                    State = (ResourceState)state
                };
                _stateChangedEventHandler?.Invoke(null, e);
            };

            int ret = Interop.IoTConnectivity.Client.RemoteResource.StartMonitoring(_remoteResourceHandle, _stateChangedCallback, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add state changed event handler");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        private void UnregisterStateChangedEvent()
        {
            int ret = Interop.IoTConnectivity.Client.RemoteResource.StopMonitoring(_remoteResourceHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove state changed event handler");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        private void CreateRemoteResource(IntPtr resourceTypeHandle, IntPtr resourceInterfaceHandle)
        {
            Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType connectivityType = GetConnectivityType(HostAddress);
            if (connectivityType == Interop.IoTConnectivity.Client.RemoteResource.ConnectivityType.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Unable to parse host address");
                throw new ArgumentException("Unable to parse host address");
            }
            int ret = Interop.IoTConnectivity.Client.RemoteResource.Create(HostAddress, (int)connectivityType, UriPath, (int)Policy, resourceTypeHandle, resourceInterfaceHandle, out _remoteResourceHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get remote resource");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        private void SetRemoteResource()
        {
            IntPtr hostAddressPtr, uriPathPtr;
            int ret = Interop.IoTConnectivity.Client.RemoteResource.GetHostAddress(_remoteResourceHandle, out hostAddressPtr);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Faled to get host address");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            ret = Interop.IoTConnectivity.Client.RemoteResource.GetUriPath(_remoteResourceHandle, out uriPathPtr);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Faled to get uri path");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            int policy = (int)ResourcePolicy.NoProperty;
            ret = Interop.IoTConnectivity.Client.RemoteResource.GetPolicies(_remoteResourceHandle, out policy);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Faled to get uri path");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            IntPtr typesHandle, interfacesHandle;
            ret = Interop.IoTConnectivity.Client.RemoteResource.GetTypes(_remoteResourceHandle, out typesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get resource types");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            ret = Interop.IoTConnectivity.Client.RemoteResource.GetInterfaces(_remoteResourceHandle, out interfacesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get resource interfaces");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            IntPtr deviceIdPtr;
            ret = Interop.IoTConnectivity.Client.RemoteResource.GetDeviceId(_remoteResourceHandle, out deviceIdPtr);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get device id");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            DeviceId = (deviceIdPtr != IntPtr.Zero) ? Marshal.PtrToStringAnsi(deviceIdPtr) : string.Empty;
            HostAddress = (hostAddressPtr != IntPtr.Zero) ? Marshal.PtrToStringAnsi(hostAddressPtr) : string.Empty;
            UriPath = (uriPathPtr != IntPtr.Zero) ? Marshal.PtrToStringAnsi(uriPathPtr) : string.Empty;
            Types = new ResourceTypes(typesHandle);
            Interfaces = new ResourceInterfaces(interfacesHandle);
            Policy = (ResourcePolicy)policy;
        }

        private static RemoteResponse GetRemoteResponse(IntPtr response)
        {
            int result;
            IntPtr representationHandle, optionsHandle;
            int ret = Interop.IoTConnectivity.Server.Response.GetResult(response, out result);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get result");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            ret = Interop.IoTConnectivity.Server.Response.GetRepresentation(response, out representationHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get representation");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            ret = Interop.IoTConnectivity.Server.Response.GetOptions(response, out optionsHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get options");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            return new RemoteResponse()
            {
                Result = (ResponseCode)result,
                Representation = new Representation(representationHandle),
                Options = (optionsHandle == IntPtr.Zero)? null : new ResourceOptions(optionsHandle)
            };
        }
    }
}
