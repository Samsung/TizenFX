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
        internal static partial class DragAndDrop
        {
            internal enum DragType
            {
                Enter,
                Leave,
                Move,
                Drop
            }

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_New__SWIG_0", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_StartDragAndDrop", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool StartDragAndDrop(IntPtr dragAndDrop, IntPtr sourceView, IntPtr shadow, string [] mimeTypes, int mimeTypsSize, string [] dataSet, int dataSetSize, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_AddListener", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AddListener(IntPtr dragAndDrop, IntPtr targetView, string mimeType, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_RemoveListener", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool RemoveListener(IntPtr dragAndDrop, IntPtr targetView, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_Window_AddListener", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WindowAddListener(IntPtr dragAndDrop, IntPtr targetWindow, string mimeType, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_Window_RemoveListener", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool WindowRemoveListener(IntPtr dragAndDrop, IntPtr targetWindow, IntPtr callback);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetAction(global::System.IntPtr dragAndDrop);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetPosition", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPosition(global::System.IntPtr dragAndDrop);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetMimeTypes", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetMimeTypes(global::System.IntPtr dragAndDrop, out global::System.IntPtr mimeTypes, out int count);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetData(global::System.IntPtr dragAndDrop);
        }
    }
}





