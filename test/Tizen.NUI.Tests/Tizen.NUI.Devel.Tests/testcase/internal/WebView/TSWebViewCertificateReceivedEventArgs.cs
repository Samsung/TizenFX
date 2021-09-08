using global::System;
using NUnit.Framework;
using NUnit.Framework.TUnit;
using Tizen.NUI.Components;
using Tizen.NUI.BaseComponents;

namespace Tizen.NUI.Devel.Tests
{
    using tlog = Tizen.Log;

    [TestFixture]
    [Description("internal/WebView/WebViewCertificateReceivedEventArgs")]
    public class InternalWebViewCertificateReceivedEventArgsTest
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
        [Description("WebViewCertificateReceivedEventArgs constructor.")]
        [Property("SPEC", "Tizen.NUI.WebViewCertificateReceivedEventArgs.WebViewCertificateReceivedEventArgs C")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "CONSTR")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCertificateReceivedEventArgsConstructor()
        {
            tlog.Debug(tag, $"WebViewCertificateReceivedEventArgsConstructor START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebCertificate certificate = new WebCertificate(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewCertificateReceivedEventArgs(certificate);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewCertificateReceivedEventArgs>(testingTarget, "Should return WebViewCertificateReceivedEventArgs instance.");

                certificate.Dispose();
            }

            tlog.Debug(tag, $"WebViewCertificateReceivedEventArgsConstructor END (OK)");
        }

        [Test]
        [Category("P1")]
        [Description("WebViewCertificateReceivedEventArgs Certificate .")]
        [Property("SPEC", "Tizen.NUI.WebViewCertificateReceivedEventArgs.Certificate  A")]
        [Property("SPEC_URL", "-")]
        [Property("CRITERIA", "PRO")]
        [Property("COVPARAM", "")]
        [Property("AUTHOR", "guowei.wang@samsung.com")]
        public void WebViewCertificateReceivedEventArgsCertificate()
        {
            tlog.Debug(tag, $"WebViewCertificateReceivedEventArgsCertificate START");

            using (Tizen.NUI.BaseComponents.WebView webview = new Tizen.NUI.BaseComponents.WebView("Shanghai", "Asia/Shanghai"))
            {
                WebCertificate certificate = new WebCertificate(webview.SwigCPtr.Handle, false);

                var testingTarget = new WebViewCertificateReceivedEventArgs(certificate);
                Assert.IsNotNull(testingTarget, "null handle");
                Assert.IsInstanceOf<WebViewCertificateReceivedEventArgs>(testingTarget, "Should return WebViewCertificateReceivedEventArgs instance.");

                var result = testingTarget.Certificate;
                tlog.Debug(tag, "Certificate : " + result);

                certificate.Dispose();
            }

            tlog.Debug(tag, $"WebViewCertificateReceivedEventArgsCertificate END (OK)");
        }
    }
}
