/*
 * Copyright(c) 2021 Samsung Electronics Co., Ltd.
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
        internal static partial class ModelView
        {
            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_New_SWIG_1")]
            public static extern global::System.IntPtr ModelViewNew(string jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_ModelView_SWIG_0")]
            public static extern global::System.IntPtr NewModelView();

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_new_ModelView_SWIG_1")]
            public static extern global::System.IntPtr NewModelView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_delete_ModelView")]
            public static extern void DeleteModelView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_Assign")]
            public static extern global::System.IntPtr ModelViewAssign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_DownCast")]
            public static extern global::System.IntPtr ModelViewDownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_GetModelRoot")]
            public static extern global::System.IntPtr GetModelRoot(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_FitSize")]
            public static extern global::System.IntPtr FitSize(global::System.Runtime.InteropServices.HandleRef jarg1, bool fit);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_FitCenter")]
            public static extern global::System.IntPtr FitCenter(global::System.Runtime.InteropServices.HandleRef jarg1, bool fit);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_SetImageBasedLightSource")]
            public static extern global::System.IntPtr SetImageBasedLightSource(global::System.Runtime.InteropServices.HandleRef jarg1, string diffuse, string specular, float scaleFactor);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_GetAnimationCount")]
            public static extern uint GetAnimationCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_GetAnimation_1")]
            public static extern global::System.IntPtr GetAnimation(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(Libraries.Scene3D, EntryPoint = "CSharp_Dali_ModelView_GetAnimation_2")]
            public static extern global::System.IntPtr GetAnimation(global::System.Runtime.InteropServices.HandleRef jarg1, string name);
        }
    }
}
