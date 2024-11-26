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
        private bool mixedContentsAllowed;
        private bool spatialNavigationEnabled;
        private bool webSecurityEnabled;
        private bool cacheBuilderEnabled;
        private bool doNotTrackEnabled;
        private bool fileAccessFromExternalUrlAllowed;
        private bool scriptsOpenWindowsAllowed;
        private bool scrollbarThumbFocusNotificationsUsed;
        private bool viewportMetaTag;

        internal WebSettings(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Enumeration for style of IME.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum WebImeStyle
        {
            /// <summary>
            /// Full IME style
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Full = 0,

            /// <summary>
            /// Floating IME style
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Floating,

            /// <summary>
            /// Dynamic IME style
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Dynamic,
        }

        /// <summary>
        /// Allows mixed contents or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MixedContentsAllowed
        {
            get
            {
                return mixedContentsAllowed;
            }
            set
            {
                Interop.WebSettings.AllowMixedContents(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                mixedContentsAllowed = value;
            }
        }

        /// <summary>
        /// Enables spatial navigation or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SpatialNavigationEnabled
        {
            get
            {
                return spatialNavigationEnabled;
            }
            set
            {
                Interop.WebSettings.EnableSpatialNavigation(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                spatialNavigationEnabled = value;
            }
        }

        /// <summary>
        /// Default font size.
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables web security or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool WebSecurityEnabled
        {
            get
            {
                return webSecurityEnabled;
            }
            set
            {
                Interop.WebSettings.EnableWebSecurity(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                webSecurityEnabled = value;
            }
        }

        /// <summary>
        /// Enables cache builder.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CacheBuilderEnabled
        {
            get 
            {
                return cacheBuilderEnabled;
            }
            set 
            {
                Interop.WebSettings.EnableCacheBuilder(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                cacheBuilderEnabled = value;
            }
        }

        /// <summary>
        /// Enables web feature that does not track to protect user privacy security.
        /// </summary>
        public bool DoNotTrackEnabled
        {
            get
            {
                return doNotTrackEnabled;
            }
            set
            {
                Interop.WebSettings.EnableDoNotTrack(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                doNotTrackEnabled = value;
            }
        }

        /// <summary>
        /// Uses scrollbar thumb focus notifications
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollbarThumbFocusNotificationsUsed
        {
            get
            {
                return scrollbarThumbFocusNotificationsUsed;
            }
            set
            {
                Interop.WebSettings.UseScrollbarThumbFocusNotifications(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                scrollbarThumbFocusNotificationsUsed = value;
            }
        }

        /// <summary>
        /// Allows file access from external url or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FileAccessFromExternalUrlAllowed
        {
            get
            {
                return fileAccessFromExternalUrlAllowed;
            }
            set
            {
                Interop.WebSettings.AllowFileAccessFromExternalUrl(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                fileAccessFromExternalUrlAllowed = value;
            }
        }

        /// <summary>
        /// Enables JavaScript or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool JavaScriptEnabled
        {
            get
            {
                return Interop.WebSettings.IsJavaScriptEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableJavaScript(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables auto fitting
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutoFittingEnabled
        {
            get
            {
                return Interop.WebSettings.IsAutoFittingEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableAutoFitting(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables plugins
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PluginsEnabled
        {
            get
            {
                return Interop.WebSettings.ArePluginsEnabled(SwigCPtr);
            }
            set 
            {
                Interop.WebSettings.EnablePlugins(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables private browsing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool PrivateBrowsingEnabled
        {
            get
            {
                return Interop.WebSettings.IsPrivateBrowsingEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnablePrivateBrowsing(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables link magnifier
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LinkMagnifierEnabled
        {
            get
            {
                return Interop.WebSettings.IsLinkMagnifierEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableLinkMagnifier(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Uses keypad without user action
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeypadWithoutUserActionUsed
        {
            get
            {
                return Interop.WebSettings.IsKeypadWithoutUserActionUsed(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.UseKeypadWithoutUserAction(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables autofill password form
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutofillPasswordFormEnabled
        {
            get
            {
                return Interop.WebSettings.IsAutofillPasswordFormEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableAutofillPasswordForm(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables form candidate data
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool FormCandidateDataEnabled
        {
            get
            {
                return Interop.WebSettings.IsFormCandidateDataEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableFormCandidateData(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables text selection
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextSelectionEnabled
        {
            get
            {
                return Interop.WebSettings.IsTextSelectionEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableTextSelection(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables text autosizing
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextAutosizingEnabled
        {
            get
            {
                return Interop.WebSettings.IsTextAutosizingEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableTextAutosizing(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables arrow scroll
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ArrowScrollEnabled
        {
            get
            {
                return Interop.WebSettings.IsArrowScrollEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableArrowScroll(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables clipboard
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ClipboardEnabled
        {
            get
            {
                return Interop.WebSettings.IsClipboardEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableClipboard(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enables IME panel
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ImePanelEnabled
        {
            get
            {
                return Interop.WebSettings.IsImePanelEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.EnableImePanel(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Allows scripts open windows or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScriptsOpenWindowsAllowed
        {
            get
            {
                return scriptsOpenWindowsAllowed;
            }
            set
            {
                Interop.WebSettings.AllowScriptsOpenWindows(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                scriptsOpenWindowsAllowed = value;
            }
        }

        /// <summary>
        /// Allows images load automatically or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AutomaticImageLoadingAllowed
        {
            get
            {
                return Interop.WebSettings.AreImagesLoadedAutomatically(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.AllowImagesLoadAutomatically(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Default text encoding name.
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        ///  Viewport meta tag.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ViewportMetaTag
        {
            get
            {
                return viewportMetaTag;
            }
            set
            {
                Interop.WebSettings.SetViewportMetaTag(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                viewportMetaTag = value;
            }
        }

        /// <summary>
        ///  Forces zoom
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ZoomForced
        {
            get
            {
                return Interop.WebSettings.IsZoomForced(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.SetForceZoom(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        ///  Enables text zoom
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TextZoomEnabled
        {
            get
            {
                return Interop.WebSettings.IsTextZoomEnabled(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.SetTextZoomEnabled(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        ///  The style of IME.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebImeStyle ImeStyle
        {
            get
            {
                return (WebImeStyle)Interop.WebSettings.GetImeStyle(SwigCPtr);
            }
            set
            {
                Interop.WebSettings.SetImeStyle(SwigCPtr, (int)value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        ///  Enables the given extra feature.
        /// </summary>
        /// <param name="str">The string of extra feature.</param>
        /// <param name="tag">Enable or disable.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EnableExtraFeature(string str, bool tag)
        {
            Interop.WebSettings.SetExtraFeature(SwigCPtr, str, tag);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        ///  Checks the extra feature is enabled or not.
        /// </summary>
        /// <param name="str">The string of extra feature.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsExtraFeatureEnabled(string str)
        {
            bool ret = Interop.WebSettings.IsExtraFeatureEnabled(SwigCPtr, str);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }
    }
}
