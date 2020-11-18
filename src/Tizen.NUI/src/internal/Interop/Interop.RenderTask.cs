using System;
using System.Collections.Generic;
using System.Text;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class RenderTask
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskList__SWIG_0")]
            public static extern global::System.IntPtr NewRenderTaskListSwig0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_DownCast")]
            public static extern global::System.IntPtr RenderTaskListDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTaskList")]
            public static extern void DeleteRenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskList__SWIG_1")]
            public static extern global::System.IntPtr NewRenderTaskListSwig1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_Assign")]
            public static extern global::System.IntPtr RenderTaskListAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_CreateTask")]
            public static extern global::System.IntPtr RenderTaskListCreateTask(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_RemoveTask")]
            public static extern void RenderTaskListRemoveTask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTaskCount")]
            public static extern uint RenderTaskListGetTaskCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTask")]
            public static extern global::System.IntPtr RenderTaskListGetTask(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_POSITION_get")]
            public static extern int RenderTaskPropertyViewportPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_SIZE_get")]
            public static extern int RenderTaskPropertyViewportSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_CLEAR_COLOR_get")]
            public static extern int RenderTaskPropertyClearColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_REQUIRES_SYNC_get")]
            public static extern int RenderTaskPropertyRequiresSyncGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask_Property")]
            public static extern global::System.IntPtr NewRenderTaskProperty();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTask_Property")]
            public static extern void DeleteRenderTaskProperty(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get")]
            public static extern global::System.IntPtr RenderTaskDefaultScreenToFramebufferFunctionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get")]
            public static extern global::System.IntPtr RenderTaskFullscreenFramebufferFunctionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_EXCLUSIVE_get")]
            public static extern bool RenderTaskDefaultExclusiveGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_INPUT_ENABLED_get")]
            public static extern bool RenderTaskDefaultInputEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CLEAR_COLOR_get")]
            public static extern global::System.IntPtr RenderTaskDefaultClearColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CLEAR_ENABLED_get")]
            public static extern bool RenderTaskDefaultClearEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CULL_MODE_get")]
            public static extern bool RenderTaskDefaultCullModeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_REFRESH_RATE_get")]
            public static extern uint RenderTaskDefaultRefreshRateGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_0")]
            public static extern global::System.IntPtr NewRenderTaskSwig0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DownCast")]
            public static extern global::System.IntPtr RenderTaskDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTask")]
            public static extern void DeleteRenderTask(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_1")]
            public static extern global::System.IntPtr NewRenderTaskSwig1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Assign")]
            public static extern global::System.IntPtr RenderTaskAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetSourceActor")]
            public static extern void RenderTaskSetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetSourceActor")]
            public static extern global::System.IntPtr RenderTaskGetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetExclusive")]
            public static extern void RenderTaskSetExclusive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_IsExclusive")]
            public static extern bool RenderTaskIsExclusive(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetInputEnabled")]
            public static extern void RenderTaskSetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetInputEnabled")]
            public static extern bool RenderTaskGetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCameraActor")]
            public static extern void RenderTaskSetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCameraActor")]
            public static extern global::System.IntPtr RenderTaskGetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetFrameBuffer")]
            public static extern void RenderTaskSetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetFrameBuffer")]
            public static extern global::System.IntPtr RenderTaskGetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetScreenToFrameBufferFunction")]
            public static extern void RenderTaskSetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetScreenToFrameBufferFunction")]
            public static extern global::System.IntPtr RenderTaskGetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetScreenToFrameBufferMappingActor")]
            public static extern void RenderTaskSetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetScreenToFrameBufferMappingActor")]
            public static extern global::System.IntPtr RenderTaskGetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportPosition")]
            public static extern void RenderTaskSetViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportPosition")]
            public static extern global::System.IntPtr RenderTaskGetCurrentViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportSize")]
            public static extern void RenderTaskSetViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportSize")]
            public static extern global::System.IntPtr RenderTaskGetCurrentViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewport")]
            public static extern void RenderTaskSetViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetViewport")]
            public static extern global::System.IntPtr RenderTaskGetViewport(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearColor")]
            public static extern void RenderTaskSetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearColor")]
            public static extern global::System.IntPtr RenderTaskGetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearEnabled")]
            public static extern void RenderTaskSetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearEnabled")]
            public static extern bool RenderTaskGetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCullMode")]
            public static extern void RenderTaskSetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCullMode")]
            public static extern bool RenderTaskGetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetRefreshRate")]
            public static extern void RenderTaskSetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetRefreshRate")]
            public static extern uint RenderTaskGetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_WorldToViewport")]
            public static extern bool RenderTaskWorldToViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, out float jarg3, out float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_ViewportToLocal")]
            public static extern bool RenderTaskViewportToLocal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, float jarg4, out float jarg5, out float jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_FinishedSignal")]
            public static extern global::System.IntPtr RenderTaskFinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskSignal")]
            public static extern global::System.IntPtr NewRenderTaskSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTaskSignal")]
            public static extern void DeleteRenderTaskSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_SWIGUpcast")]
            public static extern global::System.IntPtr RenderTaskListSwigUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SWIGUpcast")]
            public static extern global::System.IntPtr RenderTaskSwigUpcast(global::System.IntPtr jarg1);
        }
    }
}
