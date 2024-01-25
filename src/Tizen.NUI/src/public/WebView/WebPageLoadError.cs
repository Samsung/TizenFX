/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 *
 */

using System;
using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for load error of page of web view.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public class WebPageLoadError : Disposable
    {
        internal WebPageLoadError(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebPageLoadError.DeleteWebPageLoadError(swigCPtr);
        }

        /// <summary>
        /// Enumeration for the load error type
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public enum ErrorType
        {
            /// <summary>
            /// None.
            /// </summary>
            None,

            /// <summary>
            /// Internal error.
            /// </summary>
            Internal,

            /// <summary>
            /// Network error.
            /// </summary>
            Network,

            /// <summary>
            /// Policy error.
            /// </summary>
            Policy,

            /// <summary>
            /// Plugin error.
            /// </summary>
            Plugin,

            /// <summary>
            /// Download error.
            /// </summary>
            Download,

            /// <summary>
            /// Print error.
            /// </summary>
            Print,
        }

        /// <summary>
        /// Enumeration for the load error code
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public enum ErrorCode
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            Unknown,

            /// <summary>
            /// User canceled.
            /// </summary>
            Canceled,

            /// <summary>
            /// Can't show the page for this MIME type.
            /// </summary>
            CantSupportMimetype,

            /// <summary>
            /// File IO error.
            /// </summary>
            FailedFileIo,

            /// <summary>
            /// Cannot connect to the network.
            /// </summary>
            CannotConnect,

            /// <summary>
            /// Fail to look up host from the DNS.
            /// </summary>
            CannotLookupHost,

            /// <summary>
            /// Fail to SSL/TLS handshake.
            /// </summary>
            FailedTlsHandshake,

            /// <summary>
            /// Received certificate is invalid.
            /// </summary>
            InvalidCertificate,

            /// <summary>
            /// Connection timeout.
            /// </summary>
            RequestTimeout,

            /// <summary>
            /// Too many redirects.
            /// </summary>
            TooManyRedirects,

            /// <summary>
            /// Too many requests during this load.
            /// </summary>
            TooManyRequests,

            /// <summary>
            /// Malformed URL.
            /// </summary>
            BadUrl,

            /// <summary>
            /// Unsupported scheme.
            /// </summary>
            UnsupportedScheme,

            /// <summary>
            /// User authentication failed on the server.
            /// </summary>
            Authentication,

            /// <summary>
            /// Web server has an internal server error.
            /// </summary>
            InternalServer,

            /// <summary>
            /// Other error.
            /// </summary>
            Other,
        }

        /// <summary>
        /// Queries failing URL for this error.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Url
        {
            get
            {
                return Interop.WebPageLoadError.GetUrl(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries code for this error.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ErrorCode Code
        {
            get
            {
                return (ErrorCode)Interop.WebPageLoadError.GetCode(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries description for this error.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Description
        {
            get
            {
                return Interop.WebPageLoadError.GetDescription(SwigCPtr);
            }
        }

        /// <summary>
        /// Queries type for this error.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ErrorType Type
        {
            get
            {
                return (ErrorType)Interop.WebPageLoadError.GetType(SwigCPtr);
            }
        }
    }
}
