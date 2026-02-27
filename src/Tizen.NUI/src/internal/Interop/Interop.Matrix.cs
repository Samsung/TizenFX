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
        internal static partial class Matrix
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix([MarshalAs(UnmanagedType.U1)] bool jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrixQuaternion(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_IDENTITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr IdentityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetIdentity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetIdentity(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetIdentityAndScale", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetIdentityAndScale(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_InvertTransform", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InvertTransform(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Invert", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Invert(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Transpose", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Transpose(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetXAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetXAxis(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetYAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetYAxis(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetZAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetZAxis(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetXAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetXAxis(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetYAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetYAxis(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetZAxis", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetZAxis(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetTranslation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTranslation(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetTranslation3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTranslation3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetTranslation__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTranslationVector4(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetTranslation__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTranslationVector3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_OrthoNormalize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OrthoNormalize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Multiply__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Multiply(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Multiply__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void MultiplyQuaternion(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Multiply__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyVector4(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_Multiply__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Multiply(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_MultiplyAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool NotEqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetTransformComponents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTransformComponents(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetInverseTransformComponents__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInverseTransformComponents(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetInverseTransformComponents__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetInverseTransformComponents(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_GetTransformComponents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetTransformComponents(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float ValueOfIndex(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_ValueOfIndex__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float ValueOfIndex(IntPtr jarg1, uint indexRow, uint indexColumn);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetValueAtIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetValueAtIndex(IntPtr jarg1, uint index, float val);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix_SetValueAtIndex__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetValueAtIndex(IntPtr jarg1, uint indexRow, uint indexColumn, float val);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Matrix", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteMatrix(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_IDENTITY_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3IdentityGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix3__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix3();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix3__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix3__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix3Matrix(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Matrix3__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMatrix3(float jarg1, float jarg2, float jarg3, float jarg4, float jarg5, float jarg6, float jarg7, float jarg8, float jarg9);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Assign__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Assign__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3AssignMatrix(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Matrix3EqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Matrix3NotEqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Matrix3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteMatrix3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_SetIdentity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Matrix3SetIdentity(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Invert", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Matrix3Invert(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Transpose", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Matrix3Transpose(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Scale", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Matrix3Scale(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Magnitude", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Matrix3Magnitude(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_ScaledInverseTranspose", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Matrix3ScaledInverseTranspose(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Multiply", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Matrix3Multiply(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Multiply__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3MultiplyVector3(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_Multiply__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3Multiply(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_MultiplyAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Matrix3MultiplyAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Matrix3ValueOfIndex(IntPtr jarg1, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_ValueOfIndex__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Matrix3ValueOfIndex(IntPtr jarg1, uint indexRow, uint indexColumn);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_SetValueAtIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Matrix3SetValueAtIndex(IntPtr jarg1, uint index, float val);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Matrix3_SetValueAtIndex__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Matrix3SetValueAtIndex(IntPtr jarg1, uint indexRow, uint indexColumn, float val);
        }
    }
}





