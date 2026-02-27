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
        internal static partial class BaseHandle
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_BaseHandle__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewBaseHandle();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_BaseHandle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteBaseHandle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_BaseHandle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteBaseHandle(global::System.IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_BaseHandle__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewBaseHandle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_DoAction", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DoAction(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_GetTypeName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetTypeName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_GetTypeInfo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetTypeInfo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_GetBaseObject__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBaseObject(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_EqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool EqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_NotEqualTo", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool NotEqualTo(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_GetObjectPtr", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetObjectPtr(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_HasBody", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool HasBody(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_BaseHandle_IsEqual", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsEqual(IntPtr jarg1, IntPtr jarg2);
        }
    }
}





