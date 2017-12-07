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

namespace Tizen.System.Usb
{
    /// <summary>
    /// String information for USB device.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class UsbDeviceStrings
    {
        internal UsbDeviceStrings(UsbDevice device, string language)
        {
            Manufacturer = Interop.DescriptorString(device._handle.GetManufacturerStr, language);
            Product = Interop.DescriptorString(device._handle.GetProductStr, language);
            Serial = Interop.DescriptorString(device._handle.GetSerialNumberStr, language);
        }

        /// <summary>
        /// Gets string describing device manufacturer.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Manufacturer;

        /// <summary>
        /// Gets product string of device
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Product;

        /// <summary>
        /// Gets serial number of a device.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Serial;
    }
}
