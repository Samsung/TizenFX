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
        internal static partial class PaddingType
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PaddingType__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPaddingType();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PaddingType__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPaddingType(float jarg1, float jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_Set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Set(IntPtr jarg1, float jarg2, float jarg3, float jarg4, float jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_left_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LeftSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_left_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float LeftGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_start_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StartSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_start_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float StartGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_right_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RightSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_right_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float RightGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_end_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EndSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_end_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float EndGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_bottom_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BottomSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_bottom_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float BottomGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_top_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TopSet(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PaddingType_top_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float TopGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PaddingType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePaddingType(IntPtr jarg1);
        }
    }
}





