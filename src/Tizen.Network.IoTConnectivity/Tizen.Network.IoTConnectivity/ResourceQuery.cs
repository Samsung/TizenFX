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
using System.Runtime.InteropServices;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class provides APIs to manage the query of request.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class ResourceQuery : IDictionary<string, string>, IDisposable
    {
        internal const int QueryMaxLenth = 64;
        internal IntPtr _resourceQueryHandle = IntPtr.Zero;
        private readonly IDictionary<string, string> _query = new Dictionary<string, string>();
        private bool _disposed = false;

        /// <summary>
        /// The resource query constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string, string)"/>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ResourceQuery()
        {
            int ret = Interop.IoTConnectivity.Common.Query.Create(out _resourceQueryHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        internal ResourceQuery(IntPtr resourceQueryHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.Query.Create(out _resourceQueryHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            Interop.IoTConnectivity.Common.Query.QueryCallback forEachCallback = (string key, string value, IntPtr userData) =>
            {
                Add(key, value);
                return true;
            };

            ret = Interop.IoTConnectivity.Common.Query.Foreach(resourceQueryHandleToClone, forEachCallback, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to iterate query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Destructor of the ResourceQuery class.
        /// </summary>
        ~ResourceQuery()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets and sets the resource type of the query.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The resource type of the query.</value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Type = "org.tizen.light";
        /// Console.WriteLine("Type of query : {0}", query.Type);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public string Type
        {
            get
            {
                IntPtr type;
                int ret = Interop.IoTConnectivity.Common.Query.GetResourceType(_resourceQueryHandle, out type);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    return "";
                }
                return (type != IntPtr.Zero) ? Marshal.PtrToStringAnsi(type) : string.Empty;
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (ResourceTypes.IsValid(value))
                    ret = Interop.IoTConnectivity.Common.Query.SetResourceType(_resourceQueryHandle, value);

                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Gets and sets the resource interface of the query.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>
        /// The resource interface of the query.
        /// Setter value could be a value, such as <see cref="ResourceInterfaces.DefaultInterface"/>.
        /// </value>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Interface = ResourceInterfaces.LinkInterface;
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public string Interface
        {
            get
            {
                IntPtr iface;
                int ret = Interop.IoTConnectivity.Common.Query.GetInterface(_resourceQueryHandle, out iface);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get interface");
                    return "";
                }
                return (iface != IntPtr.Zero) ? Marshal.PtrToStringAnsi(iface) : string.Empty;
            }
            set
            {
                int ret = (int)IoTConnectivityError.InvalidParameter;
                if (ResourceInterfaces.IsValid(value))
                    ret = Interop.IoTConnectivity.Common.Query.SetInterface(_resourceQueryHandle, value);

                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to set interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
        }

        /// <summary>
        /// Contains all the query keys.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the query keys.</value>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var keys = query.Keys;
        /// Console.WriteLine("Resource query contains keys {0} and {1}", keys.ElementAt(0), keys.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<string> Keys
        {
            get
            {
                return _query.Keys;
            }
        }

        /// <summary>
        /// Contains all the query values.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the query values.</value>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var values = query.Values;
        /// Console.WriteLine("Resource query contains values {0} and {1}", values.ElementAt(0), values.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<string> Values
        {
            get
            {
                return _query.Values;
            }
        }

        /// <summary>
        /// Gets the number of query elements.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of query elements.</value>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var count = query.Count;
        /// Console.WriteLine("There are {0} keys in the query object", count);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public int Count
        {
            get
            {
                return _query.Count;
            }
        }

        /// <summary>
        /// Represents whether the collection is readonly.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Whether the collection is readonly.</value>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// if (query.IsReadOnly)
        ///     Console.WriteLine("Read only query");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool IsReadOnly
        {
            get
            {
                return _query.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the query data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The query data.</value>
        /// <param name="key">The query key to get or set.</param>
        /// <returns>The query with the specified key.</returns>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query["key1"] = "sample-data";
        /// Console.WriteLine("query has : {0}", query["key1"]);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public string this[string key]
        {
            get
            {
                return _query[key];
            }

            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Checks whether the given key exists in the query collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The key to look for.</param>
        /// <returns>true if exists. Otherwise, false.</returns>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// if (query.ContainsKey("key1"))
        ///     Console.WriteLine("query conatins key : key1");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool ContainsKey(string key)
        {
            return _query.ContainsKey(key);
        }

        /// <summary>
        /// Adds a new key and correspoding value into the query.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// The full length of query should be less than or equal to 64.
        /// </remarks>
        /// <param name="key">The key of the query to insert.</param>
        /// <param name="value">The string data to insert into the query.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Add(string key, string value)
        {
            if (CanAddQuery(key, value))
            {
                int ret = Interop.IoTConnectivity.Common.Query.Add(_resourceQueryHandle, key, value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add query");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                _query.Add(key, value);
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Query cannot be added");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
        }

        /// <summary>
        /// Removes the key and its associated value from the query.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The ID of the query to delete.</param>
        /// <returns>True if operation is successful. Otherwise, false.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(string, string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// var result = query.Remove("key1");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(string key)
        {
            int ret = Interop.IoTConnectivity.Common.Query.Remove(_resourceQueryHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            bool isRemoved = _query.Remove(key);

            return isRemoved;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The query key.</param>
        /// <param name="value">Value corresponding to query key.</param>
        /// <returns>True if the key exists, false otherwise.</returns>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// string value;
        /// var isPresent = query.TryGetValue("key1", out value);
        /// if (isPresent)
        ///     Console.WriteLine("value : {0}", value);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool TryGetValue(string key, out string value)
        {
            return _query.TryGetValue(key, out value);
        }

        /// <summary>
        /// Adds a query key and a value as a key value pair.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(KeyValuePair{string, string})"/>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the query collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid.</exception>
        /// <example><code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// query.Add("key2", "value2");
        /// query.Clear();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Clear()
        {
            foreach (string key in _query.Keys)
            {
                int ret = Interop.IoTConnectivity.Common.Query.Remove(_resourceQueryHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to clear query");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            _query.Clear();
        }

        /// <summary>
        /// Checks if the given query pair exists.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair.</param>
        /// <returns>True if exists. Otherwise, false.</returns>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// var isPresent = query.Contains(new KeyValuePair<string, string>("key1", "value1"));
        /// if (isPresent)
        ///     Console.WriteLine("Key value pair is present");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Contains(KeyValuePair<string, string> item)
        {
            return _query.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the query collection to an array, starting at a particular index.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">Index parameter.</param>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// KeyValuePair<string, string>[] dest = new KeyValuePair<string, string>[query.Count];
        /// query.CopyTo(dest, 0);
        /// Console.WriteLine("Dest conatins ({0}, {1})", dest[0].Key, dest[0].Value);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            _query.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the given key value pair from the query.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair to remove.</param>
        /// <returns>True if operation is successful. Otherwise, false.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(KeyValuePair{string, string})"/>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// var result = query.Remove(new KeyValuePair<string, string>("key1", "value1"));
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(KeyValuePair<string, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Gets the enumerator to the query collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Enumerator to query pairs.</returns>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// query.Add(new KeyValuePair<string, string>("key2", "value2"));
        /// foreach (KeyValuePair<string, string> pair in query)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        /// <summary>
        /// Gets the enumerator to the query collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>The enumerator to the query pairs.</returns>
        /// <example><code><![CDATA[
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// query.Add(new KeyValuePair<string, string>("key2", "value2"));
        /// foreach (KeyValuePair<string, string> pair in query)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _query.GetEnumerator();
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

            Interop.IoTConnectivity.Common.Query.Destroy(_resourceQueryHandle);
            _disposed = true;
        }

        private bool CanAddQuery(string newKey, string newValue)
        {
            int queryLenth = 0;
            foreach (string key in Keys)
            {
                queryLenth += key.Length + 2;
            }
            foreach (string value in Values)
            {
                queryLenth += value.Length;
            }

            if ((newKey.Length + newValue.Length + queryLenth + 2) < QueryMaxLenth)
                return true;

            return false;
        }
    }
}
