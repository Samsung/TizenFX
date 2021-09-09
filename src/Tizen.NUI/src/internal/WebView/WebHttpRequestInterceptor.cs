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
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// It is a class for http request interceptor of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebHttpRequestInterceptor : Disposable
    {
        private HandleRef interceptorHandle;

        internal WebHttpRequestInterceptor(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            IntPtr ip = Interop.WebHttpRequestInterceptorPtr.Get(SwigCPtr);
            interceptorHandle = new HandleRef(this, ip);
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebHttpRequestInterceptorPtr.DeleteWebHttpRequestInterceptorPtr(swigCPtr);
        }

        /// <summary>
        /// Gets url of intercepted request.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return Interop.WebHttpRequestInterceptor.GetUrl(interceptorHandle);
            }
        }

        /// <summary>
        /// Gets method of intercepted http request, for example, GET, POST, etc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Method
        {
            get
            {
                return Interop.WebHttpRequestInterceptor.GetMethod(interceptorHandle);
            }
        }

        /// <summary>
        /// Gets headers of intercepted http request.
        /// Headers is a map with string key-value pairs,
        /// for example, "Accept: text/plain", "Accept-Charset: utf-8", etc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IDictionary<string, string> Headers
        {
            get
            {
                IntPtr mapPtr = Interop.WebHttpRequestInterceptor.GetHeaders(interceptorHandle);
                IDictionary<string, string> dictionary = new Dictionary<string, string>();
                PropertyMap map = new PropertyMap(mapPtr, true);
                for (uint i = 0; i < map.Count(); i++)
                {
                    using (PropertyKey key = map.GetKeyAt(i))
                    {
                        if (key.Type == PropertyKey.KeyType.String)
                        {
                            string outValue;
                            using (PropertyValue mapValue = map.GetValue(i))
                            {
                                if (mapValue.Get(out outValue))
                                {
                                    dictionary.Add(key.StringKey, outValue);
                                }
                            }
                        }
                    }
                }
                map.Dispose();
                return dictionary;
            }
        }

        /// <summary>
        /// Ignores the http request.
        /// When application doesn't have a response for intercepted request,
        /// this function would be called which notifies engine to proceed with normal resource loading.
        /// It can be called only INSIDE WebContext.HttpRequestIntercepted.
        /// After it called, any further call on WebHttpRequestInterceptor results in undefined behavior.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignore()
        {
            bool result = Interop.WebHttpRequestInterceptor.Ignore(interceptorHandle);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Sets status code and status text of response for intercepted request.
        /// This function can be used inside or outside WebContext.HttpRequestIntercepted.
        /// <param name="statusCode">Status code of response</param>
        /// <param name="customStatusText">Status text of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetResponseStatus(int statusCode, string customStatusText)
        {
            bool result = Interop.WebHttpRequestInterceptor.SetResponseStatus(interceptorHandle, statusCode, customStatusText);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds HTTP header to response for intercepted request.
        /// This function can be used inside or outside WebContext.HttpRequestIntercepted.
        /// <param name="fieldName">Key of response header</param>
        /// <param name="fieldValue">Value of response header</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddResponseHeader(string fieldName, string fieldValue)
        {
            bool result = Interop.WebHttpRequestInterceptor.AddResponseHeader(interceptorHandle, fieldName, fieldValue);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds HTTP headers to response for intercepted request.
        /// This function can be used inside or outside WebContext.HttpRequestIntercepted.
        /// <param name="headers">Map of response headers</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddResponseHeaders(IDictionary<string, string> headers)
        {
            if (headers == null)
                return false;
            PropertyMap headerMap = new PropertyMap();
            foreach (KeyValuePair<string, string> kvp in headers)
            {
                using (PropertyValue value = new PropertyValue(kvp.Value))
                {
                    headerMap.Add(kvp.Key, value);
                }
            }
            bool result = Interop.WebHttpRequestInterceptor.AddResponseHeaders(interceptorHandle, PropertyMap.getCPtr(headerMap));
            headerMap.Dispose();
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Writes whole response body at once.
        /// To call it, application should have full response body ready for the intercepted request.
        /// This function can be used inside or outside WebContext.HttpRequestIntercepted.
        /// After this call, any further call on WebHttpRequestInterceptor results in undefined behavior.
        /// <param name="body">Contents of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetResponseBody(string body)
        {
            if (body == null)
                return false;
            bool result = Interop.WebHttpRequestInterceptor.AddResponseBody(interceptorHandle, body, (uint)body.Length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Writes whole response body with headers at once.
        /// To call it, application should have full response headers and body ready for the intercepted request.
        /// This function can be used inside or outside WebContext.HttpRequestIntercepted.
        /// After this call, any further call on WebHttpRequestInterceptor results in undefined behavior.
        /// <param name="headers">Headers of response</param>
        /// <param name="body">Contents of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetResponse(string headers, string body)
        {
            if (body == null)
                return false;
            bool result = Interop.WebHttpRequestInterceptor.AddResponse(interceptorHandle, headers, body, (uint)body.Length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Writes a part of response body.
        /// This function can be called only OUTSIDE WebContext.HttpRequestIntercepted.
        /// If it returns false, handling the request is done.
        /// Any further calls result in undefined behavior.
        /// User should always check return value, because response to this request might not be needed any more,
        /// and the function can return false even though user still has data to write.
        /// 
        /// After writing full response body in chunks using this function,
        /// call it again with null as chunk, to signal that response body is finished.
        /// <param name="chunk">Chunk of response</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WriteResponseChunk(string chunk)
        {
            int length = 0;
            if (chunk != null)
            {
                length = chunk.Length;
            }
            bool result = Interop.WebHttpRequestInterceptor.WriteResponseChunk(interceptorHandle, chunk, (uint)length);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
