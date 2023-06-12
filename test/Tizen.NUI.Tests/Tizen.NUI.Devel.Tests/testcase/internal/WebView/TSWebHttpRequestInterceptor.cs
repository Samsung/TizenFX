using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;
using System.IO;
using System.Text;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebHttpRequestInterceptor")]
    public class InternalWebHttpRequestInterceptorTest
    {
        private const string tag = "NUITEST";
        private string invalidUrl = "https://test/";
        private BaseComponents.WebView webview;

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
            webview = new BaseComponents.WebView()
            {
                Size = new Size(500, 200),
            };
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webview.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebHttpRequestInterceptor SetResponseBody.")]
        [Property("SPEC", "Tizen.NUI.WebHttpRequestInterceptor.SetResponseBody M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebHttpRequestInterceptorSetResponseBody()
        {
            tlog.Debug(tag, $"WebHttpRequestInterceptorConstructor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            WebContext.HttpRequestInterceptedCallback onRequestIntercepted = (interceptor) =>
            {
                tlog.Info(tag, $"onRequestIntercepted is called, url {interceptor.Url}.");
                if (interceptor.Url.Equals(invalidUrl))
                {
                    Assert.IsNotNull(interceptor.InterceptedWebView, "InterceptedWebView should not be null.");
                    Assert.IsNotNull(interceptor.Headers, "Headers should not be null.");

                    byte[] bData = Encoding.UTF8.GetBytes("<html><body><img src='test.jpg'></body></html>");
                    interceptor.SetResponseStatus(200, "OK");
                    interceptor.AddResponseHeader("Content-Type", "text/html; charset=UTF-8");
                    interceptor.AddResponseHeader("Content-Length", bData.Length.ToString());
                    interceptor.SetResponseBody(bData);

                    tlog.Info(tag, $"http request intercepted set response body end, {interceptor.Method}");
                }
                else if (interceptor.Url.Equals($"{invalidUrl}test.jpg"))
                {
                    string path = $"{Applications.Application.Current.DirectoryInfo.Resource}webview/tizen.png";
                    using (FileStream fs = File.OpenRead(path))
                    {
                        byte[] bData = new byte[1024];
                        while (fs.Read(bData, 0, bData.Length) > 0)
                        {
                            interceptor.WriteResponseChunk(bData);
                        }
                        interceptor.WriteResponseChunk((byte[])null);
                        tlog.Info(tag, $"http request intercepted write chunk end");
                    }
                }
                else
                {
                    tlog.Info(tag, $"http request intercepted end, url {interceptor.Url}");
                    tcs.TrySetResult(true);
                }
            };

            webview.Context.RegisterHttpRequestInterceptedCallback(onRequestIntercepted);

            webview.LoadUrl(invalidUrl);
            var result = await tcs.Task;
            Assert.IsTrue(result, "HttpAuthRequested event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.Context.RegisterHttpRequestInterceptedCallback(null);

            tlog.Debug(tag, $"WebHttpRequestInterceptorConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebHttpRequestInterceptor constructor.")]
        [Property("SPEC", "Tizen.NUI.WebHttpRequestInterceptor.Ignore M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebHttpRequestInterceptorIgnore()
        {
            tlog.Debug(tag, $"WebHttpRequestInterceptorIgnore START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            WebContext.HttpRequestInterceptedCallback onRequestIntercepted = (interceptor) =>
            {
                interceptor.Ignore();
            };

            webview.Context.RegisterHttpRequestInterceptedCallback(onRequestIntercepted);

            EventHandler<WebViewPageLoadErrorEventArgs> onLoadError = (s, e) =>
            {
                tlog.Info(tag, $"http load error!");
                tcs.TrySetResult(true);
            };
            webview.PageLoadError += onLoadError;

            webview.LoadUrl(invalidUrl);
            var result = await tcs.Task;
            Assert.IsTrue(result, "PageLoadError event should be invoked.");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webview.Context.RegisterHttpRequestInterceptedCallback(null);
            webview.PageLoadError -= onLoadError;

            tlog.Debug(tag, $"WebHttpRequestInterceptorIgnore END (OK)");
        }
    }
}
