/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    internal static partial class ComponentManager
    {
        internal enum ErrorCode
        {
            None = Tizen.Internals.Errors.ErrorCode.None,
            InvalidParameter = Tizen.Internals.Errors.ErrorCode.InvalidParameter,
            OutOfMemory = Tizen.Internals.Errors.ErrorCode.OutOfMemory,
            IoError = Tizen.Internals.Errors.ErrorCode.IoError,
            NoSuchComponent = -0x03040000 | 0x01,
            DbFailed = -0x03040000 | 0x03,
            InvalidApplication = -0x03040000 | 0x04,
            NotRunning = -0x03040000 | 0x05,
            LabelNotFound = -0x03040000 | 0x06,
            PermissionDenied = Tizen.Internals.Errors.ErrorCode.PermissionDenied
        }

        internal enum ComponentInfoComponentType
        {
            Frame = 0,
            Service = 1
        }

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ComponentManagerComponentContextCallback(IntPtr handle, IntPtr userData);
        // bool (*component_manager_component_context_cb)(component_context_h handle, void *user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        internal delegate bool ComponentManagerComponentInfoCallback(IntPtr handle, IntPtr userData);
        // bool (*component_manager_component_info_cb)(component_info_h handle, void *user_data);
               
        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_foreach_component_context")]
        internal static extern ErrorCode ComponentManagerForeachComponentContext(ComponentManagerComponentContextCallback callback, IntPtr userData);
        // int component_manager_foreach_component_context(component_manager_component_context_cb callback, void *user_data)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_foreach_component_info")]
        internal static extern ErrorCode ComponentManagerForeachComponentInfo(ComponentManagerComponentInfoCallback callback, IntPtr userData);
        // int component_manager_foreach_component_info(component_manager_component_info_cb callback, void *user_data)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_get_component_context")]
        internal static extern ErrorCode ComponentManagerGetComponentContext(string componentId, out IntPtr handle);
        // int component_manager_get_component_context(const char *comp_id, component_context_h *handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_get_component_info")]
        internal static extern ErrorCode ComponentManagerGetComponentInfo(string componentId, out IntPtr handle);
        // int component_manager_get_component_info(const char *comp_id, component_info_h *handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_is_running")]
        internal static extern ErrorCode ComponentManagerIsRunning(string componentId, out bool running);
        // int component_manager_is_running(const char *appid, bool *running);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_resume_component")]
        internal static extern ErrorCode ComponentManagerResumeComponent(IntPtr handle);
        // int component_manager_resume_component(component_context_h handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_terminate_bg_component")]
        internal static extern ErrorCode ComponentManagerTerminateBgComponent(IntPtr handle);
        // int component_manager_terminate_bg_component (component_context_h handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_pause_component")]
        internal static extern ErrorCode ComponentManagerPauseComponent(IntPtr handle);
        // int component_manager_pause_component(component_context_h handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_manager_terminate_component")]
        internal static extern ErrorCode ComponentManagerTerminateComponent(IntPtr handle);
        // int component_manager_terminate_component(component_context_h handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_destroy")]
        internal static extern ErrorCode ComponentContextDestroy(IntPtr handle);
        // int component_context_destroy(component_context_h handle)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_get_app_id")]
        internal static extern ErrorCode ComponentContextGetAppId(IntPtr handle, out string applicationId);
        // int component_context_get_app_id(component_context_h handle, char **app_id)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_get_component_id")]
        internal static extern ErrorCode ComponentContextGetComponentId(IntPtr handle, out string componentId);
        // int component_context_get_component_id(component_context_h handle, char **component_id)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_get_instance_id")]
        internal static extern ErrorCode ComponentContextGetInstanceId(IntPtr handle, out string instanceId);
        // int component_context_get_instance_id(component_context_h handle, char **instance_id)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_get_component_state")]
        internal static extern ErrorCode ComponentContextGetComponentState(IntPtr handle, out int state);
        // int component_context_get_component_state(component_context_h handle, component_state_e *state)

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_is_terminated")]
        internal static extern ErrorCode ComponentContextIsTerminated(IntPtr handle, out bool terminated);
        // int component_context_is_terminated(component_context_h handle, bool *terminated);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_is_subcomponent")]
        internal static extern ErrorCode ComponentContextIsSubComponent(IntPtr handle, out bool is_subcomponent);
        // int component_context_is_subcomponent(component_context_h handle, bool *is_subcomponent);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_context_clone")]
        internal static extern ErrorCode ComponentContextClone(out IntPtr destination, IntPtr source);
        // int component_context_clone(component_context_h *clone, component_context_h handle);
        
        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_create")]
        internal static extern ErrorCode ComponentInfoCreate(string componentId, out IntPtr handle);
        // int component_info_create(const char *component_id, component_info_h *handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_destroy")]
        internal static extern ErrorCode ComponentInfoDestroy(IntPtr handle);
        // int component_info_destroy(component_info_h handle);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_app_id")]
        internal static extern ErrorCode ComponentInfoGetAppId(IntPtr handle, out string applicationId);
        // int component_info_get_app_id(component_info_h handle, char **app_id);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_component_id")]
        internal static extern ErrorCode ComponentInfoGetComponentId(IntPtr handle, out string componentId);
        // int component_info_get_component_id(component_info_h handle, char **component_id);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_component_type")]
        internal static extern ErrorCode ComponentInfoGetComponentType(IntPtr handle, out ComponentInfoComponentType type);
        // int component_info_get_component_type(component_info_h handle, component_info_component_type_e *type);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_is_icon_display")]
        internal static extern ErrorCode ComponentInfoIsIconDisplay(IntPtr handle, out bool iconDisplay);
        // int component_info_is_icon_display(component_info_h handle, bool *icon_display);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_is_managed_by_task_manager")]
        internal static extern ErrorCode ComponentInfoIsManagedByTaskManager(IntPtr handle, out bool managed);
        // int component_info_is_managed_by_task_manager(component_info_h handle, bool *managed);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_icon")]
        internal static extern ErrorCode ComponentInfoGetIcon(IntPtr handle, out string icon);
        // int component_info_get_icon(component_info_h handle, char **icon);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_label")]
        internal static extern ErrorCode ComponentInfoGetLabel(IntPtr handle, out string label);
        // int component_info_get_label(component_info_h handle, char **label);

        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_get_localized_label")]
        internal static extern ErrorCode ComponentInfoGetLocalizedLabel(IntPtr handle, string locale, out string label);
        // int component_info_get_localized_label(component_info_h handle, const char *locale, char **label);
        
        [DllImport(Libraries.ComponentManager, EntryPoint = "component_info_clone")]
        internal static extern ErrorCode ComponentInfoClone(out IntPtr destination, IntPtr source);
        // int component_info_clone(component_info_h *clone, component_info_h handle);
    }
}
