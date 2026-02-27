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
        internal static partial class WebSettings
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowMixedContents", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AllowMixedContents(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableSpatialNavigation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableSpatialNavigation(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_GetDefaultFontSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetDefaultFontSize(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetDefaultFontSize", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultFontSize(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableWebSecurity", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableWebSecurity(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableCacheBuilder", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableCacheBuilder(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_UseScrollbarThumbFocusNotifications", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UseScrollbarThumbFocusNotifications(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableDoNotTrack", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableDoNotTrack(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowFileAccessFromExternalUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AllowFileAccessFromExternalUrl(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsJavaScriptEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsJavaScriptEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableJavaScript", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableJavaScript(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsAutoFittingEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAutoFittingEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableAutoFitting", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableAutoFitting(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_ArePluginsEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool ArePluginsEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnablePlugins", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnablePlugins(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsPrivateBrowsingEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsPrivateBrowsingEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnablePrivateBrowsing", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnablePrivateBrowsing(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsLinkMagnifierEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsLinkMagnifierEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableLinkMagnifier", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableLinkMagnifier(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsKeypadWithoutUserActionUsed", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsKeypadWithoutUserActionUsed(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_UseKeypadWithoutUserAction", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void UseKeypadWithoutUserAction(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsAutofillPasswordFormEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsAutofillPasswordFormEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableAutofillPasswordForm", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableAutofillPasswordForm(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsFormCandidateDataEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsFormCandidateDataEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableFormCandidateData", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableFormCandidateData(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsTextSelectionEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTextSelectionEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableTextSelection", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableTextSelection(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsTextAutosizingEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTextAutosizingEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableTextAutosizing", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableTextAutosizing(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsArrowScrollEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsArrowScrollEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableArrowScroll", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableArrowScroll(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsClipboardEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsClipboardEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableClipboard", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableClipboard(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsImePanelEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsImePanelEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableImePanel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableImePanel(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowScriptsOpenWindows", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AllowScriptsOpenWindows(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AreImagesLoadedAutomatically", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool AreImagesLoadedAutomatically(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_AllowImagesLoadAutomatically", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AllowImagesLoadAutomatically(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_GetDefaultTextEncodingName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial string GetDefaultTextEncodingName(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetDefaultTextEncodingName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultTextEncodingName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetViewportMetaTag", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetViewportMetaTag(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetForceZoom", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetForceZoom(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsZoomForced", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsZoomForced(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetTextZoomEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool SetTextZoomEnabled(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsTextZoomEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsTextZoomEnabled(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetImeStyle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetImeStyle(IntPtr jarg1, int jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_GetImeStyle", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int GetImeStyle(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetExtraFeature", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetExtraFeature(IntPtr jarg1, string jarg2, [MarshalAs(UnmanagedType.U1)] bool jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_IsExtraFeatureEnabled", StringMarshalling = StringMarshalling.Utf8)]
            [return: global::System.Runtime.InteropServices.MarshalAs(global::System.Runtime.InteropServices.UnmanagedType.U1)]
            public static partial bool IsExtraFeatureEnabled(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_SetDefaultAudioInputDevice", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetDefaultAudioInputDevice(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebSettings_EnableDragAndDrop", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EnableDragAndDrop(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);
        }
    }
}






