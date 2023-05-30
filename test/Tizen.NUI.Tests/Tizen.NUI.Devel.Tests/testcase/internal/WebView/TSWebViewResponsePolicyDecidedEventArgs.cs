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
    [Description("internal/WebView/WebViewResponsePolicyDecidedEventArgs")]
    public class InternalWebViewResponsePolicyDecidedEventArgsTest
    {
        private const string tag = "NUITEST";
        private string urlForResponsePolicyTest = "http://www.samsung.com";
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
        [Description("WebPolicyDecisionMaker Url.")]
        [Property("SPEC", "Tizen.NUI.WebPolicyDecisionMaker.Ignore M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPolicyDecisionMakerIgnore()
        {
            tlog.Debug(tag, $"ResponsePolicyDecided START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPolicyDecidedEventArgs> onResponsePolicyDecide = (s, e) =>
            {
                Assert.IsNotNull(e.ResponsePolicyDecisionMaker, "null handle");
                Assert.IsInstanceOf<WebPolicyDecisionMaker>(e.ResponsePolicyDecisionMaker, "Should return WebViewPolicyDecidedEventArgs instance.");

                e.ResponsePolicyDecisionMaker.Ignore();

                tcs.TrySetResult(true);
            };
            webView.ResponsePolicyDecided += onResponsePolicyDecide;

            webView.LoadUrl(urlForResponsePolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ResponsePolicyDecided event should be invoked");

            webView.ResponsePolicyDecided -= onResponsePolicyDecide;

            tlog.Debug(tag, $"WebPolicyDecisionMakerUrl END (OK)");
        }
    }
}
