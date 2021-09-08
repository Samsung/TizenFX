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
        [Description("WebViewResponsePolicyDecidedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewResponsePolicyDecidedEventArgs.WebViewResponsePolicyDecidedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewResponsePolicyDecidedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewResponsePolicyDecidedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPolicyDecisionMaker maker = new WebPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewResponsePolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewResponsePolicyDecidedEventArgs>(testingTarget, "Should return WebViewResponsePolicyDecidedEventArgs instance.");

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewResponsePolicyDecidedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewResponsePolicyDecidedEventArgs ResponsePolicyDecisionMaker.")]
        [Property("SPEC", "Tizen.NUI.WebViewResponsePolicyDecidedEventArgs.ResponsePolicyDecisionMaker A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewResponsePolicyDecidedEventArgsResponsePolicyDecisionMaker()
        {
            tlog.Debug(tag, $"WebViewResponsePolicyDecidedEventArgsResponsePolicyDecisionMaker  START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebPolicyDecisionMaker maker = new WebPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewResponsePolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewResponsePolicyDecidedEventArgs>(testingTarget, "Should return WebViewResponsePolicyDecidedEventArgs instance.");

                var result = testingTarget.ResponsePolicyDecisionMaker;
                tlog.Debug(tag, "ResponsePolicyDecisionMaker : " + result);

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewResponsePolicyDecidedEventArgsResponsePolicyDecisionMaker  END (OK)");
        }
    }
}
