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
    internal static partial class Interop
    {
        internal static partial class AsyncImageLoader
        {

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AsyncImageLoader")]
            public static extern void DeleteAsyncImageLoader(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_0")]
            public static extern uint Load(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_1")]
            public static extern uint Load(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Load__SWIG_2")]
            public static extern uint Load(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3, int jarg4, int jarg5, bool jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_Cancel")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool Cancel(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_CancelAll")]
            public static extern void CancelAll(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal_Connect")]
            public static extern void ImageLoadedSignalConnect(global::System.Runtime.InteropServices.HandleRef asyncImageLoader, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_ImageLoadedSignal_Disconnect")]
            public static extern void ImageLoadedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef asyncImageLoader, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_PixelBufferLoadedSignal_Connect")]
            public static extern void PixelBufferLoadedSignalConnect(global::System.Runtime.InteropServices.HandleRef asyncImageLoader, global::System.Runtime.InteropServices.HandleRef handler);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AsyncImageLoader_PixelBufferLoadedSignal_Disconnect")]
            public static extern void PixelBufferLoadedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef asyncImageLoader, global::System.Runtime.InteropServices.HandleRef handler);
        }
    }
}
