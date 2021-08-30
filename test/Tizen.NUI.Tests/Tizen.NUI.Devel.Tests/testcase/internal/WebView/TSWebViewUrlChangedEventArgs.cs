using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewUrlChangedEventArgs")]
    public class InternalWebViewUrlChangedEventArgsTest
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
        [Description("WebViewUrlChangedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewUrlChangedEventArgs.WebViewUrlChangedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewUrlChangedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewUrlChangedEventArgsConstructor START");

            var testingTarget = new WebViewUrlChangedEventArgs(url);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewUrlChangedEventArgs>(testingTarget, "Should return WebViewUrlChangedEventArgs instance.");

            tlog.Debug(tag, $"WebViewUrlChangedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewUrlChangedEventArgs NewPageUrl .")]
        [Property("SPEC", "Tizen.NUI.WebViewUrlChangedEventArgs.NewPageUrl A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewUrlChangedEventArgsNewPageUrl()
        {
            tlog.Debug(tag, $"WebViewUrlChangedEventArgsNewPageUrl START");

            var testingTarget = new WebViewUrlChangedEventArgs(url);
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<WebViewUrlChangedEventArgs>(testingTarget, "Should return WebViewUrlChangedEventArgs instance.");

            tlog.Debug(tag, "NewPageUrl : " + testingTarget.NewPageUrl);

            tlog.Debug(tag, $"WebViewUrlChangedEventArgsNewPageUrl END (OK)");
        }
    }
}
