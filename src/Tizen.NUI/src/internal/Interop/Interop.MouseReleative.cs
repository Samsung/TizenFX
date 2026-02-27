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

using global::System;
using global::System.Runtime.InteropServices;
using global::System.Runtime.InteropServices.Marshalling;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class MouseRelative
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_MouseRelativeEvent__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewMouseRelative(int jarg1, uint jarg2, uint jarg3, IntPtr jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_MouseRelativeEvent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteMouseRelative(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_type_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TypeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_modifiers_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint ModifiersGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_diff_position_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr DiffPositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_unaccelated_position_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr UnaccelatedPositionGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_timeStamp_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TimeStampGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_GetDeviceClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DeviceClassGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_MouseRelativeEvent_GetDeviceSubClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DeviceSubClassGet(IntPtr jarg1);
        }
    }
}





