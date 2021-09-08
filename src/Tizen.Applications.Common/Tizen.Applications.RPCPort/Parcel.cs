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
        /// The second of TimeStamp.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public long Second
        {
            get;
            private set;
        }

        /// <summary>
        /// The nano second of TimeStamp.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public long NanoSecond
        {
            get;
            private set;
        }
    }

    /// <summary>
    /// The class is the header that has the Parcel's information.
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

            return new TimeStamp(time.sec, time.nsec);
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
        /// Constructor for this class.
        /// </summary>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
        /// <since_tizen> 5 </since_tizen>
        public Parcel()
        {
            var r = Interop.LibRPCPort.Parcel.Create(out _handle);
            if (r != Interop.LibRPCPort.ErrorCode.None)
                throw new InvalidIOException();
        }

        /// <summary>
        /// Constructor with port object.
        /// </summary>
        /// <param name="port">Port object.</param>
        /// <exception cref="InvalidIOException">Thrown when an internal IO error occurs.</exception>
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
        /// Sends parcel data through the port.
        /// </summary>
        /// <param name="p">The RPC port object for writing data.</param>
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
        /// Writes a byte value into parcel object.
        /// </summary>
        /// <param name="b">byte data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteByte(byte b)
        {
            Interop.LibRPCPort.Parcel.WriteByte(_handle, b);
        }

        /// <summary>
        /// Writes a short value into parcel object.
        /// </summary>
        /// <param name="b">short data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteShort(short b)
        {
            Interop.LibRPCPort.Parcel.WriteInt16(_handle, b);
        }

        /// <summary>
        /// Writes an int value into parcel object.
        /// </summary>
        /// <param name="b">int data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteInt(int b)
        {
            Interop.LibRPCPort.Parcel.WriteInt32(_handle, b);
        }

        /// <summary>
        /// Writes a long value into parcel object.
        /// </summary>
        /// <param name="b">long data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteLong(long b)
        {
            Interop.LibRPCPort.Parcel.WriteInt64(_handle, b);
        }

        /// <summary>
        /// Writes a float value into parcel object.
        /// </summary>
        /// <param name="b">float data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteFloat(float b)
        {
            Interop.LibRPCPort.Parcel.WriteFloat(_handle, b);
        }

        /// <summary>
        /// Writes a double value into parcel object.
        /// </summary>
        /// <param name="b">double data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteDouble(double b)
        {
            Interop.LibRPCPort.Parcel.WriteDouble(_handle, b);
        }

        /// <summary>
        /// Writes a string value into parcel object.
        /// </summary>
        /// <param name="b">string data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteString(string b)
        {
            Interop.LibRPCPort.Parcel.WriteString(_handle, b);
        }

        /// <summary>
        /// Writes a bool value into parcel object.
        /// </summary>
        /// <param name="b">bool data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBool(bool b)
        {
            Interop.LibRPCPort.Parcel.WriteBool(_handle, b);
        }

        /// <summary>
        /// Writes a Bundle data into parcel object.
        /// </summary>
        /// <param name="b">Bundle data.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteBundle(Bundle b)
        {
            Interop.LibRPCPort.Parcel.WriteBundle(_handle, b.SafeBundleHandle.DangerousGetHandle());
        }

        /// <summary>
        /// Writes a count of an array into parcel object.
        /// </summary>
        /// <param name="cnt">Array count.</param>
        /// <since_tizen> 5 </since_tizen>
        public void WriteArrayCount(int cnt)
        {
            Interop.LibRPCPort.Parcel.WriteArrayCount(_handle, cnt);
        }

        /// <summary>
        /// Reads a byte value from parcel object.
        /// </summary>
        /// <returns>byte data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public byte ReadByte()
        {
            Interop.LibRPCPort.Parcel.ReadByte(_handle, out byte b);
            return b;
        }

        /// <summary>
        /// Reads a short value from parcel object.
        /// </summary>
        /// <returns>short data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public short ReadShort()
        {
            Interop.LibRPCPort.Parcel.ReadInt16(_handle, out short b);
            return b;
        }

        /// <summary>
        /// Reads an int value from parcel object.
        /// </summary>
        /// <returns>int data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadInt()
        {
            Interop.LibRPCPort.Parcel.ReadInt32(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Reads a long value from parcel object.
        /// </summary>
        /// <returns>long data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public long ReadLong()
        {
            Interop.LibRPCPort.Parcel.ReadInt64(_handle, out long b);
            return b;
        }

        /// <summary>
        /// Reads a float value from parcel object.
        /// </summary>
        /// <returns>float data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public float ReadFloat()
        {
            Interop.LibRPCPort.Parcel.ReadFloat(_handle, out float b);
            return b;
        }

        /// <summary>
        /// Reads a double value from parcel object.
        /// </summary>
        /// <returns>double data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public double ReadDouble()
        {
            Interop.LibRPCPort.Parcel.ReadDouble(_handle, out double b);
            return b;
        }

        /// <summary>
        /// Reads a string value from parcel object.
        /// </summary>
        /// <returns>string data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public string ReadString()
        {
            Interop.LibRPCPort.Parcel.ReadString(_handle, out string b);
            return b;
        }

        /// <summary>
        /// Reads a bool value from parcel object.
        /// </summary>
        /// <returns>bool data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public bool ReadBool()
        {
            Interop.LibRPCPort.Parcel.ReadBool(_handle, out bool b);
            return b;
        }

        /// <summary>
        /// Reads a Bundle value from parcel object.
        /// </summary>
        /// <returns>Bundle data.</returns>
        /// <since_tizen> 5 </since_tizen>
        public Bundle ReadBundle()
        {
            Interop.LibRPCPort.Parcel.ReadBundle(_handle, out IntPtr b);

            return new Bundle(new SafeBundleHandle(b, true));
        }

        /// <summary>
        /// Reads a count of an array from parcel object.
        /// </summary>
        /// <returns>Array count.</returns>
        /// <since_tizen> 5 </since_tizen>
        public int ReadArrayCount()
        {
            Interop.LibRPCPort.Parcel.ReadArrayCount(_handle, out int b);
            return b;
        }

        /// <summary>
        /// Writes bytes into parcel object.
        /// </summary>
        /// <param name="bytes">Array of bytes.</param>
        /// <since_tizen> 5 </since_tizen>
        public void Write(byte[] bytes)
        {
            Interop.LibRPCPort.Parcel.Write(_handle, bytes, bytes.Length);
        }

        /// <summary>
        /// Reads bytes from parcel object.
        /// </summary>
        /// <param name="size">Bytes to read.</param>
        /// <returns>Array of bytes.</returns>
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
