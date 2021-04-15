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
using NativeI2c = Interop.Peripheral.I2c;

namespace Tizen.Peripheral.I2c
{
    /// <summary>
    /// The class allows applications to communicate via i2c platform's bus.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class I2cDevice : IDisposable
    {
        /// <summary>
        /// Native handle to I2c.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Opens the connection to the I2C slave device.
        /// </summary>
        /// <param name="bus">The I2C bus number that the slave device is connected.</param>
        /// <param name="address">The address of the slave device.</param>
        public I2cDevice(int bus, int address)
        {
            var ret = NativeI2c.Open(bus, address, out _handle);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Closes the connection to the I2C slave device.
        /// </summary>
        ~I2cDevice()
        {
            Dispose(false);
        }

        /// <summary>
        /// Closes the connection to the I2C slave device.
        /// </summary>
        public void Close() => Dispose();

        /// <summary>
        /// Disposes the I2c.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the I2c.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NativeI2c.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }

        /// <summary>
        /// Reads the bytes data from the I2C slave device.
        /// </summary>
        /// <param name="dataOut">The output byte array.</param>
        public void Read(byte[] dataOut)
        {
            if (dataOut == null)
                throw new ArgumentNullException(nameof(dataOut));
            var length = Convert.ToUInt32(dataOut.Length);
            var ret = NativeI2c.Read(_handle, dataOut, length);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Writes the bytes data to the I2C slave device.
        /// </summary>
        /// <param name="data"></param>
        public void Write(byte[] data)
        {
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            var length = Convert.ToUInt32(data.Length);
            var ret = NativeI2c.Write(_handle, data, length);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Reads single byte data from the register of the I2C slave device.
        /// </summary>
        /// <param name="register">The register address of the I2C slave device to read.</param>
        /// <returns>The single byte data.</returns>
        public byte ReadRegisterByte(byte register)
        {
            var ret = NativeI2c.ReadRegisterByte(_handle, register, out byte data);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);

            return data;
        }

        /// <summary>
        /// Writes single byte data to the register of the I2C slave device.
        /// </summary>
        /// <param name="register">The register address of the I2C slave device to write.</param>
        /// <param name="data">The single byte data to write.</param>
        public void WriteRegisterByte(byte register, byte data)
        {
            var ret = NativeI2c.WriteRegisterByte(_handle, register, data);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Reads word data from the register of the I2C slave device.
        /// </summary>
        /// <param name="register">The register address of the I2C slave device to read.</param>
        /// <returns>The word (2 bytes) data.</returns>
        public ushort ReadRegisterWord(byte register)
        {
            var ret = NativeI2c.ReadRegisterWord(_handle, register, out ushort data);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);

            return data;
        }

        /// <summary>
        /// Writes word data to the register of the I2C slave device.
        /// </summary>
        /// <param name="register">The register address of the I2C slave device to write.</param>
        /// <param name="data">The word (2 bytes) data to write.</param>
        public void WriteRegisterWord(byte register, ushort data)
        {
            var ret = NativeI2c.WriteRegisterWord(_handle, register, data);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }
    }
}
