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
        internal static partial class PixelData
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New([global::System.Runtime.InteropServices.In, global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.LPArray)] byte[] jarg1, uint jarg2, uint jarg3, uint jarg4, int jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PixelData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePixelData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GetWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetWidth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GetHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetHeight(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GetPixelFormat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPixelFormat(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GetStrideBytes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetStrideBytes(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GenerateUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GenerateUrl(global::System.IntPtr handle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelData_GenerateUrl_With_PreMultiplied", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GenerateUrl(global::System.IntPtr handle, [MarshalAs(UnmanagedType.U1)] bool preMultiplied);
        }
    }
}





