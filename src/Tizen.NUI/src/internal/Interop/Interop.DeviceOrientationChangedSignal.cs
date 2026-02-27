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
        internal static partial class DeviceOrientationChangedSignalType
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_DeviceOrientationChangedSignalType_Empty", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Empty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_DeviceOrientationChangedSignalType_GetConnectionCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetConnectionCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_DeviceOrientationChangedSignalType_Connect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Connect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_DeviceOrientationChangedSignalType_Disconnect", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Disconnect(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_DeviceOrientationChangedSignalType_Emit", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Emit(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_new_DeviceOrientationChangedSignalType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewDeviceOrientationChangedSignalType();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Application_delete_DeviceOrientationChangedSignalType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteDeviceOrientationChangedSignalType(IntPtr jarg1);
        }
    }
}





