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
        internal static partial class WebHitTest
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebHitTest", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWebHitTest(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetResultContext", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetResultContext(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetLinkUri", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetLinkUri(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetLinkTitle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetLinkTitle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetLinkLabel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetLinkLabel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetImageUri", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetImageUri(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetMediaUri", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetMediaUri(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetTagName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetTagName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetNodeValue", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetNodeValue(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetAttributes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetAttributes(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetImageFileNameExtension", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetImageFileNameExtension(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebHitTest_GetImageBuffer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial global::System.IntPtr GetImageBuffer(IntPtr jarg1);
        }
    }
}






