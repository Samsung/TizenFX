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
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// A bundle object represents a bundle.
    /// A bundle holds items (key-value pairs) and can be used with other Tizen APIs.
    /// Keys can be used to access values.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// A bundle instance is not guaranteed to be thread safe if the instance is modified by multiple threads.
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public class Bundle : IDisposable
    {
        private SafeBundleHandle _handle;
        private bool _disposed = false;
        private readonly HashSet<string> _keys;

        /// <summary>
        /// The bundle constructor.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public Bundle()
        {
            _handle = Interop.Bundle.Create();
            BundleErrorFactory.CheckAndThrowException(ErrorFacts.GetLastResult(), _handle);
            _keys = new HashSet<string>();
        }

        /// <summary>
        /// The bundle constructor.
        /// </summary>
        /// <param name="handle">The SafeBundleHandle instance.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when the handle is null or invalid.</exception>
        /// <since_tizen> 3 </since_tizen>
        public Bundle(SafeBundleHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentNullException("handle");
            }

            if (handle.IsInvalid)
            {
                throw new ArgumentNullException("handle", "handle is invalid");
            }

            _handle = Interop.Bundle.DangerousClone(handle.DangerousGetHandle());
            _keys = new HashSet<string>();
            Interop.Bundle.Iterator iterator = (string key, int type, IntPtr keyval, IntPtr userData) =>
            {
                _keys.Add(key);
            };

            Interop.Bundle.Foreach(_handle, iterator, IntPtr.Zero);
            if ((BundleErrorFactory.BundleError)ErrorFacts.GetLastResult() == BundleErrorFactory.BundleError.InvalidParameter)
            {
                throw new ArgumentException("Invalid parameter - cannot create bundle instance");
            }
        }

        private enum BundleTypeProperty
        {
            Array = 0x0100,
            Primitive = 0x0200,
            Measurable = 0x0400
        }

        private enum BundleType
        {
            None = -1,
            Any = 0,
            String = 1 | BundleTypeProperty.Measurable,
            StringArray = String | BundleTypeProperty.Array | BundleTypeProperty.Measurable,
            Byte = 2,
            ByteArray = Byte | BundleTypeProperty.Array
        }

        /// <summary>
        /// The number of items in a bundle object.
        /// </summary>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// Console.WriteLine("There are {0} items in the bundle", bundle.Count);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public int Count
        {
            get
            {
                return _keys.Count;
            }
        }

        /// <summary>
        /// The keys in a bundle object.
        /// </summary>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string1", "a_string1");
        /// bundle.AddItem("string2", "a_string2");
        /// bundle.AddItem("string3", "a_string3");
        /// Console.WriteLine("The bundle contains the following keys:");
        /// foreach(string key in bundle.Keys)
        /// {
        ///     Console.WriteLine(key);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public IEnumerable<string> Keys
        {
            get
            {
                return _keys;
            }
        }

        /// <summary>
        /// Gets the SafeBundleHandle instance.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public SafeBundleHandle SafeBundleHandle
        {
            get { return _handle; }
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Checks whether the bundle contains an item with a specified key.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>true if the bundle contains the key, false otherwise.</returns>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// if (bundle.Contains("string"))
        /// {
        ///     string aValue = bundle.GetItem&lt;string&gt;("string");
        ///     Console.WriteLine(aValue);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool Contains(string key)
        {
            return _keys.Contains(key);
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// byte[] byteArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// bundle.AddItem("byte_array", byteArray);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void AddItem(string key, byte[] value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            AddItem(key, value, 0, value.Length);
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <param name="offset">The zero-based byte offset in value from which to add to the bundle.</param>
        /// <param name="count">The maximum number of bytes to add to the bundle starting with offset.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the offset or count is out of range.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.ArgumentNullException">Thrown when a value is null.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// byte[] byteArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// bundle.AddItem("byte_array", byteArray, 2, 3);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void AddItem(string key, byte[] value, int offset, int count)
        {
            if (!_keys.Contains(key))
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }
                if (offset < 0)
                {
                    throw new ArgumentOutOfRangeException("offset", offset, "Cannot be less than 0");
                }
                if (offset > value.Length - 1)
                {
                    throw new ArgumentOutOfRangeException("offset", offset, "Greater than last index of array");
                }
                if (count < 1)
                {
                    throw new ArgumentOutOfRangeException("count", count, "Must be at least 1");
                }
                if (offset + count > value.Length)
                {
                    throw new ArgumentException("The count is too large for the specified offset");
                }
                // Code is in Interop file because it is unsafe
                int ret = Interop.Bundle.UnsafeCode.AddItem(_handle, key, value, offset, count);
                BundleErrorFactory.CheckAndThrowException(ret, _handle);
                _keys.Add(key);
            }
            else
            {
                throw new ArgumentException("Key already exists", "key");
            }
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void AddItem(string key, string value)
        {
            if (!_keys.Contains(key))
            {
                int ret = Interop.Bundle.AddString(_handle, key, value);
                BundleErrorFactory.CheckAndThrowException(ret, _handle);
                _keys.Add(key);
            }
            else
            {
                throw new ArgumentException("Key already exists", "key");
            }
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public void AddItem(string key, IEnumerable<string> value)
        {
            if (!_keys.Contains(key))
            {
                string[] valueArray = value.Select(v => v == null ? string.Empty : v).ToArray();
                int ret = Interop.Bundle.AddStringArray(_handle, key, valueArray, valueArray.Count());
                BundleErrorFactory.CheckAndThrowException(ret, _handle);
                _keys.Add(key);
            }
            else
            {
                throw new ArgumentException("Key already exists", "key");
            }
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// </summary>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <returns>The value of the bundle item.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the key does not exist or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// if (bundle.Contains("string"))
        /// {
        ///     object aValue = bundle.GetItem("string");
        ///     if (bundle.Is&lt;string&gt;("string");)
        ///     {
        ///         string aString = (string)aValue;
        ///         Console.WriteLine(aString);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public object GetItem(string key)
        {
            if (_keys.Contains(key))
            {
                int type = Interop.Bundle.GetType(_handle, key);
                BundleErrorFactory.CheckAndThrowException(ErrorFacts.GetLastResult(), _handle);
                switch (type)
                {
                    case (int)BundleType.String:
                        // get string
                        IntPtr stringPtr;
                        int retString = Interop.Bundle.GetString(_handle, key, out stringPtr);
                        BundleErrorFactory.CheckAndThrowException(retString, _handle);
                        string stringValue = Marshal.PtrToStringAnsi(stringPtr);
                        if (stringValue == null)
                            return string.Empty;
                        return stringValue;

                    case (int)BundleType.StringArray:
                        // get string array
                        int stringArraySize;
                        IntPtr stringArrayPtr = Interop.Bundle.GetStringArray(_handle, key, out stringArraySize);
                        BundleErrorFactory.CheckAndThrowException(ErrorFacts.GetLastResult(), _handle);
                        string[] stringArray;
                        IntPtrToStringArray(stringArrayPtr, stringArraySize, out stringArray);
                        return stringArray;

                    case (int)BundleType.Byte:
                        // get byte array
                        IntPtr byteArrayPtr;
                        int byteArraySize;
                        int retByte = Interop.Bundle.GetByte(_handle, key, out byteArrayPtr, out byteArraySize);
                        BundleErrorFactory.CheckAndThrowException(retByte, _handle);
                        byte[] byteArray = new byte[byteArraySize];
                        Marshal.Copy(byteArrayPtr, byteArray, 0, byteArraySize);
                        return byteArray;

                    default:
                        throw new ArgumentException("Key does not exist in the bundle", "key");
                }
            }
            else
            {
                throw new ArgumentException("Key does not exist in the bundle (may be null or empty string)", "key");
            }
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// Note that this is a generic method.
        /// </summary>
        /// <typeparam name="T">The generic type to return.</typeparam>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <returns>The value of the bundle item if it is of the specified generic type.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the key does not exist or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidCastException">Thrown when the value of the bundle item cannot be converted to the specified generic type.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// if (bundle.Is&lt;string&gt;("string_array"))
        /// {
        ///     Console.WriteLine("It is a string");
        ///     Console.WriteLine(bundle.GetItem&lt;string&gt;("string_array"));
        /// }
        /// else if (bundle.Is&lt;string[]&gt;("string_array"))
        /// {
        ///     Console.WriteLine("It is a string[]");
        ///     string[] anArray = bundle.GetItem&lt;string[]&gt;("string_array");
        ///     foreach (string value in anArray)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public T GetItem<T>(string key)
        {
            return (T)GetItem(key);
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// </summary>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <param name="value">The value of the bundle item. If the key does not exist or the type of this parameter is incorrect, it is the default value for the value parameter type.</param>
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter, false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// byte[] byteArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// bundle.AddItem("byte_array", byteArray);
        /// byte[] aByteArray;
        /// if (bundle.TryGetItem("byte_array", out aByteArray))
        /// {
        ///     Console.WriteLine("First item in the byte array: {0}", aByteArray[0]);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool TryGetItem(string key, out byte[] value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.Byte)
            {
                value = GetItem<byte[]>(key);
                return true;
            }
            else
            {
                if (_keys.Contains(key) && ErrorFacts.GetLastResult() == (int)BundleErrorFactory.BundleError.InvalidParameter)
                {
                    throw new InvalidOperationException("Invalid bundle instance (object may have been disposed or released)");
                }
                value = default(byte[]);
                return false;
            }
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// </summary>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <param name="value">The value of the bundle item. If the key does not exist or the type of this parameter is incorrect, it is the default value for the value parameter type.</param>
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter, false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// string aString;
        /// if (bundle.TryGetItem("string", out aString))
        /// {
        ///     Console.WriteLine(aString);
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool TryGetItem(string key, out string value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.String)
            {
                value = GetItem<string>(key);
                return true;
            }
            else
            {
                if (_keys.Contains(key) && ErrorFacts.GetLastResult() == (int)BundleErrorFactory.BundleError.InvalidParameter)
                {
                    throw new InvalidOperationException("Invalid bundle instance (object may have been disposed or released)");
                }
                value = default(string);
                return false;
            }
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// </summary>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <param name="value">The value of the bundle item. If the key does not exist or the type of this parameter is incorrect, it is the default value for the value parameter type.</param>
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter, false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// System.Collections.Generic.IEnumerable&lt;string&gt; aStringEnumerable;
        /// if (bundle.TryGetItem("string", out aStringEnumerable))
        /// {
        ///     foreach (string value in aStringEnumerable)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool TryGetItem(string key, out IEnumerable<string> value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.StringArray)
            {
                value = GetItem<IEnumerable<string>>(key);
                return true;
            }
            else
            {
                if (_keys.Contains(key) && ErrorFacts.GetLastResult() == (int)BundleErrorFactory.BundleError.InvalidParameter)
                {
                    throw new InvalidOperationException("Invalid bundle instance (object may have been disposed or released)");
                }
                value = default(IEnumerable<string>);
                return false;
            }
        }

        /// <summary>
        /// Checks whether an item is of a specific type.
        /// </summary>
        /// <typeparam name="T">The generic type to check for.</typeparam>
        /// <param name="key">The key whose type wants to be checked.</param>
        /// <returns>true if the item is of the specified type, false otherwise.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the key does not exist or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// if (bundle.Is&lt;string[]&gt;("string_array"))
        /// {
        ///     Console.WriteLine("It is a string[]");
        ///     string[] anArray = bundle.GetItem&lt;string[]&gt;("string_array");
        ///     foreach (string value in anArray)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool Is<T>(string key)
        {
            if (_keys.Contains(key))
            {
                int type = Interop.Bundle.GetType(_handle, key);
                switch (type)
                {
                    case (int)BundleType.String:
                        return typeof(string) == typeof(T);

                    case (int)BundleType.StringArray:
                        return typeof(T).GetTypeInfo().IsAssignableFrom(typeof(string[]).GetTypeInfo());

                    case (int)BundleType.Byte:
                        return typeof(byte[]) == typeof(T);

                    default:
                        throw new ArgumentException("Key does not exist in the bundle", "key");
                }
            }
            else
            {
                throw new ArgumentException("Key does not exist in the bundle (may be null or empty string)", "key");
            }
        }

        /// <summary>
        /// Removes a bundle item with a specific key from a Bundle.
        /// </summary>
        /// <param name="key">The key of the item to delete.</param>
        /// <returns>true if the item is successfully found and removed, false otherwise (even if the item is not found).</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// if (bundle.Contains("string"))
        /// {
        ///     if (bundle.RemoveItem("string"))
        ///     {
        ///         Console.WriteLine("Removed");
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public bool RemoveItem(string key)
        {
            if (_keys.Contains(key))
            {
                int ret = Interop.Bundle.RemoveItem(_handle, key);
                if (ret == (int)BundleErrorFactory.BundleError.KeyNotAvailable)
                {
                    return false;
                }
                BundleErrorFactory.CheckAndThrowException(ret, _handle);
                _keys.Remove(key);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Decodes an encoded bundle data.
        /// </summary>
        /// <param name="bundleRaw">The encoded bundle data. bundleRaw should be the returned value of Tizen.Applications.Bundle.Encode, otherwise this method will not succeed.</param>
        /// <returns>Decoded Bundle object.</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string bundleRaw = bundle.Encode();
        /// Bundle data = bundle.Decode(bundleRaw);
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public static Bundle Decode(string bundleRaw)
        {
            SafeBundleHandle handle;

            handle = Interop.Bundle.BundleDecode(bundleRaw, bundleRaw.Length);
            if (ErrorFacts.GetLastResult() == (int)BundleErrorFactory.BundleError.InvalidParameter)
            {
                throw new ArgumentException("Invalid bundle raw");
            }

            return new Bundle(handle);
        }

        /// <summary>
        /// Encodes bundle to string.
        /// </summary>
        /// <returns>Encoded bundle data in string.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the bundle instance has been disposed.</exception>
        /// <example>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string bundleRaw = bundle.Encode();
        /// </code>
        /// </example>
        /// <since_tizen> 3 </since_tizen>
        public string Encode()
        {
            string bundleRaw;
            int len;

            Interop.Bundle.BundleEncode(_handle, out bundleRaw, out len);
            if (ErrorFacts.GetLastResult() == (int)BundleErrorFactory.BundleError.InvalidParameter)
            {
                throw new InvalidOperationException("Invalid bundle");
            }

            return bundleRaw;
        }

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        /// <since_tizen> 3 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    if (_handle != null && !_handle.IsInvalid)
                        _handle.Dispose();
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Destructor of the bundle class.
        /// </summary>
        ~Bundle()
        {
            Dispose(false);
        }

        static private void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];

            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);

            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAnsi(IntPtrArray[iterator]);
            }
        }
    }

    internal static class BundleErrorFactory
    {
        internal enum BundleError
        {
            None = ErrorCode.None,
            OutOfMemory = ErrorCode.OutOfMemory,
            InvalidParameter = ErrorCode.InvalidParameter,
            KeyNotAvailable = ErrorCode.KeyNotAvailable,
            KeyExists = -0x01180000 | 0x01
        }

        static internal void CheckAndThrowException(int error, SafeBundleHandle handle)
        {
            if ((BundleError)error == BundleError.None)
            {
                return;
            }
            else if ((BundleError)error == BundleError.OutOfMemory)
            {
                throw new InvalidOperationException("Out of memory");
            }
            else if ((BundleError)error == BundleError.InvalidParameter)
            {
                if (handle.IsInvalid)
                {
                    throw new InvalidOperationException("Invalid bundle instance (object may have been disposed or released)");
                }
                throw new ArgumentException("Invalid parameter");
            }
            else if ((BundleError)error == BundleError.KeyNotAvailable)
            {
                throw new ArgumentException("Key does not exist in the bundle");
            }
            else if ((BundleError)error == BundleError.KeyExists)
            {
                throw new ArgumentException("Key already exists");
            }
        }
    }
}
