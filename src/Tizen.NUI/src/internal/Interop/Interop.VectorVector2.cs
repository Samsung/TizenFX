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
        internal static partial class VectorVector2
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_BaseType_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int BaseTypeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorVector2__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVectorVector2();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VectorVector2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVectorVector2(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorVector2__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVectorVector2(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr daliVectorDest, IntPtr daliVectorSrc);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Begin", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Begin(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_End", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr End(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_ValueOfIndex__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ValueOfIndex(IntPtr daliVector, uint index);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_PushBack", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void PushBack(IntPtr daliVector, IntPtr item);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Insert__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr daliVector, IntPtr iterator, IntPtr item);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Insert__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr daliVector, IntPtr iterator, IntPtr first, IntPtr last);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Reserve", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reserve(IntPtr daliVector, uint size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Resize__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr daliVector, uint size);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Resize__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr daliVector, uint size, IntPtr item);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Erase__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Erase(IntPtr daliVector, IntPtr iterator);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Erase__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Erase(IntPtr daliVector, IntPtr first, IntPtr last);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Remove", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Remove(IntPtr daliVector, IntPtr item);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Swap", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Swap(IntPtr daliVector1, IntPtr daliVector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Clear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clear(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Release", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Release(IntPtr daliVector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorVector2_Size", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int Size(IntPtr daliVector);

        }
    }
}





