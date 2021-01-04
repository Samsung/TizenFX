/*
 * Copyright (c) 2021 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;

namespace Tizen.WebView
{
    /// <summary>
    /// This class provides methods and properties to handle a interpected request.
    /// </summary>
    /// <since_tizen> 8 </since_tizen>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class RequestInterceptor {
        private const string ResponseHeaderTemplate =
            "HTTP/1.1 {0} {1}\r\n" +
            "Content-Type: {2}; charset={3}\r\n" +
            "Content-Length: {4}\r\n";

        private IntPtr _handle;

        internal RequestInterceptor(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// The URL of the request.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri Url
        {
            get
            {
                return new Uri(Interop.ChromiumEwk.ewk_intercept_request_url_get(_handle));
            }
        }

        /// <summary>
        /// Sets headers and data for the response.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="mimeType"> Response's mime type. </param>
        /// <param name="encoding"> Response's character encoding. </param>
        /// <param name="statusCode"> HTTP response status code. </param>
        /// <param name="reasonPhrase"> HTTP response reason phrase. </param>
        /// <param name="responseHeaders"> Headers Map from HTTP header field names to field values. </param>
        /// <param name="data"> The streiam that provides the response's data. </param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="data"/> is null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when the native operation failed to set response.</exception>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetResponse(string mimeType, string encoding, int statusCode, string reasonPhrase, IDictionary<string, string> responseHeaders, Stream data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            byte[] body;
            using (MemoryStream ms = new MemoryStream())
            {
                data.CopyTo(ms);
                body = ms.ToArray();

                var headers = String.Format(ResponseHeaderTemplate, statusCode, reasonPhrase, mimeType, encoding, body.Length);
                if (responseHeaders != null)
                {
                    foreach(var header in responseHeaders)
                    {
                        headers += $"{header.Key}: {header.Value}\r\n";
                    }
                }
                headers += "\r\n";

                unsafe
                {
                    fixed (byte* bodyPtr = body)
                    {
                        var ret = Interop.ChromiumEwk.ewk_intercept_request_response_set(_handle, headers, bodyPtr, (uint)body.Length);
                        if (!ret)
                        {
                            throw new InvalidOperationException("Failed to set response.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Ignores the request, so WebView will load it.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Ignore()
        {
            Interop.ChromiumEwk.ewk_intercept_request_ignore(_handle);
        }
    }
}
