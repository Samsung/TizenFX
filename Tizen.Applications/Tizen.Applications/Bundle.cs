using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// A Bundle object represents a bundle.
    /// A bundle holds items (key-value pairs) and can be used with other Tizen APIs.
    /// Keys can be used to access values.
    /// This class is accessed by using a constructor to create a new instance of this object.
    /// </summary>
    public class Bundle : IDisposable
    {
        private IntPtr _handle;
        private bool _disposed = false;
        private readonly HashSet<string> _keys;

        /// <summary>
        /// The Bundle constructor.
        /// </summary>
        public Bundle()
        {
            _handle = Interop.Bundle.Create();
            if ((BundleError)Internals.Errors.ErrorFacts.GetLastResult() == BundleError.OutOfMemory)
            {
                throw new InvalidOperationException("Out of memory");
            }
            _keys = new HashSet<string>();
        }

        internal Bundle(IntPtr handle)
        {
            if (handle != IntPtr.Zero)
            {
                _handle = handle;
                _disposed = true;
                _keys = new HashSet<string>();
                Interop.Bundle.Iterator iterator = (string key, int type, IntPtr keyval, IntPtr userData) =>
                {
                    _keys.Add(key);
                };

                Interop.Bundle.Foreach(_handle, iterator, IntPtr.Zero);
            }
            else
            {
                throw new ArgumentNullException("Invalid bundle");
            }
        }

        private enum BundleError
        {
            None = Internals.Errors.ErrorCode.None,
            OutOfMemory = Internals.Errors.ErrorCode.OutOfMemory,
            InvalidParameter = Internals.Errors.ErrorCode.InvalidParameter,
            KeyNotAvailable = Internals.Errors.ErrorCode.KeyNotAvailable,
            KeyExists = -0x01180000 | 0x01
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
        public IEnumerable<string> Keys
        {
            get
            {
                return _keys;
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
        public bool Contains(string key)
        {
            return _keys.Contains(key);
        }

        /// <summary>
        /// Adds an item into the bundle.
        /// </summary>
        /// <param name="key">The key to identify the item with. If an item with the key already exists in the Bundle, this method will not succeed.</param>
        /// <param name="value">The value of the item.</param>
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
                if ((BundleError)ret == BundleError.InvalidParameter)
                {
                    throw new ArgumentException("Invalid parameter (key may be null or empty string)");
                }
                if ((BundleError)ret == BundleError.OutOfMemory)
                {
                    throw new InvalidOperationException("Out of memory");
                }
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
        public void AddItem(string key, string value)
        {
            if (!_keys.Contains(key))
            {
                int ret = Interop.Bundle.AddString(_handle, key, value);
                if ((BundleError)ret == BundleError.InvalidParameter)
                {
                    throw new ArgumentException("Invalid parameter (key may be null or empty string)");
                }
                if ((BundleError)ret == BundleError.OutOfMemory)
                {
                    throw new InvalidOperationException("Out of memory");
                }
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
        public void AddItem(string key, IEnumerable<string> value)
        {
            if (!_keys.Contains(key))
            {
                string[] valueArray = value.ToArray();
                int ret = Interop.Bundle.AddStringArray(_handle, key, valueArray, valueArray.Count());
                if ((BundleError)ret == BundleError.InvalidParameter)
                {
                    throw new ArgumentException("Invalid parameter (key may be null or empty string)");
                }
                if ((BundleError)ret == BundleError.OutOfMemory)
                {
                    throw new InvalidOperationException("Out of memory");
                }
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
        public object GetItem(string key)
        {
            if (_keys.Contains(key))
            {
                int type = Interop.Bundle.GetType(_handle, key);
                switch (type)
                {
                    case (int)BundleType.String:
                        // get string
                        IntPtr stringPtr;
                        Interop.Bundle.GetString(_handle, key, out stringPtr);
                        return Marshal.PtrToStringAuto(stringPtr);

                    case (int)BundleType.StringArray:
                        // get string array
                        int stringArraySize;
                        IntPtr stringArrayPtr = Interop.Bundle.GetStringArray(_handle, key, out stringArraySize);
                        string[] stringArray;
                        IntPtrToStringArray(stringArrayPtr, stringArraySize, out stringArray);
                        return stringArray;

                    case (int)BundleType.Byte:
                        // get byte array
                        IntPtr byteArrayPtr;
                        int byteArraySize;
                        Interop.Bundle.GetByte(_handle, key, out byteArrayPtr, out byteArraySize);
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
        public bool TryGetItem(string key, out byte[] value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.Byte)
            {
                value = GetItem<byte[]>(key);
                return true;
            }
            else
            {
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
        public bool TryGetItem(string key, out string value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.String)
            {
                value = GetItem<string>(key);
                return true;
            }
            else
            {
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
        public bool TryGetItem(string key, out IEnumerable<string> value)
        {
            if (_keys.Contains(key) && Interop.Bundle.GetType(_handle, key) == (int)BundleType.StringArray)
            {
                value = GetItem<IEnumerable<string>>(key);
                return true;
            }
            else
            {
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
        public void RemoveItem(string key)
        {
            if (_keys.Contains(key))
            {
                Interop.Bundle.RemoveItem(_handle, key);
                _keys.Remove(key);
            }
            else
            {
                throw new ArgumentException("Key does not exist in the bundle (may be null or empty string)", "key");
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
}
