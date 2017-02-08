/*
 * Copyright (c) 2016 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Collections.Generic;

namespace Tizen.Account.FidoClient
{
    /// <summary>
    /// Contains information about the authenticators registered on the device.
    /// </summary>
    /// <example>
    /// <code>
    ///     IEnumerable<AuthenticatorInformation> authInfos = await UafAuthenticatorFinder.DiscoverAuthenticatorsAsync();
    ///     foreach (AuthenticatorInformation authInfo in authInfos)
    ///     {
    ///         string aaid = authInfo.Aaid;
    ///         string title = authInfo.Title;
    ///     }
    /// </code>
    /// </example>
    public class AuthenticatorInformation
    {
        internal AuthenticatorInformation()
        {
        }

        /// <summary>
        /// The authenticator Title
        /// </summary>
        public string Title { get; internal set; }

        /// <summary>
        /// The Authenticator AAID (Authenticator Attestation ID)
        /// </summary>
        public string Aaid { get; internal set; }

        /// <summary>
        /// The Authenticator description
        /// </summary>
        public string Description { get; internal set; }

        /// <summary>
        /// The Authenticator assertion scheme.
        /// </summary>
        public string AssertionScheme { get; internal set; }

        /// <summary>
        /// The Authenticator algorithm.
        /// </summary>
        public AuthenticationAlgorithm AuthenticationAlgorithm { get; internal set; }

        /// <summary>
        /// The user verification method of this Authenticator
        /// </summary>
        public UserVerificationMethod UserVerification { get; internal set; }

        /// <summary>
        /// The key protection method of this Authenticator.
        /// </summary>
        public KeyProtectionType KeyProtection { get; internal set; }

        /// <summary>
        /// The matcher protection method of this Authenticator.
        /// </summary>
        public MatcherProtectionType MatcherProtection { get; internal set; }

        /// <summary>
        /// The attachment hint of this Authenticator.
        /// </summary>
        public AuthenticatorAttachmentHint AttachmentHint { get; internal set; }

        /// <summary>
        /// Denotes the Authenticator is Second factor only which is supported by U2F standards.
        /// </summary>
        public bool IsSecondFactorOnly { get; internal set; }

        /// <summary>
        /// The available attestation types for this Authenticator.
        /// </summary>
        public IEnumerable<AuthenticatorAttestationType> AttestationTypes { get; internal set; }

        /// <summary>
        /// The Transaction Confirmation display type of this Authenticator.
        /// </summary>
        public TransactionConfirmationDisplayType TcDisplayType { get; internal set; }

        /// <summary>
        /// The Transaction Confirmation display type of this Authenticator.
        /// </summary>
        public string TcDisplayContentType { get; internal set; }

        /// <summary>
        /// The icon of this Authenticator.
        /// </summary>
        public string Icon { get; internal set; }
    }
}