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
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebPageLoadError : Disposable
    {
        internal WebPageLoadError(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for the load error type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ErrorType
        {
            /// <summary>
            /// None.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None,

            /// <summary>
            /// Internal error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Internal,

            /// <summary>
            /// Network error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Network,

            /// <summary>
            /// Policy error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Policy,

            /// <summary>
            /// Plugin error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Plugin,

            /// <summary>
            /// Download error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Download,

            /// <summary>
            /// Print error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Print,
        }

        /// <summary>
        /// Enumeration for the load error code
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ErrorCode
        {
            /// <summary>
            /// Unknown.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Unknown,

            /// <summary>
            /// User canceled.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Canceled,

            /// <summary>
            /// Can't show the page for this MIME type.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CantSupportMimetype,

            /// <summary>
            /// File IO error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FailedFileIo,

            /// <summary>
            /// Cannot connect to the network.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CannotConnect,

            /// <summary>
            /// Fail to look up host from the DNS.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CannotLookupHost,

            /// <summary>
            /// Fail to SSL/TLS handshake.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FailedTlsHandshake,

            /// <summary>
            /// Received certificate is invalid.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            InvalidCertificate,

            /// <summary>
            /// Connection timeout.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            RequestTimeout,

            /// <summary>
            /// Too many redirects.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TooManyRedirects,

            /// <summary>
            /// Too many requests during this load.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TooManyRequests,

            /// <summary>
            /// Malformed URL.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            BadUrl,

            /// <summary>
            /// Unsupported scheme.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            UnsupportedScheme,

            /// <summary>
            /// User authentication failed on the server.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Authentication,

            /// <summary>
            /// Web server has an internal server error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            InternalServer,

            /// <summary>
            /// Other error.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Other,
        }

        /// <summary>
        /// Queries failing URL for this error.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ErrorType Type
        {
            get
            {
                return (ErrorType)Interop.WebPageLoadError.GetType(SwigCPtr);
            }
        }
    }
}
