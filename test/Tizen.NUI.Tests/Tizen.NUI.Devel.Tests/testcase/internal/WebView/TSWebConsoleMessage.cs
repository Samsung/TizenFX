using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;
using System.Threading.Tasks;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebConsoleMessage")]
    public class InternalWebConsoleMessageTest
    {
        private const string tag = "NUITEST";
        private string urlForConsoleMessageTest = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/console_info.html";
        private BaseComponents.WebView webView = null;

        [SetUp]
        public void Init()
        {
            webView = new BaseComponents.WebView()
            {
                Size = new Size(150, 100),
            };
            tlog.Info(tag, "Init() is called!");
        }

        [TearDown]
        public void Destroy()
        {
            tlog.Info(tag, "Destroy() is being called!");
            webView.Dispose();
            tlog.Info(tag, "Destroy() is called!");
        }

        [Test]
        [Category("P1")]
        [Description("WebConsoleMessage constructor.")]
        [Property("SPEC", "Tizen.NUI.WebConsoleMessage.WebConsoleMessage C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebConsoleMessageConstructor()
        {
            tlog.Debug(tag, $"WebConsoleMessageConstructor START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewConsoleMessageReceivedEventArgs> onConsoleMessageReceive = (s, e) =>
            {
                Assert.IsNotNull(e.ConsoleMessage, "null handle");
                Assert.IsInstanceOf<WebConsoleMessage>(e.ConsoleMessage, "Should return WebConsoleMessage instance.");
                tcs.TrySetResult(true);
            };
            webView.ConsoleMessageReceived += onConsoleMessageReceive;

            webView.LoadUrl(urlForConsoleMessageTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ConsoleMessageReceived event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ConsoleMessageReceived -= onConsoleMessageReceive;

            tlog.Debug(tag, $"WebConsoleMessageConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebConsoleMessage Source.")]
        [Property("SPEC", "Tizen.NUI.WebConsoleMessage.Source A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebConsoleMessageSource()
        {
            tlog.Debug(tag, $"WebConsoleMessageSource START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewConsoleMessageReceivedEventArgs> onConsoleMessageReceive = (s, e) =>
            {
                tlog.Info(tag, $"console message, Source: {e.ConsoleMessage.Source}");
                tlog.Info(tag, $"console message, Line: {e.ConsoleMessage.Line}");
                tlog.Info(tag, $"console message, Level: {e.ConsoleMessage.Level}");
                tlog.Info(tag, $"console message, Text: {e.ConsoleMessage.Text}");

                tcs.TrySetResult(true);
            };
            webView.ConsoleMessageReceived += onConsoleMessageReceive;

            webView.LoadUrl(urlForConsoleMessageTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ConsoleMessageReceived event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ConsoleMessageReceived -= onConsoleMessageReceive;

            tlog.Debug(tag, $"WebConsoleMessageSource END (OK)");
        }
    }
}
