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
        internal static partial class WebContext
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetCacheModel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetCacheModel(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetCacheModel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCacheModel(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetProxyUri", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProxyUri(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetProxyUri", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetProxyUri(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetProxyBypassRule", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetProxyBypassRule(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetProxyBypassRule", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetProxyBypassRule(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetCertificateFilePath", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCertificateFilePath(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetCertificateFilePath", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetCertificateFilePath(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetDefaultProxyAuth", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultProxyAuth(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllWebDatabase", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAllWebDatabase(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetWebDatabaseOrigins", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetWebDatabaseOrigins(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteWebDatabase", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DeleteWebDatabase(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetWebStorageOrigins", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetWebStorageOrigins(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetWebStorageUsageForOrigin", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool GetWebStorageUsageForOrigin(IntPtr jarg1, IntPtr jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllWebStorage", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAllWebStorage(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteWebStorage", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DeleteWebStorage(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteLocalFileSystem", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteLocalFileSystem(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_ClearCache", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearCache(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteApplicationCache", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DeleteApplicationCache(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetFormPasswordList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetFormPasswordList(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_RegisterDownloadStartedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterDownloadStartedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_RegisterMimeOverriddenCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterMimeOverriddenCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_RegisterRequestInterceptedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterRequestInterceptedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_EnableCache", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableCache(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_IsCacheEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsCacheEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetAppId", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetAppId(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetAppVersion", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetAppVersion(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetApplicationType", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetApplicationType(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetTimeOffset", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTimeOffset(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetTimeZoneOffset", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTimeZoneOffset(IntPtr jarg1, float jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_RegisterUrlSchemesAsCorsEnabled", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterUrlSchemesAsCorsEnabled(IntPtr jarg1, string[] jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_RegisterJsPluginMimeTypes", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterJsPluginMimeTypes(IntPtr jarg1, string[] jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_SetDefaultZoomFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultZoomFactor(IntPtr jarg1, float jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_GetDefaultZoomFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetDefaultZoomFactor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllApplicationCache", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DeleteAllApplicationCache(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllWebIndexedDatabase", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool DeleteAllWebIndexedDatabase(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteFormPasswordDataList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteFormPasswordDataList(IntPtr jarg1, string[] jarg2, uint jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllFormPasswordData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAllFormPasswordData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_DeleteAllFormCandidateData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteAllFormCandidateData(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebContext_FreeUnusedMemory", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool FreeUnusedMemory(IntPtr jarg1);
        }
    }
}






