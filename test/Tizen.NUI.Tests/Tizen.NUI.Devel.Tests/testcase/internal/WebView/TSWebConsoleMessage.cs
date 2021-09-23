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
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebConsoleMessage : WebConsoleMessage
        {
            public MyWebConsoleMessage(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

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
        [Description("WebConsoleMessage constructor.")]
        [Property("SPEC", "Tizen.NUI.WebConsoleMessage.WebConsoleMessage C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebConsoleMessageConstructor()
        {
            tlog.Debug(tag, $"WebConsoleMessageConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebConsoleMessage(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebConsoleMessage>(testingTarget, "Should return WebConsoleMessage instance.");

                testingTarget.Dispose();
            }

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

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.ConsoleMessageReceived += OnConsoleMessageReceived;
            NUIApplication.GetDefaultWindow().Add(testingTarget);

            testingTarget.LoadUrl("https://www.youtube.com");
     
            await Task.Delay(60000);
            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebConsoleMessageSource END (OK)");
        }

        private void OnConsoleMessageReceived(object sender, WebViewConsoleMessageReceivedEventArgs e)
        {
            tlog.Info(tag, $"console message, Source: {e.ConsoleMessage.Source}");
            tlog.Info(tag, $"console message, Line: {e.ConsoleMessage.Line}");
            tlog.Info(tag, $"console message, Level: {e.ConsoleMessage.Level}");
            tlog.Info(tag, $"console message, Text: {e.ConsoleMessage.Text}");
        }
    }
}
