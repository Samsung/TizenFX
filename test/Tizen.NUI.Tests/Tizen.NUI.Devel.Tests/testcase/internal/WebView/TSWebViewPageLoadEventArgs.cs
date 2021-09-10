using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;


namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewPageLoadEventArgs")]
    public class InternalWebViewPageLoadEventArgsTest
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
        [Description("WebViewPageLoadEventArgs WebView.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadEventArgs.WebView A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadEventArgsWebView()
        {
            tlog.Debug(tag, $"WebViewPageLoadEventArgsWebView START");

            var testingTarget = new WebViewPageLoadEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewPageLoadEventArgs>(testingTarget, "Should return WebViewPageLoadEventArgs instance.");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                testingTarget.WebView = webview;
                tlog.Debug(tag, "WebView : " + testingTarget.WebView);
            }

            tlog.Debug(tag, $"WebViewPageLoadEventArgsWebView END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewPageLoadEventArgs PageUrl.")]
        [Property("SPEC", "Tizen.NUI.WebViewPageLoadEventArgs.PageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPageLoadEventArgsPageUrl()
        {
            tlog.Debug(tag, $"WebViewPageLoadEventArgsPageUrl START");

            var testingTarget = new WebViewPageLoadEventArgs();
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewPageLoadEventArgs>(testingTarget, "Should return WebViewPageLoadEventArgs instance.");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                testingTarget.PageUrl = "http://www.baidu.com";
                tlog.Debug(tag, "PageUrl : " + testingTarget.PageUrl);
            }

            tlog.Debug(tag, $"WebViewPageLoadEventArgsPageUrl END (OK)");
        }
    }
}
