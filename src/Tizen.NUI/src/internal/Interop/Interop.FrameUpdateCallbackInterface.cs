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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_director_connect_with_return")]
            public static extern void FrameUpdateCallbackInterfaceDirectorConnectV1(global::System.Runtime.InteropServices.HandleRef jarg1, Tizen.NUI.FrameUpdateCallbackInterface.DelegateFrameUpdateCallbackInterfaceV1 delegate1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPosition")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetPosition")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetPosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePosition")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakePosition(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionAndSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetPositionAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScale")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetScale")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScale")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeScale(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColor")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetColor")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColor")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeColor(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_AddFrameCallback")]
            public static extern void FrameCallbackInterfaceAddFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_RemoveFrameCallback")]
            public static extern void FrameCallbackInterfaceRemoveFrameUpdateCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetUpdateArea")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetUpdateArea(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetUpdateArea")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetUpdateArea(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector);
        }
    }
}
