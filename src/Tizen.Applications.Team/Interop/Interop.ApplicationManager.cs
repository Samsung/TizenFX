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

namespace Tizen.Applications {
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

            internal enum AppInfoAppComponentType
            {
                UiApp = 0,
                ServiceApp = 1,
                WidgetApp = 2,
                WatchApp = 3
            }

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool AppInfoMetadataCallback(string key, string value, IntPtr userData);
            //bool(* app_info_metadata_cb )(const char *metadata_key, const char *metadata_value, void *user_data)

            [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
            internal delegate bool AppInfoCategoryCallback(string category, IntPtr userData);
            //bool (*app_info_category_cb) (const char *category, void *user_data)

            internal delegate bool AppInfoResControlCallback(string resType, string minResVersion, string maxResVersion, string autoClose, IntPtr userUdata);
            //bool (*app_info_res_control_cb) (const char *res_type, const char *min_res_version, const char *max_res_version, const char *auto_close, void *user_data);

            [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_info")]
            internal static extern ErrorCode AppManagerGetAppInfo(string applicationId, out IntPtr handle);
            //int app_manager_get_app_info(const char * app_id, app_info_h * app_info)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_destroy")]
            internal static extern ErrorCode AppInfoDestroy(IntPtr handle);
            //int app_info_destroy (app_info_h app_info);

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_package")]
            internal static extern ErrorCode AppInfoGetPackage(IntPtr handle, out string package);
            //int app_info_get_package (app_info_h app_info, char **package)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_label")]
            internal static extern ErrorCode AppInfoGetLabel(IntPtr handle, out string label);
            //int app_info_get_label (app_info_h app_info, char **label);

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_exec")]
            internal static extern ErrorCode AppInfoGetExec(IntPtr handle, out string exec);
            //int app_info_get_exec (app_info_h app_info, char **exec);

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_icon")]
            internal static extern ErrorCode AppInfoGetIcon(IntPtr handle, out string path);
            //int app_info_get_icon (app_info_h app_info, char **path)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_type")]
            internal static extern ErrorCode AppInfoGetType(IntPtr handle, out string type);
            //int app_info_get_type (app_info_h app_info, char **type)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_app_component_type")]
            internal static extern ErrorCode AppInfoGetAppComponentType(IntPtr handle, out AppInfoAppComponentType type);
            //int app_info_get_app_component_type(app_info_h app_info, app_info_app_component_type_e *type)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_foreach_metadata")]
            internal static extern ErrorCode AppInfoForeachMetadata(IntPtr handle, AppInfoMetadataCallback callback, IntPtr userData);
            //int app_info_foreach_metadata(app_info_h app_info, app_info_metadata_cb callback, void *user_data)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_nodisplay")]
            internal static extern ErrorCode AppInfoIsNodisplay(IntPtr handle, out bool noDisplay);
            //int app_info_is_nodisplay (app_info_h app_info, bool *nodisplay)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_onboot")]
            internal static extern ErrorCode AppInfoIsOnBoot(IntPtr handle, out bool onBoot);
            //int app_info_is_onboot (app_info_h app_info, bool *onboot)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_preload")]
            internal static extern ErrorCode AppInfoIsPreLoad(IntPtr handle, out bool preLoaded);
            //int app_info_is_preload (app_info_h app_info, bool *preload)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_foreach_category")]
            internal static extern ErrorCode AppInfoForeachCategory(IntPtr handle, AppInfoCategoryCallback callback, IntPtr userData);
            //int app_info_foreach_category(app_info_h app_info, app_info_category_cb callback, void *user_data)

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_localed_label")]
            internal static extern ErrorCode AppInfoGetLocaledLabel(string applicationId, string locale, out string label);
            //int app_info_get_localed_label (const char *app_id, const char *locale, char **label);

            [DllImport(Libraries.AppManager, EntryPoint = "app_info_foreach_res_control")]
            internal static extern ErrorCode AppInfoForeachResControl(IntPtr handle, AppInfoResControlCallback callback, IntPtr userData);
        }
    }

}