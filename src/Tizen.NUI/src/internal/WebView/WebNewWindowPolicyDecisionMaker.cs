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
    /// It is a class for new window policy decision maker of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebNewWindowPolicyDecisionMaker : Disposable
    {
        internal WebNewWindowPolicyDecisionMaker(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// <summary>
        /// Decision type
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum DecisionType
        {
            /// <summary>
            /// Use
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Use,

            /// <summary>
            /// Download
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Download,

            /// <summary>
            /// Ignore
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
        public Uri GetUrl()
        {
            string result = Interop.WebNewWindowPolicyDecisionMaker.GetUrl(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new Uri(result);
        }

        /// <summary>
        /// Gets a cookie that web page has.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetCookie()
        {
            string result = Interop.WebNewWindowPolicyDecisionMaker.GetCookie(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a decision type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DecisionType GetDecisionType()
        {
            DecisionType result = (DecisionType)Interop.WebNewWindowPolicyDecisionMaker.GetDecisionType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a MIME type for response data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetResponseMime()
        {
            string result = Interop.WebNewWindowPolicyDecisionMaker.GetResponseMime(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a HTTP status code.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int GetResponseStatusCode()
        {
            int result = Interop.WebNewWindowPolicyDecisionMaker.GetResponseStatusCode(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets a navigation type.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public NavigationType GetNavigationType()
        {
            NavigationType result = (NavigationType)Interop.WebNewWindowPolicyDecisionMaker.GetNavigationType(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Gets frame of web view.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebFrame GetFrame()
        {
            IntPtr result = Interop.WebNewWindowPolicyDecisionMaker.GetFrame(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebFrame(result, false);
        }

        /// <summary>
        /// Gets a scheme.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetScheme()
        {
            string result = Interop.WebNewWindowPolicyDecisionMaker.GetScheme(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Accepts the action which triggers this decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Use()
        {
            bool result = Interop.WebNewWindowPolicyDecisionMaker.Use(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Ignores the action which triggers this decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Ignore()
        {
            bool result = Interop.WebNewWindowPolicyDecisionMaker.Ignore(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Suspends the operation for policy decision.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Suspend()
        {
            bool result = Interop.WebNewWindowPolicyDecisionMaker.Suspend(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }
    }
}
