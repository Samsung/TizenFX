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
using Tizen.Internals;
using Tizen.Internals.Errors;


namespace Tizen.Applications {
    internal static partial class Interop
    {
        internal static partial class TeamManager
        {
            internal enum TeamAppErrorCode
            {
                None = ErrorCode.None,
                InvalidParameter = ErrorCode.InvalidParameter,
                OutOfMemory = ErrorCode.OutOfMemory,
                InvalidContext = -0x01100000 | 0x01,
                AlreadyExist = ErrorCode.FileExists,
                AlreadyRunning = ErrorCode.AlreadyInProgress,
                NoSuchMember = ErrorCode.NoSuchFile,
                IOError = ErrorCode.IoError,
                NotSupported = ErrorCode.NotSupported,
            }

            [DllImport(Libraries.TeamLib, EntryPoint = "create_wl2_window_by_id")]
            internal static extern IntPtr CreateWl2WindowById(int wl2WinId);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_cache_path")]
            internal static extern TeamAppErrorCode TeamAppGetCachePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_resource_path")]
            internal static extern TeamAppErrorCode TeamAppGetResourcePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_tep_resource_path")]
            internal static extern TeamAppErrorCode TeamAppGetTepResourcePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_shared_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetSharedDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_shared_resource_path")]
            internal static extern TeamAppErrorCode TeamAppGetSharedResourcePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_shared_trusted_path")]
            internal static extern TeamAppErrorCode TeamAppGetSharedTrustedPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_res_control_allowed_path")]
            internal static extern TeamAppErrorCode TeamAppGetResControlAllowedPath(IntPtr memberHandle, string resType, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_res_control_global_path")]
            internal static extern TeamAppErrorCode TeamAppGetResControlGlobalPath(IntPtr memberHandle, string resType, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_common_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetCommonDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_common_cache_path")]
            internal static extern TeamAppErrorCode TeamAppGetCommonCachePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_common_shared_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetCommonSharedDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_common_shared_trusted_path")]
            internal static extern TeamAppErrorCode TeamAppGetCommonSharedTrustedPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_app_id")]
            internal static extern TeamAppErrorCode TeamAppGetAppId(IntPtr memberHandle, out string appId);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_package_id")]
            internal static extern TeamAppErrorCode TeamAppGetPackageId(IntPtr memberHandle, out string packageId);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_instance_id")]
            internal static extern TeamAppErrorCode TeamAppGetInstanceId(IntPtr memberHandle, out string instId);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_app_instance_id")]
            internal static extern TeamAppErrorCode TeamAppGetAppInstanceId(IntPtr memberHandle, out string appInstId);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_name")]
            internal static extern TeamAppErrorCode TeamAppGetName(IntPtr memberHandle, out string name);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_version")]
            internal static extern TeamAppErrorCode TeamAppGetVersion(IntPtr memberHandle, out string version);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_extern_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetExternDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_extern_cache_path")]
            internal static extern TeamAppErrorCode TeamAppGetExternCachePath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "team_app_get_extern_shared_data_path")]
            internal static extern TeamAppErrorCode TeamAppGetExternSharedDataPath(IntPtr memberHandle, out string path);

            [DllImport(Libraries.TeamLib, EntryPoint = "invoke_view_visibility_event")]
            internal static extern void InvokeViewVisibilityEvent(int viewId, bool visible);

            [DllImport(Libraries.TeamLib, EntryPoint = "create_view_by_view_id")]
            internal static extern IntPtr CreateViewByViewId(int viewId);

            [DllImport(Libraries.TeamLib, EntryPoint = "destroy_view_by_view_id")]
            internal static extern void DestroyViewByViewId(int viewId);

        }
    }
}