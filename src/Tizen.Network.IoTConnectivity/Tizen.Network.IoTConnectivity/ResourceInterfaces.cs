/// Copyright 2016 by Samsung Electronics, Inc.,
///
/// This software is the confidential and proprietary information
/// of Samsung Electronics, Inc. ("Confidential Information"). You
/// shall not disclose such Confidential Information and shall use
/// it only in accordance with the terms of the license agreement
/// you entered into with Samsung.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Class containing resource interfaces
    /// </summary>
    public class ResourceInterfaces : IEnumerable<string>, IDisposable
    {
        /// <summary>
        /// Default Interface
        /// </summary>
        public const string DefaultInterface = "oic.if.baseline";

        /// <summary>
        /// List Links Interface which is used to list the references to other resources  contained in a resource.
        /// </summary>
        public const string LinkInterface = "oic.if.ll";

        /// <summary>
        /// Batch Interface which is used to manipulate (GET, PUT, POST, DELETE) on other resource contained in a resource.
        /// </summary>
        public const string BatchInterface = "oic.if.b";

        /// <summary>
        /// Group Interface which is used to manipulate (GET, PUT, POST) a group of remote resources.
        /// </summary>
        public const string GroupInterface = "oic.mi.grp";

        /// <summary>
        /// Read-Only Interface which is used to limit the methods that can be applied to a resource to GET only.
        /// </summary>
        public const string ReadonlyInterface = "oic.if.r";

        private readonly IntPtr _resourceInterfacesHandle = IntPtr.Zero;
        private const int MaxLength = 61;
        private readonly HashSet<string> _resourceInterfaces = new HashSet<string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceInterfaces()
        {
            int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Create(out _resourceInterfacesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create interface");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="ifaces">List of resource interfaces</param>
        public ResourceInterfaces(IEnumerable<string> ifaces)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Create(out _resourceInterfacesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create interface");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            foreach (string iface in ifaces)
            {
                Add(iface);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal ResourceInterfaces(IntPtr ifacesHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Clone(ifacesHandleToClone, out _resourceInterfacesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create interface");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            Interop.IoTConnectivity.Common.ResourceInterfaces.ForeachCallback cb = (string iface, IntPtr data) =>
            {
                _resourceInterfaces.Add(iface);
                return true;
            };

            ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Foreach(ifacesHandleToClone, cb, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        ~ResourceInterfaces()
        {
            Dispose(false);
        }

        internal IntPtr ResourceInterfacesHandle
        {
            get
            {
                return _resourceInterfacesHandle;
            }
        }

        /// <summary>
        /// Count of interfaces in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _resourceInterfaces.Count;
            }
        }

        /// <summary>
        /// Adds a resource interface into the list.
        /// </summary>
        /// <param name="item"> Resource interface</param>
        public void Add(string item)
        {
            if (IsValid(item))
            {
                int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Add(_resourceInterfacesHandle, item);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                _resourceInterfaces.Add(item);
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid interface");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
        }

        /// <summary>
        /// Removes a resource interface from the list
        /// </summary>
        /// <param name="item">Resource interface</param>
        public void Remove(string item)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Remove(_resourceInterfacesHandle, item);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add interface");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            _resourceInterfaces.Remove(item);
        }

        /// <summary>
        /// Return enumerator for the list of interfaces
        /// </summary>
        /// <returns>The enumerator</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        internal static bool IsValid(string type)
        {
            Regex r = new Regex("^[a-zA-Z0-9.-]+$");
            return (type.Length <= MaxLength && char.IsLower(type[0]) && r.IsMatch(type));
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.IoTConnectivity.Common.ResourceInterfaces.Destroy(_resourceInterfacesHandle);
            _disposed = true;
        }
    }
}
