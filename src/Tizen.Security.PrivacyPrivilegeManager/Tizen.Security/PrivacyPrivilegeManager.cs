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

#pragma warning disable 618

namespace Tizen.Security
{
    /// <summary>
    /// The PrivacyPrivilegeManager provides the properties or methods to check and request a permission for privacy privilege.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public static class PrivacyPrivilegeManager
    {
        private const string LogTag = "Tizen.Privilege";
        private static Dictionary<int, TaskCompletionSource<RequestMultipleResponseEventArgs>> s_multipleRequestMap = new Dictionary<int, TaskCompletionSource<RequestMultipleResponseEventArgs>>();
        private static int s_requestId = 0;
        private static IDictionary<string, WeakReference<ResponseContext>> s_responseWeakMap = new Dictionary<string, WeakReference<ResponseContext>>();
        private static Interop.PrivacyPrivilegeManager.RequestResponseCallback s_requestResponseCb =
                       (Interop.PrivacyPrivilegeManager.CallCause cause, Interop.PrivacyPrivilegeManager.RequestResult result,
                           string privilege, IntPtr userData) =>
                        {
                            try
                            {
                                if (s_responseWeakMap.TryGetValue(privilege, out WeakReference<ResponseContext> weakRef))
                                {
                                    if (weakRef.TryGetTarget(out ResponseContext context))
                                    {
                                        context.FireEvent((CallCause)cause, (RequestResult)result);
                                    }
                                    else
                                    {
                                        s_responseWeakMap.Remove(privilege);
                                        Log.Error(LogTag, "No response context for: " + privilege);
                                    }
                                }
                                else
                                {
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
        private static Interop.PrivacyPrivilegeManager.RequestMultipleResponseCallback s_multipleCallback = MultipleRequestHandler;

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
        [Obsolete("Deprecated in API11, will be removed in API13. Use CheckPermissionsAsync() instead.")]
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
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API11, will be removed in API13. Use CheckPermissionsAsync() instead.")]
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
        [Obsolete("Deprecated in API11, will be removed in API13. Use RequestPermissionsAsync() instead.")]
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
        /// <since_tizen> 6 </since_tizen>
        [Obsolete("Deprecated in API11, will be removed in API13. Use RequestPermissionsAsync() instead.")]
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

            int requestId = 0;
            lock (s_multipleRequestMap)
            {
                requestId = s_requestId++;
            }
            TaskCompletionSource<RequestMultipleResponseEventArgs> permissionResponsesTask = new TaskCompletionSource<RequestMultipleResponseEventArgs>();
            s_multipleRequestMap[requestId] = permissionResponsesTask;
            int ret = (int)Interop.PrivacyPrivilegeManager.RequestPermissions(privilegesArray, (uint)privilegesArray.Length, s_multipleCallback, (IntPtr)requestId);

            if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
            {
                Log.Error(LogTag, "Failed to request permissions.");
                foreach (string privilege in privileges)
                {
                    s_PrivilegesInProgress.Remove(privilege);
                }
                s_multipleRequestMap.Remove(requestId);
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
        [Obsolete("Deprecated in API11, will be removed in API13. Use RequestPermissionsAsync() which handles context internally.")]
        public static WeakReference<ResponseContext> GetResponseContext(string privilege)
        {
            if (!(s_responseWeakMap.TryGetValue(privilege, out WeakReference<ResponseContext> weakRef) && weakRef.TryGetTarget(out ResponseContext context)))
            {
                context = new ResponseContext(privilege);
                s_responseWeakMap[privilege] = new WeakReference<ResponseContext>(context);
            }
            return s_responseWeakMap[privilege];
        }

        private static void MultipleRequestHandler(Interop.PrivacyPrivilegeManager.CallCause cause, Interop.PrivacyPrivilegeManager.RequestResult[] results,
            string[] requestedPrivileges, uint privilegesCount, IntPtr userData)
        {
            int requestId = (int)userData;
            if (!s_multipleRequestMap.ContainsKey(requestId))
            {
                return;
            }

            var tcs = s_multipleRequestMap[requestId];
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
            tcs.SetResult(requestResponse);
            s_multipleRequestMap.Remove(requestId);
        }

        /// <summary>
        /// Gets the status of privacy privileges permission asynchronously.
        /// </summary>
        /// <param name="privileges">The privacy privileges to be checked.</param>
        /// <returns>A task that returns a permission status of the requested privileges.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// string[] privileges = new [] {"http://tizen.org/privilege/account.read",
        ///                               "http://tizen.org/privilege/alarm"};
        /// PermissionResult results = await PrivacyPrivilegeManager.CheckPermissionsAsync(privileges);
        /// foreach (var (privilege, status) in results)
        /// {
        ///     var name = Tizen.Security.Privilege.GetDisplayName("", privilege);
        ///     Console.WriteLine($"Privilege: {name}, Status: {status}");
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// <example>
        /// Check if all privileges from manifest are granted.
        /// <code>
        /// <![CDATA[
        /// List<string> manifestPrivileges = await PrivacyPrivilegeManager.LoadPrivilegesFromManifestAsync();
        /// PermissionResult states = await PrivacyPrivilegeManager.CheckPermissionsAsync(manifestPrivileges);
        /// bool allGranted = states.AllGranted();
        /// if (allGranted)
        /// {
        ///     Console.WriteLine("All permissions are granted.");
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// <since_tizen> 14 </since_tizen>
        public static async Task<PermissionResult> CheckPermissionsAsync(IEnumerable<string> privileges)
        {
            string[] privilegesArray = CheckPrivilegesArgument(privileges, "CheckPermissionsAsync");

            return await Task.Run(() =>
            {
                Interop.PrivacyPrivilegeManager.CheckResult[] results = new Interop.PrivacyPrivilegeManager.CheckResult[privilegesArray.Length];
                int ret = (int)Interop.PrivacyPrivilegeManager.CheckPermissions(privilegesArray, (uint)privilegesArray.Length, results);
                if (ret != (int)Interop.PrivacyPrivilegeManager.ErrorCode.None)
                {
                    Log.Error(LogTag, "Failed to check permissions " + string.Join(", ", privileges));
                    throw PrivacyPrivilegeManagerErrorFactory.GetException(ret);
                }

                var permissionStates = new PermissionResult();
                for (int iterator = 0; iterator < results.Length; ++iterator)
                {
                    permissionStates[privilegesArray[iterator]] = results[iterator].ToPermissionStatus();
                }
                return permissionStates;
            });
        }

        /// <summary>
        /// Triggers the permissions request for a user asynchronously.
        /// </summary>
        /// <param name="required">The required privacy privileges to be requested.</param>
        /// <param name="optional">The optional, non-critical privacy privileges to be requested.
        /// Privileges listed in both required and optional are treated as optional.</param>
        /// <returns>A task that returns a permission status of the requested privileges.</returns>
        /// <exception cref="ArgumentException">Thrown when an invalid parameter is passed.</exception>
        /// <exception cref="PermissionDeniedException">Thrown when one or more required permissions are denied.</exception>
        /// <exception cref="OutOfMemoryException">Thrown when a memory error occurred.</exception>
        /// <exception cref="System.IO.IOException">Thrown when the method failed due to an internal I/O error.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// try
        /// {
        ///     var results = await PrivacyPrivilegeManager.RequestPermissionsAsync(
        ///         required: await PrivacyPrivilegeManager.LoadPrivilegesFromManifestAsync(),
        ///         optional: new[] { "http://tizen.org/privilege/alarm" });
        ///     foreach (var (privilege, state) in results)
        ///     {
        ///         Console.WriteLine($"Privilege: {privilege}, State: {state}");
        ///     }
        ///     // required privileges have been granted, application can continue
        ///     if (!results.IsGranted("http://tizen.org/privilege/alarm")) {
        ///         HideAlarmRelatedUI();
        ///     }
        /// }
        /// catch (PermissionDeniedException ex)
        /// {
        ///     foreach (var privilege in ex.DeniedPrivileges)
        ///     {
        ///         var name = Tizen.Security.Privilege.GetDisplayName("", privilege);
        ///         Console.WriteLine($"{name} has been denied");
        ///     }
        ///     // application can not run, present a user option to re-request permissions
        /// }
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// <since_tizen> 14 </since_tizen>
        public static async Task<PermissionResult> RequestPermissionsAsync(IEnumerable<string> required = null, IEnumerable<string> optional = null)
        {
            // Build the set of privileges to request
            // Privileges in both required and optional are treated as optional
            var optionalSet = optional != null ? new HashSet<string>(optional) : new HashSet<string>();
            var requiredList = required != null ? new List<string>(required) : new List<string>();

            // Remove from required any privileges that are also in optional (they become optional)
            var actualRequired = requiredList.Where(p => !optionalSet.Contains(p)).ToList();

            // Combine all privileges to request (required + optional)
            var allPrivileges = actualRequired.Concat(optionalSet).ToList();

            var states = new PermissionResult();
            if (!allPrivileges.Any())
            {
                return states;
            }

            var result = await RequestPermissions(allPrivileges);

            // Build dictionary of results
            foreach (var response in result.Responses)
            {
                states[response.Privilege] = response.Result.ToPermissionStatus();
            }

            // Check if any required permissions were denied
            var deniedMap = actualRequired
                .Where(p => states.ContainsKey(p) && !states[p].IsGranted())
                .ToDictionary(p => p, p => states[p]);

            if (deniedMap.Any())
            {
                throw new PermissionDeniedException(deniedMap);
            }

            return states;
        }

        /// <summary>
        /// Loads privileges from the application manifest file (tizen-manifest.xml) asynchronously.
        /// </summary>
        /// <returns>A task that returns a list of privilege strings declared in the manifest.</returns>
        /// <exception cref="System.IO.FileNotFoundException">Thrown when the manifest file is not found.</exception>
        /// <exception cref="System.Xml.XmlException">Thrown when the manifest file contains invalid XML.</exception>
        /// <example>
        /// <code>
        /// <![CDATA[
        /// List<string> privileges = await PrivacyPrivilegeManager.LoadPrivilegesFromManifestAsync();
        /// foreach (var privilege in privileges)
        /// {
        ///     Console.WriteLine($"Privilege: {privilege}");
        /// }
        /// ]]>
        /// </code>
        /// </example>
        /// <since_tizen> 14 </since_tizen>
        public static async Task<IEnumerable<string>> LoadPrivilegesFromManifestAsync()
        {
            return await Task.Run(() =>
            {
                var manifestPath = System.IO.Path.GetDirectoryName(
                    System.IO.Path.GetDirectoryName(
                        Tizen.Applications.Application.Current.ApplicationInfo.ExecutablePath)
                    ) + "/tizen-manifest.xml";
                if (!System.IO.File.Exists(manifestPath))
                {
                    Log.Error(LogTag, "Manifest file not found: " + manifestPath);
                    throw new System.IO.FileNotFoundException("Manifest file not found: " + manifestPath);
                }

                var privileges = new List<string>();
                var doc = System.Xml.Linq.XDocument.Load(manifestPath);
                var ns = doc.Root?.Name.Namespace ?? System.Xml.Linq.XNamespace.None;

                var privilegesElement = doc.Root?.Element(ns + "privileges");
                if (privilegesElement != null)
                {
                    foreach (var privilegeElement in privilegesElement.Elements(ns + "privilege"))
                    {
                        if (!string.IsNullOrEmpty(privilegeElement.Value))
                        {
                            privileges.Add(privilegeElement.Value.Trim());
                        }
                    }
                }

                return privileges;
            });
        }

        /// <summary>
        /// This class manages event handlers of the privilege permission requests.
        /// This class enables having event handlers for an individual privilege.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        [Obsolete("Deprecated in API11, will be removed in API13. Use RequestPermissionsAsync() which handles context internally.")]
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
            [Obsolete("Deprecated in API11, will be removed in API13. Use RequestPermissionsAsync() which handles context internally.")]
            public event EventHandler<RequestResponseEventArgs> ResponseFetched
            {
                add
                {
                    if (_ResponseFetched == null)
                    {
                        if (!s_responseMap.ContainsKey(_privilege))
                        {
                            s_responseMap[_privilege] = this;
                        }
                    }
                    _ResponseFetched += value;
                }

                remove
                {
                    _ResponseFetched -= value;
                    if (_ResponseFetched == null)
                    {
                        if (s_responseMap.ContainsKey(_privilege))
                        {
                            s_responseMap.Remove(_privilege);
                        }
                    }
                }
            }

            private event EventHandler<RequestResponseEventArgs> _ResponseFetched;

            internal void FireEvent(CallCause _cause, RequestResult _result)
            {
                _ResponseFetched?.Invoke(this, new RequestResponseEventArgs { cause = _cause, result = _result, privilege = _privilege });
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
