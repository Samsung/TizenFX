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
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class PrivacyPrivilegeManager
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            Unknown = Tizen.Internals.Errors.ErrorCode.Unknown
        }

        internal enum CallCause
        {
            Answer = 0,
            Error = 1,
        }

        internal enum CheckResult
        {
            Allow = 0,
            Deny = 1,
            Ask = 2,
        }

        internal enum RequestResult
        {
            AllowForever = 0,
            DenyForever = 1,
            DenyOnce = 2,
        }

        //[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void RequestResponseCallback(CallCause cause, RequestResult result, string privilege, IntPtr userData);

        //[UnmanagedFunctionPointerAttribute(CallingConvention.Cdecl)]
        internal delegate void RequestMultipleResponseCallback(CallCause cause,
                                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] RequestResult[] results,
                                                               [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 3)] string[] privileges,
                                                               uint privilegesCount, IntPtr userData);

        [DllImport(Libraries.PrivacyPrivilegeManager, EntryPoint = "ppm_check_permission")]
        internal static extern ErrorCode CheckPermission(string privilege, out CheckResult result);

        [DllImport(Libraries.PrivacyPrivilegeManager, EntryPoint = "ppm_check_permissions")]
        internal static extern ErrorCode CheckPermissions([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)]string[] privileges,
                                                          uint privilegesCount,
                                                          [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] CheckResult[] results);


        [DllImport(Libraries.PrivacyPrivilegeManager, EntryPoint = "ppm_request_permission")]
        internal static extern ErrorCode RequestPermission(string privilege, RequestResponseCallback callback, IntPtr userData);

        [DllImport(Libraries.PrivacyPrivilegeManager, EntryPoint = "ppm_request_permissions")]
        internal static extern ErrorCode RequestPermissions([MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 1)] string[] privileges,
                                                            uint privilegesCount, RequestMultipleResponseCallback callback, IntPtr userData);

    }
}
