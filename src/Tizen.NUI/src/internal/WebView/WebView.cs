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

                BackForwardList.Dispose();
                Context.Dispose();
                CookieManager.Dispose();
                Settings.Dispose();
            }

            base.Dispose(type);
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

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadCallbackDelegate(IntPtr data, string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadErrorCallbackDelegate(IntPtr data, string pageUrl, int errorCode);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewScrollEdgeReachedCallbackDelegate(IntPtr data, int edge);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewUrlChangedCallbackDelegate(IntPtr data, string pageUrl);

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
                    pageLoadErrorCallback = (OnPageLoadError);
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
                return Settings.EnableJavaScript;
            }
            set
            {
                Settings.EnableJavaScript = value;
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
                return Settings.AllowImagesLoadAutomatically;
            }
            set
            {
                Settings.AllowImagesLoadAutomatically = value;
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
        /// The postion of scroll.
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
        /// Gets fav icon.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ImageView Favicon
        {
            get
            {
                global::System.IntPtr imageView = Interop.WebView.GetFavicon(SwigCPtr);
                if (NDalicPINVOKE.SWIGPendingException.Pending)
                    return null;
                return new ImageView(imageView, false);
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

        private static readonly BindableProperty TitleProperty = BindableProperty.Create(nameof(Title), typeof(string), typeof(WebView), null, defaultValueCreator: (bindable) =>
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
        /// Reloads the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reload()
        {
            Interop.WebView.Reload(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
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
        /// Scroll web view by deltaX and detlaY.
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
        /// Reply for promp popup.
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

        /// This will not be public opened.
        /// <param name="swigCPtr"></param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ReleaseSwigCPtr(System.Runtime.InteropServices.HandleRef swigCPtr)
        {
            Interop.WebView.DeleteWebView(swigCPtr);
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

        private void OnPageLoadError(IntPtr data, string pageUrl, int errorCode)
        {
            WebViewPageLoadErrorEventArgs e = new WebViewPageLoadErrorEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;
            e.ErrorCode = (WebViewPageLoadErrorEventArgs.LoadErrorCode)errorCode;

            pageLoadErrorEventHandler?.Invoke(this, e);
        }

        private void OnScrollEdgeReached(IntPtr data, int edge)
        {
            WebViewScrollEdgeReachedEventArgs arg = new WebViewScrollEdgeReachedEventArgs((WebViewScrollEdgeReachedEventArgs.Edge)edge);
            scrollEdgeReachedEventHandler?.Invoke(this, arg);
        }

        private void OnUrlChanged(IntPtr data, string pageUrl)
        {
            urlChangedEventHandler?.Invoke(this, new WebViewUrlChangedEventArgs(pageUrl));
        }
    }
}
