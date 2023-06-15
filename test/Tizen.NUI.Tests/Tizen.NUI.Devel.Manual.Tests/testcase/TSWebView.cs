/*
 *  Copyright (c) 2017 Samsung Electronics Co., Ltd All Rights Reserved
 *
 *  Licensed under the Apache License, Version 2.0 (the "License");
 *  you may not use this file except in compliance with the License.
 *  You may obtain a copy of the License at
 *
 *      http://www.apache.org/licenses/LICENSE-2.0
 *
 *  Unless required by applicable law or agreed to in writing, software
 *  distributed under the License is distributed on an "AS IS" BASIS,
 *  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *  See the License for the specific language governing permissions and
 *  limitations under the License
 */

using System;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Tests
{
    [TestFixture]
    [Description("Tizen.NUI.View test")]
    public class WebViewTests
    {
        private const string tag = "NUITEST";
        private WearableManualTestNUI _wearTestPage;
        private TextLabel _label;

        private BaseComponents.WebView _webView = null;
        private Window _window = null;
        private string url = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
        private string urlForContextMenu = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/contextmenu.html";
        //private string urlForFormSubmit = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webform.html";
        private string urlForScrollEdge = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/webscrolledge.html";
        private string urlForOpenWindow = $"file://{Tizen.Applications.Application.Current.DirectoryInfo.Resource}webview/openwindow.html";
        private Button _menu = null;
        private WebContextMenu _contextMenu;

        [SetUp]
        public void Init()
        {
            Log.Info(tag, "Preconditions for each TEST");
            if (ManualTest.IsWearable())
            {
                _label = ManualTest.CreateLabel("This case is unsuitable for wearable, please press PASS button to continue!");
                _wearTestPage = WearableManualTestNUI.GetInstance();
            }
            else
            {
                _webView = new BaseComponents.WebView()
                {
                    Size = new Size(1920, 540),
                    ParentOrigin = ParentOrigin.Center,
                    PivotPoint = PivotPoint.Center,
                    PositionUsesPivotPoint = true,
                };
                _window = Window.Instance;
            }
        }

        [TearDown]
        public void Destroy()
        {
            Log.Info(tag, "Postconditions for each TEST, webview is being destroyed.");
            _webView.Dispose();
            Log.Info(tag, "Postconditions for each TEST");
        }

        private void OnContextMenuShown(object sender, WebViewContextMenuShownEventArgs e)
        {
            Log.Info(tag, "TUnit WebView.WebViewContextMenuShownEvent!!!!!!!!!!!!!!!!!!!!!");
            ManualTest.Confirm();
        }

        private void OnMenuClicked(object sender, ClickedEventArgs e)
        {
            Log.Info(tag, "TUnit OnMenuClicked!!!!!!!!!!!!!!!!!!!!!");
            _contextMenu.Hide();
        }

        private void OnContextMenuHidden(object sender, WebViewContextMenuHiddenEventArgs e)
        {
            Log.Info(tag, "TUnit WebView.WebViewContextMenuShownEvent!!!!!!!!!!!!!!!!!!!!!");
            ManualTest.Confirm();
        }

        [Test]
        [Category("P1")]
        [Description("Test: Handle event. Try to long-press to trigger the event.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.WebView.ContextMenuShown E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Precondition(1, "In case of Emulator, only use PC keyboard or remote controller of emulator itself.")]
        [Precondition(2, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click to runt TC.")]
        [Step(2, "Long press image of test page.")]
        [Step(3, "If there is no exception, test will be automatically passed.")]
        [Postcondition(1, "NA")]
        public async Task ContextMenuShown_CB()
        {
            if (ManualTest.IsWearable())
            {
                _wearTestPage.ExecuteTC(_label);
                await ManualTest.WaitForConfirm();
                _wearTestPage.ClearTestCase(_label);
            }
            else
            {
                _window.GetDefaultLayer().Add(_webView);
                FocusManager.Instance.SetCurrentFocusView(_webView);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
                EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
                {
                    Log.Info(tag, "onLoadFinished is called.");
                    tcs.TrySetResult(true);
                };
                Log.Info(tag, "onLoadFinished is called.");
                _webView.PageLoadFinished += onLoadFinished;
                _webView.ContextMenuShown += OnContextMenuShown;
                Log.Info(tag, "onLoadFinished is called.");
                _webView.LoadUrl(urlForContextMenu);

                Log.Info(tag, "onLoadFinished is called.");
                var result = await tcs.Task;
                Assert.IsTrue(result, "PageLoadFinished event should be invoked");

                Log.Info(tag, "onLoadFinished is called.");

                // Waits for user confirmation.
                await ManualTest.WaitForConfirm();
                _webView.PageLoadFinished -= onLoadFinished;
                _webView.ContextMenuShown -= OnContextMenuShown;
                _window.GetDefaultLayer().Remove(_webView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test: Handle event. Try to long-press to trigger the event.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.WebView.ContextMenuShown E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Precondition(1, "In case of Emulator, only use PC keyboard or remote controller of emulator itself.")]
        [Precondition(2, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click to runt TC.")]
        [Step(2, "Long press image of test page.")]
        [Step(3, "If there is no exception, test will be automatically passed.")]
        [Postcondition(1, "NA")]
        public async Task ContextMenuHidden_CB()
        {
            if (ManualTest.IsWearable())
            {
                _wearTestPage.ExecuteTC(_label);
                await ManualTest.WaitForConfirm();
                _wearTestPage.ClearTestCase(_label);
            }
            else
            {
                _window.GetDefaultLayer().Add(_webView);
                FocusManager.Instance.SetCurrentFocusView(_webView);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
                EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
                {
                    Log.Info(tag, "onLoadFinished is called.");
                    tcs.TrySetResult(true);
                };
                Log.Info(tag, "onLoadFinished is called.");
                _webView.PageLoadFinished += onLoadFinished;

                EventHandler<WebViewContextMenuShownEventArgs> onContextMenuShown = (s, e) =>
                {
                    Log.Info(tag, "onContextMenuShown is called.");
                    if (_menu == null)
                    {
                        _menu = new Button();
                        _menu.Text = "Click here to trigger menu hide event.";
                        _menu.Feedback = false;
                        _menu.PointSize = 20.0f;
                        _menu.BackgroundColor = Color.Cyan;
                        _menu.Size = new Size(Window.Instance.Size.Width * 0.1f, Window.Instance.Size.Height * 0.05f);
                        _menu.Clicked += OnMenuClicked;
                        _window.GetDefaultLayer().Add(_menu);
                    }
                    _contextMenu = e.ContextMenu;
                };
                _webView.ContextMenuShown += onContextMenuShown;

                _webView.ContextMenuHidden += OnContextMenuHidden;
                Log.Info(tag, "onLoadFinished is called.");
                _webView.LoadUrl(urlForContextMenu);

                Log.Info(tag, "onLoadFinished is called.");
                var result = await tcs.Task;
                Assert.IsTrue(result, "PageLoadFinished event should be invoked");

                Log.Info(tag, "onLoadFinished is called.");

                // Waits for user confirmation.
                await ManualTest.WaitForConfirm();
                _webView.PageLoadFinished -= onLoadFinished;
                _webView.ContextMenuShown -= OnContextMenuShown;
                _webView.ContextMenuHidden -= OnContextMenuHidden;
                _window.GetDefaultLayer().Remove(_webView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test: Handle event. Try to sroll to edge to trigger the event.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.WebView.ScrollEdgeReached E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Precondition(1, "In case of Emulator, only use PC keyboard or remote controller of emulator itself.")]
        [Precondition(2, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click to runt TC.")]
        [Step(2, "Scroll testing page to edge.")]
        [Step(3, "If there is no exception, test will be automatically passed.")]
        [Postcondition(1, "NA")]
        public async Task ScrollEdgeReached_CB()
        {
            if (ManualTest.IsWearable())
            {
                _wearTestPage.ExecuteTC(_label);
                await ManualTest.WaitForConfirm();
                _wearTestPage.ClearTestCase(_label);
            }
            else
            {
                _window.GetDefaultLayer().Add(_webView);
                FocusManager.Instance.SetCurrentFocusView(_webView);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
                EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
                {
                    Log.Info(tag, "onLoadFinished is called.");
                    tcs.TrySetResult(true);
                };
                Log.Info(tag, "onLoadFinished is called.");
                _webView.PageLoadFinished += onLoadFinished;

                EventHandler<WebViewScrollEdgeReachedEventArgs> onScrollEdgeReached = (s, e) =>
                {
                    Log.Info(tag, "TUnit WebView.ScrollEdgeReached!!!!!!!!!!!!!!!!!!!!!");
                    ManualTest.Confirm();
                };
                _webView.ScrollEdgeReached += onScrollEdgeReached;
                Log.Info(tag, "onLoadFinished is called.");
                _webView.LoadUrl(urlForScrollEdge);

                Log.Info(tag, "onLoadFinished is called.");
                var result = await tcs.Task;
                Assert.IsTrue(result, "PageLoadFinished event should be invoked");

                Log.Info(tag, "onLoadFinished is called.");

                // Waits for user confirmation.
                await ManualTest.WaitForConfirm();
                _webView.PageLoadFinished -= onLoadFinished;
                _webView.ScrollEdgeReached -= onScrollEdgeReached;
                _window.GetDefaultLayer().Remove(_webView);
            }
        }

        [Test]
        [Category("P1")]
        [Description("Test: Handle event. Try to sroll to edge to trigger the event.")]
        [Property("SPEC", "Tizen.NUI.BaseComponents.WebView.NewWindowCreated E")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "EVL")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        [Precondition(1, "In case of Emulator, only use PC keyboard or remote controller of emulator itself.")]
        [Precondition(2, "If test on TV, prepare mouse and connect to TV.")]
        [Step(1, "Click to runt TC.")]
        [Step(2, "Click button to open new window.")]
        [Step(3, "If there is no exception, test will be automatically passed.")]
        [Postcondition(1, "NA")]
        public async Task NewWindowCreated_CB()
        {
            if (ManualTest.IsWearable())
            {
                _wearTestPage.ExecuteTC(_label);
                await ManualTest.WaitForConfirm();
                _wearTestPage.ClearTestCase(_label);
            }
            else
            {
                _window.GetDefaultLayer().Add(_webView);
                FocusManager.Instance.SetCurrentFocusView(_webView);

                TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
                EventHandler<WebViewPageLoadEventArgs> onLoadFinished = (s, e) =>
                {
                    Log.Info(tag, "onLoadFinished is called.");
                    tcs.TrySetResult(true);
                };
                Log.Info(tag, "onLoadFinished is called.");
                _webView.PageLoadFinished += onLoadFinished;

                EventHandlerWithReturnType<object, EventArgs, BaseComponents.WebView> onNewWindowCreated = (s, e) =>
                {
                    Log.Info(tag, "TUnit WebView.NewWindowCreated!!!!!!!!!!!!!!!!!!!!!");
                    ManualTest.Confirm();
                    return null;
                };
                _webView.NewWindowCreated += onNewWindowCreated;
                Log.Info(tag, "onLoadFinished is called.");
                _webView.LoadUrl(urlForOpenWindow);

                Log.Info(tag, "onLoadFinished is called.");
                var result = await tcs.Task;
                Assert.IsTrue(result, "PageLoadFinished event should be invoked");

                Log.Info(tag, "onLoadFinished is called.");

                // Waits for user confirmation.
                await ManualTest.WaitForConfirm();
                _webView.PageLoadFinished -= onLoadFinished;
                _webView.NewWindowCreated -= onNewWindowCreated;
                _window.GetDefaultLayer().Remove(_webView);
            }
        }

        //TODO... FormRepostPolicyDecided event is very hard to be triggered. And this event is used rarely.
        //[Test]
        //[Category("P1")]
        //[Description("Test: Handle event. Try to sroll to edge to trigger the event.")]
        //[Property("SPEC", "Tizen.NUI.BaseComponents.WebView.FormRepostPolicyDecided E")]
        //[Property("SPEC_URL", "-")]
        //[Property("CRITERIA", "EVL")]
        //[Property("AUTHOR", "guowei.wang@samsung.com")]
        //[Precondition(1, "In case of Emulator, only use PC keyboard or remote controller of emulator itself.")]
        //[Precondition(2, "If test on TV, prepare mouse and connect to TV.")]
        //[Step(1, "Click to runt TC.")]
        //[Step(2, "Click submit button.")]
        //[Step(3, "Click submit button again to simulate form repost.")]
        //[Step(4, "If there is no exception, test will be automatically passed.")]
        //[Postcondition(1, "NA")]
        //public async Task FormRepostPolicyDecided_CB()
        //{
        //    if (ManualTest.IsWearable())
        //    {
        //        _wearTestPage.ExecuteTC(_label);
        //        await ManualTest.WaitForConfirm();
        //        _wearTestPage.ClearTestCase(_label);
        //    }
        //    else
        //    {
        //        _window.GetDefaultLayer().Add(_webView);
        //        FocusManager.Instance.SetCurrentFocusView(_webView);

        //        TaskCompletionSource<bool> tcs1 = new TaskCompletionSource<bool>(false);
        //        EventHandler<WebViewPageLoadEventArgs> onLoadFinished = async (s, e) =>
        //        {
        //            if (_webView.Url.Contains("index.html"))
        //            {
        //                tcs1.TrySetResult(true);
        //            }
        //        };
        //        Log.Info(tag, "onLoadFinished is called.");
        //        _webView.PageLoadFinished += onLoadFinished;

        //        EventHandler<WebViewFormRepostPolicyDecidedEventArgs> onFormRepostPolicyDecided = (s, e) =>
        //        {
        //            Log.Info(tag, "TUnit WebView.FormRepostPolicyDecided!!!!!!!!!!!!!!!!!!!!!");
        //            ManualTest.Confirm();
        //        };
        //        _webView.FormRepostPolicyDecided += onFormRepostPolicyDecided;
        //        EventHandlerWithReturnType<object, View.TouchEventArgs, bool> onTouched = (s, e) =>
        //        {
        //            // Load index.html.
        //            Log.Info(tag, "TUnit WebView.TouchEvent !!!!!!!!!!!!!!!!!!!!!");
        //            _webView.LoadUrl(url);
        //            return false;
        //        };
        //        _webView.TouchEvent += onTouched;
        //        Log.Info(tag, "onLoadFinished is called.");
        //        _webView.LoadUrl(urlForFormSubmit);

        //        Log.Info(tag, "onLoadFinished is called.");
        //        var result = await tcs1.Task;
        //        Assert.IsTrue(result, "PageLoadFinished event should be invoked");

        //        if (_webView.CanGoBack())
        //        {
        //            Log.Info(tag, $"GoBack is called. url: {_webView.Url}");
        //            _webView.GoBack();
        //        }

        //        _webView.PageLoadFinished -= onLoadFinished;

        //        // Waits for user confirmation.
        //        await ManualTest.WaitForConfirm();
        //        _webView.FormRepostPolicyDecided -= onFormRepostPolicyDecided;
        //        _window.GetDefaultLayer().Remove(_webView);
        //    }
        //}
    }
}
