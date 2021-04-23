/*
 * Copyright (c) 2019 Samsung Electronics Co., Ltd.
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

namespace Tizen.NUI
{
    /// <summary>
    /// Event arguments that passed via the WebView.PageLoadStarted or WebView.PageLoadFinished.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public class WebViewPageLoadEventArgs : EventArgs
    {
        private WebView _webView;
        private string _pageUrl;

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
}
