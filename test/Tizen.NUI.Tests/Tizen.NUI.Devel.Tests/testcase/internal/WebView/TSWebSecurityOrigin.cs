using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebSecurityOrigin")]
    public class InternalWebSecurityOriginTest
    {
        private const string tag = "NUITEST";
        private string url = Tizen.Applications.Application.Current.DirectoryInfo.Resource + "picture.png";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

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
        [Description("WebSecurityOrigin constructor.")]
        [Property("SPEC", "Tizen.NUI.WebSecurityOrigin.WebSecurityOrigin C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSecurityOriginConstructor()
        {
            tlog.Debug(tag, $"WebSecurityOriginConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebSecurityOrigin(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebSecurityOrigin>(testingTarget, "Should return WebSecurityOrigin instance.");

                testingTarget.Dispose();
            }
                
            tlog.Debug(tag, $"WebSecurityOriginConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebSecurityOrigin getCPtr.")]
        [Property("SPEC", "Tizen.NUI.WebSecurityOrigin.getCPtr M")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebSecurityOriginGetCPtr()
        {
            tlog.Debug(tag, $"WebSecurityOriginGetCPtr START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebSecurityOrigin(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebSecurityOrigin>(testingTarget, "Should return WebSecurityOrigin instance.");

                var result = WebSecurityOrigin.getCPtr(testingTarget);
                tlog.Debug(tag, "getCPtr : " + result);

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebSecurityOriginGetCPtr END (OK)");
        }
    }
}
