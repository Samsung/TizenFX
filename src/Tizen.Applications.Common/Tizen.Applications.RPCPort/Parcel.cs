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
using System.ComponentModel;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;

namespace Tizen.Applications.RPCPort
{
    /// <summary>
    /// This structure represents the time stamp.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class TimeStamp
    {
        /// <summary>
        /// Constructor with TimeStamp.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        internal TimeStamp(long second, long nanoSecond)
        {
            this.Second = second;
            this.NanoSecond = nanoSecond;
        }

        /// <summary>
        /// The seconds of TimeStamp.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public long Second
        {
            get;
            private set;
        }

        /// <summary>
        /// The nano seconds of TimeStamp.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public long NanoSecond
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// The class represents the header information of an RPC Parcel.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class ParcelHeader
    {
        internal IntPtr _handle;

        /// <summary>
        /// Constructor with Header
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        internal ParcelHeader()
        {
        }

        /// <summary>
        /// Sets tag of Header.
        /// </summary>
        /// <param name="tag">The tag of Header</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetTag(string tag)
        {
            var r = Interop.LibRPCPort.Parcel.SetTag(_handle, tag);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Gets tag of Header.
        /// </summary>
        /// <returns>Tag</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public string GetTag()
        {
            var r = Interop.LibRPCPort.Parcel.GetTag(_handle, out string tag);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();

            return tag;
        }

        /// <summary>
        /// Sets sequence number of Header.
        /// </summary>
        /// <param name="sequenceNumber">The seqence number of Header</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public void SetSequenceNumber(int sequenceNumber)
        {
            var r = Interop.LibRPCPort.Parcel.SetSeqNum(_handle, sequenceNumber);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Gets sequence number of Header.
        /// </summary>
        /// <returns>Sequence number</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public int GetSequenceNumber()
        {
            var r = Interop.LibRPCPort.Parcel.GetSeqNum(_handle, out int sequenceNumber);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();

            return sequenceNumber;
        }

        /// <summary>
        /// Gets time stamp of Header.
        /// </summary>
        /// <returns>Time stamp</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public TimeStamp GetTimeStamp()
        {
            Interop.Libc.TimeStamp time = new Interop.Libc.TimeStamp();

            var r = Interop.LibRPCPort.Parcel.GetTimeStamp(_handle, ref time);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();

            return new TimeStamp(time.sec.ToInt64(), time.nsec.ToInt64());
        }
    };

    /// <summary>
    /// The class that helps to perform marshalling and unmarshalling for RPC.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class Parcel : IDisposable
    {
        private IntPtr _handle;
        private ParcelHeader _header;

        /// <summary>
        /// Constructs a sub parcel from origin parcel.
        /// </summary>
        /// <param name="origin">The origin parcel.</param>
        /// <param name="startPos">The start position from origin parcel.</param>
        /// <param name="size">The size of the new parcel.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <exception cref="ArgumentException">Thrown when arguments are invalid.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Parcel(Parcel origin, uint startPos, uint size)
        {
            if (origin == null)
                throw new ArgumentException();

            Interop.LibRPCPort.ErrorCode error;

            error = Interop.LibRPCPort.Parcel.CreateFromParcel(out _handle, origin._handle, startPos, size);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Constructs a new instance of the Parcel class.
        /// </summary>
        /// <param name="withHeader">Determines whether the created parcel object includes a header or not.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal I/O error occurs during the construction process.</exception>
        /// <since_tizen> 11 </since_tizen>
        public Parcel(bool withHeader)
        {
            Interop.LibRPCPort.ErrorCode error;
            if (withHeader)
            {
                error = Interop.LibRPCPort.Parcel.Create(out _handle);
                if (error != Interop.LibRPCPort.ErrorCode.None)
                    throw new InvalidIOException();
            }
            else
            {
                error = Interop.LibRPCPort.Parcel.CreateWithoutHeader(out _handle);
                if (error != Interop.LibRPCPort.ErrorCode.None)
                    throw new InvalidIOException();
            }
        }

        /// <summary>
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Parcel() : this(true)
        {
        }

        /// <summary>
        /// Creates a new parcel object from a specified port object.
        /// </summary>
        /// <param name="port">The port object to create a parcel from.</param>
        /// <exception cref="InvalidIOException">An internal IO error occurred while creating the parcel.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Parcel(Port port)
        {
            if (port == null)
                throw new InvalidIOException();
            var r = Interop.LibRPCPort.Parcel.CreateFromPort(out _handle, port.Handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Constructs a new Parcel object from the specified raw bytes.
        /// </summary>
        /// <param name="bytes">An array of bytes that represents the content of the parcel.</param>
        /// <exception cref="InvalidOperationException">Thrown if an invalid argument is passed in or an internal I/O error occurs.</exception>
        /// <since_tizen> 9 </since_tizen>
        public Parcel(byte[] bytes)
        {
            if (bytes == null)
                throw new InvalidIOException();
            var r = Interop.LibRPCPort.Parcel.CreateFromRaw(out _handle, bytes, (uint)bytes.Length);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Converts the current parcel into its raw bytes representation.
        /// </summary>
        /// <returns>An array of bytes containing the contents of the parcel.</returns>
        /// <exception cref="InvalidIOException">Thrown if an internal I/O error occurs during conversion.</exception>
        /// <since_tizen> 9 </since_tizen>
        public byte[] ToBytes()
        {
            var r = Interop.LibRPCPort.Parcel.GetRaw(_handle, out IntPtr raw, out uint size);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
            byte[] bytes = new byte[size];
            Marshal.Copy(raw, bytes, 0, (int)size);
            return bytes;
        }

        /// <summary>
        /// Sends parcel data through the specified port.
        /// </summary>
        /// <param name="port">The RPC port object for writing data.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public void Send(Port p)
        {
            if (p == null)
                throw new InvalidIOException();
            var r = Interop.LibRPCPort.Parcel.Send(_handle, p.Handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Writes a single byte value into the parcel object.
        /// </summary>
        /// <param name="b">The byte value to be written into the parcel object.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteByte(byte b)
        {
            Interop.LibRPCPort.Parcel.WriteByte(_handle, b);
        }

        /// <summary>
        /// Writes a single signed byte value into the parcel object.
        /// </summary>
        /// <param name="b">The signed byte value to be written into the parcel object.</param>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteSByte(sbyte b)
        {
            Interop.LibRPCPort.Parcel.WriteByte(_handle, (byte)b);
        }

        /// <summary>
        /// Writes a short value into parcel object.
        /// </summary>
        /// <param name="b">The short data to write.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteShort(short b)
        {
            Interop.LibRPCPort.Parcel.WriteInt16(_handle, b);
        }

        /// <summary>
        /// Writes a unsigned short value into parcel object.
        /// </summary>
        /// <param name="b">The unsigned short data to write.</param>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteUShort(ushort b)
        {
            var bytes = BitConverter.GetBytes(b);
            Write(bytes);
        }

        /// <summary>
        /// Writes an integer value into the parcel object.
        /// </summary>
        /// <param name="b">The integer value to write.</param>
        /// <example>
        /// Here's an example showing how to write an integer value into a parcel object:
        ///
        /// <code>
        /// // Create a new parcel object
        /// Parcel parcel = new Parcel();
        ///
        /// // Write an integer value into the parcel object
        /// parcel.WriteInt(42);
        ///
        /// // Do something else with the parcel object...
        /// ...
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public void WriteInt(int b)
        {
            Interop.LibRPCPort.Parcel.WriteInt32(_handle, b);
        }

        /// <summary>
        /// Writes an unsigned integer value into the parcel object.
        /// </summary>
        /// <param name="b">The unsigned integer value to write.</param>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteUInt(uint b)
        {
            var bytes = BitConverter.GetBytes(b);
            Write(bytes);
        }

        /// <summary>
        /// Writes a long value into the parcel object.
        /// </summary>
        /// <param name="b">The long data to write.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteLong(long b)
        {
            Interop.LibRPCPort.Parcel.WriteInt64(_handle, b);
        }

        /// <summary>
        /// Writes an unsigned long value into the parcel object.
        /// </summary>
        /// <param name="b">The unsigned long data to write.</param>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteULong(ulong b)
        {
            var bytes = BitConverter.GetBytes(b);
            Write(bytes);
        }

        /// <summary>
        /// Writes a float value into the parcel object.
        /// </summary>
        /// <param name="b">The float data to write into the parcel object.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteFloat(float b)
        {
            Interop.LibRPCPort.Parcel.WriteFloat(_handle, b);
        }

        /// <summary>
        /// Writes a double value into the parcel object.
        /// </summary>
        /// <param name="b">The double data to write.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteDouble(double b)
        {
            Interop.LibRPCPort.Parcel.WriteDouble(_handle, b);
        }

        /// <summary>
        /// Writes a string value into the parcel object.
        /// </summary>
        /// <param name="b">The string data to be written into the parcel object.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteString(string b)
        {
            Interop.LibRPCPort.Parcel.WriteString(_handle, b);
        }

        /// <summary>
        /// Writes a boolean value into the parcel object.
        /// </summary>
        /// <param name="b">The boolean value to write.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBool(bool b)
        {
            Interop.LibRPCPort.Parcel.WriteBool(_handle, b);
        }

        /// <summary>
        /// Writes a Bundle data into the parcel object.
        /// </summary>
        /// <param name="b">The Bundle object to write.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBundle(Bundle b)
        {
            if (b == null)
            {
                return;
            }

            Interop.LibRPCPort.Parcel.WriteBundle(_handle, b.SafeBundleHandle.DangerousGetHandle());
        }

        /// <summary>
        /// Writes a count of an array into the parcel object.
        /// </summary>
        /// <param name="cnt">The number of elements in the array.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteArrayCount(int cnt)
        {
            Interop.LibRPCPort.Parcel.WriteArrayCount(_handle, cnt);
        }

        /// <summary>
        /// Reads a byte value from the parcel object.
        /// </summary>
        /// <returns>The byte value.</returns>
        /// <since_tizen> 5 </since_tizen>
        public byte ReadByte()
        {
            Interop.LibRPCPort.Parcel.ReadByte(_handle, out byte b);
            return b;
        }

        /// <summary>
        /// Reads a signed byte value from the parcel object.
        /// </summary>
        /// <returns>The byte value.</returns>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public sbyte ReadSByte()
        {
            Interop.LibRPCPort.Parcel.ReadByte(_handle, out byte b);
            return (sbyte)b;
        }

        /// <summary>
        /// Reads a short value from the parcel object.
        /// </summary>
        /// <returns>The short data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public short ReadShort()
        {
            Interop.LibRPCPort.Parcel.ReadInt16(_handle, out short b);
            return b;
        }

        /// <summary>
        /// Reads an unsigned short value from the parcel object.
        /// </summary>
        /// <returns>The unsigned short data.</returns>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ushort ReadUShort()
        {
            var bytes = Read(sizeof(ushort));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt16(bytes, 0);
        }

        /// <summary>
        /// Reads an integer value from the parcel object.
        /// </summary>
        /// <returns>The integer data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadInt()
        {
            Interop.LibRPCPort.Parcel.ReadInt32(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Reads an unsigned integer value from the parcel object.
        /// </summary>
        /// <returns>The integer data.</returns>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint ReadUInt()
        {
            var bytes = Read(sizeof(uint));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt32(bytes, 0);
        }

        /// <summary>
        /// Reads a long value from the parcel object.
        /// </summary>
        /// <returns>The long data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public long ReadLong()
        {
            Interop.LibRPCPort.Parcel.ReadInt64(_handle, out long b);
            return b;
        }

        /// <summary>
        /// Reads an unsigned long value from the parcel object.
        /// </summary>
        /// <returns>The unsigned long data.</returns>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ulong ReadULong()
        {
            var bytes = Read(sizeof(ulong));
            if (BitConverter.IsLittleEndian)
                Array.Reverse(bytes);
            return BitConverter.ToUInt64(bytes, 0);
        }

        /// <summary>
        /// Reads a float value from the parcel object.
        /// </summary>
        /// <returns>The float data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public float ReadFloat()
        {
            Interop.LibRPCPort.Parcel.ReadFloat(_handle, out float b);
            return b;
        }

        /// <summary>
        /// Reads a double value from the parcel object.
        /// </summary>
        /// <returns>The double data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public double ReadDouble()
        {
            Interop.LibRPCPort.Parcel.ReadDouble(_handle, out double b);
            return b;
        }

        /// <summary>
        /// Reads a string value from the parcel object.
        /// </summary>
        /// <returns>The string data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string ReadString()
        {
            Interop.LibRPCPort.Parcel.ReadString(_handle, out string b);
            return b;
        }

        /// <summary>
        /// Reads a boolean value from the parcel object.
        /// </summary>
        /// <returns>The boolean data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool ReadBool()
        {
            Interop.LibRPCPort.Parcel.ReadBool(_handle, out bool b);
            return b;
        }

        /// <summary>
        /// Reads a Bundle value from the parcel object.
        /// </summary>
        /// <returns>The Bundle data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public Bundle ReadBundle()
        {
            Interop.LibRPCPort.Parcel.ReadBundle(_handle, out IntPtr b);

            Bundle bundle = null;
            using (SafeBundleHandle safeBundleHandle = new SafeBundleHandle(b, true))
            {
                bundle = new Bundle(safeBundleHandle);
            }

            return bundle;
        }

        /// <summary>
        /// Reads a count of an array from a parcel object.
        /// </summary>
        /// <returns>The number of elements in the array.</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadArrayCount()
        {
            Interop.LibRPCPort.Parcel.ReadArrayCount(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Writes bytes into the parcel object.
        /// </summary>
        /// <param name="bytes">An array of bytes containing the data to be written.</param>
        /// <since_tizen> 5 </since_tizen>
        public void Write(byte[] bytes)
        {
            if (bytes == null)
            {
                return;
            }

            Interop.LibRPCPort.Parcel.Write(_handle, bytes, bytes.Length);
        }

        /// <summary>
        /// Reads bytes from the parcel object.
        /// </summary>
        /// <param name="size">The number of bytes to read.</param>
        /// <returns>An array of bytes that were read from the parcel.</returns>
        /// <since_tizen> 5 </since_tizen>
        public byte[] Read(int size)
        {
            var ret = new byte[size];
            Interop.LibRPCPort.Parcel.Read(_handle, ret, size);
            return ret;
        }

        /// <summary>
        /// Gets header of rpc port parcel.
        /// </summary>
        /// <returns>Parcel header</returns>
        /// <since_tizen> 9 </since_tizen>
        public ParcelHeader GetHeader()
        {
            if (_header == null) {
                Interop.LibRPCPort.Parcel.GetHeader(_handle, out IntPtr handle);
                _header = new ParcelHeader() {
                    _handle = handle
                };
            }

            return _header;
        }

        /// <summary>
        /// Reserves bytes to write later.
        /// <param name="size">The bytes to reserve.</param>
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reserve(uint size)
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.Reserve(_handle, size);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Pin the memory. Once it is called, the capacity would not be changed.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Pin()
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.Pin(_handle);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Gets the reader pointer of the parcel to the start.
        /// </summary>
        /// <returns>The position of the reader</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetReader()
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.GetReader(_handle, out uint reader);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
            return reader;
        }

        /// <summary>
        /// Sets the reader pointer of the parcel to the start.
        /// </summary>
        /// <param name="pos">The position to read.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetReader(uint pos)
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.SetReader(_handle, pos);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Gets the size of the raw data of the parcel.
        /// </summary>
        /// <returns>The size of data</returns>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint GetDataSize()
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.GetDataSize(_handle, out uint size);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();

            return size;
        }

        /// <summary>
        /// Sets the size of the raw data of the parcel.
        /// </summary>
        /// <param name="size">The size of data.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 10 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDataSize(uint size)
        {
            Interop.LibRPCPort.ErrorCode error;
            error = Interop.LibRPCPort.Parcel.SetDataSize(_handle, size);
            if (error != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        #region IDisposable Support
        private bool disposedValue = false;

#pragma warning disable CA1063
        private void Dispose(bool disposing)
#pragma warning restore CA1063
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
        /// Finalizer of the class Parcel.
        /// </summary>
        ~Parcel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Release all the resources used by the class Parcel.
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
