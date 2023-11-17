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
        internal static partial class Rotation
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_0")]
            public static extern global::System.IntPtr NewRotation();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_1")]
            public static extern global::System.IntPtr NewRotation(global::System.Runtime.InteropServices.HandleRef radianAngle, global::System.Runtime.InteropServices.HandleRef vector3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_2")]
            public static extern global::System.IntPtr NewRotation2(global::System.Runtime.InteropServices.HandleRef v0, global::System.Runtime.InteropServices.HandleRef v1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_3")]
            public static extern global::System.IntPtr NewRotation3(global::System.Runtime.InteropServices.HandleRef pitch, global::System.Runtime.InteropServices.HandleRef yaw, global::System.Runtime.InteropServices.HandleRef roll);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_4")]
            public static extern global::System.IntPtr NewRotation4(global::System.Runtime.InteropServices.HandleRef vector4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Rotation")]
            public static extern void DeleteRotation(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_IDENTITY_get")]
            public static extern global::System.IntPtr IdentityGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_IsIdentity")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsIdentity(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_GetAxisAngle")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool GetAxisAngle(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef axis, global::System.Runtime.InteropServices.HandleRef radianAngle);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SetEulerAngle")]
            public static extern void SetEulerAngle(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef pitch, global::System.Runtime.InteropServices.HandleRef yaw, global::System.Runtime.InteropServices.HandleRef roll);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_GetEulerAngle")]
            public static extern void GetEulerAngle(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef pitch, global::System.Runtime.InteropServices.HandleRef yaw, global::System.Runtime.InteropServices.HandleRef roll);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Add")]
            public static extern global::System.IntPtr Add(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Subtract_0")]
            public static extern global::System.IntPtr Subtract(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_0")]
            public static extern global::System.IntPtr MultiplyQuaternion(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_1")]
            public static extern global::System.IntPtr MultiplyVector3(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Divide_0")]
            public static extern global::System.IntPtr Divide(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_2")]
            public static extern global::System.IntPtr Multiply(global::System.Runtime.InteropServices.HandleRef rotation, float scale);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Divide_1")]
            public static extern global::System.IntPtr Divide(global::System.Runtime.InteropServices.HandleRef rotation, float scale);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Subtract_1")]
            public static extern global::System.IntPtr Subtract(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_AddAssign")]
            public static extern global::System.IntPtr AddAssign(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SubtractAssign")]
            public static extern global::System.IntPtr SubtractAssign(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_MultiplyAssign_0")]
            public static extern global::System.IntPtr MultiplyAssign(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_MultiplyAssign_1")]
            public static extern global::System.IntPtr MultiplyAssign(global::System.Runtime.InteropServices.HandleRef rotation, float scale);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_DivideAssign")]
            public static extern global::System.IntPtr DivideAssign(global::System.Runtime.InteropServices.HandleRef rotation, float scale);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_EqualTo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool EqualTo(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_NotEqualTo")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool NotEqualTo(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Length")]
            public static extern float Length(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_LengthSquared")]
            public static extern float LengthSquared(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Normalize")]
            public static extern void Normalize(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Normalized")]
            public static extern global::System.IntPtr Normalized(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Conjugate")]
            public static extern void Conjugate(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Invert")]
            public static extern void Invert(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Log")]
            public static extern global::System.IntPtr Log(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Exp")]
            public static extern global::System.IntPtr Exp(global::System.Runtime.InteropServices.HandleRef rotation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Dot")]
            public static extern float Dot(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Lerp")]
            public static extern global::System.IntPtr Lerp(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1, float progress);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Slerp")]
            public static extern global::System.IntPtr Slerp(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1, float progress);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SlerpNoInvert")]
            public static extern global::System.IntPtr SlerpNoInvert(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1, float progress);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Squad")]
            public static extern global::System.IntPtr Squad(global::System.Runtime.InteropServices.HandleRef start, global::System.Runtime.InteropServices.HandleRef end, global::System.Runtime.InteropServices.HandleRef control0, global::System.Runtime.InteropServices.HandleRef control1, float progress);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_AngleBetween")]
            public static extern float AngleBetween(global::System.Runtime.InteropServices.HandleRef rotation0, global::System.Runtime.InteropServices.HandleRef rotation1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Rotate_Vector3")]
            public static extern global::System.IntPtr RotateVector3(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef vector3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Rotate_Vector4")]
            public static extern global::System.IntPtr RotateVector4(global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef vector4);
        }
    }
}
