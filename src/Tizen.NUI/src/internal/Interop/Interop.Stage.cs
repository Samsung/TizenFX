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
        internal static partial class Stage
        {
            static Stage()
            {
            }

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetCurrent", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrent();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_IsInstalled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsInstalled();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderTaskList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetRenderTaskList(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetDpi", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetDpi(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_SetRenderingBehavior", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetRenderingBehavior(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Stage_GetRenderingBehavior", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetRenderingBehavior(IntPtr jarg1);
        }
    }
}





