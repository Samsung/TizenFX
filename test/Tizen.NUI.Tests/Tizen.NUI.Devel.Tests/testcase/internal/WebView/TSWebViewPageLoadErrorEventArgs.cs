using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewPageLoadErrorEventArgs")]
    public class InternalWebViewPageLoadErrorEventArgsTest
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
        [Description("WebViewPageLoadErrorEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadErrorEventArgs.WebViewPageLoadErrorEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadErrorEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPageLoadError le = new WebPageLoadError(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewPageLoadErrorEventArgs(le);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewPageLoadErrorEventArgs>(testingTarget, "Should return WebViewPageLoadErrorEventArgs instance.");

                le.Dispose();
            }

            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewPageLoadErrorEventArgs PageLoadError.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadErrorEventArgs.PageLoadError A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadErrorEventArgsPageLoadError()
        {
            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsPageLoadError START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPageLoadError le = new WebPageLoadError(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewPageLoadErrorEventArgs(le);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewPageLoadErrorEventArgs>(testingTarget, "Should return WebViewPageLoadErrorEventArgs instance.");

                var result = testingTarget.PageLoadError;
                tlog.Debug(tag, "PageLoadError : " +  result);

                le.Dispose();
            }

            tlog.Debug(tag, $"WebViewPageLoadErrorEventArgsPageLoadError END (OK)");
        }
    }
}
