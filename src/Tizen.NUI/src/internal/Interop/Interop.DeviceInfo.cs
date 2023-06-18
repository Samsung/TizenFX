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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class DeviceInfo
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_DeviceInfoEvent__SWIG_0")]
            public static extern global::System.IntPtr NewDeviceInfo(int type, string name, string identifier, string seatName);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DeviceInfoEvent")]
            public static extern void DeleteDeviceInfo(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_type_get")]
            public static extern int TypeGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_name_get")]
            public static extern string NameGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_identifier_get")]
            public static extern string IdentifierGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_seatname_get")]
            public static extern string SeatNameGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_GetDeviceClass")]
            public static extern int DeviceClassGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceInfoEvent_GetDeviceSubClass")]
            public static extern int DeviceSubClassGet(global::System.Runtime.InteropServices.HandleRef deviceInfo);
        }
    }
}
