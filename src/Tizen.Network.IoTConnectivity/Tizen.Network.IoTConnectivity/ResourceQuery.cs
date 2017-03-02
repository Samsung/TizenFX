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
    /// This class provides APIs to manage query of request.
    /// </summary>
    public class ResourceQuery : IDictionary<string, string>, IDisposable
    {
        internal const int QueryMaxLenth = 64;
        internal IntPtr _resourceQueryHandle = IntPtr.Zero;
        private readonly IDictionary<string, string> _query = new Dictionary<string, string>();
        private bool _disposed = false;

        /// <summary>
        /// The resource query constructor
        /// </summary>
        /// <seealso cref="Add()"/>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// </code>
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
        /// Gets and sets the resource type of the query
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Type = "org.tizen.light";
        /// Console.WriteLine("Type of query : {0}", query.Type);
        /// </code>
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
                return Marshal.PtrToStringAnsi(type);
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
        /// Gets and sets the resource interface of the query
        /// </summary>
        /// <remarks>
        /// Setter value could be a value such as <see cref="ResourceInterfaces.DefaultInterface"/>
        /// </remarks>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Interface = ResourceInterfaces.LinkInterface;
        /// </code>
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
                return Marshal.PtrToStringAnsi(iface);
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
        /// Contains all the query keys
        /// </summary>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var keys = query.Keys;
        /// Console.WriteLine("Resource query contains keys {0} and {1}", keys.ElementAt(0), keys.ElementAt(1));
        /// </code>
        public ICollection<string> Keys
        {
            get
            {
                return _query.Keys;
            }
        }

        /// <summary>
        /// Contains all the query values
        /// </summary>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var values = query.Values;
        /// Console.WriteLine("Resource query contains values {0} and {1}", values.ElementAt(0), values.ElementAt(1));
        /// </code>
        public ICollection<string> Values
        {
            get
            {
                return _query.Values;
            }
        }

        /// <summary>
        /// Gets the number of query elements
        /// </summary>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key", "value");
        /// query.Add("newKey", "sample value");
        /// var count = query.Count;
        /// Console.WriteLine("There are {0} keys in the query object", count);
        /// </code>
        public int Count
        {
            get
            {
                return _query.Count;
            }
        }

        /// <summary>
        /// Represents whether the collection is readonly
        /// </summary>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// if (query.IsReadOnly)
        ///     Console.WriteLine("Read only query");
        /// </code>
        public bool IsReadOnly
        {
            get
            {
                return _query.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the query data
        /// </summary>
        /// <param name="key">The query key to get or set.</param>
        /// <returns>The query with the specified key.</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query["key1"] = "sample-data";
        /// Console.WriteLine("query has : {0}", query["key1"]);
        /// </code>
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
        /// Checks whether the given key exists in Query collection
        /// </summary>
        /// <param name="key">The key to look for</param>
        /// <returns>true if exists. Otherwise, false</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// if (query.ContainsKey("key1"))
        ///     Console.WriteLine("query conatins key : key1");
        /// </code>
        public bool ContainsKey(string key)
        {
            return _query.ContainsKey(key);
        }

        /// <summary>
        /// Adds a new key and correspoding value into the query.
        /// </summary>
        /// <remarks>
        /// The full length of query should be less than or equal to 64.
        /// </remarks>
        /// <param name="key">The key of the query to insert</param>
        /// <param name="value">The string data to insert into the query</param>
        /// <seealso cref="Remove()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// </code>
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
        /// <param name="key">The id of the query to delete</param>
        /// <returns>True if operation is successful. Otherwise, false</returns>
        /// <seealso cref="Add()"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// var result = query.Remove("key1");
        /// </code>
        public bool Remove(string key)
        {
            bool isRemoved = _query.Remove(key);
            if (isRemoved)
            {
                int ret = Interop.IoTConnectivity.Common.Query.Remove(_resourceQueryHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove query");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            return isRemoved;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The query key</param>
        /// <param name="value">Value corresponding to query key</param>
        /// <returns>True if the key exists, false otherwise</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// string value;
        /// var isPresent = query.TryGetValue("key1", out value);
        /// if (isPresent)
        ///     Console.WriteLine("value : {0}", value);
        /// </code>
        public bool TryGetValue(string key, out string value)
        {
            return _query.TryGetValue(key, out value);
        }

        /// <summary>
        ///  Adds query key and value as a key value pair
        /// </summary>
        /// <param name="item">The key value pair</param>
        /// <seealso cref="Remove()"/>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// </code>
        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the Query collection
        /// </summary>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add("key1", "value1");
        /// query.Add("key2", "value2");
        /// query.Clear();
        /// </code>
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
        /// Checks if the given query pair exists
        /// </summary>
        /// <param name="item">The key value pair</param>
        /// <returns>True if exists. Otherwise, false</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// var isPresent = query.Contains(new KeyValuePair<string, string>("key1", "value1"));
        /// if (isPresent)
        ///     Console.WriteLine("Key value pair is present");
        /// </code>
        public bool Contains(KeyValuePair<string, string> item)
        {
            return _query.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the query collection to an Array, starting at a particular index.
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">Index parameter</param>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// KeyValuePair<string, string>[] dest = new KeyValuePair<string, string>[query.Count];
        /// query.CopyTo(dest, 0);
        /// Console.WriteLine("Dest conatins ({0}, {1})", dest[0].Key, dest[0].Value);
        /// </code>
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            _query.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Remove the given key value pair from the query
        /// </summary>
        /// <param name="item">The key value pair to remove</param>
        /// <returns>True if operation is successful. Otherwise, false</returns>
        /// <seealso cref="Add()"/>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// var result = query.Remove(new KeyValuePair<string, string>("key1", "value1"));
        /// </code>
        public bool Remove(KeyValuePair<string, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Get the enumerator to query collection
        /// </summary>
        /// <returns>Enumerator to query pairs</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// query.Add(new KeyValuePair<string, string>("key2", "value2"));
        /// foreach (KeyValuePair<string, string> pair in query)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// </code>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        /// <summary>
        /// Get the enumerator to query collection
        /// </summary>
        /// <returns>Enumerator to query pairs</returns>
        /// <code>
        /// ResourceQuery query = new ResourceQuery();
        /// query.Add(new KeyValuePair<string, string>("key1", "value1"));
        /// query.Add(new KeyValuePair<string, string>("key2", "value2"));
        /// foreach (KeyValuePair<string, string> pair in query)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// </code>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
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
