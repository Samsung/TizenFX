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
        internal static partial class WebBackForwardListItem
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetUrl(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetTitle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetTitle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardListItem_GetOriginalUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetOriginalUrl(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_DeleteItem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteItem(IntPtr jarg1);
        }

        internal static partial class WebBackForwardSubList
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_DeleteCopiedItems", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteCopiedItems(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetCopiedItemsCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetItemCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemAtIndexFromCopiedItems", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetItemAtIndex(IntPtr jarg1, uint jarg2);
        }

        internal static partial class WebBackForwardList
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemCount", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint GetItemCount(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetCurrentItem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetCurrentItem(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetPreviousItem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetPreviousItem(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetNextItem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetNextItem(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetItemAtIndex", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetItemAtIndex(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetBackwardItems", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetBackwardItems(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebBackForwardList_GetForwardItems", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetForwardItems(IntPtr jarg1, int jarg2);
        }
    }
}






