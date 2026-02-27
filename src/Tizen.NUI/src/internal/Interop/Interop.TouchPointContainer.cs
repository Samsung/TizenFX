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
        internal static partial class TouchPointContainer
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Clear", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Clear(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Add", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Add(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_size", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint size(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_capacity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint capacity(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_reserve", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void reserve(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TouchPointContainer__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouchPointContainer();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TouchPointContainer__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouchPointContainer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TouchPointContainer__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouchPointContainer(int jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_getitemcopy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr getitemcopy(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_getitem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr getitem(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_setitem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void setitem(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_AddRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddRange(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_GetRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRange(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Insert", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Insert(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_InsertRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void InsertRange(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_RemoveAt", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveAt(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_RemoveRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveRange(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Repeat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Repeat(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Reverse__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reverse(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_Reverse__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reverse(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPointContainer_SetRange", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRange(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TouchPointContainer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTouchPointContainer(IntPtr jarg1);
        }
    }
}





