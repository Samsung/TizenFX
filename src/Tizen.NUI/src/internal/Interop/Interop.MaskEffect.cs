/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
        internal static partial class MaskEffect
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr control);
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(IntPtr control, MaskEffectMode maskMode, float positionX, float positionY, float scaleX, float scaleY);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_SetTargetMaskOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTargetMaskOnce(IntPtr effect, [MarshalAs(UnmanagedType.U1)] bool targetMaskOnce);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_GetTargetMaskOnce", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetTargetMaskOnce(IntPtr effect);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_SetSourceMaskOnce", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetSourceMaskOnce(IntPtr effect, [MarshalAs(UnmanagedType.U1)] bool sourceMaskOnce);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MaskEffect_GetSourceMaskOnce", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetSourceMaskOnce(IntPtr effect);
        }
    }
}





