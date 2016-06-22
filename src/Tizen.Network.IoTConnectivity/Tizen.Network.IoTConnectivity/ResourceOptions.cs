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
using System.Linq;
using Tizen;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents resource options.
    /// </summary>
    public class ResourceOptions : IDictionary<ushort, string>, IDisposable
    {
        internal const int MaxSize = 2;
        internal const int IdMin = 2048;
        internal const int IdMax = 3000;
        internal const int DataMax = 15;

        internal IntPtr _resourceOptionsHandle = IntPtr.Zero;
        private readonly IDictionary<ushort, string> _options = new Dictionary<ushort, string>();
        private bool _disposed = false;

        public ResourceOptions()
        {
            int ret = Interop.IoTConnectivity.Common.Options.Create(out _resourceOptionsHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create options");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        internal ResourceOptions(IntPtr handleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.Options.Create(out _resourceOptionsHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create options");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            Interop.IoTConnectivity.Common.Options.OptionsCallback forEachCallback = (ushort id, string value, IntPtr userData) =>
            {
                Add(id, value);
                return true;
            };

            ret = Interop.IoTConnectivity.Common.Options.ForEach(handleToClone, forEachCallback, IntPtr.Zero);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to iterate options");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        ~ResourceOptions()
        {
            Dispose(false);
        }

        /// <summary>
        /// Contains all the Option keys
        /// </summary>
        public ICollection<ushort> Keys
        {
            get
            {
                return _options.Keys;
            }
        }

        /// <summary>
        /// Contains all the Option values
        /// </summary>
        public ICollection<string> Values
        {
            get
            {
                return _options.Values;
            }
        }

        /// <summary>
        /// Gets the number of options
        /// </summary>
        public int Count
        {
            get
            {
                return _options.Count;
            }
        }

        /// <summary>
        /// Represents whether the collection is readonly
        /// </summary>
        public bool IsReadOnly
        {
            get
            {
                return _options.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the option
        /// </summary>
        /// <param name="key">The option id to get or set.</param>
        /// <returns>The option with the specified id.</returns>
        public string this[ushort key]
        {
            get
            {
                return _options[key];
            }

            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Checks the given key exists in Options collection
        /// </summary>
        /// <param name="key">The key to look for</param>
        /// <returns></returns>
        public bool ContainsKey(ushort key)
        {
            return _options.ContainsKey(key);
        }

        /// <summary>
        ///  Adds option key and value
        /// </summary>
        /// <param name="key">Option ID</param>
        /// <param name="value">Value coresponding to option</param>
        public void Add(ushort key, string value)
        {
            int ret = (int)IoTConnectivityError.InvalidParameter;
            if (IsValid(key, value))
            {
                ret = Interop.IoTConnectivity.Common.Options.Add(_resourceOptionsHandle, key, value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add option");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
                _options.Add(key, value);
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Invalid options");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
        }

        /// <summary>
        /// Removes an option
        /// </summary>
        /// <param name="key">The option to remvoe</param>
        /// <returns></returns>
        public bool Remove(ushort key)
        {
            int ret = Interop.IoTConnectivity.Common.Options.Remove(_resourceOptionsHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove option");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            return _options.Remove(key);
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The option id</param>
        /// <param name="value">value corresponding to option id</param>
        /// <returns>true if the key exists, false otherwise</returns>
        public bool TryGetValue(ushort key, out string value)
        {
            return _options.TryGetValue(key, out value);
        }

        /// <summary>
        ///  Adds options key and value as a key value pair
        /// </summary>
        /// <param name="item">The key value pair</param>
        public void Add(KeyValuePair<ushort, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the Options collection
        /// </summary>
        public void Clear()
        {
            foreach (ushort key in Keys)
            {
                int ret = Interop.IoTConnectivity.Common.Options.Remove(_resourceOptionsHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove option");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                };
            }
            _options.Clear();
        }

        /// <summary>
        /// Checks if the given option pair exists
        /// </summary>
        /// <param name="item">The key value pair</param>
        /// <returns></returns>
        public bool Contains(KeyValuePair<ushort, string> item)
        {
            return _options.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the options collection to an Array, starting at a particular index.
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">Index parameter</param>
        public void CopyTo(KeyValuePair<ushort, string>[] array, int arrayIndex)
        {
            _options.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Remove the gien option pair
        /// </summary>
        /// <param name="item">The option pair to remove</param>
        /// <returns></returns>
        public bool Remove(KeyValuePair<ushort, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Get the enumerator to options collection
        /// </summary>
        /// <returns> Enumerator to option pairs</returns>
        public IEnumerator<KeyValuePair<ushort, string>> GetEnumerator()
        {
            return _options.GetEnumerator();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _options.GetEnumerator();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free managed objects
            }

            Interop.IoTConnectivity.Common.Options.Destroy(_resourceOptionsHandle);
            _disposed = true;
        }

        private bool IsValid(ushort key, string value)
        {
            return (key > IdMin && key < IdMax && value.Length <= DataMax && _options.Count() < MaxSize);
        }
    }
}
