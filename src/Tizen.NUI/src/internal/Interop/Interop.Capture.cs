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
        internal static partial class Capture
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Upcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Capture")]
            public static extern IntPtr NewEmpty();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_New")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_DownCast")]
            public static extern IntPtr Downcast(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Capture")]
            public static extern void Delete(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Assign")]
            public static extern IntPtr Assign(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_1")]
            public static extern void Start1(HandleRef capture, HandleRef source, HandleRef size, string path, HandleRef clearColor);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_2")]
            public static extern void Start2(HandleRef capture, HandleRef source, HandleRef size, string path);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_3")]
            public static extern void Start3(HandleRef capture, HandleRef source, HandleRef size, string path, HandleRef clearColor, uint quality);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_4")]
            public static extern void Start4(HandleRef capture, HandleRef source, HandleRef position, HandleRef size, string path, HandleRef clearColor);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_SetImageQuality")]
            public static extern void SetImageQuality(HandleRef capture, uint quality);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Empty")]
            public static extern bool SignalEmpty(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_GetConnectionCount")]
            public static extern uint SignalGetConnectionCount(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Connect")]
            public static extern void SignalConnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Disconnect")]
            public static extern void SignalDisconnect(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Emit")]
            public static extern void SignalEmit(HandleRef jarg1, HandleRef jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Capture_Signal")]
            public static extern IntPtr NewSignal();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Capture_Signal")]
            public static extern void DeleteSignal(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Get")]
            public static extern IntPtr Get(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GetNativeImageSource")]
            public static extern IntPtr GetNativeImageSourcePtr(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GenerateUrl")]
            public static extern string GenerateUrl(HandleRef capture);

        }
    }
}
