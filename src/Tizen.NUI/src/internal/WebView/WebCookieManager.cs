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

using System.ComponentModel;

namespace Tizen.NUI
{
    /// <summary>
    /// WebCookieManager is a class for cookie manager of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebCookieManager : Disposable
    {
        internal WebCookieManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Cookie Accept Policy
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CookieAcceptPolicyType
        {
            /// <summary>
            /// Always
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Always,

            /// <summary>
            /// Never
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Never,

            /// <summary>
            /// No third party.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            NoThirdParty,
        }

        /// <summary>
        /// Cookie accept policy
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookieAcceptPolicyType CookieAcceptPolicy
        {
            get
            {
                return (CookieAcceptPolicyType)Interop.WebCookieManager.GetCookieAcceptPolicy(SwigCPtr);
            }
            set
            {
                Interop.WebCookieManager.SetCookieAcceptPolicy(SwigCPtr, (int)value);
            }
        }

        /// <summary>
        /// Cookie persistent storage type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CookiePersistentStorageType
        {
            /// <summary>
            /// @deprecated Cookies are stored in a text file.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Text,

            /// <summary>
            /// stored in a SQLite file
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            SqlLite,
        }

        /// <summary>
        /// Set the proxy uri.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPersistentStorage(string path, CookiePersistentStorageType storageType)
        {
            Interop.WebCookieManager.SetPersistentStorage(SwigCPtr, path, (int)storageType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Set Default Proxy Auth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCookies()
        {
            Interop.WebCookieManager.ClearCookies(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebCookieManager obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }
    }
}
