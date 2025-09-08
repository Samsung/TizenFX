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
    /// This class contains resource types and provides APIs to manage, add, or remove those types.
    /// A resource type indicates a class or a category of resources.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class ResourceTypes : IEnumerable<string>, IDisposable
    {
        internal const int MaxLength = 61;
        internal IntPtr _resourceTypeHandle = IntPtr.Zero;
        private readonly HashSet<string> _resourceTypes = new HashSet<string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor of ResourceTypes.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string)"/>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code>
        /// ResourceTypes types = new ResourceTypes();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Constructor of ResourceTypes using list of types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="types">List of resource types.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code><![CDATA[
        /// ResourceTypes types = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
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

        /// <summary>
        /// Destructor of the ResourceTypes class.
        /// </summary>
        ~ResourceTypes()
        {
            Dispose(false);
        }

        /// <summary>
        /// Indicates count of types in the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Count of types in the list.</value>
        /// <example><code><![CDATA[
        /// ResourceTypes types = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// Console.WriteLine("There are {0} items", types.Count);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public int Count
        {
            get
            {
                return _resourceTypes.Count;
            }
        }

        /// <summary>
        /// Adds a resource type into the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>The length of <paramref name="item" /> should be less than or equal to 61.</para>
        /// <para>The <paramref name="item" /> must start with a lowercase alphabetic character, followed by a sequence
        /// of lowercase alphabetic, numeric, ".", or "-" characters, and contains no white space.</para>
        /// <para>Duplicate strings are not allowed.</para>
        /// </remarks>
        /// <param name="item">The string data to insert into the resource types.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceTypes resourceTypes = new ResourceTypes();
        /// resourceTypes.Add("org.tizen.light");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Removes a resource type from the list.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The string data to delete from the resource types.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code><![CDATA[
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// resourceTypes.Remove("oic.if.room");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Returns an enumerator for the list of types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The enumerator.</returns>
        /// <example><code><![CDATA[
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// foreach(string item in resourceTypes)
        /// {
        ///     Console.WriteLine("Type : {0}", item);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public IEnumerator<string> GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator for the list of types.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The enumerator.</returns>
        /// <example><code><![CDATA[
        /// ResourceTypes resourceTypes = new ResourceTypes(new List<string>() { "org.tizen.light", "oic.if.room" });
        /// foreach(string item in resourceTypes)
        /// {
        ///     Console.WriteLine("Type : {0}", item);
        /// }
        /// ]]></code></example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _resourceTypes.GetEnumerator();
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

            Interop.IoTConnectivity.Common.ResourceTypes.Destroy(_resourceTypeHandle);
            _disposed = true;
        }
    }
}
