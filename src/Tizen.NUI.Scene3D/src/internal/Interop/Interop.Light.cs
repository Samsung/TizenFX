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
        internal static partial class Light
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_New_SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Light_SWIG_0")]
            public static extern global::System.IntPtr NewLight();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Light_SWIG_1")]
            public static extern global::System.IntPtr NewLight(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Light")]
            public static extern void DeleteLight(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_DownCast")]
            public static extern global::System.IntPtr LightDownCast(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_Enable")]
            public static extern void Enable(global::System.Runtime.InteropServices.HandleRef light, bool enable);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_IsEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsEnabled(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_SceneView_GetMaximumEnabledLightCount")]
            public static extern uint GetMaximumEnabledLightCount();
        }
    }
}
