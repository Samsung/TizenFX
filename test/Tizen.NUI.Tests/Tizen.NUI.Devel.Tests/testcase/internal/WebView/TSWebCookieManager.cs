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
    [Description("internal/WebView/WebCookieManager")]
    public class InternalWebCookieManagerTest
    {
        private const string tag = "NUITEST";
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
        [Description("WebCookieManager CookieChanged.")]
        [Property("SPEC", "Tizen.NUI.WebCookieManager.CookieChanged A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCookieManagerCookieChanged()
        {
            tlog.Debug(tag, $"WebSecurityOriginListConstructor START");

            var webview = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(webview, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(webview, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            var testingTarget = webview.CookieManager;
            Assert.IsInstanceOf<WebCookieManager>(testingTarget, "Should return WebCookieManager instance.");

            testingTarget.CookieChanged += OnCookieChanged;

            webview.LoadUrl("http://www.baidu.com/");

            await Task.Delay(10000);

            testingTarget.CookieChanged -= OnCookieChanged;

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebSecurityOriginListConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebCookieManager SetPersistentStorage.")]
        [Property("SPEC", "Tizen.NUI.WebCookieManager.SetPersistentStorage A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRW")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebCookieManagerSetPersistentStorage()
        {
            tlog.Debug(tag, $"WebCookieManagerSetPersistentStorage START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = webview.CookieManager;
                Assert.IsInstanceOf<WebCookieManager>(testingTarget, "Should return WebCookieManager instance.");

                try
                {
                    testingTarget.SetPersistentStorage("/", WebCookieManager.CookiePersistentStorageType.Text);
                }
                catch (Exception e)
                {
                    tlog.Debug(tag, e.Message.ToString());
                    Assert.Fail("Caught Exception : Failed!");
                }

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebCookieManagerSetPersistentStorage END (OK)");
        }

        private void OnCookieChanged(object sender, EventArgs e) { }
    }
}
