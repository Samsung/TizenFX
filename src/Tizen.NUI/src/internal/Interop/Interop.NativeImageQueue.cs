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
    internal static partial class Interop
    {
        internal static partial class NativeImageQueue
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_New")]
            public static extern IntPtr New(IntPtr queue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_Delete")]
            public static extern void Delete(IntPtr queue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_New_Handle")]
            public static extern IntPtr NewHandle(uint width, uint height, int colorDepth);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_CanDequeueBuffer")]
            public static extern bool CanDequeueBuffer(IntPtr queue);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_DequeueBuffer")]
            public static extern IntPtr DequeueBuffer(IntPtr queue, ref int width, ref int height, ref int colorDepth);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_NativeImageQueue_EnqueueBuffer")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool EnqueueBuffer(IntPtr queue, IntPtr buffer);
        }
    }
}
