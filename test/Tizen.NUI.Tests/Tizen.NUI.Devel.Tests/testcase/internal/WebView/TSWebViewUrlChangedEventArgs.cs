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
    [Description("internal/WebView/WebViewUrlChangedEventArgs")]
    public class InternalWebViewUrlChangedEventArgsTest
    {
        private const string tag = "NUITEST";
        private string url = $"file://{Applications.Application.Current.DirectoryInfo.Resource}webview/index.html";
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
        [Description("WebViewUrlChangedEventArgs NewPageUrl .")]
        [Property("SPEC", "Tizen.NUI.WebViewUrlChangedEventArgs.NewPageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebViewUrlChangedEventArgsNewPageUrl()
        {
            tlog.Debug(tag, $"WebViewUrlChangedEventArgsNewPageUrl START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);

            EventHandler<WebViewUrlChangedEventArgs> onUrlChange = (s, e) =>
            {
                Assert.IsNotNull(e, "null handle");
                Assert.IsInstanceOf<WebViewUrlChangedEventArgs>(e, "Should return WebViewUrlChangedEventArgs instance.");
                Assert.IsNotNull(e.NewPageUrl);

                tcs.TrySetResult(true);
            };
            webView.UrlChanged += onUrlChange;

            webView.LoadUrl(url);
            var result = await tcs.Task;
            Assert.IsTrue(result, "UrlChanged event should be invoked");

            webView.UrlChanged -= onUrlChange;

            tlog.Debug(tag, $"WebViewUrlChangedEventArgsNewPageUrl END (OK)");
        }
    }
}
