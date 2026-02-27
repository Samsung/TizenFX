/*
 * Copyright(c) 2024 Samsung Electronics Co., Ltd.
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
        internal static partial class WebView
        {
            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_2", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New2(string jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_3", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New3(int jarg1, string[] jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_4", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr New4(int argc, string[] argv, int type);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetContext", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetWebContext();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetCookieManager", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetWebCookieManager();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebView__SWIG_1", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr NewWebView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebView", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void DeleteWebView(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Assign", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Assign(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_DownCast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr DownCast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_URL_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UrlGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_USER_AGENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int UserAgentGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetBackForwardList", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetWebBackForwardList(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetSettings", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetWebSettings(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_POSITION_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollPositionGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ScrollSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CONTENT_SIZE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int ContentSizeGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TITLE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TitleGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_VIDEO_HOLE_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int VideoHoleEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_MOUSE_EVENTS_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int MouseEventsEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_KEY_EVENTS_ENABLED_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int KeyEventsEnabledGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_DOCUMENT_BACKGROUND_COLOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int DocumentBackgroundColorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILES_CLEARED_WHEN_HIDDEN_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TilesClearedWhenHiddenGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILE_COVER_AREA_MULTIPLIER_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TileCoverAreaMultiplierGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CURSOR_ENABLED_BY_CLIENT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int CursorEnabledByClientGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SELECTED_TEXT_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int SelectedTextGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_PAGE_ZOOM_FACTOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int PageZoomFactorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TEXT_ZOOM_FACTOR_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int TextZoomFactorGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_LOAD_PROGRESS_PERCENTAGE_get", StringMarshalling = StringMarshalling.Utf8)]
            public static partial int LoadProgressPercentageGet();

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetFavicon", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetFavicon(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadUrl", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LoadUrl(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlString", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void LoadHtmlString(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlStringOverrideCurrentEntry", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool LoadHtmlStringOverrideCurrentEntry(IntPtr jarg1, string jarg2, string jarg3, string jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadContents", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool LoadContents(IntPtr jarg1, string jarg2, uint jarg3, string jarg4, string jarg5, string jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "CSharp_Dali_WebView_LoadContents", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool LoadContents(IntPtr jarg1, [MarshalAs(UnmanagedType.LPArray)] byte[] jarg2, uint jarg3, string jarg4, string jarg5, string jarg6);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Reload", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Reload(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ReloadWithoutCache", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool ReloadWithoutCache(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopLoading", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void StopLoading(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Suspend", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Suspend(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Resume", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void Resume(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SuspendNetworkLoading", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SuspendNetworkLoading(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ResumeNetworkLoading", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ResumeNetworkLoading(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ChangeOrientation", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ChangeOrientation(IntPtr jarg1, int orientation);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddCustomHeader", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool AddCustomHeader(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RemoveCustomHeader", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool RemoveCustomHeader(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StartInspectorServer", StringMarshalling = StringMarshalling.Utf8)]
            public static partial uint StartInspectorServer(IntPtr jarg1, uint jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopInspectorServer", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool StopInspectorServer(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetImePositionAndAlignment", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool SetImePositionAndAlignment(IntPtr jarg1, IntPtr jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetCursorThemeName", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetCursorThemeName(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollBy", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ScrollBy(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollEdgeBy", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool ScrollEdgeBy(IntPtr jarg1, int jarg2, int jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoBack", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GoBack(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoForward", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GoForward(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoBack", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool CanGoBack(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoForward", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool CanGoForward(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_EvaluateJavaScript", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void EvaluateJavaScript(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddJavaScriptMessageHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddJavaScriptMessageHandler(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddJavaScriptEntireMessageHandler", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddJavaScriptEntireMessageHandler(IntPtr jarg1, string jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptAlertCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterJavaScriptAlertCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptAlertReply", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void JavaScriptAlertReply(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptConfirmCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterJavaScriptConfirmCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptConfirmReply", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void JavaScriptConfirmReply(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptPromptCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterJavaScriptPromptCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptPromptReply", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void JavaScriptPromptReply(IntPtr jarg1, string jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearAllTilesResources", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearAllTilesResources(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearHistory", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ClearHistory(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ExitFullscreen", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ExitFullscreen(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetScaleFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetScaleFactor(IntPtr jarg1, float jarg2, IntPtr jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScaleFactor", StringMarshalling = StringMarshalling.Utf8)]
            public static partial float GetScaleFactor(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ActivateAccessibility", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void ActivateAccessibility(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_HighlightText", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool HighlightText(IntPtr jarg1, string jarg2, int jarg3, uint jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddDynamicCertificatePath", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void AddDynamicCertificatePath(IntPtr jarg1, string jarg2, string jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshot", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr GetScreenshot(IntPtr jarg1, IntPtr jarg2, float jarg3);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshotAsynchronously", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool GetScreenshotAsynchronously(IntPtr jarg1, IntPtr jarg2, float jarg3, IntPtr jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CheckVideoPlayingAsynchronously", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool CheckVideoPlayingAsynchronously(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterGeolocationPermissionCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterGeolocationPermissionCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTest", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr CreateHitTest(IntPtr jarg1, int jarg2, int jarg3, int jarg4);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTestAsynchronously", StringMarshalling = StringMarshalling.Utf8)]
            [return: MarshalAs(UnmanagedType.U1)]
            public static partial bool CreateHitTestAsynchronously(IntPtr jarg1, int jarg2, int jarg3, int jarg4, IntPtr jarg5);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SWIGUpcast", StringMarshalling = StringMarshalling.Utf8)]
            public static partial IntPtr Upcast(IntPtr jarg1);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetTtsFocus", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetTtsFocus(IntPtr jarg1, [MarshalAs(UnmanagedType.U1)] bool jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadStartedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterPageLoadStartedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadInProgressCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterPageLoadInProgressCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadFinishedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterPageLoadFinishedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadErrorCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterPageLoadErrorCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterScrollEdgeReachedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterScrollEdgeReachedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterUrlChangedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterUrlChangedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFormRepostDecidedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterFormRepostDecidedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFrameRenderedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterFrameRenderedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterConsoleMessageReceivedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterConsoleMessageReceivedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterResponsePolicyDecidedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterResponsePolicyDecidedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNavigationPolicyDecidedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterNavigationPolicyDecidedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterOverScrolledCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterOverScrolledCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNewWindowPolicyDecidedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterNewWindowPolicyDecidedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNewWindowCreatedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterNewWindowCreatedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterCertificateConfirmedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterCertificateConfirmedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterSslCertificateChangedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterSslCertificateChangedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterHttpAuthHandlerCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterHttpAuthHandlerCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterContextMenuShownCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterContextMenuShownCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterContextMenuHiddenCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterContextMenuHiddenCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFullscreenEnteredCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterFullscreenEnteredCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFullscreenExitedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterFullscreenExitedCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterTextFoundCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterTextFoundCallback(IntPtr jarg1, IntPtr jarg2);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetPlainTextAsynchronously", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void GetPlainTextAsynchronously(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_WebAuthenticationCancel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void WebAuthenticationCancel(IntPtr webViewRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterWebAuthDisplayQRCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterWebAuthDisplayQRCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterWebAuthResponseCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterWebAuthResponseCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFileChooserRequestedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterFileChooserRequestedCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterWebProcessCrashedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterWebProcessCrashedCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterUserMediaPermissionRequestCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterUserMediaPermissionRequestCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_FeedMouseWheel", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void FeedMouseWheel(IntPtr webViewRef, [MarshalAs(UnmanagedType.U1)] bool yDirection, int step, int x, int y);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterDeviceConnectionChangedCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterDeviceConnectionChangedCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterDeviceListGetCallback", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void RegisterDeviceListGetCallback(IntPtr webViewRef, IntPtr callbackRef);

            [LibraryImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetVideoHole", StringMarshalling = StringMarshalling.Utf8)]
            public static partial void SetVideoHole(IntPtr webViewRef, [MarshalAs(UnmanagedType.U1)] bool enable, [MarshalAs(UnmanagedType.U1)] bool isWaylandWindow);
        }
    }
}



