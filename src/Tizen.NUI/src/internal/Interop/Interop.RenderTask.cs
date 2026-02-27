/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
 *
 */

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class RenderTask
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskList__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRenderTaskList();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTaskList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRenderTaskList(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RenderTaskListAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_CreateTask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RenderTaskListCreateTask(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_RemoveTask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RenderTaskListRemoveTask(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTaskCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint RenderTaskListGetTaskCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RenderTaskListGetTask(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ViewportPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ViewportSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_CLEAR_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ClearColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_REQUIRES_SYNC_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RequiresSyncGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRenderTask();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTask", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRenderTask(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRenderTask(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetSourceActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSourceActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetSourceActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetSourceActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetExclusive", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetExclusive(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_IsExclusive", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsExclusive(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetInputEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInputEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetInputEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetInputEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCameraActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCameraActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCameraActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCameraActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetFrameBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFrameBuffer(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetFrameBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetFrameBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetScreenToFrameBufferMappingActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScreenToFrameBufferMappingActor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetScreenToFrameBufferMappingActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScreenToFrameBufferMappingActor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetViewportPosition(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentViewportPosition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetViewportSize(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentViewportSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewport", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetViewport(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetViewport", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetViewport(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClearColor(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearColor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetClearColor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetClearEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetClearEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCullMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCullMode(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCullMode", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetCullMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetRefreshRate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRefreshRate(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetRefreshRate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetRefreshRate(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_WorldToViewport", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WorldToViewport(IntPtr jarg1, IntPtr jarg2, out float jarg3, out float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_ViewportToLocal", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ViewportToLocal(IntPtr jarg1, IntPtr jarg2, float jarg3, float jarg4, out float jarg5, out float jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetRenderPassTag", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRenderPassTag(IntPtr nuiRenderTask, uint renderPassTag);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetRenderPassTag", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetRenderPassTag(IntPtr nuiRenderTask);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetOrderIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetOrderIndex(IntPtr nuiRenderTask, int orderIndex);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetOrderIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetOrderIndex(IntPtr nuiRenderTask);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetRenderTaskId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetRenderTaskId(IntPtr nuiRenderTask);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_RenderUntil", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RenderUntil(IntPtr nuiRenderTask, IntPtr nuiStopperView);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetStopperActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetStopperView(IntPtr nuiRenderTask);
        }
    }
}





