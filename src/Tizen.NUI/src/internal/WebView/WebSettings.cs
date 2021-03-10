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
    /// WebSettings is a class for settings of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebSettings : Disposable
    {
        private bool allowMixedContents;
        private bool enableSpatialNavigation;
        private bool enableWebSecurity;
        private bool allowFileAccessFromExternalUrl;
        private bool allowScriptsOpenWindows;

        internal WebSettings(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Allow Mixed Contents
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowMixedContents
        {
            get
            {
                return allowMixedContents;
            }
            set
            {
                allowMixedContents = value;
                Interop.WebSettings.AllowMixedContents(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Enable Spatial Navigation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableSpatialNavigation
        {
            get
            {
                return enableSpatialNavigation;
            }
            set
            {
                enableSpatialNavigation = value;
                Interop.WebSettings.EnableSpatialNavigation(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Default Font Size.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DefaultFontSize
        {
            get
            {
                return Interop.WebSettings.GetDefaultFontSize(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.SetDefaultFontSize(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Enable web security.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableWebSecurity
        {
            get
            {
                return enableWebSecurity;
            }
            set
            {
                enableWebSecurity = value;
                Interop.WebSettings.EnableWebSecurity(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Allow File Access From External Url.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowFileAccessFromExternalUrl
        {
            get
            {
                return allowFileAccessFromExternalUrl;
            }
            set
            {
                allowFileAccessFromExternalUrl = value;
                Interop.WebSettings.AllowFileAccessFromExternalUrl(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Enable JavaScript.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableJavaScript
        {
            get
            {
                return Interop.WebSettings.IsJavaScriptEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableJavaScript(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Allow Scripts Open Windows.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowScriptsOpenWindows
        {
            get
            {
                return allowScriptsOpenWindows;
            }
            set
            {
                allowScriptsOpenWindows = value;
                Interop.WebSettings.AllowScriptsOpenWindows(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Allow Images Load Automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AllowImagesLoadAutomatically
        {
            get
            {
                return Interop.WebSettings.AreImagesAutomaticallyLoaded(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.AllowImagesLoadAutomatically(SwigCPtr, value);
            }
        }

        /// <summary>
        /// Default Text Encoding Name.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DefaultTextEncodingName
        {
            get
            {
                return Interop.WebSettings.GetDefaultTextEncodingName(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.SetDefaultTextEncodingName(SwigCPtr, value);
            }
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebSettings obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }
    }
}
