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
        internal static partial class Capture
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Capture", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Delete(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Start1(IntPtr capture, IntPtr source, IntPtr size, string path, IntPtr clearColor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Start2(IntPtr capture, IntPtr source, IntPtr size, string path);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Start3(IntPtr capture, IntPtr source, IntPtr size, string path, IntPtr clearColor, uint quality);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Start_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Start4(IntPtr capture, IntPtr source, IntPtr position, IntPtr size, string path, IntPtr clearColor);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_SetImageQuality", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetImageQuality(IntPtr capture, uint quality);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_SetExclusive", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetExclusive(IntPtr capture, [MarshalAs(UnmanagedType.U1)] bool exclusive);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_IsExclusive", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsExclusive(IntPtr capture);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint SignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SignalEmit(IntPtr jarg1, IntPtr jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_Signal_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Get(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GetImageUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetImageUrl(IntPtr capture);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GetNativeImageSource", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetNativeImageSourcePtr(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Capture_GetCapturedBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetCapturedBuffer(IntPtr capture);

        }
    }
}



