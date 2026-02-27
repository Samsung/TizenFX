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
        internal static partial class VectorBlob
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_r_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RSet(IntPtr jarg1, byte jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_r_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial byte RGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_g_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GSet(IntPtr jarg1, byte jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_g_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial byte GGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_b_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void BSet(IntPtr jarg1, byte jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_b_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial byte BGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_a_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ASet(IntPtr jarg1, byte jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_VectorBlob_a_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial byte AGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_VectorBlob", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewVectorBlob();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_VectorBlob", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteVectorBlob(IntPtr jarg1);
        }
    }
}





