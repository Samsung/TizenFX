using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewConsoleMessageReceivedEventArgs")]
    public class InternalWebViewConsoleMessageReceivedEventArgsTest
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
        [Description("WebViewConsoleMessageReceivedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewConsoleMessageReceivedEventArgs.WebViewConsoleMessageReceivedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConsoleMessageReceivedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewConsoleMessageReceivedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebConsoleMessage message = new WebConsoleMessage(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewConsoleMessageReceivedEventArgs(message);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewConsoleMessageReceivedEventArgs>(testingTarget, "Should return WebViewConsoleMessageReceivedEventArgs instance.");

                message.Dispose();
            }

            tlog.Debug(tag, $"WebViewConsoleMessageReceivedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewConsoleMessageReceivedEventArgs ConsoleMessage.")]
        [Property("SPEC", "Tizen.NUI.WebViewConsoleMessageReceivedEventArgs.ConsoleMessage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewConsoleMessageReceivedEventArgsConsoleMessage()
        {
            tlog.Debug(tag, $"WebViewConsoleMessageReceivedEventArgsConsoleMessage START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebConsoleMessage message = new WebConsoleMessage(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewConsoleMessageReceivedEventArgs(message);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewConsoleMessageReceivedEventArgs>(testingTarget, "Should return WebViewConsoleMessageReceivedEventArgs instance.");

                var result = testingTarget.ConsoleMessage;
                tlog.Debug(tag, "ConsoleMessage : " + result);

                message.Dispose();
            }

            tlog.Debug(tag, $"WebViewConsoleMessageReceivedEventArgsConsoleMessage END (OK)");
        }
    }
}
