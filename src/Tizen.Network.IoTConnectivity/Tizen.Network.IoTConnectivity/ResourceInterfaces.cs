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
    /// This class contains resource interfaces and provides APIs to manage, add, or remove those interfaces.
    /// A resource interface indicates a class or category of resources.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class ResourceInterfaces : IEnumerable<string>, IDisposable
    {
        /// <summary>
        /// Default Interface.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string DefaultInterface = "oic.if.baseline";

        /// <summary>
        /// List Links Interface, which is used to list the references to other resources contained in a resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string LinkInterface = "oic.if.ll";

        /// <summary>
        /// Batch Interface, which is used to manipulate (GET, PUT, POST, DELETE) on other resource contained in a resource.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string BatchInterface = "oic.if.b";

        /// <summary>
        /// Group Interface, which is used to manipulate (GET, PUT, POST) a group of remote resources.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string GroupInterface = "oic.mi.grp";

        /// <summary>
        /// Read-Only Interface, which is used to limit the methods that can be applied to a resource to GET only.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public const string ReadonlyInterface = "oic.if.r";

        private readonly IntPtr _resourceInterfacesHandle = IntPtr.Zero;
        private const int MaxLength = 61;
        private readonly HashSet<string> _resourceInterfaces = new HashSet<string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor of ResourceInterfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string)"/>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Constructor of ResourceInterfaces using list of interfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="ifaces">List of resource interfaces.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code><![CDATA[
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// <since_tizen> 3 </since_tizen>
        /// <value>Count of interfaces in the list.</value>
        /// <example><code><![CDATA[
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// Console.WriteLine("There are {0} interfaces", resourceInterfaces.Count);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <paramref name="item" /> could be a value, such as <see cref="DefaultInterface"/>.
        /// </remarks>
        /// <param name="item">The string data to insert into the resource interfaces.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code>
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces();
        /// resourceInterfaces.Add(ResourceInterfaces.BatchInterface);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Removes a resource interface from the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The string data to delete from the resource ifaces.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code><![CDATA[
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>(){ ResourceInterfaces.BatchInterface });
        /// resourceInterfaces.Add(ResourceInterfaces.BatchInterface);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Returns enumerator for the list of interfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The enumerator.</returns>
        /// <example><code><![CDATA[
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// foreach(string item in resourceInterfaces)
        /// {
        ///     Console.WriteLine("Interface : {0}", item);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        /// <summary>
        /// Returns enumerator for the list of interfaces.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The enumerator.</returns>
        /// <example><code><![CDATA[
        /// ResourceInterfaces resourceInterfaces = new ResourceInterfaces(new List<string>()
        ///     { ResourceInterfaces.LinkInterface, ResourceInterfaces.ReadonlyInterface });
        /// foreach(string item in resourceInterfaces)
        /// {
        ///     Console.WriteLine("Interface : {0}", item);
        /// }
        /// ]]></code></example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceInterfaces.GetEnumerator();
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        [Obsolete("Deprecated since API level 13")]
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        internal static bool IsValid(string type)
        {
            Regex r = new Regex("^[a-zA-Z0-9.-]+$");
            return (type.Length <= MaxLength && type.Length > 0 && char.IsLower(type[0]) && r.IsMatch(type));
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
                // Free managed objects
            }

            Interop.IoTConnectivity.Common.ResourceInterfaces.Destroy(_resourceInterfacesHandle);
            _disposed = true;
        }
    }
}
