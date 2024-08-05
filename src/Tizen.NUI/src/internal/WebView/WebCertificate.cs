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
    /// It is a class for certificate of web view.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebCertificate : Disposable
    {
        internal WebCertificate(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
        {
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebCertificate.DeleteWebCertificate(swigCPtr);
        }

        /// <summary>
        /// Checks whether the certificate comes from main frame.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsFromMainFrame
        {
            get
            {
                bool result = Interop.WebCertificate.IsFromMainFrame(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return false;
                return result;
            }
        }

        /// <summary>
        /// Queries certificate's PEM data.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string PemData
        {
            get
            {
                string result = Interop.WebCertificate.GetPem(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return null;
                return result;
            }
        }

        /// <summary>
        /// Queries if the context loaded with a given certificate is secure.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool IsContextSecure
        {
            get
            {
                bool result = Interop.WebCertificate.IsContextSecure(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return false;
                return result;
            }
        }

        /// <summary>
        /// Allows the site access about certificate error.
        /// </summary>
        /// <param name="allowed">Allowed or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Allow(bool allowed)
        {
            Interop.WebCertificate.Allow(SwigCPtr, allowed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get certificate policy decision error.
        /// </summary>
        /// <value>PolicyDecisionErrorType</value>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public PolicyDecisionErrorType PolicyDecisionError
        {
            get
            {
                int result = Interop.WebCertificate.GetPolicyDecisionError(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending) return PolicyDecisionErrorType.Unknown;
                return (PolicyDecisionErrorType)result;
            }
        }

        /// <summary>
        /// Suspend certification policy decision.
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool Suspend()
        {
            bool ret = Interop.WebCertificate.SuspendPolicyDecision(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum PolicyDecisionErrorType
        {
            CommonNameInvalid, //The server responded with a certificate whose common name did not match the host name.
            DateInvalid, //The server responded with a certificate that by our clock, appears to either not yet be valid or to have expired.
            AuthorityInvalid, // The server responded with a certificate that is signed by an authority we don't trust.
            NoRevocationMechanism, // The certificate has no mechanism for determining if it is revoked. In effect, this certificate cannot be revoked.
            UnableToCheckRevocation, // Revocation information for the security certificate for this site is not available.
            Revoked, // The server responded with a certificate that has been revoked.
            Invalid, // The server responded with a certificate that is invalid.
            WeakAlgorithm, // The server responded with a certificate that is signed using a weak signature algorithm.
            NonUniqueName, // The host name specified in the certificate is not unique.
            WeakKey, // The server responded with a certificate that contains a weak key (e.g. a too-small RSA key).
            PinnedKeyNotInChain, // The certificate didn't match the public key pins for the host name.
            NameViolation, // The certificate claimed DNS names that are in violation of name constraints.
            ValidityTooLong, // The certificate's validity period is too long.
            Unknown = 1000 // Reported in case of wrong usage of ewk_certificate_policy_decision_error_get API.
        }
    }
}
