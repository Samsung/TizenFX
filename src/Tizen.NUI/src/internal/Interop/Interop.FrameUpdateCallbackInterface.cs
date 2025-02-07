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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FrameCallbackInterface")]
            public static extern void DeleteFrameUpdateCallbackInterface(global::System.Runtime.InteropServices.HandleRef jarg1);

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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetOrientation")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetOrientation(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef orientation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetOrientation")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceSetOrientation(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef orientation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeOrientation")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeOrientation(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef orientation);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionAndSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetPositionAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetWorldPositionScaleAndSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetWorldPositionScaleAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2, global::System.Runtime.InteropServices.HandleRef vector3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetWorldTransformAndSize")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetWorldTransformAndSize(global::System.IntPtr proxy, uint id, global::System.Runtime.InteropServices.HandleRef vector, global::System.Runtime.InteropServices.HandleRef vector2, global::System.Runtime.InteropServices.HandleRef rotation, global::System.Runtime.InteropServices.HandleRef vector3);

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

            // UIVector2 and UIColor

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetPositionVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePositionVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakePositionVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSizeVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetSizeVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSizeVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeSizeVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScaleVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetScaleVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScaleVector2Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeScaleVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColorVector4Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceGetColorVector4Componentwise(global::System.IntPtr proxy, uint id, ref float r, ref float g, ref float b, ref float a);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColorVector4Componentwise")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool FrameCallbackInterfaceBakeColorVector4Componentwise(global::System.IntPtr proxy, uint id, float r, float g, float b, float a);
        }
    }
}
