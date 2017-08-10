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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ElmSharp;
using Tizen.Applications;
using Tizen.WebView;


namespace Tizen.WebView.Test
{
    public class SimpleWebviewApp : CoreUIApplication
    {
        private const string LogTag = "WebViewApp";

        private const string _windowName = "Simple WebView App";
        private const string _defaultUrl = "http://www.google.com";
        private WebView _webview;
        private Entry _addressEntry;
        private Button _reloadButton;

        public SimpleWebviewApp()
        {

        }

        protected override void OnCreate()
        {
            base.OnCreate();
            Chromium.Initialize();
            // Create webview and toolbox
            CreateUI();
        }

        protected override void OnTerminate()
        {
            Chromium.Shutdown();
            base.OnTerminate();
        }

        private void CreateUI()
        {
            // Create Window
            Window window = new Window(_windowName);
            window.Show();

            // Create Box for main window
            Box mainBox = CreateBaseUI(window);

            // Create top bar
            Box topBar = CreateTopBar(window);

            // Create Webview
            _webview = new WebView(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            _webview.Show();

            // Create bottom bar
            Box bottomBar = CreateBottomBar(window);

            mainBox.PackEnd(topBar);
            mainBox.PackEnd(_webview);
            mainBox.PackEnd(bottomBar);

            InitializeWebView();

            // Load default URL
            _webview.LoadUrl(_defaultUrl);
        }

        private Box CreateBaseUI(Window window)
        {
            // Create Background
            Background background = new Background(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                Color = Color.White
            };
            background.Show();
            window.AddResizeObject(background);

            // Create Conformant
            Conformant conformant = new Conformant(window);
            conformant.Show();

            // Create Box for all contents
            Box box = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1
            };
            box.Show();
            conformant.SetContent(box);

            return box;
        }

        private Box CreateTopBar(Window window)
        {
            // Create Box for address bar
            Box topBar = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = 0,
                WeightX = 1,
                WeightY = 0,
                IsHorizontal = true
            };
            topBar.Show();

            // Create address entry
            _addressEntry = new Entry(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 1,
                WeightY = 1,
                IsSingleLine = true,
                Scrollable = true,
                Text = _defaultUrl
            };
            _addressEntry.SetInputPanelLayout(InputPanelLayout.Url);
            _addressEntry.Activated += (s, e) =>
            {
                _webview.LoadUrl(((Entry)s).Text);
            };
            _addressEntry.Show();

            // Create reload button
            _reloadButton = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = -1,
                WeightX = 0.3,
                WeightY = 1,
                Text = "Reload"
            };
            _reloadButton.Clicked += (s, e) =>
            {
                if (_reloadButton.Text.Equals("Reload"))
                {
                    _webview.Reload();
                }
                else if (_reloadButton.Text.Equals("Stop"))
                {
                    _webview.StopLoading();
                }
            };
            _reloadButton.Show();

            topBar.PackEnd(_addressEntry);
            topBar.PackEnd(_reloadButton);

            return topBar;
        }

        private Box CreateBottomBar(Window window)
        {
            // Create Box for bottom bar
            Box bottomBar = new Box(window)
            {
                AlignmentX = -1,
                AlignmentY = 1,
                WeightX = 1,
                WeightY = 0,
                IsHorizontal = true
            };
            bottomBar.Show();

            // Create back/forward buttons
            Button backButton = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                Text = "Back"

            };
            backButton.Clicked += (s, e) =>
            {
                if (_webview.CanGoBack())
                    _webview.GoBack();
            };
            backButton.Show();

            Button forwardButton = new Button(window)
            {
                AlignmentX = -1,
                AlignmentY = 0.5,
                WeightX = 1,
                WeightY = 1,
                Text = "Forward"

            };
            forwardButton.Clicked += (s, e) =>
            {
                if (_webview.CanGoForward())
                    _webview.GoForward();
            };
            forwardButton.Show();

            bottomBar.PackEnd(backButton);
            bottomBar.PackEnd(forwardButton);

            return bottomBar;
        }

        private void InitializeWebView()
        {
            _webview.LoadStarted += (s, e) =>
            {
                Log.Info(LogTag, "Load started");
                _reloadButton.Text = "Stop";
            };

            _webview.LoadFinished += (s, e) =>
            {
                Log.Info(LogTag, "Load finished");
                _reloadButton.Text = "Reload";
            };

            _webview.LoadError += (s, e) =>
            {
                Log.Info(LogTag, "Load error(" + e.Code + "): " + e.Description);
            };

            _webview.UrlChanged += (s, e) =>
            {
                Log.Info(LogTag, "Url changed: " + e.GetAsString());
                _addressEntry.Text = e.GetAsString();
            };

            CookieManager cookieManager = _webview.GetContext().GetCookieManager();
            if (cookieManager != null)
            {
                cookieManager.SetCookieAcceptPolicy(CookieAcceptPolicy.Always);
                cookieManager.SetPersistentStorage(DirectoryInfo.Data, CookiePersistentStorage.SqlLite);
            }
        }

        static void Main(string[] args)
        {
            Elementary.Initialize();
            Elementary.ThemeOverlay();

            SimpleWebviewApp app = new Test.SimpleWebviewApp();
            app.Run(args);
        }
    }
}
