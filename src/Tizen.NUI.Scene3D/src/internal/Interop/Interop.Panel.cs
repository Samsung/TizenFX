/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
        internal static partial class Panel
        {            
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_New_SWIG_0")]
            public static extern global::System.IntPtr PanelNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Panel")]
            public static extern void DeletePanel(global::System.Runtime.InteropServices.HandleRef panel);
            
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_SetPanelResolution")]
            public static extern void SetPanelResolution(global::System.Runtime.InteropServices.HandleRef panel, global::System.Runtime.InteropServices.HandleRef resolution);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_GetPanelResolution")]
            public static extern global::System.IntPtr GetPanelResolution(global::System.Runtime.InteropServices.HandleRef panel);
            
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_SetContent")]
            public static extern void SetContent(global::System.Runtime.InteropServices.HandleRef panel, global::System.Runtime.InteropServices.HandleRef resolution);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_GetContent")]
            public static extern global::System.IntPtr GetContent(global::System.Runtime.InteropServices.HandleRef panel);
            
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_CastShadow")]
            public static extern void CastShadow(global::System.Runtime.InteropServices.HandleRef panel, bool castShadow);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_IsShadowCasting")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowCasting(global::System.Runtime.InteropServices.HandleRef panel);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_ReceiveShadow")]
            public static extern void ReceiveShadow(global::System.Runtime.InteropServices.HandleRef panel, bool receiveShadow);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_IsShadowReceiving")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsShadowReceiving(global::System.Runtime.InteropServices.HandleRef panel);


            // For Property index
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_property_TRANSPARENT_get")]
            public static extern int PropertyTransparentIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_property_DOUBLE_SIDED_get")]
            public static extern int PropertyDoubleSidedIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_property_USE_BACK_FACE_PLANE_get")]
            public static extern int PropertyUseBackFacePlaneIndexGet();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Panel_property_BACK_FACE_PLANE_COLOR_get")]
            public static extern int PropertyBackFacePlaneColorIndexGet();
        }
    }
}
