/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.ComponentModel;

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration values used to specify Policy Navigation Type.
    /// </summary>
    public enum NavigationType {
        /// <summary>
        /// Link Clicked.
        /// </summary>
        LinkClicked = 0,
        /// <summary>
        /// Form Submitted.
        /// </summary>
        FormSubmitted = 1,
        /// <summary>
        /// Back Forward.
        /// </summary>
        BackForward = 2,
        /// <summary>
        /// Reload.
        /// </summary>
        Reload = 3,
        /// <summary>
        /// Form Submitted.
        /// </summary>
        FormResubmitted = 4,
        /// <summary>
        /// Other.
        /// </summary>
        Other = 5
    };

    /// <summary>
    /// Arguments from the policy decision events.
    /// This class also provides the properties for Policy Decision of WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public abstract class PolicyDecisionEventArgs : EventArgs
    {
        private IntPtr _handle;

        internal PolicyDecisionEventArgs(IntPtr handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the Url.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Url
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_url_get(_handle);
            }
        }

        /// <summary>
        /// Gets the scheme.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Scheme
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_scheme_get(_handle);
            }
        }

        /// <summary>
        /// Ignores the action which triggers this decision.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Ignore()
        {
            Interop.ChromiumEwk.ewk_policy_decision_ignore(_handle);
        }

        /// <summary>
        /// Accepts the action which triggers this decision.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Use()
        {
            Interop.ChromiumEwk.ewk_policy_decision_use(_handle);
        }

        /// <summary>
        /// Checks if frame requested in policy decision is main frame.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsMainFrame()
        {
            return Interop.ChromiumEwk.ewk_policy_decision_is_main_frame(_handle);
        } 
    }

    /// <summary>
    /// This class is derived from PolicyDecisionEventArgs.
    /// This class provides the properties for New Window Policy of WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class NewWindowPolicyEventArgs : PolicyDecisionEventArgs 
    {
        private IntPtr _handle;
        internal NewWindowPolicyEventArgs(IntPtr handle) : base(handle)
        {
            _handle = handle;
        }
        
        internal static NewWindowPolicyEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new NewWindowPolicyEventArgs(info);
        }
    }


    /// <summary>
    /// This class is derived from PolicyDecisionEventArgs.
    /// This class provides the properties for Navigation Policy of WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class NavigationPolicyEventArgs : PolicyDecisionEventArgs
    {
        private IntPtr _handle;
        internal NavigationPolicyEventArgs(IntPtr handle) : base(handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets the Navigation Type of policy.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public NavigationType NavigationType
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_navigation_type_get(_handle);
            }
        }

        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Cookie
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_cookie_get(_handle);
            }
        }

        internal static NavigationPolicyEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new NavigationPolicyEventArgs(info);
        }
    }

    /// <summary>
    /// This class is derived from PolicyDecisionEventArgs.
    /// This class provides the properties for Response Policy of WebView.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public class ResponsePolicyEventArgs : PolicyDecisionEventArgs
    {
        private IntPtr _handle;
        internal ResponsePolicyEventArgs(IntPtr handle) : base(handle)
        {
            _handle = handle;
        }

        /// <summary>
        /// Gets http response status code.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public int StatusCode
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_response_status_code_get(_handle);
            }
        }

        /// <summary>
        /// Gets the cookie.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public string Cookie
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_cookie_get(_handle);
            }
        }
        
        /// <summary>
        /// Checks policy decision type is Download.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public bool IsDownload
        {
            get
            {
                return Interop.ChromiumEwk.ewk_policy_decision_type_get(_handle) == Interop.ChromiumEwk.PolicyDecisionType.Download;
            }
        }

        internal static ResponsePolicyEventArgs CreateFromSmartEvent(IntPtr data, IntPtr obj, IntPtr info)
        {
            return new ResponsePolicyEventArgs(info);
        }
    }
}
