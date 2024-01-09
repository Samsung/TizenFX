/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI.Scene3D
{
    internal static partial class Interop
    {
        internal static partial class MotionData
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_New_SWIG_0")]
            public static extern global::System.IntPtr MotionDataNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_New_SWIG_1")]
            public static extern global::System.IntPtr MotionDataNew(float duration);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_MotionData_SWIG_1")]
            public static extern global::System.IntPtr NewMotionData(global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_MotionData")]
            public static extern void DeleteMotionData(global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_Assign")]
            public static extern global::System.IntPtr MotionDataAssign(global::System.Runtime.InteropServices.HandleRef motionData, global::System.Runtime.InteropServices.HandleRef sourceMotionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_GetMotionCount")]
            public static extern uint GetMotionCount(global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_GetIndex")]
            public static extern global::System.IntPtr GetIndex(global::System.Runtime.InteropServices.HandleRef motionData, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_GetValue")]
            public static extern global::System.IntPtr GetValue(global::System.Runtime.InteropServices.HandleRef motionData, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_Add")]
            public static extern void Add(global::System.Runtime.InteropServices.HandleRef motionData, global::System.Runtime.InteropServices.HandleRef motionIndex, global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_Clear")]
            public static extern void Clear(global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_SetDuration")]
            public static extern void SetDuration(global::System.Runtime.InteropServices.HandleRef motionData, float duration);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_GetDuration")]
            public static extern float GetDuration(global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadBvh")]
            public static extern void LoadMotionCaptureAnimation(global::System.Runtime.InteropServices.HandleRef motionData, string motionCaptureFilename, bool useRootTranslationOnly, global::System.Runtime.InteropServices.HandleRef scale, bool synchronousLoad);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadBvhFromBuffer")]
            public static extern void LoadMotionCaptureAnimationFromBuffer(global::System.Runtime.InteropServices.HandleRef motionData, string motionCaptureBuffer, int motionCaptureBufferLength, bool useRootTranslationOnly, global::System.Runtime.InteropServices.HandleRef scale, bool synchronousLoad);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadFacialAnimation")]
            public static extern void LoadBlendShapeAnimation(global::System.Runtime.InteropServices.HandleRef motionData, string blendShapeFilename, bool synchronousLoad);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadFacialAnimationFromBuffer")]
            public static extern void LoadBlendShapeAnimationFromBuffer(global::System.Runtime.InteropServices.HandleRef motionData, string blendShapeBuffer, int blendShapeBufferLength, bool synchronousLoad);

            // Signals

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadCompletedSignal_Connect")]
            public static extern void LoadCompletedConnect(global::System.Runtime.InteropServices.HandleRef motionData, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionData_LoadCompletedSignal_Disconnect")]
            public static extern void LoadCompletedDisconnect(global::System.Runtime.InteropServices.HandleRef motionData, global::System.Runtime.InteropServices.HandleRef handler);
        }
    }
}
