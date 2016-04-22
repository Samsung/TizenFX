// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Tizen.Internals.Errors;

namespace Tizen.Applications
{
    /// <summary>
    /// A Bundle object represents a bundle.
    /// A bundle holds items (key-value pairs) and can be used with other Tizen APIs.
    /// Keys can be used to access values.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// A bundle instance is not guaranteed to be thread safe if the instance is modified by multiple threads.
    /// </summary>
    public class Bundle : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed = false;
        private readonly HashSet<string> _keys;

        /// <summary>
        /// The Bundle constructor.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// </code>
        public Bundle()
        {
            _handle = Interop.Bundle.Create();
            BundleErrorFactory.CheckAndThrowException(ErrorFacts.GetLastResult(), _handle);
            _keys = new HashSet<string>();
        }

        static internal Bundle MakeRetainedBundle(IntPtr handle)
        {
            IntPtr clonedHandle = Interop.Bundle.Clone(handle);
            return new Bundle(clonedHandle, true);
        }

        internal Bundle(IntPtr handle, bool ownership = false)
        {
            if (handle != IntPtr.Zero)
            {
                _handle = handle;
                if (!ownership)
                    _disposed = true;
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
            else
            {
                throw new ArgumentNullException("Invalid bundle");
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
        /// The number of items in a Bundle object.
        /// </summary>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// Console.WriteLine("There are {0} items in the bundle", bundle.Count);
        /// </code>
        public int Count
        {
            get
            {
                return _keys.Count;
            }
        }

        /// <summary>
        /// The keys in a Bundle object.
        /// </summary>
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
        public IEnumerable<string> Keys
        {
            get
            {
                return _keys;
            }
        }

        internal IntPtr Handle
        {
            get
            {
                return _handle;
            }
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
        /// Checks whether the bundle contains an item with a specified key.
        /// </summary>
        /// <param name="key">The key to check for.</param>
        /// <returns>true if the bundle contains the key. false otherwise.</returns>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// if (bundle.Contains("string"))
        /// {
        ///     string aValue = bundle.GetItem<string/>("string");
        ///     Console.WriteLine(aValue);
        /// }
        /// </code>
        public bool Contains(string key)
        {
            return _keys.Contains(key);
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the Bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// byte[] byteArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// bundle.AddItem("byte_array", byteArray);
        /// </code>
        public void AddItem(string key, byte[] value)
        {
            AddItem(key, value, 0, value.Length);
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the Bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <param name="offset">The zero-based byte offset in value from which to add to the bundle.</param>
        /// <param name="count">The maximum number of bytes to add to the bundle starting with offset.</param>
        /// <exception cref="System.ArgumentOutOfRangeException">Thrown when the offset or count is out of range.</exception>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// byte[] byteArray = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
        /// bundle.AddItem("byte_array", byteArray, 2, 3);
        /// </code>
        public void AddItem(string key, byte[] value, int offset, int count)
        {
            if (!_keys.Contains(key))
            {
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
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the Bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// </code>
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
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the Bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
        /// <exception cref="System.ArgumentException">Thrown when the key already exists or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when out of memory or when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// </code>
        public void AddItem(string key, IEnumerable<string> value)
        {
            if (!_keys.Contains(key))
            {
                string[] valueArray = value.ToArray();
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
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// if (bundle.Contains("string"))
        /// {
        ///     object aValue = bundle.GetItem("string");
        ///     if (bundle.Is<string/>("string");)
        ///     {
        ///         string aString = (string)aValue;
        ///         Console.WriteLine(aString);
        ///     }
        /// }
        /// </code>
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
                        return Marshal.PtrToStringAuto(stringPtr);

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
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// if (bundle.Is<string/>("string_array"))
        /// {
        ///     Console.WriteLine("It is a string");
        ///     Console.WriteLine(bundle.GetItem<string/>("string_array"));
        /// }
        /// else if (bundle.Is<string[]/>("string_array"))
        /// {
        ///     Console.WriteLine("It is a string[]");
        ///     string[] anArray = bundle.GetItem<string[]/>("string_array");
        ///     foreach (string value in anArray)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
        public T GetItem<T>(string key)
        {
            return (T)GetItem(key);
        }

        /// <summary>
        /// Gets the value of a bundle item with a specified key.
        /// </summary>
        /// <param name="key">The key of the bundle item whose value is desired.</param>
        /// <param name="value">The value of the bundle item. If the key does not exist or the type of this parameter is incorrect, it is the default value for the value parameter type.</param>
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter. false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
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
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter. false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// bundle.AddItem("string", "a_string");
        /// string aString;
        /// if (bundle.TryGetItem("string", out aString))
        /// {
        ///     Console.WriteLine(aString);
        /// }
        /// </code>
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
        /// <returns>true if an item with the key exists and if the value is the same type as the output value parameter. false otherwise.</returns>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// System.Collections.Generic.IEnumerable<string> aStringArray;
        /// if (bundle.TryGetItem("string", out aStringArray))
        /// {
        ///     foreach (string value in aStringArray)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
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
        /// <returns>true if the item is of the specified type. false otherwise.</returns>
        /// <exception cref="System.ArgumentException">Thrown when the key does not exist or when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
        /// <code>
        /// Tizen.Applications.Bundle bundle = new Tizen.Applications.Bundle();
        /// string[] stringArray = { "a", "b", "c" };
        /// bundle.AddItem("string_array", stringArray);
        /// if (bundle.Is<string[]/>("string_array"))
        /// {
        ///     Console.WriteLine("It is a string[]");
        ///     string[] anArray = bundle.GetItem<string[]/>("string_array");
        ///     foreach (string value in anArray)
        ///     {
        ///         Console.WriteLine(value);
        ///     }
        /// }
        /// </code>
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
                        return typeof(T).IsAssignableFrom(typeof(string[]));

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
        /// Removes a a bundle item with a specific key from a Bundle.
        /// </summary>
        /// <param name="key">The key of the item to delete.</param>
        /// <returns>true if the item is successfully found and removed. false otherwise (even if the item is not found).</returns>
        /// <exception cref="System.ArgumentException">Thrown when there is an invalid parameter.</exception>
        /// <exception cref="System.InvalidOperationException">Thrown when the Bundle instance has been disposed.</exception>
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
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable objects. If false, does not dispose disposable objects.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    // to be used if there are any other disposable objects
                }
                if (_handle != IntPtr.Zero)
                {
                    Interop.Bundle.Free(_handle);
                    _handle = IntPtr.Zero;
                }

                _disposed = true;
            }
        }

        /// <summary>
        /// Destructor of the Bundle class.
        /// </summary>
        ~Bundle()
        {
            Dispose(false);
        }

        private void IntPtrToStringArray(IntPtr unmanagedArray, int size, out string[] managedArray)
        {
            managedArray = new string[size];
            IntPtr[] IntPtrArray = new IntPtr[size];

            Marshal.Copy(unmanagedArray, IntPtrArray, 0, size);

            for (int iterator = 0; iterator < size; iterator++)
            {
                managedArray[iterator] = Marshal.PtrToStringAuto(IntPtrArray[iterator]);
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

        static internal void CheckAndThrowException(int error, IntPtr handle)
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
                if (handle == IntPtr.Zero)
                {
                    throw new InvalidOperationException("Invalid bundle instance (object may have been disposed or released)");
                }
                throw new ArgumentException("Invalid parameter");
            }
            else if ((BundleError)error == BundleError.KeyNotAvailable)
            {
                throw new ArgumentException("Key does not exist in the bundle", "key");
            }
            else if ((BundleError)error == BundleError.KeyExists)
            {
                throw new ArgumentException("Key already exists", "key");
            }
        }
    }
}
