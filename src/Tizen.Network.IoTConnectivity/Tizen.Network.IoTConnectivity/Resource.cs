/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Abstract class respresenting a resource.
    /// </summary>
    public abstract class Resource : IDisposable
    {
        private IntPtr _resourceHandle = IntPtr.Zero;
        private bool _disposed = false;
        private ObservableCollection<Resource> _children = new ObservableCollection<Resource>();
        private IntPtr _observerHandle = IntPtr.Zero;

        /// <summary>
        /// The constructor
        /// </summary>
        /// <param name="uri">URI of the resource</param>
        /// <param name="types">Resource types</param>
        /// <param name="interfaces">Resource interfaces</param>
        /// <param name="policy">Policy input of the resoruce</param>
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

        ~Resource()
        {
            Dispose(false);
        }

        /// <summary>
        /// Type details of the resource
        /// </summary>
        public ResourceTypes Types { get; internal set; }

        /// <summary>
        /// Interface details of the resource
        /// </summary>
        public ResourceInterfaces Interfaces { get; internal set; }

        /// <summary>
        /// The policy
        /// </summary>
        public ResourcePolicy Policy { get; internal set; }

        /// <summary>
        /// URI of the resource
        /// </summary>
        public string UriPath { get; internal set; }

        /// <summary>
        /// List of Child resources
        /// </summary>
        public ICollection<Resource> Children
        {
            get
            {
                return _children;
            }
        }

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
        /// <param name="representation">Representation.</param>
        /// <param name="qos">Qos.</param>
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
        /// Called on the get event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected abstract Response OnGet(Request request);

        /// <summary>
        /// Called on the put event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected abstract Response OnPut(Request request);

        /// <summary>
        /// Called on the post event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected abstract Response OnPost(Request request);

        /// <summary>
        /// Called on the delete event.
        /// </summary>
        /// <param name="request">Request.</param>
        protected abstract Response OnDelete(Request request);

        /// <summary>
        /// Called on the observing event.
        /// </summary>
        /// <param name="request">Request.</param>
        /// <param name="policy">Policy.</param>
        /// <param name="observeId">Observe identifier.</param>
        protected abstract bool OnObserving(Request request, ObserveType type, int observeId);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

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
                return null;
            }

            try
            {
                representation = (representationHandle == IntPtr.Zero) ? null : new Representation(representationHandle); ;
            }
            catch (Exception exp)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to new Representation: " + exp.Message);
                return null;
            }

            return new Request()
            {
                HostAddress = Marshal.PtrToStringAuto(hostAddressPtr),
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
