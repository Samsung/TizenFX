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
    /// It is a class for policy decision maker of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebPolicyDecisionMaker : Disposable
    {
        internal WebPolicyDecisionMaker(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Decision type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DecisionType
        {
            /// <summary>
            /// Accepts the decision.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Use,

            /// <summary>
            /// Decides to download something.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Download,

            /// <summary>
            /// Ignores the decision.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Ignore,
        }

        /// <summary>
        /// Policy navigation type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum NavigationType
        {
            /// <summary>
            /// Link clicked
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            LinkClicked,

            /// <summary>
            /// Form submitted
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FormSubmitted,

            /// <summary>
            /// Back forward
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            BackForward,

            /// <summary>
            /// Reload
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Reload,

            /// <summary>
            /// Form resubmitted
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            FormResubmitted,

            /// <summary>
            /// Other
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Other,
        }

        /// <summary>
        /// Gets the url that request policy decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return Interop.WebPolicyDecisionMaker.GetUrl(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets a cookie that web page has.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Cookie
        {
            get
            {
                return Interop.WebPolicyDecisionMaker.GetCookie(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets a decision type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DecisionType PolicyDecisionType
        {
            get
            {
                return (DecisionType)Interop.WebPolicyDecisionMaker.GetDecisionType(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets a MIME type for response data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string ResponseMime
        {
            get
            {
                return Interop.WebPolicyDecisionMaker.GetResponseMime(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets a HTTP status code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int ResponseStatusCode
        {
            get
            {
                return Interop.WebPolicyDecisionMaker.GetResponseStatusCode(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets a navigation type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NavigationType DecisionNavigationType
        {
            get
            {
                return (NavigationType)Interop.WebPolicyDecisionMaker.GetNavigationType(SwigCPtr);
            }
        }

        /// <summary>
        /// Gets frame of web view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebFrame Frame
        {
            get
            {
                IntPtr result = Interop.WebPolicyDecisionMaker.GetFrame(SwigCPtr);
                return new WebFrame(result, false);
            }
        }

        /// <summary>
        /// Gets a scheme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Scheme
        {
            get
            {
                return Interop.WebPolicyDecisionMaker.GetScheme(SwigCPtr);
            }
        }

        /// <summary>
        /// Accepts the action which triggers this decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Use()
        {
            bool result = Interop.WebPolicyDecisionMaker.Use(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Ignores the action which triggers this decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignore()
        {
            bool result = Interop.WebPolicyDecisionMaker.Ignore(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Suspends the operation for policy decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Suspend()
        {
            bool result = Interop.WebPolicyDecisionMaker.Suspend(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
