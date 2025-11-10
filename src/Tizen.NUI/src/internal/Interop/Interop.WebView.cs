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

using global::System.Runtime.InteropServices;
using global::System;

namespace Tizen.NUI
{
    internal static partial class Interop
    {
        internal static partial class WebView
        {
            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New")]
            public static extern IntPtr New();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_2")]
            public static extern IntPtr New2(string jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_3")]
            public static extern IntPtr New3(int jarg1, string[] jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_4")]
            public static extern IntPtr New4(int argc, string[] argv, int type);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetContext")]
            public static extern IntPtr GetWebContext();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetCookieManager")]
            public static extern IntPtr GetWebCookieManager();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebView__SWIG_1")]
            public static extern IntPtr NewWebView(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebView")]
            public static extern void DeleteWebView(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Assign")]
            public static extern IntPtr Assign(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_DownCast")]
            public static extern IntPtr DownCast(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_URL_get")]
            public static extern int UrlGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_USER_AGENT_get")]
            public static extern int UserAgentGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetBackForwardList")]
            public static extern IntPtr GetWebBackForwardList(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetSettings")]
            public static extern IntPtr GetWebSettings(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_POSITION_get")]
            public static extern int ScrollPositionGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_SIZE_get")]
            public static extern int ScrollSizeGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CONTENT_SIZE_get")]
            public static extern int ContentSizeGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TITLE_get")]
            public static extern int TitleGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_VIDEO_HOLE_ENABLED_get")]
            public static extern int VideoHoleEnabledGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_MOUSE_EVENTS_ENABLED_get")]
            public static extern int MouseEventsEnabledGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_KEY_EVENTS_ENABLED_get")]
            public static extern int KeyEventsEnabledGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_DOCUMENT_BACKGROUND_COLOR_get")]
            public static extern int DocumentBackgroundColorGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILES_CLEARED_WHEN_HIDDEN_get")]
            public static extern int TilesClearedWhenHiddenGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILE_COVER_AREA_MULTIPLIER_get")]
            public static extern int TileCoverAreaMultiplierGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CURSOR_ENABLED_BY_CLIENT_get")]
            public static extern int CursorEnabledByClientGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SELECTED_TEXT_get")]
            public static extern int SelectedTextGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_PAGE_ZOOM_FACTOR_get")]
            public static extern int PageZoomFactorGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TEXT_ZOOM_FACTOR_get")]
            public static extern int TextZoomFactorGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_LOAD_PROGRESS_PERCENTAGE_get")]
            public static extern int LoadProgressPercentageGet();

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetFavicon")]
            public static extern IntPtr GetFavicon(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadUrl")]
            public static extern void LoadUrl(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlString")]
            public static extern void LoadHtmlString(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlStringOverrideCurrentEntry")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool LoadHtmlStringOverrideCurrentEntry(HandleRef jarg1, string jarg2, string jarg3, string jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadContents")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool LoadContents(HandleRef jarg1, string jarg2, uint jarg3, string jarg4, string jarg5, string jarg6);

            [DllImport(NDalicPINVOKE.Lib, CallingConvention = CallingConvention.Cdecl, CharSet = CharSet.Ansi, EntryPoint = "CSharp_Dali_WebView_LoadContents")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool LoadContents(HandleRef jarg1, [MarshalAs(UnmanagedType.LPArray)] byte[] jarg2, uint jarg3, string jarg4, string jarg5, string jarg6);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Reload")]
            public static extern void Reload(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ReloadWithoutCache")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool ReloadWithoutCache(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopLoading")]
            public static extern void StopLoading(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Suspend")]
            public static extern void Suspend(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Resume")]
            public static extern void Resume(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SuspendNetworkLoading")]
            public static extern void SuspendNetworkLoading(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ResumeNetworkLoading")]
            public static extern void ResumeNetworkLoading(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ChangeOrientation")]
            public static extern void ChangeOrientation(HandleRef jarg1, int orientation);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddCustomHeader")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool AddCustomHeader(HandleRef jarg1, string jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RemoveCustomHeader")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool RemoveCustomHeader(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StartInspectorServer")]
            public static extern uint StartInspectorServer(HandleRef jarg1, uint jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopInspectorServer")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool StopInspectorServer(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetImePositionAndAlignment")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool SetImePositionAndAlignment(HandleRef jarg1, HandleRef jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetCursorThemeName")]
            public static extern void SetCursorThemeName(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollBy")]
            public static extern void ScrollBy(HandleRef jarg1, int jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollEdgeBy")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool ScrollEdgeBy(HandleRef jarg1, int jarg2, int jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoBack")]
            public static extern void GoBack(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoForward")]
            public static extern void GoForward(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoBack")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool CanGoBack(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoForward")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool CanGoForward(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_EvaluateJavaScript")]
            public static extern void EvaluateJavaScript(HandleRef jarg1, string jarg2, HandleRef jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddJavaScriptMessageHandler")]
            public static extern void AddJavaScriptMessageHandler(HandleRef jarg1, string jarg2, HandleRef jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddJavaScriptEntireMessageHandler")]
            public static extern void AddJavaScriptEntireMessageHandler(HandleRef jarg1, string jarg2, HandleRef jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptAlertCallback")]
            public static extern void RegisterJavaScriptAlertCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptAlertReply")]
            public static extern void JavaScriptAlertReply(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptConfirmCallback")]
            public static extern void RegisterJavaScriptConfirmCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptConfirmReply")]
            public static extern void JavaScriptConfirmReply(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptPromptCallback")]
            public static extern void RegisterJavaScriptPromptCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptPromptReply")]
            public static extern void JavaScriptPromptReply(HandleRef jarg1, string jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearAllTilesResources")]
            public static extern void ClearAllTilesResources(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearHistory")]
            public static extern void ClearHistory(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ExitFullscreen")]
            public static extern void ExitFullscreen(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetScaleFactor")]
            public static extern void SetScaleFactor(HandleRef jarg1, float jarg2, HandleRef jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScaleFactor")]
            public static extern float GetScaleFactor(HandleRef jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ActivateAccessibility")]
            public static extern void ActivateAccessibility(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_HighlightText")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool HighlightText(HandleRef jarg1, string jarg2, int jarg3, uint jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddDynamicCertificatePath")]
            public static extern void AddDynamicCertificatePath(HandleRef jarg1, string jarg2, string jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshot")]
            public static extern IntPtr GetScreenshot(HandleRef jarg1, HandleRef jarg2, float jarg3);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshotAsynchronously")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool GetScreenshotAsynchronously(HandleRef jarg1, HandleRef jarg2, float jarg3, HandleRef jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CheckVideoPlayingAsynchronously")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool CheckVideoPlayingAsynchronously(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterGeolocationPermissionCallback")]
            public static extern void RegisterGeolocationPermissionCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTest")]
            public static extern IntPtr CreateHitTest(HandleRef jarg1, int jarg2, int jarg3, int jarg4);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTestAsynchronously")]
            [return: MarshalAs(UnmanagedType.U1)]
            public static extern bool CreateHitTestAsynchronously(HandleRef jarg1, int jarg2, int jarg3, int jarg4, HandleRef jarg5);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SWIGUpcast")]
            public static extern IntPtr Upcast(IntPtr jarg1);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetTtsFocus")]
            public static extern void SetTtsFocus(HandleRef jarg1, bool jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadStartedCallback")]
            public static extern void RegisterPageLoadStartedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadInProgressCallback")]
            public static extern void RegisterPageLoadInProgressCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadFinishedCallback")]
            public static extern void RegisterPageLoadFinishedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterPageLoadErrorCallback")]
            public static extern void RegisterPageLoadErrorCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterScrollEdgeReachedCallback")]
            public static extern void RegisterScrollEdgeReachedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterUrlChangedCallback")]
            public static extern void RegisterUrlChangedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFormRepostDecidedCallback")]
            public static extern void RegisterFormRepostDecidedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFrameRenderedCallback")]
            public static extern void RegisterFrameRenderedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterConsoleMessageReceivedCallback")]
            public static extern void RegisterConsoleMessageReceivedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterResponsePolicyDecidedCallback")]
            public static extern void RegisterResponsePolicyDecidedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNavigationPolicyDecidedCallback")]
            public static extern void RegisterNavigationPolicyDecidedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterOverScrolledCallback")]
            public static extern void RegisterOverScrolledCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNewWindowPolicyDecidedCallback")]
            public static extern void RegisterNewWindowPolicyDecidedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterNewWindowCreatedCallback")]
            public static extern void RegisterNewWindowCreatedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterCertificateConfirmedCallback")]
            public static extern void RegisterCertificateConfirmedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterSslCertificateChangedCallback")]
            public static extern void RegisterSslCertificateChangedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterHttpAuthHandlerCallback")]
            public static extern void RegisterHttpAuthHandlerCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterContextMenuShownCallback")]
            public static extern void RegisterContextMenuShownCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterContextMenuHiddenCallback")]
            public static extern void RegisterContextMenuHiddenCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFullscreenEnteredCallback")]
            public static extern void RegisterFullscreenEnteredCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFullscreenExitedCallback")]
            public static extern void RegisterFullscreenExitedCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterTextFoundCallback")]
            public static extern void RegisterTextFoundCallback(HandleRef jarg1, HandleRef jarg2);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetPlainTextAsynchronously")]
            public static extern void GetPlainTextAsynchronously(HandleRef webViewRef, HandleRef callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_WebAuthenticationCancel")]
            public static extern void WebAuthenticationCancel(HandleRef webViewRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterWebAuthDisplayQRCallback")]
            public static extern void RegisterWebAuthDisplayQRCallback(HandleRef webViewRef, HandleRef callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterWebAuthResponseCallback")]
            public static extern void RegisterWebAuthResponseCallback(HandleRef webViewRef, HandleRef callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterFileChooserRequestedCallback")]
            public static extern void RegisterFileChooserRequestedCallback(HandleRef webViewRef, HandleRef callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterUserMediaPermissionRequestCallback")]
            public static extern void RegisterUserMediaPermissionRequestCallback(HandleRef webViewRef, HandleRef callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_FeedMouseWheel")]
            public static extern void FeedMouseWheel(HandleRef webViewRef, bool yDirection, int step, int x, int y);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterDeviceConnectionChangedCallback")]
            public static extern void RegisterDeviceConnectionChangedCallback(HandleRef webViewRef, IntPtr callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterDeviceListGetCallback")]
            public static extern void RegisterDeviceListGetCallback(HandleRef webViewRef, IntPtr callbackRef);

            [DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetVideoHole")]
            public static extern void SetVideoHole(HandleRef webViewRef, bool enable, bool isWaylandWindow);
        }
    }
}
