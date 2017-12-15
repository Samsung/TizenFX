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
    /// USB Isochronous Endpoint class.
    /// </summary>
    /// <since_tizen> 5 </since_tizen>
    public class UsbIsochronousEndpoint : UsbEndpoint
    {
        internal UsbIsochronousEndpoint(UsbInterface parent, Interop.UsbEndpointHandle handle) : base(parent, handle)
        {
        }

        /// <summary>
        /// Gets synchronization type of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public SynchronizationType SynchronizationType
        {
            get
            {
                ThrowIfDisposed();
                return (SynchronizationType)Interop.NativeGet<Interop.SynchronizationType>(_handle.GetSynchType);
            }
        }

        /// <summary>
        /// Gets usage type of this endpoint.
        /// </summary>
        /// <feature>http://tizen.org/feature/usb.host</feature>
        /// <exception cref="NotSupportedException">The required feature is not supported.</exception>
        /// <since_tizen> 5 </since_tizen>
        public UsageType UsageType
        {
            get
            {
                ThrowIfDisposed();
                return (UsageType)Interop.NativeGet<Interop.UsageType>(_handle.GetUsageType);
            }
        }
    }
}
