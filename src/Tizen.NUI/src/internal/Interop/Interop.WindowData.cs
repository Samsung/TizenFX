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
        internal static partial class WindowData
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WindowData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WindowData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWindowData(IntPtr nuiWindowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetPositionSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPositionSize(IntPtr nuiWindowData, IntPtr nuiPositionSize);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetPositionSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPositionSize(IntPtr nuiWindowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetWindowType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetWindowType(IntPtr nuiWindowData, int nuiWindowType);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetWindowType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetWindowType(IntPtr nuiWindowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetTransparency", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTransparency(IntPtr nuiWindowData, [MarshalAs(UnmanagedType.U1)] bool nuiTransparency);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetTransparency", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetTransparency(IntPtr nuiWindowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetFrontBufferRendering", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFrontBufferRendering(IntPtr nuiWindowData, [MarshalAs(UnmanagedType.U1)] bool enable);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetFrontBufferRendering", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetFrontBufferRendering(IntPtr nuiWindowData);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_SetScreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScreen(IntPtr nuiWindowData, string screenName);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WindowData_GetScreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetScreen(IntPtr nuiWindowData);

        }
    }
}



