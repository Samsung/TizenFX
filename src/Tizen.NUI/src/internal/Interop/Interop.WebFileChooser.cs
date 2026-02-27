/*
 * Copyright(c) 2025 Samsung Electronics Co., Ltd.
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
        internal static partial class WebFileChooser
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebFileChooserRequest", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWebFileChooserRequest(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebFileChooserRequest_MultipleFilesAllowed", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool MultipleFilesAllowed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebFileChooserRequest_AcceptedMimetypes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial System.IntPtr AcceptedMimetypes(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebFileChooserRequest_Cancel", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool Cancel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebFileChooserRequest_ChooseFiles", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ChooseFiles(IntPtr jarg1, string[] files, uint count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebFileChooserRequest_ChooseFile", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ChooseFile(IntPtr jarg1, string file);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_AcceptedMimetypes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAcceptedMimetypes(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AcceptedMimetypes_Count", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint AcceptedMimetypesCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_AcceptedMimetypes_GetItem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string AcceptedMimetypesGetItem(IntPtr jarg1, uint index);
        }
    }
}






