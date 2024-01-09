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
        internal static partial class ModelPrimitive
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_New_SWIG_0")]
            public static extern global::System.IntPtr ModelPrimitiveNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Model_Primitive_SWIG_1")]
            public static extern global::System.IntPtr NewModelPrimitive(global::System.Runtime.InteropServices.HandleRef modelPrimitive);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Model_Primitive")]
            public static extern void DeleteModelPrimitive(global::System.Runtime.InteropServices.HandleRef modelPrimitive);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_Assign")]
            public static extern global::System.IntPtr ModelPrimitiveAssign(global::System.Runtime.InteropServices.HandleRef modelPrimitive, global::System.Runtime.InteropServices.HandleRef sourceModelPrimitive);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_SetGeometry")]
            public static extern void SetGeometry(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef geometry);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_GetGeometry")]
            public static extern global::System.IntPtr GetGeometry(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_SetMaterial")]
            public static extern void SetMaterial(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef material);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Primitive_GetMaterial")]
            public static extern global::System.IntPtr GetMaterial(global::System.Runtime.InteropServices.HandleRef model);
        }
    }
}
