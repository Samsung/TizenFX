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
        internal static partial class VectorUnsignedChar
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_BaseType_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BaseTypeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorUnsignedChar__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVectorUnsignedChar();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VectorUnsignedChar", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVectorUnsignedChar(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorUnsignedChar__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVectorUnsignedChar(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Begin", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Begin(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_End", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr End(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ValueOfIndex(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_PushBack", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PushBack(IntPtr jarg1, byte jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Insert__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg2, byte jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Insert__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg2, IntPtr jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Reserve", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reserve(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Resize__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Resize__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr jarg1, uint jarg2, byte jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Erase__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Erase(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Erase__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Erase(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Remove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Remove(IntPtr jarg1, [global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Swap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Swap(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Clear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clear(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorUnsignedChar_Release", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Release(IntPtr jarg1);
        }
    }
}





