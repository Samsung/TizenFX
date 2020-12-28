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
    /// Enumeration for the cookies accept policies.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum CookieAcceptPolicy
    {
        /// <summary>
        /// Accepts every cookie sent from any page.
        /// </summary>
        Always,
        /// <summary>
        /// Rejects all the cookies.
        /// </summary>
        Never,
        /// <summary>
        /// Accepts only cookies set by the main document that is loaded.
        /// </summary>
        NoThirdParty
    }

    /// <summary>
    /// Enumeration for creating a type name for the storage of persistent cookies.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public enum CookiePersistentStorage
    {
        /// <summary>
        /// Cookies are stored in a text file in the Mozilla "cookies.txt" format.
        /// </summary>
        [Obsolete("Deprecated since API level 8.")]
        Text,
        /// <summary>
        /// Cookies are stored in a SQLite file in the current Mozilla format.
        /// </summary>
        SqlLite
    }

    /// <summary>
    /// This class provides methods for the cookie manager.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class CookieManager
    {
        private IntPtr _handle;

        internal CookieManager(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Sets the cookie acceptance policy.
        /// </summary>
        /// <remarks>
        /// By default, only cookies set by the main document that is loaded, are accepted.
        /// </remarks>
        /// <param name="policy">The cookie acceptance policy.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetCookieAcceptPolicy(CookieAcceptPolicy policy)
        {
            Interop.ChromiumEwk.ewk_cookie_manager_accept_policy_set(_handle, (Interop.ChromiumEwk.CookieAcceptPolicy)policy);
        }

        /// <summary>
        /// Deletes all the cookies.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void ClearCookies()
        {
            Interop.ChromiumEwk.ewk_cookie_manager_cookies_clear(_handle);
        }

        /// <summary>
        /// Sets the storage where the non-session cookies are stored persistently, to read/write the cookies.
        /// </summary>
        /// <privilege>http://tizen.org/privilege/mediastorage</privilege>
        /// <privilege>http://tizen.org/privilege/externalstorage</privilege>
        /// <param name="path">The path where to read/write cookies.</param>
        /// <param name="storage">The type of storage.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetPersistentStorage(string path, CookiePersistentStorage storage)
        {
            Interop.ChromiumEwk.ewk_cookie_manager_persistent_storage_set(_handle, path, (Interop.ChromiumEwk.CookiePersistentStorage)storage);
        }
    }
}
