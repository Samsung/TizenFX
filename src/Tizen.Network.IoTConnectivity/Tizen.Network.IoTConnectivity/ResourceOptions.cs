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
using System.Linq;

namespace Tizen.Network.IoTConnectivity
{
    /// <summary>
    /// <para>This class represents resource options. It provides APIs to manage them.</para>
    /// <para>The iotcon options API provides methods for managing vendor specific options of coap packet.</para>
    /// <para>See more about coap packet in http://tools.ietf.org/html/rfc7252.</para>
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
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
        /// The resource options constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(ushort, string)"/>
        /// <seealso cref="Remove(ushort)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Contains all the Option keys.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the Option keys.</value>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var keys = options.Keys;
        /// Console.WriteLine("Resource options contains keys {0} and {1}", keys.ElementAt(0), keys.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<ushort> Keys
        {
            get
            {
                return _options.Keys;
            }
        }

        /// <summary>
        /// Contains all the Option values.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the Option values.</value>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var values = options.Values;
        /// Console.WriteLine("Resource options contains values {0} and {1}", values.ElementAt(0), values.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<string> Values
        {
            get
            {
                return _options.Values;
            }
        }

        /// <summary>
        /// Gets the number of options.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of options.</value>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// options.Add(2055, "sample value");
        /// var count = options.Count;
        /// Console.WriteLine("There are {0} keys in the options object", count);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public int Count
        {
            get
            {
                return _options.Count;
            }
        }

        /// <summary>
        /// Represents whether the collection is readonly.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Whether the collection is readonly.</value>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// if (options.IsReadOnly)
        ///     Console.WriteLine("Read only options");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool IsReadOnly
        {
            get
            {
                return _options.IsReadOnly;
            }
        }

        /// <summary>
        /// Gets or sets the option data.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The option data.</value>
        /// <param name="key">The option ID to get or set.</param>
        /// <returns>The option with the specified ID.</returns>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options[2055] = "sample-data";
        /// Console.WriteLine("Option has : {0}", options[2055]);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Checks whether the given key exists in Options collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The key to look for.</param>
        /// <returns>true if exists. Otherwise, false.</returns>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// if (options.ContainsKey(2050))
        ///     Console.WriteLine("options conatins key : 2050");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool ContainsKey(ushort key)
        {
            return _options.ContainsKey(key);
        }

        /// <summary>
        /// Adds a new ID and a correspoding data into the options.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <remarks>
        /// <para>ResourceOptions can have up to 2 options.</para>
        /// <para>key is always situated between 2048 and 3000.</para>
        /// <para>Length of option data is less than or equal to 15.</para>
        /// </remarks>
        /// <param name="key">The ID of the option to insert.</param>
        /// <param name="value">The string data to insert into the options.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(ushort)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "sample-data");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Removes the ID and its associated data from the options.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The ID of the option to delete.</param>
        /// <returns>True if operation is successful. Otherwise, false.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(ushort, string)"/>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// var result = options.Remove(2050);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(ushort key)
        {
            int ret = Interop.IoTConnectivity.Common.Options.Remove(_resourceOptionsHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove option");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            bool isRemoved = _options.Remove(key);

            return isRemoved;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The option ID.</param>
        /// <param name="value">Value corresponding to option ID.</param>
        /// <returns>True if the key exists, false otherwise.</returns>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// string value;
        /// var isPresent = options.TryGetValue(2050, out value);
        /// if (isPresent)
        ///     Console.WriteLine("value : {0}", value);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool TryGetValue(ushort key, out string value)
        {
            return _options.TryGetValue(key, out value);
        }

        /// <summary>
        ///  Adds options key and value as a key value pair.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Remove(KeyValuePair{ushort, string})"/>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Add(KeyValuePair<ushort, string> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Clears the Options collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <example><code>
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(2050, "12345");
        /// options.Add(2055, "sample");
        /// options.Clear();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
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
        /// Checks if the given option pair exists.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair.</param>
        /// <returns>True if exists. Otherwise, false.</returns>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// var isPresent = options.Contains(new KeyValuePair<ushort, string>(2050, "12345"));
        /// if (isPresent)
        ///     Console.WriteLine("Key value pair is present");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Contains(KeyValuePair<ushort, string> item)
        {
            return _options.Contains(item);
        }

        /// <summary>
        /// Copies the elements of the options collection to an array, starting at a particular index.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">Index parameter.</param>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// KeyValuePair<ushort, string>[] dest = new KeyValuePair<ushort, string>[options.Count];
        /// options.CopyTo(dest, 0);
        /// Console.WriteLine("Dest conatins ({0}, {1})", dest[0].Key, dest[0].Value);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void CopyTo(KeyValuePair<ushort, string>[] array, int arrayIndex)
        {
            _options.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Removes the given key value pair from the options.
        /// </summary>
        /// <since_tizen>3</since_tizen>
        /// <param name="item">The key value pair to remove</param>
        /// <returns>True if operation is successful. Otherwise, false</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <seealso cref="Add(KeyValuePair{ushort, string})"/>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "12345"));
        /// var result = options.Remove(new KeyValuePair<ushort, string>(2050, "12345"));
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(KeyValuePair<ushort, string> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Get the enumerator to options collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Enumerator to option pairs.</returns>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "sample1"));
        /// options.Add(new KeyValuePair<ushort, string>(2055, "sample2"));
        /// foreach (KeyValuePair<string, object> pair in options)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public IEnumerator<KeyValuePair<ushort, string>> GetEnumerator()
        {
            return _options.GetEnumerator();
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
        /// Gets the enumerator to options collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Enumerator to option pairs.</returns>
        /// <example><code><![CDATA[
        /// ResourceOptions options = new ResourceOptions();
        /// options.Add(new KeyValuePair<ushort, string>(2050, "sample1"));
        /// options.Add(new KeyValuePair<ushort, string>(2055, "sample2"));
        /// foreach (KeyValuePair<string, object> pair in options)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _options.GetEnumerator();
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

            Interop.IoTConnectivity.Common.Options.Destroy(_resourceOptionsHandle);
            _disposed = true;
        }

        private bool IsValid(ushort key, string value)
        {
            return (key > IdMin && key < IdMax && value.Length <= DataMax && _options.Count() < MaxSize);
        }
    }
}
