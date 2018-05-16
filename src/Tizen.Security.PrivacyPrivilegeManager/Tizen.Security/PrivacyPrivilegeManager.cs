/*
 * Copyright (c) 2017 - 2018 Samsung Electronics Co., Ltd All Rights Reserved
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
using System.Linq;
using System.Threading.Tasks;
using Tizen.Internals.Errors;

namespace Tizen.Security
{
    /// <summary>
    /// The PrivacyPrivilegeManager provides the properties or methods to check and request a permission for privacy privilege.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class PrivacyPrivilegeManager
    {
        private const string LogTag = "Tizen.Privilege";
        private static Interop.PrivacyPrivilegeManager.RequestResponseCallback s_requestResponseCb =
                       (Interop.PrivacyPrivilegeManager.CallCause cause, Interop.PrivacyPrivilegeManager.RequestResult result,
                           string privilege, IntPtr userData) =>
                        {
                            try
                            {
                                if (s_responseMap.TryGetValue(privilege, out ResponseContext ctx) && ctx != null)
                                {
                                    ctx.FireEvent((CallCause)cause, (RequestResult)result);

                                }
                                else
                                {
                                    s_responseMap.Remove(privilege);
                                    Log.Error(LogTag, "No listener for: " + privilege);
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Error(LogTag, "Exception in callback : " + e.Message);
                            }
                            s_PrivilegesInProgress.Remove(privilege);
                        };

        private static IDictionary<string, ResponseContext> s_responseMap = new Dictionary<string, ResponseContext>();
        private static HashSet<string> s_PrivilegesInProgress = new HashSet<string>();

        private static string[] CheckPrivilegesArgument(IEnumerable<string> privileges, string methodName)
        {
            if (privileges == null || !privileges.Any())
            {
                Log.Error(LogTag, "privileges for " + methodName + " are null or empty.");
                throw new ArgumentException("privileges for " + methodName + " are null or empty.");
            }

            foreach (var privilege in privileges)
            {
                if (string.IsNullOrEmpty(privilege))
                {
                    Log.Error(LogTag, " At least one privilege for " + methodName + " is null or empty.");
                    throw new ArgumentException(" At least one privilege for " + methodName + " is null or empty.");
                }
            }

            return privileges as string[] ?? privileges.ToArray();
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
        /// <since_tizen> 4 </since_tizen>
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
        /// Gets the status of a privacy privileges permission.
        /// </summary>
        /// <param name="privileges">The privacy privileges to be checked.</param>
        /// <returns>The permission setting for a respective privileges.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <example>
        /// <code>
        ///     string[] privileges = new [] {"http://tizen.org/privilege/account.read",
        ///                                   "http://tizen.org/privilege/alarm"};
        ///     CheckResult[] results = PrivacyPrivilegeManager.CheckPermissions(privileges).ToArray();
        ///     List&lt;string&gt; privilegesWithAskStatus = new List&lt;string&gt;();
        ///     for (int iterator = 0; iterator &lt; results.Length; ++iterator)
        ///     {
        ///         switch (results[iterator])
        ///         {
        ///             case CheckResult.Allow:
        ///                 // Privilege can be used
        ///                 break;
        ///             case CheckResult.Deny:
        ///                 // Privilege can't be used
        ///                 break;
        ///             case CheckResult.Ask:
        ///                 // User permission request required
        ///                 privilegesWithAskStatus.Add(privileges[iterator]);
        ///                 break;
        ///         }
        ///     }
        ///     PrivacyPrivilegeManager.RequestPermissions(privilegesWithAskStatus);
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public static IEnumerable<CheckResult> CheckPermissions(IEnumerable<string> privileges)
        {
            string[] privilegesArray = CheckPrivilegesArgument(privileges, "CheckPermissions");

            Interop.PrivacyPrivilegeManager.CheckResult[] results = new Interop.PrivacyPrivilegeManager.CheckResult[privilegesArray.Length];
            int ret = (int)Interop.PrivacyPrivilegeManager.CheckPermissions(privilegesArray, (uint)privilegesArray.Length, results);
            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to check permission");
                throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
            }

            CheckResult[] checkResults = new CheckResult[results.Length];
            for (int iterator = 0; iterator < results.Length; ++iterator)
            {
                checkResults[iterator] = (CheckResult)results[iterator];
            }
            return checkResults;
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
        /// <since_tizen> 4 </since_tizen>
        public static void RequestPermission(string privilege)
        {
            if (!s_PrivilegesInProgress.Add(privilege))
            {
                Log.Error(LogTag, "Request for this privilege: " + privilege + " is already in progress.");
                throw new ArgumentException("Request for this privilege: " + privilege + " is already in progress.");
            }

            int ret = (int)Interop.PrivacyPrivilegeManager.RequestPermission(privilege, s_requestResponseCb, IntPtr.Zero);
            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to request permission");
                s_PrivilegesInProgress.Remove(privilege);
                throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
            }
        }

        /// <summary>
        /// Triggers the permissions request for a user.
        /// </summary>
        /// <param name="privileges">The privacy privileges to be requested.</param>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <returns>Permission request Task</returns>
        /// <example>
        /// <code>
        ///     string[] privileges = new [] {"http://tizen.org/privilege/account.read",
        ///                                   "http://tizen.org/privilege/alarm"};
        ///     CheckResult[] results = PrivacyPrivilegeManager.CheckPermissions(privileges).ToArray();
        ///     List&lt;string&gt; privilegesWithAskStatus = new List&lt;string&gt;();
        ///     for (int iterator = 0; iterator &lt; results.Length; ++iterator)
        ///     {
        ///         switch (results[iterator])
        ///         {
        ///             case CheckResult.Allow:
        ///                 // Privilege can be used
        ///                 break;
        ///             case CheckResult.Deny:
        ///                 // Privilege can't be used
        ///                 break;
        ///             case CheckResult.Ask:
        ///                 // User permission request required
        ///                 privilegesWithAskStatus.Add(privileges[iterator]);
        ///                 break;
        ///         }
        ///     }
        ///     IEnumerable&lt;PermissionRequestResponse&gt; responses = PrivacyPrivilegeManager.RequestPermissions(privilegesWithAskStatus).Result;
        ///     //handle responses
        /// </code>
        /// </example>
        /// <since_tizen> 5 </since_tizen>
        public static Task<RequestMultipleResponseEventArgs> RequestPermissions(IEnumerable<string> privileges)
        {
            string[] privilegesArray = CheckPrivilegesArgument(privileges, "RequestPermissions");

            for (int iterator = 0; iterator < privilegesArray.Length; ++iterator)
            {
                if (!s_PrivilegesInProgress.Add(privilegesArray[iterator]))
                {
                    Log.Error(LogTag, "Request for this privilege: " + privilegesArray[iterator] + " is already in progress.");

                    for (int removeIterator = iterator - 1; removeIterator >= 0; --removeIterator)
                    {
                        s_PrivilegesInProgress.Remove(privilegesArray[removeIterator]);
                    }
                    Log.Error(LogTag, "Request for this privilege: " + privilegesArray[iterator] + " is already in progress.");
                    throw new ArgumentException("Request for this privilege: " + privilegesArray[iterator] + " is already in progress.");
                }
            }

            Log.Info(LogTag, "Sending request for permissions: " + string.Join(" ", privilegesArray));

            TaskCompletionSource<RequestMultipleResponseEventArgs> permissionResponsesTask = new TaskCompletionSource<RequestMultipleResponseEventArgs>();
            int ret = (int)Interop.PrivacyPrivilegeManager.RequestPermissions(privilegesArray, (uint)privilegesArray.Length,
                        (Interop.PrivacyPrivilegeManager.CallCause cause, Interop.PrivacyPrivilegeManager.RequestResult[] results,
                        string[] requestedPrivileges, uint privilegesCount, IntPtr userData) =>
                        {
                            Log.Info(LogTag, "Sending request for permissions: ");
                            RequestMultipleResponseEventArgs requestResponse = new RequestMultipleResponseEventArgs();
                            PermissionRequestResponse[] permissionResponses = new PermissionRequestResponse[privilegesCount];

                            for (int iterator = 0; iterator < privilegesCount; ++iterator)
                            {
                                permissionResponses[iterator] = new PermissionRequestResponse
                                {
                                    Privilege = requestedPrivileges[iterator],
                                    Result = (RequestResult)results[iterator]
                                };
                            }
                            requestResponse.Cause = (CallCause)cause;
                            requestResponse.Responses = permissionResponses;

                            foreach (string privilege in requestedPrivileges)
                            {
                                s_PrivilegesInProgress.Remove(privilege);
                            }
                            permissionResponsesTask.SetResult(requestResponse);
                        }, IntPtr.Zero);

            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to request permissions.");
                foreach (string privilege in privileges)
                {
                    s_PrivilegesInProgress.Remove(privilege);
                }
                throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
            }
            else
            {
                Log.Info(LogTag, "Requesting permissions successfull.");
                return permissionResponsesTask.Task;
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
        /// <since_tizen> 4 </since_tizen>
        public static WeakReference<ResponseContext> GetResponseContext(string privilege)
        {
            if (!(s_responseMap.TryGetValue(privilege, out ResponseContext ctx) && ctx != null))
            {
                ctx = new ResponseContext(privilege);
                s_responseMap[privilege] = ctx;
            }
            return new WeakReference<ResponseContext>(s_responseMap[privilege]);
        }

        /// <summary>
        /// This class manages event handlers of the privilege permission requests.
        /// This class enables having event handlers for an individual privilege.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
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
            /// <since_tizen> 4 </since_tizen>
            public event EventHandler<RequestResponseEventArgs> ResponseFetched
            {
                add
                {
                    _ResponseFetched += value;
                    if (!s_responseMap.ContainsKey(_privilege))
                    {
                        s_responseMap[_privilege] = this;
                    }
                }

                remove
                {
                    _ResponseFetched -= value;
                }
            }

            private event EventHandler<RequestResponseEventArgs> _ResponseFetched;

            internal void FireEvent(CallCause _cause, RequestResult _result)
            {
                _ResponseFetched?.Invoke(null, new RequestResponseEventArgs { cause = _cause, result = _result, privilege = _privilege });
            }

            /// <summary>
            /// ResponseContext class destructor
            /// </summary>
            ~ResponseContext()
            {
                s_responseMap.Remove(_privilege);
            }
        }
    }

    internal static class PrivacyPrivilegeManagerErrorFactory
    {
        static internal Exception GetException(int error)
        {
            Interop.PrivacyPrivilegeManager.ErrorCode errCode = (Interop.PrivacyPrivilegeManager.ErrorCode)error;
            switch (errCode)
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
