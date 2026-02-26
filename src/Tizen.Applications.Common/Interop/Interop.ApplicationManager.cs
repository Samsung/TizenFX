/*
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
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;

using Tizen.Internals;

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

        internal enum AppManagerEventStatusType
        {
            All = 0x00,
            Enable = 0x01,
            Disable = 0x02
        }

        internal enum AppManagerEventType
        {
            Enable = 0,
            Disable = 1
        }

        internal enum AppManagerEventState
        {
            Started = 0,
            Completed = 1,
            Failed = 2
        }

        internal enum AppInfoAppComponentType
        {
            UiApp = 0,
            ServiceApp = 1,
            WidgetApp = 2,
            WatchApp = 3
        }

        internal enum AppLifecycleState
        {
            Initialized = 0,
            Created = 1,
            Resumed = 2,
            Paused = 3,
            Destroyed = 4
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AppManagerLifecycleStateChangedCallback(string appId, int pid, AppLifecycleState state, [MarshalAs(UnmanagedType.U1)] bool hasFocus, IntPtr userData);
        //void (*app_manager_lifecycle_state_changed_cb)(const char *app_id, pid_t pid, app_manager_lifecycle_state_e state, [MarshalAs(UnmanagedType.U1)] bool has_focus, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AppManagerEventCallback(string appType, string appId, AppManagerEventType eventType, AppManagerEventState eventState, IntPtr eventHandle, IntPtr userData);
        //void(* app_manager_event_cb)(const char *type, const char *app_id, app_manager_event_type_e event_type, app_manager_event_state_e event_state, app_manager_event_h handle, void *user_data)


        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void AppManagerAppContextEventCallback(IntPtr handle, AppContextEvent state, IntPtr userData);
        //void(* app_manager_app_context_event_cb)(app_context_h app_context, app_context_event_e event, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppManagerAppInfoCallback(IntPtr handle, IntPtr userData);
        //bool(* app_manager_app_info_cb )(app_info_h app_info, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppManagerAppContextCallback(IntPtr handle, IntPtr userData);
        //bool(* app_manager_app_context_cb)(app_context_h app_context, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppInfoFilterCallback(IntPtr handle, IntPtr userData);
        //bool(* app_info_filter_cb )(app_info_h app_info, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppInfoMetadataCallback(string key, string value, IntPtr userData);
        //bool(* app_info_metadata_cb )(const char *metadata_key, const char *metadata_value, void *user_data)

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppInfoCategoryCallback(string category, IntPtr userData);
        //bool (*app_info_category_cb) (const char *category, void *user_data)

        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool AppInfoResControlCallback(string resType, string minResVersion, string maxResVersion, string autoClose, IntPtr userUdata);
        //bool (*app_info_res_control_cb) (const char *res_type, const char *min_res_version, const char *max_res_version, const char *auto_close, void *user_data);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_set_app_context_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerSetAppContextEvent(AppManagerAppContextEventCallback callback, IntPtr userData);
        //int app_manager_set_app_context_event_cb( app_manager_app_context_event_cb callback, void * user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_unset_app_context_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void AppManagerUnSetAppContextEvent();
        //void app_manager_unset_app_context_event_cb (void);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_set_lifecycle_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerSetLifecycleStateChangedCb(AppManagerLifecycleStateChangedCallback callback, IntPtr userData);
        //int app_manager_set_lifecycle_state_changed_cb(app_manager_lifecycle_state_changed_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_unset_lifecycle_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial void AppManagerUnsetLifecycleStateChangedCb();
        //void app_manager_unset_lifecycle_state_changed_cb(void)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_add_lifecycle_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerAddLifecycleStateChangedCb(
            AppManagerLifecycleStateChangedCallback callback, IntPtr userData, out IntPtr handle);
        // int app_manager_add_lifecycle_state_changed_cb(app_manager_lifecycle_state_changed_cb callback,
        // void *user_data, app_manager_lifecycle_noti_h *handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_remove_lifecycle_state_changed_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerRemoveLifecycleStateChangedCb(IntPtr handle);
        // int app_manager_remove_lifecycle_state_changed_cb(app_manager_lifecycle_noti_h handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_foreach_running_app_context", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerForeachRunningAppContext(AppManagerAppContextCallback callback, IntPtr userData);
        //int app_manager_foreach_running_app_context(app_manager_app_context_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_foreach_app_context", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerForeachAppContext(AppManagerAppContextCallback callback, IntPtr userData);
        //int app_manager_foreach_app_context(app_manager_app_context_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_context", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetAppContext(string applicationId, out IntPtr handle);
        //int app_manager_get_app_context(const char* app_id, app_context_h *app_context);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetAppId(int processId, out string applicationId);
        //int app_manager_get_app_id (pid_t pid, char **appid);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_is_running", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerIsRunning(string applicationId, [MarshalAs(UnmanagedType.U1)] out bool running);
        //int app_manager_is_running (const char *appid, [MarshalAs(UnmanagedType.U1)] bool *running);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_resume_app", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerResumeApp(IntPtr handle);
        //int app_manager_resume_app (app_context_h handle);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_request_terminate_bg_app", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerRequestTerminateBgApp(IntPtr handle);
        //int app_manager_request_terminate_bg_app (app_context_h handle);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_foreach_app_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerForeachAppInfo(AppManagerAppInfoCallback callback, IntPtr userData);
        //int app_manager_foreach_app_info(app_manager_app_info_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetAppInfo(string applicationId, out IntPtr handle);
        //int app_manager_get_app_info(const char * app_id, app_info_h * app_info)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetSharedDataPath(string applicationId, out string path);
        //int app_manager_get_shared_data_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_resource_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetSharedResourcePath(string applicationId, out string path);
        //int app_manager_get_shared_resource_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_shared_trusted_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetSharedTrustedPath(string applicationId, out string path);
        //int app_manager_get_shared_trusted_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_common_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetCommonSharedDataPath(string applicationId, out string path);
        //int app_manager_get_common_shared_data_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_common_shared_trusted_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetCommonSharedTrustedPath(string applicationId, out string path);
        //int app_manager_get_common_shared_trusted_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_external_shared_data_path", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetExternalSharedDataPath(string applicationId, out string path);
        //int app_manager_get_external_shared_data_path (const char *appid, char **path);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_event_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerEventCreate(out IntPtr handle);
        //int app_manager_event_create (app_manager_event_h *handle);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_event_set_status", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerEventSetStatus(IntPtr handle, AppManagerEventStatusType statusType);
        //int app_manager_event_set_status (app_manager_event_h handle, int status_type);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_set_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerSetEventCallback(IntPtr handle, AppManagerEventCallback callback, IntPtr userData);
        //int app_manager_set_event_cb (app_manager_event_h handle, app_manager_event_cb callback, void *user_data);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_unset_event_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerUnSetEventCallback(IntPtr handle);
        //int app_manager_unset_event_cb (app_manager_event_h handle);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_event_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerEventDestroy(IntPtr handle);
        //int app_manager_event_destroy (app_manager_event_h handle);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_terminate_app", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerTerminateApp(IntPtr handle);
        //int app_manager_terminate_app (app_context_h app_context);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_terminate_app_without_restarting", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerTerminateAppWithoutRestarting(IntPtr handle);
        //int app_manager_terminate_app_without_restarting (app_context_h app_context);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_get_app_context_by_instance_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerGetAppContextByInstanceId(string applicationId, string instanceId, out IntPtr handle);
        //int app_manager_get_app_context_by_instance_id (const char *app_id, const char *instance_id, app_context_h *app_context);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_attach_window", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerAttachWindow(string parentAppId, string childAppId);
        //int app_manager_attach_window(const char *parent_app_id, const char *child_app_id);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_detach_window", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerDetachWindow(string applicationId);
        //int app_manager_detach_window(const char *app_id);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_attach_window_below", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerAttachWindowBelow(string parentAppId, string childAppId);
        //int app_manager_attach_window_below(const char *parent_app_id, const char *child_app_id);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_manager_request_remount_subsession", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppManagerRequestRemountSubsession(string subsessionId);
        //int app_manager_request_remount_subsession(const char *subsession_id);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextDestroy(IntPtr handle);
        //int app_context_destroy(app_context_h app_context)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextGetAppId(IntPtr handle, out string applicationId);
        //int app_context_get_app_id(app_context_h app_context, char **app_id)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_get_package_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextGetPackageId(IntPtr handle, out string packageId);
        //int app_context_get_package_id(app_context_h app_context, char **package_id)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_get_pid", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextGetPid(IntPtr handle, out int processId);
        //int app_context_get_pid (app_context_h app_context, pid_t *pid)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_get_app_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextGetAppState(IntPtr handle, out int state);
        //int app_context_get_app_state (app_context_h app_context, app_state_e *state)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_is_terminated", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextIsTerminated(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool terminated);
        //int app_context_is_terminated (app_context_h app_context, [MarshalAs(UnmanagedType.U1)] bool *terminated);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_is_equal", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextIsEqual(IntPtr first, IntPtr second, [MarshalAs(UnmanagedType.U1)] out bool equal);
        //int app_context_is_equal (app_context_h lhs, app_context_h rhs, [MarshalAs(UnmanagedType.U1)] bool *equal);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_is_sub_app", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextIsSubApp(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool is_sub_app);
        //int app_context_is_sub_app (app_context_h app_context, [MarshalAs(UnmanagedType.U1)] bool *is_sub_app);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_context_clone", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppContextClone(out IntPtr destination, IntPtr source);
        //int app_context_clone (app_context_h *clone, app_context_h app_context);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoCreate(string applicationId, out IntPtr handle);
        //int app_info_create (const char *app_id, app_info_h *app_info);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoDestroy(IntPtr handle);
        //int app_info_destroy (app_info_h app_info);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetAppId(IntPtr handle, out string applicationId);
        //int app_info_get_app_id (app_info_h app_info, char **app_id);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_exec", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetExec(IntPtr handle, out string exec);
        //int app_info_get_exec (app_info_h app_info, char **exec);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_label", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetLabel(IntPtr handle, out string label);
        //int app_info_get_label (app_info_h app_info, char **label);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_localed_label", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetLocaledLabel(string applicationId, string locale, out string label);
        //int app_info_get_localed_label (const char *app_id, const char *locale, char **label);

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_icon", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetIcon(IntPtr handle, out string path);
        //int app_info_get_icon (app_info_h app_info, char **path)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_package", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetPackage(IntPtr handle, out string package);
        //int app_info_get_package (app_info_h app_info, char **package)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetType(IntPtr handle, out string type);
        //int app_info_get_type (app_info_h app_info, char **type)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_get_app_component_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoGetAppComponentType(IntPtr handle, out AppInfoAppComponentType type);
        //int app_info_get_app_component_type(app_info_h app_info, app_info_app_component_type_e *type)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_foreach_metadata", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoForeachMetadata(IntPtr handle, AppInfoMetadataCallback callback, IntPtr userData);
        //int app_info_foreach_metadata(app_info_h app_info, app_info_metadata_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_is_nodisplay", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoIsNodisplay(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool noDisplay);
        //int app_info_is_nodisplay (app_info_h app_info, [MarshalAs(UnmanagedType.U1)] bool *nodisplay)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_is_equal", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoIsEqual(IntPtr first, IntPtr second, [MarshalAs(UnmanagedType.U1)] out bool equal);
        //int app_info_is_equal (app_info_h lhs, app_info_h rhs, [MarshalAs(UnmanagedType.U1)] bool *equal)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_is_enabled", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoIsEnabled(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool enabled);
        //int app_info_is_enabled (app_info_h app_info, [MarshalAs(UnmanagedType.U1)] bool *enabled)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_is_onboot", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoIsOnBoot(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool onBoot);
        //int app_info_is_onboot (app_info_h app_info, [MarshalAs(UnmanagedType.U1)] bool *onboot)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_is_preload", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoIsPreLoad(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool preLoaded);
        //int app_info_is_preload (app_info_h app_info, [MarshalAs(UnmanagedType.U1)] bool *preload)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_clone", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoClone(out IntPtr destination, IntPtr source);
        //int app_info_clone(app_info_h * clone, app_info_h app_info)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_foreach_category", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoForeachCategory(IntPtr handle, AppInfoCategoryCallback callback, IntPtr userData);
        //int app_info_foreach_category(app_info_h app_info, app_info_category_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterCreate(out IntPtr handle);
        //int app_info_filter_create(app_info_filter_h * handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterDestroy(IntPtr handle);
        //int app_info_filter_destroy(app_info_filter_h handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_add_bool", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterAddBool(IntPtr handle, string property, [MarshalAs(UnmanagedType.U1)] bool value);
        //int app_info_filter_add_bool(app_info_filter_h handle, const char *property, const [MarshalAs(UnmanagedType.U1)] bool value)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_add_string", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterAddString(IntPtr handle, string property, string value);
        //int app_info_filter_add_string(app_info_filter_h handle, const char *property, const char *value)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_count_appinfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterCountAppinfo(IntPtr handle, out int count);
        //int app_info_filter_count_appinfo(app_info_filter_h handle, int *count)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_filter_foreach_appinfo", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoFilterForeachAppinfo(IntPtr handle, AppInfoFilterCallback callback, IntPtr userData);
        //int app_info_filter_foreach_appinfo(app_info_filter_h handle, app_info_filter_cb callback, void * user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoMetadataFilterCreate(out IntPtr handle);
        //int app_info_metadata_filter_create (app_info_metadata_filter_h *handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoMetadataFilterDestroy(IntPtr handle);
        //int app_info_metadata_filter_destroy (app_info_metadata_filter_h handle)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_add", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoMetadataFilterAdd(IntPtr handle, string key, string value);
        //int app_info_metadata_filter_add (app_info_metadata_filter_h handle, const char *key, const char *value)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_metadata_filter_foreach", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoMetadataFilterForeach(IntPtr handle, AppInfoFilterCallback callback, IntPtr userData);
        //int app_info_metadata_filter_foreach (app_info_metadata_filter_h handle, app_info_filter_cb callback, void *user_data)

        [LibraryImport(Libraries.AppManager, EntryPoint = "app_info_foreach_res_control", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode AppInfoForeachResControl(IntPtr handle, AppInfoResControlCallback callback, IntPtr userData);

        [NativeStruct("struct rua_rec", Include = "rua.h", PkgConfig = "rua")]
        [StructLayout(LayoutKind.Sequential)]
        internal struct RuaRec
        {
            internal int id;
            internal IntPtr pkgName;
            internal IntPtr appPath;
            internal IntPtr arg;
            internal IntPtr launchTime;
            internal IntPtr instanceId;
            internal IntPtr instanceName;
            internal IntPtr icon;
            internal IntPtr uri;
            internal IntPtr image;
            internal IntPtr compId;
        };

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate void RuaHistoryUpdateCallback(IntPtr table, int nRows, int nCols, IntPtr userData);
        //void (*rua_history_update_cb) (char **table, int nrows, int ncols, void *user_data);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_history_get_rec", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaHistoryGetRecord(out RuaRec record, IntPtr table, int nRows, int nCols, int row);
        //int rua_history_get_rec(struct rua_rec *rec, char** table, int nrows, int ncols, int row);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_history_load_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaHistoryLoadDb(out IntPtr table, out int nRows, out int nCols);
        //int rua_history_load_db(char*** table, int *nrows, int *ncols);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_history_unload_db", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaHistoryUnLoadDb(ref IntPtr table);
        //int rua_history_unload_db(char*** table);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_delete_history_with_pkgname", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaDeleteHistoryWithPkgname(string pkgName);
        //int rua_delete_history_with_pkgname(char* pkg_name);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_delete_history_with_apppath", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaDeleteHistoryWithApppath(string appPath);
        //int rua_delete_history_with_apppath(char* app_path);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_clear_history", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaClearHistory();
        //int rua_clear_history(void);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_register_update_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaSetUpdateCallback(RuaHistoryUpdateCallback callback, IntPtr userData, out int id);
        //int rua_register_update_cb(rua_history_update_cb callback, void *user_data, int *callback_id);

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_unregister_update_cb", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaUnSetUpdateCallback(int id);
        //int rua_unregister_update_cb(int callback_id);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate int RuaStatTagIterCallback([MarshalAs(UnmanagedType.LPStr)] string ruaStatTag,
                                                     IntPtr userData);
        // int (*rua_stat_tag_iter_fn)(const char *rua_stat_tag, void *data)

        [LibraryImport(Libraries.Rua, EntryPoint = "rua_stat_get_stat_tags", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode RuaStatGetStatTags(string caller, RuaStatTagIterCallback callback,
                                                            IntPtr userData);
        // int rua_stat_get_stat_tags(char *caller, int (*rua_stat_tag_iter_fn)(const char *rua_stat_tag, void *data),
        // void *data);
    }
}




