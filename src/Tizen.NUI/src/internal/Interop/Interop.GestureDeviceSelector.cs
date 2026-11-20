/*
 * Copyright(c) 2026 Samsung Electronics Co., Ltd.
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
        internal static partial class GestureDeviceSelector
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_GestureDeviceSelector")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_ByDeviceClass")]
            public static extern global::System.IntPtr ByDeviceClass(int deviceClass);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_ByDeviceClassAndSubclass")]
            public static extern global::System.IntPtr ByDeviceClassAndSubclass(int deviceClass, int deviceSubclass);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_ByDeviceName")]
            public static extern global::System.IntPtr ByDeviceName(string deviceName);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_GestureDeviceSelector")]
            public static extern void Delete(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_GetMatchType")]
            public static extern int GetMatchType(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_GetDeviceClass")]
            public static extern int GetDeviceClass(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_GetDeviceSubclass")]
            public static extern int GetDeviceSubclass(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_GetDeviceName")]
            public static extern string GetDeviceName(global::System.Runtime.InteropServices.HandleRef nuiSelector);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_GestureDeviceSelector_Equals")]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static extern bool IsEqual(global::System.Runtime.InteropServices.HandleRef nuiSelector, global::System.Runtime.InteropServices.HandleRef nuiOther);
        }
    }
}
