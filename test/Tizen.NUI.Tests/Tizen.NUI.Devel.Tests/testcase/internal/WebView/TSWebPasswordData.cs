using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests 
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebPasswordData")]
    public class InternalWebPasswordDataTest
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
        [Description("WebPasswordData constructor.")]
        [Property("SPEC", "Tizen.NUI.WebPasswordData.WebPasswordData C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPasswordDataConstructor()
        {
            tlog.Debug(tag, $"WebPasswordDataConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebPasswordData(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPasswordData>(testingTarget, "Should return WebPasswordData instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPasswordDataConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebPasswordData FingerprintUsed.")]
        [Property("SPEC", "Tizen.NUI.WebPasswordData.FingerprintUsed A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebPasswordDataFingerprintUsed()
        {
            tlog.Debug(tag, $"WebPasswordDataFingerprintUsed START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                webview.LoadUrl("http://www.baidu.com");

                var testingTarget = new WebPasswordData(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebPasswordData>(testingTarget, "Should return WebPasswordData instance.");

                var result = testingTarget.FingerprintUsed;
                tlog.Debug(tag, "FingerprintUsed : " + result);

                webview.ClearCache();
                webview.ClearCookies();

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebPasswordDataFingerprintUsed END (OK)");
        }
    }
}
