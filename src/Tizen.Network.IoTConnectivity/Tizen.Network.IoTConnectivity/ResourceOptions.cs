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

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// This class represents resource options. It provides APIs to manage them.\n
    /// The iotcon options API provides methods for managing vendor specific options of coap packet.\n
    /// See more about coap packet in http://tools.ietf.org/html/rfc7252.
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

        /// <summary>
        /// The resource options constructor
        /// </summary>
        /// <seealso cref="Add()"/>
        /// <seealso cref="Remove()"/>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// </code>
        public ResourceOptions()
        {
            int ret = Interop.IoTConnectivity.Common.Options.Create(out _resourceOptionsHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create options");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        // internal constructor
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

        /// <summary>
        /// Destructor of the ResourceOptions class.
        /// </summary>
        ~ResourceOptions()
        {
            Dispose(false);
        }

        /// <summary>
        /// Contains all the Option keys
        /// </summary>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var keys = options.Keys;
        /// Console.WriteLine("Resource options contains keys {0} and {1}", keys.ElementAt(0), keys.ElementAt(1));
        /// </code>
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
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var values = options.Values;
        /// Console.WriteLine("Resource options contains values {0} and {1}", values.ElementAt(0), values.ElementAt(1));
        /// </code>
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
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var count = options.Count;
        /// Console.WriteLine("There are {0} keys in the options object", count);
        /// </code>
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
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// if (options.IsReadOnly)
        ///     Console.WriteLine("Read only options");
        /// </code>
        public bool IsReadOnly
        {
            get
            {
                return _options.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the option data
        /// </summary>
        /// <remarks>
        /// <param name="key">The option id to get or set.</param>
        /// <returns>The option with the specified id.</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options[2055] = "sample-data";
        /// Console.WriteLine("Option has : {0}", options[2055]);
        /// </code>
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
        /// Checks whether the given key exists in Options collection
        /// </summary>
        /// <param name="key">The key to look for</param>
        /// <returns>true if exists. Otherwise, false</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// if (options.ContainsKey(2050))
        ///     Console.WriteLine("options conatins key : 2050");
        /// </code>
        public bool ContainsKey(ushort key)
        {
            return _options.ContainsKey(key);
        }

        /// <summary>
        /// Adds a new id and a correspoding data into the options.
        /// </summary>
        /// <remarks>
        /// ResourceOptions can have up to 2 options. \n
        /// key is always situated between 2048 and 3000. \n
        /// Length of option data is less than or equal to 15.
        /// </remarks>
        /// <param name="key">The id of the option to insert</param>
        /// <param name="value">The string data to insert into the options</param>
        /// <seealso cref="Remove()"/>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// </code>
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
        /// Removes the id and its associated data from the options.
        /// </summary>
        /// <param name="key">The id of the option to delete</param>
        /// <returns>True if operation is successful. Otherwise, false</returns>
        /// <seealso cref="Add()"/>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// var result = options.Remove(2050);
        /// </code>
        public bool Remove(ushort key)
        {
            bool isRemoved = _options.Remove(key);
            if (isRemoved)
            {
                int ret = Interop.IoTConnectivity.Common.Options.Remove(_resourceOptionsHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove option");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            return isRemoved;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <param name="key">The option id</param>
        /// <param name="value">Value corresponding to option id</param>
        /// <returns>True if the key exists, false otherwise</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// string value;
        /// var isPresent = options.TryGetValue(2050, out value);
        /// if (isPresent)
        ///     Console.WriteLine("value : {0}", value);
        /// </code>
        public bool TryGetValue(ushort key, out string value)
        {
            return _options.TryGetValue(key, out value);
        }

        /// <summary>
        ///  Adds options key and value as a key value pair
        /// </summary>
        /// <param name="item">The key value pair</param>
        /// <seealso cref="Remove()"/>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// </code>
        public void Add(KeyValuePair<ushort, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the Options collection
        /// </summary>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// options.Add(2055, "sample");
        /// options.Clear();
        /// </code>
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
        /// <returns>True if exists. Otherwise, false</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// var isPresent = options.Contains(new KeyValuePair<ushort, string>(2050, "12345"));
        /// if (isPresent)
        ///     Console.WriteLine("Key value pair is present");
        /// </code>
        public bool Contains(KeyValuePair<ushort, string> item)
        {
            return _options.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the options collection to an Array, starting at a particular index.
        /// </summary>
        /// <param name="array">The destination array</param>
        /// <param name="arrayIndex">Index parameter</param>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// KeyValuePair<ushort, string>[] dest = new KeyValuePair<ushort, string>[options.Count];
        /// options.CopyTo(dest, 0);
        /// Console.WriteLine("Dest conatins ({0}, {1})", dest[0].Key, dest[0].Value);
        /// </code>
        public void CopyTo(KeyValuePair<ushort, string>[] array, int arrayIndex)
        {
            _options.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Remove the given key value pair from the options
        /// </summary>
        /// <param name="item">The key value pair to remove</param>
        /// <returns>True if operation is successful. Otherwise, false</returns>
        /// <seealso cref="Add()"/>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// var result = options.Remove(new KeyValuePair<ushort, string>(2050, "12345"));
        /// </code>
        public bool Remove(KeyValuePair<ushort, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Get the enumerator to options collection
        /// </summary>
        /// <returns>Enumerator to option pairs</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "sample1"));
        /// options.Add(new KeyValuePair<ushort, string>(2055, "sample2"));
        /// foreach (KeyValuePair<string, object> pair in options)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// </code>
        public IEnumerator<KeyValuePair<ushort, string>> GetEnumerator()
        {
            return _options.GetEnumerator();
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
        /// Get the enumerator to options collection
        /// </summary>
        /// <returns>Enumerator to option pairs</returns>
        /// <code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "sample1"));
        /// options.Add(new KeyValuePair<ushort, string>(2055, "sample2"));
        /// foreach (KeyValuePair<string, object> pair in options)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// </code>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _options.GetEnumerator();
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

            Interop.IoTConnectivity.Common.Options.Destroy(_resourceOptionsHandle);
            _disposed = true;
        }

        private bool IsValid(ushort key, string value)
        {
            return (key > IdMin && key < IdMax && value.Length <= DataMax && _options.Count() < MaxSize);
        }
    }
}
