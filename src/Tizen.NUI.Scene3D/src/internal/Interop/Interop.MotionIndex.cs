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
        internal static partial class MotionIndex
        {
            #region MotionIndex
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_MotionIndex_SWIG_1")]
            public static extern global::System.IntPtr NewMotionIndex(global::System.Runtime.InteropServices.HandleRef motionIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_MotionIndex")]
            public static extern void DeleteMotionIndex(global::System.Runtime.InteropServices.HandleRef motionIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionIndex_Assign")]
            public static extern global::System.IntPtr MotionIndexAssign(global::System.Runtime.InteropServices.HandleRef motionIndex, global::System.Runtime.InteropServices.HandleRef sourceMotionIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionIndex_SetModelNodeId")]
            public static extern void SetModelNodeId(global::System.Runtime.InteropServices.HandleRef motionIndex, global::System.Runtime.InteropServices.HandleRef modelNodeId);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionIndex_GetModelNodeId")]
            public static extern global::System.IntPtr GetModelNodeId(global::System.Runtime.InteropServices.HandleRef motionIndex);
            #endregion

            #region BlendShapeIndex
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_New_SWIG_0")]
            public static extern global::System.IntPtr BlendShapeIndexNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_New_SWIG_1")]
            public static extern global::System.IntPtr BlendShapeIndexNew(global::System.Runtime.InteropServices.HandleRef blendShapePropertyKey);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_New_SWIG_2")]
            public static extern global::System.IntPtr BlendShapeIndexNew(global::System.Runtime.InteropServices.HandleRef modelNodePropertKey, global::System.Runtime.InteropServices.HandleRef blendShapePropertyKey);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_BlendShapeIndex_SWIG_1")]
            public static extern global::System.IntPtr NewBlendShapeIndex(global::System.Runtime.InteropServices.HandleRef blendShapeIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_BlendShapeIndex")]
            public static extern void DeleteBlendShapeIndex(global::System.Runtime.InteropServices.HandleRef blendShapeIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_Assign")]
            public static extern global::System.IntPtr BlendShapeIndexAssign(global::System.Runtime.InteropServices.HandleRef blendShapeIndex, global::System.Runtime.InteropServices.HandleRef sourceBlendShapeIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_DownCast")]
            public static extern global::System.IntPtr BlendShapeIndexDownCast(global::System.Runtime.InteropServices.HandleRef sourceBaseHandle);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_SetBlendShapeId")]
            public static extern void SetBlendShapeId(global::System.Runtime.InteropServices.HandleRef blendShapeIndex, global::System.Runtime.InteropServices.HandleRef modelNodeId);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_BlendShapeIndex_GetBlendShapeId")]
            public static extern global::System.IntPtr GetBlendShapeId(global::System.Runtime.InteropServices.HandleRef blendShapeIndex);
            #endregion

            #region MotionPropertyIndex
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_New_SWIG_0")]
            public static extern global::System.IntPtr MotionPropertyIndexNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_New_SWIG_1")]
            public static extern global::System.IntPtr MotionPropertyIndexNew(global::System.Runtime.InteropServices.HandleRef modelNodePropertKey, global::System.Runtime.InteropServices.HandleRef propertyKey);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_MotionPropertyIndex_SWIG_1")]
            public static extern global::System.IntPtr NewMotionPropertyIndex(global::System.Runtime.InteropServices.HandleRef motionPropertyIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_MotionPropertyIndex")]
            public static extern void DeleteMotionPropertyIndex(global::System.Runtime.InteropServices.HandleRef motionPropertyIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_Assign")]
            public static extern global::System.IntPtr MotionPropertyIndexAssign(global::System.Runtime.InteropServices.HandleRef motionPropertyIndex, global::System.Runtime.InteropServices.HandleRef sourceMotionPropertyIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_DownCast")]
            public static extern global::System.IntPtr MotionPropertyIndexDownCast(global::System.Runtime.InteropServices.HandleRef sourceBaseHandle);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_SetPropertyId")]
            public static extern void SetPropertyId(global::System.Runtime.InteropServices.HandleRef motionPropertyIndex, global::System.Runtime.InteropServices.HandleRef propertyKey);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionPropertyIndex_GetPropertyId")]
            public static extern global::System.IntPtr GetPropertyId(global::System.Runtime.InteropServices.HandleRef motionPropertyIndex);
            #endregion

            #region MotionTransformIndex
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_New_SWIG_0")]
            public static extern global::System.IntPtr MotionTransformIndexNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_New_SWIG_1")]
            public static extern global::System.IntPtr MotionTransformIndexNew(global::System.Runtime.InteropServices.HandleRef modelNodePropertKey, int transformType);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_MotionTransformIndex_SWIG_1")]
            public static extern global::System.IntPtr NewMotionTransformIndex(global::System.Runtime.InteropServices.HandleRef motionTransformIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_MotionTransformIndex")]
            public static extern void DeleteMotionTransformIndex(global::System.Runtime.InteropServices.HandleRef motionTransformIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_Assign")]
            public static extern global::System.IntPtr MotionTransformIndexAssign(global::System.Runtime.InteropServices.HandleRef motionTransformIndex, global::System.Runtime.InteropServices.HandleRef sourceMotionTransformIndex);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_DownCast")]
            public static extern global::System.IntPtr MotionTransformIndexDownCast(global::System.Runtime.InteropServices.HandleRef sourceBaseHandle);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_SetTransformType")]
            public static extern void SetTransformType(global::System.Runtime.InteropServices.HandleRef motionTransformIndex, int transformType);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionTransformIndex_GetTransformType")]
            public static extern int GetTransformType(global::System.Runtime.InteropServices.HandleRef motionTransformIndex);
            #endregion
        }
    }
}
