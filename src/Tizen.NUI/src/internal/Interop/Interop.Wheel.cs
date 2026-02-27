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
        internal static partial class Wheel
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(int jarg1, int jarg2, uint jarg3, IntPtr jarg4, int jarg5, uint jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Wheel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWheel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsShiftModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsShiftModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsCtrlModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsCtrlModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_IsAltModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAltModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_type_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TypeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_direction_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DirectionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_modifiers_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint ModifiersGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_point_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr PointGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_delta_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DeltaGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Wheel_timeStamp_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TimeStampGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool StageWheelSignalEmpty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint StageWheelSignalGetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StageWheelSignalConnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StageWheelSignalDisconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_StageWheelSignal_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StageWheelSignalEmit(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_StageWheelSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewStageWheelSignal();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_StageWheelSignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteStageWheelSignal(IntPtr jarg1);
        }
    }
}





