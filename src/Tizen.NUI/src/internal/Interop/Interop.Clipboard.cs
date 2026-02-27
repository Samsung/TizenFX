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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class Clipboard
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_SetData", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetData(IntPtr clipboard, string mimeType, string data);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_GetData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetData(IntPtr clipboard, string mimeType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_DataReceivedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ClipboardDataReceivedSignal(IntPtr clipboard);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Clipboard_DataSelectedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ClipboardDataSelectedSignal(IntPtr clipboard);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ClipboardSignalEmpty(IntPtr signal);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint ClipboardSignalGetConnectionCount(IntPtr signal);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClipboardSignalConnect(IntPtr signal, IntPtr clipboard);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClipboardSignalDisconnect(IntPtr signal, IntPtr clipboard);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_ClipboardSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClipboardSignalEmit(IntPtr signal, IntPtr clipboard);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_ClipboardSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewClipboardSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_ClipboardSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteClipboardSignal(IntPtr signal);
        }
    }
}





