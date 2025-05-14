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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class AlphaFunction
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_0")]
            public static extern global::System.IntPtr NewAlphaFunction();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_BuiltInFunction")]
            public static extern global::System.IntPtr NewAlphaFunction(int builtInFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_CustomAlphaFunction")]
            public static extern global::System.IntPtr NewAlphaFunction(global::System.Runtime.InteropServices.HandleRef alphaFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_Bezier")]
            public static extern global::System.IntPtr NewAlphaFunction(global::System.Runtime.InteropServices.HandleRef controlPoint0, global::System.Runtime.InteropServices.HandleRef controlPoint1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_BuiltInSpring")]
            public static extern global::System.IntPtr NewAlphaFunctionSpringType(int springType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_AlphaFunction_CustomSpring")]
            public static extern global::System.IntPtr NewAlphaFunctionSpringData(float stiffness, float damping, float mass);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBezierControlPoints")]
            public static extern global::System.IntPtr GetBezierControlPoints(global::System.Runtime.InteropServices.HandleRef alphaFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetBuiltinFunction")]
            public static extern int GetBuiltinFunction(global::System.Runtime.InteropServices.HandleRef alphaFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AlphaFunction_GetMode")]
            public static extern int GetMode(global::System.Runtime.InteropServices.HandleRef alphaFunction);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AlphaFunction")]
            public static extern void DeleteAlphaFunction(global::System.Runtime.InteropServices.HandleRef jarg1);
        }
    }
}
