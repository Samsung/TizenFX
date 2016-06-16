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
    /// Class containing representation of a resource
    /// </summary>
    public class Representation : IDisposable
    {
        internal IntPtr _representationHandle = IntPtr.Zero;

        private bool _disposed = false;
        private ObservableCollection<Representation> _children = new ObservableCollection<Representation>();

        /// <summary>
        /// Constructor
        /// </summary>
        public Representation()
        {
            int ret = Interop.IoTConnectivity.Common.Representation.Create(out _representationHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create representation");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _children.CollectionChanged += ChildrenCollectionChanged;
        }

        // Constructor for cloning native representation object
        internal Representation(IntPtr handleToClone)
        {
            int ret = (int)IoTConnectivityError.InvalidParameter;
            if (handleToClone != IntPtr.Zero)
            {
                ret = Interop.IoTConnectivity.Common.Representation.Clone(handleToClone, out _representationHandle);
            }
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create representation");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _children.CollectionChanged += ChildrenCollectionChanged;
        }

        ~Representation()
        {
            Dispose(false);
        }

        /// <summary>
        /// The URI of resource
        /// </summary>
        public string UriPath
        {
            get
            {
                IntPtr path;
                int ret = Interop.IoTConnectivity.Common.Representation.GetUriPath(_representationHandle, out path);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Get uri");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return Marshal.PtrToStringAuto(path);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetUriPath(_representationHandle, value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set uri");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// The type of resource
        /// </summary>
        public ResourceTypes Type
        {
            get
            {
                IntPtr typeHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetResourceTypes(_representationHandle, out typeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return new ResourceTypes(typeHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetResourceTypes(_representationHandle, value._resourceTypeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// The interface of the resource
        /// </summary>
        public ResourceInterfaces Interface
        {
            get
            {
                IntPtr interfaceHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetResourceInterfaces(_representationHandle, out interfaceHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return new ResourceInterfaces(interfaceHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                    ret = Interop.IoTConnectivity.Common.Representation.SetResourceInterfaces(_representationHandle, value.ResourceInterfacesHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Current attributes of the resource
        /// </summary>
        public Attributes Attributes
        {
            get
            {
                IntPtr attributeHandle;
                int ret = Interop.IoTConnectivity.Common.Representation.GetAttributes(_representationHandle, out attributeHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return new Attributes(attributeHandle);
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (value != null)
                {
                    ret = Interop.IoTConnectivity.Common.Representation.SetAttributes(_representationHandle, value._resourceAttributesHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set attributes");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }

        /// <summary>
        /// List of Child resource representation
        /// </summary>
        public ICollection<Representation> Children
        {
            get
            {
                return _children;
            }
        }

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
                // Free managed objects
                Type?.Dispose();
                Interface?.Dispose();
                Attributes?.Dispose();
            }

            Interop.IoTConnectivity.Common.Representation.Destroy(_representationHandle);
            _disposed = true;
        }

        private void ChildrenCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Representation r in e.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Common.Representation.AddChild(_representationHandle, r._representationHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add child");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Representation r in e.NewItems)
                {
                    int ret = Interop.IoTConnectivity.Common.Representation.RemoveChild(_representationHandle, r._representationHandle);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove child");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
        }
    }
}
