/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
using global::System.Runtime.InteropServices;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebDeviceList
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_DeviceListGet")]
            public static extern void Delete(HandleRef obj);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceListGet_GetTypeAndConnect")]
            public static extern void GetTypeAndConnect(HandleRef obj, out int type, out bool connect, int idx);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceListGet_GetDeviceId")]
            public static extern string GetDeviceId(HandleRef obj, int idx);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DeviceListGet_GetDeviceLabel")]
            public static extern string GetDeviceLabel(HandleRef obj, int idx);
        }
    }
}
