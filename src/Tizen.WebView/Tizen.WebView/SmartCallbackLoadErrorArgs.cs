/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Runtime.InteropServices;

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration that provides an option to error codes.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum LoadErrorCode
    {
        /// <summary>
        /// Unknown
        /// </summary>
        Unknown = 0,
        /// <summary>
        /// User canceled
        /// </summary>
        Canceled,
        /// <summary>
        /// Can't show page for this MIME Type.
        /// </summary>
        CantSupportMimetype,
        /// <summary>
        /// File IO error
        /// </summary>
        FailedFileIo,
        /// <summary>
        /// Cannot connect to network.
        /// </summary>
        CantConnect,
        /// <summary>
        /// Fail to look up host from DNS.
        /// </summary>
        CantLookupHost,
        /// <summary>
        /// Fail to SSL/TLS handshake.
        /// </summary>
        FailedTlsHandshake,
        /// <summary>
        /// Received certificate is invalid.
        /// </summary>
        InvalidCertificate,
        /// <summary>
        /// Connection timeout
        /// </summary>
        RequestTimeout,
        /// <summary>
        /// Too many redirects
        /// </summary>
        TooManyRedirects,
        /// <summary>
        /// Too many requests during this load
        /// </summary>
        TooManyRequests,
        /// <summary>
        /// Malformed url
        /// </summary>
        BadUrl,
        /// <summary>
        /// Unsupported scheme
        /// </summary>
        UnsupportedScheme,
        /// <summary>
        /// User authentication failed on server
        /// </summary>
        Authentication,
        /// <summary>
        /// Web server has internal server error.
        /// </summary>
        InternalServer,
    }

    /// <summary>
    /// Argument from the LoadError SmartCallback.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class SmartCallbackLoadErrorArgs : EventArgs
    {
        IntPtr _handle;

        internal SmartCallbackLoadErrorArgs(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Failing URL for the error.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Url
        {
            get
            {
                return Interop.ChromiumEwk.ewk_error_url_get(_handle);
            }
        }

        /// <summary>
        /// The error code.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public LoadErrorCode Code
        {
            get
            {
                return (LoadErrorCode)Interop.ChromiumEwk.ewk_error_code_get(_handle);
            }
        }

        /// <summary>
        /// The description for the error.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Description
        {
            get
            {
                return Interop.ChromiumEwk.ewk_error_description_get(_handle);
            }
        }

        /// <summary>
        /// Whether the error should be treated as a cancellation.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool Cancellation
        {
            get
            {
                return Interop.ChromiumEwk.ewk_error_cancellation_get(_handle);
            }
        }

        internal static SmartCallbackLoadErrorArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new SmartCallbackLoadErrorArgs(info);
        }
    }
}
