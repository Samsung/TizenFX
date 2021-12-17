/*
 * Copyright(c) 2022 Samsung Electronics Co., Ltd.
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

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_New__SWIG_0")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_StartDragAndDrop")]
            public static extern bool StartDragAndDrop(global::System.Runtime.InteropServices.HandleRef dragAndDrop, global::System.Runtime.InteropServices.HandleRef sourceView, global::System.Runtime.InteropServices.HandleRef shadow, string mimeType, string data);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_AddListener")]
            public static extern bool AddListener(global::System.Runtime.InteropServices.HandleRef dragAndDrop, global::System.Runtime.InteropServices.HandleRef targetView, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragAndDrop_RemoveListener")]
            public static extern bool RemoveListener(global::System.Runtime.InteropServices.HandleRef dragAndDrop, global::System.Runtime.InteropServices.HandleRef targetView, global::System.Runtime.InteropServices.HandleRef callback);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetAction")]
            public static extern int GetAction(global::System.IntPtr dragAndDrop);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetPosition")]
            public static extern global::System.IntPtr GetPosition(global::System.IntPtr dragAndDrop);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetMimeType")]
            public static extern string GetMimeType(global::System.IntPtr dragAndDrop);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_DragEvent_GetData")]
            public static extern string GetData(global::System.IntPtr dragAndDrop);
        }
    }
}
