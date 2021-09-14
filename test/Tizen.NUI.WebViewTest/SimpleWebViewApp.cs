/*
 * Copyright (c) 2020 Samsung Electronics Co., Ltd.
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
using System.Collections.Generic;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;

namespace Tizen.NUI.WebViewTest
{
    internal class MenuView : View
    {
        private WebContextMenu contextMenu;
        private Button[] buttons;

        public event EventHandler<ItemClickedEventArgs> ClickedEvent;

        public class ItemClickedEventArgs : EventArgs
        {
            public uint CurrentIndex;
        }

        internal MenuView(WebContextMenu menu)
        {
            contextMenu = menu;

            Layout = new LinearLayout()
            {
                LinearOrientation = LinearLayout.Orientation.Vertical,
                LinearAlignment = LinearLayout.Alignment.Center
            };

            buttons = new Button[menu.ItemCount];

            for (uint i = 0; i < menu.ItemCount; i++)
            {
                WebContextMenuItem item = menu.GetItemAtIndex(i);
                buttons[i] = new Button()
                {
                    Size = new Size(200, 80),
                    PointSize = 30.0f,
                    TextColor = Color.Black,
                    Text = item.Title,
                };
                buttons[i].TouchEvent += OnMenuItemTouched;
                Add(buttons[i]);
            }
        }

        private bool OnMenuItemTouched(object s, TouchEventArgs e)
        {
            uint i = 0;
            for (; i < buttons.Length; i++)
            {
                if (buttons[i] == (Button)s)
                {
                    Log.Info("WebView", $"found button {i} is selected.");
                    break;
                }
            }

            Log.Info("WebView", $"button {i} is selected.");

            //WebContextMenuItem item = contextMenu.ItemList.GetItemAtIndex(i);
            //if (item != null)
            //{
            //    contextMenu.SelectItem(item);
            //    contextMenu.Hide();
            //}

            ItemClickedEventArgs args = new ItemClickedEventArgs();
            args.CurrentIndex = i;
            ClickedEvent?.Invoke(this, args);

            Log.Info("WebView", $"button {i} is selected.");

            return false;
        }

        internal void HideMenu()
        {
            contextMenu.Hide();
        }
    }

    public class SimpleWebViewApplication : NUIApplication
    {
        private BaseComponents.WebView simpleWebView = null;
        private TextField addressBar = null;
        private Button backButton = null;
        private Button forwardButton = null;
        private Button refreshButton = null;

        private int index = 0;
        private const int WEBSITES_COUNT = 2;
        private string[] websites =
        {
            "https://terms.account.samsung.com/contents/legal/kor/kor/customizedservicecontent.html",
            "https://www.youtube.com"
        };

        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        private const int ADDRESSBAR_HEIGHT = 100;

        private const int SCREEN_WIDTH = 1920;
        private const int SCREEN_HEIGHT = 1080;

        private const int MIN_WEBVIEW_WIDTH = 1000;
        private const int MIN_WEBVIEW_HEIGHT = 600;

        private const int WEBVIEW_WIDTH = SCREEN_WIDTH;
        private const int WEBVIEW_HEIGHT = SCREEN_HEIGHT - ADDRESSBAR_HEIGHT;

        private Vector2 menuPosition;
        private MenuView menuView;

        private int blueKeyPressedCount = 0;
        private int yellowKeyPressedCount = 0;
        private int redKeyPressedCount = 0;

        private static long startTime = 0;

        private Timer messageTimer = null;
        private ImageView faviconView = null;
        private ImageView screenshotView = null;
        private ImageView hitTestImageView = null;

        private static string[] runtimeArgs = { "Tizen.NUI.WebViewTest", "--enable-dali-window", "--enable-spatial-navigation" };

        protected override void OnCreate()
        {
            base.OnCreate();

            GetDefaultWindow().BackgroundColor = new Color((float)189 / 255, (float)179 / 255, (float)204 / 255, 1.0f);

            backButton = new Button()
            {
                Position = new Position(0, 0),
                Size = new Size(100, 100),
                PointSize = 30.0f,
                TextColor = Color.Black,
                Text = "Back",
            };
            backButton.TouchEvent += OnBackButtonTouchEvent;
            GetDefaultWindow().Add(backButton);

            forwardButton = new Button()
            {
                Position = new Position(100, 0),
                Size = new Size(100, 100),
                PointSize = 30.0f,
                TextColor = Color.Black,
                Text = "Forward",
            };
            forwardButton.TouchEvent += OnForwardButtonTouchEvent;
            GetDefaultWindow().Add(forwardButton);

            refreshButton = new Button()
            {
                Position = new Position(200, 0),
                Size = new Size(100, 100),
                PointSize = 30.0f,
                TextColor = Color.Black,
                Text = "Refresh",
            };
            refreshButton.TouchEvent += OnRefreshButtonTouchEvent;
            GetDefaultWindow().Add(refreshButton);

            addressBar = new TextField()
            {
                Position = new Position(300, 0),
                BackgroundColor = Color.White,
                Size = new Size(SCREEN_WIDTH - 300, ADDRESSBAR_HEIGHT),
                EnableGrabHandlePopup = false,
                EnableGrabHandle = false,
                EnableSelection = true,
                Focusable = true,
                PlaceholderText = "Please input url here like Www.baidu.com.",
            };
            addressBar.FocusGained += OnTextEditorFocusGained;
            addressBar.FocusLost += OnTextEditorFocusLost;
            addressBar.KeyEvent += OnAddressBarKeyEvent;
            addressBar.TouchEvent += OnAddressBarTouchEvent;
            GetDefaultWindow().Add(addressBar);

            Log.Info("WebView", $"args count is {runtimeArgs.Length}");
            for (int i = 0; i < runtimeArgs.Length; i++)
            {
                Log.Info("WebView", $"arg {i} is {runtimeArgs[i]}");
            }

            simpleWebView = new BaseComponents.WebView(runtimeArgs)
            {
                Position = new Position(0, ADDRESSBAR_HEIGHT),
                Size = new Size(WEBVIEW_WIDTH, WEBVIEW_HEIGHT),
                UserAgent = USER_AGENT,
                Focusable = true,
                VideoHoleEnabled = true,
            };
            simpleWebView.FocusGained += OnWebViewFocusGained;
            simpleWebView.FocusLost += OnWebViewFocusLost;
            simpleWebView.KeyEvent += OnWebViewKeyEvent;
            simpleWebView.TouchEvent += OnWebViewTouchEvent;
            simpleWebView.SslCertificateChanged += OnSslCertificateChanged;
            //simpleWebView.HttpAuthRequested += OnHttpAuthRequested;
            simpleWebView.PageLoadStarted += OnPageLoadStarted;
            simpleWebView.PageLoading += OnPageLoading;
            simpleWebView.PageLoadFinished += OnPageLoadFinished;
            simpleWebView.PageLoadError += OnPageLoadError;
            simpleWebView.ContextMenuShown += OnContextMenuShown;
            simpleWebView.ContextMenuHidden += OnContextMenuHidden;
            simpleWebView.ScrollEdgeReached += OnScrollEdgeReached;
            simpleWebView.UrlChanged += OnUrlChanged;
            simpleWebView.FormRepostPolicyDecided += OnFormRepostPolicyDecided;
            //simpleWebView.FrameRendered += OnFrameRendered;
            simpleWebView.ConsoleMessageReceived += OnConsoleMessageReceived;
            simpleWebView.CertificateConfirmed += OnCertificateConfirmed;
            simpleWebView.ResponsePolicyDecided += OnResponsePolicyDecided;
            GetDefaultWindow().Add(simpleWebView);

            GetDefaultWindow().KeyEvent += Instance_KeyEvent;
            simpleWebView.LoadUrl(websites[index]);
            //simpleWebView.LoadHtmlString("<Html><Head><title>Example</title></Head><Body><b>[This text is Bold......]</b></Body></Html>");
            FocusManager.Instance.SetCurrentFocusView(simpleWebView);

            messageTimer = new Timer(10000);
            messageTimer.Tick += OnTick;
        }

        protected override void OnTerminate()
        {
            if (menuView != null)
            {
                GetDefaultWindow().Remove(menuView);
            }
            GetDefaultWindow().Remove(backButton);
            GetDefaultWindow().Remove(forwardButton);
            GetDefaultWindow().Remove(refreshButton);
            GetDefaultWindow().Remove(addressBar);

            if (screenshotView != null)
            {
                GetDefaultWindow().Remove(screenshotView);
            }

            messageTimer.Tick -= OnTick;
            messageTimer.Dispose();
            messageTimer = null;

            base.OnTerminate();
        }

        private bool OnBackButtonTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (simpleWebView.CanGoBack())
            {
                simpleWebView.GoBack();
            }
            return false;
        }

        private bool OnForwardButtonTouchEvent(object sender, View.TouchEventArgs e)
        {
            if (simpleWebView.CanGoForward())
            {
                simpleWebView.GoForward();
            }
            return false;
        }

        private bool OnRefreshButtonTouchEvent(object sender, View.TouchEventArgs e)
        {
            simpleWebView.Reload();
            return false;
        }

        private bool OnTick(object sender, EventArgs e)
        {
            Log.Info("WebView", $"------------timer tick-------");

            if (faviconView != null)
            {
                GetDefaultWindow().Remove(faviconView);
                faviconView.Dispose();
                faviconView = null;
            }

            if (screenshotView != null)
            {
                Log.Info("WebView", $"------------remove screen shot-------");
                GetDefaultWindow().Remove(screenshotView);
                screenshotView.Dispose();
                screenshotView = null;
            }
            else
            {
                Log.Info("WebView", $"------------screen shot is null-------");
            }

            if (hitTestImageView != null)
            {
                GetDefaultWindow().Remove(hitTestImageView);
                hitTestImageView.Dispose();
                hitTestImageView = null;
            }

            return false;
        }

        private bool OnWebViewTouchEvent(object source, View.TouchEventArgs args)
        {
            if (!simpleWebView.HasFocus())
            {
                FocusManager.Instance.SetCurrentFocusView(simpleWebView);
            }

            if (args.Touch.GetState(0) == PointStateType.Down && args.Touch.GetMouseButton(0) == MouseButton.Secondary)
            {
                if (menuView == null && menuPosition == null)
                {
                    menuPosition = args.Touch.GetScreenPosition(0);
                }
            }
            else if (args.Touch.GetState(0) == PointStateType.Down && args.Touch.GetMouseButton(0) == MouseButton.Primary)
            {
                if (menuView != null)
                {
                    menuView.HideMenu();
                    GetDefaultWindow().Remove(menuView);
                    menuView = null;
                    menuPosition = null;
                }
            }
            return false;
        }

        private void OnMenuViewItemSelected(object source, MenuView.ItemClickedEventArgs e)
        {
            Log.Info("WebView", $"------------menu item is selected-------");
            GetDefaultWindow().Remove(menuView);
            menuView = null;
        }

        private void OnWebViewFocusGained(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------web view focus is gained-------");
        }

        private void OnWebViewFocusLost(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------web view focus is lost-------");
        }

        private void OnHttpAuthRequested(object sender, WebViewHttpAuthRequestedEventArgs e)
        {
            Log.Info("WebView", $"------------http auth requested, Realm: {e.HttpAuthHandler.Realm}-------");
            e.HttpAuthHandler.CancelCredential();
            e.HttpAuthHandler.Suspend();
            e.HttpAuthHandler.UseCredential("", "");
        }

        private void OnHttpRequestIntercepted(WebHttpRequestInterceptor interceptor)
        {
            Log.Info("WebView", $"------------http request intercepted, Url: {interceptor.Url}-------");

            interceptor.Ignore();

            Log.Info("WebView", $"------------http request intercepted-------");
        }

        private void OnSslCertificateChanged(object sender, WebViewCertificateReceivedEventArgs e)
        {
            Log.Info("WebView", $"------------ssl certificate changed, IsFromMainFrame: {e.Certificate.IsFromMainFrame}-------");
            Log.Info("WebView", $"------------ssl certificate changed, PemData: {e.Certificate.PemData}-------");
            Log.Info("WebView", $"------------ssl certificate changed, PemData: {e.Certificate.IsContextSecure}-------");
        }

        private void OnPageLoadStarted(object sender, WebViewPageLoadEventArgs e)
        {
            Log.Info("WebView", $"------------web view start to load time: {DateTime.Now.Ticks - startTime}-------");
        }

        private void OnPageLoading(object sender, WebViewPageLoadEventArgs e)
        {
            Log.Info("WebView", $"------------web view is loading-------");
        }

        private void OnPageLoadFinished(object sender, WebViewPageLoadEventArgs e)
        {
            Log.Info("WebView", $"------------web view finishes loading-------");

            if (simpleWebView.CanGoBack())
            {
                backButton.IsEnabled = true;
            }
            else
            {
                backButton.IsEnabled = false;
            }

            if (simpleWebView.CanGoForward())
            {
                forwardButton.IsEnabled = true;
            }
            else
            {
                forwardButton.IsEnabled = false;
            }
        }

        private void OnPageLoadError(object sender, WebViewPageLoadErrorEventArgs e)
        {
            Log.Info("WebView", $"------------web view load error, Url: {e.PageLoadError.Url}-------");
            Log.Info("WebView", $"------------web view load error, Code: {e.PageLoadError.Code}-------");
            Log.Info("WebView", $"------------web view load error, Description: {e.PageLoadError.Description}-------");
            Log.Info("WebView", $"------------web view load error, Type: {e.PageLoadError.Type}-------");
        }

        private void OnScrollEdgeReached(object sender, WebViewScrollEdgeReachedEventArgs e)
        {
            Log.Info("WebView", $"------------scroll edge reached, ScrollEdge: {e.ScrollEdge}-------");
        }

        private void OnUrlChanged(object sender, WebViewUrlChangedEventArgs e)
        {
            Log.Info("WebView", $"------------url changed, NewPageUrl: {e.NewPageUrl}-------");
        }

        private void OnFormRepostPolicyDecided(object sender, WebViewFormRepostPolicyDecidedEventArgs e)
        {
            Log.Info("WebView", $"------------form repost policy decided-------");
            e.FormRepostPolicyDecisionMaker.Reply(true);
        }

        private void OnFrameRendered(object sender, EventArgs e)
        {
            Log.Info("WebView", $"------------frame rendered-------");
        }

        private void OnContextMenuShown(object sender, WebViewContextMenuShownEventArgs e)
        {
            Log.Info("WebView", $"------------context menu is shown, -------");

            if (menuPosition != null)
            {
                menuView = new MenuView(e.ContextMenu)
                {
                    BackgroundColor = Color.Cyan,
                    Position = new Position(menuPosition),
                    Size = new Size(200, e.ContextMenu.ItemCount * 80),
                };
                menuView.ClickedEvent += OnMenuViewItemSelected;
                GetDefaultWindow().Add(menuView);
            }

            Log.Info("WebView", $"------------context menu shown, ItemList ItemCount: {e.ContextMenu.ItemCount}-------");
            if (e.ContextMenu.ItemCount > 0)
            {
                WebContextMenuItem item = e.ContextMenu.GetItemAtIndex(0);
                Log.Info("WebView", $"------------context menu shown, Item Tag: {item.Tag}-------");
                Log.Info("WebView", $"------------context menu shown, Item Type: {item.Type}-------");
                Log.Info("WebView", $"------------context menu shown, Item IsEnabled: {item.IsEnabled}-------");
                Log.Info("WebView", $"------------context menu shown, Item LinkUrl: {item.LinkUrl}-------");
                Log.Info("WebView", $"------------context menu shown, Item ImageUrl: {item.ImageUrl}-------");
                Log.Info("WebView", $"------------context menu shown, Item Title: {item.Title}-------");
                if (item.ParentMenu != null)
                {
                    Log.Info("WebView", $"------------context menu shown, ParentMenu item count: {item.ParentMenu.ItemCount}-------");
                }
            }
            Log.Info("WebView", $"------------context menu shown, ItemCount: {e.ContextMenu.ItemCount}-------");
            //Log.Info("WebView", $"------------context menu shown, Position: {e.ContextMenu.Position}-------");
            e.ContextMenu.AppendItem(WebContextMenuItem.ItemTag.NoAction, "test1", true);
            e.ContextMenu.AppendItem(WebContextMenuItem.ItemTag.NoAction, "test2", "", true);
            //e.ContextMenu.Hide();
            if (e.ContextMenu.ItemCount > 0)
            {
                //WebContextMenuItem item = e.ContextMenu.GetItemAtIndex(0);
                //e.ContextMenu.SelectItem(item);
                //e.ContextMenu.RemoveItem(item);
            }
        }

        private void OnContextMenuHidden(object sender, WebViewContextMenuHiddenEventArgs e)
        {
            Log.Info("WebView", $"------------context menu is hidden, -------");
        }

        private void OnConsoleMessageReceived(object sender, WebViewConsoleMessageReceivedEventArgs e)
        {
            Log.Info("WebView", $"------------console message received, Source: {e.ConsoleMessage.Source}-------");
            Log.Info("WebView", $"------------console message received, Line: {e.ConsoleMessage.Line}-------");
            Log.Info("WebView", $"------------console message received, Level: {e.ConsoleMessage.Level}-------");
            Log.Info("WebView", $"------------console message received, Text: {e.ConsoleMessage.Text}-------");
        }

        private void OnCertificateConfirmed(object sender, WebViewCertificateReceivedEventArgs e)
        {
            Log.Info("WebView", $"------------ssl certificate confirmed, IsFromMainFrame: {e.Certificate.IsFromMainFrame}-------");
            Log.Info("WebView", $"------------ssl certificate confirmed, PemData: {e.Certificate.PemData}-------");
            Log.Info("WebView", $"------------ssl certificate confirmed, PemData: {e.Certificate.IsContextSecure}-------");
            e.Certificate.Allow(true);
        }

        private void OnResponsePolicyDecided(object sender, WebViewResponsePolicyDecidedEventArgs e)
        {
            Log.Info("WebView", $"------------response policy decided, Url: {e.ResponsePolicyDecisionMaker.Url}-------");
            Log.Info("WebView", $"------------response policy decided, Cookie: {e.ResponsePolicyDecisionMaker.Cookie}-------");
            Log.Info("WebView", $"------------response policy decided, PolicyDecisionType: {e.ResponsePolicyDecisionMaker.PolicyDecisionType}-------");
            Log.Info("WebView", $"------------response policy decided, ResponseMime: {e.ResponsePolicyDecisionMaker.ResponseMime}-------");
            Log.Info("WebView", $"------------response policy decided, ResponseStatusCode: {e.ResponsePolicyDecisionMaker.ResponseStatusCode}-------");
            Log.Info("WebView", $"------------response policy decided, DecisionNavigationType: {e.ResponsePolicyDecisionMaker.DecisionNavigationType}-------");
            Log.Info("WebView", $"------------response policy decided, Scheme: {e.ResponsePolicyDecisionMaker.Scheme}-------");
            if (e.ResponsePolicyDecisionMaker.Frame != null)
            {
                Log.Info("WebView", $"------------response policy decided, Frame.IsMainFrame: {e.ResponsePolicyDecisionMaker.Frame.IsMainFrame}-------");
            }
            //e.ResponsePolicyDecisionMaker.Ignore();
            //e.ResponsePolicyDecisionMaker.Suspend();
            //e.ResponsePolicyDecisionMaker.Use();
        }

        private void OnJavaScriptMessageReceived(string message)
        {
            Log.Info("WebView", $"------------javascript message handler, message: {message}-------");
        }

        private void OnVideoPlaying(bool isPlaying)
        {
            Log.Info("WebView", $"------------video playing, isPlaying: {isPlaying}-------");
        }

        private void OnScreenshotAcquired(ImageView image)
        {
            Log.Info("WebView", $"------------screen shot acquired-------");

            if (image != null)
            {
                screenshotView = image;
                screenshotView.Position = new Position(500, 500);
                screenshotView.BackgroundColor = Color.Blue;
                GetDefaultWindow().Add(screenshotView);
                if (messageTimer.IsRunning())
                {
                    messageTimer.Stop();
                }
                messageTimer.Start();
                Log.Info("WebView", $"------------screen shot would be shown-------");
            }
        }

        private void OnHitTestFinished(WebHitTestResult test)
        {
            Log.Info("WebView", $"------------hit test finished-------");
            Log.Info("WebView", $"WebHitTestResult, TestResultContext: {test.TestResultContext}");
            Log.Info("WebView", $"WebHitTestResult, LinkUrl: {test.LinkUrl}");
            Log.Info("WebView", $"WebHitTestResult, LinkTitle: {test.LinkTitle}");
            Log.Info("WebView", $"WebHitTestResult, LinkLabel: {test.LinkLabel}");
            Log.Info("WebView", $"WebHitTestResult, ImageUrl: {test.ImageUrl}");
            Log.Info("WebView", $"WebHitTestResult, MediaUrl: {test.MediaUrl}");
            Log.Info("WebView", $"WebHitTestResult, TagName: {test.TagName}");
            Log.Info("WebView", $"WebHitTestResult, NodeValue: {test.NodeValue}");
            if (test.Attributes != null)
            {
                Log.Info("WebView", $"WebHitTestResult, Attributes: {test.Attributes}");
            }
            Log.Info("WebView", $"WebHitTestResult, ImageFileNameExtension: {test.ImageFileNameExtension}");
            ImageView imageView = test.Image;
            if (imageView != null)
            {
                hitTestImageView = imageView;
                hitTestImageView.Position = new Position(1000, 500);
                hitTestImageView.BackgroundColor = Color.Blue;
                GetDefaultWindow().Add(hitTestImageView);
                if (messageTimer.IsRunning())
                {
                    messageTimer.Stop();
                }
                messageTimer.Start();
                Log.Info("WebView", $"WebHitTestResult, Got image view");
            }
        }

        private void OnJavaScriptAlert(string message)
        {
            Log.Info("WebView", $"------------javascript alert {message}-------");
            simpleWebView.JavaScriptAlertReply();
        }

        private void OnGeolocationPermission(string host, string protocol)
        {
            Log.Info("WebView", $"------------geolocation permission, host: {host}, protocol: {protocol}-------");
        }

        private void OnJavaScriptConfirm(string message)
        {
            Log.Info("WebView", $"------------javascript confirm {message}-------");
            simpleWebView.JavaScriptConfirmReply(true);
        }

        private void OnJavaScriptPrompt(string message1, string message2)
        {
            Log.Info("WebView", $"------------javascript prompt {message1}, {message2}-------");
            simpleWebView.JavaScriptPromptReply("test");
        }

        private void OnPasswordDataListAcquired(IList<WebPasswordData> list)
        {
            Log.Info("WebView", $"------------password data list, count: {list.Count}-------");
            string[] passwords = new string[list.Count];
            for (int i = 0; i < list.Count; i++)
            {
                WebPasswordData data = list[i];
                passwords[i] = data.Url;
                Log.Info("WebView", $"------------password data, Url: {data.Url}-------");
                Log.Info("WebView", $"------------password data, FingerprintUsed: {data.FingerprintUsed}-------");
            }

            if (list.Count > 0)
            {
                simpleWebView.Context.DeleteFormPasswordDataList(passwords);
            }
        }

        private void OnSecurityOriginListAcquired(IList<WebSecurityOrigin> list)
        {
            Log.Info("WebView", $"------------security origin, count: {list.Count}-------");
            for (int i = 0; i < list.Count; i++)
            {
                WebSecurityOrigin origin = list[i];
                Log.Info("WebView", $"------------security origin, Host: {origin.Host}-------");
                Log.Info("WebView", $"------------security origin, Protocol: {origin.Protocol}-------");
            }

            if (list.Count > 0)
            {
                WebSecurityOrigin origin = list[0];
                simpleWebView.Context.GetWebStorageUsageForOrigin(origin, OnStorageUsageAcquired);
                simpleWebView.Context.DeleteApplicationCache(origin);
                simpleWebView.Context.DeleteWebDatabase(origin);
                simpleWebView.Context.DeleteWebStorage(origin);
            }
        }

        private void OnStorageUsageAcquired(ulong usage)
        {
            Log.Info("WebView", $"------------storage usage acquired, usage: {usage}-------");
        }

        private void OnDownloadStarted(string url)
        {
            Log.Info("WebView", $"------------download started, url: {url}-------");
        }

        private bool OnMimeOverridden(string url, string currentMime, out string newMime)
        {
            Log.Info("WebView", $"------------mime overridden, url: {url}-------");
            Log.Info("WebView", $"------------mime overridden, currentMime: {currentMime}-------");
            newMime = "test";
            return true;
        }

        private void OnCookieChanged(object sender, EventArgs e)
        {
            Log.Info("WebView", $"------------cookie changed-------");
        }

        private bool OnWebViewKeyEvent(object source, View.KeyEventArgs args)
        {
            bool result = false;

            Log.Info("WebView", $"----web view key is {args.Key.KeyPressedName}, state is {args.Key.State}-------");

            if (args.Key.State == Key.StateType.Up)
            {
                if (args.Key.KeyPressedName == "XF86RaiseChannel")
                {
                    Log.Info("WebView", $"old url is {simpleWebView.Url}.");
                    if (index != 0)
                    {
                        simpleWebView.Url = websites[--index].ToLowerInvariant();
                    }
                    else
                    {
                        simpleWebView.Url = websites[WEBSITES_COUNT - 1].ToLowerInvariant();
                    }
                    result = true;
                    Log.Info("WebView", $"new url is {simpleWebView.Url}.");
                }
                else if (args.Key.KeyPressedName == "XF86LowerChannel")
                {
                    Log.Info("WebView", $"old url is {simpleWebView.Url}.");
                    if (index != WEBSITES_COUNT - 1)
                    {
                        simpleWebView.Url = websites[++index].ToLowerInvariant();
                    }
                    else
                    {
                        simpleWebView.Url = websites[0].ToLowerInvariant();
                    }
                    result = true;
                    Log.Info("WebView", $"new url is {simpleWebView.Url}.");
                }
                //else if (args.Key.KeyPressedName == "1")
                //{
                //    Rectangle viewArea = new Rectangle(0, 0, 20, 20);
                //    bool succeeded = simpleWebView.GetScreenshotAsynchronously(viewArea, 1.0f, OnScreenshotAcquired);
                //    Log.Info("WebView", $"GetScreenshotAsynchronously, {succeeded}");

                //    succeeded = simpleWebView.HitTestAsynchronously(100, 100, BaseComponents.WebView.HitTestMode.Default, OnHitTestFinished);
                //    Log.Info("WebView", $"HitTestAsynchronously, {succeeded}");
                //}
                else if (args.Key.KeyPressedName == "XF86Red")
                {
                    if (redKeyPressedCount % 2 == 0)
                    {
                        simpleWebView.Context.RegisterHttpRequestInterceptedCallback(OnHttpRequestIntercepted);
                        redKeyPressedCount = 0;
                    }
                    else
                    {
                        simpleWebView.Context.RegisterHttpRequestInterceptedCallback(null);
                    }
                    redKeyPressedCount++;
                    FocusManager.Instance.SetCurrentFocusView(addressBar);
                    result = true;
                }
                else if (args.Key.KeyPressedName == "XF86Blue")
                {
                    blueKeyPressedCount++;
                    if (blueKeyPressedCount % 6 == 0)
                    {
                        simpleWebView.Position = new Position(0, ADDRESSBAR_HEIGHT);
                        simpleWebView.Orientation = new Rotation(new Radian(new Degree(60 * blueKeyPressedCount)), Vector3.ZAxis);
                        blueKeyPressedCount = 0;
                    }
                    else
                    {
                        simpleWebView.Orientation = new Rotation(new Radian(new Degree(60 * blueKeyPressedCount)), Vector3.ZAxis);
                    }
                    result = true;
                }
                else if (args.Key.KeyPressedName == "XF86Yellow")
                {
                    yellowKeyPressedCount++;
                    int wdistance = (SCREEN_WIDTH - MIN_WEBVIEW_WIDTH) / 5;
                    int hdistance = (SCREEN_HEIGHT - MIN_WEBVIEW_HEIGHT - ADDRESSBAR_HEIGHT) / 5;
                    simpleWebView.Position = new Position((SCREEN_WIDTH - MIN_WEBVIEW_WIDTH - yellowKeyPressedCount * wdistance) / 2, ADDRESSBAR_HEIGHT);
                    simpleWebView.Size = new Size(MIN_WEBVIEW_WIDTH + yellowKeyPressedCount * wdistance, MIN_WEBVIEW_HEIGHT + hdistance * yellowKeyPressedCount);
                    if (yellowKeyPressedCount % 5 == 0)
                    {
                        yellowKeyPressedCount = 0;
                    }
                    result = true;
                }
                else if (args.Key.KeyPressedName == "XF86Green")
                {
                    Log.Info("WebView", $"key XF86Green is pressed.");

                    //greenKeyPressedCount++;
                    if (simpleWebView.Url.Contains("account.samsung"))
                    {
                        // webview apis
                        Log.Info("WebView", $"web page title is {simpleWebView.Title}");

                        //faviconView = simpleWebView.Favicon;
                        //if (faviconView != null)
                        //{
                        //    faviconView.Position = new Position(500, 100);
                        //    GetDefaultWindow().Add(faviconView);
                        //    messageTimer.Start();
                        //}

                        simpleWebView.ContentBackgroundColor = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                        Log.Info("WebView", $"web page ContentBackgroundColor is {simpleWebView.ContentBackgroundColor}");
                        simpleWebView.TilesClearedWhenHidden = true;
                        Log.Info("WebView", $"web page TilesClearedWhenHidden is {simpleWebView.TilesClearedWhenHidden}");
                        simpleWebView.TileCoverAreaMultiplier = 2.0f;
                        Log.Info("WebView", $"web page TileCoverAreaMultiplier is {simpleWebView.TileCoverAreaMultiplier}");
                        simpleWebView.CursorEnabledByClient = true;
                        Log.Info("WebView", $"web page CursorEnabledByClient is {simpleWebView.CursorEnabledByClient}");
                        Log.Info("WebView", $"web page SelectedText is {simpleWebView.SelectedText}");
                        simpleWebView.PageZoomFactor = 2.0f;
                        Log.Info("WebView", $"web page PageZoomFactor is {simpleWebView.PageZoomFactor}");
                        simpleWebView.TextZoomFactor = 2.0f;
                        Log.Info("WebView", $"web page TextZoomFactor is {simpleWebView.TextZoomFactor}");
                        Log.Info("WebView", $"web page LoadProgressPercentage is {simpleWebView.LoadProgressPercentage}");

                        //simpleWebView.ActivateAccessibility(true);
                        //simpleWebView.AddCustomHeader("test", "value");
                        //simpleWebView.AddDynamicCertificatePath("", "");
                        simpleWebView.AddJavaScriptMessageHandler("", OnJavaScriptMessageReceived);
                        simpleWebView.CheckVideoPlayingAsynchronously(OnVideoPlaying);
                        //simpleWebView.ClearAllTilesResources();
                        //simpleWebView.ClearHistory();
                        simpleWebView.EvaluateJavaScript("document.body.style.backgroundColor='yellow';");
                        Log.Info("WebView", $"web view, ScaleFactor is {simpleWebView.GetScaleFactor()}");

                        //Rectangle viewArea = new Rectangle(0, 0, 20, 20);
                        //ImageView shotView = simpleWebView.GetScreenshot(viewArea, 1.0f);
                        //if (shotView != null)
                        //{
                        //    shotView.Position = new Position(500, 200);
                        //    GetDefaultWindow().Add(shotView);
                        //}

                        simpleWebView.HighlightText("test", BaseComponents.WebView.FindOption.CaseInsensitive, 2);
                        Log.Info("WebView", $"web view, here");
                        WebHitTestResult test = null;//simpleWebView.HitTest(100, 100, WebView.HitTestMode.Default);
                        if (test != null)
                        {
                            Log.Info("WebView", $"WebHitTestResult, TestResultContext: {test.TestResultContext}");
                            Log.Info("WebView", $"WebHitTestResult, LinkUrl: {test.LinkUrl}");
                            Log.Info("WebView", $"WebHitTestResult, LinkTitle: {test.LinkTitle}");
                            Log.Info("WebView", $"WebHitTestResult, LinkLabel: {test.LinkLabel}");
                            Log.Info("WebView", $"WebHitTestResult, ImageUrl: {test.ImageUrl}");
                            Log.Info("WebView", $"WebHitTestResult, MediaUrl: {test.MediaUrl}");
                            Log.Info("WebView", $"WebHitTestResult, TagName: {test.TagName}");
                            Log.Info("WebView", $"WebHitTestResult, NodeValue: {test.NodeValue}");
                            if (test.Attributes != null)
                            {
                                Log.Info("WebView", $"WebHitTestResult, Attributes: {test.Attributes}");
                            }
                            Log.Info("WebView", $"WebHitTestResult, NodeValue: {test.ImageFileNameExtension}");
                            ImageView imageView = test.Image;
                            if (imageView != null)
                            {
                                imageView.Position = new Position(500, 500);
                                GetDefaultWindow().Add(imageView);
                            }
                        }

                        simpleWebView.RegisterGeolocationPermissionCallback(OnGeolocationPermission);
                        Log.Info("WebView", $"Register javascript alert/confirm/prompt callback.");
                        simpleWebView.RegisterJavaScriptAlertCallback(OnJavaScriptAlert);
                        simpleWebView.RegisterJavaScriptConfirmCallback(OnJavaScriptConfirm);
                        simpleWebView.RegisterJavaScriptPromptCallback(OnJavaScriptPrompt);
                        //Log.Info("WebView", $"Reload without cache.");
                        //simpleWebView.ReloadWithoutCache();
                        //Log.Info("WebView", $"Remove custom header");
                        //simpleWebView.RemoveCustomHeader("test");
                        //Log.Info("WebView", $"Suspend");
                        //simpleWebView.Suspend();
                        //simpleWebView.SuspendNetworkLoading();
                        //Log.Info("WebView", $"Resume");
                        //simpleWebView.Resume();
                        //simpleWebView.ResumeNetworkLoading();
                        //Log.Info("WebView", $"load contents");
                        //simpleWebView.LoadContents();
                        //simpleWebView.LoadHtmlStringOverrideCurrentEntry();
                        //simpleWebView.LoadHtmlString("<Html><Head><title>Example</title></Head><Body><b>[This text is Bold......]</b></Body></Html>");
                        //simpleWebView.ScrollPosition = new Position(0, 200);
                        //simpleWebView.ScrollBy(0, 50);
                        //simpleWebView.ScrollEdgeBy(0, 50);

                        //Log.Info("WebView", $"scroll position is ({simpleWebView.ScrollPosition.X}, {simpleWebView.ScrollPosition.Y}).");
                        //Log.Info("WebView", $"scroll size is ({simpleWebView.ScrollSize.Width}, {simpleWebView.ScrollSize.Height}).");
                        //Log.Info("WebView", $"content size is ({simpleWebView.ContentSize.Width}, {simpleWebView.ContentSize.Height}).");

                        //simpleWebView.StartInspectorServer(8080);
                        //simpleWebView.StopInspectorServer();
                        //simpleWebView.StopLoading();

                        // websettings apis
                        simpleWebView.Settings.LinkMagnifierEnabled = true;
                        Log.Info("WebView", $"web settings LinkMagnifierEnabled is {simpleWebView.Settings.LinkMagnifierEnabled}");
                        simpleWebView.Settings.ViewportMetaTag = true;
                        Log.Info("WebView", $"web settings ViewportMetaTag is {simpleWebView.Settings.ViewportMetaTag}");
                        simpleWebView.Settings.DefaultTextEncodingName = "utf-8";
                        Log.Info("WebView", $"web settings DefaultTextEncodingName is {simpleWebView.Settings.DefaultTextEncodingName}");
                        simpleWebView.Settings.AutomaticImageLoadingAllowed = true;
                        Log.Info("WebView", $"web settings AutomaticImageLoadingAllowed is {simpleWebView.Settings.AutomaticImageLoadingAllowed}");
                        simpleWebView.Settings.ScriptsOpenWindowsAllowed = true;
                        Log.Info("WebView", $"web settings ScriptsOpenWindowsAllowed is {simpleWebView.Settings.ScriptsOpenWindowsAllowed}");
                        simpleWebView.Settings.ImePanelEnabled = true;
                        Log.Info("WebView", $"web settings ImePanelEnabled is {simpleWebView.Settings.ImePanelEnabled}");
                        simpleWebView.Settings.ClipboardEnabled = true;
                        Log.Info("WebView", $"web settings ClipboardEnabled is {simpleWebView.Settings.ClipboardEnabled}");
                        simpleWebView.Settings.ArrowScrollEnabled = true;
                        Log.Info("WebView", $"web settings ArrowScrollEnabled is {simpleWebView.Settings.ArrowScrollEnabled}");
                        simpleWebView.Settings.TextAutosizingEnabled = true;
                        Log.Info("WebView", $"web settings TextAutosizingEnabled is {simpleWebView.Settings.TextAutosizingEnabled}");
                        simpleWebView.Settings.TextSelectionEnabled = true;
                        Log.Info("WebView", $"web settings TextSelectionEnabled is {simpleWebView.Settings.TextSelectionEnabled}");
                        simpleWebView.Settings.FormCandidateDataEnabled = true;
                        Log.Info("WebView", $"web settings FormCandidateDataEnabled is {simpleWebView.Settings.FormCandidateDataEnabled}");
                        simpleWebView.Settings.AutofillPasswordFormEnabled = true;
                        Log.Info("WebView", $"web settings AutofillPasswordFormEnabled is {simpleWebView.Settings.AutofillPasswordFormEnabled}");
                        simpleWebView.Settings.KeypadWithoutUserActionUsed = true;
                        Log.Info("WebView", $"web settings KeypadWithoutUserActionUsed is {simpleWebView.Settings.KeypadWithoutUserActionUsed}");
                        simpleWebView.Settings.ZoomForced = true;
                        Log.Info("WebView", $"web settings ZoomForced is {simpleWebView.Settings.ZoomForced}");
                        simpleWebView.Settings.TextZoomEnabled = true;
                        Log.Info("WebView", $"web settings TextZoomEnabled is {simpleWebView.Settings.TextZoomEnabled}");
                        simpleWebView.Settings.PluginsEnabled = true;
                        Log.Info("WebView", $"web settings PluginsEnabled is {simpleWebView.Settings.PluginsEnabled}");
                        simpleWebView.Settings.AutoFittingEnabled = true;
                        Log.Info("WebView", $"web settings AutoFittingEnabled is {simpleWebView.Settings.AutoFittingEnabled}");
                        simpleWebView.Settings.JavaScriptEnabled = true;
                        Log.Info("WebView", $"web settings JavaScriptEnabled is {simpleWebView.Settings.JavaScriptEnabled}");
                        simpleWebView.Settings.FileAccessFromExternalUrlAllowed = true;
                        Log.Info("WebView", $"web settings FileAccessFromExternalUrlAllowed is {simpleWebView.Settings.FileAccessFromExternalUrlAllowed}");
                        simpleWebView.Settings.ScrollbarThumbFocusNotificationsUsed = true;
                        Log.Info("WebView", $"web settings ScrollbarThumbFocusNotificationsUsed is {simpleWebView.Settings.ScrollbarThumbFocusNotificationsUsed}");
                        simpleWebView.Settings.DoNotTrackEnabled = true;
                        Log.Info("WebView", $"web settings DoNotTrackEnabled is {simpleWebView.Settings.DoNotTrackEnabled}");
                        simpleWebView.Settings.CacheBuilderEnabled = true;
                        Log.Info("WebView", $"web settings CacheBuilderEnabled is {simpleWebView.Settings.CacheBuilderEnabled}");
                        simpleWebView.Settings.WebSecurityEnabled = true;
                        Log.Info("WebView", $"web settings WebSecurityEnabled is {simpleWebView.Settings.WebSecurityEnabled}");
                        simpleWebView.Settings.DefaultFontSize = 20;
                        Log.Info("WebView", $"web settings DefaultFontSize is {simpleWebView.Settings.DefaultFontSize}");
                        simpleWebView.Settings.SpatialNavigationEnabled = true;
                        Log.Info("WebView", $"web settings SpatialNavigationEnabled is {simpleWebView.Settings.SpatialNavigationEnabled}");
                        simpleWebView.Settings.MixedContentsAllowed = true;
                        Log.Info("WebView", $"web settings MixedContentsAllowed is {simpleWebView.Settings.MixedContentsAllowed}");
                        simpleWebView.Settings.PrivateBrowsingEnabled = true;
                        Log.Info("WebView", $"web settings PrivateBrowsingEnabled is {simpleWebView.Settings.PrivateBrowsingEnabled}");
                        simpleWebView.Settings.EnableExtraFeature("feature", true);
                        Log.Info("WebView", $"web settings EnableExtraFeature is {simpleWebView.Settings.IsExtraFeatureEnabled("feature")}");

                        // webcontext apis
                        simpleWebView.Context.AppType = WebContext.ApplicationType.WebBrowser;
                        Log.Info("WebView", $"web context, AppType: {simpleWebView.Context.AppType}");
                        simpleWebView.Context.AppVersion = "6.5";
                        Log.Info("WebView", $"web context, AppVersion: {simpleWebView.Context.AppVersion}");
                        simpleWebView.Context.AppId = "1.0id";
                        Log.Info("WebView", $"web context, AppId: {simpleWebView.Context.AppId}");
                        simpleWebView.Context.CacheEnabled = false;
                        Log.Info("WebView", $"web context, CacheEnabled: {simpleWebView.Context.CacheEnabled}");
                        simpleWebView.Context.CertificateFilePath = "/root/share";
                        Log.Info("WebView", $"web context, CertificateFilePath: {simpleWebView.Context.CertificateFilePath}");
                        simpleWebView.Context.ProxyUrl = "https://127.0.0.1";
                        Log.Info("WebView", $"web context, ProxyUrl: {simpleWebView.Context.ProxyUrl}");
                        simpleWebView.Context.CacheModel = WebContext.CacheModelType.DocumentBrowser;
                        Log.Info("WebView", $"web context, cache model is {simpleWebView.Context.CacheModel}");
                        Log.Info("WebView", $"web context, ProxyBypassRule: {simpleWebView.Context.ProxyBypassRule}");
                        simpleWebView.Context.DefaultZoomFactor = 2.0f;
                        Log.Info("WebView", $"web context, DefaultZoomFactor: {simpleWebView.Context.DefaultZoomFactor}");
                        //simpleWebView.Context.ClearCache();
                        //simpleWebView.Context.DeleteAllApplicationCache();
                        //simpleWebView.Context.DeleteAllFormCandidateData();
                        //simpleWebView.Context.DeleteAllFormPasswordData();
                        //simpleWebView.Context.DeleteAllWebDatabase();
                        //simpleWebView.Context.DeleteAllWebIndexedDatabase();
                        //simpleWebView.Context.DeleteAllWebStorage();
                        //simpleWebView.Context.DeleteLocalFileSystem();
                        //simpleWebView.Context.FreeUnusedMemory();
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.GetFormPasswordList(OnPasswordDataListAcquired);
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.GetWebDatabaseOrigins(OnSecurityOriginListAcquired);
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.GetWebStorageOrigins(OnSecurityOriginListAcquired);
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.RegisterDownloadStartedCallback(OnDownloadStarted);
                        Log.Info("WebView", $"web view, here");
                        string[] mimes = { "txt" };
                        simpleWebView.Context.RegisterJsPluginMimeTypes(mimes);
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.RegisterMimeOverriddenCallback(OnMimeOverridden);
                        Log.Info("WebView", $"web view, here");
                        string[] schemes = { "test" };
                        simpleWebView.Context.RegisterUrlSchemesAsCorsEnabled(schemes);
                        Log.Info("WebView", $"web view, here");
                        simpleWebView.Context.SetProxyBypassRule("test", "");
                        Log.Info("WebView", $"web context, ContextProxy: {simpleWebView.Context.ProxyUrl}");
                        simpleWebView.Context.TimeOffset = 8.0f;
                        Log.Info("WebView", $"web context, TimeOffset: {simpleWebView.Context.TimeOffset}");
                        simpleWebView.Context.SetTimeZoneOffset(2.0f, 3.0f);
                        simpleWebView.Context.SetDefaultProxyAuth("user", "password");

                        // webcookiemanager apis
                        simpleWebView.CookieManager.CookieAcceptPolicy = WebCookieManager.CookieAcceptPolicyType.Never;
                        Log.Info("WebView", $"web cookie manager accept policy is {simpleWebView.CookieManager.CookieAcceptPolicy}");
                        //simpleWebView.CookieManager.ClearCookies();
                        simpleWebView.CookieManager.SetPersistentStorage("/root/share", WebCookieManager.CookiePersistentStorageType.SqlLite);
                        simpleWebView.CookieManager.CookieChanged += OnCookieChanged;

                        // webbackforwardlist apis
                        Log.Info("WebView", $"web back forward list item count is {simpleWebView.BackForwardList.ItemCount}");
                        WebBackForwardListItem item = simpleWebView.BackForwardList.GetCurrentItem();
                        Log.Info("WebView", $"web back forward list, current item url is {item.Url}");
                        Log.Info("WebView", $"web back forward list, current item title is {item.Title}");
                        Log.Info("WebView", $"web back forward list, current item original url is {item.OriginalUrl}");
                        if (simpleWebView.BackForwardList.ItemCount > 0)
                        {
                            item = simpleWebView.BackForwardList.GetItemAtIndex(0);
                            Log.Info("WebView", $"web back forward list, item0 url is {item.Url}");
                            Log.Info("WebView", $"web back forward list, item0 title is {item.Title}");
                            Log.Info("WebView", $"web back forward list, item0 original url is {item.OriginalUrl}");
                            IList<WebBackForwardListItem> subList = simpleWebView.BackForwardList.GetForwardItems(0);
                            Log.Info("WebView", $"web back forward list, forward sub list ItemCount is {subList.Count}");
                            subList = simpleWebView.BackForwardList.GetBackwardItems(0);
                            Log.Info("WebView", $"web back forward list, backward sub list  ItemCount is {subList.Count}");
                        }

                        //
                        result = true;
                    }
                }
            }

            return result;
        }

        private bool OnAddressBarTouchEvent(object source, View.TouchEventArgs args)
        {
            FocusManager.Instance.SetCurrentFocusView(addressBar);
            return false;
        }

        private void OnTextEditorFocusGained(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------address bar focus is gained-------");

            addressBar.Text = "";

            addressBar.GetInputMethodContext().Activate();
            addressBar.GetInputMethodContext().ShowInputPanel();
        }

        private void OnTextEditorFocusLost(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------address bar focus lost-------");
        }

        private bool OnAddressBarKeyEvent(object source, View.KeyEventArgs args)
        {
            Log.Info("WebView", $"------------address bar key is {args.Key.KeyPressedName}-------");

            if (args.Key.State == Key.StateType.Up)
            {
                if (args.Key.KeyPressedName == "Select")
                {
                    Log.Info("WebView", $"------------address bar text is {addressBar.Text}-------");

                    if (addressBar.Text.Length > 0)
                    {
                        addressBar.GetInputMethodContext().HideInputPanel();
                        addressBar.GetInputMethodContext().Deactivate();

                        simpleWebView.Url = $"http://{addressBar.Text.ToLowerInvariant()}";

                        // set focus to webview.
                        FocusManager.Instance.SetCurrentFocusView(simpleWebView);
                    }
                }
                else if (args.Key.KeyPressedName == "BackSpace")
                {
                    if (addressBar.Text.Length > 0)
                    {
                        addressBar.Text = addressBar.Text.Substring(0, addressBar.Text.Length - 1);
                    }
                }
                else if (args.Key.KeyPressedName == "XF86Red")
                {
                    FocusManager.Instance.SetCurrentFocusView(simpleWebView);
                }
            }

            return true;
        }

        private void Instance_KeyEvent(object sender, Window.KeyEventArgs args)
        {
            if (args.Key.State == Key.StateType.Up)
            {
                Log.Info("WebView", $"window key is {args.Key.KeyPressedName}.");

                if (args.Key.KeyPressedName == "XF86Exit")
                {
                    if (simpleWebView != null)
                    {
                        GetDefaultWindow().Remove(simpleWebView);
                        simpleWebView.Dispose();
                        simpleWebView = null;
                        Log.Info("WebView", $"WebView is disposed..............");
                    }
                }
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            startTime = DateTime.Now.Ticks;
            Log.Info("WebView", $"------------web view start time: {startTime}-------");
            new SimpleWebViewApplication().Run(args);
        }
    }
}