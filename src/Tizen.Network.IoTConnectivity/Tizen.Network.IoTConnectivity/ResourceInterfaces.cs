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
using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class contains resource interfaces and provides APIs to manage, add, remove those interfaces.
    /// A resource interface indicates a class or category of resources.
    /// </summary>
    public class ResourceInterfaces : IEnumerable<string>, IDisposable
    {
        /// <summary>
        /// Default Interface
        /// </summary>
        public const string DefaultInterface = "oic.if.baseline";

        /// <summary>
        /// List Links Interface which is used to list the references to other resources contained in a resource.
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
        /// Constructor of ResourceInterfaces
        /// </summary>
        /// <seealso cref="Add()"/>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces();
        /// </code>
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
        /// Constructor of ResourceInterfaces using list of interfaces
        /// </summary>
        /// <param name="ifaces">List of resource interfaces</param>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// </code>
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

        /// <summary>
        /// Destructor of the ResourceInterfaces class.
        /// </summary>
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
        /// Indicates count of interfaces in the list
        /// </summary>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// Console.WriteLine("There are {0} interfaces", resourceInterfaces.Count);
        /// </code>
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
        /// <remarks>
        /// @a item could be a value such as <see cref="DefaultInterface"/>
        /// </remarks>
        /// <param name="item">The string data to insert into the resource interfaces</param>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces();
        /// resourceInterfaces.Add(ResourceInterfaces.BatchInterface);
        /// </code>
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
        /// <param name="item">The string data to delete from the resource ifaces</param>
        /// <seealso cref="Add()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>(){ ResourceInterfaces.BatchInterface });
        /// resourceInterfaces.Add(ResourceInterfaces.BatchInterface);
        /// </code>
        public void Remove(string item)
        {
            bool isRemoved = _resourceInterfaces.Remove(item);
            if (isRemoved)
            {
                int ret = Interop.IoTConnectivity.Common.ResourceInterfaces.Remove(_resourceInterfacesHandle, item);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
        }

        /// <summary>
        /// Return enumerator for the list of interfaces
        /// </summary>
        /// <returns>The enumerator</returns>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// foreach(string item in resourceInterfaces)
        /// {
        ///     Console.WriteLine("Interface : {0}", item);
        /// }
        /// </code>
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        /// <summary>
        /// Return enumerator for the list of interfaces
        /// </summary>
        /// <returns>The enumerator</returns>
        /// <code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// foreach(string item in resourceInterfaces)
        /// {
        ///     Console.WriteLine("Interface : {0}", item);
        /// }
        /// </code>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
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

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
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
