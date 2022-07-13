using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewResponsePolicyDecidedEventArgs")]
    public class InternalWebViewResponsePolicyDecidedEventArgsTest
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
        [Description("WebViewPolicyDecidedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewPolicyDecidedEventArgs.WebViewPolicyDecidedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPolicyDecidedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewPolicyDecidedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPolicyDecisionMaker maker = new WebPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewPolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewPolicyDecidedEventArgs>(testingTarget, "Should return WebViewPolicyDecidedEventArgs instance.");

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewPolicyDecidedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewPolicyDecidedEventArgs ResponsePolicyDecisionMaker.")]
        [Property("SPEC", "Tizen.NUI.WebViewPolicyDecidedEventArgs.ResponsePolicyDecisionMaker A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewPolicyDecidedEventArgsResponsePolicyDecisionMaker()
        {
            tlog.Debug(tag, $"WebViewPolicyDecidedEventArgsResponsePolicyDecisionMaker  START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPolicyDecisionMaker maker = new WebPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewPolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewPolicyDecidedEventArgs>(testingTarget, "Should return WebViewPolicyDecidedEventArgs instance.");

                var result = testingTarget.ResponsePolicyDecisionMaker;
                tlog.Debug(tag, "ResponsePolicyDecisionMaker : " + result);

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewPolicyDecidedEventArgsResponsePolicyDecisionMaker  END (OK)");
        }
    }
}
