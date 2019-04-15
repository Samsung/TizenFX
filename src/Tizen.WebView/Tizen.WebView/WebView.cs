/*
 * Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 * Licensed under the Apache License, Version 2.0 (the License);
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an AS IS BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using ElmSharp;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace Tizen.WebView
{
    /// <summary>
    /// A view used to render the web contents.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WebView: EvasObject
    {
        private static IDictionary<string, JavaScriptMessageHandler> _javaScriptMessageHandlerMap = new Dictionary<string, JavaScriptMessageHandler>();

        private IntPtr _handle;
        private IntPtr _realHandle;
        private Context _context;
        private Settings _settings;

        // focus dummy
        private SmartEvent _focusIn;
        private SmartEvent _focusOut;

        // Smart events
        private SmartEvent _loadStarted;
        private SmartEvent _loadFinished;
        private SmartEvent<SmartCallbackLoadErrorArgs> _loadError;
        private SmartEvent<SmartCallbackArgs> _titleChanged;
        private SmartEvent<SmartCallbackArgs> _urlChanged;



        /// <summary>
        /// Event that occurs when the load is started.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler LoadStarted;

        /// <summary>
        /// Event that occurs when the load is finished.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler LoadFinished;

        /// <summary>
        /// Event that occurs when the load throws an error.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<SmartCallbackLoadErrorArgs> LoadError;

        /// <summary>
        /// Event that occurs when the title of the main frame is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<SmartCallbackArgs> TitleChanged;

        /// <summary>
        /// Event that occurs when the URL of the main frame is changed.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public event EventHandler<SmartCallbackArgs> UrlChanged;

        /// <summary>
        /// Current URL of the main frame.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Url
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_url_get(_realHandle);
            }
        }

        /// <summary>
        /// Current title of the main frame.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string Title
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_title_get(_realHandle);
            }
        }

        /// <summary>
        /// Current user agent string of this view.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public string UserAgent
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_user_agent_get(_realHandle);
            }

            set
            {
                Interop.ChromiumEwk.ewk_view_user_agent_set(_realHandle, value);
            }
        }

        /// <summary>
        /// Whether a view has the focus.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public bool HasFocus
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_focus_get(_realHandle);
            }
        }

        /// <summary>
        /// Creates a WebView object.
        /// </summary>
        /// <param name="parent">Parent object of the WebView.</param>
        /// <since_tizen> 4 </since_tizen>
        public WebView(EvasObject parent) : base(parent)
        {
            InitializeSmartEvent();
        }

        /// <summary>
        /// Gets the context object of this view.
        /// </summary>
        /// <returns>The context object of this view.</returns>
        /// <since_tizen> 4 </since_tizen>
        public Context GetContext()
        {
            if (_context == null)
            {
                IntPtr contextHandle = Interop.ChromiumEwk.ewk_view_context_get(_realHandle);
                if (contextHandle == IntPtr.Zero)
                {
                    return null;
                }
                _context = new Context(contextHandle);
            }
            return _context;
        }

        /// <summary>
        /// Gets the settings object of this view.
        /// </summary>
        /// <returns>The settings object of this view.</returns>
        /// <since_tizen> 4 </since_tizen>
        public Settings GetSettings()
        {
            if (_settings == null)
            {
                IntPtr settingsHandle = Interop.ChromiumEwk.ewk_view_settings_get(_realHandle);
                if (settingsHandle == IntPtr.Zero)
                {
                    return null;
                }
                _settings = new Settings(settingsHandle);
            }
            return _settings;
        }

        /// <summary>
        /// Gets the back/forward list object of this view.
        /// </summary>
        /// <returns>The BackForward List object of this view.</returns>
        /// <since_tizen> 6 </since_tizen>
        public BackForwardList GetBackForwardList()
        {
            IntPtr backforwardlistHandle = Interop.ChromiumEwk.ewk_view_back_forward_list_get(_realHandle);
            if (backforwardlistHandle == IntPtr.Zero)
            {
                return null;
            }
            return new BackForwardList(backforwardlistHandle);
        }

        /// <summary>
        /// Clear the back/forward list object of this view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ClearBackForwardList()
        {
            Interop.ChromiumEwk.ewk_view_back_forward_list_clear(_realHandle);
        }

        /// <summary>
        /// Asks the object to load the given URL.
        /// </summary>
        /// <remarks>
        /// You can only be sure that the URL changes after UrlChanged event.
        /// </remarks>
        /// <param name="url">The uniform resource identifier to load.</param>
        /// <since_tizen> 4 </since_tizen>
        public void LoadUrl(string url)
        {
            Interop.ChromiumEwk.ewk_view_url_set(_realHandle, url);
        }

        /// <summary>
        /// Loads the specified HTML string as the content of the view.
        /// </summary>
        /// <param name="html">HTML data to load.</param>
        /// <param name="baseUrl">Base URL used for relative paths to external objects.</param>
        /// <since_tizen> 4 </since_tizen>
        public void LoadHtml(string html, string baseUrl)
        {
            Interop.ChromiumEwk.ewk_view_html_string_load(_realHandle, html, baseUrl, null);
        }

        /// <summary>
        /// Asks the main frame to stop loading.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void StopLoading()
        {
            Interop.ChromiumEwk.ewk_view_stop(_realHandle);
        }

        /// <summary>
        /// Asks the main frame to reload the current document.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void Reload()
        {
            Interop.ChromiumEwk.ewk_view_reload(_realHandle);
        }

        /// <summary>
        /// Asks the main frame to navigate back in history.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void GoBack()
        {
            Interop.ChromiumEwk.ewk_view_back(_realHandle);
        }

        /// <summary>
        /// Asks the main frame to navigate forward in history.
        /// </summary>
        /// <since_tizen> 4 </since_tizen>
        public void GoForward()
        {
            Interop.ChromiumEwk.ewk_view_forward(_realHandle);
        }

        /// <summary>
        /// Checks whether it is possible to navigate backward one item in history.
        /// </summary>
        /// <returns>Whether it is possible to navigate backward one item in history.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool CanGoBack()
        {
            return Interop.ChromiumEwk.ewk_view_back_possible(_realHandle);
        }

        /// <summary>
        /// Checks whether it is possible to navigate forward one item in history.
        /// </summary>
        /// <returns>Whether it is possible to navigate forward one item in history.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool CanGoForward()
        {
            return Interop.ChromiumEwk.ewk_view_forward_possible(_realHandle);
        }

        /// <summary>
        /// Injects the supplied javascript message handler into the view.
        /// </summary>
        /// <param name="name"> The message callback.</param>
        /// <param name="handler">The name used to expose the object in JavaScript.</param>
        /// <returns>'true' on success, otherwise 'false'.</returns>
        /// <since_tizen> 4 </since_tizen>
        public bool AddJavaScriptMessageHandler(string name, JavaScriptMessageHandler handler)
        {
            lock (_javaScriptMessageHandlerMap)
            {
                if (_javaScriptMessageHandlerMap.ContainsKey(name))
                {
                    return false;
                }
                _javaScriptMessageHandlerMap[name] = handler;
            }
            Interop.ChromiumEwk.ScriptMessageCallback callback = (handle, message) =>
            {
                JavaScriptMessage convertedMessage = new JavaScriptMessage(message);
                lock (_javaScriptMessageHandlerMap)
                {
                    if (_javaScriptMessageHandlerMap.ContainsKey(convertedMessage.Name))
                    {
                        _javaScriptMessageHandlerMap[convertedMessage.Name](convertedMessage);
                    }
                }
            };
            if (!Interop.ChromiumEwk.ewk_view_javascript_message_handler_add(_realHandle, callback, name))
            {
                lock (_javaScriptMessageHandlerMap)
                {
                    _javaScriptMessageHandlerMap.Remove(name);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Requests the execution of a given name and the result to the JavaScript runtime.
        /// </summary>
        /// <param name="name">The name used to expose the object in JavaScript.</param>
        /// <param name="result">The result to the JavaScript runtime.</param>
        /// <since_tizen> 4 </since_tizen>
        public void EvalWithResult(string name, string result)
        {
            Interop.ChromiumEwk.ewk_view_evaluate_javascript(_realHandle, name, result);
        }

        /// <summary>
        /// Requests the execution of the given script.
        /// </summary>
        /// <param name="script">The JavaScript code string to execute.</param>
        /// <since_tizen> 4 </since_tizen>
        public void Eval(string script)
        {
            Interop.ChromiumEwk.ewk_view_script_execute(_realHandle, script, null, IntPtr.Zero);
        }

        /// <summary>
        /// Requests to set or unset a view as the currently focused one.
        /// </summary>
        /// <param name="focused">'true' to set the focus on the view, 'false' to remove the focus from the view.</param>
        /// <since_tizen> 4 </since_tizen>
        public void SetFocus(bool focused)
        {
            Interop.ChromiumEwk.ewk_view_focus_set(_realHandle, focused);
        }

        /// <summary>
        /// Creates a widget handle.
        /// </summary>
        /// <param name="parent">Parent EvasObject.</param>
        /// <returns>IntPtr of the widget handle.</returns>
        /// <since_tizen> 4 </since_tizen>
        protected override IntPtr CreateHandle(EvasObject parent)
        {
            // focus dummy
            _handle = Interop.Elementary.elm_layout_add((IntPtr)parent);
            Interop.Elementary.elm_layout_theme_set(_handle, "layout", "elm_widget", "default");
            Interop.Elementary.elm_object_focus_allow_set(_handle, true);

            IntPtr evas = Interop.Evas.evas_object_evas_get(parent);
            _realHandle = Interop.ChromiumEwk.ewk_view_add(evas);
            Interop.Elementary.elm_object_part_content_set(_handle, "elm.swallow.content", _realHandle);

            return _handle;
        }

        private void InitializeSmartEvent()
        {
            // focus dummy
            _focusIn = new SmartEvent(this, "focused");
            _focusOut = new SmartEvent(this, "unfocused");

            _focusIn.On += (s, e) => { ((WebView)s).SetFocus(true); };
            _focusOut.On += (s, e) => { ((WebView)s).SetFocus(false); };

            _loadStarted = new SmartEvent(this, _realHandle, "load,started");
            _loadFinished = new SmartEvent(this, _realHandle, "load,finished");
            _loadError = new SmartEvent<SmartCallbackLoadErrorArgs>(this, _realHandle, "load,error", SmartCallbackLoadErrorArgs.CreateFromSmartEvent);
            _titleChanged = new SmartEvent<SmartCallbackArgs>(this, _realHandle, "title,changed", SmartCallbackArgs.CreateFromSmartEvent);
            _urlChanged = new SmartEvent<SmartCallbackArgs>(this, _realHandle, "url,changed", SmartCallbackArgs.CreateFromSmartEvent);

            _loadStarted.On += (s, e) => { LoadStarted?.Invoke(this, EventArgs.Empty); };
            _loadFinished.On += (s, e) => { LoadFinished?.Invoke(this, EventArgs.Empty); };
            _loadError.On += (s, e) => { LoadError?.Invoke(this, e); };
            _titleChanged.On += (s, e) => { TitleChanged?.Invoke(this, e); };
            _urlChanged.On += (s, e) => { UrlChanged?.Invoke(this, e); };
        }
    }
}
