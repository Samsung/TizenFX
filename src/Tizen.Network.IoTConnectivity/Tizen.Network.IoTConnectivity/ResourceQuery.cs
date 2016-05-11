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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// Class to manage query of request
    /// </summary>
    public class ResourceQuery : IDictionary<string, string>, IDisposable
    {
        internal const int QueryMaxLenth = 64;
        internal IntPtr _resourceQueryHandle = IntPtr.Zero;
        private readonly IDictionary<string, string> _query = new Dictionary<string, string>();
        private bool _disposed = false;

        /// <summary>
        /// Constructor
        /// </summary>
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

        ~ResourceQuery()
        {
            Dispose(false);
        }

        /// <summary>
        /// Resource type of the query
        /// </summary>
        public string Type
        {
            get
            {
                string type;
                int ret = Interop.IoTConnectivity.Common.Query.GetResourceType(_resourceQueryHandle, out type);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return type;
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
        /// Resource interface of the query
        /// </summary>
        public string Interface
        {
            get
            {
                string iface;
                int ret = Interop.IoTConnectivity.Common.Query.GetInterface(_resourceQueryHandle, out iface);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get interface");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                return iface;
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
        /// Contains all keys of Query
        /// </summary>
        public ICollection<string> Keys
        {
            get
            {
                return _query.Keys;
            }
        }

        /// <summary>
        /// Contains all the values of Query
        /// </summary>
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
        public int Count
        {
            get
            {
                return _query.Count;
            }
        }

        /// <summary>
        /// Represents whether Query is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return _query.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the Query key..
        /// </summary>
        /// <param name="key">The key of the Query to get or set.</param>
        /// <returns>The element with the specified key.</returns>
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
        /// Checks the given key exists in Query
        /// </summary>
        /// <param name="key">The Query key</param>
        /// <returns>true if exists. Otherwise, false</returns>
        public bool ContainsKey(string key)
        {
            return _query.ContainsKey(key);
        }

        /// <summary>
        /// Adds Query element
        /// </summary>
        /// <param name="key">The key representing the Query</param>
        /// <param name="value">The value representing the Query</param>
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
        /// Removes a Query element from collection
        /// </summary>
        /// <param name="item">The Query element to remove</param>
        /// <returns>true if operation is success. Otherwise, false</returns>
        public bool Remove(string key)
        {
            int ret = Interop.IoTConnectivity.Common.Query.Remove(_resourceQueryHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            return _query.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value"> The value associated with the specified key</param>
        /// <returns> true if the Query contains an element with the specified key; otherwise, false.</returns>
        public bool TryGetValue(string key, out string value)
        {
            return _query.TryGetValue(key, out value);
        }

        /// <summary>
        /// Adds Query as a key value pair
        /// </summary>
        /// <param name="item">The key value pair</param>
        public void Add(KeyValuePair<string, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears Query
        /// </summary>
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
        /// Checks the given key value pair exists in Query
        /// </summary>
        /// <param name="item">The key value pair</param>
        /// <returns>true if exists. Otherwise, false</returns>
        public bool Contains(KeyValuePair<string, string> item)
        {
            return _query.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the Query to an Array, starting at a particular index.
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">The zero-based index in array at which copying begins.</param>
        public void CopyTo(KeyValuePair<string, string>[] array, int arrayIndex)
        {
            _query.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes a Query element from collection
        /// </summary>
        /// <param name="item">The Query element to remove</param>
        /// <returns>true if operation is success. Otherwise, false</returns>
        public bool Remove(KeyValuePair<string, string> item)
        {
            int ret = Interop.IoTConnectivity.Common.Query.Remove(_resourceQueryHandle, item.Key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove query");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            return _query.Remove(item);
        }

        /// <summary>
        ///   Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns> An enumerator that can be used to iterate through the collection.</returns>
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _query.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _query.GetEnumerator();
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
            }

            Interop.IoTConnectivity.Common.Query.Destroy(_resourceQueryHandle);
            _disposed = true;
        }

        private bool CanAddQuery(string newKey, string newValue)
        {
            int queryLenth = 0;
            foreach (string key in Keys)
            {
                queryLenth += key.Length;
            }
            foreach (string value in Values)
            {
                queryLenth += value.Length;
            }

            if ((newKey.Length + newValue.Length + queryLenth) < QueryMaxLenth)
                return true;

            return false;
        }
    }
}
