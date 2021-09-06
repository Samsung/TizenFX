using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewHttpRequestInterceptedEventArgs")]
    public class InternalWebViewHttpRequestInterceptedEventArgsTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";

        [SetUp]
        public void Init()
        {
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewHttpRequestInterceptedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewHttpRequestInterceptedEventArgs.WebViewHttpRequestInterceptedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewHttpRequestInterceptedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebHttpRequestInterceptor interceptor = new WebHttpRequestInterceptor(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewHttpRequestInterceptedEventArgs(interceptor);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewHttpRequestInterceptedEventArgs>(testingTarget, "Should return WebViewHttpRequestInterceptedEventArgs instance.");

                interceptor.Dispose();
            }

            tlog.Debug(tag, $"WebViewHttpRequestInterceptedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewHttpRequestInterceptedEventArgs HttpRequestInterceptor.")]
        [Property("SPEC", "Tizen.NUI.WebViewHttpRequestInterceptedEventArgs.HttpRequestInterceptor A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewHttpRequestInterceptedEventArgsHttpRequestInterceptor()
        {
            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsHttpRequestInterceptor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebHttpRequestInterceptor interceptor = new WebHttpRequestInterceptor(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewHttpRequestInterceptedEventArgs(interceptor);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewHttpRequestInterceptedEventArgs>(testingTarget, "Should return WebViewHttpRequestInterceptedEventArgs instance.");

                var result = testingTarget.HttpRequestInterceptor;
                tlog.Debug(tag, "HttpRequestInterceptor : " + result);

                interceptor.Dispose();
            }

            tlog.Debug(tag, $"WebViewHttpRequestInterceptedEventArgsHttpRequestInterceptor END (OK)");
        }
    }
}
