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
        internal static partial class PropertyNotification
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyNotification__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyNotification();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_PropertyNotification", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeletePropertyNotification(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_PropertyNotification__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NewPropertyNotification(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetCondition__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCondition(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetTarget", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetTarget(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetTargetProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetTargetProperty(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_SetNotifyMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetNotifyMode(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetNotifyMode", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetNotifyMode(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_GetNotifyResult", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetNotifyResult(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_PropertyNotification_NotifySignal", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr NotifySignal(IntPtr jarg1);
        }
    }
}





