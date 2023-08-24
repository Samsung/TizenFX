/*
* Copyright (c) 2020 - 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using NativeUart = Interop.Peripheral.Uart;

namespace Tizen.Peripheral.Uart
{
    /// <summary>
    /// Enumeration for baud rate.
    /// </summary>
    public enum BaudRate
    {
        /// <summary>The number of signal in one second is 0.</summary>
        Rate0 = 0,

        /// <summary>The number of signal in one second is 50.</summary>
        Rate50,

        /// <summary>The number of signal in one second is 75.</summary>
        Rate75,

        /// <summary>The number of signal in one second is 110.</summary>
        Rate110,

        /// <summary>The number of signal in one second is 134.</summary>
        Rate134,

        /// <summary>The number of signal in one second is 150.</summary>
        Rate150,

        /// <summary>The number of signal in one second is 200.</summary>
        Rate200,

        /// <summary>The number of signal in one second is 300.</summary>
        Rate300,

        /// <summary>The number of signal in one second is 600.</summary>
        Rate600,

        /// <summary>The number of signal in one second is 1200.</summary>
        Rate1200,

        /// <summary>The number of signal in one second is 1800.</summary>
        Rate1800,

        /// <summary>The number of signal in one second is 2400.</summary>
        Rate2400,

        /// <summary>The number of signal in one second is 4800.</summary>
        Rate4800,

        /// <summary>The number of signal in one second is 9600.</summary>
        Rate9600,

        /// <summary>The number of signal in one second is 19200.</summary>
        Rate19200,

        /// <summary>The number of signal in one second is 38400.</summary>
        Rate38400,

        /// <summary>The number of signal in one second is 57600.</summary>
        Rate57600,

        /// <summary>The number of signal in one second is 115200.</summary>
        Rate115200,

        /// <summary>The number of signal in one second is 230400.</summary>
        Rate230400
    }

    /// <summary>
    /// Enumeration for byte size.
    /// </summary>
    public enum DataBits
    {
        /// <summary>5 data bits.</summary>
        Size5Bit = 0,

        /// <summary>6 data bits.</summary>
        Size6Bit,

        /// <summary>7 data bits.</summary>
        Size7Bit,

        /// <summary>8 data bits.</summary>
        Size8Bit
    }

    /// <summary>
    /// Enumeration for parity bit.
    /// </summary>
    public enum Parity
    {
        /// <summary>No parity is used.</summary>
        None = 0,

        /// <summary>Even parity is used.</summary>
        Even,

        /// <summary>Odd parity is used.</summary>
        Odd
    }

    /// <summary>
    /// Enumeration for stop bits.
    /// </summary>
    public enum StopBits
    {
        /// <summary>One stop bit.</summary>
        One = 0,

        /// <summary>Two stop bits.</summary>
        Two
    }

    /// <summary>
    /// Enumeration for hardware flow control.
    /// </summary>
    public enum HardwareFlowControl
    {
        /// <summary>No hardware flow control.</summary>
        None = 0,

        /// <summary>Automatic RTS/CTS hardware flow control.</summary>
        AutoRtsCts
    }

    /// <summary>
    /// Enumeration for software flow control.
    /// </summary>
    public enum SoftwareFlowControl
    {
        /// <summary>No software flow control.</summary>
        None = 0,

        /// <summary>XON/XOFF software flow control.</summary>
        XonXoff,
    }

    /// <summary>
    /// The class allows applications to communicate via UART platform's bus.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class SerialPort : IDisposable
    {
        private BaudRate _baudRate;
        private DataBits _dataBits;
        private Parity _parity;
        private StopBits _stopBits;
        private HardwareFlowControl _hardwareFlowControl;
        private SoftwareFlowControl _softwareFlowControl;
        private bool _disposed = false;

        /// <summary>
        /// Native handle to I2c.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;

        /// <summary>
        /// Opens the UART slave device.
        /// </summary>
        /// <param name="port">The UART port number that the slave device is connected.</param>
        public SerialPort(int port)
        {
            var ret = NativeUart.Open(port, out _handle);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Closes the UART slave device.
        /// </summary>
        ~SerialPort()
        {
            Dispose(false);
        }

        /// <summary>
        /// Closes the UART slave device.
        /// </summary>
        public void Close() => Dispose();

        /// <summary>
        /// Disposes Uart object.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes Uart object.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NativeUart.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// Reads the bytes data from the UART slave device.
        /// </summary>
        /// <param name="buffer">The output byte array.</param>
        /// <param name="offset">The offset in buffer at which to write the bytes.</param>
        /// <param name="count">The number of bytes to read.</param>
        /// <returns>The number of bytes read.</returns>
        public int Read(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (count > buffer.Length - offset)
                throw new Exception("Can not read more bytes than the buffer can hold.");
            byte[] tmpBuffer = new byte[count];
            var length = Convert.ToUInt32(count);
            var ret = NativeUart.Read(_handle, tmpBuffer, length);
            if (ret < Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
            Array.Copy(tmpBuffer, 0, buffer, offset, (int)ret);
            return (int)ret;
        }

        /// <summary>
        /// Writes the bytes data to the UART slave device.
        /// </summary>
        /// <param name="buffer">The byte array that contains the data to write to the device.</param>
        /// <param name="offset">The offset in buffer at which to begin copying bytes.</param>
        /// <param name="count">The number of bytes to write</param>
        public int Write(byte[] buffer, int offset, int count)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            if (count > buffer.Length - offset)
                throw new Exception("Can not write more bytes than the buffer holds.");
            byte[] tmpBuffer = new byte[count];
            Array.Copy(buffer, offset, tmpBuffer, 0, count);
            var length = Convert.ToUInt32(count);
            var ret = NativeUart.Write(_handle, tmpBuffer, length);
            if (ret < Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
            return (int)ret;
        }

        /// <summary>
        /// Sets or gets baud rate of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public BaudRate BaudRate
        {
            get => _baudRate;
            set
            {
                var ret = NativeUart.SetBaudRate(_handle, (NativeUart.BaudRate)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _baudRate = value;
            }
        }

        /// <summary>
        /// Sets or gets byte size of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public DataBits DataBits
        {
            get => _dataBits;
            set
            {
                var ret = NativeUart.SetByteSize(_handle, (NativeUart.ByteSize)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _dataBits = value;
            }
        }

        /// <summary>
        /// Sets or gets parity bit of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public Parity Parity
        {
            get => _parity;
            set
            {
                var ret = NativeUart.SetParity(_handle, (NativeUart.Parity)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _parity = value;
            }
        }

        /// <summary>
        /// Sets or gets stop bits of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public StopBits StopBits
        {
            get => _stopBits;
            set
            {
                var ret = NativeUart.SetStopBits(_handle, (NativeUart.StopBits)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _stopBits = value;
            }
        }

        /// <summary>
        /// Sets or gets hardware flow control of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public HardwareFlowControl HardwareFlowControl
        {
            get => _hardwareFlowControl;
            set
            {
                var ret = NativeUart.SetFlowControl(_handle, (NativeUart.SoftwareFlowControl)_softwareFlowControl, (NativeUart.HardwareFlowControl)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _hardwareFlowControl = value;
            }
        }

        /// <summary>
        /// Sets or gets software flow control of the UART slave device.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public SoftwareFlowControl SoftwareFlowControl
        {
            get => _softwareFlowControl;
            set
            {
                var ret = NativeUart.SetFlowControl(_handle, (NativeUart.SoftwareFlowControl)value, (NativeUart.HardwareFlowControl)_hardwareFlowControl);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _softwareFlowControl = value;
            }
        }
    }
}
