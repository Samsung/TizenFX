/*
 * Copyright(c) 2023 Samsung Electronics Co., Ltd.
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
        internal static partial class Clipboard
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_Get")]
            public static extern global::System.IntPtr Get();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_SetData")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool SetData(global::System.Runtime.InteropServices.HandleRef clipboard, string mimeType, string data);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_GetData")]
            public static extern uint GetData(global::System.Runtime.InteropServices.HandleRef clipboard, string mimeType);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_DataSentSignal")]
            public static extern global::System.IntPtr ClipboardDataSentSignal(global::System.Runtime.InteropServices.HandleRef clipboard);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_DataReceivedSignal")]
            public static extern global::System.IntPtr ClipboardDataReceivedSignal(global::System.Runtime.InteropServices.HandleRef clipboard);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Empty")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool ClipboardSignalEmpty(global::System.Runtime.InteropServices.HandleRef signal);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_GetConnectionCount")]
            public static extern uint ClipboardSignalGetConnectionCount(global::System.Runtime.InteropServices.HandleRef signal);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Connect")]
            public static extern void ClipboardSignalConnect(global::System.Runtime.InteropServices.HandleRef signal, global::System.Runtime.InteropServices.HandleRef clipboard);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Disconnect")]
            public static extern void ClipboardSignalDisconnect(global::System.Runtime.InteropServices.HandleRef signal, global::System.Runtime.InteropServices.HandleRef clipboard);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Emit")]
            public static extern void ClipboardSignalEmit(global::System.Runtime.InteropServices.HandleRef signal, global::System.Runtime.InteropServices.HandleRef clipboard);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ClipboardSignal")]
            public static extern global::System.IntPtr NewClipboardSignal();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ClipboardSignal")]
            public static extern void DeleteClipboardSignal(global::System.Runtime.InteropServices.HandleRef signal);
        }
    }
}
