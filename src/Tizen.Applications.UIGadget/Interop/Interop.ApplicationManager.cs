/*
 * Copyright (c) 2025 Samsung Electronics Co., Ltd All Rights Reserved
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

using Tizen.Internals.Errors;
using Tizen.Applications;

internal static partial class Interop
{
    internal static partial class ApplicationManager
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            NoSuchApp = -0x01110000 | 0x01,
            DbFailed = -0x01110000 | 0x03,
            InvalidPackage = -0x01110000 | 0x04,
            AppNoRunning = -0x01110000 | 0x05,
            RequestFailed = -0x01110000 | 0x06,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
        }

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_request_remount_gadget_path")]
        internal static extern ErrorCode AppRemountGadgetPath(out string pkgList);
    }
}
