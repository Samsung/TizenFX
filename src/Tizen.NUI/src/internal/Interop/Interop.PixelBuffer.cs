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
        internal static partial class PixelBuffer
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1, uint jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PixelBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePixelBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PixelBuffer__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPixelBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Convert", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Convert(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_CreatePixelData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr CreatePixelData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBuffer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetWidth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetWidth(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetHeight", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetHeight(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetPixelFormat", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPixelFormat(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetStrideBytes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetStrideBytes(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyMask(IntPtr jarg1, IntPtr jarg2, float jarg3, [MarshalAs(UnmanagedType.U1)] bool jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyMask(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyMask__SWIG_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyMask(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_ApplyGaussianBlur", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ApplyGaussianBlur(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Crop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Crop(IntPtr jarg1, ushort jarg2, ushort jarg3, ushort jarg4, ushort jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Resize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resize(IntPtr jarg1, ushort jarg2, ushort jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_Rotate", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Rotate(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PixelBuffer_GetBrightness", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetBrightness(IntPtr jarg1);
        }
    }
}





