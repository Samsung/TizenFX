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
        internal static partial class NativeImageSource
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New(IntPtr handle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_Delete", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Delete(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New_Handle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewHandle(uint jarg1, uint jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_AcquireBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr AcquireBuffer(IntPtr jarg1, ref int jarg2, ref int jarg3, ref int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_ReleaseBuffer", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ReleaseBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_GenerateUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GenerateUrl(IntPtr handle);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_GenerateUrl_With_PreMultiplied", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GenerateUrl(IntPtr handle, [MarshalAs(UnmanagedType.U1)] bool preMultiplied);

            // Platform dependency methods
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_New_Handle_With_TbmSurface", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewHandleWithTbmSurface(IntPtr csTbmSurface);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageSource_SetSource", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSource(IntPtr handle, IntPtr csTbmSurface);
        }
    }
}





