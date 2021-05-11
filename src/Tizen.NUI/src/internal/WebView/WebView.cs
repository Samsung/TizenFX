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
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Binding;

namespace Tizen.NUI
{
    /// <summary>
    /// WebView
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebView : View
    {
        private Vector4 contentBackgroundColor;
        private bool tilesClearedWhenHidden;
        private float tileCoverAreaMultiplier;
        private bool cursorEnabledByClient;

        private readonly WebViewPageLoadSignal pageLoadStartedSignal;
        private EventHandler<WebViewPageLoadEventArgs> pageLoadStartedEventHandler;
        private WebViewPageLoadCallbackDelegate pageLoadStartedCallback;

        private readonly WebViewPageLoadSignal pageLoadingSignal;
        private EventHandler<WebViewPageLoadEventArgs> pageLoadingEventHandler;
        private WebViewPageLoadCallbackDelegate pageLoadingCallback;

        private readonly WebViewPageLoadSignal pageLoadFinishedSignal;
        private EventHandler<WebViewPageLoadEventArgs> pageLoadFinishedEventHandler;
        private WebViewPageLoadCallbackDelegate pageLoadFinishedCallback;

        private readonly WebViewPageLoadErrorSignal pageLoadErrorSignal;
        private EventHandler<WebViewPageLoadErrorEventArgs> pageLoadErrorEventHandler;
        private WebViewPageLoadErrorCallbackDelegate pageLoadErrorCallback;

        private readonly WebViewScrollEdgeReachedSignal scrollEdgeReachedSignal;
        private EventHandler<WebViewScrollEdgeReachedEventArgs> scrollEdgeReachedEventHandler;
        private WebViewScrollEdgeReachedCallbackDelegate scrollEdgeReachedCallback;

        private readonly WebViewUrlChangedSignal urlChangedSignal;
        private EventHandler<WebViewUrlChangedEventArgs> urlChangedEventHandler;
        private WebViewUrlChangedCallbackDelegate urlChangedCallback;

        private readonly WebViewFormRepostPolicyDecidedSignal formRepostPolicyDecidedSignal;
        private EventHandler<WebViewFormRepostPolicyDecidedEventArgs> formRepostPolicyDecidedEventHandler;
        private WebViewFormRepostPolicyDecidedCallbackDelegate formRepostPolicyDecidedCallback;

        private readonly WebViewFrameRenderedSignal frameRenderedSignal;
        private EventHandler<EventArgs> frameRenderedEventHandler;
        private WebViewFrameRenderedCallbackDelegate frameRenderedCallback;

        private ScreenshotAcquiredCallback screenshotAcquiredCallback;
        private readonly WebViewScreenshotAcquiredProxyCallback screenshotAcquiredProxyCallback;

        private HitTestFinishedCallback hitTestFinishedCallback;
        private readonly WebViewHitTestFinishedProxyCallback hitTestFinishedProxyCallback;

        private readonly WebViewResponsePolicyDecidedSignal responsePolicyDecidedSignal;
        private EventHandler<WebViewResponsePolicyDecidedEventArgs> responsePolicyDecidedEventHandler;
        private WebViewResponsePolicyDecidedCallbackDelegate responsePolicyDecidedCallback;

        private readonly WebViewCertificateReceivedSignal certificateConfirmedSignal;
        private EventHandler<WebViewCertificateReceivedEventArgs> certificateConfirmedEventHandler;
        private WebViewCertificateReceivedCallbackDelegate certificateConfirmedCallback;

        private readonly WebViewCertificateReceivedSignal sslCertificateChangedSignal;
        private EventHandler<WebViewCertificateReceivedEventArgs> sslCertificateChangedEventHandler;
        private WebViewCertificateReceivedCallbackDelegate sslCertificateChangedCallback;

        private readonly WebViewHttpAuthRequestedSignal httpAuthRequestedSignal;
        private EventHandler<WebViewHttpAuthRequestedEventArgs> httpAuthRequestedEventHandler;
        private WebViewHttpAuthRequestedCallbackDelegate httpAuthRequestedCallback;

        private readonly WebViewHttpRequestInterceptedSignal httpRequestInterceptedSignal;
        private EventHandler<WebViewHttpRequestInterceptedEventArgs> httpRequestInterceptedEventHandler;
        private WebViewHttpRequestInterceptedCallbackDelegate httpRequestInterceptedCallback;

        private readonly WebViewConsoleMessageReceivedSignal consoleMessageReceivedSignal;
        private EventHandler<WebViewConsoleMessageReceivedEventArgs> consoleMessageReceivedEventHandler;
        private WebViewConsoleMessageReceivedCallbackDelegate consoleMessageReceivedCallback;

        private readonly WebViewContextMenuCustomizedSignal contextMenuCustomizedSignal;
        private EventHandler<WebViewContextMenuCustomizedEventArgs> contextMenuCustomizedEventHandler;
        private WebViewContextMenuCustomizedCallbackDelegate contextMenuCustomizedCallback;

        private readonly WebViewContextMenuItemSelectedSignal contextMenuItemSelectedSignal;
        private EventHandler<WebViewContextMenuItemSelectedEventArgs> contextMenuItemSelectedEventHandler;
        private WebViewContextMenuItemSelectedCallbackDelegate contextMenuItemSelectedCallback;

        /// <summary>
        /// Creates a WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView() : this(Interop.WebView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a WebView with local language and time zone.
        /// <param name="locale">The locale language of Web</param>
        /// <param name="timezoneId">The time zone Id of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string locale, string timezoneId) : this(Interop.WebView.New2(locale, timezoneId), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Creates a WebView with an args list.
        /// <param name="args">args array. The first value of array must be program's name.</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string[] args) : this(Interop.WebView.New3(args?.Length ?? 0, args), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// <param name="webView">WebView to copy. The copied WebView will point at the same implementation</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(WebView webView) : this(Interop.WebView.NewWebView(WebView.getCPtr(webView)), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WebView.Upcast(cPtr), cMemoryOwn)
        {
            pageLoadStartedSignal = new WebViewPageLoadSignal(Interop.WebView.NewWebViewPageLoadSignalPageLoadStarted(SwigCPtr));
            pageLoadingSignal = new WebViewPageLoadSignal(Interop.WebView.NewWebViewPageLoadSignalPageLoadInProgress(SwigCPtr));
            pageLoadFinishedSignal = new WebViewPageLoadSignal(Interop.WebView.NewWebViewPageLoadSignalPageLoadFinished(SwigCPtr));
            pageLoadErrorSignal = new WebViewPageLoadErrorSignal(Interop.WebView.NewWebViewPageLoadErrorSignalPageLoadError(SwigCPtr));
            scrollEdgeReachedSignal = new WebViewScrollEdgeReachedSignal(Interop.WebView.NewWebViewScrollEdgeReachedSignalScrollEdgeReached(SwigCPtr));
            urlChangedSignal = new WebViewUrlChangedSignal(Interop.WebView.NewWebViewUrlChangedSignalUrlChanged(SwigCPtr));
            formRepostPolicyDecidedSignal = new WebViewFormRepostPolicyDecidedSignal(Interop.WebView.NewWebViewFormRepostDecisionSignalFormRepostDecision(SwigCPtr));
            frameRenderedSignal = new WebViewFrameRenderedSignal(Interop.WebView.WebViewFrameRenderedSignalFrameRenderedGet(SwigCPtr));
            responsePolicyDecidedSignal = new WebViewResponsePolicyDecidedSignal(Interop.WebView.NewWebViewResponsePolicyDecisionSignalPolicyDecision(SwigCPtr));
            certificateConfirmedSignal = new WebViewCertificateReceivedSignal(Interop.WebView.NewWebViewCertificateSignalCertificateConfirm(SwigCPtr));
            sslCertificateChangedSignal = new WebViewCertificateReceivedSignal(Interop.WebView.NewWebViewCertificateSignalSslCertificateChanged(SwigCPtr));
            httpAuthRequestedSignal = new WebViewHttpAuthRequestedSignal(Interop.WebView.NewWebViewHttpAuthHandlerSignalHttpAuthHandler(SwigCPtr));
            httpRequestInterceptedSignal = new WebViewHttpRequestInterceptedSignal(Interop.WebView.NewWebViewRequestInterceptorSignalRequestInterceptor(SwigCPtr));
            consoleMessageReceivedSignal = new WebViewConsoleMessageReceivedSignal(Interop.WebView.NewWebViewConsoleMessageSignalConsoleMessage(SwigCPtr));
            contextMenuCustomizedSignal = new WebViewContextMenuCustomizedSignal(Interop.WebView.NewWebViewContextMenuCustomizedSignalContextMenuCustomized(SwigCPtr));
            contextMenuItemSelectedSignal = new WebViewContextMenuItemSelectedSignal(Interop.WebView.NewWebViewContextMenuItemSelectedSignalContextMenuItemSelected(SwigCPtr));

            screenshotAcquiredProxyCallback = OnScreenshotAcquired;
            hitTestFinishedProxyCallback = OnHitTestFinished;

            BackForwardList = new WebBackForwardList(Interop.WebView.GetWebBackForwardList(SwigCPtr), false);
            Context = new WebContext(Interop.WebView.GetWebContext(SwigCPtr), false);
            CookieManager = new WebCookieManager(Interop.WebView.GetWebCookieManager(SwigCPtr), false);
            Settings = new WebSettings(Interop.WebView.GetWebSettings(SwigCPtr), false);
        }

        /// <summary>
        /// Dispose for IDisposable pattern
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void Dispose(DisposeTypes type)
        {
            if (disposed)
            {
                return;
            }

            if (type == DisposeTypes.Explicit)
            {
                //Called by User
                //Release your own managed resources here.
                //You should release all of your own disposable objects here.
                pageLoadStartedSignal.Dispose();
                pageLoadingSignal.Dispose();
                pageLoadFinishedSignal.Dispose();
                pageLoadErrorSignal.Dispose();
                scrollEdgeReachedSignal.Dispose();
                urlChangedSignal.Dispose();
                formRepostPolicyDecidedSignal.Dispose();
                frameRenderedSignal.Dispose();
                responsePolicyDecidedSignal.Dispose();
                certificateConfirmedSignal.Dispose();
                sslCertificateChangedSignal.Dispose();
                httpAuthRequestedSignal.Dispose();
                httpRequestInterceptedSignal.Dispose();
                consoleMessageReceivedSignal.Dispose();
                contextMenuCustomizedSignal.Dispose();
                contextMenuItemSelectedSignal.Dispose();

                BackForwardList.Dispose();
                Context.Dispose();
                CookieManager.Dispose();
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
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptMessageHandler(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptAlertCallback(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptConfirmCallback(string message);

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptPromptCallback(string message1, string message2);

        /// <summary>
        /// The callback function that is invoked when screen shot is acquired asynchronously.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void ScreenshotAcquiredCallback(ImageView image);

        /// <summary>
        /// The callback function that is invoked when video playing is checked asynchronously.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void VideoPlayingCallback(bool isPlaying);

        /// <summary>
        /// The callback function that is invoked when geolocation permission is requested.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void GeolocationPermissionCallback(string host, string protocol);

        /// <summary>
        /// The callback function that is invoked when hit test is finished.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void HitTestFinishedCallback(WebHitTestResult test);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadCallbackDelegate(IntPtr data, string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadErrorCallbackDelegate(IntPtr data, IntPtr error);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewScrollEdgeReachedCallbackDelegate(IntPtr data, int edge);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewUrlChangedCallbackDelegate(IntPtr data, string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewFormRepostPolicyDecidedCallbackDelegate(IntPtr data, IntPtr maker);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewFrameRenderedCallbackDelegate(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewScreenshotAcquiredProxyCallback(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewHitTestFinishedProxyCallback(IntPtr data);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewResponsePolicyDecidedCallbackDelegate(IntPtr data, IntPtr maker);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewCertificateReceivedCallbackDelegate(IntPtr data, IntPtr certificate);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewHttpAuthRequestedCallbackDelegate(IntPtr data, IntPtr handler);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewHttpRequestInterceptedCallbackDelegate(IntPtr data, IntPtr interceptor);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewConsoleMessageReceivedCallbackDelegate(IntPtr data, IntPtr message);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewContextMenuCustomizedCallbackDelegate(IntPtr data, IntPtr menu);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewContextMenuItemSelectedCallbackDelegate(IntPtr data, IntPtr item);

        /// <summary>
        /// Event for the PageLoadStarted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has started.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPageLoadEventArgs> PageLoadStarted
        {
            add
            {
                if (pageLoadStartedEventHandler == null)
                {
                    pageLoadStartedCallback = (OnPageLoadStarted);
                    pageLoadStartedSignal.Connect(pageLoadStartedCallback);
                }
                pageLoadStartedEventHandler += value;
            }
            remove
            {
                pageLoadStartedEventHandler -= value;
                if (pageLoadStartedEventHandler == null && pageLoadStartedCallback != null)
                {
                    pageLoadStartedSignal.Disconnect(pageLoadStartedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the PageLoading signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading is in progress.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPageLoadEventArgs> PageLoading
        {
            add
            {
                if (pageLoadingEventHandler == null)
                {
                    pageLoadingCallback = OnPageLoading;
                    pageLoadingSignal.Connect(pageLoadingCallback);
                }
                pageLoadingEventHandler += value;
            }
            remove
            {
                pageLoadingEventHandler -= value;
                if (pageLoadingEventHandler == null && pageLoadingCallback != null)
                {
                    pageLoadingSignal.Disconnect(pageLoadingCallback);
                }
            }
        }

        /// <summary>
        /// Event for the PageLoadFinished signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has finished.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPageLoadEventArgs> PageLoadFinished
        {
            add
            {
                if (pageLoadFinishedEventHandler == null)
                {
                    pageLoadFinishedCallback = (OnPageLoadFinished);
                    pageLoadFinishedSignal.Connect(pageLoadFinishedCallback);
                }
                pageLoadFinishedEventHandler += value;
            }
            remove
            {
                pageLoadFinishedEventHandler -= value;
                if (pageLoadFinishedEventHandler == null && pageLoadFinishedCallback != null)
                {
                    pageLoadFinishedSignal.Disconnect(pageLoadFinishedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the PageLoadError signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when there's an error in page loading.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewPageLoadErrorEventArgs> PageLoadError
        {
            add
            {
                if (pageLoadErrorEventHandler == null)
                {
                    pageLoadErrorCallback = OnPageLoadError;
                    pageLoadErrorSignal.Connect(pageLoadErrorCallback);
                }
                pageLoadErrorEventHandler += value;
            }
            remove
            {
                pageLoadErrorEventHandler -= value;
                if (pageLoadErrorEventHandler == null && pageLoadErrorCallback != null)
                {
                    pageLoadErrorSignal.Disconnect(pageLoadErrorCallback);
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
                    scrollEdgeReachedSignal.Connect(scrollEdgeReachedCallback);
                }
                scrollEdgeReachedEventHandler += value;
            }
            remove
            {
                scrollEdgeReachedEventHandler -= value;
                if (scrollEdgeReachedEventHandler == null && scrollEdgeReachedCallback != null)
                {
                    scrollEdgeReachedSignal.Disconnect(scrollEdgeReachedCallback);
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
                    urlChangedSignal.Connect(urlChangedCallback);
                }
                urlChangedEventHandler += value;
            }
            remove
            {
                urlChangedEventHandler -= value;
                if (urlChangedEventHandler == null && urlChangedCallback != null)
                {
                    urlChangedSignal.Disconnect(urlChangedCallback);
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
                    formRepostPolicyDecidedSignal.Connect(formRepostPolicyDecidedCallback);
                }
                formRepostPolicyDecidedEventHandler += value;
            }
            remove
            {
                formRepostPolicyDecidedEventHandler -= value;
                if (formRepostPolicyDecidedEventHandler == null && formRepostPolicyDecidedCallback != null)
                {
                    formRepostPolicyDecidedSignal.Disconnect(formRepostPolicyDecidedCallback);
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
                    frameRenderedSignal.Connect(frameRenderedCallback);
                }
                frameRenderedEventHandler += value;
            }
            remove
            {
                frameRenderedEventHandler -= value;
                if (frameRenderedEventHandler == null && frameRenderedCallback != null)
                {
                    frameRenderedSignal.Disconnect(frameRenderedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the ResponsePolicyDecided signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when response policy would be decided.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewResponsePolicyDecidedEventArgs> ResponsePolicyDecided
        {
            add
            {
                if (responsePolicyDecidedEventHandler == null)
                {
                    responsePolicyDecidedCallback = OnResponsePolicyDecided;
                    responsePolicyDecidedSignal.Connect(responsePolicyDecidedCallback);
                }
                responsePolicyDecidedEventHandler += value;
            }
            remove
            {
                responsePolicyDecidedEventHandler -= value;
                if (responsePolicyDecidedEventHandler == null && responsePolicyDecidedCallback != null)
                {
                    responsePolicyDecidedSignal.Disconnect(responsePolicyDecidedCallback);
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
                    certificateConfirmedSignal.Connect(certificateConfirmedCallback);
                }
                certificateConfirmedEventHandler += value;
            }
            remove
            {
                certificateConfirmedEventHandler -= value;
                if (certificateConfirmedEventHandler == null && certificateConfirmedCallback != null)
                {
                    certificateConfirmedSignal.Disconnect(certificateConfirmedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the HttpRequestIntercepted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when http request would be intercepted.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewHttpRequestInterceptedEventArgs> HttpRequestIntercepted
        {
            add
            {
                if (httpRequestInterceptedEventHandler == null)
                {
                    httpRequestInterceptedCallback = OnHttpRequestIntercepted;
                    httpRequestInterceptedSignal.Connect(httpRequestInterceptedCallback);
                }
                httpRequestInterceptedEventHandler += value;
            }
            remove
            {
                httpRequestInterceptedEventHandler -= value;
                if (httpRequestInterceptedEventHandler == null && httpRequestInterceptedCallback != null)
                {
                    httpRequestInterceptedSignal.Disconnect(httpRequestInterceptedCallback);
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
                    sslCertificateChangedSignal.Connect(sslCertificateChangedCallback);
                }
                sslCertificateChangedEventHandler += value;
            }
            remove
            {
                sslCertificateChangedEventHandler -= value;
                if (sslCertificateChangedEventHandler == null && sslCertificateChangedCallback != null)
                {
                    sslCertificateChangedSignal.Disconnect(sslCertificateChangedCallback);
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
                    httpAuthRequestedSignal.Connect(httpAuthRequestedCallback);
                }
                httpAuthRequestedEventHandler += value;
            }
            remove
            {
                httpAuthRequestedEventHandler -= value;
                if (httpAuthRequestedEventHandler == null && httpAuthRequestedCallback != null)
                {
                    httpAuthRequestedSignal.Disconnect(httpAuthRequestedCallback);
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
                    consoleMessageReceivedSignal.Connect(consoleMessageReceivedCallback);
                }
                consoleMessageReceivedEventHandler += value;
            }
            remove
            {
                consoleMessageReceivedEventHandler -= value;
                if (consoleMessageReceivedEventHandler == null && consoleMessageReceivedCallback != null)
                {
                    consoleMessageReceivedSignal.Disconnect(consoleMessageReceivedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the ContextMenuCustomized signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when context menu is customized.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewContextMenuCustomizedEventArgs> ContextMenuCustomized
        {
            add
            {
                if (contextMenuCustomizedEventHandler == null)
                {
                    contextMenuCustomizedCallback = OnContextMenuCustomized;
                    contextMenuCustomizedSignal.Connect(contextMenuCustomizedCallback);
                }
                contextMenuCustomizedEventHandler += value;
            }
            remove
            {
                contextMenuCustomizedEventHandler -= value;
                if (contextMenuCustomizedEventHandler == null && contextMenuCustomizedCallback != null)
                {
                    contextMenuCustomizedSignal.Disconnect(contextMenuCustomizedCallback);
                }
            }
        }

        /// <summary>
        /// Event for the ContextMenuItemSelected signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when context menu item is selected.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewContextMenuItemSelectedEventArgs> ContextMenuItemSelected
        {
            add
            {
                if (contextMenuItemSelectedEventHandler == null)
                {
                    contextMenuItemSelectedCallback = OnContextMenuItemSelected;
                    contextMenuItemSelectedSignal.Connect(contextMenuItemSelectedCallback);
                }
                contextMenuItemSelectedEventHandler += value;
            }
            remove
            {
                contextMenuItemSelectedEventHandler -= value;
                if (contextMenuItemSelectedEventHandler == null && contextMenuItemSelectedCallback != null)
                {
                    contextMenuItemSelectedSignal.Disconnect(contextMenuItemSelectedCallback);
                }
            }
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
        /// BackForwardList.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebBackForwardList BackForwardList { get; }

        /// <summary>
        /// Context.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebContext Context { get; }

        /// <summary>
        /// CookieManager.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebCookieManager CookieManager { get; }

        /// <summary>
        /// BackForwardList.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebSettings Settings { get; }

        /// <summary>
        /// The url to load.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Url
        {
            get
            {
                return (string)GetValue(UrlProperty);
            }
            set
            {
                SetValue(UrlProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Deprecated. The cache model of the current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheModel CacheModel
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
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string UserAgent
        {
            get
            {
                return (string)GetValue(UserAgentProperty);
            }
            set
            {
                SetValue(UserAgentProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Deprecated. Whether JavaScript is enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableJavaScript
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
                Vector2 pv = (Vector2)GetValue(ScrollPositionProperty);
                return new Position(pv.X, pv.Y);
            }
            set
            {
                if (value != null)
                {
                    Position pv = value;
                    Vector2 vpv = new Vector2(pv.X, pv.Y);
                    SetValue(ScrollPositionProperty, vpv);
                    NotifyPropertyChanged();
                }
            }
        }

        /// <summary>
        /// The size of scroll, read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ScrollSize
        {
            get
            {
                Vector2 sv = (Vector2)GetValue(ScrollSizeProperty);
                return new Size(sv.Width, sv.Height);
            }
        }

        /// <summary>
        /// The size of content, read-only.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Size ContentSize
        {
            get
            {
                Vector2 sv = (Vector2)GetValue(ContentSizeProperty);
                return new Size(sv.Width, sv.Height);
            }
        }

        /// <summary>
        /// Whether video hole is enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool VideoHoleEnabled
        {
            get
            {
                return (bool)GetValue(VideoHoleEnabledProperty);
            }
            set
            {
                SetValue(VideoHoleEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether mouse events are enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool MouseEventsEnabled
        {
            get
            {
                return (bool)GetValue(MouseEventsEnabledProperty);
            }
            set
            {
                SetValue(MouseEventsEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether key events are enabled or not.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool KeyEventsEnabled
        {
            get
            {
                return (bool)GetValue(KeyEventsEnabledProperty);
            }
            set
            {
                SetValue(KeyEventsEnabledProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Background color of web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Color ContentBackgroundColor
        {
            get
            {
                return (Color)GetValue(ContentBackgroundColorProperty);
            }
            set
            {
                SetValue(ContentBackgroundColorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether tiles are cleared or not when hidden.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool TilesClearedWhenHidden
        {
            get
            {
                return (bool)GetValue(TilesClearedWhenHiddenProperty);
            }
            set
            {
                SetValue(TilesClearedWhenHiddenProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Multiplier of cover area of tile when web page is rendered.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TileCoverAreaMultiplier
        {
            get
            {
                return (float)GetValue(TileCoverAreaMultiplierProperty);
            }
            set
            {
                SetValue(TileCoverAreaMultiplierProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether cursor is enabled or not by client.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CursorEnabledByClient
        {
            get
            {
                return (bool)GetValue(CursorEnabledByClientProperty);
            }
            set
            {
                SetValue(CursorEnabledByClientProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets selected text in web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string SelectedText
        {
            get
            {
                return (string)GetValue(SelectedTextProperty);
            }
        }

        /// <summary>
        /// Gets title of web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string Title
        {
            get
            {
                return (string)GetValue(TitleProperty);
            }
        }

        /// <summary>
        /// Gets favicon of web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
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
                return (float)GetValue(PageZoomFactorProperty);
            }
            set
            {
                SetValue(PageZoomFactorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Zoom factor of text in web page.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float TextZoomFactor
        {
            get
            {
                return (float)GetValue(TextZoomFactorProperty);
            }
            set
            {
                SetValue(TextZoomFactorProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Gets percentage of loading progress.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public float LoadProgressPercentage
        {
            get
            {
                return (float)GetValue(LoadProgressPercentageProperty);
            }
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

        private static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(WebView), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.Url, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.Url).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty UserAgentProperty = BindableProperty.Create(nameof(UserAgent), typeof(string), typeof(WebView), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.UserAgent, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.UserAgent).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty ScrollPositionProperty = BindableProperty.Create(nameof(ScrollPosition), typeof(Vector2), typeof(WebView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.ScrollPosition, new Tizen.NUI.PropertyValue((Vector2)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.ScrollPosition).Get(temp);
            return temp;
        });

        private static readonly BindableProperty ScrollSizeProperty = BindableProperty.Create(nameof(ScrollSize), typeof(Vector2), typeof(WebView), null, defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.ScrollSize).Get(temp);
            return temp;
        });

        private static readonly BindableProperty ContentSizeProperty = BindableProperty.Create(nameof(ContentSize), typeof(Vector2), typeof(WebView), null, defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            Vector2 temp = new Vector2(0.0f, 0.0f);
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.ContentSize).Get(temp);
            return temp;
        });

        private static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(WebView), string.Empty, defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string title;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.Title).Get(out title);
            return title;
        });

        private static readonly BindableProperty VideoHoleEnabledProperty = BindableProperty.Create(nameof(VideoHoleEnabled), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.VideoHoleEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.VideoHoleEnabled).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty MouseEventsEnabledProperty = BindableProperty.Create(nameof(MouseEventsEnabled), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.MouseEventsEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.MouseEventsEnabled).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty KeyEventsEnabledProperty = BindableProperty.Create(nameof(KeyEventsEnabled), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.KeyEventsEnabled, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.KeyEventsEnabled).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty ContentBackgroundColorProperty = BindableProperty.Create(nameof(ContentBackgroundColor), typeof(Vector4), typeof(WebView), null, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                webview.contentBackgroundColor = (Vector4)newValue;
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.DocumentBackgroundColor, new Tizen.NUI.PropertyValue((Vector4)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            return webview.contentBackgroundColor;
        });

        private static readonly BindableProperty TilesClearedWhenHiddenProperty = BindableProperty.Create(nameof(TilesClearedWhenHidden), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                webview.tilesClearedWhenHidden = (bool)newValue;
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.TilesClearedWhenHidden, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            return webview.tilesClearedWhenHidden;
        });

        private static readonly BindableProperty TileCoverAreaMultiplierProperty = BindableProperty.Create(nameof(TileCoverAreaMultiplier), typeof(float), typeof(WebView), 0.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                webview.tileCoverAreaMultiplier = (float)newValue;
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.TileCoverAreaMultiplier, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            return webview.tileCoverAreaMultiplier;
        });

        private static readonly BindableProperty CursorEnabledByClientProperty = BindableProperty.Create(nameof(CursorEnabledByClient), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                webview.cursorEnabledByClient = (bool)newValue;
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.CursorEnabledByClient, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            return webview.cursorEnabledByClient;
        });

        private static readonly BindableProperty SelectedTextProperty = BindableProperty.Create(nameof(SelectedText), typeof(string), typeof(WebView), string.Empty, defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string text;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.SelectedText).Get(out text);
            return text;
        });

        private static readonly BindableProperty PageZoomFactorProperty = BindableProperty.Create(nameof(PageZoomFactor), typeof(float), typeof(WebView), 0.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.PageZoomFactor, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            float temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.PageZoomFactor).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty TextZoomFactorProperty = BindableProperty.Create(nameof(TextZoomFactor), typeof(float), typeof(WebView), 0.0f, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.SwigCPtr, WebView.Property.TextZoomFactor, new Tizen.NUI.PropertyValue((float)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            float temp;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.TextZoomFactor).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty LoadProgressPercentageProperty = BindableProperty.Create(nameof(LoadProgressPercentage), typeof(float), typeof(WebView), 0.0f, defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            float percentage;
            Tizen.NUI.Object.GetProperty(webview.SwigCPtr, WebView.Property.LoadProgressPercentage).Get(out percentage);
            return percentage;
        });

        // For rooting handlers
        internal Dictionary<string, JavaScriptMessageHandler> handlerRootMap = new Dictionary<string, JavaScriptMessageHandler>();

        /// <summary>
        /// Loads a html.
        /// <param name="url">The path of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadUrl(string url)
        {
            Interop.WebView.LoadUrl(SwigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Deprecated. Loads a html by string.
        /// <param name="data">The data of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHTMLString(string data)
        {
            Interop.WebView.LoadHtmlString(SwigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Loads a html by string.
        /// <param name="data">The data of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHtmlString(string data)
        {
            Interop.WebView.LoadHtmlString(SwigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Loads the specified html as the content of the view to override current history entry.
        /// <param name="html">The html to be loaded</param>
        /// <param name="baseUri">Base URL used for relative paths to external objects</param>
        /// <param name="unreachableUri">URL that could not be reached</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadHtmlStringOverrideCurrentEntry(string html, string baseUri, string unreachableUri)
        {
            bool result = Interop.WebView.LoadHtmlStringOverrideCurrentEntry(SwigCPtr, html, baseUri, unreachableUri);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Requests to load the given contents by MIME type.
        /// <param name="contents">The contents to be loaded</param>
        /// <param name="contentSize">The size of contents (in bytes)</param>
        /// <param name="mimeType">The type of contents, "text/html" is assumed if null</param>
        /// <param name="encoding">The encoding for contents, "UTF-8" is assumed if null</param>
        /// <param name="baseUri">The base URI to use for relative resources</param>
        /// </summary>
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
        /// Adds custom header.
        /// <param name="name">The name of custom header</param>
        /// <param name="value">The value of custom header</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool AddCustomHeader(string name, string value)
        {
            bool result = Interop.WebView.AddCustomHeader(SwigCPtr, name, value);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Removes custom header.
        /// <param name="name">The name of custom header</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool RemoveCustomHeader(string name)
        {
            bool result = Interop.WebView.RemoveCustomHeader(SwigCPtr, name);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Starts the inspector server.
        /// <param name="port">The port number</param>
        /// </summary>
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
        /// Scrolls page of web view by deltaX and detlaY.
        /// <param name="deltaX">The deltaX of scroll</param>
        /// <param name="deltaY">The deltaY of scroll</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ScrollBy(int deltaX, int deltaY)
        {
            Interop.WebView.ScrollBy(SwigCPtr, deltaX, deltaY);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Scrolls edge of web view by deltaX and deltaY.
        /// <param name="deltaX">The deltaX of scroll</param>
        /// <param name="deltaY">The deltaY of scroll</param>
        /// </summary>
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
        /// <returns>True if backward is possible, false otherwise</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoBack()
        {
            bool ret = Interop.WebView.CanGoBack(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Returns whether forward is possible.
        /// <returns>True if forward is possible, false otherwise</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoForward()
        {
            bool ret = Interop.WebView.CanGoForward(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Evaluates JavaScript code represented as a string.
        /// <param name="script">The JavaScript code</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EvaluateJavaScript(string script)
        {
            Interop.WebView.EvaluateJavaScript(SwigCPtr, script, new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add a message handler into the WebView.
        /// <param name="objectName">The name of exposed object</param>
        /// <param name="handler">The callback function</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddJavaScriptMessageHandler(string objectName, JavaScriptMessageHandler handler)
        {
            if (handlerRootMap.ContainsKey(objectName))
            {
                return;
            }

            handlerRootMap.Add(objectName, handler);

            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(handler);
            Interop.WebView.AddJavaScriptMessageHandler(SwigCPtr, objectName, new System.Runtime.InteropServices.HandleRef(this, ip));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add a message handler into the WebView.
        /// <param name="callback">The callback function</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptAlertCallback(JavaScriptAlertCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
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
        /// Add a message handler into the WebView.
        /// <param name="callback">The callback function</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptConfirmCallback(JavaScriptConfirmCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebView.RegisterJavaScriptConfirmCallback(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reply for confirm popup.
        /// <param name="confirmed">confirmed or not</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void JavaScriptConfirmReply(bool confirmed)
        {
            Interop.WebView.JavaScriptConfirmReply(SwigCPtr, confirmed);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Add a message handler into the WebView.
        /// <param name="callback">The callback function</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterJavaScriptPromptCallback(JavaScriptPromptCallback callback)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebView.RegisterJavaScriptPromptCallback(SwigCPtr, new System.Runtime.InteropServices.HandleRef(this, ip));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reply for prompt popup.
        /// <param name="result">text in prompt input field.</param>
        /// </summary>
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
        /// Scales the current page, centered at the given point.
        /// <param name="scaleFactor">The new factor to be scaled</param>
        /// <param name="point">The center coordinate</param>
        /// </summary>
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
        /// <param name="activated">The new factor to be scaled</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ActivateAccessibility(bool activated)
        {
            Interop.WebView.ActivateAccessibility(SwigCPtr, activated);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Searches and highlights the given string in the document.
        /// <param name="text">The text to be searched</param>
        /// <param name="options">The options to search</param>
        /// <param name="maxMatchCount">The maximum match count to search</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool HighlightText(string text, FindOption options, uint maxMatchCount)
        {
            bool result = Interop.WebView.HighlightText(SwigCPtr, text, (int)options, maxMatchCount);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return result;
        }

        /// <summary>
        /// Adds dynamic certificate path.
        /// <param name="host">Host that required client authentication</param>
        /// <param name="certPath">The file path stored certificate</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void AddDynamicCertificatePath(string host, string certPath)
        {
            Interop.WebView.AddDynamicCertificatePath(SwigCPtr, host, certPath);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Get snapshot of the specified viewArea of page.
        /// <param name="viewArea">Host that required client authentication</param>
        /// <param name="scaleFactor">The file path stored certificate</param>
        /// </summary>
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
        /// <param name="viewArea">Host that required client authentication</param>
        /// <param name="scaleFactor">The file path stored certificate</param>
        /// <param name="callback">The callback for getting screen shot</param>
        /// </summary>
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
        /// Asynchronous requests to check if there is a video playing in the given view.
        /// <param name="callback">The callback called after checking if video is playing or not</param>
        /// </summary>
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
        /// <param name="callback">The callback for requesting geolocation permission</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void RegisterGeolocationPermissionCallback(GeolocationPermissionCallback callback)
        {
            System.IntPtr ip = Marshal.GetFunctionPointerForDelegate(callback);
            Interop.WebView.RegisterGeolocationPermissionCallback(SwigCPtr, new HandleRef(this, ip));
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Does hit test synchronously.
        /// <param name="x">the horizontal position to query</param>
        /// <param name="y">the vertical position to query</param>
        /// <param name="mode">the mode of hit test</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebHitTestResult HitTest(int x, int y, HitTestMode mode)
        {
            System.IntPtr result = Interop.WebView.CreateHitTest(SwigCPtr, x, y, (int)mode);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return new WebHitTestResult(result, true);
        }

        /// <summary>
        /// Does hit test asynchronously.
        /// <param name="x">the horizontal position to query</param>
        /// <param name="y">the vertical position to query</param>
        /// <param name="mode">the mode of hit test</param>
        /// <param name="callback">the callback that is called after hit test is finished.</param>
        /// </summary>
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

        internal static WebView DownCast(BaseHandle handle)
        {
            WebView ret = new WebView(Interop.WebView.DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.SwigCPtr;
        }

        internal WebView Assign(WebView webView)
        {
            WebView ret = new WebView(Interop.WebView.Assign(SwigCPtr, WebView.getCPtr(webView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        private void OnPageLoadStarted(IntPtr data, string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            pageLoadStartedEventHandler?.Invoke(this, e);
        }

        private void OnPageLoading(IntPtr data, string pageUrl)
        {
            pageLoadingEventHandler?.Invoke(this, new WebViewPageLoadEventArgs());
        }

        private void OnPageLoadFinished(IntPtr data, string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            pageLoadFinishedEventHandler?.Invoke(this, e);
        }

        private void OnPageLoadError(IntPtr data, IntPtr error)
        {
            pageLoadErrorEventHandler?.Invoke(this, new WebViewPageLoadErrorEventArgs(new WebPageLoadError(error, false)));
        }

        private void OnScrollEdgeReached(IntPtr data, int edge)
        {
            scrollEdgeReachedEventHandler?.Invoke(this, new WebViewScrollEdgeReachedEventArgs((WebViewScrollEdgeReachedEventArgs.Edge)edge));
        }

        private void OnUrlChanged(IntPtr data, string pageUrl)
        {
            urlChangedEventHandler?.Invoke(this, new WebViewUrlChangedEventArgs(pageUrl));
        }

        private void OnFormRepostPolicyDecided(IntPtr data, IntPtr decision)
        {
            formRepostPolicyDecidedEventHandler?.Invoke(this, new WebViewFormRepostPolicyDecidedEventArgs(new WebFormRepostPolicyDecisionMaker(decision, false)));
        }

        private void OnFrameRendered(IntPtr data)
        {
            frameRenderedEventHandler?.Invoke(this, new EventArgs());
        }

        private void OnScreenshotAcquired(IntPtr data)
        {
            ImageView image = new ImageView(data, true);
            screenshotAcquiredCallback?.Invoke(image);
            image.Dispose();
        }

        private void OnResponsePolicyDecided(IntPtr data, IntPtr maker)
        {
            responsePolicyDecidedEventHandler?.Invoke(this, new WebViewResponsePolicyDecidedEventArgs(new WebPolicyDecisionMaker(maker, false)));
        }

        private void OnCertificateConfirmed(IntPtr data, IntPtr certificate)
        {
            certificateConfirmedEventHandler?.Invoke(this, new WebViewCertificateReceivedEventArgs(new WebCertificate(certificate, false)));
        }

        private void OnSslCertificateChanged(IntPtr data, IntPtr certificate)
        {
            sslCertificateChangedEventHandler?.Invoke(this, new WebViewCertificateReceivedEventArgs(new WebCertificate(certificate, false)));
        }

        private void OnHttpAuthRequested(IntPtr data, IntPtr handler)
        {
            httpAuthRequestedEventHandler?.Invoke(this, new WebViewHttpAuthRequestedEventArgs(new WebHttpAuthHandler(handler, false)));
        }

        private void OnHttpRequestIntercepted(IntPtr data, IntPtr interceptor)
        {
            httpRequestInterceptedEventHandler?.Invoke(this, new WebViewHttpRequestInterceptedEventArgs(new WebHttpRequestInterceptor(interceptor, false)));
        }

        private void OnConsoleMessageReceived(IntPtr data, IntPtr message)
        {
            consoleMessageReceivedEventHandler?.Invoke(this, new WebViewConsoleMessageReceivedEventArgs(new WebConsoleMessage(message, false)));
        }

        private void OnContextMenuCustomized(IntPtr data, IntPtr menu)
        {
            contextMenuCustomizedEventHandler?.Invoke(this, new WebViewContextMenuCustomizedEventArgs(new WebContextMenu(menu, false)));
        }

        private void OnContextMenuItemSelected(IntPtr data, IntPtr item)
        {
            contextMenuItemSelectedEventHandler?.Invoke(this, new WebViewContextMenuItemSelectedEventArgs(new WebContextMenuItem(item, false)));
        }

        private void OnHitTestFinished(IntPtr test)
        {
            WebHitTestResult hitTest = new WebHitTestResult(test, true);
            hitTestFinishedCallback?.Invoke(hitTest);
            hitTest.Dispose();
        }
    }
}
