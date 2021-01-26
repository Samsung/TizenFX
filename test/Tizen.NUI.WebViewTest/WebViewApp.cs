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
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.WebViewTest
{
    public class WebViewApplication : NUIApplication
    {
        private WebView simpleWebView = null;
        private TextField addressBar = null;

        private int index = 0;
        private const int WEBSITES_COUNT = 93;
        private string[] websites = 
        {
            "http://www.baidu.com","http://www.Google.com","http://www.Facebook.com","http://www.Youtube.com","http://www.Yahoo.com",
            "http://www.Amazon.com","http://www.Wikipedia.org","http://www.Google.co.in","http://www.Qq.com","http://www.Twitter.com",
            "http://www.Live.com","http://www.Taobao.com","http://www.Msn.com","http://www.Yahoo.co.jp","http://www.Linkedin.com",
            "http://www.Google.co.jp","http://www.Sina.com.cn","http://www.Bing.com","http://www.Weibo.com","http://www.Yandex.ru",
            "http://www.Vk.com","http://www.Instagram.com","http://www.Hao123.com","http://www.Ebay.com","http://www.Google.de",
            "http://www.Amazon.co.jp","http://www.Mail.ru","http://www.Google.co.uk","http://www.Google.ru","http://www.Pinterest.com",
            "http://www.360.cn","http://www.T.co","http://www.Reddit.com","http://www.Google.com.br","http://www.Netflix.com",
            "http://www.Tmall.com","http://www.Google.fr","http://www.Paypal.com","http://www.Microsoft.com","http://www.Wordpress.com",
            "http://www.Sohu.com","http://www.Blogspot.com","http://www.Google.it","http://www.Google.es","http://www.Onclickads.net",
            "http://www.Tumblr.com","http://www.Imgur.com","http://www.Gmw.cn","http://www.Ok.ru","http://www.Aliexpress.com",
            "http://www.Apple.com","http://www.Imdb.com","http://www.Stackoverflow.com","http://www.Fc2.com","http://www.Google.com.mx",
            "http://www.Ask.com","http://www.Amazon.de","http://www.Google.com.hk","http://www.Google.com.tr","http://www.Alibaba.com",
            "http://www.Google.ca","http://www.Office.com","http://www.Rakuten.co.jp","http://www.Google.co.id","http://www.Tianya.cn",
            "http://www.Xinhuanet.com","http://www.Github.com","http://www.Craigslist.org","http://www.Nicovideo.jp","http://www.Soso.com",
            "http://www.Amazon.co.uk","http://www.Amazon.in","http://www.Blogger.com","http://www.Kat.cr","http://www.Outbrain.com",
            "http://www.Pixnet.net","http://www.Cnn.com","http://www.Go.com","http://www.Google.pl","http://www.Dropbox.com",
            "http://www.Google.com.au","http://www.360.com","http://www.Haosou.com","http://www.Naver.com","http://www.Jd.com",
            "http://www.Adobe.com","http://www.Flipkart.com","http://www.Whatsapp.com","http://www.Nytimes.com","http://www.Coccoc.com",
            "http://www.Chase.com","http://www.Chinadaily.com.cn","http://www.bbc.co.uk"
        };

        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        private const int ADDRESSBAR_HEIGHT = 100;

        private const int SCREEN_WIDTH = 1920;
        private const int SCREEN_HEIGHT = 1080;

        private const int MIN_WEBVIEW_WIDTH = 1000;
        private const int MIN_WEBVIEW_HEIGHT = 600;

        private const int WEBVIEW_WIDTH = SCREEN_WIDTH;
        private const int WEBVIEW_HEIGHT = SCREEN_HEIGHT - ADDRESSBAR_HEIGHT;

        private int blueKeyPressedCount = 0;
        private int yellowKeyPressedCount = 0;

        private static long startTime = 0;

        private TextLabel messageLabel = null;
        private Timer messageTimer = null;

        protected override void OnCreate()
        {
            base.OnCreate();

            GetDefaultWindow().BackgroundColor = new Color((float)189 /255, (float)179 /255, (float)204 /255, 1.0f);
            //EnvironmentVariable.SetEnvironmentVariable("DALI_WEB_ENGINE_NAME", "lwe");

            addressBar = new TextField()
            {
                BackgroundColor = Color.White,
                Size = new Size(SCREEN_WIDTH, ADDRESSBAR_HEIGHT),
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

            simpleWebView = new WebView()
            {
                Position = new Position(0, ADDRESSBAR_HEIGHT),
                Size = new Size(WEBVIEW_WIDTH, WEBVIEW_HEIGHT),
                UserAgent = USER_AGENT,
                Focusable = true,
            };
            simpleWebView.FocusGained += OnWebViewFocusGained;
            simpleWebView.FocusLost += OnWebViewFocusLost;
            simpleWebView.KeyEvent += OnWebViewKeyEvent;
            simpleWebView.TouchEvent += OnWebViewTouchEvent;
            simpleWebView.PageLoadStarted += OnPageLoadStarted;
            simpleWebView.ScrollEdgeReached += OnScrollEdgeReached;
            GetDefaultWindow().Add(simpleWebView);

            GetDefaultWindow().KeyEvent += Instance_KeyEvent;
            simpleWebView.LoadUrl(websites[index]);
            FocusManager.Instance.SetCurrentFocusView(simpleWebView);

            messageTimer = new Timer(10000);
            messageTimer.Tick += OnTick;
        }

        protected override void OnTerminate()
        {
            GetDefaultWindow().Remove(simpleWebView);
            GetDefaultWindow().Remove(addressBar);

            messageTimer.Tick -= OnTick;
            messageTimer.Dispose();
            messageTimer = null;

            base.OnTerminate();
        }

        private bool OnTick(object sender, EventArgs e)
        {
            GetDefaultWindow().Remove(messageLabel);
            messageLabel.Dispose();
            messageLabel = null;
            return false;
        }

        private bool OnWebViewTouchEvent(object source, View.TouchEventArgs args)
        {
            if (!simpleWebView.HasFocus())
            {
                FocusManager.Instance.SetCurrentFocusView(simpleWebView);
            }
            return false;
        }

        private void OnScrollEdgeReached(object sender, WebViewScrollEdgeReachedEventArgs e)
        {
            Log.Info("WebView", $"------------scroll edge reached: {e.ScrollEdge}-------");
        }

        private void OnPageLoadStarted(object sender, WebViewPageLoadEventArgs e)
        {
            Log.Info("WebView", $"------------web view start to load time: {DateTime.Now.Ticks - startTime}-------");
        }

        private void OnWebViewFocusGained(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------web view focus is gained-------");
        }

        private void OnWebViewFocusLost(object source, EventArgs args)
        {
            Log.Info("WebView", $"------------web view focus is lost-------");
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
                else if (args.Key.KeyPressedName == "XF86Back")
                {
                    simpleWebView.GoBack();
                    result = true;
                }
                else if (args.Key.KeyPressedName == "XF86Red")
                {
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
                    if (messageLabel != null)
                        return result;

                    Log.Info("WebView", $"key XF86Green is pressed.");

                    simpleWebView.ScrollPosition = new Position(0, 200);
                    simpleWebView.ScrollBy(0, 50);
                    Log.Info("WebView", $"scroll position is ({simpleWebView.ScrollPosition.X}, {simpleWebView.ScrollPosition.Y}).");
                    Log.Info("WebView", $"scroll size is ({simpleWebView.ScrollSize.Width}, {simpleWebView.ScrollSize.Height}).");
                    Log.Info("WebView", $"content size is ({simpleWebView.ContentSize.Width}, {simpleWebView.ContentSize.Height}).");

                    result = true;
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
            }
        }

        [STAThread]
        static void Main(string[] args)
        {
            startTime = DateTime.Now.Ticks;
            Log.Info("WebView", $"------------web view start time: {startTime}-------");
            new WebViewApplication().Run(args);
        }
    }
}

