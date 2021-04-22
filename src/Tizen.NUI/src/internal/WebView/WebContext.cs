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
        private string proxyUrl;
        private string appId;
        private string appVersion;
        private float timeOffset;
        private ApplicationType applicationType;
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
        /// Proxy url.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ProxyUrl
        {
            get
            {
                return proxyUrl;
            }
            set
            {
                if (value != null)
                {
                    Interop.WebContext.SetProxyUri(SwigCPtr, value);
                    if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                    proxyUrl = value;
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
        /// App id.
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
                Interop.WebContext.SetContextAppId(SwigCPtr, value);
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
                Interop.WebContext.SetContextAppVersion(SwigCPtr, value);
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
                Interop.WebContext.SetContextApplicationType(SwigCPtr, (int)value);
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
                Interop.WebContext.SetContextTimeOffset(SwigCPtr, value);
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
                return Interop.WebContext.GetContextDefaultZoomFactor(SwigCPtr);
            }
            set
            {
                Interop.WebContext.SetDefaultZoomFactor(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Gets context proxy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ContextProxy
        {
            get
            {
                return Interop.WebContext.GetContextProxy(SwigCPtr);
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
        /// <param name="origin">security origin of web storage</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool DeleteWebStorage(WebSecurityOrigin origin)
        {
            bool result = Interop.WebContext.DeleteWebStorage(SwigCPtr, WebSecurityOrigin.getCPtr(origin));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Deletes local fileSystem.
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

        /// <summary>
        /// Sets context time zone offset.
        /// <param name="offset">Time offset</param>
        /// <param name="time">Daylight saving time</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetContextTimeZoneOffset(float offset, float time)
        {
            Interop.WebContext.SetContextTimeZoneOffset(SwigCPtr, offset, time);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers url schemes enabled.
        /// <param name="strArray">The string array of schemes</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterUrlSchemesAsCorsEnabled(string[] strArray)
        {
            if (strArray != null)
            {
                Interop.WebContext.RegisterUrlSchemesAsCorsEnabled(SwigCPtr, strArray, (uint)strArray.Length);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Registers js plugin mime types.
        /// <param name="strArray">The string array of types</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJsPluginMimeTypes(string[] strArray)
        {
            if (strArray != null)
            {
                Interop.WebContext.RegisterJsPluginMimeTypes(SwigCPtr, strArray, (uint)strArray.Length);
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
        /// <param name="strArray">The string array of dataList</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteFormPasswordDataList(string[] strArray)
        {
            if (strArray != null)
            {
                Interop.WebContext.DeleteFormPasswordDataList(SwigCPtr, strArray, (uint)strArray.Length);
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
        /// Sets context proxy.
        /// <param name="proxy">The string array of dataList</param>
        /// <param name="rule">Bypass rule</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetContextProxy(string proxy, string rule)
        {
            Interop.WebContext.SetContextProxy(SwigCPtr, proxy, rule);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
