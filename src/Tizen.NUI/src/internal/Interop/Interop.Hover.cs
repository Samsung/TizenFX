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
        internal static partial class Hover
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(uint jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetTime", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetTime(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetPointCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetPointCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetDeviceId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceId(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetState", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetState(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetHitActor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetHitActor(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetLocalPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetLocalPosition(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetScreenPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetScreenPosition(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetDeviceClass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceClass(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetDeviceSubclass", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDeviceSubClass(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Hover_GetDeviceName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetDeviceName(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Hover", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteHover(IntPtr jarg1);
        }
    }
}





