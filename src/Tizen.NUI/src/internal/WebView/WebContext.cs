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
    /// WebContext is a class for context of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContext : Disposable
    {
        private string appId;
        private string appVersion;
        private float timeOffset;
        private ApplicationType applicationType;
        private WebSecurityOriginList securityOriginList;
        private SecurityOriginListAcquiredCallback securityOriginListAcquiredCallback;
        private readonly WebContextSecurityOriginListAcquiredProxyCallback securityOriginListAcquiredProxyCallback;
        private WebPasswordDataList passwordDataList;
        private PasswordDataListAcquiredCallback passwordDataListAcquiredCallback;
        private readonly WebContextPasswordDataListAcquiredProxyCallback passwordDataListAcquiredProxyCallback;
        private HttpRequestInterceptedCallback httpRequestInterceptedCallback;
        private readonly WebContextHttpRequestInterceptedProxyCallback httpRequestInterceptedProxyCallback;

        internal WebContext(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
            securityOriginListAcquiredProxyCallback = OnSecurityOriginListAcquired;
            passwordDataListAcquiredProxyCallback = OnPasswordDataListAcquired;
            httpRequestInterceptedProxyCallback = OnHttpRequestIntercepted;
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                if (passwordDataList != null)
                {
                    passwordDataList.Dispose();
                }
                if (securityOriginList != null)
                {
                    securityOriginList.Dispose();
                }
            }

            base.Dispose(type);
        }

        /// <summary>
        /// The callback function that is invoked when security origin list is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void SecurityOriginListAcquiredCallback(IList<WebSecurityOrigin> list);

        /// <summary>
        /// The callback function that is invoked when storage usage is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void StorageUsageAcquiredCallback(ulong usage);

        /// <summary>
        /// The callback function that is invoked when password data list is acquired.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void PasswordDataListAcquiredCallback(IList<WebPasswordData> list);

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
        public delegate bool MimeOverriddenCallback(string url, string currentMime, out string newMime);

        /// <summary>
        /// The callback function that is invoked when http request need be intercepted.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void HttpRequestInterceptedCallback(WebHttpRequestInterceptor interceptor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebContextSecurityOriginListAcquiredProxyCallback(IntPtr list);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebContextPasswordDataListAcquiredProxyCallback(IntPtr list);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebContextHttpRequestInterceptedProxyCallback(IntPtr interceptor);

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
        /// Application type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ApplicationType
        {
            /// <summary>
            /// Web browser.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            WebBrowser,

            /// <summary>
            /// Hbb tv.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            HbbTv,

            /// <summary>
            /// Web runtime.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            WebRuntime,

            /// <summary>
            /// Other.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Other,
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Proxy URL.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProxyUrl
        {
            get
            {
                return Interop.WebContext.GetProxyUri(SwigCPtr);
            }
            set
            {
                if (value != null)
                {
                    Interop.WebContext.SetProxyUri(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                }
            }
        }

        /// <summary>
        /// Certificate file path.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string CertificateFilePath
        {
            get
            {
                return Interop.WebContext.GetCertificateFilePath(SwigCPtr);
            }
            set
            {
                Interop.WebContext.SetCertificateFilePath(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables cache or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CacheEnabled
        {
            get
            {
                return Interop.WebContext.IsCacheEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebContext.EnableCache(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// App ID.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AppId
        {
            get
            {
                return appId;
            }
            set
            {
                Interop.WebContext.SetAppId(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                appId = value;
            }
        }

        /// <summary>
        /// App version.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string AppVersion
        {
            get
            {
                return appVersion;
            }
            set
            {
                Interop.WebContext.SetAppVersion(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                appVersion = value;
            }
        }

        /// <summary>
        /// App type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ApplicationType AppType
        {
            get
            {
                return applicationType;
            }
            set
            {
                Interop.WebContext.SetApplicationType(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                applicationType = value;
            }
        }

        /// <summary>
        /// Time offset.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TimeOffset
        {
            get
            {
                return timeOffset;
            }
            set
            {
                Interop.WebContext.SetTimeOffset(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                timeOffset = value;
            }
        }

        /// <summary>
        /// Default zoom factor.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float DefaultZoomFactor
        {
            get
            {
                return Interop.WebContext.GetDefaultZoomFactor(SwigCPtr);
            }
            set
            {
                Interop.WebContext.SetDefaultZoomFactor(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Deprecated. Gets context proxy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ContextProxy
        {
            get
            {
                return Interop.WebContext.GetProxyUri(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets proxy bypass rule.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProxyBypassRule
        {
            get
            {
                return Interop.WebContext.GetProxyBypassRule(SwigCPtr);
            }
        }

        /// <summary>
        /// Sets default proxy auth.
        /// </summary>
        /// <param name="username">Default username for proxy</param>
        /// <param name="password">Default password for proxy</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDefaultProxyAuth(string username, string password)
        {
            Interop.WebContext.SetDefaultProxyAuth(SwigCPtr, username, password);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes all web database.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllWebDatabase()
        {
            Interop.WebContext.DeleteAllWebDatabase(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets security origins of web database asynchronously.
        /// </summary>
        /// <param name="callback">callback for acquiring security origins</param>
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
        /// </summary>
        /// <param name="origin">security origin of web database</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteWebDatabase(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteWebDatabase(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a list of security origins of web storage asynchronously.
        /// </summary>
        /// <param name="callback">callback for acquiring security origins</param>
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
        /// </summary>
        /// <param name="origin">security origin of web storage</param>
        /// <param name="callback">callback for acquiring storage usage</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetWebStorageUsageForOrigin(WebSecurityOrigin origin, StorageUsageAcquiredCallback callback)
        {
            IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            bool result = Interop.WebContext.GetWebStorageUsageForOrigin(SwigCPtr, WebSecurityOrigin.getCPtr(origin), new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Deletes all web storage.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllWebStorage()
        {
            Interop.WebContext.DeleteAllWebStorage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes web storage by origin.
        /// </summary>
        /// <param name="origin">security origin of web storage</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteWebStorage(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteWebStorage(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Deletes directories and files in local file system.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteLocalFileSystem()
        {
            Interop.WebContext.DeleteLocalFileSystem(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears cache.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Interop.WebContext.ClearCache(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes web application cache by origin.
        /// </summary>
        /// <param name="origin">security origin of web application</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteApplicationCache(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteApplicationCache(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a list of all password data asynchronously.
        /// </summary>
        /// <param name="callback">callback for acquiring password data list</param>
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
        /// </summary>
        /// <param name="callback">callback for download started</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterDownloadStartedCallback(DownloadStartedCallback callback)
        {
            IntPtr ip = IntPtr.Zero;
            if (callback != null)
            {
                ip = Marshal.GetFunctionPointerForDelegate(callback);
            }
            Interop.WebContext.RegisterDownloadStartedCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers callback for overriding MIME type.
        /// </summary>
        /// <param name="callback">callback for overriding MIME type</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterMimeOverriddenCallback(MimeOverriddenCallback callback)
        {
            IntPtr ip = IntPtr.Zero;
            if (callback != null)
            {
                ip = Marshal.GetFunctionPointerForDelegate(callback);
            }
            Interop.WebContext.RegisterMimeOverriddenCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers callback for http request interceptor.
        /// This callback is not called on UI(Main) thread, so users should be cautious
        /// when accessing their data also used on UI thread.
        /// No other than WebEngineRequestInterceptor API should be used in the callback.
        /// </summary>
        /// <param name="callback">callback for intercepting http request</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterHttpRequestInterceptedCallback(HttpRequestInterceptedCallback callback)
        {
            httpRequestInterceptedCallback = callback;
            IntPtr ip = IntPtr.Zero;
            if (httpRequestInterceptedCallback != null)
            {
                ip = Marshal.GetFunctionPointerForDelegate(httpRequestInterceptedProxyCallback);
            }
            Interop.WebContext.RegisterRequestInterceptedCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets context time zone offset.
        /// </summary>
        /// <param name="offset">Time offset</param>
        /// <param name="time">Daylight saving time</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTimeZoneOffset(float offset, float time)
        {
            Interop.WebContext.SetTimeZoneOffset(SwigCPtr, offset, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deprecated. Sets context time zone offset.
        /// </summary>
        /// <param name="offset">Time offset</param>
        /// <param name="time">Daylight saving time</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetContextTimeZoneOffset(float offset, float time)
        {
            SetTimeZoneOffset(offset, time);
        }

        /// <summary>
        /// Registers URL schemes enabled.
        /// </summary>
        /// <param name="schemes">The string array of schemes</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterUrlSchemesAsCorsEnabled(string[] schemes)
        {
            if (schemes != null)
            {
                Interop.WebContext.RegisterUrlSchemesAsCorsEnabled(SwigCPtr, schemes, (uint)schemes.Length);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Registers JS plugin mime types.
        /// </summary>
        /// <param name="mimes">The string array of types</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJsPluginMimeTypes(string[] mimes)
        {
            if (mimes != null)
            {
                Interop.WebContext.RegisterJsPluginMimeTypes(SwigCPtr, mimes, (uint)mimes.Length);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Deletes all application cache.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteAllApplicationCache()
        {
            bool ret = Interop.WebContext.DeleteAllApplicationCache(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Deletes all web indexed database.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteAllWebIndexedDatabase()
        {
            bool ret = Interop.WebContext.DeleteAllWebIndexedDatabase(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Deletes password dataList.
        /// </summary>
        /// <param name="passwords">The string array of data list</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteFormPasswordDataList(string[] passwords)
        {
            if (passwords != null)
            {
                Interop.WebContext.DeleteFormPasswordDataList(SwigCPtr, passwords, (uint)passwords.Length);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Deletes all password data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllFormPasswordData()
        {
            Interop.WebContext.DeleteAllFormPasswordData(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deletes all candidate data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteAllFormCandidateData()
        {
            Interop.WebContext.DeleteAllFormCandidateData(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Sets proxy bypass rule.
        /// </summary>
        /// <param name="proxy">The proxy string</param>
        /// <param name="rule">Bypass rule</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetProxyBypassRule(string proxy, string rule)
        {
            Interop.WebContext.SetProxyBypassRule(SwigCPtr, proxy, rule);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deprecated. Sets proxy bypass rule.
        /// </summary>
        /// <param name="proxy">The proxy string</param>
        /// <param name="rule">Bypass rule</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetContextProxy(string proxy, string rule)
        {
            SetProxyBypassRule(proxy, rule);
        }

        /// <summary>
        /// Frees unused memory.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FreeUnusedMemory()
        {
            bool ret = Interop.WebContext.FreeUnusedMemory(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnSecurityOriginListAcquired(IntPtr alist)
        {
            if (securityOriginList != null)
            {
                securityOriginList.Dispose();
            }
            securityOriginList = new WebSecurityOriginList(alist, true);
            List<WebSecurityOrigin> originList = new List<WebSecurityOrigin>();
            for (uint i = 0; i < securityOriginList.ItemCount; i++)
            {
                originList.Add(securityOriginList.GetItemAtIndex(i));
            }
            securityOriginListAcquiredCallback?.Invoke(originList);
        }

        private void OnPasswordDataListAcquired(IntPtr alist)
        {
            if (passwordDataList != null)
            {
                passwordDataList.Dispose();
            }
            passwordDataList = new WebPasswordDataList(alist, true);
            List<WebPasswordData> pList = new List<WebPasswordData>();
            for(uint i = 0; i < passwordDataList.ItemCount; i++)
            {
                pList.Add(passwordDataList.GetItemAtIndex(i));
            }
            passwordDataListAcquiredCallback?.Invoke(pList);
        }

        private void OnHttpRequestIntercepted(IntPtr interceptor)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            httpRequestInterceptedCallback?.Invoke(new WebHttpRequestInterceptor(interceptor, true));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }
    }
}
