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
        internal static partial class PropertyInputContainer
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetCount")]
            public static extern uint GetCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetType")]
            public static extern int GetPropertyType(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetBoolean")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetBoolean(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetFloat")]
            public static extern float GetFloat(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetInteger")]
            public static extern int GetInteger(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector2_Componentwise")]
            public static extern void GetVector2Componentwise(global::System.Runtime.InteropServices.HandleRef jarg1, uint index, out float x, out float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector3_Componentwise")]
            public static extern void GetVector3Componentwise(global::System.Runtime.InteropServices.HandleRef jarg1, uint index, out float x, out float y, out float z);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetVector4_Componentwise")]
            public static extern void GetVector4Componentwise(global::System.Runtime.InteropServices.HandleRef jarg1, uint index, out float x, out float y, out float z, out float w);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetMatrix3")]
            public static extern global::System.IntPtr GetMatrix3(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetMatrix")]
            public static extern global::System.IntPtr GetMatrix(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyInputContainer_GetQuaternion")]
            public static extern global::System.IntPtr GetRotation(global::System.Runtime.InteropServices.HandleRef jarg1, uint index);
        }
    }
}
