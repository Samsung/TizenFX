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
        internal static partial class Key
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New(string jarg1, string jarg2, int jarg3, int jarg4, uint jarg5, int jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_New__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Key", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteKey(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_IsShiftModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsShiftModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_IsCtrlModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsCtrlModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_IsAltModifier", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAltModifier(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressedName_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyPressedNameSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressedName_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string KeyPressedNameGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressed_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyPressedSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressed_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string KeyPressedGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressed_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyStringSet(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyPressed_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string KeyStringGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyCode_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyCodeSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyCode_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int KeyCodeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyModifier_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void KeyModifierSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_keyModifier_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int KeyModifierGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_time_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void TimeSet(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_time_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint TimeGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_state_set", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StateSet(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_state_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int StateGet(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Key_logicalKey_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string LogicalKeyGet(IntPtr jarg1);
        }
    }
}





