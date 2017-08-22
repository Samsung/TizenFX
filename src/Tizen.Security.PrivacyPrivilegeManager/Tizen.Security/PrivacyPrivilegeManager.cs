/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
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
using Tizen.Internals.Errors;

namespace Tizen.Security
{
    /// <summary>
    /// The PrivacyPrivilegeManager provides the properties or methods to check and request a permission for privacy privilege.
    /// </summary>
    public static class PrivacyPrivilegeManager
    {
        private const string LogTag = "Tizen.Privilege";
        private static Interop.PrivacyPrivilegeManager.RequestResponseCallback s_requestResponseCb;
        private static IDictionary<string, ResponseContext> s_responseMap = new Dictionary<string, ResponseContext>();

        static PrivacyPrivilegeManager()
        {
            s_requestResponseCb = (Interop.PrivacyPrivilegeManager.CallCause cause, Interop.PrivacyPrivilegeManager.RequestResult result, string privilege, IntPtr userData) =>
            {
                try
                {
                    s_responseMap[privilege].FireEvent((CallCause)cause, (RequestResult) result);
                }
                catch (Exception e)
                {
                    Log.Error(LogTag, "Exception in callback : " + e.Message);
                }
            };
        }

        /// <summary>
        /// Gets the status of a privacy privilege permission.
        /// </summary>
        /// <param name="privilege">The privacy privilege to be checked.</param>
        /// <returns>The permission setting for a respective privilege.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <example>
        /// <code>
        ///     CheckResult result = PrivacyPrivilegeManager.CheckPermission("http://tizen.org/privilege/account.read");
        ///     switch (result)
        ///     {
        ///         case Allow:
        ///             // Privilege can be used
        ///             break;
        ///         case Deny:
        ///             // Privilege can't be used
        ///             break;
        ///         case Ask:
        ///             // User permission request required
        ///             PrivacyPrivilegeManager.RequestPermission("http://tizen.org/privilege/account.read");
        ///             break;
        ///     }
        /// </code>
        /// </example>
        public static CheckResult CheckPermission(string privilege)
        {
            Interop.PrivacyPrivilegeManager.CheckResult result;
            int ret = (int)Interop.PrivacyPrivilegeManager.CheckPermission(privilege, out result);
            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to check permission");
                throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
            }
            return (CheckResult)result;
        }

        /// <summary>
        /// Triggers the permission request for a user.
        /// </summary>
        /// <param name="privilege">The privacy privilege to be requested.</param>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <example>
        /// <code>
        ///     CheckResult result = PrivacyPrivilegeManager.CheckPermission("http://tizen.org/privilege/account.read");
        ///     switch (result)
        ///     {
        ///         case Allow:
        ///             // Privilege can be used
        ///             break;
        ///         case Deny:
        ///             // Privilege can't be used
        ///             break;
        ///         case Ask:
        ///             // User permission request required
        ///             PrivacyPrivilegeManager.RequestPermission("http://tizen.org/privilege/account.read");
        ///             break;
        ///     }
        /// </code>
        /// </example>
        public static void RequestPermission(string privilege)
        {
            int ret = (int)Interop.PrivacyPrivilegeManager.RequestPermission(privilege, s_requestResponseCb, IntPtr.Zero);
            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to request permission");
                throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Gets the response context for a given privilege.
        /// </summary>
        /// <seealso cref="ResponseContext"/>
        /// <param name="privilege">The privilege.</param>
        /// <returns>The response context of a respective privilege.</returns>
        /// <exception cref="ArgumentException">Thrown if the key is an invalid parameter.</exception>
        /// <example>
        /// <code>
        /// private static void PPM_RequestResponse(object sender, RequestResponseEventArgs e)
        /// {
        ///     if (e.cause == CallCause.Answer)
        ///     {
        ///        switch(e.result)
        ///
        ///        {
        ///
        ///         case RequestResult.AllowForever:
        ///             Console.WriteLine("User allowed usage of privilege {0} definitely", e.privilege);
        ///             break;
        ///         case RequestResult.DenyForever:
        ///             Console.WriteLine("User denied usage of privilege {0} definitely", e.privilege);
        ///             break;
        ///         case RequestResult.DenyOnce:
        ///             Console.WriteLine("User denied usage of privilege {0} this time", e.privilege);
        ///             break;
        ///         };
        ///     }
        ///     else
        ///     {
        ///         Console.WriteLine("Error occured during requesting permission for {0}", e.privilege);
        ///     }
        ///}
        ///
        ///     PrivacyPrivilegeManager.ResponseContext context = null;
        ///     PrivacyPrivilegeManager.GetResponseContext("http://tizen.org/privilege/account.read").TryGetTarget(out context);
        ///     if(context != null)
        ///     {
        ///         context.ResponseFetched += PPM_RequestResponse;
        ///     }
        ///
        ///     PrivacyPrivilegeManager.RequestPermission("http://tizen.org/privilege/account.read");
        ///
        ///     PrivacyPrivilegeManager.GetResponseContext("http://tizen.org/privilege/account.read").TryGetTarget(out context);
        ///     if(context != null)
        ///     {
        ///         context.ResponseFetched -= PPM_RequestResponse;
        ///     }
        /// </code>
        /// </example>
        public static WeakReference<ResponseContext> GetResponseContext(string privilege)
        {
            if (!s_responseMap.ContainsKey(privilege))
            {
                s_responseMap[privilege] = new ResponseContext(privilege);
            }
            return new WeakReference<ResponseContext>(s_responseMap[privilege]);
        }

        /// <summary>
        /// This class manages event handlers of the privilege permission requests.
        /// This class enables having event handlers for an individual privilege.
        /// </summary>
        public class ResponseContext
        {
            private string _privilege;

            internal ResponseContext(string privilege)
            {
                _privilege = privilege;
            }
            /// <summary>
            /// Occurs when the response for a permission request is fetched.
            /// </summary>
            /// <exception cref="System.InvalidOperationException">Thrown when the bundle instance has been disposed.</exception>
            public event EventHandler<RequestResponseEventArgs> ResponseFetched
            {
                add
                {
                    _ResponseFetched += value;
                }

                remove
                {
                    _ResponseFetched -= value;
                    if (_ResponseFetched == null)
                    {
                        s_responseMap.Remove(_privilege);
                    }
                }
            }

            private event EventHandler<RequestResponseEventArgs> _ResponseFetched;

            internal void FireEvent(CallCause _cause, RequestResult _result)
            {
                _ResponseFetched?.Invoke(null, new RequestResponseEventArgs() { cause = _cause, result = _result, privilege = _privilege });
            }
        }
    }

    internal static class PrivacyPrivilegeManagerErrorFactory
    {
        static internal Exception GetException(int error)
        {
            Interop.PrivacyPrivilegeManager.ErrorCode errCode = (Interop.PrivacyPrivilegeManager.ErrorCode)error;
            switch(errCode)
            {
                case Interop.PrivacyPrivilegeManager.ErrorCode.InvalidParameter:
                    return new ArgumentException("Invalid parameter");
                case Interop.PrivacyPrivilegeManager.ErrorCode.IoError:
                    return new System.IO.IOException("I/O Error");
                case Interop.PrivacyPrivilegeManager.ErrorCode.OutOfMemory:
                    return new OutOfMemoryException("Out of memory");
                case Interop.PrivacyPrivilegeManager.ErrorCode.Unknown:
                default:
                    return new ArgumentException("Unknown error");
            }
        }
    }
}
