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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Rotation
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotation();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotation(IntPtr radianAngle, IntPtr vector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotation2(IntPtr v0, IntPtr v1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotation3(IntPtr pitch, IntPtr yaw, IntPtr roll);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Rotation_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewRotation4(IntPtr vector4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotationAssign(IntPtr destination, IntPtr source);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Rotation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteRotation(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_IDENTITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr IdentityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_IsIdentity", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsIdentity(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_GetAxisAngle", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetAxisAngle(IntPtr rotation, IntPtr axis, IntPtr radianAngle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SetEulerAngle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetEulerAngle(IntPtr rotation, IntPtr pitch, IntPtr yaw, IntPtr roll);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_GetEulerAngle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetEulerAngle(IntPtr rotation, IntPtr pitch, IntPtr yaw, IntPtr roll);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Add(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Subtract_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Subtract(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyQuaternion(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyVector3(IntPtr rotation, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Divide_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Divide(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Multiply_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Multiply(IntPtr rotation, float scale);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Divide_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Divide(IntPtr rotation, float scale);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Subtract_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Subtract(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_AddAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AddAssign(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SubtractAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SubtractAssign(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_MultiplyAssign_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyAssign(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_MultiplyAssign_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyAssign(IntPtr rotation, float scale);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_DivideAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DivideAssign(IntPtr rotation, float scale);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualTo(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool NotEqualTo(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Length", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Length(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_LengthSquared", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float LengthSquared(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Normalize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Normalize(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Normalized", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Normalized(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Conjugate", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Conjugate(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Invert", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Invert(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Log", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Log(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Exp", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Exp(IntPtr rotation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Dot", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Dot(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Lerp", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Lerp(IntPtr rotation0, IntPtr rotation1, float progress);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Slerp", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Slerp(IntPtr rotation0, IntPtr rotation1, float progress);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_SlerpNoInvert", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SlerpNoInvert(IntPtr rotation0, IntPtr rotation1, float progress);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Squad", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Squad(IntPtr start, IntPtr end, IntPtr control0, IntPtr control1, float progress);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_AngleBetween", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float AngleBetween(IntPtr rotation0, IntPtr rotation1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Rotate_Vector3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotateVector3(IntPtr rotation, IntPtr vector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Rotation_Rotate_Vector4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr RotateVector4(IntPtr rotation, IntPtr vector4);
        }
    }
}





