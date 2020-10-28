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

        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WebView.WebView_SWIGUpcast(cPtr), cMemoryOwn)
        {

            pageLoadStartedSignal = new WebViewPageLoadSignal(Interop.WebView.new_WebViewPageLoadSignal_PageLoadStarted(swigCPtr));
            pageLoadFinishedSignal = new WebViewPageLoadSignal(Interop.WebView.new_WebViewPageLoadSignal_PageLoadFinished(swigCPtr));
            pageLoadErrorSignal = new WebViewPageLoadErrorSignal(Interop.WebView.new_WebViewPageLoadErrorSignal_PageLoadError(swigCPtr));
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }

        internal WebView Assign(WebView webView)
        {
            WebView ret = new WebView(Interop.WebView.WebView_Assign(swigCPtr, WebView.getCPtr(webView)), false);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static WebView DownCast(BaseHandle handle)
        {
            WebView ret = new WebView(Interop.WebView.WebView_DownCast(BaseHandle.getCPtr(handle)), true);
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
            Interop.WebView.delete_WebView(swigCPtr);
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
            internal static readonly int URL = Interop.WebView.WebView_Property_URL_get();
            internal static readonly int CACHE_MODEL = Interop.WebView.WebView_Property_CACHE_MODEL_get();
            internal static readonly int COOKIE_ACCEPT_POLICY = Interop.WebView.WebView_Property_COOKIE_ACCEPT_POLICY_get();
            internal static readonly int USER_AGENT = Interop.WebView.WebView_Property_USER_AGENT_get();
            internal static readonly int ENABLE_JAVASCRIPT = Interop.WebView.WebView_Property_ENABLE_JAVASCRIPT_get();
            internal static readonly int LOAD_IMAGES_AUTOMATICALLY = Interop.WebView.WebView_Property_LOAD_IMAGES_AUTOMATICALLY_get();
            internal static readonly int DEFAULT_TEXT_ENCODING_NAME = Interop.WebView.WebView_Property_DEFAULT_TEXT_ENCODING_NAME_get();
            internal static readonly int DEFAULT_FONT_SIZE = Interop.WebView.WebView_Property_DEFAULT_FONT_SIZE_get();
        }

        private static readonly BindableProperty UrlProperty = BindableProperty.Create(nameof(Url), typeof(string), typeof(WebView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.URL, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.URL).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty CacheModelProperty = BindableProperty.Create(nameof(CacheModel), typeof(CacheModel), typeof(WebView), CacheModel.DocumentViewer, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.CACHE_MODEL, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.CACHE_MODEL).Get(out temp) == false)
            {
                NUILog.Error("CacheModel get error!");
            }
            switch (temp)
            {
                case "DOCUMENT_VIEWER": return CacheModel.DocumentViewer;
                case "DOCUMENT_BROWSER": return CacheModel.DocumentBrowser;
                default: return CacheModel.PrimaryWebBrowser;
            }
        });

        private static readonly BindableProperty CookieAcceptPolicyProperty = BindableProperty.Create(nameof(CookieAcceptPolicy), typeof(CookieAcceptPolicy), typeof(WebView), CookieAcceptPolicy.NoThirdParty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.COOKIE_ACCEPT_POLICY, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            if (Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.COOKIE_ACCEPT_POLICY).Get(out temp) == false)
            {
                NUILog.Error("CookieAcceptPolicy get error!");
            }
            switch (temp)
            {
                case "ALWAYS": return CookieAcceptPolicy.Always;
                case "NEVER": return CookieAcceptPolicy.Never;
                default: return CookieAcceptPolicy.NoThirdParty;
            }
        });

        private static readonly BindableProperty UserAgentProperty = BindableProperty.Create(nameof(UserAgent), typeof(string), typeof(WebView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.USER_AGENT, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.USER_AGENT).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty EnableJavaScriptProperty = BindableProperty.Create(nameof(EnableJavaScript), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.ENABLE_JAVASCRIPT, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.ENABLE_JAVASCRIPT).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty LoadImagesAutomaticallyProperty = BindableProperty.Create(nameof(LoadImagesAutomatically), typeof(bool), typeof(WebView), true, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.LOAD_IMAGES_AUTOMATICALLY, new Tizen.NUI.PropertyValue((bool)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            bool temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.LOAD_IMAGES_AUTOMATICALLY).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty DefaultTextEncodingNameProperty = BindableProperty.Create(nameof(DefaultTextEncodingName), typeof(string), typeof(WebView), string.Empty, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.DEFAULT_TEXT_ENCODING_NAME, new Tizen.NUI.PropertyValue((string)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            string temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.DEFAULT_TEXT_ENCODING_NAME).Get(out temp);
            return temp;
        });

        private static readonly BindableProperty DefaultFontSizeProperty = BindableProperty.Create(nameof(DefaultFontSize), typeof(int), typeof(WebView), 16, propertyChanged: (bindable, oldValue, newValue) =>
        {
            var webview = (WebView)bindable;
            if (newValue != null)
            {
                Tizen.NUI.Object.SetProperty(webview.swigCPtr, WebView.Property.DEFAULT_FONT_SIZE, new Tizen.NUI.PropertyValue((int)newValue));
            }
        },
        defaultValueCreator: (bindable) =>
        {
            var webview = (WebView)bindable;
            int temp;
            Tizen.NUI.Object.GetProperty(webview.swigCPtr, WebView.Property.DEFAULT_FONT_SIZE).Get(out temp);
            return temp;
        });

        /// <summary>
        /// Creates an uninitialized WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView() : this(Interop.WebView.WebView_New(), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an uninitialized WebView.
        /// <param name="locale">The locale of Web</param>
        /// <param name="timezoneId">The timezoneId of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string locale, string timezoneId) : this(Interop.WebView.WebView_New_2(locale, timezoneId), true)
        {
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// <param name="webView">WebView to copy. The copied WebView will point at the same implementation</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(WebView webView) : this(Interop.WebView.new_WebView__SWIG_1(WebView.getCPtr(webView)), true)
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
            Interop.WebView.WebView_LoadUrl(swigCPtr, url);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the URL of the Web
        /// <param name="data">The data of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHTMLString(string data)
        {
            Interop.WebView.WebView_LoadHTMLString(swigCPtr, data);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reloads the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reload()
        {
            Interop.WebView.WebView_Reload(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops loading the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopLoading()
        {
            Interop.WebView.WebView_StopLoading(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Suspends the operation.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Suspend()
        {
            Interop.WebView.WebView_Suspend(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Resumes the operation after calling Suspend()
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Resume()
        {
            Interop.WebView.WebView_Resume(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Goes to the back
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoBack()
        {
            Interop.WebView.WebView_GoBack(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Goes to the forward
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoForward()
        {
            Interop.WebView.WebView_GoForward(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether backward is possible.
        /// <returns>True if backward is possible, false otherwise</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoBack()
        {
            bool ret = Interop.WebView.WebView_CanGoBack(swigCPtr);
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
            bool ret = Interop.WebView.WebView_CanGoForward(swigCPtr);
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
            Interop.WebView.WebView_EvaluateJavaScript(swigCPtr, script, new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero));
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
            Interop.WebView.WebView_AddJavaScriptMessageHandler(swigCPtr, objectName, new System.Runtime.InteropServices.HandleRef(this, ip));

            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the history of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearHistory()
        {
            Interop.WebView.WebView_ClearHistory(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the cache of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Interop.WebView.WebView_ClearCache(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears all the cookies of current WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCookies()
        {
            Interop.WebView.WebView_ClearCookies(swigCPtr);
            if (NDalicPINVOKE.SWIGPendingException.Pending) throw NDalicPINVOKE.SWIGPendingException.Retrieve();
        }
    }
}
