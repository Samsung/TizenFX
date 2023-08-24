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

namespace Tizen.NUI
{
    using global::System;
    using global::System.Runtime.InteropServices;

    internal static partial class Interop
    {
        internal static partial class EncodedImageBuffer
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EncodedImageBuffer_New")]
            public static extern IntPtr New(global::System.Runtime.InteropServices.HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_EncodedImageBuffer__SWIG_0")]
            public static extern IntPtr NewEncodedImageBuffer();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_EncodedImageBuffer__SWIG_1")]
            public static extern IntPtr NewEncodedImageBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_EncodedImageBuffer")]
            public static extern void DeleteEncodedImageBuffer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EncodedImageBuffer_GetRawBuffer")]
            public static extern IntPtr GetRawBuffer(IntPtr handle);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_EncodedImageBuffer_GenerateUrl")]
            public static extern IntPtr GenerateUrl(IntPtr handle);
        }
    }
}