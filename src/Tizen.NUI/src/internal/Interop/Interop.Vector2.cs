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
        internal static partial class Vector2
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Vector2__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVector2();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Vector2__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVector2(float jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Vector2__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVector2([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] float[] jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Vector2__SWIG_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVector2WithVector3(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Vector2__SWIG_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVector2WithVector4(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Add(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_AddAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AddAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Subtract__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Subtract(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_SubtractAssign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr SubtractAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Multiply__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Multiply(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Multiply__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Multiply(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_MultiplyAssign__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_MultiplyAssign__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr MultiplyAssign(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Divide__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Divide(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Divide__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Divide(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_DivideAssign__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DivideAssign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_DivideAssign__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DivideAssign(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Subtract__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Subtract(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool NotEqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float ValueOfIndex(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Length", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float Length(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_LengthSquared", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float LengthSquared(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Normalize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Normalize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Clamp", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clamp(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_X_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void XSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_X_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float XGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Width_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WidthSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Width_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float WidthGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Y_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void YSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Y_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float YGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Height_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HeightSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_Height_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float HeightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Vector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVector2(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Vector2_set_all", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAll(IntPtr jarg1, float jarg2, float jarg3);
        }
    }
}





