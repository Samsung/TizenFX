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
        internal static partial class KeyInputFocusManager
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_KeyInputFocusManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewKeyInputFocusManager();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_KeyInputFocusManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteKeyInputFocusManager(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_Get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Get();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_SetFocus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetFocus(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_GetCurrentFocusControl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetCurrentFocusControl(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_KeyInputFocusManager_RemoveFocus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemoveFocus(IntPtr jarg1, IntPtr jarg2);
        }
    }
}



