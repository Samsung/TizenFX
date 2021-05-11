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
        internal static partial class WebView
        {
            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New")]
            public static extern global::System.IntPtr New();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_2")]
            public static extern global::System.IntPtr New2(string jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_New_3")]
            public static extern global::System.IntPtr New3(int jarg1, string[] jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebView__SWIG_1")]
            public static extern global::System.IntPtr NewWebView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebView")]
            public static extern void DeleteWebView(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Assign")]
            public static extern global::System.IntPtr Assign(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_DownCast")]
            public static extern global::System.IntPtr DownCast(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_URL_get")]
            public static extern int UrlGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_USER_AGENT_get")]
            public static extern int UserAgentGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetBackForwardList")]
            public static extern global::System.IntPtr GetWebBackForwardList(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetContext")]
            public static extern global::System.IntPtr GetWebContext(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetCookieManager")]
            public static extern global::System.IntPtr GetWebCookieManager(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetSettings")]
            public static extern global::System.IntPtr GetWebSettings(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_POSITION_get")]
            public static extern int ScrollPositionGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SCROLL_SIZE_get")]
            public static extern int ScrollSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CONTENT_SIZE_get")]
            public static extern int ContentSizeGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TITLE_get")]
            public static extern int TitleGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_VIDEO_HOLE_ENABLED_get")]
            public static extern int VideoHoleEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_MOUSE_EVENTS_ENABLED_get")]
            public static extern int MouseEventsEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_KEY_EVENTS_ENABLED_get")]
            public static extern int KeyEventsEnabledGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_DOCUMENT_BACKGROUND_COLOR_get")]
            public static extern int DocumentBackgroundColorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILES_CLEARED_WHEN_HIDDEN_get")]
            public static extern int TilesClearedWhenHiddenGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TILE_COVER_AREA_MULTIPLIER_get")]
            public static extern int TileCoverAreaMultiplierGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_CURSOR_ENABLED_BY_CLIENT_get")]
            public static extern int CursorEnabledByClientGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_SELECTED_TEXT_get")]
            public static extern int SelectedTextGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_PAGE_ZOOM_FACTOR_get")]
            public static extern int PageZoomFactorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_TEXT_ZOOM_FACTOR_get")]
            public static extern int TextZoomFactorGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Property_LOAD_PROGRESS_PERCENTAGE_get")]
            public static extern int LoadProgressPercentageGet();

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetFavicon")]
            public static extern global::System.IntPtr GetFavicon(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadUrl")]
            public static extern void LoadUrl(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlString")]
            public static extern void LoadHtmlString(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadHtmlStringOverrideCurrentEntry")]
            public static extern bool LoadHtmlStringOverrideCurrentEntry(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3, string jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_LoadContents")]
            public static extern bool LoadContents(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, uint jarg3, string jarg4, string jarg5, string jarg6);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Reload")]
            public static extern void Reload(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ReloadWithoutCache")]
            public static extern bool ReloadWithoutCache(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopLoading")]
            public static extern void StopLoading(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Suspend")]
            public static extern void Suspend(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_Resume")]
            public static extern void Resume(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SuspendNetworkLoading")]
            public static extern void SuspendNetworkLoading(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ResumeNetworkLoading")]
            public static extern void ResumeNetworkLoading(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddCustomHeader")]
            public static extern bool AddCustomHeader(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RemoveCustomHeader")]
            public static extern bool RemoveCustomHeader(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StartInspectorServer")]
            public static extern uint StartInspectorServer(global::System.Runtime.InteropServices.HandleRef jarg1, uint jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_StopInspectorServer")]
            public static extern bool StopInspectorServer(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollBy")]
            public static extern void ScrollBy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ScrollEdgeBy")]
            public static extern bool ScrollEdgeBy(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoBack")]
            public static extern void GoBack(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GoForward")]
            public static extern void GoForward(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoBack")]
            public static extern bool CanGoBack(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CanGoForward")]
            public static extern bool CanGoForward(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_EvaluateJavaScript")]
            public static extern void EvaluateJavaScript(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddJavaScriptMessageHandler")]
            public static extern void AddJavaScriptMessageHandler(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptAlertCallback")]
            public static extern void RegisterJavaScriptAlertCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptAlertReply")]
            public static extern void JavaScriptAlertReply(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptConfirmCallback")]
            public static extern void RegisterJavaScriptConfirmCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptConfirmReply")]
            public static extern void JavaScriptConfirmReply(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterJavaScriptPromptCallback")]
            public static extern void RegisterJavaScriptPromptCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_JavaScriptPromptReply")]
            public static extern void JavaScriptPromptReply(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearAllTilesResources")]
            public static extern void ClearAllTilesResources(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ClearHistory")]
            public static extern void ClearHistory(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SetScaleFactor")]
            public static extern void SetScaleFactor(global::System.Runtime.InteropServices.HandleRef jarg1, float jarg2, global::System.Runtime.InteropServices.HandleRef jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScaleFactor")]
            public static extern float GetScaleFactor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_ActivateAccessibility")]
            public static extern void ActivateAccessibility(global::System.Runtime.InteropServices.HandleRef jarg1, bool jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_HighlightText")]
            public static extern bool HighlightText(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, int jarg3, uint jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_AddDynamicCertificatePath")]
            public static extern void AddDynamicCertificatePath(global::System.Runtime.InteropServices.HandleRef jarg1, string jarg2, string jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshot")]
            public static extern global::System.IntPtr GetScreenshot(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_GetScreenshotAsynchronously")]
            public static extern bool GetScreenshotAsynchronously(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2, float jarg3, global::System.Runtime.InteropServices.HandleRef jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CheckVideoPlayingAsynchronously")]
            public static extern bool CheckVideoPlayingAsynchronously(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_RegisterGeolocationPermissionCallback")]
            public static extern void RegisterGeolocationPermissionCallback(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTest")]
            public static extern global::System.IntPtr CreateHitTest(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_CreateHitTestAsynchronously")]
            public static extern bool CreateHitTestAsynchronously(global::System.Runtime.InteropServices.HandleRef jarg1, int jarg2, int jarg3, int jarg4, global::System.Runtime.InteropServices.HandleRef jarg5);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebView_SWIGUpcast")]
            public static extern global::System.IntPtr Upcast(global::System.IntPtr jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewPageLoadSignal_PageLoadStarted")]
            public static extern global::System.IntPtr NewWebViewPageLoadSignalPageLoadStarted(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewPageLoadSignal_PageLoadInProgress")]
            public static extern global::System.IntPtr NewWebViewPageLoadSignalPageLoadInProgress(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewPageLoadSignal_PageLoadFinished")]
            public static extern global::System.IntPtr NewWebViewPageLoadSignalPageLoadFinished(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewPageLoadSignal")]
            public static extern void DeleteWebViewPageLoadSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPageLoadSignal_Connect")]
            public static extern void WebViewPageLoadSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPageLoadSignal_Disconnect")]
            public static extern void WebViewPageLoadSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewPageLoadErrorSignal_PageLoadError")]
            public static extern global::System.IntPtr NewWebViewPageLoadErrorSignalPageLoadError(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewPageLoadErrorSignal")]
            public static extern void DeleteWebViewPageLoadErrorSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPageLoadErrorSignal_Connect")]
            public static extern void WebViewPageLoadErrorSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPageLoadErrorSignal_Disconnect")]
            public static extern void WebViewPageLoadErrorSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewScrollEdgeReachedSignal_ScrollEdgeReached")]
            public static extern global::System.IntPtr NewWebViewScrollEdgeReachedSignalScrollEdgeReached(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewScrollEdgeReachedSignal")]
            public static extern void DeleteWebViewScrollEdgeReachedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewScrollEdgeReachedSignal_Connect")]
            public static extern void WebViewScrollEdgeReachedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewScrollEdgeReachedSignal_Disconnect")]
            public static extern void WebViewScrollEdgeReachedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewUrlChangedSignal_UrlChanged")]
            public static extern global::System.IntPtr NewWebViewUrlChangedSignalUrlChanged(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewUrlChangedSignal")]
            public static extern void DeleteWebViewUrlChangedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewUrlChangedSignal_Connect")]
            public static extern void WebViewUrlChangedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewUrlChangedSignal_Disconnect")]
            public static extern void WebViewUrlChangedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewFormRepostDecisionSignal_FormRepostDecision")]
            public static extern global::System.IntPtr NewWebViewFormRepostDecisionSignalFormRepostDecision(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewFormRepostDecisionSignal")]
            public static extern void DeleteWebViewFormRepostDecisionSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewFormRepostDecisionSignal_Connect")]
            public static extern void WebViewFormRepostDecisionSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewFormRepostDecisionSignal_Disconnect")]
            public static extern void WebViewFormRepostDecisionSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewFrameRenderedSignal_FrameRendered")]
            public static extern global::System.IntPtr WebViewFrameRenderedSignalFrameRenderedGet(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewFrameRenderedSignal_Connect")]
            public static extern void WebViewFrameRenderedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewFrameRenderedSignal_Disconnect")]
            public static extern void WebViewFrameRenderedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewResponsePolicyDecisionSignal_ResponsePolicyDecision")]
            public static extern global::System.IntPtr NewWebViewResponsePolicyDecisionSignalPolicyDecision(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewResponsePolicyDecisionSignal")]
            public static extern void DeleteWebViewResponsePolicyDecisionSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPolicyDecisionSignal_Connect")]
            public static extern void WebViewPolicyDecisionSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewPolicyDecisionSignal_Disconnect")]
            public static extern void WebViewPolicyDecisionSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewCertificateSignal_CertificateConfirm")]
            public static extern global::System.IntPtr NewWebViewCertificateSignalCertificateConfirm(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewCertificateSignal_SslCertificateChanged")]
            public static extern global::System.IntPtr NewWebViewCertificateSignalSslCertificateChanged(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewCertificateSignal")]
            public static extern void DeleteWebViewCertificateSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewCertificateSignal_Connect")]
            public static extern void WebViewCertificateSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewCertificateSignal_Disconnect")]
            public static extern void WebViewCertificateSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewHttpAuthHandlerSignal_HttpAuthHandler")]
            public static extern global::System.IntPtr NewWebViewHttpAuthHandlerSignalHttpAuthHandler(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewHttpAuthHandlerSignal")]
            public static extern void DeleteWebViewHttpAuthHandlerSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewHttpAuthHandlerSignal_Connect")]
            public static extern void WebViewHttpAuthHandlerSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewHttpAuthHandlerSignal_Disconnect")]
            public static extern void WebViewHttpAuthHandlerSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewRequestInterceptorSignal_RequestInterceptor")]
            public static extern global::System.IntPtr NewWebViewRequestInterceptorSignalRequestInterceptor(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewRequestInterceptorSignal")]
            public static extern void DeleteWebViewRequestInterceptorSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewRequestInterceptorSignal_Connect")]
            public static extern void WebViewRequestInterceptorSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewRequestInterceptorSignal_Disconnect")]
            public static extern void WebViewRequestInterceptorSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewConsoleMessageSignal_ConsoleMessage")]
            public static extern global::System.IntPtr NewWebViewConsoleMessageSignalConsoleMessage(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewConsoleMessageSignal")]
            public static extern void DeleteWebViewConsoleMessageSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewConsoleMessageSignal_Connect")]
            public static extern void WebViewConsoleMessageSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewConsoleMessageSignal_Disconnect")]
            public static extern void WebViewConsoleMessageSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewContextMenuCustomizedSignal_ContextMenuCustomized")]
            public static extern global::System.IntPtr NewWebViewContextMenuCustomizedSignalContextMenuCustomized(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewContextMenuCustomizedSignal")]
            public static extern void DeleteWebViewContextMenuCustomizedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewContextMenuCustomizedSignal_Connect")]
            public static extern void WebViewContextMenuCustomizedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewContextMenuCustomizedSignal_Disconnect")]
            public static extern void WebViewContextMenuCustomizedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_new_WebViewContextMenuItemSelectedSignal_ContextMenuItemSelected")]
            public static extern global::System.IntPtr NewWebViewContextMenuItemSelectedSignalContextMenuItemSelected(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_delete_WebViewContextMenuItemSelectedSignal")]
            public static extern void DeleteWebViewContextMenuItemSelectedSignal(global::System.Runtime.InteropServices.HandleRef jarg1);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewContextMenuItemSelectedSignal_Connect")]
            public static extern void WebViewContextMenuItemSelectedSignalConnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);

            [global::System.Runtime.InteropServices.DllImport(NDalicPINVOKE.Lib, EntryPoint = "CSharp_Dali_WebViewContextMenuItemSelectedSignal_Disconnect")]
            public static extern void WebViewContextMenuItemSelectedSignalDisconnect(global::System.Runtime.InteropServices.HandleRef jarg1, global::System.Runtime.InteropServices.HandleRef jarg2);
        }
    }
}
