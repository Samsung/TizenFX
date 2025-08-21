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
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Abstract class respresenting a resource.
    /// All resources need to inherit from this class.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public abstract class Resource : IDisposable
    {
        private IntPtr _resourceHandle = IntPtr.Zero;
        private bool _disposed = false;
        private ObservableCollection<Resource> _children = new ObservableCollection<Resource>();
        private IntPtr _observerHandle = IntPtr.Zero;

        /// <summary>
        /// The constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <paramref name="uri" /> format would be relative URI path like '/a/light'
        /// and its length must be less than 128.
        /// </remarks>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="uri">The URI path of the resource.</param>
        /// <param name="types">Resource types.</param>
        /// <param name="interfaces">Resource interfaces.</param>
        /// <param name="policy">The policies of the resoruce.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// IoTConnectivityServerManager.Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="ResourceTypes"/>
        /// <seealso cref="ResourceInterfaces"/>
        /// <seealso cref="ResourcePolicy"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code><![CDATA[
        /// // Create a class which inherits from Resource
        /// public class DoorResource : Resource
        /// {
        ///     public DoorResource(string uri, ResourceTypes types, ResourceInterfaces interfaces, ResourcePolicy policy)
        ///             : base(uri, types, interfaces, policy) {
        ///     }
        ///     protected override Response OnDelete(Request request) {
        ///         // Do something
        ///     }
        ///     protected override Response OnGet(Request request) {
        ///         // Do something
        ///     }
        ///     // Override other abstract methods of Resource class
        /// }
        ///
        /// // Use it like below
        /// ResourceInterfaces ifaces = new ResourceInterfaces(new List<string>(){ ResourceInterfaces.DefaultInterface });
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "oic.iot.door.new" });
        /// Resource resource = new DoorResource("/door/uri1", types, ifaces, ResourcePolicy.Discoverable | ResourcePolicy.Observable);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        protected Resource(string uri, ResourceTypes types, ResourceInterfaces interfaces, ResourcePolicy policy)
        {
            UriPath = uri;
            Types = types;
            Interfaces = interfaces;
            Policy = policy;

            _children.CollectionChanged += ChildrenCollectionChanged;

            int ret = Interop.IoTConnectivity.Server.Observers.Create(out _observerHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create obsever handle");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Destructor of the Resource class.
        /// </summary>
        ~Resource()
        {
            Dispose(false);
        }

        /// <summary>
        /// Type details of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Type details of the resource.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourceTypes Types { get; internal set; }

        /// <summary>
        /// Interface details of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Interface details of the resource.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourceInterfaces Interfaces { get; internal set; }

        /// <summary>
        /// The policies of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The policies of the resource.</value>
        [Obsolete("Deprecated since API level 13")]
        public ResourcePolicy Policy { get; internal set; }

        /// <summary>
        /// URI path of the resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>URI path of the resource.</value>
        [Obsolete("Deprecated since API level 13")]
        public string UriPath { get; internal set; }

        /// <summary>
        /// List of Child resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>List of Child resources.</value>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<Resource> Children
        {
            get
            {
                return _children;
            }
        }

        [Obsolete("Deprecated since API level 13")]
        internal IntPtr ResourceHandle
        {
            get
            {
                return _resourceHandle;
            }
            set
            {
                _resourceHandle = value;
            }
        }

        /// <summary>
        /// Notify the specified representation and qos.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <privilege>http://tizen.org/privilege/internet</privilege>
        /// <privlevel>public</privlevel>
        /// <param name="representation">Representation.</param>
        /// <param name="qos">The quality of service for message transfer.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <pre>
        /// IoTConnectivityServerManager.Initialize() should be called to initialize.
        /// </pre>
        /// <seealso cref="Representation"/>
        /// <seealso cref="QualityOfService"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when an application does not have privilege to access.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code><![CDATA[
        /// ResourceInterfaces ifaces = new ResourceInterfaces(new List<string>(){ ResourceInterfaces.DefaultInterface });
        /// ResourceTypes types = new ResourceTypes(new List<string>(){ "oic.iot.door.new.notify" });
        /// Resource resource = new DoorResource("/door/uri/new/notify", types, ifaces, ResourcePolicy.Discoverable | ResourcePolicy.Observable);
        /// IoTConnectivityServerManager.RegisterResource(resource);
        ///
        /// Representation repr = new Representation();
        /// repr.UriPath = "/door/uri/new/notify";
        /// repr.Type = new ResourceTypes(new List<string>(){ "oic.iot.door.new.notify" });
        /// repr.Attributes = new Attributes() {
        ///      _attribute, 1 }
        /// };
        /// resource.Notify(repr, QualityOfService.High);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Notify(Representation representation, QualityOfService qos)
        {
            int ret = (int)IoTConnectivityError.None;
            ret = Interop.IoTConnectivity.Server.Resource.Notify(_resourceHandle, representation._representationHandle, _observerHandle, (int)qos);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send notification");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// This is called when the client performs get operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response having the representation and the result.</returns>
        protected abstract Response OnGet(Request request);

        /// <summary>
        /// This is called when the client performs put operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response.</returns>
        protected abstract Response OnPut(Request request);

        /// <summary>
        /// This is called when the client performs post operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response having the representation and the result.</returns>
        protected abstract Response OnPost(Request request);

        /// <summary>
        /// This is called when the client performs delete operation on this resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <returns>A response.</returns>
        protected abstract Response OnDelete(Request request);

        /// <summary>
        /// Called on the observing event.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="request">A request from client.</param>
        /// <param name="type">Observer type.</param>
        /// <param name="observeId">Observe identifier.</param>
        /// <returns>Returns true if it wants to be observed, else false.</returns>
        protected abstract bool OnObserving(Request request, ObserveType type, int observeId);

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

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                Types?.Dispose();
                Interfaces?.Dispose();
            }

            if (_resourceHandle != IntPtr.Zero)
                Interop.IoTConnectivity.Server.Resource.Destroy(_resourceHandle);
            if (_observerHandle != IntPtr.Zero)
                Interop.IoTConnectivity.Server.Observers.Destroy(_observerHandle);
            _disposed = true;
        }

        // This method is used as callback for Resource
        internal void OnRequest(IntPtr resourceHandle, IntPtr requestHandle, IntPtr userData)
        {
            Request request = GetRequest(requestHandle);
            Response response = null;

            if (request == null)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get Request");
                return;
            }

            try
            {
                int observeType;
                int ret = Interop.IoTConnectivity.Server.Request.GetObserveType(requestHandle, out observeType);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get observe type");
                    return;
                }
                if ((ObserveType)observeType != ObserveType.NoType)
                {
                    int observeId;
                    ret = Interop.IoTConnectivity.Server.Request.GetObserveId(requestHandle, out observeId);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get observe id");
                        return;
                    }
                    switch ((ObserveType)observeType)
                    {
                        case ObserveType.Register:
                        {
                            if (OnObserving(request, ObserveType.Register, observeId))
                            {
                                ret = Interop.IoTConnectivity.Server.Observers.Add(_observerHandle, observeId);
                                if (ret != (int)IoTConnectivityError.None)
                                {
                                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add observer id");
                                    return;
                                }
                                break;
                            }
                            else
                            {
                                // If OnObserving for ObserveType.Register returns false, do not operate for Get operation after Observe operation.
                                return;
                            }
                        }
                        case ObserveType.Deregister:
                        {
                            if (OnObserving(request, ObserveType.Deregister, observeId))
                            {
                                ret = Interop.IoTConnectivity.Server.Observers.Remove(_observerHandle, observeId);
                                if (ret != (int)IoTConnectivityError.None)
                                {
                                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove observer id");
                                    return;
                                }
                                break;
                            }
                            else
                            {
                                // If OnObserving for ObserveType.Deregister returns false, do not operate for Get operation after Observe operation.
                                return;
                            }
                        }
                    }
                }
                int requestType;
                ret = Interop.IoTConnectivity.Server.Request.GetRequestType(requestHandle, out requestType);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get request type");
                    return;
                }
                switch ((Interop.IoTConnectivity.Server.RequestType)requestType)
                {
                    case Interop.IoTConnectivity.Server.RequestType.Put:
                    {
                        response = OnPut(request);
                        break;
                    }
                    case Interop.IoTConnectivity.Server.RequestType.Get:
                    {
                        response = OnGet(request);
                        break;
                    }
                    case Interop.IoTConnectivity.Server.RequestType.Post:
                    {
                        response = OnPost(request);
                        break;
                    }
                    case Interop.IoTConnectivity.Server.RequestType.Delete:
                    {
                        response = OnDelete(request);
                        break;
                    }
                    default:
                    	break;
                }
                if (response == null)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send Response");
                    return;
                }

                if (!response.Send(requestHandle))
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to send Response");
                    return;
                }
            }
            finally
            {
                request?.Dispose();
                response?.Dispose();
            }
        }

        private Request GetRequest(IntPtr requestHandle)
        {
            IntPtr hostAddressPtr;
            int ret = Interop.IoTConnectivity.Server.Request.GetHostAddress(requestHandle, out hostAddressPtr);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get host address");
                return null;
            }

            IntPtr optionsHandle = IntPtr.Zero;
            ret = Interop.IoTConnectivity.Server.Request.GetOptions(requestHandle, out optionsHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get options");
                return null;
            }

            IntPtr queryHandle = IntPtr.Zero;
            ret = Interop.IoTConnectivity.Server.Request.GetQuery(requestHandle, out queryHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get Query");
                return null;
            }

            IntPtr representationHandle = IntPtr.Zero;
            ret = Interop.IoTConnectivity.Server.Request.GetRepresentation(requestHandle, out representationHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get representation");
                return null;
            }

            ResourceOptions opts = null;
            ResourceQuery query = null;
            Representation representation = null;
            try
            {
                opts = (optionsHandle == IntPtr.Zero) ? null : new ResourceOptions(optionsHandle);
            }
            catch (Exception exp)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new ResourceOptions: " + exp.Message);
                return null;
            }

            try
            {
                query = (queryHandle == IntPtr.Zero) ? null : new ResourceQuery(queryHandle);
            }
            catch (Exception exp)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new ResourceQuery: " + exp.Message);
                opts?.Dispose();
                return null;
            }

            try
            {
                representation = (representationHandle == IntPtr.Zero) ? null : new Representation(representationHandle);
            }
            catch (Exception exp)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new Representation: " + exp.Message);
                opts?.Dispose();
                query?.Dispose();
                return null;
            }

            return new Request()
            {
                HostAddress = (hostAddressPtr != IntPtr.Zero) ? Marshal.PtrToStringAnsi(hostAddressPtr) : string.Empty,
                Options = opts,
                Query = query,
                Representation = representation
            };
        }

        private void ChildrenCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs eventArgs)
        {
            if (eventArgs.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Resource r in eventArgs.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Server.Resource.BindChildResource(_resourceHandle, r._resourceHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to bind resource ");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (eventArgs.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Resource r in eventArgs.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Server.Resource.UnbindChildResource(_resourceHandle, r._resourceHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to unbind resource");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }
    }
}
