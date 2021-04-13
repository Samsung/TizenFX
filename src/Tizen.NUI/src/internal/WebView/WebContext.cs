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
    /// WebContext is a class for context of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebContext : Disposable
    {
        private string proxyUri;
        private string certificateFilePath;
        private bool disableCache;

        internal WebContext(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

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
        /// Delete Web Database.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteWebDatabase()
        {
            Interop.WebContext.DeleteWebDatabase(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Delete Web Storage.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void DeleteWebStorage()
        {
            Interop.WebContext.DeleteWebStorage(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Delete Local FileSystem.
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
    }
}
