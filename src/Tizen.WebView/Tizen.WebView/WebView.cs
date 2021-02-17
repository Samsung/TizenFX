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
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Tizen.WebView
{
    /// <summary>
    /// Enumeration values used to specify search options.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    [Flags]
    public enum FindOption
    {
        /// <summary>
        /// No search flags, this means a case sensitive, no wrap, forward only search.
        /// </summary>
        None = 0,
        /// <summary>
        /// Case insensitive search.
        /// </summary>
        CaseInsensitive = 1 << 0,
        /// <summary>
        /// Search text only at the beginning of the words.
        /// </summary>
        AtWordStart = 1 << 1,
        /// <summary>
        /// Treat capital letters in the middle of words as word start.
        /// </summary>
        TreatMedialCapitalAsWordStart = 1 << 2,
        /// <summary>
        /// Search backwards.
        /// </summary>
        Backwards = 1 << 3,
        /// <summary>
        /// If not present the search stops at the end of the document.
        /// </summary>
        WrapAround = 1 << 4,
        /// <summary>
        /// Show overlay.
        /// </summary>
        ShowOverlay = 1 << 5,
        /// <summary>
        /// Show Indicator.
        /// </summary>
        ShowIndicator = 1 << 6,
        /// <summary>
        /// Show Highlight.
        /// </summary>
        ShowHighlight = 1 << 7,
    }

    /// <summary>
    /// Enumeration for Http Method.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum HttpMethod
    {
        /// <summary>
        /// Get.
        /// </summary>
        Get,
        /// <summary>
        /// Head.
        /// </summary>
        Head,
        /// <summary>
        /// Post.
        /// </summary>
        Post,
        /// <summary>
        /// Put.
        /// </summary>
        Put,
        /// <summary>
        /// Delete.
        /// </summary>
        Delete,
    }

    /// <summary>
    /// Enumeration for Orientation of the device.
    /// </summary>
    /// <since_tizen> 6 </since_tizen>
    public enum Orientation
    {
        /// <summary>
        /// 0 degrees when the device is oriented to natural position.
        /// </summary>
        Natural = 0,
        /// <summary>
        /// -90 degrees when it's left side is at the top.
        /// </summary>
        LeftAtTop = -90,
        /// <summary>
        /// 90 degrees when it's right side is at the top.
        /// </summary>
        RightAtTop = 90,
        /// <summary>
        /// 180 degrees when it is upside down.
        /// </summary>
        UpsideDown = 180,
    }

    /// <summary>
    /// A view used to render the web contents.
    /// </summary>
    /// <since_tizen> 4 </since_tizen>
    public class WebView : EvasObject
    {
        private static IDictionary<string, JavaScriptMessageHandler> _javaScriptMessageHandlerMap = new Dictionary<string, JavaScriptMessageHandler>();

        private IntPtr _handle;
        private IntPtr _realHandle;
        private Context _context;
        private Settings _settings;

        private IDictionary<IntPtr, Interop.ChromiumEwk.ScriptExcuteCallback> _evalCallbacks = new Dictionary<IntPtr, Interop.ChromiumEwk.ScriptExcuteCallback>();
        private int _evalCallbackId = 0;

        // focus dummy
        private SmartEvent _focusIn;
        private SmartEvent _focusOut;

        // Smart events
        private SmartEvent _loadStarted;
        private SmartEvent _loadFinished;
        private SmartEvent<SmartCallbackLoadErrorArgs> _loadError;
        private SmartEvent<SmartCallbackArgs> _titleChanged;
        private SmartEvent<SmartCallbackArgs> _urlChanged;
        private SmartEvent<NavigationPolicyEventArgs> _policyNavigationDecide;
        private SmartEvent<NewWindowPolicyEventArgs> _policyNewWindowDecide;
        private SmartEvent<ResponsePolicyEventArgs> _policyResponseDecide;

        private SmartEvent<ContextMenuItemEventArgs> _contextMenuItemSelected;
        private SmartEvent<ContextMenuCustomizeEventArgs> _contextMenuCustomize;

        private ContextMenuCustomize _contextMenuCustomizeDelegate;

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
        /// Event that occurs when the policy navigation is decided.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<NavigationPolicyEventArgs> NavigationPolicyDecideRequested;

        /// <summary>
        /// Event that occurs when the policy new window is decided.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<NewWindowPolicyEventArgs> NewWindowPolicyDecideRequested;

        /// <summary>
        /// Event that occurs when the policy response is decided.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ResponsePolicyEventArgs> ResponsePolicyDecideRequested;

        /// <summary>
        /// Event that occurs when the context menu item selected.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public event EventHandler<ContextMenuItemEventArgs> ContextMenuItemSelected;

        /// <summary>
        /// The delegate is invoked when context menu customization is needed.
        /// </summary>
        /// <param name="menu">The instance of ContextMenu.</param>
        /// <since_tizen> 6 </since_tizen>
        public delegate void ContextMenuCustomize(ContextMenu menu);


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
        /// Requests the evaluation of the given script.
        /// </summary>
        /// <param name="script">The JavaScript code string to evaluate.</param>
        /// <returns>A task that contains the result of the evaluation as a string.</returns>
        /// <since_tizen> 8 </since_tizen>
        /// <exception cref="ArgumentException">Thrown when a script is null or empty string.</exception>
        public async Task<string> EvalAsync(string script)
        {
            if (string.IsNullOrEmpty(script))
            {
                throw new ArgumentException(nameof(script));
            }

            var tcs = new TaskCompletionSource<string>();
            IntPtr id = IntPtr.Zero;

            lock (_evalCallbacks)
            {
                id = (IntPtr)_evalCallbackId++;
                _evalCallbacks[id] = (obj, returnValue, userData) =>
                {
                    tcs.SetResult(Marshal.PtrToStringAnsi(returnValue));
                    lock (_evalCallbacks)
                    {
                        _evalCallbacks.Remove(userData);
                    }
                };

                Interop.ChromiumEwk.ewk_view_script_execute(_realHandle, script, _evalCallbacks[id], id);
            }

            return await tcs.Task;
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
        /// Gets size of the content.
        /// </summary>
        /// <returns> size of the coordinate.</returns>
        /// <since_tizen> 6 </since_tizen>
        public Size ContentsSize
        {
            get
            {
                int width, height;
                Interop.ChromiumEwk.ewk_view_contents_size_get(_realHandle, out width, out height);
                return new Size(width, height);
            }
        }

        /// <summary>
        /// Exit full screen.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void ExitFullscreen ()
        {
            Interop.ChromiumEwk.ewk_view_fullscreen_exit(_realHandle);
        }

        /// <summary>
        /// Gets the current load progress of the page.
        /// </summary>
        /// <returns>'value 0.0 to 1.0' on success, otherwise '-1.0'.</returns>
        /// <since_tizen> 6 </since_tizen>
        public double LoadProgress
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_load_progress_get(_realHandle);
            }
        }

        /// <summary>
        /// Sends the orientation of the device.
        /// </summary>
        /// <param name="orientation">The new orientation of the device in degree.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SendOrientation (Orientation orientation)
        {
            Interop.ChromiumEwk.ewk_view_orientation_send(_realHandle, orientation);
        }

        /// <summary>
        /// Suspends the operation associated with the view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Suspend ()
        {
            Interop.ChromiumEwk.ewk_view_suspend(_realHandle);
        }

        /// <summary>
        /// Resumes the operation associated with the view.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public void Resume ()
        {
            Interop.ChromiumEwk.ewk_view_resume(_realHandle);
        }

        /// <summary>
        /// Gets the current scale factor of the page.
        /// </summary>
        /// <since_tizen> 6 </since_tizen>
        public double Scale
        {
            get
            {
                return Interop.ChromiumEwk.ewk_view_scale_get(_realHandle);
            }
        }

        /// <summary>
        /// Sets the current scale factor of the page.
        /// </summary>
        /// <param name="scaleFactor">A new level to set.</param>
        /// <param name="scrollTo">The class Point object with X, Y coordinates.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetScale (double scaleFactor, Point scrollTo)
        {
            Interop.ChromiumEwk.ewk_view_scale_set(_realHandle, scaleFactor, scrollTo.X, scrollTo.Y);
        }

        /// <summary>
        /// Sets the current page's visibility.
        /// </summary>
        /// <param name="enable">'true' to set on the visibility of the page, 'false' otherwise.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetViewVisibility (bool enable)
        {
            Interop.ChromiumEwk.ewk_view_visibility_set(_realHandle, enable);
        }

        /// <summary>
        /// Get and Sets the scroll position of the page.
        /// </summary>
        /// <returns>The class Point object with X, Y coordinates.</returns>
        /// <since_tizen> 6 </since_tizen>
        public Point ScrollPosition
        {
            get
            {
                Point p;
                Interop.ChromiumEwk.ewk_view_scroll_pos_get(_realHandle, out p.X, out p.Y);
                return p;
            }
            set
            {
                Interop.ChromiumEwk.ewk_view_scroll_set(_realHandle, value.X, value.Y);
            }
        }

        /// <summary>
        /// Scrolls the webpage by the given amount.
        /// </summary>
        /// <param name="delta">The class Point object with X, Y coordinates.</param>
        /// <since_tizen> 6 </since_tizen>
        public void ScrollBy (Point delta)
        {
            Interop.ChromiumEwk.ewk_view_scroll_by(_realHandle, delta.X, delta.Y);
        }

        /// <summary>
        /// Searches and highlights the given text string in the document.
        /// </summary>
        /// <param name="text">The text to find.</param>
        /// <param name="option">The options to find.</param>
        /// <param name="maxMatchCount">The maximum match count to find, unlimited if 0.</param>
        /// <since_tizen> 6 </since_tizen>
        public void FindText (string text, FindOption option, int maxMatchCount)
        {
            Interop.ChromiumEwk.ewk_view_text_find(_realHandle, text, option, maxMatchCount);
        }

        /// <summary>
        /// Requests loading of the given request data.
        /// </summary>
        /// <param name="url">The uniform resource identifier to load.</param>
        /// <param name="httpMethod">The http method.</param>
        /// <param name="httpHeaders">The http headers.</param>
        /// <param name="httpBody">The http body data.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetUrlRequest (string url, HttpMethod httpMethod, IDictionary<string, string> httpHeaders, string httpBody)
        {
            List<IntPtr> stringHandles = new List<IntPtr>();
            IntPtr hashHttpHeaders = Interop.Eina.eina_hash_string_small_new(IntPtr.Zero);

            foreach (KeyValuePair<string, string> entry in httpHeaders)
            {
                IntPtr keyHandle = Marshal.StringToHGlobalAnsi(entry.Key);
                IntPtr valueHandle = Marshal.StringToHGlobalAnsi(entry.Value);
                Interop.Eina.eina_hash_add(hashHttpHeaders, keyHandle, valueHandle);
                stringHandles.Add(keyHandle);
                stringHandles.Add(valueHandle);
             }
             Interop.ChromiumEwk.ewk_view_url_request_set(_realHandle, url, httpMethod, hashHttpHeaders, httpBody);

             foreach(IntPtr handle in stringHandles)
             {
                 Marshal.FreeHGlobal(handle);
             }
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

        /// <summary>
        /// Sets the delegate for context menu customization.
        /// </summary>
        /// <param name="contextMenuCustomizeDelegate">The delegate for context menu customization.</param>
        /// <since_tizen> 6 </since_tizen>
        public void SetContextMenuCustomizeDelegate(ContextMenuCustomize contextMenuCustomizeDelegate)
        {
            _contextMenuCustomizeDelegate = contextMenuCustomizeDelegate;
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
            _contextMenuCustomize = new SmartEvent<ContextMenuCustomizeEventArgs>(this, _realHandle, "contextmenu,customize", ContextMenuCustomizeEventArgs.CreateFromSmartEvent);
            _contextMenuItemSelected = new SmartEvent<ContextMenuItemEventArgs>(this, _realHandle, "contextmenu,selected", ContextMenuItemEventArgs.CreateFromSmartEvent);
            _policyNavigationDecide = new SmartEvent<NavigationPolicyEventArgs>(this, _realHandle, "policy,navigation,decide", NavigationPolicyEventArgs.CreateFromSmartEvent);
            _policyNewWindowDecide = new SmartEvent<NewWindowPolicyEventArgs>(this, _realHandle, "policy,newwindow,decide", NewWindowPolicyEventArgs.CreateFromSmartEvent);
            _policyResponseDecide = new SmartEvent<ResponsePolicyEventArgs>(this, _realHandle, "policy,response,decide", ResponsePolicyEventArgs.CreateFromSmartEvent);

            _loadStarted.On += (s, e) => { LoadStarted?.Invoke(this, EventArgs.Empty); };
            _loadFinished.On += (s, e) => { LoadFinished?.Invoke(this, EventArgs.Empty); };
            _loadError.On += (s, e) => { LoadError?.Invoke(this, e); };
            _titleChanged.On += (s, e) => { TitleChanged?.Invoke(this, e); };
            _urlChanged.On += (s, e) => { UrlChanged?.Invoke(this, e); };
            _policyNavigationDecide.On += (s, e) => { NavigationPolicyDecideRequested?.Invoke(this, e); };
            _policyNewWindowDecide.On += (s, e) => { NewWindowPolicyDecideRequested?.Invoke(this, e); };
            _policyResponseDecide.On += (s, e) => { ResponsePolicyDecideRequested?.Invoke(this, e); };
            _contextMenuItemSelected.On += (s, e) => { ContextMenuItemSelected?.Invoke(this, e); };
            _contextMenuCustomize.On += (s, e) => { _contextMenuCustomizeDelegate?.Invoke(e.Menu); };
        }

    }
}
