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
        internal static partial class Touch
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_Touch__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewTouch();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetMouseButton", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetMouseButton(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTime(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_SetTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTime(IntPtr touchEvent, uint time);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetPointCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetPointCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetDeviceId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceId(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetState(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetHitActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetHitActor(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetLocalPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetLocalPosition(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetScreenPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScreenPosition(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetRadius(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetEllipseRadius", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetEllipseRadius(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetPressure", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetPressure(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetAngle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetAngle(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetDeviceClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceClass(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetDeviceSubclass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceSubClass(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Touch_GetDeviceName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetDeviceName(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Touch", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteTouch(IntPtr jarg1);
        }
    }
}





