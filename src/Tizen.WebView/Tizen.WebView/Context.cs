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
using System.ComponentModel;

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration for cache model options.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum CacheModel
    {
        /// <summary>
        /// Use the smallest cache capacity.
        /// </summary>
        DocumentViewer,
        /// <summary>
        /// Use the bigger cache capacity than DocumentBrowser.
        /// </summary>
        DocumentBrowser,
        /// <summary>
        /// Use the biggest cache capacity.
        /// </summary>
        PrimaryWebBrowser
    }

    /// <summary>
    /// This class encapsulates all the pages related to the specific use of the Chromium-efl.
    /// </summary>
    /// <remarks>
    /// Applications have the option of creating a context different from the default one and using it for a group of pages.
    /// All pages in the same context share the same preferences, visited link set, local storage, and so on.
    /// </remarks>
    /// <since_tizen> 4 </since_tizen>
    public class Context
    {
        private IntPtr _handle;
        private CookieManager _cookieManager;

        private Interop.ChromiumEwk.DownloadStartCallback _downloadStartCallback;
        private Interop.ChromiumEwk.InterceptRequestCallback _interceptRequestCallback;

        /// <summary>
        /// The delegate for handling download request.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        /// <param name="url"> url of the download request. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DownloadRequestDelegate(string url);

        /// <summary>
        /// The delegate for intercepting and handling a resource request.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="interceptor"> The object which can handle a intercepted request. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void InterceptRequestDelegate(RequestInterceptor interceptor);

        internal Context(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// The cache model.
        /// </summary>
        /// <remarks>
        /// The default cache model is DocumentViewer.
        /// </remarks>
        /// <since_tizen> 4 </since_tizen>
        public CacheModel CacheModel
        {
            get
            {
                return (CacheModel)Interop.ChromiumEwk.ewk_context_cache_model_get(_handle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_context_cache_model_set(_handle, (Interop.ChromiumEwk.CacheModel)value);
            }
        }

        /// <summary>
        /// Gets the CookieManager object for this context.
        /// </summary>
        /// <returns>The CookieManager object.</returns>
        /// <since_tizen> 4 </since_tizen>
        public CookieManager GetCookieManager()
        {
            if (_cookieManager == null)
            {
                IntPtr cookieManagerHandle = Interop.ChromiumEwk.ewk_context_cookie_manager_get(_handle);
                if (cookieManagerHandle == IntPtr.Zero)
                {
                    return null;
                }
                _cookieManager = new CookieManager(cookieManagerHandle);
            }
            return _cookieManager;
        }

        /// <summary>
        /// Clears HTTP caches in the local storage and all resources cached in memory.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ClearResourceCache()
        {
            Interop.ChromiumEwk.ewk_context_resource_cache_clear(_handle);
        }

        /// <summary>
        /// Informs the WebEngine low memory to release unused memory.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void NotifyLowMemory()
        {
            Interop.ChromiumEwk.ewk_context_notify_low_memory(_handle);
        }

        /// <summary>
        /// Sets the delegate function for download request.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDownloadRequestDelegate(DownloadRequestDelegate startDownloadCb)
        {
            _downloadStartCallback = (string url, IntPtr userData) =>
            {
                startDownloadCb(url);
            };
            Interop.ChromiumEwk.ewk_context_did_start_download_callback_set(_handle, _downloadStartCallback, IntPtr.Zero);
        }

        /// <summary>
        /// Sets the delegate function for intercepting a resource request.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="interceptRequestCb"> The delegate function for intercepting a resource request. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetInterceptRequestDelegate(InterceptRequestDelegate interceptRequestCb)
        {
            _interceptRequestCallback = (IntPtr context, IntPtr request, IntPtr userData) =>
            {
                interceptRequestCb(new RequestInterceptor(request));
            };
            Interop.ChromiumEwk.ewk_context_intercept_request_callback_set(_handle, _interceptRequestCallback, IntPtr.Zero);

        }

        /// <summary>
        /// Starts the inspector server.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        /// <param name="port"> The port number. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint StartInspectorServer(uint port)
        {
            return Interop.ChromiumEwk.ewk_context_inspector_server_start(_handle, port);
        }

        /// <summary>
        /// Stops the inspector server.
        /// </summary>
        /// <since_tizen> 8 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopInspectorServer()
        {
            Interop.ChromiumEwk.ewk_context_inspector_server_stop(_handle);
        }
    }
}
