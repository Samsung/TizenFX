using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewFormRepostPolicyDecidedEventArgs")]
    public class InternalWebViewFormRepostPolicyDecidedEventArgsTest
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
        [Description("WebViewFormRepostPolicyDecidedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewFormRepostPolicyDecidedEventArgs.WebViewFormRepostPolicyDecidedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewFormRepostPolicyDecidedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewFormRepostPolicyDecidedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebFormRepostPolicyDecisionMaker maker = new WebFormRepostPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewFormRepostPolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewFormRepostPolicyDecidedEventArgs>(testingTarget, "Should return WebViewFormRepostPolicyDecidedEventArgs instance.");

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewFormRepostPolicyDecidedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewFormRepostPolicyDecidedEventArgs FormRepostPolicyDecisionMaker.")]
        [Property("SPEC", "Tizen.NUI.WebViewFormRepostPolicyDecidedEventArgs.FormRepostPolicyDecisionMaker A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewFormRepostPolicyDecidedEventArgsFormRepostPolicyDecisionMaker()
        {
            tlog.Debug(tag, $"WebViewFormRepostPolicyDecidedEventArgsFormRepostPolicyDecisionMaker START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebFormRepostPolicyDecisionMaker maker = new WebFormRepostPolicyDecisionMaker(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewFormRepostPolicyDecidedEventArgs(maker);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewFormRepostPolicyDecidedEventArgs>(testingTarget, "Should return WebViewFormRepostPolicyDecidedEventArgs instance.");

                var result = testingTarget.FormRepostPolicyDecisionMaker;
                tlog.Debug(tag, "FormRepostPolicyDecisionMaker : " + result);

                maker.Dispose();
            }

            tlog.Debug(tag, $"WebViewFormRepostPolicyDecidedEventArgsFormRepostPolicyDecisionMaker END (OK)");
        }
    }
}
