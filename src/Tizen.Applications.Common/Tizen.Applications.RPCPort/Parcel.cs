/*
 * Copyright (c) 2018 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// The class for helping marshalling and unmarshalling for RPC
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Parcel : IDisposable
    {
        private IntPtr _handle;

        /// <summary>
        /// Constructor for this class
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when internal IO error happens</exception>
        /// <since_tizen> 5 </since_tizen>
        public Parcel()
        {
            var r = Interop.LibRPCPort.Parcel.Create(out _handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Constructor with Port object
        /// </summary>
        /// <param name="port">Port object</param>
        /// <exception cref="InvalidIOException">Thrown when internal IO error happens</exception>
        /// <since_tizen> 5 </since_tizen>
        public Parcel(Port port)
        {
            var r = Interop.LibRPCPort.Parcel.CreateFromPort(out _handle, port.Handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Sends parcel data through the port
        /// </summary>
        /// <param name="p">The RPC port object for writing data</param>
        /// <exception cref="InvalidIOException">Thrown when internal IO error happens</exception>
        /// <since_tizen> 5 </since_tizen>
        public void Send(Port p)
        {
            var r = Interop.LibRPCPort.Parcel.Send(_handle, p.Handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Writes 'byte' type value into Parcel object
        /// </summary>
        /// <param name="b">'byte' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteByte(byte b)
        {
            Interop.LibRPCPort.Parcel.WriteByte(_handle, b);
        }

        /// <summary>
        /// Writes 'short' type value into Parcel object
        /// </summary>
        /// <param name="b">'short' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteShort(short b)
        {
            Interop.LibRPCPort.Parcel.WriteInt16(_handle, b);
        }

        /// <summary>
        /// Writes 'int' type value into Parcel object
        /// </summary>
        /// <param name="b">'int' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteInt(int b)
        {
            Interop.LibRPCPort.Parcel.WriteInt32(_handle, b);
        }

        /// <summary>
        /// Writes a Long type value into Parcel handle
        /// </summary>
        /// <param name="b">'long' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteLong(long b)
        {
            Interop.LibRPCPort.Parcel.WriteInt64(_handle, b);
        }

        /// <summary>
        /// Writes a 'float' type value into Parcel handle
        /// </summary>
        /// <param name="b">'float' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteFloat(float b)
        {
            Interop.LibRPCPort.Parcel.WriteFloat(_handle, b);
        }

        /// <summary>
        /// Writes a 'double' type value into Parcel handle
        /// </summary>
        /// <param name="b">'double' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteDouble(double b)
        {
            Interop.LibRPCPort.Parcel.WriteDouble(_handle, b);
        }

        /// <summary>
        /// Writes a 'string' type value into Parcel handle
        /// </summary>
        /// <param name="b">'string' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteString(string b)
        {
            Interop.LibRPCPort.Parcel.WriteString(_handle, b);
        }

        /// <summary>
        /// Writes a 'bool' type value into Parcel handle
        /// </summary>
        /// <param name="b">'bool' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBool(bool b)
        {
            Interop.LibRPCPort.Parcel.WriteBool(_handle, b);
        }

        /// <summary>
        /// Writes a 'Bundle' type value into Parcel handle
        /// </summary>
        /// <param name="b">'Bundle' type data</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBundle(Bundle b)
        {
            Interop.LibRPCPort.Parcel.WriteBundle(_handle, b.SafeBundleHandle.DangerousGetHandle());
        }

        /// <summary>
        /// Writes a count for array into Parcel object
        /// </summary>
        /// <param name="cnt">Array count</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteArrayCount(int cnt)
        {
            Interop.LibRPCPort.Parcel.WriteArrayCount(_handle, cnt);
        }

        /// <summary>
        /// Reads 'byte' type value from Parcel object
        /// </summary>
        /// <returns>'byte' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public byte ReadByte()
        {
            Interop.LibRPCPort.Parcel.ReadByte(_handle, out byte b);
            return b;
        }

        /// <summary>
        /// Reads 'short' type value from Parcel object
        /// </summary>
        /// <returns>'short' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public short ReadShort()
        {
            Interop.LibRPCPort.Parcel.ReadInt16(_handle, out short b);
            return b;
        }

        /// <summary>
        /// Reads 'int' type value from Parcel object
        /// </summary>
        /// <returns>'int' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadInt()
        {
            Interop.LibRPCPort.Parcel.ReadInt32(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Reads 'long' type value from Parcel object
        /// </summary>
        /// <returns>'long' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public long ReadLong()
        {
            Interop.LibRPCPort.Parcel.ReadInt64(_handle, out long b);
            return b;
        }

        /// <summary>
        /// Reads 'float' type value from Parcel object
        /// </summary>
        /// <returns>'float' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public float ReadFloat()
        {
            Interop.LibRPCPort.Parcel.ReadFloat(_handle, out float b);
            return b;
        }

        /// <summary>
        /// Reads 'double' type value from Parcel object
        /// </summary>
        /// <returns>'double' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public double ReadDouble()
        {
            Interop.LibRPCPort.Parcel.ReadDouble(_handle, out double b);
            return b;
        }

        /// <summary>
        /// Reads 'string' type value from Parcel object
        /// </summary>
        /// <returns>'string' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public string ReadString()
        {
            Interop.LibRPCPort.Parcel.ReadString(_handle, out string b);
            return b;
        }

        /// <summary>
        /// Reads 'bool' type value from Parcel object
        /// </summary>
        /// <returns>'bool' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool ReadBool()
        {
            Interop.LibRPCPort.Parcel.ReadBool(_handle, out bool b);
            return b;
        }

        /// <summary>
        /// Reads 'Bundle' type value from Parcel object
        /// </summary>
        /// <returns>'Bundle' type data</returns>
        /// <since_tizen> 5 </since_tizen>
        public Bundle ReadBundle()
        {
            Interop.LibRPCPort.Parcel.ReadBundle(_handle, out IntPtr b);

            return new Bundle(new SafeBundleHandle(b, true));
        }

        /// <summary>
        /// Reads a count for array from Parcel object
        /// </summary>
        /// <returns>Array count</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadArrayCount()
        {
            Interop.LibRPCPort.Parcel.ReadArrayCount(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Writes bytes into Parcel object
        /// </summary>
        /// <param name="bytes">Array of bytes</param>
        /// <since_tizen> 5 </since_tizen>
        public void Write(byte[] bytes)
        {
            Interop.LibRPCPort.Parcel.Write(_handle, bytes, bytes.Length);
        }

        /// <summary>
        /// Reads bytes from Parcel object
        /// </summary>
        /// <param name="size">Bytes to read</param>
        /// <returns>Array of bytes</returns>
        /// <since_tizen> 5 </since_tizen>
        public byte[] Read(int size)
        {
            var ret = new byte[size];
            Interop.LibRPCPort.Parcel.Read(_handle, ret, size);
            return ret;
        }

        #region IDisposable Support
        private bool disposedValue = false;

        private void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                }

                if (_handle != IntPtr.Zero)
                {
                    Interop.LibRPCPort.Parcel.Destroy(_handle);
                    _handle = IntPtr.Zero;
                }

                disposedValue = true;
            }
        }

        /// <summary>
        /// Finalizer of the class Parcel
        /// </summary>
        ~Parcel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release all resources used by the class Parcel
        /// </summary>
        /// <since_tizen> 5 </since_tizen>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
