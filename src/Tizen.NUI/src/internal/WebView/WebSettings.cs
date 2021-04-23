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
        private bool enableCacheBuilder;
        private bool enableDoNotTrack;
        private bool allowFileAccessFromExternalUrl;
        private bool allowScriptsOpenWindows;
        private bool useScrollbarThumbFocusNotifications;
        private bool viewportMetaTag;

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
                Interop.WebSettings.AllowMixedContents(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                allowMixedContents = value;
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
                Interop.WebSettings.EnableSpatialNavigation(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                enableSpatialNavigation = value;
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
                Interop.WebSettings.EnableWebSecurity(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                enableWebSecurity = value;
            }
        }

        /// <summary>
        /// Enable cache builer
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CacheBuilderEnabled
        {
            get 
            {
                return enableCacheBuilder;
            }
            set 
            {
                Interop.WebSettings.EnableCacheBuilder(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                enableCacheBuilder = value;
            }
        }

        /// <summary>
        /// Enable do not track, to protect user privacy security.
        /// </summary>
        public bool DoNotTrackEnabled
        {
            get
            {
                return enableDoNotTrack;
            }
            set
            {
                Interop.WebSettings.EnableDoNotTrack(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                enableDoNotTrack = value;
            }
        }

        /// <summary>
        /// Use scrollbar thumb focus notifications
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollbarThumbFocusNotificationsUsed
        {
            get
            {
                return useScrollbarThumbFocusNotifications;
            }
            set
            {
                Interop.WebSettings.UseScrollbarThumbFocusNotifications(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                useScrollbarThumbFocusNotifications = value;
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
                Interop.WebSettings.AllowFileAccessFromExternalUrl(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                allowFileAccessFromExternalUrl = value;
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            }
        }

        /// <summary>
        /// Enable auto fitting
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
        /// Enable plugins
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
        /// Enable private browsing
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
        /// Enable link magnifier
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
        /// Use keypad without user action
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
        /// Enable autofill password form
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
        /// Enable form candidate data
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
        /// Enable text selection
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
        /// Enable text autosizing
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
        /// Enable arrow scroll
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
        /// Enable clipboard
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
        /// Enable ime panel
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
                Interop.WebSettings.AllowScriptsOpenWindows(SwigCPtr, value);
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
                allowScriptsOpenWindows = value;
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
                if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
        ///  Force zoom
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
        ///  Enable text zoom
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
        ///  Enable extra feature
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
        ///  Enable extra feature
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
