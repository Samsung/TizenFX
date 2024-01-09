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

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Light_SWIG_1")]
            public static extern global::System.IntPtr NewLight(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_Enable")]
            public static extern void Enable(global::System.Runtime.InteropServices.HandleRef light, bool enable);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_IsEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsEnabled(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_GetMaximumEnabledLightCount")]
            public static extern uint GetMaximumEnabledLightCount();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_EnableShadow")]
            public static extern void EnableShadow(global::System.Runtime.InteropServices.HandleRef light, bool enable);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_IsShadowEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowEnabled(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_EnableShadowSoftFiltering")]
            public static extern void EnableShadowSoftFiltering(global::System.Runtime.InteropServices.HandleRef light, bool enable);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_IsShadowSoftFilteringEnabled")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowSoftFilteringEnabled(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_SetShadowIntensity")]
            public static extern void SetShadowIntensity(global::System.Runtime.InteropServices.HandleRef light, float shadowIntensity);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_GetShadowIntensity")]
            public static extern float GetShadowIntensity(global::System.Runtime.InteropServices.HandleRef light);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_SetShadowBias")]
            public static extern void SetShadowBias(global::System.Runtime.InteropServices.HandleRef light, float shadowIntensity);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Light_GetShadowBias")]
            public static extern float GetShadowBias(global::System.Runtime.InteropServices.HandleRef light);
        }
    }
}
