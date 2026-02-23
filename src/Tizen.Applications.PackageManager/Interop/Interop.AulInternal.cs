/*
 * Copyright (c) 2026 Samsung Electronics Co., Ltd All Rights Reserved
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
    internal static partial class AulInternal
    {
        internal enum AulErrorCode
        {
            /// <summary>
            /// General success
            /// </summary>
            Ok = 0,
            /// <summary>
            /// General error
            /// </summary>
            Error = -1,
            /// <summary>
            /// AUL handler NOT initialized
            /// </summary>
            ENoInit = -2,
            /// <summary>
            /// Communication Error
            /// </summary>
            EComm = -3,
            /// <summary>
            /// Invalid argument
            /// </summary>
            EInval = -4,
            /// <summary>
            /// Operation canceled
            /// </summary>
            ECanceled = -5,
            /// <summary>
            /// Timeout
            /// </summary>
            ETimeout = -6,
            /// <summary>
            /// Launch by himself
            /// </summary>
            Local = -7,
            /// <summary>
            /// Illegal Access
            /// </summary>
            EIllAcc = -8,
            /// <summary>
            /// Application terminating
            /// </summary>
            ETerminating = -9,
            /// <summary>
            /// No launchpad
            /// </summary>
            ENoLaunchpad = -10,
            /// <summary>
            /// App hidden for guest mode
            /// </summary>
            EHiddenForGuest = -11,
            /// <summary>
            /// Failed to find app ID or pkg ID
            /// </summary>
            ENoApp = -13,
            /// <summary>
            /// App disable for mode
            /// </summary>
            ERejected = -14,
            /// <summary>
            /// App directory entry error
            /// </summary>
            ENoEnt = -15,
            /// <summary>
            /// Out of memory
            /// </summary>
            ENoMem = -16
        }

        [DllImport(Libraries.Aul, EntryPoint = "aul_package_get_install_status")]
        internal static extern AulErrorCode AulPackageGetInstallStatus(string pkgid, out int status);
    }
}
