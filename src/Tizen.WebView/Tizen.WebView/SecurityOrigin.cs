/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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

namespace Tizen.WebView
{
    /// <summary>
    /// This class provides the properties for Security Origin of WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class SecurityOrigin
    {
        private IntPtr _handle;

        internal SecurityOrigin(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the Host.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Host
        {
            get
            {
                return Interop.ChromiumEwk.ewk_security_origin_host_get(_handle);
            }
        }

        /// <summary>
        /// Gets the Protocol.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Protocol
        {
            get
            {
                return Interop.ChromiumEwk.ewk_security_origin_protocol_get(_handle);
            }
        }
    }
}
