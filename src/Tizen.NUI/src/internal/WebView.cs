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

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadCallbackDelegate(IntPtr data, string pageUrl);

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewPageLoadErrorCallbackDelegate(IntPtr data, string pageUrl, int errorCode);

        private readonly WebViewPageLoadSignal pageLoadStartedSignal;
        private EventHandler<WebViewPageLoadEventArgs> pageLoadStartedEventHandler;
        private WebViewPageLoadCallbackDelegate pageLoadStartedCallback;

        private readonly WebViewPageLoadSignal pageLoadFinishedSignal;
        private EventHandler<WebViewPageLoadEventArgs> pageLoadFinishedEventHandler;
        private WebViewPageLoadCallbackDelegate pageLoadFinishedCallback;

        private readonly WebViewPageLoadErrorSignal pageLoadErrorSignal;
        private EventHandler<WebViewPageLoadErrorEventArgs> pageLoadErrorEventHandler;
        private WebViewPageLoadErrorCallbackDelegate pageLoadErrorCallback;

        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WebView.Upcast(cPtr), cMemoryOwn)
        {

            pageLoadStartedSignal = new WebViewPageLoadSignal(Interop.WebView.NewWebViewPageLoadSignalPageLoadStarted(SwigCPtr));
            pageLoadFinishedSignal = new WebViewPageLoadSignal(Interop.WebView.NewWebViewPageLoadSignalPageLoadFinished(SwigCPtr));
            pageLoadErrorSignal = new WebViewPageLoadErrorSignal(Interop.WebView.NewWebViewPageLoadErrorSignalPageLoadError(SwigCPtr));
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

        internal static WebView DownCast(BaseHandle handle)
        {
            WebView ret = new WebView(Interop.WebView.DownCast(BaseHandle.getCPtr(handle)), true);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
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
                pageLoadFinishedSignal.Dispose();
                pageLoadErrorSignal.Dispose();
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

        private void OnPageLoadStarted(IntPtr data, string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            if (pageLoadStartedEventHandler != null)
            {
                pageLoadStartedEventHandler(this, e);
            }
        }

        private void OnPageLoadFinished(IntPtr data, string pageUrl)
        {
            WebViewPageLoadEventArgs e = new WebViewPageLoadEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            if (pageLoadFinishedEventHandler != null)
            {
                pageLoadFinishedEventHandler(this, e);
            }
        }

        private void OnPageLoadError(IntPtr data, string pageUrl, int errorCode)
        {
            WebViewPageLoadErrorEventArgs e = new WebViewPageLoadErrorEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;
            e.ErrorCode = (WebViewPageLoadErrorEventArgs.LoadErrorCode)errorCode;

            if (pageLoadErrorEventHandler != null)
            {
                pageLoadErrorEventHandler(this, e);
            }
        }

        internal static new class Property
        {
            internal static readonly int URL = Interop.WebView.UrlGet();
            internal static readonly int CacheModel = Interop.WebView.CacheModelGet();
            internal static readonly int CookieAcceptPolicy = Interop.WebView.CookieAcceptPolicyGet();
            internal static readonly int UserAgent = Interop.WebView.UserAgentGet();
            internal static readonly int EnableJavascript = Interop.WebView.EnableJavascriptGet();
            internal static readonly int LoadImagesAutomatically = Interop.WebView.LoadImagesAutomaticallyGet();
            internal static readonly int DefaultTextEncodingName = Interop.WebView.DefaultTextEncodingNameGet();
            internal static readonly int DefaultFontSize = Interop.WebView.DefaultFontSizeGet();
        }

        private static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(WebView), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.URL, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.URL).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty CacheModelProperty = BindableProperty.Create(nameof(CacheModel), typeof(CacheModel), typeof(WebView), CacheModel.DocumentViewer, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.CacheModel, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.CacheModel).Get(out temp) == false)
            {
                NUILog.Error("CacheModel get error!");
            }
            switch (temp)
            {
                case "DOCUMENT_VIEWER": return CacheModel.DocumentViewer;
                case "DOCUMENT_BROWSER": return CacheModel.DocumentBrowser;
                default: return CacheModel.PrimaryWebBrowser;
            }
        }));

        private static readonly BindableProperty CookieAcceptPolicyProperty = BindableProperty.Create(nameof(CookieAcceptPolicy), typeof(CookieAcceptPolicy), typeof(WebView), CookieAcceptPolicy.NoThirdParty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.CookieAcceptPolicy, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.CookieAcceptPolicy).Get(out temp) == false)
            {
                NUILog.Error("CookieAcceptPolicy get error!");
            }
            switch (temp)
            {
                case "ALWAYS": return CookieAcceptPolicy.Always;
                case "NEVER": return CookieAcceptPolicy.Never;
                default: return CookieAcceptPolicy.NoThirdParty;
            }
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

        private static readonly BindableProperty EnableJavaScriptProperty = BindableProperty.Create(nameof(EnableJavaScript), typeof(bool), typeof(WebView), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.EnableJavascript, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.EnableJavascript).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty LoadImagesAutomaticallyProperty = BindableProperty.Create(nameof(LoadImagesAutomatically), typeof(bool), typeof(WebView), true, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.LoadImagesAutomatically, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.LoadImagesAutomatically).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty DefaultTextEncodingNameProperty = BindableProperty.Create(nameof(DefaultTextEncodingName), typeof(string), typeof(WebView), string.Empty, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.DefaultTextEncodingName, new Tizen.NUI.PropertyValue((string)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.DefaultTextEncodingName).Get(out temp);
            return temp;
        }));

        private static readonly BindableProperty DefaultFontSizeProperty = BindableProperty.Create(nameof(DefaultFontSize), typeof(int), typeof(WebView), 16, propertyChanged: (BindableProperty.BindingPropertyChangedDelegate)((bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty((HandleRef)webview.SwigCPtr, WebView.Property.DefaultFontSize, new Tizen.NUI.PropertyValue((int)newValue));
            }
        }),
        defaultValueCreator: (BindableProperty.CreateDefaultValueDelegate)((bindable) =>
        {
            var webview = (WebView)bindable;
            int temp;
            Tizen.NUI.Object.GetProperty((HandleRef)webview.SwigCPtr, WebView.Property.DefaultFontSize).Get(out temp);
            return temp;
        }));

        /// <summary>
        /// Creates an uninitialized WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView() : this(Interop.WebView.New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an uninitialized WebView.
        /// <param name="locale">The locale of Web</param>
        /// <param name="timezoneId">The timezoneId of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string locale, string timezoneId) : this(Interop.WebView.New2(locale, timezoneId), true)
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
        /// The cache model of the current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CacheModel CacheModel
        {
            get
            {
                return (CacheModel)GetValue(CacheModelProperty);
            }
            set
            {
                SetValue(CacheModelProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// The cookie acceptance policy.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public CookieAcceptPolicy CookieAcceptPolicy
        {
            get
            {
                return (CookieAcceptPolicy)GetValue(CookieAcceptPolicyProperty);
            }
            set
            {
                SetValue(CookieAcceptPolicyProperty, value);
                NotifyPropertyChanged();
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
        /// Whether JavaScript is enabled.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool EnableJavaScript
        {
            get
            {
                return (bool)GetValue(EnableJavaScriptProperty);
            }
            set
            {
                SetValue(EnableJavaScriptProperty, value);
                NotifyPropertyChanged();
            }
        }

        /// <summary>
        /// Whether images can be loaded automatically.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool LoadImagesAutomatically
        {
            get
            {
                return (bool)GetValue(LoadImagesAutomaticallyProperty);
            }
            set
            {
                SetValue(LoadImagesAutomaticallyProperty, value);
                NotifyPropertyChanged();
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
                return (string)GetValue(DefaultTextEncodingNameProperty);
            }
            set
            {
                SetValue(DefaultTextEncodingNameProperty, value);
                NotifyPropertyChanged();
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
                return (int)GetValue(DefaultFontSizeProperty);
            }
            set
            {
                SetValue(DefaultFontSizeProperty, value);
                NotifyPropertyChanged();
            }
        }

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
        /// Returns the URL of the Web
        /// <param name="data">The data of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHTMLString(string data)
        {
            Interop.WebView.LoadHTMLString(SwigCPtr, data);
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
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptMessageHandler(string message);

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

        // For rooting handlers
        internal Dictionary<string, JavaScriptMessageHandler> handlerRootMap = new Dictionary<string, JavaScriptMessageHandler>();

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
        /// Clears the history of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearHistory()
        {
            Interop.WebView.ClearHistory(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the cache of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Interop.WebView.ClearCache(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears all the cookies of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCookies()
        {
            Interop.WebView.ClearCookies(SwigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
