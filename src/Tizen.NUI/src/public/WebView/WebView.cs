/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd.
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

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Tizen.NUI;
using Tizen.NUI.Binding;

namespace Tizen.NUI.BaseComponents
{
    /// <summary>
    /// WebView allows presenting content with embedded web browser, both local files and remote websites.
    /// </summary>
    /// <since_tizen> 9 </since_tizen>
    public partial class WebView : View
    {
        static WebView()
        {
            if(NUIApplication.IsUsingXaml)
            {
                UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(WebView), string.Empty, propertyChanged: SetInternalUrlProperty, defaultValueCreator: GetInternalUrlProperty);

                UserAgentProperty = BindableProperty.Create(nameof(UserAgent), typeof(string), typeof(WebView), string.Empty, propertyChanged: SetInternalUserAgentProperty, defaultValueCreator: GetInternalUserAgentProperty);

                ScrollPositionProperty = BindableProperty.Create(nameof(ScrollPosition), typeof(Vector2), typeof(WebView), null, propertyChanged: SetInternalScrollPositionProperty, defaultValueCreator: GetInternalScrollPositionProperty);

                ScrollSizeProperty = BindableProperty.Create(nameof(ScrollSize), typeof(Vector2), typeof(WebView), null, defaultValueCreator: GetInternalScrollSizeProperty);

                ContentSizeProperty = BindableProperty.Create(nameof(ContentSize), typeof(Vector2), typeof(WebView), null, defaultValueCreator: GetInternalContentSizeProperty);

                TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(WebView), string.Empty, defaultValueCreator: GetInternalTitleProperty);

                VideoHoleEnabledProperty = BindableProperty.Create(nameof(VideoHoleEnabled), typeof(bool), typeof(WebView), true, propertyChanged: SetInternalVideoHoleEnabledProperty, defaultValueCreator: GetInternalVideoHoleEnabledProperty);

                MouseEventsEnabledProperty = BindableProperty.Create(nameof(MouseEventsEnabled), typeof(bool), typeof(WebView), true, propertyChanged: SetInternalMouseEventsEnabledProperty, defaultValueCreator: GetInternalMouseEventsEnabledProperty);

                KeyEventsEnabledProperty = BindableProperty.Create(nameof(KeyEventsEnabled), typeof(bool), typeof(WebView), true, propertyChanged: SetInternalKeyEventsEnabledProperty, defaultValueCreator: GetInternalKeyEventsEnabledProperty);

                ContentBackgroundColorProperty = BindableProperty.Create(nameof(ContentBackgroundColor), typeof(Color), typeof(WebView), null, propertyChanged: SetInternalContentBackgroundColorProperty, defaultValueCreator: GetInternalContentBackgroundColorProperty);

                TilesClearedWhenHiddenProperty = BindableProperty.Create(nameof(TilesClearedWhenHidden), typeof(bool), typeof(WebView), true, propertyChanged: SetInternalTilesClearedWhenHiddenProperty, defaultValueCreator: GetInternalTilesClearedWhenHiddenProperty);

                TileCoverAreaMultiplierProperty = BindableProperty.Create(nameof(TileCoverAreaMultiplier), typeof(float), typeof(WebView), 0.0f, propertyChanged: SetInternalTileCoverAreaMultiplierProperty, defaultValueCreator: GetInternalTileCoverAreaMultiplierProperty);

                CursorEnabledByClientProperty = BindableProperty.Create(nameof(CursorEnabledByClient), typeof(bool), typeof(WebView), true, propertyChanged: SetInternalCursorEnabledByClientProperty, defaultValueCreator: GetInternalCursorEnabledByClientProperty);

                SelectedTextProperty = BindableProperty.Create(nameof(SelectedText), typeof(string), typeof(WebView), string.Empty, defaultValueCreator: GetInternalSelectedTextProperty);

                PageZoomFactorProperty = BindableProperty.Create(nameof(PageZoomFactor), typeof(float), typeof(WebView), 0.0f, propertyChanged: SetInternalPageZoomFactorProperty, defaultValueCreator: GetInternalPageZoomFactorProperty);

                TextZoomFactorProperty = BindableProperty.Create(nameof(TextZoomFactor), typeof(float), typeof(WebView), 0.0f, propertyChanged: SetInternalTextZoomFactorProperty, defaultValueCreator: GetInternalTextZoomFactorProperty);

                LoadProgressPercentageProperty = BindableProperty.Create(nameof(LoadProgressPercentage), typeof(float), typeof(WebView), 0.0f, defaultValueCreator: GetInternalLoadProgressPercentageProperty);

                CacheModelProperty = BindableProperty.Create(nameof(CacheModel), typeof(CacheModel), typeof(WebView), default(CacheModel), propertyChanged: SetInternalCacheModelProperty, defaultValueCreator: GetInternalCacheModelProperty);

                CookieAcceptPolicyProperty = BindableProperty.Create(nameof(CookieAcceptPolicy), typeof(CookieAcceptPolicy), typeof(WebView), default(CookieAcceptPolicy), propertyChanged: SetInternalCookieAcceptPolicyProperty, defaultValueCreator: GetInternalCookieAcceptPolicyProperty);

                EnableJavaScriptProperty = BindableProperty.Create(nameof(EnableJavaScript), typeof(bool), typeof(WebView), false, propertyChanged: SetInternalEnableJavaScriptProperty, defaultValueCreator: GetInternalEnableJavaScriptProperty);

                LoadImagesAutomaticallyProperty = BindableProperty.Create(nameof(LoadImagesAutomatically), typeof(bool), typeof(WebView), false, propertyChanged: SetInternalLoadImagesAutomaticallyProperty, defaultValueCreator: GetInternalLoadImagesAutomaticallyProperty);

                DefaultTextEncodingNameProperty = BindableProperty.Create(nameof(DefaultTextEncodingName), typeof(string), typeof(WebView), string.Empty, propertyChanged: SetInternalDefaultTextEncodingNameProperty, defaultValueCreator: GetInternalDefaultTextEncodingNameProperty);

                DefaultFontSizeProperty = BindableProperty.Create(nameof(DefaultFontSize), typeof(int), typeof(WebView), 0, propertyChanged: SetInternalDefaultFontSizeProperty, defaultValueCreator: GetInternalDefaultFontSizeProperty);

            }
        }

        private Color contentBackgroundColor;
        private bool tilesClearedWhenHidden;
        private float tileCoverAreaMultiplier;
        private bool cursorEnabledByClient;

        private EventHandler<WebViewPageLoadEventArgs> pageLoadStartedEventHandler;
        private WebViewPageLoadCallback pageLoadStartedCallback;

        private EventHandler<WebViewPageLoadEventArgs> pageLoadingEventHandler;
        private WebViewPageLoadCallback pageLoadingCallback;

        private EventHandler<WebViewPageLoadEventArgs> pageLoadFinishedEventHandler;
        private WebViewPageLoadCallback pageLoadFinishedCallback;

        private EventHandler<WebViewPageLoadErrorEventArgs> pageLoadErrorEventHandler;
        private WebViewPageLoadErrorCallback pageLoadErrorCallback;

        private EventHandler<WebViewScrollEdgeReachedEventArgs> scrollEdgeReachedEventHandler;
        private WebViewScrollEdgeReachedCallback scrollEdgeReachedCallback;

        private EventHandler<WebViewOverScrolledEventArgs> overScrolledEventHandler;
        private WebViewOverScrolledCallback overScrolledCallback;

        private EventHandler<WebViewUrlChangedEventArgs> urlChangedEventHandler;
        private WebViewUrlChangedCallback urlChangedCallback;

        private EventHandler<WebViewFormRepostPolicyDecidedEventArgs> formRepostPolicyDecidedEventHandler;
        private WebViewFormRepostPolicyDecidedCallback formRepostPolicyDecidedCallback;

        private EventHandler<EventArgs> frameRenderedEventHandler;
        private WebViewFrameRenderedCallback frameRenderedCallback;

        private ScreenshotAcquiredCallback screenshotAcquiredCallback;
        private readonly WebViewScreenshotAcquiredProxyCallback screenshotAcquiredProxyCallback;

        private HitTestFinishedCallback hitTestFinishedCallback;
        private readonly WebViewHitTestFinishedProxyCallback hitTestFinishedProxyCallback;

        private EventHandler<WebViewPolicyDecidedEventArgs> responsePolicyDecidedEventHandler;
        private WebViewPolicyDecidedCallback responsePolicyDecidedCallback;

        private EventHandler<WebViewPolicyDecidedEventArgs> navigationPolicyDecidedEventHandler;
        private WebViewPolicyDecidedCallback navigationPolicyDecidedCallback;

        private EventHandler<WebViewPolicyDecidedEventArgs> newWindowPolicyDecidedEventHandler;
        private WebViewPolicyDecidedCallback newWindowPolicyDecidedCallback;

        private EventHandlerWithReturnType<object, EventArgs, WebView> newWindowCreatedEventHandler;
        private WebViewNewWindowCreatedCallback newWindowCreatedCallback;

        private EventHandler<WebViewCertificateReceivedEventArgs> certificateConfirmedEventHandler;
        private WebViewCertificateReceivedCallback certificateConfirmedCallback;

        private EventHandler<WebViewCertificateReceivedEventArgs> sslCertificateChangedEventHandler;
        private WebViewCertificateReceivedCallback sslCertificateChangedCallback;

        private EventHandler<WebViewHttpAuthRequestedEventArgs> httpAuthRequestedEventHandler;
        private WebViewHttpAuthRequestedCallback httpAuthRequestedCallback;

        private EventHandler<WebViewConsoleMessageReceivedEventArgs> consoleMessageReceivedEventHandler;
        private WebViewConsoleMessageReceivedCallback consoleMessageReceivedCallback;

        private EventHandler<WebViewContextMenuShownEventArgs> contextMenuShownEventHandler;
        private WebViewContextMenuShownCallback contextMenuShownCallback;

        private EventHandler<WebViewContextMenuHiddenEventArgs> contextMenuHiddenEventHandler;
        private WebViewContextMenuHiddenCallback contextMenuHiddenCallback;

        private EventHandler<EventArgs> fullscreenEnteredEventHandler;
        private WebViewFullscreenEnteredCallback fullscreenEnteredCallback;

        private EventHandler<EventArgs> fullscreenExitedEventHandler;
        private WebViewFullscreenExitedCallback fullscreenExitedCallback;

        private EventHandler<WebViewTextFoundEventArgs> textFoundEventHandler;
        private WebViewTextFoundCallback textFoundCallback;

        private PlainTextReceivedCallback plainTextReceivedCallback;

        private EventHandler<WebViewWebAuthDisplayQREventArgs> webAuthDisplayQREventHandler;
        private WebViewWebAuthDisplayQRCallback webAuthDisplayQRCallback;
        private EventHandler webAuthResponseEventHandler;
        private WebViewWebAuthResponseCallback webAuthResponseCallback;

        private EventHandler<WebViewUserMediaPermissionRequestEventArgs> userMediaPermissionRequestEventHandler;
        private WebViewUserMediaPermissionRequestCallback userMediaPermissionRequestCallback;

        private WebContext webContext;
        private WebCookieManager webCookieManager;

        private EventHandler<WebViewDeviceConnectionChangedEventArgs> deviceConnectionChangedEventHandler;
        private webViewDeviceConnectionChangedCallback deviceConnectionChangedCallback;

        /// <summary>
        /// Default constructor to create a WebView.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public WebView() : this(Interop.WebView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a WebView with locale and time-zone.
        /// </summary>
        /// <param name="locale">The specified locale</param>
        /// <param name="timezoneId">The specified time-zone ID</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string locale, string timezoneId) : this(Interop.WebView.New2(locale, timezoneId), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a WebView with an args list.
        /// </summary>
        /// <param name="args">Arguments passed into web engine. The first value of array must be program's name.</param>
        /// <since_tizen> 9 </since_tizen>
        public WebView(string[] args) : this(Interop.WebView.New3(args?.Length ?? 0, args), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a WebView with an args list and WebEngine type.
        /// </summary>
        /// <param name="args">Arguments passed into web engine. The first value of array must be program's name.</param>
        /// <param name="webEngineType">Can select the plugin of Web Engine type. Chromium or LWE.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string[] args, WebEngineType webEngineType) : this(Interop.WebView.New4(args?.Length ?? 0, args, (int)webEngineType), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// </summary>
        /// <param name="webView">WebView to copy. The copied WebView will point at the same implementation</param>
        /// <since_tizen> 9 </since_tizen>
        public WebView(WebView webView) : this(Interop.WebView.NewWebView(WebView.getCPtr(webView)), true, false)
        {
            // TODO : Please deprecate this API.
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn) : this(cPtr, cMemoryOwn, cMemoryOwn)
        {
        }

        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn, bool cRegister) : base(Interop.WebView.Upcast(cPtr), cMemoryOwn, true, cRegister)
        {
            screenshotAcquiredProxyCallback = OnScreenshotAcquired;
            hitTestFinishedProxyCallback = OnHitTestFinished;

            BackForwardList = new WebBackForwardList(Interop.WebView.GetWebBackForwardList(SwigCPtr), false);
            Settings = new WebSettings(Interop.WebView.GetWebSettings(SwigCPtr), false);
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (Disposed)
            {
                return;
            }

            if (webContext != null)
            {
                webContext.RegisterDownloadStartedCallback(null);
                webContext.RegisterMimeOverriddenCallback(null);
                webContext.RegisterHttpRequestInterceptedCallback(null);
                webContext.Dispose();
                webContext = null;
            }

            if (webCookieManager != null)
            {
                webCookieManager.Dispose();
                webCookieManager = null;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.

               if(handlerRootMap != null)
                {
                    foreach (string key in handlerRootMap?.Keys)
                    {
                        Interop.WebView.AddJavaScriptMessageHandler(SwigCPtr, key, new HandleRef(null, IntPtr.Zero));
                    }
                    handlerRootMap?.Clear();
                    handlerRootMap = null;
                }

                if(_addJavaScriptEntireMessageHandlerMap != null)
                {
                    foreach (string key in _addJavaScriptEntireMessageHandlerMap?.Keys)
                    {
                        Interop.WebView.AddJavaScriptEntireMessageHandler(SwigCPtr, key, new HandleRef(null, IntPtr.Zero));
                    }
                    _addJavaScriptEntireMessageHandlerMap?.Clear();
                    _addJavaScriptEntireMessageHandlerMap = null;
                }

                BackForwardList.Dispose();
                Settings.Dispose();
            }

            base.Dispose(type);
        }

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebView.DeleteWebView(swigCPtr);
        }

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptMessageHandler(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptEntireMessageHandler(string messageName, string messageBody);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptAlertCallback(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptConfirmCallback(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptPromptCallback(string message1, string message2);

        /// <summary>
        /// The callback function that is invoked when screen shot is acquired asynchronously.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ScreenshotAcquiredCallback(ImageView image);

        /// <summary>
        /// The callback function that is invoked when video playing is checked asynchronously.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void VideoPlayingCallback(bool isPlaying);

        /// <summary>
        /// The callback function that is invoked when geolocation permission is requested.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GeolocationPermissionCallback(string host, string protocol);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void UserMediaPermissionCallback(IntPtr permission);

        /// <summary>
        /// The callback function that is invoked when hit test is finished.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void HitTestFinishedCallback(WebHitTestResult test);

        /// <summary>
        /// The callback function that is invoked when the plain text of the current page is received.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void PlainTextReceivedCallback(string plainText);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewPageLoadCallback(string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewPageLoadErrorCallback(IntPtr error);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewScrollEdgeReachedCallback(int edge);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewOverScrolledCallback(int overscrolled);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewUrlChangedCallback(string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewFormRepostPolicyDecidedCallback(IntPtr maker);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewFrameRenderedCallback();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewScreenshotAcquiredProxyCallback(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewHitTestFinishedProxyCallback(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewPolicyDecidedCallback(IntPtr maker);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewNewWindowCreatedCallback(out IntPtr outView);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewCertificateReceivedCallback(IntPtr certificate);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewHttpAuthRequestedCallback(IntPtr handler);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewConsoleMessageReceivedCallback(IntPtr message);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewContextMenuShownCallback(IntPtr menu);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewContextMenuHiddenCallback(IntPtr menu);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewFullscreenEnteredCallback();

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewFullscreenExitedCallback();

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewTextFoundCallback(uint count);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewWebAuthDisplayQRCallback(string contents);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewWebAuthResponseCallback();

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void WebViewUserMediaPermissionRequestCallback(IntPtr permission, string message);
       
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void webViewDeviceConnectionChangedCallback(int deviceType);

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        private delegate void internalWebViewDeviceListGetCallback(IntPtr list, int size);
        private internalWebViewDeviceListGetCallback internalDeviceListGetCallback;

        /// <summary>
        /// The callback to receive the list of currently connected devices
        /// </summary>
        /// <param name="list">the list of currently connected devices</param>
        /// <param name="size">the number of currently connected devices</param>
        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void WebViewDeviceListGetCallback(WebDeviceList list, int size);
        private WebViewDeviceListGetCallback deviceListGetCallbackForUser;

        /// <summary>
        /// Event for the PageLoadStarted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has started.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebViewPageLoadEventArgs> PageLoadStarted
        {
            add
            {
                if (pageLoadStartedEventHandler == null)
                {
                    pageLoadStartedCallback = OnPageLoadStarted;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(pageLoadStartedCallback);
                    Interop.WebView.RegisterPageLoadStartedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                pageLoadStartedEventHandler += value;
            }
            remove
            {
                pageLoadStartedEventHandler -= value;
                if (pageLoadStartedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterPageLoadStartedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the PageLoading signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading is in progress.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebViewPageLoadEventArgs> PageLoading
        {
            add
            {
                if (pageLoadingEventHandler == null)
                {
                    pageLoadingCallback = OnPageLoading;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(pageLoadingCallback);
                    Interop.WebView.RegisterPageLoadInProgressCallback(SwigCPtr, new HandleRef(this, ip));
                }
                pageLoadingEventHandler += value;
            }
            remove
            {
                pageLoadingEventHandler -= value;
                if (pageLoadingEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterPageLoadInProgressCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the PageLoadFinished signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has finished.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebViewPageLoadEventArgs> PageLoadFinished
        {
            add
            {
                if (pageLoadFinishedEventHandler == null)
                {
                    pageLoadFinishedCallback = (OnPageLoadFinished);
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(pageLoadFinishedCallback);
                    Interop.WebView.RegisterPageLoadFinishedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                pageLoadFinishedEventHandler += value;
            }
            remove
            {
                pageLoadFinishedEventHandler -= value;
                if (pageLoadFinishedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterPageLoadFinishedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the PageLoadError signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when there's an error in page loading.<br />
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public event EventHandler<WebViewPageLoadErrorEventArgs> PageLoadError
        {
            add
            {
                if (pageLoadErrorEventHandler == null)
                {
                    pageLoadErrorCallback = OnPageLoadError;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(pageLoadErrorCallback);
                    Interop.WebView.RegisterPageLoadErrorCallback(SwigCPtr, new HandleRef(this, ip));
                }
                pageLoadErrorEventHandler += value;
            }
            remove
            {
                pageLoadErrorEventHandler -= value;
                if (pageLoadErrorEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterPageLoadErrorCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the ScrollEdgeReached signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when web view is scrolled to edge.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewScrollEdgeReachedEventArgs> ScrollEdgeReached
        {
            add
            {
                if (scrollEdgeReachedEventHandler == null)
                {
                    scrollEdgeReachedCallback = OnScrollEdgeReached;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(scrollEdgeReachedCallback);
                    Interop.WebView.RegisterScrollEdgeReachedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                scrollEdgeReachedEventHandler += value;
            }
            remove
            {
                scrollEdgeReachedEventHandler -= value;
                if (scrollEdgeReachedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterScrollEdgeReachedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the OverScrolled signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when web view is over scrolled.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewOverScrolledEventArgs> OverScrolled
        {
            add
            {
                if (overScrolledEventHandler == null)
                {
                    overScrolledCallback = OnOverScrolled;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(overScrolledCallback);
                    Interop.WebView.RegisterOverScrolledCallback(SwigCPtr, new HandleRef(this, ip));
                }
                overScrolledEventHandler += value;
            }
            remove
            {
                overScrolledEventHandler -= value;
                if (overScrolledEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterOverScrolledCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the UrlChanged signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when url is changed.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewUrlChangedEventArgs> UrlChanged
        {
            add
            {
                if (urlChangedEventHandler == null)
                {
                    urlChangedCallback = OnUrlChanged;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(urlChangedCallback);
                    Interop.WebView.RegisterUrlChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                urlChangedEventHandler += value;
            }
            remove
            {
                urlChangedEventHandler -= value;
                if (urlChangedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterUrlChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the FormRepostDecided signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when form repost policy would be decided.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewFormRepostPolicyDecidedEventArgs> FormRepostPolicyDecided
        {
            add
            {
                if (formRepostPolicyDecidedEventHandler == null)
                {
                    formRepostPolicyDecidedCallback = OnFormRepostPolicyDecided;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(formRepostPolicyDecidedCallback);
                    Interop.WebView.RegisterFormRepostDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                formRepostPolicyDecidedEventHandler += value;
            }
            remove
            {
                formRepostPolicyDecidedEventHandler -= value;
                if (formRepostPolicyDecidedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterFormRepostDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the FrameRendered signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when frame is rendered off-screen.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> FrameRendered
        {
            add
            {
                if (frameRenderedEventHandler == null)
                {
                    frameRenderedCallback = OnFrameRendered;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(frameRenderedCallback);
                    Interop.WebView.RegisterFrameRenderedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                frameRenderedEventHandler += value;
            }
            remove
            {
                frameRenderedEventHandler -= value;
                if (frameRenderedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterFrameRenderedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the ResponsePolicyDecided signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when response policy would be decided.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPolicyDecidedEventArgs> ResponsePolicyDecided
        {
            add
            {
                if (responsePolicyDecidedEventHandler == null)
                {
                    responsePolicyDecidedCallback = OnResponsePolicyDecided;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(responsePolicyDecidedCallback);
                    Interop.WebView.RegisterResponsePolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                responsePolicyDecidedEventHandler += value;
            }
            remove
            {
                responsePolicyDecidedEventHandler -= value;
                if (responsePolicyDecidedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterResponsePolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the NavigationPolicyDecided signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when response policy would be decided.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPolicyDecidedEventArgs> NavigationPolicyDecided
        {
            add
            {
                if (navigationPolicyDecidedEventHandler == null)
                {
                    navigationPolicyDecidedCallback = OnNavigationPolicyDecided;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(navigationPolicyDecidedCallback);
                    Interop.WebView.RegisterNavigationPolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                navigationPolicyDecidedEventHandler += value;
            }
            remove
            {
                navigationPolicyDecidedEventHandler -= value;
                if (navigationPolicyDecidedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterNavigationPolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the NewWindowPolicyDecided signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when new window policy would be decided.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPolicyDecidedEventArgs> NewWindowPolicyDecided
        {
            add
            {
                if (newWindowPolicyDecidedEventHandler == null)
                {
                    newWindowPolicyDecidedCallback = OnNewWindowPolicyDecided;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(newWindowPolicyDecidedCallback);
                    Interop.WebView.RegisterNewWindowPolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                newWindowPolicyDecidedEventHandler += value;
            }
            remove
            {
                newWindowPolicyDecidedEventHandler -= value;
                if (newWindowPolicyDecidedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterNewWindowPolicyDecidedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the NewWindowCreated signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when a new window would be created.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandlerWithReturnType<object, EventArgs, WebView> NewWindowCreated
        {
            add
            {
                if (newWindowCreatedEventHandler == null)
                {
                    newWindowCreatedCallback = OnNewWindowCreated;
                    System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(newWindowCreatedCallback);
                    Interop.WebView.RegisterNewWindowCreatedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                newWindowCreatedEventHandler += value;
            }
            remove
            {
                newWindowCreatedEventHandler -= value;
                if (newWindowCreatedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterNewWindowCreatedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the CertificateConfirmed signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when certificate would be confirmed.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewCertificateReceivedEventArgs> CertificateConfirmed
        {
            add
            {
                if (certificateConfirmedEventHandler == null)
                {
                    certificateConfirmedCallback = OnCertificateConfirmed;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(certificateConfirmedCallback);
                    Interop.WebView.RegisterCertificateConfirmedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                certificateConfirmedEventHandler += value;
            }
            remove
            {
                certificateConfirmedEventHandler -= value;
                if (certificateConfirmedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterCertificateConfirmedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the SslCertificateChanged signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when SSL certificate is changed.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewCertificateReceivedEventArgs> SslCertificateChanged
        {
            add
            {
                if (sslCertificateChangedEventHandler == null)
                {
                    sslCertificateChangedCallback = OnSslCertificateChanged;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(sslCertificateChangedCallback);
                    Interop.WebView.RegisterSslCertificateChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                sslCertificateChangedEventHandler += value;
            }
            remove
            {
                sslCertificateChangedEventHandler -= value;
                if (sslCertificateChangedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterSslCertificateChangedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the HttpAuthRequested signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when http authentication is requested.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewHttpAuthRequestedEventArgs> HttpAuthRequested
        {
            add
            {
                if (httpAuthRequestedEventHandler == null)
                {
                    httpAuthRequestedCallback = OnHttpAuthRequested;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(httpAuthRequestedCallback);
                    Interop.WebView.RegisterHttpAuthHandlerCallback(SwigCPtr, new HandleRef(this, ip));
                }
                httpAuthRequestedEventHandler += value;
            }
            remove
            {
                httpAuthRequestedEventHandler -= value;
                if (httpAuthRequestedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterHttpAuthHandlerCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the ConsoleMessageReceived signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when console message is received.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewConsoleMessageReceivedEventArgs> ConsoleMessageReceived
        {
            add
            {
                if (consoleMessageReceivedEventHandler == null)
                {
                    consoleMessageReceivedCallback = OnConsoleMessageReceived;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(consoleMessageReceivedCallback);
                    Interop.WebView.RegisterConsoleMessageReceivedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                consoleMessageReceivedEventHandler += value;
            }
            remove
            {
                consoleMessageReceivedEventHandler -= value;
                if (consoleMessageReceivedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterConsoleMessageReceivedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the ContextMenuShown signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when context menu is shown.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewContextMenuShownEventArgs> ContextMenuShown
        {
            add
            {
                if (contextMenuShownEventHandler == null)
                {
                    contextMenuShownCallback = OnContextMenuShown;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(contextMenuShownCallback);
                    Interop.WebView.RegisterContextMenuShownCallback(SwigCPtr, new HandleRef(this, ip));
                }
                contextMenuShownEventHandler += value;
            }
            remove
            {
                contextMenuShownEventHandler -= value;
                if (contextMenuShownEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterContextMenuShownCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the ContextMenuHidden signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when context menu item is hidden.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewContextMenuHiddenEventArgs> ContextMenuHidden
        {
            add
            {
                if (contextMenuHiddenEventHandler == null)
                {
                    contextMenuHiddenCallback = OnContextMenuHidden;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(contextMenuHiddenCallback);
                    Interop.WebView.RegisterContextMenuHiddenCallback(SwigCPtr, new HandleRef(this, ip));
                }
                contextMenuHiddenEventHandler += value;
            }
            remove
            {
                contextMenuHiddenEventHandler -= value;
                if (contextMenuHiddenEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterContextMenuHiddenCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the FullscreenEntered signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when fullscreen is entered.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> FullscreenEntered
        {
            add
            {
                if (fullscreenEnteredEventHandler == null)
                {
                    fullscreenEnteredCallback = OnFullscreenEntered;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(fullscreenEnteredCallback);
                    Interop.WebView.RegisterFullscreenEnteredCallback(SwigCPtr, new HandleRef(this, ip));
                }
                fullscreenEnteredEventHandler += value;
            }
            remove
            {
                fullscreenEnteredEventHandler -= value;
                if (fullscreenEnteredEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterFullscreenEnteredCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the FullscreenExited signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when fullscreen is exited.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<EventArgs> FullscreenExited
        {
            add
            {
                if (fullscreenExitedEventHandler == null)
                {
                    fullscreenExitedCallback = OnFullscreenExited;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(fullscreenExitedCallback);
                    Interop.WebView.RegisterFullscreenExitedCallback(SwigCPtr, new HandleRef(this, ip));
                }
                fullscreenExitedEventHandler += value;
            }
            remove
            {
                fullscreenExitedEventHandler -= value;
                if (fullscreenExitedEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterFullscreenExitedCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event for the TextFound signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when text is found.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewTextFoundEventArgs> TextFound
        {
            add
            {
                if (textFoundEventHandler == null)
                {
                    textFoundCallback = OnTextFound;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(textFoundCallback);
                    Interop.WebView.RegisterTextFoundCallback(SwigCPtr, new HandleRef(this, ip));
                }
                textFoundEventHandler += value;
            }
            remove
            {
                textFoundEventHandler -= value;
                if (textFoundEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterTextFoundCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event to informs user application to display QR code popup for passkey scenario.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewWebAuthDisplayQREventArgs> WebAuthDisplayQR
        {
            add
            {
                if (webAuthDisplayQREventHandler == null)
                {
                    webAuthDisplayQRCallback = OnWebAuthDisplayQR;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(webAuthDisplayQRCallback);
                    Interop.WebView.RegisterWebAuthDisplayQRCallback(SwigCPtr, new HandleRef(this, ip));
                }
                webAuthDisplayQREventHandler += value;
            }
            remove
            {
                webAuthDisplayQREventHandler -= value;
                if (webAuthDisplayQREventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterWebAuthDisplayQRCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// Event to informs user application that the passkey registration and authentication has been successful.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler WebAuthResponse
        {
            add
            {
                if (webAuthResponseEventHandler == null)
                {
                    webAuthResponseCallback = OnWebAuthResponse;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(webAuthResponseCallback);
                    Interop.WebView.RegisterWebAuthResponseCallback(SwigCPtr, new HandleRef(this, ip));
                }
                webAuthResponseEventHandler += value;
            }
            remove
            {
                webAuthResponseEventHandler -= value;
                if (webAuthResponseEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterWebAuthResponseCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }


        /// <summary>
        /// Event to UserMediaPermissionRequest.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewUserMediaPermissionRequestEventArgs> UserMediaPermissionRequest
        {
            add
            {
                if (userMediaPermissionRequestEventHandler == null)
                {
                    userMediaPermissionRequestCallback = OnUserMediaPermissionRequset;
                    IntPtr ip = Marshal.GetFunctionPointerForDelegate(userMediaPermissionRequestCallback);
                    Interop.WebView.RegisterUserMediaPermissionRequestCallback(SwigCPtr, new HandleRef(this, ip));
                }
                userMediaPermissionRequestEventHandler += value;
            }
            remove
            {
                userMediaPermissionRequestEventHandler -= value;
                if (userMediaPermissionRequestEventHandler == null)
                {
                    IntPtr ip = IntPtr.Zero;
                    Interop.WebView.RegisterUserMediaPermissionRequestCallback(SwigCPtr, new HandleRef(this, ip));
                }
            }
        }

        /// <summary>
        /// This event is triggered when the connected devices change, such as when a new device is connected or an already connected device is disconnected
        /// </summary>
        /// <remarks>
        /// In the handler of this event, you can set the callback method in the SetDeviceListGetCallback method to receive the list of currently connected devices
        /// </remarks>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewDeviceConnectionChangedEventArgs> DeviceConnectionChanged
        {
            add
            {
                if (deviceConnectionChangedEventHandler == null)
                {
                    deviceConnectionChangedCallback = OnDeviceConnectionChanged;
                    Interop.WebView.RegisterDeviceConnectionChangedCallback(SwigCPtr, Marshal.GetFunctionPointerForDelegate(deviceConnectionChangedCallback));
                }
                deviceConnectionChangedEventHandler += value;
            }
            remove
            {
                deviceConnectionChangedEventHandler -= value;
                if (deviceConnectionChangedEventHandler == null)
                {
                    Interop.WebView.RegisterDeviceConnectionChangedCallback(SwigCPtr, IntPtr.Zero);
                }
            }
        }

        /// <summary>
        /// Set a callback method in this method to receive the list of currently connected devices
        /// </summary>
        /// <param name="callback">The callback to get the device list</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetDeviceListGetCallback(WebViewDeviceListGetCallback callback)
        {
            deviceListGetCallbackForUser = callback;
            internalDeviceListGetCallback ??= deviceListGet;
            Interop.WebView.RegisterDeviceListGetCallback(SwigCPtr, Marshal.GetFunctionPointerForDelegate(internalDeviceListGetCallback));
        }

        private void deviceListGet(IntPtr list, int size)
        {
            deviceListGetCallbackForUser?.Invoke(new WebDeviceList(list, true), size);
        }

        /// <summary>
        /// Options for searching texts.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum FindOption
        {
            /// <summary>
            /// No search flags
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            None = 0,

            /// <summary>
            /// Case insensitive search
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            CaseInsensitive = 1 << 0,

            /// <summary>
            /// Search text only at the beginning of the words
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            AtWordStart = 1 << 1,

            /// <summary>
            /// Treat capital letters in the middle of words as word start
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TreatMediaCapitalAsWordStart = 1 << 2,

            /// <summary>
            /// Search backwards
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Backwards = 1 << 3,

            /// <summary>
            /// If not present the search stops at the end of the document
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            WrapAround = 1 << 4,

            /// <summary>
            /// Show overlay
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ShowOverlay = 1 << 5,

            /// <summary>
            /// Show indicator
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ShowFindIndiator = 1 << 6,

            /// <summary>
            /// Show highlight
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ShowHighlight = 1 << 7,
        }

        /// <summary>
        /// Enumeration for mode of hit test.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum HitTestMode
        {
            /// <summary>
            /// Link data
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Default = 1 << 1,

            /// <summary>
            /// Extra node data(tag name, node value, attribute infomation, etc).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            NodeData = 1 << 2,

            /// <summary>
            /// Extra image data(image data, image data length, image file name exteionsion, etc).
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            ImageData = 1 << 3,

            /// <summary>
            /// All data
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            All = Default | NodeData | ImageData,
        }

        /// <summary>
        /// WebEngine type which can be set by a specific constructor of this WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum WebEngineType
        {
            /// <summary>
            /// Depend on environement value setting. (default)
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            UseSystemSetting = -1,

            /// <summary>
            /// Chromium Web Engine type.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            Chromium = 0,

            /// <summary>
            /// LWE, Light Web Engine type.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            LWE = 1,
        }

        /// <summary>
        /// IME alignment in web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public enum ImeAlignment
        {
            /// <summary>
            /// Top-left corner.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TopLeft = 0,

            /// <summary>
            /// top-center position.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TopCenter,

            /// <summary>
            /// Top-right corner.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            TopRight,

            /// <summary>
            /// Middle-left position.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MiddleLeft,

            /// <summary>
            /// Middle-center position.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MiddleCenter,

            /// <summary>
            /// Middle-right position.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            MiddleRight,

            /// <summary>
            /// Bottom-left corner.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            BottomLeft,

            /// <summary>
            /// Bottom-center position.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            BottomCenter,

            /// <summary>
            /// Bottom-right corner.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            BottomRight,
        }

        /// <summary>
        /// Context.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContext Context
        {
            get
            {
                webContext ??= new WebContext(Interop.WebView.GetWebContext(), false);
                return webContext;
            }
        }

        /// <summary>
        /// CookieManager.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebCookieManager CookieManager
        {
            get
            {
                webCookieManager ??= new WebCookieManager(Interop.WebView.GetWebCookieManager(), false);
                return webCookieManager;
            }
        }

        /// <summary>
        /// BackForwardList.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardList BackForwardList { get; }

        /// <summary>
        /// BackForwardList.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebSettings Settings { get; }

        /// <summary>
        /// The URL to load.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Url
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(UrlProperty);
                }
                else
                {
                    return GetInternalUrl();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UrlProperty, value);
                }
                else
                {
                    SetInternalUrl(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUrl(string newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.Url, pv);
            }
        }

        private string GetInternalUrl()
        {
            string temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.Url);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Deprecated. The cache model of the current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheModel CacheModel
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (CacheModel)GetValue(CacheModelProperty);
                }
                else
                {
                    return InternalCacheModel;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CacheModelProperty, value);
                }
                else
                {
                    InternalCacheModel = value;
                }
                NotifyPropertyChanged();
            }
        }

        private CacheModel InternalCacheModel
        {
            get
            {
                return (CacheModel)Context.CacheModel;
            }
            set
            {
                Context.CacheModel = (WebContext.CacheModelType)value;
            }
        }

        /// <summary>
        /// Deprecated. The cookie acceptance policy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookieAcceptPolicy CookieAcceptPolicy
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (CookieAcceptPolicy)GetValue(CookieAcceptPolicyProperty);
                }
                else
                {
                    return InternalCookieAcceptPolicy;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CookieAcceptPolicyProperty, value);
                }
                else
                {
                    InternalCookieAcceptPolicy = value;
                }
                NotifyPropertyChanged();
            }
        }

        private CookieAcceptPolicy InternalCookieAcceptPolicy
        {
            get
            {
                return (CookieAcceptPolicy)CookieManager.CookieAcceptPolicy;
            }
            set
            {
                CookieManager.CookieAcceptPolicy = (WebCookieManager.CookieAcceptPolicyType)value;
            }
        }

        /// <summary>
        /// The user agent string.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string UserAgent
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(UserAgentProperty);
                }
                else
                {
                    return GetInternalUserAgent();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(UserAgentProperty, value);
                }
                else
                {
                    SetInternalUserAgent(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalUserAgent(string newValue)
        {
            if (newValue != null)
            {
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.UserAgent, pv);
            }
        }

        private string GetInternalUserAgent()
        {
            string temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.UserAgent);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Deprecated. Whether JavaScript is enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableJavaScript
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(EnableJavaScriptProperty);
                }
                else
                {
                    return InternalEnableJavaScript;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(EnableJavaScriptProperty, value);
                }
                else
                {
                    InternalEnableJavaScript = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalEnableJavaScript
        {
            get
            {
                return Settings.JavaScriptEnabled;
            }
            set
            {
                Settings.JavaScriptEnabled = value;
            }
        }

        /// <summary>
        /// Deprecated. Whether images can be loaded automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadImagesAutomatically
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(LoadImagesAutomaticallyProperty);
                }
                else
                {
                    return InternalLoadImagesAutomatically;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(LoadImagesAutomaticallyProperty, value);
                }
                else
                {
                    InternalLoadImagesAutomatically = value;
                }
                NotifyPropertyChanged();
            }
        }

        private bool InternalLoadImagesAutomatically
        {
            get
            {
                return Settings.AutomaticImageLoadingAllowed;
            }
            set
            {
                Settings.AutomaticImageLoadingAllowed = value;
            }
        }

        /// <summary>
        /// The default text encoding name.<br />
        /// e.g. "UTF-8"<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DefaultTextEncodingName
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(DefaultTextEncodingNameProperty) as string;
                }
                else
                {
                    return InternalDefaultTextEncodingName;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DefaultTextEncodingNameProperty, value);
                }
                else
                {
                    InternalDefaultTextEncodingName = value;
                }
                NotifyPropertyChanged();
            }
        }

        private string InternalDefaultTextEncodingName
        {
            get
            {
                return Settings.DefaultTextEncodingName;
            }
            set
            {
                Settings.DefaultTextEncodingName = value;
            }
        }

        /// <summary>
        /// The default font size in pixel.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public int DefaultFontSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (int)GetValue(DefaultFontSizeProperty);
                }
                else
                {
                    return InternalDefaultFontSize;
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(DefaultFontSizeProperty, value);
                }
                else
                {
                    InternalDefaultFontSize = value;
                }
                NotifyPropertyChanged();
            }
        }

        private int InternalDefaultFontSize
        {
            get
            {
                return Settings.DefaultFontSize;
            }
            set
            {
                Settings.DefaultFontSize = value;
            }
        }

        /// <summary>
        /// The position of scroll.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Position ScrollPosition
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return GetValue(ScrollPositionProperty) as Position;
                }
                else
                {
                    return GetInternalScrollPosition();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ScrollPositionProperty, value);
                }
                else
                {
                    SetInternalScrollPosition(value);
                }
            }
        }

        private void SetInternalScrollPosition(Position pos)
        {
            if (pos != null)
            {
                using var v2 = new Vector2(pos.X, pos.Y);
                using var pv = new PropertyValue(v2);
                Object.SetProperty(SwigCPtr, Property.ScrollPosition, pv);
            }
        }

        private Position GetInternalScrollPosition()
        {
            using Vector2 temp = new Vector2(0.0f, 0.0f);
            using var prop = Object.GetProperty(SwigCPtr, Property.ScrollPosition);
            prop.Get(temp);
            return new Position(temp.X, temp.Y);
        }

        /// <summary>
        /// The size of scroll, read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ScrollSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    Vector2 sv = (Vector2)GetValue(ScrollSizeProperty);
                    return new Size(sv.Width, sv.Height);
                }
                else
                {
                    using Vector2 sv = GetInternalScrollSize();
                    return new Size(sv.Width, sv.Height);
                }
            }
        }

        private Vector2 GetInternalScrollSize()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.ScrollSize))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// The size of content, read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ContentSize
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    Vector2 sv = (Vector2)GetValue(ContentSizeProperty);
                    return new Size(sv.Width, sv.Height);
                }
                else
                {
                    using Vector2 sv = GetInternalContentSize();
                    return new Size(sv.Width, sv.Height);
                }
            }
        }

        private Vector2 GetInternalContentSize()
        {
            Vector2 temp = new Vector2(0.0f, 0.0f);
            using (var prop = Object.GetProperty(SwigCPtr, Property.ContentSize))
            {
                prop.Get(temp);
            }
            return temp;
        }

        /// <summary>
        /// Whether video hole is enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool VideoHoleEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(VideoHoleEnabledProperty);
                }
                else
                {
                    return GetInternalVideoHoleEnabled();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(VideoHoleEnabledProperty, value);
                }
                else
                {
                    SetInternalVideoHoleEnabled(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalVideoHoleEnabled(bool newValue)
        {
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.VideoHoleEnabled, pv);
        }

        private bool GetInternalVideoHoleEnabled()
        {
            bool temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.VideoHoleEnabled);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Whether mouse events are enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MouseEventsEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(MouseEventsEnabledProperty);
                }
                else
                {
                     return GetInternalMouseEventsEnabled();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(MouseEventsEnabledProperty, value);
                }
                else
                {
                    SetInternalMouseEventsEnabled(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalMouseEventsEnabled(bool newValue)
        {
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.MouseEventsEnabled, pv);
        }

        private bool GetInternalMouseEventsEnabled()
        {
            bool temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.MouseEventsEnabled);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Whether key events are enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeyEventsEnabled
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(KeyEventsEnabledProperty);
                }
                else
                {
                    return GetInternalKeyEventsEnabled();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(KeyEventsEnabledProperty, value);
                }
                else
                {
                    SetInternalKeyEventsEnabled(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalKeyEventsEnabled(bool newValue)
        {
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.KeyEventsEnabled, pv);
        }

        private bool GetInternalKeyEventsEnabled()
        {
            bool temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.KeyEventsEnabled);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Background color of web page.
        /// Please note that it only works after LoadUrl, etc.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ContentBackgroundColor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (Color)GetValue(ContentBackgroundColorProperty);
                }
                else
                {
                    return GetInternalContentBackgroundColor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(ContentBackgroundColorProperty, value);
                }
                else
                {
                    SetInternalContentBackgroundColor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalContentBackgroundColor(Color newValue)
        {
            if (newValue != null)
            {
                contentBackgroundColor = newValue;
                using var pv = new PropertyValue(newValue);
                Object.SetProperty(SwigCPtr, Property.DocumentBackgroundColor, pv);
            }
        }

        private Color GetInternalContentBackgroundColor()
        {
            return contentBackgroundColor;
        }

        /// <summary>
        /// Whether tiles are cleared or not when hidden.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TilesClearedWhenHidden
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(TilesClearedWhenHiddenProperty);
                }
                else
                {
                    return GetInternalTilesClearedWhenHidden();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TilesClearedWhenHiddenProperty, value);
                }
                else
                {
                    SetInternalTilesClearedWhenHidden(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTilesClearedWhenHidden(bool newValue)
        {
            tilesClearedWhenHidden = newValue;
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.TilesClearedWhenHidden, pv);
        }

        private bool GetInternalTilesClearedWhenHidden()
        {
            return tilesClearedWhenHidden;
        }

        /// <summary>
        /// Multiplier of cover area of tile when web page is rendered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TileCoverAreaMultiplier
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(TileCoverAreaMultiplierProperty);
                }
                else
                {
                    return GetInternalTileCoverAreaMultiplier();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TileCoverAreaMultiplierProperty, value);
                }
                else
                {
                    SetInternalTileCoverAreaMultiplier(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTileCoverAreaMultiplier(float newValue)
        {
            tileCoverAreaMultiplier = newValue;
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.TileCoverAreaMultiplier, pv);
        }

        private float GetInternalTileCoverAreaMultiplier()
        {
            return tileCoverAreaMultiplier;
        }

        /// <summary>
        /// Whether cursor is enabled or not by client.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CursorEnabledByClient
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (bool)GetValue(CursorEnabledByClientProperty);
                }
                else
                {
                    return GetInternalCursorEnabledByClient();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(CursorEnabledByClientProperty, value);
                }
                else
                {
                    SetInternalCursorEnabledByClient(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalCursorEnabledByClient(bool newValue)
        {
            cursorEnabledByClient = newValue;
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.CursorEnabledByClient, pv);
        }

        private bool GetInternalCursorEnabledByClient()
        {
            return cursorEnabledByClient;
        }

        /// <summary>
        /// Gets selected text in web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectedText
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(SelectedTextProperty);
                }
                else
                {
                    return GetInternalSelectedText();
                }
            }
        }

        private string GetInternalSelectedText()
        {
            string text;
            using var prop = Object.GetProperty(SwigCPtr, Property.SelectedText);
            prop.Get(out text);
            return text;
        }

        /// <summary>
        /// Gets title of web page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public string Title
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (string)GetValue(TitleProperty);
                }
                else
                {
                    return GetInternalTitle();
                }
            }
        }

        private string GetInternalTitle()
        {
            string title;
            using var prop = Object.GetProperty(SwigCPtr, Property.Title);
            prop.Get(out title);
            return title;
        }

        /// <summary>
        /// Gets favicon of web page.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public ImageView Favicon
        {
            get
            {
                global::System.IntPtr imageView = Interop.WebView.GetFavicon(SwigCPtr);
                if (imageView == IntPtr.Zero)
                    return null;
                return new ImageView(imageView, false);
            }
        }

        /// <summary>
        /// Zoom factor of web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float PageZoomFactor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(PageZoomFactorProperty);
                }
                else
                {
                    return GetInternalPageZoomFactor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(PageZoomFactorProperty, value);
                }
                else
                {
                    SetInternalPageZoomFactor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalPageZoomFactor(float newValue)
        {
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.PageZoomFactor, pv);
        }

        private float GetInternalPageZoomFactor()
        {
            float temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.PageZoomFactor);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Zoom factor of text in web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TextZoomFactor
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(TextZoomFactorProperty);
                }
                else
                {
                    return GetInternalTextZoomFactor();
                }
            }
            set
            {
                if (NUIApplication.IsUsingXaml)
                {
                    SetValue(TextZoomFactorProperty, value);
                }
                else
                {
                    SetInternalTextZoomFactor(value);
                }
                NotifyPropertyChanged();
            }
        }

        private void SetInternalTextZoomFactor(float newValue)
        {
            using var pv = new PropertyValue(newValue);
            Object.SetProperty(SwigCPtr, Property.TextZoomFactor, pv);
        }

        private float GetInternalTextZoomFactor()
        {
            float temp;
            using var prop = Object.GetProperty(SwigCPtr, Property.TextZoomFactor);
            prop.Get(out temp);
            return temp;
        }

        /// <summary>
        /// Gets percentage of loading progress.
        /// </summary>
        /// <since_tizen> 9 </since_tizen>
        public float LoadProgressPercentage
        {
            get
            {
                if (NUIApplication.IsUsingXaml)
                {
                    return (float)GetValue(LoadProgressPercentageProperty);
                }
                else
                {
                    return GetInternalLoadProgressPercentage();
                }
            }
        }

        private float GetInternalLoadProgressPercentage()
        {
            float percentage;
            using var prop = Object.GetProperty(SwigCPtr, Property.LoadProgressPercentage);
            prop.Get(out percentage);
            return percentage;
        }

        internal static new class Property
        {
            internal static readonly int Url = Interop.WebView.UrlGet();
            internal static readonly int UserAgent = Interop.WebView.UserAgentGet();
            internal static readonly int ScrollPosition = Interop.WebView.ScrollPositionGet();
            internal static readonly int ScrollSize = Interop.WebView.ScrollSizeGet();
            internal static readonly int ContentSize = Interop.WebView.ContentSizeGet();
            internal static readonly int Title = Interop.WebView.TitleGet();
            internal static readonly int VideoHoleEnabled = Interop.WebView.VideoHoleEnabledGet();
            internal static readonly int MouseEventsEnabled = Interop.WebView.MouseEventsEnabledGet();
            internal static readonly int KeyEventsEnabled = Interop.WebView.KeyEventsEnabledGet();
            internal static readonly int DocumentBackgroundColor = Interop.WebView.DocumentBackgroundColorGet();
            internal static readonly int TilesClearedWhenHidden = Interop.WebView.TilesClearedWhenHiddenGet();
            internal static readonly int TileCoverAreaMultiplier = Interop.WebView.TileCoverAreaMultiplierGet();
            internal static readonly int CursorEnabledByClient = Interop.WebView.CursorEnabledByClientGet();
            internal static readonly int SelectedText = Interop.WebView.SelectedTextGet();
            internal static readonly int PageZoomFactor = Interop.WebView.PageZoomFactorGet();
            internal static readonly int TextZoomFactor = Interop.WebView.TextZoomFactorGet();
            internal static readonly int LoadProgressPercentage = Interop.WebView.LoadProgressPercentageGet();
        }

        // For rooting handlers
        internal Dictionary<string, JavaScriptMessageHandler> handlerRootMap = new Dictionary<string, JavaScriptMessageHandler>();

        /// <summary>
        /// Loads a html.
        /// </summary>
        /// <param name="url">The path of Web</param>
        /// <remarks>
        /// The following privileges are required:
        /// http://tizen.org/privilege/internet for remote web pages of websites.
        /// http://tizen.org/privilege/mediastorage for local files in media storage.
        /// http://tizen.org/privilege/externalstorage for local files in external storage.
        /// </remarks>
        /// <since_tizen> 9 </since_tizen>
        public void LoadUrl(string url)
        {
            Interop.WebView.LoadUrl(SwigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deprecated. Loads a html by string.
        /// </summary>
        /// <param name="data">The data of Web</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHTMLString(string data)
        {
            Interop.WebView.LoadHtmlString(SwigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Loads a html by string.
        /// </summary>
        /// <param name="data">The data of Web</param>
        /// <since_tizen> 9 </since_tizen>
        public void LoadHtmlString(string data)
        {
            Interop.WebView.LoadHtmlString(SwigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Loads the specified html as the content of the view to override current history entry.
        /// </summary>
        /// <param name="html">The html to be loaded</param>
        /// <param name="baseUri">Base URL used for relative paths to external objects</param>
        /// <param name="unreachableUri">URL that could not be reached</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadHtmlStringOverrideCurrentEntry(string html, string baseUri, string unreachableUri)
        {
            bool result = Interop.WebView.LoadHtmlStringOverrideCurrentEntry(SwigCPtr, html, baseUri, unreachableUri);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Requests to load the given contents by MIME type.
        /// </summary>
        /// <param name="contents">The contents to be loaded in bytes</param>
        /// <param name="mimeType">The type of contents, "text/html" is assumed if null</param>
        /// <param name="encoding">The encoding for contents, "UTF-8" is assumed if null</param>
        /// <param name="baseUri">The base URI to use for relative resources</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadContents(byte[] contents, string mimeType, string encoding, string baseUri)
        {
            int length = contents != null ? contents.Length : 0;
            bool result = Interop.WebView.LoadContents(SwigCPtr, contents, (uint)length, mimeType, encoding, baseUri);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Requests to load the given contents by MIME type.
        /// </summary>
        /// <param name="contents">The contents to be loaded. For UTF-8 encoding, contents would be got like System.Text.Encoding.UTF8.GetString(...)</param>
        /// <param name="contentSize">The size of contents (in bytes)</param>
        /// <param name="mimeType">The type of contents, "text/html" is assumed if null</param>
        /// <param name="encoding">The encoding for contents, "UTF-8" is assumed if null</param>
        /// <param name="baseUri">The base URI to use for relative resources</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadContents(string contents, uint contentSize, string mimeType, string encoding, string baseUri)
        {
            bool result = Interop.WebView.LoadContents(SwigCPtr, contents, contentSize, mimeType, encoding, baseUri);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Reloads the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reload()
        {
            Interop.WebView.Reload(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reloads the current page's document without cache
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ReloadWithoutCache()
        {
            bool result = Interop.WebView.ReloadWithoutCache(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Stops loading the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopLoading()
        {
            Interop.WebView.StopLoading(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suspends the operation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Suspend()
        {
            Interop.WebView.Suspend(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes the operation after calling Suspend()
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Resume()
        {
            Interop.WebView.Resume(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suspends all network loading.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SuspendNetworkLoading()
        {
            Interop.WebView.SuspendNetworkLoading(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes all network loading.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ResumeNetworkLoading()
        {
            Interop.WebView.ResumeNetworkLoading(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Change orientation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ChangeOrientation(Window.WindowOrientation orientation)
        {
            Interop.WebView.ChangeOrientation(SwigCPtr, (int)orientation);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Adds custom header.
        /// </summary>
        /// <param name="name">The name of custom header</param>
        /// <param name="value">The value of custom header</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddCustomHeader(string name, string value)
        {
            bool result = Interop.WebView.AddCustomHeader(SwigCPtr, name, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Removes custom header.
        /// </summary>
        /// <param name="name">The name of custom header</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveCustomHeader(string name)
        {
            bool result = Interop.WebView.RemoveCustomHeader(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Starts the inspector server.
        /// </summary>
        /// <param name="port">The port number</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public uint StartInspectorServer(uint port)
        {
            uint result = Interop.WebView.StartInspectorServer(SwigCPtr, port);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Stops the inspector server.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool StopInspectorServer()
        {
            bool result = Interop.WebView.StopInspectorServer(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Set the style of IME.
        /// </summary>
        /// <param name="position">The position of IME</param>
        /// <param name="alignment">The alignment of IME</param>
        /// <returns>True if setting successfully, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool SetImePositionAndAlignment(Vector2 position, ImeAlignment alignment)
        {
            bool result = Interop.WebView.SetImePositionAndAlignment(SwigCPtr, Vector2.getCPtr(position), (int)alignment);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Set the theme name of cursor.
        /// </summary>
        /// <param name="themeName">The theme name of cursor</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetCursorThemeName(string themeName)
        {
            Interop.WebView.SetCursorThemeName(SwigCPtr, themeName);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls page of web view by deltaX and detlaY.
        /// </summary>
        /// <param name="deltaX">The deltaX of scroll</param>
        /// <param name="deltaY">The deltaY of scroll</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollBy(int deltaX, int deltaY)
        {
            Interop.WebView.ScrollBy(SwigCPtr, deltaX, deltaY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls edge of web view by deltaX and deltaY.
        /// </summary>
        /// <param name="deltaX">The deltaX of scroll</param>
        /// <param name="deltaY">The deltaY of scroll</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ScrollEdgeBy(int deltaX, int deltaY)
        {
            bool result = Interop.WebView.ScrollEdgeBy(SwigCPtr, deltaX, deltaY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Goes to the back
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoBack()
        {
            Interop.WebView.GoBack(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Goes to the forward
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoForward()
        {
            Interop.WebView.GoForward(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether backward is possible.
        /// </summary>
        /// <returns>True if backward is possible, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoBack()
        {
            bool ret = Interop.WebView.CanGoBack(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether forward is possible.
        /// </summary>
        /// <returns>True if forward is possible, false otherwise</returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoForward()
        {
            bool ret = Interop.WebView.CanGoForward(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Evaluates JavaScript code represented as a string.
        /// </summary>
        /// <param name="script">The JavaScript code</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EvaluateJavaScript(string script)
        {
            Interop.WebView.EvaluateJavaScript(SwigCPtr, script, new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private JavaScriptMessageHandler _javaScriptMessageHandler;

        /// <summary>
        /// Evaluates JavaScript code represented as a string.
        /// If EvaluateJavaScript is called many times, its argument 'handler' callback would be called not sequentially.
        /// A possible call sequence is like:
        /// 1) webview.EvaluateJavaScript("abc", handler1),
        /// 2) webview.EvaluateJavaScript("def", handler2),
        /// 3) handle2 would be called,
        /// 4) handle2 would be called, handler1 would not be called any more.
        /// </summary>
        /// <param name="script">The JavaScript code</param>
        /// <param name="handler">The callback for result of JavaScript code evaluation</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EvaluateJavaScript(string script, JavaScriptMessageHandler handler)
        {
            _javaScriptMessageHandler = new JavaScriptMessageHandler(handler);
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(_javaScriptMessageHandler);
            Interop.WebView.EvaluateJavaScript(SwigCPtr, script, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add a message handler into the WebView.
        /// </summary>
        /// <param name="objectName">The name of exposed object</param>
        /// <param name="handler">The callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddJavaScriptMessageHandler(string objectName, JavaScriptMessageHandler handler)
        {
            handlerRootMap[objectName] = handler;

            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(handler);
            Interop.WebView.AddJavaScriptMessageHandler(SwigCPtr, objectName, new System.Runtime.InteropServices.HandleRef(this, ip));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        private Dictionary<string, JavaScriptEntireMessageHandler> _addJavaScriptEntireMessageHandlerMap = new Dictionary<string, JavaScriptEntireMessageHandler>();

        /// <summary>
        /// Add a message handler into the WebView.
        /// </summary>
        /// <param name="objectName">The name of exposed object</param>
        /// <param name="handler">The callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddJavaScriptMessageHandler(string objectName, JavaScriptEntireMessageHandler handler)
        {
            _addJavaScriptEntireMessageHandlerMap[objectName] = handler;
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(handler);
            Interop.WebView.AddJavaScriptEntireMessageHandler(SwigCPtr, objectName, new System.Runtime.InteropServices.HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers a callback for JS alert.
        /// </summary>
        /// <param name="callback">The callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptAlertCallback(JavaScriptAlertCallback callback)
        {
            IntPtr ip = IntPtr.Zero;
            if (callback != null)
            {
                ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
            }
            Interop.WebView.RegisterJavaScriptAlertCallback(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reply for alert popup.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void JavaScriptAlertReply()
        {
            Interop.WebView.JavaScriptAlertReply(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers a callback for JS confirm.
        /// </summary>
        /// <param name="callback">The callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptConfirmCallback(JavaScriptConfirmCallback callback)
        {
            IntPtr ip = IntPtr.Zero;
            if (callback != null)
            {
                ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
            }
            Interop.WebView.RegisterJavaScriptConfirmCallback(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reply for confirm popup.
        /// </summary>
        /// <param name="confirmed">Confirmed or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void JavaScriptConfirmReply(bool confirmed)
        {
            Interop.WebView.JavaScriptConfirmReply(SwigCPtr, confirmed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Registers a callback for JS promt.
        /// </summary>
        /// <param name="callback">The callback function</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptPromptCallback(JavaScriptPromptCallback callback)
        {
            IntPtr ip = IntPtr.Zero;
            if (callback != null)
            {
                ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
            }
            Interop.WebView.RegisterJavaScriptPromptCallback(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reply for prompt popup.
        /// </summary>
        /// <param name="result">Text in prompt input field.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void JavaScriptPromptReply(string result)
        {
            Interop.WebView.JavaScriptPromptReply(SwigCPtr, result);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears title resources of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearAllTilesResources()
        {
            Interop.WebView.ClearAllTilesResources(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the history of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearHistory()
        {
            Interop.WebView.ClearHistory(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Exit fullscreen.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ExitFullscreen()
        {
            Interop.WebView.ExitFullscreen(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scales the current page, centered at the given point.
        /// </summary>
        /// <param name="scaleFactor">The new factor to be scaled</param>
        /// <param name="point">The center coordinate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetScaleFactor(float scaleFactor, Vector2 point)
        {
            Interop.WebView.SetScaleFactor(SwigCPtr, scaleFactor, Vector2.getCPtr(point));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Gets the current scale factor of the page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float GetScaleFactor()
        {
            float result = Interop.WebView.GetScaleFactor(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Requests to activate/deactivate the accessibility usage set by web app.
        /// </summary>
        /// <param name="activated">The new factor to be scaled</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateAccessibility(bool activated)
        {
            Interop.WebView.ActivateAccessibility(SwigCPtr, activated);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Searches and highlights the given string in the document.
        /// </summary>
        /// <param name="text">The text to be searched</param>
        /// <param name="options">The options to search</param>
        /// <param name="maxMatchCount">The maximum match count to search</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HighlightText(string text, FindOption options, uint maxMatchCount)
        {
            bool result = Interop.WebView.HighlightText(SwigCPtr, text, (int)options, maxMatchCount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds dynamic certificate path.
        /// </summary>
        /// <param name="host">Host that required client authentication</param>
        /// <param name="certPath">The file path stored certificate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddDynamicCertificatePath(string host, string certPath)
        {
            Interop.WebView.AddDynamicCertificatePath(SwigCPtr, host, certPath);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get snapshot of the specified viewArea of page.
        /// </summary>
        /// <param name="viewArea">Host that required client authentication</param>
        /// <param name="scaleFactor">The file path stored certificate</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView GetScreenshot(Rectangle viewArea, float scaleFactor)
        {
            IntPtr image = Interop.WebView.GetScreenshot(SwigCPtr, Rectangle.getCPtr(viewArea), scaleFactor);
            ImageView imageView = new ImageView(image, true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return imageView;
        }

        /// <summary>
        /// Get snapshot of the specified viewArea of page.
        /// </summary>
        /// <param name="viewArea">Host that required client authentication</param>
        /// <param name="scaleFactor">The file path stored certificate</param>
        /// <param name="callback">The callback for getting screen shot</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool GetScreenshotAsynchronously(Rectangle viewArea, float scaleFactor, ScreenshotAcquiredCallback callback)
        {
            screenshotAcquiredCallback = callback;
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(screenshotAcquiredProxyCallback);
            bool result = Interop.WebView.GetScreenshotAsynchronously(SwigCPtr, Rectangle.getCPtr(viewArea), scaleFactor, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Asynchronously requests to check if there is a video playing in the given view.
        /// </summary>
        /// <param name="callback">The callback called after checking if video is playing or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CheckVideoPlayingAsynchronously(VideoPlayingCallback callback)
        {
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            bool result = Interop.WebView.CheckVideoPlayingAsynchronously(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Registers callback which will be called upon geolocation permission request.
        /// </summary>
        /// <param name="callback">The callback for requesting geolocation permission</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterGeolocationPermissionCallback(GeolocationPermissionCallback callback)
        {
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebView.RegisterGeolocationPermissionCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Does hit test synchronously.
        /// </summary>
        /// <param name="x">the horizontal position to query</param>
        /// <param name="y">the vertical position to query</param>
        /// <param name="mode">the mode of hit test</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebHitTestResult HitTest(int x, int y, HitTestMode mode)
        {
            System.IntPtr result = Interop.WebView.CreateHitTest(SwigCPtr, x, y, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebHitTestResult(result, true);
        }

        /// <summary>
        /// Does hit test asynchronously.
        /// </summary>
        /// <param name="x">the horizontal position to query</param>
        /// <param name="y">the vertical position to query</param>
        /// <param name="mode">the mode of hit test</param>
        /// <param name="callback">the callback that is called after hit test is finished.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HitTestAsynchronously(int x, int y, HitTestMode mode, HitTestFinishedCallback callback)
        {
            hitTestFinishedCallback = callback;
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(hitTestFinishedProxyCallback);
            bool result = Interop.WebView.CreateHitTestAsynchronously(SwigCPtr, x, y, (int)mode, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Deprecated. Clears the cache of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Context.ClearCache();
        }

        /// <summary>
        /// Deprecated. Clears all the cookies of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCookies()
        {
            CookieManager.ClearCookies();
        }

        /// <summary>
        /// Sets the tts focus to the webview.
        /// Please note that it only works when the webview does not have keyinput focus.
        /// If the webview has a keyinput focus, it also has tts focus so calling SetTtsFocus(false) is ignored.
        /// </summary>
        /// <param name="focused">Focused or not</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetTtsFocus(bool focused)
        {
            Interop.WebView.SetTtsFocus(SwigCPtr, focused);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get a plain text of current web page asynchronously.
        /// Please note that it gets plain text of currently loaded page so please call this method after page load finished.
        /// </summary>
        /// <param name="callback">The callback for getting plain text</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GetPlainTextAsynchronously(PlainTextReceivedCallback callback)
        {
            plainTextReceivedCallback = callback;
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(plainTextReceivedCallback);
            Interop.WebView.GetPlainTextAsynchronously(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// cancel in progress web authentication that is passkey operation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WebAuthenticationCancel()
        {
            Interop.WebView.WebAuthenticationCancel(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Feed mouse wheel event forcefully.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void FeedMouseWheel(bool yDirection, int step, int x, int y)
        {
            Interop.WebView.FeedMouseWheel(SwigCPtr, yDirection, step, x, y);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Enable video hole for a specific window type.
        /// </summary>
        /// <param name="enable">true if enabled, false othewise</param>
        /// <param name="isWaylandWindow">true if wayland window, false if EFL window.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void SetVideoHole(bool enable, bool isWaylandWindow)
        {
            Interop.WebView.SetVideoHole(SwigCPtr, enable, isWaylandWindow);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal static WebView DownCast(BaseHandle handle)
        {
            WebView ret = new WebView(Interop.WebView.DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal WebView Assign(WebView webView)
        {
            WebView ret = new WebView(Interop.WebView.Assign(SwigCPtr, WebView.getCPtr(webView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnPageLoadStarted(string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = this;
            e.PageUrl = pageUrl;

            pageLoadStartedEventHandler?.Invoke(this, e);
        }

        private void OnPageLoading(string pageUrl)
        {
            pageLoadingEventHandler?.Invoke(this, new WebViewPageLoadEventArgs());
        }

        private void OnPageLoadFinished(string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = this;
            e.PageUrl = pageUrl;

            pageLoadFinishedEventHandler?.Invoke(this, e);
        }

        private void OnPageLoadError(IntPtr error)
        {
            pageLoadErrorEventHandler?.Invoke(this, new WebViewPageLoadErrorEventArgs(new WebPageLoadError(error, true)));
        }

        private void OnScrollEdgeReached(int edge)
        {
            scrollEdgeReachedEventHandler?.Invoke(this, new WebViewScrollEdgeReachedEventArgs((WebViewScrollEdgeReachedEventArgs.Edge)edge));
        }

        private void OnOverScrolled(int over)
        {
            overScrolledEventHandler?.Invoke(this, new WebViewOverScrolledEventArgs((WebViewOverScrolledEventArgs.Over)over));
        }

        private void OnUrlChanged(string pageUrl)
        {
            urlChangedEventHandler?.Invoke(this, new WebViewUrlChangedEventArgs(pageUrl));
        }

        private void OnFormRepostPolicyDecided(IntPtr decision)
        {
            formRepostPolicyDecidedEventHandler?.Invoke(this, new WebViewFormRepostPolicyDecidedEventArgs(new WebFormRepostPolicyDecisionMaker(decision, true)));
        }

        private void OnFrameRendered()
        {
            frameRenderedEventHandler?.Invoke(this, new EventArgs());
        }

        private void OnScreenshotAcquired(IntPtr data)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            screenshotAcquiredCallback?.Invoke(new ImageView(data, true));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private void OnResponsePolicyDecided(IntPtr maker)
        {
            responsePolicyDecidedEventHandler?.Invoke(this, new WebViewPolicyDecidedEventArgs(new WebPolicyDecisionMaker(maker, true)));
        }

        private void OnNavigationPolicyDecided(IntPtr maker)
        {
            navigationPolicyDecidedEventHandler?.Invoke(this, new WebViewPolicyDecidedEventArgs(new WebPolicyDecisionMaker(maker, true)));
        }

        private void OnNewWindowPolicyDecided(IntPtr maker)
        {
            newWindowPolicyDecidedEventHandler?.Invoke(this, new WebViewPolicyDecidedEventArgs(new WebPolicyDecisionMaker(maker, true)));
        }

        private void OnNewWindowCreated(out IntPtr viewHandle)
        {
            WebView view = newWindowCreatedEventHandler?.Invoke(this, new EventArgs());
            viewHandle = (IntPtr)view.SwigCPtr;
        }

        private void OnCertificateConfirmed(IntPtr certificate)
        {
            certificateConfirmedEventHandler?.Invoke(this, new WebViewCertificateReceivedEventArgs(new WebCertificate(certificate, true)));
        }

        private void OnSslCertificateChanged(IntPtr certificate)
        {
            sslCertificateChangedEventHandler?.Invoke(this, new WebViewCertificateReceivedEventArgs(new WebCertificate(certificate, true)));
        }

        private void OnHttpAuthRequested(IntPtr handler)
        {
            httpAuthRequestedEventHandler?.Invoke(this, new WebViewHttpAuthRequestedEventArgs(new WebHttpAuthHandler(handler, true)));
        }

        private void OnConsoleMessageReceived(IntPtr message)
        {
            consoleMessageReceivedEventHandler?.Invoke(this, new WebViewConsoleMessageReceivedEventArgs(new WebConsoleMessage(message, true)));
        }

        private void OnContextMenuShown(IntPtr menu)
        {
            contextMenuShownEventHandler?.Invoke(this, new WebViewContextMenuShownEventArgs(new WebContextMenu(menu, true)));
        }

        private void OnContextMenuHidden(IntPtr menu)
        {
            contextMenuHiddenEventHandler?.Invoke(this, new WebViewContextMenuHiddenEventArgs(new WebContextMenu(menu, true)));
        }

        private void OnHitTestFinished(IntPtr test)
        {
#pragma warning disable CA2000 // Dispose objects before losing scope
            hitTestFinishedCallback?.Invoke(new WebHitTestResult(test, true));
#pragma warning restore CA2000 // Dispose objects before losing scope
        }

        private void OnFullscreenEntered()
        {
            fullscreenEnteredEventHandler?.Invoke(this, new EventArgs());
        }

        private void OnFullscreenExited()
        {
            fullscreenExitedEventHandler?.Invoke(this, new EventArgs());
        }

        private void OnTextFound(uint count)
        {
            textFoundEventHandler?.Invoke(this, new WebViewTextFoundEventArgs(count));
        }

        private void OnWebAuthDisplayQR(string contents)
        {
            webAuthDisplayQREventHandler?.Invoke(this, new WebViewWebAuthDisplayQREventArgs(contents));
        }

        private void OnWebAuthResponse()
        {
            webAuthResponseEventHandler?.Invoke(this, new EventArgs());
        }

        private void OnUserMediaPermissionRequset(IntPtr permission, string message)
        {
            userMediaPermissionRequestEventHandler?.Invoke(this, new WebViewUserMediaPermissionRequestEventArgs(new WebUserMediaPermissionRequest(permission, true), message));
        }

        private void OnDeviceConnectionChanged(int deviceType)
        {
            deviceConnectionChangedEventHandler?.Invoke(this, new WebViewDeviceConnectionChangedEventArgs(deviceType));
        }

    }
}
