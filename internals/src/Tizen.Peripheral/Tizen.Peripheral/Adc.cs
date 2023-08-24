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
using NativeAdc = Interop.Peripheral.Adc;

namespace Tizen.Peripheral.Adc
{
    /// <summary>
    /// The class allows applications to use the platform ADC peripheral.
    /// </summary>
    /// <privilege>http://tizen.org/privilege/peripheralio</privilege>
    public class AdcChannel : IDisposable
    {
        /// <summary>
        /// Native handle to ADC.
        /// </summary>
        private IntPtr _handle = IntPtr.Zero;
        private bool _disposed = false;

        /// <summary>
        /// Opens the ADC pin.
        /// </summary>
        /// <param name="device">The ADC device number.</param>
        /// <param name="channel">The ADC channel number to control.</param>
        public AdcChannel(int device, int channel)
        {
            var ret = NativeAdc.Open(device, channel, out _handle);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
        }

        /// <summary>
        /// Closes the ADC pin.
        /// </summary>
        ~AdcChannel()
        {
            Dispose(false);
        }

        /// <summary>
        /// Gets the current value of the ADC pin.
        /// </summary>
        public uint ReadValue()
        {
            var ret = NativeAdc.Read(_handle, out uint adcValue);
            if (ret != Internals.Errors.ErrorCode.None)
                throw ExceptionFactory.CreateException(ret);
            return adcValue;
        }

        /// <summary>
        /// Closes the ADC pin.
        /// </summary>
       public void Close() => Dispose();

        /// <summary>
        /// Disposes the ADC pin.
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// Disposes the ADC pin.
        /// </summary>
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            NativeAdc.Close(_handle);
            _handle = IntPtr.Zero;
            _disposed = true;
        }
    }
}
