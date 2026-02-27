/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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
        internal static partial class WindowAccessibilityHighlightSignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetSignal(IntPtr window);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Empty(IntPtr signalType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetConnectionCount(IntPtr signalType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Connect(IntPtr signalType, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Disconnect(IntPtr signalType, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Window_Accessibility_Highlight_Signal_delete", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteSignal(IntPtr signalType);
        }
    }
}





