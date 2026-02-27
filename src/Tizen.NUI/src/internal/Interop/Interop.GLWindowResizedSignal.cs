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
        internal static partial class GLWindowResizedSignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GlWindowResizedSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GlWindowResizedSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowResizedSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowResizedSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_ResizedSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowResizedSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GlWindow_ResizedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewGlWindowResizedSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GlWindow_delete_ResizedSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GlWindowDeleteResizedSignal(IntPtr jarg1);
        }
    }
}



