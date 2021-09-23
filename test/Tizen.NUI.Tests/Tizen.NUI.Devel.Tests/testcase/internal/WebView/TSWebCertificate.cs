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
    [Description("internal/WebView/WebCertificate")]
    public class InternalWebCertificateTest
    {
        private const string tag = "NUITEST";
        private static string[] runtimeArgs = { "Tizen.NUI.Devel.Tests", "--enable-dali-window", "--enable-spatial-navigation" };
        private const string USER_AGENT = "Mozilla/5.0 (SMART-TV; Linux; Tizen 6.0) AppleWebKit/537.36 (KHTML, like Gecko) SamsungBrowser/4.0 Chrome/76.0.3809.146 TV Safari/537.36";

        internal class MyWebCertificate : WebCertificate
        {
            public MyWebCertificate(global::System.IntPtr cPtr, bool cMemoryOwn) : base(cPtr, cMemoryOwn)
            { }

            public void OnReleaseSwigCPtr(global::System.Runtime.InteropServices.HandleRef swigCPtr)
            {
                base.ReleaseSwigCPtr(swigCPtr);
            }
        }

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
        [Description("WebCertificate constructor.")]
        [Property("SPEC", "Tizen.NUI.WebCertificate.WebCertificate C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebCertificateConstructor()
        {
            tlog.Debug(tag, $"WebCertificateConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                var testingTarget = new WebCertificate(webview.SwigCPtr.Handle, false);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebCertificate>(testingTarget, "Should return WebCertificate instance.");

                testingTarget.Dispose();
            }

            tlog.Debug(tag, $"WebCertificateConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebCertificate IsFromMainFrame.")]
        [Property("SPEC", "Tizen.NUI.WebCertificate.IsFromMainFrame A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public async Task WebCertificateIsFromMainFrame()
        {
            tlog.Debug(tag, $"WebCertificateIsFromMainFrame START");

            var testingTarget = new Tizen.NUI.BaseComponents.WebView(runtimeArgs)
            {
                Size = new Size(500, 200),
                UserAgent = USER_AGENT
            };
            Assert.IsNotNull(testingTarget, "null handle");
            Assert.IsInstanceOf<Tizen.NUI.BaseComponents.WebView>(testingTarget, "Should return Tizen.NUI.BaseComponents.WebView instance.");

            testingTarget.SslCertificateChanged += OnSslCertificateChanged;
            NUIApplication.GetDefaultWindow().Add(testingTarget);
            
            testingTarget.LoadUrl("http://www.baidu.com");
            await Task.Delay(10000);

            testingTarget.ClearCache();
            testingTarget.ClearCookies();
            NUIApplication.GetDefaultWindow().Remove(testingTarget);

            testingTarget.Dispose();
            tlog.Debug(tag, $"WebCertificateIsFromMainFrame END (OK)");
        }

        private void OnSslCertificateChanged(object sender, WebViewCertificateReceivedEventArgs e)
        {
            tlog.Info(tag, $"ssl certificate changed, PemData: {e.Certificate.PemData}");
            tlog.Info(tag, $"ssl certificate changed, IsFromMainFrame: {e.Certificate.IsFromMainFrame}");
            tlog.Info(tag, $"ssl certificate changed, IsContextSecure: {e.Certificate.IsContextSecure}");
            
            e.Certificate.Allow(false);
        }
    }
}
