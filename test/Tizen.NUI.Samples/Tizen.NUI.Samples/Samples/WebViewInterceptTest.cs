
using System;
using Tizen.NUI;
using Tizen.NUI.BaseComponents;
using Tizen.NUI.Components;
using System.IO;
using System.Text;

namespace Tizen.NUI.Samples
{
    using tlog = Tizen.Log;
    public class WebViewInterceptTest : IExample
    {
        const string tag = "NUITEST";
        private View root;
        private Window win;
        private Button btn1, btn2, btn3;
        private WebView webView1, webView2;
        private string invalidUrl = "https://test/";

        public void Activate()
        {
            win = NUIApplication.GetDefaultWindow();

            root = new View()
            {
                Size = new Size(win.Size.Width, win.Size.Height, 0),
                BackgroundColor = Color.Green,
                Layout = new LinearLayout()
                {
                    LinearOrientation = LinearLayout.Orientation.Vertical,
                    Padding = new Extents(3, 3, 3, 3),
                },
            };
            win.Add(root);

            webView1 = new WebView();
            webView1.Url = "https://m.naver.com/";
            webView1.WidthSpecification = LayoutParamPolicies.MatchParent;
            webView1.HeightSpecification = LayoutParamPolicies.MatchParent;
            root.Add(webView1);

            webView2 = new WebView();
            webView2.Url = "https://m.google.com/";
            webView2.WidthSpecification = LayoutParamPolicies.MatchParent;
            webView2.HeightSpecification = LayoutParamPolicies.MatchParent;
            root.Add(webView2);

            btn1 = new Button()
            {
                HeightSpecification = 50,
                WidthSpecification = 300,
                Text = "register intercept callback",
            };
            btn1.Clicked += (s, e) =>
            {
                webView1.Context.RegisterHttpRequestInterceptedCallback(Callback);
                // only this Callback2 will be invoked for all created WebViews, because the Context is global(Callback will be ignored).
                webView2.Context.RegisterHttpRequestInterceptedCallback(Callback2);
            };
            root.Add(btn1);

            btn2 = new Button()
            {
                HeightSpecification = 50,
                WidthSpecification = 300,
                Text = "WebView1 load invalid url",
            };
            btn2.Clicked += (s, e) =>
            {
                webView1.LoadUrl(invalidUrl);
            };
            root.Add(btn2);

            btn3 = new Button()
            {
                HeightSpecification = 50,
                WidthSpecification = 300,
                Text = "WebView2 load invalid url",
            };
            btn3.Clicked += (s, e) =>
            {
                webView2.LoadUrl(invalidUrl);
            };
            root.Add(btn3);

        }

        private void Callback(WebHttpRequestInterceptor interceptor)
        {
            tlog.Debug(tag, $"callback: http request intercepted start, Url: {interceptor.Url}");

            //interceptor.Ignore();
            if (interceptor.Url.Equals(invalidUrl))
            {
                byte[] bData = Encoding.UTF8.GetBytes("<html><body><img src='test.jpg'></body></html>");
                interceptor.SetResponseStatus(200, "OK");
                interceptor.AddResponseHeader("Content-Type", "text/html; charset=UTF-8");
                interceptor.AddResponseHeader("Content-Length", bData.Length.ToString());
                interceptor.SetResponseBody(bData);
                tlog.Debug(tag, $"http request intercepted set response body end");
            }
            else if (interceptor.Url.Equals($"{invalidUrl}test.jpg"))
            {
                string path = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "soundcloud.png";
                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] bData = new byte[1024];
                    while (fs.Read(bData, 0, bData.Length) > 0)
                    {
                        interceptor.WriteResponseChunk(bData);
                    }
                    interceptor.WriteResponseChunk((byte[])null);
                    tlog.Debug(tag, $"http request intercepted write chunk end");
                }
            }

            if (interceptor.InterceptedWebView != null)
            {
                tlog.Debug(tag, $"http request intercepted web view is not null");
                if(webView2 == interceptor.InterceptedWebView)
                {
                    tlog.Debug(tag, $"InterceptedWebView is webView2!");
                }
                else if(webView1 == interceptor.InterceptedWebView)
                {
                    tlog.Debug(tag, $"InterceptedWebView is webView1!");
                }
                else
                {
                    tlog.Debug(tag, $"InterceptedWebView is not either webView1 or webView2");
                }
            }

            tlog.Debug(tag, $"http request intercepted end");
            tlog.Debug(tag, $"");
        }

        private void Callback2(WebHttpRequestInterceptor interceptor)
        {
            tlog.Debug(tag, $"callback2: http request intercepted start, Url: {interceptor.Url}");

            //interceptor.Ignore();
            if (interceptor.Url.Equals(invalidUrl))
            {
                byte[] bData = Encoding.UTF8.GetBytes("<html><body><img src='test.jpg'></body></html>");
                interceptor.SetResponseStatus(200, "OK");
                interceptor.AddResponseHeader("Content-Type", "text/html; charset=UTF-8");
                interceptor.AddResponseHeader("Content-Length", bData.Length.ToString());
                interceptor.SetResponseBody(bData);
                tlog.Debug(tag, $"http request intercepted set response body end");
            }
            else if (interceptor.Url.Equals($"{invalidUrl}test.jpg"))
            {
                string path = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "netflix.png";

                if (interceptor.InterceptedWebView == webView2)
                {
                    path = Tizen.Applications.Application.Current.DirectoryInfo.SharedResource + "hbo.png";
                }

                using (FileStream fs = File.OpenRead(path))
                {
                    byte[] bData = new byte[1024];
                    while (fs.Read(bData, 0, bData.Length) > 0)
                    {
                        interceptor.WriteResponseChunk(bData);
                    }
                    interceptor.WriteResponseChunk((byte[])null);
                    tlog.Debug(tag, $"http request intercepted write chunk end");
                }
            }

            if (interceptor.InterceptedWebView != null)
            {
                tlog.Debug(tag, $"http request intercepted web view is not null");
                if (webView2 == interceptor.InterceptedWebView)
                {
                    tlog.Debug(tag, $"InterceptedWebView is webView2!");
                }
                else if (webView1 == interceptor.InterceptedWebView)
                {
                    tlog.Debug(tag, $"InterceptedWebView is webView1!");
                }
                else
                {
                    tlog.Debug(tag, $"InterceptedWebView is not either webView1 or webView2");
                }
            }

            tlog.Debug(tag, $"http request intercepted end");
            tlog.Debug(tag, $"");
        }

        public void Deactivate()
        {
            btn3.Unparent();
            btn2.Unparent();
            btn1.Unparent();
            webView2.Unparent();
            webView1.Unparent();
            root.Unparent();

            btn3.Dispose();
            btn2.Dispose();
            btn1.Dispose();
            webView2.Dispose();
            webView1.Dispose();
            root.Dispose();
        }
    }
}
