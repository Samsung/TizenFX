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
            public static extern global::System.IntPtr new_RenderTaskList__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_DownCast")]
            public static extern global::System.IntPtr RenderTaskList_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTaskList")]
            public static extern void delete_RenderTaskList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskList__SWIG_1")]
            public static extern global::System.IntPtr new_RenderTaskList__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_Assign")]
            public static extern global::System.IntPtr RenderTaskList_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_CreateTask")]
            public static extern global::System.IntPtr RenderTaskList_CreateTask(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_RemoveTask")]
            public static extern void RenderTaskList_RemoveTask(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTaskCount")]
            public static extern uint RenderTaskList_GetTaskCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_GetTask")]
            public static extern global::System.IntPtr RenderTaskList_GetTask(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_POSITION_get")]
            public static extern int RenderTask_Property_VIEWPORT_POSITION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_VIEWPORT_SIZE_get")]
            public static extern int RenderTask_Property_VIEWPORT_SIZE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_CLEAR_COLOR_get")]
            public static extern int RenderTask_Property_CLEAR_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Property_REQUIRES_SYNC_get")]
            public static extern int RenderTask_Property_REQUIRES_SYNC_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask_Property")]
            public static extern global::System.IntPtr new_RenderTask_Property();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTask_Property")]
            public static extern void delete_RenderTask_Property(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get")]
            public static extern global::System.IntPtr RenderTask_DEFAULT_SCREEN_TO_FRAMEBUFFER_FUNCTION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get")]
            public static extern global::System.IntPtr RenderTask_FULLSCREEN_FRAMEBUFFER_FUNCTION_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_EXCLUSIVE_get")]
            public static extern bool RenderTask_DEFAULT_EXCLUSIVE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_INPUT_ENABLED_get")]
            public static extern bool RenderTask_DEFAULT_INPUT_ENABLED_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CLEAR_COLOR_get")]
            public static extern global::System.IntPtr RenderTask_DEFAULT_CLEAR_COLOR_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CLEAR_ENABLED_get")]
            public static extern bool RenderTask_DEFAULT_CLEAR_ENABLED_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_CULL_MODE_get")]
            public static extern bool RenderTask_DEFAULT_CULL_MODE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DEFAULT_REFRESH_RATE_get")]
            public static extern uint RenderTask_DEFAULT_REFRESH_RATE_get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_0")]
            public static extern global::System.IntPtr new_RenderTask__SWIG_0();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_DownCast")]
            public static extern global::System.IntPtr RenderTask_DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTask")]
            public static extern void delete_RenderTask(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTask__SWIG_1")]
            public static extern global::System.IntPtr new_RenderTask__SWIG_1(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_Assign")]
            public static extern global::System.IntPtr RenderTask_Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetSourceActor")]
            public static extern void RenderTask_SetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetSourceActor")]
            public static extern global::System.IntPtr RenderTask_GetSourceActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetExclusive")]
            public static extern void RenderTask_SetExclusive(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_IsExclusive")]
            public static extern bool RenderTask_IsExclusive(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetInputEnabled")]
            public static extern void RenderTask_SetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetInputEnabled")]
            public static extern bool RenderTask_GetInputEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCameraActor")]
            public static extern void RenderTask_SetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCameraActor")]
            public static extern global::System.IntPtr RenderTask_GetCameraActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetTargetFrameBuffer")]
            public static extern void RenderTask_SetTargetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetTargetFrameBuffer")]
            public static extern global::System.IntPtr RenderTask_GetTargetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetFrameBuffer")]
            public static extern void RenderTask_SetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetFrameBuffer")]
            public static extern global::System.IntPtr RenderTask_GetFrameBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetScreenToFrameBufferFunction")]
            public static extern void RenderTask_SetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetScreenToFrameBufferFunction")]
            public static extern global::System.IntPtr RenderTask_GetScreenToFrameBufferFunction(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetScreenToFrameBufferMappingActor")]
            public static extern void RenderTask_SetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetScreenToFrameBufferMappingActor")]
            public static extern global::System.IntPtr RenderTask_GetScreenToFrameBufferMappingActor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportPosition")]
            public static extern void RenderTask_SetViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportPosition")]
            public static extern global::System.IntPtr RenderTask_GetCurrentViewportPosition(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewportSize")]
            public static extern void RenderTask_SetViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCurrentViewportSize")]
            public static extern global::System.IntPtr RenderTask_GetCurrentViewportSize(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetViewport")]
            public static extern void RenderTask_SetViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetViewport")]
            public static extern global::System.IntPtr RenderTask_GetViewport(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearColor")]
            public static extern void RenderTask_SetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearColor")]
            public static extern global::System.IntPtr RenderTask_GetClearColor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetClearEnabled")]
            public static extern void RenderTask_SetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetClearEnabled")]
            public static extern bool RenderTask_GetClearEnabled(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetCullMode")]
            public static extern void RenderTask_SetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetCullMode")]
            public static extern bool RenderTask_GetCullMode(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SetRefreshRate")]
            public static extern void RenderTask_SetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_GetRefreshRate")]
            public static extern uint RenderTask_GetRefreshRate(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_WorldToViewport")]
            public static extern bool RenderTask_WorldToViewport(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, out float jarg3, out float jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_ViewportToLocal")]
            public static extern bool RenderTask_ViewportToLocal(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, float jarg4, out float jarg5, out float jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_FinishedSignal")]
            public static extern global::System.IntPtr RenderTask_FinishedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_RenderTaskSignal")]
            public static extern global::System.IntPtr new_RenderTaskSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_RenderTaskSignal")]
            public static extern void delete_RenderTaskSignal(global::System.Runtime.InteropServices.HandleRef jarg1);
            
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTaskList_SWIGUpcast")]
            public static extern global::System.IntPtr RenderTaskList_SWIGUpcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_RenderTask_SWIGUpcast")]
            public static extern global::System.IntPtr RenderTask_SWIGUpcast(global::System.IntPtr jarg1);
        }
    }
}