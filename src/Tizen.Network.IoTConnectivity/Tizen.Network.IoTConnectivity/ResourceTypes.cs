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
    /// Class containing resource types
    /// </summary>
    public class ResourceTypes : IEnumerable<string>, IDisposable
    {
        internal const int MaxLength = 61;
        internal IntPtr _resourceTypeHandle = IntPtr.Zero;
        private readonly HashSet<string> _resourceTypes = new HashSet<string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypes()
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Create(out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public ResourceTypes(IEnumerable<string> types)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Create(out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            foreach (string type in types)
            {
                Add(type);
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        internal ResourceTypes(IntPtr typesHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Clone(typesHandleToClone, out _resourceTypeHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            Interop.IoTConnectivity.Common.ResourceTypes.ForeachCallback cb = (string type, IntPtr data) =>
            {
                _resourceTypes.Add(type);
                return true;
            };

            ret = Interop.IoTConnectivity.Common.ResourceTypes.Foreach(typesHandleToClone, cb, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        ~ResourceTypes()
        {
            Dispose(false);
        }

        /// <summary>
        /// Count of resource types in the list
        /// </summary>
        public int Count
        {
            get
            {
                return _resourceTypes.Count;
            }
        }

        /// <summary>
        ///  Inserts a resource type into the list.
        /// </summary>
        /// <param name="item">The resource type to add</param>
        public void Add(string item)
        {
            if (IsValid(item))
            {
                int ret = Interop.IoTConnectivity.Common.ResourceTypes.Add(_resourceTypeHandle, item);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                _resourceTypes.Add(item);
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid type");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
        }

        /// <summary>
        ///  Removes a resource type from the list
        /// </summary>
        /// <param name="item">The resource type to remove</param>
        public void Remove(string item)
        {
            int ret = Interop.IoTConnectivity.Common.ResourceTypes.Remove(_resourceTypeHandle, item);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            _resourceTypes.Remove(item);
        }

        /// <summary>
        ///  Return enumerator for the list of types
        /// </summary>
        /// <returns>Enumerator of the collection</returns>
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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

            Interop.IoTConnectivity.Common.ResourceTypes.Destroy(_resourceTypeHandle);
            _disposed = true;
        }
    }
}
