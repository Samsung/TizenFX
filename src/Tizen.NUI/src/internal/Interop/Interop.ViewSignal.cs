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
        internal static partial class ViewSignal
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyEventSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyEventConnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyEventSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyEventDisconnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyInputFocusGainedConnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusGainedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyInputFocusGainedDisconnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyInputFocusLostConnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_KeyInputFocusLostSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyInputFocusLostDisconnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ResourceReadySignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResourceReadyConnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_ResourceReadySignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResourceReadyDisconnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_OffScreenRenderingFinishedSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OffScreenRenderingFinishedConnect(IntPtr view, IntPtr handler);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_View_OffScreenRenderingFinishedSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void OffScreenRenderingFinishedDisconnect(IntPtr view, IntPtr handler);
        }
    }
}



