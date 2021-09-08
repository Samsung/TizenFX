using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewHttpAuthRequestedEventArgs")]
    public class InternalWebViewHttpAuthRequestedEventArgsTest
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
        [Description("WebViewHttpAuthRequestedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewHttpAuthRequestedEventArgs.WebViewHttpAuthRequestedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewHttpAuthRequestedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewHttpAuthRequestedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebHttpAuthHandler handler = new WebHttpAuthHandler(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewHttpAuthRequestedEventArgs(handler);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewHttpAuthRequestedEventArgs>(testingTarget, "Should return WebViewHttpAuthRequestedEventArgs instance.");

                handler.Dispose();
            }

            tlog.Debug(tag, $"WebViewHttpAuthRequestedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewHttpAuthRequestedEventArgs HttpAuthHandler.")]
        [Property("SPEC", "Tizen.NUI.WebViewHttpAuthRequestedEventArgs.HttpAuthHandler A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewHttpRequestInterceptedEventArgsHttpAuthHandler()
        {
            tlog.Debug(tag, $"WebViewHttpRequestInterceptedEventArgsHttpAuthHandler START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebHttpAuthHandler handler = new WebHttpAuthHandler(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewHttpAuthRequestedEventArgs(handler);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewHttpAuthRequestedEventArgs>(testingTarget, "Should return WebViewHttpAuthRequestedEventArgs instance.");

                var result = testingTarget.HttpAuthHandler;
                tlog.Debug(tag, "HttpAuthHandler : " + result);

                handler.Dispose();
            }

            tlog.Debug(tag, $"WebViewHttpRequestInterceptedEventArgsHttpAuthHandler END (OK)");
        }
    }
}
