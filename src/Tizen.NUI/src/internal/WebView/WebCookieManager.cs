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
using System.Runtime.InteropServices;

namespace Tizen.NUI
{
    /// <summary>
    /// WebCookieManager is a class for cookie manager of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebCookieManager : Disposable
    {
        private EventHandler<EventArgs> cookieChangedEventHandler;
        private CookieChangedCallback cookieChangedCallback;

        internal WebCookieManager(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void CookieChangedCallback();

        /// <summary>
        /// Event for cookie changed when cookies are added, removed or modified.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> CookieChanged
        {
            add
            {
                if (cookieChangedEventHandler == null)
                {
                    cookieChangedCallback = OnCookieChanged;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(cookieChangedCallback);
                    Interop.WebCookieManager.CookieChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                cookieChangedEventHandler += value;
            }
            remove
            {
                cookieChangedEventHandler -= value;
                if (cookieChangedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebCookieManager.CookieChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Enumeration for cookie accept policy
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
        /// Enumeration for cookie persistent storage type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CookiePersistentStorageType
        {
            /// <summary>
            /// Deprecated. Cookies are stored in a text file.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Text,

            /// <summary>
            /// Cookies are stored in a SQLite file.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            SqlLite,
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
        /// Sets the persistent storage.
        /// </summary>
        /// <param name="path">The path for persistent storage</param>
        /// <param name="storageType">The type of storage</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetPersistentStorage(string path, CookiePersistentStorageType storageType)
        {
            Interop.WebCookieManager.SetPersistentStorage(SwigCPtr, path, (int)storageType);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears cookies.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCookies()
        {
            Interop.WebCookieManager.ClearCookies(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void OnCookieChanged()
        {
            cookieChangedEventHandler?.Invoke(this, new EventArgs());
        }
    }
}
