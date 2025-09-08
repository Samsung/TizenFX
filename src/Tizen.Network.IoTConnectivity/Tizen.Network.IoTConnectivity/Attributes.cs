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
    /// This class represents current attributes of a resource.
    /// It provides API to manage attributes.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    [Obsolete("Deprecated since API level 13")]
    public class Attributes : IDictionary<string, object>, IDisposable
    {
        internal IntPtr _resourceAttributesHandle = IntPtr.Zero;
        private readonly IDictionary<string, object> _attributes = new Dictionary<string, object>();
        private bool _disposed = false;

        /// <summary>
        /// The Attributes constructor.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when there is not enough memory.</exception>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public Attributes()
        {
            int ret = Interop.IoTConnectivity.Common.Attributes.Create(out _resourceAttributesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create attributes handle");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
        }

        internal Attributes(IntPtr attributesHandleToClone)
        {
            int ret = Interop.IoTConnectivity.Common.Attributes.Clone(attributesHandleToClone, out _resourceAttributesHandle);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to create attributes handle");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            SetAttributes(_resourceAttributesHandle);
        }

        /// <summary>
        /// Destructor of the Attributes class.
        /// </summary>
        ~Attributes()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the number of keys.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The number of keys.</value>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        /// attributes.Add("brightness", 50);
        /// var count = attributes.Count;
        /// Console.WriteLine("There are {0} keys in the attribute object", count);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public int Count
        {
            get
            {
                return _attributes.Count;
            }
        }

        /// <summary>
        /// Represents whether an attribute is readonly.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>Whether an attribute is readonly.</value>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// if (attributes.IsReadOnly)
        ///     Console.WriteLine("Read only attribute");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool IsReadOnly
        {
            get
            {
                return _attributes.IsReadOnly;
            }
        }

        /// <summary>
        /// Contains all the attribute keys.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the attribute keys.</value>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// var keys = attributes.Keys;
        /// Console.WriteLine("Attribute contains keys {0} and {1}", keys.ElementAt(0), keys.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<string> Keys
        {
            get
            {
                return _attributes.Keys;
            }
        }

        /// <summary>
        /// Contains all the attribute values.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>All the attribute values.</value>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// var values = attributes.Values;
        /// Console.WriteLine("Attribute contains values {0} and {1}", values.ElementAt(0), values.ElementAt(1));
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public ICollection<object> Values
        {
            get
            {
                return _attributes.Values;
            }
        }

        /// <summary>
        /// Gets or sets the attribute with the specified key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <value>The attribute with the specified key.</value>
        /// <param name="key">The key of the attribute to get or set.</param>
        /// <returns>The element with the specified key.</returns>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes();
        /// attributes["state"] = "ON";
        /// Console.WriteLine("Attribute value for key 'state' : {0}", attributes["state"]);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public object this[string key]
        {
            get
            {
                if (_attributes.ContainsKey(key))
                    return _attributes[key];
                else
                    return null;
            }

            set
            {
                Add(key, value);
            }
        }

        /// <summary>
        /// Adds the attribute key and a value as a key value pair.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The key value pair to add.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <example><code><![CDATA[
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes();
        /// attributes.Add(new KeyValuePair<string, object> ("state", "ON"));
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Add(KeyValuePair<string, object> item)
        {
            Add(item.Key, item.Value);
        }

        /// <summary>
        /// Adds an attribute.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The key representing the attribute.</param>
        /// <param name="value">The value representing the attribute.</param>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes();
        /// attributes.Add("brightness", 50);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Add(string key, object value)
        {
            int ret = 0;
            if (value is int)
            {
                ret = Interop.IoTConnectivity.Common.Attributes.AddInt(_resourceAttributesHandle, key, (int)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add int");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is Attributes)
            {
                Attributes attribs = (Attributes)value;
                ret = Interop.IoTConnectivity.Common.Attributes.AddAttributes(_resourceAttributesHandle, key, attribs._resourceAttributesHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add attributes");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is string)
            {
                ret = Interop.IoTConnectivity.Common.Attributes.AddStr(_resourceAttributesHandle, key, (string)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add string");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is double)
            {
                ret = Interop.IoTConnectivity.Common.Attributes.AddDouble(_resourceAttributesHandle, key, (double)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add double");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is bool)
            {
                ret = Interop.IoTConnectivity.Common.Attributes.AddBool(_resourceAttributesHandle, key, (bool)value);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add bool");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is byte[])
            {
                byte[] val = value as byte[];
                if (val == null)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get byte[] val");
                    throw new ArgumentException("Invalid Parameter");
                }
                ret = Interop.IoTConnectivity.Common.Attributes.AddByteStr(_resourceAttributesHandle, key, val, val.Length);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add bool");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else if (value is IEnumerable)
            {
                IntPtr listHandle = List.GetListHandle(value);
                ret = Interop.IoTConnectivity.Common.Attributes.AddList(_resourceAttributesHandle, key, listHandle);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add list");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to Add");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
            _attributes.Add(key, value);
        }

        /// <summary>
        /// Clears attributes collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes();
        /// attributes.Add("brightness", 50);
        /// attributes.Clear();
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public void Clear()
        {
            foreach (string key in _attributes.Keys)
            {
                int ret = Interop.IoTConnectivity.Common.Attributes.Remove(_resourceAttributesHandle, key);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to clear attributes");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }
            }
            _attributes.Clear();
        }

        /// <summary>
        /// Checks whether the given key value pair exists in attributes collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The status key value pair.</param>
        /// <returns>true if exists. Otherwise, false.</returns>
        /// <example><code><![CDATA[
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// if (attributes.Contains(new KeyValuePair<string, object> ("dim", 10))
        ///     Console.WriteLine("Attribute conatins pair ('dim', 10)");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Contains(KeyValuePair<string, object> item)
        {
            return _attributes.Contains(item);
        }

        /// <summary>
        /// Checks whether the given key exists in attributes collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The status key to look for.</param>
        /// <returns>true if exists. Otherwise, false.</returns>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// if (attributes.ContainsKey("dim"))
        ///     Console.WriteLine("Attribute conatins key : dim");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool ContainsKey(string key)
        {
            return _attributes.ContainsKey(key);
        }

        /// <summary>
        /// Copies the elements of the attributes to an array, starting at a particular index.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="array">The destination array.</param>
        /// <param name="arrayIndex">The zero-based index in an array at which copying begins.</param>
        /// <example><code><![CDATA[
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// KeyValuePair<string, object>[] dest = new KeyValuePair<string, object>[attributes.Count];
        /// int index = 0;
        /// attributes.CopyTo(dest, index);
        /// Console.WriteLine("Dest conatins ({0}, {1})", dest[0].Key, dest[0].Value);
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public void CopyTo(KeyValuePair<string, object>[] array, int arrayIndex)
        {
            _attributes.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns> An enumerator that can be used to iterate through the collection.</returns>
        /// <example><code><![CDATA[
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// foreach (KeyValuePair<string, object> pair in attributes)
        /// {
        ///     Console.WriteLine("key : {0}, value : {1}", pair.Key, pair.Value);
        /// }
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public IEnumerator<KeyValuePair<string, object>> GetEnumerator()
        {
            return _attributes.GetEnumerator();
        }

        /// <summary>
        /// Removes an attribute from collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="item">The attributes element to remove.</param>
        /// <returns>true if operation is successful, otherwise, false.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <example><code><![CDATA[
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// if (attributes.Remove(new KeyValuePair<string, object>("dim", 10)))
        ///     Console.WriteLine("Remove was successful");
        /// ]]></code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(KeyValuePair<string, object> item)
        {
            return Remove(item.Key);
        }

        /// <summary>
        /// Removes an attribute from collection using a key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The attributes element to remove.</param>
        /// <returns>true if operation is successful, otherwise, false.</returns>
        /// <feature>http://tizen.org/feature/iot.ocf</feature>
        /// <exception cref="NotSupportedException">Thrown when the iotcon is not supported</exception>
        /// <exception cref="ArgumentException">Thrown when there is an invalid parameter</exception>
        /// <exception cref="InvalidOperationException">Thrown when the operation is invalid</exception>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" },
        ///     { "dim", 10 }
        /// };
        /// if (attributes.Remove("state"))
        ///     Console.WriteLine("Remove was successful");
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool Remove(string key)
        {
            int ret = Interop.IoTConnectivity.Common.Attributes.Remove(_resourceAttributesHandle, key);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove attributes");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }

            bool isRemoved = _attributes.Remove(key);

            return isRemoved;
        }

        /// <summary>
        /// Gets the value associated with the specified key.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="key">The key whose value to get.</param>
        /// <param name="value"> The value associated with the specified key.</param>
        /// <returns> true if the attributes collection contains an element with the specified key, otherwise, false.</returns>
        /// <example><code>
        /// Tizen.Network.IoTConnectivity.Attributes attributes = new Tizen.Network.IoTConnectivity.Attributes() {
        ///     { "state", "ON" }
        /// };
        /// object value;
        /// var isPresent = attributes.TryGetValue("state", out value);
        /// if (isPresent)
        ///     Console.WriteLine("value : {0}", value);
        /// </code></example>
        [Obsolete("Deprecated since API level 13")]
        public bool TryGetValue(string key, out object value)
        {
            return _attributes.TryGetValue(key, out value);
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return _attributes.GetEnumerator();
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

            Interop.IoTConnectivity.Common.Attributes.Destroy(_resourceAttributesHandle);
            _disposed = true;
        }

        private void SetAttributes(IntPtr attributesHandle)
        {
            Interop.IoTConnectivity.Common.Attributes.AttributesCallback cb = (IntPtr attributes, string key, IntPtr userData) =>
            {
                Interop.IoTConnectivity.Common.DataType dataType;
                int ret = Interop.IoTConnectivity.Common.Attributes.GetType(attributes, key, out dataType);
                if (ret != (int)IoTConnectivityError.None)
                {
                    Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                    throw IoTConnectivityErrorFactory.GetException(ret);
                }

                switch ((Interop.IoTConnectivity.Common.DataType)dataType)
                {
                    case Interop.IoTConnectivity.Common.DataType.Int:
                        {
                            int value;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetInt(attributes, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            _attributes.Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Bool:
                        {
                            bool value;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetBool(attributes, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            _attributes.Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Double:
                        {
                            double value;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetDouble(attributes, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            _attributes.Add(key, value);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.String:
                        {
                            IntPtr value;
                            string Str;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetStr(attributes, key, out value);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            Str = (value != IntPtr.Zero) ? Marshal.PtrToStringAnsi(value) : string.Empty;
                            _attributes.Add(key, Str);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.ByteStr:
                        {
                            IntPtr byteStrPtr;
                            int byteStrSize;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetByteStr(attributes, key, out byteStrPtr, out byteStrSize);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            byte[] byteStr = new byte[byteStrSize];
                            Marshal.Copy(byteStrPtr, byteStr, 0, byteStrSize);
                            _attributes.Add(key, byteStr);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Null:
                        {
                            _attributes.Add(key, null);
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.List:
                        {
                            IntPtr listHandle;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetList(attributes, key, out listHandle);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            _attributes.Add(key, List.GetList(listHandle));
                            break;
                        }
                    case Interop.IoTConnectivity.Common.DataType.Attributes:
                        {
                            IntPtr attribsHandle;
                            ret = Interop.IoTConnectivity.Common.Attributes.GetAttributes(attributes, key, out attribsHandle);
                            if (ret != (int)IoTConnectivityError.None)
                            {
                                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                                throw IoTConnectivityErrorFactory.GetException(ret);
                            }
                            _attributes.Add(key, new Attributes(attribsHandle));
                            break;
                        }
                    default:
                        break;
                }

                return true;
            };

            int res = Interop.IoTConnectivity.Common.Attributes.Foreach(attributesHandle, cb, IntPtr.Zero);
            if (res != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to remove attributes");
                throw IoTConnectivityErrorFactory.GetException(res);
            }
        }
    }

    internal static class List
    {
        internal static IntPtr GetListHandle(object list)
        {
            IntPtr listHandle = IntPtr.Zero;
            int ret;
            int pos = 0;

            if (list is IEnumerable<IEnumerable>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.List, out listHandle);
                pos = 0;
                foreach (IEnumerable val in (IEnumerable<IEnumerable>)list)
                {
                    IntPtr childList = GetListHandle(val);
                    ret = Interop.IoTConnectivity.Common.List.AddList(listHandle, childList, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add attributes");
                        Interop.IoTConnectivity.Common.List.Destroy(childList);
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<int>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Int, out listHandle);
                pos = 0;
                foreach (int val in (IEnumerable<int>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddInt(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add attributes");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<string>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.String, out listHandle);
                pos = 0;
                foreach (string val in (IEnumerable<string>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddStr(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add str");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<double>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Double, out listHandle);
                pos = 0;
                foreach (double val in (IEnumerable<double>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddDouble(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add double");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<bool>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Bool, out listHandle);
                pos = 0;
                foreach (bool val in (IEnumerable<bool>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddBool(listHandle, val, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add bool");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<Attributes>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.Attributes, out listHandle);
                pos = 0;
                foreach (Attributes val in (IEnumerable<Attributes>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddAttributes(listHandle, val._resourceAttributesHandle, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add attributes");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else if (list is IEnumerable<byte[]>)
            {
                ret = Interop.IoTConnectivity.Common.List.Create(Interop.IoTConnectivity.Common.DataType.ByteStr, out listHandle);
                pos = 0;
                foreach (byte[] val in (IEnumerable<byte[]>)list)
                {
                    ret = Interop.IoTConnectivity.Common.List.AddByteStr(listHandle, val, val.Length, pos++);
                    if (ret != (int)IoTConnectivityError.None)
                    {
                        Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to add byte[]");
                        throw IoTConnectivityErrorFactory.GetException(ret);
                    }
                }
            }
            else
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to GetListHandle");
                throw IoTConnectivityErrorFactory.GetException((int)IoTConnectivityError.InvalidParameter);
            }
            return listHandle;
        }

        internal static object GetList(IntPtr listHandle)
        {
            IList list = null;
            int type;
            int ret = Interop.IoTConnectivity.Common.List.GetType(listHandle, out type);
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get type");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            switch ((Interop.IoTConnectivity.Common.DataType)type)
            {
                case Interop.IoTConnectivity.Common.DataType.Int:
                    {
                        list = new List<int>();
                        Interop.IoTConnectivity.Common.List.IntCallback cb = (int pos, int value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachInt(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.Bool:
                    {
                        list = new List<bool>();
                        Interop.IoTConnectivity.Common.List.BoolCallback cb = (int pos, bool value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachBool(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.Double:
                    {
                        list = new List<double>();
                        Interop.IoTConnectivity.Common.List.DoubleCallback cb = (int pos, double value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachDouble(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.String:
                    {
                        list = new List<string>();
                        Interop.IoTConnectivity.Common.List.StrCallback cb = (int pos, string value, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachStr(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.Attributes:
                    {
                        list = new List<Attributes>();
                        Interop.IoTConnectivity.Common.List.AttribsCallback cb = (int pos, IntPtr value, IntPtr userData) =>
                        {
                            list.Add(new Attributes(value));
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachAttributes(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.ByteStr:
                    {
                        list = new List<byte[]>();
                        Interop.IoTConnectivity.Common.List.ByteStrCallback cb = (int pos, byte[] value, int len, IntPtr userData) =>
                        {
                            list.Add(value);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachByteStr(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                case Interop.IoTConnectivity.Common.DataType.List:
                    {
                        list = new List<List<object>>();
                        Interop.IoTConnectivity.Common.List.ListCallback cb = (int pos, IntPtr value, IntPtr userData) =>
                        {
                            object childList = GetList(value);
                            if (childList != null)
                                list.Add(childList);
                            return true;
                        };
                        ret = Interop.IoTConnectivity.Common.List.ForeachList(listHandle, cb, IntPtr.Zero);
                        break;
                    }
                default:
                    break;
            }
            if (ret != (int)IoTConnectivityError.None)
            {
                Log.Error(IoTConnectivityErrorFactory.LogTag, "Failed to get attributes");
                throw IoTConnectivityErrorFactory.GetException(ret);
            }
            return list;
        }
    }
}
