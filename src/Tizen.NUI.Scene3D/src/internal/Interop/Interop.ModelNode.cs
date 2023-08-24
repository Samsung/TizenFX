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
        internal static partial class ModelNode
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_New_SWIG_0")]
            public static extern global::System.IntPtr ModelNodeNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Model_Node_SWIG_0")]
            public static extern global::System.IntPtr NewModelNode();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_Model_Node_SWIG_1")]
            public static extern global::System.IntPtr NewModelNode(global::System.Runtime.InteropServices.HandleRef modelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_Model_Node")]
            public static extern void DeleteModelNode(global::System.Runtime.InteropServices.HandleRef modelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_Assign")]
            public static extern global::System.IntPtr ModelNodeAssign(global::System.Runtime.InteropServices.HandleRef modelNode, global::System.Runtime.InteropServices.HandleRef sourceModelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_DownCast")]
            public static extern global::System.IntPtr ModelNodeDownCast(global::System.Runtime.InteropServices.HandleRef modelNode);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_GetModelPrimitiveCount")]
            public static extern uint GetModelPrimitiveCount(global::System.Runtime.InteropServices.HandleRef model);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_AddModelPrimitive")]
            public static extern void AddModelPrimitive(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef modelPrimitive);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_RemoveModelPrimitive")]
            public static extern void RemoveModelPrimitive(global::System.Runtime.InteropServices.HandleRef model, global::System.Runtime.InteropServices.HandleRef modelPrimitive);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_RemoveModelPrimitive")]
            public static extern void RemoveModelPrimitive(global::System.Runtime.InteropServices.HandleRef model, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_GetModelPrimitive")]
            public static extern global::System.IntPtr GetModelPrimitive(global::System.Runtime.InteropServices.HandleRef model, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_Model_Node_FindChildModelNodeByName")]
            public static extern global::System.IntPtr FindChildModelNodeByName(global::System.Runtime.InteropServices.HandleRef model, string nodeName);
        }
    }
}
