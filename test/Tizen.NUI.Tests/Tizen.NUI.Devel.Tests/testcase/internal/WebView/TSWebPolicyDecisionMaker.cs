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
    [Description("internal/WebView/WebPolicyDecisionMaker")]
    public class InternalWebPolicyDecisionMakerTest
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
                tlog.Info(tag, $"response policy decided, Url: {e.ResponsePolicyDecisionMaker.Url}");
                tlog.Info(tag, $"response policy decided, Cookie: {e.ResponsePolicyDecisionMaker.Cookie}");
                tlog.Info(tag, $"response policy decided, PolicyDecisionType: {e.ResponsePolicyDecisionMaker.PolicyDecisionType}");
                tlog.Info(tag, $"response policy decided, ResponseMime: {e.ResponsePolicyDecisionMaker.ResponseMime}");
                tlog.Info(tag, $"response policy decided, ResponseStatusCode: {e.ResponsePolicyDecisionMaker.ResponseStatusCode}");
                tlog.Info(tag, $"response policy decided, DecisionNavigationType: {e.ResponsePolicyDecisionMaker.DecisionNavigationType}");
                tlog.Info(tag, $"response policy decided, Scheme: {e.ResponsePolicyDecisionMaker.Scheme}");
                tlog.Info(tag, $"response policy decided, MainFrame: {e.ResponsePolicyDecisionMaker.Frame.IsMainFrame}");

                if (e.ResponsePolicyDecisionMaker.Frame != null)
                {
                    tlog.Info(tag, $"response policy decided, Frame.IsMainFrame: {e.ResponsePolicyDecisionMaker.Frame.IsMainFrame}");
                }
                e.ResponsePolicyDecisionMaker.Ignore();

                tcs.TrySetResult(true);
            };
            webView.ResponsePolicyDecided += onResponsePolicyDecide;

            webView.LoadUrl(urlForResponsePolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ResponsePolicyDecided event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ResponsePolicyDecided -= onResponsePolicyDecide;

            tlog.Debug(tag, $"WebPolicyDecisionMakerUrl END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPolicyDecisionMaker Url.")]
        [Property("SPEC", "Tizen.NUI.WebPolicyDecisionMaker.Suspend M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPolicyDecisionMakerSuspend()
        {
            tlog.Debug(tag, $"WebPolicyDecisionMakerIgnore START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPolicyDecidedEventArgs> onResponsePolicyDecide = (s, e) =>
            {
                e.ResponsePolicyDecisionMaker.Suspend();
                tcs.TrySetResult(true);
            };
            webView.ResponsePolicyDecided += onResponsePolicyDecide;

            webView.LoadUrl(urlForResponsePolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ResponsePolicyDecided event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ResponsePolicyDecided -= onResponsePolicyDecide;

            tlog.Debug(tag, $"WebPolicyDecisionMakerIgnore END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPolicyDecisionMaker Url.")]
        [Property("SPEC", "Tizen.NUI.WebPolicyDecisionMaker.Use M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebPolicyDecisionMakerUse()
        {
            tlog.Debug(tag, $"ResponsePolicyDecided START");

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>(false);
            EventHandler<WebViewPolicyDecidedEventArgs> onResponsePolicyDecide = (s, e) =>
            {
                e.ResponsePolicyDecisionMaker.Use();
                tcs.TrySetResult(true);
            };
            webView.ResponsePolicyDecided += onResponsePolicyDecide;

            webView.LoadUrl(urlForResponsePolicyTest);
            var result = await tcs.Task;
            Assert.IsTrue(result, "ResponsePolicyDecided event should be invoked");

            // Make current thread (CPU) sleep...
            await Task.Delay(1);

            webView.ResponsePolicyDecided -= onResponsePolicyDecide;

            tlog.Debug(tag, $"WebPolicyDecisionMakerUse END (OK)");
        }
    }
}
