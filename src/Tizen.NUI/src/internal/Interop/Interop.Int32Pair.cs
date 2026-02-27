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
         internal static partial class Int32Pair
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Int32Pair__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInt32Pair();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Int32Pair__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewInt32Pair(int x, int y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_SetX", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetX(IntPtr handle, int x);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_GetX", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetX(IntPtr handle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_SetY", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetY(IntPtr handle, int y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Int32Pair_GetY", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetY(IntPtr handle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Int32Pair", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteInt32Pair(IntPtr handle);
       }
    }
}





