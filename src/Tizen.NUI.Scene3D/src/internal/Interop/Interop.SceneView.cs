﻿/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
        internal static partial class SceneView
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_New_SWIG_0")]
            public static extern global::System.IntPtr SceneNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_SceneView_SWIG_0")]
            public static extern global::System.IntPtr NewScene();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_SceneView_SWIG_1")]
            public static extern global::System.IntPtr NewScene(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_SceneView")]
            public static extern void DeleteScene(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_Assign")]
            public static extern global::System.IntPtr SceneAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_DownCast")]
            public static extern global::System.IntPtr SceneDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_AddCamera")]
            public static extern void AddCamera(global::System.Runtime.InteropServices.HandleRef sceneView, global::System.Runtime.InteropServices.HandleRef camera);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_RemoveCamera")]
            public static extern void RemoveCamera(global::System.Runtime.InteropServices.HandleRef sceneView, global::System.Runtime.InteropServices.HandleRef camera);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetCameraCount")]
            public static extern uint GetCameraCount(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetSelectedCamera")]
            public static extern global::System.IntPtr GetSelectedCamera(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetCamera_0")]
            public static extern global::System.IntPtr GetCamera(global::System.Runtime.InteropServices.HandleRef sceneView, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetCamera_1")]
            public static extern global::System.IntPtr GetCamera(global::System.Runtime.InteropServices.HandleRef sceneView, string name);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SelectCamera_0")]
            public static extern void SelectCamera(global::System.Runtime.InteropServices.HandleRef sceneView, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SelectCamera_1")]
            public static extern void SelectCamera(global::System.Runtime.InteropServices.HandleRef sceneView, string name);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetImageBasedLightSource")]
            public static extern void SetImageBasedLightSource(global::System.Runtime.InteropServices.HandleRef sceneView, string diffuseUrl, string specularUrl, float scaleFactor);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetImageBasedLightScaleFactor")]
            public static extern global::System.IntPtr SetImageBasedLightScaleFactor(global::System.Runtime.InteropServices.HandleRef sceneView, float scaleFactor);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetImageBasedLightScaleFactor")]
            public static extern float GetImageBasedLightScaleFactor(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_UseFramebuffer")]
            public static extern void UseFramebuffer(global::System.Runtime.InteropServices.HandleRef sceneView, bool useFramebuffer);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_IsUsingFramebuffer")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsUsingFramebuffer(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetFramebufferMultiSamplingLevel")]
            public static extern void SetFramebufferMultiSamplingLevel(global::System.Runtime.InteropServices.HandleRef sceneView, uint multiSamplingLevel);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetFramebufferMultiSamplingLevel")]
            public static extern uint GetFramebufferMultiSamplingLevel(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetSkybox")]
            public static extern void SetSkybox(global::System.Runtime.InteropServices.HandleRef sceneView, string skyboxUrl);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetSkyboxIntensity")]
            public static extern void SetSkyboxIntensity(global::System.Runtime.InteropServices.HandleRef sceneView, float intensity);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetSkyboxIntensity")]
            public static extern float GetSkyboxIntensity(global::System.Runtime.InteropServices.HandleRef sceneView);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_SetSkyboxOrientation")]
            public static extern void SetSkyboxOrientation(global::System.Runtime.InteropServices.HandleRef sceneView, global::System.Runtime.InteropServices.HandleRef orientation);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetSkyboxOrientation")]
            public static extern global::System.IntPtr GetSkyboxOrientation(global::System.Runtime.InteropServices.HandleRef sceneView);
        }
    }
}
