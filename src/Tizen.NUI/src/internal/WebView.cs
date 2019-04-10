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

namespace Tizen.NUI
{
    /// <summary>
    /// WebView
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebView : View
    {
        private global::System.Runtime.InteropServices.HandleRef swigCPtr;
        internal WebView(global::System.IntPtr cPtr, bool cMemoryOwn) : base(Interop.WebView.WebView_SWIGUpcast(cPtr), cMemoryOwn)
        {
            swigCPtr = new global::System.Runtime.InteropServices.HandleRef(this, cPtr);

            InitializeSignals();
        }

        private global::System.Runtime.InteropServices.HandleRef pageLoadStartedSignalProxy;
        private global::System.Runtime.InteropServices.HandleRef pageLoadFinishedSignalProxy;
        private void InitializeSignals()
        {
            pageLoadStartedSignalProxy = new global::System.Runtime.InteropServices.HandleRef(this, Interop.WebView.new_WebViewSignalProxy_PageLoadStarted(swigCPtr));
            pageLoadFinishedSignalProxy = new global::System.Runtime.InteropServices.HandleRef(this, Interop.WebView.new_WebViewSignalProxy_PageLoadFinished(swigCPtr));
        }

        internal static global::System.Runtime.InteropServices.HandleRef getCPtr(WebView obj)
        {
            return (obj == null) ? new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero) : obj.swigCPtr;
        }


        /// <summary>
        /// To make Button instance be disposed.
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

            }

            //Release your own unmanaged resources here.
            //You should not access any managed member here except static instance.
            //because the execution order of Finalizes is non-deterministic.

            DisposeSignals();

            if (swigCPtr.Handle != global::System.IntPtr.Zero)
            {
                if (swigCMemOwn)
                {
                    swigCMemOwn = false;
                    Interop.WebView.delete_WebView(swigCPtr);
                }
                swigCPtr = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            base.Dispose(type);
        }

        private void DisposeSignals()
        {
            if (pageLoadStartedSignalProxy.Handle != global::System.IntPtr.Zero)
            {
                if (pageLoadStartedCallback != null)
                {
                    WebViewProxyDisconnect(pageLoadStartedSignalProxy, pageLoadStartedCallback);
                }
                Interop.WebView.delete_WebViewSignalProxy(pageLoadStartedSignalProxy);
                pageLoadStartedSignalProxy = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }

            if (pageLoadFinishedSignalProxy.Handle != global::System.IntPtr.Zero)
            {
                if (pageLoadFinishedCallback != null)
                {
                    WebViewProxyDisconnect(pageLoadFinishedSignalProxy, pageLoadFinishedCallback);
                }
                Interop.WebView.delete_WebViewSignalProxy(pageLoadFinishedSignalProxy);
                pageLoadFinishedSignalProxy = new global::System.Runtime.InteropServices.HandleRef(null, global::System.IntPtr.Zero);
            }
        }

        /// <summary>
        /// Creates an uninitialized WebView.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView() : this(Interop.WebView.WebView_New(), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();

        }

        /// <summary>
        /// Creates an uninitialized WebView.
        /// <param name="locale">The locale of Web</param>
        /// <param name="timezoneId">The timezoneId of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(string locale, string timezoneId) : this(Interop.WebView.WebView_New_2(locale, timezoneId), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Copy constructor.
        /// <param name="webView">WebView to copy. The copied WebView will point at the same implementation</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WebView(WebView webView) : this(Interop.WebView.new_WebView__SWIG_1(WebView.getCPtr(webView)), true)
        {
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        internal WebView Assign(WebView webView)
        {
            WebView ret = new WebView(Interop.WebView.WebView_Assign(swigCPtr, WebView.getCPtr(webView)), false);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        internal static WebView DownCast(BaseHandle handle)
        {
            WebView ret = new WebView(Interop.WebView.WebView_DownCast(BaseHandle.getCPtr(handle)), true);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Event arguments that passed via the webview signal.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public class WebViewEventArgs : EventArgs
        {
            private WebView _webView;
            /// <summary>
            /// The view for displaying webpages.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public WebView WebView
            {
                get
                {
                    return _webView;
                }
                set
                {
                    _webView = value;
                }
            }

            private string _pageUrl;
            /// <summary>
            /// The url string of current webpage.
            /// </summary>
            [EditorBrowsable(EditorBrowsableState.Never)]
            public string PageUrl
            {
                get
                {
                    return _pageUrl;
                }
                set
                {
                    _pageUrl = value;
                }
            }
        }

        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        private delegate void WebViewCallbackDelegate(IntPtr data, string pageUrl);

        private void WebViewProxyConnect(global::System.Runtime.InteropServices.HandleRef proxy, System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.WebView.WebViewSignalProxy_Connect(proxy, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
        }

        private void WebViewProxyDisconnect(global::System.Runtime.InteropServices.HandleRef proxy, System.Delegate func)
        {
            System.IntPtr ip = System.Runtime.InteropServices.Marshal.GetFunctionPointerForDelegate(func);
            {
                Interop.WebView.WebViewSignalProxy_Disconnect(proxy, new System.Runtime.InteropServices.HandleRef(this, ip));
                if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            }
        }

        private EventHandler<WebViewEventArgs> pageLoadStartedEventHandler;
        private WebViewCallbackDelegate pageLoadStartedCallback;

        /// <summary>
        /// Event for the PageLoadStarted signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has started.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewEventArgs> PageLoadStarted
        {
            add
            {
                if (pageLoadStartedEventHandler == null)
                {
                    pageLoadStartedCallback = (OnPageLoadStarted);
                    WebViewProxyConnect(pageLoadStartedSignalProxy, pageLoadStartedCallback);
                }
                pageLoadStartedEventHandler += value;
            }
            remove
            {
                pageLoadStartedEventHandler -= value;
                if (pageLoadStartedEventHandler == null && pageLoadStartedCallback != null)
                {
                    WebViewProxyDisconnect(pageLoadStartedSignalProxy, pageLoadStartedCallback);
                }
            }
        }

        private void OnPageLoadStarted(IntPtr data, string pageUrl)
        {
            WebViewEventArgs e = new WebViewEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            if (pageLoadStartedEventHandler != null)
            {
                pageLoadStartedEventHandler(this, e);
            }
        }

        private EventHandler<WebViewEventArgs> pageLoadFinishedEventHandler;
        private WebViewCallbackDelegate pageLoadFinishedCallback;

        /// <summary>
        /// Event for the PageLoadFinished signal which can be used to subscribe or unsubscribe the event handler.<br />
        /// This signal is emitted when page loading has finished.<br />
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public event EventHandler<WebViewEventArgs> PageLoadFinished
        {
            add
            {
                if (pageLoadFinishedEventHandler == null)
                {
                    pageLoadFinishedCallback = (OnPageLoadFinished);
                    WebViewProxyConnect(pageLoadFinishedSignalProxy, pageLoadFinishedCallback);
                }
                pageLoadFinishedEventHandler += value;
            }
            remove
            {
                pageLoadFinishedEventHandler -= value;
                if (pageLoadFinishedEventHandler == null && pageLoadFinishedCallback != null)
                {
                    WebViewProxyDisconnect(pageLoadFinishedSignalProxy, pageLoadFinishedCallback);
                }
            }
        }

        private void OnPageLoadFinished(IntPtr data, string pageUrl)
        {
            WebViewEventArgs e = new WebViewEventArgs();

            e.WebView = Registry.GetManagedBaseHandleFromNativePtr(data) as WebView;
            e.PageUrl = pageUrl;

            if (pageLoadFinishedEventHandler != null)
            {
                pageLoadFinishedEventHandler(this, e);
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
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns the URL of the Web
        /// <returns>Url of string type</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string GetUrl()
        {
            string url = Interop.WebView.WebView_GetUrl(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return url;
        }

        /// <summary>
        /// Returns the URL of the Web
        /// <param name="data">The data of Web</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void LoadHTMLString(string data)
        {
            Interop.WebView.WebView_LoadHTMLString(swigCPtr, data);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Reloads the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void Reload()
        {
            Interop.WebView.WebView_Reload(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Stops loading the Web
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void StopLoading()
        {
            Interop.WebView.WebView_StopLoading(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Goes to the back
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoBack()
        {
            Interop.WebView.WebView_GoBack(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Goes to the forward
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void GoForward()
        {
            Interop.WebView.WebView_GoForward(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Returns whether backward is possible.
        /// <returns>True if backward is possible, false otherwise</returns>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanGoBack()
        {
            bool ret = Interop.WebView.WebView_CanGoBack(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
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
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
            return ret;
        }

        /// <summary>
        /// Evaluates JavaScript code represented as a string.
        /// <param name="script">The JavaScript code</param>
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void EvaluateJavaScript(string script)
        {
            Interop.WebView.WebView_EvaluateJavaScript(swigCPtr, script);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// The callback function that is invoked when the message is received from the script.
        /// </summary>
        [UnmanagedFunctionPointer(CallingConvention.StdCall)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public delegate void JavaScriptMessageHandler(string message);


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

            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the history of Web.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearHistory()
        {
            Interop.WebView.WebView_ClearHistory(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }

        /// <summary>
        /// Clears the cache of Web.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void ClearCache()
        {
            Interop.WebView.WebView_ClearCache(swigCPtr);
            if (SWIGException.SWIGPendingException.Pending) throw SWIGException.SWIGPendingException.Retrieve();
        }
    }
}
