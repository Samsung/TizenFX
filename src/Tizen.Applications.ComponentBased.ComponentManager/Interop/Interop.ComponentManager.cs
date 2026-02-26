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
using System.Runtime.InteropServices.Marshalling;

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
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ComponentManagerComponentContextCallback(IntPtr handle, IntPtr userData);
        // [MarshalAs(UnmanagedType.U1)] bool (*component_manager_component_context_cb)(component_context_h handle, void *user_data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [return: MarshalAs(UnmanagedType.U1)] internal delegate bool ComponentManagerComponentInfoCallback(IntPtr handle, IntPtr userData);
        // [MarshalAs(UnmanagedType.U1)] bool (*component_manager_component_info_cb)(component_info_h handle, void *user_data);
               
        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_foreach_component_context", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerForeachComponentContext(ComponentManagerComponentContextCallback callback, IntPtr userData);
        // int component_manager_foreach_component_context(component_manager_component_context_cb callback, void *user_data)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_foreach_component_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerForeachComponentInfo(ComponentManagerComponentInfoCallback callback, IntPtr userData);
        // int component_manager_foreach_component_info(component_manager_component_info_cb callback, void *user_data)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_get_component_context", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerGetComponentContext(string componentId, out IntPtr handle);
        // int component_manager_get_component_context(const char *comp_id, component_context_h *handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_get_component_info", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerGetComponentInfo(string componentId, out IntPtr handle);
        // int component_manager_get_component_info(const char *comp_id, component_info_h *handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_is_running", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerIsRunning(string componentId, [MarshalAs(UnmanagedType.U1)] out bool running);
        // int component_manager_is_running(const char *appid, [MarshalAs(UnmanagedType.U1)] bool *running);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_resume_component", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerResumeComponent(IntPtr handle);
        // int component_manager_resume_component(component_context_h handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_terminate_bg_component", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerTerminateBgComponent(IntPtr handle);
        // int component_manager_terminate_bg_component (component_context_h handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_pause_component", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerPauseComponent(IntPtr handle);
        // int component_manager_pause_component(component_context_h handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_manager_terminate_component", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentManagerTerminateComponent(IntPtr handle);
        // int component_manager_terminate_component(component_context_h handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextDestroy(IntPtr handle);
        // int component_context_destroy(component_context_h handle)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextGetAppId(IntPtr handle, out string applicationId);
        // int component_context_get_app_id(component_context_h handle, char **app_id)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_get_component_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextGetComponentId(IntPtr handle, out string componentId);
        // int component_context_get_component_id(component_context_h handle, char **component_id)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_get_instance_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextGetInstanceId(IntPtr handle, out string instanceId);
        // int component_context_get_instance_id(component_context_h handle, char **instance_id)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_get_component_state", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextGetComponentState(IntPtr handle, out int state);
        // int component_context_get_component_state(component_context_h handle, component_state_e *state)

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_is_terminated", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextIsTerminated(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool terminated);
        // int component_context_is_terminated(component_context_h handle, [MarshalAs(UnmanagedType.U1)] bool *terminated);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_is_subcomponent", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextIsSubComponent(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool is_subcomponent);
        // int component_context_is_subcomponent(component_context_h handle, [MarshalAs(UnmanagedType.U1)] bool *is_subcomponent);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_context_clone", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentContextClone(out IntPtr destination, IntPtr source);
        // int component_context_clone(component_context_h *clone, component_context_h handle);
        
        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_create", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoCreate(string componentId, out IntPtr handle);
        // int component_info_create(const char *component_id, component_info_h *handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_destroy", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoDestroy(IntPtr handle);
        // int component_info_destroy(component_info_h handle);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_app_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetAppId(IntPtr handle, out string applicationId);
        // int component_info_get_app_id(component_info_h handle, char **app_id);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_component_id", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetComponentId(IntPtr handle, out string componentId);
        // int component_info_get_component_id(component_info_h handle, char **component_id);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_component_type", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetComponentType(IntPtr handle, out ComponentInfoComponentType type);
        // int component_info_get_component_type(component_info_h handle, component_info_component_type_e *type);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_is_icon_display", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoIsIconDisplay(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool iconDisplay);
        // int component_info_is_icon_display(component_info_h handle, [MarshalAs(UnmanagedType.U1)] bool *icon_display);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_is_managed_by_task_manager", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoIsManagedByTaskManager(IntPtr handle, [MarshalAs(UnmanagedType.U1)] out bool managed);
        // int component_info_is_managed_by_task_manager(component_info_h handle, [MarshalAs(UnmanagedType.U1)] bool *managed);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_icon", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetIcon(IntPtr handle, out string icon);
        // int component_info_get_icon(component_info_h handle, char **icon);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_label", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetLabel(IntPtr handle, out string label);
        // int component_info_get_label(component_info_h handle, char **label);

        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_get_localized_label", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoGetLocalizedLabel(IntPtr handle, string locale, out string label);
        // int component_info_get_localized_label(component_info_h handle, const char *locale, char **label);
        
        [LibraryImport(Libraries.ComponentManager, EntryPoint = "component_info_clone", StringMarshalling = StringMarshalling.Utf8)]
        internal static partial ErrorCode ComponentInfoClone(out IntPtr destination, IntPtr source);
        // int component_info_clone(component_info_h *clone, component_info_h handle);
    }
}




