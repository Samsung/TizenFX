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
        internal static partial class WebCookieManager
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_GetCookieAcceptPolicy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetCookieAcceptPolicy(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_SetCookieAcceptPolicy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCookieAcceptPolicy(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_SetPersistentStorage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetPersistentStorage(IntPtr jarg1, string jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_ClearCookies", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearCookies(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebCookieManager_ChangesWatch", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void CookieChangedCallback(IntPtr jarg1, IntPtr jarg2);
        }
    }
}






