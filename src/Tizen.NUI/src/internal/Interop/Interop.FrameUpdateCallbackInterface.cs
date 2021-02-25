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
        internal static partial class FrameUpdateCallbackInterface
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FrameCallbackInterface")]
            public static extern global::System.IntPtr newFrameUpdateCallbackInterface();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_director_connect")]
            public static extern void FrameUpdateCallbackInterfaceDirectorConnect(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.FrameUpdateCallbackInterface.DelegateFrameUpdateCallbackInterface delegate0);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPosition")]
            public static extern bool FraemCallbackInterfaceGetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetPosition")]
            public static extern bool FraemCallbackInterfaceSetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePosition")]
            public static extern bool FraemCallbackInterfaceBakePosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionAndSize")]
            public static extern bool FraemCallbackInterfaceGetPositionAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSize")]
            public static extern bool FraemCallbackInterfaceGetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetSize")]
            public static extern bool FraemCallbackInterfaceSetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSize")]
            public static extern bool FraemCallbackInterfaceBakeSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScale")]
            public static extern bool FraemCallbackInterfaceGetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetScale")]
            public static extern bool FraemCallbackInterfaceSetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScale")]
            public static extern bool FraemCallbackInterfaceBakeScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColor")]
            public static extern bool FraemCallbackInterfaceGetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetColor")]
            public static extern bool FraemCallbackInterfaceSetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColor")]
            public static extern bool FraemCallbackInterfaceBakeColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_AddFrameCallback")]
            public static extern void FraemCallbackInterfaceAddFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_RemoveFrameCallback")]
            public static extern void FraemCallbackInterfaceRemoveFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
        }
    }
}
