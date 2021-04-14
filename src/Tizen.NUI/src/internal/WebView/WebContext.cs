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
    /// WebContext is a class for context of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContext : Disposable
    {
        private string proxyUri;
        private string certificateFilePath;
        private bool disableCache;
        private SecurityOriginListAcquiredCallback securityOriginListAcquiredCallback;
        private readonly WebContextSecurityOriginListAcquiredProxyCallback securityOriginListAcquiredProxyCallback;
        private PasswordDataListAcquiredCallback passwordDataListAcquiredCallback;
        private readonly WebContextPasswordDataListAcquiredProxyCallback passwordDataListAcquiredProxyCallback;

        internal WebContext(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            securityOriginListAcquiredProxyCallback = OnSecurityOriginListAcquired;
            passwordDataListAcquiredProxyCallback = OnPasswordDataListAcquired;
        }

        /// <summary>
        /// The callback function that is invoked when security origin list is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SecurityOriginListAcquiredCallback(WebSecurityOriginList list);

        /// <summary>
        /// The callback function that is invoked when storage usage is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void StorageUsageAcquiredCallback(ulong usage);

        /// <summary>
        /// The callback function that is invoked when security origin list is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void PasswordDataListAcquiredCallback(WebPasswordDataList list);

        /// <summary>
        /// The callback function that is invoked when download is started.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void DownloadStartedCallback(string url);

        /// <summary>
        /// The callback function that is invoked when current mime type need be overridden.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate bool MimeOverriddenCallback(string url, string currentMime, string newMime);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebContextSecurityOriginListAcquiredProxyCallback(IntPtr list);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebContextPasswordDataListAcquiredProxyCallback(IntPtr list);

        /// <summary>
        /// Cache model
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum CacheModelType
        {
            /// <summary>
            /// The smallest cache capacity
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            DocumentViewer,

            /// <summary>
            /// The bigger cache capacity than DocumentBrowser
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            DocumentBrowser,

            /// <summary>
            /// The biggest cache capacity.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            PrimaryWebBrowser,
        }

        /// <summary>
        /// Cache model
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheModelType CacheModel
        {
            get
            {
                return (CacheModelType)Interop.WebContext.GetCacheModel(SwigCPtr);
            }
            set
            {
                Interop.WebContext.SetCacheModel(SwigCPtr, (int)value);
            }
        }

        /// <summary>
        /// Set the proxy uri.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Uri ProxyUri
        {
            get
            {
                return new Uri(proxyUri);
            }
            set
            {
                if (value != null)
                {
                    proxyUri = value.AbsoluteUri;
                    Interop.WebContext.SetProxyUri(SwigCPtr, proxyUri);
                }
            }
        }

        /// <summary>
        /// Set the Certificate File Path.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CertificateFilePath
        {
            get
            {
                return certificateFilePath;
            }
            set
            {
                certificateFilePath = value;
                Interop.WebContext.SetCertificateFilePath(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Disable cache or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DisableCache
        {
            get
            {
                return disableCache;
            }
            set
            {
                disableCache = value;
                Interop.WebContext.DisableCache(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Set Default Proxy Auth.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDefaultProxyAuth(string username, string password)
        {
            Interop.WebContext.SetDefaultProxyAuth(SwigCPtr, username, password);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Delete all web database.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllWebDatabase()
        {
            Interop.WebContext.DeleteAllWebDatabase(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets security origins of web database asynchronously.
        /// <param name="callback">callback for acquiring security origins</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetWebDatabaseOrigins(SecurityOriginListAcquiredCallback callback)
        {
            securityOriginListAcquiredCallback = callback;
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(securityOriginListAcquiredProxyCallback);
            bool result = Interop.WebContext.GetWebDatabaseOrigins(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Deletes web databases by origin.
        /// <param name="origin">security origin of web database</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteWebDatabase(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteWebDatabase(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a list of security origins of web storage asynchronously.
        /// <param name="callback">callback for acquiring security origins</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetWebStorageOrigins(SecurityOriginListAcquiredCallback callback)
        {
            securityOriginListAcquiredCallback = callback;
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(securityOriginListAcquiredProxyCallback);
            bool result = Interop.WebContext.GetWebStorageOrigins(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a list of security origins of web storage asynchronously.
        /// <param name="origin">security origin of web storage</param>
        /// <param name="callback">callback for acquiring storage usage</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetWebStorageUsageForOrigin(WebSecurityOrigin origin, StorageUsageAcquiredCallback callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            bool result = Interop.WebContext.GetWebStorageUsageForOrigin(SwigCPtr, WebSecurityOrigin.getCPtr(origin), new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Delete all web storage.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllWebStorage()
        {
            Interop.WebContext.DeleteAllWebStorage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes web storage by origin.
        /// <param name="origin">security origin of web storage</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteWebStorage(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteWebStorageOrigin(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Delete local fileSystem.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteLocalFileSystem()
        {
            Interop.WebContext.DeleteLocalFileSystem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clear cache.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Interop.WebContext.ClearCache(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes web application cache by origin.
        /// <param name="origin">security origin of web application</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteApplicationCache(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteApplicationCache(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a list of all password data asynchronously.
        /// <param name="callback">callback for acquiring password data list</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetFormPasswordList(PasswordDataListAcquiredCallback callback)
        {
            passwordDataListAcquiredCallback = callback;
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(passwordDataListAcquiredProxyCallback);
            Interop.WebContext.GetFormPasswordList(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers callback for download started.
        /// <param name="callback">callback for download started</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterDownloadStartedCallback(DownloadStartedCallback callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebContext.RegisterDownloadStartedCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers callback for overriding mime type.
        /// <param name="callback">callback for overriding mime type</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterMimeOverriddenCallback(MimeOverriddenCallback callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebContext.RegisterMimeOverriddenCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private void OnSecurityOriginListAcquired(IntPtr list)
        {
            WebSecurityOriginList originList = new WebSecurityOriginList(list, true);
            securityOriginListAcquiredCallback?.Invoke(originList);
            originList.Dispose();
        }

        private void OnPasswordDataListAcquired(IntPtr list)
        {
            WebPasswordDataList passwordList = new WebPasswordDataList(list, true);
            passwordDataListAcquiredCallback?.Invoke(passwordList);
            passwordList.Dispose();
        }
    }
}
