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

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration that contains option for cache model.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum CacheModel
    {
        /// <summary>
        /// Use the smallest cache capacity.
        /// </summary>
        DocumentViewer,
        /// <summary>
        /// Use bigger cache capacity than DocumentBrowser.
        /// </summary>
        DocumentBrowser,
        /// <summary>
        /// Use the biggest cache capacity.
        /// </summary>
        PrimaryWebBrowser
    }

    /// <summary>
    /// This class encapsulates all pages related to the specific use of Chromium-efl.
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
        /// <returns>The CookieManager object</returns>
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
    }
}
