/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

namespace Tizen.Applications
{
    /// <summary>
    /// The class that helps to perform marshalling and unmarshalling.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class Parcel : IDisposable
    {
        private readonly SafeParcelHandle _handle;

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficient.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Parcel()
        {
            var ret = Interop.Parcel.Create(out _handle);
            if (ret != Interop.Parcel.ErrorCode.None)
                throw ParcelErrorFactory.GetException(ret, "Parcel() is failed.");
        }

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="ArgumentException">Thrown when the handle is null.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when the memory is insufficent.</exception>
        /// <param name="handle">SafeParcelHandle</param>
        /// <since_tizen> 9 </since_tizen>
        public Parcel(SafeParcelHandle handle)
        {
            if (handle == null)
            {
                throw new ArgumentException("handle is null");
            }
            
            Interop.Parcel.ErrorCode err = Interop.Parcel.DangerousClone(handle.DangerousGetHandle(), out _handle);
            if (err != Interop.Parcel.ErrorCode.None)
            {
                throw ParcelErrorFactory.GetException(err, "Failed to clone parcel handle.");
            }
        }

        /// <summary>
        /// Gets the SafeParcelHandle instance.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public SafeParcelHandle SafeParcelHandle
        {
            get
            {
                return _handle;
            }
        }

        /// <summary>
        /// Writes a boolean value into parcel object.
        /// </summary>
        /// <param name="val">boolean data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteBool(bool val)
        {
            Interop.Parcel.WriteBool(_handle, val);
        }

        /// <summary>
        /// Writes a byte value into parcel object.
        /// </summary>
        /// <param name="val">byte data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteByte(byte val)
        {
            Interop.Parcel.WriteByte(_handle, val);
        }

        /// <summary>
        /// Writes an unsigned short value into parcel object.
        /// </summary>
        /// <param name="val">unsigned short data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteUInt16(UInt16 val)
        {
            Interop.Parcel.WriteUInt16(_handle, val);
        }

        /// <summary>
        /// Writes an unsigned integer value into parcel object.
        /// </summary>
        /// <param name="val">unsigned integer data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteUInt32(UInt32 val)
        {
            Interop.Parcel.WriteUInt32(_handle, val);
        }

        /// <summary>
        /// Writes an unsigned long long integer value into parcel object.
        /// </summary>
        /// <param name="val">unsinged long long integer data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteUInt64(UInt64 val)
        {
            Interop.Parcel.WriteUInt64(_handle, val);
        }

        /// <summary>
        /// Writes a signed short value into parcel object.
        /// </summary>
        /// <param name="val">signed short data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WirteInt16(Int16 val)
        {
            Interop.Parcel.WriteInt16(_handle, val);
        }

        /// <summary>
        /// Writes a signed integer value into parcel object.
        /// </summary>
        /// <param name="val">signed integer data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteInt32(Int32 val)
        {
            Interop.Parcel.WriteInt32(_handle, val);
        }

        /// <summary>
        /// Writes a signed long long integer value into parcel object.
        /// </summary>
        /// <param name="val">signed long long integer data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteInt64(Int64 val)
        {
            Interop.Parcel.WriteInt64(_handle, val);
        }

        /// <summary>
        /// Writes a string value into parcel object.
        /// </summary>
        /// <param name="str">string data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteString(string str)
        {
            Interop.Parcel.WriteString(_handle, str);
        }

        /// <summary>
        /// Writes a bundle object into parcel object.
        /// </summary>
        /// <param name="b">Bundle data</param>
        /// <since_tizen> 9 </since_tizen>
        public void WriteBundle(Bundle b)
        {
            Interop.Parcel.WriteBundle(_handle, b.SafeBundleHandle.DangerousGetHandle());
        }

        /// <summary>
        /// Reads a boolean value from parcel object.
        /// </summary>
        /// <returns>boolean data</returns>
        /// <since_tizen> 9 </since_tizen>
        public bool ReadBool()
        {
            Interop.Parcel.ReadBool(_handle, out bool val);
            return val;
        }

        /// <summary>
        /// Reads a byte value from parcel object.
        /// </summary>
        /// <returns>byte data</returns>
        /// <since_tizen> 9 </since_tizen>
        public byte ReadByte()
        {
            Interop.Parcel.ReadByte(_handle, out byte val);
            return val;
        }

        /// <summary>
        /// Reads an unsigned short value from parcel object.
        /// </summary>
        /// <returns>unsigned short data</returns>
        /// <since_tizen> 9 </since_tizen>
        public UInt16 ReadUInt16()
        {
            Interop.Parcel.ReadUInt16(_handle, out UInt16 val);
            return val;
        }

        /// <summary>
        /// Reads an unsigned integer value from parcel object.
        /// </summary>
        /// <returns>unsigned integer data</returns>
        /// <since_tizen> 9 </since_tizen>
        public UInt32 ReadUInt32()
        {
            Interop.Parcel.ReadUInt32(_handle, out UInt32 val);
            return val;
        }

        /// <summary>
        /// Reads a unsigned long long integer value from parcel object.
        /// </summary>
        /// <returns>unsigned long long integer data</returns>
        /// <since_tizen> 9 </since_tizen>
        public UInt64 ReadUInt64()
        {
            Interop.Parcel.ReadUInt64(_handle, out UInt64 val);
            return val;
        }

        /// <summary>
        /// Reads a signed short value from parcel object.
        /// </summary>
        /// <returns>signed short data</returns>
        /// <since_tizen> 9 </since_tizen>
        public Int16 ReadInt16()
        {
            Interop.Parcel.ReadInt16(_handle, out Int16 val);
            return val;
        }

        /// <summary>
        /// Reads a signed integer value from parcel object.
        /// </summary>
        /// <returns>signed integer data</returns>
        /// <since_tizen> 9 </since_tizen>
        public Int32 ReadInt32()
        {
            Interop.Parcel.ReadInt32(_handle, out Int32 val);
            return val;
        }

        /// <summary>
        /// Reads a signed long long integer value from parcel object.
        /// </summary>
        /// <returns>signed long long integer data</returns>
        /// <since_tizen> 9 </since_tizen>
        public Int64 ReadInt64()
        {
            Interop.Parcel.ReadInt64(_handle, out Int64 val);
            return val;
        }

        /// <summary>
        /// Reads a float value from parcel object.
        /// </summary>
        /// <returns>float data</returns>
        /// <since_tizen> 9 </since_tizen>
        public float ReadFloat()
        {
            Interop.Parcel.ReadFloat(_handle, out float val);
            return val;
        }

        /// <summary>
        /// Reads a double value from parcel object.
        /// </summary>
        /// <returns>double data</returns>
        /// <since_tizen> 9 </since_tizen>
        public double ReadDouble()
        {
            Interop.Parcel.ReadDouble(_handle, out double val);
            return val;
        }

        /// <summary>
        /// Reads a string value from parcel object.
        /// </summary>
        /// <returns>string data</returns>
        /// <since_tizen> 9 </since_tizen>
        public string ReadString()
        {
            Interop.Parcel.ReadString(_handle, out string str);
            return str;
        }

        /// <summary>
        /// Reads a bundle object from parcel object.
        /// </summary>
        /// <returns>Bundle data</returns>
        /// <since_tizen> 9 </since_tizen>
        public Bundle ReadBundle()
        {
            Interop.Parcel.ReadBundle(_handle, out IntPtr b);
            var safeHandle = new SafeBundleHandle(b, true);
            var ret = new Bundle(safeHandle);
            safeHandle.Dispose();
            return ret;
        }

        /// <summary>
        /// Writes bytes into parcel object.
        /// </summary>
        /// <param name="bytes">bytes data</param>
        /// <since_tizen> 9 </since_tizen>
        public void Write(byte[] bytes)
        {
            Interop.Parcel.BurstWrite(_handle, bytes, (UInt32)bytes.Length);
        }

        /// <summary>
        /// Reads bytes from parcel object.
        /// </summary>
        /// <param name="size">size of bytes</param>
        /// <returns>bytes data</returns>
        public byte[] Read(UInt32 size)
        {
            var ret = new byte[size];
            Interop.Parcel.BurstRead(_handle, ret, size);
            return ret;
        }

        /// <summary>
        /// Returns the raw bytes of the parcel.
        /// </summary>
        /// <returns>raw bytes</returns>
        /// <since_tizen> 9 </since_tizen>
        public byte[] Marshall()
        {
            Interop.Parcel.GetRaw(_handle, out IntPtr raw, out UInt32 size);
            byte[] ret = new byte[size];
            Marshal.Copy((IntPtr)raw, (byte[])ret, 0, (int)size);
            return ret;
        }

        /// <summary>
        /// Sets the bytes in data to be the raw bytes of this parcel object.
        /// </summary>
        /// <param name="bytes">bytes data</param>
        /// <since_tizen> 9 </since_tizen>
        public void UnMarshall(byte[] bytes)
        {
            Interop.Parcel.Reset(_handle, bytes, (UInt32)bytes.Length);
        }

        /// <summary>
        /// Writes the parcelable data into parcel object.
        /// </summary>
        /// <param name="parcelable">Parcelable data</param>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Write(IParcelable parcelable)
        {
            if (parcelable == null)
            {
                throw new ArgumentException("parcelable is null");
            }

            parcelable.WriteToParcel(this);
        }

        /// <summary>
        /// Reads the parcelable data from parcel object.
        /// </summary>
        /// <param name="parcelable">Parcelable data</param>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void Read(IParcelable parcelable)
        {
            if (parcelable == null)
            {
                throw new ArgumentException("parcelable is null");
            }

            parcelable.ReadFromParcel(this);
        }

        #region IDisposable Support
        private bool disposedValue = false;

        /// <summary>
        /// Releases any unmanaged resources used by this object. Can also dispose any other disposable objects.
        /// </summary>
        /// <param name="disposing">If true, disposes any disposable object.</param>
        /// <since_tizen> 9 </since_tizen>
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    if (_handle != null && !_handle.IsInvalid)
                        _handle.Dispose();
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class Parcel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        ~Parcel()
        {
            Dispose(disposing: false);
        }

        /// <summary>
        /// Releases all the resources used by the class parcel.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>>
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
        #endregion

        internal static class ParcelErrorFactory
        {
            internal static Exception GetException(Interop.Parcel.ErrorCode err, string message)
            {
                string errMessage = string.Format("{0} err = {1}", message, err);
                switch (err)
                {
                    case Interop.Parcel.ErrorCode.NoData:
                    case Interop.Parcel.ErrorCode.IllegalByteSeq:
                        return new InvalidOperationException(errMessage);
                    case Interop.Parcel.ErrorCode.InvalidParameter:
                        return new ArgumentException(errMessage);
                    default:
                        return new OutOfMemoryException(errMessage);
                }
            }
        }
    }
}