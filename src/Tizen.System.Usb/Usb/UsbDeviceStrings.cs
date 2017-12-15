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
    /// <since_tizen> 5 </since_tizen>
    public class UsbDeviceStrings
    {
        private readonly UsbDevice _device;
        private string _language;
        private string _Serial;

        internal UsbDeviceStrings(UsbDevice device, string language)
        {
            _device = device;
            _language = language;
            _Serial = Serial;
        }

        /// <summary>
        /// Gets string describing device manufacturer.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
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
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
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
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
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
