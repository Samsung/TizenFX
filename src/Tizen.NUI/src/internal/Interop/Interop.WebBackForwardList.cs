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

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebBackForwardListItem
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetUrl")]
            public static extern string GetUrl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetTitle")]
            public static extern string GetTitle(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetOriginalUrl")]
            public static extern string GetOriginalUrl(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_DeleteItem")]
            public static extern void DeleteItem(global::System.Runtime.InteropServices.HandleRef jarg1);
        }

        internal static partial class WebBackForwardSubList
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_DeleteCopiedItems")]
            public static extern void DeleteCopiedItems(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetCopiedItemsCount")]
            public static extern uint GetItemCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemAtIndexFromCopiedItems")]
            public static extern global::System.IntPtr GetItemAtIndex(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);
        }

        internal static partial class WebBackForwardList
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemCount")]
            public static extern uint GetItemCount(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetCurrentItem")]
            public static extern global::System.IntPtr GetCurrentItem(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetPreviousItem")]
            public static extern global::System.IntPtr GetPreviousItem(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetNextItem")]
            public static extern global::System.IntPtr GetNextItem(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemAtIndex")]
            public static extern global::System.IntPtr GetItemAtIndex(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetBackwardItems")]
            public static extern global::System.IntPtr GetBackwardItems(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetForwardItems")]
            public static extern global::System.IntPtr GetForwardItems(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2);
        }
    }
}

