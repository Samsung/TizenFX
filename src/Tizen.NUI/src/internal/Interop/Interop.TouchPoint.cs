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
        internal static partial class TouchPoint
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TouchPoint__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouchPoint(int jarg1, int jarg2, float jarg3, float jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_TouchPoint__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouchPoint(int jarg1, int jarg2, float jarg3, float jarg4, float jarg5, float jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_TouchPoint", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTouchPoint(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_deviceId_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeviceIdSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_deviceId_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DeviceIdGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_state_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StateSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_state_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StateGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_hitActor_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void HitActorSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_hitActor_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr HitActorGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_local_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LocalSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_local_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr LocalGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_screen_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScreenSet(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_TouchPoint_screen_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr ScreenGet(IntPtr jarg1);
        }
    }
}





