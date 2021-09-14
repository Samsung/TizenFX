using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewScrollEdgeReachedEventArgs")]
    public class InternalWebViewScrollEdgeReachedEventArgsTest
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
        [Description("WebViewScrollEdgeReachedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewScrollEdgeReachedEventArgs.WebViewScrollEdgeReachedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollEdgeReachedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewScrollEdgeReachedEventArgsConstructor START");

            var testingTarget = new WebViewScrollEdgeReachedEventArgs(WebViewScrollEdgeReachedEventArgs.Edge.Right);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewScrollEdgeReachedEventArgs>(testingTarget, "Should return WebViewScrollEdgeReachedEventArgs instance.");

            tlog.Debug(tag, $"WebViewScrollEdgeReachedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewScrollEdgeReachedEventArgs ScrollEdge.")]
        [Property("SPEC", "Tizen.NUI.WebViewScrollEdgeReachedEventArgs.ScrollEdge A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewScrollEdgeReachedEventArgsScrollEdge()
        {
            tlog.Debug(tag, $"WebViewScrollEdgeReachedEventArgsScrollEdge START");

            var testingTarget = new WebViewScrollEdgeReachedEventArgs(WebViewScrollEdgeReachedEventArgs.Edge.Right);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewScrollEdgeReachedEventArgs>(testingTarget, "Should return WebViewScrollEdgeReachedEventArgs instance.");

            var result = testingTarget.ScrollEdge;
            tlog.Debug(tag, "ScrollEdge : " + result);

            tlog.Debug(tag, $"WebViewScrollEdgeReachedEventArgsScrollEdge END (OK)");
        }
    }
}
