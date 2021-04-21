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
    /// It is a class for http request interceptor of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebHttpRequestInterceptor : Disposable
    {
        internal WebHttpRequestInterceptor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Gets url of intercepted request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return Interop.WebHttpRequestInterceptor.GetUrl(SwigCPtr);
            }
        }

        /// <summary>
        /// Ignores this request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignore()
        {
            bool result = Interop.WebHttpRequestInterceptor.Ignore(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Sets status code and status text of response for intercepted request.
        /// <param name="statusCode">Status code of response</param>
        /// <param name="customStatusText">Status text of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetResponseStatus(int statusCode, string customStatusText)
        {
            bool result = Interop.WebHttpRequestInterceptor.SetResponseStatus(SwigCPtr, statusCode, customStatusText);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds HTTP header to response for intercepted request.
        /// <param name="fieldName">Key of response header</param>
        /// <param name="fieldValue">Value of response header</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddResponseHeader(string fieldName, string fieldValue)
        {
            bool result = Interop.WebHttpRequestInterceptor.AddResponseHeader(SwigCPtr, fieldName, fieldValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Writes whole response body at once.
        /// <param name="body">Contents of response</param>
        /// <param name="length">Length of Contents of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddResponseBody(string body, uint length)
        {
            bool result = Interop.WebHttpRequestInterceptor.AddResponseBody(SwigCPtr, body, length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
