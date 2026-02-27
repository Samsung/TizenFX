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
        internal static partial class Handle
        {

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_Handle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteHandle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetPropertyName(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPropertyIndex(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_IsPropertyWritable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPropertyWritable(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_IsPropertyAnimatable", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPropertyAnimatable(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_IsPropertyAConstraintInput", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPropertyAConstraintInput(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetPropertyType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetPropertyType(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_SetProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProperty(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_SetProperties", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProperties(IntPtr handle, IntPtr propertyMap);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RegisterProperty__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RegisterProperty(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RegisterProperty__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int RegisterProperty(IntPtr jarg1, string jarg2, IntPtr jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetProperty(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_GetCurrentProperty", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentProperty(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_AddPropertyNotification__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AddPropertyNotification(IntPtr jarg1, int jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_AddPropertyNotification__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr AddPropertyNotification(IntPtr jarg1, int jarg2, int jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RemovePropertyNotification", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemovePropertyNotification(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_Handle_RemovePropertyNotifications", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RemovePropertyNotifications(IntPtr jarg1);
        }
    }
}





