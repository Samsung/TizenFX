﻿/*
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
using System.Threading.Tasks;
using Tizen.Internals.Errors;

namespace Tizen.Account.FidoClient
{
    /// <summary>
    /// The FIDO UAF Client APIs
    /// </summary>
    /// <since_tizen> 3 </since_tizen>
    public static class UafClient
    {
        private static string _vendorName = null;
        private static int _majorVersion;
        private static int _minorVersion;

        static UafClient()
        {
            int ret = Interop.UafClient.FidoGetClientVendor(out _vendorName);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            ret = Interop.UafClient.FidoGetClientVersion(out _majorVersion, out _minorVersion);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// The FIDO Client vendor name
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static string VendorName
        {
            get
            {
                return _vendorName;
            }
        }

        /// <summary>
        /// The FIDO Client Major version
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static int MajorVersion
        {
            get
            {
                return _majorVersion;
            }
        }

        /// <summary>
        /// The FIDO Client Minor version
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static int MinorVersion
        {
            get
            {
                return _minorVersion;
            }
        }

        /// <summary>
        /// The FIDO Server response for successfull interaction.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        public static int StautsOk
        {
            get
            {
                return 1200;
            }
        }

        /// <summary>
        /// Checks whether the FIDO message can be processed
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="uafMessage">The FIDO UAF message which is received from the relying party server</param>
        /// <returns>True if the message can be handled by the device, else false</returns>
        /// <privilege>http://tizen.org/privilege/fido.client</privilege>
        /// <feature>http://tizen.org/feature/fido.uaf</feature>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method</exception>
        /// <exception cref="NotSupportedException">FIDO is not supported</exception>
        /// <example>
        /// <code>
        ///     UafMessage uafRequest = new UafMessage()
        ///     {
        ///         Operation = "UafRequestJson"
        ///     };
        ///     bool response = await UafClient.CheckPolicyAsync(uafRequest);
        /// </code>
        /// </example>
        public static async Task<bool> CheckPolicyAsync(UafMessage uafMessage)
        {
            if (uafMessage == null)
            {
                Log.Error(ErrorFactory.LogTag, "Invalid request or request is null");
                throw ErrorFactory.GetException((int)FidoErrorCode.InvalidParameter);
            }

            bool result = false;
            await Task.Run(() => result = CheckPolicy(uafMessage.Operation));
            return result;
        }

        /// <summary>
        /// Processes the given FIDO UAF message.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="uafMessage">The FIDO UAF message which is received from the relying party server</param>
        /// <param name="channelBindng">The channel binding data in JSON format which is received from the relying party server</param>
        /// <returns>FIDO response message</returns>
        /// <privilege>http://tizen.org/privilege/fido.client</privilege>
        /// <feature>http://tizen.org/feature/fido.uaf</feature>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method</exception>
        /// <exception cref="NotSupportedException">FIDO is not supported</exception>
        /// <example>
        /// <code>
        ///     UafMessage uafRequest = new UafMessage()
        ///     {
        ///         Operation = "UafAuthRequestJson"
        ///     };
        ///
        ///     var response = await UafClient.ProcessRequestAsync(uafRequest, null);
        /// </code>
        /// </example>
        public static async Task<UafResponse> ProcessRequestAsync(UafMessage uafMessage, string channelBindng)
        {
            if (uafMessage == null)
            {
                Log.Error(ErrorFactory.LogTag, "Invalid request or request is null");
                throw ErrorFactory.GetException((int)FidoErrorCode.InvalidParameter);
            }

            TaskCompletionSource<UafResponse> tcs = new TaskCompletionSource<UafResponse>();
            Interop.UafClient.FidoUafResponseMessageCallback cb = (int errorCode, string uafResponseJson, IntPtr userData) =>
            {
                if (uafMessage == null)
                {
                    Log.Error(ErrorFactory.LogTag, "Invalid request or request is null");
                    tcs.SetException(ErrorFactory.GetException((int)FidoErrorCode.InvalidParameter));
                }

                if (errorCode != (int)FidoErrorCode.None)
                {
                    Log.Error(ErrorFactory.LogTag, "Interop callback failed with error code: [" + errorCode + "]");
                    tcs.SetException(ErrorFactory.GetException(errorCode));
                }

                tcs.SetResult(new UafResponse() { Response = uafResponseJson });
            };

            int ret = Interop.UafClient.FidoUafGetResponseMessage(uafMessage.Operation, channelBindng, cb, IntPtr.Zero);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }

            return await tcs.Task;
        }

        /// <summary>
        /// Notifies the FIDO client about the server result. FIDO Server sends the result of processing a UAF message to FIDO client.
        /// </summary>
        /// <since_tizen> 3 </since_tizen>
        /// <param name="responseCode">The status code received from Server.(StautsOk implies success)</param>
        /// <param name="response">The FIDO response message sent to server in JSON format</param>
        /// <privilege>http://tizen.org/privilege/fido.client</privilege>
        /// <feature>http://tizen.org/feature/fido.uaf</feature>
        /// <remarks>
        /// This is especially important for cases when a new registration may be considered by the client to be in a pending state until it is communicated that the server accepted it
        /// </remarks>
        /// <exception cref="ArgumentException"> In case of invalid parameter</exception>
        /// <exception cref="UnauthorizedAccessException">Thrown when the application does not have privilege to access this method</exception>
        /// <exception cref="NotSupportedException">FIDO is not supported</exception>
        /// <example>
        /// <code>
        ///     UafResponse response = new UafResponse()
        ///     {
        ///         Response = "Responsejson"
        ///     };
        ///
        ///     await UafClient.NotifyResultAsync(UafClient.StautsOk, response);
        /// </code>
        /// </example>
        public static async Task NotifyResultAsync(int responseCode, UafResponse response)
        {
            if (response == null)
            {
                Log.Error(ErrorFactory.LogTag, "Invalid parameter");
                throw ErrorFactory.GetException((int)FidoErrorCode.InvalidParameter);
            }

            await Task.Run(() => NotifyResult(responseCode, response.Response));
        }

        private static bool CheckPolicy(string uafOperation)
        {
            bool isSupported;
            int ret = Interop.UafClient.FidoUafIsSupported(uafOperation, out isSupported);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ret + "]");
                throw ErrorFactory.GetException(ret);
            }
            return isSupported;
        }

        private static void NotifyResult(int responseCode, string response)
        {
            int ret = Interop.UafClient.FidoUafSetServerResult(responseCode, response);
            if (ret != (int)FidoErrorCode.None)
            {
                Log.Error(ErrorFactory.LogTag, "Interop API failed with error code: [" + ErrorFacts.GetErrorMessage(ret) + "]");
                throw ErrorFactory.GetException(ret);
            }
        }

    }
}
