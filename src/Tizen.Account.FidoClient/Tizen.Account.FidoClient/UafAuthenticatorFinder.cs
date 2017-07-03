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
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace Tizen.Account.FidoClient
{
    /// <summary>
    /// Class to find available FIDO specific authenticators on the device
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class UafAuthenticatorFinder
    {
        /// <summary>
        /// Retrieves  all the available FIDO authenticators supported by this Device.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <returns>Enumerable list of authenticators</returns>
        /// <privilege>http://tizen.org/privilege/fido.client</privilege>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method</exception>
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
        public static async Task<IEnumerable<AuthenticatorInformation>> DiscoverAuthenticatorsAsync()
        {
            IEnumerable<AuthenticatorInformation> result = null;
            await Task.Run(() => result = Discover());
            return result;
        }

        private static IEnumerable<AuthenticatorInformation> Discover()
        {
            IList<AuthenticatorInformation> result = new List<AuthenticatorInformation>();

            Interop.UafAuthenticator.FidoAuthenticatorCallback cb = (IntPtr authHandle, IntPtr userData) =>
            {
                Log.Info(ErrorFactory.LogTag, "Iterating authenticators");
                result.Add(GetAuthInfo(authHandle));
            };

            int ret = Interop.UafAuthenticator.ForeachAuthenticator(cb, IntPtr.Zero);
            if(ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            return result;
        }

        private static AuthenticatorInformation GetAuthInfo(IntPtr authHandle)
        {
            var authInfo = new AuthenticatorInformation();

            IntPtr stringPtr;
            int ret = Interop.UafAuthenticator.GetTitle(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.Title = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.UafAuthenticator.GetAaid(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.Aaid = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.UafAuthenticator.GetDescription(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.Description = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.UafAuthenticator.GetAssertionScheme(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.AssertionScheme = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            int authAlgo;
            ret = Interop.UafAuthenticator.GetAlgorithm(authHandle, out authAlgo);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            int usrVerificationMethod;
            ret = Interop.UafAuthenticator.GetVerificationMethod(authHandle, out usrVerificationMethod);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            int keyProtectionType;
            ret = Interop.UafAuthenticator.GetKeyProtectionMethod(authHandle, out keyProtectionType);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            int matcherProtection;
            ret = Interop.UafAuthenticator.GetMatcherProtectionMethod(authHandle, out matcherProtection);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            int attachmentHint;
            ret = Interop.UafAuthenticator.GetAttachmentHint(authHandle, out attachmentHint);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            bool isSecondaryOnly = Interop.UafAuthenticator.GetIsSecondFactorOnly(authHandle);

            int tcDisplayType;
            ret = Interop.UafAuthenticator.GetTcDiscplay(authHandle, out tcDisplayType);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.UafAuthenticator.GetTcDisplayType(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.TcDisplayContentType = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            ret = Interop.UafAuthenticator.GetIcon(authHandle, out stringPtr);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            authInfo.Icon = Marshal.PtrToStringAnsi(stringPtr);
            Interop.Libc.Free(stringPtr);

            var attestationTypes = new List<AuthenticatorAttestationType> ();
            Interop.UafAuthenticator.FidoAttestationTypeCallback cb = (int type, IntPtr usrData) =>
            {
                attestationTypes.Add((AuthenticatorAttestationType)type);
            };

            ret = Interop.UafAuthenticator.ForeachAttestationType(authHandle, cb, IntPtr.Zero);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            authInfo.AuthenticationAlgorithm = (AuthenticationAlgorithm)authAlgo;
            authInfo.UserVerification = (UserVerificationMethod)usrVerificationMethod;
            authInfo.KeyProtection = (KeyProtectionType)keyProtectionType;
            authInfo.MatcherProtection = (MatcherProtectionType)matcherProtection;
            authInfo.AttachmentHint = (AuthenticatorAttachmentHint)attachmentHint;
            authInfo.IsSecondFactorOnly = isSecondaryOnly;
            authInfo.TcDisplayType = (TransactionConfirmationDisplayType)tcDisplayType;
            authInfo.AttestationTypes = attestationTypes;

            return authInfo;
        }
    }
}
