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
        internal static partial class FrameUpdateCallbackInterface
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_FrameCallbackInterface", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr newFrameUpdateCallbackInterface();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_FrameCallbackInterface", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFrameUpdateCallbackInterface(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_director_connect_with_return", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FrameUpdateCallbackInterfaceDirectorConnectV1(IntPtr jarg1, Tizen.NUI.FrameUpdateCallbackInterface.DelegateFrameUpdateCallbackInterfaceV1 delegate1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPosition", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetPosition(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetPosition", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetPosition(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePosition", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakePosition(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetOrientation", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetOrientation(global::System.IntPtr proxy, uint id, IntPtr orientation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetOrientation", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetOrientation(global::System.IntPtr proxy, uint id, IntPtr orientation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeOrientation", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeOrientation(global::System.IntPtr proxy, uint id, IntPtr orientation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionAndSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetPositionAndSize(global::System.IntPtr proxy, uint id, IntPtr vector, IntPtr vector2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetWorldPositionScaleAndSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetWorldPositionScaleAndSize(global::System.IntPtr proxy, uint id, IntPtr vector, IntPtr vector2, IntPtr vector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetWorldTransformAndSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetWorldTransformAndSize(global::System.IntPtr proxy, uint id, IntPtr vector, IntPtr vector2, IntPtr rotation, IntPtr vector3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetSize(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetSize(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSize", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeSize(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScale", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetScale(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetScale", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetScale(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScale", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeScale(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColor", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetColor(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetColor", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetColor(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColor", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeColor(global::System.IntPtr proxy, uint id, IntPtr vector);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_SetIgnored", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceSetIgnored(global::System.IntPtr proxy, uint id, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)] bool ignored);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetIgnored", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetIgnored(global::System.IntPtr proxy, uint id, [global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)] out bool ignored);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetCustomProperty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetCustomProperty(global::System.IntPtr proxy, uint id, string propertyName, IntPtr propertyValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeCustomProperty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeCustomProperty(global::System.IntPtr proxy, uint id, string propertyName, IntPtr propertyValue);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_AddFrameCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FrameCallbackInterfaceAddFrameUpdateCallback(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_RemoveFrameCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FrameCallbackInterfaceRemoveFrameUpdateCallback(IntPtr jarg1, IntPtr jarg2);

            // UIVector2 and UIColor

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetPositionVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetPositionVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakePositionVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakePositionVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetSizeVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetSizeVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeSizeVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeSizeVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetScaleVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetScaleVector2Componentwise(global::System.IntPtr proxy, uint id, ref float x, ref float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeScaleVector2Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeScaleVector2Componentwise(global::System.IntPtr proxy, uint id, float x, float y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_GetColorVector4Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceGetColorVector4Componentwise(global::System.IntPtr proxy, uint id, ref float r, ref float g, ref float b, ref float a);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_FrameCallbackInterface_BakeColorVector4Componentwise", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FrameCallbackInterfaceBakeColorVector4Componentwise(global::System.IntPtr proxy, uint id, float r, float g, float b, float a);
        }
    }
}





