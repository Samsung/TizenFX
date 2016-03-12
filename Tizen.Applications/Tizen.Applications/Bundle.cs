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
        internal IntPtr _handle;
        private bool _disposed = false;
        private readonly List<string> _keys;

        /// <summary>
        /// The Bundle constructor.
        /// </summary>
        public Bundle()
        {
            _keys = new List<string>();
            _handle = Interop.Bundle.Create();
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
            StringArray = BundleType.String | BundleTypeProperty.Array | BundleTypeProperty.Measurable,
            Byte = 2,
            ByteArray = BundleType.Byte | BundleTypeProperty.Array
        }

        /// <summary>
        /// The number of items in a Bundle object.
        /// </summary>
        public int Count
        {
            get
            {
                return Interop.Bundle.Count(_handle);
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
                // TODO: validate offset and count
                // Code is in Interop file because it is unsafe
                Interop.Bundle.UnsafeCode.AddItem(_handle, key, value, offset, count);
                _keys.Add(key);
            }
            else
            {
                // TODO: handle when key already exists
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
                Interop.Bundle.AddString(_handle, key, value);
                _keys.Add(key);
            }
            else
            {
                // TODO: handle when key already exists
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
                Interop.Bundle.AddStringArray(_handle, key, valueArray, valueArray.Count());
                _keys.Add(key);
            }
            else
            {
                // TODO: handle when key already exists
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
                    string stringResult = Marshal.PtrToStringAuto(stringPtr);
                    return stringResult;

                    case (int)BundleType.StringArray:
                    // get string array
                    IntPtr stringArrayPtr;
                    int stringArraySize;
                    stringArrayPtr = Interop.Bundle.GetStringArray(_handle, key, out stringArraySize);
                    string[] stringArray;
                    IntPtrToStringArray(stringArrayPtr, stringArraySize, out stringArray);
                    return stringArray;

                    case (int)BundleType.Byte:
                    case (int)BundleType.ByteArray:
                    // get byte array
                    IntPtr byteArrayPtr;
                    int byteArraySize;
                    Interop.Bundle.GetByte(_handle, key, out byteArrayPtr, out byteArraySize);
                    byte[] byteArray = new byte[byteArraySize];
                    Marshal.Copy(byteArrayPtr, byteArray, 0, byteArraySize);
                    return byteArray;

                    default:
                    return "PROBLEM"; // TODO: Handle this
                }
            }
            else
            {
                return "PROBLEM"; // TODO: handle when key does not exist
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
                Interop.Bundle.DeleteItem(_handle, key);
                _keys.Remove(key);
            }
            else
            {
                // TODO: handle when key does not exist
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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
