/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
namespace Tizen.NUI.Scene3D
{
    internal static partial class Interop
    {
        internal static partial class Model
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_New_SWIG_0")]
            public static extern global::System.IntPtr ModelNew(string modelUrl, string resourcePasth);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_New_SWIG_1")]
            public static extern global::System.IntPtr ModelNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Model_SWIG_1")]
            public static extern global::System.IntPtr NewModel(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Model")]
            public static extern void DeleteModel(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetModelRoot")]
            public static extern global::System.IntPtr GetModelRoot(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_AddModelNode")]
            public static extern void AddModelNode(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef modelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_RemoveModelNode")]
            public static extern void RemoveModelNode(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef modelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_SetImageBasedLightSource")]
            public static extern global::System.IntPtr SetImageBasedLightSource(global::System.Runtime.InteropServices.HandleRef model, string diffuse, string specular, float scaleFactor);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_SetImageBasedLightScaleFactor")]
            public static extern global::System.IntPtr SetImageBasedLightScaleFactor(global::System.Runtime.InteropServices.HandleRef model, float scaleFactor);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetImageBasedLightScaleFactor")]
            public static extern float GetImageBasedLightScaleFactor(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetAnimationCount")]
            public static extern uint GetAnimationCount(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetAnimation_1")]
            public static extern global::System.IntPtr GetAnimation(global::System.Runtime.InteropServices.HandleRef model, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetAnimation_2")]
            public static extern global::System.IntPtr GetAnimation(global::System.Runtime.InteropServices.HandleRef model, string name);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetCameraCount")]
            public static extern uint GetCameraCount(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GenerateCamera")]
            public static extern global::System.IntPtr GenerateCamera(global::System.Runtime.InteropServices.HandleRef model, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_ApplyCamera")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool ApplyCamera(global::System.Runtime.InteropServices.HandleRef model, uint index, global::System.Runtime.InteropServices.HandleRef camera);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_FindChildModelNodeByName")]
            public static extern global::System.IntPtr FindChildModelNodeByName(global::System.Runtime.InteropServices.HandleRef model, string nodeName);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GenerateMotionDataAnimation")]
            public static extern global::System.IntPtr GenerateMotionDataAnimation(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_SetMotionData")]
            public static extern void SetMotionData(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef motionData);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_LoadBvhAnimation_1")]
            public static extern global::System.IntPtr LoadBvhAnimation(global::System.Runtime.InteropServices.HandleRef model, string bvhFilename, global::System.Runtime.InteropServices.HandleRef scale, bool translateRootFromModelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_LoadBvhAnimation_2")]
            public static extern global::System.IntPtr LoadBvhAnimationFromBuffer(global::System.Runtime.InteropServices.HandleRef model, string bvhBuffer, int bvhBufferLength, global::System.Runtime.InteropServices.HandleRef scale, bool translateRootFromModelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_LoadFacialAnimation_1")]
            public static extern global::System.IntPtr LoadBlendShapeAnimation(global::System.Runtime.InteropServices.HandleRef model, string jsonFilename);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_LoadFacialAnimation_2")]
            public static extern global::System.IntPtr LoadBlendShapeAnimationFromBuffer(global::System.Runtime.InteropServices.HandleRef model, string jsonBuffer, int jsonBufferLength);
            
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_CastShadow")]
            public static extern void CastShadow(global::System.Runtime.InteropServices.HandleRef model, bool castShadow);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_IsShadowCasting")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowCasting(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_ReceiveShadow")]
            public static extern void ReceiveShadow(global::System.Runtime.InteropServices.HandleRef model, bool receiveShadow);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_IsShadowReceiving")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowReceiving(global::System.Runtime.InteropServices.HandleRef model);

            
            // Signals
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_MeshHitSignal_Connect")]
            public static extern void MeshHitSignalConnect(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_MeshHitSignal_Disconnect")]
            public static extern void MeshHitSignalDisconnect(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_GetLoadingStatus")]
            public static extern int GetLoadingStatus(global::System.Runtime.InteropServices.HandleRef model);
        }
    }
}
