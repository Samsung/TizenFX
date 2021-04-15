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
using NativeSpi = Interop.Peripheral.Spi;

namespace Tizen.Peripheral.Spi
{
    /// <summary>
    /// Enumeration of SPI transfer modes.
    /// </summary>
    public enum SpiMode
    {
        /// <summary>
        /// CPOL = 0, CPHa = 0 Mode.
        /// </summary>
        Mode0 = 0,

        /// <summary>
        /// CPOL = 0, CPHa = 1 Mode.
        /// </summary>
        Mode1,

        /// <summary>
        /// CPOL = 1, CPHa = 0 Mode.
        /// </summary>
        Mode2,

        /// <summary>
        /// CPOL = 1, CPHa = 1 Mode.
        /// </summary>
        Mode3
    }

    /// <summary>
    /// Enumeration of bit orders.
    /// </summary>
    /// <remarks>
    /// Currently only LSB order is supported!
    /// </remarks>
    public enum BitOrder
    {
        /// <summary>
        /// Use most siginificant bit first.
        /// </summary>
        MSB = 0,

        /// <summary>
        /// Use least siginificant bit first.
        /// </summary>
        LSB
    }

    /// <summary>
    /// The class allows applications to communicate via SPI platform's bus.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class SpiDevice : IDisposable
    {

        //TODO Provide default values.
        private SpiMode _transferMode;
        private BitOrder _bitOrder;
        private byte _bitsPerWord;
        private uint _frequency;

        /// <summary>
        /// Native handle to Spi.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Opens a SPI slave device.
        /// </summary>
        /// <param name="bus">The SPI bus number.</param>
        /// <param name="chip">The SPI chip select number.</param>
        public SpiDevice(int bus, int chip)
        {
            var ret = NativeSpi.Open(bus, chip, out _handle);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Closes the SPI slave device.
        /// </summary>
        ~SpiDevice()
        {
            Dispose(false);
        }

        /// <summary>
        /// Closes the SPI slave device.
        /// </summary>
        public void Close() => Dispose();

        /// <summary>
        /// Disposes the Spi.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the Spi.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NativeSpi.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// Reads the bytes data from the SPI slave device.
        /// </summary>
        /// <param name="buffer">The Data buffer.</param>
        public void Read(byte[] buffer)
        {
            if (buffer == null)
                throw new ArgumentNullException(nameof(buffer));
            var length = Convert.ToUInt32(buffer.Length);
            var ret = NativeSpi.Read(_handle, buffer, length);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Writes the bytes data to the SPI slave device.
        /// </summary>
        /// <param name="data">The data buffer to write.</param>
        public void Write(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var length = Convert.ToUInt32(data.Length);
            var ret = NativeSpi.Write(_handle, data, length);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Exchanges the bytes data to the SPI slave device.
        /// writeBuffer.Length and readBuffer.Length must be equal.
        /// </summary>
        /// <param name="writeBuffer">Array containing data to write to the device.</param>
        /// <param name="readBuffer">Array containing data read from the dievice.</param>
        public void TransferSequential(byte[] writeBuffer, byte[] readBuffer)
        {
            if (readBuffer == null)
                throw new ArgumentNullException(nameof(readBuffer));
            if (writeBuffer == null)
                throw new ArgumentNullException(nameof(writeBuffer));
            if (writeBuffer.Length != readBuffer.Length)
                throw new Exception("writeBuffer.Length is not equal to readBuffer.Length");

            var buffersLength = Convert.ToUInt32(writeBuffer.Length);

            var ret = NativeSpi.Transfer(_handle, writeBuffer, readBuffer, buffersLength);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Sets or gets the SPI transfer mode.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public SpiMode Mode
        {
            get => _transferMode;
            set
            {
                var ret = NativeSpi.SetMode(_handle, (NativeSpi.Mode)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _transferMode = value;
            }
        }

        /// <summary>
        /// Sets or gets the SPI bit order.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public BitOrder BitOrder
        {
            get => _bitOrder;
            set
            {
                var ret = NativeSpi.SetBitOrder(_handle, (NativeSpi.BitOrder)value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _bitOrder = value;
            }
        }

        /// <summary>
        /// Sets or gets the number of bits per word.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public byte BitsPerWord
        {
            get => _bitsPerWord;
            set
            {
                var ret = NativeSpi.SetBitsPerWord(_handle, value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _bitsPerWord = value;
            }
        }

        /// <summary>
        /// Sets or gets the frequency of the SPI bus.
        /// </summary>
        /// <remarks>Get value is initialized after successful Set call.</remarks>
        public uint ClockFrequency
        {
            get => _frequency;
            set
            {
                var ret = NativeSpi.SetFrequency(_handle, value);
                if (ret != Internals.Errors.ErrorCode.None)
                    throw ExceptionFactory.CreateException(ret);

                _frequency = value;
            }
        }
    }
}
