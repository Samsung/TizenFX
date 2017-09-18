/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.System.Usb
{
    /// <summary>
    /// String information for USB device.
    /// </summary>
    public class UsbDeviceStrings
    {
        private readonly UsbDevice _device;
        private string _language;

        internal UsbDeviceStrings(UsbDevice device, string language)
        {
            _device = device;
            _language = language;
        }

        /// <summary>
        /// Gets string describing device manufacturer.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws exception if device is disconnected or not opened for operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        public string Manufacturer
        {
            get
            {
                _device.ThrowIfDisposed();
                return Interop.DescriptorString(_device._handle.GetManufacturerStr, _language);
            }
        }

        /// <summary>
        /// Gets product string of device
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws exception if device is not opened for operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        public string Product
        {
            get
            {
                _device.ThrowIfDisposed();
                return Interop.DescriptorString(_device._handle.GetProductStr, _language);
            }
        }

        /// <summary>
        /// Gets serial number of a device.
        /// </summary>
        /// <exception cref="InvalidOperationException">Throws exception if device is not opened for operation.</exception>
        /// <exception cref="UnauthorizedAccessException">Throws exception if user has insufficient permission on device.</exception>
        public string Serial
        {
            get
            {
                _device.ThrowIfDisposed();
                return Interop.DescriptorString(_device._handle.GetSerialNumberStr, _language);
            }
        }
    }
}
