// Copyright 2016 by Samsung Electronics, Inc.,
//
// This software is the confidential and proprietary information
// of Samsung Electronics, Inc. ("Confidential Information"). You
// shall not disclose such Confidential Information and shall use
// it only in accordance with the terms of the license agreement
// you entered into with Samsung.

using System;
using System.Runtime.InteropServices;

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

        internal enum AppContextEvent
        {
            Launched = 0,
            Terminated = 1
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AppManagerAppContextEventCallback(IntPtr handle, AppContextEvent state, IntPtr userData);
        //void(* app_manager_app_context_event_cb)(app_context_h app_context, app_context_event_e event, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AppManagerAppInfoCallback(IntPtr handle, IntPtr userData);
        //bool(* app_manager_app_info_cb )(app_info_h app_info, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AppManagerAppContextCallback(IntPtr handle, IntPtr userData);
        //bool(* app_manager_app_context_cb)(app_context_h app_context, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AppInfoFilterCallback(IntPtr handle, IntPtr userData);
        //bool(* app_info_filter_cb )(app_info_h app_info, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool AppInfoMetadataCallback(string key, string value, IntPtr userData);
        //bool(* app_info_metadata_cb )(const char *metadata_key, const char *metadata_value, void *user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_set_app_context_event_cb")]
        internal static extern ErrorCode AppManagerSetAppContextEvent(AppManagerAppContextEventCallback callback, IntPtr userData);
        //int app_manager_set_app_context_event_cb( app_manager_app_context_event_cb callback, void * user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_unset_app_context_event_cb")]
        internal static extern void AppManagerUnSetAppContextEvent();
        //void app_manager_unset_app_context_event_cb (void);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_foreach_app_context")]
        internal static extern ErrorCode AppManagerForeachAppContext(AppManagerAppContextCallback callback, IntPtr userData);
        //int app_manager_foreach_app_context(app_manager_app_context_cb callback, void *user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_context")]
        internal static extern ErrorCode AppManagerGetAppContext(string applicationId, out IntPtr handle);
        //int app_manager_get_app_context(const char* app_id, app_context_h *app_context);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_id")]
        internal static extern ErrorCode AppManagerGetAppId(int processId, out string applicationId);
        //int app_manager_get_app_id (pid_t pid, char **appid);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_is_running")]
        internal static extern ErrorCode AppManagerIsRunning(string applicationId, out bool running);
        //int app_manager_is_running (const char *appid, bool *running);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_resume_app")]
        internal static extern ErrorCode AppManagerResumeApp(IntPtr handle);
        //int app_manager_resume_app (app_context_h handle);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_request_terminate_bg_app")]
        internal static extern ErrorCode AppManagerRequestTerminateBgApp(IntPtr handle);
        //int app_manager_request_terminate_bg_app (app_context_h handle);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_foreach_app_info")]
        internal static extern ErrorCode AppManagerForeachAppInfo(AppManagerAppInfoCallback callback, IntPtr userData);
        //int app_manager_foreach_app_info(app_manager_app_info_cb callback, void *user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_info")]
        internal static extern ErrorCode AppManagerGetAppInfo(string applicationId, out IntPtr handle);
        //int app_manager_get_app_info(const char * app_id, app_info_h * app_info)

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_data_path")]
        internal static extern ErrorCode AppManagerGetSharedDataPath(string applicationId, out string path);
        //int app_manager_get_shared_data_path (const char *appid, char **path);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_resource_path")]
        internal static extern ErrorCode AppManagerGetSharedResourcePath(string applicationId, out string path);
        //int app_manager_get_shared_resource_path (const char *appid, char **path);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_trusted_path")]
        internal static extern ErrorCode AppManagerGetSharedTrustedPath(string applicationId, out string path);
        //int app_manager_get_shared_trusted_path (const char *appid, char **path);

        [DllImport(Libraries.AppManager, EntryPoint = "app_manager_get_external_shared_data_path")]
        internal static extern ErrorCode AppManagerGetExternalSharedDataPath(string applicationId, out string path);
        //int app_manager_get_external_shared_data_path (const char *appid, char **path);

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_destroy")]
        internal static extern ErrorCode AppContextDestroy(IntPtr handle);
        //int app_context_destroy(app_context_h app_context)

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_get_package")]
        internal static extern ErrorCode AppContextGetPackage(IntPtr handle, out IntPtr package);
        //int app_context_get_package (app_context_h app_context, char **package);

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_get_app_id")]
        internal static extern ErrorCode AppContextGetAppId(IntPtr handle, out string applicationId);
        //int app_context_get_app_id(app_context_h app_context, char **app_id)

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_get_pid")]
        internal static extern ErrorCode AppContextGetPid(IntPtr handle, out int processId);
        //int app_context_get_pid (app_context_h app_context, pid_t *pid)

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_is_terminated")]
        internal static extern ErrorCode AppContextIsTerminated(IntPtr handle, out bool terminated);
        //int app_context_is_terminated (app_context_h app_context, bool *terminated);

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_is_equal")]
        internal static extern ErrorCode AppContextIsEqual(IntPtr first, IntPtr second, out bool equal);
        //int app_context_is_equal (app_context_h lhs, app_context_h rhs, bool *equal);

        [DllImport(Libraries.AppManager, EntryPoint = "app_context_clone")]
        internal static extern ErrorCode AppContextClone(out IntPtr destination, IntPtr source);
        //int app_context_clone (app_context_h *clone, app_context_h app_context);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_create")]
        internal static extern ErrorCode AppInfoCreate(string applicationId, out IntPtr handle);
        //int app_info_create (const char *app_id, app_info_h *app_info);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_destroy")]
        internal static extern ErrorCode AppInfoDestroy(IntPtr handle);
        //int app_info_destroy (app_info_h app_info);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_app_id")]
        internal static extern ErrorCode AppInfoGetAppId(IntPtr handle, out IntPtr applicationId);
        //int app_info_get_app_id (app_info_h app_info, char **app_id);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_exec")]
        internal static extern ErrorCode AppInfoGetExec(IntPtr handle, out IntPtr exec);
        //int app_info_get_exec (app_info_h app_info, char **exec);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_label")]
        internal static extern ErrorCode AppInfoGetLabel(IntPtr handle, out IntPtr label);
        //int app_info_get_label (app_info_h app_info, char **label);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_localed_label")]
        internal static extern ErrorCode AppInfoGetLocaledLabel(string applicationId, string locale, out IntPtr label);
        //int app_info_get_localed_label (const char *app_id, const char *locale, char **label);

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_icon")]
        internal static extern ErrorCode AppInfoGetIcon(IntPtr handle, out IntPtr path);
        //int app_info_get_icon (app_info_h app_info, char **path)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_package")]
        internal static extern ErrorCode AppInfoGetPackage(IntPtr handle, out IntPtr package);
        //int app_info_get_package (app_info_h app_info, char **package)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_get_type")]
        internal static extern ErrorCode AppInfoGetType(IntPtr handle, out IntPtr type);
        //int app_info_get_type (app_info_h app_info, char **type)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_foreach_metadata")]
        internal static extern ErrorCode AppInfoForeachMetadata(IntPtr handle, AppInfoMetadataCallback callback, IntPtr userData);
        //int app_info_foreach_metadata(app_info_h app_info, app_info_metadata_cb callback, void *user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_nodisplay")]
        internal static extern ErrorCode AppInfoIsNodisplay(IntPtr handle, out bool noDisplay);
        //int app_info_is_nodisplay (app_info_h app_info, bool *nodisplay)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_equal")]
        internal static extern ErrorCode AppInfoIsEqual(IntPtr first, IntPtr second, out bool equal);
        //int app_info_is_equal (app_info_h lhs, app_info_h rhs, bool *equal)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_enabled")]
        internal static extern ErrorCode AppInfoIsEnabled(IntPtr handle, out bool enabled);
        //int app_info_is_enabled (app_info_h app_info, bool *enabled)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_onboot")]
        internal static extern ErrorCode AppInfoIsOnBoot(IntPtr handle, out bool onBoot);
        //int app_info_is_onboot (app_info_h app_info, bool *onboot)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_is_preload")]
        internal static extern ErrorCode AppInfoIsPreLoad(IntPtr handle, out bool preLoaded);
        //int app_info_is_preload (app_info_h app_info, bool *preload)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_clone")]
        internal static extern ErrorCode AppInfoClone(out IntPtr destination, IntPtr source);
        //int app_info_clone(app_info_h * clone, app_info_h app_info)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_create")]
        internal static extern ErrorCode AppInfoFilterCreate(out IntPtr handle);
        //int app_info_filter_create(app_info_filter_h * handle)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_destroy")]
        internal static extern ErrorCode AppInfoFilterDestroy(IntPtr handle);
        //int app_info_filter_destroy(app_info_filter_h handle)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_add_bool")]
        internal static extern ErrorCode AppInfoFilterAddBool(IntPtr handle, string property, bool value);
        //int app_info_filter_add_bool(app_info_filter_h handle, const char *property, const bool value)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_add_string")]
        internal static extern ErrorCode AppInfoFilterAddString(IntPtr handle, string property, string value);
        //int app_info_filter_add_string(app_info_filter_h handle, const char *property, const char *value)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_count_appinfo")]
        internal static extern ErrorCode AppInfoFilterCountAppinfo(IntPtr handle, out int count);
        //int app_info_filter_count_appinfo(app_info_filter_h handle, int *count)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_filter_foreach_appinfo")]
        internal static extern ErrorCode AppInfoFilterForeachAppinfo(IntPtr handle, AppInfoFilterCallback callback, IntPtr userData);
        //int app_info_filter_foreach_appinfo(app_info_filter_h handle, app_info_filter_cb callback, void * user_data)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_create")]
        internal static extern ErrorCode AppInfoMetadataFilterCreate(out IntPtr handle);
        //int app_info_metadata_filter_create (app_info_metadata_filter_h *handle)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_destroy")]
        internal static extern ErrorCode AppInfoMetadataFilterDestroy(IntPtr handle);
        //int app_info_metadata_filter_destroy (app_info_metadata_filter_h handle)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_add")]
        internal static extern ErrorCode AppInfoMetadataFilterAdd(IntPtr handle, string key, string value);
        //int app_info_metadata_filter_add (app_info_metadata_filter_h handle, const char *key, const char *value)

        [DllImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_foreach")]
        internal static extern ErrorCode AppInfoMetadataFilterForeach(IntPtr handle, AppInfoFilterCallback callback, IntPtr userData);
        //int app_info_metadata_filter_foreach (app_info_metadata_filter_h handle, app_info_filter_cb callback, void *user_data)
    }
}
