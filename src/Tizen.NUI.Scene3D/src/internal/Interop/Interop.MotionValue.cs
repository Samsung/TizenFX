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
        internal static partial class MotionValue
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_New_SWIG_0")]
            public static extern global::System.IntPtr MotionValueNew();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_New_SWIG_1")]
            public static extern global::System.IntPtr MotionValueNewPropertyValue(global::System.Runtime.InteropServices.HandleRef propertyValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_New_SWIG_2")]
            public static extern global::System.IntPtr MotionValueNewKeyFrames(global::System.Runtime.InteropServices.HandleRef keyFrames);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_MotionValue_SWIG_1")]
            public static extern global::System.IntPtr NewMotionValue(global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_MotionValue")]
            public static extern void DeleteMotionValue(global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_Assign")]
            public static extern global::System.IntPtr MotionValueAssign(global::System.Runtime.InteropServices.HandleRef motionValue, global::System.Runtime.InteropServices.HandleRef sourceMotionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_GetValueType")]
            public static extern int GetValueType(global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_SetValue_PropertyValue")]
            public static extern void SetValuePropertyValue(global::System.Runtime.InteropServices.HandleRef motionValue, global::System.Runtime.InteropServices.HandleRef propertyValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_SetValue_KeyFrames")]
            public static extern void SetValueKeyFrames(global::System.Runtime.InteropServices.HandleRef motionValue, global::System.Runtime.InteropServices.HandleRef keyFrames);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_Clear")]
            public static extern void Clear(global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_GetPropertyValue")]
            public static extern global::System.IntPtr GetPropertyValue(global::System.Runtime.InteropServices.HandleRef motionValue);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_MotionValue_GetKeyFrames")]
            public static extern global::System.IntPtr GetKeyFrames(global::System.Runtime.InteropServices.HandleRef motionValue);
        }
    }
}
